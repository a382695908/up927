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
        AccessBll accessBll = new AccessBll();
        int articleId = 0;
        string title = "";
        string tagName = "";
        int tag_id = 0;
        int articleType = 0;
        public string articleTypeName = "";
        public string html_title = "";//页面title
        public string tishi = "";

        public string description = "好宝宝网为您提供有关" + @ConfigurationManager.AppSettings["title"].ToString() + "的相关内容";
        public string keywords = @ConfigurationManager.AppSettings["title"].ToString().Replace("|", ",");

        public int itemscount = 0;

        string sql = "";
        DataTable dt;

        public string navStr = "";// ?at=1 ?tag=1

        protected void Page_Load(object sender, EventArgs e)
        {
            CommonMethod.ValidUrl();

            if (!string.IsNullOrEmpty(Request.QueryString["title"]))
            {
                title = InText.SafeSql(InText.SafeStr(Request.QueryString["title"].ToString()));
                //this.txt_search.Value = title;
                articleTypeName = "&gt " + "“" + title + "”的搜索结果";
                html_title = "“" + title + "”" + "的搜索结果_好宝宝早教网";
                tishi = title;
                this.div_tishi.Visible = true;

                description = "好宝宝早教网为您提供有关" + title +"_" + @ConfigurationManager.AppSettings["title"].ToString()+ "的相关内容";
                keywords = title + "_" + @ConfigurationManager.AppSettings["title"].ToString();
            }
            if (!string.IsNullOrEmpty(Request.QueryString["tag"]))
            {
                tag_id = (Utils.CheckInt(Request.QueryString["tag"].ToString()));
                if (tag_id != 0)
                {
                    tagName = this.SelectOneTagName(tag_id.ToString());
                    html_title = tagName + "_" + @ConfigurationManager.AppSettings["title"].ToString();
                    tishi = tagName;
                    this.div_tishi.Visible = true;

                    description = "好宝宝早教网为您提供有关" + tagName + "_" + @ConfigurationManager.AppSettings["title"].ToString() + "的相关内容";
                    keywords = tagName + "_" + @ConfigurationManager.AppSettings["title"].ToString();

                    navStr = "tag=" + tag_id.ToString();
                    this.div_nav.Visible = true;
                }
            }
            if (!string.IsNullOrEmpty(Request.QueryString["at"]) && MetarnetRegex.IsNumeric(Request.QueryString["at"]))
            {
                articleType = Utils.CheckInt(Request.QueryString["at"].ToString());

                string sql = "select type_name,type_keyword from t_article_type where id=" + articleType;
                DataTable dtType = accessBll.SelectToDataTable(sql);
                if (dtType.Rows.Count > 0)
                {
                    articleTypeName = "&gt <span style='color:#36648b'>" + dtType.Rows[0]["type_name"].ToString() + "</span>";
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

                    navStr = "at=" + articleType.ToString();
                    this.div_nav.Visible = true;
                }
            }

            if (html_title.Trim() == "")
            {
                html_title = @ConfigurationManager.AppSettings["title"].ToString();
            }

            if (tishi.Trim() == "")
            {
                this.div_tishi.Visible = false;
            }

            if (!IsPostBack)
            {
                BindList();//绑定列表

                //GetTypeList();//绑定文章分类
                //BindHotList();//绑定热门文章
            }
        }

        #region 绑定列表

        private bool BindList()
        {
            bool ifOk = true;

            int pageIndex = 1;
            int pageSize = 20;//pager.PageSize;//每页显示10条信息
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
                where += " and title like '%" + title + "%'";
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
                where += " and daoyu<>'no' ";
            }
            //string strSql = " Select P.ProductID,P.ProClassID,P.ProductName,P.ProFlag,P.DateTime,P.ProductImage,C.ProClassName,C.ProClassKey,C.ProClassDes FROM ProductInfo P  " +
            //                    " LEFT JOIN ProClass C ON P.ProClassID=C.ProClassID ";
            //string strShow = " ProductID,ProductName,DateTime,ProductImage,ProFlag,ProClassName,ProClassKey,ProClassDes ";
            //return ClassFile.AccessHelper.ExecutePager(PageIndex, PageSize, "ProductID", strShow, strSql, strWhere, " ProductID DESC ", out PageCount, out RecordCount);

            string strSql = " Select t_article.id as articleId,t_article.title,t_article.keyword,t_article.daoyu,t_article.content,t_article.type,t_article.update_date,t_article.declare_mark,t_article.pic,t_article.html,t_article.remark,t_article_type.type_name,tag,tag_id FROM t_article  " +
                                " LEFT JOIN t_article_type ON t_article.type=t_article_type.id ";
            string strShow = " articleId,title,keyword,daoyu,content,type,update_date,declare_mark,pic,remark,type_name,html,tag,tag_id ";//要显示的字段
            int PageCount = 0;
            DataTable dt = accessBll.ExecutePager(pageIndex, pageSize, "articleId", strShow, strSql, where, " update_date DESC ", out PageCount, out totalRecord);

            string sqlCount = "select count(*) from t_article left join t_article_type on t_article.type=t_article_type.id " + where;
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

                this.div_news.Visible = true;
            }
            else
            {
                this.divFenye.Visible = false;
                ifOk = false;

                //绑定最新发布的前N条文章
                sql = "Select top 30 t_article.id as articleId,t_article.title,t_article.keyword,t_article.daoyu,t_article.content,t_article.type,t_article.update_date,t_article.declare_mark,t_article.pic,t_article.html,t_article.remark,t_article_type.type_name,source,tag,tag_id FROM t_article  " +
                                    " LEFT JOIN t_article_type ON t_article.type=t_article_type.id  ";

                sql += " where daoyu<>'no' ";

                sql += " order by update_date desc ";
                dt = accessBll.SelectToDataTable(sql);
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

        #region 返回是否显示图片

        public string GetImgShow(string pic)
        {
            if (pic.Trim() != "")
            {
                return "";
            }
            else
            {
                return "none;";
            }
        }
        #endregion

        protected void repList1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HyperLink link = e.Item.FindControl("hl_artImg") as HyperLink;//找到里层的对象
                DataRowView rowv = (DataRowView)e.Item.DataItem;//找到分类Repeater关联的数据项 
                string pic = rowv["pic"].ToString(); //获取填充子类的id 
                if (pic.Trim() == "")
                {
                    link.Visible = false;
                }
            }
        }

        #region 返回图片，若没有则返回默认图片，避免404

        public string GetPic(string pic)
        {
            if (pic.Trim() != "")
            {
                return pic;
            }
            else
            {
                return "up927.jpg";
            }
        }
        #endregion

        #region 返回导语

        public string GetDaoyu(string daoyu, string content, int length)
        {
            daoyu = InText.SafeStr(daoyu);
            content = InText.SafeStr(content);

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
                if (content.Length > length)
                    return content.Substring(0, length) + "...";
                else
                    return content + "...";
            }
        }
        #endregion

        #region 截取标题字数

        public string GetPartContent(string content, int length)
        {
            return CommonMethod.GetStringByLenth(content, length);
        }
        #endregion

        #region 绑定文章分类

        private void GetTypeList()
        {
            //String sql = "select * from t_article_type ";
            //DataTable dt = accessBll.SelectToDataTable(sql);
            //if (dt.Rows.Count > 0)
            //{
            //    this.repList2.DataSource = dt;
            //    this.repList2.DataBind();
            //}
        }
        #endregion

        #region 绑定热门文章

        private void BindHotList()
        {
            ////绑定最新发布的前N条文章
            //sql = "Select top 10 t_article.id as articleId,t_article.title,t_article.keyword,t_article.daoyu,t_article.content,t_article.type,t_article.update_date,t_article.declare_mark,t_article.pic,t_article.html,t_article.remark,t_article_type.type_name,source FROM t_article  " +
            //                    " LEFT JOIN t_article_type ON t_article.type=t_article_type.id  order by update_date desc ";//where articleId not in (0,Select top 10 id from t_article order by update_date desc)
            //dt = accessBll.SelectToDataTable(sql);
            //if (dt.Rows.Count > 0)
            //{
            //    this.repList3.DataSource = dt;
            //    this.repList3.DataBind();
            //}
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
                returnStr = "标签：";
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].Trim() != "" && arrayId[i].Trim() != "")
                    {
                        returnStr += "<a href='/list.aspx?tag=" + arrayId[i] + "' target='_blank'>" + array[i] + "</a>&nbsp;";//HttpUtility.UrlEncode(array[i])
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
            DataTable dt = accessBll.SelectToDataTable(sql);
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
