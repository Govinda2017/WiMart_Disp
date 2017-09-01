using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using WIMARTS.CODEMGR;
using WIMARTS.DB.BusinessObjects;
using WIMARTS.DB.BLL;

namespace WIMARTS.COMMON
{
    public partial class FrmBoxWastage : Form
    {
        BLLManager bllMgr;
        ItemDetails oldItem;
        ItemDetails newItem;
        public FrmBoxWastage()
        {
            InitializeComponent();
            bllMgr = new BLLManager();
            oldItem = new ItemDetails();
        }

        #region UI Handlers
        private void txtScannedData_TextChanged(object sender, EventArgs e)
        {
            try
            {
                EnableControls(txtAltUID, false);
                EnableControls(txtAltScanned, false);

                if (txtScannedData.Text.EndsWith("\n"))
                {
                    string dataCode = txtScannedData.Text = txtScannedData.Text.Replace("\n", "");
                    dataCode = dataCode.Replace("\r", "");
                    ProcessInspectedData(dataCode);
                    txtScannedData.SelectAll();
                    Trace.TraceInformation("{0}, Data Scanned: {1}", DateTime.Now, dataCode);
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, Error:{1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
            }
        }
        private void txtUID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                EnableControls(txtAltUID, false);
                EnableControls(txtAltScanned, false);

                if (txtUID.Text.EndsWith("\n"))
                {
                    string dataCode = txtUID.Text = txtUID.Text.Replace("\n", "");
                    dataCode = "21" + dataCode.Replace("\r", "");
                    ProcessInspectedData(dataCode);
                    txtUID.SelectAll();
                    Trace.TraceInformation("{0}, Data Scanned: {1}", DateTime.Now, dataCode);
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, Error:{1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
            }
        }
        private void txtAltScanned_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtAltScanned.Text.EndsWith("\n"))
                {
                    string dataCode = txtAltScanned.Text = txtAltScanned.Text.Replace("\n", "");
                    dataCode = dataCode.Replace("\r", "");
                    ProcessInspectedAltData(dataCode);
                    txtScannedData.SelectAll();
                    Trace.TraceInformation("{0}, Data Scanned: {1}", DateTime.Now, dataCode);
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, Error:{1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
            }
        }
        private void txtAltUID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtAltUID.Text.EndsWith("\n"))
                {
                    string dataCode = txtAltUID.Text = txtAltUID.Text.Replace("\n", "");
                    dataCode = "21" + dataCode.Replace("\r", "");
                    ProcessInspectedAltData(dataCode);
                    txtUID.SelectAll();
                    Trace.TraceInformation("{0}, Data Scanned: {1}", DateTime.Now, dataCode);
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, Error:{1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
            }
        }

        #endregion UI Handlers

        #region Data Handlers

        private void ProcessInspectedData(string dataCode)
        {
            try
            {
                GS1Mgr.GS1Values lstTags = DecodeData(dataCode);
                if (string.IsNullOrEmpty(lstTags.UID) == false)
                {
                    bool dataResult = ValidateData(lstTags.UID);

                    if (dataResult == true)
                    {
                        EnableControls(txtAltUID, true);
                        EnableControls(txtAltScanned, true);
                        FillCurItem(lstTags);
                        UpdateText(lblStatusBar, "Enter Alternate BoxID: ");
                        UpdateStatusColor(btnIndicator, true);
                    }
                    else
                    {
                        EnableControls(txtAltUID, false);
                        EnableControls(txtAltScanned, false);
                        UpdateStatusColor(btnIndicator, false);
                    }
                }
                else
                {
                    txtScannedData.Clear();
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, Error:{1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
            }
        }

        private bool ValidateData(string UIDCode)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new MethodInvoker(delegate { ValidateData(UIDCode); }));
            }
            else
            {
                foreach (DataGridViewRow row in dgScannedData.Rows)
                {
                    if (row.Cells["UIDColumn"].Value.ToString().Equals(UIDCode))
                    {
                        row.Selected = true;
                        dgScannedData.FirstDisplayedScrollingRowIndex = row.Index;
                        UpdateText(lblStatusBar, "Repeated Box: " + UIDCode);
                        Trace.TraceInformation("{0},Rejection: Repeated Box:{1}", DateTime.Now, UIDCode);
                        return false;
                    }
                }
                ItemDetails oPrint = bllMgr.ItemDetailsBLL.GetItemDetails(BLLManager.DetailsStatus.Scanned, UIDCode);
                if (oPrint == null || oPrint.DetailsID == 0)
                {
                    UpdateText(lblStatusBar, "Wrong box: " + UIDCode);
                    Trace.TraceInformation("{0}, Wrong box: {1}", DateTime.Now, UIDCode);
                    return false;
                }
            }
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

        private void FillCurItem(GS1Mgr.GS1Values CodeData)
        {
            oldItem = bllMgr.ItemDetailsBLL.GetItemDetails(BLLManager.DetailsStatus.Scanned, CodeData.UID);
        }

        private void AddData2Grid()
        {
            if (dgScannedData.InvokeRequired == true)
            {
                dgScannedData.Invoke(new MethodInvoker(delegate { AddData2Grid(); }));
            }
            else
            {
                int i = dgScannedData.Rows.Add();
                dgScannedData.Rows[i].Cells["SrNoColumn"].Value = i + 1;
                dgScannedData.Rows[i].Cells["ProductCodeColumn"].Value = oldItem.ProdCode;
                dgScannedData.Rows[i].Cells["BatchNameColumn"].Value = oldItem.BatchCode;
                dgScannedData.Rows[i].Cells["UIDColumn"].Value = oldItem.UIDCode;
                dgScannedData.Rows[i].Cells["AlternateBoxIDColumn"].Value = newItem.UIDCode;
                dgScannedData.Rows[i].Cells["DateColumn"].Value = DateTime.Now;
                dgScannedData.FirstDisplayedScrollingRowIndex = i;
            }
        }


        private void ProcessInspectedAltData(string dataCode)
        {
            try
            {
                GS1Mgr.GS1Values lstTags = DecodeData(dataCode);
                if (string.IsNullOrEmpty(lstTags.UID) == false)
                {
                    bool dataResult = ValidateAltData(lstTags.UID);

                    if (dataResult == true)
                    {
                        AddData2Grid();
                        UpdateStatusColor(btnIndicator, true);
                    }
                    else
                    {
                        UpdateStatusColor(btnIndicator, false);
                    }
                }
                else
                {
                    txtScannedData.Clear();
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, Error:{1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
            }
        }
        private bool ValidateAltData(string UIDCode)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new MethodInvoker(delegate { ValidateData(UIDCode); }));
            }
            else
            {
                foreach (DataGridViewRow row in dgScannedData.Rows)
                {
                    if (row.Cells["UIDColumn"].Value.ToString().Equals(UIDCode))
                    {
                        row.Selected = true;
                        dgScannedData.FirstDisplayedScrollingRowIndex = row.Index;
                        Trace.TraceInformation("{0}, Repeated Box:{1}", DateTime.Now, UIDCode);
                        return false;
                    }
                }
                newItem = bllMgr.ItemDetailsBLL.GetItemDetails(BLLManager.DetailsStatus.Created, UIDCode);
                if (newItem == null || newItem.DetailsID == 0)
                {
                    UpdateText(lblStatusBar, "Wrong box: " + UIDCode);
                    Trace.TraceInformation("{0}, Wrong box: {1}", DateTime.Now, UIDCode);
                    return false;
                }
                else
                {
                    if (newItem.ProdCode == oldItem.ProdCode && newItem.BatchCode == oldItem.BatchCode)
                    {
                        newItem.InspID = oldItem.InspID;
                        newItem.InspectedDate = oldItem.InspectedDate;
                        newItem.Status = Convert.ToInt32(BLLManager.DetailsStatus.Scanned);
                        newItem.LUDate = DateTime.Now;
                        bllMgr.ItemDetailsBLL.UpdateItemDetails(newItem);

                        oldItem.Status = Convert.ToInt32(BLLManager.DetailsStatus.Wasted);
                        oldItem.LUDate = DateTime.Now;
                        bllMgr.ItemDetailsBLL.UpdateItemDetails(oldItem);
                        UpdateText(lblStatusBar, "Box data exchanged ");
                        Trace.TraceInformation("{0}, Box data exchanged, Old Box ID: {1}, New Box ID: {2}", DateTime.Now, oldItem.UIDCode, newItem.UIDCode);

                    }
                    else
                        return false;
                }
            }
            return true;
        }

        private void AlterUIDCode()
        {
            if (oldItem.DetailsID > 0)
            {

            }
        }

        #endregion Data Handlers

        #region UI Updates
        private void EnableControls(Control ctrl, bool IsEnabled)
        {
            if (ctrl.InvokeRequired == true)
            {
                ctrl.Invoke(new MethodInvoker(delegate { EnableControls(ctrl, IsEnabled); }));
            }
            else
            {
                ctrl.Enabled = IsEnabled;
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

        #endregion UI Updates
    }
}