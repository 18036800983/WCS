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
using WCS.View.WareM;

namespace WCS.Manager
{
    public class PageManager
    {
        #region Base
        public static HomePage homePage = new HomePage();

        public static BarcodeRulePage barcodeRulePage = new BarcodeRulePage();

        public static ClientPage clientPage = new ClientPage();

        public static ProductionPage productionPage = new ProductionPage();

        public static SupplierPage supplierPage = new SupplierPage();
        #endregion

        #region Board
        public static WareHouseBoardPage wareHouseBoardPage = new WareHouseBoardPage();

        public static WareHouseChartPage wareHouseChartPage = new WareHouseChartPage();
        #endregion

        #region Log
        public static ChartLogPage chartLogPage = new ChartLogPage();

        public static LoginLogPage loginLogPage = new LoginLogPage();

        public static RunLoginPage runLoginPage = new RunLoginPage();

        public static SysLogPage sysLogPage = new SysLogPage();
        #endregion

        #region sys
        public static CharacterPage characterPage = new CharacterPage();

        public static PartmentPage partmentPage = new PartmentPage();

        public static PermissionPage permissionPage = new PermissionPage();

        public static UserPage userPage = new UserPage();
        #endregion

        #region Ware
        public static AreaPage areaPage = new AreaPage();

        public static InStockPage inStockPage = new InStockPage();

        public static OutWarehousePage outWarehousePage = new OutWarehousePage();

        public static ShelfPage shelfPage = new ShelfPage();

        public static StoragePage storagePage = new StoragePage();

        public static WarehousePage warehousePage = new WarehousePage();
        #endregion
    }
}
