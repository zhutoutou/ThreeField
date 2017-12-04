using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ZIT.ThreeField.Utility
{
    public class XMLHelper
    {
        public static string Serializer<T>(T obj)
        {
            using (MemoryStream Stream = new MemoryStream())
            {
                //创建序列化对象  
                XmlSerializer xml = new XmlSerializer(typeof(T));
                try
                {
                    //序列化对象  
                    xml.Serialize(Stream, obj);
                }
                catch (InvalidOperationException)
                {
                    throw;
                }
                Stream.Position = 0;
                StreamReader sr = new StreamReader(Stream);
                string str = sr.ReadToEnd();
                //str = SequenceFormat(str, typeof(T));
                return str;
            }
        }

        public static T Deserialize<T>(string xml)
        {
            try
            {
                using (StringReader sr = new StringReader(xml))
                {
                    XmlSerializer xmldes = new XmlSerializer(typeof(T));
                    return (T)xmldes.Deserialize(sr);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static T DeserializeFile<T>(string path)
        {
            object obj = null;
            try
            {
                if (!File.Exists(path)) return (T)obj;

                using (Stream tr = new FileStream(path, FileMode.Open))
                //using (StringReader sr = new StringReader())
                {
                    XmlSerializer xmldes = new XmlSerializer(typeof(T));
                    return (T)xmldes.Deserialize(tr);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}