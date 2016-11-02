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

namespace MyProject02.xzdd927.system
{
    public partial class upload : System.Web.UI.Page
    {
        ArtBll artBll = new ArtBll();

        int adminId = 0;//编辑ID



        protected void Page_Load(object sender, EventArgs e)
        {
            adminId = new AdminMethod().CheckAdminLogin();//-----------------------------

        }


         //上传按钮
        protected void btn_upload_Click(object sender, EventArgs e)
        {
            string savePath = HttpRuntime.AppDomainAppPath.ToString();
            if (this.txt_path.Text.Trim() != "")
            {
                savePath += this.txt_path.Text;
            }
            if (this.fu1.HasFile)
            {
                string fileName = this.fu1.FileName;
                this.fu1.PostedFile.SaveAs(savePath + fileName);//保存
            }
        }

    }
}
