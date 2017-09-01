using System;
using System.Collections;
using System.Collections.Generic;
using WIMARTS.UTIL;
using WIMARTS.UTIL.SystemIntegrity;
using System.Reflection;
using System.Linq;
namespace WIMARTS.CODEMGR
{ 
    //redtcp,alphajet,
    public interface IRedCODEMGR
    {
        //event PrintedUidStatusHandler UpdateprintedUid;
         
        decimal MaxBatchNos { get;}
        bool TestMode { get; set; }
        int CodesGenerated { get; }
        int CodesRemaining { get; }
        VariableDataConfig VdConfig { get; }
        void Init(VariableDataConfig config,decimal batchQty);

        /// <summary>
        /// It should be of type VdSourceType enum,But to make functionality more dynamic..removed this dependancy 
        /// </summary>
        /// <param name="sourceType"></param>
        /// <returns></returns>
        bool isValidSourceType(string sourceType); 

        /// <summary>
        /// No of uids to be fetch==batchQty (param of init)
        /// </summary>
        /// <returns></returns>
        bool FetchCodes(); 
       
        object GetNextCode();

        object GetNextCode(string fldName);
        /// <summary>
        /// Register event PrintedUidStatusHandler and to add callback as this method
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        /// 
        bool UpdateStatus(object code);
        void ReleaseObjects();

        event EventHandler OnDataReady;
    } 

    public delegate bool PrintedUidStatusHandler(string uid);
    public delegate void ReleaseObjectsHandler();

    public class IRedCODEMGRHandler
    {  
        //Assembly a = Assembly.Load(config.VeriableDataInfo.SourceDll);
        // Type myType = a.GetType(myType.FullName);
        // MethodInfo mymethod = myType.GetMethod("GetNextUID");
        // Create an instance.
        //Object obj = Activator.CreateInstance(myType, "129.168.1.1", 223);
        // Execute the method.
        //mymethod.Invoke(obj, null);

        public static IRedCODEMGR LoadAssambly(WIMARTS.UTIL.VariableDataConfig config)
        {
            // Use the file name to load the assembly into the current 
            // application domain.
            Assembly a = Assembly.Load(config.VariableDataInfo.SourceDll);
            if (a == null)
                return null ;
            // Get the type to use.
            Type[] t = a.GetTypes();
            if (t == null)
               return null;

            Type myType = t.First(itm => itm.Name == config.VariableDataInfo.vdSourceType.ToString());
            //Type myType = a.GetType(config.VeriableDataInfo.SourceDll + "." + config.VeriableDataInfo.SourceType);
            if (myType == null)
                return null;
             
            Object obj = Activator.CreateInstance(myType); 
            IRedCODEMGR ired = (IRedCODEMGR)obj; 
            return ired;
        }

        public static IRedCODEMGR LoadAssambly(WIMARTS.UTIL.VariableDataInfo  vInfo)
        {
            // Use the file name to load the assembly into the current 
            // application domain.
            Assembly a = Assembly.Load(vInfo.SourceDll);
            if (a == null)
                return null;
            // Get the type to use.
            Type[] t = a.GetTypes();
            if (t == null)
                return null;

            Type myType = t.First(itm => itm.Name == vInfo.vdSourceType.ToString());
            //Type myType = a.GetType(config.VeriableDataInfo.SourceDll + "." + config.VeriableDataInfo.SourceType);
            if (myType == null)
                return null;

            Object obj = Activator.CreateInstance(myType);
            IRedCODEMGR ired = (IRedCODEMGR)obj;
            return ired;
        }

    }
}
