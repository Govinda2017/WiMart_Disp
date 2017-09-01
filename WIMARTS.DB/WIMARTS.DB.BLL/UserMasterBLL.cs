using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using WIMARTS.DB.BusinessObjects;
using WIMARTS.DB.DAL;

namespace WIMARTS.DB.BLL
{
	public partial class UserMasterBLL
	{
		private UserMasterDAO _UserMasterDAO;

		public UserMasterDAO UserMasterDAO
		{
			get { return _UserMasterDAO; }
			set { _UserMasterDAO = value; }
		}

		public UserMasterBLL()
		{
			UserMasterDAO = new UserMasterDAO();
		}
		public List<UserMaster> GetUserMasters()
		{
			try
			{
				return UserMasterDAO.GetUserMasters();
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		public UserMaster GetUserMaster(int UserID)
		{
			try
			{
				return UserMasterDAO.GetUserMaster(UserID);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		public int AddUserMaster(UserMaster oUserMaster)
		{
			try
			{
				return UserMasterDAO.AddUserMaster(oUserMaster);
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
				return UserMasterDAO.UpdateUserMaster(oUserMaster);
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
				return UserMasterDAO.RemoveUserMaster(oUserMaster);
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
				return UserMasterDAO.RemoveUserMaster(UserID);
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
				return UserMasterDAO.GetUserMastersOfRoleMaster(RoleID);
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
				return UserMasterDAO.GetRoleMasterOfUserMaster(RoleID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public RoleMaster GetRoleMasterOfUserMaster(UserMaster oUserMaster)
		{
			try
			{
				return UserMasterDAO.GetRoleMasterOfUserMaster(oUserMaster.RoleID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<UserMaster> DeserializeUserMasters(string Path)
		{
			try
			{
				return GenericXmlSerializer<List<UserMaster>>.Deserialize(Path);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public void SerializeUserMasters(string Path, List<UserMaster> UserMasters)
		{
			try
			{
				GenericXmlSerializer<List<UserMaster>>.Serialize(UserMasters, Path);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
