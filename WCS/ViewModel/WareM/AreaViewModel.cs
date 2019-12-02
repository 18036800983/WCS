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
    public class AreaViewModel : AreaBase
    {
        public AreaViewModel()
        {
            ShowAreaTable();
        }
        /// <summary>
        /// 显示条码规则列表
        /// </summary>
        public void ShowAreaTable()
        {
            foreach (var model in GetAreaList())
            {
                AreaList.Add(model);
            }
            ShowAreaList();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public static List<WMS_Area_Model> GetAreaList()
        {
            List<WMS_Area_Model> list = new List<WMS_Area_Model>();
            DataTable dt = WMS_Area_Bll.Select_Area(string.Empty);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WMS_Area_Model wms_Area_Model = new WMS_Area_Model
                {
                    AreaName = dt.Rows[i]["AreaName"].ToString(),
                    AreaNo = dt.Rows[i]["AreaNo"].ToString(),
                    WarehouseNo = dt.Rows[i]["WarehouseNo"].ToString(),
                    Remark = dt.Rows[i]["Remark"].ToString(),
                    CreatPerson = dt.Rows[i]["CreatPerson"].ToString(),
                    CreatTime = dt.Rows[i]["CreatTime"].ToString(),
                    ModifyPerson = dt.Rows[i]["ModifyPerson"].ToString(),
                    ModifyTime = dt.Rows[i]["ModifyTime"].ToString()
                };
                list.Add(wms_Area_Model);
            }
            return list;
        }
    }
}
