using DMSkin.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WCS.Manager;
using WCS.Model;
using WCS.View.BaseM;
using WCS.View.BoardM;
using WCS.View.LogM;
using WCS.View.SysM;
using WCS.View.TopBar;
using WCS.View.WareM;
using WCS.ViewModel.TopBar;

namespace WCS.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region 页面切换
        private Page currentPage = PageManager.homePage;

        /// <summary>
        /// 当前页面
        /// </summary>
        public Page CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

        private LeftMenu selectMenu;
        /// <summary>
        /// 选中的菜单
        /// </summary>
        public LeftMenu SelectMenu
        {
            get { return selectMenu; }
            set
            {
                selectMenu = value;
                switch (selectMenu)
                {
                    case LeftMenu.Home:
                        CurrentPage = new HomePage();
                        break;
                    case LeftMenu.BarcodeRule:
                        CurrentPage = new BarcodeRulePage();
                        break;
                    case LeftMenu.Client:
                        CurrentPage = new ClientPage();
                        break;
                    case LeftMenu.Prodution:
                        CurrentPage = new ProductionPage();
                        break;
                    case LeftMenu.Supplier:
                        CurrentPage = new SupplierPage();
                        break;
                    case LeftMenu.WareHouseBoard:
                        CurrentPage = new WareHouseBoardPage();
                        break;
                    case LeftMenu.WareHouseChart:
                        CurrentPage = new WareHouseChartPage();
                        break;
                    case LeftMenu.ChartLog:
                        CurrentPage = new ChartLogPage();
                        break;
                    case LeftMenu.LoginLog:
                        CurrentPage = new LoginLogPage();
                        break;
                    case LeftMenu.RunLog:
                        CurrentPage = new RunLoginPage();
                        break;
                    case LeftMenu.SysLog:
                        CurrentPage = new SysLogPage();
                        break;
                    case LeftMenu.Character:
                        CurrentPage = new CharacterPage();
                        break;
                    case LeftMenu.Partment:
                        CurrentPage = new PartmentPage();
                        break;
                    case LeftMenu.Permiss:
                        CurrentPage = new PermissionPage();
                        break;
                    case LeftMenu.User:
                        CurrentPage = new UserPage();
                        break;
                    case LeftMenu.Area:
                        CurrentPage = new AreaPage();
                        break;
                    case LeftMenu.InStock:
                        CurrentPage = new InStockPage();
                        break;
                    case LeftMenu.OutWarehouse:
                        CurrentPage = new OutWarehousePage();
                        break;
                    case LeftMenu.Shelf:
                        CurrentPage = new ShelfPage();
                        break;
                    case LeftMenu.Storage:
                        CurrentPage = new StoragePage();
                        break;
                    case LeftMenu.WareHouse:
                        CurrentPage = new WarehousePage();
                        break;
                    case LeftMenu.Message:
                        //PageManager.messagePage = new View.TopBar.MessagePage();
                        CurrentPage = new MessagePage();
                        break;
                    case LeftMenu.Setting:
                        CurrentPage = new SettingPage();
                        break;
                    case LeftMenu.Skin:
                        CurrentPage =  new SkinPage();
                        break;
                    case LeftMenu.UserInfo:
                        CurrentPage = new UserInfoPage();
                        break;
                }
                OnPropertyChanged("SelectMenu");
            }
        }
        #endregion
    }
}
