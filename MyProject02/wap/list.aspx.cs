using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;
using System.Text;
using System.Data.SqlClient;
using BLL;
using WebBasic.Info;
using WebBasic.Text;
using System.Configuration;
using System.Text.RegularExpressions;
using MyProject02.App_Code;

namespace MyProject02.wap
{
    public partial class list : System.Web.UI.Page
    {
        ArtBll artBll = new ArtBll();

        int articleId = 0;
        string title = "";
        int articleType = 0;
        string tagName = "";
        int tag_id = 0;
        public string articleTypeName = "";
        public string html_title = "好宝宝";//页面title

        string sql = "";
        DataTable dt;

        public string listStr = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            string host = HttpContext.Current.Request.Url.Host.ToString();
            if (!host.Contains(".up927.com"))
            {
                Response.Redirect("http://www.up927.com/");
            }
            else if (host.Contains("vhye.pw"))
            {
                Response.Redirect("http://www.up927.com/");
            }

            if (!string.IsNullOrEmpty(Request.QueryString["a_t"]) && MetarnetRegex.IsNumeric(Request.QueryString["a_t"]))
            {
                articleType = Utils.CheckInt(Request.QueryString["a_t"].ToString());

                string sql = "select type_name,type_keyword from t_article_type where id=" + articleType;
                DataTable dtType = artBll.SelectToDataTable(sql);
                if (dtType.Rows.Count > 0)
                {
                    articleTypeName = dtType.Rows[0]["type_name"].ToString();
                    html_title = articleTypeName + "_" + html_title;
                }
            }
            if (!string.IsNullOrEmpty(Request.QueryString["tag"]))
            {
                tag_id = (Utils.CheckInt(Request.QueryString["tag"].ToString()));
                if (tag_id != 0)
                {
                    tagName = this.SelectOneTagName(tag_id.ToString());
                    html_title = tagName + "_" + html_title;
                    articleTypeName = tagName;
                }
            }

            BindList();//绑定列表
        }

        #region 绑定列表

        private void BindList()
        {
            //if (articleType == 0)
            //{
            //    sql = "select top 50 * from t_article order by update_date desc ";
            //}
            if (tag_id != 0)
            {
                sql = "select top 50 * from t_article where tag_id like '%," + tag_id + ",%' order by update_date desc ";
            }
            else if (articleType != 0)
            {
                sql = "select top 50 * from t_article where type=" + articleType + " order by update_date desc ";
            }
            else
            {
                sql = "select top 50 * from t_article order by update_date desc ";
            }
            dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                this.repList1.DataSource = dt;
                this.repList1.DataBind();
            }
        }
        #endregion

        #region 截取标题字数

        public string GetPartContent(string content, int length)
        {
            return CommonMethod.GetStringByLenth(content, length);
        }
        #endregion

        #region 查询一个标签名称

        private string SelectOneTagName(string tag_id)
        {
            String sql = "select * from t_tag where id=" + tag_id;
            DataTable dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["tag_name"].ToString();
            }
            else
            {
                return "";
            }
        }
        #endregion

    }
}
