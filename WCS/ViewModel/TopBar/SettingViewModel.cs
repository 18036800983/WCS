using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tool;
using WCS.ViewBase.TopBar;
using WCS_Model.DB;

namespace WCS.ViewModel.TopBar
{
    public class SettingViewModel : SettingBase
    {
        public SettingViewModel()
        {
            ShowDBConfigTable();
        }
        /// <summary>
        /// 显示列表
        /// </summary>
        public void ShowDBConfigTable()
        {
            foreach (var model in GetDBConfigList())
            {
                DBConfigList.Add(model);
            }
            ShowDBConfigList();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public static List<WMS_DBConfig_Model> GetDBConfigList()
        {
            List<WMS_DBConfig_Model> list = new List<WMS_DBConfig_Model>();
            WMS_DBConfig_Model wMS_DBConfig_Model = new WMS_DBConfig_Model 
            {
                DataSource = Xml_Tool.xml.DataBase.DataSource,
                InitialCatalog = Xml_Tool.xml.DataBase.InitialCatalog,
                UserID = Xml_Tool.xml.DataBase.UserID,
                Pwd = Xml_Tool.xml.DataBase.pwd,
                DatabaseType = Xml_Tool.xml.DataBase.DatabaseType.ToString()
            };
            list.Add(wMS_DBConfig_Model);
            return list;
        }
    }
}
