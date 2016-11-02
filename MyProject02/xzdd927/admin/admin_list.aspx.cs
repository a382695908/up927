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

namespace MyProject02.xzdd927.admin
{
    public partial class admin_list : System.Web.UI.Page
    {
        ArtBll artBll = new ArtBll();

        int adminId = 0;//编辑ID

        protected void Page_Load(object sender, EventArgs e)
        {
            adminId = new AdminMethod().CheckAdminLogin();//-----------------------------

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
            int pageSize = 20;//pager.PageSize;//每页显示20条信息
            int totalRecord = 0;

            if (!string.IsNullOrEmpty(Request.QueryString["p"]) && MetarnetRegex.IsNumeric(Request.QueryString["p"]))
            {
                pageIndex = Convert.ToInt32(InText.SafeSql(InText.SafeStr(Request.QueryString["p"].ToString())));
            }

            string strSql = " Select id,name,pwd,remark " + " ,row_number() over(order by t_admin.id asc) as rowNumber from t_admin ";
            DataTable dt = artBll.ExecutePager(strSql, pageSize, pageIndex, ref totalRecord);

            if (dt.Rows.Count > 0)
            {
                ifOk = true;

                pager.PageSize = pageSize;
                pager.RecordCount = totalRecord;
                this.repList.DataSource = dt;
                this.repList.DataBind();

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

        //删除一个编辑人员按钮
        protected void repList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int admin_id = Convert.ToInt32(e.CommandArgument);
                bool isOk = DeleteOneAdmin(admin_id);//执行删除操作
                if (isOk)
                {
                    InText.AlertAndRedirect("删除成功！", Request.Url.ToString());//刷新当前页
                }
                else
                {
                    InText.AlertAndRedirect("删除失败，请重试！", Request.Url.ToString());//刷新当前页
                }
            }
        }

        //删除一篇文章
        private bool DeleteOneAdmin(int admin_id)
        {
            string sql = "delete from t_admin where id=" + admin_id;
            return artBll.ExecuteSQLNonquery(sql);
        }

        public string GetPwd(string pwd)
        {
            return WebBasic.Encryption.Decrypt(pwd);
        }

        #region 截取标题字数

        public string GetPartContent(string content, int length)
        {
            return CommonMethod.GetStringByLenth(content, length);
        }
        #endregion

    }
}
