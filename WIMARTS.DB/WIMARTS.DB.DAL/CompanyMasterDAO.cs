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
		public CompanyMasterDAO()
		{
			DbProviderHelper.GetConnection();
		}
		public List<CompanyMaster> GetCompanyMasters()
		{
			try
			{
				List<CompanyMaster> lstCompanyMasters = new List<CompanyMaster>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTCompanyMasters",CommandType.StoredProcedure);
				DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					CompanyMaster oCompanyMaster = new CompanyMaster();
					oCompanyMaster.CompanyID = Convert.ToInt32(oDbDataReader["CompanyID"]);
					oCompanyMaster.CompanyName = Convert.ToString(oDbDataReader["CompanyName"]);
					oCompanyMaster.Logo = (Byte[])(oDbDataReader["Logo"]);
					oCompanyMaster.AddressLine = Convert.ToString(oDbDataReader["AddressLine"]);
					oCompanyMaster.City = Convert.ToString(oDbDataReader["City"]);
					oCompanyMaster.Pincode = Convert.ToString(oDbDataReader["Pincode"]);
					oCompanyMaster.PhoneNum = Convert.ToString(oDbDataReader["PhoneNum"]);
					oCompanyMaster.EmailID = Convert.ToString(oDbDataReader["EmailID"]);
					oCompanyMaster.WebSite = Convert.ToString(oDbDataReader["WebSite"]);
					oCompanyMaster.LUDate = Convert.ToDateTime(oDbDataReader["LUDate"]);
					oCompanyMaster.LUBy = Convert.ToInt32(oDbDataReader["LUBy"]);

					if(oDbDataReader["Remarks"] != DBNull.Value)
						oCompanyMaster.Remarks = Convert.ToString(oDbDataReader["Remarks"]);
					lstCompanyMasters.Add(oCompanyMaster);
				}
				oDbDataReader.Close();
				return lstCompanyMasters;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public CompanyMaster GetCompanyMaster(int CompanyID)
		{
			try
			{
				CompanyMaster oCompanyMaster = new CompanyMaster();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTCompanyMaster",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CompanyID",DbType.Int32,CompanyID));
				DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					oCompanyMaster.CompanyID = Convert.ToInt32(oDbDataReader["CompanyID"]);
					oCompanyMaster.CompanyName = Convert.ToString(oDbDataReader["CompanyName"]);
					oCompanyMaster.Logo = (Byte[])(oDbDataReader["Logo"]);
					oCompanyMaster.AddressLine = Convert.ToString(oDbDataReader["AddressLine"]);
					oCompanyMaster.City = Convert.ToString(oDbDataReader["City"]);
					oCompanyMaster.Pincode = Convert.ToString(oDbDataReader["Pincode"]);
					oCompanyMaster.PhoneNum = Convert.ToString(oDbDataReader["PhoneNum"]);
					oCompanyMaster.EmailID = Convert.ToString(oDbDataReader["EmailID"]);
					oCompanyMaster.WebSite = Convert.ToString(oDbDataReader["WebSite"]);
					oCompanyMaster.LUDate = Convert.ToDateTime(oDbDataReader["LUDate"]);
					oCompanyMaster.LUBy = Convert.ToInt32(oDbDataReader["LUBy"]);

					if(oDbDataReader["Remarks"] != DBNull.Value)
						oCompanyMaster.Remarks = Convert.ToString(oDbDataReader["Remarks"]);
				}
				oDbDataReader.Close();
				return oCompanyMaster;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int AddCompanyMaster(CompanyMaster oCompanyMaster)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("INSERTCompanyMaster",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CompanyName",DbType.String,oCompanyMaster.CompanyName));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Logo",DbType.Binary,oCompanyMaster.Logo));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@AddressLine",DbType.String,oCompanyMaster.AddressLine));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@City",DbType.String,oCompanyMaster.City));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Pincode",DbType.String,oCompanyMaster.Pincode));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@PhoneNum",DbType.String,oCompanyMaster.PhoneNum));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@EmailID",DbType.String,oCompanyMaster.EmailID));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@WebSite",DbType.String,oCompanyMaster.WebSite));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LUDate",DbType.DateTime,oCompanyMaster.LUDate));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LUBy",DbType.Int32,oCompanyMaster.LUBy));
				if (oCompanyMaster.Remarks!=null)
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Remarks",DbType.String,oCompanyMaster.Remarks));
				else
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Remarks",DbType.String,DBNull.Value));

				return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int UpdateCompanyMaster(CompanyMaster oCompanyMaster)
		{

			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("UPDATECompanyMaster",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CompanyName",DbType.String,oCompanyMaster.CompanyName));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Logo",DbType.Binary,oCompanyMaster.Logo));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@AddressLine",DbType.String,oCompanyMaster.AddressLine));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@City",DbType.String,oCompanyMaster.City));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Pincode",DbType.String,oCompanyMaster.Pincode));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@PhoneNum",DbType.String,oCompanyMaster.PhoneNum));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@EmailID",DbType.String,oCompanyMaster.EmailID));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@WebSite",DbType.String,oCompanyMaster.WebSite));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LUDate",DbType.DateTime,oCompanyMaster.LUDate));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LUBy",DbType.Int32,oCompanyMaster.LUBy));
				if (oCompanyMaster.Remarks!=null)
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Remarks",DbType.String,oCompanyMaster.Remarks));
				else
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Remarks",DbType.String,DBNull.Value));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CompanyID",DbType.Int32,oCompanyMaster.CompanyID));
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int RemoveCompanyMaster(CompanyMaster oCompanyMaster)
		{

			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("DELETECompanyMaster",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CompanyID",DbType.Int32,oCompanyMaster.CompanyID));
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int RemoveCompanyMaster(int CompanyID)
		{

			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("DELETECompanyMaster",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CompanyID",DbType.Int32,CompanyID));
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
