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

namespace MyProject02.template
{
    public partial class _04 : System.Web.UI.Page
    {
        ArtBll artBll = new ArtBll();

        string sql = "";
        DataTable dt;

        public string title = @ConfigurationManager.AppSettings["title"].ToString();//网站title关键词
        public string keyword = "";

        string Article_File = @ConfigurationManager.AppSettings["Article_File"].ToString();//文章图片存储路径

        protected void Page_Load(object sender, EventArgs e)
        {
            keyword = title.Replace("|", ",");

            BindHotList();//绑定热门文章
        }


        #region 绑定热门文章

        private void BindHotList()
        {
            //绑定最新发布的前N条文章
            sql = "Select top 23 t_article.id as articleId,t_article.title,t_article.keyword,t_article.daoyu,t_article.content,t_article.type,t_article.update_date,t_article.declare_mark,t_article.pic,t_article.html,t_article.remark,t_article_type.type_name,source FROM t_article  " +
                                " LEFT JOIN t_article_type ON t_article.type=t_article_type.id where t_article.type<>6 order by update_date desc ";//where articleId not in (0,Select top 10 id from t_article order by update_date desc)
            dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                this.repList.DataSource = dt;
                this.repList.DataBind();
            }
        }
        #endregion


        public string UrlEncode(string str)
        {
            return Utils.UrlEncode(str);
        }

        #region 截取标题字数

        public string GetPartContent(string content, int length)
        {
            return CommonMethod.GetStringByLenth(content, length);
        }
        #endregion


    }
}
