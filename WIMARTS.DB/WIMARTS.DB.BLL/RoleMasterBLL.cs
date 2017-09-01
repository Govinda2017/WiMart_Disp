using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using WIMARTS.DB.BusinessObjects;
using WIMARTS.DB.DAL;

namespace WIMARTS.DB.BLL
{
	public partial class RoleMasterBLL
	{
		private RoleMasterDAO _RoleMasterDAO;

		public RoleMasterDAO RoleMasterDAO
		{
			get { return _RoleMasterDAO; }
			set { _RoleMasterDAO = value; }
		}

		public RoleMasterBLL()
		{
			RoleMasterDAO = new RoleMasterDAO();
		}
		public List<RoleMaster> GetRoleMasters()
		{
			try
			{
				return RoleMasterDAO.GetRoleMasters();
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		public RoleMaster GetRoleMaster(int RoleID)
		{
			try
			{
				return RoleMasterDAO.GetRoleMaster(RoleID);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		public int AddRoleMaster(RoleMaster oRoleMaster)
		{
			try
			{
				return RoleMasterDAO.AddRoleMaster(oRoleMaster);
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
				return RoleMasterDAO.UpdateRoleMaster(oRoleMaster);
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
				return RoleMasterDAO.RemoveRoleMaster(oRoleMaster);
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
				return RoleMasterDAO.RemoveRoleMaster(RoleID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<RoleMaster> DeserializeRoleMasters(string Path)
		{
			try
			{
				return GenericXmlSerializer<List<RoleMaster>>.Deserialize(Path);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public void SerializeRoleMasters(string Path, List<RoleMaster> RoleMasters)
		{
			try
			{
				GenericXmlSerializer<List<RoleMaster>>.Serialize(RoleMasters, Path);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
