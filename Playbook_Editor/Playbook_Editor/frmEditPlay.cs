using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Playbook_Editor
{
    public partial class frmEditPlay : Form
    {
        public PLAY Play;

        public frmEditPlay()
        {
            InitializeComponent();

            Hide();
        }

        #region Title Bar

        public Point mouseLocation, mousePos;

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

        private void mnuPBPL_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void mnuPBPL_MouseMove(object sender, MouseEventArgs e)
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

        private void mnuPBPL_DoubleClick(object sender, EventArgs e)
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

        private void frmEditPlay_Load(object sender, EventArgs e)
        {
            #region PBPL

            if (Play.PBPL.Count > 0)
            {
                dgvPBPL.DataSource = Play.PBPL;

                dgvPBPL.Columns["rec"].ReadOnly = true;
                dgvPBPL.Columns["rec"].DefaultCellStyle.BackColor = Color.White;
                dgvPBPL.Columns["rec"].DefaultCellStyle.SelectionBackColor = Color.White;
                dgvPBPL.Columns["rec"].DefaultCellStyle.ForeColor = Color.DarkGray;
                dgvPBPL.Columns["rec"].DefaultCellStyle.SelectionForeColor = Color.DarkGray;

                dgvPBPL.Columns["SETL"].ReadOnly = true;
                dgvPBPL.Columns["SETL"].DefaultCellStyle.BackColor = Color.White;
                dgvPBPL.Columns["SETL"].DefaultCellStyle.SelectionBackColor = Color.White;
                dgvPBPL.Columns["SETL"].DefaultCellStyle.ForeColor = Color.DarkGray;
                dgvPBPL.Columns["SETL"].DefaultCellStyle.SelectionForeColor = Color.DarkGray;

                dgvPBPL.Columns["PLYL"].ReadOnly = true;
                dgvPBPL.Columns["PLYL"].DefaultCellStyle.BackColor = Color.White;
                dgvPBPL.Columns["PLYL"].DefaultCellStyle.SelectionBackColor = Color.White;
                dgvPBPL.Columns["PLYL"].DefaultCellStyle.ForeColor = Color.DarkGray;
                dgvPBPL.Columns["PLYL"].DefaultCellStyle.SelectionForeColor = Color.DarkGray;

                dgvPBPL.Visible = true;
                lblPBPL.Visible = true;
                dgvPBPL.AutoResizeColumns();
                Program.ResizeDataGrid(dgvPBPL);
                Width = dgvPBPL.Width + 24;
            }

            #endregion

            #region PLPD

            if (Play.PLPD.Count > 0)
            {
                dgvPLPD.DataSource = Play.PLPD;

                dgvPLPD.Columns["rec"].ReadOnly = true;
                dgvPLPD.Columns["rec"].DefaultCellStyle.BackColor = Color.White;
                dgvPLPD.Columns["rec"].DefaultCellStyle.SelectionBackColor = Color.White;
                dgvPLPD.Columns["rec"].DefaultCellStyle.ForeColor = Color.DarkGray;
                dgvPLPD.Columns["rec"].DefaultCellStyle.SelectionForeColor = Color.DarkGray;

                dgvPLPD.Columns["PLYL"].ReadOnly = true;
                dgvPLPD.Columns["PLYL"].DefaultCellStyle.BackColor = Color.White;
                dgvPLPD.Columns["PLYL"].DefaultCellStyle.SelectionBackColor = Color.White;
                dgvPLPD.Columns["PLYL"].DefaultCellStyle.ForeColor = Color.DarkGray;
                dgvPLPD.Columns["PLYL"].DefaultCellStyle.SelectionForeColor = Color.DarkGray;

                dgvPLPD.Visible = true;
                lblPLPD.Visible = true;
                dgvPLPD.AutoResizeColumns();
                Program.ResizeDataGrid(dgvPLPD);
                Width = dgvPLPD.Width + 24;
            }

            #endregion

            #region PLRD

            if (Play.PLRD.Count > 0)
            {
                dgvPLRD.DataSource = Play.PLRD;

                dgvPLRD.Columns["rec"].ReadOnly = true;
                dgvPLRD.Columns["rec"].DefaultCellStyle.BackColor = Color.White;
                dgvPLRD.Columns["rec"].DefaultCellStyle.SelectionBackColor = Color.White;
                dgvPLRD.Columns["rec"].DefaultCellStyle.ForeColor = Color.DarkGray;
                dgvPLRD.Columns["rec"].DefaultCellStyle.SelectionForeColor = Color.DarkGray;

                dgvPLRD.Columns["PLYL"].ReadOnly = true;
                dgvPLRD.Columns["PLYL"].DefaultCellStyle.BackColor = Color.White;
                dgvPLRD.Columns["PLYL"].DefaultCellStyle.SelectionBackColor = Color.White;
                dgvPLRD.Columns["PLYL"].DefaultCellStyle.ForeColor = Color.DarkGray;
                dgvPLRD.Columns["PLYL"].DefaultCellStyle.SelectionForeColor = Color.DarkGray;

                dgvPLRD.Visible = true;
                lblPLRD.Visible = true;
                dgvPLRD.AutoResizeColumns();
                Program.ResizeDataGrid(dgvPLRD);
            }

            #endregion

            CenterToParent();
            Show();
        }

        private void dgvPBPL_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Play.PBPL = (from row in dgvPBPL.Rows.OfType<DataGridViewRow>()
                         select new PBPL()
                         {
                             rec = (int)row.Cells["rec"].Value,
                             COMF = (int)row.Cells["COMF"].Value,
                             SETL = (int)row.Cells["SETL"].Value,
                             PLYL = (int)row.Cells["PLYL"].Value,
                             SRMM = (int)row.Cells["SRMM"].Value,
                             SITT = (int)row.Cells["SITT"].Value,
                             PLYT = (int)row.Cells["PLYT"].Value,
                             PLF_ = (int)row.Cells["PLF_"].Value,
                             name = row.Cells["name"].Value.ToString(),
                             risk = (int)row.Cells["risk"].Value,
                             motn = (int)row.Cells["motn"].Value,
                             vpos = (int)row.Cells["vpos"].Value
                         }).ToList();

            dgvPBPL.AutoResizeColumns();
            Program.ResizeDataGrid(dgvPBPL);
        }

        private void dgvPLPD_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Play.PLPD = (from row in dgvPLPD.Rows.OfType<DataGridViewRow>()
                         select new PLPD()
                         {
                             rec = (int)row.Cells["rec"].Value,
                             com1 = (int)row.Cells["com1"].Value,
                             con1 = (int)row.Cells["con1"].Value,
                             per1 = (int)row.Cells["per1"].Value,
                             rcv1 = (int)row.Cells["rcv1"].Value,
                             com2 = (int)row.Cells["com2"].Value,
                             con2 = (int)row.Cells["con2"].Value,
                             per2 = (int)row.Cells["per2"].Value,
                             rcv2 = (int)row.Cells["rcv2"].Value,
                             com3 = (int)row.Cells["com3"].Value,
                             con3 = (int)row.Cells["con3"].Value,
                             per3 = (int)row.Cells["per3"].Value,
                             rcv3 = (int)row.Cells["rcv3"].Value,
                             com4 = (int)row.Cells["com4"].Value,
                             con4 = (int)row.Cells["con4"].Value,
                             per4 = (int)row.Cells["per4"].Value,
                             rcv4 = (int)row.Cells["rcv4"].Value,
                             com5 = (int)row.Cells["com5"].Value,
                             con5 = (int)row.Cells["con5"].Value,
                             per5 = (int)row.Cells["per5"].Value,
                             rcv5 = (int)row.Cells["rcv5"].Value,
                             PLYL = (int)row.Cells["PLYL"].Value
                         }).ToList();

            Width = dgvPLPD.Width + 24;
            CenterToParent();
            dgvPLPD.AutoResizeColumns();
            Program.ResizeDataGrid(dgvPLPD);
        }

        private void dgvPLRD_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Play.PLRD = (from row in dgvPLRD.Rows.OfType<DataGridViewRow>()
                         select new PLRD()
                         {
                             rec = (int)row.Cells["rec"].Value,
                             PLYL = (int)row.Cells["PLYL"].Value,
                             hole = (int)row.Cells["hole"].Value
                         }).ToList();

            dgvPLRD.AutoResizeColumns();
            Program.ResizeDataGrid(dgvPLRD);
        }
    }
}
