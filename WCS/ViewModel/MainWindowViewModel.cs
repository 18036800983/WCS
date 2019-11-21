using DMSkin.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WCS.Manager;
using WCS.Model;

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
                        CurrentPage = PageManager.homePage;
                        break;
                    case LeftMenu.BarcodeRule:
                        CurrentPage = PageManager.barcodeRulePage;
                        break;
                    case LeftMenu.Client:
                        CurrentPage = PageManager.clientPage;
                        break;
                    case LeftMenu.Prodution:
                        CurrentPage = PageManager.productionPage;
                        break;
                    case LeftMenu.Supplier:
                        CurrentPage = PageManager.supplierPage;
                        break;
                    case LeftMenu.WareHouseBoard:
                        CurrentPage = PageManager.wareHouseBoardPage;
                        break;
                    case LeftMenu.WareHouseChart:
                        CurrentPage = PageManager.wareHouseChartPage;
                        break;
                    case LeftMenu.ChartLog:
                        CurrentPage = PageManager.chartLogPage;
                        break;
                    case LeftMenu.LoginLog:
                        CurrentPage = PageManager.loginLogPage;
                        break;
                    case LeftMenu.RunLog:
                        CurrentPage = PageManager.runLoginPage;
                        break;
                    case LeftMenu.SysLog:
                        CurrentPage = PageManager.sysLogPage;
                        break;
                    case LeftMenu.Character:
                        CurrentPage = PageManager.characterPage;
                        break;
                    case LeftMenu.Partment:
                        CurrentPage = PageManager.partmentPage;
                        break;
                    case LeftMenu.Permiss:
                        CurrentPage = PageManager.permissionPage;
                        break;
                    case LeftMenu.User:
                        CurrentPage = PageManager.userPage;
                        break;
                    case LeftMenu.Area:
                        CurrentPage = PageManager.areaPage;
                        break;
                    case LeftMenu.InStock:
                        CurrentPage = PageManager.inStockPage;
                        break;
                    case LeftMenu.OutWarehouse:
                        CurrentPage = PageManager.outWarehousePage;
                        break;
                    case LeftMenu.Shelf:
                        CurrentPage = PageManager.shelfPage;
                        break;
                    case LeftMenu.Storage:
                        CurrentPage = PageManager.storagePage;
                        break;
                    case LeftMenu.WareHouse:
                        CurrentPage = PageManager.warehousePage;
                        break;
                }
                OnPropertyChanged("SelectMenu");
            }
        }
        #endregion
    }
}
