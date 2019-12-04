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
    /// WarehousePage.xaml 的交互逻辑
    /// </summary>
    public partial class WarehousePage : Page
    {
        WMS_Warehouse_Model wms_Warehouse_Model = new WMS_Warehouse_Model();
        WarehouseBase warehouseBase = new WarehouseBase();
        int editFlag = 0;//可编辑标签
        string warehouseName = string.Empty;
        List<string> selectWarehouseName = new List<string>();
        public WarehousePage()
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
            WarehouseDataGrid.IsReadOnly = false;
            WarehouseDataGrid.CanUserAddRows = true;
        }

        /// <summary>
        /// 编辑按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Edit_Click(object sender, RoutedEventArgs e)
        {
            editFlag = 2;
            WarehouseDataGrid.IsReadOnly = false;
            WarehouseDataGrid.CanUserAddRows = false;
        }

        /// <summary>
        /// 删除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Delete_Click(object sender, RoutedEventArgs e)
        {
            foreach (var no in selectWarehouseName)
            {
                WMS_Warehouse_Bll.Delete_Warehouse(" WarehouseName = '" + no + "'");
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
                WMS_Warehouse_Bll.Insert_Warehouse(wms_Warehouse_Model);
            }
            else if (editFlag == 2)
            {
                WMS_Warehouse_Bll.Update_Warehouse(wms_Warehouse_Model, " WarehouseName = '" + warehouseName + "'");
            }
            editFlag = 0;
            Page_Frush();
            WarehouseDataGrid.CanUserAddRows = false;
            WarehouseDataGrid.IsReadOnly = true;
        }

        /// <summary>
        /// 搜索按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Search_Click(object sender, RoutedEventArgs e)
        {
            warehouseBase.WarehouseList.Clear();
            List<WMS_Warehouse_Model> list = new List<WMS_Warehouse_Model>();
            DataTable dt = WMS_Warehouse_Bll.Select_Warehouse(" WarehouseName = '" + SearchText.Text.Trim() + "'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WMS_Warehouse_Model wMS_Warehouse_Model = new WMS_Warehouse_Model
                {
                    WarehouseName = dt.Rows[i]["WarehouseName"].ToString(),
                    WarehouseNo = dt.Rows[i]["WarehouseNo"].ToString(),
                    Remark = dt.Rows[i]["Remark"].ToString(),
                    CreatPerson = dt.Rows[i]["CreatPerson"].ToString(),
                    CreatTime = dt.Rows[i]["CreatTime"].ToString(),
                    ModifyPerson = dt.Rows[i]["ModifyPerson"].ToString(),
                    ModifyTime = dt.Rows[i]["ModifyTime"].ToString()
                };
                list.Add(wMS_Warehouse_Model);
            }
            foreach (var model in list)
            {
                warehouseBase.WarehouseList.Add(model);
            }
            this.WarehouseDataGrid.ItemsSource = warehouseBase.WarehouseList;
        }

        /// <summary>
        /// 编辑事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WarehouseDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            wms_Warehouse_Model = e.Row.Item as WMS_Warehouse_Model;
            warehouseName = wms_Warehouse_Model.WarehouseName;
        }

        /// <summary>
        /// 选中框事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox dg = sender as CheckBox;
            string name = dg.Tag.ToString();
            var bl = dg.IsChecked;
            if (bl == true)
            {
                selectWarehouseName.Add(name);
            }
            else
            {
                selectWarehouseName.Remove(name);
            }
        }

        /// <summary>
        /// 实时界面数据刷新
        /// </summary>
        private void Page_Frush()
        {
            warehouseBase.WarehouseList.Clear();
            foreach (var model in WarehouseViewModel.GetWarehouseList())
            {
                warehouseBase.WarehouseList.Add(model);
            }
            this.WarehouseDataGrid.ItemsSource = warehouseBase.WarehouseList;
        }
    }
}
