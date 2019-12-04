using DMSkin.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS_Model.DB;

namespace WCS.ViewBase.WareM
{
    public class WarehouseBase : ViewModelBase
    {
        #region 选中
        private WMS_Warehouse_Model selectedWarehouse;

        public WMS_Warehouse_Model SelectedWarehouse
        {
            get { return selectedWarehouse; }
            set
            {
                selectedWarehouse = value;
                OnPropertyChanged("SelectedWarehouse");
            }
        }
        #endregion

        #region 列表
        private ObservableCollection<WMS_Warehouse_Model> warehouseList;

        public ObservableCollection<WMS_Warehouse_Model> WarehouseList
        {
            get
            {
                if (warehouseList == null)
                {
                    warehouseList = new ObservableCollection<WMS_Warehouse_Model>();
                }
                return warehouseList;
            }
            set
            {
                warehouseList = value;
                OnPropertyChanged("WarehouseList");
            }
        }
        #endregion

        #region 是否显示列表
        private bool displayWarehouseList;

        public bool DisplayWarehouseList
        {
            get { return displayWarehouseList; }
            set
            {
                displayWarehouseList = value;
                OnPropertyChanged("DisplayWarehouseList");
            }
        }

        public void ShowWarehouseList(bool show = true)
        {
            if (WarehouseList.Count > 0)
            {
                DisplayWarehouseList = show;
            }
            else
            {
                DisplayWarehouseList = false;
            }
        }
        #endregion
    }
}
