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

namespace MyProject02.xzdd927.ajax
{
    public partial class ajax_m : System.Web.UI.Page
    {
        ArtBll artBll = new ArtBll();

        private int get = 2;//执行哪个方法

        string cookie_domain = System.Configuration.ConfigurationManager.AppSettings["Cookie_Domain"].ToString();//Cookie_Domain
        string returnFailed = "{\"result\":\"failed\"}";//失败/错误时返回值

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request["g"]))
            {
                get = Utils.CheckInt(HttpContext.Current.Request["g"]);
            }
            //if (!string.IsNullOrEmpty(HttpContext.Current.Request.Form["g"]))
            //{
            //    get = Utils.CheckInt(HttpContext.Current.Request.Form["g"]);
            //}

            if (get == 1)//后台登录
            {
                LoginManage();
            }
        }

        private void LoginManage()
        {
            StringWriter sw = new StringWriter();
            Newtonsoft.Json.JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(sw);

            int code_result = ValidCheckCode();//检测验证码：1、成功  2、验证码错误  3、请更换验证码重试
            if (code_result == 1)
            {
                string name = "";
                if (!string.IsNullOrEmpty(HttpContext.Current.Request["name"]))
                {
                    name = InText.SafeSql(HttpContext.Current.Request["name"]);
                }
                string pwd = "";
                if (!string.IsNullOrEmpty(HttpContext.Current.Request["pwd"]))
                {
                    pwd = WebBasic.Encryption.Encrypt(InText.SafeSql(HttpContext.Current.Request["pwd"]));
                }

                String sql = string.Format("select * from t_admin where name='{0}' and pwd='{1}'", name, pwd);
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

                    //writer.WriteStartArray();
                    writer.WriteStartObject();
                    writer.WritePropertyName("result");
                    writer.WriteValue("success");
                    writer.WriteEndObject();
                    writer.Flush();
                    //writer.WriteEndArray();
                }
                else
                {
                    //writer.WriteStartArray();
                    writer.WriteStartObject();
                    writer.WritePropertyName("result");
                    writer.WriteValue("failed");
                    writer.WritePropertyName("message");
                    writer.WriteValue("用户名或密码错误");
                    writer.WriteEndObject();
                    writer.Flush();
                    //writer.WriteEndArray();
                }
            }
            else
            {
                //writer.WriteStartArray();
                writer.WriteStartObject();
                writer.WritePropertyName("result");
                writer.WriteValue("failed");
                writer.WritePropertyName("message");
                if (code_result == 2)
                {
                    writer.WriteValue("验证码错误");
                }
                else
                {
                    writer.WriteValue("请更换验证码重试");
                }
                writer.WriteEndObject();
                writer.Flush();
                //writer.WriteEndArray();
            }

            string jsonText = sw.GetStringBuilder().ToString();
            //jsonText = "{\"returnValue\":" + jsonText + "}";
            Response.Write(jsonText);
        }

        #region 检测验证码

        private int ValidCheckCode()
        {
            int result = 0;

            string checkcode = "";
            if (!string.IsNullOrEmpty(HttpContext.Current.Request["checkcode"]))
            {
                checkcode = InText.SafeSql(HttpContext.Current.Request["checkcode"]);
            }

            string returnStr = "";
            if (Session["rndcode"] != null)
            {
                if (Session["rndcode"].ToString().ToLower() != checkcode.ToLower())
                {
                    //验证码错误
                    result = 2;
                }
                else
                {
                    result = 1;
                }
            }
            else
            {
                //请更换验证码重试
                result = 3;
            }
            return result;
        }
        #endregion

    }
}
