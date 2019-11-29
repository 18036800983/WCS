using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS.ViewBase.BaseM;
using WCS_Bll;
using WCS_Model.DB;

namespace WCS.ViewModel.BaseM
{
    public class BarcodeRuleViewModel : BarcodeRuleBase
    {
        public BarcodeRuleViewModel()
        {
            ShowBarcodeTable();
        }
        /// <summary>
        /// 显示条码规则列表
        /// </summary>
        public void ShowBarcodeTable()
        {
            foreach (var model in GetBarcodeList())
            {
                BarcodeList.Add(model);
            }
            ShowBarcodeList();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public static List<WMS_Barcode_Model> GetBarcodeList()
        {
            List<WMS_Barcode_Model> list = new List<WMS_Barcode_Model>();
            DataTable dt = WMS_Barcode_Bll.Select_Barcode(string.Empty);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WMS_Barcode_Model wms_Barcode_Model = new WMS_Barcode_Model
                {
                    BarcodeLength = int.Parse(dt.Rows[i]["BarcodeLength"].ToString()),
                    BarcodeRule = dt.Rows[i]["BarcodeRule"].ToString(),
                    ProductionNo = dt.Rows[i]["ProductionNo"].ToString(),
                    CreatPerson = dt.Rows[i]["CreatPerson"].ToString(),
                    CreatTime = dt.Rows[i]["CreatTime"].ToString(),
                    ModifyPerson = dt.Rows[i]["ModifyPerson"].ToString(),
                    ModifyTime = dt.Rows[i]["ModifyTime"].ToString()
                };
                list.Add(wms_Barcode_Model);
            }
            return list;
        }
    }
}
