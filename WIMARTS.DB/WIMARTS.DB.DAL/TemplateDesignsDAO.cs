using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using WIMARTS.DB.BusinessObjects;

namespace WIMARTS.DB.DAL
{
	public partial class TemplateDesignsDAO
	{
		public TemplateDesignsDAO()
		{
			DbProviderHelper.GetConnection();
		}
		public List<TemplateDesigns> GetTemplateDesignss()
		{
			try
			{
				List<TemplateDesigns> lstTemplateDesignss = new List<TemplateDesigns>();
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTTemplateDesignss",CommandType.StoredProcedure);
				DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
				while (oDbDataReader.Read())
				{
					TemplateDesigns oTemplateDesigns = new TemplateDesigns();
					oTemplateDesigns.TemplateName = Convert.ToString(oDbDataReader["TemplateName"]);
					oTemplateDesigns.Template = Convert.ToString(oDbDataReader["Template"]);

					if(oDbDataReader["CreateDate"] != DBNull.Value)
						oTemplateDesigns.CreateDate = Convert.ToDateTime(oDbDataReader["CreateDate"]);

					if(oDbDataReader["LastUpdatedDate"] != DBNull.Value)
						oTemplateDesigns.LastUpdatedDate = Convert.ToDateTime(oDbDataReader["LastUpdatedDate"]);
					lstTemplateDesignss.Add(oTemplateDesigns);
				}
				oDbDataReader.Close();
				return lstTemplateDesignss;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int AddTemplateDesigns(TemplateDesigns oTemplateDesigns)
		{
			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("INSERTTemplateDesigns",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@TemplateName",DbType.String,oTemplateDesigns.TemplateName));
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Template",DbType.String,oTemplateDesigns.Template));
				if (oTemplateDesigns.CreateDate.HasValue)
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CreateDate",DbType.DateTime,oTemplateDesigns.CreateDate));
				else
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CreateDate",DbType.DateTime,DBNull.Value));
				if (oTemplateDesigns.LastUpdatedDate.HasValue)
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LastUpdatedDate",DbType.DateTime,oTemplateDesigns.LastUpdatedDate));
				else
					oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LastUpdatedDate",DbType.DateTime,DBNull.Value));

				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
       
        public int UpdateTemplateDesigns(TemplateDesigns oTemplateDesigns)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("UPDATETemplateDesigns", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@TemplateName", DbType.String, oTemplateDesigns.TemplateName));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Template", DbType.String, oTemplateDesigns.Template));
                if (oTemplateDesigns.CreateDate.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CreateDate", DbType.DateTime, oTemplateDesigns.CreateDate));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CreateDate", DbType.DateTime, DBNull.Value));
                if (oTemplateDesigns.LastUpdatedDate.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LastUpdatedDate", DbType.DateTime, oTemplateDesigns.LastUpdatedDate));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LastUpdatedDate", DbType.DateTime, DBNull.Value));

                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
	public int RemoveTemplateDesigns(TemplateDesigns oTemplateDesigns)
		{

			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("DELETETemplateDesigns",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@TemplateName",DbType.String,oTemplateDesigns.TemplateName));
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int RemoveTemplateDesigns(string TemplateName)
		{

			try
			{
				DbCommand oDbCommand = DbProviderHelper.CreateCommand("DELETETemplateDesigns",CommandType.StoredProcedure);
				oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@TemplateName",DbType.String,TemplateName));
				return DbProviderHelper.ExecuteNonQuery(oDbCommand);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
}  
 }
