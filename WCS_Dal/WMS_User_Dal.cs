using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS_Model.DB;

namespace WCS_Dal
{
    public class WMS_User_Dal
    {

        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Select_User(string condition)
        {
            string _selectSql = string.Empty;
            if (string.IsNullOrEmpty(condition))
            {
                _selectSql = "SELECT [LoginName],[LoginPassword],[PrivilegeLevel]" 
                    + ",[CreatPerson],[CreatTime],[ModifyPerson],[ModifyTime]" 
                    + "FROM [WMS].[dbo].[WMS_User]";
            }
            else
            {
                _selectSql = "SELECT [LoginName],[LoginPassword],[PrivilegeLevel]"
                   + ",[CreatPerson],[CreatTime],[ModifyPerson],[ModifyTime]"
                   + "FROM [WMS].[dbo].[WMS_User] WHERE " + condition;
            }
            return _selectSql;
        }

        /// <summary>
        /// 插入用户
        /// </summary>
        /// <param name="wms_User_Model"></param>
        /// <returns></returns>
        public static string Insert_User(WMS_User_Model wms_User_Model)
        {
            string _insertSql = "INSERT INTO [WMS].[dbo].[WMS_User]" 
                + "([LoginName],[LoginPassword],[PrivilegeLevel],[CreatPerson]" 
                + ",[CreatTime],[ModifyPerson],[ModifyTime])VALUES('" 
                + wms_User_Model.LoginName + "','" + wms_User_Model.LoginPassword 
                + "'," + wms_User_Model.PrivilegeLevel + ",'" 
                + wms_User_Model.CreatPerson + "','" + wms_User_Model.CreatTime 
                + "','" + wms_User_Model.ModifyPerson + "','" 
                + wms_User_Model.ModifyTime + "')";
            return _insertSql;
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="wms_User_Model"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Update_User(WMS_User_Model wms_User_Model,string condition)
        {
            string _updateSql = "UPDATE [WMS].[dbo].[WMS_User]" 
                + "SET[LoginName] = '" + wms_User_Model.LoginName 
                + "',[LoginPassword] = '" + wms_User_Model.LoginPassword 
                + "',[PrivilegeLevel] = " + wms_User_Model.PrivilegeLevel 
                + ",[CreatPerson] = '" + wms_User_Model.CreatPerson 
                + "',[CreatTime] = '" + wms_User_Model.CreatTime 
                + "',[ModifyPerson] = '" + wms_User_Model.ModifyPerson 
                + "',[ModifyTime] = '" + wms_User_Model.ModifyTime 
                + "' WHERE " + condition ;
            return _updateSql;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Delete_User(string condition)
        {
            string _deleteSql = string.Empty;
            if (string.IsNullOrEmpty(condition))
            {
                _deleteSql = "DELETE FROM [WMS].[dbo].[WMS_User]";
            }
            else
            {
                _deleteSql = "DELETE FROM [WMS].[dbo].[WMS_User] WHERE " + condition;
            }
            return _deleteSql;
        }
    }
}
