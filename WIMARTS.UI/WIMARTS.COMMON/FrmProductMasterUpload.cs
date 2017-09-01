using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using iPRINT.DB.BLL;
using iPRINT.DB.BusinessObjects;
using System.Diagnostics;

namespace iPRINT.COMMON
{
    public partial class FrmProductMasterUpload : Form
    {
        BLLManager bllMgr;
        public FrmProductMasterUpload()
        {
            InitializeComponent();
            bllMgr = new BLLManager();
        }
   
        private void btnUpload_Click(object sender, EventArgs e)
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
                openDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                openDialog.FilterIndex = 1;
                openDialog.RestoreDirectory = true;
                if (openDialog.ShowDialog() == DialogResult.OK && string.IsNullOrEmpty(openDialog.FileName) == false)
                    strExcelPathName = openDialog.FileName;

                if (string.IsNullOrEmpty(strExcelPathName) == false)
                {
                    int worksheetNumber = 1;

                    FileInfo fl = new FileInfo(strExcelPathName);
                    if (fl.Extension.ToUpper() == ".XLSX")
                        cnn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + strExcelPathName + ";" + "Extended Properties='Excel 12.0 xml;HDR=NO;IMEX=1';");
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
                    cnn.Close();
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
                foreach (DataRow dataRow in dtList.Rows)
                {
                    if (rowID == 1)
                    {
                        rowID++; continue;
                    }
                    ProductMaster oProd = new ProductMaster();
                    oProd.Code = Convert.ToString(dataRow["F1"]);
                    oProd.Name = Convert.ToString(dataRow["F2"]);
                    oProd.Unit = Convert.ToString(dataRow["F3"]);
                    oProd.Category = Convert.ToString(dataRow["F4"]);
                    oProd.MRP = Convert.ToDecimal(dataRow["F6"]);
                    oProd.Packsize = Convert.ToInt32(dataRow["F7"]);
                    oProd.OldItemCode = Convert.ToString(dataRow["F8"]);
                    oProd.Status = Convert.ToBoolean(dataRow["F9"]);
                    oProd.ProductGroup = Convert.ToString(dataRow["F13"]);

                    oProd.CreatedDate = oProd.LUDate = DateTime.Now;
                    AddProducts(oProd);
                    rowID++;
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}:{1},{2}", DateTime.Now, ex.Message, ex.StackTrace);
            }
        }

        private void AddProducts(ProductMaster oProduct)
        {
            try
            {              
                if (oProduct != null)
                {
                    bllMgr.ProductMasterBLL.AddProductMaster(oProduct);
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
