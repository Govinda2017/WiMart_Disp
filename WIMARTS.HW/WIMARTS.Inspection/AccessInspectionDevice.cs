using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WIMARTS.INSPECTION
{
    public class AccessInspectionDevice
    {
        public static List<string> GetDevices()
        {
            List<string> devices = new List<string>();
            devices.Add("Matrix");
            devices.Add("Omron_FQ2");
            devices.Add("Baumer");
            devices.Add("Scanner");
            return devices;
        }

        public static IRedInspection LoadIredInspection(string deviceName, string deviceAddress, int devicePort)//, PictureBox imgDispCtrl)
        {
            IRedInspection ireInspection=null;
            switch (deviceName)
            {
                case "Matrix":
                 //   ireInspection = new MatrixVision();
                    break;
                case "Omron_FQ2":
                    ireInspection = new Omron_FQ2(deviceAddress,devicePort);
                    break;
                case "Baumer":
                    ireInspection = new Baumer(deviceAddress, devicePort);
                    break;
                case "Scanner":
                    ireInspection = new Scanner(deviceAddress);
                    break;
            }
            return ireInspection;
        }

        
    }
}
