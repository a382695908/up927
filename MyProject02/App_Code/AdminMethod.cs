using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BLL;
using WebBasic;
using WebBasic.Text;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace MyProject02.App_Code
{
    public class AdminMethod
    {
        //AccessBll accessBll = new AccessBll();
        ArtBll artBll = new ArtBll();

        /// <summary>
        /// 验证后台人员是否登录
        /// </summary>
        /// <returns></returns>
        //public int CheckAdminLogin()
        //{
        //    if (HttpContext.Current.Session["adminId"] == null || HttpContext.Current.Session["adminId"].ToString() == "")//先判断Session是否为空
        //    {
        //        HttpContext.Current.Response.Redirect("/xzdd927/login.html");
        //        return 0;
        //    }
        //    else //Session不为空，直接从Session取值
        //    {
        //        return Convert.ToInt32(HttpContext.Current.Session["adminId"]);
        //    }
        //}

        /// <summary>
        /// 验证后台人员是否登录，未登录跳转登陆页
        /// </summary>
        /// <returns></returns>
        public int CheckAdminLogin()
        {
            if (HttpContext.Current.Session["adminId"] == null || Convert.ToString(HttpContext.Current.Session["adminId"]) == "")//先判断Session是否为空
            {

                if (HttpContext.Current.Request.Cookies["Cookie_admin"] != null)//若Session为空则判断Cookie是否为空
                {
                    if (ValidPassword())//验证cookie里的密码是否正确
                    {
                        InsertSessionByCookie();//若Cookie不为空，则从Cookie为Session赋值
                        return Convert.ToInt32(HttpContext.Current.Session["adminId"]);//返回后台人员ID
                    }
                    else
                    {
                        //string url = "/xzdd927/login.html";
                        //HttpContext.Current.Response.Redirect(url);
                        HttpContext.Current.Response.Write(" <script language = javascript> window.top.location = '/xzdd927/login.html'</script> ");
                        return 0;
                    }
                }
                else //若Cookie也为空，返回-1
                {
                    string url = "/xzdd927/login.html";
                    HttpContext.Current.Response.Redirect(url);
                    return 0;
                }
            }
            else //Session不为空，直接从Session取值
            {
                return Convert.ToInt32(HttpContext.Current.Session["adminId"]);//返回后台人员ID
            }
            //return 1;
        }

        /// <summary>
        /// 验证后台人员是否登录，未登录不跳转
        /// </summary>
        /// <returns></returns>
        public int CheckAdminLogin1()
        {
            if (HttpContext.Current.Session["adminId"] == null || Convert.ToString(HttpContext.Current.Session["adminId"]) == "")//先判断Session是否为空
            {

                if (HttpContext.Current.Request.Cookies["Cookie_admin"] != null)//若Session为空则判断Cookie是否为空
                {
                    if (ValidPassword())//验证cookie里的密码是否正确
                    {
                        InsertSessionByCookie();//若Cookie不为空，则从Cookie为Session赋值
                        return Convert.ToInt32(HttpContext.Current.Session["adminId"]);//返回后台人员ID
                    }
                    else
                    {
                        return 0;
                    }
                }
                else //若Cookie也为空，返回-1
                {
                    return 0;
                }
            }
            else //Session不为空，直接从Session取值
            {
                return Convert.ToInt32(HttpContext.Current.Session["adminId"]);//返回后台人员ID
            }
        }

        /// <summary>
        /// 验证cookie里的公司账户密码是否正确
        /// </summary>
        /// <returns></returns>
        public bool ValidPassword()
        {
            HttpCookie hc = HttpContext.Current.Request.Cookies["Cookie_admin"];
            string username = HttpUtility.UrlDecode(hc.Values["login_name"].ToString());
            string password = hc.Values["pwd"];

            if (!string.IsNullOrEmpty(password))
            {
                password = WebBasic.Encryption.Decrypt(password);//解密，得到原先加密后的密码(数据库中保存的密码)
                String sql = string.Format("select * from t_admin where name='{0}' and pwd='{1}'", username, password);
                DataTable dt = artBll.SelectToDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else //密码错误
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 从Cookie为Session赋值
        /// </summary>
        private void InsertSessionByCookie()
        {
            HttpCookie hc = HttpContext.Current.Request.Cookies["Cookie_admin"];
            HttpContext.Current.Session["adminId"] = hc.Values["adminId"];
            HttpContext.Current.Session["login_name"] = HttpUtility.UrlDecode(hc.Values["login_name"].ToString());
            HttpContext.Current.Session["pwd"] = WebBasic.Encryption.Encrypt(hc.Values["pwd"].ToString());
        }

        //账户退出登录
        public void Logout(string url)
        {
            /*----先将Session清空----*/
            HttpContext.Current.Session["adminId"] = null;
            HttpContext.Current.Session["login_name"] = null;
            HttpContext.Current.Session["pwd"] = null;
            HttpContext.Current.Session.Abandon();

            /*----再将Cookie清空----*/
            if (HttpContext.Current.Response.Cookies["Cookie_admin"] != null)
            {
                HttpContext.Current.Response.Cookies["Cookie_admin"].Domain = System.Configuration.ConfigurationManager.AppSettings["Cookie_Domain"].ToString();
                HttpContext.Current.Response.Cookies["Cookie_admin"].Expires = DateTime.Now.AddDays(-31);
            }

            //Utils.ClearUserCookie("dnt");//论坛同步退出登录

            /*----跳转登陆页----*/
            if (url != "")
                HttpContext.Current.Response.Redirect(HttpContext.Current.Server.UrlDecode(url));
            else
                HttpContext.Current.Response.Write(" <script language = javascript> window.top.location = '/xzdd927/login.html'</script> ");
        }

    }
}
