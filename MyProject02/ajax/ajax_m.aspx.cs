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
using Newtonsoft.Json;
using MyProject02.App_Code;

namespace MyProject02.ajax
{
    public partial class ajax_m : System.Web.UI.Page
    {
        private int get = 2;//执行哪个方法

        //AccessBll accessBll = new AccessBll();
        ArtBll artBll = new ArtBll();
        UserBll userBll = new UserBll();
        UserMethod userMethod = new UserMethod();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["get"]))
            {
                get = Utils.CheckInt(Request.QueryString["get"].ToString());
            }

            if (get == 1)//查询标签名称
            {
                SelectTag();
            }
            if (get == 2)//测试json
            {
                TestJson();
            }
            if (get == 22)
            {
                TestJSONP();//测试jsonp
            }
            if (get == 3)
            {
                register();//注册用户
            }
            if (get == 4)
            {
                ValidUsername();//查询用户名是否已存在
            }
            if (get == 5)
            {
                SelectEmailExist();//查询邮箱是否已存在
            }
            if (get == 6)
            {
                Login();//登录
            }
            if (get == 7)
            {
                GetUserInfoHead();//获取用户信息（头部head_top.html文件用）
            }
            if (get == 8)
            {
                LogOut();//退出登录
            }
        }

        #region 查询标签名称

        private void SelectTag()
        {
            string returnStr = "未查到相关标签";
            string tag = "";
            if (!string.IsNullOrEmpty(Request.QueryString["tag"]))
            {
                tag = InText.SafeStr(InText.SafeSql(Request.QueryString["tag"].ToString()));
            }
            if (tag.Trim() != "")
            {
                String sql = "select * from t_tag where tag_name like '%" + tag + "%' ";
                DataTable dt = artBll.SelectToDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    returnStr = "<ul>";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        returnStr += "<li><a href='javascript:void(0)' onclick='SetTag(\"" + dt.Rows[i]["tag_name"].ToString() + "\")'>" + dt.Rows[i]["tag_name"].ToString() + "</a></li>";
                    }
                    returnStr += "</ul>";
                }
            }
            Response.Write(returnStr);
        }
        #endregion

        #region 测试json

        private void TestJson()
        {
            StringWriter sw = new StringWriter();
            JsonWriter writer = new JsonTextWriter(sw);

            //writer.writest
            
            writer.WriteStartArray();

            writer.WriteStartObject();
            writer.WritePropertyName("name");
            writer.WriteValue("王晓明");
            writer.WritePropertyName("age");
            writer.WriteValue("95");
            writer.WriteEndObject();
            writer.Flush();

            writer.WriteStartObject();
            writer.WritePropertyName("name");
            writer.WriteValue("王晓明1");
            writer.WritePropertyName("age");
            writer.WriteValue("951");
            writer.WriteEndObject();
            writer.Flush();

            writer.WriteEndArray();

            string jsonText = sw.GetStringBuilder().ToString();
            //string aaa = "[{\"name\":\"王晓明\",\"age\":\"95\"},{\"name\":\"王晓明1\",\"age\":\"951\"}]";
            Response.Write("{\"man\":"+jsonText+"}");
        }
        #endregion

        #region 测试jsonp

        private void TestJSONP()
        {
            string cb = "";
            if (!string.IsNullOrEmpty(Request.QueryString["cb"]))
            {
                cb = InText.SafeStr(Request.QueryString["cb"].ToString());
            }

            StringWriter sw = new StringWriter();
            JsonWriter writer = new JsonTextWriter(sw);

            //writer.writest

            writer.WriteStartArray();

            writer.WriteStartObject();
            writer.WritePropertyName("name");
            writer.WriteValue("王晓明");
            writer.WritePropertyName("age");
            writer.WriteValue("95");
            writer.WriteEndObject();
            writer.Flush();

            writer.WriteStartObject();
            writer.WritePropertyName("name");
            writer.WriteValue("王晓明1");
            writer.WritePropertyName("age");
            writer.WriteValue("951");
            writer.WriteEndObject();
            writer.Flush();

            writer.WriteEndArray();

            string jsonText = sw.GetStringBuilder().ToString();
            //string aaa = "[{\"name\":\"王晓明\",\"age\":\"95\"},{\"name\":\"王晓明1\",\"age\":\"951\"}]";
            string retrunStr="{\"man\":" + jsonText + "}";
            if(cb.Trim()!="")
            {
                retrunStr=cb+"("+retrunStr+")";
            }
            Response.Write(retrunStr);
        }
        #endregion

        #region 注册用户

        private void register()
        {
            string username = "";
            if (!string.IsNullOrEmpty(HttpContext.Current.Request["username"]))
            {
                username = InText.SafeSql(InText.SafeStr(HttpContext.Current.Request["username"]));
            }
            string pwd = "";
            if (!string.IsNullOrEmpty(HttpContext.Current.Request["pwd"]))
            {
                pwd = Utils.Encrypt(InText.SafeSql(InText.SafeStr(HttpContext.Current.Request["pwd"])));
            }
            string email = "";
            if (!string.IsNullOrEmpty(HttpContext.Current.Request["email"]))
            {
                email = InText.SafeSql(InText.SafeStr(HttpContext.Current.Request["email"]));
            }
            int sex = 2;
            if (!string.IsNullOrEmpty(HttpContext.Current.Request["sex"]))
            {
                sex = Utils.CheckInt(HttpContext.Current.Request["sex"]);
            }
            int baby = 2;
            if (!string.IsNullOrEmpty(HttpContext.Current.Request["baby"]))
            {
                baby = Utils.CheckInt(HttpContext.Current.Request["baby"]);
            }
            DateTime baby_date = DateTime.Now;
            if (!string.IsNullOrEmpty(HttpContext.Current.Request["baby_date"]))
            {
                baby_date =Convert.ToDateTime(HttpContext.Current.Request["baby_date"]);
            }
            string remark = "";
            if (!string.IsNullOrEmpty(HttpContext.Current.Request["remark"]))
            {
                remark = InText.SafeSql(InText.SafeStr(HttpContext.Current.Request["remark"]));
            }

            int result = userBll.Add_User(username,pwd,email,sex,baby,baby_date,remark);

            StringWriter sw = new StringWriter();
            Newtonsoft.Json.JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(sw);

            if (result > 0)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("status");
                writer.WriteValue("200");
                writer.WritePropertyName("newid");
                writer.WriteValue(result.ToString());
                writer.WriteEndObject();
                writer.Flush();
            }
            else
            {
                writer.WriteStartObject();
                writer.WritePropertyName("status");
                writer.WriteValue("500");
                writer.WriteEndObject();
                writer.Flush();
            }
            string jsonText = sw.GetStringBuilder().ToString();
            Response.Write(jsonText);
        }
        #endregion

        #region 查询用户名是否已存在

        private void ValidUsername()
        {
            string username = "";
            if (!string.IsNullOrEmpty(HttpContext.Current.Request["username"]))
            {
                username = InText.SafeSql(InText.SafeStr(HttpContext.Current.Request["username"]));
            }
            int result = userBll.SelectUsernameExist(username);

            StringWriter sw = new StringWriter();
            Newtonsoft.Json.JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(sw);

            if (result == 0)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("status");
                writer.WriteValue("200");
                writer.WriteEndObject();
                writer.Flush();
            }
            else
            {
                writer.WriteStartObject();
                writer.WritePropertyName("status");
                writer.WriteValue("500");
                writer.WriteEndObject();
                writer.Flush();
            }
            string jsonText = sw.GetStringBuilder().ToString();
            Response.Write(jsonText);
        }
        #endregion

        #region 查询邮箱是否已存在

        private void SelectEmailExist()
        {
            string email = "";
            if (!string.IsNullOrEmpty(HttpContext.Current.Request["email"]))
            {
                email = InText.SafeSql(InText.SafeStr(HttpContext.Current.Request["email"]));
            }
            int result = userBll.SelectEmailExist(email);

            StringWriter sw = new StringWriter();
            Newtonsoft.Json.JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(sw);

            if (result == 0)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("status");
                writer.WriteValue("200");
                writer.WriteEndObject();
                writer.Flush();
            }
            else
            {
                writer.WriteStartObject();
                writer.WritePropertyName("status");
                writer.WriteValue("500");
                writer.WriteEndObject();
                writer.Flush();
            }
            string jsonText = sw.GetStringBuilder().ToString();
            Response.Write(jsonText);
        }
        #endregion

        #region 登录

        private void Login()
        {
            //string username = "";
            //if (!string.IsNullOrEmpty(HttpContext.Current.Request["username"]))
            //{
            //    username = InText.SafeSql(InText.SafeStr(HttpContext.Current.Request["username"]));
            //}
            //string pwd = "";
            //if (!string.IsNullOrEmpty(HttpContext.Current.Request["pwd"]))
            //{
            //    pwd = InText.SafeSql(InText.SafeStr(HttpContext.Current.Request["pwd"]));
            //    //pwd = WebBasic.Encryption.Encrypt(pwd);
            //    pwd = Utils.Encrypt(pwd);
            //}
            string username = "";
            if (!string.IsNullOrEmpty(HttpContext.Current.Request["username"]))
            {
                username = InText.SafeSql(InText.SafeStr(HttpContext.Current.Request.Form["username"]));
            }
            string pwd = "";
            if (!string.IsNullOrEmpty(HttpContext.Current.Request["pwd"]))
            {
                pwd = InText.SafeSql(InText.SafeStr(HttpContext.Current.Request.Form["pwd"]));
                //pwd = WebBasic.Encryption.Encrypt(pwd);
                pwd = Utils.Encrypt(pwd);
            }
            int valid_type = 1;//1、根据用户名判断  2、根据邮箱判断
            if(username.Contains("@"))
            {
                valid_type = 2;
            }
            int result = 0;
            if (userBll.SelectUsernameEmailExist(username) > 0)

            {
                int count = userBll.SelectUserPwdIsTrue(username, pwd, valid_type);
                if (count > 0)
                {
                    result = UserLogin(username);//执行登录，并返回登录结果
                }
                else
                {
                    result = 2;//用户名或密码错误
                }
            }
            else
            {
                result = 4;//用户名不存在
            }
            StringWriter sw = new StringWriter();
            Newtonsoft.Json.JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(sw);

            writer.WriteStartObject();
            writer.WritePropertyName("status");
            writer.WriteValue("200");
            writer.WritePropertyName("result");
            writer.WriteValue(result.ToString());
            writer.WriteEndObject();
            writer.Flush();

            string jsonText = sw.GetStringBuilder().ToString();
            Response.Write(jsonText);
        }
        #endregion

        #region 用户登录
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="username"></param>
        public int UserLogin(string username)
        {
            int result = 0;
            DataTable dt = userBll.SelectUserInfo(username);
            if (dt.Rows.Count > 0)
            {
                int uid = Convert.ToInt32(dt.Rows[0]["uid"].ToString());
                string username1 = dt.Rows[0]["username"].ToString();
                string loginIP = WebBasic.Text.Info.GetIP();
                if (dt.Rows[0]["is_lock"].ToString() != "1")//账号被锁定
                {
                    //先退出登录
                    userMethod.UserAbandon();

                    //----将信息保存到Session----
                    Session["uid"] = dt.Rows[0]["uid"].ToString();
                    Session["username"] = dt.Rows[0]["username"].ToString();
                    Session["email"] = dt.Rows[0]["email"].ToString();

                    //----将信息保存到Cookie----
                    HttpCookie hc = new HttpCookie("UserInfo_up927");
                    hc.Values["uid"] = dt.Rows[0]["uid"].ToString();
                    hc.Values["username"] = HttpUtility.UrlEncode(dt.Rows[0]["username"].ToString());
                    hc.Values["pwd"] = Utils.Encrypt(dt.Rows[0]["pwd"].ToString());//密码再次加密
                    hc.Values["email"] = dt.Rows[0]["email"].ToString();
                    hc.Values["usertype"] = dt.Rows[0]["usertype"].ToString(); ;//用户类别：1、普通用户   2、商家
                    hc.Expires = DateTime.Now.AddDays(3);

                    //if (cookie_domain != "")
                    //{
                    //    hc.Domain = cookie_domain;
                    //}
                    //if (this.chk_long.Checked == true)
                    //{
                    //    hc.Expires = DateTime.Now.AddDays(7);//长期登录
                    //}

                    Response.Cookies.Add(hc);
                    result = 1;//登录成功
                }
                else
                {
                    result = 3;//该用户已被锁定
                }
            }
            return result;
        }
        #endregion

        #region 获取用户信息（头部head_top.html文件用）

        private void GetUserInfoHead()
        {
            StringWriter sw = new StringWriter();
            Newtonsoft.Json.JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(sw);

            string username = userMethod.CheckUserIndentity_Username();
            if (username.Trim() != "")
            {
                writer.WriteStartObject();
                writer.WritePropertyName("status");
                writer.WriteValue("200");
                writer.WritePropertyName("username");
                writer.WriteValue(username);
                writer.WriteEndObject();
                writer.Flush();
            }
            else
            {
                writer.WriteStartObject();
                writer.WritePropertyName("status");
                writer.WriteValue("200");
                writer.WritePropertyName("username");
                writer.WriteValue("");
                writer.WriteEndObject();
                writer.Flush();
            }
            string jsonText = sw.GetStringBuilder().ToString();
            Response.Write(jsonText);
        }
        #endregion

        #region 退出登录

        private void LogOut()
        {
            //退出登录
            userMethod.UserAbandon();
        }
        #endregion

    }
}
