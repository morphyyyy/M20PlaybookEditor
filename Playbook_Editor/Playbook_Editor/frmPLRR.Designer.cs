namespace Playbook_Editor
{
    partial class frmPLRR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPLRR));
            this.cbxPLRR = new System.Windows.Forms.ComboBox();
            this.cbxPSAL = new System.Windows.Forms.ComboBox();
            this.lblPLRR = new System.Windows.Forms.Label();
            this.lblPSAL = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbxPLRR
            // 
            this.cbxPLRR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPLRR.FormattingEnabled = true;
            this.cbxPLRR.Location = new System.Drawing.Point(114, 12);
            this.cbxPLRR.Name = "cbxPLRR";
            this.cbxPLRR.Size = new System.Drawing.Size(191, 21);
            this.cbxPLRR.TabIndex = 0;
            this.cbxPLRR.SelectionChangeCommitted += new System.EventHandler(this.cbxPLRR_SelectedIndexChanged);
            // 
            // cbxPSAL
            // 
            this.cbxPSAL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPSAL.FormattingEnabled = true;
            this.cbxPSAL.Location = new System.Drawing.Point(114, 39);
            this.cbxPSAL.Name = "cbxPSAL";
            this.cbxPSAL.Size = new System.Drawing.Size(191, 21);
            this.cbxPSAL.TabIndex = 1;
            this.cbxPSAL.SelectionChangeCommitted += new System.EventHandler(this.cbxPSAL_SelectedIndexChanged);
            // 
            // lblPLRR
            // 
            this.lblPLRR.AutoSize = true;
            this.lblPLRR.BackColor = System.Drawing.Color.Transparent;
            this.lblPLRR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblPLRR.Location = new System.Drawing.Point(9, 17);
            this.lblPLRR.Name = "lblPLRR";
            this.lblPLRR.Size = new System.Drawing.Size(99, 13);
            this.lblPLRR.TabIndex = 18;
            this.lblPLRR.Text = "PSAL Type (PLRR)";
            // 
            // lblPSAL
            // 
            this.lblPSAL.AutoSize = true;
            this.lblPSAL.BackColor = System.Drawing.Color.Transparent;
            this.lblPSAL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblPSAL.Location = new System.Drawing.Point(60, 43);
            this.lblPSAL.Name = "lblPSAL";
            this.lblPSAL.Size = new System.Drawing.Size(48, 13);
            this.lblPSAL.TabIndex = 19;
            this.lblPSAL.Text = "PSAL ID";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(12, 39);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(43, 20);
            this.btnReset.TabIndex = 20;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // frmPLRR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Playbook_Editor.Properties.Resources.chalkboard_2;
            this.ClientSize = new System.Drawing.Size(314, 72);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblPSAL);
            this.Controls.Add(this.lblPLRR);
            this.Controls.Add(this.cbxPSAL);
            this.Controls.Add(this.cbxPLRR);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPLRR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmPLRR";
            this.Deactivate += new System.EventHandler(this.frmPLRR_Deactivate);
            this.Load += new System.EventHandler(this.frmPLRR_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmPLRR_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmPLRR_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPLRR;
        private System.Windows.Forms.Label lblPSAL;
        private System.Windows.Forms.Button btnReset;
        public System.Windows.Forms.ComboBox cbxPLRR;
        public System.Windows.Forms.ComboBox cbxPSAL;
    }
}