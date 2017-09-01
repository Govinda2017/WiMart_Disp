using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WIMARTS.DB.BLL;
using WIMARTS.DB.BusinessObjects;
using RedRapidUI;
using System.Diagnostics;
using System.Data.OleDb;
using System.IO;

namespace WIMARTS.COMMON
{
    public partial class FrmDispatchMaster : Form
    {

        #region PROPERTIES

        BLLManager bllMgr;
        UserMaster curUserLogged;
        bool ViewMode = false;

        #endregion PROPERTIES

        #region FORM EVENTS

        public FrmDispatchMaster(UserMaster oUserLogged, bool oViewMode)
        {
            InitializeComponent();
            curUserLogged = oUserLogged;
            ViewMode = oViewMode;
            InitializeRADUI();
        }

        private void FrmDispatchMaster_Load(object sender, EventArgs e)
        {
            LoadDBData();
            pnlStatus.Visible = ViewMode;

            if (ViewMode == true)
                redCRUDAS1.ButtonsSkipped = RedCRUDAS.eCRUDASButtons.CREATE | RedCRUDAS.eCRUDASButtons.RECREATE | RedCRUDAS.eCRUDASButtons.DELETE | RedCRUDAS.eCRUDASButtons.CUSTB3 | RedCRUDAS.eCRUDASButtons.CUSTB6;
            else
                redCRUDAS1.ButtonsSkipped = RedCRUDAS.eCRUDASButtons.CUSTB1 | RedCRUDAS.eCRUDASButtons.CUSTB2 | RedCRUDAS.eCRUDASButtons.CUSTB3 | RedCRUDAS.eCRUDASButtons.CUSTB6;

            redCRUDAS1.TrackChange = false;
            redCRUDAS1.RADUI_State = RedCRUDAS.eCRUDASState.Find;
        }
        private void FrmDispatchMaster_Shown(object sender, EventArgs e)
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
                case RedCRUDAS.tagSEARCH:
                    result = DisplayRecord(redGridControl1.DGSelectedRec);
                    break;
                case RedCRUDAS.tagCLOSE:
                    this.Close();
                    break;
                case RedCRUDAS.tagCUSTB1:
                    result = DisplayReport(false);
                    break;
                case RedCRUDAS.tagCUSTB2:
                    result = DisplayReport(true);
                    break;
                case RedCRUDAS.tagCUSTB3:
                    result = ExportSummaryData();
                    break;
                case RedCRUDAS.tagCUSTB4:
                    result = ExportData();
                    // result = DisplayReport();
                    break;
                case RedCRUDAS.tagCUSTB5:
                    result = ExportSummaryData();
                    // result = DisplayReport();
                    break;
                case RedCRUDAS.tagCUSTB6:
                    //result = DisplayReport();
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

        #endregion RADUI CONTROL EVENTS

        #region DB & CONTROL OPERATIONS

        private DispatchMaster m_dbBusObj;

        private void InitializeRADUI()
        {
            bllMgr = new BLLManager();
            redGridControl1.dbBindingSrc.DataSource = typeof(DispatchMaster);
            redGridControl1.dgMainData_OnClick += new RedGridControl.GridControl_ClickHandler(GridControl_Clicked);
            redCRUDAS1.CRUDAS_Click += new RedCRUDAS.CRUDAS_ClickHandler(redCRUDAS1_Clicked);
            redCRUDAS1.RADUI_DataPanel = PAN_RecordInfo;
            redCRUDAS1.RADUI_DataGridView = redGridControl1;
            SetupDBnUILink();
            redCRUDAS1.SetButtonName(RedCRUDAS.tagCUSTB1, "View Summary");
            redCRUDAS1.SetButtonName(RedCRUDAS.tagCUSTB2, "View Details");
            redCRUDAS1.SetButtonName(RedCRUDAS.tagCUSTB5, "Export Summary");
            redCRUDAS1.SetButtonName(RedCRUDAS.tagCUSTB4, "Export Details");

            BindDetails();
            UITagData oUITAGs = new UITagData(true);
            numGoodQty.Tag = numBadQty.Tag = cmbStatus.Tag = oUITAGs;
        }
        private void SetupDBnUILink()
        {
            redGridControl1.SetBindingTXT(txtGDN, () => m_dbBusObj.GDN);
            redGridControl1.SetBindingCMBValue(cmbCustomer, () => m_dbBusObj.CustID);
            redGridControl1.SetBindingCMBValue(cmbTransporter, () => m_dbBusObj.TransporterID);
            redGridControl1.SetBindingTXT(txtDriverName, () => m_dbBusObj.DriverName);
            redGridControl1.SetBindingTXT(txtVehicleNo, () => m_dbBusObj.VehicleNo);
            redGridControl1.SetBindingDTP(dtpDispatchDate, () => m_dbBusObj.DispatchDate);
            redGridControl1.SetBindingDTP(dtpStartDate, () => m_dbBusObj.StartedAt);
            redGridControl1.SetBindingDTP(dtpEndDate, () => m_dbBusObj.CompletedAt);
            redGridControl1.SetBindingCMBIndex(cmbStatus, () => m_dbBusObj.Status);
            redGridControl1.SetBindingNUM(numGoodQty, () => m_dbBusObj.GoodQty);
            redGridControl1.SetBindingNUM(numBadQty, () => m_dbBusObj.BadQty);
            redGridControl1.SetBindingTXT(txtRemarks, () => m_dbBusObj.Remarks);
        }
        private void LoadDBData()
        {
            System.Data.DataTable dt = new DataTable();
            if (ViewMode == true)
                dt = bllMgr.DispatchMasterBLL.GetDispatchMasterList(BLLManager.MasterStatus.All);
            else
                dt = bllMgr.DispatchMasterBLL.GetDispatchMasterList(BLLManager.MasterStatus.Created);
            redGridControl1.LoadGridData(dt);
        }
        private bool NewRecord()
        {
            m_dbBusObj = new DispatchMaster();
            redGridControl1.dbBindingSrc.Clear();
            redGridControl1.dbBindingSrc.Add(m_dbBusObj);
            dtpDispatchDate.Value = DateTime.Now;
            if (dgvDispDetails.Rows.Count > 0)
                dgvDispDetails.Rows.Clear();
            txtGDN.Focus();
            return true;
        }
        private bool EditRecord()
        {
            txtGDN.Focus();
            return true;
        }
        private void SaveDispatchDetails(int oDispMasterID)
        {
            List<DispatchDetails> lstCurDetails = bllMgr.DispatchDetailsBLL.GetDispatchDetailsByDispMaster(DispatchDetailsBLL.Flag.Master, Convert.ToString(oDispMasterID));

            int uiRecCount = dgvDispDetails.Rows.Count;
            int dbRecCount = lstCurDetails.Count;

            int maxRecCounts = uiRecCount > dbRecCount ? uiRecCount : dbRecCount;
            int minRecCounts = uiRecCount < dbRecCount ? uiRecCount : dbRecCount;

            string operPerformed = string.Empty;

            DispatchDetails oDispatchDetails = new DispatchDetails();
            for (int i = 0; i < maxRecCounts; i++)
            {
                if (i >= minRecCounts && dbRecCount > uiRecCount)
                {//Remove i rec
                    operPerformed += ("D" + i);
                    bllMgr.DispatchDetailsBLL.RemoveDispatchDetails(lstCurDetails[i]);
                    continue;
                }
                oDispatchDetails = new DispatchDetails();
                DataGridViewRow datarow = dgvDispDetails.Rows[i];
                oDispatchDetails.DispMasterID = oDispMasterID;
                // oDispatchDetails.SrNo = Convert.ToInt32(datarow.Cells["SrNo"].Value);
                oDispatchDetails.ProdCode = Convert.ToString(datarow.Cells["DDProductCodeColumn"].Value);
                oDispatchDetails.QtytoDispatch = Convert.ToDecimal(datarow.Cells["DDProductGivenQtyColumn"].Value);
                oDispatchDetails.MinQty = Convert.ToDecimal(datarow.Cells["DDProductMinQtyColumn"].Value);
                oDispatchDetails.MaxQty = Convert.ToDecimal(datarow.Cells["DDProductMaxQtyColumn"].Value);
                oDispatchDetails.DispatchedQty = 0;
                oDispatchDetails.Remark = Convert.ToString(datarow.Cells["DDProductRemarksColumn"].Value);
                oDispatchDetails.LUDate = DateTime.Now;

                if (i >= minRecCounts && uiRecCount > dbRecCount)
                {// Insert I rec
                    operPerformed += ("I" + i);
                    oDispatchDetails.DispDetailsID = 0;
                    oDispatchDetails.CreatedDate = DateTime.Now;
                    bllMgr.DispatchDetailsBLL.AddDispatchDetails(oDispatchDetails);
                }
                else
                {// Update i rec
                    operPerformed += ("U" + i);
                    oDispatchDetails.DispDetailsID = lstCurDetails[i].DispDetailsID;
                    oDispatchDetails.CreatedDate = lstCurDetails[i].CreatedDate;
                    bllMgr.DispatchDetailsBLL.UpdateDispatchDetails(oDispatchDetails);
                }
            }
            Trace.TraceInformation("{0}, {1}", DateTime.Now, operPerformed);
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
                    m_dbBusObj.LUDate = DateTime.Now;
                    m_dbBusObj.CreatedBy = curUserLogged.UserID;
                    switch (redCRUDAS1.RADUI_State)
                    {
                        case RedRapidUI.RedCRUDAS.eCRUDASState.New:
                            m_dbBusObj.CreatedDate = DateTime.Now;
                            int DispMasterID = bllMgr.DispatchMasterBLL.AddDispatchMaster(m_dbBusObj);
                            SaveDispatchDetails(DispMasterID);
                            Msg4User = "Record Added Successfully";
                            break;
                        case RedRapidUI.RedCRUDAS.eCRUDASState.Edit:
                            bllMgr.DispatchMasterBLL.UpdateDispatchMaster(m_dbBusObj);
                            SaveDispatchDetails(m_dbBusObj.DispMasterID);
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
                    DisplayRecord(curSelectedRow);
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                flag = false;
                Trace.TraceError("{0}, {1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
                return flag;
            }
            return flag;
        }
        private bool ValidateData()
        {
            try
            {
                // Validation of data Input for Saving...
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
        private bool DeleteRecord()
        {
            try
            {
                int curSelectedRow = redGridControl1.DGSelectedRec;
                m_dbBusObj.DispMasterID = redGridControl1.GetGridVal(0, curSelectedRow);

                if (MessageBox.Show("Are you sure to delete selected record?", this.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (m_dbBusObj != null)
                    {
                        bllMgr.DispatchMasterBLL.RemoveDispatchMaster(m_dbBusObj);
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
        private bool DisplayRecord(int recordNum)
        {
            if (recordNum < 0 || recordNum >= redGridControl1.dgMainData.RowCount)
                return false;
            if (redGridControl1.dgMainData.RowCount > 0)
            {
                if (dgvDispDetails.Rows.Count > 0)
                    dgvDispDetails.Rows.Clear();

                if (recordNum < 0 || recordNum >= redGridControl1.dgMainData.RowCount)
                    return false;
                if (redGridControl1.dgMainData.RowCount > 0)
                {
                    redGridControl1.dbBindingSrc.Remove(m_dbBusObj);
                    m_dbBusObj = bllMgr.DispatchMasterBLL.GetDispatchMaster(redGridControl1.GetGridVal(0, recordNum));
                    redGridControl1.dbBindingSrc.Add(m_dbBusObj);
                    if (m_dbBusObj.TransporterID.HasValue)
                        cmbTransporter.SelectedValue = m_dbBusObj.TransporterID;
                    List<DispatchDetails> DetailsList = bllMgr.DispatchDetailsBLL.GetDispatchDetailsByDispMaster(DispatchDetailsBLL.Flag.Master, redGridControl1.GetGridValS(0, recordNum));

                    if (DetailsList.Count > 0)
                    {
                        dgvDispDetails.Rows.Add(DetailsList.Count);
                        dgvDispDetails.ClearSelection();
                    }

                    int lstID = 0;
                    foreach (DataGridViewRow item in dgvDispDetails.Rows)
                    {
                        item.Cells["DDDispDetailsIDColumn"].Value = DetailsList[lstID].DispDetailsID;
                        item.Cells["DDSrNoColumn"].Value = lstID + 1;
                        item.Cells["DDProductCodeColumn"].Value = DetailsList[lstID].ProdCode;
                        item.Cells["DDProductNameColumn"].Value = lstProducts.Find(x => x.Code == DetailsList[lstID].ProdCode).Name;
                        item.Cells["DDProductGivenQtyColumn"].Value = DetailsList[lstID].QtytoDispatch;
                        item.Cells["DDProductMaxQtyColumn"].Value = DetailsList[lstID].MaxQty;
                        item.Cells["DDProductMinQtyColumn"].Value = DetailsList[lstID].MinQty;
                        item.Cells["DDProductDispatchedQtyColumn"].Value = DetailsList[lstID].DispatchedQty;
                        item.Cells["DDProductRemarksColumn"].Value = DetailsList[lstID].Remark;
                        lstID++;
                    }
                    return true;
                }
            }
            return false;
        }

        List<ProductMaster> lstProducts = new List<ProductMaster>();

        private void BindDetails()
        {
            lstProducts = bllMgr.ProductMasterBLL.GetProductMasters();
            cmbProductCode.DataSource = lstProducts;
            cmbProductCode.DisplayMember = "Code";
            cmbProductCode.ValueMember = "ProdID";

            cmbProductName.DataSource = lstProducts;
            cmbProductName.DisplayMember = "Name";
            cmbProductName.ValueMember = "ProdID";

            DDProductCodeColumn.DataSource = bllMgr.ProductMasterBLL.GetProductMasters();
            DDProductCodeColumn.DisplayMember = "Code";
            DDProductCodeColumn.ValueMember = "ProdID";

            cmbCustomer.DataSource = bllMgr.CustomerMasterBLL.GetCustomerMasters();
            cmbCustomer.DisplayMember = "CustName";
            cmbCustomer.ValueMember = "CustID";

            cmbTransporter.DataSource = bllMgr.TransporterDetailsBLL.GetTransporterDetailsList();
            cmbTransporter.DisplayMember = "TransporterName";
            cmbTransporter.ValueMember = "TransporterID";
        }
        private void btnDeleteDetails_Click(object sender, EventArgs e)
        {
            if (dgvDispDetails.SelectedRows.Count > 0)
                dgvDispDetails.Rows.Remove(dgvDispDetails.SelectedRows[0]);
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateProducts();
        }
        private void btnAddDetails_Click(object sender, EventArgs e)
        {
            ProductMaster oProduct = (ProductMaster)cmbProductCode.SelectedItem;
            AddNewProduct(oProduct);
        }
        private void dgvDispDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDispDetails.SelectedRows.Count > 0)
            {
                cmbProductCode.SelectedValue = Convert.ToInt32(lstProducts.Find(x => x.Code == Convert.ToString(dgvDispDetails.SelectedRows[0].Cells["DDProductCodeColumn"].Value)).ProdID);
                numDetailsQty.Value = Convert.ToDecimal(dgvDispDetails.SelectedRows[0].Cells["DDProductGivenQtyColumn"].Value);
                numMinimumQty.Value = Convert.ToDecimal(dgvDispDetails.SelectedRows[0].Cells["DDProductMinQtyColumn"].Value);
                numMaximumQty.Value = Convert.ToDecimal(dgvDispDetails.SelectedRows[0].Cells["DDProductMaxQtyColumn"].Value);
                txtDetailsRemarks.Text = Convert.ToString(dgvDispDetails.SelectedRows[0].Cells["DDProductRemarksColumn"].Value);
            }
        }
        private void dgvDispDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        private void numDetailsQty_ValueChanged(object sender, EventArgs e)
        {
            numMaximumQty.Minimum = numMinimumQty.Maximum = numDetailsQty.Value;
            if (redCRUDAS1.RADUI_State == RedCRUDAS.eCRUDASState.New || redCRUDAS1.RADUI_State == RedCRUDAS.eCRUDASState.Edit)
            {
                numMaximumQty.Value = numMinimumQty.Value = numDetailsQty.Value;
            }

        }
        private void dgvDispDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CalCulateTotalQty();
        }

        private void AddNewProduct(ProductMaster oProduct)
        {
            try
            {
                if (oProduct != null && oProduct.ProdID > 0 && ValidateProduct(oProduct) == true)
                {
                    int RowID = dgvDispDetails.Rows.Add();
                    dgvDispDetails.Rows[RowID].Cells["DDSrNoColumn"].Value = RowID + 1;
                    dgvDispDetails.Rows[RowID].Cells["DDProductCodeColumn"].Value = oProduct.Code;
                    dgvDispDetails.Rows[RowID].Cells["DDProductNameColumn"].Value = oProduct.Name;
                    dgvDispDetails.Rows[RowID].Cells["DDProductGivenQtyColumn"].Value = numDetailsQty.Value;
                    dgvDispDetails.Rows[RowID].Cells["DDProductMinQtyColumn"].Value = numMinimumQty.Value;
                    dgvDispDetails.Rows[RowID].Cells["DDProductMaxQtyColumn"].Value = numMaximumQty.Value;
                    dgvDispDetails.Rows[RowID].Cells["DDProductRemarksColumn"].Value = txtDetailsRemarks.Text;
                    dgvDispDetails.FirstDisplayedScrollingRowIndex = RowID;
                    dgvDispDetails.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, Error:{1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
            }
        }
        private void UpdateProducts()
        {
            try
            {
                if (dgvDispDetails.SelectedRows.Count > 0)
                {
                    int RowID = dgvDispDetails.SelectedRows[0].Index;
                    ProductMaster oProduct = (ProductMaster)cmbProductCode.SelectedItem;
                    if (oProduct != null && oProduct.ProdID > 0 && ValidateUpdateProduct(oProduct, RowID))
                    {
                        dgvDispDetails.Rows[RowID].Cells["DDSrNoColumn"].Value = RowID + 1;
                        dgvDispDetails.Rows[RowID].Cells["DDProductCodeColumn"].Value = oProduct.Code;
                        dgvDispDetails.Rows[RowID].Cells["DDProductNameColumn"].Value = oProduct.Name;
                        dgvDispDetails.Rows[RowID].Cells["DDProductGivenQtyColumn"].Value = numDetailsQty.Value;
                        dgvDispDetails.Rows[RowID].Cells["DDProductMinQtyColumn"].Value = numMinimumQty.Value;
                        dgvDispDetails.Rows[RowID].Cells["DDProductMaxQtyColumn"].Value = numMaximumQty.Value;
                        dgvDispDetails.Rows[RowID].Cells["DDProductRemarksColumn"].Value = txtDetailsRemarks.Text;
                        dgvDispDetails.FirstDisplayedScrollingRowIndex = RowID;
                        dgvDispDetails.ClearSelection();
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, Error:{1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
            }
        }
        private void CalCulateTotalQty()
        {
            int ActualQty = 0;
            int MinQty = 0, MaxQty = 0, DispQty = 0;
            int totalNo = 0;
            foreach (DataGridViewRow item in dgvDispDetails.Rows)
            {
                totalNo = Convert.ToInt32(item.Cells["DDSrNoColumn"].Value);
                ActualQty += Convert.ToInt32(item.Cells["DDProductGivenQtyColumn"].Value);
                MinQty += Convert.ToInt32(item.Cells["DDProductMinQtyColumn"].Value);
                MaxQty += Convert.ToInt32(item.Cells["DDProductMaxQtyColumn"].Value);
                DispQty += Convert.ToInt32(item.Cells["DDProductDispatchedQtyColumn"].Value);
            }
            txtTotalQty.Text = "Total Quantity= " + ActualQty;
        }
        private bool ValidateUpdateProduct(ProductMaster oProduct, int Index)
        {
            foreach (DataGridViewRow item in dgvDispDetails.Rows)
            {
                string SelectedText = Convert.ToString(item.Cells["DDProductNameColumn"].Value);
                if (SelectedText == oProduct.Name)
                {
                    if (item.Index == Index)
                        continue;
                    item.Selected = true;
                    dgvDispDetails.FirstDisplayedScrollingRowIndex = item.Index;
                    return false;
                }
            }
            return true;
        }
        private bool ValidateProduct(ProductMaster oProduct)
        {
            foreach (DataGridViewRow item in dgvDispDetails.Rows)
            {
                string SelectedText = Convert.ToString(item.Cells["DDProductNameColumn"].Value);
                if (SelectedText == oProduct.Name)
                {
                    item.Selected = true;
                    dgvDispDetails.FirstDisplayedScrollingRowIndex = item.Index;
                    return false;
                }
            }
            return true;
        }

        private bool DisplayReport(bool showUIDs)
        {
            WIMARTS.REPORTS.PrintReports.DispatchReport(m_dbBusObj.DispMasterID, showUIDs, this.MdiParent, curUserLogged);
            return true;
        }
        private bool ExportData()
        {
            bool retVal = false;

            string Data = string.Empty;
            CompanyMaster oCompanyMaster = bllMgr.CompanyMasterBLL.GetCompanyMasters().FirstOrDefault();
            if (oCompanyMaster != null)
            {
                Data = ",," + oCompanyMaster.CompanyName;
                Data += "\n" + ",," + oCompanyMaster.AddressLine + " " + oCompanyMaster.City + " " + oCompanyMaster.Pincode;
            }
            DispatchMaster oMaster = bllMgr.DispatchMasterBLL.GetDispatchMaster(m_dbBusObj.DispMasterID);
            Data += "\n\n" + ",,Detail Dispatch Report";
            Data += "\n\n" + "Job Name," + m_dbBusObj.GDN;
            if (oMaster != null)
            {
                if (oMaster.TransporterID.HasValue)
                {
                    TransporterDetails TransporterDetails = bllMgr.TransporterDetailsBLL.GetTransporterDetails(Convert.ToInt32(oMaster.TransporterID));
                    if (TransporterDetails != null)
                    {
                        Data += "\n" + "Transporter Name," + TransporterDetails.TransporterName;
                        Data += "\n" + "Transporter Address," + TransporterDetails.Address + " " + TransporterDetails.City + " " + TransporterDetails.Pincode;
                    }

                }

            }

            Data += "\n" + "Driver Name," + m_dbBusObj.DriverName;

            Data += "\n" + "Vehicle No," + m_dbBusObj.VehicleNo;
            Data += "\n" + "Line ID," + m_dbBusObj.LineID;
            List<DetailsDispatchDetails> lstDispatchDetails = bllMgr.DispatchDetailsBLL.GetDetailsDispatchDetailsByDispMaster(DispatchDetailsBLL.Flag.Master, m_dbBusObj.DispMasterID.ToString()).Distinct().ToList();

            List<CSVItemDetails> lstItems = bllMgr.ItemDetailsBLL.GetCSVItemDetailss(ItemDetailsBLL.Flag.DispID, BLLManager.DetailsStatus.All, m_dbBusObj.DispMasterID.ToString());

            Data += "\n";
            int SrNo = 1;
            foreach (DetailsDispatchDetails value in lstDispatchDetails)
            {
                SrNo = 1;
                List<CSVItemDetails> lstCSVItemDetails = lstItems.FindAll(it => it.ProdCode == value.ProdCode).ToList();
                if (lstCSVItemDetails != null)
                {
                    Data += "\n" + "Product Name:," + value.ProductName + ",Product Code:," + value.ProdCode + ",Pack size:," + value.Packsize + ",Target Qty:," + value.QtytoDispatch + ",Dispatched Quantity:," + value.DispatchedQty;
                    Data += "\n";
                    Data += "\n" + "SrNo,Batch Code,UID Code,Date";
                    Data += "\n";
                    foreach (CSVItemDetails item2 in lstCSVItemDetails)
                    {
                        Data += "\n" + SrNo + "," + item2.BatchCode + "," + item2.UIDCode + "," + item2.DispatchedDate;
                        SrNo++;
                    }
                    Data += "\n";
                }
            }
            Data += "\n";

            if (oMaster != null)
                Data += "\n" + ",,,,,,,Total:," + oMaster.GoodQty;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Application.StartupPath;
            sfd.FileName = m_dbBusObj.GDN;
            sfd.Filter = "CSV (*.csv)|.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string FileName = sfd.FileName;
                using (System.IO.StreamWriter sw = System.IO.File.CreateText(FileName))
                {
                    sw.WriteLine(Data);
                }
            }
            return retVal;
        }
        private bool ExportSummaryData()
        {
            bool retVal = false;
            CustomerMaster oCustomer = bllMgr.CustomerMasterBLL.GetCustomerMasterCSV(m_dbBusObj.DispMasterID);
            string Data = string.Empty;
            CompanyMaster oCompanyMaster = bllMgr.CompanyMasterBLL.GetCompanyMasters().FirstOrDefault();
            DispatchMaster oMaster = bllMgr.DispatchMasterBLL.GetDispatchMaster(m_dbBusObj.DispMasterID);
            if (oCompanyMaster != null)
            {
                Data = "," + oCompanyMaster.CompanyName;
                Data += "\n" + ",," + oCompanyMaster.AddressLine + " " + oCompanyMaster.City + " " + oCompanyMaster.Pincode;
            }
            Data += "\n\n" + ",,Dispatch Summary";
            Data += "\n\n" + "Dispatch No," + m_dbBusObj.GDN + " " + ",,Driver Name," + m_dbBusObj.DriverName;
            if (oMaster != null)
            {
                if (oMaster.TransporterID.HasValue)
                {
                    TransporterDetails TransporterDetails = bllMgr.TransporterDetailsBLL.GetTransporterDetails(Convert.ToInt32(oMaster.TransporterID));
                    if (TransporterDetails != null)
                    {
                        Data += "\n" + "Transporter Name," + TransporterDetails.TransporterName;
                        Data += "\n" + "Transporter Address," + TransporterDetails.Address + " " + TransporterDetails.City + " " + TransporterDetails.Pincode;
                    }
                }

            }
            Data += "\n" + "Dispatch Date," + m_dbBusObj.DispatchDate + ",," + "Vehicle No," + m_dbBusObj.VehicleNo;
            Data += "\n" + "Party Name," + oCustomer.CustName + ",," + "User Name," + curUserLogged.Name; ;
            Data += "\n" + "Destination," + oCustomer.AddrLine + " " + oCustomer.City + " " + oCustomer.Pincode;

            Data += "\n";
            List<CSVDispatchDetails> lstDispatchDetails = bllMgr.DispatchDetailsBLL.GetCSVDispatchDetailsByDispMaster(DispatchDetailsBLL.Flag.Master, m_dbBusObj.DispMasterID.ToString());
            int SrNo = 1;
            Data += "\n" + "SrNo,Product Code,Product Name,Pack Size,Plant Qty,Loading SlipQty,Scanned Qty,Difference,Remark";
            Data += "\n";
            foreach (CSVDispatchDetails item2 in lstDispatchDetails)
            {
                Data += "\n" + SrNo + "," + item2.ProdCode + "," + item2.ProductName + "," + item2.Packsize + ",,," + item2.ScanneddQty + ",";
                SrNo++;
            }
            Data += "\n";

            if (oMaster != null)
                Data += "\n" + ",,,,,Total:," + oMaster.GoodQty;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Application.StartupPath;
            sfd.FileName = m_dbBusObj.GDN;
            sfd.Filter = "CSV (*.csv)|.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string FileName = sfd.FileName;
                using (System.IO.StreamWriter sw = System.IO.File.CreateText(FileName))
                {
                    sw.WriteLine(Data);
                }
            }
            return retVal;
        }
        #endregion DB & CONTROL OPERATIONS

        private void btnLoadDL_Click(object sender, EventArgs e)
        {
            LoadExcelFile();
        }

        private void LoadExcelFile()
        {
            OleDbConnection cnn = new OleDbConnection();
            try
            {

                string strExcelPathName = null;

                OpenFileDialog openDialog = new OpenFileDialog();
                openDialog.Title = "Select file";
                //         openDialog.InitialDirectory = UTIL.SettingsPath.DataDir;
                openDialog.Filter = "Excel Sheet(*.xlsx)|*.xlsx|(*.xls)|*.xls";
                openDialog.FilterIndex = 1;
                openDialog.RestoreDirectory = true;
                if (openDialog.ShowDialog() == DialogResult.OK && string.IsNullOrEmpty(openDialog.FileName) == false)
                    strExcelPathName = openDialog.FileName;

                if (string.IsNullOrEmpty(strExcelPathName) == false)
                {
                    int worksheetNumber = 1;

                    FileInfo fl = new FileInfo(strExcelPathName);
                    if (fl.Extension.ToUpper() == ".XLSX")
                        cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + strExcelPathName + ";" + "Extended Properties='Excel 12.0 xml;HDR=No;IMEX=1';");
                    else if (fl.Extension.ToUpper() == ".XLS")
                        cnn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + strExcelPathName + ";" + "Extended Properties='Excel 8.0;HDR=NO;IMEX=1'");
                    //cnn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strExcelPathName + ";Extended Properties='Excel 8.0 xml;HDR=No;IMEX=1';");

                    cnn.Open();
                    var schemaTable = cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    if (schemaTable.Rows.Count < worksheetNumber) throw new ArgumentException("The worksheet number provided cannot be found in the spreadsheet");
                    string worksheet = schemaTable.Rows[worksheetNumber - 1]["table_name"].ToString().Replace("'", "");
                    string sql = String.Format("select * from [{0}]", worksheet);
                    var da = new OleDbDataAdapter(sql, cnn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    FetchDispatchList(dt);
                }
            }
            catch (Exception ex)
            {
                cnn.Close();
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void FetchDispatchList(DataTable dtList)
        {
            int rowID = 1;
            try
            {
                bool StartFetch = false;
                foreach (DataRow dataRow in dtList.Rows)
                {
                    string ProdCode = string.Empty;
                    decimal Qty = 0;
                    foreach (DataColumn dataCol in dtList.Columns)
                    {
                        //Add first row data
                        if (dataCol.ColumnName.Equals("F4") == true)
                        {
                            string Val = getStringValue(dataRow, dataCol);
                            if (Val.Contains("TOTAL") == true)
                            {
                                StartFetch = false;
                                break;
                            }
                        }
                        if (StartFetch == true)
                        {
                            if (dataCol.ColumnName.Equals("F3") == true)
                                ProdCode = getStringValue(dataRow, dataCol);
                            if (dataCol.ColumnName.Equals("F5") == true)
                                Qty = getDecimalValue(dataRow, dataCol);
                        }
                        if (dataCol.ColumnName.Equals("F3") == true)
                        {
                            string Val = getStringValue(dataRow, dataCol);
                            if (Val.Contains("ERP Code") == true)
                            {
                                StartFetch = true;
                            }
                        }
                        rowID++;
                    }
                    if (StartFetch == true)
                        AddProducts(ProdCode, Qty);
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}:{1},{2}", DateTime.Now, ex.Message, ex.StackTrace);
            }
        }

        private void AddProducts(string ProdCode, decimal Qty)
        {
            try
            {
                ProductMaster oProduct = bllMgr.ProductMasterBLL.GetProductMaster(ProductMasterBLL.Flag.Code, ProdCode);

                if (oProduct != null && oProduct.ProdID > 0 && ValidateProduct(oProduct) == true)
                {
                    int RowID = dgvDispDetails.Rows.Add();
                    dgvDispDetails.Rows[RowID].Cells["DDSrNoColumn"].Value = RowID + 1;
                    dgvDispDetails.Rows[RowID].Cells["DDProductCodeColumn"].Value = oProduct.Code;
                    dgvDispDetails.Rows[RowID].Cells["DDProductNameColumn"].Value = oProduct.Name;
                    dgvDispDetails.Rows[RowID].Cells["DDProductGivenQtyColumn"].Value = Qty;
                    dgvDispDetails.Rows[RowID].Cells["DDProductMinQtyColumn"].Value = Qty;
                    dgvDispDetails.Rows[RowID].Cells["DDProductMaxQtyColumn"].Value = Qty;
                    dgvDispDetails.FirstDisplayedScrollingRowIndex = RowID;
                    dgvDispDetails.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, Error:{1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
            }
        }

        private string getStringValue(DataRow dr, DataColumn dc)
        {
            try
            {
                string retVal = string.Empty;
                retVal = Convert.ToString(dr[dc]);
                return retVal;
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}:{1},{2}", DateTime.Now, ex.Message, ex.StackTrace);
                return " ";
            }
        }

        private decimal getDecimalValue(DataRow dr, DataColumn dc)
        {
            try
            {
                decimal retVal = 0;
                retVal = Convert.ToDecimal(dr[dc]);
                return retVal;
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}:{1},{2}", DateTime.Now, ex.Message, ex.StackTrace);
                return 0;
            }
        }
    }
}