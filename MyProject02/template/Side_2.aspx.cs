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
    public partial class Side_2 : System.Web.UI.Page
    {
        ArtBll artBll = new ArtBll();

        string sql = "";
        DataTable dt;

        public string title = @ConfigurationManager.AppSettings["title"].ToString();//网站title关键词
        public string keyword = "";

        string Article_File = @ConfigurationManager.AppSettings["Article_File"].ToString();//文章图片存储路径

        protected void Page_Load(object sender, EventArgs e)
        {
            BindTuijianList();//绑定推荐阅读
        }


        #region 绑定推荐阅读，热门好贴

        private void BindTuijianList()
        {
            //推荐阅读
            //绑定最新发布的前N条文章
            sql = "Select top 4 t_article.id as articleId,t_article.title,t_article.title1,t_article.keyword,t_article.daoyu,t_article.content,t_article.type,t_article.update_date,t_article.declare_mark,t_article.pic,t_article.html,t_article.remark,t_article_type.type_name,source FROM t_article  " +
                                " LEFT JOIN t_article_type ON t_article.type=t_article_type.id where t_article.right_type=3 order by update_date desc ";//where articleId not in (0,Select top 10 id from t_article order by update_date desc)
            dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                this.repList12.DataSource = dt;
                this.repList12.DataBind();
            }

            //热门好贴
            //绑定最新发布的前N条文章
            sql = "Select top 15 t_article.id as articleId,t_article.title,t_article.title1,t_article.keyword,t_article.daoyu,t_article.content,t_article.type,t_article.update_date,t_article.declare_mark,t_article.pic,t_article.html,t_article.remark,t_article_type.type_name,source FROM t_article  " +
                                " LEFT JOIN t_article_type ON t_article.type=t_article_type.id where t_article.right_type=1 order by update_date desc ";//where articleId not in (0,Select top 10 id from t_article order by update_date desc)
            dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                this.repList13.DataSource = dt;
                this.repList13.DataBind();
            }
        }
        #endregion

        #region 截取标题字数

        public string GetPartContent(string content, int length)
        {
            if (content.Length > length)
                return content.Substring(0, length);
            else
                return content;
        }
        #endregion

        #region 返回导语

        public string GetDaoyu(string daoyu, string content, int length)
        {
            //if (daoyu.Trim() != "")
            //{
            //    return GetPartContent(InText.SafeStr(daoyu), length) + "...";
            //}
            //else
            //{
            //    return GetPartContent(InText.SafeStr(content), length) + "...";
            //}
            if (daoyu.Trim() != "" && daoyu.Trim() != "no")
            {
                //return GetPartContent(InText.SafeStr(daoyu), length) + "...";
                if (daoyu.Length > length)
                    return daoyu.Substring(0, length) + "...";
                else
                    return daoyu + "...";
            }
            else
            {
                //return GetPartContent(InText.SafeStr(content), length) + "...";
                string returnStr = InText.SafeSqlContent(content);
                if (returnStr.Length > length)
                    return returnStr.Substring(0, length);
                else
                    return content + "...";
            }
        }
        #endregion


    }
}
