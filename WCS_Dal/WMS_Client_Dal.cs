using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS_Model.DB;

namespace WCS_Dal
{
    public class WMS_Client_Dal
    {

        /// <summary>
        /// 查询客户
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Select_Client(string condition)
        {
            string _selectClient = string.Empty;
            if (string.IsNullOrEmpty(condition))
            {
                _selectClient = "SELECT [CompanyName]"
                    + ",[ProductionName],[CreatPerson],[CreatTime]"
                    + ",[ModifyPerson],[ModifyTime] FROM [WMS].[dbo].[WMS_Client] Where " + condition;
            }
            else
            {
                _selectClient = "SELECT [CompanyName]"
                    + ",[ProductionName],[CreatPerson],[CreatTime]"
                    + ",[ModifyPerson],[ModifyTime] FROM [WMS].[dbo].[WMS_Client]";
            }
            return _selectClient;
        }

        /// <summary>
        /// 插入客户
        /// </summary>
        /// <param name="wms_Client_Model"></param>
        /// <returns></returns>
        public static string Insert_Client(WMS_Client_Model wms_Client_Model)
        {
            string _insertSql = "INSERT INTO [WMS].[dbo].[WMS_Client]" 
                + "([CompanyName],[ProductionName],[CreatPerson]" 
                + ",[CreatTime],[ModifyPerson],[ModifyTime])" 
                + "VALUES('" + wms_Client_Model.CompanyName 
                + "','" + wms_Client_Model.ProductionName 
                + "','" + wms_Client_Model.CreatPerson 
                + "','" + wms_Client_Model.CreatTime 
                + "','" + wms_Client_Model.ModifyPerson 
                + "','" + wms_Client_Model.ModifyTime + "')";
            return _insertSql;
        }

        /// <summary>
        /// 更新客户
        /// </summary>
        /// <param name="wms_Client_Model"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Update_Client(WMS_Client_Model wms_Client_Model, string condition)
        {
            string _updateSql = "UPDATE [WMS].[dbo].[WMS_Client]" 
                + "SET[CompanyName] = '" + wms_Client_Model.CompanyName 
                + "',[ProductionName] = '" + wms_Client_Model.ProductionName 
                + "',[CreatPerson] = '" + wms_Client_Model.CreatPerson 
                + "',[CreatTime] = '" + wms_Client_Model.CreatTime 
                + "',[ModifyPerson] = '" + wms_Client_Model.ModifyPerson 
                + "',[ModifyTime] = '" + wms_Client_Model.ModifyTime 
                + "' WHERE " + condition;
            return _updateSql;
        }

        /// <summary>
        /// 删除客户
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Delete_Client(string condition)
        {
            string _deleteSql = string.Empty;
            if (string.IsNullOrEmpty(condition))
            {
                _deleteSql = "DELETE FROM [WMS].[dbo].[WMS_Client]";
            }
            else
            {
                _deleteSql = "DELETE FROM [WMS].[dbo].[WMS_Client] Where " + condition;
            }
            return _deleteSql;
        }
    }
}
