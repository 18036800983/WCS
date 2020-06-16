using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WCS.View.BaseM;
using WCS.View.BoardM;
using WCS.View.LogM;
using WCS.View.SysM;
using WCS.View.TopBar;
using WCS.View.WareM;

namespace WCS.Manager
{
    public class PageManager
    {
        #region Base
        public static HomePage homePage;

        public static BarcodeRulePage barcodeRulePage;

        public static ClientPage clientPage;

        public static ProductionPage productionPage;

        public static SupplierPage supplierPage;
        #endregion

        #region Board
        public static WareHouseBoardPage wareHouseBoardPage;

        public static WareHouseChartPage wareHouseChartPage;
        #endregion

        #region Log
        public static ChartLogPage chartLogPage;

        public static LoginLogPage loginLogPage;

        public static RunLoginPage runLoginPage;

        public static SysLogPage sysLogPage;
        #endregion

        #region sys
        public static CharacterPage characterPage;

        public static PartmentPage partmentPage;

        public static PermissionPage permissionPage;

        public static UserPage userPage;
        #endregion

        #region Ware
        public static AreaPage areaPage;

        public static InStockPage inStockPage;

        public static OutWarehousePage outWarehousePage;

        public static ShelfPage shelfPage;

        public static StoragePage storagePage;

        public static WarehousePage warehousePage;
        #endregion

        #region Top bar
        public static MessagePage messagePage;

        public static SettingPage settingPage;

        public static SkinPage skinPage;

        public static UserInfoPage userInfoPage;
        #endregion
    }
}
