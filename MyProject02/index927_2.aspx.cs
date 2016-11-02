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

namespace MyProject02
{
    public partial class index927_2 : System.Web.UI.Page
    {
        AccessBll accessBll = new AccessBll();
        ArtBll artBll = new ArtBll();

        string sql = "";
        DataTable dt;

        public string title = @ConfigurationManager.AppSettings["title"].ToString();//网站title关键词
        public string keyword = "";

        string Article_File = @ConfigurationManager.AppSettings["Article_File"].ToString();//文章图片存储路径

        public string friendLink = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            CommonMethod.ValidUrl();

            keyword = title.Replace("|", ",");

            BindHuandeng();//绑定首页幻灯
            BindRiji();//绑定妈咪日记
            BindList();//绑定列表
            BindTuijianList();//绑定推荐阅读
            BindFriendLink();//绑定友情链接
        }

        #region 绑定首页幻灯

        private void BindHuandeng()
        {
            sql = "Select top 3 title,html,huandeng1_pic FROM t_article  where huandeng1=1 order by update_date desc ";
            dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                this.repList_hd.DataSource = dt;
                this.repList_hd.DataBind();
            }
        }
        #endregion

        #region 绑定妈咪日记

        private void BindRiji()
        {
            //绑定最新发布的前N条文章
            sql = "Select top 3 t_article.id as articleId,t_article.title,t_article.title1,t_article.keyword,t_article.daoyu,t_article.content,t_article.type,t_article.update_date,t_article.declare_mark,t_article.pic,t_article.html,t_article.remark,t_article_type.type_name,source,tag,tag_id FROM t_article  " +
                                " LEFT JOIN t_article_type ON t_article.type=t_article_type.id  ";

            sql += " where daoyu<>'no' and pic<>'' and tag_id like '%,8,%' ";

            sql += " order by update_date desc ";
            dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                this.repList11.DataSource = dt;
                this.repList11.DataBind();
            }
        }
        #endregion

        #region 绑定列表

        private void BindList()
        {
            int art_img_id = 0;
            //儿童早教 
            //绑定第一个带图片和导语的文章
            sql = "Select top 1 t_article.id as articleId,t_article.title,t_article.title1,t_article.keyword,t_article.daoyu,t_article.content,t_article.type,t_article.update_date,t_article.declare_mark,t_article.pic,t_article.html,t_article.remark,t_article_type.type_name,source,tag,tag_id FROM t_article  " +
                                " LEFT JOIN t_article_type ON t_article.type=t_article_type.id  ";
            sql += " where daoyu<>'no' and pic<>'' and type=3 ";
            sql += " order by update_date desc ";
            dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                this.repList01a.DataSource = dt;
                this.repList01a.DataBind();
                art_img_id = Convert.ToInt32(dt.Rows[0]["articleId"]);
            }
            //绑定最新发布的前N条文章
            sql = "Select top 10 t_article.id as articleId,t_article.title,t_article.title1,t_article.keyword,t_article.daoyu,t_article.content,t_article.type,t_article.update_date,t_article.declare_mark,t_article.pic,t_article.html,t_article.remark,t_article_type.type_name,source,tag,tag_id FROM t_article  " +
                                " LEFT JOIN t_article_type ON t_article.type=t_article_type.id  ";
            sql += " where type=3 and t_article.id<>" + art_img_id;
            sql += " order by update_date desc ";
            dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                this.repList01b.DataSource = dt;
                this.repList01b.DataBind();
            }

            //母婴知识 
            //绑定第一个带图片和导语的文章
            sql = "Select top 1 t_article.id as articleId,t_article.title,t_article.title1,t_article.keyword,t_article.daoyu,t_article.content,t_article.type,t_article.update_date,t_article.declare_mark,t_article.pic,t_article.html,t_article.remark,t_article_type.type_name,source,tag,tag_id FROM t_article  " +
                                " LEFT JOIN t_article_type ON t_article.type=t_article_type.id  ";
            sql += " where daoyu<>'no' and pic<>'' and type=2 ";
            sql += " order by update_date desc ";
            dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                this.repList02a.DataSource = dt;
                this.repList02a.DataBind();
                art_img_id = Convert.ToInt32(dt.Rows[0]["articleId"]);
            }
            //绑定最新发布的前N条文章
            sql = "Select top 10 t_article.id as articleId,t_article.title,t_article.title1,t_article.keyword,t_article.daoyu,t_article.content,t_article.type,t_article.update_date,t_article.declare_mark,t_article.pic,t_article.html,t_article.remark,t_article_type.type_name,source,tag,tag_id FROM t_article  " +
                                " LEFT JOIN t_article_type ON t_article.type=t_article_type.id  ";
            sql += " where type=2 ";//and t_article.id<>" + art_img_id;
            sql += " order by update_date desc ";
            dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                this.repList02b.DataSource = dt;
                this.repList02b.DataBind();
            }

            //育儿知识 
            //绑定第一个带图片和导语的文章
            sql = "Select top 1 t_article.id as articleId,t_article.title,t_article.title1,t_article.keyword,t_article.daoyu,t_article.content,t_article.type,t_article.update_date,t_article.declare_mark,t_article.pic,t_article.html,t_article.remark,t_article_type.type_name,source,tag,tag_id FROM t_article  " +
                                " LEFT JOIN t_article_type ON t_article.type=t_article_type.id  ";
            sql += " where daoyu<>'no' and pic<>'' and type=4 ";
            sql += " order by update_date desc ";
            dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                this.repList03a.DataSource = dt;
                this.repList03a.DataBind();
                art_img_id = Convert.ToInt32(dt.Rows[0]["articleId"]);
            }
            //绑定最新发布的前N条文章
            sql = "Select top 10 t_article.id as articleId,t_article.title,t_article.title1,t_article.keyword,t_article.daoyu,t_article.content,t_article.type,t_article.update_date,t_article.declare_mark,t_article.pic,t_article.html,t_article.remark,t_article_type.type_name,source,tag,tag_id FROM t_article  " +
                                " LEFT JOIN t_article_type ON t_article.type=t_article_type.id  ";
            sql += " where type=4 and t_article.id<>" + art_img_id;
            sql += " order by update_date desc ";
            dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                this.repList03b.DataSource = dt;
                this.repList03b.DataBind();
            }

            //生活常识 
            //绑定第一个带图片和导语的文章
            sql = "Select top 1 t_article.id as articleId,t_article.title,t_article.title1,t_article.keyword,t_article.daoyu,t_article.content,t_article.type,t_article.update_date,t_article.declare_mark,t_article.pic,t_article.html,t_article.remark,t_article_type.type_name,source,tag,tag_id FROM t_article  " +
                                " LEFT JOIN t_article_type ON t_article.type=t_article_type.id  ";
            sql += " where daoyu<>'no' and pic<>'' and type=5 ";
            sql += " order by update_date desc ";
            dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                this.repList04a.DataSource = dt;
                this.repList04a.DataBind();
                art_img_id = Convert.ToInt32(dt.Rows[0]["articleId"]);
            }
            //绑定最新发布的前N条文章
            sql = "Select top 10 t_article.id as articleId,t_article.title,t_article.title1,t_article.keyword,t_article.daoyu,t_article.content,t_article.type,t_article.update_date,t_article.declare_mark,t_article.pic,t_article.html,t_article.remark,t_article_type.type_name,source,tag,tag_id FROM t_article  " +
                                " LEFT JOIN t_article_type ON t_article.type=t_article_type.id  ";
            sql += " where type=5 and t_article.id<>" + art_img_id;
            sql += " order by update_date desc ";
            dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                this.repList04b.DataSource = dt;
                this.repList04b.DataBind();
            }
        }
        #endregion

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
            sql = "Select top 7 t_article.id as articleId,t_article.title,t_article.title1,t_article.keyword,t_article.daoyu,t_article.content,t_article.type,t_article.update_date,t_article.declare_mark,t_article.pic,t_article.html,t_article.remark,t_article_type.type_name,source FROM t_article  " +
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
            daoyu = daoyu.Trim();
            content = content.Trim();
            if (daoyu.Trim() != "" && daoyu.Trim() != "no")
            {
                if (daoyu.Length > length)
                    return daoyu.Substring(0, length) + "...";
                else
                    return daoyu + "...";
            }
            else
            {
                string returnStr = InText.SafeSqlContent(content);
                if (returnStr.Length > length)
                    return returnStr.Substring(0, length);
                else
                    return content + "...";
            }
        }
        #endregion

        #region 绑定友情链接

        private void BindFriendLink()
        {
            string sql = " Select id,link_name,link,link_order FROM t_friendlink order by link_order";
            DataTable dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                this.repFriend.DataSource = dt;
                this.repFriend.DataBind();
            }
        }
        #endregion

    }
}
