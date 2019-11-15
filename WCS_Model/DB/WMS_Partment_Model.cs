using DMSkin.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCS_Model.DB
{
    public class WMS_Partment_Model : ViewModelBase
    {
        private int partmentNo;

        private string partmentName;

        private string creatPerson;

        private string creatTime;

        private string modifyPerson;

        private string modifyTime;

        /// <summary>
        /// 部门标号
        /// </summary>
        public int PartmentNo
        {
            get => partmentNo;
            set => partmentNo = value;
        }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string PartmentName
        {
            get => partmentName;
            set => partmentName = value;
        }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreatPerson
        {
            get => creatPerson;
            set => creatPerson = value;
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreatTime
        {
            get => creatTime;
            set => creatTime = value;
        }

        /// <summary>
        /// 修改人
        /// </summary>
        public string ModifyPerson
        {
            get => modifyPerson;
            set => modifyPerson = value;
        }

        /// <summary>
        /// 修改时间
        /// </summary>
        public string ModifyTime
        {
            get => modifyTime;
            set => modifyTime = value;
        }
    }
}
