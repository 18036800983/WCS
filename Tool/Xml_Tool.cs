using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
using WCS_Model.XML;

namespace Tool
{
    public class Xml_Tool
    {     
        private static string configFilePath = @"MyFile\MyConfig.dll";//配置文件地址

        public static Xml_ConfigRoot xml;//配置文件

        public static XDocument xdoc;
        public static XDocument PLCXdoc;

        public static MySecurity.GTXXmlCrypt ms = new MySecurity.GTXXmlCrypt();
        static Xml_Tool()
        {
            Load();
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        private static void Load()
        {
            try
            {
                ms.Decrypt(configFilePath, "11121112");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            StreamReader fs = null;
            try
            {
                fs = new StreamReader(configFilePath);
                XmlSerializer serializer = new XmlSerializer(typeof(Xml_ConfigRoot));
                xml = (Xml_ConfigRoot)serializer.Deserialize(fs);
                xdoc = XDocument.Load(configFilePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }


        /// <summary>
        /// 序列化
        /// </summary>
        public static void Save()
        {
            StreamWriter fs = null;
            StreamWriter plc_fs = null;
            try
            {
                fs = new StreamWriter(configFilePath);
                XmlSerializer serializer = new XmlSerializer(xml.GetType());
                XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
                xmlns.Add(String.Empty, String.Empty);
                serializer.Serialize(fs, xml, xmlns);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
                if (plc_fs != null)
                    plc_fs.Close();
            }
        }
    }
}
