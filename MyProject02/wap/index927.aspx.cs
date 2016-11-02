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

namespace MyProject02.wap
{
    public partial class index927 : System.Web.UI.Page
    {
        ArtBll artBll = new ArtBll();

        string sql = "";
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            BindList();//绑定列表
        }

        #region 绑定列表

        private void BindList()
        {
            ////首页头条(带导语)
            //sql = "select top 5 * from t_article where daoyu<>'' order by update_date desc ";
            //dt = accessBll.SelectToDataTable(sql);
            //if (dt.Rows.Count > 0)
            //{
            //    this.repList1.DataSource = dt;
            //    this.repList1.DataBind();
            //}

            //母婴知识
            sql = "select top 5 * from t_article where type=2 order by update_date desc ";
            dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                this.repList2.DataSource = dt;
                this.repList2.DataBind();
            }

            //儿童教育
            sql = "select top 5 * from t_article where type=3 order by update_date desc ";
            dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                this.repList3.DataSource = dt;
                this.repList3.DataBind();
            }

            //育儿知识
            sql = "select top 5 * from t_article where type=4 order by update_date desc ";
            dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                this.repList4.DataSource = dt;
                this.repList4.DataBind();
            }

            //生活常识
            sql = "select top 5 * from t_article where type=5 order by update_date desc ";
            dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                this.repList5.DataSource = dt;
                this.repList5.DataBind();
            }

            //轻松一刻
            sql = "select top 5 * from t_article where type=6 order by update_date desc ";
            dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                this.repList6.DataSource = dt;
                this.repList6.DataBind();
            }

            //谈天说地
            sql = "select top 5 * from t_article where type=7 order by update_date desc ";
            dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                this.repList7.DataSource = dt;
                this.repList7.DataBind();
            }
        }
        #endregion

        #region 截取标题字数

        public string GetPartContent(string content, int length)
        {
            return CommonMethod.GetStringByLenth(content, length);
        }
        #endregion

    }
}
