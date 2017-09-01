using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using WIMARTS.DB.BusinessObjects;
using WIMARTS.DB.DAL;

namespace WIMARTS.DB.BLL
{
	public partial class TemplateDesignsBLL
	{
		private TemplateDesignsDAO _TemplateDesignsDAO;

		public TemplateDesignsDAO TemplateDesignsDAO
		{
			get { return _TemplateDesignsDAO; }
			set { _TemplateDesignsDAO = value; }
		}

		public TemplateDesignsBLL()
		{
			TemplateDesignsDAO = new TemplateDesignsDAO();
		}
		public List<TemplateDesigns> GetTemplateDesignss()
		{
			try
			{
				return TemplateDesignsDAO.GetTemplateDesignss();
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		public int AddTemplateDesigns(TemplateDesigns oTemplateDesigns)
		{
			try
			{
				return TemplateDesignsDAO.AddTemplateDesigns(oTemplateDesigns);
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
                return TemplateDesignsDAO.UpdateTemplateDesigns(oTemplateDesigns);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		public List<TemplateDesigns> DeserializeTemplateDesignss(string Path)
		{
			try
			{
				return GenericXmlSerializer<List<TemplateDesigns>>.Deserialize(Path);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public void SerializeTemplateDesignss(string Path, List<TemplateDesigns> TemplateDesignss)
		{
			try
			{
				GenericXmlSerializer<List<TemplateDesigns>>.Serialize(TemplateDesignss, Path);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
