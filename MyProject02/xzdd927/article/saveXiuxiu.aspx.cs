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
    public partial class saveXiuxiu : System.Web.UI.Page
    {
        ArtBll artBll = new ArtBll();
        int adminId = 0;//编辑ID

        public string savePath = HttpRuntime.AppDomainAppPath.ToString() + @ConfigurationManager.AppSettings["Article_File"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            //adminId = new AdminMethod().CheckAdminLogin();//-----------------------------

            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["get"]))
                {
                    int get = Utils.CheckInt(Request.QueryString["get"].ToString());
                    if (get == 1)
                    {
                        SaveArtImage();//保存文章图片
                    }
                    else if (get == 2)
                    {
                        SaveTagImage();//保存标签图片
                    }
                }
            }
        }

        //保存文章图片
        private void SaveArtImage()
        {
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Guid.NewGuid().ToString("N") + ".jpg";
            string filePath = savePath + "o_" + fileName;//先保存原图
            Request.Files[0].SaveAs(filePath);

            CommonMethod.MakeThumbnail(filePath, savePath + fileName, 400, 400, "cut");//生成缩略图

            CommonMethod.FilePicDelete(filePath);//删除原图

            string aaa = "/Article_File/af/" + "&&&&&" + fileName;
            Response.Write(aaa);
        }

        //保存标签图片
        private void SaveTagImage()
        {
            savePath = HttpRuntime.AppDomainAppPath.ToString() + @ConfigurationManager.AppSettings["Tag_File"].ToString();

            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Guid.NewGuid().ToString("N") + ".jpg";
            string filePath = savePath + "o_" + fileName;//先保存原图
            Request.Files[0].SaveAs(filePath);

            CommonMethod.MakeThumbnail(filePath, savePath + fileName, 400, 400, "cut");//生成缩略图

            CommonMethod.FilePicDelete(filePath);//删除原图

            string aaa = "/Article_File/tf/" + "&&&&&" + fileName;
            Response.Write(aaa);
        }

    }
}
