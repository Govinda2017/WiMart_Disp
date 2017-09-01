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
    public partial class FrmUserManager : Form
    {
        BLLManager bllMgr;
        UserMaster curUser;

        #region FORM EVENTS
        public FrmUserManager(UserMaster oUser)
        {
            InitializeComponent();
            curUser = oUser;
            InitializeRADUI();
        }
        private void FrmUserManager_Load(object sender, EventArgs e)
        {
            LoadDBData();
            if (curUser.RoleID == 1)
            {
                redCRUDAS1.ButtonsSkipped = RedCRUDAS.eCRUDASButtons.CUSTB1 | RedCRUDAS.eCRUDASButtons.CUSTB2 | RedCRUDAS.eCRUDASButtons.CUSTB3 | RedCRUDAS.eCRUDASButtons.CUSTB4 | RedCRUDAS.eCRUDASButtons.CUSTB5 | RedCRUDAS.eCRUDASButtons.CUSTB6;
            }
            else
            {
                redCRUDAS1.ButtonsSkipped = RedCRUDAS.eCRUDASButtons.CREATE | RedCRUDAS.eCRUDASButtons.DELETE | RedCRUDAS.eCRUDASButtons.CUSTB1 | RedCRUDAS.eCRUDASButtons.CUSTB2 | RedCRUDAS.eCRUDASButtons.CUSTB3 | RedCRUDAS.eCRUDASButtons.CUSTB4 | RedCRUDAS.eCRUDASButtons.CUSTB5 | RedCRUDAS.eCRUDASButtons.CUSTB6;
                CMB_Roles.Enabled = false;
            }
            redCRUDAS1.TrackChange = false;
            redCRUDAS1.RADUI_State = RedCRUDAS.eCRUDASState.Find;

            CMB_Roles.DataSource = bllMgr.RoleMasterBLL.GetRoleMasters();
            CMB_Roles.DisplayMember = "Name";
            CMB_Roles.ValueMember = "RoleID";
        }

        private void FrmUserManager_Shown(object sender, EventArgs e)
        {

        }
        #endregion FORM EVENTS

        #region RADUI CONTROL EVENTS
        private void TrackChange_NewEdit(object sender, EventArgs e)
        {
            redCRUDAS1.DataChanged(true);
        }
        private bool redCRUDAS1_Clicked(object sender, string Action)
        {
            bool result = false;

            switch (Action)
            {
                case RedCRUDAS.tagCREATE:
                    result = NewRecord();
                    break;
                case RedCRUDAS.tagRECREATE:
                    result = EditRecord();
                    break;
                case RedCRUDAS.tagUPDATE:
                    result = SaveRecord();
                    break;
                case RedCRUDAS.tagDELETE:
                    result = DeleteRecord();
                    break;
                case RedCRUDAS.tagABORT:
                    result = DisplayRecord(redGridControl1.DGSelectedRec);
                    break;
                case RedCRUDAS.tagCLOSE:
                    this.Close();
                    break;
                case RedCRUDAS.tagSEARCH:
                    result = DisplayRecord(redGridControl1.DGSelectedRec);
                    break;
                case RedCRUDAS.tagCUSTB1:
                    this.Close();
                    //result = DisplayReport();
                    break;
            }
            if (curUser.RoleID != 1) { CMB_Roles.Enabled = false; CHK_Active.Enabled = false; }
            return result;
        }
        private bool GridControl_Clicked(object sender, string Action, int index)
        {
            bool result = false;
            switch (Action)
            {
                case RedGridControl.tagCELLCLICK:
                    result = DisplayRecord(index);
                    break;
                case RedGridControl.tagROWENTER:
                    result = DisplayRecord(index);
                    break;
            }
            return result;
        }
        #endregion RADUI CONTROL EVENTS

        #region DB & CONTROL OPERATIONS
        private UserMaster m_dbBusObj;
        private void InitializeRADUI()
        {
            bllMgr = new BLLManager();
            redGridControl1.dbBindingSrc.DataSource = typeof(UserMaster);
            redGridControl1.dgMainData_OnClick += new RedGridControl.GridControl_ClickHandler(GridControl_Clicked);

            redCRUDAS1.CRUDAS_Click += new RedCRUDAS.CRUDAS_ClickHandler(redCRUDAS1_Clicked);
            redCRUDAS1.RADUI_DataPanel = PAN_RecordInfo;
            redCRUDAS1.RADUI_DataGridView = redGridControl1;
            redCRUDAS1.ButtonsSkipped = RedCRUDAS.eCRUDASButtons._NONE;

            SetupDBnUILink();
        }
        private void SetupDBnUILink()
        {
            redGridControl1.SetBindingTXT(TXT_UserName, () => m_dbBusObj.Name);
            redGridControl1.SetBindingTXT(TXT_Password, () => m_dbBusObj.Password);
            redGridControl1.SetBindingTXT(TXT_ConfirmPassword, () => m_dbBusObj.Password);
            redGridControl1.SetBindingCMBValue(CMB_Roles, () => m_dbBusObj.RoleID);
            redGridControl1.SetBindingCHK(CHK_Active, () => m_dbBusObj.Active);
        }
        private void cleardata()
        {
            //cbsActive.Checked = false;
            TXT_ConfirmPassword.Text = "";
        }
        private void LoadDBData()
        {
            DataTable dt = bllMgr.UserMasterBLL.GetUserMasterList(curUser.RoleID, curUser.UserID);
            redGridControl1.LoadGridData(dt);
        }
        private bool NewRecord()
        {
            m_dbBusObj = new UserMaster();
            m_dbBusObj.Active = true;

            redGridControl1.dbBindingSrc.Clear();
            redGridControl1.dbBindingSrc.Add(m_dbBusObj);

            CHK_Active.Checked = true;
            TXT_UserName.Focus();
            return true;
        }
        private bool EditRecord()
        {
            TXT_UserName.Focus();
            return true;
        }
        private bool SaveRecord()
        {
            bool flag = false;
            try
            {
                if (ValidateData() != false)
                {
                    string Msg4User = string.Empty;
                    redGridControl1.dbBindingSrc.EndEdit();

                    switch (redCRUDAS1.RADUI_State)
                    {
                        case RedRapidUI.RedCRUDAS.eCRUDASState.New:
                            m_dbBusObj.Active = CHK_Active.Checked;
                            bllMgr.UserMasterBLL.AddUserMaster(m_dbBusObj);
                            Msg4User = "Record Added Successfully";
                            break;
                        case RedRapidUI.RedCRUDAS.eCRUDASState.Edit:
                            bllMgr.UserMasterBLL.UpdateUserMaster(m_dbBusObj);
                            Msg4User = "Record Updated Successfully";
                            break;
                        case RedRapidUI.RedCRUDAS.eCRUDASState.Find:
                            Msg4User = "You are in find Mode Cannot Edit or Update Record";
                            break;
                    }

                    MessageBox.Show(Msg4User, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDBData();
                    int curSelectedRow = redGridControl1.DGSelectedRec;
                    curSelectedRow = (curSelectedRow < redGridControl1.DGTotalRec) ? curSelectedRow : redGridControl1.DGTotalRec - 1;
                    redGridControl1.dgMainData.Rows[curSelectedRow].Selected = true;
                    cleardata();
                    DisplayRecord(curSelectedRow);
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                flag = false;
                throw ex;
            }
            return flag;
        }
        private bool DeleteRecord()
        {
            try
            {
                int curSelectedRow = redGridControl1.DGSelectedRec;
                m_dbBusObj.UserID = redGridControl1.GetGridVal(0, curSelectedRow);

                if (MessageBox.Show("Are you sure to delete selected record?", this.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (m_dbBusObj != null)
                    {
                        bllMgr.UserMasterBLL.RemoveUserMaster(m_dbBusObj);
                        LoadDBData();
                        curSelectedRow = (curSelectedRow < redGridControl1.DGTotalRec) ? curSelectedRow : redGridControl1.DGTotalRec - 1;
                        redGridControl1.dgMainData.Rows[curSelectedRow].Selected = true;
                        DisplayRecord(curSelectedRow);
                        MessageBox.Show("Record Deleted Successfully", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        private bool ValidateData()
        {
            try
            {
                if (TXT_UserName.Text.Trim() == "") { MessageBox.Show("PLEASE INSERT USER NAME", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); TXT_UserName.Focus(); return false; }
                if (TXT_Password.Text.Trim() == "") { MessageBox.Show("PLEASE INSERT PASSWORD", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); TXT_Password.Focus(); return false; }
                if (TXT_ConfirmPassword.Text.Trim() == "") { MessageBox.Show("PLEASE CONFIRM PASSWORD", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); TXT_Password.Focus(); return false; }
                //  if (CommonUtil.compare(TXT_Password.Text, TXT_ConfirmPassword.Text)==false) { MessageBox.Show("PASSWORD CONFIRMATION FAILED", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); TXT_ConfirmPassword.Focus(); return false; }
                if (CMB_Roles.Text == "") { MessageBox.Show("PLEASE SELECT ROLE", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); CMB_Roles.Focus(); return false; }

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
        private bool DisplayRecord(int recordNum)
        {
            if (recordNum < 0 || recordNum >= redGridControl1.dgMainData.RowCount)
                return false;
            if (redGridControl1.dgMainData.RowCount > 0)
            {
                redGridControl1.dbBindingSrc.Remove(m_dbBusObj);
                m_dbBusObj = bllMgr.UserMasterBLL.GetUserMaster(redGridControl1.GetGridVal(0, recordNum));
                redGridControl1.dbBindingSrc.Add(m_dbBusObj);
                return true;
            }
            return false;
        }
        #endregion DB & CONTROL OPERATIONS
        private void CMB_Roles_SelectedIndexChanged(object sender, EventArgs e)
        {
            redCRUDAS1.DataChanged(true);
        }
    }
}
