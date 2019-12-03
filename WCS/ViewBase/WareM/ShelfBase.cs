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
    public class ShelfBase : ViewModelBase
    {
        #region 选中
        private WMS_Shelf_Model selectedShelf;

        public WMS_Shelf_Model SelectedShelf
        {
            get { return selectedShelf; }
            set
            {
                selectedShelf = value;
                OnPropertyChanged("SelectedShelf");
            }
        }
        #endregion

        #region 列表
        private ObservableCollection<WMS_Shelf_Model> shelfList;

        public ObservableCollection<WMS_Shelf_Model> ShelfList
        {
            get
            {
                if (shelfList == null)
                {
                    shelfList = new ObservableCollection<WMS_Shelf_Model>();
                }
                return shelfList;
            }
            set
            {
                shelfList = value;
                OnPropertyChanged("ShelfList");
            }
        }
        #endregion

        #region 是否显示列表
        private bool displayShelfList;

        public bool DisplayShelfList
        {
            get { return displayShelfList; }
            set
            {
                displayShelfList = value;
                OnPropertyChanged("DisplayShelfList");
            }
        }

        public void ShowShelfList(bool show = true)
        {
            if (ShelfList.Count > 0)
            {
                DisplayShelfList = show;
            }
            else
            {
                DisplayShelfList = false;
            }
        }
        #endregion
    }
}
