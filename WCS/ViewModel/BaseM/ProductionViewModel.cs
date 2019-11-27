using DMSkin.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS.ViewBase.BaseM;
using WCS_Bll;
using WCS_Dal;
using WCS_Model.DB;

namespace WCS.ViewModel.BaseM
{
    public class ProductionViewModel : ProductionBase
    {
        public ProductionViewModel()
        {
            ShowProductionTable();
        }
        /// <summary>
        /// 显示条码规则列表
        /// </summary>
        public void ShowProductionTable()
        {
            foreach (var model in GetProductionList())
            {
                ProductionList.Add(model);
            }
            ShowProductionList();
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        public static List<WMS_Production_Model> GetProductionList()
        {
            List<WMS_Production_Model> list = new List<WMS_Production_Model>();
            DataTable dt = WMS_Production_Bll.Select_Production(string.Empty);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WMS_Production_Model wms_Production_Model = new WMS_Production_Model
                {
                    ProductionNo = dt.Rows[i]["ProductionNo"].ToString(),
                    ProductionName = dt.Rows[i]["ProductionName"].ToString(),
                    LocationNo = dt.Rows[i]["LocationNo"].ToString(),
                    WarehouseNo = dt.Rows[i]["WarehouseNo"].ToString(),
                    CreatPerson = dt.Rows[i]["CreatPerson"].ToString(),
                    CreatTime = dt.Rows[i]["CreatTime"].ToString(),
                    ModifyPerson = dt.Rows[i]["ModifyPerson"].ToString(),
                    ModifyTime = dt.Rows[i]["ModifyTime"].ToString()
                };
                list.Add(wms_Production_Model);
            }
            return list;
        }
    }
}
