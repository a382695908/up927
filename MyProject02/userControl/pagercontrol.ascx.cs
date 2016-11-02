using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace Web.userControl
{
    public partial class PagerControl : System.Web.UI.UserControl
    {
        #region 存储过程使用的
        private DataTable  _dataSource;
        private Control _controlToPaginate;
        private PagedDataSource _pagedDataSource;
        private SqlParameter[] _sqlParameters;

        /// <summary>
        /// sql参数
        /// </summary>
        public SqlParameter[] SqlParameters
        {
            get { return _sqlParameters; }
            set { _sqlParameters = value; }
        }
        private bool _customParameters=false;

        public bool CustomParameters
        {
            get { return _customParameters; }
            set { _customParameters = value; }
        }

        private string _dataContainer="";
        /// <summary>
        /// 要绑定的控件
        /// </summary>
        public string DataContainer
        {
            get { return _dataContainer; }
            set { _dataContainer = value; }
        }
        private string _tableName="";
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }
        private string _fields="";
        /// <summary>
        /// 显示的列
        /// </summary>
        public string Fields
        {
            get { return _fields; }
            set { _fields = value; }
        }
        private string _fieldKey="";
        /// <summary>
        /// 主键
        /// </summary>
        public string FieldKey
        {
            get { return _fieldKey; }
            set { _fieldKey = value; }
        }
        private string _sortField="";
        /// <summary>
        /// 排序
        /// </summary>
        public string SortField
        {
            get { return _sortField; }
            set { _sortField = value; }
        }
        private string _sqlCondition="";
        /// <summary>
        /// sql查询条件
        /// </summary>
        public string SqlCondition
        {
            get { return _sqlCondition; }
            set { _sqlCondition = value; }
        }

        private string _connString="";

        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnString
        {
            get { return _connString; }
            set { _connString = value; }
        }

        private string _storedProcedure = "sp_PageView";
        /// <summary>
        /// 分页存储过程名
        /// </summary>
        public string StoredProcedure
        {
            get { return _storedProcedure; }
            set { _storedProcedure = value; }
        }
        #endregion

        #region 其他属性
        private string queryString;
        private bool _useStoredProcedure=false;
        /// <summary>
        /// 是否使用存储过程，如果使用需要按一定规则进行，如果不使用只起分页功能
        /// </summary>
        public bool UseStoredProcedure
        {
            get { return _useStoredProcedure; }
            set { _useStoredProcedure = value; }
        }
        private int _curPage=1;

        public int CurPage
        {
            get { return _curPage; }
            set { _curPage = value; }
        }

        private int _recordCount=0;

        public int RecordCount
        {
            get { return _recordCount; }
            set { _recordCount = value; }
        }

        private int _totalPage;

        public int TotalPage
        {
            get { return _totalPage; }
            set { _totalPage = value; }
        }
        private int _pageSize=15;

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }
        private string _curUrl;

        public string CurUrl
        {
            get { return _curUrl; }
            set { _curUrl = value; }
        }
        #endregion

        #region 属性
        private bool _showPageNum = true;
        /// <summary>
        /// 是否显示页码
        /// </summary>
        public bool ShowPageNum
        {
            get { return _showPageNum; }
            set { _showPageNum = value; }
        }

        private bool _showGo = false;
        /// <summary>
        /// 显示GOTOpage
        /// </summary>
        public bool ShowGo
        {
            get { return _showGo; }
            set { _showGo = value; }
        }

        private bool _showSelectPage = false;
        /// <summary>
        /// 显示下拉跳转页面
        /// </summary>
        public bool ShowSelectPage
        {
            get { return _showSelectPage; }
            set { _showSelectPage = value; }
        }

        private string _pageStyle = "";
        /// <summary>
        /// 分页控件部分样式定义
        /// </summary>
        public string PageStyle
        {
            get { return _pageStyle; }
            set { _pageStyle = value; }
        }
        #endregion

        protected StringBuilder str = new StringBuilder("");

        protected void Page_Load(object sender, EventArgs e)
        {
                int index;
                CurUrl = Page.Request.Path;
                queryString = Page.Request.ServerVariables["Query_String"];
                int.TryParse(Page.Request.QueryString["p"], out index);
                if (UseStoredProcedure && !CustomParameters)
                {
                    RecordCount = GetQueryVirtualCount();
                    TotalPage = (int)Math.Ceiling((double)RecordCount / (double)PageSize);
                }
                else
                {
                    TotalPage = (int)Math.Ceiling((double)RecordCount / (double)PageSize);
                }
                CurPage = index;
                if (index <= 0)
                    CurPage = 1;
                if (index > TotalPage)
                    CurPage = TotalPage;
            //获取当前url 获取当前页

                //是否启用存储过程 如果未启用
                if (UseStoredProcedure)
                {
                    //存储过程
                    GetUserStoreProcedure();
                    GetUnUserStoreProcedure();
                }
                else
                { 
                   //非存储过程
                    GetUnUserStoreProcedure();
                }
               //如果启用
        }

        private void GetUserStoreProcedure()
        {
            BindData();
        }

        private void BindData()
        {
            // 确保控件存在且为列表控件
            _controlToPaginate = Page.FindControl(DataContainer);
            if (_controlToPaginate == null)
                return;
            if (!(_controlToPaginate is BaseDataList || _controlToPaginate is ListControl || _controlToPaginate is Repeater))
                return;

            // 确保具有足够的连接信息并指定查询
            if (ConnString == "")
                return;

            // 获取数据
            FetchPageData();

            // 将数据绑定到合作者控件
            BaseDataList baseDataListControl = null;
            ListControl listControl = null;
            Repeater repeaterControl = null;
            if (CustomParameters)
            {
                if (this._pagedDataSource == null)
                {
                    this._pagedDataSource = new PagedDataSource();
                }
                this._pagedDataSource.PageSize = PageSize;
                TotalPage = this._pagedDataSource.PageCount;
                _pagedDataSource.CurrentPageIndex = CurPage;
                _pagedDataSource.VirtualCount = RecordCount;
                _pagedDataSource.DataSource = _dataSource.DefaultView;

                if (_controlToPaginate is BaseDataList)
                {
                    baseDataListControl = (BaseDataList)_controlToPaginate;
                    baseDataListControl.DataSource = _pagedDataSource;
                    baseDataListControl.DataBind();
                    return;
                }
                if (_controlToPaginate is ListControl)
                {
                    listControl = (ListControl)_controlToPaginate;
                    listControl.Items.Clear();
                    listControl.DataSource = _pagedDataSource;
                    listControl.DataBind();
                    return;
                }
                if (_controlToPaginate is Repeater)
                {
                    repeaterControl = (Repeater)_controlToPaginate;
                    repeaterControl.DataSource = _pagedDataSource;
                    repeaterControl.DataBind();
                    return;
                }
            }
            else
            {
                if (_controlToPaginate is BaseDataList)
                {
                    baseDataListControl = (BaseDataList)_controlToPaginate;
                    baseDataListControl.DataSource = _dataSource.DefaultView;
                    baseDataListControl.DataBind();
                    return;
                }
                if (_controlToPaginate is ListControl)
                {
                    listControl = (ListControl)_controlToPaginate;
                    listControl.Items.Clear();
                    listControl.DataSource = _dataSource.DefaultView;
                    listControl.DataBind();
                    return;
                }
                if (_controlToPaginate is Repeater)
                {
                    repeaterControl = (Repeater)_controlToPaginate;
                    repeaterControl.DataSource = _dataSource.DefaultView;
                    repeaterControl.DataBind();
                    return;
                }
            }
        }

        private void FetchPageData()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(ConnString);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = StoredProcedure;
            if(!CustomParameters)
            {
            cmd.Parameters.AddWithValue("@tbname",TableName);
            cmd.Parameters.AddWithValue("@FieldKey",FieldKey);
            cmd.Parameters.AddWithValue("@PageCurrent",CurPage);
            cmd.Parameters.AddWithValue("@PageSize",PageSize);
            cmd.Parameters.AddWithValue("@FieldShow",Fields);
            cmd.Parameters.AddWithValue("@FieldOrder",SortField);
            cmd.Parameters.AddWithValue("@Where",SqlCondition);
            }
            else
            {
                for (int i = 0; i < SqlParameters.Length; i++)
                {
                    cmd.Parameters.AddWithValue(SqlParameters[i].ParameterName, SqlParameters[i].Value);
                }
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            if (_dataSource == null)
                _dataSource = new DataTable();
            adapter.Fill(_dataSource);

        }

        private int GetQueryVirtualCount()
        {
            SqlConnection conn = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand("dbo.sp_PageCount", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tbname", TableName);
            cmd.Parameters.AddWithValue("@Where", SqlCondition);
            cmd.Connection.Open();
            int recCount = (int)cmd.ExecuteScalar();
            cmd.Connection.Close();

            return recCount;
        }

        private void GetUnUserStoreProcedure()
        {
            str.Append("<div class=\"imos_pagebox font12_7C7C7C\">");
            CreateNavigationButton("FirstPrev");
            //首页 上一页
            //生成页码
            if (ShowPageNum)
            {
                CreatePageNum();
            }
            if (ShowSelectPage || ShowGo)
            {
                StringBuilder jscript = new StringBuilder("");
                jscript.Append("<script type=\"text/javascript\">function goToPage(boxEl){boxEl=document.getElementById(boxEl);if(boxEl!=null){var pi;if(boxEl.tagName==\"SELECT\")");
                jscript.Append("{pi=boxEl.options[boxEl.selectedIndex].value;}else{pi=boxEl.value;}");
                jscript.Append("location.href=\"").Append(BuildUrlString("p", "\"+pi+\"")).Append("\"");
                jscript.Append(";}}</script>\n");
                if(!Page.ClientScript.IsClientScriptBlockRegistered("goToPage"))
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(),"goToPage", jscript.ToString());
            }
            //下一页 尾页
            CreateNavigationButton("LastNext");
            //生成第几页跳转方式
            //if (ShowSelectPage)
            //{
            //    CreateSelectPage();
            //}
            //生成gotopager
            if (ShowGo)
            {
                CreateShowGo();
            }
            str.Append("</div>");
        }

        private void CreateSelectPage()
        {
            str.Append("第<select class=\"selpager\" onchange=\"goToPage(this)\">");
            for (int i = 1; i <= TotalPage; i++)
            {
                if (i == CurPage)
                    str.Append("<option selected value=\"" + i + "\">" + i + "</option>");
                else
                    str.Append("<option value=\"" + i + "\">" + i + "</option>");
            }
            str.Append("</select>页");
        }
        private void CreateShowGo()
        {
            str.Append("<span style=\"padding:0px 10px;\">共"+TotalPage.ToString()+"页</span><span>到 <input type=\"text\" onkeydown=\"if(event.keyCode==13){event.keyCode=9;goToPage('goNum');return false;}\"  size=\"10\" id=\"goNum\" class=\"imos_page_text\" /> 页</span> <a href=\"javascript:;\" onclick=\"goToPage('goNum')\">确定</a>");
        }

        private void CreateNavigationButton(string type)
        {
            if (type == "FirstPrev")
            {
                if (TotalPage > 1 && CurPage > 1)
                {
                    str.Append("<a href=\"" + BuildUrlString("p", "1") + "\">首页</a> <a href=\"" + BuildUrlString("p", (CurPage - 1).ToString()) + "\">上页</a>");
                }
                //else
                //{
                //    str.Append("<a class=\"first\" disabled=\"disabled\">首页</a><a class=\"pre\" disabled=\"disabled\">上页</a>");
                //}
            }
            else
            {
                if (TotalPage > 1 && CurPage < TotalPage)
                {
                    str.Append(" <a href=\"" + BuildUrlString("p", (CurPage + 1).ToString()) + "\">下页</a> <a href=\"" + BuildUrlString("p", TotalPage.ToString()) + "\">尾页</a>");
                }
                //else
                //{
                //    str.Append("<a class=\"next\" disabled=\"disabled\">下页</a><a class=\"last\" disabled=\"disabled\">尾页</a>");
                //}
            }

        }

        private void CreatePageNum()
        { 
            int maxpage,minpage;
            int js = 5;
            bool haspre = false;
            bool hasnext = false;
            if (CurPage < js)
            {
                minpage = 1;
                maxpage = TotalPage >= js+2 ? js+2 : TotalPage;
                if (TotalPage >= js + 2)
                    hasnext = true;
            }
            else
            {
                //if (CurPage % 10 == 0)
                //{
                //    minpage = CurPage - 9;
                //    maxpage = CurPage;
                //}
                //else
                //{
                    haspre = true;
                    minpage = CurPage - 3;
                    if (CurPage + 3 > TotalPage)
                    {
                        maxpage = TotalPage;
                    }
                    else
                    {
                        maxpage = CurPage + 3;
                        hasnext = true;
                    }
                //}
            }
            if (haspre)
                str.Append(" ...");
            for (int i = minpage; i <= maxpage; i++)
            {
                if (i == CurPage)
                    str.Append(" <a class=\"cur\">" + CurPage.ToString() + "</a>");
                else
                    str.Append(" <a href=\"" + BuildUrlString("p", i.ToString()) + "\">" + i + "</a>");
            }
            if (hasnext)
                str.Append(" ...");
        }

        private string BuildUrlString(string sk, string sv)
        {
            StringBuilder ubuilder = new StringBuilder(80);
            bool keyFound = false;
            int num = (queryString != null) ? queryString.Length : 0;
            for (int i = 0; i < num; i++)
            {
                int startIndex = i;
                int num4 = -1;
                while (i < num)
                {
                    char ch = queryString[i];
                    if (ch == '=')
                    {
                        if (num4 < 0)
                        {
                            num4 = i;
                        }
                    }
                    else if (ch == '&')
                    {
                        break;
                    }
                    i++;
                }
                string skey = null;
                string svalue;
                if (num4 >= 0)
                {
                    skey = queryString.Substring(startIndex, num4 - startIndex);
                    svalue = queryString.Substring(num4 + 1, (i - num4) - 1);
                }
                else
                {
                    svalue = queryString.Substring(startIndex, i - startIndex);
                }
                ubuilder.Append(skey).Append("=");
                if (skey == sk)
                {
                    keyFound = true;
                    ubuilder.Append(sv);
                }
                else
                    ubuilder.Append(svalue);
                ubuilder.Append("&");
            }
            if (!keyFound)
                ubuilder.Append(sk).Append("=").Append(sv);
            ubuilder.Insert(0, "?").Insert(0, Path.GetFileName(CurUrl));
            return ubuilder.ToString().Trim('&');
        }
    }
}