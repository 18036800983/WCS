using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS.ViewBase.BoardM;
using WCS_Bll;
using WCS_Model.DB;

namespace WCS.ViewModel.BoardM
{
    public class WareHouseBoardViewModel : WareHouseBoardBase
    {
        public WareHouseBoardViewModel()
        {
            ShowStoreDisplayTable();
        }
        /// <summary>
        /// 显示列表
        /// </summary>
        public void ShowStoreDisplayTable()
        {
            foreach (var model in GetStoreDisplayList())
            {
                StoreDisplayList.Add(model);
            }
            ShowStoreDisplayList();
        }

        static WMS_StoreDisplay_Model wMS_StoreDisplay_Model = new WMS_StoreDisplay_Model();
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public static List<WMS_StoreDisplay_Model> GetStoreDisplayList()
        {
            List<WMS_StoreDisplay_Model> list = new List<WMS_StoreDisplay_Model>();
            DataTable dataTable = WMS_Stock_Bll.Select_StockDisplay();
            DataTable shelfDt = WMS_Shelf_Bll.Select_Shelf("ORDER");
            for (int i = 0; i < shelfDt.Rows.Count; i++) //货架数
            {
                DataTable dt = new DataTable();
                dt = dataTable.AsEnumerable().Where(o => o.Field<string>("AreaNo").ToString() == shelfDt.Rows[i]["AreaNo"].ToString()).CopyToDataTable();
                int f = 1;
                for (int m = 0; m < dt.Rows.Count; m++) //已存PACK
                {
                    for (int j = 1; j <= int.Parse(dt.Rows[m]["ShelfNo"].ToString().Substring(2)); j++)//以空补足未存位置--竖
                    {
                        if (int.Parse(dt.Rows[m]["LocationNo"].ToString().Substring(2)) == j)
                        {
                            for (int n = f; n < int.Parse(dt.Rows[m]["ShelfNo"].ToString().Substring(0, 2)); n++)//以空补足未存位置--横
                            {
                                if (int.Parse(dt.Rows[m]["LocationNo"].ToString().Substring(0, 2)) == f)
                                {
                                    SetColumn(f, dt.Rows[m]["SN"].ToString());
                                }
                                f++;
                                if (f == int.Parse(dt.Rows[m]["ShelfNo"].ToString().Substring(0, 2)))
                                    f = 1;
                            }
                        }
                        list.Add(wMS_StoreDisplay_Model);
                        wMS_StoreDisplay_Model = new WMS_StoreDisplay_Model();
                    }
                }
            }
            return list;
        }

        public static void SetColumn(int v,string input) 
        {
            switch (v) 
            {
                case 1:
                    wMS_StoreDisplay_Model.Column1 = input;
                    break;
                case 2:
                    wMS_StoreDisplay_Model.Column2 = input;
                    break;
                case 3:
                    wMS_StoreDisplay_Model.Column3 = input;
                    break;
                case 4:
                    wMS_StoreDisplay_Model.Column4 = input;
                    break;
                case 5:
                    wMS_StoreDisplay_Model.Column5 = input;
                    break;
                case 6:
                    wMS_StoreDisplay_Model.Column6 = input;
                    break;
                case 7:
                    wMS_StoreDisplay_Model.Column7 = input;
                    break;
                case 8:
                    wMS_StoreDisplay_Model.Column8 = input;
                    break;
                case 9:
                    wMS_StoreDisplay_Model.Column9 = input;
                    break;
                case 10:
                    wMS_StoreDisplay_Model.Column10 = input;
                    break;
                case 11:
                    wMS_StoreDisplay_Model.Column11 = input;
                    break;
                case 12:
                    wMS_StoreDisplay_Model.Column12 = input;
                    break;
                case 13:
                    wMS_StoreDisplay_Model.Column13 = input;
                    break;
                case 14:
                    wMS_StoreDisplay_Model.Column14 = input;
                    break;
                case 15:
                    wMS_StoreDisplay_Model.Column15 = input;
                    break;
                case 16:
                    wMS_StoreDisplay_Model.Column16 = input;
                    break;
                case 17:
                    wMS_StoreDisplay_Model.Column17 = input;
                    break;
                case 18:
                    wMS_StoreDisplay_Model.Column18 = input;
                    break;
                case 19:
                    wMS_StoreDisplay_Model.Column19 = input;
                    break;
                case 20:
                    wMS_StoreDisplay_Model.Column20 = input;
                    break;
                case 21:
                    wMS_StoreDisplay_Model.Column21 = input;
                    break;
                case 22:
                    wMS_StoreDisplay_Model.Column22 = input;
                    break;
                case 23:
                    wMS_StoreDisplay_Model.Column23 = input;
                    break;
                case 24:
                    wMS_StoreDisplay_Model.Column24 = input;
                    break;
                case 25:
                    wMS_StoreDisplay_Model.Column25 = input;
                    break;
                case 26:
                    wMS_StoreDisplay_Model.Column26 = input;
                    break;
                case 27:
                    wMS_StoreDisplay_Model.Column27 = input;
                    break;
                case 28:
                    wMS_StoreDisplay_Model.Column28 = input;
                    break;
                case 29:
                    wMS_StoreDisplay_Model.Column29 = input;
                    break;
                case 30:
                    wMS_StoreDisplay_Model.Column30 = input;
                    break;
            }
        }
    }
}
