using System;
using System.Windows.Forms; using System.Diagnostics;
using RedRapidUI;
using WIMARTS.DB.BLL;
using WIMARTS.DB.BusinessObjects;

namespace WIMARTS.COMMON
{
    public partial class FrmCompanyMaster : Form
    {
        #region Private Members
        UserMaster curUser;
        BLLManager bllMgr;

        #endregion

        #region FORM EVENTS
        public FrmCompanyMaster(UserMaster oCurUser)
        {
            InitializeComponent();
            InitializeRADUI();
            curUser = oCurUser;
        }

        private void FrmCompanyMaster_Load(object sender, EventArgs e)
        {
            LoadDBData();
            redCRUDAS1.ButtonsSkipped = RedCRUDAS.eCRUDASButtons.CREATE | RedCRUDAS.eCRUDASButtons.DELETE | RedCRUDAS.eCRUDASButtons.CUSTB3 | RedCRUDAS.eCRUDASButtons.CUSTB1 | RedCRUDAS.eCRUDASButtons.CUSTB2 | RedCRUDAS.eCRUDASButtons.CUSTB4 | RedCRUDAS.eCRUDASButtons.CUSTB5 | RedCRUDAS.eCRUDASButtons.CUSTB6;
            redCRUDAS1.TrackChange = false;
            redCRUDAS1.RADUI_State = RedCRUDAS.eCRUDASState.New;
        }
        private void FrmCompanyMaster_Shown(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Normal;
        }

        private void FrmCompanyMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (redCRUDAS1.RADUI_State == RedCRUDAS.eCRUDASState.Edit || redCRUDAS1.RADUI_State == RedCRUDAS.eCRUDASState.New)
            //{
            //    DialogResult drs = MessageBox.Show("In Edit Mode\n Press OK to Continue", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            //    if (drs == DialogResult.OK)
            //        e.Cancel = false;
            //    else
            //        e.Cancel = true;
            //}
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
                    SaveRecord();
                    result =false;
                    break;
                case RedCRUDAS.tagDELETE:
                    result = DeleteRecord();
                    break;
                case RedCRUDAS.tagABORT:
                    result = DisplayRecord(redGridControl1.DGSelectedRec);
                    break;
                case RedCRUDAS.tagSEARCH:
                    result = DisplayRecord(redGridControl1.DGSelectedRec);
                    break;
                case RedCRUDAS.tagCLOSE:
                    this.Close();
                    break;
                case RedCRUDAS.tagCUSTB1:
                    result = DisplayReport();
                    break;
                case RedCRUDAS.tagCUSTB2:
                    break;
            }

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
        private void pbLogo_DoubleClick(object sender, EventArgs e)
        {
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                pbLogo.ImageLocation = ofdImage.FileName;
            }
        }

        #endregion RADUI CONTROL EVENTS

        #region DB & CONTROL OPERATIONS

        private CompanyMaster m_dbBusObj;
        private void InitializeRADUI()
        {
            bllMgr = new BLLManager();
            redGridControl1.dbBindingSrc.DataSource = typeof(CompanyMaster);
            redGridControl1.dgMainData_OnClick += new RedGridControl.GridControl_ClickHandler(GridControl_Clicked);
            redCRUDAS1.CRUDAS_Click += new RedCRUDAS.CRUDAS_ClickHandler(redCRUDAS1_Clicked);
            redCRUDAS1.RADUI_DataPanel = PAN_RecordInfo;
            redCRUDAS1.RADUI_DataGridView = redGridControl1;
            redCRUDAS1.ButtonsSkipped = RedCRUDAS.eCRUDASButtons.CUSTB3 | RedCRUDAS.eCRUDASButtons._NONE;
            SetupDBnUILink();
        }
        private void SetupDBnUILink()
        {
            redGridControl1.SetBindingTXT(txtCompname, () => m_dbBusObj.CompanyName);
            redGridControl1.SetBindingPIC(pbLogo, () => m_dbBusObj.Logo);
            redGridControl1.SetBindingTXT(TBX_Address, () => m_dbBusObj.AddressLine);
            redGridControl1.SetBindingTXT(TXT_City, () => m_dbBusObj.City);
            redGridControl1.SetBindingTXT(txtpincode, () => m_dbBusObj.Pincode);
            redGridControl1.SetBindingTXT(txtPhoneNum, () => m_dbBusObj.PhoneNum);
            redGridControl1.SetBindingTXT(txtEmailID, () => m_dbBusObj.EmailID);
            redGridControl1.SetBindingTXT(txtWebsite, () => m_dbBusObj.WebSite);
            redGridControl1.SetBindingTXT(txtAddInfo, () => m_dbBusObj.Remarks);
        }

        private void LoadDBData()
        {
            System.Data.DataTable dt = bllMgr.CompanyMasterBLL.GetCompanyMasterList();
            redGridControl1.LoadGridData(dt);
        }

        private bool NewRecord()
        {

            m_dbBusObj = new CompanyMaster();
            redGridControl1.dbBindingSrc.Clear();
            redGridControl1.dbBindingSrc.Add(m_dbBusObj);
            txtCompname.Focus();
            return true;
        }
        private bool EditRecord()
        {
            txtCompname.Focus();
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
                            m_dbBusObj.LUDate = Convert.ToDateTime(DateTime.Now.Date);
                            bllMgr.CompanyMasterBLL.AddCompanyMaster(m_dbBusObj);
                            Msg4User = "Record Added Successfully";
                            break;
                        case RedRapidUI.RedCRUDAS.eCRUDASState.Edit:
                            m_dbBusObj.LUDate = Convert.ToDateTime(DateTime.Now.Date);
                            bllMgr.CompanyMasterBLL.UpdateCompanyMaster(m_dbBusObj);
                            Msg4User = "Record Updated Successfully";
                            break;
                        case RedRapidUI.RedCRUDAS.eCRUDASState.Find:
                            Msg4User = "You are in find Mode Cannot Edit or Update Record";
                            break;
                    }
                    MessageBox.Show(Msg4User, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information); redCRUDAS1.RADUI_State = RedCRUDAS.eCRUDASState.Find;
                    int curSelectedRow = redGridControl1.DGSelectedRec;
                    LoadDBData();
                    curSelectedRow = (curSelectedRow < redGridControl1.DGTotalRec) ? curSelectedRow : redGridControl1.DGTotalRec - 1;
                    redGridControl1.dgMainData.Rows[curSelectedRow].Selected = true;
                    DisplayRecord(curSelectedRow);
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                flag = false;
                Trace.TraceError("{0}, {1}", DateTime.Now, ex.Message);
            }
            return flag;
        }


        private bool ValidateData()
        {
            try
            {
                if (txtCompname.Text.Trim() == "") { MessageBox.Show("Enter Company Name", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); txtCompname.Focus(); return false; }
                //if (TBX_Address.Text.Trim() == "") { MessageBox.Show("Enter Address", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); TBX_Address.Focus(); return false; }
                //if (txtPhNum1.Text.Trim() == "") { MessageBox.Show("Enter Phone Number", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); txtPhNum2.Focus(); return false; }
                //if (txtEmailID.Text.Trim() == "") { MessageBox.Show("Enter Email Address", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); txtEmailID.Focus(); return false; }
                if (txtEmailID.Text.Length > 0)
                {
                    if (RedRapidUI.Utilities.IsValidEmailid(txtEmailID.Text.Trim()) == false)
                    {
                        MessageBox.Show("Enter Valid Email Id", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtEmailID.Focus();
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, {1}", DateTime.Now, ex.Message);
                return false;
            }
        }

        private bool DeleteRecord()
        {
            try
            {
                int curSelectedRow = redGridControl1.DGSelectedRec;
                m_dbBusObj.CompanyID = redGridControl1.GetGridVal(0, curSelectedRow);

                if (MessageBox.Show("Are you sure to delete selected record?", this.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (m_dbBusObj != null)
                    {
                        bllMgr.CompanyMasterBLL.RemoveCompanyMaster(m_dbBusObj);
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
                Trace.TraceError("{0}, {1}", DateTime.Now, ex.Message);
            }
            return true;
        }

        private bool DisplayRecord(int recordNum)
        {
            if (recordNum < 0 || recordNum >= redGridControl1.dgMainData.RowCount)
                return false;
            if (redGridControl1.dgMainData.RowCount > 0)
            {
                redGridControl1.dbBindingSrc.Remove(m_dbBusObj);
                m_dbBusObj = bllMgr.CompanyMasterBLL.GetCompanyMaster(redGridControl1.GetGridVal(0, recordNum));
                redGridControl1.dbBindingSrc.Add(m_dbBusObj);
                return true;
            }
            return false;
        }


        private bool DisplayReport()
        {

            return true;
        }

        #endregion DB & CONTROL OPERATIONS

    }
}