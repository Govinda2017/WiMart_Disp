using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RedRapidUI;
using iPRINT.DB.BLL;
using iPRINT.DB.BusinessObjects;
using iPRINT.UTIL;

namespace iPRINT.COMMON
{
    public partial class FrmProductMasterRegular : Form
    {
        BLLManager bllMgr;
        #region FORM EVENTS

        public FrmProductMasterRegular()
        {
            InitializeComponent();
            InitializeRADUI();
        }

        private void FrmProductMasterRegular_Load(object sender, EventArgs e)
        {
            LoadDBData();
            redCRUDAS1.ButtonsSkipped =RedCRUDAS.eCRUDASButtons.DELETE | RedCRUDAS.eCRUDASButtons.CUSTB1 | RedCRUDAS.eCRUDASButtons.CUSTB2 | RedCRUDAS.eCRUDASButtons.CUSTB3 | RedCRUDAS.eCRUDASButtons.CUSTB4 | RedCRUDAS.eCRUDASButtons.CUSTB5 | RedCRUDAS.eCRUDASButtons.CUSTB6;
            redCRUDAS1.TrackChange = false;
            redCRUDAS1.RADUI_State = RedCRUDAS.eCRUDASState.Find;
        }
        private void FrmProductMasterRegular_Shown(object sender, EventArgs e)
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
                case RedCRUDAS.tagCUSTB1:
                   // result = DisplayReport();
                    break;
                case RedCRUDAS.tagCUSTB2:
                    // result = DisplayReport();
                    break;
                case RedCRUDAS.tagCUSTB3:
                    //result = DisplayReport();
                    break;
                case RedCRUDAS.tagCLOSE:
                    this.Close();
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
        private ProductMaster m_dbBusObj;
        private void InitializeRADUI()
        {
            bllMgr = new BLLManager();
            redGridControl1.dbBindingSrc.DataSource = typeof(ProductMaster);
            redGridControl1.dgMainData_OnClick += new RedGridControl.GridControl_ClickHandler(GridControl_Clicked);
            redCRUDAS1.CRUDAS_Click += new RedCRUDAS.CRUDAS_ClickHandler(redCRUDAS1_Clicked);
            redCRUDAS1.RADUI_DataPanel = PAN_RecordInfo;
            redCRUDAS1.RADUI_DataGridView = redGridControl1;
            //redCRUDAS1.ButtonsSkipped = RedCRUDAS.eCRUDASButtons._NONE;
            SetupDBnUILink();
        }
        private void SetupDBnUILink()
        {
            redGridControl1.SetBindingTXT(txtProductCode, () => m_dbBusObj.Code);
            redGridControl1.SetBindingTXT(txtProductName, () => m_dbBusObj.Name);
            redGridControl1.SetBindingTXT(txtUnit, () => m_dbBusObj.Unit);
            redGridControl1.SetBindingTXT(txtCategory, () => m_dbBusObj.Category);
            redGridControl1.SetBindingNUM(nmMRP, () => m_dbBusObj.MRP);
            redGridControl1.SetBindingNUM(nmNetWeight, () => m_dbBusObj.NetWeight);
            redGridControl1.SetBindingNUM(nmPackSize, () => m_dbBusObj.Packsize);
            redGridControl1.SetBindingNUM(nmGrossWeight, () => m_dbBusObj.GrossWeight);
            redGridControl1.SetBindingTXT(txtOldItemCode, () => m_dbBusObj.OldItemCode);
            redGridControl1.SetBindingTXT(txtProdGrp, () => m_dbBusObj.ProductGroup);
            redGridControl1.SetBindingTXT(txtRemark, () => m_dbBusObj.Remarks);
        }
        private void LoadDBData()
        {
            List <ProductMaster> lstProduct = bllMgr.ProductMasterBLL.GetProductMasters();
            try
            {
                int i = 1;
                DataTable dt = new DataTable();
                DataRow dr;
                dt.Columns.Add("ProductID");
                dt.Columns.Add("Name");
                dt.Columns.Add("Code");
                foreach (ProductMaster Product in lstProduct)
                {
                    dr = dt.NewRow();
                    dr[0] = Product.ProdID;
                    dr[1] = Product.Name;
                    dr[2] = Product.Code;
                    dt.Rows.Add(dr);
                    i++;
                }
                redGridControl1.LoadGridData(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool NewRecord()
        {
            m_dbBusObj = new ProductMaster();
            redGridControl1.dbBindingSrc.Clear();
            redGridControl1.dbBindingSrc.Add(m_dbBusObj);
            m_dbBusObj.CreatedDate = DateTime.Now;
            m_dbBusObj.LUDate = DateTime.Now;
            return true;
        }
        private bool EditRecord()
        {
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
                            bllMgr.ProductMasterBLL.AddProductMaster(m_dbBusObj);
                            Msg4User = "Record Added Successfully";
                            break;
                        case RedRapidUI.RedCRUDAS.eCRUDASState.Edit:
                            m_dbBusObj.LUDate = DateTime.Now;
                            bllMgr.ProductMasterBLL.UpdateProductMaster(m_dbBusObj);
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
                RedMessageBox.Show("Duplicate Product Code, Check and Re-enter Product Code", this.Text, RedMessageBox.RedMessageBoxButtons.OK, 0);                 
            }
            return flag;
        }
        private bool ValidateData()
        {
            try
            {
                // Validation of data Input for Saving...
                //Check For ProdCode
                if (txtProductCode.Text.Trim() == "") { RedMessageBox.Show("Please Enter Product Code", this.Text, RedMessageBox.RedMessageBoxButtons.OK, 0); txtProductCode.Focus(); return false; }
                if (txtProductName.Text.Trim() == "") { RedMessageBox.Show("Please Enter Product Name", this.Text, RedMessageBox.RedMessageBoxButtons.OK, 0); txtProductName.Focus(); return false; }
                ProductMaster oProduct = bllMgr.ProductMasterBLL.GetProductMaster(ProductMasterBLL.Flag.Code, txtProductCode.Text);
                if (oProduct != null && oProduct.ProdID > 0)
                {                   
                    RedMessageBox.Show("Duplicate Product Code, Check and Re-enter Product Code", this.Text, RedMessageBox.RedMessageBoxButtons.OK, 0);
                    txtProductCode.Focus();
                    return false;
                }
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
                m_dbBusObj.ProdID = redGridControl1.GetGridVal(0, curSelectedRow);

                if (MessageBox.Show("Are you sure to delete selected record?", this.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (m_dbBusObj != null)
                    {
                        bllMgr.ProductMasterBLL.RemoveProductMaster(m_dbBusObj);
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
                redGridControl1.dbBindingSrc.Remove(m_dbBusObj);
                m_dbBusObj = bllMgr.ProductMasterBLL.GetProductMaster(redGridControl1.GetGridVal(0, recordNum));
                redGridControl1.dbBindingSrc.Add(m_dbBusObj);
                return true;
            }
            return false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        //private RptDataset GetRptDS()
        //{
        //    RptDataset rptDS = new RptDataset();
        //    System.Data.DataSet ds1 = redGridControl1.bllMgr.ProductMasterBLL.GetCustDetail();
        //    if (ds1 != null)
        //    {
        //        rptDS.CustDT.Merge(ds1.Tables[0]);
        //    }
        //    return rptDS;
        //}
        //private bool DisplayReport()
        //{
        //    ReportCity rpt = new ReportCity();
        //    FrmReport cryViewer = new FrmReport();
        //    RptDataset ds = GetRptDS();
        //    rpt.SetDataSource(ds);
        //    cryViewer.crystalReportViewer1.ReportSource = rpt;
        //    cryViewer.MdiParent = this.MdiParent;
        //    cryViewer.Show();
        //    return true;
        //}
        #endregion DB & CONTROL OPERATIONS
    }
}
