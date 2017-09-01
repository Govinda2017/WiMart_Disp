using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIMARTS.UTIL;
using RedXML;


namespace WIMARTS.UTIL
{
    public enum AppStage
    {
        ApplicationStart,
        PrinterConnectCompletion,
        BeforeJobLoad,
        AfterJobLoad,
        StartJob,
        PauseJob,
        StopJob,               //Exit from running Job 
        ApplicationExit
    }

    public class ControllerStage
    {
        private AppStage _stage;

        public AppStage Stage
        {
            get { return _stage; }
            set { _stage = value; }
        }

        private List<ControllerCommands> _Commands;

        public List<ControllerCommands> Commands
        {
            get { return _Commands; }
            set { _Commands = value; }
        }

        public static List<ControllerStage> LstStages = new List<ControllerStage>();

        public static void Save(List<ControllerStage> LstStage)
        {
        //    GenericXmlSerializer<List<ControllerStage>>.Serialize(LstStage, SettingsPath.CommandInfo);
        }

        public static List<ControllerCommands> GetCommands(AppStage Stage)
        {
            List<ControllerStage> LstStages = new List<ControllerStage>(); ;
            List<ControllerCommands> LstCommands = new List<ControllerCommands>();
            int index = -1;
            LstStages = LoadStages();
            if (LstStages.Count > 0)
            {
                index = (LstStages.FindIndex(delegate(ControllerStage o) { return o._stage == Stage; }));
                if (index > -1)
                    LstCommands = LstStages[index].Commands;
            }
            return LstCommands;
        }
       
        public static List<ControllerStage> LoadStages()
        {
            //if (System.IO.File.Exists(SettingsPath.CommandInfo) && (!string.IsNullOrEmpty(System.IO.File.ReadAllText(SettingsPath.CommandInfo))))
            //{
            //    LstStages = GenericXmlSerializer<List<ControllerStage>>.Deserialize(SettingsPath.CommandInfo);
            //}
            //else
            //    SaveDefaultInfo();
            return LstStages;
        }
        public static int FindIndex4Name(List<ControllerStage> LstStages, AppStage stage)
        {
            int index = -1;
            if(LstStages.Count > 0)
                index = LstStages.FindIndex(delegate(ControllerStage item) { return item.Stage == stage; });
            return index;
        }
        //public static void SaveDefaultInfo()
        //{
        //    ControllerStage St = new ControllerStage();
        //    St.Name = AppStage.ApplicationStart.ToString();
        //    St.Commands = new List<ControllerCommands>();
        //    St.Commands.Add(ControllerCommands.GetDefCmd());
        //    List<ControllerStage> temp = new List<ControllerStage>();
        //    temp.Add(St);
        //    Save(temp);           
        //}

        public static ControllerStage GetStage(string p)
        {
            throw new NotImplementedException();
        }
    }

    public class ControllerCommands
    {
        private string _CmdName;

        public string CmdName
        {
            get { return _CmdName; }
            set { _CmdName = value; }
        }

        private string _Value;

        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        private int _PreSleep;

        public int PreSleep
        {
            get { return _PreSleep; }
            set { _PreSleep = value; }
        }

        private int _PostSleep;

        public int PostSleep
        {
            get { return _PostSleep; }
            set { _PostSleep = value; }
        }

        public static int FindIndex4Name(List<ControllerCommands> LstCommands, string Name)
        {
            int index = -1;
            if (LstCommands.Count > 0)
                index = LstCommands.FindIndex(delegate(ControllerCommands item) { return item.CmdName == Name; });
            return index;
        }

        //public static ControllerCommands GetDefCmd()
        //{
        //    ControllerCommands CMD = new ControllerCommands();
        //    CMD.CmdName = "ProcNew";
        //    CMD.Value = "10000";
        //    CMD.PreSleep = 100;
        //    CMD.PostSleep = 100;
        //    return CMD;
        //}
    }
}
