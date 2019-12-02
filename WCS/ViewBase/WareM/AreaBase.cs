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
    public class AreaBase : ViewModelBase
    {
        #region 选中
        private WMS_Area_Model selectedArea;

        public WMS_Area_Model SelectedArea
        {
            get { return selectedArea; }
            set
            {
                selectedArea = value;
                OnPropertyChanged("SelectedArea");
            }
        }
        #endregion

        #region 列表
        private ObservableCollection<WMS_Area_Model> areaList;

        public ObservableCollection<WMS_Area_Model> AreaList
        {
            get
            {
                if (areaList == null)
                {
                    areaList = new ObservableCollection<WMS_Area_Model>();
                }
                return areaList;
            }
            set
            {
                areaList = value;
                OnPropertyChanged("AreaList");
            }
        }
        #endregion

        #region 是否显示列表
        private bool displayAreaList;

        public bool DisplayAreaList
        {
            get { return displayAreaList; }
            set
            {
                displayAreaList = value;
                OnPropertyChanged("DisplayAreaList");
            }
        }

        public void ShowAreaList(bool show = true)
        {
            if (AreaList.Count > 0)
            {
                DisplayAreaList = show;
            }
            else
            {
                DisplayAreaList = false;
            }
        }
        #endregion
    }
}
