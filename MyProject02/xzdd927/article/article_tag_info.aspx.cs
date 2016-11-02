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

namespace MyProject02.xzdd927.article
{
    public partial class article_tag_info : System.Web.UI.Page
    {
        int adminId = 0;//编辑ID

        ArtBll artBll = new ArtBll();
        int tag_id = 21;

        public string tag_name = "";
        public string tag_keyword = "";
        public string article_num = "0";
        public string tag_pic = "";
        public string tag_miaoshu = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            adminId = new AdminMethod().CheckAdminLogin();//-----------------------------

            if (!string.IsNullOrEmpty(Request.QueryString["t_id"]) && MetarnetRegex.IsNumeric(Request.QueryString["t_id"]))
            {
                tag_id = Utils.CheckInt(Request.QueryString["t_id"]);
            }

            if (!IsPostBack)
            {
                if (tag_id != 0)
                {
                    SelectTagInfo();
                }
            }
        }

        private void SelectTagInfo()
        {
            string sql = "select * from t_tag where id=" + tag_id;
            DataTable dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                tag_name = dt.Rows[0]["tag_name"].ToString();
                tag_keyword = dt.Rows[0]["tag_keyword"].ToString();
                article_num = dt.Rows[0]["article_num"].ToString();
                this.txt_tag_miaoshu.Text = dt.Rows[0]["tag_miaoshu"].ToString();
                if (dt.Rows[0]["tag_pic"].ToString().Trim() != "")//标签图片
                {
                    tag_pic = dt.Rows[0]["tag_pic"].ToString();
                    this.hid_artPic.Value = tag_pic;
                    this.img_artImg.Src = "/Article_File/tf/" + tag_pic;
                    this.td_artImg.Style.Add("display", "block");
                    this.td_artImgUpload.Style.Add("display", "none");
                    //this.td_artImg.Visible = true;
                    //this.td_artImgUpload.Visible = false;
                }
                else
                {
                    //this.td_artImgUpload.Visible = true;
                    this.td_artImg.Style.Add("display", "none");
                    this.td_artImgUpload.Style.Add("display", "block");
                }
            }
        }

        //删除图片按钮
        protected void btn_delImg_Click(object sender, EventArgs e)
        {
            if (tag_pic.Trim() == "")
            {
                tag_pic = this.hid_artPic.Value;
            }
            if (tag_pic.Trim() != "")
            {
                string sql = "update t_tag set tag_pic='' where id=" + tag_id;
                bool isOk = artBll.ExecuteSQLNonquery(sql);
                if (isOk)
                {
                    string strPath = HttpRuntime.AppDomainAppPath.ToString() + @ConfigurationManager.AppSettings["Tag_File"].ToString() + tag_pic;//删除原图
                    CommonMethod.FilePicDelete(strPath);

                    InText.AlertAndRedirect("删除成功", Request.Url.AbsoluteUri);
                }

            }
        }


        //保存按钮
        protected void btn_add_Click(object sender, EventArgs e)
        {
            tag_pic = this.hid_artPic.Value;
            tag_miaoshu = this.txt_tag_miaoshu.Text;

            string sql = "update t_tag set tag_pic='" + tag_pic + "',tag_miaoshu='" + tag_miaoshu + "' where id=" + tag_id;
            bool isOk = artBll.ExecuteSQLNonquery(sql);
            Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "key", "<script type=\"text/javascript\">layer.alert('保存成功', function(index){Hide();});  ;</script>");
        }

    }
}
