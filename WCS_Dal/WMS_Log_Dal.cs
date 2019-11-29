using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS_Model.DB;

namespace WCS_Dal
{
    public class WMS_Log_Dal
    {

        /// <summary>
        /// 日志查询
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Select_Log(string condition)
        {
            string _selectSql = string.Empty;
            if (string.IsNullOrEmpty(condition))
            {
                _selectSql = "SELECT [LogTime],[LogType],[LogLocation]"
                    + ",[LogMessage],[LogLevel] FROM [WMS].[dbo].[WMS_Log]";
            }
            else
            {
                _selectSql = "SELECT [LogTime],[LogType],[LogLocation]"
                    + ",[LogMessage],[LogLevel] FROM [WMS].[dbo].[WMS_Log] Where " + condition;
            }
            return _selectSql;
        }

        /// <summary>
        /// 日志插入
        /// </summary>
        /// <param name="wMS_Log_Model"></param>
        /// <returns></returns>
        public static string Inseert_Log(WMS_Log_Model wMS_Log_Model)
        {
            string _insertSql = "INSERT INTO [WMS].[dbo].[WMS_Log]" 
                + "([LogTime],[LogType],[LogLocation],[LogMessage],[LogLevel])"
                + "VALUES('" + wMS_Log_Model.LogTime + "','" + wMS_Log_Model.LogType 
                + "','" + wMS_Log_Model.LogLocation + "','" + wMS_Log_Model.LogMessage 
                + "'," + wMS_Log_Model.LogLevel + ")";
            return _insertSql;
        }

        /// <summary>
        /// 日志更新
        /// </summary>
        /// <param name="wMS_Log_Model"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Update_Log(WMS_Log_Model wMS_Log_Model,string condition)
        {
            string _updateSql = "UPDATE [WMS].[dbo].[WMS_Log]" 
                + "SET[LogTime] = '" + wMS_Log_Model.LogTime + "',[LogType] = '" 
                + wMS_Log_Model.LogType + "',[LogLocation] = '" 
                + wMS_Log_Model.LogLocation + "',[LogMessage] = '" 
                + wMS_Log_Model.LogMessage + "',[LogLevel] = " 
                + wMS_Log_Model.LogLevel + " WHERE " + condition;
            return _updateSql;
        }

        /// <summary>
        /// 日志删除
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Delete_Log(string condition)
        {
            string _deleteSql = "";
            if (string.IsNullOrEmpty(condition))
            {
                _deleteSql = "DELETE FROM [WMS].[dbo].[WMS_Log]";
            }
            else
            {
                _deleteSql = "DELETE FROM [WMS].[dbo].[WMS_Log] Where " + condition;
            }
            return _deleteSql;
        }
    }
}
