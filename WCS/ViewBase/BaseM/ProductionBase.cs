using DMSkin.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS_Model.DB;

namespace WCS.ViewBase.BaseM
{
    public class ProductionBase : ViewModelBase
    {
        #region 选中
        private WMS_Production_Model selectedProduction;

        public WMS_Production_Model SelectedProduction
        {
            get { return selectedProduction; }
            set
            {
                selectedProduction = value;
                OnPropertyChanged("SelectedProduction");
            }
        }
        #endregion

        #region 列表
        private ObservableCollection<WMS_Production_Model> productionList;

        public ObservableCollection<WMS_Production_Model> ProductionList
        {
            get
            {
                if (productionList == null)
                {
                    productionList = new ObservableCollection<WMS_Production_Model>();
                }
                return productionList;
            }
            set
            {
                productionList = value;
                OnPropertyChanged("ProductionList");
            }
        }
        #endregion

        #region 是否显示列表
        private bool displayProductionList;

        public bool DisplayProductionList
        {
            get { return displayProductionList; }
            set
            {
                displayProductionList = value;
                OnPropertyChanged("DisplayProductionList");
            }
        }

        public void ShowProductionList(bool show = true)
        {
            if (ProductionList.Count > 0)
            {
                DisplayProductionList = show;
            }
            else
            {
                DisplayProductionList = false;
            }
        }
        #endregion
    }
}
