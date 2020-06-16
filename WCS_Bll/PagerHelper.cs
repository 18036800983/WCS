using MySql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tool;

namespace WCS_Bll
{
    public class PagerHelper : DB_Tool
    {
        /// <summary>
        /// 获取数据库分页数据
        /// </summary>
        public static DataTable PagerTable(int page, int sizePage, string showColumn, string tabName, string strCondition, string ascColumn, int bitOrderType, string pkColumn)
        {
            using (var con = GetOpenConnection())
            {
                List<DbParameter> parameters = new List<DbParameter>();
                
                parameters.Add(DbUtility.CreateDbParameter("@currPage", page,ParameterDirection.Input));
                parameters.Add(DbUtility.CreateDbParameter("@showColumn", showColumn,ParameterDirection.Input));
                parameters.Add(DbUtility.CreateDbParameter("@tabName", tabName,ParameterDirection.Input));
                parameters.Add(DbUtility.CreateDbParameter("@strCondition", strCondition,ParameterDirection.Input));
                parameters.Add(DbUtility.CreateDbParameter("@ascColumn", ascColumn,ParameterDirection.Input));
                parameters.Add(DbUtility.CreateDbParameter("@bitOrderType",bitOrderType,ParameterDirection.Input));
                parameters.Add(DbUtility.CreateDbParameter("@pkColumn ", pkColumn,ParameterDirection.Input));
                parameters.Add(DbUtility.CreateDbParameter("@pageSize ", sizePage, ParameterDirection.Input));

                return con.ExecuteDataTable("prcPage", parameters, CommandType.StoredProcedure);
            }
        }
    }
}
