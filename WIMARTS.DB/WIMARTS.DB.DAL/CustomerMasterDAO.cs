using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using WIMARTS.DB.BusinessObjects;

namespace WIMARTS.DB.DAL
{
	public partial class CustomerMasterDAO
	{
		public CustomerMasterDAO()
		{
			DbProviderHelper.GetConnection();
		}
		public List<CustomerMaster> GetCustomerMasters()
		{
			try
			{
				List<CustomerMaster> lstCustomerMasters = new List<CustomerMaster>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTCustomerMasters",CommandType.StoredProcedure);
				DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					CustomerMaster oCustomerMaster = new CustomerMaster();
					oCustomerMaster.CustID = Convert.ToInt32(oDbDataReader["CustID"]);
					oCustomerMaster.CustName = Convert.ToString(oDbDataReader["CustName"]);
					oCustomerMaster.EmailID = Convert.ToString(oDbDataReader["EmailID"]);
					oCustomerMaster.PhoneNum = Convert.ToString(oDbDataReader["PhoneNum"]);
					oCustomerMaster.WebSite = Convert.ToString(oDbDataReader["WebSite"]);
					oCustomerMaster.AddrLine = Convert.ToString(oDbDataReader["AddrLine"]);
					oCustomerMaster.City = Convert.ToString(oDbDataReader["City"]);
					oCustomerMaster.Pincode = Convert.ToString(oDbDataReader["Pincode"]);
					oCustomerMaster.LUDate = Convert.ToDateTime(oDbDataReader["LUDate"]);
					oCustomerMaster.LUBy = Convert.ToInt32(oDbDataReader["LUBy"]);

					if(oDbDataReader["Remarks"] != DBNull.Value)
						oCustomerMaster.Remarks = Convert.ToString(oDbDataReader["Remarks"]);
					lstCustomerMasters.Add(oCustomerMaster);
				}
				oDbDataReader.Close();
				return lstCustomerMasters;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public CustomerMaster GetCustomerMaster(int CustID)
		{
			try
			{
				CustomerMaster oCustomerMaster = new CustomerMaster();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTCustomerMaster",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CustID",DbType.Int32,CustID));
				DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					oCustomerMaster.CustID = Convert.ToInt32(oDbDataReader["CustID"]);
					oCustomerMaster.CustName = Convert.ToString(oDbDataReader["CustName"]);
					oCustomerMaster.EmailID = Convert.ToString(oDbDataReader["EmailID"]);
					oCustomerMaster.PhoneNum = Convert.ToString(oDbDataReader["PhoneNum"]);
					oCustomerMaster.WebSite = Convert.ToString(oDbDataReader["WebSite"]);
					oCustomerMaster.AddrLine = Convert.ToString(oDbDataReader["AddrLine"]);
					oCustomerMaster.City = Convert.ToString(oDbDataReader["City"]);
					oCustomerMaster.Pincode = Convert.ToString(oDbDataReader["Pincode"]);
					oCustomerMaster.LUDate = Convert.ToDateTime(oDbDataReader["LUDate"]);
					oCustomerMaster.LUBy = Convert.ToInt32(oDbDataReader["LUBy"]);

					if(oDbDataReader["Remarks"] != DBNull.Value)
						oCustomerMaster.Remarks = Convert.ToString(oDbDataReader["Remarks"]);
				}
				oDbDataReader.Close();
				return oCustomerMaster;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int AddCustomerMaster(CustomerMaster oCustomerMaster)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("INSERTCustomerMaster",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CustName",DbType.String,oCustomerMaster.CustName));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@EmailID",DbType.String,oCustomerMaster.EmailID));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@PhoneNum",DbType.String,oCustomerMaster.PhoneNum));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@WebSite",DbType.String,oCustomerMaster.WebSite));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@AddrLine",DbType.String,oCustomerMaster.AddrLine));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@City",DbType.String,oCustomerMaster.City));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Pincode",DbType.String,oCustomerMaster.Pincode));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LUDate",DbType.DateTime,oCustomerMaster.LUDate));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LUBy",DbType.Int32,oCustomerMaster.LUBy));
				if (oCustomerMaster.Remarks!=null)
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Remarks",DbType.String,oCustomerMaster.Remarks));
				else
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Remarks",DbType.String,DBNull.Value));

				return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
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
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("UPDATECustomerMaster",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CustName",DbType.String,oCustomerMaster.CustName));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@EmailID",DbType.String,oCustomerMaster.EmailID));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@PhoneNum",DbType.String,oCustomerMaster.PhoneNum));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@WebSite",DbType.String,oCustomerMaster.WebSite));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@AddrLine",DbType.String,oCustomerMaster.AddrLine));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@City",DbType.String,oCustomerMaster.City));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Pincode",DbType.String,oCustomerMaster.Pincode));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LUDate",DbType.DateTime,oCustomerMaster.LUDate));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LUBy",DbType.Int32,oCustomerMaster.LUBy));
				if (oCustomerMaster.Remarks!=null)
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Remarks",DbType.String,oCustomerMaster.Remarks));
				else
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Remarks",DbType.String,DBNull.Value));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CustID",DbType.Int32,oCustomerMaster.CustID));
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
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
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("DELETECustomerMaster",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CustID",DbType.Int32,oCustomerMaster.CustID));
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
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
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("DELETECustomerMaster",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CustID",DbType.Int32,CustID));
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public  DataSet GetCustomerMastersDS(int MasterID)
        {

            try
            {
                DataSet ds = new DataSet();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTCustomerDetailsByDispMaster", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispMasterID", DbType.Int32, MasterID));                
                DbDataAdapter dataAdpt = DbProviderHelper.CreateDataAdapter(oDbCommand);
                ds = DbProviderHelper.FillDataSet(dataAdpt);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CustomerMaster GetCustomerMasterCSV(int MasterID)
        {

            try
            {
                CustomerMaster oCustomerMaster =new CustomerMaster();
                DataSet ds = new DataSet();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTCustomerDetailsByDispMaster", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@DispMasterID", DbType.Int32, MasterID));
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    oCustomerMaster.CustID = Convert.ToInt32(oDbDataReader["CustID"]);
                    oCustomerMaster.CustName = Convert.ToString(oDbDataReader["CustName"]);
                    oCustomerMaster.EmailID = Convert.ToString(oDbDataReader["EmailID"]);
                    oCustomerMaster.PhoneNum = Convert.ToString(oDbDataReader["PhoneNum"]);
                    oCustomerMaster.WebSite = Convert.ToString(oDbDataReader["WebSite"]);
                    oCustomerMaster.AddrLine = Convert.ToString(oDbDataReader["AddrLine"]);
                    oCustomerMaster.City = Convert.ToString(oDbDataReader["City"]);
                    oCustomerMaster.Pincode = Convert.ToString(oDbDataReader["Pincode"]);
                    oCustomerMaster.LUDate = Convert.ToDateTime(oDbDataReader["LUDate"]);
                    oCustomerMaster.LUBy = Convert.ToInt32(oDbDataReader["LUBy"]);

                    if (oDbDataReader["Remarks"] != DBNull.Value)
                        oCustomerMaster.Remarks = Convert.ToString(oDbDataReader["Remarks"]);
                }
                oDbDataReader.Close();                
                return oCustomerMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
