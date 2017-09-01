using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using WIMARTS.DB.BusinessObjects;
using WIMARTS.DB.DAL;

namespace WIMARTS.DB.BLL
{
	public partial class ProductMasterBLL
	{
		private ProductMasterDAO _ProductMasterDAO;

		public ProductMasterDAO ProductMasterDAO
		{
			get { return _ProductMasterDAO; }
			set { _ProductMasterDAO = value; }
		}

		public ProductMasterBLL()
		{
			ProductMasterDAO = new ProductMasterDAO();
		}
		public List<ProductMaster> GetProductMasters()
		{
			try
			{
				return ProductMasterDAO.GetProductMasters();
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		public ProductMaster GetProductMaster(int ProdID)
		{
			try
			{
				return ProductMasterDAO.GetProductMaster(ProdID);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		public int AddProductMaster(ProductMaster oProductMaster)
		{
			try
			{
				return ProductMasterDAO.AddProductMaster(oProductMaster);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int UpdateProductMaster(ProductMaster oProductMaster)
		{
			try
			{
				return ProductMasterDAO.UpdateProductMaster(oProductMaster);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int RemoveProductMaster(ProductMaster oProductMaster)
		{
			try
			{
				return ProductMasterDAO.RemoveProductMaster(oProductMaster);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int RemoveProductMaster(int ProdID)
		{
			try
			{
				return ProductMasterDAO.RemoveProductMaster(ProdID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ProductMaster> DeserializeProductMasters(string Path)
		{
			try
			{
				return GenericXmlSerializer<List<ProductMaster>>.Deserialize(Path);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public void SerializeProductMasters(string Path, List<ProductMaster> ProductMasters)
		{
			try
			{
				GenericXmlSerializer<List<ProductMaster>>.Serialize(ProductMasters, Path);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
