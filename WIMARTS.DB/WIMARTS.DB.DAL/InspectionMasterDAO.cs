using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using WIMARTS.DB.BusinessObjects;

namespace WIMARTS.DB.DAL
{
    public partial class InspectionMasterDAO
    {
        public InspectionMasterDAO()
        {
            DbProviderHelper.GetConnection();
        }
        public List<InspectionMaster> GetInspectionMasters()
        {
            try
            {
                List<InspectionMaster> lstInspectionMasters = new List<InspectionMaster>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTInspectionMasters", CommandType.StoredProcedure);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    InspectionMaster oInspectionMaster = new InspectionMaster();
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
                    lstInspectionMasters.Add(oInspectionMaster);
                }
                oDbDataReader.Close();
                return lstInspectionMasters;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public InspectionMaster GetInspectionMaster(int InspID)
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
        public int AddInspectionMaster(InspectionMaster oInspectionMaster)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("INSERTInspectionMaster", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@BatchName", DbType.String, oInspectionMaster.BatchName));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LineID", DbType.Int32, oInspectionMaster.LineID));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Status", DbType.Int32, oInspectionMaster.Status));
                if (oInspectionMaster.GoodQty.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@GoodQty", DbType.Decimal, oInspectionMaster.GoodQty));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@GoodQty", DbType.Decimal, DBNull.Value));
                if (oInspectionMaster.BadQty.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@BadQty", DbType.Decimal, oInspectionMaster.BadQty));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@BadQty", DbType.Decimal, DBNull.Value));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CreatedDate", DbType.DateTime, oInspectionMaster.CreatedDate));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LUDate", DbType.DateTime, oInspectionMaster.LUDate));
                if (oInspectionMaster.Remark != null)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Remark", DbType.String, oInspectionMaster.Remark));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Remark", DbType.String, DBNull.Value));

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateInspectionMaster(InspectionMaster oInspectionMaster)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("UPDATEInspectionMaster", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@BatchName", DbType.String, oInspectionMaster.BatchName));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LineID", DbType.Int32, oInspectionMaster.LineID));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Status", DbType.Int32, oInspectionMaster.Status));
                if (oInspectionMaster.GoodQty.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@GoodQty", DbType.Decimal, oInspectionMaster.GoodQty));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@GoodQty", DbType.Decimal, DBNull.Value));
                if (oInspectionMaster.BadQty.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@BadQty", DbType.Decimal, oInspectionMaster.BadQty));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@BadQty", DbType.Decimal, DBNull.Value));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CreatedDate", DbType.DateTime, oInspectionMaster.CreatedDate));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LUDate", DbType.DateTime, oInspectionMaster.LUDate));
                if (oInspectionMaster.Remark != null)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Remark", DbType.String, oInspectionMaster.Remark));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Remark", DbType.String, DBNull.Value));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@InspID", DbType.Int32, oInspectionMaster.InspID));
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int RemoveInspectionMaster(InspectionMaster oInspectionMaster)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("DELETEInspectionMaster", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@InspID", DbType.Int32, oInspectionMaster.InspID));
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int RemoveInspectionMaster(int InspID)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("DELETEInspectionMaster", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@InspID", DbType.Int32, InspID));
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}