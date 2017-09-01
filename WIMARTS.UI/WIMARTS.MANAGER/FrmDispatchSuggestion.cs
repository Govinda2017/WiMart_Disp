using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPRINT.DB.BLL;
using iPRINT.DB.BusinessObjects;

namespace iPRINT.MANAGER
{
    public partial class FrmDispatchSuggestion : Form
    {
        #region Properties

        private BLLManager bllMgr;
        private UserMaster curUserLogged;

        #endregion Properties

        #region FormEvents

        public FrmDispatchSuggestion(UserMaster oUser)
        {
            InitializeComponent();
            curUserLogged = oUser;
            bllMgr = new BLLManager();
        }

        private void FrmDispatchSuggestion_Load(object sender, EventArgs e)
        {

        }

        private void FrmDispatchSuggestion_Shown(object sender, EventArgs e)
        {
            LoadDbData();
        }

        private void FrmDispatchSuggestion_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        #endregion FormEvents

        #region LoadData

        private void LoadDbData()
        {
            //chlstDispatchMaster.DataSource = bllMgr.DispatchMasterBLL.GetDispatchMasterByDates(BLLManager.MasterStatus.All, DateTime.Now);
            //chlstDispatchMaster.DisplayMember = "GDN";
            //chlstDispatchMaster.ValueMember = "DispMasterID";
            //dgvDispDate.DataSource = GetDispDate();           
        }

        private DataTable GetDispDate()
        {
            DataTable dt = new DataTable();
            //dt.Columns.Add("Date");
            //List<DispatchMaster> lstDispMaster = bllMgr.DispatchMasterBLL.GetDispatchDates(BLLManager.MasterStatus.All);           
            //foreach (DispatchMaster item in lstDispMaster)
            //{
            //DataRow    dr = dt.NewRow();
            //    dr["Date"] = item.DispatchDate;
            //    dt.Rows.Add(dr);
            //}
            return dt;
        }

        private DataTable GetDispMaster()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("GDN");
            dt.Columns.Add("Date");
            List<DispatchMaster> lstDispMaster = new List<DispatchMaster>();// bllMgr.DispatchMasterBLL.GetDispatchMasterByDates(BLLManager.MasterStatus.All, DateTime.Now);
            //DataRow dr = dt.NewRow();
            //dr["ID"] = -1;
            //dr["GDN"] = "All";
            //dr["Date"] = null;
            //dt.Rows.Add(dr);
            foreach (DispatchMaster item in lstDispMaster)
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = item.DispMasterID;
                dr["GDN"] = item.GDN;
                dr["Date"] = item.DispatchDate;
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private DataTable GetDispDetails(string DispMasterID)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Product");
            dt.Columns.Add("Quantity");
            List<DispatchDetails> lstDispMaster = bllMgr.DispatchDetailsBLL.GetDispatchDetailsByDispMaster(DispatchDetailsBLL.Flag.MultiMaster, DispMasterID);
            DataRow dr = dt.NewRow();
            dr["Product"] = "All";
            dr["Quantity"] = null;
            dt.Rows.Add(dr);
            foreach (DispatchDetails item in lstDispMaster)
            {
                dr = dt.NewRow();
                dr["Product"] = item.ProdCode;
                dr["Quantity"] = item.QtytoDispatch;
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private DataTable GetItemDetails()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Product");
            dt.Columns.Add("BatchCode");
            dt.Columns.Add("UIDCode");
            List<ItemDetails> lstDispMaster = new List<ItemDetails>();
            foreach (DataGridViewRow item in dgvDispDetails.Rows)
            {
         //       lstDispMaster.AddRange(bllMgr.ItemDetailsBLL.GetItemDetailsByValue(ItemDetailsBLL.FLag.ProdCodenStatus, BLLManager.DetailsStatus.Scanned, "FG-0001"));  
            }
                   
            foreach (ItemDetails item in lstDispMaster)
            {
                DataRow dr = dt.NewRow();
                dr["Product"] = item.ProdCode;
                dr["BatchCode"] = item.BatchCode;
                dr["UIDCode"] = item.UIDCode;
                dt.Rows.Add(dr);
            }
            return dt;
        }

        #endregion LoadData

      
        private void dgvDispDetails_SelectionChanged(object sender, EventArgs e)
        {
            dgvItemDetails.DataSource = GetItemDetails();   
        }

        private void dgvDispDate_SelectionChanged(object sender, EventArgs e)
        {
            //dgvDispMaster.DataSource = GetDispMaster();
            //if (dgvDispDate.SelectedRows.Count > 0)
            //{
            //    int Val = Convert.ToInt32(dgvDispDate.SelectedRows[0].Cells[0].Value);
            //    string strID = string.Empty;
            //    if (Val == -1)
            //    {
            //        foreach (DataGridViewRow item in dgvDispMaster.Rows)
            //        {
            //            strID += Convert.ToString(item.Cells[0].Value) + ",";
            //        }
            //      //  dgvDispMaster.DataSource = GetDispMaster(strID);
            //    }
            //    else
            //        dgvDispMaster.DataSource = GetDispDetails(Convert.ToString(Val));
            //}
        }

        private void dgvDispMaster_SelectionChanged(object sender, EventArgs e)
        {
            //if (dgvDispMaster.SelectedRows.Count > 0)
            //{
            //    int Val = Convert.ToInt32(dgvDispMaster.SelectedRows[0].Cells[0].Value);
            //    string strID = string.Empty;
            //    if (Val == -1)
            //    {
            //        foreach (DataGridViewRow item in dgvDispMaster.Rows)
            //        {
            //            strID += Convert.ToString(item.Cells[0].Value) + ",";
            //        }
            //        dgvDispDetails.DataSource = GetDispDetails(strID);
            //    }
            //    else
            //        dgvDispDetails.DataSource = GetDispDetails(Convert.ToString(Val));
            //}
            
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            dgvDispDetails.DataSource = GetDispDetails(GetCheckedItems());
        }

        private string GetCheckedItems()
        {
            String Dispidlist = "";
            foreach (DispatchMaster oDisp in chlstDispatchMaster.CheckedItems)
                Dispidlist += oDisp.DispMasterID + ",";
            return Dispidlist;
        }
    }
}
