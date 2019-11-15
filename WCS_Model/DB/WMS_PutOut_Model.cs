using DMSkin.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCS_Model.DB
{
    public class WMS_PutOut_Model : ViewModelBase
    {
        private string shelfNo;

        private string putOutNo;

        private string sN;

        private string orderNo;

        private string putOutType;

        private string status;

        private string putOutTime;

        /// <summary>
        /// 货架编号
        /// </summary>
        public string ShelfNo
        {
            get => shelfNo;
            set { shelfNo = value; OnPropertyChanged("ShelfNo"); }
        }

        /// <summary>
        /// 出库编号
        /// </summary>
        public string PutOutNo
        {
            get => putOutNo;
            set { putOutNo = value; OnPropertyChanged("PutOutNo"); }
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
        /// 订单号
        /// </summary>
        public string OrderNo
        {
            get => orderNo;
            set { orderNo = value; OnPropertyChanged("OrderNo"); }
        }

        /// <summary>
        /// 出库类型
        /// </summary>
        public string PutOutType
        {
            get => putOutType;
            set { putOutType = value; OnPropertyChanged("PutOutType"); }
        }

        /// <summary>
        /// 出库状态
        /// </summary>
        public string Status
        {
            get => status;
            set { status = value; OnPropertyChanged("Status"); }
        }

        /// <summary>
        /// 出库时间
        /// </summary>
        public string PutOutTime
        {
            get => putOutTime;
            set { putOutTime = value; OnPropertyChanged("PutOutTime"); }
        }
    }
}
