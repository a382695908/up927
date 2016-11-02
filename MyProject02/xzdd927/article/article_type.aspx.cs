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
    public partial class article_type : System.Web.UI.Page
    {
        int adminId = 0;//编辑ID

        ArtBll artBll = new ArtBll();
        int articleType = 0;

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

            string strSql = " Select id,type_name,type_keyword " + " ,row_number() over(order by t_article_type.id asc ) as rowNumber " + " FROM t_article_type ";
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

        //添加分类按钮
        protected void imgBtn_Click(object sender, ImageClickEventArgs e)
        {
            string type_name = InText.SafeSql(InText.SafeStr(this.txtAddType.Value));
            string type_keyword = InText.SafeSql(InText.SafeStr(this.txtAddTypeKeyword.Value));
            if (type_name.Trim() != "")
            {
                string sql = string.Format("insert into t_article_type (type_name,type_keyword,remark) values ('{0}','{1}','')", type_name, type_keyword);

                if (artBll.ExecuteSQLNonquery(sql))
                {
                    InText.AlertAndRedirect("添加成功！", Request.Url.ToString());//刷新当前页
                }
            }
        }

        //更新/删除一条分类名称
        protected void repList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.CommandName == "Update")
                {
                    string type_id = this.hidUpdateId.Value;//分类ID
                    string type_name = this.hidUpdateTypeName.Value;//分类名称
                    string type_keyword = this.hidUpdateTypeKeyword.Value;//分类关键词

                    if (type_id != "" && type_name != "")
                    {
                        string sql = "update t_article_type set type_name='" + type_name + "',type_keyword='" + type_keyword + "' where id=" + type_id;

                        if (artBll.ExecuteSQLNonquery(sql))
                        {
                            InText.AlertAndRedirect("修改成功！", Request.Url.ToString());//刷新当前页
                        }
                    }
                }
                if (e.CommandName == "Delete")
                {
                    string sql = "select count(*) from t_article where type=" + e.CommandArgument.ToString();
                    int totalRecord = Utils.CheckInt(artBll.ExecuteScalar(sql));
                    if (totalRecord > 0)
                    {
                        InText.AlertAndRedirect("该分类下有文章，请先修改文章分类或删除文章！", Request.Url.ToString());//刷新当前页
                    }
                    else
                    {
                        sql = "delete from t_article_type where id=" + e.CommandArgument.ToString();

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
