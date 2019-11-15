using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS_Model.DB;

namespace WCS_Dal
{
    public class WMS_Area_Dal
    {       
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Select_Area(string condition)
        {
            string _selectSql = string.Empty;
            if (string.IsNullOrEmpty(condition))
                _selectSql = "select * from WMS_Area";
            else
                _selectSql = "select * from WMS_Area Where " + condition;
            return _selectSql;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="wMS_Area_Model"></param>
        /// <returns></returns>
        public static string Insert_Area(WMS_Area_Model wms_Area_Model)
        {
            string _insertSql = "INSERT INTO [WMS].[dbo].[WMS_Area]" 
                + "([AreaName],[AreaNo],[WarehouseNo],[Remark]" 
                + ",[CreatPerson],[CreatTime],[ModifyPerson]" 
                + ",[ModifyTime]) VALUES('" + wms_Area_Model.AreaName 
                + "','" + wms_Area_Model.AreaNo + "','" 
                + wms_Area_Model.WarehouseNo + "','" + wms_Area_Model.Remark 
                + "','" + wms_Area_Model.CreatPerson + "','" 
                + wms_Area_Model.CreatTime + "','" + wms_Area_Model.ModifyPerson 
                + "','" + wms_Area_Model.ModifyTime + "')";
            return _insertSql;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="wMS_Area_Model"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Update_Area(WMS_Area_Model wms_Area_Model, string condition)
        {
            string _updateSql = "UPDATE [WMS].[dbo].[WMS_Area]"
                                + " SET[AreaName] = '" + wms_Area_Model.AreaName
                                + "',[AreaNo] = '" + wms_Area_Model.AreaNo
                                + "',[WarehouseNo] = '" + wms_Area_Model.WarehouseNo
                                + "',[Remark] = '" + wms_Area_Model.Remark
                                + "',[CreatPerson] = '" + wms_Area_Model.CreatPerson
                                + "',[CreatTime] = '" + wms_Area_Model.CreatTime
                                + "',[ModifyPerson] = '" + wms_Area_Model.ModifyPerson
                                + "',[ModifyTime] = '" + wms_Area_Model.ModifyTime
                                + "' WHERE " + condition;
            return _updateSql;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Delete_Area(string condition)
        {
            string _deleteSql = string.Empty;
            if (string.IsNullOrEmpty(condition))
                _deleteSql = "DELETE FROM [WMS].[dbo].[WMS_Area]";
            else
                _deleteSql = "DELETE FROM [WMS].[dbo].[WMS_Area] WHERE " + condition;
            return _deleteSql;
        }
    }
}
