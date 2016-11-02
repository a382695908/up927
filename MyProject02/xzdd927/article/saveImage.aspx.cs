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

namespace MyProject02.xzdd927.article
{
    public partial class saveImage : System.Web.UI.Page
    {
        string savePath = HttpRuntime.AppDomainAppPath.ToString() + @ConfigurationManager.AppSettings["Article_File"].ToString();
        ArtBll artBll = new ArtBll();
        string imageNamePre = "art_";//图片名称前缀:art_

        int adminId = 0;//编辑ID

        int articleId = 0;//图片对应的文章ID
        protected void Page_Load(object sender, EventArgs e)
        {
            adminId = new AdminMethod().CheckAdminLogin();//-----------------------------

            if (!string.IsNullOrEmpty(Request.QueryString["a_id"]) && MetarnetRegex.IsNumeric(Request.QueryString["a_id"]))
            {
                articleId = Utils.CheckInt(Request.QueryString["a_id"]);
            }

            if (articleId != 0)
            {
                string artPic = "";
                string fileName = "";
                if (Request.Files.Count > 0)
                {
                    fileName = Request.Files[0].FileName;
                    fileName = Server.UrlDecode(fileName);

                    string aLastName = fileName.Substring(fileName.LastIndexOf(".") + 1, (fileName.Length - fileName.LastIndexOf(".") - 1));//扩展名


                    if (aLastName.Trim().ToLower() == "gif")
                    {
                        artPic = imageNamePre + DateTime.Now.ToString("yyyyMMddHHmmss") + Guid.NewGuid().ToString("N") + ".gif";
                    }
                    else
                    {
                        artPic = imageNamePre + DateTime.Now.ToString("yyyyMMddHHmmss") + Guid.NewGuid().ToString("N") + ".jpg";
                    }

                    Request.Files[0].SaveAs(savePath + artPic);
                }
                else
                {

                    System.Drawing.Image img = System.Drawing.Image.FromStream(Request.InputStream);
                    fileName = Request.Headers["fileName"];
                    fileName = Server.UrlDecode(fileName);

                    string aLastName = fileName.Substring(fileName.LastIndexOf(".") + 1, (fileName.Length - fileName.LastIndexOf(".") - 1));//扩展名


                    if (aLastName.Trim().ToLower() == "gif")
                    {
                        artPic = imageNamePre + DateTime.Now.ToString("yyyyMMddHHmmss") + Guid.NewGuid().ToString("N") + ".gif";
                    }
                    else
                    {
                        artPic = imageNamePre + DateTime.Now.ToString("yyyyMMddHHmmss") + Guid.NewGuid().ToString("N") + ".jpg";
                    }

                    img.Save(savePath + artPic);
                }
                //string sql = string.Format("insert into t_article_pic (article_id,pic,update_date,remark) values ({0},'{1}',now(),'{2}')", articleId, artPic, "");

                //bool isOk = artBll.ExecuteSQLNonquery(sql);
            }
        }



    }
}
