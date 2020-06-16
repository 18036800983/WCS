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
using System.Windows.Shapes;
using WCS.ViewModel.LoginM;
using WCS_Bll;

namespace WCS.View.LoginM
{
    /// <summary>
    /// LoginPage.xaml 的交互逻辑
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 登录事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            if (LoginCheck(UserTextBox.Text.Trim(), PwdTextBox.Password.Trim()))
            {
                LoginViewModel.loginName = UserTextBox.Text.Trim();
                MainWindow mainWindow = new MainWindow();
                App.Current.MainWindow = mainWindow;
                this.Close();
                mainWindow.Show();
            }
            else 
            {
                UserTextBox.Text = string.Empty;
                PwdTextBox.Password = string.Empty;
            }
        }

        /// <summary>
        /// 关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool LoginCheck(string loginName,string password) 
        {
            DataTable dataTable = WMS_User_Bll.Select_User(" LoginName = '" + loginName + "'");
            if (dataTable.Rows.Count != 1)
            {
                MessageBox.Show("用户数量错误");
                return false;
            }
            else 
            {
                if (dataTable.Rows[0]["LoginPassword"].ToString() == password)
                    return true;
                else
                {
                    MessageBox.Show("密码错误");
                    return false;
                }
            }
        }
    }
}
