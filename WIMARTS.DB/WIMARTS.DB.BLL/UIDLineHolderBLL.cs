using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using WIMARTS.DB.BusinessObjects;
using WIMARTS.DB.DAL;

namespace WIMARTS.DB.BLL
{
	public partial class UIDLineHolderBLL
	{
		private UIDLineHolderDAO _UIDLineHolderDAO;

		public UIDLineHolderDAO UIDLineHolderDAO
		{
			get { return _UIDLineHolderDAO; }
			set { _UIDLineHolderDAO = value; }
		}

		public UIDLineHolderBLL()
		{
			UIDLineHolderDAO = new UIDLineHolderDAO();
		}
		
		public UIDLineHolder GetUIDLineHolder(string UnitCode, string LineCode)
		{
			try
			{
				return UIDLineHolderDAO.GetUIDLineHolder(UnitCode,LineCode);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		public int AddUIDLineHolder(UIDLineHolder oUIDLineHolder)
		{
			try
			{
				return UIDLineHolderDAO.AddUIDLineHolder(oUIDLineHolder);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		
		public List<UIDLineHolder> DeserializeUIDLineHolders(string Path)
		{
			try
			{
				return GenericXmlSerializer<List<UIDLineHolder>>.Deserialize(Path);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public void SerializeUIDLineHolders(string Path, List<UIDLineHolder> UIDLineHolders)
		{
			try
			{
				GenericXmlSerializer<List<UIDLineHolder>>.Serialize(UIDLineHolders, Path);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
