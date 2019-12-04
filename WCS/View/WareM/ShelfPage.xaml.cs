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
    /// ShelfPage.xaml 的交互逻辑
    /// </summary>
    public partial class ShelfPage : Page
    {
        WMS_Shelf_Model wms_Shelf_Model = new WMS_Shelf_Model();
        ShelfBase shelfBase = new ShelfBase();
        int editFlag = 0;//可编辑标签
        string shelfName = string.Empty;
        List<string> selectShelfName = new List<string>();
        public ShelfPage()
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
            ShelfDataGrid.IsReadOnly = false;
            ShelfDataGrid.CanUserAddRows = true;
        }

        /// <summary>
        /// 编辑按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Edit_Click(object sender, RoutedEventArgs e)
        {
            editFlag = 2;
            ShelfDataGrid.IsReadOnly = false;
            ShelfDataGrid.CanUserAddRows = false;
        }

        /// <summary>
        /// 删除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Delete_Click(object sender, RoutedEventArgs e)
        {
            foreach (var no in selectShelfName)
            {
                WMS_Shelf_Bll.Delete_Shelf(" ShelfName = '" + no + "'");
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
                WMS_Shelf_Bll.Insert_Shelf(wms_Shelf_Model);
            }
            else if (editFlag == 2)
            {
                WMS_Shelf_Bll.Update_Shelf(wms_Shelf_Model, " ShelfName = '" + shelfName + "'");
            }
            editFlag = 0;
            Page_Frush();
            ShelfDataGrid.CanUserAddRows = false;
            ShelfDataGrid.IsReadOnly = true;
        }

        /// <summary>
        /// 搜索按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Search_Click(object sender, RoutedEventArgs e)
        {
            shelfBase.ShelfList.Clear();
            List<WMS_Shelf_Model> list = new List<WMS_Shelf_Model>();
            DataTable dt = WMS_Shelf_Bll.Select_Shelf(" ShelfName = '" + SearchText.Text.Trim() + "'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WMS_Shelf_Model wMS_Shelf_Model = new WMS_Shelf_Model
                {
                    ShelfName = dt.Rows[i]["ShelfName"].ToString(),
                    ShelfNo = dt.Rows[i]["ShelfNo"].ToString(),
                    AreaNo = dt.Rows[i]["AreaNo"].ToString(),
                    WarehouseNo = dt.Rows[i]["WarehouseNo"].ToString(),
                    Remark = dt.Rows[i]["Remark"].ToString(),
                    CreatPerson = dt.Rows[i]["CreatPerson"].ToString(),
                    CreatTime = dt.Rows[i]["CreatTime"].ToString(),
                    ModifyPerson = dt.Rows[i]["ModifyPerson"].ToString(),
                    ModifyTime = dt.Rows[i]["ModifyTime"].ToString()
                };
                list.Add(wMS_Shelf_Model);
            }
            foreach (var model in list)
            {
                shelfBase.ShelfList.Add(model);
            }
            this.ShelfDataGrid.ItemsSource = shelfBase.ShelfList;
        }

        /// <summary>
        /// 编辑事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShelfDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            wms_Shelf_Model = e.Row.Item as WMS_Shelf_Model;
            shelfName = wms_Shelf_Model.ShelfName;
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
                selectShelfName.Add(name);
            }
            else
            {
                selectShelfName.Remove(name);
            }
        }

        /// <summary>
        /// 实时界面数据刷新
        /// </summary>
        private void Page_Frush()
        {
            shelfBase.ShelfList.Clear();
            foreach (var model in ShelfViewModel.GetShelfList())
            {
                shelfBase.ShelfList.Add(model);
            }
            this.ShelfDataGrid.ItemsSource = shelfBase.ShelfList;
        }
    }
}
