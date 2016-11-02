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
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using WebBasic.Text;
using WebBasic.Info;

namespace MyProject02.test
{
    public partial class Delegate01 : System.Web.UI.Page
    {
        public delegate void GetInfoDelegate();//委托，查询信息

        public string result
        {
            get
            {
                Object obj = this.ViewState["result"];
                if (obj != null)
                {
                    return (string)ViewState["result"];
                }
                else
                {
                    return "sdsd";
                }
            }
            set
            {
                ViewState["result"] = value;
            }
        }
        string keyword = "";
        string url = "";

        string baidu = "http://www.baidu.com/s?wd=";
        string html = "";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //查询信息


                GetInfoDelegate clDel = new GetInfoDelegate(this.GetInfo);

                AsyncCallback callBackClose = new AsyncCallback(GetReturn);
                clDel.BeginInvoke(callBackClose, null);// 异步调用方法,查询信息
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                InText.AlertAndRedirect("执行成功!", Request.Url.AbsoluteUri);
            }
        }

        #region 查询信息的回调函数，当异步调用的方法执行完后执行

        private void GetReturn(IAsyncResult asyncResult)
        {
            AsyncResult asyncresult = (AsyncResult)asyncResult;
            GetInfoDelegate del = (GetInfoDelegate)asyncresult.AsyncDelegate;
            del.EndInvoke(asyncResult);

            //InText.Alert(result);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "<script>alert(" + result + ")</script>", false);
            //Response.Write(result);
        }
        #endregion


        private void GetInfo()
        {
            result = "";
            keyword = this.txt_keyword.Value;
            url = this.txt_url.Value; //www.beibeidai.com/

            url = url.Replace("http://", "");
            url = url.Substring(url.IndexOf("."), url.Length - url.IndexOf("."));
            if (url.Contains("/"))
            {
                url = url.Substring(0, url.IndexOf("/"));
            }


            result += GetPaiming(0, 50);
            result += GetPaiming(51, 100);
            result += GetPaiming(101, 150);
            result += GetPaiming(151, 200);
            result += GetPaiming(201, 250);
            result += GetPaiming(251, 300);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "<script>alert(" + result + ")</script>", false);
            //HttpContext.Current.Response.Write(result);
        }

        public string GetPaiming(int beginNum, int endNum)
        {
            int count = 0;

            int pn = beginNum;

            html = baidu + HttpUtility.HtmlEncode(keyword) + "&pn=" + pn.ToString() + "&rn=50";
            if (beginNum == 0)
            {
                beginNum = 1;
            }
            string returnStr = "<div class='paiming'><b>" + beginNum + "-" + endNum + "位：</b>";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(html);
            //request.UserAgent = "Mozilla/5.0+(compatible;+Googlebot/2.1;++http://www.google.com/bot.html)"; //google
            //request.UserAgent = "Baiduspider+(+http://www.baidu.com/search/spider.htm";//baidu //--------------
            WebResponse response = request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(resStream, Encoding.GetEncoding("utf-8"));
            string code = sr.ReadToEnd();
            resStream.Close();
            sr.Close();

            //InText.Alert(code);
            string str = code.ToLower();
            int begin = str.IndexOf("<div id=\"content_left\">");
            int end = str.IndexOf("<div id=\"rs\">") - str.IndexOf("<div id=\"content_left\">");
            str = str.Substring(begin, end);
            //str = str.Substring(str.IndexOf("<div id=\"content_left\">"), str.IndexOf("<div id=\"rs\">") - str.IndexOf("<div class=\"clear\" id=\"content_left\">"));

            //标题和url
            StringBuilder sb = new StringBuilder();
            MatchCollection collectTitle = Regex.Matches(str, "<div class=\"f13\">.*?</div>", RegexOptions.Multiline);
            if (collectTitle.Count > 0)
            {
                foreach (Match mT in collectTitle)
                {
                    string url1 = Regex.Match(mT.ToString(), "<span class=\"g\">(.|\n)*?</span>", RegexOptions.Multiline).ToString();
                    url1 = Regex.Replace(url1, "<(.[^>]*)>", "").Replace("，", "").Trim();

                    if (url1.Contains(url) || url1.Replace("/", "").Contains(url.Substring(1, url.Length - 1)))
                    {
                        string paimingStr = mT.ToString().Substring(mT.ToString().IndexOf("<div class=\"c-tools\" id=\""), mT.ToString().IndexOf("\" data-tools=") - mT.ToString().IndexOf("<div class=\"c-tools\" id=\""));
                        string[] paimingArray = paimingStr.Split('_');
                        string paiming = paimingArray[2];//得到排名

                        if (count < 25)
                        {
                            returnStr += paiming + "名 ";
                        }
                        count += 1;
                    }
                }
            }

            //pn += 50;


            if (count == 0)
            {
                returnStr += "没有排名";
            }
            else if (count >= 25)
            {
                returnStr += "...";
            }

            if (count > 0)
            {
                returnStr += "&nbsp;<a href='" + html + "' target='_blank'>查看</a>";
            }
            returnStr += "</div>";

            return returnStr;
        }

    }
}
