using System;

namespace RedCommunication
{
    public class DataHelper
    {
        public static byte[] RawToByte(string msg, out int length)
        {
            //msg = msg.Replace(" ", "");
            byte[] comBuffer = new byte[msg.Length];
            length = 0;
            for (int i = 0; i < msg.Length; i++)
            {
                if (msg[i] == '$')//Hex Byte
                {
                    i++;
                    comBuffer[length++] = (byte)Convert.ToByte(msg.Substring(i, 2), 16);
                    i++;
                }
                else
                {
                    comBuffer[length++] = (byte)msg[i];
                }
            }
            return comBuffer;
        }
        public static string RawToString(string msg)
        {
            int length = 0;
            byte[] comBuffer = RawToByte(msg, out length);

            string buff = System.Text.Encoding.Default.GetString(comBuffer, 0, length);

            return buff;
        }
        public static int RawByteLen(string msg)
        {
            //msg = msg.Replace(" ", "");
            int length = 0;
            for (int i = 0; i < msg.Length; i++)
            {
                if (msg[i] == '$')//Hex Byte
                {
                    i++;
                    i++;
                    length++;
                }
                else
                {
                    length++;
                }
            }
            return length;
        }
        public static string RBexorCheckSum(string msg)
        {
            byte csVal = 0;
            for (int i = 0; i < msg.Length; i++)
            {
                if (msg[i] == '$')//Hex Byte
                {
                    i++;
                    byte val = (byte)Convert.ToByte(msg.Substring(i, 2), 16);
                    csVal ^= (val);
                    i++;
                }
                else
                {
                    byte val = (byte)msg[i];
                    csVal ^= val;
                }
            }
            string csum = String.Format("${0:X2}", csVal); // "$" + csVal.ToString();
            return (csum);
        }

        private byte CalcCheckSum(byte[] buffer, int length)
        {
            int chkSUM = 0;
            if (buffer == null || length > buffer.Length)
                throw new System.ArgumentException("Parameter value mismatch", " Invalid Buffer or Length provided");
            //chkSUM = buffer[0] ^ buffer[1];
            for (int i = 0; i < length; i++)
            {
                chkSUM = chkSUM ^ buffer[i];
            }
            return (byte)chkSUM;
        }

    }
}
