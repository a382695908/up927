using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using WebBasic;
using System.Data;
using System.Net;
using System.IO;
using System.Configuration;
using System.Collections;

namespace BLL
{
    public class ArtBll
    {
        private SqlDataBase database = new SqlDataBase("Up927Con", false);

        public bool ExecuteSQLNonquery(string sql)
        {
            return database.ExecNonQuery(sql,false,null);
        }


        public DataTable SelectToDataTable(string sql)
        {
            return database.ExecDataTable(sql, false, null);
        }

        /// <summary>
        /// 通用分页存储过程
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="totalRecord"></param>
        /// <returns></returns>
        public DataTable ExecutePager(string sql, int pageSize, int pageIndex, ref int totalRecord)
        {
            string strSql = "[up927_f].[Select_List]";
            SqlParameter[] spInfo = new SqlParameter[4];
            spInfo[0] = new SqlParameter("@PageSize", pageSize);
            spInfo[1] = new SqlParameter("@PageIndex", pageIndex);
            spInfo[2] = new SqlParameter("@TotalRecord", 0);
            spInfo[2].Direction = ParameterDirection.Output;

            spInfo[3] = new SqlParameter("@sql", sql);

            DataTable dt = database.ExecDataTable(strSql, true, spInfo);
            totalRecord = Convert.ToInt32(spInfo[2].Value);
            return dt;
        }

        public string ExecuteScalar(string sql)
        {
            return database.ExecuteScalar(sql,false,null).ToString();
        }
    }
}
