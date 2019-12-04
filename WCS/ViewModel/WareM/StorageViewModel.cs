﻿using System;
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
    public class StorageViewModel : StorageBase
    {
        public StorageViewModel()
        {
            ShowStockTable();
        }
        /// <summary>
        /// 显示条码规则列表
        /// </summary>
        public void ShowStockTable()
        {
            foreach (var model in GetStockList())
            {
                StockList.Add(model);
            }
            ShowStockList();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public static List<WMS_Stock_Model> GetStockList()
        {
            List<WMS_Stock_Model> list = new List<WMS_Stock_Model>();
            DataTable dt = WMS_Stock_Bll.Select_Stock(string.Empty);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WMS_Stock_Model wms_Stock_Model = new WMS_Stock_Model
                {
                    ShelfNo = dt.Rows[i]["ShelfNo"].ToString(),
                    AreaNo = dt.Rows[i]["AreaNo"].ToString(),
                    WarehouseNo = dt.Rows[i]["WarehouseNo"].ToString(),
                    SN = dt.Rows[i]["SN"].ToString(),
                    ProductionNo = dt.Rows[i]["ProductionNo"].ToString(),
                    PutInNo = dt.Rows[i]["PutInNo"].ToString()
                };
                list.Add(wms_Stock_Model);
            }
            return list;
        }
    }
}
