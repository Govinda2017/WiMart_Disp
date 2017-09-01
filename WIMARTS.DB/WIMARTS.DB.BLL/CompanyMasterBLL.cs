using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using WIMARTS.DB.BusinessObjects;
using WIMARTS.DB.DAL;

namespace WIMARTS.DB.BLL
{
	public partial class CompanyMasterBLL
	{
		private CompanyMasterDAO _CompanyMasterDAO;

		public CompanyMasterDAO CompanyMasterDAO
		{
			get { return _CompanyMasterDAO; }
			set { _CompanyMasterDAO = value; }
		}

		public CompanyMasterBLL()
		{
			CompanyMasterDAO = new CompanyMasterDAO();
		}
		public List<CompanyMaster> GetCompanyMasters()
		{
			try
			{
				return CompanyMasterDAO.GetCompanyMasters();
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		public CompanyMaster GetCompanyMaster(int CompanyID)
		{
			try
			{
				return CompanyMasterDAO.GetCompanyMaster(CompanyID);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		public int AddCompanyMaster(CompanyMaster oCompanyMaster)
		{
			try
			{
				return CompanyMasterDAO.AddCompanyMaster(oCompanyMaster);
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
				return CompanyMasterDAO.UpdateCompanyMaster(oCompanyMaster);
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
				return CompanyMasterDAO.RemoveCompanyMaster(oCompanyMaster);
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
				return CompanyMasterDAO.RemoveCompanyMaster(CompanyID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<CompanyMaster> DeserializeCompanyMasters(string Path)
		{
			try
			{
				return GenericXmlSerializer<List<CompanyMaster>>.Deserialize(Path);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public void SerializeCompanyMasters(string Path, List<CompanyMaster> CompanyMasters)
		{
			try
			{
				GenericXmlSerializer<List<CompanyMaster>>.Serialize(CompanyMasters, Path);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
