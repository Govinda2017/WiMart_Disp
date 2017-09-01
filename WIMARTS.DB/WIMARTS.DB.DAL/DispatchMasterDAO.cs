using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using WIMARTS.DB.BusinessObjects;

namespace WIMARTS.DB.DAL
{
    public partial class DispatchMasterDAO
    {
        public DispatchMasterDAO()
        {
            DbProviderHelper.GetConnection();
        }
        public List<DispatchMaster> GetDispatchMasters(int Flag)
        {
            try
            {
                List<DispatchMaster> lstDispatchMasters = new List<DispatchMaster>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTDispatchMasters", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Flag", DbType.Int32, Flag));
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
        public DispatchMaster GetDispatchMaster(int DispMasterID)
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
                }
                oDbDataReader.Close();
                return oDispatchMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int AddDispatchMaster(DispatchMaster oDispatchMaster)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("INSERTDispatchMaster", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@GDN", DbType.String, oDispatchMaster.GDN));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CustID", DbType.Int32, oDispatchMaster.CustID));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@VehicleNo", DbType.String, oDispatchMaster.VehicleNo));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DriverName", DbType.String, oDispatchMaster.DriverName));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LineID", DbType.Int32, oDispatchMaster.LineID));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispType", DbType.Int32, oDispatchMaster.DispType));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Status", DbType.Int32, oDispatchMaster.Status));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Quantity", DbType.Decimal, oDispatchMaster.Quantity));

                if (oDispatchMaster.TransporterID.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@TransporterID", DbType.Int32, oDispatchMaster.TransporterID));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@TransporterID", DbType.Int32, DBNull.Value));

                if (oDispatchMaster.GoodQty.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@GoodQty", DbType.Decimal, oDispatchMaster.GoodQty));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@GoodQty", DbType.Decimal, DBNull.Value));
                if (oDispatchMaster.BadQty.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@BadQty", DbType.Decimal, oDispatchMaster.BadQty));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@BadQty", DbType.Decimal, DBNull.Value));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispatchDate", DbType.Date, oDispatchMaster.DispatchDate));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CreatedBy", DbType.Int32, oDispatchMaster.CreatedBy));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CreatedDate", DbType.DateTime, oDispatchMaster.CreatedDate));
                if (oDispatchMaster.StartedAt.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@StartedAt", DbType.DateTime, oDispatchMaster.StartedAt));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@StartedAt", DbType.DateTime, DBNull.Value));
                if (oDispatchMaster.CompletedAt.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CompletedAt", DbType.DateTime, oDispatchMaster.CompletedAt));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CompletedAt", DbType.DateTime, DBNull.Value));

                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LUDate", DbType.DateTime, oDispatchMaster.LUDate));
                if (oDispatchMaster.Remarks != null)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Remarks", DbType.String, oDispatchMaster.Remarks));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Remarks", DbType.String, DBNull.Value));

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateDispatchMaster(DispatchMaster oDispatchMaster)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("UPDATEDispatchMaster", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@GDN", DbType.String, oDispatchMaster.GDN));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CustID", DbType.Int32, oDispatchMaster.CustID));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@VehicleNo", DbType.String, oDispatchMaster.VehicleNo));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DriverName", DbType.String, oDispatchMaster.DriverName));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LineID", DbType.Int32, oDispatchMaster.LineID));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispType", DbType.Int32, oDispatchMaster.DispType));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Status", DbType.Int32, oDispatchMaster.Status));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Quantity", DbType.Decimal, oDispatchMaster.Quantity));
                if (oDispatchMaster.TransporterID.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@TransporterID", DbType.Int32, oDispatchMaster.TransporterID));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@TransporterID", DbType.Int32, DBNull.Value));
                if (oDispatchMaster.GoodQty.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@GoodQty", DbType.Decimal, oDispatchMaster.GoodQty));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@GoodQty", DbType.Decimal, DBNull.Value));
                if (oDispatchMaster.BadQty.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@BadQty", DbType.Decimal, oDispatchMaster.BadQty));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@BadQty", DbType.Decimal, DBNull.Value));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispatchDate", DbType.Date, oDispatchMaster.DispatchDate));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CreatedBy", DbType.Int32, oDispatchMaster.CreatedBy));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CreatedDate", DbType.DateTime, oDispatchMaster.CreatedDate));

                if (oDispatchMaster.StartedAt.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@StartedAt", DbType.DateTime, oDispatchMaster.StartedAt));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@StartedAt", DbType.DateTime, DBNull.Value));
                if (oDispatchMaster.CompletedAt.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CompletedAt", DbType.DateTime, oDispatchMaster.CompletedAt));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CompletedAt", DbType.DateTime, DBNull.Value));

                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LUDate", DbType.DateTime, oDispatchMaster.LUDate));
                if (oDispatchMaster.Remarks != null)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Remarks", DbType.String, oDispatchMaster.Remarks));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Remarks", DbType.String, DBNull.Value));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispMasterID", DbType.Int32, oDispatchMaster.DispMasterID));
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int RemoveDispatchMaster(DispatchMaster oDispatchMaster)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("DELETEDispatchMaster", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispMasterID", DbType.Int32, oDispatchMaster.DispMasterID));
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int RemoveDispatchMaster(int DispMasterID)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("DELETEDispatchMaster", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispMasterID", DbType.Int32, DispMasterID));
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
