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
using System.Net;

namespace MyProject02.xzdd927.article
{
    public partial class UpdateHtml : System.Web.UI.Page
    {
        ArtBll artBll = new ArtBll();

        int adminId = 0;//编辑ID

        int articleId = 0;
        static string staticPath = @ConfigurationManager.AppSettings["Article_Path"].ToString();
        string url = @ConfigurationManager.AppSettings["url"].ToString();

        string pc = @ConfigurationManager.AppSettings["pc"].ToString();

        public string last_html //
        {
            get
            {
                Object obj = this.ViewState["last_html"];
                if (obj != null)
                {
                    return (string)ViewState["last_html"];
                }
                else
                {
                    return "";
                }
            }
            set
            {
                ViewState["last_html"] = value;
            }
        }
        public string last_title //
        {
            get
            {
                Object obj = this.ViewState["last_title"];
                if (obj != null)
                {
                    return (string)ViewState["last_title"];
                }
                else
                {
                    return "";
                }
            }
            set
            {
                ViewState["last_title"] = value;
            }
        }
        public string next_html //
        {
            get
            {
                Object obj = this.ViewState["next_html"];
                if (obj != null)
                {
                    return (string)ViewState["next_html"];
                }
                else
                {
                    return "";
                }
            }
            set
            {
                ViewState["next_html"] = value;
            }
        }
        public string next_title //
        {
            get
            {
                Object obj = this.ViewState["next_title"];
                if (obj != null)
                {
                    return (string)ViewState["next_title"];
                }
                else
                {
                    return "";
                }
            }
            set
            {
                ViewState["next_title"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            adminId = new AdminMethod().CheckAdminLogin();//-----------------------------

            //string result = "";
            //string sql = "select * from t_article_pic order by id asc ";
            //DataTable dt = artBll.SelectToDataTable(sql);
            //if (dt.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        //t_article
            //        //result += " insert into t_article values ("+dt.Rows[i]["id"]+",'" + dt.Rows[i]["id_show"] + "','" + dt.Rows[i]["title"] + "','" + dt.Rows[i]["title1"] + "','" + dt.Rows[i]["source"] + "','" + dt.Rows[i]["keyword"]+"',"
            //        //    + "'" + dt.Rows[i]["daoyu"] + "','" + dt.Rows[i]["content"] + "'," + dt.Rows[i]["type"] + ",'" + dt.Rows[i]["update_date"] + "',"
            //        //    + "" + dt.Rows[i]["declare_mark"] + ",'" + dt.Rows[i]["pic"] + "','" + dt.Rows[i]["html"] + "','" + dt.Rows[i]["remark"] + "',"
            //        //    + "" + dt.Rows[i]["huandeng1"] + ",'" + dt.Rows[i]["huandeng1_pic"] + "'," + dt.Rows[i]["is_finish"] + ",'" + dt.Rows[i]["tag"] + "','" + dt.Rows[i]["tag_id"] + "',"
            //        //    + "" + dt.Rows[i]["right_type"] + "," + dt.Rows[i]["ts_baidu"] + "," + dt.Rows[i]["last_id"] + "," + dt.Rows[i]["next_id"] + ""
            //        //    + ") ";

            //        result += " insert into t_article_pic values ( " + dt.Rows[i]["id"] + "," + dt.Rows[i]["article_id"] + ",'" + dt.Rows[i]["pic"] + "','" + dt.Rows[i]["update_date"] + "','" + dt.Rows[i]["remark"] + "'"
                        
            //            +" ) ";
            //    }
            //}
            //string aa = result;

            //FileStream fs = new FileStream("E:\\aaaaaa.txt", FileMode.Create);
            ////获得字节数组
            //byte[] data = System.Text.Encoding.Default.GetBytes(result);
            ////开始写入
            //fs.Write(data, 0, data.Length);
            ////清空缓冲区、关闭流
            //fs.Flush();
            //fs.Close();

            //string sql = "select id from t_article order by id asc ";
            //DataTable dt=artBll.SelectToDataTable(sql);
            //if (dt.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        articleId = Convert.ToInt32(dt.Rows[i]["id"]);
            //        int last_id = 0;
            //        int next_id = 0;
            //        string sql1 = "select top 1 * from t_article where id <" + articleId + " order by id desc";
            //        DataTable dt1 = artBll.SelectToDataTable(sql1);
            //        if (dt1.Rows.Count > 0)
            //        {
            //            last_id = Convert.ToInt32(dt1.Rows[0]["id"]);
            //        }

            //        //下一篇
            //        sql1 = "select top 1 * from t_article where id >" + articleId + " order by id ";
            //        dt1 = artBll.SelectToDataTable(sql1);
            //        if (dt1.Rows.Count > 0)
            //        {
            //            next_id = Convert.ToInt32(dt1.Rows[0]["id"]);
            //        }

            //        string sql_exec = "update t_article set last_id=" + last_id + ",next_id=" + next_id + " where id=" + articleId;
            //        artBll.ExecuteSQLNonquery(sql_exec);
            //    }
            //}



        }

        //重新生成PC静态页
        protected void btnUpdateHtml_Click(object sender, EventArgs e)
        {
            string sql = @"Select t_article.id as articleId,t_article.title,t_article.title1,t_article.source,t_article.keyword,t_article.daoyu,t_article.content,t_article.type,t_article.update_date,t_article.declare_mark,t_article.pic as artPic,t_article.html,t_article.remark,t_article.last_id,t_article.next_id,
                            t_article1.html AS last_html,t_article1.title AS last_title,t_article2.html AS next_html,t_article2.title AS next_title,
                            t_article_type.id as type_id,t_article_type.type_name,t_article.tag,t_article.tag_id,t_article.search_keyword
                            FROM (((t_article  
                            LEFT JOIN t_article_type ON (t_article.type=t_article_type.id) )
                            LEFT JOIN t_article t_article1 ON (t_article.last_id=t_article1.id) )
                            LEFT JOIN t_article t_article2 ON (t_article.next_id=t_article2.id)) ";

            DataTable dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int article_id = Convert.ToInt32(dt.Rows[i]["articleId"]);
                    string title = dt.Rows[i]["title"].ToString();
                    string title1 = dt.Rows[i]["title1"].ToString();
                    string source = dt.Rows[i]["source"].ToString();
                    int articleType = Convert.ToInt32(dt.Rows[i]["type_id"]);
                    string articleTypeName = dt.Rows[i]["type_name"].ToString();
                    string content = dt.Rows[i]["content"].ToString();
                    string keyword = dt.Rows[i]["keyword"].ToString();
                    string search_keyword = dt.Rows[i]["search_keyword"].ToString();
                    string artPic = dt.Rows[i]["artPic"].ToString();
                    string article_html = dt.Rows[i]["html"].ToString();
                    string tagStr = dt.Rows[i]["tag"].ToString();
                    string tagIdHtml = dt.Rows[i]["tag_id"].ToString();
                    string update_date = Convert.ToDateTime(dt.Rows[i]["update_date"]).ToString("yyyy年M月d日");
                    string tag_id = dt.Rows[i]["tag_id"].ToString();

                    last_title = "上一篇：" + dt.Rows[i]["last_title"].ToString();
                    last_html = dt.Rows[i]["last_html"].ToString();
                    next_title = "下一篇：" + dt.Rows[i]["next_title"].ToString();
                    next_html = dt.Rows[i]["next_html"].ToString();

                    if (tagIdHtml.Trim() != "")
                    {
                        string[] tagArray = tagIdHtml.Split(',');
                        for (int j = 0; j < tagArray.Length; j++)
                        {
                            if (tagArray[j].Trim() != "" && tagArray[j].Trim() != ",")
                            {
                                tagIdHtml = tagArray[j].Trim();
                                break;
                            }
                        }
                    }

                    //GetLastNext(article_id, articleType);
                    //生成静态页
                    CommonMethod.CreateArticleHtml(article_id, title, title1, source, articleType, articleTypeName, content, keyword, artPic, article_html, tagStr, tag_id, tagIdHtml, update_date, last_html, last_title, next_html, next_title, search_keyword);
                }
            }
            InText.AlertAndRedirect("生成成功！", Request.Url.ToString());//刷新当前页
        }

        //重新生成wap静态页
        protected void btnUpdateWapHtml_Click(object sender, EventArgs e)
        {
            string sql = "select t_article.*,t_article_type.type_name,t_article_type.id as articleType from t_article left join t_article_type on (t_article.type=t_article_type.id)  ";
            DataTable dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int articleId = Convert.ToInt32(dt.Rows[i]["id"]);
                    string title = dt.Rows[i]["title"].ToString();
                    string title1 = dt.Rows[i]["title1"].ToString();
                    string source = dt.Rows[i]["source"].ToString();
                    int articleType = Convert.ToInt32(dt.Rows[i]["articleType"]);
                    string articleTypeName = dt.Rows[i]["type_name"].ToString();
                    string content = dt.Rows[i]["content"].ToString();
                    string keyword = dt.Rows[i]["keyword"].ToString();
                    string search_keyword = dt.Rows[i]["search_keyword"].ToString();
                    string artPic = dt.Rows[i]["pic"].ToString();
                    string article_html = dt.Rows[i]["html"].ToString();
                    string tagStr = dt.Rows[i]["tag"].ToString();
                    string tag_id = dt.Rows[i]["tag_id"].ToString();
                    string tagIdHtml = "";
                    if (tag_id.Trim() != "")
                    {
                        string[] arrayTag_id = tag_id.Split(',');
                        for (int j = 0; j < arrayTag_id.Length; j++)
                        {
                            if (arrayTag_id[j].Trim() != "," && arrayTag_id[j].Trim() != "")
                            {
                                tagIdHtml = arrayTag_id[j];
                                break;
                            }
                        }
                    }

                    //生成wap版静态页
                    CommonMethod.CreateArticleHtml_Wap(articleId, title, title1, source, articleType, articleTypeName, content, keyword, artPic, article_html, tagStr, tag_id, tagIdHtml, search_keyword);
                }
            }
            InText.AlertAndRedirect("生成成功！", Request.Url.ToString());//刷新当前页
        }

        #region 上一篇、下一篇

        private void GetLastNext(int articleId, int articleType)
        {
            //上一篇
            string sql = "select top 1 * from t_article where id <" + articleId +  " order by id desc";
            DataTable dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                last_title = "上一篇：" + dt.Rows[0]["title"].ToString();
                last_html = dt.Rows[0]["html"].ToString();
            }

            //下一篇
            sql = "select top 1 * from t_article where id >" + articleId + " order by id ";
            dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                next_title = "下一篇：" + dt.Rows[0]["title"].ToString();
                next_html = dt.Rows[0]["html"].ToString();
            }
        }

        #endregion

        //首页生成静态页
        protected void btnUpdateHtml_Index_Click(object sender, EventArgs e)
        {
            this.CteateHTML(url + "index927_2.aspx", "/", "");
            this.CteateHTML(url + "wap/index927.aspx", "/wap/","");
            InText.AlertAndRedirect("生成成功！", Request.Url.ToString());//刷新当前页
        }


        //重新生成右侧
        protected void btnUpdateSide_Click(object sender, EventArgs e)
        {
            //生成右侧
            CommonMethod.CteateHTML(url + "template/Side_2.aspx", "", "/userControl/Side_2.html");
            InText.AlertAndRedirect("生成成功！", Request.Url.ToString());//刷新当前页
        }

        //重新生成404
        protected void btnUpdate404_Click(object sender, EventArgs e)
        {
            //生成404
            CommonMethod.CteateHTML(url + "template/404.aspx", "", "/404.html");
            InText.AlertAndRedirect("生成成功！", Request.Url.ToString());//刷新当前页
        }

        //生成sitemap
        protected void btnSitemap_Click(object sender, EventArgs e)
        {
            string site = "http://www.up927.com" + "\r\n";
            string sql = "";
            DataTable dt = new DataTable();

            sql = "select id from t_article_type ";
            dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    site += "http://www.up927.com/list.aspx?at=" + dt.Rows[i]["id"].ToString() + "\r\n";
                }
            }

            sql = "select top 20 id from t_tag where article_num<>0 order by article_num desc ";
            dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    site += "http://www.up927.com/list.aspx?tag=" + dt.Rows[i]["id"].ToString() + "\r\n";
                }
            }

            sql = "select html from t_article order by update_date DESC ";
            dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    site += "http://www.up927.com" + dt.Rows[i]["html"].ToString() + "\r\n";
                }
            }
            FileStream fs = new FileStream(HttpContext.Current.Server.MapPath("/sitemap.txt"), FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("UTF-8"));
            //开始写入
            sw.Write(site);
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
            InText.AlertAndRedirect("生成成功！", Request.Url.ToString());//刷新当前页
        }

        #region 详细页生成静态页
        public void CteateHTML(string strurl, string path, string article_html)
        {
            StreamReader sr;
            StreamWriter sw;
            WebRequest HttpWebRequest = WebRequest.Create(strurl);
            WebResponse HttpWebResponse = HttpWebRequest.GetResponse();
            sr = new StreamReader(HttpWebResponse.GetResponseStream(), System.Text.Encoding.GetEncoding("utf-8"));//gb2312
            string strHtml = sr.ReadToEnd();
            //strurl = strurl.Substring(strurl.LastIndexOf("/") + 1);
            //strurl = strurl.Replace(".aspx", ".shtml");

            strHtml = strHtml.Replace("</form>", "");
            strHtml = Regex.Replace(strHtml, "<form[^>]*>", "");
            string savefile = HttpContext.Current.Server.MapPath(path) + article_html.Replace("/art/", "");//---------------
            if (articleId == 0)
            {
                savefile = HttpContext.Current.Server.MapPath(path) + "index.html";//生成首页
            }

            //编辑后台未登录状态下不能生成静态页
            if (strurl.Contains("很抱歉，没有找到您要访问的页面"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "<script type=\"text/javascript\">showResult('静态页未生成，请登录后重新操作！',false)</script>", false);
            }
            else
            {
                sw = new StreamWriter(savefile, false, System.Text.Encoding.GetEncoding("utf-8"));
                sw.WriteLine(strHtml);
                sw.Flush();
                sw.Close();
            }
        }
        #endregion

    }
}
