using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WCS_Model.XML
{
    [XmlRoot("line"),
            CollectionFormInfo("产线配置", 500, 500)]
    public class Xml_InfoConfig
    {
        [XmlAttribute("name"),
         Category("Line设置"),
         DisplayName("名称"),
         Description("名称"),
         Browsable(true),
         ReadOnly(false)]
        public string Name { get; set; } = "Line";

        [XmlAttribute("index"),
       Category("PLC索引"),
       DisplayName("PLC索引"),
       Description("PLC索引"),
       Browsable(true),
       ReadOnly(false)]
        public int Index { get; set; }

        [XmlAttribute("plcIP"),
         Category("PLC设置"),
         DisplayName("IP"),
         Description("IP地址"),
         Browsable(true),
         ReadOnly(false)]
        public string IP { get; set; }

        [XmlAttribute("updateRate"),
         Category("PLC设置"),
         DisplayName("PLC监控更新间隔（ms）"),
         Description("PLC监控更新间隔（ms）"),
         Browsable(true),
         ReadOnly(false)]
        public int UpdateRate { get; set; }

        [XmlAttribute("threaCount"),
         Category("PLC设置"),
         DisplayName("PLC监控线程个数"),
         Description("PLC监控线程个数"),
         Browsable(true),
         ReadOnly(false)]
        public int ThreaCount { get; set; }

        [XmlAttribute("heartBeatAddr"),
         Category("PLC设置"),
         DisplayName("PLC心跳地址"),
         Description("PLC心跳地址"),
         Browsable(true),
         ReadOnly(false)]

        public string HeartBeatAddr { get; set; }

        [XmlAttribute("plcSlot"),
       Category("PLC设置"),
       DisplayName("PLC卡槽号"),
       Description("PLC卡槽号"),
       Browsable(true),
       ReadOnly(false)]
        public int PLCSlot { get; set; }

        [XmlAttribute("AddrType"),
       Category("标签类型"),
       DisplayName("标签类型"),
       Description("标签类型"),
       Browsable(true),
       ReadOnly(false)]
        public string AddrType { get; set; }

        [XmlAttribute("plcType"),
       Category("PLC设置"),
       DisplayName("PLC品牌"),
       Description("PLC品牌"),
       Browsable(true),
       ReadOnly(false)]
        public string PLCType { get; set; }

        [XmlElement("station"),
         TypeConverter(typeof(ListConverter)),
         Editor(typeof(CustomEditor), typeof(UITypeEditor)),
         Category("产线设置"),
         DisplayName("产线配置"),
         Description("产线配置"),
         Browsable(true),
         ReadOnly(false)]
        public List<Xml_InfoConfig_Station> STATION { get; set; }
    }
}
