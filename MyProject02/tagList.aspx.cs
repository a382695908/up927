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

namespace MyProject02
{
    public partial class tagList : System.Web.UI.Page
    {
        AccessBll accessBll = new AccessBll();
        ArtBll artBll = new ArtBll();

        string sql = "";
        DataTable dt;

        public string title = @ConfigurationManager.AppSettings["title"].ToString();//网站title关键词
        public string keyword = "";

        string Article_File = @ConfigurationManager.AppSettings["Article_File"].ToString();//文章图片存储路径


        protected void Page_Load(object sender, EventArgs e)
        {
            keyword = title.Replace("|", ",");

            BindList();
        }

        #region 绑定列表

        private bool BindList()
        {
            bool ifOk = true;

            int pageIndex = 1;
            int pageSize = 100;//pager.PageSize;//每页显示20条信息
            int totalRecord = 0;

            if (!string.IsNullOrEmpty(Request.QueryString["p"]) && MetarnetRegex.IsNumeric(Request.QueryString["p"]))
            {
                pageIndex = Convert.ToInt32(InText.SafeSql(InText.SafeStr(Request.QueryString["p"].ToString())));
            }

            string strSql = " Select id,tag_name,tag_keyword,article_num  " + " ,row_number() over(order by t_tag.article_num desc ) as rowNumber " + " FROM t_tag where t_tag.article_num>0 ";
            DataTable dt = artBll.ExecutePager(strSql, pageSize, pageIndex, ref totalRecord);

            if (dt.Rows.Count > 0)
            {
                ifOk = true;

                pager.PageSize = pageSize;
                pager.RecordCount = totalRecord;
                this.repList.DataSource = dt;
                this.repList.DataBind();

                //this.labInfoCount.Text = totalRecord.ToString();

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
