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
    /// BarcodeRulePage.xaml 的交互逻辑
    /// </summary>
    public partial class BarcodeRulePage : Page
    {
        WMS_Barcode_Model wms_Barcode_Model = new WMS_Barcode_Model();
        BarcodeRuleBase barcodeRuleBase = new BarcodeRuleBase();
        int editFlag = 0;//可编辑标签
        string productionNo = string.Empty;
        List<string> selectProductionNo = new List<string>();
        public BarcodeRulePage()
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
            BarcodeDataGrid.IsReadOnly = false;
            BarcodeDataGrid.CanUserAddRows = true;
        }

        /// <summary>
        /// 编辑按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Edit_Click(object sender, RoutedEventArgs e)
        {
            editFlag = 2;
            BarcodeDataGrid.IsReadOnly = false;
            BarcodeDataGrid.CanUserAddRows = false;
        }

        /// <summary>
        /// 删除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Delete_Click(object sender, RoutedEventArgs e)
        {
            foreach (var no in selectProductionNo)
            {
                WMS_Barcode_Bll.Delete_Barcode(" ProductionNo = '" + no + "'");
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
                WMS_Barcode_Bll.Insert_Barcode(wms_Barcode_Model);
            }
            else if (editFlag == 2)
            {
                WMS_Barcode_Bll.Update_Barcode(wms_Barcode_Model, " ProductionNo = '" + productionNo + "'");
            }
            editFlag = 0;
            Page_Frush();
            BarcodeDataGrid.CanUserAddRows = false;
            BarcodeDataGrid.IsReadOnly = true;
        }

        /// <summary>
        /// 搜索按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Search_Click(object sender, RoutedEventArgs e)
        {
            barcodeRuleBase.BarcodeList.Clear();
            List<WMS_Barcode_Model> list = new List<WMS_Barcode_Model>();
            DataTable dt = WMS_Barcode_Bll.Select_Barcode(" ProductionNo = '" + SearchText.Text.Trim() + "'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WMS_Barcode_Model wMS_Barcode_Model = new WMS_Barcode_Model
                {
                    BarcodeLength = int.Parse(dt.Rows[i]["BarcodeLength"].ToString()),
                    BarcodeRule = dt.Rows[i]["BarcodeRule"].ToString(),
                    ProductionNo = dt.Rows[i]["ProductionNo"].ToString(),
                    CreatPerson = dt.Rows[i]["CreatPerson"].ToString(),
                    CreatTime = dt.Rows[i]["CreatTime"].ToString(),
                    ModifyPerson = dt.Rows[i]["ModifyPerson"].ToString(),
                    ModifyTime = dt.Rows[i]["ModifyTime"].ToString()
                };
                list.Add(wMS_Barcode_Model);
            }
            foreach (var model in list)
            {
                barcodeRuleBase.BarcodeList.Add(model);
            }
            this.BarcodeDataGrid.ItemsSource = barcodeRuleBase.BarcodeList;
        }

        /// <summary>
        /// 选中框选中事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox dg = sender as CheckBox;
            string productionNo = dg.Tag.ToString();
            var bl = dg.IsChecked;
            if (bl == true)
            {
                selectProductionNo.Add(productionNo);
            }
            else
            {
                selectProductionNo.Remove(productionNo);
            }
        }

        /// <summary>
        /// DataGrid编辑完事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            wms_Barcode_Model = e.Row.Item as WMS_Barcode_Model;
            productionNo = wms_Barcode_Model.ProductionNo;
        }

        /// <summary>
        /// 实时界面数据刷新
        /// </summary>
        private void Page_Frush()
        {
            barcodeRuleBase.BarcodeList.Clear();
            foreach (var model in BarcodeRuleViewModel.GetBarcodeList())
            {
                barcodeRuleBase.BarcodeList.Add(model);
            }
            this.BarcodeDataGrid.ItemsSource = barcodeRuleBase.BarcodeList;
        }
    }
}
