using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.OleDb;

namespace BLL
{
    public class AccessBll
    {
        ////从配置文件中得到数据库名称  
        //public static readonly string access_con = ConfigurationManager.ConnectionStrings["access_con"].ConnectionString;
        ////从配置文件中得到数据库驱动  
        //public static readonly string access_path = ConfigurationManager.ConnectionStrings["access_path"].ConnectionString;
        ////得到数据库连接字符串  
        //public static readonly string DBConnectionString = access_con + HttpContext.Current.Server.MapPath(access_path);
        ////建立数据库连接对象  
        //private OleDbConnection OleDbConn = new OleDbConnection(DBConnectionString);//初始化数据库连接对象  



        //public OleDbConnection getConnection()
        //{
        //    return OleDbConn;
        //}

        //变量声明处#region 变量声明处
        public OleDbConnection Conn;
        public string ConnString;//连接字符串

        public AccessBll()
        {
            ConnString = ConfigurationManager.ConnectionStrings["access_con"].ConnectionString + HttpContext.Current.Server.MapPath(ConfigurationManager.ConnectionStrings["access_path"].ConnectionString);
            Conn = new OleDbConnection(ConnString);
            Conn.Open();
        }

        //构造函数与连接关闭数据库#region 构造函数与连接关闭数据库
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="Dbpath">ACCESS数据库路径-webconfig中自定义</param>
        public AccessBll(string DBpath)
        {
            ConnString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString + System.AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.ConnectionStrings[DBpath].ConnectionString;
            Conn = new OleDbConnection(ConnString);
            Conn.Open();
        }



        /// <summary>
        /// 打开数据源链接
        /// </summary>
        /// <returns></returns>
        public OleDbConnection DbConn()
        {
            Conn.Open();
            return Conn;
        }

        /// <summary>
        /// 请在数据传递完毕后调用该函数，关闭数据链接。
        /// </summary>
        public void Close()
        {
            Conn.Close();
            Conn.Dispose();
        }


        /// 数据库基本操作#region 数据库基本操作
        /// <summary>
        /// 根据SQL命令返回数据DataTable数据表,
        /// 可直接作为dataGridView的数据源
        /// </summary>
        /// <param name="SQL"></param>
        /// <returns></returns>
        public DataTable SelectToDataTable(string SQL)
        {
            //OleDbDataAdapter adapter = new OleDbDataAdapter();
            //OleDbCommand command = new OleDbCommand(SQL, Conn);
            //adapter.SelectCommand = command;
            //DataTable Dt = new DataTable();
            //adapter.Fill(Dt);
            //Close();
            //return Dt;

            string ConnectionString = ConfigurationManager.ConnectionStrings["access_con"].ConnectionString + HttpContext.Current.Server.MapPath(ConfigurationManager.ConnectionStrings["access_path"].ConnectionString);
            using (OleDbConnection m_Conn = new OleDbConnection(ConnectionString))
            {
                m_Conn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                OleDbCommand cmd = new OleDbCommand(SQL, m_Conn);
                adapter.SelectCommand = cmd;
                DataTable Dt = new DataTable();
                adapter.Fill(Dt);

                m_Conn.Close();
                m_Conn.Dispose();

                return Dt;
            }
        }

        /// <summary>
        /// 根据SQL命令返回数据DataSet数据集，其中的表可直接作为dataGridView的数据源。
        /// </summary>
        /// <param name="SQL"></param>
        /// <param name="subtableName">在返回的数据集中所添加的表的名称</param>
        /// <returns></returns>
        public DataSet SelectToDataSet(string SQL, string subtableName)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command = new OleDbCommand(SQL, Conn);
            adapter.SelectCommand = command;
            DataSet Ds = new DataSet();
            Ds.Tables.Add(subtableName);
            adapter.Fill(Ds, subtableName);
            Close();
            return Ds;
        }

        /// <summary>
        /// 在指定的数据集中添加带有指定名称的表，由于存在覆盖已有名称表的危险，返回操作之前的数据集。
        /// </summary>
        /// <param name="SQL"></param>
        /// <param name="subtableName">添加的表名</param>
        /// <param name="DataSetName">被添加的数据集名</param>
        /// <returns></returns>
        public DataSet SelectToDataSet(string SQL, string subtableName, DataSet DataSetName)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command = new OleDbCommand(SQL, Conn);
            adapter.SelectCommand = command;
            DataTable Dt = new DataTable();
            DataSet Ds = new DataSet();
            Ds = DataSetName;
            adapter.Fill(DataSetName, subtableName);
            Close();
            return Ds;
        }


        /// <summary>
        /// 根据SQL命令返回OleDbDataAdapter，
        /// 使用前请在主程序中添加命名空间System.Data.OleDb
        /// </summary>
        /// <param name="SQL"></param>
        /// <returns></returns>
        public OleDbDataAdapter SelectToOleDbDataAdapter(string SQL)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command = new OleDbCommand(SQL, Conn);
            adapter.SelectCommand = command;
            return adapter;
        }

        /// <summary>
        /// 执行SQL命令，不需要返回数据的修改，删除可以使用本函数
        /// </summary>
        /// <param name="SQL"></param>
        /// <returns></returns>
        public bool ExecuteSQLNonquery(string SQL)
        {
            //OleDbCommand cmd = new OleDbCommand(SQL, Conn);
            //try
            //{
            //    string state = Conn.State.ToString().ToLower();
            //    if (state != "open")
            //    {
            //        Conn.Open();
            //    }
            //    cmd.ExecuteNonQuery();
            //    //Close();
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    string ex1 = ex.ToString();
            //    return false;
            //}
            //finally
            //{
            //    Close();
            //}

            string ConnectionString = ConfigurationManager.ConnectionStrings["access_con"].ConnectionString + HttpContext.Current.Server.MapPath(ConfigurationManager.ConnectionStrings["access_path"].ConnectionString);
            using (OleDbConnection m_Conn = new OleDbConnection(ConnectionString))
            {
                m_Conn.Open();
                OleDbCommand cmd = new OleDbCommand(SQL, m_Conn);
                cmd.ExecuteNonQuery();

                m_Conn.Close();
                m_Conn.Dispose();

                return true;
            }
        }

        /// <summary>
        /// 执行SQL命令，数据是否存在，返回bool
        /// </summary>
        /// <param name="SQL"></param>
        /// <returns></returns>
        public bool Exists(string SQL)
        {
            OleDbCommand cmd = new OleDbCommand(SQL, Conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            Close();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 执行SQL命令，查询记录总数，返回int
        /// </summary>
        /// <param name="SQL"></param>
        /// <returns></returns>
        public int MaxCount(string SQL)
        {
            OleDbCommand cmd = new OleDbCommand(SQL, Conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            //Close();
            if (count > 0)
            {
                return count;
            }
            else
            {
                return 0;
            }
        }




        /// <summary>
        /// 分页使用
        /// </summary>
        /// <param name="query"></param>
        /// <param name="passCount"></param>
        /// <returns></returns>
        private static string recordID(string query, int passCount)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["access_con"].ConnectionString + HttpContext.Current.Server.MapPath(ConfigurationManager.ConnectionStrings["access_path"].ConnectionString);
            using (OleDbConnection m_Conn = new OleDbConnection(ConnectionString))
            {
                m_Conn.Open();
                OleDbCommand cmd = new OleDbCommand(query, m_Conn);
                string result = string.Empty;
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (passCount < 1)
                        {
                            result += "," + dr.GetInt32(0);
                        }
                        passCount--;
                    }
                }
                m_Conn.Close();
                m_Conn.Dispose();
                return result.Substring(1);
            }
        }
        /// <summary>
        /// ACCESS高效分页
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">分页容量</param>
        /// <param name="strKey">主键</param>
        /// <param name="showString">显示的字段</param>
        /// <param name="queryString">查询字符串，支持联合查询</param>
        /// <param name="whereString">查询条件，若有条件限制则必须以where 开头</param>
        /// <param name="orderString">排序规则</param>
        /// <param name="pageCount">传出参数：总页数统计</param>
        /// <param name="recordCount">传出参数：总记录统计</param>
        /// <returns>装载记录的DataTable</returns>
        public DataTable ExecutePager(int pageIndex, int pageSize, string strKey, string showString, string queryString, string whereString, string orderString, out int pageCount, out int recordCount)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["access_con"].ConnectionString + HttpContext.Current.Server.MapPath(ConfigurationManager.ConnectionStrings["access_path"].ConnectionString);
            if (pageIndex < 1) pageIndex = 1;
            if (pageSize < 1) pageSize = 10;
            if (string.IsNullOrEmpty(showString)) showString = "*";
            if (string.IsNullOrEmpty(orderString)) orderString = strKey + " asc ";
            using (OleDbConnection m_Conn = new OleDbConnection(ConnectionString))
            {
                m_Conn.Open();
                string myVw = string.Format(" ( {0} ) tempVw ", queryString);
                OleDbCommand cmdCount = new OleDbCommand(string.Format(" select count(*) as recordCount from {0} {1}", myVw, whereString), m_Conn);

                recordCount = Convert.ToInt32(cmdCount.ExecuteScalar());

                if ((recordCount % pageSize) > 0)
                    pageCount = recordCount / pageSize + 1;
                else
                    pageCount = recordCount / pageSize;
                OleDbCommand cmdRecord;
                if (pageIndex == 1)//第一页
                {
                    cmdRecord = new OleDbCommand(string.Format("select top {0} {1} from {2} {3} order by {4} ", pageSize, showString, myVw, whereString, orderString), m_Conn);
                }
                else if (pageIndex > pageCount)//超出总页数
                {
                    cmdRecord = new OleDbCommand(string.Format("select top {0} {1} from {2} {3} order by {4} ", pageSize, showString, myVw, "where 1=2", orderString), m_Conn);
                }
                else
                {
                    int pageLowerBound = pageSize * pageIndex;
                    int pageUpperBound = pageLowerBound - pageSize;
                    string recordIDs = recordID(string.Format("select top {0} {1} from {2} {3} order by {4} ", pageLowerBound, strKey, myVw, whereString, orderString), pageUpperBound);
                    cmdRecord = new OleDbCommand(string.Format("select {0} from {1} where {2} in ({3}) order by {4} ", showString, myVw, strKey, recordIDs, orderString), m_Conn);

                }
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmdRecord);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                m_Conn.Close();
                m_Conn.Dispose();
                return dt;
            }
        }




    }
}
