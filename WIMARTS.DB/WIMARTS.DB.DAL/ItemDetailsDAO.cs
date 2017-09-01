using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using WIMARTS.DB.BusinessObjects;

namespace WIMARTS.DB.DAL
{
    public partial class ItemDetailsDAO
    {
        public ItemDetailsDAO()
        {
            DbProviderHelper.GetConnection();
        }
        public List<ItemDetails> GetItemDetailss()
        {
            try
            {
                List<ItemDetails> lstItemDetailss = new List<ItemDetails>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTItemDetailss", CommandType.StoredProcedure);
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
        public ItemDetails GetItemDetails(int DetailsID)
        {
            try
            {
                ItemDetails oItemDetails = new ItemDetails();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTItemDetails", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DetailsID", DbType.Int32, DetailsID));
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
        public int AddItemDetails(ItemDetails oItemDetails)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("INSERTItemDetails", CommandType.StoredProcedure);
                if (oItemDetails.PrintID.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@PrintID", DbType.Int32, oItemDetails.PrintID));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@PrintID", DbType.Int32, DBNull.Value));
                if (oItemDetails.InspID.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@InspID", DbType.Int32, oItemDetails.InspID));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@InspID", DbType.Int32, DBNull.Value));
                if (oItemDetails.DispID.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispID", DbType.Int32, oItemDetails.DispID));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispID", DbType.Int32, DBNull.Value));
                if (oItemDetails.DispLineID.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispLineID", DbType.Int32, oItemDetails.DispLineID));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispLineID", DbType.Int32, DBNull.Value));

                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@ProdCode", DbType.String, oItemDetails.ProdCode));
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@BatchCode", DbType.String, oItemDetails.BatchCode));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@UIDCode", DbType.String, oItemDetails.UIDCode));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Status", DbType.Int32, oItemDetails.Status));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CreatedDate", DbType.DateTime, oItemDetails.CreatedDate));
                if (oItemDetails.InspectedDate.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@InspectedDate", DbType.DateTime, oItemDetails.InspectedDate));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@InspectedDate", DbType.DateTime, DBNull.Value));
                if (oItemDetails.DispatchedDate.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispatchedDate", DbType.DateTime, oItemDetails.DispatchedDate));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispatchedDate", DbType.DateTime, DBNull.Value));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LUDate", DbType.DateTime, oItemDetails.LUDate));

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateItemDetails(ItemDetails oItemDetails)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("UPDATEItemDetails", CommandType.StoredProcedure);
                if (oItemDetails.PrintID.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@PrintID", DbType.Int32, oItemDetails.PrintID));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@PrintID", DbType.Int32, DBNull.Value));
                if (oItemDetails.InspID.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@InspID", DbType.Int32, oItemDetails.InspID));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@InspID", DbType.Int32, DBNull.Value));
                if (oItemDetails.DispID.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispID", DbType.Int32, oItemDetails.DispID));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispID", DbType.Int32, DBNull.Value));
                if (oItemDetails.DispLineID.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispLineID", DbType.Int32, oItemDetails.DispLineID));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispLineID", DbType.Int32, DBNull.Value));
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@ProdCode", DbType.String, oItemDetails.ProdCode));
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@BatchCode", DbType.String, oItemDetails.BatchCode));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@UIDCode", DbType.String, oItemDetails.UIDCode));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Status", DbType.Int32, oItemDetails.Status));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CreatedDate", DbType.DateTime, oItemDetails.CreatedDate));
                if (oItemDetails.InspectedDate.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@InspectedDate", DbType.DateTime, oItemDetails.InspectedDate));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@InspectedDate", DbType.DateTime, DBNull.Value));
                if (oItemDetails.DispatchedDate.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispatchedDate", DbType.DateTime, oItemDetails.DispatchedDate));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispatchedDate", DbType.DateTime, DBNull.Value));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LUDate", DbType.DateTime, oItemDetails.LUDate));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DetailsID", DbType.Int32, oItemDetails.DetailsID));
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int RemoveItemDetails(ItemDetails oItemDetails)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("DELETEItemDetails", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DetailsID", DbType.Int32, oItemDetails.DetailsID));
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int RemoveItemDetails(int DetailsID)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("DELETEItemDetails", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DetailsID", DbType.Int32, DetailsID));
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PrintMaster GetPrintMasterOfItemDetails(int PrintID)
        {
            try
            {
                PrintMaster oPrintMaster = new PrintMaster();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTPrintMaster", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@PrintID", DbType.Int32, PrintID));
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
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
                }
                oDbDataReader.Close();
                return oPrintMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public InspectionMaster GetInspectionMasterOfItemDetails(int InspID)
        {
            try
            {
                InspectionMaster oInspectionMaster = new InspectionMaster();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTInspectionMaster", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@InspID", DbType.Int32, InspID));
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    oInspectionMaster.InspID = Convert.ToInt32(oDbDataReader["InspID"]);
                    oInspectionMaster.BatchName = Convert.ToString(oDbDataReader["BatchName"]);
                    oInspectionMaster.LineID = Convert.ToInt32(oDbDataReader["LineID"]);
                    oInspectionMaster.Status = Convert.ToInt32(oDbDataReader["Status"]);

                    if (oDbDataReader["GoodQty"] != DBNull.Value)
                        oInspectionMaster.GoodQty = Convert.ToDecimal(oDbDataReader["GoodQty"]);

                    if (oDbDataReader["BadQty"] != DBNull.Value)
                        oInspectionMaster.BadQty = Convert.ToDecimal(oDbDataReader["BadQty"]);
                    oInspectionMaster.CreatedDate = Convert.ToDateTime(oDbDataReader["CreatedDate"]);
                    oInspectionMaster.LUDate = Convert.ToDateTime(oDbDataReader["LUDate"]);

                    if (oDbDataReader["Remark"] != DBNull.Value)
                        oInspectionMaster.Remark = Convert.ToString(oDbDataReader["Remark"]);
                }
                oDbDataReader.Close();
                return oInspectionMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DispatchMaster GetDispatchMasterOfItemDetails(int DispMasterID)
        {
            try
            {
                DispatchMaster oDispatchMaster = new DispatchMaster();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTDispatchMaster", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispMasterID", DbType.Int32, DispMasterID));
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    oDispatchMaster.DispMasterID = Convert.ToInt32(oDbDataReader["DispMasterID"]);
                    oDispatchMaster.GDN = Convert.ToString(oDbDataReader["GDN"]);
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
                    oDispatchMaster.CreatedBy = Convert.ToInt32(oDbDataReader["CreatedBy"]);
                    oDispatchMaster.CreatedDate = Convert.ToDateTime(oDbDataReader["CreatedDate"]);
                    oDispatchMaster.LUDate = Convert.ToDateTime(oDbDataReader["LUDate"]);

                    if (oDbDataReader["Remarks"] != DBNull.Value)
                        oDispatchMaster.Remarks = Convert.ToString(oDbDataReader["Remarks"]);
                }
                oDbDataReader.Close();
                return oDispatchMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
