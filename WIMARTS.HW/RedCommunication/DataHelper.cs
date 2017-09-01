using System;
using System.Text;
using System.Diagnostics;

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

            string buff = System.Text.Encoding.UTF8.GetString(comBuffer, 0, length);

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
        public static string RBexorCheckSumTermStyle(string msg)
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
            string csum = String.Format("{0:X2}", csVal); // "$" + csVal.ToString();
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

        public static string HexAsciiConvert(string hex)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= hex.Length - 2; i += 2)
            {
                sb.Append(Convert.ToString(Convert.ToChar(Int32.Parse(hex.Substring(i, 2),
                    System.Globalization.NumberStyles.HexNumber))));
            }
            return sb.ToString();
        }
        public static string DisplaybleHexValues(string strData)
        {
            StringBuilder sBuffer = new StringBuilder();
            for (int i = 0; i < strData.Length; i++)
            {
                sBuffer.Append(" 0x" + Convert.ToInt32(strData[i]).ToString("x").ToUpper());
            }
            string hex = sBuffer.ToString();

            //hex = strData.Select(c => ((int)c).ToString("X")).Aggregate((a, s) => a + s);
            //hex = string.Join(string.Empty, strData.Select(c => ((int)c).ToString("X")).ToArray());

            return hex;
        }
        public static string DisplaybleAsciiValues(string strData)
        {
            StringBuilder sBuffer = new StringBuilder();
            for (int i = 0; i < strData.Length; i++)
            {
                sBuffer.Append(" " + Convert.ToInt32(strData[i]).ToString());
            }
            string hex = sBuffer.ToString();

            //hex = strData.Select(c => ((int)c).ToString("X")).Aggregate((a, s) => a + s);
            //hex = string.Join(string.Empty, strData.Select(c => ((int)c).ToString("X")).ToArray());

            return hex;
        }
        public static string DisplaybleTextValues(string strData)
        {
            StringBuilder sBuffer = new StringBuilder();
            for (int i = 0; i < strData.Length; i++)
            {
                if (strData[i] != '\0')
                    sBuffer.Append((strData[i]).ToString());
            }
            string buff = sBuffer.ToString();

            //hex = strData.Select(c => ((int)c).ToString("X")).Aggregate((a, s) => a + s);
            //hex = string.Join(string.Empty, strData.Select(c => ((int)c).ToString("X")).ToArray());

            return buff;
        }
        public static string TermMode2RawData(string msg, out int length)
        {
            //msg = msg.Replace(" ", "");
            string rawBuffer = string.Empty;
            length = 0;
            for (int i = 0; i < msg.Length; i++)
            {
                if (msg[i] == '$')//Hex Byte
                {
                    i++;
                    rawBuffer += HexAsciiConvert(msg.Substring(i, 2));
                    length++;
                    i++;
                }
                else
                {
                    rawBuffer += msg[i];
                    length++;
                }
            }
            return rawBuffer;
        }

        public static bool TryConvertFromHexStr(string hexChars, ref int Value)
        {
            try
            {
                Value = Int32.Parse(hexChars, System.Globalization.NumberStyles.HexNumber);
                return true;
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0},{1}{2}", DateTime.Now.ToString(), ex.Message, ex.StackTrace);
                return false;
            }           
        }
        public static bool TryConvertFromHexStr(string hexChars, ref long Value)
        {
            try
            {
                // Value = Int64.Parse(hexChars, System.Globalization.NumberStyles.HexNumber);
                Value = long.Parse(hexChars, System.Globalization.NumberStyles.HexNumber);
                return true;
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0},{1}{2}", DateTime.Now.ToString(), ex.Message, ex.StackTrace);
                return false;
            }
        }
        public static bool TryConvertFromHexStr(string hexChars, ref long Value, bool SwapMSBLSB)
        {
            try
            {
                //Swap MSB&LSB
                if (SwapMSBLSB == true)
                {
                    string swapedHexChars = string.Empty;

                    for (int k = 0; k < hexChars.Length; k += 4)
                    {
                        swapedHexChars = swapedHexChars.Insert(0, (hexChars.Substring(k, hexChars.Length - k > 4 ? 4 : hexChars.Length - k)));
                    }
                    // Value = Int64.Parse(hexChars, System.Globalization.NumberStyles.HexNumber);
                    Value = long.Parse(swapedHexChars, System.Globalization.NumberStyles.HexNumber);
                }
                else
                {
                    Value = long.Parse(hexChars, System.Globalization.NumberStyles.HexNumber);
                }
                return true;
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0},{1}{2}", DateTime.Now.ToString(), ex.Message, ex.StackTrace);
                return false;
            }
        }
        
        public static bool TryConvertFromBuffer(string strData, ref Int16 Value)
        {
            Int16 value = 0;
            try
            {
                if (string.IsNullOrEmpty(strData) == true || strData.Length > 2)
                    return false;

                byte[] array = new byte[2];
                for (int i = 0; i < strData.Length; i++)
                {
                    array[i] = (byte)strData[i];
                }

                value = BitConverter.ToInt16(array, 0);
                //value = array[0] | (array[1] << 8);

                Value = value;
                return true;
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0},{1}{2}", DateTime.Now.ToString(), ex.Message, ex.StackTrace);
                return false;
            }
        }
        public static bool TryConvertFromBuffer(string strData, ref UInt16 Value)
        {
            UInt16 value = 0;
            try
            {
                if (string.IsNullOrEmpty(strData) == true || strData.Length > 2)
                    return false;

                byte[] array = new byte[2];
                for (int i = 0; i < strData.Length; i++)
                {
                    array[i] = (byte)strData[i];
                }

                value = BitConverter.ToUInt16(array, 0);
                //value = array[0] | (array[1] << 8);

                Value = value;
                return true;
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0},{1}{2}", DateTime.Now.ToString(), ex.Message, ex.StackTrace);
                return false;
            }
        }
        public static bool TryConvertFromBuffer(string strData, ref Int32 Value)
        {
            Int32 value = 0;
            try
            {
                if (string.IsNullOrEmpty(strData) == true || strData.Length != 4)
                    return false;

                byte[] array = new byte[4];
                for (int i = 0; i < strData.Length; i++)
                {
                    array[i] = (byte)strData[i];
                }

                value = BitConverter.ToInt32(array, 0);
                //value = array[0] | (array[1] << 8);

                Value = value;
                return true;
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0},{1}{2}", DateTime.Now.ToString(), ex.Message, ex.StackTrace);
                return false;
            }
        }

        public static string TryConvert2Buffer(Int16 value)
        {
            byte[] biteBuff = BitConverter.GetBytes(value);
            string buff = System.Text.Encoding.Default.GetString(biteBuff, 0, biteBuff.Length);

            return buff;
        }

        public static int GetPrintableLength(string buffer, bool trimStart, bool trimEnd)
        {
            int length = 0;
            if (string.IsNullOrEmpty(buffer) == true)
                return length;

            string newBuff = buffer.Replace("\0", " ");

            if (trimStart == true && trimEnd == true)
                length = newBuff.Trim().Length;
            else if (trimStart == true )
                length = newBuff.TrimStart().Length;
            else if (trimEnd == true)
                length = newBuff.TrimEnd().Length;

            return length;
        }
    }
}
