using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using WIMARTS.DB.BusinessObjects;

namespace WIMARTS.DB.DAL
{
	public partial class UserMasterDAO
	{
		public UserMasterDAO()
		{
			DbProviderHelper.GetConnection();
		}
		public List<UserMaster> GetUserMasters()
		{
			try
			{
				List<UserMaster> lstUserMasters = new List<UserMaster>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTUserMasters",CommandType.StoredProcedure);
				DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					UserMaster oUserMaster = new UserMaster();
					oUserMaster.UserID = Convert.ToInt32(oDbDataReader["UserID"]);
					oUserMaster.Name = Convert.ToString(oDbDataReader["Name"]);
					oUserMaster.Password = Convert.ToString(oDbDataReader["Password"]);
					oUserMaster.RoleID = Convert.ToInt32(oDbDataReader["RoleID"]);
					oUserMaster.Active = Convert.ToBoolean(oDbDataReader["Active"]);

					if(oDbDataReader["LastUpdatedDate"] != DBNull.Value)
						oUserMaster.LastUpdatedDate = Convert.ToDateTime(oDbDataReader["LastUpdatedDate"]);

					if(oDbDataReader["LastUpdatedBy"] != DBNull.Value)
						oUserMaster.LastUpdatedBy = Convert.ToInt32(oDbDataReader["LastUpdatedBy"]);
					lstUserMasters.Add(oUserMaster);
				}
				oDbDataReader.Close();
				return lstUserMasters;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public UserMaster GetUserMaster(int UserID)
		{
			try
			{
				UserMaster oUserMaster = new UserMaster();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTUserMaster",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@UserID",DbType.Int32,UserID));
				DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					oUserMaster.UserID = Convert.ToInt32(oDbDataReader["UserID"]);
					oUserMaster.Name = Convert.ToString(oDbDataReader["Name"]);
					oUserMaster.Password = Convert.ToString(oDbDataReader["Password"]);
					oUserMaster.RoleID = Convert.ToInt32(oDbDataReader["RoleID"]);
					oUserMaster.Active = Convert.ToBoolean(oDbDataReader["Active"]);

					if(oDbDataReader["LastUpdatedDate"] != DBNull.Value)
						oUserMaster.LastUpdatedDate = Convert.ToDateTime(oDbDataReader["LastUpdatedDate"]);

					if(oDbDataReader["LastUpdatedBy"] != DBNull.Value)
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
		public int AddUserMaster(UserMaster oUserMaster)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("INSERTUserMaster",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Name",DbType.String,oUserMaster.Name));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Password",DbType.String,oUserMaster.Password));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@RoleID",DbType.Int32,oUserMaster.RoleID));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Active",DbType.Boolean,oUserMaster.Active));
				if (oUserMaster.LastUpdatedDate.HasValue)
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LastUpdatedDate",DbType.DateTime,oUserMaster.LastUpdatedDate));
				else
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LastUpdatedDate",DbType.DateTime,DBNull.Value));
				if (oUserMaster.LastUpdatedBy.HasValue)
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LastUpdatedBy",DbType.Int32,oUserMaster.LastUpdatedBy));
				else
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LastUpdatedBy",DbType.Int32,DBNull.Value));

				return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int UpdateUserMaster(UserMaster oUserMaster)
		{

			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("UPDATEUserMaster",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Name",DbType.String,oUserMaster.Name));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Password",DbType.String,oUserMaster.Password));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@RoleID",DbType.Int32,oUserMaster.RoleID));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Active",DbType.Boolean,oUserMaster.Active));
				if (oUserMaster.LastUpdatedDate.HasValue)
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LastUpdatedDate",DbType.DateTime,oUserMaster.LastUpdatedDate));
				else
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LastUpdatedDate",DbType.DateTime,DBNull.Value));
				if (oUserMaster.LastUpdatedBy.HasValue)
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LastUpdatedBy",DbType.Int32,oUserMaster.LastUpdatedBy));
				else
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LastUpdatedBy",DbType.Int32,DBNull.Value));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@UserID",DbType.Int32,oUserMaster.UserID));
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int RemoveUserMaster(UserMaster oUserMaster)
		{

			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("DELETEUserMaster",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@UserID",DbType.Int32,oUserMaster.UserID));
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int RemoveUserMaster(int UserID)
		{

			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("DELETEUserMaster",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@UserID",DbType.Int32,UserID));
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<UserMaster> GetUserMastersOfRoleMaster(int RoleID)
		{
			try
			{
				List<UserMaster> lstUserMasters = new List<UserMaster>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTUserMastersOfRoleMaster",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@RoleID",DbType.Int32,RoleID));
				DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					UserMaster oUserMaster = new UserMaster();
					oUserMaster.UserID = Convert.ToInt32(oDbDataReader["UserID"]);
					oUserMaster.Name = Convert.ToString(oDbDataReader["Name"]);
					oUserMaster.Password = Convert.ToString(oDbDataReader["Password"]);
					oUserMaster.RoleID = Convert.ToInt32(oDbDataReader["RoleID"]);
					oUserMaster.Active = Convert.ToBoolean(oDbDataReader["Active"]);

					if(oDbDataReader["LastUpdatedDate"] != DBNull.Value)
						oUserMaster.LastUpdatedDate = Convert.ToDateTime(oDbDataReader["LastUpdatedDate"]);

					if(oDbDataReader["LastUpdatedBy"] != DBNull.Value)
						oUserMaster.LastUpdatedBy = Convert.ToInt32(oDbDataReader["LastUpdatedBy"]);
					lstUserMasters.Add(oUserMaster);
				}
				oDbDataReader.Close();
				return lstUserMasters;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public RoleMaster GetRoleMasterOfUserMaster(int RoleID)
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
	}
}
