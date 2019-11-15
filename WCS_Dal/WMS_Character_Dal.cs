using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS_Model.DB;

namespace WCS_Dal
{
    public class WMS_Character_Dal
    {

        /// <summary>
        /// 查询角色
        /// </summary>
        /// <returns></returns>
        public static string Select_Character(string condition)
        {
            string _selectSql = string.Empty;
            if (string.IsNullOrEmpty(condition))
            {
                _selectSql = "SELECT [LoginName]"
                    + ",[UserName],[PartmentNo],[UserPrivilege]"
                    + ",[CreatPerson],[CreatTime],[ModifyPerson]"
                    + ",[ModifyTime] FROM [WMS].[dbo].[WMS_Character]";
            }
            else
            {
                _selectSql = "SELECT [LoginName]"
                    + ",[UserName],[PartmentNo],[UserPrivilege]"
                    + ",[CreatPerson],[CreatTime],[ModifyPerson]"
                    + ",[ModifyTime] FROM [WMS].[dbo].[WMS_Character] WHERE " 
                    + condition;
            }
            return _selectSql;
        }

        /// <summary>
        /// 插入角色
        /// </summary>
        /// <returns></returns>
        public static string Insert_Character(WMS_Character_Model wms_Character_Model)
        {
            string _insertSql = "INSERT INTO [WMS].[dbo].[WMS_Character]" 
                + "([LoginName],[UserName],[PartmentNo],[UserPrivilege]" 
                + ",[CreatPerson],[CreatTime],[ModifyPerson],[ModifyTime])" 
                + "VALUES('" + wms_Character_Model.LoginName + "','" 
                + wms_Character_Model.UserName + "','" + wms_Character_Model.PartmentNo 
                + "','" + wms_Character_Model.UserPrivilege + "','" 
                + wms_Character_Model.CreatPerson + "','" 
                + wms_Character_Model.CreatTime + "','" 
                + wms_Character_Model.ModifyPerson + "','" 
                + wms_Character_Model.ModifyTime + "')";
            return _insertSql;
        }

        /// <summary>
        /// 更新角色
        /// </summary>
        /// <returns></returns>
        public static string Update_Character(WMS_Character_Model wms_Character_Model,string condition)
        {
            string _updateSql = "UPDATE [WMS].[dbo].[WMS_Character]" 
                + "SET[LoginName] = '" + wms_Character_Model.LoginName 
                + "',[UserName] = '" + wms_Character_Model.UserName 
                + "',[PartmentNo] = " + wms_Character_Model.PartmentNo 
                + ",[UserPrivilege] = '" + wms_Character_Model.UserPrivilege 
                + "',[CreatPerson] = '" + wms_Character_Model.CreatPerson 
                + "',[CreatTime] = '" + wms_Character_Model.CreatTime 
                + "',[ModifyPerson] = '" + wms_Character_Model.ModifyPerson 
                + "',[ModifyTime] = '" + wms_Character_Model.ModifyTime 
                + "' WHERE " + condition;
            return _updateSql;
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <returns></returns>
        public static string Delete_Character(string condition)
        {
            string _deleteSql = string.Empty;
            if (string.IsNullOrEmpty(condition))
            {
                _deleteSql = "DELETE FROM [WMS].[dbo].[WMS_Character]";
            }
            else
            {
                _deleteSql = "DELETE FROM [WMS].[dbo].[WMS_Character]" 
                    + " WHERE " + condition;
            }
            return _deleteSql;
        }
    }
}
