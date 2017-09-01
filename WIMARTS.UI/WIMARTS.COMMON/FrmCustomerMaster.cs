using System;
using System.Windows.Forms; using System.Diagnostics;
using RedRapidUI;
using WIMARTS.DB.BLL;
using WIMARTS.DB.BusinessObjects;

namespace WIMARTS.COMMON
{
    public partial class FrmCustomerMaster : Form
    {
        #region Private Members
        UserMaster curUser;
        RedCRUDAS.eCRUDASState eState;
        BLLManager bllMgr;

        #endregion

        #region FORM EVENTS

        public FrmCustomerMaster(UserMaster oCurUser)
        {
            InitializeComponent();
            curUser = oCurUser;
            eState = RedCRUDAS.eCRUDASState.Find;
            InitializeRADUI();
        }
        public FrmCustomerMaster(UserMaster oCurUser, RedCRUDAS.eCRUDASState State)
        {
            InitializeComponent();
            curUser = oCurUser;
            eState = State;
            InitializeRADUI();
        }
        private void FrmCustomerMaster_Load(object sender, EventArgs e)
        {
           LoadDBData();
            redCRUDAS1.ButtonsSkipped = RedCRUDAS.eCRUDASButtons.CUSTB3 | RedCRUDAS.eCRUDASButtons.CUSTB1 | RedCRUDAS.eCRUDASButtons.CUSTB2 | RedCRUDAS.eCRUDASButtons.CUSTB4 | RedCRUDAS.eCRUDASButtons.CUSTB5 | RedCRUDAS.eCRUDASButtons.CUSTB6;
            redCRUDAS1.TrackChange = false;
            redCRUDAS1.RADUI_State = RedCRUDAS.eCRUDASState.Find;
        }
        private void FrmCustomerMaster_Shown(object sender, EventArgs e)
        {
            //   this.WindowState = FormWindowState.Normal;
            if (eState == RedCRUDAS.eCRUDASState.New)
            {
                redCRUDAS1.Operation_BtnClick(RedCRUDAS.tagCREATE);
            }
        }

        private void FrmCustomerMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (redCRUDAS1.RADUI_State == RedCRUDAS.eCRUDASState.Edit || redCRUDAS1.RADUI_State == RedCRUDAS.eCRUDASState.New)
            {
                DialogResult drs = MessageBox.Show("In Edit Mode/n Press OK to Continue", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (drs == DialogResult.OK)
                    e.Cancel = false;
                else
                    e.Cancel = true;
            }
        }
        private void txtCustName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //ValidateData();
            if (txtCustName.Text == "")
            {
                epErrors.SetError(txtCustName, "Customer Name name must be entered.");
                txtCustName.Focus();

            }
            else epErrors.Clear();
        }

        private void TBX_Address_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (TBX_Address.Text == "")
            {
                epErrors.SetError(TBX_Address, "Address must be entered.");
                TBX_Address.Focus();

            }
            else epErrors.Clear();
        }

        private void TXT_City_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (TXT_City.Text == "")
            {
                epErrors.SetError(TXT_City, "City must be entered.");
                TXT_City.Focus();

            }
            else epErrors.Clear();
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
                case RedCRUDAS.tagSEARCH:
                    epErrors.Clear();
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
        private void PAN_RecordInfo_SizeChanged(object sender, EventArgs e)
        {

        }
        #endregion RADUI CONTROL EVENTS

        #region DB & CONTROL OPERATIONS

        private CustomerMaster m_dbBusObj;

        private void InitializeRADUI()
        {
            bllMgr = new BLLManager();
            redGridControl1.dbBindingSrc.DataSource = typeof(CustomerMaster);

            redGridControl1.dgMainData_OnClick += new RedGridControl.GridControl_ClickHandler(GridControl_Clicked);

            redCRUDAS1.CRUDAS_Click += new RedCRUDAS.CRUDAS_ClickHandler(redCRUDAS1_Clicked);
            redCRUDAS1.RADUI_DataPanel = PAN_RecordInfo;
            redCRUDAS1.RADUI_DataGridView = redGridControl1;
            redCRUDAS1.ButtonsSkipped = RedCRUDAS.eCRUDASButtons.CUSTB3 | RedCRUDAS.eCRUDASButtons._NONE;

            SetupDBnUILink();
        }
        private void SetupDBnUILink()
        {
            redGridControl1.SetBindingTXT(txtCustName, () => m_dbBusObj.CustName);
            redGridControl1.SetBindingTXT(txtEmailID1, () => m_dbBusObj.EmailID);
            redGridControl1.SetBindingTXT(txtPhoneNum1, () => m_dbBusObj.PhoneNum);
            redGridControl1.SetBindingTXT(txtWebsite, () => m_dbBusObj.WebSite);
            redGridControl1.SetBindingTXT(TBX_Address, () => m_dbBusObj.AddrLine);
            redGridControl1.SetBindingTXT(TXT_City, () => m_dbBusObj.City);
            redGridControl1.SetBindingTXT(txtpincode, () => m_dbBusObj.Pincode);
            redGridControl1.SetBindingTXT(txtAdditionalInfo, () => m_dbBusObj.Remarks);
        }

        private void LoadDBData()
        {
            System.Data.DataTable dt = bllMgr.CustomerMasterBLL.GetCustomerMasterList();
            redGridControl1.LoadGridData(dt);
        }

        private bool NewRecord()
        {
            m_dbBusObj = new CustomerMaster();
            redGridControl1.dbBindingSrc.Clear(); 
            redGridControl1.dbBindingSrc.Add(m_dbBusObj);
            txtCustName.Focus();
            return true;
        }
        private bool EditRecord()
        {
            txtCustName.Focus();
            return true;
        }

        private bool SaveRecord()
        {
            bool flag = false;
            try
            {
                int oCustID = -1;
                if (ValidateData() != false)
                {
                    string Msg4User = string.Empty;
                    redGridControl1.dbBindingSrc.EndEdit();
                    switch (redCRUDAS1.RADUI_State)
                    {
                        case RedRapidUI.RedCRUDAS.eCRUDASState.New:
                            m_dbBusObj.LUDate = Convert.ToDateTime(DateTime.Now.Date);
                            oCustID = bllMgr.CustomerMasterBLL.AddCustomerMaster(m_dbBusObj);
                           Msg4User = "Record Added Successfully";
                            break;
                        case RedRapidUI.RedCRUDAS.eCRUDASState.Edit:
                            m_dbBusObj.LUDate = Convert.ToDateTime(DateTime.Now.Date);
                            bllMgr.CustomerMasterBLL.UpdateCustomerMaster(m_dbBusObj);
                            Msg4User = "Record Updated Successfully";
                            break;
                        case RedRapidUI.RedCRUDAS.eCRUDASState.Find:
                            Msg4User = "You are in find Mode Cannot Edit or Update Record";
                            break;
                    }
                    MessageBox.Show(Msg4User, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);       
                    redCRUDAS1.RADUI_State = RedCRUDAS.eCRUDASState.Find;
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
                if (txtCustName.Text.Trim() == "") { MessageBox.Show("Enter Customer's Legal Name", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); txtCustName.Focus(); return false; }
                          
              
                if (TBX_Address.Text.Trim() == "") { MessageBox.Show("Enter Address", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); TBX_Address.Focus(); return false; }
                if (TXT_City.Text.Trim() == "") { MessageBox.Show("Enter City", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); TXT_City.Focus(); return false; }
            
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
                m_dbBusObj.CustID = redGridControl1.GetGridVal(0, curSelectedRow);

                if (MessageBox.Show("Are you sure to delete selected record?", this.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (m_dbBusObj != null)
                    {
                        bllMgr.CustomerMasterBLL.RemoveCustomerMaster(m_dbBusObj);
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
                m_dbBusObj = bllMgr.CustomerMasterBLL.GetCustomerMaster(redGridControl1.GetGridVal(0, recordNum));
                redGridControl1.dbBindingSrc.Add(m_dbBusObj);
               return true;
            }
            return false;
        }

     
        private bool DisplayReport()
        {
            //ReportCustomer rpt = new ReportCustomer();
            //FrmReport cryViewer = new FrmReport();
            //RptDataset ds = GetRptDS();
            //rpt.SetDataSource(ds);
            //cryViewer.crystalReportViewer1.ReportSource = rpt;
            //cryViewer.ShowDialog();
            return true;
        }

        #endregion DB & CONTROL OPERATIONS

    
    }
}