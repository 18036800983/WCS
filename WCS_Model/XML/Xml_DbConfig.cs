using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WCS_Model.XML
{
    [XmlRoot("dbConfig")]
    public class Xml_DbConfig
    {
        [XmlElement("DataSource"),
         DisplayName("数据源"),
         Description("数据源"),
         Browsable(true),
         ReadOnly(false)]
        public string DataSource { get; set; }

        [XmlElement("InitialCatalog"),
         DisplayName("数据库名称"),
         Description("数据库名称"),
         Browsable(true),
         ReadOnly(false)]
        public string InitialCatalog { get; set; }

        [XmlElement("UserID"),
         DisplayName("用户名"),
         Description("用户名"),
         Browsable(true),
         ReadOnly(false)]
        public string UserID { get; set; }

        [XmlElement("pwd"),
         DisplayName("密码"),
         Description("密码"),
         Browsable(true),
         ReadOnly(false),
         TypeConverter(typeof(PasswordStringConverter))]
        public string pwd { get; set; }

        [XmlElement("BackupPath"),
         DisplayName("备份地址"),
         Description("备份地址"),
         Browsable(true),
         ReadOnly(false)]
        public string BackupPath { get; set; }

        [XmlElement("BackupPeriod"),
         DisplayName("备份间隔"),
         Description("备份间隔"),
         Browsable(false),
         ReadOnly(false)]
        public int BackupPeriod { get; set; }

        [XmlElement("BackupTime"),
         DisplayName("备份时间"),
         Description("备份时间"),
         Browsable(false),
         ReadOnly(false)]
        public DateTime BackupTime { get; set; }

        [XmlElement("ReportNameShowType"),
         DisplayName("报表显示方式"),
         Description("报表显示方式"),
         Browsable(true),
         ReadOnly(false)]
        public ReportNameShow ReportNameShowType { get; set; }

        [XmlElement("DatabaseType"),
         DisplayName("数据库类型"),
         Description("数据库类型"),
         Browsable(true),
         ReadOnly(false)]
        public DbProviderType DatabaseType { get; set; }


        [XmlElement("DatetimeColmn"),
         DisplayName("时间列名称"),
         Description("时间列名称"),
         Browsable(true),
         ReadOnly(false)]
        public string DatetimeColmn { get; set; }

        [XmlElement("AutoBackup"),
         DisplayName("自动备份"),
         Description("自动备份"),
         Browsable(true),
         ReadOnly(false)]
        public bool AutoBackup { get; set; }

        public enum ReportNameShow
        {
            数据库说明,
            特性
        }

        public enum DbProviderType : byte
        {
            SqlServer,
            MySql,
            SQLite,
            Oracle,
            ODBC,
            OleDb,
            Firebird,
            PostgreSql,
            DB2,
            Informix,
            SqlServerCe
        }
    }
}
