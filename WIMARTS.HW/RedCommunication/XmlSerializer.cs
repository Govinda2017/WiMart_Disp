using System;
using System.Collections.Generic;
using System.Text;

namespace Red.xml
{
    public class GenericXmlSerializer<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="Path"></param>
        public static void Serialize(T obj, string Path)
        {
            if (obj != null)
            {
                System.Xml.Serialization.XmlSerializer oXmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                System.IO.StreamWriter oStreamWriter = new System.IO.StreamWriter(Path);
                oXmlSerializer.Serialize(oStreamWriter, obj);
                oStreamWriter.Close();
            }
        }
        public static string Serialize(T obj)
        {
            if (obj != null)
            {
                StringBuilder sb = new StringBuilder();
                System.Xml.Serialization.XmlSerializer oXmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                System.IO.StringWriter oStreamWriter = new System.IO.StringWriter(sb);
                oXmlSerializer.Serialize(oStreamWriter, obj);
                oStreamWriter.Close();
                return sb.ToString();
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static T Deserialize(string Path)
        {
            System.Xml.Serialization.XmlSerializer oXmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            System.IO.StreamReader oStreamReader = new System.IO.StreamReader(Path);
            T obj = (T)oXmlSerializer.Deserialize(oStreamReader);
            oStreamReader.Close();
            return obj;
        }

        public static T DeserializeString(string text)
        {
            System.Xml.Serialization.XmlSerializer oXmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            System.IO.StringReader oStringReader = new System.IO.StringReader(text);
            T obj = (T)oXmlSerializer.Deserialize(oStringReader);
            oStringReader.Close();
            return obj;
        }
    }
}
