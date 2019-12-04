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
    public class StorageBase : ViewModelBase
    {
        #region 选中
        private WMS_Stock_Model selectedStock;

        public WMS_Stock_Model SelectedStock
        {
            get { return selectedStock; }
            set
            {
                selectedStock = value;
                OnPropertyChanged("SelectedStock");
            }
        }
        #endregion

        #region 列表
        private ObservableCollection<WMS_Stock_Model> stockList;

        public ObservableCollection<WMS_Stock_Model> StockList
        {
            get
            {
                if (stockList == null)
                {
                    stockList = new ObservableCollection<WMS_Stock_Model>();
                }
                return stockList;
            }
            set
            {
                stockList = value;
                OnPropertyChanged("StockList");
            }
        }
        #endregion

        #region 是否显示列表
        private bool displayStockList;

        public bool DisplayStockList
        {
            get { return displayStockList; }
            set
            {
                displayStockList = value;
                OnPropertyChanged("DisplayStockList");
            }
        }

        public void ShowStockList(bool show = true)
        {
            if (StockList.Count > 0)
            {
                DisplayStockList = show;
            }
            else
            {
                DisplayStockList = false;
            }
        }
        #endregion
    }
}
