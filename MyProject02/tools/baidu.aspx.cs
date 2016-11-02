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
using System.Net;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using WebBasic.Text;
using WebBasic.Info;
using System.Collections.Generic;

namespace MyProject02.tools
{
    public partial class baidu : System.Web.UI.Page
    {
        string keyword = "";
        string url = "";

        string baiduUrl = "http://www.baidu.com/s?wd=";
        string html = "";//http://www.baidu.com/s?wd=%E8%B4%9D%E8%B4%9D&pn=0&rn=100

        List<string> listPaiming = new List<string>();

        //public string result = "";
        //public string resultMore = "";

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
                    return "";
                }
            }
            set
            {
                ViewState["result"] = value;
            }
        }

        public string resultMore
        {
            get
            {
                Object obj = this.ViewState["resultMore"];
                if (obj != null)
                {
                    return (string)ViewState["resultMore"];
                }
                else
                {
                    return "";
                }
            }
            set
            {
                ViewState["resultMore"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void imgBtnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            result = "";
            resultMore = "";
            keyword = this.txt_keyword.Value;
            url = this.txt_url.Value; //www.beibeidai.com/

            url = url.Replace("http://", "");
            int cc = url.Split('.').Length - 1;
            if (cc <= 1)// beibeidai.com/
            {
                url = "." + url;
            }
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

            //result += GetPaiming(301, 350);
            //result += GetPaiming(351, 400);
            //result += GetPaiming(401, 450);
            //result += GetPaiming(451, 500);
            //result += GetPaiming(501, 550);
            //result += GetPaiming(551, 600);
            //result += GetPaiming(601, 650);
            //result += GetPaiming(651, 700);
            //result += GetPaiming(701, 750);
            //result += GetPaiming(751, 760);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "<script>document.getElementById('div_loading').style.display='none';document.getElementById('div_result').style.display='';</script>", false);
        }

        //“更多”按钮
        protected void linkBtnSubmit_Click(object sender, EventArgs e)
        {
            resultMore = "";
            keyword = this.txt_keyword.Value;
            url = this.txt_url.Value; //www.beibeidai.com/  .beibeidai.com/ beibeidai.com/

            url = url.Replace("http://", "");
            int cc = url.Split('.').Length - 1;
            if (cc <= 1)// beibeidai.com/
            {
                url = "." + url;
            }
            url = url.Substring(url.IndexOf("."), url.Length - url.IndexOf("."));//string.Split(char c).Length-1;
            if (url.Contains("/"))
            {
                url = url.Substring(0, url.IndexOf("/"));
            }

            resultMore += GetPaiming(301, 350);
            resultMore += GetPaiming(351, 400);
            resultMore += GetPaiming(401, 450);
            resultMore += GetPaiming(451, 500);
            resultMore += GetPaiming(501, 550);
            resultMore += GetPaiming(551, 600);
            resultMore += GetPaiming(601, 650);
            resultMore += GetPaiming(651, 700);
            resultMore += GetPaiming(701, 750);
            resultMore += GetPaiming(751, 760);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "<script>document.getElementById('div_loading').style.display='none';document.getElementById('linkBtnSubmit').style.display='none';document.getElementById('div_result').style.display='';</script>", false);
        }

        public string GetPaiming(int beginNum, int endNum)
        {
            int count = 0;

            int pn = beginNum;

            html = baiduUrl + HttpUtility.HtmlEncode(keyword) + "&pn=" + pn.ToString() + "&rn=50";
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
                    //string url1 = Regex.Match(mT.ToString(), "<span class=\"g\">(.|\n)*?</span>", RegexOptions.Multiline).ToString();
                    // url1 = Regex.Replace(url1, "<(.[^>]*)>", "").Replace("，", "").Trim();
                    string url1 = Regex.Replace(mT.ToString(), "<(.[^>]*)>", "").Replace("-&nbsp;", "").Replace("，", "").Replace("&nbsp;", "").Replace("/", "").Trim();

                    if (url1.Contains(url))
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
