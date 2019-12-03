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
    public class OutWarehouseBase : ViewModelBase
    {
        #region 选中
        private WMS_PutOut_Model selectedPutOut;

        public WMS_PutOut_Model SelectedPutOut
        {
            get { return selectedPutOut; }
            set
            {
                selectedPutOut = value;
                OnPropertyChanged("SelectedPutOut");
            }
        }
        #endregion

        #region 列表
        private ObservableCollection<WMS_PutOut_Model> putOutList;

        public ObservableCollection<WMS_PutOut_Model> PutOutList
        {
            get
            {
                if (putOutList == null)
                {
                    putOutList = new ObservableCollection<WMS_PutOut_Model>();
                }
                return putOutList;
            }
            set
            {
                putOutList = value;
                OnPropertyChanged("PutOutList");
            }
        }
        #endregion

        #region 是否显示列表
        private bool displayPutOutList;

        public bool DisplayPutOutList
        {
            get { return displayPutOutList; }
            set
            {
                displayPutOutList = value;
                OnPropertyChanged("DisplayPutOutList");
            }
        }

        public void ShowPutOutList(bool show = true)
        {
            if (PutOutList.Count > 0)
            {
                DisplayPutOutList = show;
            }
            else
            {
                DisplayPutOutList = false;
            }
        }
        #endregion
    }
}
