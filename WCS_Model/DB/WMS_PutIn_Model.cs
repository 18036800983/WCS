using DMSkin.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCS_Model.DB
{
    public class WMS_PutIn_Model : ViewModelBase
    {
        private string shelfNo;

        private string putInNo;

        private string sN;

        private string orderNo;

        private string putInType;

        private string status;

        private string putInTime;

        /// <summary>
        /// 货架编号
        /// </summary>
        public string ShelfNo
        {
            get => shelfNo;
            set { shelfNo = value; OnPropertyChanged("ShelfNo"); }
        }

        /// <summary>
        /// 入库编号
        /// </summary>
        public string PutInNo
        {
            get => putInNo;
            set { putInNo = value; OnPropertyChanged("PutInNo"); }
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
        /// 订单编号
        /// </summary>
        public string OrderNo
        {
            get => orderNo;
            set { orderNo = value; OnPropertyChanged("OrderNo"); }
        }

        /// <summary>
        /// 入库类型
        /// </summary>
        public string PutInType
        {
            get => putInType;
            set { putInType = value; OnPropertyChanged("PutInType"); }
        }

        /// <summary>
        /// 入库状态
        /// </summary>
        public string Status
        {
            get => status;
            set { status = value; OnPropertyChanged("Status"); }
        }

        /// <summary>
        /// 入库时间
        /// </summary>
        public string PutInTime
        {
            get => putInTime;
            set { putInTime = value; OnPropertyChanged("PutInTime"); }
        }
    }
}
