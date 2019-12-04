using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS.ViewBase.WareM;
using WCS_Bll;
using WCS_Model.DB;

namespace WCS.ViewModel.WareM
{
    public class WarehouseViewModel : WarehouseBase
    {
        public WarehouseViewModel()
        {
            ShowWarehouseTable();
        }
        /// <summary>
        /// 显示条码规则列表
        /// </summary>
        public void ShowWarehouseTable()
        {
            foreach (var model in GetWarehouseList())
            {
                WarehouseList.Add(model);
            }
            ShowWarehouseList();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public static List<WMS_Warehouse_Model> GetWarehouseList()
        {
            List<WMS_Warehouse_Model> list = new List<WMS_Warehouse_Model>();
            DataTable dt = WMS_Warehouse_Bll.Select_Warehouse(string.Empty);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WMS_Warehouse_Model wms_Warehouse_Model = new WMS_Warehouse_Model
                {
                    WarehouseName = dt.Rows[i]["WarehouseName"].ToString(),
                    WarehouseNo = dt.Rows[i]["WarehouseNo"].ToString(),
                    Remark = dt.Rows[i]["Remark"].ToString(),
                    CreatPerson = dt.Rows[i]["CreatPerson"].ToString(),
                    CreatTime = dt.Rows[i]["CreatTime"].ToString(),
                    ModifyPerson = dt.Rows[i]["ModifyPerson"].ToString(),
                    ModifyTime = dt.Rows[i]["ModifyTime"].ToString()
                };
                list.Add(wms_Warehouse_Model);
            }
            return list;
        }
    }
}
