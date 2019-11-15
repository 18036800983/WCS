using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS_Model.DB;

namespace WCS_Dal
{
    public class WMS_Barcode_Dal
    {

        /// <summary>
        /// 查询条码规则
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Select_Barcode(string condition)
        {
            string _selectSql = string.Empty;
            if (string.IsNullOrEmpty(condition))
            {
                _selectSql = "SELECT [BarcodeLength]"
                    + ",[BarcodeRule],[ProductionNo],[CreatPerson]"
                    + ",[CreatTime],[ModifyPerson],[ModifyTime]"
                    + "FROM [WMS].[dbo].[WMS_Barcode]";
            }
            else
            {
                _selectSql = "SELECT [BarcodeLength]"
                    + ",[BarcodeRule],[ProductionNo],[CreatPerson]"
                    + ",[CreatTime],[ModifyPerson],[ModifyTime]"
                    + "FROM [WMS].[dbo].[WMS_Barcode] Where " + condition;
            }
            return _selectSql;
        }


        /// <summary>
        /// 添加条码规则
        /// </summary>
        /// <returns></returns>
        public static string Insert_Barcode(WMS_Barcode_Model wms_Barcode_Model)
        {
            string _insertSql = "INSERT INTO [WMS].[dbo].[WMS_Barcode]" 
                + "([BarcodeLength],[BarcodeRule],[ProductionNo]" 
                + ",[CreatPerson],[CreatTime],[ModifyPerson],[ModifyTime]) " 
                + "VALUES(" + wms_Barcode_Model.BarcodeLength + ",'" 
                + wms_Barcode_Model.BarcodeRule + "','" + wms_Barcode_Model.ProductionNo 
                + "','" + wms_Barcode_Model.CreatPerson + "','" 
                + wms_Barcode_Model.CreatTime + "','" + wms_Barcode_Model.ModifyPerson 
                + "','" + wms_Barcode_Model.ModifyTime + "')";
            return _insertSql;
        }


        /// <summary>
        /// 更新条码规则
        /// </summary>
        /// <returns></returns>
        public static string Update_Barcode(WMS_Barcode_Model wms_Barcode_Model,string condition)
        {
            string _updateSql = "UPDATE [WMS].[dbo].[WMS_Barcode]" 
                + "SET[BarcodeLength] = " + wms_Barcode_Model.BarcodeLength 
                + ",[BarcodeRule] = '" + wms_Barcode_Model.BarcodeRule 
                + "',[ProductionNo] = '" + wms_Barcode_Model.ProductionNo 
                + "',[CreatPerson] = '" + wms_Barcode_Model.CreatPerson 
                + "',[CreatTime] = '" + wms_Barcode_Model.CreatTime 
                + "',[ModifyPerson] = '" + wms_Barcode_Model.ModifyPerson 
                + "',[ModifyTime] = '" + wms_Barcode_Model.ModifyTime 
                + "' WHERE " + condition;
            return _updateSql;
        }

        /// <summary>
        /// 删除条码规则
        /// </summary>
        /// <returns></returns>
        public static string Delete_Barcode(string condition)
        {
            string _deleteSql = string.Empty;
            if (!string.IsNullOrEmpty(condition))
                _deleteSql = "DELETE FROM [WMS].[dbo].[WMS_Barcode]"
                    + " WHERE " + condition;
            else
                _deleteSql = "DELETE FROM [WMS].[dbo].[WMS_Barcode]";
            return _deleteSql;
        }
    }
}
