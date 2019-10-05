namespace Playbook_Editor
{
    partial class frmPlaybook
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlaybook));
            this.mnuPlaybook = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFile_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFile_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBreak_Playbook = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFile_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools_PSALVisualizer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOptions_Field = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOptions_Field_Transparent = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOptions_Field_Default = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOptions_Field_Brown = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOptions_Field_Green = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOptions_Field_Dark = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Max = new System.Windows.Forms.Button();
            this.btn_Min = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cbxFormations = new System.Windows.Forms.ComboBox();
            this.lblFormations = new System.Windows.Forms.Label();
            this.lblSubFormations = new System.Windows.Forms.Label();
            this.cbxSubFormations = new System.Windows.Forms.ComboBox();
            this.lblPlays = new System.Windows.Forms.Label();
            this.cbxPlays = new System.Windows.Forms.ComboBox();
            this.picPlay = new System.Windows.Forms.PictureBox();
            this.dgvPLYS = new System.Windows.Forms.DataGridView();
            this.lblAlignments = new System.Windows.Forms.Label();
            this.cbxAlignments = new System.Windows.Forms.ComboBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.cmsPlayOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editPlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblFileName = new System.Windows.Forms.Label();
            this.btnEditPlayData = new System.Windows.Forms.Button();
            this.mnuPlaybook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPLYS)).BeginInit();
            this.cmsPlayOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuPlaybook
            // 
            this.mnuPlaybook.BackgroundImage = global::Playbook_Editor.Properties.Resources.Football_toolbar;
            this.mnuPlaybook.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuTools,
            this.mnuOptions});
            this.mnuPlaybook.Location = new System.Drawing.Point(0, 0);
            this.mnuPlaybook.Name = "mnuPlaybook";
            this.mnuPlaybook.Size = new System.Drawing.Size(915, 24);
            this.mnuPlaybook.TabIndex = 11;
            this.mnuPlaybook.Text = "mnuPlaybook";
            this.mnuPlaybook.DoubleClick += new System.EventHandler(this.mnuPlaybook_DoubleClick);
            this.mnuPlaybook.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mnuPlaybook_MouseDown);
            this.mnuPlaybook.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mnuPlaybook_MouseMove);
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile_Open,
            this.toolStripSeparator1,
            this.mnuFile_Save,
            this.mnuBreak_Playbook,
            this.mnuFile_Exit});
            this.mnuFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuFile_Open
            // 
            this.mnuFile_Open.Name = "mnuFile_Open";
            this.mnuFile_Open.Size = new System.Drawing.Size(155, 22);
            this.mnuFile_Open.Text = "Open Playbook";
            this.mnuFile_Open.Click += new System.EventHandler(this.mnuFile_Open_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // mnuFile_Save
            // 
            this.mnuFile_Save.Enabled = false;
            this.mnuFile_Save.Name = "mnuFile_Save";
            this.mnuFile_Save.Size = new System.Drawing.Size(155, 22);
            this.mnuFile_Save.Text = "Save Playbook";
            this.mnuFile_Save.Click += new System.EventHandler(this.mnuFile_Save_Click);
            // 
            // mnuBreak_Playbook
            // 
            this.mnuBreak_Playbook.Name = "mnuBreak_Playbook";
            this.mnuBreak_Playbook.Size = new System.Drawing.Size(152, 6);
            // 
            // mnuFile_Exit
            // 
            this.mnuFile_Exit.Name = "mnuFile_Exit";
            this.mnuFile_Exit.Size = new System.Drawing.Size(155, 22);
            this.mnuFile_Exit.Text = "Exit";
            this.mnuFile_Exit.Click += new System.EventHandler(this.mnuFile_Exit_Click);
            // 
            // mnuTools
            // 
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTools_PSALVisualizer});
            this.mnuTools.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(48, 20);
            this.mnuTools.Text = "Tools";
            // 
            // mnuTools_PSALVisualizer
            // 
            this.mnuTools_PSALVisualizer.Name = "mnuTools_PSALVisualizer";
            this.mnuTools_PSALVisualizer.Size = new System.Drawing.Size(153, 22);
            this.mnuTools_PSALVisualizer.Text = "PSAL Visualizer";
            this.mnuTools_PSALVisualizer.Click += new System.EventHandler(this.mnuTools_PSALVisualizer_Click);
            // 
            // mnuOptions
            // 
            this.mnuOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOptions_Field});
            this.mnuOptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mnuOptions.Name = "mnuOptions";
            this.mnuOptions.Size = new System.Drawing.Size(61, 20);
            this.mnuOptions.Text = "Options";
            // 
            // mnuOptions_Field
            // 
            this.mnuOptions_Field.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOptions_Field_Transparent,
            this.mnuOptions_Field_Default,
            this.mnuOptions_Field_Brown,
            this.mnuOptions_Field_Green,
            this.mnuOptions_Field_Dark});
            this.mnuOptions_Field.Name = "mnuOptions_Field";
            this.mnuOptions_Field.Size = new System.Drawing.Size(99, 22);
            this.mnuOptions_Field.Text = "Field";
            // 
            // mnuOptions_Field_Transparent
            // 
            this.mnuOptions_Field_Transparent.Checked = true;
            this.mnuOptions_Field_Transparent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuOptions_Field_Transparent.Name = "mnuOptions_Field_Transparent";
            this.mnuOptions_Field_Transparent.Size = new System.Drawing.Size(137, 22);
            this.mnuOptions_Field_Transparent.Text = "Transparent";
            this.mnuOptions_Field_Transparent.Click += new System.EventHandler(this.mnuOptions_Field_Transparent_Click);
            // 
            // mnuOptions_Field_Default
            // 
            this.mnuOptions_Field_Default.Name = "mnuOptions_Field_Default";
            this.mnuOptions_Field_Default.Size = new System.Drawing.Size(137, 22);
            this.mnuOptions_Field_Default.Text = "Default";
            this.mnuOptions_Field_Default.Click += new System.EventHandler(this.mnuOptions_Field_Default_Click);
            // 
            // mnuOptions_Field_Brown
            // 
            this.mnuOptions_Field_Brown.Name = "mnuOptions_Field_Brown";
            this.mnuOptions_Field_Brown.Size = new System.Drawing.Size(137, 22);
            this.mnuOptions_Field_Brown.Text = "Brown";
            this.mnuOptions_Field_Brown.Click += new System.EventHandler(this.mnuOptions_Field_Brown_Click);
            // 
            // mnuOptions_Field_Green
            // 
            this.mnuOptions_Field_Green.Name = "mnuOptions_Field_Green";
            this.mnuOptions_Field_Green.Size = new System.Drawing.Size(137, 22);
            this.mnuOptions_Field_Green.Text = "Green";
            this.mnuOptions_Field_Green.Click += new System.EventHandler(this.mnuOptions_Field_Green_Click);
            // 
            // mnuOptions_Field_Dark
            // 
            this.mnuOptions_Field_Dark.Name = "mnuOptions_Field_Dark";
            this.mnuOptions_Field_Dark.Size = new System.Drawing.Size(137, 22);
            this.mnuOptions_Field_Dark.Text = "Dark";
            this.mnuOptions_Field_Dark.Click += new System.EventHandler(this.mnuOptions_Field_Dark_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Image = global::Playbook_Editor.Properties.Resources.btn_close;
            this.btn_Close.Location = new System.Drawing.Point(891, 1);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(22, 22);
            this.btn_Close.TabIndex = 8;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            this.btn_Close.MouseEnter += new System.EventHandler(this.btn_Close_MouseEnter);
            this.btn_Close.MouseLeave += new System.EventHandler(this.btn_Close_MouseLeave);
            // 
            // btn_Max
            // 
            this.btn_Max.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Max.BackColor = System.Drawing.Color.Transparent;
            this.btn_Max.FlatAppearance.BorderSize = 0;
            this.btn_Max.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btn_Max.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Max.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Max.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Max.Image = global::Playbook_Editor.Properties.Resources.btn_max;
            this.btn_Max.Location = new System.Drawing.Point(867, 1);
            this.btn_Max.Name = "btn_Max";
            this.btn_Max.Size = new System.Drawing.Size(22, 22);
            this.btn_Max.TabIndex = 9;
            this.btn_Max.UseVisualStyleBackColor = false;
            this.btn_Max.Click += new System.EventHandler(this.btn_Max_Click);
            this.btn_Max.MouseEnter += new System.EventHandler(this.btn_Max_MouseEnter);
            this.btn_Max.MouseLeave += new System.EventHandler(this.btn_Max_MouseLeave);
            // 
            // btn_Min
            // 
            this.btn_Min.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Min.BackColor = System.Drawing.Color.Transparent;
            this.btn_Min.FlatAppearance.BorderSize = 0;
            this.btn_Min.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btn_Min.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Min.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Min.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Min.Image = global::Playbook_Editor.Properties.Resources.btn_min;
            this.btn_Min.Location = new System.Drawing.Point(843, 1);
            this.btn_Min.Name = "btn_Min";
            this.btn_Min.Size = new System.Drawing.Size(22, 22);
            this.btn_Min.TabIndex = 10;
            this.btn_Min.UseVisualStyleBackColor = false;
            this.btn_Min.Click += new System.EventHandler(this.btn_Min_Click);
            this.btn_Min.MouseEnter += new System.EventHandler(this.btn_Min_MouseEnter);
            this.btn_Min.MouseLeave += new System.EventHandler(this.btn_Min_MouseLeave);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cbxFormations
            // 
            this.cbxFormations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFormations.FormattingEnabled = true;
            this.cbxFormations.Location = new System.Drawing.Point(12, 51);
            this.cbxFormations.Name = "cbxFormations";
            this.cbxFormations.Size = new System.Drawing.Size(140, 21);
            this.cbxFormations.Sorted = true;
            this.cbxFormations.TabIndex = 12;
            this.cbxFormations.Visible = false;
            this.cbxFormations.SelectedIndexChanged += new System.EventHandler(this.selectFormation);
            // 
            // lblFormations
            // 
            this.lblFormations.AutoSize = true;
            this.lblFormations.BackColor = System.Drawing.Color.Transparent;
            this.lblFormations.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblFormations.Location = new System.Drawing.Point(12, 35);
            this.lblFormations.Name = "lblFormations";
            this.lblFormations.Size = new System.Drawing.Size(58, 13);
            this.lblFormations.TabIndex = 13;
            this.lblFormations.Text = "Formations";
            this.lblFormations.Visible = false;
            // 
            // lblSubFormations
            // 
            this.lblSubFormations.AutoSize = true;
            this.lblSubFormations.BackColor = System.Drawing.Color.Transparent;
            this.lblSubFormations.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblSubFormations.Location = new System.Drawing.Point(12, 80);
            this.lblSubFormations.Name = "lblSubFormations";
            this.lblSubFormations.Size = new System.Drawing.Size(80, 13);
            this.lblSubFormations.TabIndex = 15;
            this.lblSubFormations.Text = "Sub-Formations";
            this.lblSubFormations.Visible = false;
            // 
            // cbxSubFormations
            // 
            this.cbxSubFormations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSubFormations.FormattingEnabled = true;
            this.cbxSubFormations.Location = new System.Drawing.Point(12, 96);
            this.cbxSubFormations.Name = "cbxSubFormations";
            this.cbxSubFormations.Size = new System.Drawing.Size(140, 21);
            this.cbxSubFormations.Sorted = true;
            this.cbxSubFormations.TabIndex = 14;
            this.cbxSubFormations.Visible = false;
            this.cbxSubFormations.SelectedIndexChanged += new System.EventHandler(this.selectSubFormation);
            // 
            // lblPlays
            // 
            this.lblPlays.AutoSize = true;
            this.lblPlays.BackColor = System.Drawing.Color.Transparent;
            this.lblPlays.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblPlays.Location = new System.Drawing.Point(12, 125);
            this.lblPlays.Name = "lblPlays";
            this.lblPlays.Size = new System.Drawing.Size(32, 13);
            this.lblPlays.TabIndex = 17;
            this.lblPlays.Text = "Plays";
            this.lblPlays.Visible = false;
            // 
            // cbxPlays
            // 
            this.cbxPlays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPlays.FormattingEnabled = true;
            this.cbxPlays.Location = new System.Drawing.Point(12, 141);
            this.cbxPlays.Name = "cbxPlays";
            this.cbxPlays.Size = new System.Drawing.Size(140, 21);
            this.cbxPlays.Sorted = true;
            this.cbxPlays.TabIndex = 16;
            this.cbxPlays.Visible = false;
            this.cbxPlays.SelectedIndexChanged += new System.EventHandler(this.selectPlay);
            this.cbxPlays.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbxPlays_MouseClick);
            this.cbxPlays.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cbxPlays_MouseDown);
            this.cbxPlays.MouseHover += new System.EventHandler(this.cbxPlays_MouseHover);
            // 
            // picPlay
            // 
            this.picPlay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picPlay.BackColor = System.Drawing.Color.Transparent;
            this.picPlay.Image = global::Playbook_Editor.Properties.Resources.field_blank_lines;
            this.picPlay.Location = new System.Drawing.Point(370, 35);
            this.picPlay.Name = "picPlay";
            this.picPlay.Size = new System.Drawing.Size(533, 600);
            this.picPlay.TabIndex = 18;
            this.picPlay.TabStop = false;
            this.picPlay.Click += new System.EventHandler(this.picPlay_Click);
            // 
            // dgvPLYS
            // 
            this.dgvPLYS.AllowUserToAddRows = false;
            this.dgvPLYS.AllowUserToDeleteRows = false;
            this.dgvPLYS.AllowUserToResizeColumns = false;
            this.dgvPLYS.AllowUserToResizeRows = false;
            this.dgvPLYS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPLYS.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPLYS.Location = new System.Drawing.Point(12, 186);
            this.dgvPLYS.MultiSelect = false;
            this.dgvPLYS.Name = "dgvPLYS";
            this.dgvPLYS.RowHeadersVisible = false;
            this.dgvPLYS.RowHeadersWidth = 40;
            this.dgvPLYS.Size = new System.Drawing.Size(300, 300);
            this.dgvPLYS.TabIndex = 20;
            this.dgvPLYS.Visible = false;
            this.dgvPLYS.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPLYS_CellClick);
            this.dgvPLYS.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPLYS_CellEndEdit);
            this.dgvPLYS.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPLYS_CellClick);
            this.dgvPLYS.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPLYS_CellMouseDown);
            this.dgvPLYS.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPLYS_CellValueChanged);
            this.dgvPLYS.SelectionChanged += new System.EventHandler(this.dgvPLYS_SelectionChanged);
            // 
            // lblAlignments
            // 
            this.lblAlignments.AutoSize = true;
            this.lblAlignments.BackColor = System.Drawing.Color.Transparent;
            this.lblAlignments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblAlignments.Location = new System.Drawing.Point(169, 80);
            this.lblAlignments.Name = "lblAlignments";
            this.lblAlignments.Size = new System.Drawing.Size(53, 13);
            this.lblAlignments.TabIndex = 22;
            this.lblAlignments.Text = "Alignment";
            this.lblAlignments.Visible = false;
            // 
            // cbxAlignments
            // 
            this.cbxAlignments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAlignments.Enabled = false;
            this.cbxAlignments.FormattingEnabled = true;
            this.cbxAlignments.Location = new System.Drawing.Point(172, 96);
            this.cbxAlignments.Name = "cbxAlignments";
            this.cbxAlignments.Size = new System.Drawing.Size(140, 21);
            this.cbxAlignments.Sorted = true;
            this.cbxAlignments.TabIndex = 21;
            this.cbxAlignments.Visible = false;
            this.cbxAlignments.SelectedIndexChanged += new System.EventHandler(this.selectAlignment);
            // 
            // cmsPlayOptions
            // 
            this.cmsPlayOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editPlayToolStripMenuItem});
            this.cmsPlayOptions.Name = "cmsPlayOptions";
            this.cmsPlayOptions.Size = new System.Drawing.Size(257, 26);
            this.cmsPlayOptions.Text = "Play Options";
            // 
            // editPlayToolStripMenuItem
            // 
            this.editPlayToolStripMenuItem.Name = "editPlayToolStripMenuItem";
            this.editPlayToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.editPlayToolStripMenuItem.Text = "Edit Play (Name, Type, vpos, etc)...";
            this.editPlayToolStripMenuItem.Click += new System.EventHandler(this.EditPlayData_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFileName.AutoSize = true;
            this.lblFileName.BackColor = System.Drawing.Color.Transparent;
            this.lblFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblFileName.Location = new System.Drawing.Point(9, 623);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(0, 16);
            this.lblFileName.TabIndex = 24;
            // 
            // btnEditPlayData
            // 
            this.btnEditPlayData.Location = new System.Drawing.Point(172, 141);
            this.btnEditPlayData.Name = "btnEditPlayData";
            this.btnEditPlayData.Size = new System.Drawing.Size(84, 21);
            this.btnEditPlayData.TabIndex = 25;
            this.btnEditPlayData.Text = "Edit Play Data";
            this.btnEditPlayData.UseVisualStyleBackColor = true;
            this.btnEditPlayData.Visible = false;
            this.btnEditPlayData.Click += new System.EventHandler(this.EditPlayData_Click);
            this.btnEditPlayData.MouseHover += new System.EventHandler(this.btnEditPlayData_MouseHover);
            // 
            // frmPlaybook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Playbook_Editor.Properties.Resources.chalkboard_2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(915, 651);
            this.Controls.Add(this.btnEditPlayData);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.lblAlignments);
            this.Controls.Add(this.cbxAlignments);
            this.Controls.Add(this.dgvPLYS);
            this.Controls.Add(this.picPlay);
            this.Controls.Add(this.lblPlays);
            this.Controls.Add(this.cbxPlays);
            this.Controls.Add(this.lblSubFormations);
            this.Controls.Add(this.cbxSubFormations);
            this.Controls.Add(this.lblFormations);
            this.Controls.Add(this.cbxFormations);
            this.Controls.Add(this.btn_Min);
            this.Controls.Add(this.btn_Max);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.mnuPlaybook);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuPlaybook;
            this.Name = "frmPlaybook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Playbook";
            this.Click += new System.EventHandler(this.frmPlaybook_Click);
            this.mnuPlaybook.ResumeLayout(false);
            this.mnuPlaybook.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPLYS)).EndInit();
            this.cmsPlayOptions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuPlaybook;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFile_Open;
        private System.Windows.Forms.ToolStripSeparator mnuBreak_Playbook;
        private System.Windows.Forms.ToolStripMenuItem mnuFile_Exit;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Max;
        private System.Windows.Forms.Button btn_Min;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cbxFormations;
        private System.Windows.Forms.Label lblFormations;
        private System.Windows.Forms.Label lblSubFormations;
        private System.Windows.Forms.ComboBox cbxSubFormations;
        private System.Windows.Forms.Label lblPlays;
        private System.Windows.Forms.ComboBox cbxPlays;
        private System.Windows.Forms.PictureBox picPlay;
        private System.Windows.Forms.Label lblAlignments;
        private System.Windows.Forms.ComboBox cbxAlignments;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile_Save;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ToolStripMenuItem mnuTools_PSALVisualizer;
        private System.Windows.Forms.ContextMenuStrip cmsPlayOptions;
        private System.Windows.Forms.ToolStripMenuItem editPlayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuOptions;
        private System.Windows.Forms.ToolStripMenuItem mnuOptions_Field;
        private System.Windows.Forms.ToolStripMenuItem mnuOptions_Field_Default;
        private System.Windows.Forms.ToolStripMenuItem mnuOptions_Field_Brown;
        private System.Windows.Forms.ToolStripMenuItem mnuOptions_Field_Green;
        private System.Windows.Forms.ToolStripMenuItem mnuOptions_Field_Dark;
        private System.Windows.Forms.ToolStripMenuItem mnuOptions_Field_Transparent;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnEditPlayData;
        public System.Windows.Forms.DataGridView dgvPLYS;
    }
}