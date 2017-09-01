using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using WIMARTS.DB.BusinessObjects;
using WIMARTS.DB.DAL;

namespace WIMARTS.DB.BLL
{
	public partial class InspectionMasterBLL
	{
		private InspectionMasterDAO _InspectionMasterDAO;

		public InspectionMasterDAO InspectionMasterDAO
		{
			get { return _InspectionMasterDAO; }
			set { _InspectionMasterDAO = value; }
		}

		public InspectionMasterBLL()
		{
			InspectionMasterDAO = new InspectionMasterDAO();
		}
		public List<InspectionMaster> GetInspectionMasters()
		{
			try
			{
				return InspectionMasterDAO.GetInspectionMasters();
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		public InspectionMaster GetInspectionMaster(int InspID)
		{
			try
			{
				return InspectionMasterDAO.GetInspectionMaster(InspID);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		public int AddInspectionMaster(InspectionMaster oInspectionMaster)
		{
			try
			{
				return InspectionMasterDAO.AddInspectionMaster(oInspectionMaster);
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
				return InspectionMasterDAO.UpdateInspectionMaster(oInspectionMaster);
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
				return InspectionMasterDAO.RemoveInspectionMaster(oInspectionMaster);
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
				return InspectionMasterDAO.RemoveInspectionMaster(InspID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<InspectionMaster> DeserializeInspectionMasters(string Path)
		{
			try
			{
				return GenericXmlSerializer<List<InspectionMaster>>.Deserialize(Path);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public void SerializeInspectionMasters(string Path, List<InspectionMaster> InspectionMasters)
		{
			try
			{
				GenericXmlSerializer<List<InspectionMaster>>.Serialize(InspectionMasters, Path);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
