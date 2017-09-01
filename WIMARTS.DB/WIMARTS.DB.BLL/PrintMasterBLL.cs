using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using WIMARTS.DB.BusinessObjects;
using WIMARTS.DB.DAL;

namespace WIMARTS.DB.BLL
{
	public partial class PrintMasterBLL
	{
		private PrintMasterDAO _PrintMasterDAO;

		public PrintMasterDAO PrintMasterDAO
		{
			get { return _PrintMasterDAO; }
			set { _PrintMasterDAO = value; }
		}

		public PrintMasterBLL()
		{
			PrintMasterDAO = new PrintMasterDAO();
		}
		public List<PrintMaster> GetPrintMasters()
		{
			try
			{
				return PrintMasterDAO.GetPrintMasters();
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		public PrintMaster GetPrintMaster(int PrintID)
		{
			try
			{
				return PrintMasterDAO.GetPrintMaster(PrintID);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		public int AddPrintMaster(PrintMaster oPrintMaster)
		{
			try
			{
				return PrintMasterDAO.AddPrintMaster(oPrintMaster);
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
				return PrintMasterDAO.UpdatePrintMaster(oPrintMaster);
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
				return PrintMasterDAO.RemovePrintMaster(oPrintMaster);
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
				return PrintMasterDAO.RemovePrintMaster(PrintID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<PrintMaster> DeserializePrintMasters(string Path)
		{
			try
			{
				return GenericXmlSerializer<List<PrintMaster>>.Deserialize(Path);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public void SerializePrintMasters(string Path, List<PrintMaster> PrintMasters)
		{
			try
			{
				GenericXmlSerializer<List<PrintMaster>>.Serialize(PrintMasters, Path);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
