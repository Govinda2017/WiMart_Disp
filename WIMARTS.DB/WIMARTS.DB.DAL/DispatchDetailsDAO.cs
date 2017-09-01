using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using WIMARTS.DB.BusinessObjects;

namespace WIMARTS.DB.DAL
{
	public partial class DispatchDetailsDAO
	{
		public DispatchDetailsDAO()
		{
			DbProviderHelper.GetConnection();
		}
		public List<DispatchDetails> GetDispatchDetailss()
		{
			try
			{
				List<DispatchDetails> lstDispatchDetailss = new List<DispatchDetails>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTDispatchDetailss",CommandType.StoredProcedure);
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

					if(oDbDataReader["Remark"] != DBNull.Value)
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
		public DispatchDetails GetDispatchDetails(int DispDetailsID)
		{
			try
			{
				DispatchDetails oDispatchDetails = new DispatchDetails();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTDispatchDetails",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispDetailsID",DbType.Int32,DispDetailsID));
				DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					oDispatchDetails.DispDetailsID = Convert.ToInt32(oDbDataReader["DispDetailsID"]);
					oDispatchDetails.DispMasterID = Convert.ToInt32(oDbDataReader["DispMasterID"]);
                    oDispatchDetails.ProdCode = Convert.ToString(oDbDataReader["ProdCode"]);
					oDispatchDetails.QtytoDispatch = Convert.ToDecimal(oDbDataReader["QtytoDispatch"]);
                    oDispatchDetails.MaxQty = Convert.ToDecimal(oDbDataReader["MaxQty"]);
                    oDispatchDetails.MinQty = Convert.ToDecimal(oDbDataReader["MinQty"]);
                    oDispatchDetails.DispatchedQty = Convert.ToDecimal(oDbDataReader["DispatchedQty"]);
                    oDispatchDetails.CreatedDate = Convert.ToDateTime(oDbDataReader["CreatedDate"]);
					oDispatchDetails.LUDate = Convert.ToDateTime(oDbDataReader["LUDate"]);

					if(oDbDataReader["Remark"] != DBNull.Value)
						oDispatchDetails.Remark = Convert.ToString(oDbDataReader["Remark"]);
				}
				oDbDataReader.Close();
				return oDispatchDetails;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int AddDispatchDetails(DispatchDetails oDispatchDetails)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("INSERTDispatchDetails",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispMasterID",DbType.Int32,oDispatchDetails.DispMasterID));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@ProdCode",DbType.String,oDispatchDetails.ProdCode));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@QtytoDispatch",DbType.Decimal,oDispatchDetails.QtytoDispatch));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@MaxQty", DbType.Decimal, oDispatchDetails.MaxQty));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@MinQty", DbType.Decimal, oDispatchDetails.MinQty));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispatchedQty", DbType.Decimal, oDispatchDetails.DispatchedQty));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CreatedDate", DbType.DateTime, oDispatchDetails.CreatedDate));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LUDate",DbType.DateTime,oDispatchDetails.LUDate));
				if (oDispatchDetails.Remark!=null)
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Remark",DbType.String,oDispatchDetails.Remark));
				else
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Remark",DbType.String,DBNull.Value));

				return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int UpdateDispatchDetails(DispatchDetails oDispatchDetails)
		{

			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("UPDATEDispatchDetails",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispMasterID",DbType.Int32,oDispatchDetails.DispMasterID));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@ProdCode", DbType.String, oDispatchDetails.ProdCode));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@QtytoDispatch",DbType.Decimal,oDispatchDetails.QtytoDispatch));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispatchedQty", DbType.Decimal, oDispatchDetails.DispatchedQty));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@MaxQty", DbType.Decimal, oDispatchDetails.MaxQty));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@MinQty", DbType.Decimal, oDispatchDetails.MinQty));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CreatedDate", DbType.DateTime, oDispatchDetails.CreatedDate));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LUDate",DbType.DateTime,oDispatchDetails.LUDate));
				if (oDispatchDetails.Remark!=null)
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Remark",DbType.String,oDispatchDetails.Remark));
				else
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Remark",DbType.String,DBNull.Value));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispDetailsID",DbType.Int32,oDispatchDetails.DispDetailsID));
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int RemoveDispatchDetails(DispatchDetails oDispatchDetails)
		{

			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("DELETEDispatchDetails",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispDetailsID",DbType.Int32,oDispatchDetails.DispDetailsID));
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int RemoveDispatchDetails(int DispDetailsID)
		{

			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("DELETEDispatchDetails",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispDetailsID",DbType.Int32,DispDetailsID));
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
