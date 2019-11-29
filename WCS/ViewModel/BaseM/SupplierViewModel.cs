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
    public class SupplierViewModel : SupplierBase
    {
        public SupplierViewModel()
        {
            ShowSupplierTable();
        }
        /// <summary>
        /// 显示列表
        /// </summary>
        public void ShowSupplierTable()
        {
            foreach (var model in GetSupplierList())
            {
                SupplierList.Add(model);
            }
            ShowSupplierList();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public static List<WMS_Supplier_Model> GetSupplierList()
        {
            List<WMS_Supplier_Model> list = new List<WMS_Supplier_Model>();
            DataTable dt = WMS_Supplier_Bll.Select_Supplier(string.Empty);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WMS_Supplier_Model wms_Supplier_Model = new WMS_Supplier_Model
                {
                    CompanyName = dt.Rows[i]["CompanyName"].ToString(),
                    PartName = dt.Rows[i]["PartName"].ToString(),
                    CreatPerson = dt.Rows[i]["CreatPerson"].ToString(),
                    CreatTime = dt.Rows[i]["CreatTime"].ToString(),
                    ModifyPerson = dt.Rows[i]["ModifyPerson"].ToString(),
                    ModifyTime = dt.Rows[i]["ModifyTime"].ToString()
                };
                list.Add(wms_Supplier_Model);
            }
            return list;
        }
    }
}
