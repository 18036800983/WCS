using MyLog;
using System.ComponentModel;
using System.Xml.Serialization;

namespace WCS_Model.XML
{
    [XmlRoot("sysConfig")]
    public class Xml_SysConfig
    {
        [XmlElement("IsChinese"),
         Category("系统设置"),
         DisplayName("是否中文"),
         Description("是否中文"),
         Browsable(true),
         ReadOnly(false)]
        public bool IsChinese { get; set; }

        [XmlElement("IsHaveClient"),
         Category("系统设置"),
         DisplayName("是否有客户端"),
         Description("是否有客户端"),
         Browsable(true),
         ReadOnly(false)]
        public bool IsHaveClient { get; set; }

        [XmlElement("QCScannerStr"),
         Category("系统设置"),
         DisplayName("QC枪号"),
         Description("QC枪号"),
         Browsable(true),
         ReadOnly(false)]
        public string QCScannerStr { get; set; }

        [XmlElement("offlineTest"),
         Category("工艺设置"),
         DisplayName("仿真测试"),
         Description("仿真测试"),
         Browsable(true),
         ReadOnly(false)]
        public bool offlineTest { get; set; }

        [XmlElement("leftTrayCode"),
         Category("工艺设置"),
         DisplayName("托盘条码-左"),
         Description("托盘条码-左"),
         Browsable(true),
         ReadOnly(false)]
        public string leftTrayCode { get; set; }

        [XmlElement("rightTrayCode"),
         Category("工艺设置"),
         DisplayName("托盘条码-右"),
         Description("托盘条码-右"),
         Browsable(true),
         ReadOnly(false)]
        public string rightTrayCode { get; set; }

        [XmlElement("TrayCode"),
         Category("工艺设置"),
         DisplayName("托盘条码-不分左右"),
         Description("托盘条码-不分左右"),
         Browsable(true),
         ReadOnly(false)]
        public string TrayCode { get; set; }

        [XmlElement("Style"),
         Category("工艺设置"),
         DisplayName("界面"),
         Description("界面"),
         Browsable(true),
         ReadOnly(false)]
        public int Style { get; set; }

        [XmlElement("ProgramName"),
         Category("工艺设置"),
         DisplayName("项目名称"),
         Description("项目名称"),
         Browsable(true),
         ReadOnly(false)]
        public string ProgramName { get; set; }

        [XmlElement("SystemEnable"),
         Browsable(false),
         ReadOnly(false)]
        public bool SystemEnable { get; set; }

        [XmlElement("ControlTagType"),
         Browsable(false),
         ReadOnly(false)]
        public ControlTagType ConnectType { get; set; }

        [XmlElement("LogKeepPeriod"),
         Category("工艺设置"),
         DisplayName("日志保存时间"),
         Description("日志保存时间"),
         Browsable(true),
         ReadOnly(false)]
        public LogExpired LogKeepPeriod { get; set; }

        [XmlElement("AutoStart"),
         Category("工艺设置"),
         DisplayName("开机自启"),
         Description("开机自启"),
         Browsable(true),
         ReadOnly(false)]
        public bool AutoStart { get; set; }

        [XmlElement("WorkStatus"),
         Browsable(false),
         ReadOnly(false)]
        public bool WorkStatus { get; set; }

        [XmlElement("startWithReport"),
         Category("工艺设置"),
         DisplayName("启动报表"),
         Description("启动报表"),
         Browsable(true),
         ReadOnly(false)]
        public bool startWithReport { get; set; }

        [XmlElement("StartWithLogin"),
         Category("工艺设置"),
         DisplayName("启用开启登录界面"),
         Description("启用开启登录界面"),
         Browsable(true),
         ReadOnly(false)]
        public bool StartWithLogin { get; set; }

        [XmlElement("QuitWithLogin"),
         Category("工艺设置"),
         DisplayName("启用退出登录界面"),
         Description("启用退出登录界面"),
         Browsable(true),
         ReadOnly(false)]
        public bool QuitWithLogin { get; set; }

        [XmlElement("FullScreen"),
         Category("工艺设置"),
         DisplayName("全屏"),
         Description("全屏"),
         Browsable(true),
         ReadOnly(false)]
        public bool FullScreen { get; set; }

        [XmlElement("selectRecord"),
         Browsable(false),
         ReadOnly(false)]
        public int selectRecord { get; set; }



        [XmlElement("DataRecordEnable"),
         Category("工艺设置"),
         DisplayName("追溯开关"),
         Description("追溯开关"),
         //DefaultValue(""),
         Browsable(true),
         ReadOnly(false)]
        public bool DataRecordEnable { get; set; }

        [XmlElement("RecipeEnable"),
         Category("工艺设置"),
         DisplayName("配方请求"),
         Description("配方请求"),
         Browsable(true),
         ReadOnly(false)]
        public bool RecipeEnable { get; set; }

        public enum ControlTagType
        {
            MyPLCDataview,
            OPC
        }
    }
}
