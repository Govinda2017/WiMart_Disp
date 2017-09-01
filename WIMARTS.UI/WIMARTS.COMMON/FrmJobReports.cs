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

namespace WIMARTS.COMMON
{
    public partial class FrmJobReport : Form
    {
        BLLManager bllMgr;
        public FrmJobReport()
        {
            InitializeComponent();
            bllMgr = new BLLManager();
        }

        private void FrmJobReports_Load(object sender, EventArgs e)
        {
            cmbApplication.SelectedIndex = cmbLineNo.SelectedIndex
                = cmbWise.SelectedIndex = 0;
        }

        private void FrmJobReports_Shown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            LoadDBData();
            Cursor = Cursors.Arrow;
        }

        private void LoadDBData()
        {
            dtpFromDate.Value = DateTime.Now;
            dtpToDate.Value = DateTime.Now;
        }

        private void btnSummaryProd_Click(object sender, EventArgs e)
        {
            WIMARTS.REPORTS.PrintReports.ProductSummaryReport(this.MdiParent);
        }

        private void btnDispDetails_Click(object sender, EventArgs e)
        {
            WIMARTS.REPORTS.PrintReports.PackListReport(dtpFromDate.Value, this.MdiParent);
        }
        private void btnInspDetails_Click(object sender, EventArgs e)
        {
            WIMARTS.REPORTS.PrintReports.InspectionProductwiseReport(UTIL.SystemIntegrity.Globals.AppSettings.LineID, dtpFromDate.Value.Date, dtpToDate.Value, this.MdiParent);
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            ApplicationID oApp = (ApplicationID)cmbApplication.SelectedIndex;
            int LineID = 0;
            switch (oApp)
            {
                case ApplicationID.Printing:
                    if (cmbWise.SelectedIndex == 0)
                    {
                        WIMARTS.REPORTS.PrintReports.ProductItemReport(ItemDetailsBLL.Report.PProduct, 0, "Printing Report", dtpFromDate.Value, dtpToDate.Value, this.MdiParent);
                    }
                    else if (cmbWise.SelectedIndex == 1)
                    {
                        WIMARTS.REPORTS.PrintReports.BatchItemReport(ItemDetailsBLL.Report.PBatch, 0, "Printing Report", dtpFromDate.Value, dtpToDate.Value, this.MdiParent);
                    }
                    else
                    { }
                    break;
                case ApplicationID.Production:
                    LineID = cmbLineNo.SelectedIndex;
                    if (cmbWise.SelectedIndex == 0)
                    {
                        WIMARTS.REPORTS.PrintReports.ProductItemReport(ItemDetailsBLL.Report.IProduct, LineID, "Production Report", dtpFromDate.Value, dtpToDate.Value, this.MdiParent);
                    }
                    else if (cmbWise.SelectedIndex == 1)
                    {
                        WIMARTS.REPORTS.PrintReports.BatchItemReport(ItemDetailsBLL.Report.IBatch, LineID, "Production Report", dtpFromDate.Value, dtpToDate.Value, this.MdiParent);
                    }
                    else
                    { }
                    break;
                case ApplicationID.Dispatch:
                    LineID = cmbLineNo.SelectedIndex;
                    if (cmbWise.SelectedIndex == 0)
                    {
                        WIMARTS.REPORTS.PrintReports.ProductItemReport(ItemDetailsBLL.Report.DProduct, LineID, "Dispatch Report", dtpFromDate.Value, dtpToDate.Value, this.MdiParent);
                    }
                    else if (cmbWise.SelectedIndex == 1)
                    {
                        WIMARTS.REPORTS.PrintReports.BatchItemReport(ItemDetailsBLL.Report.DBatch, LineID, "Dispatch Report", dtpFromDate.Value, dtpToDate.Value, this.MdiParent);
                    }
                    else
                    { }
                    break;
            }
        }

        private void cmbApplication_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbApplication.SelectedIndex <= 0)
            {
                ControlsVisibility(pnlLines, false);
            }
            else
            {
                ControlsVisibility(pnlLines, true);
                if (cmbApplication.SelectedIndex == 1)
                {
                    AddItems(true);
                }
                else
                {
                    AddItems(false);
                }
            }
        }

        private void AddItems(bool IsProduction)
        {
            cmbLineNo.Items.Clear();
            cmbLineNo.Items.Add("All");
            if (IsProduction == true)
            {
                cmbLineNo.Items.Add("5 KG Pickle");
                cmbLineNo.Items.Add("Pickle and Spices");
                cmbLineNo.Items.Add("Jam, Ketchup, Tamarind and Sause");
                cmbLineNo.Items.Add("Inward (Musali and Dambhurni)");
             //   cmbLineNo.Items.Add("");
            }
            else
            {
                cmbLineNo.Items.Add("Dispatch Deck 1");
                cmbLineNo.Items.Add("Dispatch Deck 2");
                cmbLineNo.Items.Add("Dispatch Deck 3");
                cmbLineNo.Items.Add("Dispatch Deck 4");
            //    cmbLineNo.Items.Add("");            
            }
            cmbLineNo.SelectedIndex = 0;
        }

        private void ControlsVisibility(Control ctrl, bool isVisible)
        {
            if (ctrl.InvokeRequired == true)
            {
                ctrl.Invoke(new MethodInvoker(delegate { ControlsVisibility(ctrl, isVisible); }));
            }
            else
            {
                ctrl.Visible = isVisible;
            }
        }

        enum ApplicationID
        {
            Printing = 0,
            Production = 1,
            Dispatch = 2,
        }
        enum Wise
        {
            Batch = 0,
            Product = 1,
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            dtpToDate.MinDate = dtpFromDate.Value;
        }
    }
}