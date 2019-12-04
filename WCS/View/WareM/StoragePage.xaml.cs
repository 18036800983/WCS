using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WCS.ViewBase.WareM;
using WCS.ViewModel.WareM;
using WCS_Bll;
using WCS_Model.DB;

namespace WCS.View.WareM
{
    /// <summary>
    /// StoragePage.xaml 的交互逻辑
    /// </summary>
    public partial class StoragePage : Page
    {
        WMS_Stock_Model wms_Stock_Model = new WMS_Stock_Model();
        StorageBase stockBase = new StorageBase();
        int editFlag = 0;//可编辑标签
        string stockName = string.Empty;
        List<string> selectStockName = new List<string>();
        public StoragePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 添加按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Add_Click(object sender, RoutedEventArgs e)
        {
            editFlag = 1;
            StockDataGrid.IsReadOnly = false;
            StockDataGrid.CanUserAddRows = true;
        }

        /// <summary>
        /// 编辑按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Edit_Click(object sender, RoutedEventArgs e)
        {
            editFlag = 2;
            StockDataGrid.IsReadOnly = false;
            StockDataGrid.CanUserAddRows = false;
        }

        /// <summary>
        /// 删除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Delete_Click(object sender, RoutedEventArgs e)
        {
            foreach (var no in selectStockName)
            {
                WMS_Stock_Bll.Delete_Stock(" SN = '" + no + "'");
            }
            Page_Frush();
        }

        /// <summary>
        /// 保存按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Save_Click(object sender, RoutedEventArgs e)
        {
            if (editFlag == 1)
            {
                WMS_Stock_Bll.Insert_Stock(wms_Stock_Model);
            }
            else if (editFlag == 2)
            {
                WMS_Stock_Bll.Update_Stock(wms_Stock_Model, " SN = '" + stockName + "'");
            }
            editFlag = 0;
            Page_Frush();
            StockDataGrid.CanUserAddRows = false;
            StockDataGrid.IsReadOnly = true;
        }

        /// <summary>
        /// 搜索按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Search_Click(object sender, RoutedEventArgs e)
        {
            stockBase.StockList.Clear();
            List<WMS_Stock_Model> list = new List<WMS_Stock_Model>();
            DataTable dt = WMS_Stock_Bll.Select_Stock(" SN = '" + SearchText.Text.Trim() + "'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WMS_Stock_Model wMS_Stock_Model = new WMS_Stock_Model
                {
                    ShelfNo = dt.Rows[i]["ShelfNo"].ToString(),
                    AreaNo = dt.Rows[i]["AreaNo"].ToString(),
                    WarehouseNo = dt.Rows[i]["WarehouseNo"].ToString(),
                    SN = dt.Rows[i]["SN"].ToString(),
                    ProductionNo = dt.Rows[i]["ProductionNo"].ToString(),
                    PutInNo = dt.Rows[i]["PutInNo"].ToString()
                };
                list.Add(wMS_Stock_Model);
            }
            foreach (var model in list)
            {
                stockBase.StockList.Add(model);
            }
            this.StockDataGrid.ItemsSource = stockBase.StockList;
        }

        /// <summary>
        /// 编辑事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            wms_Stock_Model = e.Row.Item as WMS_Stock_Model;
            stockName = wms_Stock_Model.SN;
        }

        /// <summary>
        /// 选中框事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox dg = sender as CheckBox;
            string sn = dg.Tag.ToString();
            var bl = dg.IsChecked;
            if (bl == true)
            {
                selectStockName.Add(sn);
            }
            else
            {
                selectStockName.Remove(sn);
            }
        }

        /// <summary>
        /// 实时界面数据刷新
        /// </summary>
        private void Page_Frush()
        {
            stockBase.StockList.Clear();
            foreach (var model in StorageViewModel.GetStockList())
            {
                stockBase.StockList.Add(model);
            }
            this.StockDataGrid.ItemsSource = stockBase.StockList;
        }
    }
}
