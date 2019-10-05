using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Playbook_Editor
{
    public partial class frmPlaybook : Form
    {
        #region Variables

        private Point mouseLocation, mousePos;
        private string DBfileDir;
        private int OpenIndex;
        private bool BigEndian = false;
        private bool FBChunks = false;
        private string OpenFileDialogTMP = "";
        private Image blankField, gImage;
        private DataTable dtPLYS = new DataTable();
        private List<TableNames> TableNames;
        private List<CPFM> Formations;
        private List<SETL> SubFormations;
        private List<PBPL> PBPL;
        private List<PLPD> PLPD;
        private List<PLRD> PLRD;
        public List<PLYS> PLYS;
        private List<SETP> SETP;
        private List<SETG> SETG;
        private List<SGFF> SGFF;
        private List<PSAL> PSLO;
        private List<PSAL> PSLD;
        private List<PLRR> PSAL_PLRR_ARTL;
        public PLAY Play;
        private Point LOS;
        private bool flag_cell_edited;
        private int currentDGVRow = 0;
        private int currentDGVCol = 0;

        #endregion

        public frmPlaybook()
        {
            InitializeComponent();

            blankField = picPlay.Image;

            LOS = new Point((int)(picPlay.Width / 2), (int)(picPlay.Height / 1.2));
            mnuPlaybook.Renderer = new MyRenderer();
        }

        #region Title Bar

        private void btn_Min_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btn_Max_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Close_MouseEnter(object sender, EventArgs e)
        {
            btn_Close.Image = ((Image)(Properties.Resources.btn_close_hover));
        }

        private void btn_Close_MouseLeave(object sender, EventArgs e)
        {
            btn_Close.Image = ((Image)(Properties.Resources.btn_close));
        }

        private void btn_Min_MouseEnter(object sender, EventArgs e)
        {
            btn_Min.Image = ((Image)(Properties.Resources.btn_min_hover));
        }

        private void btn_Min_MouseLeave(object sender, EventArgs e)
        {
            btn_Min.Image = ((Image)(Properties.Resources.btn_min));
        }

        private void btn_Max_MouseEnter(object sender, EventArgs e)
        {
            btn_Max.Image = ((Image)(Properties.Resources.btn_max_hover));
        }

        private void btn_Max_MouseLeave(object sender, EventArgs e)
        {
            btn_Max.Image = ((Image)(Properties.Resources.btn_max));
        }

        private void mnuPlaybook_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void mnuPlaybook_MouseMove(object sender, MouseEventArgs e)
        {
            while (e.Button == MouseButtons.Left && WindowState == FormWindowState.Normal)
            {
                mousePos = MousePosition;
                mousePos.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePos;
                if (MousePosition.Y < 1)
                {
                    WindowState = FormWindowState.Maximized;
                }
                break;
            }
        }

        private void mnuPlaybook_DoubleClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                CenterToScreen();
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        #endregion

        #region Menu/Context Strips

        private void mnuFile_Open_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "DB Files | *.db";
            openFileDialog1.FileName = "";

            DialogResult result = openFileDialog1.ShowDialog();
            if (!(result == DialogResult.OK) || openFileDialog1.FileName == "")
            {
                return;
            }

            BigEndian = false;
            FBChunks = false;
            CheckDB(openFileDialog1.FileName);

            OpenIndex = TDB.TDBOpen(openFileDialog1.FileName);

            //store the folder where the DB file is located
            DBfileDir = openFileDialog1.FileName.Substring(0, openFileDialog1.FileName.LastIndexOf('\\'));

            if (OpenIndex == -1)
            {
                MessageBox.Show("Unable to open the database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                lblFileName.Text = openFileDialog1.SafeFileName;
                LoadDB();
                mnuFile_Save.Enabled = true;
            }
        }

        private void mnuFile_Save_Click(object sender, EventArgs e)
        {
            //saveFileDialog1.Filter = "DB Files | *.db";
            //saveFileDialog1.FileName = "";

            //DialogResult result = saveFileDialog1.ShowDialog();
            //if (!(result == DialogResult.OK) || saveFileDialog1.FileName == "")
            //{
            //    return;
            //}

            //if (OpenIndex == -1)
            //{
            //    MessageBox.Show("Unable to open the database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else
            //{
            UpdateDB();
            SaveDB();
            MessageBox.Show("Playbook saved", "Save Playbook");
            //}          
        }

        private void mnuFile_Exit_Click(object sender, EventArgs e)
        {
            if (Application.MessageLoop)
            {
                // WinForms app
                Application.Exit();
            }
            else
            {
                // Console app
                Environment.Exit(1);
            }
        }

        private void mnuTools_PSALVisualizer_Click(object sender, EventArgs e)
        {
            frmPSALVisualizer PSAL_Visualizer = new frmPSALVisualizer();
            PSAL_Visualizer.ShowDialog();
        }

        private void mnuOptions_Field_Default_Click(object sender, EventArgs e)
        {
            picPlay.Image = ((Image)(Properties.Resources.field_blank_resized));
            blankField = picPlay.Image;
            mnuOptions_Field_Default.Checked = true;
            mnuOptions_Field_Brown.Checked = false;
            mnuOptions_Field_Green.Checked = false;
            mnuOptions_Field_Dark.Checked = false;
            mnuOptions_Field_Transparent.Checked = false;
            if (!(Play.PBPL == null)) UpdatePlay(Play);
        }

        private void mnuOptions_Field_Brown_Click(object sender, EventArgs e)
        {
            picPlay.Image = ((Image)(Properties.Resources.field_blank_resized_dead));
            blankField = picPlay.Image;
            mnuOptions_Field_Default.Checked = false;
            mnuOptions_Field_Brown.Checked = true;
            mnuOptions_Field_Green.Checked = false;
            mnuOptions_Field_Dark.Checked = false;
            mnuOptions_Field_Transparent.Checked = false;
            if (!(Play.PBPL == null)) UpdatePlay(Play);
        }

        private void mnuOptions_Field_Green_Click(object sender, EventArgs e)
        {
            picPlay.Image = ((Image)(Properties.Resources.field_blank_resized_green));
            blankField = picPlay.Image;
            mnuOptions_Field_Default.Checked = false;
            mnuOptions_Field_Brown.Checked = false;
            mnuOptions_Field_Green.Checked = true;
            mnuOptions_Field_Dark.Checked = false;
            mnuOptions_Field_Transparent.Checked = false;
            if (!(Play.PBPL == null)) UpdatePlay(Play);
        }

        private void mnuOptions_Field_Dark_Click(object sender, EventArgs e)
        {
            picPlay.Image = ((Image)(Properties.Resources.field_blank_resized_Desaturated));
            blankField = picPlay.Image;
            mnuOptions_Field_Default.Checked = false;
            mnuOptions_Field_Brown.Checked = false;
            mnuOptions_Field_Green.Checked = false;
            mnuOptions_Field_Dark.Checked = true;
            mnuOptions_Field_Transparent.Checked = false;
            if (!(Play.PBPL == null)) UpdatePlay(Play);
        }

        private void mnuOptions_Field_Transparent_Click(object sender, EventArgs e)
        {
            picPlay.Image = ((Image)(Properties.Resources.field_blank_lines));
            blankField = picPlay.Image;
            mnuOptions_Field_Default.Checked = false;
            mnuOptions_Field_Brown.Checked = false;
            mnuOptions_Field_Green.Checked = false;
            mnuOptions_Field_Dark.Checked = false;
            mnuOptions_Field_Transparent.Checked = true;
            if (!(Play.PBPL == null)) UpdatePlay(Play);
        }

        #endregion

        #region UI Interaction

        private void frmPlaybook_Click(object sender, EventArgs e)
        {
            picPlay.Focus();
        }

        private void picPlay_Click(object sender, EventArgs e)
        {
            picPlay.Focus();
        }

        private void cbxPlays_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(cbxPlays, "Right-Click to edit Play Data." + "\n\n" + "(Name, Type, vpos, etc)...");
        }

        private void btnEditPlayData_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnEditPlayData, "Click to edit Play Data." + "\n\n" + "(Name, Type, vpos, etc)...");
        }

        private void cbxPlays_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cmsPlayOptions.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void cbxPlays_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cmsPlayOptions.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void EditPlayData_Click(object sender, EventArgs e)
        {
            int playREC = ((PBPL)cbxPlays.SelectedItem).rec;

            frmEditPlay frmEditPlay = new frmEditPlay();
            frmEditPlay.Play = Play;
            if (frmEditPlay.ShowDialog() == DialogResult.OK)
            {
                Play = frmEditPlay.Play;
                SetPlay(Play);
                Play = GetPlay();
                UpdateSubFormations();
                cbxPlays.SelectedItem = (cbxPlays.Items.Cast<PBPL>().ToList()).Find(item => item.rec == playREC);
                UpdatePlay(Play);
            }
        }

        private void dgvPLYS_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dgvPLYS.CurrentCell = dgvPLYS[e.ColumnIndex, e.RowIndex];

                frmPLRR frmPLRR = new frmPLRR(this);
                frmPLRR.PSAL_PLRR_ARTL = PSAL_PLRR_ARTL;
                frmPLRR.DefaultPSAL = new PLYS
                {
                    ARTL = Play.PLYS[dgvPLYS.SelectedCells[0].RowIndex].ARTL,
                    PLRR = Play.PLYS[dgvPLYS.SelectedCells[0].RowIndex].PLRR,
                    PSAL = Play.PLYS[dgvPLYS.SelectedCells[0].RowIndex].PSAL
                };

                frmPLRR.Location = new Point(Cursor.Position.X - (frmPLRR.Width / 2), Cursor.Position.Y + (frmPLRR.Height / 3));
                frmPLRR.Show();
            }
        }

        private void dgvPLYS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!flag_cell_edited)
            {
                currentDGVRow = dgvPLYS.CurrentCell.RowIndex;
                currentDGVCol = dgvPLYS.CurrentCell.ColumnIndex;
            }

            int selectedPoso = dgvPLYS.CurrentRow.Index;

            switch (selectedPoso)
            {
                case 0:
                    Play.poso0.Highlighted = true;
                    Play.poso1.Highlighted = false;
                    Play.poso2.Highlighted = false;
                    Play.poso3.Highlighted = false;
                    Play.poso4.Highlighted = false;
                    Play.poso5.Highlighted = false;
                    Play.poso6.Highlighted = false;
                    Play.poso7.Highlighted = false;
                    Play.poso8.Highlighted = false;
                    Play.poso9.Highlighted = false;
                    Play.poso10.Highlighted = false;
                    break;
                case 1:
                    Play.poso0.Highlighted = false;
                    Play.poso1.Highlighted = true;
                    Play.poso2.Highlighted = false;
                    Play.poso3.Highlighted = false;
                    Play.poso4.Highlighted = false;
                    Play.poso5.Highlighted = false;
                    Play.poso6.Highlighted = false;
                    Play.poso7.Highlighted = false;
                    Play.poso8.Highlighted = false;
                    Play.poso9.Highlighted = false;
                    Play.poso10.Highlighted = false;
                    break;
                case 2:
                    Play.poso0.Highlighted = false;
                    Play.poso1.Highlighted = false;
                    Play.poso2.Highlighted = true;
                    Play.poso3.Highlighted = false;
                    Play.poso4.Highlighted = false;
                    Play.poso5.Highlighted = false;
                    Play.poso6.Highlighted = false;
                    Play.poso7.Highlighted = false;
                    Play.poso8.Highlighted = false;
                    Play.poso9.Highlighted = false;
                    Play.poso10.Highlighted = false;
                    break;
                case 3:
                    Play.poso0.Highlighted = false;
                    Play.poso1.Highlighted = false;
                    Play.poso2.Highlighted = false;
                    Play.poso3.Highlighted = true;
                    Play.poso4.Highlighted = false;
                    Play.poso5.Highlighted = false;
                    Play.poso6.Highlighted = false;
                    Play.poso7.Highlighted = false;
                    Play.poso8.Highlighted = false;
                    Play.poso9.Highlighted = false;
                    Play.poso10.Highlighted = false;
                    break;
                case 4:
                    Play.poso0.Highlighted = false;
                    Play.poso1.Highlighted = false;
                    Play.poso2.Highlighted = false;
                    Play.poso3.Highlighted = false;
                    Play.poso4.Highlighted = true;
                    Play.poso5.Highlighted = false;
                    Play.poso6.Highlighted = false;
                    Play.poso7.Highlighted = false;
                    Play.poso8.Highlighted = false;
                    Play.poso9.Highlighted = false;
                    Play.poso10.Highlighted = false;
                    break;
                case 5:
                    Play.poso0.Highlighted = false;
                    Play.poso1.Highlighted = false;
                    Play.poso2.Highlighted = false;
                    Play.poso3.Highlighted = false;
                    Play.poso4.Highlighted = false;
                    Play.poso5.Highlighted = true;
                    Play.poso6.Highlighted = false;
                    Play.poso7.Highlighted = false;
                    Play.poso8.Highlighted = false;
                    Play.poso9.Highlighted = false;
                    Play.poso10.Highlighted = false;
                    break;
                case 6:
                    Play.poso0.Highlighted = false;
                    Play.poso1.Highlighted = false;
                    Play.poso2.Highlighted = false;
                    Play.poso3.Highlighted = false;
                    Play.poso4.Highlighted = false;
                    Play.poso5.Highlighted = false;
                    Play.poso6.Highlighted = true;
                    Play.poso7.Highlighted = false;
                    Play.poso8.Highlighted = false;
                    Play.poso9.Highlighted = false;
                    Play.poso10.Highlighted = false;
                    break;
                case 7:
                    Play.poso0.Highlighted = false;
                    Play.poso1.Highlighted = false;
                    Play.poso2.Highlighted = false;
                    Play.poso3.Highlighted = false;
                    Play.poso4.Highlighted = false;
                    Play.poso5.Highlighted = false;
                    Play.poso6.Highlighted = false;
                    Play.poso7.Highlighted = true;
                    Play.poso8.Highlighted = false;
                    Play.poso9.Highlighted = false;
                    Play.poso10.Highlighted = false;
                    break;
                case 8:
                    Play.poso0.Highlighted = false;
                    Play.poso1.Highlighted = false;
                    Play.poso2.Highlighted = false;
                    Play.poso3.Highlighted = false;
                    Play.poso4.Highlighted = false;
                    Play.poso5.Highlighted = false;
                    Play.poso6.Highlighted = false;
                    Play.poso7.Highlighted = false;
                    Play.poso8.Highlighted = true;
                    Play.poso9.Highlighted = false;
                    Play.poso10.Highlighted = false;
                    break;
                case 9:
                    Play.poso0.Highlighted = false;
                    Play.poso1.Highlighted = false;
                    Play.poso2.Highlighted = false;
                    Play.poso3.Highlighted = false;
                    Play.poso4.Highlighted = false;
                    Play.poso5.Highlighted = false;
                    Play.poso6.Highlighted = false;
                    Play.poso7.Highlighted = false;
                    Play.poso8.Highlighted = false;
                    Play.poso9.Highlighted = true;
                    Play.poso10.Highlighted = false;
                    break;
                case 10:
                    Play.poso0.Highlighted = false;
                    Play.poso1.Highlighted = false;
                    Play.poso2.Highlighted = false;
                    Play.poso3.Highlighted = false;
                    Play.poso4.Highlighted = false;
                    Play.poso5.Highlighted = false;
                    Play.poso6.Highlighted = false;
                    Play.poso7.Highlighted = false;
                    Play.poso8.Highlighted = false;
                    Play.poso9.Highlighted = false;
                    Play.poso10.Highlighted = true;
                    break;
            }

            ClearField();
            drawPlay(Graphics.FromImage(gImage), Play);
            //drawFormation(Graphics.FromImage(gImage), ((SETL)cbxSubFormations.SelectedItem).setl, ((SGFF)cbxAlignments.SelectedItem).SGF_);
        }

        private void dgvPLYS_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            SetPlay(Play);
            Play = GetPlay();
            UpdatePlay(Play);
        }

        private void dgvPLYS_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            flag_cell_edited = true;
        }

        private void dgvPLYS_SelectionChanged(object sender, EventArgs e)
        {
            if (flag_cell_edited)
            {
                DataGridViewCell cell = dgvPLYS.Rows[currentDGVRow].Cells[currentDGVCol];
                dgvPLYS.CurrentCell = cell;
                flag_cell_edited = false;
            }
        }

        private void selectFormation(object sender, EventArgs e)
        {
            lblSubFormations.Visible = true;
            cbxSubFormations.Visible = true;
            cbxSubFormations.Items.Clear();
            cbxSubFormations.ValueMember = null;
            cbxSubFormations.DisplayMember = "name";

            for (int i = 0; i < SubFormations.Count; i++)
            {
                if (SubFormations[i].FORM == ((CPFM)cbxFormations.SelectedItem).FORM)
                {
                    cbxSubFormations.Items.Add(SubFormations[i]);
                }
            }

            cbxSubFormations.SelectedIndex = 0;
            cbxPlays.Focus();
        }

        private void selectSubFormation(object sender, EventArgs e)
        {
            UpdateSubFormations();
        }

        private void selectAlignment(object sender, EventArgs e)
        {

        }

        private void selectPlay(object sender, EventArgs e)
        {
            btnEditPlayData.Visible = true;
            Play = GetPlay();
            UpdatePlay(Play);
        }

        #endregion

        public void UpdatePlay(PLAY play)
        {
            //Get the selected play detail (PSALs, etc) information
            //Play.PLYS = GetPlay();

            dgvPLYS.Visible = true;
            dgvPLYS.DataSource = Play.PLYS;
            dgvPLYS.AutoResizeColumns();
            Program.ResizeDataGrid(dgvPLYS);

            #region Set dgvPLYS Style

            dgvPLYS.Columns["rec"].ReadOnly = true;
            dgvPLYS.Columns["rec"].DefaultCellStyle.BackColor = Color.White;
            dgvPLYS.Columns["rec"].DefaultCellStyle.SelectionBackColor = Color.White;
            dgvPLYS.Columns["rec"].DefaultCellStyle.ForeColor = Color.DarkGray;
            dgvPLYS.Columns["rec"].DefaultCellStyle.SelectionForeColor = Color.DarkGray;

            dgvPLYS.Columns["PLYL"].ReadOnly = true;
            dgvPLYS.Columns["PLYL"].DefaultCellStyle.BackColor = Color.White;
            dgvPLYS.Columns["PLYL"].DefaultCellStyle.SelectionBackColor = Color.White;
            dgvPLYS.Columns["PLYL"].DefaultCellStyle.ForeColor = Color.DarkGray;
            dgvPLYS.Columns["PLYL"].DefaultCellStyle.SelectionForeColor = Color.DarkGray;

            dgvPLYS.Columns["poso"].ReadOnly = true;
            dgvPLYS.Columns["poso"].DefaultCellStyle.BackColor = Color.White;
            dgvPLYS.Columns["poso"].DefaultCellStyle.SelectionBackColor = Color.White;
            dgvPLYS.Columns["poso"].DefaultCellStyle.ForeColor = Color.DarkGray;
            dgvPLYS.Columns["poso"].DefaultCellStyle.SelectionForeColor = Color.DarkGray;

            #endregion

            ClearField();

            //Convert PSALs
            play.poso0 = Program.convertPSAL(play.poso0, LOS);
            play.poso1 = Program.convertPSAL(play.poso1, LOS);
            play.poso2 = Program.convertPSAL(play.poso2, LOS);
            play.poso3 = Program.convertPSAL(play.poso3, LOS);
            play.poso4 = Program.convertPSAL(play.poso4, LOS);
            play.poso5 = Program.convertPSAL(play.poso5, LOS);
            play.poso6 = Program.convertPSAL(play.poso6, LOS);
            play.poso7 = Program.convertPSAL(play.poso7, LOS);
            play.poso8 = Program.convertPSAL(play.poso8, LOS);
            play.poso9 = Program.convertPSAL(play.poso9, LOS);
            play.poso10 = Program.convertPSAL(play.poso10, LOS);

            drawPlay(Graphics.FromImage(gImage), Play);
            //drawFormation(Graphics.FromImage(gImage), ((SETL)cbxSubFormations.SelectedItem).setl, ((SGFF)cbxAlignments.SelectedItem).SGF_);
        }

        private void UpdateSubFormations()
        {
            ////Get the selected formation alignment table information
            //Play.SETP = GetFormationSETP();
            //Play.SETG = GetFormationSETG(Play.SETP);
            //Play.SGFF = GetFormationSGFF();

            //Fill the Play list and show it
            lblPlays.Visible = true;
            cbxPlays.Visible = true;
            cbxPlays.Items.Clear();
            cbxPlays.ValueMember = null;
            cbxPlays.DisplayMember = "name";

            for (int i = 0; i < PBPL.Count; i++)
            {
                if (PBPL[i].SETL == ((SETL)cbxSubFormations.SelectedItem).setl)
                {
                    cbxPlays.Items.Add(PBPL[i]);
                }
            }

            //Fill the Alignments list and show it
            lblAlignments.Visible = true;
            cbxAlignments.Visible = true;
            cbxAlignments.Items.Clear();
            cbxAlignments.ValueMember = null;
            cbxAlignments.DisplayMember = "name";

            for (int i = 0; i < SGFF.Count; i++)
            {
                if (SGFF[i].SETL == ((SETL)cbxSubFormations.SelectedItem).setl)
                {
                    cbxAlignments.Items.Add(SGFF[i]);
                }
            }

            cbxAlignments.SelectedItem = (cbxAlignments.Items.Cast<SGFF>().ToList()).Find(item => item.name == "Norm");

            ClearField();
            //drawFormation(Graphics.FromImage(gImage), ((SETL)cbxSubFormations.SelectedItem).setl, ((SGFF)cbxAlignments.SelectedItem).SGF_);

            cbxPlays.SelectedIndex = 0;
        }

        private string StrReverse(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        #region Load/Edit Tables

        private void CheckDB(string filename)
        {
            byte[] array = File.ReadAllBytes(filename);  // Load DB into memory.

            // This really should be wrapped in a try-catch to prevent people trying to open the db file while it is already opened

            BinaryReader binreader = new BinaryReader(File.Open(filename, FileMode.Open));
            UInt16 check = binreader.ReadUInt16();      // Read 16bit unsigned int

            // DB file  0x means hex, so this is checking to see that file begins with 44 42, which is the "DB" ID
            // This ID works even if the file is bigendian
            if (check == 0x4244)
            {
                binreader.BaseStream.Position = 4;      // Advance the binreader to offset 4 of the file
                UInt32 endian = binreader.ReadUInt32(); // Read in 32bit  unsigned int
                if (endian == 1)
                    BigEndian = true;
            }
            else if (check == 0x4246)                   // Checking to see that file begins with 46 42, which is the "FB" ID (FBCHUNKS).
            {
                OpenFileDialogTMP = filename;
                FBChunks = true;
                // Save FBCHUNKS information.
                BinaryWriter fbbinwriter = new BinaryWriter(File.Open(filename + ".bin", FileMode.Create));
                for (int i = 0; i < 62; i++)
                {
                    fbbinwriter.Write(array[i]);
                }
                fbbinwriter.Close();  // end Save FBCHUNKS information.

                // Check if DB is BigEndian.
                if (Convert.ToUInt32(array[66]) == 1)
                    BigEndian = true;

                // Save DB information.
                BinaryWriter dbbinwriter = new BinaryWriter(File.Open(filename + ".db", FileMode.Create));
                for (int i = 62; i < array.Length; i++)
                {
                    dbbinwriter.Write(array[i]);
                }
                dbbinwriter.Close();  // end Save DB information.
                openFileDialog1.FileName = filename + ".db";
            }
            binreader.Close();
        }

        private void LoadDB()
        {
            //Load the tables into memory
            TableNames = GetTables();
            Formations = GetCPFM();
            SubFormations = GetSETL();
            SETP = GetSETP();
            SETG = GetSETG();
            SGFF = GetSGFF();
            PBPL = GetPBPL();
            PLPD = GetPLPD();
            PLRD = GetPLRD();
            PLYS = GetPLYL();
            PSLO = GetPSLO();
            PSLD = GetPSLD();
            PSAL_PLRR_ARTL = GetPSAO_PLRR_ARTL();

            lblFormations.Visible = true;
            cbxFormations.Visible = true;
            cbxFormations.Items.Clear();
            cbxFormations.ValueMember = null;
            cbxFormations.DisplayMember = "name";

            for (int i = 0; i < Formations.Count; i++)
            {
                cbxFormations.Items.Add(Formations[i]);
            }
        }

        private List<TableNames> GetTables()
        {
            //Number of tables
            int TableCount = TDB.TDBDatabaseGetTableCount(OpenIndex);

            //Table Properties
            TdbTableProperties TableProps = new TdbTableProperties();

            //Table Name
            StringBuilder TableName = new StringBuilder("    ", 5);

            List<TableNames> tablenames = new List<TableNames>();

            for (int i = 0; i < TableCount; i++)
            {
                // Init the tdbtableproperties name
                TableProps.Name = TableName.ToString();

                // Get the tableproperties for the given table number
                if (TDB.TDBTableGetProperties(OpenIndex, i, ref TableProps))
                {
                    if (BigEndian)
                        TableProps.Name = StrReverse(TableProps.Name);

                    tablenames.Add(new TableNames { rec = i, name = TableProps.Name });
                }
            }
            return tablenames;
        }

        private void SaveDB()
        {
            if (!TDB.TDBSave(OpenIndex))
            {
                MessageBox.Show("Error Saving");
            }
        }

        private void UpdateDB()
        {
            foreach (PLYS item in PLYS)
            {
                TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLYS"), StrReverse("PSAL"), item.rec, item.PSAL);
                TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLYS"), StrReverse("ARTL"), item.rec, item.ARTL);
                TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLYS"), StrReverse("PLRR"), item.rec, item.PLRR);
            }

            foreach (PBPL item in PBPL)
            {
                TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PBPL"), StrReverse("COMF"), item.rec, item.COMF);
                //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PBPL"), StrReverse("SETL"), rec.rec, rec.SETL);
                //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PBPL"), StrReverse("PLYL"), rec.rec, rec.PLYL);
                TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PBPL"), StrReverse("SRMM"), item.rec, item.SRMM);
                TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PBPL"), StrReverse("SITT"), item.rec, item.SITT);
                TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PBPL"), StrReverse("PLYT"), item.rec, item.PLYT);
                TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PBPL"), StrReverse("PLF_"), item.rec, item.PLF_);
                TDB.TDBFieldSetValueAsString(OpenIndex, StrReverse("PBPL"), StrReverse("name"), item.rec, item.name);
                TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PBPL"), StrReverse("risk"), item.rec, item.risk);
                TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PBPL"), StrReverse("motn"), item.rec, item.motn);
                TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PBPL"), StrReverse("vpos"), item.rec, item.vpos);
            }

            if (Play.PLPD.Count > 0)
            {
                foreach (PLPD item in PLPD)
                {
                    TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("com1"), item.rec, item.com1);
                    TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("con1"), item.rec, item.con1);
                    TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("per1"), item.rec, item.per1);
                    TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("rcv1"), item.rec, item.rcv1);
                    TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("com2"), item.rec, item.com2);
                    TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("con2"), item.rec, item.con2);
                    TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("per2"), item.rec, item.per2);
                    TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("rcv2"), item.rec, item.rcv2);
                    TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("com3"), item.rec, item.com3);
                    TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("con3"), item.rec, item.con3);
                    TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("per3"), item.rec, item.per3);
                    TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("rcv3"), item.rec, item.rcv3);
                    TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("com4"), item.rec, item.com4);
                    TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("con4"), item.rec, item.con4);
                    TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("per4"), item.rec, item.per4);
                    TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("rcv4"), item.rec, item.rcv4);
                    TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("com5"), item.rec, item.com5);
                    TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("con5"), item.rec, item.con5);
                    TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("per5"), item.rec, item.per5);
                    TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("rcv5"), item.rec, item.rcv5);
                    TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("PLYL"), item.rec, item.PLYL);
                }
            }

            if (Play.PLRD.Count > 0)
            {
                foreach (PLRD item in PLRD)
                {
                    TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLRD"), StrReverse("PLYL"), item.rec, item.PLYL);
                    TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLRD"), StrReverse("hole"), item.rec, item.hole);
                }
            }
        }

        private List<CPFM> GetCPFM()
        {
            List<CPFM> _Formations = new List<CPFM>();

            TdbTableProperties TableProps = new TdbTableProperties();
            TableProps.Name = new string((char)0, 5);

            // Get Tableprops based on the selected index
            if (!TDB.TDBTableGetProperties(OpenIndex, TableNames.Find(item => item.name == "CPFM").rec, ref TableProps))
                return null;

            for (int i = 0; i < TableProps.RecordCount; i++)
            {
                TdbFieldProperties FieldProps = new TdbFieldProperties();
                FieldProps.Name = new string((char)0, 5);

                TDB.TDBFieldGetProperties(OpenIndex, StrReverse("CPFM"), 2, ref FieldProps);

                string _name = new string((char)0, (FieldProps.Size / 8) + 1);

                TDB.TDBFieldGetValueAsString(OpenIndex, StrReverse("CPFM"), StrReverse("name"), i, ref _name);
                _name = _name.Replace(",", "");

                _Formations.Add(new CPFM
                {
                    rec = i,
                    FORM = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("CPFM"), StrReverse("FORM"), i),
                    FTYP = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("CPFM"), StrReverse("FTYP"), i),
                    name = _name
                });
            }
            return _Formations;
        }

        private List<SETL> GetSETL()
        {
            List<SETL> _SubFormations = new List<SETL>();

            TdbTableProperties TableProps = new TdbTableProperties();
            TableProps.Name = new string((char)0, 5);

            // Get Tableprops based on the selected index
            if (!TDB.TDBTableGetProperties(OpenIndex, TableNames.Find(item => item.name == "SETL").rec, ref TableProps))
                return null;

            for (int i = 0; i < TableProps.RecordCount; i++)
            {
                TdbFieldProperties FieldProps = new TdbFieldProperties();
                FieldProps.Name = new string((char)0, 5);

                TDB.TDBFieldGetProperties(OpenIndex, StrReverse("SETL"), 7, ref FieldProps);

                string _name = new string((char)0, (FieldProps.Size / 8) + 1);

                TDB.TDBFieldGetValueAsString(OpenIndex, StrReverse("SETL"), StrReverse("name"), i, ref _name);
                _name = _name.Replace(",", "");

                _SubFormations.Add(new SETL
                {
                    rec = i,
                    setl = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETL"), StrReverse("SETL"), i),
                    FORM = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETL"), StrReverse("FORM"), i),
                    MOTN = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETL"), StrReverse("MOTN"), i),
                    CLAS = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETL"), StrReverse("CLAS"), i),
                    SETT = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETL"), StrReverse("SETT"), i),
                    SITT = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETL"), StrReverse("SITT"), i),
                    SLF_ = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETL"), StrReverse("SLF_"), i),
                    name = _name,
                    poso = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETL"), StrReverse("poso"), i)
                });
            }
            return _SubFormations;
        }

        private List<PBPL> GetPBPL()
        {
            List<PBPL> _Plays = new List<PBPL>();

            TdbTableProperties TableProps = new TdbTableProperties();
            TableProps.Name = new string((char)0, 5);

            // Get Tableprops based on the selected index
            if (!TDB.TDBTableGetProperties(OpenIndex, TableNames.Find(item => item.name == "PBPL").rec, ref TableProps))
                return null;

            for (int i = 0; i < TableProps.RecordCount; i++)
            {
                TdbFieldProperties FieldProps = new TdbFieldProperties();
                FieldProps.Name = new string((char)0, 5);

                TDB.TDBFieldGetProperties(OpenIndex, StrReverse("PBPL"), 7, ref FieldProps);

                string _name = new string((char)0, (FieldProps.Size / 8) + 1);

                TDB.TDBFieldGetValueAsString(OpenIndex, StrReverse("PBPL"), StrReverse("name"), i, ref _name);
                _name = _name.Replace(",", "");

                _Plays.Add(new PBPL
                {
                    rec = i,
                    COMF = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PBPL"), StrReverse("COMF"), i),
                    SETL = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PBPL"), StrReverse("SETL"), i),
                    PLYL = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PBPL"), StrReverse("PLYL"), i),
                    SRMM = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PBPL"), StrReverse("SRMM"), i),
                    SITT = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PBPL"), StrReverse("SITT"), i),
                    PLYT = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PBPL"), StrReverse("PLYT"), i),
                    PLF_ = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PBPL"), StrReverse("PLF_"), i),
                    name = _name,
                    risk = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PBPL"), StrReverse("risk"), i),
                    motn = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PBPL"), StrReverse("motn"), i),
                    vpos = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PBPL"), StrReverse("vpos"), i)
                });
            }
            return _Plays;
        }

        private List<PLPD> GetPLPD()
        {
            List<PLPD> _PLPD = new List<PLPD>();

            TdbTableProperties TableProps = new TdbTableProperties();
            TableProps.Name = new string((char)0, 5);

            // Get Tableprops based on the selected index
            if (!TDB.TDBTableGetProperties(OpenIndex, TableNames.Find(item => item.name == "PLPD").rec, ref TableProps))
                return null;

            for (int i = 0; i < TableProps.RecordCount; i++)
            {
                _PLPD.Add(new PLPD
                {
                    rec = i,
                    com1 = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("com1"), i),
                    con1 = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("con1"), i),
                    per1 = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("per1"), i),
                    rcv1 = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("rcv1"), i),
                    com2 = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("com2"), i),
                    con2 = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("con2"), i),
                    per2 = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("per2"), i),
                    rcv2 = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("rcv2"), i),
                    com3 = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("com3"), i),
                    con3 = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("con3"), i),
                    per3 = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("per3"), i),
                    rcv3 = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("rcv3"), i),
                    com4 = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("com4"), i),
                    con4 = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("con4"), i),
                    per4 = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("per4"), i),
                    rcv4 = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("rcv4"), i),
                    com5 = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("com5"), i),
                    con5 = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("con5"), i),
                    per5 = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("per5"), i),
                    rcv5 = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("rcv5"), i),
                    PLYL = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("PLYL"), i)
                });
            }
            return _PLPD;

        }

        private List<PLRD> GetPLRD()
        {
            List<PLRD> _PLRD = new List<PLRD>();

            TdbTableProperties TableProps = new TdbTableProperties();
            TableProps.Name = new string((char)0, 5);

            // Get Tableprops based on the selected index
            if (!TDB.TDBTableGetProperties(OpenIndex, TableNames.Find(item => item.name == "PLRD").rec, ref TableProps))
                return null;

            for (int i = 0; i < TableProps.RecordCount; i++)
            {
                _PLRD.Add(new PLRD
                {
                    rec = i,
                    PLYL = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PLRD"), StrReverse("PLYL"), i),
                    hole = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PLRD"), StrReverse("hole"), i)
                });
            }
            return _PLRD;
        }

        public PLAY GetPlay()
        {
            PLAY _PLAY = new PLAY();

            #region Get PLYS for current play

            _PLAY.PLYS = new List<PLYS>();

            for (int i = 0; i < PLYS.Count; i++)
            {
                if (PLYS[i].PLYL == ((PBPL)cbxPlays.SelectedItem).PLYL)
                {
                    _PLAY.PLYS.Add(new PLYS
                    {
                        rec = PLYS[i].rec,
                        PSAL = PLYS[i].PSAL,
                        ARTL = PLYS[i].ARTL,
                        PLYL = PLYS[i].PLYL,
                        PLRR = PLYS[i].PLRR,
                        poso = PLYS[i].poso
                    });
                }
                if (_PLAY.PLYS.Count == 11)
                {
                    break;
                }
            }

            #endregion

            #region Get PBPL for current play

            _PLAY.PBPL = new List<PBPL>();

            for (int i = 0; i < PBPL.Count; i++)
            {
                if (PBPL[i].PLYL == ((PBPL)cbxPlays.SelectedItem).PLYL)
                {
                    _PLAY.PBPL.Add(new PBPL
                    {
                        rec = PBPL[i].rec,
                        COMF = PBPL[i].COMF,
                        SETL = PBPL[i].SETL,
                        PLYL = PBPL[i].PLYL,
                        SRMM = PBPL[i].SRMM,
                        SITT = PBPL[i].SITT,
                        PLYT = PBPL[i].PLYT,
                        PLF_ = PBPL[i].PLF_,
                        name = PBPL[i].name,
                        risk = PBPL[i].risk,
                        motn = PBPL[i].motn,
                        vpos = PBPL[i].vpos,
                    });
                    break;
                }
            }

            #endregion

            #region Get PLPD for current play

            _PLAY.PLPD = new List<PLPD>();

            for (int i = 0; i < PLPD.Count; i++)
            {
                if (PLPD[i].PLYL == ((PBPL)cbxPlays.SelectedItem).PLYL)
                {
                    _PLAY.PLPD.Add(new PLPD
                    {
                        rec = PLPD[i].rec,
                        com1 = PLPD[i].com1,
                        con1 = PLPD[i].con1,
                        per1 = PLPD[i].per1,
                        rcv1 = PLPD[i].rcv1,
                        com2 = PLPD[i].com2,
                        con2 = PLPD[i].con2,
                        per2 = PLPD[i].per2,
                        rcv2 = PLPD[i].rcv2,
                        com3 = PLPD[i].com3,
                        con3 = PLPD[i].con3,
                        per3 = PLPD[i].per3,
                        rcv3 = PLPD[i].rcv3,
                        com4 = PLPD[i].com4,
                        con4 = PLPD[i].con4,
                        per4 = PLPD[i].per4,
                        rcv4 = PLPD[i].rcv4,
                        com5 = PLPD[i].com5,
                        con5 = PLPD[i].con5,
                        per5 = PLPD[i].per5,
                        rcv5 = PLPD[i].rcv5,
                        PLYL = PLPD[i].PLYL
                    });
                    break;
                }
            }

            #endregion

            #region Get PLRD for current play

            _PLAY.PLRD = new List<PLRD>();

            for (int i = 0; i < PLRD.Count; i++)
            {
                if (PLRD[i].PLYL == ((PBPL)cbxPlays.SelectedItem).PLYL)
                {
                    _PLAY.PLRD.Add(new PLRD
                    {
                        rec = PLRD[i].rec,
                        PLYL = PLRD[i].PLYL,
                        hole = PLRD[i].hole
                    });
                    break;
                }
            }

            #endregion

            #region Get SETP for current play

            _PLAY.SETP = new List<SETP>();

            for (int i = 0; i < SETP.Count; i++)
            {
                if (SETP[i].SETL == ((SETL)cbxSubFormations.SelectedItem).setl)
                {
                    _PLAY.SETP.Add(new SETP
                    {
                        rec = SETP[i].rec,
                        SETL = SETP[i].SETL,
                        setp = SETP[i].setp,
                        SGT_ = SETP[i].SGT_,
                        arti = SETP[i].arti,
                        opnm = SETP[i].opnm,
                        tabo = SETP[i].tabo,
                        poso = SETP[i].poso,
                        odep = SETP[i].odep,
                        flas = SETP[i].flas,
                        DPos = SETP[i].DPos,
                        EPos = SETP[i].EPos,
                        fmtx = SETP[i].fmtx,
                        artx = SETP[i].artx,
                        fmty = SETP[i].fmty,
                        arty = SETP[i].arty,
                    });
                    if (_PLAY.SETP.Count == 11)
                    {
                        _PLAY.SETP = _PLAY.SETP.ToList().OrderBy(s => s.poso).Cast<SETP>().ToList();
                        break;
                    }
                }
            }

            #endregion

            #region Get SGFF for current play

            _PLAY.SGFF = new List<SGFF>();

            for (int i = 0; i < SGFF.Count; i++)
            {
                if (SGFF[i].SETL == ((SETL)cbxSubFormations.SelectedItem).setl)
                {
                    _PLAY.SGFF.Add(new SGFF
                    {
                        rec = SGFF[i].rec,
                        SETL = SGFF[i].SETL,
                        SGF_ = SGFF[i].SGF_,
                        name = SGFF[i].name,
                        dflt = SGFF[i].dflt
                    });
                }
            }
            _PLAY.SGFF = _PLAY.SGFF.ToList().OrderBy(s => s.SGF_).Cast<SGFF>().ToList();

            #endregion

            #region Get SETG for current play

            _PLAY.SETG = new List<SETG>();

            for (int i = 0; i < SETG.Count; i++)
            {
                if (SETG[i].SGF_ == ((SGFF)cbxAlignments.SelectedItem).SGF_)
                {
                    _PLAY.SETG.Add(new SETG
                    {
                        rec = SETG[i].rec,
                        SETP = SETG[i].SETP,
                        SGF_ = SETG[i].SGF_,
                        SF__ = SETG[i].SF__,
                        x___ = SETG[i].x___,
                        y___ = SETG[i].y___,
                        fx__ = SETG[i].fx__,
                        fy__ = SETG[i].fy__,
                        anm_ = SETG[i].anm_,
                        dir_ = SETG[i].dir_,
                        fanm = SETG[i].fanm,
                        fdir = SETG[i].fdir
                    });
                    if (_PLAY.SETG.Count == 11)
                    {
                        _PLAY.SETG = _PLAY.SETG.ToList().OrderBy(s => s.SETP).Cast<SETG>().ToList();
                        break;
                    }
                }
            }

            #endregion

            #region Get PSAL info for current play

            //Get PSAL steps for each poso
            _PLAY.poso0 = getSTEPs(_PLAY.PLYS[0].PSAL);
            _PLAY.poso1 = getSTEPs(_PLAY.PLYS[1].PSAL);
            _PLAY.poso2 = getSTEPs(_PLAY.PLYS[2].PSAL);
            _PLAY.poso3 = getSTEPs(_PLAY.PLYS[3].PSAL);
            _PLAY.poso4 = getSTEPs(_PLAY.PLYS[4].PSAL);
            _PLAY.poso5 = getSTEPs(_PLAY.PLYS[5].PSAL);
            _PLAY.poso6 = getSTEPs(_PLAY.PLYS[6].PSAL);
            _PLAY.poso7 = getSTEPs(_PLAY.PLYS[7].PSAL);
            _PLAY.poso8 = getSTEPs(_PLAY.PLYS[8].PSAL);
            _PLAY.poso9 = getSTEPs(_PLAY.PLYS[9].PSAL);
            _PLAY.poso10 = getSTEPs(_PLAY.PLYS[10].PSAL);

            //Get player position for each poso
            _PLAY.poso0.playerXY = GetPlayerXY(_PLAY.SETG[0]);
            _PLAY.poso1.playerXY = GetPlayerXY(_PLAY.SETG[1]);
            _PLAY.poso2.playerXY = GetPlayerXY(_PLAY.SETG[2]);
            _PLAY.poso3.playerXY = GetPlayerXY(_PLAY.SETG[3]);
            _PLAY.poso4.playerXY = GetPlayerXY(_PLAY.SETG[4]);
            _PLAY.poso5.playerXY = GetPlayerXY(_PLAY.SETG[5]);
            _PLAY.poso6.playerXY = GetPlayerXY(_PLAY.SETG[6]);
            _PLAY.poso7.playerXY = GetPlayerXY(_PLAY.SETG[7]);
            _PLAY.poso8.playerXY = GetPlayerXY(_PLAY.SETG[8]);
            _PLAY.poso9.playerXY = GetPlayerXY(_PLAY.SETG[9]);
            _PLAY.poso10.playerXY = GetPlayerXY(_PLAY.SETG[10]);

            //Clear player route color
            _PLAY.poso0.routeColor = Color.Black;
            _PLAY.poso1.routeColor = Color.Black;
            _PLAY.poso2.routeColor = Color.Black;
            _PLAY.poso3.routeColor = Color.Black;
            _PLAY.poso4.routeColor = Color.Black;
            _PLAY.poso5.routeColor = Color.Black;
            _PLAY.poso6.routeColor = Color.Black;
            _PLAY.poso7.routeColor = Color.Black;
            _PLAY.poso8.routeColor = Color.Black;
            _PLAY.poso9.routeColor = Color.Black;
            _PLAY.poso10.routeColor = Color.Black;

            //Set primary reciever route color
            if (_PLAY.PBPL[0].vpos == 1) _PLAY.poso1.routeColor = Color.FromArgb(255, 202, 48, 84);
            if (_PLAY.PBPL[0].vpos == 2) _PLAY.poso2.routeColor = Color.FromArgb(255, 202, 48, 84);
            if (_PLAY.PBPL[0].vpos == 3) _PLAY.poso3.routeColor = Color.FromArgb(255, 202, 48, 84);
            if (_PLAY.PBPL[0].vpos == 4) _PLAY.poso4.routeColor = Color.FromArgb(255, 202, 48, 84);
            if (_PLAY.PBPL[0].vpos == 5) _PLAY.poso5.routeColor = Color.FromArgb(255, 202, 48, 84);

            //Set Position names
            _PLAY.poso0.Position = GetPlayerPosition(_PLAY.SETP[0].EPos, _PLAY.SETP[0].DPos);
            _PLAY.poso1.Position = GetPlayerPosition(_PLAY.SETP[1].EPos, _PLAY.SETP[1].DPos);
            _PLAY.poso2.Position = GetPlayerPosition(_PLAY.SETP[2].EPos, _PLAY.SETP[2].DPos);
            _PLAY.poso3.Position = GetPlayerPosition(_PLAY.SETP[3].EPos, _PLAY.SETP[3].DPos);
            _PLAY.poso4.Position = GetPlayerPosition(_PLAY.SETP[4].EPos, _PLAY.SETP[4].DPos);
            _PLAY.poso5.Position = GetPlayerPosition(_PLAY.SETP[5].EPos, _PLAY.SETP[5].DPos);
            _PLAY.poso6.Position = GetPlayerPosition(_PLAY.SETP[6].EPos, _PLAY.SETP[6].DPos);
            _PLAY.poso7.Position = GetPlayerPosition(_PLAY.SETP[7].EPos, _PLAY.SETP[7].DPos);
            _PLAY.poso8.Position = GetPlayerPosition(_PLAY.SETP[8].EPos, _PLAY.SETP[8].DPos);
            _PLAY.poso9.Position = GetPlayerPosition(_PLAY.SETP[9].EPos, _PLAY.SETP[9].DPos);
            _PLAY.poso10.Position = GetPlayerPosition(_PLAY.SETP[10].EPos, _PLAY.SETP[10].DPos);

            #endregion

            return _PLAY;
        }

        public void SetPlay(PLAY Play)
        {
            foreach (PLYS item in Play.PLYS)
            {
                PLYS[item.rec].PSAL = item.PSAL;
                PLYS[item.rec].ARTL = item.ARTL;
                PLYS[item.rec].PLRR = item.PLRR;

                //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLYS"), StrReverse("PSAL"), item.rec, item.PSAL);
                //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLYS"), StrReverse("ARTL"), item.rec, item.ARTL);
                //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLYS"), StrReverse("PLRR"), item.rec, item.PLRR);
            }

            foreach (PBPL item in Play.PBPL)
            {
                PBPL[item.rec].COMF = item.COMF;
                PBPL[item.rec].SRMM = item.SRMM;
                PBPL[item.rec].SITT = item.SITT;
                PBPL[item.rec].PLYT = item.PLYT;
                PBPL[item.rec].PLF_ = item.PLF_;
                PBPL[item.rec].name = item.name;
                PBPL[item.rec].risk = item.risk;
                PBPL[item.rec].motn = item.motn;
                PBPL[item.rec].vpos = item.vpos;

                //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PBPL"), StrReverse("COMF"), item.rec, item.COMF);
                ////TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PBPL"), StrReverse("SETL"), rec.rec, rec.SETL);
                ////TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PBPL"), StrReverse("PLYL"), rec.rec, rec.PLYL);
                //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PBPL"), StrReverse("SRMM"), item.rec, item.SRMM);
                //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PBPL"), StrReverse("SITT"), item.rec, item.SITT);
                //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PBPL"), StrReverse("PLYT"), item.rec, item.PLYT);
                //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PBPL"), StrReverse("PLF_"), item.rec, item.PLF_);
                //TDB.TDBFieldSetValueAsString(OpenIndex, StrReverse("PBPL"), StrReverse("name"), item.rec, item.name);
                //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PBPL"), StrReverse("risk"), item.rec, item.risk);
                //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PBPL"), StrReverse("motn"), item.rec, item.motn);
                //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PBPL"), StrReverse("vpos"), item.rec, item.vpos);
            }

            if (Play.PLPD.Count > 0)
            {
                foreach (PLPD item in Play.PLPD)
                {
                    PLPD[item.rec].com1 = item.com1;
                    PLPD[item.rec].con1 = item.con1;
                    PLPD[item.rec].per1 = item.per1;
                    PLPD[item.rec].rcv1 = item.rcv1;
                    PLPD[item.rec].com2 = item.com2;
                    PLPD[item.rec].con2 = item.con2;
                    PLPD[item.rec].per2 = item.per2;
                    PLPD[item.rec].rcv2 = item.rcv2;
                    PLPD[item.rec].com3 = item.com3;
                    PLPD[item.rec].con3 = item.con3;
                    PLPD[item.rec].per3 = item.per3;
                    PLPD[item.rec].rcv3 = item.rcv3;
                    PLPD[item.rec].com4 = item.com4;
                    PLPD[item.rec].con4 = item.con4;
                    PLPD[item.rec].per4 = item.per4;
                    PLPD[item.rec].rcv4 = item.rcv4;
                    PLPD[item.rec].com5 = item.com5;
                    PLPD[item.rec].con5 = item.con5;
                    PLPD[item.rec].per5 = item.per5;
                    PLPD[item.rec].rcv5 = item.rcv5;
                    PLPD[item.rec].PLYL = item.PLYL;

                    //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("com1"), item.rec, item.com1);
                    //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("con1"), item.rec, item.con1);
                    //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("per1"), item.rec, item.per1);
                    //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("rcv1"), item.rec, item.rcv1);
                    //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("com2"), item.rec, item.com2);
                    //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("con2"), item.rec, item.con2);
                    //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("per2"), item.rec, item.per2);
                    //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("rcv2"), item.rec, item.rcv2);
                    //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("com3"), item.rec, item.com3);
                    //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("con3"), item.rec, item.con3);
                    //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("per3"), item.rec, item.per3);
                    //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("rcv3"), item.rec, item.rcv3);
                    //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("com4"), item.rec, item.com4);
                    //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("con4"), item.rec, item.con4);
                    //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("per4"), item.rec, item.per4);
                    //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("rcv4"), item.rec, item.rcv4);
                    //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("com5"), item.rec, item.com5);
                    //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("con5"), item.rec, item.con5);
                    //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("per5"), item.rec, item.per5);
                    //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("rcv5"), item.rec, item.rcv5);
                    //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLPD"), StrReverse("PLYL"), item.rec, item.PLYL);
                }
            }

            if (Play.PLRD.Count > 0)
            {
                foreach (PLRD item in Play.PLRD)
                {
                    PLRD[item.rec].PLYL = item.PLYL;
                    PLRD[item.rec].hole = item.hole;

                    //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLRD"), StrReverse("PLYL"), item.rec, item.PLYL);
                    //TDB.TDBFieldSetValueAsInteger(OpenIndex, StrReverse("PLRD"), StrReverse("hole"), item.rec, item.hole);
                }

            }
        }

        public List<PLYS> GetPLYL()
        {
            List<PLYS> _PLYL = new List<PLYS>();

            TdbTableProperties TableProps = new TdbTableProperties();
            TableProps.Name = new string((char)0, 5);

            // Get Tableprops based on the selected index
            if (!TDB.TDBTableGetProperties(OpenIndex, TableNames.Find(item => item.name == "PLYS").rec, ref TableProps))
                return null;

            for (int i = 0; i < TableProps.RecordCount; i++)
            {
                _PLYL.Add(new PLYS
                {
                    rec = i,
                    PSAL = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PLYS"), StrReverse("PSAL"), i),
                    ARTL = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PLYS"), StrReverse("ARTL"), i),
                    PLYL = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PLYS"), StrReverse("PLYL"), i),
                    PLRR = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PLYS"), StrReverse("PLRR"), i),
                    poso = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PLYS"), StrReverse("poso"), i)
                });
            }
            return _PLYL;
        }

        private List<SETP> GetSETP()
        {
            List<SETP> _SETP = new List<SETP>();

            TdbTableProperties TableProps = new TdbTableProperties();
            TableProps.Name = new string((char)0, 5);

            // Get Tableprops based on the selected index
            if (!TDB.TDBTableGetProperties(OpenIndex, TableNames.Find(item => item.name == "SETP").rec, ref TableProps))
                return null;

            for (int i = 0; i < TableProps.RecordCount; i++)
            {
                _SETP.Add(new SETP
                {
                    rec = i,
                    SETL = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETP"), StrReverse("SETL"), i),
                    setp = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETP"), StrReverse("SETP"), i),
                    SGT_ = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETP"), StrReverse("SGT_"), i),
                    arti = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETP"), StrReverse("arti"), i),
                    opnm = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETP"), StrReverse("opnm"), i),
                    tabo = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETP"), StrReverse("tabo"), i),
                    poso = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETP"), StrReverse("poso"), i),
                    odep = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETP"), StrReverse("odep"), i),
                    flas = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETP"), StrReverse("flas"), i),
                    DPos = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETP"), StrReverse("DPos"), i),
                    EPos = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETP"), StrReverse("EPos"), i),
                    fmtx = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETP"), StrReverse("fmtx"), i),
                    artx = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETP"), StrReverse("artx"), i),
                    fmty = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETP"), StrReverse("fmty"), i),
                    arty = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETP"), StrReverse("arty"), i)
                });
            }
            return _SETP;
        }

        private List<SETG> GetSETG()
        {
            List<SETG> _SETG = new List<SETG>();

            TdbTableProperties TableProps = new TdbTableProperties();
            TableProps.Name = new string((char)0, 5);

            // Get Tableprops based on the selected index
            if (!TDB.TDBTableGetProperties(OpenIndex, TableNames.Find(item => item.name == "SETG").rec, ref TableProps))
                return null;

            for (int i = 0; i < TableProps.RecordCount; i++)
            {
                _SETG.Add(new SETG
                {
                    rec = i,
                    SETP = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETG"), StrReverse("SETP"), i),
                    SGF_ = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETG"), StrReverse("SGF_"), i),
                    SF__ = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETG"), StrReverse("SF__"), i),
                    x___ = (float)TDB.TDBFieldGetValueAsFloat(OpenIndex, StrReverse("SETG"), StrReverse("x___"), i),
                    y___ = (float)TDB.TDBFieldGetValueAsFloat(OpenIndex, StrReverse("SETG"), StrReverse("y___"), i),
                    fx__ = (float)TDB.TDBFieldGetValueAsFloat(OpenIndex, StrReverse("SETG"), StrReverse("fx__"), i),
                    fy__ = (float)TDB.TDBFieldGetValueAsFloat(OpenIndex, StrReverse("SETG"), StrReverse("fy__"), i),
                    anm_ = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETG"), StrReverse("anm_"), i),
                    dir_ = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETG"), StrReverse("dir_"), i),
                    fanm = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETG"), StrReverse("fanm"), i),
                    fdir = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETG"), StrReverse("fdir"), i)
                });
            }
            return _SETG;
        }

        private List<SGFF> GetSGFF()
        {
            List<SGFF> _SGFF = new List<SGFF>();

            TdbTableProperties TableProps = new TdbTableProperties();
            TableProps.Name = new string((char)0, 5);

            // Get Tableprops based on the selected index
            if (!TDB.TDBTableGetProperties(OpenIndex, TableNames.Find(item => item.name == "SGFF").rec, ref TableProps))
                return null;

            for (int i = 0; i < TableProps.RecordCount; i++)
            {
                TdbFieldProperties FieldProps = new TdbFieldProperties();
                FieldProps.Name = new string((char)0, 5);

                TDB.TDBFieldGetProperties(OpenIndex, StrReverse("SGFF"), 2, ref FieldProps);

                string _name = new string((char)0, (FieldProps.Size / 8) + 1);

                TDB.TDBFieldGetValueAsString(OpenIndex, StrReverse("SGFF"), StrReverse("name"), i, ref _name);
                _name = _name.Replace(",", "");

                _SGFF.Add(new SGFF
                {
                    rec = i,
                    SETL = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SGFF"), StrReverse("SETL"), i),
                    SGF_ = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SGFF"), StrReverse("SGF_"), i),
                    name = _name,
                    dflt = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SGFF"), StrReverse("dflt"), i)
                });
            }
            return _SGFF;
        }

        private List<SETP> GetFormationSETP()
        {
            List<SETP> _SETP = new List<SETP>();

            for (int i = 0; i < SETP.Count; i++)
            {
                if (SETP[i].SETL == ((SETL)cbxSubFormations.SelectedItem).setl)
                {
                    _SETP.Add(new SETP
                    {
                        rec = i,
                        SETL = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETP"), StrReverse("SETL"), i),
                        setp = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETP"), StrReverse("SETP"), i),
                        SGT_ = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETP"), StrReverse("SGT_"), i),
                        arti = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETP"), StrReverse("arti"), i),
                        opnm = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETP"), StrReverse("opnm"), i),
                        tabo = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETP"), StrReverse("tabo"), i),
                        poso = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETP"), StrReverse("poso"), i),
                        odep = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETP"), StrReverse("odep"), i),
                        flas = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETP"), StrReverse("flas"), i),
                        DPos = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETP"), StrReverse("DPos"), i),
                        EPos = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETP"), StrReverse("EPos"), i),
                        fmtx = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETP"), StrReverse("fmtx"), i),
                        artx = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETP"), StrReverse("artx"), i),
                        fmty = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETP"), StrReverse("fmty"), i),
                        arty = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETP"), StrReverse("arty"), i),
                    });
                }
            }

            return _SETP;
        }

        private List<SETG> GetFormationSETG(List<SETP> _SETP)
        {
            List<SETG> _SETG = new List<SETG>();

            for (int p = 0; p < Play.SETP.Count; p++)
            {
                for (int g = 0; g < SETG.Count; g++)
                {
                    if (SETG[g].SETP == _SETP[p].setp)
                    {
                        _SETG.Add(new SETG
                        {
                            rec = g,
                            SETP = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETG"), StrReverse("SETP"), g),
                            SGF_ = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETG"), StrReverse("SGF_"), g),
                            SF__ = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETG"), StrReverse("SF__"), g),
                            x___ = (float)TDB.TDBFieldGetValueAsFloat(OpenIndex, StrReverse("SETG"), StrReverse("x___"), g),
                            y___ = (float)TDB.TDBFieldGetValueAsFloat(OpenIndex, StrReverse("SETG"), StrReverse("y___"), g),
                            fx__ = (float)TDB.TDBFieldGetValueAsFloat(OpenIndex, StrReverse("SETG"), StrReverse("fx__"), g),
                            fy__ = (float)TDB.TDBFieldGetValueAsFloat(OpenIndex, StrReverse("SETG"), StrReverse("fy__"), g),
                            anm_ = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETG"), StrReverse("anm_"), g),
                            dir_ = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETG"), StrReverse("dir_"), g),
                            fanm = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETG"), StrReverse("fanm"), g),
                            fdir = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SETG"), StrReverse("fdir"), g),
                        });
                    }
                }
            }

            return _SETG;
        }

        private List<SGFF> GetFormationSGFF()
        {
            List<SGFF> _SGFF = new List<SGFF>();

            for (int i = 0; i < SGFF.Count; i++)
            {
                if (SGFF[i].SETL == ((SETL)cbxSubFormations.SelectedItem).setl)
                {
                    TdbFieldProperties FieldProps = new TdbFieldProperties();
                    FieldProps.Name = new string((char)0, 5);

                    TDB.TDBFieldGetProperties(OpenIndex, StrReverse("SGFF"), 2, ref FieldProps);

                    string _name = new string((char)0, (FieldProps.Size / 8) + 1);

                    TDB.TDBFieldGetValueAsString(OpenIndex, StrReverse("SGFF"), StrReverse("name"), i, ref _name);
                    _name = _name.Replace(",", "");

                    _SGFF.Add(new SGFF
                    {
                        rec = i,
                        SETL = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SGFF"), StrReverse("SETL"), i),
                        SGF_ = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SGFF"), StrReverse("SGF_"), i),
                        name = _name,
                        dflt = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("SGFF"), StrReverse("dflt"), i),
                    });
                }
            }

            return _SGFF;
        }

        private List<PSAL> GetPSLO()
        {
            List<PSAL> PSLO = new List<PSAL>();

            TdbTableProperties TableProps = new TdbTableProperties();
            TableProps.Name = new string((char)0, 5);

            // Get Tableprops based on the selected index
            if (!TDB.TDBTableGetProperties(OpenIndex, TableNames.Find(item => item.name == "PSLO").rec, ref TableProps))
                return null;

            for (int i = 0; i < TableProps.RecordCount; i++)
            {
                PSLO.Add(new PSAL
                {
                    rec = i,
                    val1 = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PSLO"), StrReverse("val1"), i),
                    val2 = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PSLO"), StrReverse("val2"), i),
                    val3 = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PSLO"), StrReverse("val3"), i),
                    psal = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PSLO"), StrReverse("PSAL"), i),
                    code = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PSLO"), StrReverse("code"), i),
                    step = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PSLO"), StrReverse("step"), i)
                });
            }
            return PSLO;
        }

        private List<PSAL> GetPSLD()
        {
            List<PSAL> PSLD = new List<PSAL>();

            TdbTableProperties TableProps = new TdbTableProperties();
            TableProps.Name = new string((char)0, 5);

            // Get Tableprops based on the selected index
            if (!TDB.TDBTableGetProperties(OpenIndex, TableNames.Find(item => item.name == "PSLD").rec, ref TableProps))
                return null;

            for (int i = 0; i < TableProps.RecordCount; i++)
            {
                PSLD.Add(new PSAL
                {
                    rec = i,
                    val1 = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PSLD"), StrReverse("val1"), i),
                    val2 = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PSLD"), StrReverse("val2"), i),
                    val3 = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PSLD"), StrReverse("val3"), i),
                    psal = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PSLD"), StrReverse("PSAL"), i),
                    code = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PSLD"), StrReverse("code"), i),
                    step = (int)(UInt32)TDB.TDBFieldGetValueAsInteger(OpenIndex, StrReverse("PSLD"), StrReverse("step"), i)
                });
            }
            return PSLD;
        }

        private List<PLRR> GetPSAO_PLRR_ARTL()
        {
            IEnumerable<PSAL> PSLOu = PSLO.Distinct();

            List<PLRR> PLRR = new List<PLRR>();
            int index;

            foreach (PSAL psal in PSLOu)
            {
                try
                {
                    index = PLYS.FindIndex(x => x.PSAL == psal.psal);
                    PLRR.Add(new PLRR() { psal = PLYS[index].PSAL, artl = PLYS[index].ARTL, plrr = PLYS[index].PLRR, name = PLRRname.PLRRnameDic[PLYS[index].PLRR] });
                }
                catch
                {
                    PLRR.Add(new PLRR() { psal = psal.psal, artl = 0, plrr = 0, name = "UNUSED PSALS" });
                }
            }

            PLRR = PLRR.ToList().OrderBy(s => s.name).ThenBy(s => s.psal).Cast<PLRR>().ToList();
            return PLRR;
        }

        #endregion

        private void ClearField()
        {
            //Clear the canvas
            picPlay.Image = blankField;

            //Create a clone of the field to draw the formation
            gImage = (Image)blankField.Clone();
        }

        private XY GetPlayerXY(SETG setg)
        {
            XY playerXY = new XY { X = (int)(setg.x___ * 10), Y = (int)(setg.y___ * -10) };
            playerXY.X = playerXY.X + LOS.X;
            playerXY.Y = playerXY.Y + LOS.Y;
            return playerXY;
        }

        private string GetPlayerPosition(int Epos, int Dpos)
        {
            string Position = "";

            switch (Epos)
            {
                case 0:
                    Position = "QB";
                    break;
                case 1:
                    Position = "RB" + Dpos.ToString();
                    break;
                case 2:
                    Position = "FB" + Dpos.ToString();
                    break;
                case 3:
                    Position = "WR" + Dpos.ToString();
                    break;
                case 4:
                    Position = "TE" + Dpos.ToString();
                    break;
                case 5:
                    Position = "T";
                    break;
                case 6:
                    Position = "G";
                    break;
                case 7:
                    Position = "C";
                    break;
                case 8:
                    Position = "G";
                    break;
                case 9:
                    Position = "T";
                    break;
                case 25:
                    Position = "3RB";
                    break;
                case 26:
                    Position = "PRB";
                    break;
                case 27:
                    Position = "SWR";
                    break;
            }

            return Position;
        }

        //private void drawFormation(Graphics g, int SETL, int SGF_)
        //{
        //    //Reset the progress bar
        //    progressBar1.Value = 0;

        //    try
        //    {
        //        poso0.playerXY = new Point
        //        (
        //            (int)((SETG.Find(item2 => item2.SETP == (SETP.Find(item1 => item1.SETL == SETL && item1.poso == 0).setp) && item2.SGF_ == SGF_).x___) * 10),
        //            (int)((SETG.Find(item2 => item2.SETP == (SETP.Find(item1 => item1.SETL == SETL && item1.poso == 0).setp) && item2.SGF_ == SGF_).y___) * -10)
        //        );
        //        poso0.playerXY.Offset(LOS);
        //    }
        //    catch { }
        //    Program.drawPlayerCircle(g, Color.White, poso0, 12);
        //    progressBar1.Increment(1);

        //    try
        //    {
        //        poso1.playerXY = new Point
        //        (
        //            (int)((SETG.Find(item2 => item2.SETP == (SETP.Find(item1 => item1.SETL == SETL && item1.poso == 1).setp) && item2.SGF_ == SGF_).x___) * 10),
        //            (int)((SETG.Find(item2 => item2.SETP == (SETP.Find(item1 => item1.SETL == SETL && item1.poso == 1).setp) && item2.SGF_ == SGF_).y___) * -10)
        //        );
        //        poso1.playerXY.Offset(LOS);
        //    }
        //    catch { }
        //    Program.drawPlayerCircle(g, Color.White, poso1, 12);
        //    progressBar1.Increment(1);

        //    try
        //    {
        //        poso2.playerXY = new Point
        //        (
        //            (int)((SETG.Find(item2 => item2.SETP == (SETP.Find(item1 => item1.SETL == SETL && item1.poso == 2).setp) && item2.SGF_ == SGF_).x___) * 10),
        //            (int)((SETG.Find(item2 => item2.SETP == (SETP.Find(item1 => item1.SETL == SETL && item1.poso == 2).setp) && item2.SGF_ == SGF_).y___) * -10)
        //        );
        //        poso2.playerXY.Offset(LOS);
        //    }
        //    catch { }
        //    Program.drawPlayerCircle(g, Color.White, poso2, 12);
        //    progressBar1.Increment(1);

        //    try
        //    {
        //        poso3.playerXY = new Point
        //        (
        //            (int)((SETG.Find(item2 => item2.SETP == (SETP.Find(item1 => item1.SETL == SETL && item1.poso == 3).setp) && item2.SGF_ == SGF_).x___) * 10),
        //            (int)((SETG.Find(item2 => item2.SETP == (SETP.Find(item1 => item1.SETL == SETL && item1.poso == 3).setp) && item2.SGF_ == SGF_).y___) * -10)
        //        );
        //        poso3.playerXY.Offset(LOS);
        //    }
        //    catch { }
        //    Program.drawPlayerCircle(g, Color.White, poso3, 12);
        //    progressBar1.Increment(1);

        //    try
        //    {
        //        poso4.playerXY = new Point
        //        (
        //            (int)((SETG.Find(item2 => item2.SETP == (SETP.Find(item1 => item1.SETL == SETL && item1.poso == 4).setp) && item2.SGF_ == SGF_).x___) * 10),
        //            (int)((SETG.Find(item2 => item2.SETP == (SETP.Find(item1 => item1.SETL == SETL && item1.poso == 4).setp) && item2.SGF_ == SGF_).y___) * -10)
        //        );
        //        poso4.playerXY.Offset(LOS);
        //    }
        //    catch { }
        //    Program.drawPlayerCircle(g, Color.White, poso4, 12);
        //    progressBar1.Increment(1);

        //    try
        //    {
        //        poso5.playerXY = new Point
        //        (
        //            (int)((SETG.Find(item2 => item2.SETP == (SETP.Find(item1 => item1.SETL == SETL && item1.poso == 5).setp) && item2.SGF_ == SGF_).x___) * 10),
        //            (int)((SETG.Find(item2 => item2.SETP == (SETP.Find(item1 => item1.SETL == SETL && item1.poso == 5).setp) && item2.SGF_ == SGF_).y___) * -10)
        //        );
        //        poso5.playerXY.Offset(LOS);
        //    }
        //    catch { }
        //    Program.drawPlayerCircle(g, Color.White, poso5, 12);
        //    progressBar1.Increment(1);

        //    try
        //    {
        //        poso6.playerXY = new Point
        //        (
        //            (int)((SETG.Find(item2 => item2.SETP == (SETP.Find(item1 => item1.SETL == SETL && item1.poso == 6).setp) && item2.SGF_ == SGF_).x___) * 10),
        //            (int)((SETG.Find(item2 => item2.SETP == (SETP.Find(item1 => item1.SETL == SETL && item1.poso == 6).setp) && item2.SGF_ == SGF_).y___) * -10)
        //        );
        //        poso6.playerXY.Offset(LOS);
        //    }
        //    catch { }
        //    Program.drawPlayerCircle(g, Color.White, poso6, 12);
        //    progressBar1.Increment(1);

        //    try
        //    {
        //        poso7.playerXY = new Point
        //        (
        //            (int)((SETG.Find(item2 => item2.SETP == (SETP.Find(item1 => item1.SETL == SETL && item1.poso == 7).setp) && item2.SGF_ == SGF_).x___) * 10),
        //            (int)((SETG.Find(item2 => item2.SETP == (SETP.Find(item1 => item1.SETL == SETL && item1.poso == 7).setp) && item2.SGF_ == SGF_).y___) * -10)
        //        );
        //        poso7.playerXY.Offset(LOS);
        //    }
        //    catch { }
        //    Program.drawPlayerCircle(g, Color.White, poso7, 12);
        //    progressBar1.Increment(1);

        //    try
        //    {
        //        poso8.playerXY = new Point
        //        (
        //            (int)((SETG.Find(item2 => item2.SETP == (SETP.Find(item1 => item1.SETL == SETL && item1.poso == 8).setp) && item2.SGF_ == SGF_).x___) * 10),
        //            (int)((SETG.Find(item2 => item2.SETP == (SETP.Find(item1 => item1.SETL == SETL && item1.poso == 8).setp) && item2.SGF_ == SGF_).y___) * -10)
        //        );
        //        poso8.playerXY.Offset(LOS);
        //    }
        //    catch { }
        //    Program.drawPlayerCircle(g, Color.White, poso8, 12);
        //    progressBar1.Increment(1);

        //    try
        //    {
        //        poso9.playerXY = new Point
        //        (
        //            (int)((SETG.Find(item2 => item2.SETP == (SETP.Find(item1 => item1.SETL == SETL && item1.poso == 9).setp) && item2.SGF_ == SGF_).x___) * 10),
        //            (int)((SETG.Find(item2 => item2.SETP == (SETP.Find(item1 => item1.SETL == SETL && item1.poso == 9).setp) && item2.SGF_ == SGF_).y___) * -10)
        //        );
        //        poso9.playerXY.Offset(LOS);
        //    }
        //    catch { }
        //    Program.drawPlayerCircle(g, Color.White, poso9, 12);
        //    progressBar1.Increment(1);

        //    try
        //    {
        //        poso10.playerXY = new Point
        //        (
        //            (int)((SETG.Find(item2 => item2.SETP == (SETP.Find(item1 => item1.SETL == SETL && item1.poso == 10).setp) && item2.SGF_ == SGF_).x___) * 10),
        //            (int)((SETG.Find(item2 => item2.SETP == (SETP.Find(item1 => item1.SETL == SETL && item1.poso == 10).setp) && item2.SGF_ == SGF_).y___) * -10)
        //        );
        //        poso10.playerXY.Offset(LOS);
        //    }
        //    catch { }
        //    Program.drawPlayerCircle(g, Color.White, poso10, 12);
        //    progressBar1.Increment(1);

        //    picPlay.Image = gImage;
        //}

        private void drawPlay(Graphics g, PLAY play)
        {
            //draw PSALs
            Program.drawRoute(g, play.poso0);
            Program.drawRoute(g, play.poso3);
            Program.drawRoute(g, play.poso4);
            Program.drawRoute(g, play.poso5);
            Program.drawRoute(g, play.poso6);
            Program.drawRoute(g, play.poso7);
            Program.drawRoute(g, play.poso8);
            Program.drawRoute(g, play.poso9);
            Program.drawRoute(g, play.poso10);
            Program.drawRoute(g, play.poso1);
            Program.drawRoute(g, play.poso2);

            //draw player highlight below icons
            Program.drawPlayerHighlight(g, Color.White, play.poso0, 12);
            Program.drawPlayerHighlight(g, Color.White, play.poso1, 12);
            Program.drawPlayerHighlight(g, Color.White, play.poso2, 12);
            Program.drawPlayerHighlight(g, Color.White, play.poso3, 12);
            Program.drawPlayerHighlight(g, Color.White, play.poso4, 12);
            Program.drawPlayerHighlight(g, Color.White, play.poso5, 12);
            Program.drawPlayerHighlight(g, Color.White, play.poso6, 12);
            Program.drawPlayerHighlight(g, Color.White, play.poso7, 12);
            Program.drawPlayerHighlight(g, Color.White, play.poso8, 12);
            Program.drawPlayerHighlight(g, Color.White, play.poso9, 12);
            Program.drawPlayerHighlight(g, Color.White, play.poso10, 12);

            //draw player icons
            Program.drawPlayerCircle(g, Color.White, play.poso0, 12);
            Program.drawPlayerCircle(g, Color.White, play.poso1, 12);
            Program.drawPlayerCircle(g, Color.White, play.poso2, 12);
            Program.drawPlayerCircle(g, Color.White, play.poso3, 12);
            Program.drawPlayerCircle(g, Color.White, play.poso4, 12);
            Program.drawPlayerCircle(g, Color.White, play.poso5, 12);
            Program.drawPlayerCircle(g, Color.White, play.poso6, 12);
            Program.drawPlayerCircle(g, Color.White, play.poso7, 12);
            Program.drawPlayerCircle(g, Color.White, play.poso8, 12);
            Program.drawPlayerCircle(g, Color.White, play.poso9, 12);
            Program.drawPlayerCircle(g, Color.White, play.poso10, 12);

            picPlay.Image = gImage;
            g.Dispose();
        }

        private PSALroute getSTEPs(int PSALposo)
        {
            //Return all PSAL entries for given PSALposo (PSAL ID), sorted by steps
            PSALroute pSALroute = new PSALroute();

            pSALroute.steps = (from row in PSLO
                               where row.psal == PSALposo
                               select new PSALroute.Steps()
                               {
                                   rec = row.rec,
                                   val1 = row.val1,
                                   val2 = row.val2,
                                   val3 = row.val3,
                                   PSAL = row.psal,
                                   code = row.code,
                                   step = row.step,
                               }).ToList().OrderBy(s => s.step).Cast<PSALroute.Steps>().ToList();

            return pSALroute;
        }
    }
}
