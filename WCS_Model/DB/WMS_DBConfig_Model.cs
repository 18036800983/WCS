using DMSkin.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCS_Model.DB
{
    public class WMS_DBConfig_Model : ViewModelBase
    {
        private string dataSource;

        private string initialCatalog;

        private string userID;

        private string pwd;

        private string databaseType;

        /// <summary>
        /// 服务器名称
        /// </summary>
        public string DataSource { get => dataSource; set => dataSource = value; }

        /// <summary>
        /// 数据库名称
        /// </summary>
        public string InitialCatalog { get => initialCatalog; set => initialCatalog = value; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserID { get => userID; set => userID = value; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get => pwd; set => pwd = value; }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public string DatabaseType { get => databaseType; set => databaseType = value; }
    }
}
