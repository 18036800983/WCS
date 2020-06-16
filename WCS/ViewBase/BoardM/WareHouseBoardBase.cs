using DMSkin.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS_Model.DB;

namespace WCS.ViewBase.BoardM
{
    public class WareHouseBoardBase : ViewModelBase
    {
        #region 列表
        private ObservableCollection<WMS_StoreDisplay_Model> storeDisplayList;

        public ObservableCollection<WMS_StoreDisplay_Model> StoreDisplayList
        {
            get
            {
                if (storeDisplayList == null)
                {
                    storeDisplayList = new ObservableCollection<WMS_StoreDisplay_Model>();
                }
                return storeDisplayList;
            }
            set
            {
                storeDisplayList = value;
                OnPropertyChanged("StoreDisplayList");
            }
        }
        #endregion

        #region 是否显示列表
        private bool displayStoreList;

        public bool DisplayStoreList
        {
            get { return displayStoreList; }
            set
            {
                displayStoreList = value;
                OnPropertyChanged("DisplayStoreList");
            }
        }

        public void ShowStoreDisplayList(bool show = true)
        {
            if (StoreDisplayList.Count > 0)
            {
                DisplayStoreList = show;
            }
            else
            {
                DisplayStoreList = false;
            }
        }
        #endregion
    }
}
