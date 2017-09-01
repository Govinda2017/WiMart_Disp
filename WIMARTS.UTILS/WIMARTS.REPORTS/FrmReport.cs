using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WIMARTS.DB.BusinessObjects;
using WIMARTS.DB.BLL;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace WIMARTS.REPORTS
{
    public partial class FrmReport : Form
    {
        #region Properties
        BLLManager bllMgr;
        wimart curDS = new wimart();
        string rptPath;

        private string Mailer { get; set; }
        private string Mailee { get; set; }
        private string MailSubject { get; set; }
        private string AttachmentPath { get; set; }

        #endregion Properties

        public FrmReport()
        {
            InitializeComponent();
            bllMgr = new BLLManager();
        }

        public FrmReport(wimart ds, string ReportPath, bool oShow)
        {
            InitializeComponent();
            bllMgr = new BLLManager();
            curDS = ds;
        }

        private void BTN_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTN_Export_Click(object sender, EventArgs e)
        {
            SaveFileDialog fp = new SaveFileDialog();
            fp.CheckPathExists = true;
            fp.RestoreDirectory = true;
            fp.Filter = "PDF file (*.pdf)|*.pdf";
            string fileName = Application.StartupPath + MailSubject + ".pdf";
            fp.FileName = fileName;
            if (fp.ShowDialog() == DialogResult.OK)
            {
                ReportDocument rptCls = (ReportDocument)crystalReportViewer1.ReportSource;
                rptCls.ExportToDisk(ExportFormatType.PortableDocFormat, fp.FileName);
            }
        }
        private void BTN_ExportXLS_Click(object sender, EventArgs e)
        {
            SaveFileDialog fp = new SaveFileDialog();
            fp.CheckPathExists = true;
            fp.RestoreDirectory = true;
            fp.Filter = "Excel file (*.xls)|*.xls";
            string fileName = Application.StartupPath + MailSubject + ".xls";
            fp.FileName = fileName;
            if (fp.ShowDialog() == DialogResult.OK)
            {
                ReportDocument rptCls = (ReportDocument)crystalReportViewer1.ReportSource;
                rptCls.ExportToDisk(ExportFormatType.Excel, fp.FileName);
            }

        }

        private void BTN_ExportWord_Click(object sender, EventArgs e)
        {
            SaveFileDialog fp = new SaveFileDialog();
            fp.CheckPathExists = true;
            fp.RestoreDirectory = true;
            fp.Filter = "Excel file (*.doc)|*.doc";
            string fileName = Application.StartupPath + MailSubject + ".doc";
            fp.FileName = fileName;
            if (fp.ShowDialog() == DialogResult.OK)
            {
                ReportDocument rptCls = (ReportDocument)crystalReportViewer1.ReportSource;
                rptCls.ExportToDisk(ExportFormatType.WordForWindows, fp.FileName);
            }
        }

        private void Btn_ExportMail_Click(object sender, EventArgs e)
        {
            try
            {
                // sendEMailThroughOUTLOOK();
            }
            catch (System.Exception ex)
            {
                Trace.TraceError("{0}, Btn_ExportMail_Click {1}", DateTime.Now, ex.Message);
            }
        }


        private void FrmReport_Load(object sender, EventArgs e)
        {
            //   crystalReportViewer1.RefreshReport();
            //    crystalReportViewer1.ReportSource = rptDoc;
        }

        public void SetMailInfo(int oMaileeID, string oPoNumber, string oSubject)
        {

            //  PurchaseOrderNum = oPoNumber.Replace('/', '-');
            //    //switch (oFormType)
            //{
            //    case Module.Sales:
            //        CustomerMaster oCust = bllMgr.CustomerMasterBLL.GetCustomerMaster(oMaileeID.ToString());
            //        if (oCust != null)
            //            Mailee = oCust.EmailID1;
            //        Mailer = oCust.CustName;
            //        break;
            //    case Module.Purchase:
            //        SupplierMaster oSupp = bllMgr.SupplierMasterBLL.GetSupplierMaster(oMaileeID.ToString());
            //        if (oSupp != null)
            //            Mailee = oSupp.EmailID1;
            //        Mailer = oSupp.SupplierName;
            //        break;
            //    case Module.Manufacturing:
            //        VendorMaster oVend = bllMgr.VendorMasterBLL.GetVendorMaster(oMaileeID.ToString());
            //        if (oVend != null)
            //            Mailee = oVend.EmailID1;
            //        Mailer = oVend.VendorName;
            //        break;
            //    default:
            //        break;
            //}
            //  MailSubject = oSubject + PurchaseOrderNum + Mailer;
        }

        //Microsoft.Office.Interop.Outlook.Application oApp;
        //Microsoft.Office.Interop.Outlook.MailItem oMsg;
        ////method to send email to outlook
        //public void sendEMailThroughOUTLOOK()
        //{
        //    try
        //    {
        //        this.Cursor = Cursors.WaitCursor;
        //        //Save pdf file before Attaching
        //        // string fileName = RedUTILS.SettingsPath.DataDir + MailSubject + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".pdf";
        //        string fileName = RedUTILS.SettingsPath.DataDir + MailSubject + ".pdf";
        //        ReportDocument rptCls = (ReportDocument)crystalReportViewer1.ReportSource;
        //        rptCls.ExportToDisk(ExportFormatType.PortableDocFormat, fileName);
        //        // Create the Outlook application.
        //        oApp = new Microsoft.Office.Interop.Outlook.Application();
        //        // Create a new mail item.
        //        oMsg = (Microsoft.Office.Interop.Outlook.MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
        //        // Set HTMLBody. 
        //        //add the body of the email
        //        oMsg.HTMLBody = "" + ReadSignature();
        //        //Add an attachment.
        //        String sDisplayName = "MyAttachment";
        //        int iPosition = (int)oMsg.Body.Length + 1;
        //        //oMsg.HTMLBody= ReadSignature();
        //        int iAttachType = (int)Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue;
        //        //now attached the file
        //        Microsoft.Office.Interop.Outlook.Attachment oAttach = oMsg.Attachments.Add(@fileName, iAttachType, iPosition, sDisplayName);
        //        //Subject line
        //        oMsg.Subject = MailSubject;
        //        // Add a recipient.
        //        Microsoft.Office.Interop.Outlook.Recipients oRecips = (Microsoft.Office.Interop.Outlook.Recipients)oMsg.Recipients;
        //        // Change the recipient in the next line if necessary.
        //        Microsoft.Office.Interop.Outlook.Recipient oRecip;
        //        if (Mailee != string.Empty)
        //            oRecip = (Microsoft.Office.Interop.Outlook.Recipient)oRecips.Add(Mailee);
        //        else
        //            oRecip = (Microsoft.Office.Interop.Outlook.Recipient)oRecips.Add(" ");
        //        oRecip.Resolve();
        //        // Send.

        //        oMsg.Display();
        //        //                oMsg.Send();
        //        // Clean up.
        //        oRecip = null;
        //        oRecips = null;
        //    }//end of try block
        //    catch (System.Exception ex)
        //    {
        //        MessageBox.Show("" + ex.Message);
        //        Trace.TraceError("{0}, Outlook Print {1}", DateTime.Now, ex.Message);
        //    }//end of catch

        //    // Clean up.
        //    oMsg = null;
        //    oApp = null;
        //    this.Cursor = Cursors.Default;
        //}//end of Email Method
        //private string ReadSignature()
        //{
        //    string appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Signatures";
        //    string signature = string.Empty;
        //    DirectoryInfo diInfo = new DirectoryInfo(appDataDir);
        //    if
        //    (diInfo.Exists)
        //    {
        //        FileInfo[] fiSignature = diInfo.GetFiles("*.htm");

        //        if (fiSignature.Length > 0)
        //        {
        //            StreamReader sr = new StreamReader(fiSignature[0].FullName, Encoding.Default);
        //            signature = sr.ReadToEnd();
        //            if (!string.IsNullOrEmpty(signature))
        //            {
        //                string fileName = fiSignature[0].Name.Replace(fiSignature[0].Extension, string.Empty);
        //                signature = signature.Replace(fileName + "_files/", appDataDir + "/" + fileName + "_files/");
        //            }
        //        }

        //    }
        //    return signature;
        //}
    }
}