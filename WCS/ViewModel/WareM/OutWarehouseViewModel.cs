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
    public class OutWarehouseViewModel : OutWarehouseBase
    {
        public OutWarehouseViewModel()
        {
            ShowPutOutTable();
        }
        /// <summary>
        /// 显示条码规则列表
        /// </summary>
        public void ShowPutOutTable()
        {
            foreach (var model in GetPutOutList())
            {
                PutOutList.Add(model);
            }
            ShowPutOutList();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public static List<WMS_PutOut_Model> GetPutOutList()
        {
            List<WMS_PutOut_Model> list = new List<WMS_PutOut_Model>();
            DataTable dt = WMS_PutOut_Bll.Select_PutOut(string.Empty);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WMS_PutOut_Model wms_PutOut_Model = new WMS_PutOut_Model
                {
                    ShelfNo = dt.Rows[i]["ShelfNo"].ToString(),
                    PutOutNo = dt.Rows[i]["PutOutNo"].ToString(),
                    SN = dt.Rows[i]["SN"].ToString(),
                    OrderNo = dt.Rows[i]["OrderNo"].ToString(),
                    PutOutType = dt.Rows[i]["PutOutType"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    PutOutTime = dt.Rows[i]["PutOutTime"].ToString()
                };
                list.Add(wms_PutOut_Model);
            }
            return list;
        }
    }
}
