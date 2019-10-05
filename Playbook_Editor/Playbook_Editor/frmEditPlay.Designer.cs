namespace Playbook_Editor
{
    partial class frmEditPlay
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_Close = new System.Windows.Forms.Button();
            this.mnuPBPL = new System.Windows.Forms.MenuStrip();
            this.dgvPBPL = new System.Windows.Forms.DataGridView();
            this.lblPBPL = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblPLPD = new System.Windows.Forms.Label();
            this.dgvPLPD = new System.Windows.Forms.DataGridView();
            this.lblPLRD = new System.Windows.Forms.Label();
            this.dgvPLRD = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPBPL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPLPD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPLRD)).BeginInit();
            this.SuspendLayout();
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
            this.btn_Close.Location = new System.Drawing.Point(768, 1);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(22, 22);
            this.btn_Close.TabIndex = 12;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            this.btn_Close.MouseEnter += new System.EventHandler(this.btn_Close_MouseEnter);
            this.btn_Close.MouseLeave += new System.EventHandler(this.btn_Close_MouseLeave);
            // 
            // mnuPBPL
            // 
            this.mnuPBPL.BackgroundImage = global::Playbook_Editor.Properties.Resources.Football_toolbar;
            this.mnuPBPL.Location = new System.Drawing.Point(0, 0);
            this.mnuPBPL.Name = "mnuPBPL";
            this.mnuPBPL.Size = new System.Drawing.Size(792, 24);
            this.mnuPBPL.TabIndex = 15;
            this.mnuPBPL.Text = "mnuPlaybook";
            this.mnuPBPL.DoubleClick += new System.EventHandler(this.mnuPBPL_DoubleClick);
            this.mnuPBPL.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mnuPBPL_MouseDown);
            this.mnuPBPL.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mnuPBPL_MouseMove);
            // 
            // dgvPBPL
            // 
            this.dgvPBPL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPBPL.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPBPL.Location = new System.Drawing.Point(12, 52);
            this.dgvPBPL.Name = "dgvPBPL";
            this.dgvPBPL.RowHeadersVisible = false;
            this.dgvPBPL.Size = new System.Drawing.Size(768, 50);
            this.dgvPBPL.TabIndex = 26;
            this.dgvPBPL.Visible = false;
            this.dgvPBPL.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPBPL_CellValueChanged);
            // 
            // lblPBPL
            // 
            this.lblPBPL.AutoSize = true;
            this.lblPBPL.BackColor = System.Drawing.Color.Transparent;
            this.lblPBPL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblPBPL.Location = new System.Drawing.Point(12, 36);
            this.lblPBPL.Name = "lblPBPL";
            this.lblPBPL.Size = new System.Drawing.Size(89, 13);
            this.lblPBPL.TabIndex = 27;
            this.lblPBPL.Text = "PBPL - Play Data";
            this.lblPBPL.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnUpdate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnUpdate.Location = new System.Drawing.Point(359, 287);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 28;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // lblPLPD
            // 
            this.lblPLPD.AutoSize = true;
            this.lblPLPD.BackColor = System.Drawing.Color.Transparent;
            this.lblPLPD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblPLPD.Location = new System.Drawing.Point(12, 119);
            this.lblPLPD.Name = "lblPLPD";
            this.lblPLPD.Size = new System.Drawing.Size(116, 13);
            this.lblPLPD.TabIndex = 30;
            this.lblPLPD.Text = "PLPD - Pass Play Data";
            this.lblPLPD.Visible = false;
            // 
            // dgvPLPD
            // 
            this.dgvPLPD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPLPD.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPLPD.Location = new System.Drawing.Point(12, 135);
            this.dgvPLPD.Name = "dgvPLPD";
            this.dgvPLPD.RowHeadersVisible = false;
            this.dgvPLPD.Size = new System.Drawing.Size(768, 50);
            this.dgvPLPD.TabIndex = 29;
            this.dgvPLPD.Visible = false;
            this.dgvPLPD.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPLPD_CellValueChanged);
            // 
            // lblPLRD
            // 
            this.lblPLRD.AutoSize = true;
            this.lblPLRD.BackColor = System.Drawing.Color.Transparent;
            this.lblPLRD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblPLRD.Location = new System.Drawing.Point(12, 202);
            this.lblPLRD.Name = "lblPLRD";
            this.lblPLRD.Size = new System.Drawing.Size(114, 13);
            this.lblPLRD.TabIndex = 32;
            this.lblPLRD.Text = "PLRD - Run Play Data";
            this.lblPLRD.Visible = false;
            // 
            // dgvPLRD
            // 
            this.dgvPLRD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPLRD.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPLRD.Location = new System.Drawing.Point(12, 218);
            this.dgvPLRD.Name = "dgvPLRD";
            this.dgvPLRD.RowHeadersVisible = false;
            this.dgvPLRD.Size = new System.Drawing.Size(768, 50);
            this.dgvPLRD.TabIndex = 31;
            this.dgvPLRD.Visible = false;
            this.dgvPLRD.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPLRD_CellValueChanged);
            // 
            // frmEditPlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Playbook_Editor.Properties.Resources.chalkboard_2;
            this.ClientSize = new System.Drawing.Size(792, 322);
            this.Controls.Add(this.lblPLRD);
            this.Controls.Add(this.dgvPLRD);
            this.Controls.Add(this.lblPLPD);
            this.Controls.Add(this.dgvPLPD);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblPBPL);
            this.Controls.Add(this.dgvPBPL);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.mnuPBPL);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEditPlay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Play & Formation Tables";
            this.Load += new System.EventHandler(this.frmEditPlay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPBPL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPLPD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPLRD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.MenuStrip mnuPBPL;
        private System.Windows.Forms.DataGridView dgvPBPL;
        private System.Windows.Forms.Label lblPBPL;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblPLPD;
        private System.Windows.Forms.DataGridView dgvPLPD;
        private System.Windows.Forms.Label lblPLRD;
        private System.Windows.Forms.DataGridView dgvPLRD;
    }
}