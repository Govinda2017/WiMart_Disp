using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using WIMARTS.DB.BusinessObjects;

namespace WIMARTS.DB.DAL
{
	public partial class UIDLineHolderDAO
	{
		public UIDLineHolderDAO()
		{
			DbProviderHelper.GetConnection();
		}
	
		public UIDLineHolder GetUIDLineHolder(string UnitCode, string LineCode)
		{
			try
			{
				UIDLineHolder oUIDLineHolder = new UIDLineHolder();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTUIDLineHolder",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@UnitCode",DbType.String,UnitCode));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LineCode", DbType.String, LineCode));
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					oUIDLineHolder.ID = Convert.ToInt32(oDbDataReader["ID"]);
                    oUIDLineHolder.Date = Convert.ToDateTime(oDbDataReader["Date"]);
                    oUIDLineHolder.UnitCode = Convert.ToString(oDbDataReader["UnitCode"]);
					oUIDLineHolder.LineCode = Convert.ToString(oDbDataReader["LineCode"]);
					oUIDLineHolder.LastUID = Convert.ToDecimal(oDbDataReader["LastUID"]);

					if(oDbDataReader["Remarks"] != DBNull.Value)
						oUIDLineHolder.Remarks = Convert.ToString(oDbDataReader["Remarks"]);
				}
				oDbDataReader.Close();
				return oUIDLineHolder;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int AddUIDLineHolder(UIDLineHolder oUIDLineHolder)
		{
			try
			{
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("InsertOrUpdateUIDLineHolder", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Date", DbType.Date, oUIDLineHolder.Date));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@UnitCode", DbType.String, oUIDLineHolder.UnitCode));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LineCode",DbType.String,oUIDLineHolder.LineCode));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LastUID",DbType.Decimal,oUIDLineHolder.LastUID));				
				return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		
	
	}
}
