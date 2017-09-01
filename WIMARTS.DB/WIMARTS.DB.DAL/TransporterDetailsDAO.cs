using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using WIMARTS.DB.BusinessObjects;

namespace WIMARTS.DB.DAL
{
	public partial class TransporterDetailsDAO
	{
		public TransporterDetailsDAO()
		{
			DbProviderHelper.GetConnection();
		}
		public TransporterDetailsDAO(string providerName, string connectionString)
		{
			DbProviderHelper.GetConnection(providerName, connectionString);
		}

		public int AddTransporterDetails(TransporterDetails oTransporterDetails)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("INSERTTransporterDetails",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@TransporterName",DbType.String,oTransporterDetails.TransporterName));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Address",DbType.String,oTransporterDetails.Address));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@City",DbType.String,oTransporterDetails.City));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Pincode",DbType.String,oTransporterDetails.Pincode));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@PhoneNum",DbType.String,oTransporterDetails.PhoneNum));
				if (oTransporterDetails.EmailID!=null)
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@EmailID",DbType.String,oTransporterDetails.EmailID));
				else
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@EmailID",DbType.String,DBNull.Value));

				return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int UpdateTransporterDetails(TransporterDetails oTransporterDetails)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("UPDATETransporterDetails",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@TransporterName",DbType.String,oTransporterDetails.TransporterName));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Address",DbType.String,oTransporterDetails.Address));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@City",DbType.String,oTransporterDetails.City));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Pincode",DbType.String,oTransporterDetails.Pincode));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@PhoneNum",DbType.String,oTransporterDetails.PhoneNum));
				if (oTransporterDetails.EmailID!=null)
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@EmailID",DbType.String,oTransporterDetails.EmailID));
				else
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@EmailID",DbType.String,DBNull.Value));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@TransporterID",DbType.Int32,oTransporterDetails.TransporterID));
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int AddOrUpdateTransporterDetails(TransporterDetails oTransporterDetails)
		{
			try
			{
				TransporterDetails objData = GetTransporterDetails(oTransporterDetails.TransporterID);
				if (objData == null)
					return AddTransporterDetails(oTransporterDetails);
				else
					return UpdateTransporterDetails(oTransporterDetails);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int RemoveTransporterDetails(TransporterDetails oTransporterDetails)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("DELETETransporterDetails",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@TransporterID",DbType.Int32,oTransporterDetails.TransporterID));
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int RemoveTransporterDetails(int TransporterID)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("DELETETransporterDetails",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@TransporterID",DbType.Int32,TransporterID));
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		#region ELEMENT

        public TransporterDetails GetTransporterDetails(int TransporterID)
		{
			try
			{
				TransporterDetails oTransporterDetails = null;

				DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTTransporterDetails",CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@TransporterID", DbType.Int32, TransporterID));
				DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					oTransporterDetails = new TransporterDetails();

					oTransporterDetails.TransporterID = Convert.ToInt32(oDbDataReader["TransporterID"]);

					oTransporterDetails.TransporterName = Convert.ToString(oDbDataReader["TransporterName"]);

					oTransporterDetails.Address = Convert.ToString(oDbDataReader["Address"]);

					oTransporterDetails.City = Convert.ToString(oDbDataReader["City"]);

					oTransporterDetails.Pincode = Convert.ToString(oDbDataReader["Pincode"]);

					oTransporterDetails.PhoneNum = Convert.ToString(oDbDataReader["PhoneNum"]);

					if(oDbDataReader["EmailID"] != DBNull.Value)
						oTransporterDetails.EmailID = Convert.ToString(oDbDataReader["EmailID"]);

				}
				oDbDataReader.Close();
				return oTransporterDetails;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public Boolean IsFieldDataExists(TransporterDetails.enumFlags Fld2Use, object ParamValue)
		{
			try
			{
				Boolean RetValue = false;
				DbType FldParamDbType = GetFieldDBType(Fld2Use);
				string FldParam = string.Empty;

				if (Fld2Use != TransporterDetails.enumFlags.ALL)
					FldParam = Fld2Use.ToString();

				DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTTransporterDetails",CommandType.StoredProcedure);
				DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					RetValue = true;
					break;
				}
				oDbDataReader.Close();
				return RetValue;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		#endregion ELEMENT

		#region LIST

		public List<TransporterDetails> GetTransporterDetailsList()
		{
			try
			{
				List<TransporterDetails> lstTransporterDetails = new List<TransporterDetails>();

                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTTransporterDetailss", CommandType.StoredProcedure);
				DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					TransporterDetails oTransporterDetails = new TransporterDetails();

					oTransporterDetails.TransporterID = Convert.ToInt32(oDbDataReader["TransporterID"]);

					oTransporterDetails.TransporterName = Convert.ToString(oDbDataReader["TransporterName"]);

					oTransporterDetails.Address = Convert.ToString(oDbDataReader["Address"]);

					oTransporterDetails.City = Convert.ToString(oDbDataReader["City"]);

					oTransporterDetails.Pincode = Convert.ToString(oDbDataReader["Pincode"]);

					oTransporterDetails.PhoneNum = Convert.ToString(oDbDataReader["PhoneNum"]);

					if(oDbDataReader["EmailID"] != DBNull.Value)
						oTransporterDetails.EmailID = Convert.ToString(oDbDataReader["EmailID"]);

					lstTransporterDetails.Add(oTransporterDetails);
				}
				oDbDataReader.Close();
				return lstTransporterDetails;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		#endregion LIST

		#region DataSet

		public DataSet GetTransporterDetailsDS(TransporterDetails.enumFlags Fld2Use, object ParamValue)
		{
			try
			{
				DbType FldParamDbType = GetFieldDBType(Fld2Use);
				string FldParam = string.Empty;

				if (Fld2Use != TransporterDetails.enumFlags.ALL)
					FldParam = Fld2Use.ToString();

				string Query = "SELECT [TransporterID],[TransporterName],[Address],[City],[Pincode],[PhoneNum],[EmailID] FROM [TransporterDetails]  WHERE [" + FldParam + "]=@FldParam";

				DbCommand oDbCommand = DbProviderHelper.CreateCommand(Query, CommandType.Text);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(FldParam, FldParamDbType, ParamValue));

				DataSet ds;
				DbDataAdapter dataAdpt = DbProviderHelper.CreateDataAdapter(oDbCommand);
				ds = DbProviderHelper.FillDataSet(dataAdpt);
				return ds;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		#endregion DataSet

		#region DataTables

		public DataTable GetTransporterDetailsDT(TransporterDetails.enumFlags Fld2Use, object ParamValue)
		{
			try
			{
				DbType FldParamDbType = GetFieldDBType(Fld2Use);
				string FldParam = string.Empty;

				if (Fld2Use != TransporterDetails.enumFlags.ALL)
					FldParam = Fld2Use.ToString();

				string Query = "SELECT [TransporterID],[TransporterName],[Address],[City],[Pincode],[PhoneNum],[EmailID] FROM [TransporterDetails]  WHERE [" + FldParam + "]=@FldParam";

				DbCommand oDbCommand = DbProviderHelper.CreateCommand(Query, CommandType.Text);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter(FldParam, FldParamDbType, ParamValue));

				DataTable dt;
				DbDataAdapter dataAdpt = DbProviderHelper.CreateDataAdapter(oDbCommand);
				dt = DbProviderHelper.FillDataTable(dataAdpt);
				return dt;

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		#endregion DataTables

		#region Internal Methods

		DbType GetFieldDBType(TransporterDetails.enumFlags Fld2Use)
		{
			DbType oDbType = DbType.String;

			switch (Fld2Use)
			{
				case TransporterDetails.enumFlags.TransporterID:
					oDbType = DbType.Int32; break;
				case TransporterDetails.enumFlags.TransporterName:
					oDbType = DbType.String; break;
				case TransporterDetails.enumFlags.Address:
					oDbType = DbType.String; break;
				case TransporterDetails.enumFlags.City:
					oDbType = DbType.String; break;
				case TransporterDetails.enumFlags.Pincode:
					oDbType = DbType.String; break;
				case TransporterDetails.enumFlags.PhoneNum:
					oDbType = DbType.String; break;
				case TransporterDetails.enumFlags.EmailID:
					oDbType = DbType.String; break;
			}
			return oDbType;
		}

		#endregion Internal Methods

	}
}
