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
    public class UserMethod
    {
        
        //用户退出登录
        public void UserAbandon()
        {
            /*----先将Session清空----*/
            HttpContext.Current.Session["uid"] = null;
            HttpContext.Current.Session["username"] = null;
            HttpContext.Current.Session["pwd"] = null;
            HttpContext.Current.Session["email"] = null;
            HttpContext.Current.Session.Abandon();

            /*----再将Cookie清空----*/
            if (HttpContext.Current.Response.Cookies["UserInfo_up927"] != null)
            {
                //HttpContext.Current.Response.Cookies["UserInfo_up927"].Domain = System.Configuration.ConfigurationManager.AppSettings["Cookie_Domain"].ToString();
                HttpContext.Current.Response.Cookies["UserInfo_up927"].Expires = DateTime.Now.AddDays(-31);
            }
        }

        /// <summary>
        /// 判断用户是否登录，返回用户ID
        /// </summary>
        /// <returns></returns>
        public int CheckUserIndentity_ID()
        {
            if (HttpContext.Current.Request.Cookies["UserInfo_up927"] != null)//若Session为空则判断Cookie是否为空
            {
                if (ValidPassword())//验证cookie里的密码是否正确
                {
                    InsertSessionByCookie();//若Cookie不为空，则从Cookie为Session赋值
                    return Convert.ToInt32(HttpContext.Current.Session["uid"]);//返回用户ID
                }
                else
                {
                    return -1;
                }
            }
            else //若Cookie也为空，返回-1
            {
                return -1;
            }
        }

        /// <summary>
        /// 判断用户是否登录，返回用户名///////////////////
        /// </summary>
        /// <returns></returns>
        public string CheckUserIndentity_Username()
        {
            if (HttpContext.Current.Request.Cookies["UserInfo_up927"] != null)//若Session为空则判断Cookie是否为空
            {
                if (ValidPassword())//验证cookie里的密码是否正确
                {
                    InsertSessionByCookie();//若Cookie不为空，则从Cookie为Session赋值
                    return HttpContext.Current.Session["username"].ToString();//返回用户ID
                }
                else
                {
                    return "";
                }
            }
            else //若Cookie也为空，返回""
            {
                return "";
            }
        }

        /// <summary>
        /// 从Cookie为Session赋值
        /// </summary>
        private void InsertSessionByCookie()
        {
            HttpCookie hc = HttpContext.Current.Request.Cookies["UserInfo_up927"];
            HttpContext.Current.Session["uid"] = hc.Values["uid"];
            HttpContext.Current.Session["username"] = HttpUtility.UrlDecode(hc.Values["username"].ToString());
            HttpContext.Current.Session["pwd"] = hc.Values["pwd"];
            HttpContext.Current.Session["email"] = hc.Values["email"];
            HttpContext.Current.Session["usertype"] = hc.Values["usertype"];

            hc.Expires = DateTime.Now.AddHours(1);
        }

        /// <summary>
        /// 验证cookie里的密码是否正确
        /// </summary>
        /// <returns></returns>
        public bool ValidPassword()
        {
            HttpCookie hc = HttpContext.Current.Request.Cookies["UserInfo_up927"];
            string username = HttpUtility.UrlDecode(hc.Values["username"].ToString());
            string email = hc.Values["email"];
            string password = hc.Values["pwd"];

            if (!string.IsNullOrEmpty(password))
            {
                password = Utils.Decrypt(password);//解密，得到原先加密后的密码(数据库中保存的密码)
                UserBll userBll = new UserBll();
                int result = userBll.SelectUserPwdIsTrue(username, password, 1);
                //int result = 1;//--------------------------
                if (result == 1)//密码正确
                {
                    return true;
                }
                else //用户名/邮箱/手机号不存在 或 密码错误
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            //return false;
        }

    }
}
