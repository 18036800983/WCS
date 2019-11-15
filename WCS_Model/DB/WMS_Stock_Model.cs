using DMSkin.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCS_Model.DB
{
    public class WMS_Stock_Model : ViewModelBase
    {
        private string shelfNo;

        private string areaNo;

        private string warehouseNo;

        private string sN;

        private string productionNo;

        private string putInNo;

        /// <summary>
        /// 货架编号
        /// </summary>
        public string ShelfNo
        {
            get => shelfNo;
            set { shelfNo = value; OnPropertyChanged("ShelfNo"); }
        }

        /// <summary>
        /// 库区编号
        /// </summary>
        public string AreaNo
        {
            get => areaNo;
            set { areaNo = value; OnPropertyChanged("AreaNo"); }
        }

        /// <summary>
        /// 仓库编号
        /// </summary>
        public string WarehouseNo
        {
            get => warehouseNo;
            set { warehouseNo = value; OnPropertyChanged("WarehouseNo"); }
        }

        /// <summary>
        /// 总成号
        /// </summary>
        public string SN
        {
            get => sN;
            set { sN = value; OnPropertyChanged("SN"); }
        }

        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductionNo
        {
            get => productionNo;
            set { productionNo = value; OnPropertyChanged("ProductionNo"); }
        }

        /// <summary>
        /// 入库编号
        /// </summary>
        public string PutInNo
        {
            get => putInNo;
            set { putInNo = value; OnPropertyChanged("PutInNo"); }
        }
    }
}
