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
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyProject02.xzdd927.article
{
    public partial class article_list : System.Web.UI.Page
    {
        int adminId = 0;//编辑ID

        ArtBll artBll = new ArtBll();
        int articleId = 0;
        string title = "";
        int articleType = 0;
        int right_type = 0;
        int isHuandeng1 = 0;

        string update_date_min = "";
        string update_date_max = "";

        string tag = "";
        string html = "";

        string search_keyword = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            adminId = new AdminMethod().CheckAdminLogin();//-----------------------------

            if (!IsPostBack)
            {
                InitArticle();
            }

            if (!string.IsNullOrEmpty(Request.QueryString["a_id"]) && MetarnetRegex.IsNumeric(Request.QueryString["a_id"]))
            {
                articleId = Utils.CheckInt(Request.QueryString["a_id"].ToString());
                this.txt_article_id.Value = InText.SafeSql(InText.SafeStr(Request.QueryString["a_id"].ToString()));
            }
            if (!string.IsNullOrEmpty(Request.QueryString["title"]))
            {
                title = InText.SafeStr(Request.QueryString["title"].ToString());
                this.txt_title.Value = title;
            }
            if (!string.IsNullOrEmpty(Request.QueryString["search_keyword"]))
            {
                search_keyword = InText.SafeStr(Request.QueryString["search_keyword"].ToString());
                this.txt_search_keyword.Value = title;
            }
            if (!string.IsNullOrEmpty(Request.QueryString["a_t"]) && MetarnetRegex.IsNumeric(Request.QueryString["a_t"]))
            {
                articleType = Utils.CheckInt(Request.QueryString["a_t"].ToString());
                this.ddl_articleType.SelectedValue = InText.SafeStr(Request.QueryString["a_t"].ToString());
            }

            if (!string.IsNullOrEmpty(Request.QueryString["dateMin"]))
            {
                update_date_min =InText.SafeSql(InText.SafeStr(Request.QueryString["dateMin"].ToString()));
                this.txt_update_date_min.Value = update_date_min;
            }
            if (!string.IsNullOrEmpty(Request.QueryString["dateMax"]))
            {
                update_date_max = InText.SafeSql(InText.SafeStr(Request.QueryString["dateMax"].ToString()));
                this.txt_update_date_max.Value = update_date_max;
            }

            if (!string.IsNullOrEmpty(Request.QueryString["tag"]))
            {
                tag = InText.SafeStr(Request.QueryString["tag"].ToString());
                this.txt_tag.Value = tag;
            }
            if (!string.IsNullOrEmpty(Request.QueryString["html"]))
            {
                html = InText.SafeStr(Request.QueryString["html"].ToString());
                this.txt_html.Value = html;
            }
            if (!string.IsNullOrEmpty(Request.QueryString["hd1"]) && MetarnetRegex.IsNumeric(Request.QueryString["hd1"]))
            {
                isHuandeng1 = Utils.CheckInt(Request.QueryString["hd1"].ToString());
                this.chkIsHuandeng1.Checked = true;
            }

            if (!string.IsNullOrEmpty(Request.QueryString["r_t"]) && MetarnetRegex.IsNumeric(Request.QueryString["r_t"]))
            {
                right_type = Utils.CheckInt(Request.QueryString["r_t"].ToString());
                this.ddl_right_type.SelectedValue = InText.SafeStr(Request.QueryString["r_t"].ToString());
            }

            if (!IsPostBack)
            {
                BindList();//绑定列表
            }
        }

        private void InitArticle()
        {
            String sql = "select * from t_article_type ";
            DataTable dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                this.ddl_articleType.DataSource = dt;
                this.ddl_articleType.DataBind();
                this.ddl_articleType.Items.Insert(0, new ListItem("全部分类", "0"));
            }
        }

        #region 绑定列表

        private bool BindList()
        {
            bool ifOk = true;

            int pageIndex = 1;
            int pageSize = 20;//pager.PageSize;//每页显示20条信息
            int totalRecord = 0;

            if (!string.IsNullOrEmpty(Request.QueryString["p"]) && MetarnetRegex.IsNumeric(Request.QueryString["p"]))
            {
                pageIndex = Convert.ToInt32(InText.SafeSql(InText.SafeStr(Request.QueryString["p"].ToString())));
            }

            string where = " where 1=1";
            if (articleId != 0)
            {
                where += " and t_article.id=" + articleId;
            }
            if (title.Trim() != "")
            {
                where += " and title like '%" + title+"%'";
            }
            if (search_keyword.Trim() != "")
            {
                where += " and search_keyword like '%" + search_keyword + "%'";
            }
            
            if (articleType != 0)
            {
                where += " and type=" + articleType;
            }
            if (right_type != 0)
            {
                where += " and right_type=" + right_type;
            }
            if (update_date_min != "")
            {
                where += " and  DateDiff( day,  '" + update_date_min + "',update_date) >=0 ";
            }
            if (update_date_max != "")
            {
                where += " and  DateDiff( day,  '" + update_date_max + "',update_date) <=0 ";
            }
            if (tag.Trim() != "")
            {
                where += " and tag like '%" + tag + "%'";
            }
            if (html.Trim() != "")
            {
                where += " and html like '%" + html + "%'";
            }
            if (isHuandeng1 != 0)
            {
                where += " and huandeng1=1 ";
            }

            //string strSql = " Select P.ProductID,P.ProClassID,P.ProductName,P.ProFlag,P.DateTime,P.ProductImage,C.ProClassName,C.ProClassKey,C.ProClassDes FROM ProductInfo P  " +
            //                    " LEFT JOIN ProClass C ON P.ProClassID=C.ProClassID ";
            //string strShow = " ProductID,ProductName,DateTime,ProductImage,ProFlag,ProClassName,ProClassKey,ProClassDes ";
            //return ClassFile.AccessHelper.ExecutePager(PageIndex, PageSize, "ProductID", strShow, strSql, strWhere, " ProductID DESC ", out PageCount, out RecordCount);

            string strSql = " Select t_article.id as articleId,t_article.title,t_article.keyword,t_article.search_keyword,t_article.daoyu,t_article.content,t_article.type,t_article.update_date,t_article.declare_mark,t_article.pic,t_article.html,t_article.remark,t_article_type.type_name,source,t_article.tag,t_article.tag_id,t_article.huandeng1,right_type,t_article.ts_baidu "
                                + " ,row_number() over(order by t_article.id desc) as rowNumber "
                                +" FROM t_article  " 
                                +" LEFT JOIN t_article_type ON t_article.type=t_article_type.id ";
            DataTable dt = artBll.ExecutePager(strSql + where, pageSize, pageIndex, ref totalRecord);

            if (dt.Rows.Count > 0)
            {
                ifOk = true;

                pager.PageSize = pageSize;
                pager.RecordCount = totalRecord;
                this.repList.DataSource = dt;
                this.repList.DataBind();

                this.labInfoCount.Text = totalRecord.ToString();

                if (totalRecord <= pageSize)//只有一页，隐藏分页控件
                {
                    this.divFenye.Visible = false;
                }
            }
            else
            {
                this.divFenye.Visible = false;
                ifOk = false;
            }
            return ifOk;
        }
        #endregion

        //删除、推送一条文章按钮
        protected void repList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.CommandName == "Delete")
                {
                    int articleId = Convert.ToInt32(e.CommandArgument);
                    string delImg = "";
                    string delImg_huandeng1 = "";
                    string delHtml = "";
                    DataTable dtDel = artBll.SelectToDataTable("select * from t_article where id=" + articleId);
                    if (dtDel.Rows.Count > 0)
                    {
                        delImg = dtDel.Rows[0]["pic"].ToString();//文章图片
                        delImg_huandeng1 = dtDel.Rows[0]["huandeng1_pic"].ToString();//文章幻灯图片
                        delHtml = dtDel.Rows[0]["html"].ToString();//文章静态页

                        bool isOk = DeleteOneArticle(articleId);//执行删除操作

                        if (isOk)
                        {
                            string strPath = HttpRuntime.AppDomainAppPath.ToString() + @ConfigurationManager.AppSettings["Article_File"].ToString() + delImg;//删除原图
                            CommonMethod.FilePicDelete(strPath);
                            strPath = HttpRuntime.AppDomainAppPath.ToString() + @ConfigurationManager.AppSettings["Article_File"].ToString() + "100_100_" + delImg;//删除缩略图
                            CommonMethod.FilePicDelete(strPath);

                            strPath = HttpRuntime.AppDomainAppPath.ToString() + @ConfigurationManager.AppSettings["hd1"].ToString() + delImg_huandeng1;//删除幻灯图片
                            CommonMethod.FilePicDelete(strPath);

                            strPath = HttpRuntime.AppDomainAppPath.ToString() + delHtml;//删除静态页
                            CommonMethod.FilePicDelete(strPath);


                            InText.AlertAndRedirect("删除成功！", Request.Url.ToString());//刷新当前页
                        }
                        else
                        {
                            InText.AlertAndRedirect("删除失败，请重试！", Request.Url.ToString());//刷新当前页
                        }

                    }
                }
                if (e.CommandName == "ts_baidu")//执行推送百度
                {
                    //string[] array = e.CommandArgument.ToString().Split('|');
                    //int art_id = Utils.CheckInt(array[0]);
                    //string html = array[1];
                    //SEO seo = new SEO();
                    //string resultStr = seo.TS_baidu(art_id, html);
                    //InText.AlertAndRedirect(resultStr, Request.Url.ToString());

                    string[] array = e.CommandArgument.ToString().Split('|');
                    int art_id = Utils.CheckInt(array[0]);
                    string html = array[1];
                    SEO seo = new SEO();

                    if (Request.Url.ToString().Contains("http://www.up927.com/"))
                    {
                        
                        string resultStr = seo.TS_baidu(art_id, html);
                        InText.AlertAndRedirect(resultStr, Request.Url.ToString());
                    }
                    else
                    {
                        InText.AlertAndRedirect("本地不能推送百度", Request.Url.ToString());
                    }
                }
            }
        }

        //删除一篇文章
        private bool DeleteOneArticle(int articleId)
        {
            string sql = "delete from t_article where id=" + articleId;
            return artBll.ExecuteSQLNonquery(sql);
        }

        public string GetTS_baiduShow(int ts_baidu)
        {
            if (ts_baidu == 1)
            {
                return "none";
            }
            else
            {
                return "";
            }
        }

        ////推送百度
        //private void TS_baidu(string html)
        //{
        //    string[] result = { "-1", "尚未执行" };//执行结果

        //    string param = "POST /urls?site=www.111.com&token=UO50AFeBnZc5cFdy HTTP/1.1 User-Agent: curl/7.12.1 Host: data.zz.baidu.com Content-Type: text/plain Content-Length: 83 http://www.up927.com" + html;
        //    string aaa = new Http().Post(string.Format("http://data.zz.baidu.com/urls?site=www.up927.com&token={0}", "UO50AFeBnZc5cFdy"), param);
        //    JObject jo = JObject.Parse(aaa);
        //    result = jo.Properties().Select(item => item.Value.ToString()).ToArray();
        //    Response.Redirect(Request.Url.ToString());
        //}

        #region 截取标题字数

        public string GetPartContent(string content, int length)
        {
            return CommonMethod.GetStringByLenth(content, length);
        }
        #endregion

        #region 返回文章是否有图片

        public string GetImg(string pic)
        {
            if (pic.Trim() != "")
            {
                return "<img src='/images/img.gif' onclick='OpenImg(\"" + "/Article_File/" + pic +"\")' style='cursor:pointer;'/>";
            }
            else
            {
                return "";
            }
        }
        #endregion

        #region 返回右侧类别

        public string GetRightType(int right_type)
        {
            if (right_type == 1)
            {
                return "热门文章";
            }
            else if (right_type == 2)
            {
                return "精品文章";
            }
            else if (right_type == 3)
            {
                return "推荐文章";
            }
            else
            {
                return "无";
            }
        }
        #endregion

    }
}
