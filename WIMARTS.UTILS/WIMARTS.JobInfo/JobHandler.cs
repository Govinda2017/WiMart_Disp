using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iPRINT.UTIL;
using iPRINT.DB.BusinessObjects;
using System.Xml.Serialization;
using System.Diagnostics;
using iPRINT.DB.HELPER;
using iPRINT.DB.BLL;
using iPRINT.UTIL.SystemIntegrity;
//using iPRINT.CODEMGR;

namespace iPRINT.PrintJob
{
    public enum FieldsToSet
    {
        Both,
        Fixed,
        Variable
    }
    public class JobResult
    {
        #region JobResult

        #region PROPS

        private decimal _printerID;
        public decimal printerID
        {
            get { return _printerID; }
        }

        internal long _TprintedQty;
        public long TPrintedQty
        {
            get { return _TprintedQty; }

        }

       private int _qCount;
       public int qCount 
       { 
           get { return _qCount; } 
           set { _qCount = value; } 
       }

        #endregion END_PROPS

        private Queue<List<AITagVal>> _printedQueue = null;
        DbHelper _dbHelper = null;
        public JobResult()
        {
            _printedQueue = new Queue<List<AITagVal>>();
            _dbHelper = new DbHelper();
         }

        #endregion END_JobResult

        public void LoadPrintedQty(JobInfo jbInfo)
        {
          //  _printerID = jbInfo.jobDtls.PrinterID;
          
        }

        /// <summary>
        /// Printed queue stores variable data list for each print.
        /// one printer can contains more than one type of variable data.
        /// So here is taken list of AItagVal..
        /// </summary>
        /// <param name="data"></param>
        /// 

     
        public void AddQueue(List<TemplateFields> VariableData)
        {
            bool hasAdded = false;
            List<string> addedSources = new List<string>();
            List<AITagVal> VDdata = new List<AITagVal>();
              
            foreach (TemplateFields item in VariableData)
            {
                if (TemplateFields.isIdCode(item.FldType)) 
                    continue;
                if (isExists(addedSources, item.DataSource, item.DataField))
                    continue;

                if (item.FldType == TemplateFields.eFldType.IDFLDText)
                {
                    //check if HR format exists
                    int i = VariableData.FindIndex(fti => fti.DataSource == item.DataSource
                                                                  && fti.DataField == item.DataField
                                                                  && fti.FldType != TemplateFields.eFldType.IDFLDText);
                    if (i > -1)
                        continue;
                }
                
                string data = Convert.ToString(item.Data);
                if (string.IsNullOrEmpty(data) == false)
                {
                    addedSources.Add(item.DataSource + "#" + item.DataField);
                    AITagVal ai = new AITagVal();
                    ai.FldName = item.FldName;
                    ai.Identifier = Convert.ToString(item.DataField);
                    ai.Value = data;
                    VDdata.Add(ai);
                    hasAdded = true;
                }
            }




            if (hasAdded)
                _printedQueue.Enqueue(VDdata);
            qCount = _printedQueue.Count;
        }
        private bool isExists(List<string> addedSources, string SourcefldName, int? configID)
        {
            foreach (string item in addedSources)
            {
                string[] split=item.Split('#');
                if (split[0] == SourcefldName && split[1] == Convert.ToString(configID))
                    return true;
            }
            return false;
        }
       

        internal List<AITagVal> Dequeue()
        {
            if (_printedQueue.Count > 0)
            {
                qCount = _printedQueue.Count - 1;
                return _printedQueue.Dequeue();
            }
            else
                return null;
           
        }
    }
    public class JobHandler
    {
        #region JobHandler
       
        private Dictionary<string, IRedCODEMGR> m_dVdCM = new Dictionary<string, IRedCODEMGR>();
        public IRedCODEMGR ired;
        private DbHelper m_DbHelper = new DbHelper();
        private UserMaster m_UserLoggedIn;
        public JobResult m_jobResult;
        public JobInfo m_jobInfo;
       
        public JobHandler(UserMaster userLoggedIn, JobInfo jobInfo)
        {
            m_UserLoggedIn = userLoggedIn;
            m_jobInfo = jobInfo;
            m_jobResult = new JobResult();
        }
        public JobHandler()
        {
        
        }
        public void SetJobHandler(List<TemplateFields> vDataTemplate, bool isLoadForPrinting)
        {
            try
            {
                //if (isLoadForPrinting)
                //    m_jobResult.LoadPrintedQty(m_jobInfo);

                foreach (TemplateFields item in vDataTemplate)
                {
                    if (item.IsVariable == false)
                        continue;


                    ////check if Variable data HR field is available Ow fill variable data for IDTExtField..
                    /////If available then IDField Text and HR Fields will be same....
                    if (item.FldType == TemplateFields.eFldType.IDFLDText)
                    {
                        int i = vDataTemplate.FindIndex(fti => fti.DataSource == item.DataSource
                                                               && fti.DataField == item.DataField
                                                               && fti.FldType != TemplateFields.eFldType.IDFLDText);

                        if (i > 0) ///If HR Text for this Source available then no need to fill Cm for IdFieldText..
                            ///Because both will have same data..
                            continue;
                    }

                    VariableDataConfig lconfig = VariableDataConfig.GetVDConfig(item.DataSource, item.DataField);
                    if (lconfig != null)
                    {
                        if (lconfig.VariableDataInfo.vdSourceType == VdSourceType.SerialNo)
                        {
                            lconfig.serialConfig.number = m_jobResult.TPrintedQty;
                        }
                        if (lconfig.VariableDataInfo.vdSourceType == VdSourceType.ReadFromHW)
                            _hasDataFromHW = true;



                        //for init mgr..If mgr is only required for test Uid then no need to init unmanged resources..
                        //To check if codeMgr exists for current key
                        string key = CreateKey(item);
                        if (getCM(key) != null)
                            continue;

                        IRedCODEMGR iCM = iPRINT.CODEMGR.IRedCODEMGRHandler.LoadAssambly(lconfig);
                        iCM.TestMode = !isLoadForPrinting;
                        iCM.Init(lconfig, m_jobInfo.Quantity);//- m_jobResult._TprintedQty);                  
                        if (_hasDataFromHW)
                        {
                            iCM.OnDataReady += new EventHandler(iCM_OnDataReady);
                        }

                        m_dVdCM.Add(key, iCM);
                        ired = iCM;
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}:{1},{2}", DateTime.Now, ex.Message, ex.StackTrace);
            }
        }
      
        #endregion END_JobHandler
         
        private IRedCODEMGR getCM(string key)
        {
            IRedCODEMGR ired;
            m_dVdCM.TryGetValue(key, out ired);
            return ired;
        }  

        private string CreateKey(TemplateFields tf)
        {
            // return tf.FldName;// tf.SourceFldName + "_" + tf.FldName;
            return tf.DataSource + "_" + tf.DataField;
        }

        #region HW_Data_Interface_Hanlder
         
        private bool _hasDataFromHW;
        public bool hasDataFromHW
        {
            get
            {
                return _hasDataFromHW;
            }
        } 
        public bool isDataready()
        {
            bool isDataReady = true;

            if (hasDataFromHW)
            {
                foreach (var item in m_dVdCM)
                {
                    IRedCODEMGR iredCodeMgr = (IRedCODEMGR)item.Value;
                    //isDataReady &= iredCodeMgr.CodesRemaining > 0 ? true : false;                    
                    isDataReady = true;
                }
            }
            return isDataReady;
        }  
        private void iCM_OnDataReady(object ob,EventArgs e)
        {
            if (onNotifyDataReady != null)
                onNotifyDataReady();//m_jobInfo.jobDtls.PrinterName
        }
       
        #endregion END_HW_Data_Interface_Hanlder

        #region VariableCodeManager
    
        public bool FetchVariableData(decimal qty, out List<string> inCompleteUidFldList)
        {
            bool hasAllUidFetched = true;
            inCompleteUidFldList = new List<string>();
            
            foreach (var item in m_dVdCM)
            {

                if (item.Value == null)
                    return false;
                bool hasFetched = item.Value.FetchCodes();
                
                if (hasFetched == false)
                    inCompleteUidFldList.Add(item.Key.Split('_')[0]);

                hasAllUidFetched &= hasFetched;
            }

            //After fetch Uid...set testmode as true...It will reset at online system
            return hasAllUidFetched;
        }
      
        public object GetVariableData(TemplateFields tf)
        {
            string uid = string.Empty;
            string key = CreateKey(tf);
            IRedCODEMGR iCM = getCM(key);

            if (iCM == null)
                return string.Empty;

            if (iCM.isValidSourceType(tf.DataSource))
            {
                if (iCM.CodesRemaining > 0 || iCM.TestMode)
                {
                    if (iCM.VdConfig.VariableDataInfo.vdSourceType == VdSourceType.RedCSVGen)
                    {
                        uid = Convert.ToString(iCM.GetNextCode(tf.FldName));
                    }
                    else
                    {
                        uid = Convert.ToString(iCM.GetNextCode());
                    }
                    ////
               
                }
            }
            return uid;
        }
  
     
        private void UpdateiCMvdStatus(List<TemplateFields> lst)
        {
            foreach (TemplateFields item in lst)
            {
                if (item.IsVariable == false || TemplateFields.isIdCode(item.FldType))
                    continue;
                string key = CreateKey(item);
                IRedCODEMGR iCM = getCM(key);
                try
                {
                    iCM.UpdateStatus(item.Data);
                }
                catch (Exception ex)
                {
                    Trace.TraceError("{0}:{1},{2}", DateTime.Now, ex.Message, ex.StackTrace);
                }
            }
        }
        public void ReleaseObject()
        {
            foreach (var item in m_dVdCM)
            {
                if (item.Value == null)
                    return;
                item.Value.ReleaseObjects();
            }
        }
        public void SetVdCodeonline()
        {
            foreach (var item in m_dVdCM)
            {
                if (item.Value != null)
                    item.Value.TestMode = false;
            }
        }
        #endregion END_VariableCodeManager

        #region PRINT_JOB_OPERATIONS
        /// <summary>
        /// Maintain Printed Qty and UpdateResult at DB..
        /// </summary>
        /// <param name="CurjobRslt"></param>
       // public void ValidateData(List<TemplateFields> lst)
        public string  ValidateData(List<TemplateFields> lst)
        {
            string PrintMode = null;
            try
            {
                m_jobResult._TprintedQty++;
                InsertPrintDetails(lst);
                UpdateiCMvdStatus(lst);
              
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0},{1}{2}", DateTime.Now.ToString(), ex.Message, ex.StackTrace);
            }
            return PrintMode;
            
        }

        internal delegate void SetInsertPrintDetails(List<TemplateFields> lst);

        private void InsertPrintDetails(List<TemplateFields> lst)
        {
            try
            {

                ItemDetails prnt = new ItemDetails();
                prnt.PrintID = Convert.ToInt32(m_jobInfo.JobID);
                prnt.InspID = null;
                prnt.DispID = null;
                prnt.ProdCode = m_jobInfo.ProdCode;
                prnt.BatchCode = m_jobInfo.BatchName;
                prnt.UIDCode = Convert.ToString(lst.Find(x => x.FldName == "VFLD01").Data);
                prnt.LUDate = DateTime.Now;
                prnt.CreatedDate = DateTime.Now;
                prnt.InspectedDate = null;
                prnt.DispatchedDate = null;
                prnt.Status = Convert.ToInt32(BLLManager.DetailsStatus.Created);
                m_DbHelper.DBManager.ItemDetailsBLL.AddItemDetails(prnt);
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0},{1}{2}", DateTime.Now.ToString(), ex.Message, ex.StackTrace);
            }
        }      

        
        public void AddQueue(List<TemplateFields> lstPrinterDataFld)
        {
            m_jobResult.AddQueue(lstPrinterDataFld.FindAll(item => item.IsVariable == true));
        }
        public bool IsBatchCompleted()
        {
            bool hasCompleted = false;          
                hasCompleted = (QtyToPrint < 0 || QtyToPrint == 0);

            return hasCompleted;
        }

        public decimal QtyToPrint
        {
            get
            {
                decimal totalJobQty = m_jobInfo.Quantity;
                decimal PrintedQty = m_jobResult.TPrintedQty;

                decimal qtyToPrint = totalJobQty - PrintedQty;
                return qtyToPrint;
            }
        }
        #endregion END_PRINT_JOB_OPERATIONS

        #region SetValueTemplateOperation
        List<List<TemplateFields>> lstTemplates = new List<List<TemplateFields>>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="LstPrinterDataFld"></param>
        /// <param name="printerName"></param>
        /// <param name="FieldsToSet">For only fixed data pass Fixed ,For only variable data pass Variable,For both data set (variable/Fixed) pass Both.</param>
        /// 
        public List<TemplateFields> SetFieldValues(List<TemplateFields> LstPrinterDataFld, FieldsToSet fldToSet)
        {
            bool isVariable = fldToSet == FieldsToSet.Variable;
            if (fldToSet != FieldsToSet.Both)
                LstPrinterDataFld = LstPrinterDataFld.FindAll(item => item.IsVariable == isVariable || TemplateFields.isIdCode(item.FldType));


            try
            {
                //To clear all variable data
                foreach (TemplateFields item in LstPrinterDataFld)
                {
                    if (TemplateFields.isIdCode(item.FldType) == true)
                        continue;
                    if (item.IsVariable)
                    {
                        item.Data = null;
                    }
                }

                //To set values to Non Id Code Type fields.           
                foreach (TemplateFields item in LstPrinterDataFld)
                {
                    if (TemplateFields.isIdCode(item.FldType) == true)
                        continue;
                    if (item.IsVariable)
                    {
                        TemplateFields tf = null;

                        if (VariableDataInfo.isMultiDataSource(item.DataSource) == false)
                        {
                            tf = LstPrinterDataFld.Find(tfi => tfi.DataSource == item.DataSource && tfi.DataField == item.DataField && tfi != item);
                        }

                        if (tf != null && tf.Data != null)
                        {
                            item.Data = tf.Data;
                            continue;
                        }
                    }
                    item.Data = GetNonIDValue(item);
                }


                ///Once all IdFld type values set...ID code will set..
                //To set Id fld values...Id_fld values will bind from Fldname of Non_Id_Field of fldtype IDFLDText/string/Date

                foreach (TemplateFields item in LstPrinterDataFld)
                {
                    if (TemplateFields.isIdCode(item.FldType) == false)
                        continue;
                    List<AITagVal> lst = (List<AITagVal>)item.Data;
                   foreach (AITagVal id in lst)
                    {
                       
                        object obVal;
                        bool isvariableData;

                        obVal = GetIDFldValue(LstPrinterDataFld, id.FldName, out isvariableData);

                        if ((isvariableData || fldToSet != FieldsToSet.Variable) == false)
                            continue;
                        id.Value = Convert.ToString(obVal);      
                    }
                   item.Data = lst;
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0},{1}{2}", DateTime.Now.ToString(), ex.Message, ex.StackTrace);
            }
            return LstPrinterDataFld;
        }
  
        private object GetNonIDValue(TemplateFields tf)
        {
            object obVal=null;
            if (string.IsNullOrEmpty(tf.DataSource) == false)
            {               
                if (tf.IsVariable)
                {
                    obVal = GetVariableData(tf);                   
                }
                else
                    obVal = PropHandler.GetPropertyValue(m_jobInfo, tf.DataSource);
                tf.Data = obVal;
                obVal = TemplateFields.FormatData(tf.FldType, tf.Data, tf.DataFormat, tf.Length);
            }
            System.Reflection.PropertyInfo propInfo = typeof(JobInfo).GetProperty(tf.FldName);
            if (propInfo != null && tf.IsVariable==true)
            {
                if (propInfo.PropertyType.Equals(typeof(Decimal)) == true)
                    obVal = Convert.ToDecimal(obVal);
                propInfo.SetValue(m_jobInfo, obVal, null);
            }

            return obVal;
        }

        private object GetIDFldValue(List<TemplateFields> LstPrinterDataFld, string fldName, out bool isvariableFld)
        {
            isvariableFld = false;
            object vdValue = null;

            TemplateFields tf = LstPrinterDataFld.Find(f => f.DataSource == fldName);

            //if in case user has set printer filed name in Id format .
            //this is the case if for e.g user want diff dataformat for id field than text field (like data formats) in that case user can add another Id type value template field.
            //in this case source fields are same but dataformats are different.to idetify template user can add printer field name in id data format.
            //for this case user should add ID fild template..
            if (tf == null)
                tf = LstPrinterDataFld.Find(f => f.FldName == fldName);

            if (tf != null)
            {
                vdValue = tf.Data;
                isvariableFld = tf.IsVariable;
            }

            return vdValue;
        }

        public void RemoveIncorrectVariableData(List<TemplateFields> tfList)
        {
            string uid = string.Empty;

            foreach (TemplateFields tf in tfList)
            {

                string key = CreateKey(tf);
                IRedCODEMGR iCM = getCM(key);

                if (iCM == null)
                    continue;// return string.Empty;

                if (iCM.isValidSourceType(tf.DataSource))
                {
                    if (iCM.CodesRemaining > 0 || iCM.TestMode)
                    {
                        if (iCM.VdConfig.VariableDataInfo.vdSourceType == VdSourceType.ReadFromHW)
                        {
                            uid = Convert.ToString(iCM.GetNextCode());                            
                        }
                    }
                }
            }
            //return uid;
        }

        #endregion END_SetValueTemplateOperation

        public delegate void NotifyDataReadyHandler();
        public event NotifyDataReadyHandler onNotifyDataReady;

        public delegate void NotifyVariableDataInsertion(decimal PrinterID, ItemDetails pvd);
        public static event NotifyVariableDataInsertion OnVeriableDataInsertion;
    }

}
