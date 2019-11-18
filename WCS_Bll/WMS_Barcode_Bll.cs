using MySql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tool;
using WCS_Dal;
using WCS_Model.DB;

namespace WCS_Bll
{
    public class WMS_Barcode_Bll : DB_Tool
    {
        /// <summary>
        /// 查询条码规则
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static DataTable Select_Barcode(string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.ExecuteDataTable(WMS_Barcode_Dal.Select_Barcode(condition));
            }
        }

        /// <summary>
        /// 添加条码规则
        /// </summary>
        /// <returns></returns>
        public static int Insert_Barcode(WMS_Barcode_Model wms_Barcode_Model)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Barcode_Dal.Insert_Barcode(wms_Barcode_Model));
            }
        }

        /// <summary>
        /// 更新条码规则
        /// </summary>
        /// <returns></returns>
        public static int Update_Barcode(WMS_Barcode_Model wms_Barcode_Model, string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Barcode_Dal.Update_Barcode(wms_Barcode_Model,condition));
            }
        }

        /// <summary>
        /// 删除条码规则
        /// </summary>
        /// <returns></returns>
        public static int Delete_Barcode(string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Barcode_Dal.Delete_Barcode(condition));
            }
        }
    }
}
