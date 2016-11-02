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
    public partial class article_tag : System.Web.UI.Page
    {
        int adminId = 0;//编辑ID

        ArtBll artBll = new ArtBll();
        int tag_id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            adminId = new AdminMethod().CheckAdminLogin();//-----------------------------

            if (!IsPostBack)
            {
                BindList();//绑定列表
            }
        }

        #region 绑定列表

        private bool BindList()
        {
            bool ifOk = true;

            int pageIndex = 1;
            int pageSize = 20;//pager.PageSize;//每页显示20条信息
            int totalRecord = 0;

            if (!string.IsNullOrEmpty(Request.QueryString["p"]) && MetarnetRegex.IsNumeric(Request.QueryString["p"]))
            {
                pageIndex = Convert.ToInt32(InText.SafeSql(InText.SafeStr(Request.QueryString["p"].ToString())));
            }

            string strSql = " Select id,tag_name,tag_keyword,article_num  " + " ,row_number() over(order by t_tag.id asc ) as rowNumber " + " FROM t_tag ";
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


        //添加标签按钮
        protected void imgBtn_Click(object sender, ImageClickEventArgs e)
        {
            string tag_name = InText.SafeSql(InText.SafeStr(this.txtAddTag.Value));
            string tag_keyword = InText.SafeSql(InText.SafeStr(this.txtAddTagKeyword.Value));//标签关键词
            if (tag_name.Trim() != "")
            {
                string sql = string.Format("insert into t_tag (tag_name,tag_keyword) values ('{0}','{1}')", tag_name, tag_keyword);

                if (artBll.ExecuteSQLNonquery(sql))
                {
                    InText.AlertAndRedirect("添加成功！", Request.Url.ToString());//刷新当前页
                }
            }
        }

        //更新/删除一条标签名称
        protected void repList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.CommandName == "Update")
                {
                    string tag_id = this.hidUpdateId.Value;//分类ID
                    string tag_name = this.hidUpdateName.Value;//分类名称
                    string tag_keyword = this.hidUpdateTagKeyword.Value;//分类关键词

                    if (tag_id != "" && tag_name != "")
                    {
                        string sql = "update t_tag set tag_name='" + tag_name + "',tag_keyword='" + tag_keyword + "' where id=" + tag_id;

                        if (artBll.ExecuteSQLNonquery(sql))
                        {
                            InText.AlertAndRedirect("修改成功！", Request.Url.ToString());//刷新当前页
                        }
                    }
                }
                if (e.CommandName == "Delete")
                {
                    string sql = "select count(*) from t_article where tag_id=" + e.CommandArgument.ToString();
                    int totalRecord = Utils.CheckInt(artBll.ExecuteScalar(sql));
                    if (totalRecord > 0)
                    {
                        InText.AlertAndRedirect("该标签下有文章，请先修改文章标签或删除文章！", Request.Url.ToString());//刷新当前页
                    }
                    else
                    {
                        sql = "delete from t_tag where id=" + e.CommandArgument.ToString();

                        if (artBll.ExecuteSQLNonquery(sql))
                        {
                            InText.AlertAndRedirect("删除成功！", Request.Url.ToString());//刷新当前页
                        }
                    }
                }
            }
        }



    }
}
