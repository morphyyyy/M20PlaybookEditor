using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Playbook_Editor
{
    public partial class frmPLRR : Form
    {
        public List<PLRR> PSAL_PLRR_ARTL;
        private Point mouseLocation, mousePos;
        public PLYS DefaultPSAL;
        private frmPlaybook playbookFormRef;

        public frmPLRR(frmPlaybook playbookFormHandle)
        {
            playbookFormRef = playbookFormHandle;
            InitializeComponent();
        }

        private void frmPLRR_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void frmPLRR_MouseMove(object sender, MouseEventArgs e)
        {
            while (e.Button == MouseButtons.Left)
            {
                mousePos = MousePosition;
                mousePos.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePos;
                break;
            }
        }

        private void frmPLRR_Deactivate(object sender, EventArgs e)
        {
            Close();
        }

        private void frmPLRR_Load(object sender, EventArgs e)
        {
            cbxPLRR.ValueMember = null;
            cbxPLRR.DisplayMember = "name";
            cbxPLRR.DataSource = PSAL_PLRR_ARTL.Distinct().ToList();

            cbxPLRR.SelectedItem = (cbxPLRR.Items.Cast<PLRR>().ToList()).Find(item => item.plrr == DefaultPSAL.PLRR);

            cbxPSAL.ValueMember = null;
            cbxPSAL.DisplayMember = "psal";
            cbxPSAL.DataSource = PSAL_PLRR_ARTL.Where(psal => psal.plrr == ((PLRR)cbxPLRR.SelectedItem).plrr).OrderBy(s => s.psal).ToList();

            cbxPSAL.SelectedItem = (cbxPSAL.Items.Cast<PLRR>().ToList()).Find(item => item.psal == DefaultPSAL.PSAL);
        }

        private void cbxPLRR_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxPSAL.ValueMember = null;
            cbxPSAL.DisplayMember = "psal";
            cbxPSAL.DataSource = PSAL_PLRR_ARTL.Where(psal => psal.plrr == ((PLRR)cbxPLRR.SelectedItem).plrr).OrderBy(s => s.psal).ToList();
        }

        private void cbxPSAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            int dgvRow = playbookFormRef.dgvPLYS.CurrentCell.RowIndex;
            int dgvCol = playbookFormRef.dgvPLYS.CurrentCell.ColumnIndex;

            playbookFormRef.Play.PLYS[playbookFormRef.dgvPLYS.SelectedCells[0].RowIndex] = new PLYS
            {
                rec = playbookFormRef.Play.PLYS[playbookFormRef.dgvPLYS.SelectedCells[0].RowIndex].rec,
                PSAL = ((PLRR)cbxPSAL.SelectedItem).psal,
                ARTL = ((PLRR)cbxPSAL.SelectedItem).artl,
                PLYL = playbookFormRef.Play.PLYS[playbookFormRef.dgvPLYS.SelectedCells[0].RowIndex].PLYL,
                PLRR = ((PLRR)cbxPSAL.SelectedItem).plrr,
                poso = playbookFormRef.Play.PLYS[playbookFormRef.dgvPLYS.SelectedCells[0].RowIndex].poso
            };
            playbookFormRef.SetPlay(playbookFormRef.Play);
            playbookFormRef.Play = playbookFormRef.GetPlay();
            playbookFormRef.UpdatePlay(playbookFormRef.Play);

            playbookFormRef.dgvPLYS.CurrentCell = playbookFormRef.dgvPLYS[dgvCol, dgvRow];
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            int dgvRow = playbookFormRef.dgvPLYS.CurrentCell.RowIndex;
            int dgvCol = playbookFormRef.dgvPLYS.CurrentCell.ColumnIndex;

            cbxPLRR.SelectedItem = (cbxPLRR.Items.Cast<PLRR>().ToList()).Find(item => item.plrr == DefaultPSAL.PLRR);
            cbxPSAL.SelectedItem = (cbxPSAL.Items.Cast<PLRR>().ToList()).Find(item => item.psal == DefaultPSAL.PSAL);

            playbookFormRef.Play.PLYS[playbookFormRef.dgvPLYS.SelectedCells[0].RowIndex] = new PLYS
            {
                rec = playbookFormRef.Play.PLYS[playbookFormRef.dgvPLYS.SelectedCells[0].RowIndex].rec,
                PSAL = DefaultPSAL.PSAL,
                ARTL = DefaultPSAL.ARTL,
                PLYL = playbookFormRef.Play.PLYS[playbookFormRef.dgvPLYS.SelectedCells[0].RowIndex].PLYL,
                PLRR = DefaultPSAL.PLRR,
                poso = playbookFormRef.Play.PLYS[playbookFormRef.dgvPLYS.SelectedCells[0].RowIndex].poso
            };
            playbookFormRef.SetPlay(playbookFormRef.Play);
            playbookFormRef.Play = playbookFormRef.GetPlay();
            playbookFormRef.UpdatePlay(playbookFormRef.Play);

            playbookFormRef.dgvPLYS.CurrentCell = playbookFormRef.dgvPLYS[dgvCol, dgvRow];
        }
    }
}
