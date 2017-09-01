using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using WIMARTS.DB.BusinessObjects;
using WIMARTS.DB.BLL;
using System.Diagnostics;
using System.Windows.Forms;

namespace WIMARTS.REPORTS
{
    public static class PrintReports
    {
        #region Inspection


        public static void InspectionProductwiseReport(int LineID, DateTime FromDate, DateTime ToDate, Form parentForm)
        {
            try
            {
                BLLManager bllMgr = new BLLManager();
                FrmReport frm = new FrmReport();
                wimart oWiMart = GetInspectRptDS(LineID, FromDate, ToDate);
                DataSet DetailsCount = bllMgr.ItemDetailsBLL.GetItemDetailsDateDSCount(ItemDetailsBLL.ItemDate.Inspect, LineID, FromDate, ToDate);
                frm = new FrmReport(oWiMart, "", true);
                rptInspectionReport rptReport10 = new rptInspectionReport();
                rptReport10.SetDataSource(oWiMart);

                string paramval = string.Empty;
                if (FromDate.Date.Equals(ToDate.Date) == true)
                    paramval = "Date: " + FromDate.ToString("dd-MM-yyyy");
                else
                    paramval = "Date: " + FromDate.ToString("dd-MM-yyyy") + " to " + ToDate.ToString("dd-MM-yyyy");
                SetParameter(rptReport10, "FldDate", paramval);


                frm.crystalReportViewer1.ReportSource = rptReport10;
                if (parentForm != null)
                    frm.MdiParent = parentForm;
                frm.Show();
                ExportInspectionProductwiseReport(oWiMart, DetailsCount);
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, {1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
            }
        }

        private static void ExportInspectionProductwiseReport(wimart owimart, DataSet ds)
        {
            BLLManager bllMgr = new BLLManager();
            string Data = string.Empty;
            Data = GetCompanyData(owimart);

            Data += "\n";
            Data += "\n,,Production Report";

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                Data += "\n,Product Code," + item["ProdCode"] + ",Total," + item["ProdCodeCount"] + "\n";

                Data += "\n," + "Batch Code,UID Code,Date\n";

                foreach (DataRow item2 in owimart.ItemDetails.Rows)
                {
                    if (item["ProdCode"].ToString() == item2["ProdCode"].ToString())
                        Data += "\n," + item2["BatchCode"] + "," + item2["UIDCode"] + "," + item2["InspectedDate"];
                }
                Data += "\n";
            }


            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Application.StartupPath;

            sfd.Filter = "CSV (*.csv)|.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string FileName = sfd.FileName;
                using (System.IO.StreamWriter sw = System.IO.File.CreateText(FileName))
                {
                    sw.WriteLine(Data);
                }
            }

        }

        static wimart GetInspectRptDS(int id)
        {
            wimart oWiMart = new wimart();
            BLLManager bllMgr = new BLLManager();

            DataSet oInspectionMaster = bllMgr.InspectionMasterBLL.GetInspectionMasterDS(id);
            if (oInspectionMaster != null)
            {
                oWiMart.InspectionMaster.Merge(oInspectionMaster.Tables[0]);
            }
            //DataSet lstDetails = bllMgr.ItemDetailsBLL.GetItemDetailsDS(BLLManager.Flag.MasterID, Convert.ToString(id));
            //if (lstDetails != null)
            //{
            //    oWiMart.InspectionDetails.Merge(lstDetails.Tables[0]);
            //}
            DataSet lstProduct = bllMgr.ProductMasterBLL.GetProductDataset();
            if (lstProduct != null)
            {
                oWiMart.ProductMaster.Merge(lstProduct.Tables[0]);
            }
            return oWiMart;
        }

        static wimart GetInspectRptDS(int LineID, DateTime FromDate, DateTime ToDate)
        {
            wimart oWiMart = new wimart();
            BLLManager bllMgr = new BLLManager();
            DataSet lstDetails = bllMgr.ItemDetailsBLL.GetItemDetailsDateDS(ItemDetailsBLL.ItemDate.Inspect, LineID, FromDate, ToDate);
            if (lstDetails != null)
            {
                oWiMart.ItemDetails.Merge(lstDetails.Tables[0]);
            }
            DataSet dsCompany = bllMgr.CompanyMasterBLL.GetCompanyMasterDS();
            if (dsCompany != null)
            {
                oWiMart.CompanyMaster.Merge(dsCompany.Tables[0]);
            }
            return oWiMart;
        }

        static wimart GetInspectRptSummaryDS(DateTime FromDate, DateTime ToDate)
        {

            wimart oWiMart = new wimart();
            BLLManager bllMgr = new BLLManager();

            DataSet oInspectionMaster = bllMgr.InspectionMasterBLL.GetInspectionMasterDS(FromDate, ToDate);
            if (oInspectionMaster != null)
            {
                oWiMart.InspectionMaster.Merge(oInspectionMaster.Tables[0]);
            }
            return oWiMart;
        }

        static wimart GetInspectRptDetailedSummaryDS(DateTime FromDate, DateTime ToDate)
        {

            wimart oWiMart = new wimart();
            BLLManager bllMgr = new BLLManager();

            //DataSet oInspectionDetails = bllMgr.InspectionDetailsBLL.GetInspectionDetailedSummaryDS(FromDate, ToDate);
            //if (oInspectionDetails != null)
            //{
            //    oWiMart.InspectionSummary.Merge(oInspectionDetails.Tables[0]);
            //}
            return oWiMart;
        }

        #endregion Inspection


        #region Dispatch

        public static void DispatchReport(int MasterID, bool showUIDs, Form parentForm, UserMaster curUser)
        {
            wimart oWiMart = GetDispatchRpt(MasterID, showUIDs);
            BLLManager bllMgr = new BLLManager();
            FrmReport frm = new FrmReport(oWiMart, "", true);
            if (showUIDs == true)
            {
                rptDispatchReport rptReport10 = new rptDispatchReport();

                DataSet dsCompany = bllMgr.CompanyMasterBLL.GetCompanyMasterDS();
                if (dsCompany != null)
                {
                    oWiMart.CompanyMaster.Merge(dsCompany.Tables[0]);
                }
                rptReport10.SetDataSource(oWiMart);
                frm.crystalReportViewer1.ReportSource = rptReport10;
            }
            else
            {
                rptBatchwiseItems_Dispatch rptReport = new rptBatchwiseItems_Dispatch();

                DataSet dsCompany = bllMgr.CompanyMasterBLL.GetCompanyMasterDS();
                if (dsCompany != null)
                {
                    oWiMart.CompanyMaster.Merge(dsCompany.Tables[0]);
                }
                rptReport.SetDataSource(oWiMart);
                SetParameter(rptReport, "ReportName", "Dispatch Summary");
                SetParameter(rptReport, "UserName", curUser.Name);
                frm.crystalReportViewer1.ReportSource = rptReport;
            }

            if (parentForm != null)
                frm.MdiParent = parentForm;
            frm.Show();
        }

        static wimart GetDispatchRpt(int MasterID, bool showUIDs)
        {
            wimart obj = new wimart();
            BLLManager bllMgr = new BLLManager();
            DataSet oMaster = bllMgr.DispatchMasterBLL.GetDispatchMDatasetByValue(DispatchMasterBLL.Flag.MasterID, MasterID.ToString());
            if (oMaster != null)
            {
                obj.DispatchMaster.Merge(oMaster.Tables[0]);
            }
            DataSet oDetails = bllMgr.DispatchDetailsBLL.GetDispatchDetailsByDispMasterDS(DispatchDetailsBLL.Flag.Master, Convert.ToString(MasterID));
            if (oDetails != null)
            {
                obj.DispatchDetails.Merge(oDetails.Tables[0]);
            }
            DataSet oCustomer = bllMgr.CustomerMasterBLL.GetCustomerMastersDS(MasterID);
            if (oCustomer != null)
            {
                obj.CustomerMaster.Merge(oCustomer.Tables[0]);
            }
            if (showUIDs == true)
            {
                DataSet oItems = bllMgr.ItemDetailsBLL.GetItemDetailsDS(ItemDetailsBLL.Flag.DispID, BLLManager.DetailsStatus.All, MasterID.ToString());
                if (oItems != null)
                {
                    obj.ItemDetails.Merge(oItems.Tables[0]);
                }

            }
            else
            {
                //DataSet oDataSet = bllMgr.CustomerMasterBLL.get
            }
            return obj;
        }

        #endregion Dispatch

        #region Item Report
        public static void ProductSummaryReport(Form parentForm)
        {
            try
            {
                FrmReport frm = new FrmReport();
                wimart oWiMart = GetProductSummaryRptDS();
                frm = new FrmReport(oWiMart, "", true);
                rptProductSummary rptReport10 = new rptProductSummary();
                rptReport10.SetDataSource(oWiMart);
                frm.crystalReportViewer1.ReportSource = rptReport10;
                if (parentForm != null)
                    frm.MdiParent = parentForm;
                frm.Show();
                ExportProductSummaryReport(oWiMart);
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, {1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
            }
        }
        public static void ProductItemReport(ItemDetailsBLL.Report Flag, int LineID, string ReportName, DateTime FromDate, DateTime ToDate, Form parentForm)
        {
            try
            {
                FrmReport frm = new FrmReport();
                wimart oWiMart = GetProductItemRptDS(Flag, LineID, FromDate, ToDate);
                frm = new FrmReport(oWiMart, "", true);
                rptProductwiseItems rptReport10 = new rptProductwiseItems();
                rptReport10.SetDataSource(oWiMart);
                SetParameter(rptReport10, "ReportName", ReportName);

                string paramval = string.Empty;
                if (FromDate.Date.Equals(ToDate.Date) == true)
                    paramval = "Date: " + FromDate.ToString("dd-MM-yyyy");
                else
                    paramval = "Date: " + FromDate.ToString("dd-MM-yyyy") + " to " + ToDate.ToString("dd-MM-yyyy");
                SetParameter(rptReport10, "FldDate", paramval);

                frm.crystalReportViewer1.ReportSource = rptReport10;
                if (parentForm != null)
                    frm.MdiParent = parentForm;
                frm.Show();
                ExportProductItemReport(oWiMart, ReportName);
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, {1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
            }
        }
        public static void BatchItemReport(ItemDetailsBLL.Report Flag, int LineID, String ReportName, DateTime FromDate, DateTime ToDate, Form parentForm)
        {
            try
            {
                BLLManager bllMgr = new BLLManager();
                FrmReport frm = new FrmReport();
                wimart oWiMart = GetBatchItemRptDS(Flag, LineID, FromDate, ToDate);
                frm = new FrmReport(oWiMart, "", true);
                rptBatchwiseItems rptReport10 = new rptBatchwiseItems();
                DataSet DetailsCount = bllMgr.ItemDetailsBLL.GetItemDetailsReportCount(Flag, LineID, FromDate, ToDate);
                rptReport10.SetDataSource(oWiMart);
                SetParameter(rptReport10, "ReportName", ReportName);
                string paramval = string.Empty;
                if (FromDate.Date.Equals(ToDate.Date) == true)
                    paramval = "Date: " + FromDate.ToString("dd-MM-yyyy");
                else
                    paramval = "Date: " + FromDate.ToString("dd-MM-yyyy") + " to " + ToDate.ToString("dd-MM-yyyy");
                SetParameter(rptReport10, "FldDate", paramval);


                frm.crystalReportViewer1.ReportSource = rptReport10;
                if (parentForm != null)
                    frm.MdiParent = parentForm;
                frm.Show();
                ExportBatchItemReport(oWiMart, DetailsCount, ReportName);
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, {1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
            }
        }

        private static void ExportProductSummaryReport(wimart owimart)
        {
            BLLManager bllMgr = new BLLManager();
            string Data = string.Empty;
            int srNo = 1;
            Data = GetCompanyData(owimart);

            Data += "\n";
            Data += "\n,,Report";

            Data += "\nSrNo,Code,Name,Printed,Reject,Inspected,Wasted,Dispatch,Archived,Total\n";

            int Printed = 0;
            int Rejected = 0;
            int Inspected = 0;
            int Wasted = 0;
            int Dispatched = 0;
            int Archived = 0;
            int Total = 0;
            foreach (DataRow item2 in owimart.ProductSummary.Rows)
            {

                Data += "\n" + srNo + "," + item2["Code"] + "," + item2["Name"] + "," + item2["Printed"] + "," + item2["Rejected"] + "," + item2["Inspected"] + "," + item2["Wasted"] + "," + item2["Dispatched"] + "," + item2["Archived"] + "," + item2["Total"];
                Printed += Convert.ToInt32(item2["Printed"].ToString());
                Rejected += Convert.ToInt32(item2["Rejected"].ToString());
                Inspected += Convert.ToInt32(item2["Inspected"].ToString());
                Wasted += Convert.ToInt32(item2["Wasted"].ToString());
                Dispatched += Convert.ToInt32(item2["Dispatched"].ToString());
                Archived += Convert.ToInt32(item2["Archived"].ToString());
                Total += Convert.ToInt32(item2["Total"].ToString());

                srNo++;
            }

            Data += "\n\n,,Total," + Printed + "," + Rejected + "," + Inspected + "," + Wasted + "," + Dispatched + "," + Archived + "," + Total;


            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Application.StartupPath;

            sfd.Filter = "CSV (*.csv)|.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string FileName = sfd.FileName;
                using (System.IO.StreamWriter sw = System.IO.File.CreateText(FileName))
                {
                    sw.WriteLine(Data);
                }
            }
        }
        private static void ExportProductItemReport(wimart owimart, string ReportName)
        {
            BLLManager bllMgr = new BLLManager();
            string Data = string.Empty;
            int srNo = 1;

            Data = GetCompanyData(owimart);

            Data += "\n";
            Data += "\n,," + ReportName;

            Data += "\nSrNo,Code,Name,Pack Size,Quantity\n";

            int Total = 0;
            foreach (DataRow item2 in owimart.ProductwiseItems.Rows)
            {
                Data += "\n" + srNo + "," + item2["Code"] + "," + item2["Name"] + "," + item2["PACKSIZE"] + "," + item2["QUANTITY"];

                Total += Convert.ToInt32(item2["QUANTITY"].ToString());
                srNo++;
            }

            Data += "\n\n,,,Total," + Total;


            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Application.StartupPath;

            sfd.Filter = "CSV (*.csv)|.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string FileName = sfd.FileName;
                using (System.IO.StreamWriter sw = System.IO.File.CreateText(FileName))
                {
                    sw.WriteLine(Data);
                }
            }
        }
        private static void ExportBatchItemReport(wimart owimart, DataSet DetailsCount, string ReportName)
        {
            BLLManager bllMgr = new BLLManager();
            string Data = string.Empty;
            int srNo = 1;
            Data = GetCompanyData(owimart);

            Data += "\n";
            Data += "\n,," + ReportName;

            Data += "\nSrNo,Code,Name,Quantity\n";

            int Total = 0;

            foreach (DataRow item in DetailsCount.Tables[0].Rows)
            {
                Data += "\nBatch," + item["BATCH"] + ",Total," + item["BatchCodeCount"] + "\n";

                Data += "\nSrNo,Code,Name,Quantity\n";

                foreach (DataRow item2 in owimart.BatchwiseItems.Rows)
                {
                    if (item["BATCH"].ToString() == item2["BATCH"].ToString())
                    {
                        Data += "\n" + srNo + "," + item2["Code"] + "," + item2["Name"] + "," + item2["QUANTITY"];

                        Total += Convert.ToInt32(item2["QUANTITY"].ToString());
                        srNo++;
                    }

                }
                Data += "\n";
            }

            Data += "\n\n,,Total," + Total;


            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Application.StartupPath;

            sfd.Filter = "CSV (*.csv)|.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string FileName = sfd.FileName;
                using (System.IO.StreamWriter sw = System.IO.File.CreateText(FileName))
                {
                    sw.WriteLine(Data);
                }
            }
        }

        static wimart GetProductSummaryRptDS()
        {
            wimart oWiMart = new wimart();
            BLLManager bllMgr = new BLLManager();
            DataSet lstDetails = bllMgr.ProductMasterBLL.GetProductSummary();
            if (lstDetails != null)
            {
                oWiMart.ProductSummary.Merge(lstDetails.Tables[0]);
            }
            DataSet dsCompany = bllMgr.CompanyMasterBLL.GetCompanyMasterDS();
            if (dsCompany != null)
            {
                oWiMart.CompanyMaster.Merge(dsCompany.Tables[0]);
            }
            return oWiMart;
        }
        static wimart GetProductItemRptDS(ItemDetailsBLL.Report Flag, int LineID, DateTime FromDate, DateTime ToDate)
        {
            wimart oWiMart = new wimart();
            BLLManager bllMgr = new BLLManager();
            DataSet dsCompany = bllMgr.CompanyMasterBLL.GetCompanyMasterDS();
            if (dsCompany != null)
            {
                oWiMart.CompanyMaster.Merge(dsCompany.Tables[0]);
            }
            DataSet lstDetails = bllMgr.ItemDetailsBLL.GetItemDetailsReport(Flag, LineID, FromDate, ToDate);
            if (lstDetails != null)
            {
                oWiMart.ProductwiseItems.Merge(lstDetails.Tables[0]);
            }
            return oWiMart;
        }
        static wimart GetBatchItemRptDS(ItemDetailsBLL.Report Flag, int LineID, DateTime FromDate, DateTime ToDate)
        {
            wimart oWiMart = new wimart();
            BLLManager bllMgr = new BLLManager();
            DataSet dsCompany = bllMgr.CompanyMasterBLL.GetCompanyMasterDS();
            if (dsCompany != null)
            {
                oWiMart.CompanyMaster.Merge(dsCompany.Tables[0]);
            }
            DataSet lstDetails = bllMgr.ItemDetailsBLL.GetItemDetailsReport(Flag, LineID, FromDate, ToDate);
            if (lstDetails != null)
            {
                oWiMart.BatchwiseItems.Merge(lstDetails.Tables[0]);
            }
            return oWiMart;
        }
        
        private static string GetCompanyData(wimart owimart)
        {
            string Data = string.Empty;
            if (owimart.CompanyMaster.Rows.Count > 0)
            {

                Data = "," + owimart.CompanyMaster.Rows[0]["CompanyName"];
                Data += "\n" + ",," + owimart.CompanyMaster.Rows[0]["AddressLine"] + " " + owimart.CompanyMaster.Rows[0]["City"] + " " + owimart.CompanyMaster.Rows[0]["Pincode"];
            }
            return Data;
        }

        #endregion Item Report

        #region PackList

        public static void PackListReport(DateTime date, Form parentForm)
        {
            try
            {
                FrmReport frm = new FrmReport();
                wimart oWiMart = GetPickList(date);
                frm = new FrmReport(oWiMart, "", true);
                rptPickList rptReport10 = new rptPickList();
                rptReport10.SetDataSource(oWiMart);
                frm.crystalReportViewer1.ReportSource = rptReport10;
                if (parentForm != null)
                    frm.MdiParent = parentForm;
                frm.Show();
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, {1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
            }
        }
        static wimart GetPickList(DateTime date)
        {
            wimart obj = new wimart();
            BLLManager bllMgr = new BLLManager();
            List<DispatchMaster> lstMaster = bllMgr.DispatchMasterBLL.GetDispatchListByValue(DispatchMasterBLL.Flag.DispatchDate, date.ToString("s"));
            string dispMasterID = string.Empty;
            foreach (DispatchMaster oMaster in lstMaster)
            {
                dispMasterID += oMaster.DispMasterID + ",";
            }
            DataSet oDetails = bllMgr.DispatchDetailsBLL.GetDispatchDetailsByDispMasterDS(DispatchDetailsBLL.Flag.MultiMaster, dispMasterID);
            if (oDetails != null)
            {
                obj.DispatchDetails.Merge(oDetails.Tables[0]);
                foreach (DataRow item2 in oDetails.Tables[0].Rows)
                {
                    DataSet oItems = bllMgr.ItemDetailsBLL.GetItemDetailsQuantityDS(Convert.ToInt32(item2["MaxQty"]), BLLManager.DetailsStatus.Scanned, item2["ProdCode"].ToString());
                    if (oItems != null)
                    {
                        obj.ItemDetails.Merge(oItems.Tables[0]);
                    }
                }
            }
            DataSet lstProduct = bllMgr.ProductMasterBLL.GetProductDataset();
            if (lstProduct != null)
            {
                obj.ProductMaster.Merge(lstProduct.Tables[0]);
            }
            DataSet dsCompany = bllMgr.CompanyMasterBLL.GetCompanyMasterDS();
            if (dsCompany != null)
            {
                obj.CompanyMaster.Merge(dsCompany.Tables[0]);
            }
            return obj;
        }

        #endregion packList

        private static void SetParameter(CrystalDecisions.CrystalReports.Engine.ReportClass rps, string ParameterName, String Value)
        {
            string ParameterValue = Value;
            CrystalDecisions.CrystalReports.Engine.ParameterFieldDefinitions crParameterFieldDefinitions = rps.DataDefinition.ParameterFields;
            CrystalDecisions.CrystalReports.Engine.ParameterFieldDefinition crParameterFieldLocation = crParameterFieldDefinitions[ParameterName];
            CrystalDecisions.Shared.ParameterValues crParameterValues = crParameterFieldLocation.CurrentValues;
            CrystalDecisions.Shared.ParameterDiscreteValue crParameterDiscreteValue = new CrystalDecisions.Shared.ParameterDiscreteValue();
            crParameterDiscreteValue.Value = ParameterValue;
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues);
        }
        public static List<ItemDetails> GeneratePackList(DateTime date)
        {
            BLLManager bllMgr = new BLLManager();
            List<ItemDetails> lstItems = new List<ItemDetails>();
            List<DispatchMaster> lstMaster = bllMgr.DispatchMasterBLL.GetDispatchListByValue(DispatchMasterBLL.Flag.DispatchDate, date.ToString("s"));
            string dispMasterID = string.Empty;
            foreach (DispatchMaster oMaster in lstMaster)
            {
                dispMasterID += oMaster.DispMasterID + ",";
            }
            //    List<DispatchDetails> lstDispDetails = bllMgr.DispatchDetailsBLL.GetDispatchDetailsByDispMaster(DispatchDetailsBLL.Flag.MultiMaster, dispMasterID);
            return lstItems;
        }
    }
}
