using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using WIMARTS.DB.BusinessObjects;

namespace WIMARTS.DB.DAL
{
    public partial class CompanyMasterDAO
    {
        public DataSet GetCompanyMastersDS()
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTCompanyMasters", CommandType.StoredProcedure);
                DbDataAdapter dataAdpt = DbProviderHelper.CreateDataAdapter(oDbCommand);
                ds = DbProviderHelper.FillDataSet(dataAdpt);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    public partial class ProductMasterDAO
    {
        public DataSet GetProductSummary()
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTProductSummary", CommandType.StoredProcedure);
                DbDataAdapter dataAdpt = DbProviderHelper.CreateDataAdapter(oDbCommand);
                ds = DbProviderHelper.FillDataSet(dataAdpt);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetProductDataset()
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTProductMasters", CommandType.StoredProcedure);
                DbDataAdapter dataAdpt = DbProviderHelper.CreateDataAdapter(oDbCommand);
                ds = DbProviderHelper.FillDataSet(dataAdpt);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetProductDetail(int ProdID)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTProductMaster", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@ProdID", DbType.Int32, ProdID));
                DbDataAdapter dataAdpt = DbProviderHelper.CreateDataAdapter(oDbCommand);
                ds = DbProviderHelper.FillDataSet(dataAdpt);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ProductMaster GetProductMaster(int Flag, string Value)
        {
            try
            {
                ProductMaster oProductMaster = new ProductMaster();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTProductMasterByValue", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Flag", DbType.Int32, Flag));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Value", DbType.String, Value));
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    oProductMaster.ProdID = Convert.ToInt32(oDbDataReader["ProdID"]);
                    oProductMaster.Code = Convert.ToString(oDbDataReader["Code"]);
                    oProductMaster.Name = Convert.ToString(oDbDataReader["Name"]);

                    if (oDbDataReader["Unit"] != DBNull.Value)
                        oProductMaster.Unit = Convert.ToString(oDbDataReader["Unit"]);

                    if (oDbDataReader["Category"] != DBNull.Value)
                        oProductMaster.Category = Convert.ToString(oDbDataReader["Category"]);
                    oProductMaster.MRP = Convert.ToDecimal(oDbDataReader["MRP"]);
                    oProductMaster.Packsize = Convert.ToInt32(oDbDataReader["Packsize"]);

                    if (oDbDataReader["NetWeight"] != DBNull.Value)
                        oProductMaster.NetWeight = Convert.ToDecimal(oDbDataReader["NetWeight"]);

                    if (oDbDataReader["GrossWeight"] != DBNull.Value)
                        oProductMaster.GrossWeight = Convert.ToDecimal(oDbDataReader["GrossWeight"]);

                    if (oDbDataReader["OldItemCode"] != DBNull.Value)
                        oProductMaster.OldItemCode = Convert.ToString(oDbDataReader["OldItemCode"]);

                    if (oDbDataReader["ProductGroup"] != DBNull.Value)
                        oProductMaster.ProductGroup = Convert.ToString(oDbDataReader["ProductGroup"]);

                    if (oDbDataReader["Status"] != DBNull.Value)
                        oProductMaster.Status = Convert.ToBoolean(oDbDataReader["Status"]);
                    oProductMaster.CreatedDate = Convert.ToDateTime(oDbDataReader["CreatedDate"]);
                    oProductMaster.LUDate = Convert.ToDateTime(oDbDataReader["LUDate"]);

                    if (oDbDataReader["Remarks"] != DBNull.Value)
                        oProductMaster.Remarks = Convert.ToString(oDbDataReader["Remarks"]);
                }
                oDbDataReader.Close();
                return oProductMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public partial class PrintMasterDAO
    {
        public DataSet GetPrintMastersDataset()
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTPrintMasters", CommandType.StoredProcedure);
                DbDataAdapter dataAdpt = DbProviderHelper.CreateDataAdapter(oDbCommand);
                ds = DbProviderHelper.FillDataSet(dataAdpt);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetPrintMasterDS(int PrintID)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTPrintMaster", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@PrintID", DbType.Int32, PrintID));
                DbDataAdapter dataAdpt = DbProviderHelper.CreateDataAdapter(oDbCommand);
                ds = DbProviderHelper.FillDataSet(dataAdpt);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetPrintMasterDS(int Flag, DateTime FromDate, DateTime ToDate, string ProdID)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTPrintMastersBtnDate", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Flag", DbType.Int32, Flag));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@FromDate", DbType.Date, FromDate));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@ToDate", DbType.Date, ToDate));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@ProdID", DbType.String, ProdID));
                DbDataAdapter dataAdpt = DbProviderHelper.CreateDataAdapter(oDbCommand);
                ds = DbProviderHelper.FillDataSet(dataAdpt);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetPrintMastersBtnDate(int Flag, DateTime FromDate, DateTime ToDate, string ProdID)
        {
            try
            {
                DataTable dt = new DataTable();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTPrintMastersBtnDate", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Flag", DbType.Int32, Flag));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@FromDate", DbType.Date, FromDate));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@ToDate", DbType.Date, ToDate));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@ProdID", DbType.String, ProdID));
                DbDataAdapter dataAdpt = DbProviderHelper.CreateDataAdapter(oDbCommand);
                dt = DbProviderHelper.FillDataTable(dataAdpt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<PrintMaster> GetPrintMasterTop5()
        {
            try
            {
                List<PrintMaster> lstPrintMasters = new List<PrintMaster>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTPrintMastersTop5", CommandType.StoredProcedure);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    PrintMaster oPrintMaster = new PrintMaster();
                    oPrintMaster.PrintID = Convert.ToInt32(oDbDataReader["PrintID"]);
                    oPrintMaster.ProdID = Convert.ToInt32(oDbDataReader["ProdID"]);
                    oPrintMaster.ProdCode = Convert.ToString(oDbDataReader["ProdCode"]);
                    oPrintMaster.ProdName = Convert.ToString(oDbDataReader["ProdName"]);
                    oPrintMaster.BatchName = Convert.ToString(oDbDataReader["BatchName"]);
                    oPrintMaster.MfgDate = Convert.ToDateTime(oDbDataReader["MfgDate"]);
                    oPrintMaster.MRP = Convert.ToDecimal(oDbDataReader["MRP"]);
                    oPrintMaster.TemplateName = Convert.ToString(oDbDataReader["TemplateName"]);
                    oPrintMaster.Template = Convert.ToString(oDbDataReader["Template"]);
                    oPrintMaster.Status = Convert.ToInt32(oDbDataReader["Status"]);

                    oPrintMaster.Quantity = Convert.ToDecimal(oDbDataReader["Quantity"]);

                    if (oDbDataReader["GoodQty"] != DBNull.Value)
                        oPrintMaster.GoodQty = Convert.ToDecimal(oDbDataReader["GoodQty"]);

                    if (oDbDataReader["BadQty"] != DBNull.Value)
                        oPrintMaster.BadQty = Convert.ToDecimal(oDbDataReader["BadQty"]);
                    oPrintMaster.CreatedDate = Convert.ToDateTime(oDbDataReader["CreatedDate"]);
                    oPrintMaster.LUDate = Convert.ToDateTime(oDbDataReader["LUDate"]);

                    if (oDbDataReader["Remarks"] != DBNull.Value)
                        oPrintMaster.Remarks = Convert.ToString(oDbDataReader["Remarks"]);
                    lstPrintMasters.Add(oPrintMaster);
                }
                oDbDataReader.Close();
                return lstPrintMasters;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateStatus(PrintMaster oPrintMaster)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("STATUSPrintMaster", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Status", DbType.Int32, oPrintMaster.Status));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@InspID", DbType.Int32, oPrintMaster.PrintID));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LUDate", DbType.DateTime, oPrintMaster.LUDate));
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateQuantity(PrintMaster oPrintMaster)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("UPDATEPrintMasterQty", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@GoodQty", DbType.Decimal, oPrintMaster.GoodQty));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@BadQty", DbType.Decimal, oPrintMaster.BadQty));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@PrintID", DbType.Int32, oPrintMaster.PrintID));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LUDate", DbType.DateTime, oPrintMaster.LUDate));
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public partial class InspectionMasterDAO
    {
        public DataSet GetInspectionMastersDataset()
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTInspectionMasters", CommandType.StoredProcedure);
                DbDataAdapter dataAdpt = DbProviderHelper.CreateDataAdapter(oDbCommand);
                ds = DbProviderHelper.FillDataSet(dataAdpt);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetInspectionMasterDS(int InspID)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTInspectionMaster", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@InspID", DbType.Int32, InspID));
                DbDataAdapter dataAdpt = DbProviderHelper.CreateDataAdapter(oDbCommand);
                ds = DbProviderHelper.FillDataSet(dataAdpt);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetInspectionMasterDS(DateTime FromDate, DateTime ToDate)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTInspectionMasterByDate", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@FromDate", DbType.Date, FromDate));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@ToDate", DbType.Date, ToDate));
                DbDataAdapter dataAdpt = DbProviderHelper.CreateDataAdapter(oDbCommand);
                ds = DbProviderHelper.FillDataSet(dataAdpt);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateStatus(InspectionMaster oInspectionMaster)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("STATUSInspectionMaster", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Status", DbType.Int32, oInspectionMaster.Status));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@InspID", DbType.Int32, oInspectionMaster.InspID));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LUDate", DbType.DateTime, oInspectionMaster.LUDate));
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateQuantity(InspectionMaster oInspectionMaster)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("UPDATEInspectionMasterQty", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@GoodQty", DbType.Decimal, oInspectionMaster.GoodQty));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@BadQty", DbType.Decimal, oInspectionMaster.BadQty));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@InspID", DbType.Int32, oInspectionMaster.InspID));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LUDate", DbType.DateTime, oInspectionMaster.LUDate));
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public partial class DispatchMasterDAO
    {
        public DataSet GetDispatchMDatasetByValue(int Flag, string Value)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTDispatchMastersByValue", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Flag", DbType.Int32, Flag));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Value", DbType.String, Value));
                DbDataAdapter dataAdpt = DbProviderHelper.CreateDataAdapter(oDbCommand);
                ds = DbProviderHelper.FillDataSet(dataAdpt);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DispatchMaster> GetDispatchListByValue(int Flag, string Value)
        {
            try
            {
                List<DispatchMaster> lstDispatchMasters = new List<DispatchMaster>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTDispatchMastersByValue", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Flag", DbType.Int32, Flag));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Value", DbType.String, Value));
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    DispatchMaster oDispatchMaster = new DispatchMaster();
                    oDispatchMaster.DispMasterID = Convert.ToInt32(oDbDataReader["DispMasterID"]);
                    oDispatchMaster.GDN = Convert.ToString(oDbDataReader["GDN"]);
                    oDispatchMaster.CustID = Convert.ToInt32(oDbDataReader["CustID"]);
                    if (oDbDataReader["TransporterID"] != DBNull.Value)
                        oDispatchMaster.TransporterID = Convert.ToInt32(oDbDataReader["TransporterID"]);
                    oDispatchMaster.VehicleNo = Convert.ToString(oDbDataReader["VehicleNo"]);
                    oDispatchMaster.DriverName = Convert.ToString(oDbDataReader["DriverName"]);
                    oDispatchMaster.LineID = Convert.ToInt32(oDbDataReader["LineID"]);
                    oDispatchMaster.DispType = Convert.ToInt32(oDbDataReader["DispType"]);
                    oDispatchMaster.Status = Convert.ToInt32(oDbDataReader["Status"]);
                    oDispatchMaster.Quantity = Convert.ToDecimal(oDbDataReader["Quantity"]);

                    if (oDbDataReader["GoodQty"] != DBNull.Value)
                        oDispatchMaster.GoodQty = Convert.ToDecimal(oDbDataReader["GoodQty"]);

                    if (oDbDataReader["BadQty"] != DBNull.Value)
                        oDispatchMaster.BadQty = Convert.ToDecimal(oDbDataReader["BadQty"]);

                    oDispatchMaster.DispatchDate = Convert.ToDateTime(oDbDataReader["DispatchDate"]);
                    oDispatchMaster.CreatedBy = Convert.ToInt32(oDbDataReader["CreatedBy"]);
                    oDispatchMaster.CreatedDate = Convert.ToDateTime(oDbDataReader["CreatedDate"]);

                    if (oDbDataReader["StartedAt"] != DBNull.Value)
                        oDispatchMaster.StartedAt = Convert.ToDateTime(oDbDataReader["StartedAt"]);
                    if (oDbDataReader["CompletedAt"] != DBNull.Value)
                        oDispatchMaster.CompletedAt = Convert.ToDateTime(oDbDataReader["CompletedAt"]);
                    oDispatchMaster.LUDate = Convert.ToDateTime(oDbDataReader["LUDate"]);

                    if (oDbDataReader["Remarks"] != DBNull.Value)
                        oDispatchMaster.Remarks = Convert.ToString(oDbDataReader["Remarks"]);

                    lstDispatchMasters.Add(oDispatchMaster);
                }
                oDbDataReader.Close();
                return lstDispatchMasters;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateStatus(DispatchMaster oDispatchMaster)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("STATUSDispatchMaster", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Status", DbType.Int32, oDispatchMaster.Status));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispMasterID", DbType.Int32, oDispatchMaster.DispMasterID));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LUDate", DbType.DateTime, oDispatchMaster.LUDate));
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateQuantity(DispatchMaster oDispatchMaster)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("UPDATEDispatchMasterQty", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@GoodQty", DbType.Decimal, oDispatchMaster.GoodQty));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@BadQty", DbType.Decimal, oDispatchMaster.BadQty));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispMasterID", DbType.Int32, oDispatchMaster.DispMasterID));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LUDate", DbType.DateTime, oDispatchMaster.LUDate));
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public partial class DispatchDetailsDAO
    {
        public DataSet GetDispatchDsDataset()
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTDispatchDetailss", CommandType.StoredProcedure);
                DbDataAdapter dataAdpt = DbProviderHelper.CreateDataAdapter(oDbCommand);
                ds = DbProviderHelper.FillDataSet(dataAdpt);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetDailyDispatch(DateTime FromDate, DateTime ToDate)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTItemDispatchByDate", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@FromDate", DbType.Date, FromDate));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@ToDate", DbType.Date, ToDate));
                DbDataAdapter dataAdpt = DbProviderHelper.CreateDataAdapter(oDbCommand);
                ds = DbProviderHelper.FillDataSet(dataAdpt);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetDispatchDetailsByDispMasterDS(int Flag, string DispMasterID)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTDispatchDetailsByDispMaster", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Flag", DbType.Int32, Flag));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispMasterID", DbType.String, DispMasterID));
                DbDataAdapter dataAdpt = DbProviderHelper.CreateDataAdapter(oDbCommand);
                ds = DbProviderHelper.FillDataSet(dataAdpt);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DispatchDetails> GetDispatchDetailsByDispMaster(int Flag, string DispMasterID)
        {
            try
            {
                List<DispatchDetails> lstDispatchDetailss = new List<DispatchDetails>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTDispatchDetailsByDispMaster", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Flag", DbType.Int32, Flag));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispMasterID", DbType.String, DispMasterID));
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    DispatchDetails oDispatchDetails = new DispatchDetails();
                    oDispatchDetails.DispDetailsID = Convert.ToInt32(oDbDataReader["DispDetailsID"]);
                    oDispatchDetails.DispMasterID = Convert.ToInt32(oDbDataReader["DispMasterID"]);
                    oDispatchDetails.ProdCode = Convert.ToString(oDbDataReader["ProdCode"]);
                    oDispatchDetails.QtytoDispatch = Convert.ToDecimal(oDbDataReader["QtytoDispatch"]);
                    oDispatchDetails.MaxQty = Convert.ToDecimal(oDbDataReader["MaxQty"]);
                    oDispatchDetails.MinQty = Convert.ToDecimal(oDbDataReader["MinQty"]);
                    oDispatchDetails.DispatchedQty = Convert.ToDecimal(oDbDataReader["DispatchedQty"]);
                    oDispatchDetails.CreatedDate = Convert.ToDateTime(oDbDataReader["CreatedDate"]);
                    oDispatchDetails.LUDate = Convert.ToDateTime(oDbDataReader["LUDate"]);

                    if (oDbDataReader["Remark"] != DBNull.Value)
                        oDispatchDetails.Remark = Convert.ToString(oDbDataReader["Remark"]);
                    lstDispatchDetailss.Add(oDispatchDetails);
                }
                oDbDataReader.Close();
                return lstDispatchDetailss;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DetailsDispatchDetails> GetDetailsDispatchDetailsByDispMaster(int Flag, string DispMasterID)
        {
            try
            {
                List<DetailsDispatchDetails> lstDispatchDetailss = new List<DetailsDispatchDetails>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTDispatchDetailsByDispMasterCSV", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Flag", DbType.Int32, Flag));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispMasterID", DbType.String, DispMasterID));
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    DetailsDispatchDetails oDispatchDetails = new DetailsDispatchDetails();
                    oDispatchDetails.ProductName = Convert.ToString(oDbDataReader["ProductName"]);

                    oDispatchDetails.ProdCode = Convert.ToString(oDbDataReader["ProdCode"]);
                    oDispatchDetails.QtytoDispatch = Convert.ToDecimal(oDbDataReader["QtytoDispatch"]);
                    oDispatchDetails.Packsize = Convert.ToDecimal(oDbDataReader["Packsize"]);
                    oDispatchDetails.DispatchedQty = Convert.ToDecimal(oDbDataReader["DispatchedQty"]);

                    lstDispatchDetailss.Add(oDispatchDetails);
                }
                oDbDataReader.Close();
                return lstDispatchDetailss;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CSVDispatchDetails> GetCSVDispatchDetailsByDispMaster(int Flag, string DispMasterID)
        {
            try
            {
                List<CSVDispatchDetails> lstDispatchDetailss = new List<CSVDispatchDetails>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTDispatchDetailsByDispMasterCSV", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Flag", DbType.Int32, Flag));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispMasterID", DbType.String, DispMasterID));
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    CSVDispatchDetails oDispatchDetails = new CSVDispatchDetails();
                    oDispatchDetails.ProductName = Convert.ToString(oDbDataReader["ProductName"]);
                    oDispatchDetails.ProductName = oDispatchDetails.ProductName;
                    oDispatchDetails.ProdCode = Convert.ToString(oDbDataReader["ProdCode"]);
                    oDispatchDetails.Packsize = Convert.ToDecimal(oDbDataReader["Packsize"]);
                    oDispatchDetails.ScanneddQty = Convert.ToDecimal(oDbDataReader["DispatchedQty"]);

                    lstDispatchDetailss.Add(oDispatchDetails);
                }
                oDbDataReader.Close();
                return lstDispatchDetailss;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateDispatchedQty(DispatchDetails oDispatchDetails)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("UPDATEDispatchDetailsDispatchedQty", CommandType.StoredProcedure);
                //    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispatchedQty", DbType.Decimal, oDispatchDetails.DispatchedQty));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispDetailsID", DbType.Int32, oDispatchDetails.DispDetailsID));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LUDate", DbType.DateTime, oDispatchDetails.LUDate));
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public partial class ItemDetailsDAO
    {
        public DataSet GetItemDetailsReport(int Flag, int LineID, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTItemDetailsReport", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Flag", DbType.Int32, Flag));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LineID", DbType.Int32, LineID));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@FromDate", DbType.Date, FromDate));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@ToDate", DbType.Date, ToDate));
                DbDataAdapter dataAdpt = DbProviderHelper.CreateDataAdapter(oDbCommand);
                ds = DbProviderHelper.FillDataSet(dataAdpt);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetItemDetailsDS(int Flag, int Status, string Value)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTItemDetailsByValue", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Flag", DbType.Int32, Flag));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Status", DbType.Int32, Status));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Value", DbType.String, Value));
                DbDataAdapter dataAdpt = DbProviderHelper.CreateDataAdapter(oDbCommand);
                ds = DbProviderHelper.FillDataSet(dataAdpt);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetItemDetailsQuantityDS(int Quantity, int Status, string Value)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTItemDetailsTop", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Quantity", DbType.Int32, Quantity));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Status", DbType.Int32, Status));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Value", DbType.String, Value));
                DbDataAdapter dataAdpt = DbProviderHelper.CreateDataAdapter(oDbCommand);
                ds = DbProviderHelper.FillDataSet(dataAdpt);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ItemDetails> GetItemDetailsQuantity(int Quantity, int Status, string Value)
        {
            try
            {
                List<ItemDetails> lstItemDetailss = new List<ItemDetails>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTItemDetailsTop", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Quantity", DbType.Int32, Quantity));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Status", DbType.Int32, Status));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Value", DbType.String, Value));
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    ItemDetails oItemDetails = new ItemDetails();
                    oItemDetails.DetailsID = Convert.ToInt32(oDbDataReader["DetailsID"]);
                    if (oDbDataReader["PrintID"] != DBNull.Value)
                        oItemDetails.PrintID = Convert.ToInt32(oDbDataReader["PrintID"]);

                    if (oDbDataReader["InspID"] != DBNull.Value)
                        oItemDetails.InspID = Convert.ToInt32(oDbDataReader["InspID"]);

                    if (oDbDataReader["DispID"] != DBNull.Value)
                        oItemDetails.DispID = Convert.ToInt32(oDbDataReader["DispID"]);
                    if (oDbDataReader["DispLineID"] != DBNull.Value)
                        oItemDetails.DispLineID = Convert.ToInt32(oDbDataReader["DispLineID"]);
                    oItemDetails.ProdCode = Convert.ToString(oDbDataReader["ProdCode"]);
                    oItemDetails.BatchCode = Convert.ToString(oDbDataReader["BatchCode"]);
                    oItemDetails.UIDCode = Convert.ToString(oDbDataReader["UIDCode"]);
                    oItemDetails.Status = Convert.ToInt32(oDbDataReader["Status"]);
                    oItemDetails.CreatedDate = Convert.ToDateTime(oDbDataReader["CreatedDate"]);

                    if (oDbDataReader["InspectedDate"] != DBNull.Value)
                        oItemDetails.InspectedDate = Convert.ToDateTime(oDbDataReader["InspectedDate"]);

                    if (oDbDataReader["DispatchedDate"] != DBNull.Value)
                        oItemDetails.DispatchedDate = Convert.ToDateTime(oDbDataReader["DispatchedDate"]);
                    oItemDetails.LUDate = Convert.ToDateTime(oDbDataReader["LUDate"]);
                    lstItemDetailss.Add(oItemDetails);
                }
                oDbDataReader.Close();
                return lstItemDetailss;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetItemDetailsDateDS(int Flag, int LineID, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTItemDetailsDates", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Flag", DbType.Int32, Flag));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LineID", DbType.Int32, LineID));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@FromDate", DbType.DateTime, FromDate));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@ToDate", DbType.DateTime, ToDate));
                DbDataAdapter dataAdpt = DbProviderHelper.CreateDataAdapter(oDbCommand);
                ds = DbProviderHelper.FillDataSet(dataAdpt);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ItemDetails> GetItemDetailss(int Flag, int Status, string Value)
        {
            try
            {
                List<ItemDetails> lstItemDetailss = new List<ItemDetails>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTItemDetailsByValue", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Flag", DbType.Int32, Flag));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Status", DbType.Int32, Status));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Value", DbType.String, Value));
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    ItemDetails oItemDetails = new ItemDetails();
                    oItemDetails.DetailsID = Convert.ToInt32(oDbDataReader["DetailsID"]);
                    if (oDbDataReader["PrintID"] != DBNull.Value)
                        oItemDetails.PrintID = Convert.ToInt32(oDbDataReader["PrintID"]);

                    if (oDbDataReader["InspID"] != DBNull.Value)
                        oItemDetails.InspID = Convert.ToInt32(oDbDataReader["InspID"]);

                    if (oDbDataReader["DispID"] != DBNull.Value)
                        oItemDetails.DispID = Convert.ToInt32(oDbDataReader["DispID"]);
                    if (oDbDataReader["DispLineID"] != DBNull.Value)
                        oItemDetails.DispLineID = Convert.ToInt32(oDbDataReader["DispLineID"]);
                    oItemDetails.ProdCode = Convert.ToString(oDbDataReader["ProdCode"]);
                    oItemDetails.BatchCode = Convert.ToString(oDbDataReader["BatchCode"]);
                    oItemDetails.UIDCode = Convert.ToString(oDbDataReader["UIDCode"]);
                    oItemDetails.Status = Convert.ToInt32(oDbDataReader["Status"]);
                    oItemDetails.CreatedDate = Convert.ToDateTime(oDbDataReader["CreatedDate"]);

                    if (oDbDataReader["InspectedDate"] != DBNull.Value)
                        oItemDetails.InspectedDate = Convert.ToDateTime(oDbDataReader["InspectedDate"]);

                    if (oDbDataReader["DispatchedDate"] != DBNull.Value)
                        oItemDetails.DispatchedDate = Convert.ToDateTime(oDbDataReader["DispatchedDate"]);
                    oItemDetails.LUDate = Convert.ToDateTime(oDbDataReader["LUDate"]);
                    lstItemDetailss.Add(oItemDetails);
                }
                oDbDataReader.Close();
                return lstItemDetailss;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CSVItemDetails> GetCSVItemDetailss(int Flag, int Status, string Value)
        {
            try
            {
                List<CSVItemDetails> lstCSVItemDetailss = new List<CSVItemDetails>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTItemDetailsByValueCSV", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Flag", DbType.Int32, Flag));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Status", DbType.Int32, Status));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Value", DbType.String, Value));
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    CSVItemDetails oCSVItemDetails = new CSVItemDetails();

                    oCSVItemDetails.ProdCode = Convert.ToString(oDbDataReader["ProdCode"]);
                    oCSVItemDetails.BatchCode = Convert.ToString(oDbDataReader["BatchCode"]);
                    oCSVItemDetails.UIDCode = Convert.ToString(oDbDataReader["UIDCode"]);
                    oCSVItemDetails.ProductName = Convert.ToString(oDbDataReader["ProductName"]);
                    oCSVItemDetails.Packsize = Convert.ToDecimal(oDbDataReader["Packsize"]);
                    if (oDbDataReader["DispatchedDate"] != DBNull.Value)
                        oCSVItemDetails.DispatchedDate = Convert.ToDateTime(oDbDataReader["DispatchedDate"]);

                    lstCSVItemDetailss.Add(oCSVItemDetails);
                }
                oDbDataReader.Close();
                return lstCSVItemDetailss;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ItemDetails GetItemDetails(int Flag, int Status, string Value)
        {
            try
            {
                ItemDetails oItemDetails = new ItemDetails();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTItemDetailsByValue", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Flag", DbType.Int32, Flag));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Status", DbType.Int32, Status));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Value", DbType.String, Value));
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    oItemDetails.DetailsID = Convert.ToInt32(oDbDataReader["DetailsID"]);
                    if (oDbDataReader["PrintID"] != DBNull.Value)
                        oItemDetails.PrintID = Convert.ToInt32(oDbDataReader["PrintID"]);

                    if (oDbDataReader["InspID"] != DBNull.Value)
                        oItemDetails.InspID = Convert.ToInt32(oDbDataReader["InspID"]);

                    if (oDbDataReader["DispID"] != DBNull.Value)
                        oItemDetails.DispID = Convert.ToInt32(oDbDataReader["DispID"]);
                    if (oDbDataReader["DispLineID"] != DBNull.Value)
                        oItemDetails.DispLineID = Convert.ToInt32(oDbDataReader["DispLineID"]);
                    oItemDetails.ProdCode = Convert.ToString(oDbDataReader["ProdCode"]);
                    oItemDetails.BatchCode = Convert.ToString(oDbDataReader["BatchCode"]);
                    oItemDetails.UIDCode = Convert.ToString(oDbDataReader["UIDCode"]);
                    oItemDetails.Status = Convert.ToInt32(oDbDataReader["Status"]);
                    oItemDetails.CreatedDate = Convert.ToDateTime(oDbDataReader["CreatedDate"]);

                    if (oDbDataReader["InspectedDate"] != DBNull.Value)
                        oItemDetails.InspectedDate = Convert.ToDateTime(oDbDataReader["InspectedDate"]);

                    if (oDbDataReader["DispatchedDate"] != DBNull.Value)
                        oItemDetails.DispatchedDate = Convert.ToDateTime(oDbDataReader["DispatchedDate"]);
                    oItemDetails.LUDate = Convert.ToDateTime(oDbDataReader["LUDate"]);
                }
                oDbDataReader.Close();
                return oItemDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ItemDetails GetItemDetails(int Flag, string UIDCode)
        {
            try
            {
                ItemDetails oItemDetails = new ItemDetails();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTItemDetailsByUID", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Flag", DbType.Int32, Flag));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@UIDCode", DbType.String, UIDCode));
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    oItemDetails.DetailsID = Convert.ToInt32(oDbDataReader["DetailsID"]);
                    if (oDbDataReader["PrintID"] != DBNull.Value)
                        oItemDetails.PrintID = Convert.ToInt32(oDbDataReader["PrintID"]);

                    if (oDbDataReader["InspID"] != DBNull.Value)
                        oItemDetails.InspID = Convert.ToInt32(oDbDataReader["InspID"]);

                    if (oDbDataReader["DispID"] != DBNull.Value)
                        oItemDetails.DispID = Convert.ToInt32(oDbDataReader["DispID"]);
                    if (oDbDataReader["DispLineID"] != DBNull.Value)
                        oItemDetails.DispLineID = Convert.ToInt32(oDbDataReader["DispLineID"]);
                    oItemDetails.ProdCode = Convert.ToString(oDbDataReader["ProdCode"]);
                    oItemDetails.BatchCode = Convert.ToString(oDbDataReader["BatchCode"]);
                    oItemDetails.UIDCode = Convert.ToString(oDbDataReader["UIDCode"]);
                    oItemDetails.Status = Convert.ToInt32(oDbDataReader["Status"]);
                    oItemDetails.CreatedDate = Convert.ToDateTime(oDbDataReader["CreatedDate"]);

                    if (oDbDataReader["InspectedDate"] != DBNull.Value)
                        oItemDetails.InspectedDate = Convert.ToDateTime(oDbDataReader["InspectedDate"]);

                    if (oDbDataReader["DispatchedDate"] != DBNull.Value)
                        oItemDetails.DispatchedDate = Convert.ToDateTime(oDbDataReader["DispatchedDate"]);
                    oItemDetails.LUDate = Convert.ToDateTime(oDbDataReader["LUDate"]);
                }
                oDbDataReader.Close();
                return oItemDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ItemDetails GetItemDetailsBtnDays(int Flag, int Days, string UIDCode)
        {
            try
            {
                ItemDetails oItemDetails = new ItemDetails();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTItemDetailsBtnDays", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Flag", DbType.Int32, Flag));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Days", DbType.Int32, Days));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@UIDCode", DbType.String, UIDCode));
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    oItemDetails.DetailsID = Convert.ToInt32(oDbDataReader["DetailsID"]);
                    if (oDbDataReader["PrintID"] != DBNull.Value)
                        oItemDetails.PrintID = Convert.ToInt32(oDbDataReader["PrintID"]);

                    if (oDbDataReader["InspID"] != DBNull.Value)
                        oItemDetails.InspID = Convert.ToInt32(oDbDataReader["InspID"]);

                    if (oDbDataReader["DispID"] != DBNull.Value)
                        oItemDetails.DispID = Convert.ToInt32(oDbDataReader["DispID"]);
                    if (oDbDataReader["DispLineID"] != DBNull.Value)
                        oItemDetails.DispLineID = Convert.ToInt32(oDbDataReader["DispLineID"]);
                    oItemDetails.ProdCode = Convert.ToString(oDbDataReader["ProdCode"]);
                    oItemDetails.BatchCode = Convert.ToString(oDbDataReader["BatchCode"]);
                    oItemDetails.UIDCode = Convert.ToString(oDbDataReader["UIDCode"]);
                    oItemDetails.Status = Convert.ToInt32(oDbDataReader["Status"]);
                    oItemDetails.CreatedDate = Convert.ToDateTime(oDbDataReader["CreatedDate"]);

                    if (oDbDataReader["InspectedDate"] != DBNull.Value)
                        oItemDetails.InspectedDate = Convert.ToDateTime(oDbDataReader["InspectedDate"]);

                    if (oDbDataReader["DispatchedDate"] != DBNull.Value)
                        oItemDetails.DispatchedDate = Convert.ToDateTime(oDbDataReader["DispatchedDate"]);
                    oItemDetails.LUDate = Convert.ToDateTime(oDbDataReader["LUDate"]);
                }
                oDbDataReader.Close();
                return oItemDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateInspectionStatus(ItemDetails oDetails)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("STATUSInspectionDetails", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@InspID", DbType.Int32, oDetails.InspID));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Status", DbType.Int32, oDetails.Status));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@UIDCode", DbType.String, oDetails.UIDCode));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@InspectedDate", DbType.DateTime, oDetails.InspectedDate));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LUDate", DbType.DateTime, oDetails.LUDate));
                oDbCommand.CommandTimeout = 60;
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateDispatchStatus(ItemDetails oDetails)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("STATUSDispatchDetails", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispID", DbType.Int32, oDetails.DispID));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispLineID", DbType.Int32, oDetails.DispLineID));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Status", DbType.Int32, oDetails.Status));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@UIDCode", DbType.String, oDetails.UIDCode));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispatchedDate", DbType.DateTime, oDetails.DispatchedDate));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LUDate", DbType.DateTime, oDetails.LUDate));
                oDbCommand.CommandTimeout = 60;
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<string> GetItemDetailsUIDs(int Flag, int Status, string Value)
        {
            try
            {
                List<string> lstItemDetailsUIDs = new List<string>();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTItemDetailsByValue", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Flag", DbType.Int32, Flag));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Status", DbType.Int32, Status));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Value", DbType.String, Value));
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    string UIDCode = Convert.ToString(oDbDataReader["UIDCode"]);
                    if (string.IsNullOrEmpty(UIDCode) == false)
                        lstItemDetailsUIDs.Add(UIDCode);
                }
                oDbDataReader.Close();
                return lstItemDetailsUIDs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet GetItemDetailsDateDSCount(int Flag, int LineID, DateTime FromDate, DateTime ToDate)
        {

            try
            {
                DataSet ds = new DataSet();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTItemDetailsDatesCount", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Flag", DbType.Int32, Flag));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LineID", DbType.Int32, LineID));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@FromDate", DbType.DateTime, FromDate));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@ToDate", DbType.DateTime, ToDate));
                DbDataAdapter dataAdpt = DbProviderHelper.CreateDataAdapter(oDbCommand);
                ds = DbProviderHelper.FillDataSet(dataAdpt);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetItemDetailsReportCount(int Flag, int LineID, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                DataSet ds = new DataSet();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTItemDetailsReportCount", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Flag", DbType.Int32, Flag));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LineID", DbType.Int32, LineID));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@FromDate", DbType.Date, FromDate));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@ToDate", DbType.Date, ToDate));
                DbDataAdapter dataAdpt = DbProviderHelper.CreateDataAdapter(oDbCommand);
                ds = DbProviderHelper.FillDataSet(dataAdpt);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public partial class RoleMasterDAO
    {

    }

    public partial class TemplateDesignsDAO
    {

    }

    public partial class UserMasterDAO
    {
        public UserMaster UserSignIn(int UserID, String Password)
        {
            try
            {
                UserMaster oUserMaster = new UserMaster();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECT [UserID],[Name],[Password],[RoleID],[Active],[LastUpdatedDate],[LastUpdatedBy] FROM [UserMaster] WHERE [UserID]=@UserID AND [Password]=@Password", CommandType.Text);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@UserID", DbType.Int32, UserID));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Password", DbType.String, Password));
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    oUserMaster.UserID = Convert.ToInt32(oDbDataReader["UserID"]);
                    oUserMaster.Name = Convert.ToString(oDbDataReader["Name"]);
                    oUserMaster.Password = Convert.ToString(oDbDataReader["Password"]);
                    oUserMaster.RoleID = Convert.ToInt32(oDbDataReader["RoleID"]);
                    oUserMaster.Active = Convert.ToBoolean(oDbDataReader["Active"]);

                    if (oDbDataReader["LastUpdatedDate"] != DBNull.Value)
                        oUserMaster.LastUpdatedDate = Convert.ToDateTime(oDbDataReader["LastUpdatedDate"]);

                    if (oDbDataReader["LastUpdatedBy"] != DBNull.Value)
                        oUserMaster.LastUpdatedBy = Convert.ToInt32(oDbDataReader["LastUpdatedBy"]);
                }
                oDbDataReader.Close();
                return oUserMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}