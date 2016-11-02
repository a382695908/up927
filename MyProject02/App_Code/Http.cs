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
using System.Net;

namespace MyProject02.App_Code
{
    public class Http
    {
        public string Post(string Url, string param)
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(Url);

            byte[] bs = Encoding.UTF8.GetBytes(param);
            string responseData = String.Empty;
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = bs.Length;
            req.UserAgent = "curl/7.12.1";
            req.ContentType = "text/plain";

            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
                reqStream.Close();
            }
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        responseData = reader.ReadToEnd().ToString();
                    }
                }
            }
            catch (WebException ex)
            {
                using (HttpWebResponse response = (HttpWebResponse)ex.Response)
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        responseData = reader.ReadToEnd().ToString();
                    }
                }
            }
            return responseData;
        }
    }
}
