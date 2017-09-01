using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RedRapidUI;
using WIMARTS.DB.BLL;
using WIMARTS.DB.BusinessObjects;

namespace WIMARTS.COMMON
{
    public partial class FrmSignIn : Form
    {
        #region Private Members
        private BLLManager bllMgr;

        #endregion Private Members

        public UserMaster userLogged { get; set; }

        public FrmSignIn(bool IsMgr)
        {
            InitializeComponent();
            bllMgr = new BLLManager();

            List<UserMaster> lstUsers = new List<UserMaster>();
            if (IsMgr == false)
                lstUsers = bllMgr.UserMasterBLL.GetActiveUsers(0);
            else
            {
                lstUsers.AddRange(bllMgr.UserMasterBLL.GetActiveUsers(Convert.ToInt32(BLLManager.Roles.Admin)));
                lstUsers.AddRange(bllMgr.UserMasterBLL.GetActiveUsers(Convert.ToInt32(BLLManager.Roles.Superviser)));
            }
            cmbUser.DataSource = lstUsers;
            cmbUser.DisplayMember = "Name";
            cmbUser.ValueMember = "UserID";
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            userLogged = bllMgr.UserMasterBLL.UserSignIn(Convert.ToInt32(cmbUser.SelectedValue), Convert.ToString(txtPwd.Text));
            if (userLogged.Name != null)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect UserName or Password\n Try Again!!!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearText();
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult dlgResult = DialogResult.Yes;
            dlgResult = MessageBox.Show("Do u want to cancel", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dlgResult == DialogResult.Yes)
            {
                ClearText();
                this.Close();
            }
        }
        private void ClearText()
        {
            cmbUser.SelectedIndex = -1;
            txtPwd.Clear();
        }


    }
}
