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
    /// ProductionPage.xaml 的交互逻辑
    /// </summary>
    public partial class ProductionPage : Page
    {
        WMS_Production_Model wms_Production_Model = new WMS_Production_Model();
        ProductionBase productionBase = new ProductionBase();
        int editFlag = 0;//可编辑标签
        string productionName = string.Empty;
        List<string> selectProductionName = new List<string>();
        public ProductionPage()
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
            ProductionDataGrid.IsReadOnly = false;
            ProductionDataGrid.CanUserAddRows = true;
        }

        /// <summary>
        /// 编辑按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Edit_Click(object sender, RoutedEventArgs e)
        {
            editFlag = 2;
            ProductionDataGrid.IsReadOnly = false;
            ProductionDataGrid.CanUserAddRows = false;
        }

        /// <summary>
        /// 删除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Delete_Click(object sender, RoutedEventArgs e)
        {
            foreach (var name in selectProductionName)
            {
                WMS_Production_Bll.Delete_Production(" ProductionName = '" + name + "'");
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
                WMS_Production_Bll.Insert_Production(wms_Production_Model);
            }
            else if (editFlag == 2)
            {
                WMS_Production_Bll.Update_Production(wms_Production_Model, " ProductionName = '" + productionName + "'");
            }
            editFlag = 0;
            Page_Frush();
            ProductionDataGrid.CanUserAddRows = false;
            ProductionDataGrid.IsReadOnly = true;
        }

        /// <summary>
        /// 搜索按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Search_Click(object sender, RoutedEventArgs e)
        {
            productionBase.ProductionList.Clear();
            List<WMS_Production_Model> list = new List<WMS_Production_Model>();
            DataTable dt = WMS_Production_Bll.Select_Production(" ProductionName = '" + SearchText.Text.Trim() + "'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WMS_Production_Model wMS_Production_Model = new WMS_Production_Model
                {
                    ProductionNo = dt.Rows[i]["ProductionNo"].ToString(),
                    ProductionName = dt.Rows[i]["ProductionName"].ToString(),
                    LocationNo = dt.Rows[i]["LocationNo"].ToString(),
                    WarehouseNo = dt.Rows[i]["WarehouseNo"].ToString(),
                    CreatPerson = dt.Rows[i]["CreatPerson"].ToString(),
                    CreatTime = dt.Rows[i]["CreatTime"].ToString(),
                    ModifyPerson = dt.Rows[i]["ModifyPerson"].ToString(),
                    ModifyTime = dt.Rows[i]["ModifyTime"].ToString()
                };
                list.Add(wMS_Production_Model);
            }
            foreach (var model in list)
            {
                productionBase.ProductionList.Add(model);
            }
            this.ProductionDataGrid.ItemsSource = productionBase.ProductionList;
        }

        /// <summary>
        /// DataGrid编辑事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductionDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            wms_Production_Model = e.Row.Item as WMS_Production_Model;
            productionName = wms_Production_Model.ProductionName;
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
                selectProductionName.Add(productionName);
            }
            else
            {
                selectProductionName.Remove(productionName);
            }
        }

        /// <summary>
        /// 实时界面数据刷新
        /// </summary>
        private void Page_Frush()
        {
            productionBase.ProductionList.Clear();
            foreach (var model in ProductionViewModel.GetProductionList())
            {
                productionBase.ProductionList.Add(model);
            }
            this.ProductionDataGrid.ItemsSource = productionBase.ProductionList;
        }
    }
}
