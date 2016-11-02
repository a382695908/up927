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
using System.Drawing;
using System.Net;
using BLL;

namespace MyProject02.test
{
    public partial class test01 : System.Web.UI.Page
    {
        ArtBll artBll = new ArtBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            //getimages();
        }

        //下载并保存图片
        public void getimages()
        {
            string sql = "select pic from t_article_pic where pic<>''";
            DataTable dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string url = "http://www.up927.com/Article_File/af/" + dt.Rows[i]["pic"].ToString();
                    //创建一个request 同时可以配置requst其余属性

                    //在这里以流的方式保存图片
                    System.Net.WebRequest imgRequst = System.Net.WebRequest.Create(url);
                    try
                    {
                        System.Drawing.Image downImage = System.Drawing.Image.FromStream(imgRequst.GetResponse().GetResponseStream());

                        downImage.Save(Server.MapPath("/Article_File/af1/" + dt.Rows[i]["pic"].ToString()));

                        downImage.Dispose();

                        //用完一定要释放
                    }
                    catch
                    {

                    }
                    finally
                    {

                    }
                }
            }
            

        }

        public static bool IsUrlExist(string Url)
        {
            bool IsExist = false;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(Url));
            ServicePointManager.Expect100Continue = false;
            try
            {
                ((HttpWebResponse)request.GetResponse()).Close();
                IsExist = true;
            }
            catch (WebException exception)
            {
                //if (exception.Status != WebExceptionStatus.ProtocolError)
                //{
                //    return num;
                //}
                //if (exception.Message.IndexOf("500 ") > 0)
                //{
                //    return 500;
                //}
                //if (exception.Message.IndexOf("401 ") > 0)
                //{
                //    return 401;
                //}
                //if (exception.Message.IndexOf("404") > 0)
                //{
                //    num = 404;
                //}
                IsExist = false;
            }

            return IsExist;
        }



    }
}
