using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using WIMARTS.DB.BusinessObjects;

namespace WIMARTS.DB.DAL
{
	public partial class RoleMasterDAO
	{
		public RoleMasterDAO()
		{
			DbProviderHelper.GetConnection();
		}
		public List<RoleMaster> GetRoleMasters()
		{
			try
			{
				List<RoleMaster> lstRoleMasters = new List<RoleMaster>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTRoleMasters",CommandType.StoredProcedure);
				DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					RoleMaster oRoleMaster = new RoleMaster();
					oRoleMaster.RoleID = Convert.ToInt32(oDbDataReader["RoleID"]);
					oRoleMaster.Name = Convert.ToString(oDbDataReader["Name"]);

					if(oDbDataReader["Remarks"] != DBNull.Value)
						oRoleMaster.Remarks = Convert.ToString(oDbDataReader["Remarks"]);
					lstRoleMasters.Add(oRoleMaster);
				}
				oDbDataReader.Close();
				return lstRoleMasters;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public RoleMaster GetRoleMaster(int RoleID)
		{
			try
			{
				RoleMaster oRoleMaster = new RoleMaster();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTRoleMaster",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@RoleID",DbType.Int32,RoleID));
				DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					oRoleMaster.RoleID = Convert.ToInt32(oDbDataReader["RoleID"]);
					oRoleMaster.Name = Convert.ToString(oDbDataReader["Name"]);

					if(oDbDataReader["Remarks"] != DBNull.Value)
						oRoleMaster.Remarks = Convert.ToString(oDbDataReader["Remarks"]);
				}
				oDbDataReader.Close();
				return oRoleMaster;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int AddRoleMaster(RoleMaster oRoleMaster)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("INSERTRoleMaster",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Name",DbType.String,oRoleMaster.Name));
				if (oRoleMaster.Remarks!=null)
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Remarks",DbType.String,oRoleMaster.Remarks));
				else
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Remarks",DbType.String,DBNull.Value));

				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int UpdateRoleMaster(RoleMaster oRoleMaster)
		{

			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("UPDATERoleMaster",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Name",DbType.String,oRoleMaster.Name));
				if (oRoleMaster.Remarks!=null)
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Remarks",DbType.String,oRoleMaster.Remarks));
				else
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Remarks",DbType.String,DBNull.Value));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@RoleID",DbType.Int32,oRoleMaster.RoleID));
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int RemoveRoleMaster(RoleMaster oRoleMaster)
		{

			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("DELETERoleMaster",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@RoleID",DbType.Int32,oRoleMaster.RoleID));
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int RemoveRoleMaster(int RoleID)
		{

			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("DELETERoleMaster",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@RoleID",DbType.Int32,RoleID));
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
