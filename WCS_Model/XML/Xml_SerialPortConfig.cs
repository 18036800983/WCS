using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WCS_Model.XML
{
    public class Xml_SerialPortConfig
    {
        [XmlElement("PortName")]
        public string Name { get; set; }

        [XmlElement("Parity")]
        public Parity Parity { get; set; }

        [XmlElement("BaudRate")]
        public int BaudRate { get; set; }

        [XmlElement("DataBits")]
        public int DataBits { get; set; }

        [XmlElement("StopBits")]
        public StopBits StopBits { get; set; }
    }
}
