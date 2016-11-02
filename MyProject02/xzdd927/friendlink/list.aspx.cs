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

namespace MyProject02.xzdd927.friendlink
{
    public partial class list : System.Web.UI.Page
    {
        int adminId = 0;//编辑ID
        string url = @ConfigurationManager.AppSettings["url"].ToString();

        ArtBll artBll = new ArtBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            adminId = new AdminMethod().CheckAdminLogin();//-----------------------------

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
            int pageSize = 20;//pager.PageSize;//每页显示20条信息
            int totalRecord = 0;

            if (!string.IsNullOrEmpty(Request.QueryString["p"]) && MetarnetRegex.IsNumeric(Request.QueryString["p"]))
            {
                pageIndex = Convert.ToInt32(InText.SafeSql(InText.SafeStr(Request.QueryString["p"].ToString())));
            }

            string strSql = " Select id,link_name,link,link_order " + " ,row_number() over(order by t_friendlink.id asc) as rowNumber FROM t_friendlink ";
            DataTable dt = artBll.ExecutePager(strSql, pageSize, pageIndex, ref totalRecord);
            if (dt.Rows.Count > 0)
            {
                ifOk = true;

                pager.PageSize = pageSize;
                pager.RecordCount = totalRecord;
                this.repList.DataSource = dt;
                this.repList.DataBind();

                //this.labInfoCount.Text = totalRecord.ToString();

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

        //添加按钮
        protected void imgBtn_Click(object sender, ImageClickEventArgs e)
        {
            int order = 0;
            string sql = "select max(link_order) as maxOrder from t_friendlink";
            DataTable dtMaxOrder = artBll.SelectToDataTable(sql);
            if (dtMaxOrder.Rows.Count > 0)
            {
                order = Convert.ToInt32(dtMaxOrder.Rows[0]["maxOrder"]) + 1;
            }

            string name = InText.SafeSql(InText.SafeStr(this.txtAddLinkName.Value));
            string link = InText.SafeSql(InText.SafeStr(this.txtAddLink.Value));
            if (name.Trim() != "" && link.Trim()!="")
            {
                sql = string.Format("insert into t_friendlink (link_name,link,link_order,update_date) values ('{0}','{1}',{2},getdate())", name, link, order);

                if (artBll.ExecuteSQLNonquery(sql))
                {
                    this.CteateHTML(url + "index927_2.aspx", "/", "");//重新生成首页
                    InText.AlertAndRedirect("添加成功！", Request.Url.ToString());//刷新当前页
                }
            }
        }

        //更新/删除一条分类名称
        protected void repList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.CommandName == "Update")
                {
                    string id = this.hidUpdateId.Value;//分类ID
                    string name = this.hidUpdateName.Value;//分类名称
                    string link = this.hidUpdateLink.Value;//分类关键词

                    if (name.Trim() != "" && link.Trim() != "")
                    {
                        string sql = "update t_friendlink set link_name='" + name + "',link='" + link + "' where id=" + id;

                        if (artBll.ExecuteSQLNonquery(sql))
                        {
                            this.CteateHTML(url + "index927_2.aspx", "/", "");//重新生成首页
                            InText.AlertAndRedirect("修改成功！", Request.Url.ToString());//刷新当前页
                        }
                    }
                }
                if (e.CommandName == "Delete")
                {
                    string sql = "delete from t_friendlink where id=" + e.CommandArgument.ToString();

                    if (artBll.ExecuteSQLNonquery(sql))
                    {
                        this.CteateHTML(url + "index927_2.aspx", "/", "");//重新生成首页
                        InText.AlertAndRedirect("删除成功！", Request.Url.ToString());//刷新当前页
                    }
                }
            }
        }

        #region 生成静态页

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
            string savefile = HttpContext.Current.Server.MapPath(path) + "index.html";//生成首页

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
