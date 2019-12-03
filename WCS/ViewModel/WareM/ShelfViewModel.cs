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
    public class ShelfViewModel : ShelfBase
    {
        public ShelfViewModel()
        {
            ShowShelfTable();
        }
        /// <summary>
        /// 显示条码规则列表
        /// </summary>
        public void ShowShelfTable()
        {
            foreach (var model in GetShelfList())
            {
                ShelfList.Add(model);
            }
            ShowShelfList();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public static List<WMS_Shelf_Model> GetShelfList()
        {
            List<WMS_Shelf_Model> list = new List<WMS_Shelf_Model>();
            DataTable dt = WMS_Shelf_Bll.Select_Shelf(string.Empty);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WMS_Shelf_Model wms_Shelf_Model = new WMS_Shelf_Model
                {
                    ShelfName = dt.Rows[i]["ShelfName"].ToString(),
                    ShelfNo = dt.Rows[i]["ShelfNo"].ToString(),
                    AreaNo = dt.Rows[i]["AreaNo"].ToString(),
                    WarehouseNo = dt.Rows[i]["WarehouseNo"].ToString(),
                    Remark = dt.Rows[i]["Remark"].ToString(),
                    CreatPerson = dt.Rows[i]["CreatPerson"].ToString(),
                    CreatTime = dt.Rows[i]["CreatTime"].ToString(),
                    ModifyPerson = dt.Rows[i]["ModifyPerson"].ToString(),
                    ModifyTime = dt.Rows[i]["ModifyTime"].ToString()
                };
                list.Add(wms_Shelf_Model);
            }
            return list;
        }
    }
}
