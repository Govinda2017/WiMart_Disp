using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WIMARTS.UTIL;
using WIMARTS.DB.BusinessObjects;
using WIMARTS.REPORTS;
using WIMARTS.COMMON;

namespace WIMARTS.MANAGER
{
    public partial class FrmMDI : Form
    {
        UserMaster curUser;

        public FrmMDI()
        {
            InitializeComponent();
            menuStrip1.Visible = false;
        }
        private void FrmMDI_Load(object sender, EventArgs e)
        {
            FrmSignIn frm = new FrmSignIn(true);
            DialogResult dlgRes = frm.ShowDialog();
            if (dlgRes == DialogResult.OK)
            {
                //to action
                curUser = frm.userLogged;
                SetAccessControl();
                menuStrip1.Visible = true;
            }
            else
            {
                System.Windows.Forms.Application.Exit();
            }
        }
        private void MdiManager_Shown(object sender, EventArgs e)
        {

        }

        private void tsmiUserMaster_Click(object sender, EventArgs e)
        {
            FrmUserManager frm = new FrmUserManager(curUser); ;
            frm.MdiParent = this;
            frm.Show();
        }

        private void tsmWIMARTSerSetting_Click(object sender, EventArgs e)
        {
            FrmHWCSettings frm = new FrmHWCSettings(); ;
            frm.MdiParent = this;
            frm.Show();
        }

        private void inspectionSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInspectionSettings frm = new FrmInspectionSettings();
            frm.MdiParent = this;
            frm.Show();
        }

        private void dispatchMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDispatchMaster frm = new FrmDispatchMaster(curUser, false);//New/Edit/Delete
            frm.MdiParent = this;
            frm.Show();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDispatchMaster frm = new FrmDispatchMaster(curUser, true);//View Only
            frm.MdiParent = this;
            frm.Show();
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmJobReport frm = new FrmJobReport();
            frm.MdiParent = this;
            frm.Show();
        }

        private void boxWastageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmBoxWastage frm = new FrmBoxWastage();
            frm.MdiParent = this;
            frm.Show();
        }

        private void applicationSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAppSettings frm = new FrmAppSettings();
            frm.MdiParent = this;
            frm.Show();
        }

        private void pickListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WIMARTS.REPORTS.PrintReports.PackListReport(DateTime.Now, this);
        }

        private void companyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCompanyMaster frm = new FrmCompanyMaster(curUser);
            frm.MdiParent = this;
            frm.Show();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCustomerMaster frm = new FrmCustomerMaster(curUser);
            frm.MdiParent = this;
            frm.Show();
        }

        private void SetAccessControl()
        {
            if (curUser.RoleID != 1)
            {
                foreach (ToolStripMenuItem item in menuStrip1.Items)
                {
                    if (curUser.RoleID == 2)
                    {
                        if (item.Tag == "1")
                            item.Visible = false;
                    }
                    else
                    {
                        if (item.Tag == "1" || item.Tag == "2")
                            item.Visible = false;
                    }

                }
            }
        }

        private void transporterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTransporterMaster frm = new FrmTransporterMaster(curUser);
            frm.MdiParent = this;
            frm.Show();
        }
    }
}