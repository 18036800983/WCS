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
    public class InStockBase : ViewModelBase
    {
        #region 选中
        private WMS_PutIn_Model selectedPutIn;

        public WMS_PutIn_Model SelectedPutIn
        {
            get { return selectedPutIn; }
            set
            {
                selectedPutIn = value;
                OnPropertyChanged("SelectedPutIn");
            }
        }
        #endregion

        #region 列表
        private ObservableCollection<WMS_PutIn_Model> putInList;

        public ObservableCollection<WMS_PutIn_Model> PutInList
        {
            get
            {
                if (putInList == null)
                {
                    putInList = new ObservableCollection<WMS_PutIn_Model>();
                }
                return putInList;
            }
            set
            {
                putInList = value;
                OnPropertyChanged("PutInList");
            }
        }
        #endregion

        #region 是否显示列表
        private bool displayPutInList;

        public bool DisplayPutInList
        {
            get { return displayPutInList; }
            set
            {
                displayPutInList = value;
                OnPropertyChanged("DisplayPutInList");
            }
        }

        public void ShowPutInList(bool show = true)
        {
            if (PutInList.Count > 0)
            {
                DisplayPutInList = show;
            }
            else
            {
                DisplayPutInList = false;
            }
        }
        #endregion
    }
}
