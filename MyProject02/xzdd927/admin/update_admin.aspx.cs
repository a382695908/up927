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

namespace MyProject02.xzdd927.admin
{
    public partial class update_admin : System.Web.UI.Page
    {
        ArtBll artBll = new ArtBll();

        int adminId = 0;//编辑ID

        int admin_id = 0;
        string name = "";
        string pwd = "";
        string remark = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            adminId = new AdminMethod().CheckAdminLogin();//-----------------------------

            if (!string.IsNullOrEmpty(Request.QueryString["admin_id"]) && MetarnetRegex.IsNumeric(Request.QueryString["admin_id"]))
            {
                admin_id = Convert.ToInt32(Request.QueryString["admin_id"].ToString());
            }

            if (!Page.IsPostBack)
            {
                if (admin_id != 0)
                {
                    InitAdminInfo();//初始化人员信息

                }
            }
        }

        #region 初始化人员信息

        private void InitAdminInfo()
        {
            String sql = "select * from t_admin where id=" + admin_id;
            DataTable dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                name = dt.Rows[0]["name"].ToString();
                pwd = WebBasic.Encryption.Decrypt(dt.Rows[0]["pwd"].ToString());
                remark = dt.Rows[0]["remark"].ToString();

                this.txt_name.Value = name;
                this.txt_pwd.Value = pwd;
                this.txt_remark.Value = remark;
            }
        }
        #endregion

        //保存按钮
        protected void btn_Update_Click(object sender, EventArgs e)
        {
            name = InText.SafeSql(InText.SafeStr(this.txt_name.Value));
            pwd = WebBasic.Encryption.Encrypt(InText.SafeSql(InText.SafeStr(this.txt_pwd.Value)));
            remark = InText.SafeSql(InText.SafeStr(this.txt_remark.Value));

            if (admin_id != 0)//执行修改
            {
                string sql = string.Format("update t_admin set name='{0}',pwd='{1}',remark='{2}' where id={3}",name,pwd,remark,admin_id);
                bool isOk = artBll.ExecuteSQLNonquery(sql);
                if (isOk)
                {
                    InText.AlertAndRedirect("修改成功", "/xzdd927/admin/admin_list.aspx");// Request.Url.AbsoluteUri
                }
            }
            else //执行添加
            {
                string sql = string.Format("insert into t_admin (name,pwd,remark) values ('{0}','{1}','{2}')", name, pwd, remark);
                bool isOk = artBll.ExecuteSQLNonquery(sql);
                if (isOk)
                {
                    InText.AlertAndRedirect("添加成功", "/xzdd927/admin/admin_list.aspx");// Request.Url.AbsoluteUri
                }
            }
        }


    }
}
