using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS_Model.DB;

namespace WCS_Dal
{
    public class WMS_Privilege_Dal
    {

        /// <summary>
        /// 查询权限
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Select_Privilege(string condition)
        {
            string _selectSql = string.Empty;
            if (string.IsNullOrEmpty(condition))
            {
                _selectSql = "SELECT [PrivilegeNo],[PrivilegeName]"
                    + "FROM [WMS].[dbo].[WMS_Privilege]";
            }
            else
            {
                _selectSql = "SELECT [PrivilegeNo],[PrivilegeName]"
                    + "FROM [WMS].[dbo].[WMS_Privilege] WHERE " + condition;
            }
            return _selectSql;
        }

        /// <summary>
        /// 插入权限
        /// </summary>
        /// <param name="wms_Privilege_Model"></param>
        /// <returns></returns>
        public static string Insert_Privilege(WMS_Privilege_Model wms_Privilege_Model)
        {
            string _insertSql = "INSERT INTO [WMS].[dbo].[WMS_Privilege]" 
                + "([PrivilegeNo],[PrivilegeName])VALUES(" + wms_Privilege_Model.PrivilegeNo 
                + ",'" + wms_Privilege_Model.PrivilegeName + "')";
            return _insertSql;
        }

        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="wms_Privilege_Model"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Update_Privilege(WMS_Privilege_Model wms_Privilege_Model,string condition)
        {
            string _updateSql = "UPDATE [WMS].[dbo].[WMS_Privilege]" 
                + "SET[PrivilegeNo] = " + wms_Privilege_Model.PrivilegeNo 
                + ",[PrivilegeName] = '" + wms_Privilege_Model.PrivilegeName 
                + "'WHERE " + condition;
            return _updateSql;
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Delete_Privilege(string condition)
        {
            string _deleteSql = string.Empty;
            if (string.IsNullOrEmpty(condition))
                _deleteSql = "DELETE FROM [WMS].[dbo].[WMS_Privilege]";
            else
                _deleteSql = "DELETE FROM [WMS].[dbo].[WMS_Privilege] WHERE " + condition;
            return _deleteSql;
        }
    }
}
