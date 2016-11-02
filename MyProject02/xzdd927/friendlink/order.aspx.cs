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
    public partial class order : System.Web.UI.Page
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



        private void BindList()
        {
            string sql = " Select id,link_name,link,link_order FROM t_friendlink  order by link_order";
            DataTable dt = artBll.SelectToDataTable(sql);
            this.ListBox1.DataSource = dt;
            this.ListBox1.DataValueField = "id";
            this.ListBox1.DataTextField = "link_name";
            this.ListBox1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "";
            int i = 0;
            foreach (ListItem li in ListBox1.Items)  //循环遍历
            {
                i++;
                sql = " update t_friendlink set link_order=" + i.ToString() + " where id=" + li.Value;
                artBll.ExecuteSQLNonquery(sql);
            }

            this.CteateHTML(url + "index927_2.aspx", "/", "");//重新生成首页

            this.BindList();
            InText.Alert("保存成功！");
        }

        protected void Button_First_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ListBox1.SelectedValue))
            {
                ListItem li = new ListItem(ListBox1.SelectedItem.Text, ListBox1.SelectedValue);
                ListBox1.Items.Remove(li);
                ListBox1.Items.Insert(0, li);
            }
            else
            {
                InText.Alert("请选择要排序的友链！");
            }
        }

        protected void Button_Before_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ListBox1.SelectedValue))
            {
                if (ListBox1.SelectedIndex > 0)
                {
                    ListItem li = new ListItem(ListBox1.SelectedItem.Text, ListBox1.SelectedValue);
                    ListBox1.Items[ListBox1.SelectedIndex].Text = ListBox1.Items[ListBox1.SelectedIndex - 1].Text;
                    ListBox1.Items[ListBox1.SelectedIndex].Value = ListBox1.Items[ListBox1.SelectedIndex - 1].Value;
                    ListBox1.Items[ListBox1.SelectedIndex - 1].Text = li.Text;
                    ListBox1.Items[ListBox1.SelectedIndex - 1].Value = li.Value;
                    ListBox1.SelectedValue = li.Value;
                }
            }
            else
            {
                InText.Alert("请选择要排序的友链！");
            }
        }

        protected void Button_Next_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ListBox1.SelectedValue))
            {
                if (ListBox1.SelectedIndex < ListBox1.Items.Count - 1)
                {
                    ListItem li = new ListItem(ListBox1.SelectedItem.Text, ListBox1.SelectedValue);
                    ListBox1.Items[ListBox1.SelectedIndex].Text = ListBox1.Items[ListBox1.SelectedIndex + 1].Text;
                    ListBox1.Items[ListBox1.SelectedIndex].Value = ListBox1.Items[ListBox1.SelectedIndex + 1].Value;
                    ListBox1.Items[ListBox1.SelectedIndex + 1].Text = li.Text;
                    ListBox1.Items[ListBox1.SelectedIndex + 1].Value = li.Value;
                    ListBox1.SelectedValue = li.Value;
                }
            }
            else
            {
                InText.Alert("请选择要排序的友链！");
            }
        }

        protected void Button_End_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ListBox1.SelectedValue))
            {
                ListItem li = new ListItem(ListBox1.SelectedItem.Text, ListBox1.SelectedValue);
                ListBox1.Items.Remove(li);
                ListBox1.Items.Insert(ListBox1.Items.Count, li);
            }
            else
            {
                InText.Alert("请选择要排序的友链！");
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
            string savefile =  HttpContext.Current.Server.MapPath(path) + "index.html";//生成首页

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
