using DMSkin.WPF.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WCS.Converters;
using WCS.View.TopBar;
using WCS.ViewModel.LoginM;

namespace WCS
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Width = SystemParameters.PrimaryScreenWidth;
            this.Height = SystemParameters.PrimaryScreenHeight;
            this.userInfoName.Text = LoginViewModel.loginName;
        }

        /// <summary>
        /// 系统设置Check事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sysRB_Checked(object sender, RoutedEventArgs e)
        {
            sysRB.IsChecked = false;
        }

        /// <summary>
        /// 换肤Check事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinRB_Checked(object sender, RoutedEventArgs e)
        {
            //skinRB.IsChecked = false;
        }

        /// <summary>
        /// 信息框Check事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void messageRB_Checked(object sender, RoutedEventArgs e)
        {
            messageRB.IsChecked = false;
        }

        /// <summary>
        /// 当前用户Check事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userInfoRB_Checked(object sender, RoutedEventArgs e)
        {
            userInfoRB.IsChecked = false;
        }

        /// <summary>
        /// 关闭按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMSystemCloseButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
