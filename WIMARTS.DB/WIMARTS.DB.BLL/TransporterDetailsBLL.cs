using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using WIMARTS.DB.BusinessObjects;
using WIMARTS.DB.DAL;

namespace WIMARTS.DB.BLL
{
    public partial class TransporterDetailsBLL
    {
        private TransporterDetailsDAO _TransporterDetailsDAO;

        public TransporterDetailsDAO TransporterDetailsDAO
        {
            get { return _TransporterDetailsDAO; }
            set { _TransporterDetailsDAO = value; }
        }

        public TransporterDetailsBLL()
        {
            TransporterDetailsDAO = new TransporterDetailsDAO();
        }
        public TransporterDetailsBLL(string providerName, string connectionString)
        {
            TransporterDetailsDAO = new TransporterDetailsDAO(providerName, connectionString);
        }

        public int AddTransporterDetails(TransporterDetails oTransporterDetails)
        {
            try
            {
                return TransporterDetailsDAO.AddTransporterDetails(oTransporterDetails);
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
                return TransporterDetailsDAO.UpdateTransporterDetails(oTransporterDetails);
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
                return TransporterDetailsDAO.AddOrUpdateTransporterDetails(oTransporterDetails);
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
                return TransporterDetailsDAO.RemoveTransporterDetails(oTransporterDetails);
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
                return TransporterDetailsDAO.RemoveTransporterDetails(TransporterID);
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
                return TransporterDetailsDAO.GetTransporterDetails(TransporterID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Boolean IsFieldDataExists(TransporterDetails.enumFlags Fld2Use, string ParamValue)
        {
            try
            {
                return TransporterDetailsDAO.IsFieldDataExists(Fld2Use, ParamValue);
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
                return TransporterDetailsDAO.GetTransporterDetailsList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion LIST

        #region DATASET

        public DataSet GetTransporterDetailsDS(TransporterDetails.enumFlags Fld2Use, string ParamValue)
        {
            try
            {
                return TransporterDetailsDAO.GetTransporterDetailsDS(Fld2Use, ParamValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion DATASET

        #region DATATABLES

        public DataTable GetTransporterDetailsDT(TransporterDetails.enumFlags Fld2Use, string ParamValue)
        {
            try
            {
                return TransporterDetailsDAO.GetTransporterDetailsDT(Fld2Use, ParamValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion DATATABLES

        #region INTERNAL METHODS


        #endregion INTERNAL METHODS

        #region OTHER METHODS

        public List<TransporterDetails> DeserializeTransporterDetailss(string Path)
        {
            try
            {
                return GenericXmlSerializer<List<TransporterDetails>>.Deserialize(Path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SerializeTransporterDetailss(string Path, List<TransporterDetails> TransporterDetailss)
        {
            try
            {
                GenericXmlSerializer<List<TransporterDetails>>.Serialize(TransporterDetailss, Path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion OTHER METHODS

    }
}
