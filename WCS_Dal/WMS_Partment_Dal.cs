using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS_Model.DB;

namespace WCS_Dal
{
    public class WMS_Partment_Dal
    {

        /// <summary>
        /// 查询部门
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Select_Partment(string condition)
        {
            string _selectSql = string.Empty;
            if (string.IsNullOrEmpty(condition))
            {
                _selectSql = "SELECT [PartmentNo],[PartmentName]" 
                    + ",[CreatPerson],[CreatTime],[ModifyPerson]" 
                    + ",[ModifyTime] FROM [WMS].[dbo].[WMS_Partment]";
            }
            else
            {
                _selectSql = "SELECT [PartmentNo],[PartmentName]"
                    + ",[CreatPerson],[CreatTime],[ModifyPerson]"
                    + ",[ModifyTime] FROM [WMS].[dbo].[WMS_Partment] WHERE " + condition;
            }
            return _selectSql;
        }

        /// <summary>
        /// 插入部门
        /// </summary>
        /// <param name="wms_Partment_Model"></param>
        /// <returns></returns>
        public static string Insert_Partment(WMS_Partment_Model wms_Partment_Model)
        {
            string _insertSql = "INSERT INTO [WMS].[dbo].[WMS_Partment]" 
                + "([PartmentNo],[PartmentName],[CreatPerson],[CreatTime]" 
                + ",[ModifyPerson],[ModifyTime])VALUES(" + wms_Partment_Model.PartmentNo 
                + ",'" + wms_Partment_Model.PartmentName + "','" + wms_Partment_Model.CreatPerson 
                + "','" + wms_Partment_Model.CreatTime + "','" + wms_Partment_Model.ModifyPerson 
                + "','" + wms_Partment_Model.ModifyTime + "')";
            return _insertSql;
        }

        /// <summary>
        /// 更新部门
        /// </summary>
        /// <param name="wms_Partment_Model"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Update_Partment(WMS_Partment_Model wms_Partment_Model, string condition)
        {
            string _updateSql = "UPDATE [WMS].[dbo].[WMS_Partment]" 
                + "SET[PartmentNo] = " + wms_Partment_Model.PartmentNo 
                + ",[PartmentName] = '" + wms_Partment_Model.PartmentName 
                + "',[CreatPerson] = '" + wms_Partment_Model.CreatPerson 
                + "',[CreatTime] = '" + wms_Partment_Model.CreatTime 
                + "',[ModifyPerson] = '" + wms_Partment_Model.ModifyPerson 
                + "',[ModifyTime] = '" + wms_Partment_Model.ModifyTime 
                + "' WHERE " + condition;
            return _updateSql;
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Delete_Partment(string condition)
        {
            string _deleteSql = string.Empty;
            if (string.IsNullOrEmpty(condition))
            {
                _deleteSql = "DELETE FROM [WMS].[dbo].[WMS_Partment]";
            }
            else
            {
                _deleteSql = "DELETE FROM [WMS].[dbo].[WMS_Partment]"
                    + "WHERE " + condition;
            }
            return _deleteSql;
        }
    }
}
