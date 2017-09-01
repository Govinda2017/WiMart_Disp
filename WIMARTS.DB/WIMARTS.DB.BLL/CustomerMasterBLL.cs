using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using WIMARTS.DB.BusinessObjects;
using WIMARTS.DB.DAL;

namespace WIMARTS.DB.BLL
{
	public partial class CustomerMasterBLL
	{
		private CustomerMasterDAO _CustomerMasterDAO;

		public CustomerMasterDAO CustomerMasterDAO
		{
			get { return _CustomerMasterDAO; }
			set { _CustomerMasterDAO = value; }
		}

		public CustomerMasterBLL()
		{
			CustomerMasterDAO = new CustomerMasterDAO();
		}
		public List<CustomerMaster> GetCustomerMasters()
		{
			try
			{
				return CustomerMasterDAO.GetCustomerMasters();
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		public CustomerMaster GetCustomerMaster(int CustID)
		{
			try
			{
				return CustomerMasterDAO.GetCustomerMaster(CustID);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		public int AddCustomerMaster(CustomerMaster oCustomerMaster)
		{
			try
			{
				return CustomerMasterDAO.AddCustomerMaster(oCustomerMaster);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int UpdateCustomerMaster(CustomerMaster oCustomerMaster)
		{
			try
			{
				return CustomerMasterDAO.UpdateCustomerMaster(oCustomerMaster);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int RemoveCustomerMaster(CustomerMaster oCustomerMaster)
		{
			try
			{
				return CustomerMasterDAO.RemoveCustomerMaster(oCustomerMaster);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int RemoveCustomerMaster(int CustID)
		{
			try
			{
				return CustomerMasterDAO.RemoveCustomerMaster(CustID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<CustomerMaster> DeserializeCustomerMasters(string Path)
		{
			try
			{
				return GenericXmlSerializer<List<CustomerMaster>>.Deserialize(Path);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public void SerializeCustomerMasters(string Path, List<CustomerMaster> CustomerMasters)
		{
			try
			{
				GenericXmlSerializer<List<CustomerMaster>>.Serialize(CustomerMasters, Path);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
