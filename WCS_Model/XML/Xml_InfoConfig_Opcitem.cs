using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WCS_Model.XML
{
    [XmlRoot("opcitem"),
    CollectionFormInfo("控制字配置", 550, 550)]
    public class Xml_InfoConfig_Opcitem
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("addr"), OPCAddress("", true)]
        public string Addr { get; set; }

        [XmlAttribute("backaddr"), OPCAddress("", true)]
        public string BackAddr { get; set; }

        [XmlAttribute("AddrType")]
        public string AddrType { get; set; }
    }
}
