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

namespace MyProject02.xzdd927
{
    public partial class login : System.Web.UI.Page
    {
        ArtBll artBll = new ArtBll();

        string cookie_domain = System.Configuration.ConfigurationManager.AppSettings["Cookie_Domain"].ToString();//Cookie_Domain

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (!ValidCheckCode())
            {
                return;
            }

            int ifOk = 0;

            string name = this.txtLoginName.Value;
            string pwd = WebBasic.Encryption.Encrypt(this.txtPassword.Value);
            String sql = string.Format("select * from t_admin where name='{0}' and pwd='{1}'",name,pwd);
            DataTable dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                //将后台人员信息保存至session
                Session["adminId"] = dt.Rows[0]["id"].ToString();
                Session["login_name"] = dt.Rows[0]["name"].ToString();
                Session["pwd"] = WebBasic.Encryption.Encrypt(dt.Rows[0]["pwd"].ToString());

                //----将信息保存到Cookie----
                HttpCookie hc = new HttpCookie("Cookie_admin");
                hc.Values["adminId"] = HttpUtility.UrlEncode(dt.Rows[0]["id"].ToString());
                hc.Values["login_name"] = HttpUtility.UrlEncode(dt.Rows[0]["name"].ToString());
                hc.Values["pwd"] = WebBasic.Encryption.Encrypt(dt.Rows[0]["pwd"].ToString());//密码再次加密

                if (cookie_domain != "")
                {
                    hc.Domain = cookie_domain;
                }
                hc.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(hc);

                Response.Redirect("/xzdd927/index.aspx");
            }
            else
            {
                //InText.AlertAndRedirect("用户名或密码错误！", Request.Url.ToString());//刷新当前页
                Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "key", "<script type=\"text/javascript\">layer.alert('用户名或密码错误');</script>");
            }
        }

        private bool ValidCheckCode()
        {

            bool isOk = false;

            string checkcode = this.txt_checkCode.Value;

            string returnStr = "";
            if (Session["rndcode"] != null)
            {
                if (Session["rndcode"].ToString().ToLower() != checkcode.ToLower())
                {
                    //InText.Alert("验证码错误");//验证码错误！
                    Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "key", "<script type=\"text/javascript\">layer.alert('验证码错误');</script>");
                    //HttpContext.Current.Response.Write(" <script language = javascript>layer.alert('验证码错误');</script> ");
                }
                else
                {
                    isOk = true;
                }
            }
            else
            {
                //InText.Alert("请更换验证码重试");//Session为null！
                Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "key", "<script type=\"text/javascript\">layer.alert('请更换验证码重试');</script>");
            }
            return isOk;
        }

    }
}
