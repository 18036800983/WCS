using DMSkin.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCS_Model.DB
{
    public class WMS_Area_Model : ViewModelBase
    {
        private string areaName;

        private string areaNo;

        private string warehouseNo;

        private string remark;

        private string creatPerson;

        private string creatTime;

        private string modifyPerson;

        private string modifyTime;

        /// <summary>
        /// 库区名称
        /// </summary>
        public string AreaName
        {
            get => areaName;
            set { areaName = value; OnPropertyChanged("AreaName"); }
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
        /// 备注
        /// </summary>
        public string Remark
        {
            get => remark;
            set { remark = value; OnPropertyChanged("Remark"); }
        }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreatPerson
        {
            get => creatPerson;
            set { creatPerson = value; OnPropertyChanged("CreatPerson"); }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreatTime
        {
            get => creatTime;
            set { creatTime = value; OnPropertyChanged("CreatTime"); }
        }

        /// <summary>
        /// 修改人
        /// </summary>
        public string ModifyPerson
        {
            get => modifyPerson;
            set { modifyPerson = value; OnPropertyChanged("ModifyPerson"); }
        }

        /// <summary>
        /// 修改时间
        /// </summary>
        public string ModifyTime
        {
            get => modifyTime;
            set { modifyTime = value; OnPropertyChanged("ModifyTime");}
        }
    }
}
