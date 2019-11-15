using DMSkin.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCS_Model.DB
{
    public class WMS_Privilege_Model : ViewModelBase
    {
        private int privilegeNo;

        private string privilegeName;

        /// <summary>
        /// 权限编号
        /// </summary>
        public int PrivilegeNo
        {
            get => privilegeNo;
            set { privilegeNo = value; OnPropertyChanged("PrivilegeNo"); }
        }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string PrivilegeName
        {
            get => privilegeName;
            set { privilegeName = value; OnPropertyChanged("PrivilegeName"); }
        }
    }
}
