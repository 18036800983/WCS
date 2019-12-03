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
    public class InStockViewModel : InStockBase
    {
        public InStockViewModel()
        {
            ShowPutInTable();
        }
        /// <summary>
        /// 显示条码规则列表
        /// </summary>
        public void ShowPutInTable()
        {
            foreach (var model in GetPutInList())
            {
                PutInList.Add(model);
            }
            ShowPutInList();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public static List<WMS_PutIn_Model> GetPutInList()
        {
            List<WMS_PutIn_Model> list = new List<WMS_PutIn_Model>();
            DataTable dt = WMS_PutIn_Bll.Select_PutIn(string.Empty);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WMS_PutIn_Model wms_PutIn_Model = new WMS_PutIn_Model
                {
                    ShelfNo = dt.Rows[i]["ShelfNo"].ToString(),
                    PutInNo = dt.Rows[i]["PutInNo"].ToString(),
                    SN = dt.Rows[i]["SN"].ToString(),
                    OrderNo = dt.Rows[i]["OrderNo"].ToString(),
                    PutInType = dt.Rows[i]["PutInType"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    PutInTime = dt.Rows[i]["PutInTime"].ToString()
                };
                list.Add(wms_PutIn_Model);
            }
            return list;
        }
    }
}
