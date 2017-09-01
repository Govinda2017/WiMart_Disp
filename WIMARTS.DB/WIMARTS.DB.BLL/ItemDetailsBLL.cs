using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using WIMARTS.DB.BusinessObjects;
using WIMARTS.DB.DAL;

namespace WIMARTS.DB.BLL
{
	public partial class ItemDetailsBLL
	{
		private ItemDetailsDAO _ItemDetailsDAO;

		public ItemDetailsDAO ItemDetailsDAO
		{
			get { return _ItemDetailsDAO; }
			set { _ItemDetailsDAO = value; }
		}

		public ItemDetailsBLL()
		{
			ItemDetailsDAO = new ItemDetailsDAO();
		}
		public List<ItemDetails> GetItemDetailss()
		{
			try
			{
				return ItemDetailsDAO.GetItemDetailss();
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		public ItemDetails GetItemDetails(int PrintDetailsID)
		{
			try
			{
				return ItemDetailsDAO.GetItemDetails(PrintDetailsID);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		public int AddItemDetails(ItemDetails oItemDetails)
		{
			try
			{
				return ItemDetailsDAO.AddItemDetails(oItemDetails);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int UpdateItemDetails(ItemDetails oItemDetails)
		{
			try
			{
				return ItemDetailsDAO.UpdateItemDetails(oItemDetails);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int RemoveItemDetails(ItemDetails oItemDetails)
		{
			try
			{
				return ItemDetailsDAO.RemoveItemDetails(oItemDetails);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public int RemoveItemDetails(int PrintDetailsID)
		{
			try
			{
				return ItemDetailsDAO.RemoveItemDetails(PrintDetailsID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public PrintMaster GetPrintMasterOfItemDetails(int PrintID)
		{
			try
			{
				return ItemDetailsDAO.GetPrintMasterOfItemDetails(PrintID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public InspectionMaster GetInspectionMasterOfItemDetails(int InspID)
		{
			try
			{
				return ItemDetailsDAO.GetInspectionMasterOfItemDetails(InspID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public DispatchMaster GetDispatchMasterOfItemDetails(int DispMasterID)
		{
			try
			{
				return ItemDetailsDAO.GetDispatchMasterOfItemDetails(DispMasterID);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<ItemDetails> DeserializeItemDetailss(string Path)
		{
			try
			{
				return GenericXmlSerializer<List<ItemDetails>>.Deserialize(Path);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public void SerializeItemDetailss(string Path, List<ItemDetails> ItemDetailss)
		{
			try
			{
				GenericXmlSerializer<List<ItemDetails>>.Serialize(ItemDetailss, Path);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
