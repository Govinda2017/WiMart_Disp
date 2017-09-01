using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIMARTS.DB.BusinessObjects;
using System.Threading;
using System.Windows.Forms;
using WIMARTS.INSPECTION;
using System.Drawing;
using WIMARTS.UTIL;
using WIMARTS.CODEMGR;
using WIMARTS.DB.BLL;
using System.Diagnostics;
using rcs.CONTROLS;

namespace WIMARTS.DISPATCH
{
    public partial class FrmMain
    {
        #region UI Functions

        private void StartApplication()
        {
            if (HasController == true)
            {
                //if (mHWControl != null && mHWControl.IsConnected())
                //{
                //    mHWControl.CURRENTMODEEXIT();
                //    Thread.Sleep(200);
                //    mHWControl.DRESET();
                //    RetryCounts++;
                //}
                ctrlPLCDeck1.PerformMachineOperation(PLCnRUN_if.RunAction.plc_ConveyorClear);
            }
            else
            {
                m_AppMode = AppMode.StandBy;
            }
        }

        private void StartClicked()
        {
            if (m_AppMode == AppMode.StandBy || m_AppMode == AppMode.ReadyMode || m_AppMode == AppMode.ExitJob)
            {
                if (ValidateJob() == true)
                {
                    string msg = "Kindly Check Dispatch details before Loading...." + Environment.NewLine
                        + "    Dispatch Number: " + mJobMaster.GDN + Environment.NewLine
                        + "    Customer Name: " + txtCustomer.Text + Environment.NewLine
                        + "    Vehicle Number: " + mJobMaster.VehicleNo + Environment.NewLine + Environment.NewLine
                        + "Press OK to Proceed.";

                    DialogResult dg = RedMessageBox.Show(msg, "WIMARTS", RedMessageBox.RedMessageBoxButtons.OKCancel, 0);
                    if (dg == DialogResult.OK)
                        m_AppMode = AppMode.LoadJob;
                }
                else
                {
                    UpdateText(lblScanStatus, "Select a Job to Proceed...");
                }
            }
            else if ((ManualMode == false) && (m_AppMode == AppMode.LoadJob || m_AppMode == AppMode.Offline || m_AppMode == AppMode.ConveyorStop || m_AppMode == AppMode.Error))
            {
                if (HasController == true)
                {
                    //mHWControl.ASTARTINSP();
                    //RetryCounts++;
                    ctrlPLCDeck1.PerformMachineOperation(PLCnRUN_if.RunAction.plc_ConveyorStart);
                }
                else
                    m_AppMode = AppMode.Online;
            }
            else if ((ManualMode == true) && (m_AppMode == AppMode.LoadJob || m_AppMode == AppMode.Offline || m_AppMode == AppMode.ConveyorStop))
            {
                if (HasController == true)
                {
                    //mHWControl.TSTARTCONV(1);
                    //RetryCounts++;
                    ctrlPLCDeck1.PerformMachineOperation(PLCnRUN_if.RunAction.plc_ConveyorFreeMove);
                }
                else
                    m_AppMode = AppMode.ConveyorStart;
            }
        }

        private void ExitClicked()
        {
            if (m_AppMode == AppMode.ReadyMode || m_AppMode == AppMode.LoadJob || m_AppMode == AppMode.Offline || m_AppMode == AppMode.ConveyorStop)
            {
                m_AppMode = AppMode.ExitJob;
            }
            else if (ManualMode == false && m_AppMode == AppMode.Online)
            {
                if (HasController == true)
                {
                    //mHWControl.ASTOPINSP();
                    //RetryCounts++;
                    ctrlPLCDeck1.PerformMachineOperation(PLCnRUN_if.RunAction.plc_ConveyorStop);
                }
                else
                    m_AppMode = AppMode.Offline;
            }
            else if (ManualMode == true && m_AppMode == AppMode.ConveyorStart)
            {
                if (HasController == true)
                {
                    //mHWControl.TSTOPCONV();
                    //RetryCounts++;
                    ctrlPLCDeck1.PerformMachineOperation(PLCnRUN_if.RunAction.plc_ConveyorStop);
                }
                else
                    m_AppMode = AppMode.ConveyorStop;
            }
            else if (m_AppMode == AppMode.StandBy || m_AppMode == AppMode.ExitJob || m_AppMode == AppMode.Start)
            {
                m_AppMode = AppMode.ExitApp;
            }
            else
            {
                m_AppMode = AppMode.ExitApp;
            }
        }

        private void ExitJob()
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new MethodInvoker(delegate { ExitJob(); }));
            }
            else
            {
                dgvDispDetails.Rows.Clear();
                dgvScannedData.Rows.Clear();
                dataGridView1.Rows.Clear();

                if (mJobMaster.Status != Convert.ToInt32(DB.BLL.BLLManager.MasterStatus.Completed))
                    UpdateJobMasterStatus(Convert.ToInt32(DB.BLL.BLLManager.MasterStatus.Abonden), null, null);
            }
        }

        private void ExitApplication()
        {
            //if (mHWControl != null)
            //{
            //    mHWControl.Disconnect();
            //    mHWControl = null;
            //}
            ctrlPLCDeck1.PerformDisconnect();

            if (mInspectDev1 != null)
            {
                mInspectDev1.Disconnect();
                mInspectDev1 = null;
            }
            if (mInspectDev2 != null)
            {
                mInspectDev2.Disconnect();
                mInspectDev2 = null;
            }
            if (mJobMaster != null && mJobMaster.DispMasterID > 0)
            {
                if (mJobMaster.Status != Convert.ToInt32(DB.BLL.BLLManager.MasterStatus.Completed))
                    UpdateJobMasterStatus(Convert.ToInt32(DB.BLL.BLLManager.MasterStatus.Abonden), null, null);
            }
            bllMgr.CloseDB();
            Application.Exit();
        }

        private void LoadDispatchMaster()
        {
            lstDispatchMasters = bllMgr.DispatchMasterBLL.GetDispatchListByValue(DispatchMasterBLL.Flag.DispatchDate, DateTime.Now.ToString("s"));
            cmbDispMaster.DataSource = lstDispatchMasters;
            cmbDispMaster.DisplayMember = "GDN";
            cmbDispMaster.ValueMember = "DispMasterID";

            cmbDispMaster.SelectedIndex = -1;
        }

        private void BindDetails()
        {
            List<ProductMaster> lstProducts = bllMgr.ProductMasterBLL.GetProductMasters();

            DDProductCodeColumn.DataSource = lstProducts;
            DDProductCodeColumn.DisplayMember = "Code";
            DDProductCodeColumn.ValueMember = "Code";

            DDProductNameColumn.DataSource = lstProducts;
            DDProductNameColumn.DisplayMember = "Name";
            DDProductNameColumn.ValueMember = "Code";

        }

        private void LoadDispatchData()
        {
            try
            {
                txtVehicleNo.Clear();
                txtDriverName.Clear();
                cmbStatus.SelectedIndex = -1;
                txtCustomer.Text = "";

                dgvDispDetails.Rows.Clear();
                dgvScannedData.Rows.Clear();
                dataGridView1.Rows.Clear();

                if (cmbDispMaster.SelectedIndex < 0 || cmbDispMaster.SelectedItem == null || string.IsNullOrEmpty(cmbDispMaster.ValueMember) == true)
                    return;

                DispatchMaster oDisp = (DispatchMaster)cmbDispMaster.SelectedItem;
                if (oDisp != null)
                {
                    mJobMaster = oDisp;

                    txtVehicleNo.Text = oDisp.VehicleNo;
                    txtDriverName.Text = oDisp.DriverName;
                    cmbStatus.SelectedIndex = oDisp.Status;
                    CustomerMaster oCustomerMaster = bllMgr.CustomerMasterBLL.GetCustomerMaster(oDisp.CustID);
                    if (oCustomerMaster != null)
                        txtCustomer.Text = oCustomerMaster.CustName;
                    if (oDisp.TransporterID != null)
                    {
                        TransporterDetails oTransporterDetails = bllMgr.TransporterDetailsBLL.GetTransporterDetails(Convert.ToInt32(oDisp.TransporterID));
                        if (oTransporterDetails != null)
                            txtTransporter.Text = oTransporterDetails.TransporterName;
                    }

                    TotalQuantity = 0;
                    lstDispDetails = bllMgr.DispatchDetailsBLL.GetDispatchDetailsByDispMaster(DispatchDetailsBLL.Flag.Master, Convert.ToString(oDisp.DispMasterID));
                    foreach (DispatchDetails item in lstDispDetails)
                    {
                        TotalQuantity += item.QtytoDispatch;
                        AddDispatchDetails2Grid(item);
                    }

                    ///Load Previously Dispatched UIDs under the selected Job/GDN.
                    mLstUIDsInJob.Clear();
                    mLstUIDsInJob = bllMgr.ItemDetailsBLL.GetItemDetailsUIDs(ItemDetailsBLL.Flag.DispID, BLLManager.DetailsStatus.All, oDisp.DispMasterID.ToString());
                    GoodCount = mLstUIDsInJob.Count;
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, {1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
            }
        }

        private bool ValidateJob()
        {
            bool RetVal = false;
            if (cmbDispMaster.SelectedIndex >= 0)
                RetVal = true;
            return RetVal;
        }

        #endregion UI Functions

        #region Data Handlers

        private void ProcessInspectedData(string dataCode)
        {
            bool resSend2HWC = false;
            try
            {
                bool dataResult = false;
                string scanStatus = string.Empty;

                GS1Mgr.GS1Values lstTags = DecodeData(dataCode);
                if (string.IsNullOrEmpty(lstTags.PARTNO) == false && string.IsNullOrEmpty(lstTags.LOT) == false && string.IsNullOrEmpty(lstTags.UID) == false)
                {
                    dataResult = ValidateData(lstTags, out scanStatus);
                    if (dataResult == true)
                        mLstUIDsInJob.Add(lstTags.UID);
                    scanStatus += lstTags.UID;
                }
                else
                {
                    scanStatus = "Wrong Data received, Rescan/Check the data";
                    txtScannedData.Clear();
                }

                resSend2HWC = SendResult2HWC(dataResult);

                SetCounts(dataResult);

                if (dataResult == true)
                {
                    Thread th1 = new Thread(() => InsertDispatchDetails(lstTags));
                    th1.Start();
                    Thread th2 = new Thread(() => UpdateDispatchedQty(lstTags));
                    th2.Start();
                    Thread th3 = new Thread(() => UpdateUIDDetails(lstTags));
                    th3.Start();
                    Thread th4 = new Thread(() => AddData2Grid(lstTags));
                    th4.Start();
                }

                UpdateText(lblScanStatus, scanStatus);
                UpdateStatusColor(lblScanStatus, dataResult);
                UpdateStatusColor(btnIndicator, dataResult);
                UpdateData2ResultGrid(scanStatus, dataResult);
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, Error:{1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
                if (resSend2HWC == false)
                    resSend2HWC = SendResult2HWC(false);
                SetCounts(false);

                UpdateStatusColor(btnIndicator, false);
                UpdateText(lblScanStatus, "SYSTEM DATA ERRROR received, Rescan/Check the data");
                UpdateStatusColor(lblScanStatus, false);
                UpdateData2ResultGrid("SYSTEM DATA ERRROR received, Rescan/Check the data", false);
            }
        }

        private bool ValidateData_OLD(GS1Mgr.GS1Values CodeData)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new MethodInvoker(delegate { ValidateData_OLD(CodeData); }));
            }
            else
            {
                foreach (DataGridViewRow row in dgvScannedData.Rows)
                {
                    if (row.Cells["UIDColumn"].Value.ToString().Equals(CodeData.UID))
                    {
                        row.Selected = true;
                        dgvScannedData.FirstDisplayedScrollingRowIndex = row.Index;
                        //Repeated UID
                        UpdateText(lblScanStatus, "Box is already scanned: " + CodeData.PARTNO);
                        Trace.TraceInformation("{0}, Box is already scanned: {1}", DateTime.Now, CodeData.UID);
                        return false;
                    }
                }
                if (AllowFreeFlowDispatch == false)
                {
                    //Strict Dispatch
                    if (AllowOnlyScheduleDispatch == true)
                    {
                        if (lstDispDetails.Count > 0)
                        {
                            DispatchDetails oDispDtls = lstDispDetails.Find(x => x.ProdCode == CodeData.PARTNO);
                            if (oDispDtls == null || oDispDtls.DispDetailsID == 0)
                            {
                                UpdateText(lblScanStatus, "Wrong Product: " + CodeData.PARTNO);
                                Trace.TraceInformation("{0}, Wrong Product: {1}, BoxID: {2}", DateTime.Now, CodeData.PARTNO, CodeData.UID);
                                return false;
                            }
                        }
                        else
                        {
                            UpdateText(lblScanStatus, "Product is not in Dispatch List, check Dispatch List: " + CodeData.PARTNO);
                            Trace.TraceInformation("{0}, Product is not in Dispatch List, check Dispatch List: {1}, BoxID: {2}", DateTime.Now, CodeData.PARTNO, CodeData.UID);
                            return false;
                        }

                        foreach (DataGridViewRow item in dgvDispDetails.Rows)
                        {
                            string SelectedText = Convert.ToString((item.Cells["DDProductCodeColumn"] as DataGridViewComboBoxCell).FormattedValue.ToString());
                            if (SelectedText == CodeData.PARTNO)
                            {
                                int QtytoDispatch = Convert.ToInt32(item.Cells["DDProductGivenQtyColumn"].Value);
                                int DispatchedQty = Convert.ToInt32(item.Cells["DDProductDispatchedQtyColumn"].Value);
                                DispatchDetails oDispDtls = lstDispDetails.Find(x => x.ProdCode == CodeData.PARTNO);
                                // if (DispatchedQty >= oDispDtls.MinQty && DispatchedQty <= oDispDtls.MaxQty)
                                if (DispatchedQty >= QtytoDispatch)
                                {
                                    item.Selected = true;
                                    dgvDispDetails.FirstDisplayedScrollingRowIndex = item.Index;
                                    //Qty greater than given qty
                                    UpdateText(lblScanStatus, "Reached Total Product Quantity: " + CodeData.PARTNO);
                                    Trace.TraceInformation("{0}, Reached Total Product Quantity: {1}", DateTime.Now, CodeData.PARTNO);
                                    return false;
                                }
                            }
                        }
                    }

                    ItemDetails oItem = new ItemDetails();
                    if (AllowOnlyProductionVerified == true)
                    {
                        oItem = bllMgr.ItemDetailsBLL.GetItemDetailsBtnDays(BLLManager.DetailsStatus.Scanned, DispatchDaysLimit, CodeData.UID);
                    }
                    else
                    {
                        oItem = bllMgr.ItemDetailsBLL.GetItemDetailsBtnDays(BLLManager.DetailsStatus.NotDispatched, DispatchDaysLimit, CodeData.UID);
                    }

                    if (oItem == null || oItem.DetailsID == 0)
                    {
                        UpdateText(lblScanStatus, "This box is not available in store or it is expired: " + CodeData.UID);
                        Trace.TraceInformation("{0}, This box is not available in store or it is expired: {1}", DateTime.Now, CodeData.UID);
                        return false;
                    }
                }
                else
                {
                    /// Check Product FG Code, if exist, than process the Box, else raise error...
                    bool isValidFGCode = false;

                    if (isValidFGCode == false)
                    {
                        UpdateText(lblScanStatus, "Invalid FG Code received: " + CodeData.PARTNO);
                        Trace.TraceInformation("{0}, Invalid FG Code received: {1}", DateTime.Now, CodeData.PARTNO);
                        return false;
                    }
                }
                UpdateText(lblScanStatus, "Box Inspected Successfully: " + CodeData.UID);
                Trace.TraceInformation("{0}, Box Inspected Successfully: {1}", DateTime.Now, CodeData.UID);
            }
            return true;
        }

        private bool SendResult2HWC(bool IsGood)
        {
            int TriggerNo = DequeTrigger();
            if (IsGood == true)
            {
                if (HasController == true && ManualMode == false)
                {
                    //mHWControl.ACAMRESPONSE(TriggerNo, true);
                    //RetryCounts++;
                    ctrlPLCDeck1.PerformRejectionOperation(true);
                }
            }
            else
            {
                if (HasController == true)
                {
                    if (ManualMode == true)
                    {
                        //mHWControl.TSTOPCONV();//TBV
                        //RetryCounts++;
                        ctrlPLCDeck1.PerformMachineOperation(PLCnRUN_if.RunAction.plc_ConveyorStop);
                    }
                    else
                    {
                        //mHWControl.ACAMRESPONSE(TriggerNo, false);
                        //RetryCounts++;
                        ctrlPLCDeck1.PerformRejectionOperation(false);
                    }
                }
            }
            return true;
        }

        const string ScanStatus_EIV = "ERROR IN VALIDATION";
        const string ScanStatus_RBF = "Repeated Box Found: ";
        const string ScanStatus_WPF = "Wrong Product Found: ";
        const string ScanStatus_PNIL = "Product is not in Dispatch List, check Dispatch List: ";
        const string ScanStatus_RPQ = "Reached Total Product Quantity: ";
        const string ScanStatus_IFG = "Invalid FG Code received: ";

        const string ScanStatus_BIS = "Box Inspected Successfully: ";
        const string ScanStatus_NPL = "UnIdentified/Non Printed Label: ";
        const string ScanStatus_ADB = "Already Dispathed Box: ";
        const string ScanStatus_NASEx = "This box is not available in store or it is expired: ";

        private bool ValidateData(GS1Mgr.GS1Values CodeData, out string scanStatus)
        {
            scanStatus = ScanStatus_EIV;

            bool hasUIDInCurScanJob = mLstUIDsInJob.Exists(item => item == CodeData.UID);
            if (hasUIDInCurScanJob == true)
            {
                scanStatus = ScanStatus_RBF;
                //HighlightBox();
                return false;
            }

            if (AllowFreeFlowDispatch == false)
            {
                //Strict Dispatch
                if (AllowOnlyScheduleDispatch == true)
                {
                    if (lstDispDetails.Count > 0)
                    {
                        DispatchDetails oDispDtls = lstDispDetails.Find(x => x.ProdCode == CodeData.PARTNO);
                        if (oDispDtls == null || oDispDtls.DispDetailsID == 0)
                        {
                            scanStatus = ScanStatus_WPF;
                            //Trace.TraceInformation("{0}, Wrong Product: {1}, BoxID: {2}", DateTime.Now, CodeData.PARTNO, CodeData.UID);
                            return false;
                        }
                    }
                    else
                    {
                        scanStatus = ScanStatus_PNIL;
                        //Trace.TraceInformation("{0}, Product is not in Dispatch List, check Dispatch List: {1}, BoxID: {2}", DateTime.Now, CodeData.PARTNO, CodeData.UID);
                        return false;
                    }

                    foreach (DataGridViewRow item in dgvDispDetails.Rows)
                    {
                        string SelectedText = Convert.ToString((item.Cells["DDProductCodeColumn"] as DataGridViewComboBoxCell).FormattedValue.ToString());
                        if (SelectedText == CodeData.PARTNO)
                        {
                            int QtytoDispatch = Convert.ToInt32(item.Cells["DDProductGivenQtyColumn"].Value);
                            int DispatchedQty = Convert.ToInt32(item.Cells["DDProductDispatchedQtyColumn"].Value);
                            DispatchDetails oDispDtls = lstDispDetails.Find(x => x.ProdCode == CodeData.PARTNO);
                            // if (DispatchedQty >= oDispDtls.MinQty && DispatchedQty <= oDispDtls.MaxQty)
                            if (DispatchedQty >= QtytoDispatch)
                            {
                                item.Selected = true;
                                dgvDispDetails.FirstDisplayedScrollingRowIndex = item.Index;
                                //Qty greater than given qty

                                scanStatus = ScanStatus_RPQ;
                                //Trace.TraceInformation("{0}, Reached Total Product Quantity: {1}", DateTime.Now, CodeData.PARTNO);
                                return false;
                            }
                        }
                    }
                }

                ItemDetails oItem = new ItemDetails();
                if (AllowOnlyProductionVerified == true)
                {
                    oItem = bllMgr.ItemDetailsBLL.GetItemDetailsBtnDays(BLLManager.DetailsStatus.Scanned, DispatchDaysLimit, CodeData.UID);
                }
                else
                {
                    oItem = bllMgr.ItemDetailsBLL.GetItemDetailsBtnDays(BLLManager.DetailsStatus.NotDispatched, DispatchDaysLimit, CodeData.UID);
                }

                if (oItem == null || oItem.DetailsID == 0)
                {
                    scanStatus = ScanStatus_NASEx;
                    //Trace.TraceInformation("{0}, This box is not available in store or it is expired: {1}", DateTime.Now, CodeData.UID);
                    return false;
                }
            }
            else
            {
                ItemDetails oItemDetails = bllMgr.ItemDetailsBLL.GetItemDetails(BLLManager.DetailsStatus.All, CodeData.UID);
                if (oItemDetails == null || oItemDetails.DetailsID == 0)
                {
                    /// Check Product FG Code, if exist, than process the Box, else raise error...
                    //bool isValidFGCode = bllMgr.ProductMasterBLL.IsValidFGCode(CodeData.PARTNO);
                    ProductMaster oProductMaster = bllMgr.ProductMasterBLL.GetProductMaster(ProductMasterBLL.Flag.Code, CodeData.PARTNO);
                    if (oProductMaster == null || string.IsNullOrEmpty(oProductMaster.Code) == true)
                    {
                        scanStatus = ScanStatus_IFG + ": " + CodeData.PARTNO;
                        //Trace.TraceInformation("{0}, Invalid FG Code received: {1}", DateTime.Now, CodeData.PARTNO);
                        return false;
                    }

                    // As item details does not exist... Insert it
                    oItemDetails = new ItemDetails();
                    //oItemDetails.DetailsID = DetailsID;
                    oItemDetails.PrintID = null;
                    oItemDetails.InspID = null;
                    oItemDetails.DispID = null;
                    oItemDetails.DispLineID = null;
                    oItemDetails.ProdCode = CodeData.PARTNO;
                    oItemDetails.BatchCode = CodeData.LOT;
                    oItemDetails.UIDCode = CodeData.UID;
                    oItemDetails.Status = (int)DB.BLL.BLLManager.DetailsStatus.Created;
                    oItemDetails.CreatedDate = DateTime.Now;
                    oItemDetails.InspectedDate = null;
                    oItemDetails.DispatchedDate = null;
                    oItemDetails.LUDate = DateTime.Now;

                    bllMgr.ItemDetailsBLL.AddItemDetails(oItemDetails);
                }
                else
                {
                    if (oItemDetails.Status == (int)BLLManager.DetailsStatus.Dispatched)
                    {
                        scanStatus = ScanStatus_ADB;
                        //Trace.TraceInformation("{0}, This box is not available in store or it is expired: {1}", DateTime.Now, CodeData.UID);
                        return false;
                    }
                    else if (oItemDetails.Status == (int)BLLManager.DetailsStatus.Scrapped || oItemDetails.Status == (int)BLLManager.DetailsStatus.Wasted || oItemDetails.Status == (int)BLLManager.DetailsStatus.Archived)
                    {
                        scanStatus = ScanStatus_NASEx;
                        //Trace.TraceInformation("{0}, This box is not available in store or it is expired: {1}", DateTime.Now, CodeData.UID);
                        return false;
                    }
                }
            }
            scanStatus = ScanStatus_BIS;
            //Trace.TraceInformation("{0}, Box Inspected Successfully: {1}", DateTime.Now, CodeData.UID);

            return true;
        }

        private GS1Mgr.GS1Values DecodeData(string readCode)
        {
            try
            {
                GS1Mgr.GS1Values decodedValues = GS1Mgr.DecodeData(readCode);
                return decodedValues;
            }
            catch (Exception ex)
            {
                //Error while decoding data
                Trace.TraceError("{0}, Error:{1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
                return null;
            }
        }

        private void AddDispatchDetails2Grid(DispatchDetails item)
        {
            decimal TargetQty = 0, DispatchedQty = 0;

            if (dgvDispDetails.InvokeRequired == true)
            {
                dgvDispDetails.Invoke(new MethodInvoker(delegate { AddDispatchDetails2Grid(item); }));
            }
            else
            {
                int RowID = dgvDispDetails.Rows.Add();
                dgvDispDetails.Rows[RowID].Cells["DDDispDetailsIDColumn"].Value = item.DispDetailsID;
                dgvDispDetails.Rows[RowID].Cells["DDSrNoColumn"].Value = RowID + 1;
                dgvDispDetails.Rows[RowID].Cells["DDProductCodeColumn"].Value = item.ProdCode;
                dgvDispDetails.Rows[RowID].Cells["DDProductNameColumn"].Value = item.ProdCode;
                dgvDispDetails.Rows[RowID].Cells["DDProductGivenQtyColumn"].Value = item.QtytoDispatch;
                dgvDispDetails.Rows[RowID].Cells["DDProductDispatchedQtyColumn"].Value = item.DispatchedQty;
                dgvDispDetails.Rows[RowID].Selected = true;
                dgvDispDetails.FirstDisplayedScrollingRowIndex = RowID;
                TargetQty += item.QtytoDispatch;
                DispatchedQty += item.DispatchedQty;
            }
            UpdateText(txtTargetQty, "Total Quantity= " + Convert.ToString(TotalQuantity));
            UpdateText(txtDispatchedQty, Convert.ToString(DispatchedQty));
        }

        private void AddData2Grid(GS1Mgr.GS1Values CodeData)
        {
            if (dgvScannedData.InvokeRequired == true)
            {
                dgvScannedData.Invoke(new MethodInvoker(delegate { AddData2Grid(CodeData); }));
            }
            else
            {
                if (dgvScannedData.Rows.Count >= 100)
                {
                    //dgvScannedData.Rows.Clear();
                    dgvScannedData.Rows.RemoveAt(0);
                    dgvScannedData.Rows.RemoveAt(0);
                    dgvScannedData.Rows.RemoveAt(0);
                    dgvScannedData.Rows.RemoveAt(0);
                    dgvScannedData.Rows.RemoveAt(0);
                    dgvScannedData.Rows.RemoveAt(0);
                    dgvScannedData.Rows.RemoveAt(0);
                    dgvScannedData.Rows.RemoveAt(0);
                    dgvScannedData.Rows.RemoveAt(0);
                    dgvScannedData.Rows.RemoveAt(0);
                }
                int i = dgvScannedData.Rows.Add();
                dgvScannedData.Rows[i].Cells["SrNoColumn"].Value = GoodCount;
                dgvScannedData.Rows[i].Cells["ProductCodeColumn"].Value = CodeData.PARTNO;
                dgvScannedData.Rows[i].Cells["BatchNameColumn"].Value = CodeData.LOT;
                dgvScannedData.Rows[i].Cells["UIDColumn"].Value = CodeData.UID;
                dgvScannedData.Rows[i].Cells["DateColumn"].Value = DateTime.Now;
                dgvScannedData.FirstDisplayedScrollingRowIndex = i;
                dgvScannedData.Rows[i].Selected = true;
            }
        }

        private bool ValidateHwValues(string Value1, int Value2)
        {
            try
            {
                bool retVal = false;
                int no = 0;
                Int32.TryParse(Value1, out no);
                retVal = no.Equals(Value2);
                return retVal;
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, Error:{1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
                return false;
            }
        }

        #endregion Data Handlers

        #region DB Handlers

        private void InsertDispatchDetails(GS1Mgr.GS1Values CodeData)
        {
            if (dgvDispDetails.InvokeRequired == true)
            {
                dgvDispDetails.Invoke(new MethodInvoker(delegate { InsertDispatchDetails(CodeData); }));
            }
            else
            {
                try
                {
                    //if Free mode then insert else ignore
                    if (AllowOnlyScheduleDispatch == true)
                        return;

                    foreach (DataGridViewRow item in dgvDispDetails.Rows)
                    {
                        string SelectedText = Convert.ToString((item.Cells["DDProductCodeColumn"] as DataGridViewComboBoxCell).FormattedValue.ToString());
                        if (SelectedText == CodeData.PARTNO)
                        {
                            return;
                        }
                    }
                    List<ProductMaster> lstProducts = (List<ProductMaster>)DDProductCodeColumn.DataSource;
                    ProductMaster oProduct = lstProducts.Find(x => x.Code == CodeData.PARTNO);
                    if (oProduct == null)
                        return;
                    DispatchDetails oDispDetls = new DispatchDetails();
                    oDispDetls.DispMasterID = mJobMaster.DispMasterID;
                    oDispDetls.ProdCode = oProduct.Code;
                    oDispDetls.QtytoDispatch = 0;
                    oDispDetls.DispatchedQty = 0;
                    oDispDetls.Remark = "Free mode Dispatch";
                    oDispDetls.CreatedDate = DateTime.Now;
                    oDispDetls.LUDate = DateTime.Now;
                    oDispDetls.DispDetailsID = bllMgr.DispatchDetailsBLL.AddDispatchDetails(oDispDetls);

                    //Insert row to grid
                    AddDispatchDetails2Grid(oDispDetls);
                }
                catch (Exception ex)
                {
                    Trace.TraceError("{0}, {1}", DateTime.Now, ex.Message);
                    //Error While Updating
                }
            }
        }

        private void UpdateDispatchedQty(GS1Mgr.GS1Values CodeData)
        {
            if (dgvDispDetails.InvokeRequired == true)
            {
                dgvDispDetails.Invoke(new MethodInvoker(delegate { UpdateDispatchedQty(CodeData); }));
            }
            else
            {
                try
                {
                    decimal DispatchedQty = 0;
                    foreach (DataGridViewRow item in dgvDispDetails.Rows)
                    {
                        string SelectedText = Convert.ToString((item.Cells["DDProductCodeColumn"] as DataGridViewComboBoxCell).FormattedValue.ToString());
                        if (SelectedText == CodeData.PARTNO)
                        {
                            DispatchDetails oDipsDetails = new DispatchDetails();
                            oDipsDetails.DispDetailsID = Convert.ToInt32(item.Cells["DDDispDetailsIDColumn"].Value);
                            // oDipsDetails.DispatchedQty = Convert.ToInt32(item.Cells["DDProductDispatchedQtyColumn"].Value);
                            oDipsDetails.LUDate = DateTime.Now;
                            bllMgr.DispatchDetailsBLL.UpdateDispatchedQty(oDipsDetails);
                            oDipsDetails = bllMgr.DispatchDetailsBLL.GetDispatchDetails(oDipsDetails.DispDetailsID);
                            item.Cells["DDProductDispatchedQtyColumn"].Value = oDipsDetails.DispatchedQty;
                            //
                            item.Selected = true;
                            dgvDispDetails.FirstDisplayedScrollingRowIndex = item.Index;
                        }
                        DispatchedQty += Convert.ToDecimal(item.Cells["DDProductDispatchedQtyColumn"].Value);
                    }
                    UpdateText(txtDispatchedQty, Convert.ToString(DispatchedQty));
                }
                catch (Exception ex)
                {
                    Trace.TraceError("{0}, {1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
                    //Error while updating data
                }
            }
        }



        private void UpdateJobQty()
        {
            try
            {
                mJobMaster.GoodQty = GoodCount;
                mJobMaster.BadQty = TotalBadCount;
                mJobMaster.LUDate = DateTime.Now;
                bllMgr.DispatchMasterBLL.UpdateQuantity(mJobMaster);
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, {1}", DateTime.Now, ex.Message);
            }
        }

        private void UpdateJobMasterStatus(int Status, Nullable<DateTime> startDate, Nullable<DateTime> EndDate)
        {
            try
            {
                mJobMaster.Status = Status;
                if (startDate.HasValue == true)
                {
                    mJobMaster.StartedAt = startDate;
                    mJobMaster.LineID = UTIL.SystemIntegrity.Globals.AppSettings.LineID;
                }
                if (EndDate.HasValue == true)
                    mJobMaster.CompletedAt = EndDate;
                mJobMaster.LUDate = DateTime.Now;
                bllMgr.DispatchMasterBLL.UpdateStatus(mJobMaster);
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, {1}", DateTime.Now, ex.Message);
            }
        }

        private void UpdateUIDDetails(GS1Mgr.GS1Values CodeData)
        {
            ItemDetails oDetails = new ItemDetails();
            try
            {
                oDetails.UIDCode = CodeData.UID;
                oDetails.DispID = mJobMaster.DispMasterID;
                oDetails.DispLineID = UTIL.SystemIntegrity.Globals.AppSettings.LineID;
                oDetails.Status = Convert.ToInt32(DB.BLL.BLLManager.DetailsStatus.Dispatched);
                oDetails.DispatchedDate = DateTime.Now;
                oDetails.LUDate = DateTime.Now;
                bllMgr.ItemDetailsBLL.UpdateDispatchStatus(oDetails);
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, {1}", DateTime.Now, ex.Message);
                WriteDetailsToFile(oDetails);
            }
        }

        //TBD
        private void CheckforQuantity(int Qty)
        {
            if (Qty >= TotalQuantity)
            {
                UpdateJobMasterStatus(Convert.ToInt32(BLLManager.MasterStatus.Completed), null, DateTime.Now);
                if (HasController == true)
                    //mHWControl.ASTARTINSP();
                    ctrlPLCDeck1.PerformMachineOperation(PLCnRUN_if.RunAction.plc_ConveyorStart);
                else
                    m_AppMode = AppMode.Offline;
                UpdateText(lblScanStatus, "Dispatch Quantity completed, Load New Dispatch...");
            }
        }

        #endregion DB Handlers

        #region Status Updates

        private void CheckSensor2Trigger(string strTriggerNumber)
        {
            try
            {
                int TriggerNumber = 0;
                Int32.TryParse(strTriggerNumber, out TriggerNumber);
                CheckSensor2Trigger(TriggerNumber);
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, Error:{1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
            }
        }
        private void CheckSensor2Trigger(int TriggerNumber)
        {
            Sensor2Count = TriggerNumber;
            //if (Sensor2Count > Sensor1Count && (Sensor1Count != 1 || Sensor2Count != 10))
            if (Sens2TotalCount > Sens1TotalCount)
            {
                string Msg = "Major Blunder with Hardware.\nSecond Sensor count Exceeded than first\nClick OK to Reset OR \nClick Cancel and adjust sensor count.";
                DialogResult dr = RedMessageBox.Show(Msg, "WIMARTS", RedMessageBox.RedMessageBoxButtons.OKCancel, 0);
                if (dr == DialogResult.OK)
                {
                    _RetryCounts = 1;
                    StartApplication();
                }
            }
        }
        private void UpdateStatusColor(Control ctrl, bool isValid)
        {
            if (ctrl.InvokeRequired == true)
            {
                ctrl.Invoke(new MethodInvoker(delegate { UpdateStatusColor(ctrl, isValid); }));
            }
            else
            {
                if (isValid == true)
                    ctrl.BackColor = Color.Green;
                else
                    ctrl.BackColor = Color.Red;
            }
        }

        private void UpdateText(Control ctrl, string data)
        {
            if (ctrl.InvokeRequired == true)
            {
                ctrl.Invoke(new MethodInvoker(delegate { UpdateText(ctrl, data); }));
            }
            else
            {
                ctrl.Text = data;
            }
        }

        private void UpdateImageResult(Bitmap oImage)
        {
            if (picImage.InvokeRequired == true)
            {
                picImage.Invoke(new MethodInvoker(delegate { UpdateImageResult(oImage); }));
            }
            else
            {
                picImage.Image = oImage;
            }
        }

        //private void UpdateSplashMessage(COMMON.CtrlSplashBox ctrl, string data)
        //{
        //    if (ctrl.InvokeRequired == true)
        //    {
        //        ctrl.Invoke(new MethodInvoker(delegate { UpdateSplashMessage(ctrl, data); }));
        //    }
        //    else
        //    {
        //        ctrl.SplashMessage = data;
        //    }
        //}
        //private void UpdateSplashMessageColor(COMMON.CtrlSplashBox ctrl, bool isValid)
        //{
        //    if (ctrl.InvokeRequired == true)
        //    {
        //        ctrl.Invoke(new MethodInvoker(delegate { UpdateSplashMessageColor(ctrl, isValid); }));
        //    }
        //    else
        //    {
        //        if (isValid == true)
        //            ctrl.BackColor = Color.Green;
        //        else
        //            ctrl.BackColor = Color.Red;
        //    }
        //}
        //private void UpdateSplashMessageStart(COMMON.CtrlSplashBox ctrl, bool SplashStart, int splashCount)
        //{
        //    if (ctrl.InvokeRequired == true)
        //    {
        //        ctrl.Invoke(new MethodInvoker(delegate { UpdateSplashMessageStart(ctrl, SplashStart, splashCount); }));
        //    }
        //    else
        //    {
        //        if (splashCount >= 0)
        //            ctrl.SplashCount = splashCount;

        //        ctrl.SplashStart = SplashStart;
        //    }
        //}

        const string strGOOD = "GOOD";
        const string strERROR = "ERROR";
        const string strEJECTED = "EJECTED";

        private void UpdateData2ResultGrid(string scanStatus, bool dataResult)
        {
            if (dataGridView1.InvokeRequired == true)
            {
                dataGridView1.Invoke(new MethodInvoker(delegate { UpdateData2ResultGrid(scanStatus, dataResult); }));
            }
            else
            {
                try
                {
                    if (dataGridView1.Rows.Count > 0 && dataGridView1.Rows.Count >= 5)
                        dataGridView1.Rows.RemoveAt(0);

                    int i = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = GoodCount + TotalBadCount;
                    dataGridView1.Rows[i].Cells[1].Value = (dataResult == true ? strGOOD : strERROR);
                    dataGridView1.Rows[i].Cells[2].Value = scanStatus;

                    Color color2Set = Color.Green;
                    if (dataResult == true)
                    {
                        color2Set = Color.Green;
                    }
                    else
                    {
                        color2Set = Color.Red;
                    }
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor =
                        dataGridView1.Rows[i].DefaultCellStyle.SelectionBackColor = color2Set;
                }
                catch (Exception ex)
                {
                    Trace.TraceError("{0}, UpdateData2ResultGrid Error:{1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
                }
            }
        }
        private void HighlightResultGrid4Error(bool errorRaised)
        {
            //Sens2TotalCount > Sens1TotalCount
            if (dataGridView1.InvokeRequired == true)
            {
                dataGridView1.Invoke(new MethodInvoker(delegate { HighlightResultGrid4Error(errorRaised); }));
            }
            else
            {
                try
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        DataGridViewCellStyle newCellStyle = dataGridView1.RowTemplate.DefaultCellStyle;
                        if (dataGridView1.SelectedRows.Count > 0)
                        {
                            newCellStyle = new DataGridViewCellStyle(dataGridView1.SelectedRows[0].DefaultCellStyle);
                            newCellStyle.Font = dataGridView1.RowTemplate.DefaultCellStyle.Font;
                            dataGridView1.SelectedRows[0].DefaultCellStyle = newCellStyle;
                        }

                        foreach (DataGridViewRow item in dataGridView1.Rows)
                        {
                            string result = (string)item.Cells[1].Value;
                            string ejectedStatus = (string)item.Cells[3].Value;
                            if (result == strERROR && ejectedStatus != strEJECTED)
                            {
                                item.Selected = true;

                                if (errorRaised == true)
                                    item.Cells[3].Value = strEJECTED;

                                newCellStyle = new DataGridViewCellStyle(item.DefaultCellStyle);
                                newCellStyle.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                item.DefaultCellStyle = newCellStyle;
                                break;
                            }
                        }
                        //int row2Select = 0;
                        //row2Select = (dataGridView1.Rows.Count - 1) - (Sens1TotalCount - Sens2TotalCount);
                        //if (row2Select >= 0 && row2Select < dataGridView1.Rows.Count)
                        //{
                        //    dataGridView1.FirstDisplayedScrollingRowIndex = row2Select;
                        //    dataGridView1.Rows[row2Select].Selected = true;
                        //    if (errorRaised == true)
                        //        dataGridView1.Rows[row2Select].Cells[3].Value = strEJECTED;

                        //    newCellStyle = new DataGridViewCellStyle(dataGridView1.Rows[row2Select].DefaultCellStyle);
                        //    newCellStyle.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        //    dataGridView1.Rows[row2Select].DefaultCellStyle = newCellStyle;
                        //}
                    }
                }
                catch (Exception ex)
                {
                    Trace.TraceError("{0}, AddData2Grid Error:{1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
                }
            }
        }
        private void Timer4HighlightResultGridError()
        {
            System.Timers.Timer m_Timer = null;
            m_Timer = new System.Timers.Timer();
            m_Timer.Interval = 3000;
            m_Timer.AutoReset = false;
            m_Timer.Elapsed += new System.Timers.ElapsedEventHandler(m_Timer_Elapsed);
            m_Timer.Start();
        }
        private void m_Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            HighlightResultGrid4Error(true);
        }

        private void SetCounts(bool IsGood)
        {
            if (IsGood == true)
            {
                GoodCount++;
            }
            else
            {
                TotalBadCount++;
            }
        }

        private void UpdateCounts(TextBox txt, decimal Count)
        {
            if (txt.InvokeRequired == true)
            {
                txt.Invoke(new MethodInvoker(delegate { UpdateCounts(txt, Count); }));
            }
            else
            {
                txt.Text = Convert.ToString(Count);
                UpdateTotalQty();
                if (Count != 0)
                {
                    Thread th = new Thread(UpdateJobQty);
                    th.IsBackground = true;
                    th.Start();
                }
            }
        }

        private void UpdateTotalQty()
        {
            if (txtTotalQty.InvokeRequired == true)
            {
                txtTotalQty.Invoke(new MethodInvoker(delegate { UpdateTotalQty(); }));
            }
            else
            {
                txtTotalQty.Text = Convert.ToString(GoodCount + TotalBadCount);
            }
        }

        private void EnableControl(Control ctrl, bool IsEnable)
        {
            if (ctrl.InvokeRequired == true)
            {
                ctrl.Invoke(new MethodInvoker(delegate { EnableControl(ctrl, IsEnable); }));
            }
            else
            {
                ctrl.Enabled = IsEnable;
            }
        }

        private void HideControls(Control ctrl, bool IsEnable)
        {
            if (ctrl.InvokeRequired == true)
            {
                ctrl.Invoke(new MethodInvoker(delegate { EnableControl(ctrl, IsEnable); }));
            }
            else
            {
                ctrl.Visible = IsEnable;
            }
        }

        #endregion Status Updates

        #region LostDataRecovery

        private void WriteDetailsToFile(ItemDetails oInsp)
        {
            try
            {
                Trace.TraceInformation("{0}, Started Dumping....", DateTime.Now);
                if (oInsp != null)
                {
                    string Data = oInsp.DispID + "|" + oInsp.DispLineID + "|"
                        + Convert.ToString(oInsp.UIDCode) + "|" + oInsp.Status + "|" + oInsp.DispatchedDate;
                    UTIL.SystemIntegrity.Globals.DataDumpFile.WriteToFile(mJobMaster.GDN, Data);
                    Trace.TraceInformation("{0}, Dumped UIDCode: {1}", DateTime.Now, oInsp.UIDCode);
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, Error:{1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
            }
        }

        private void RecoverLostData(string Name)
        {
            List<string> lst = UTIL.SystemIntegrity.Globals.DataDumpFile.ReadFromFile(Name);
            List<string> distinct = lst.Distinct().ToList();

            try
            {
                for (int i = distinct.Count - 1; i >= 0; )
                {
                    bool flag = RecoverData(distinct[i]);
                    if (flag == false)
                    {
                        DialogResult dr = RedMessageBox.Show("Data Failed to Recover, Press OK to retry", "WIMARTS", RedMessageBox.RedMessageBoxButtons.OKCancel, 0);
                        if (dr == DialogResult.OK)
                        {
                            continue;
                        }
                        else
                        {
                            distinct.RemoveAt(i);
                            i--;
                        }

                    }
                    else
                    {
                        distinct.RemoveAt(i);
                        i--;
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, Error:{1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
                if (distinct != null && distinct.Count > 0)
                {
                    foreach (string item in distinct)
                    {
                        UTIL.SystemIntegrity.Globals.DataDumpFile.WriteToFile(mJobMaster.GDN, item);
                    }
                }
            }
        }

        private bool RecoverData(string dataLine)
        {
            bool retval = false;
            try
            {
                string[] data = dataLine.Split('|');
                if (data.Length > 4)
                {
                    ItemDetails oDetails = new ItemDetails();
                    oDetails.DispID = Convert.ToInt32(data[0]);
                    oDetails.DispLineID = Convert.ToInt32(data[1]);
                    oDetails.UIDCode = data[2];
                    oDetails.Status = Convert.ToInt32(data[3]);
                    oDetails.DispatchedDate = Convert.ToDateTime(data[4]);
                    oDetails.LUDate = DateTime.Now;
                    oDetails.DetailsID = bllMgr.ItemDetailsBLL.UpdateDispatchStatus(oDetails);
                    //  

                    Trace.TraceInformation("{0}, Recovered and Saved UIDCode: {1}", DateTime.Now, oDetails.UIDCode);
                }
                else
                {
                    Trace.TraceInformation("{0}, Wrong Data... Can not be recovered..: {1}", DateTime.Now, dataLine);
                }
                retval = true;
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, Error:{1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
                retval = false;
            }
            return retval;
        }


        private bool CheckForDataRecovery()
        {
            bool retVal = false;
            try
            {
                List<string> lstFailedJobs = UTIL.SystemIntegrity.Globals.DataDumpFile.GetFailedJobs();
                foreach (string item in lstFailedJobs)
                {
                    RecoverLostData(item);
                    retVal = true;
                }
                retVal = true;
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, Error:{1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
                retVal = false;
            }
            return retVal;
        }

        #endregion LostDataRecovery

        #region SaveInThreadTrial

        private bool DBSaveThread = false;
        private Queue<ItemDetails> PacksQueueSave = new Queue<ItemDetails>();
        private Thread SavePacksThread = null;
        EventWaitHandle savePackhandle = new AutoResetEvent(false);
        public int AddNewPack(ItemDetails oJobDtls)
        {
            ItemDetails pack = oJobDtls;

            if (DBSaveThread == false)
            {
                return bllMgr.ItemDetailsBLL.AddItemDetails(pack);
            }
            else
            {
                PacksQueueSave.Enqueue(pack);
                if (SavePacksThread == null)
                {
                    SavePacksThread = new Thread(new ParameterizedThreadStart(WaitforPacksToBeSaved));
                    SavePacksThread.Start();
                }
                savePackhandle.Set();
            }
            return 1;
        }
        void WaitforPacksToBeSaved(object node)
        {
            while (true)
            {
                savePackhandle.WaitOne();
                if (PacksQueueSave.Count > 0)
                {
                    ItemDetails pack = PacksQueueSave.Dequeue();
                    bllMgr.ItemDetailsBLL.AddItemDetails(pack);
                }
                else
                {
                    break;
                }
            }
        }

        #endregion SaveInThreadTrial
    }
}