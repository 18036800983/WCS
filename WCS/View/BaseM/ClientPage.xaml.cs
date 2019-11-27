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
    /// ClientPage.xaml 的交互逻辑
    /// </summary>
    public partial class ClientPage : Page
    {
        WMS_Client_Model wms_Client_Model = new WMS_Client_Model();
        ClientBase clientBase = new ClientBase();
        int editFlag = 0;//可编辑标签
        string clientName = string.Empty;
        List<string> selectClientName = new List<string>();
        public ClientPage()
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
            ClientDataGrid.IsReadOnly = false;
            ClientDataGrid.CanUserAddRows = true;
        }

        /// <summary>
        /// 编辑按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Edit_Click(object sender, RoutedEventArgs e)
        {
            editFlag = 2;
            ClientDataGrid.IsReadOnly = false;
            ClientDataGrid.CanUserAddRows = false;
        }

        /// <summary>
        /// 删除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Delete_Click(object sender, RoutedEventArgs e)
        {
            foreach (var name in selectClientName)
            {
                WMS_Client_Bll.Delete_Client(" CompanyName = '" + name + "'");
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
                WMS_Client_Bll.Insert_Client(wms_Client_Model);
            }
            else if (editFlag == 2)
            {
                WMS_Client_Bll.Update_Client(wms_Client_Model, " CompanyName = '" + clientName + "'");
            }
            editFlag = 0;
            Page_Frush();
            ClientDataGrid.CanUserAddRows = false;
            ClientDataGrid.IsReadOnly = true;
        }

        /// <summary>
        /// 搜索按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Search_Click(object sender, RoutedEventArgs e)
        {
            clientBase.ClientList.Clear();
            List<WMS_Client_Model> list = new List<WMS_Client_Model>();
            DataTable dt = WMS_Client_Bll.Select_Client(" CompanyName = '" + SearchText.Text.Trim() + "'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WMS_Client_Model wMS_Client_Model = new WMS_Client_Model
                {
                    CompanyName = dt.Rows[i]["CompanyName"].ToString(),
                    ProductionName = dt.Rows[i]["ProductionName"].ToString(),
                    CreatPerson = dt.Rows[i]["CreatPerson"].ToString(),
                    CreatTime = dt.Rows[i]["CreatTime"].ToString(),
                    ModifyPerson = dt.Rows[i]["ModifyPerson"].ToString(),
                    ModifyTime = dt.Rows[i]["ModifyTime"].ToString()
                };
                list.Add(wMS_Client_Model);
            }
            foreach (var model in list)
            {
                clientBase.ClientList.Add(model);
            }
            this.ClientDataGrid.ItemsSource = clientBase.ClientList;
        }

        /// <summary>
        /// 选中框选中事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox dg = sender as CheckBox;
            string companyName = dg.Tag.ToString();
            var bl = dg.IsChecked;
            if (bl == true)
            {
                selectClientName.Add(companyName);
            }
            else
            {
                selectClientName.Remove(companyName);
            }
        }

        /// <summary>
        /// 编辑结束事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClientDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            wms_Client_Model = e.Row.Item as WMS_Client_Model;
            clientName = wms_Client_Model.CompanyName;
        }

        /// <summary>
        /// 实时界面数据刷新
        /// </summary>
        private void Page_Frush()
        {
            clientBase.ClientList.Clear();
            foreach (var model in ClientViewModel.GetClienteList())
            {
                clientBase.ClientList.Add(model);
            }
            this.ClientDataGrid.ItemsSource = clientBase.ClientList;
        }
    }
}
