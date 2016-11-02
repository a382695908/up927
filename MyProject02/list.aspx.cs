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
    public partial class list : System.Web.UI.Page
    {
        ArtBll artBll = new ArtBll();

        int articleId = 0;
        string title = "";
        string tagName = "";
        int tag_id = 0;
        int articleType = 0;
        public string articleTypeName = "";
        public string html_title = "";//页面title
        public string tishi = "搜索结果";

        public string description = "好宝宝网为您提供有关" + @ConfigurationManager.AppSettings["title"].ToString() + "的相关内容";
        public string keywords = @ConfigurationManager.AppSettings["title"].ToString().Replace("|", ",");

        public int itemscount = 0;

        string sql = "";
        DataTable dt;

        public string navStr = "";// ?at=1 ?tag=1

        public string miaoshu_title = "";
        public string miaoshu_pic = "";
        public string miaoshu = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            CommonMethod.ValidUrl();

            if (!string.IsNullOrEmpty(Request.QueryString["title"]))
            {
                title = InText.SafeSql(InText.SafeStr(Request.QueryString["title"].ToString()));
                tishi = "“" + title + "”的搜索结果";
                html_title = "“" + title + "”" + "的搜索结果_好宝宝早教网";
                description = "好宝宝早教网为您提供有关" + title + "_" + @ConfigurationManager.AppSettings["title"].ToString() + "的相关内容";
                keywords = title + "_" + @ConfigurationManager.AppSettings["title"].ToString();
            }
            if (!string.IsNullOrEmpty(Request.QueryString["tag"]))
            {
                tag_id = (Utils.CheckInt(Request.QueryString["tag"].ToString()));
                if (tag_id != 0)
                {
                    String sql = "select * from t_tag where id=" + tag_id;
                    DataTable dt = artBll.SelectToDataTable(sql);
                    if (dt.Rows.Count > 0)
                    {
                        tagName = dt.Rows[0]["tag_name"].ToString();
                        if (dt.Rows[0]["tag_keyword"].ToString().Trim() != "")
                        {
                            html_title = tagName + "_" + dt.Rows[0]["tag_keyword"].ToString()+"_好宝宝早教网";
                            description = "好宝宝早教网为您提供有关" + tagName + "_" + dt.Rows[0]["tag_keyword"].ToString() + "的相关内容";
                            keywords = tagName + "_" + dt.Rows[0]["tag_keyword"].ToString();
                        }
                        else
                        {
                            html_title = tagName + "_好宝宝早教网";//+ "_" + @ConfigurationManager.AppSettings["title"].ToString();
                            description = "好宝宝早教网为您提供有关" + tagName + "_" + @ConfigurationManager.AppSettings["title"].ToString() + "的相关内容";
                            keywords = tagName + "_" + @ConfigurationManager.AppSettings["title"].ToString();
                        }
                        tishi = tagName;

                        miaoshu_pic = dt.Rows[0]["tag_pic"].ToString();
                        miaoshu = dt.Rows[0]["tag_miaoshu"].ToString();
                        miaoshu_title = tagName;
                        if (miaoshu.Trim() != "")
                        {
                            this.div_miaoshu.Visible = true;//显示描述div
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(Request.QueryString["at"]) && MetarnetRegex.IsNumeric(Request.QueryString["at"]))
            {
                articleType = Utils.CheckInt(Request.QueryString["at"].ToString());
                this.hid_type.Value = Request.QueryString["at"].ToString();

                string sql = "select type_name,type_keyword from t_article_type where id=" + articleType;
                DataTable dtType = artBll.SelectToDataTable(sql);
                if (dtType.Rows.Count > 0)
                {
                    articleTypeName = dtType.Rows[0]["type_name"].ToString();
                    if (dtType.Rows[0]["type_keyword"].ToString().Trim() != "")//分类关键词
                    {
                        html_title = dtType.Rows[0]["type_name"].ToString() + "_" + dtType.Rows[0]["type_keyword"].ToString() + "_好宝宝早教网";

                        description = "好宝宝早教网为您提供有关" + dtType.Rows[0]["type_name"].ToString() + "_" + dtType.Rows[0]["type_keyword"].ToString() + "_" + @ConfigurationManager.AppSettings["title"].ToString() + "的相关内容";
                        keywords = dtType.Rows[0]["type_name"].ToString() + "," + dtType.Rows[0]["type_keyword"].ToString() + "," + @ConfigurationManager.AppSettings["title"].ToString().Replace("|", ",");
                    }
                    else
                    {
                        html_title = dtType.Rows[0]["type_name"].ToString() + "_好宝宝早教网";

                        description = "好宝宝早教网为您提供有关" + dtType.Rows[0]["type_name"].ToString() + "_" + @ConfigurationManager.AppSettings["title"].ToString() + "的相关内容";
                        keywords = dtType.Rows[0]["type_name"].ToString() + "," + @ConfigurationManager.AppSettings["title"].ToString().Replace("|", ",");
                    }
                    tishi = dtType.Rows[0]["type_name"].ToString();
                }
            }
            if (html_title.Trim() == "")
            {
                html_title = @ConfigurationManager.AppSettings["title"].ToString();
            }

            if (!string.IsNullOrEmpty(Request.QueryString["p"]) && MetarnetRegex.IsNumeric(Request.QueryString["p"]))
            {
                int p = Convert.ToInt32(InText.SafeSql(InText.SafeStr(Request.QueryString["p"].ToString())));
                if (p > 1)
                {
                    html_title += "_第"+p+"页";
                }
            }

            if (!IsPostBack)
            {
                BindList();//绑定列表
            }
        }

        #region 绑定列表

        private bool BindList()
        {
            bool ifOk = true;

            int pageIndex = 1;
            int pageSize = 30;//pager.PageSize;//每页显示10条信息
            int totalRecord = 0;

            if (!string.IsNullOrEmpty(Request.QueryString["p"]) && MetarnetRegex.IsNumeric(Request.QueryString["p"]))
            {
                pageIndex = Convert.ToInt32(InText.SafeSql(InText.SafeStr(Request.QueryString["p"].ToString())));
            }

            string where = " where 1=1";
            if (articleId != 0)
            {
                where += " and articleId=" + articleId;
            }
            if (title.Trim() != "")
            {
                where += " and (title like '%" + title + "%' or keyword like '%" + title + "%' or tag_name like '%" + title + "%' or search_keyword like '%" + title + "%')";
            }
            if (tag_id != 0)
            {
                where += " and tag_id like '%," + tag_id + ",%'";
            }
            if (articleType != 0)
            {
                where += " and type=" + articleType;
            }

            if (where == " where 1=1")
            {
                //where += " and daoyu<>'no' ";
            }

            string strSql = " Select t_article.id as articleId,t_article.title,t_article.keyword,t_article.daoyu,t_article.content,t_article.type,t_article.update_date,t_article.declare_mark,t_article.pic,t_article.html,t_article.remark,t_article_type.type_name,tag,tag_id,tag_name "
                               + " ,row_number() over(order by t_article.id desc) as rowNumber "
                               +" FROM t_article  " 
                               +"  LEFT JOIN t_article_type ON t_article.type=t_article_type.id "
                               + " LEFT JOIN t_tag ON replace(t_article.tag_id,',','')=t_tag.id ";
            DataTable dt = artBll.ExecutePager(strSql + where, pageSize, pageIndex, ref totalRecord);
            //string strShow = " articleId,title,keyword,daoyu,content,type,update_date,declare_mark,pic,remark,type_name,html,tag,tag_id ";//要显示的字段
            //int PageCount = 0;
            //DataTable dt = artBll.ExecutePager(strSql, pageSize, pageIndex, ref totalRecord);

            //string sqlCount = "select count(*) from t_article left join t_article_type on t_article.type=t_article_type.id " + where;
            //totalRecord = accessBll.MaxCount(sqlCount);
            if (dt.Rows.Count > 0)
            {
                ifOk = true;

                pager.PageSize = pageSize;
                pager.RecordCount = totalRecord;
                this.repList1.DataSource = dt;
                this.repList1.DataBind();

                //this.labInfoCount.Text = totalRecord.ToString();

                if (totalRecord <= pageSize)//只有一页，隐藏分页控件
                {
                    this.divFenye.Visible = false;
                }

                //this.div_news.Visible = true;
            }
            else
            {
                this.divFenye.Visible = false;
                ifOk = false;

                //绑定最新发布的前N条文章
                sql = "Select top 20 t_article.id as articleId,t_article.title,t_article.keyword,t_article.daoyu,t_article.content,t_article.type,t_article.update_date,t_article.declare_mark,t_article.pic,t_article.html,t_article.remark,t_article_type.type_name,source,tag,tag_id FROM t_article  " +
                                    " LEFT JOIN t_article_type ON t_article.type=t_article_type.id  ";

                sql += " where daoyu<>'no' ";

                sql += " order by update_date desc ";
                dt = artBll.SelectToDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    this.repList2.DataSource = dt;
                    this.repList2.DataBind();
                }
                this.div_nonews1.Visible = true;
                this.div_nonews2.Visible = true;
            }
            return ifOk;
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

        #region 返回标签

        public string GetTag(string tag, string tag_id)
        {
            string returnStr = "";
            if (tag.Trim() != "")
            {
                string[] array = tag.Split(' ');
                string[] arrayId = CommonMethod.GetArrayNoEmpty(tag_id.Split(','));
                returnStr = "百科：";
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].Trim() != "" && arrayId[i].Trim() != "")
                    {
                        returnStr += "<a href='http://www.up927.com/list.aspx?tag=" + arrayId[i] + "' target='_blank'>" + array[i] + "</a>&nbsp;";//HttpUtility.UrlEncode(array[i])
                    }
                }
            }
            return returnStr;
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
