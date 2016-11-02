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
    public partial class image_list : System.Web.UI.Page
    {
        int adminId = 0;//编辑ID

        ArtBll artBll = new ArtBll();
        string update_date_min = "";
        string update_date_max = "";
        string html = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            adminId = new AdminMethod().CheckAdminLogin();//-----------------------------

            if (!string.IsNullOrEmpty(Request.QueryString["html"]))
            {
                html = InText.SafeStr(Request.QueryString["html"].ToString());
                this.txt_html.Value = html;
            }
            if (!string.IsNullOrEmpty(Request.QueryString["dateMin"]))
            {
                update_date_min = InText.SafeSql(InText.SafeStr(Request.QueryString["dateMin"].ToString()));
                this.txt_update_date_min.Value = update_date_min;
            }
            if (!string.IsNullOrEmpty(Request.QueryString["dateMax"]))
            {
                update_date_max = InText.SafeSql(InText.SafeStr(Request.QueryString["dateMax"].ToString()));
                this.txt_update_date_max.Value = update_date_max;
            }


            if (!IsPostBack)
            {
                BindList();
            }
        }

        #region 绑定列表

        private bool BindList()
        {
            bool ifOk = true;

            int pageIndex = 1;
            int pageSize = 30;//pager.PageSize;//每页显示20条信息
            int totalRecord = 0;

            if (!string.IsNullOrEmpty(Request.QueryString["p"]) && MetarnetRegex.IsNumeric(Request.QueryString["p"]))
            {
                pageIndex = Convert.ToInt32(InText.SafeSql(InText.SafeStr(Request.QueryString["p"].ToString())));
            }

            string where = " where 1=1";

            if (html.Trim() != "")
            {
                where += " and html like '%" + html + "%'";
            }
            if (update_date_min != "")
            {
                where += " and  DateDiff( day,  '" + update_date_min + "',t_article_pic.update_date) >=0 ";
            }
            if (update_date_max != "")
            {
                where += " and  DateDiff( day,  '" + update_date_max + "',t_article_pic.update_date) <=0 ";
            }


            string strSql = " Select t_article_pic.id as pic_id,t_article.title,t_article.html,t_article_pic.pic,t_article_pic.update_date   "
                             + " ,row_number() over(order by t_article_pic.id desc) as rowNumber "
                             + " FROM t_article_pic "
                             + " LEFT JOIN t_article ON t_article_pic.article_id=t_article.id ";
            DataTable dt = artBll.ExecutePager(strSql + where, pageSize, pageIndex, ref totalRecord);
            if (dt.Rows.Count > 0)
            {
                ifOk = true;

                pager.PageSize = pageSize;
                pager.RecordCount = totalRecord;
                this.repList_Img.DataSource = dt;
                this.repList_Img.DataBind();

                this.labInfoCount.Text = totalRecord.ToString();

                if (totalRecord <= pageSize)//只有一页，隐藏分页控件
                {
                    this.divFenye.Visible = false;
                }
            }
            else
            {
                this.divFenye.Visible = false;
                ifOk = false;
            }
            return ifOk;
        }
        #endregion

    }
}
