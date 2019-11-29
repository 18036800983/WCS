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
using WCS.ViewBase.BaseM;
using WCS.ViewModel.BaseM;
using WCS_Bll;
using WCS_Model.DB;

namespace WCS.View.BaseM
{
    /// <summary>
    /// SupplierPage.xaml 的交互逻辑
    /// </summary>
    public partial class SupplierPage : Page
    {
        WMS_Supplier_Model wms_Supplier_Model = new WMS_Supplier_Model();
        SupplierBase supplierBase = new SupplierBase();
        int editFlag = 0;//可编辑标签
        string partName = string.Empty;
        List<string> selectPartName = new List<string>();
        public SupplierPage()
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
            SupplierDataGrid.IsReadOnly = false;
            SupplierDataGrid.CanUserAddRows = true;
        }

        /// <summary>
        /// 编辑按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Edit_Click(object sender, RoutedEventArgs e)
        {
            editFlag = 2;
            SupplierDataGrid.IsReadOnly = false;
            SupplierDataGrid.CanUserAddRows = false;
        }

        /// <summary>
        /// 删除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Delete_Click(object sender, RoutedEventArgs e)
        {
            foreach (var name in selectPartName)
            {
                WMS_Supplier_Bll.Delete_Supplier(" PartName = '" + name + "'");
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
                WMS_Supplier_Bll.Insert_Supplier(wms_Supplier_Model);
            }
            else if (editFlag == 2)
            {
                WMS_Supplier_Bll.Update_Supplier(wms_Supplier_Model, " PartName = '" + partName + "'");
            }
            editFlag = 0;
            Page_Frush();
            SupplierDataGrid.CanUserAddRows = false;
            SupplierDataGrid.IsReadOnly = true;
        }

        /// <summary>
        /// 搜索按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Search_Click(object sender, RoutedEventArgs e)
        {
            supplierBase.SupplierList.Clear();
            List<WMS_Supplier_Model> list = new List<WMS_Supplier_Model>();
            DataTable dt = WMS_Supplier_Bll.Select_Supplier(" PartName = '" + SearchText.Text.Trim() + "'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WMS_Supplier_Model wMS_Supplier_Model = new WMS_Supplier_Model
                {
                    CompanyName = dt.Rows[i]["CompanyName"].ToString(),
                    PartName = dt.Rows[i]["PartName"].ToString(),
                    CreatPerson = dt.Rows[i]["CreatPerson"].ToString(),
                    CreatTime = dt.Rows[i]["CreatTime"].ToString(),
                    ModifyPerson = dt.Rows[i]["ModifyPerson"].ToString(),
                    ModifyTime = dt.Rows[i]["ModifyTime"].ToString()
                };
                list.Add(wMS_Supplier_Model);
            }
            foreach (var model in list)
            {
                supplierBase.SupplierList.Add(model);
            }
            this.SupplierDataGrid.ItemsSource = supplierBase.SupplierList;
        }

        /// <summary>
        /// DataDrid编辑事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            wms_Supplier_Model = e.Row.Item as WMS_Supplier_Model;
            partName = wms_Supplier_Model.PartName;
        }

        /// <summary>
        /// 选中框选中事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox dg = sender as CheckBox;
            string productionName = dg.Tag.ToString();
            var bl = dg.IsChecked;
            if (bl == true)
            {
                selectPartName.Add(productionName);
            }
            else
            {
                selectPartName.Remove(productionName);
            }
        }

        /// <summary>
        /// 实时界面数据刷新
        /// </summary>
        private void Page_Frush()
        {
            supplierBase.SupplierList.Clear();
            foreach (var model in SupplierViewModel.GetSupplierList())
            {
                supplierBase.SupplierList.Add(model);
            }
            this.SupplierDataGrid.ItemsSource = supplierBase.SupplierList;
        }
    }
}
