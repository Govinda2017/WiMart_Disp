using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using WIMARTS.DB.BusinessObjects;

namespace WIMARTS.DB.DAL
{
	public partial class PrintMasterDAO
	{
		public PrintMasterDAO()
		{
			DbProviderHelper.GetConnection();
		}
        public List<PrintMaster> GetPrintMasters()
        {
            try
            {
                List<PrintMaster> lstPrintMasters = new List<PrintMaster>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTPrintMasters", CommandType.StoredProcedure);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    PrintMaster oPrintMaster = new PrintMaster();
                    oPrintMaster.PrintID = Convert.ToInt32(oDbDataReader["PrintID"]);
                    oPrintMaster.ProdID = Convert.ToInt32(oDbDataReader["ProdID"]);
                    oPrintMaster.ProdCode = Convert.ToString(oDbDataReader["ProdCode"]);
                    oPrintMaster.ProdName = Convert.ToString(oDbDataReader["ProdName"]);
                    oPrintMaster.BatchName = Convert.ToString(oDbDataReader["BatchName"]);
                        oPrintMaster.MfgDate = Convert.ToDateTime(oDbDataReader["MfgDate"]);
                    oPrintMaster.MRP = Convert.ToDecimal(oDbDataReader["MRP"]);
                    oPrintMaster.TemplateName = Convert.ToString(oDbDataReader["TemplateName"]);
                    oPrintMaster.Template = Convert.ToString(oDbDataReader["Template"]);
                    oPrintMaster.Status = Convert.ToInt32(oDbDataReader["Status"]);

                    oPrintMaster.Quantity = Convert.ToDecimal(oDbDataReader["Quantity"]);

                    if (oDbDataReader["GoodQty"] != DBNull.Value)
                        oPrintMaster.GoodQty = Convert.ToDecimal(oDbDataReader["GoodQty"]);

                    if (oDbDataReader["BadQty"] != DBNull.Value)
                        oPrintMaster.BadQty = Convert.ToDecimal(oDbDataReader["BadQty"]);
                    oPrintMaster.CreatedDate = Convert.ToDateTime(oDbDataReader["CreatedDate"]);
                    oPrintMaster.LUDate = Convert.ToDateTime(oDbDataReader["LUDate"]);

                    if (oDbDataReader["Remarks"] != DBNull.Value)
                        oPrintMaster.Remarks = Convert.ToString(oDbDataReader["Remarks"]);
                    lstPrintMasters.Add(oPrintMaster);
                }
                oDbDataReader.Close();
                return lstPrintMasters;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		public PrintMaster GetPrintMaster(int PrintID)
		{
			try
			{
				PrintMaster oPrintMaster = new PrintMaster();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTPrintMaster",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@PrintID",DbType.Int32,PrintID));
				DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					oPrintMaster.PrintID = Convert.ToInt32(oDbDataReader["PrintID"]);
					oPrintMaster.ProdID = Convert.ToInt32(oDbDataReader["ProdID"]);
					oPrintMaster.ProdCode = Convert.ToString(oDbDataReader["ProdCode"]);
					oPrintMaster.ProdName = Convert.ToString(oDbDataReader["ProdName"]);
					oPrintMaster.BatchName = Convert.ToString(oDbDataReader["BatchName"]);
                       oPrintMaster.MfgDate = Convert.ToDateTime(oDbDataReader["MfgDate"]);
                    oPrintMaster.MRP = Convert.ToDecimal(oDbDataReader["MRP"]);
					oPrintMaster.TemplateName = Convert.ToString(oDbDataReader["TemplateName"]);
					oPrintMaster.Template = Convert.ToString(oDbDataReader["Template"]);
					oPrintMaster.Status = Convert.ToInt32(oDbDataReader["Status"]);

						oPrintMaster.Quantity = Convert.ToDecimal(oDbDataReader["Quantity"]);

					if(oDbDataReader["GoodQty"] != DBNull.Value)
						oPrintMaster.GoodQty = Convert.ToDecimal(oDbDataReader["GoodQty"]);

					if(oDbDataReader["BadQty"] != DBNull.Value)
						oPrintMaster.BadQty = Convert.ToDecimal(oDbDataReader["BadQty"]);
					oPrintMaster.CreatedDate = Convert.ToDateTime(oDbDataReader["CreatedDate"]);
					oPrintMaster.LUDate = Convert.ToDateTime(oDbDataReader["LUDate"]);

					if(oDbDataReader["Remarks"] != DBNull.Value)
						oPrintMaster.Remarks = Convert.ToString(oDbDataReader["Remarks"]);
				}
				oDbDataReader.Close();
				return oPrintMaster;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public int AddPrintMaster(PrintMaster oPrintMaster)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("INSERTPrintMaster", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@ProdID", DbType.Int32, oPrintMaster.ProdID));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@ProdCode", DbType.String, oPrintMaster.ProdCode));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@ProdName", DbType.String, oPrintMaster.ProdName));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@BatchName", DbType.String, oPrintMaster.BatchName));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@MfgDate", DbType.DateTime, oPrintMaster.MfgDate));
            
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@MRP", DbType.Decimal, oPrintMaster.MRP));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@TemplateName", DbType.String, oPrintMaster.TemplateName));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Template", DbType.String, oPrintMaster.Template));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Status", DbType.Int32, oPrintMaster.Status));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Quantity", DbType.Decimal, oPrintMaster.Quantity));
                if (oPrintMaster.GoodQty.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@GoodQty", DbType.Decimal, oPrintMaster.GoodQty));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@GoodQty", DbType.Decimal, DBNull.Value));
                if (oPrintMaster.BadQty.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@BadQty", DbType.Decimal, oPrintMaster.BadQty));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@BadQty", DbType.Decimal, DBNull.Value));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CreatedDate", DbType.DateTime, oPrintMaster.CreatedDate));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LUDate", DbType.DateTime, oPrintMaster.LUDate));
                if (oPrintMaster.Remarks != null)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Remarks", DbType.String, oPrintMaster.Remarks));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Remarks", DbType.String, DBNull.Value));

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		public int UpdatePrintMaster(PrintMaster oPrintMaster)
		{

			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("UPDATEPrintMaster",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@ProdID",DbType.Int32,oPrintMaster.ProdID));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@ProdCode",DbType.String,oPrintMaster.ProdCode));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@ProdName",DbType.String,oPrintMaster.ProdName));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@BatchName",DbType.String,oPrintMaster.BatchName));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@MfgDate", DbType.DateTime, oPrintMaster.MfgDate));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@MRP", DbType.Decimal, oPrintMaster.MRP));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@TemplateName",DbType.String,oPrintMaster.TemplateName));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Template",DbType.String,oPrintMaster.Template));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Status",DbType.Int32,oPrintMaster.Status));
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Quantity",DbType.Decimal,oPrintMaster.Quantity));
				if (oPrintMaster.GoodQty.HasValue)
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@GoodQty",DbType.Decimal,oPrintMaster.GoodQty));
				else
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@GoodQty",DbType.Decimal,DBNull.Value));
				if (oPrintMaster.BadQty.HasValue)
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@BadQty",DbType.Decimal,oPrintMaster.BadQty));
				else
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@BadQty",DbType.Decimal,DBNull.Value));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CreatedDate",DbType.DateTime,oPrintMaster.CreatedDate));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LUDate",DbType.DateTime,oPrintMaster.LUDate));
				if (oPrintMaster.Remarks!=null)
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Remarks",DbType.String,oPrintMaster.Remarks));
				else
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Remarks",DbType.String,DBNull.Value));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@PrintID",DbType.Int32,oPrintMaster.PrintID));
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int RemovePrintMaster(PrintMaster oPrintMaster)
		{

			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("DELETEPrintMaster",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@PrintID",DbType.Int32,oPrintMaster.PrintID));
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int RemovePrintMaster(int PrintID)
		{

			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("DELETEPrintMaster",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@PrintID",DbType.Int32,PrintID));
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
