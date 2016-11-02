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
    public partial class add_article : System.Web.UI.Page
    {
        ArtBll artBll = new ArtBll();

        int adminId = 0;//编辑ID

        string imageNamePre = "art_";//图片名称前缀:art_

        public int articleId //查询文章ID
        {
            get
            {
                Object obj = this.ViewState["articleId"];
                if (obj != null)
                {
                    return (int)ViewState["articleId"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["articleId"] = value;
            }
        }

        public string artPic //文章图片
        {
            get
            {
                Object obj = this.ViewState["artPic"];
                if (obj != null)
                {
                    return (string)ViewState["artPic"];
                }
                else
                {
                    return "";
                }
            }
            set
            {
                ViewState["artPic"] = value;
            }
        }

        public string artPic_huandeng1 //文章幻灯图片
        {
            get
            {
                Object obj = this.ViewState["artPic_huandeng1"];
                if (obj != null)
                {
                    return (string)ViewState["artPic_huandeng1"];
                }
                else
                {
                    return "";
                }
            }
            set
            {
                ViewState["artPic_huandeng1"] = value;
            }
        }

        public int articleId_img //
        {
            get
            {
                Object obj = this.ViewState["articleId_img"];
                if (obj != null)
                {
                    return (int)ViewState["articleId_img"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["articleId_img"] = value;
            }
        }

        public string article_html //
        {
            get
            {
                Object obj = this.ViewState["article_html"];
                if (obj != null)
                {
                    return (string)ViewState["article_html"];
                }
                else
                {
                    return "";
                }
            }
            set
            {
                ViewState["article_html"] = value;
            }
        }

        public string update_date //
        {
            get
            {
                Object obj = this.ViewState["update_date"];
                if (obj != null)
                {
                    return (string)ViewState["update_date"];
                }
                else
                {
                    return "";
                }
            }
            set
            {
                ViewState["update_date"] = value;
            }
        }

        public string tag_id_a //
        {
            get
            {
                Object obj = this.ViewState["tag_id_a"];
                if (obj != null)
                {
                    return (string)ViewState["tag_id_a"];
                }
                else
                {
                    return "";
                }
            }
            set
            {
                ViewState["tag_id_a"] = value;
            }
        }


        public int last_id = 0;
        public int next_id = 0;
        public string last_html //
        {
            get
            {
                Object obj = this.ViewState["last_html"];
                if (obj != null)
                {
                    return (string)ViewState["last_html"];
                }
                else
                {
                    return "";
                }
            }
            set
            {
                ViewState["last_html"] = value;
            }
        }
        public string last_title //
        {
            get
            {
                Object obj = this.ViewState["last_title"];
                if (obj != null)
                {
                    return (string)ViewState["last_title"];
                }
                else
                {
                    return "";
                }
            }
            set
            {
                ViewState["last_title"] = value;
            }
        }
        public string next_html //
        {
            get
            {
                Object obj = this.ViewState["next_html"];
                if (obj != null)
                {
                    return (string)ViewState["next_html"];
                }
                else
                {
                    return "";
                }
            }
            set
            {
                ViewState["next_html"] = value;
            }
        }
        public string next_title //
        {
            get
            {
                Object obj = this.ViewState["next_title"];
                if (obj != null)
                {
                    return (string)ViewState["next_title"];
                }
                else
                {
                    return "";
                }
            }
            set
            {
                ViewState["next_title"] = value;
            }
        }

        public string staticPath = @ConfigurationManager.AppSettings["Article_Path"].ToString();
        string url = @ConfigurationManager.AppSettings["url"].ToString();//"http://localhost:27442";//
        public string Article_File = @ConfigurationManager.AppSettings["Article_File"].ToString();
        public string pc = @ConfigurationManager.AppSettings["pc"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            adminId = new AdminMethod().CheckAdminLogin();//-----------------------------

            if (!string.IsNullOrEmpty(Request.QueryString["a_id"]) && MetarnetRegex.IsNumeric(Request.QueryString["a_id"]))
            {
                articleId = Utils.CheckInt(Request.QueryString["a_id"]);
            }
            //articleId = 0;//-------------------------
            if (articleId == 0)
            {
                string sql = "select max(id) as maxId from t_article";
                DataTable dtMaxId = artBll.SelectToDataTable(sql);
                if (dtMaxId.Rows.Count > 0)
                {
                    articleId_img = Convert.ToInt32(dtMaxId.Rows[0]["maxId"]) + 1;

                    ////文章分类默认为与上一篇文章相同
                    //sql = "select * from t_article where id=" + dtMaxId.Rows[0]["maxId"].ToString();
                    //dtMaxId = artBll.SelectToDataTable(sql);
                    //if (dtMaxId.Rows.Count > 0)
                    //{
                    //    this.ddl_articleType.SelectedValue = dtMaxId.Rows[0]["type"].ToString();
                    //}
                }
                
            }
            else
            {
                articleId_img = articleId;
            }

            if (!IsPostBack)
            {
                InitArticle();
                InitImg();
            }
        }

        private void InitImg()
        {
            if (articleId_img != 0)
            {
                String sql = "select * from t_article_pic where article_id=" + articleId_img;
                DataTable dt = artBll.SelectToDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    this.repList_Img.DataSource = dt;
                    this.repList_Img.DataBind();
                }
            }
        }

        private void InitArticle()
        {
            String sql = "select * from t_article_type ";
            DataTable dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                this.ddl_articleType.DataSource = dt;
                this.ddl_articleType.DataBind();
            }

            if (articleId != 0)
            {
                sql = "select * from t_article where id=" + articleId ;
                DataTable dtArticle = artBll.SelectToDataTable(sql);
                if (dtArticle.Rows.Count > 0)
                {
                    this.txt_title.Text = dtArticle.Rows[0]["title"].ToString();
                    this.txt_title1.Text = dtArticle.Rows[0]["title1"].ToString();
                    this.txt_source.Text = dtArticle.Rows[0]["source"].ToString();
                    this.ddl_articleType.SelectedValue = dtArticle.Rows[0]["type"].ToString();
                    //content2.Text = dtArticle.Rows[0]["content"].ToString();
                    this.hidDes.Value = dtArticle.Rows[0]["content"].ToString();

                    this.ddl_declare_mark.SelectedValue = dtArticle.Rows[0]["declare_mark"].ToString();
                    this.txt_keyword.Text = dtArticle.Rows[0]["keyword"].ToString();
                    this.txt_search_keyword.Text = dtArticle.Rows[0]["search_keyword"].ToString();
                    this.txt_daoyu.Text = dtArticle.Rows[0]["daoyu"].ToString();
                    update_date = dtArticle.Rows[0]["update_date"].ToString();
                    if (dtArticle.Rows[0]["pic"].ToString().Trim() != "")//文章图片
                    {
                        artPic = dtArticle.Rows[0]["pic"].ToString();
                        this.hid_artPic.Value = artPic;
                        this.img_artImg.Src = "/Article_File/af/" + artPic;
                        this.td_artImg.Style.Add("display","block");
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

                    if (dtArticle.Rows[0]["huandeng1_pic"].ToString().Trim() != "")//文章幻灯图片
                    {
                        artPic_huandeng1 = dtArticle.Rows[0]["huandeng1_pic"].ToString();
                        this.img_artImg_huandeng1.Src = "/Article_File/hd1/" + artPic_huandeng1;
                        this.img_artImg_huandeng1.Visible = true;
                        this.fu_image_huandeng1.Visible = false;
                    }
                    else
                    {
                        this.fu_image_huandeng1.Visible = true;
                    }

                    //是否首页幻灯
                    if (dtArticle.Rows[0]["huandeng1"].ToString().Trim() != "" && dtArticle.Rows[0]["huandeng1"].ToString() == "1")
                    {
                        this.chkHuandeng1.Checked = true;
                    }
                    else
                    {
                        this.chkHuandeng1.Checked = false;
                    }

                    this.ddl_right_type.SelectedValue = dtArticle.Rows[0]["right_type"].ToString();

                    this.txt_tag.Text = dtArticle.Rows[0]["tag"].ToString();
                    tag_id_a = dtArticle.Rows[0]["tag_id"].ToString();
                    //hidTagId.Value = dtArticle.Rows[0]["tag_id"].ToString();//标签ID 
                    //if (hidTagId.Value.Trim() != "")
                    //{
                    //    string tagName = "";
                    //    string[] arrayTagId = hidTagId.Value.Split(',');
                    //    for (int i = 0; i < arrayTagId.Length; i++)
                    //    {
                    //        if (arrayTagId[i].Trim() != "")
                    //        {
                    //            tagName += SelectOneTag(arrayTagId[i]) + " ";
                    //        }
                    //    }
                    //    this.txt_tag.Text = tagName;
                    //}

                    article_html = dtArticle.Rows[0]["html"].ToString();
                }
            }
        }

        //添加/修改按钮
        protected void btn_add_Click(object sender, EventArgs e)
        {
            int huandeng1 = 0;
            if (this.chkHuandeng1.Checked)//是否首页幻灯
            {
                huandeng1 = 1;
            }

            string title =InText.SafeSql(InText.SafeStr( this.txt_title.Text));
            string title1 = InText.SafeSql(InText.SafeStr(this.txt_title1.Text));
            if (title1.Trim() == "")
            {
                title1 = title;
            }
            string source =InText.SafeSql(InText.SafeStr( this.txt_source.Text));
            int articleType = Convert.ToInt32(this.ddl_articleType.SelectedValue);
            string articleTypeName = this.ddl_articleType.SelectedItem.Text;
            string content = this.hidDes.Value.Trim();//素材内容（编辑器）   //InText.SafeSql(InText.SafeSqlContent(content2.Text));
            int declare_mark = Convert.ToInt32(this.ddl_declare_mark.SelectedValue);
            string keyword = InText.SafeSql(InText.SafeStr(this.txt_keyword.Text));
            string search_keyword = InText.SafeSql(InText.SafeStr(this.txt_search_keyword.Text));
            string daoyu = InText.SafeSql(InText.SafeStr(this.txt_daoyu.Text));
            string tag = InText.SafeSql(InText.SafeStr(this.txt_tag.Text));
            int right_type = Convert.ToInt32(this.ddl_right_type.SelectedValue);

            //================================上传图片附件============================================================================
            string savePath = HttpRuntime.AppDomainAppPath.ToString()+@ConfigurationManager.AppSettings["Article_File"].ToString();
            //int result = 0;
            //文章图片
            if (this.fu_image.HasFile)
            {
                //修改文章时，删除原来的图片
                if (articleId != 0)
                {
                    if (artPic.Trim() != "")
                    {
                        string sql = "update t_article set pic='' where id=" + articleId;
                        bool isOk = artBll.ExecuteSQLNonquery(sql);
                        if (isOk)
                        {
                            string strPath = HttpRuntime.AppDomainAppPath.ToString() + @ConfigurationManager.AppSettings["Article_File"].ToString() + artPic;//删除原图
                            CommonMethod.FilePicDelete(strPath);
                            strPath = HttpRuntime.AppDomainAppPath.ToString() + @ConfigurationManager.AppSettings["Article_File"].ToString() + "100_100_" + artPic;//删除缩略图
                            CommonMethod.FilePicDelete(strPath);
                        }
                    }
                }

                artPic = "";
                int len = fu_image.PostedFile.ContentLength;
                if (fu_image.PostedFile.ContentLength <= 10240000)//10M内
                {
                    //if (FileUpload.PostedFile.ContentLength<=)
                    if (CommonMethod.IsAllowedExtension(fu_image))//验证下文件是否为图片
                    {
                        string filepath = fu_image.PostedFile.FileName;
                        string filename_user = filepath.Substring(filepath.LastIndexOf("\\") + 1);
                        artPic = imageNamePre + DateTime.Now.ToString("yyyyMMddHHmmss") + Guid.NewGuid().ToString("N") + ".jpg";
                        string serverpath = savePath + "img_"+artPic;
                        fu_image.PostedFile.SaveAs(serverpath);//保存原图片

                        string smallPath = savePath + artPic;//缩略图路径
                        //CommonMethod.MakeThumbnail(serverpath, smallPath, 500, 500, "W");//保存成最大500*500
                        smallPath = savePath + "100_100_" + artPic;//缩略图路径
                        CommonMethod.MakeThumbnail(serverpath, smallPath, 300, 300, "HW");//生成缩略图150*150

                        CommonMethod.FilePicDelete(serverpath);//删除原图片
                    }
                }
            }
            artPic = this.hid_artPic.Value;

            //幻灯图片
            if (this.fu_image_huandeng1.HasFile)
            {
                savePath = HttpRuntime.AppDomainAppPath.ToString() + @ConfigurationManager.AppSettings["hd1"].ToString();
          
                //修改文章时，删除原来的图片
                if (articleId != 0)
                {
                    if (artPic_huandeng1.Trim() != "")
                    {
                        string sql = "update t_article set huandeng1_pic='' where id=" + articleId;
                        bool isOk = artBll.ExecuteSQLNonquery(sql);
                        if (isOk)
                        {
                            string strPath = HttpRuntime.AppDomainAppPath.ToString() + @ConfigurationManager.AppSettings["Article_File"].ToString() + artPic_huandeng1;//删除原图
                            CommonMethod.FilePicDelete(strPath);
                        }
                    }
                }

                artPic_huandeng1 = "";
                int len = fu_image_huandeng1.PostedFile.ContentLength;
                if (fu_image_huandeng1.PostedFile.ContentLength <= 10240000)//10M内
                {
                    if (CommonMethod.IsAllowedExtension(fu_image_huandeng1))//验证下文件是否为图片
                    {
                        string filepath = fu_image_huandeng1.PostedFile.FileName;
                        string filename_user = filepath.Substring(filepath.LastIndexOf("\\") + 1);
                        artPic_huandeng1 = imageNamePre + "hd1_" + DateTime.Now.ToString("yyyyMMddHHmmss") + Guid.NewGuid().ToString("N") + ".jpg";
                        string serverpath = savePath + artPic_huandeng1;
                        fu_image_huandeng1.PostedFile.SaveAs(serverpath);//保存原图片

                        //string smallPath = savePath + artPic;//缩略图路径
                        //CommonMethod.MakeThumbnail(serverpath, smallPath, 500, 500, "W");//保存成最大500*500

                        //CommonMethod.FilePicDelete(serverpath);//删除原图片
                        huandeng1 = 1;
                    }
                }
            }
            //======================================上传图片附件==========================================================================

            string tagIdHtml = "";//要引用的标签静态页ID（第一个标签的ID）
            string tagId = "";//要保存的多个标签ID
            string tagStr = "";//要保存的多个标签
            if (this.txt_tag.Text.Trim() != "")
            {
                tagStr = InText.SafeSql(InText.SafeStr(this.txt_tag.Text));

                //生成标签
                string[] arrayTag = tagStr.Split(' ');
                for (int i = 0; i < arrayTag.Length; i++)
                {
                    if (arrayTag[i].Trim() != "")
                    {
                        string tag_id = SelectOneTag(arrayTag[i]);
                        if (tag_id != "")
                        {
                            //CreateOneTag(tag_id);
                            if (tagIdHtml == "")
                            {
                                tagIdHtml = tag_id;
                            }
                            tagId += tag_id + ",";
                        }
                    }
                }
                tagId = "," + tagId;
            }



            if (articleId != 0)//执行修改
            {
                string sql = string.Format("update t_article set title='{0}',keyword='{1}',daoyu='{2}',content='{3}',type={4},declare_mark={5},pic='{6}',remark='{7}',source='{9}',huandeng1={10},huandeng1_pic='{11}',tag='{12}',tag_id='{13}',right_type={14},title1='{15}',search_keyword='{16}' where id={8}",
                    title, keyword, daoyu, content, articleType, declare_mark, artPic, "article/", articleId, source, huandeng1, artPic_huandeng1, tagStr, tagId, right_type, title1, search_keyword);//

                bool isOk = artBll.ExecuteSQLNonquery(sql);

                GetLastNext(articleId, articleType);//获取上一篇、下一篇

                //更新上一篇、下一篇 
                sql = "update t_article set last_id=" + last_id + ",next_id=" + next_id + " where id=" + articleId;
                isOk = artBll.ExecuteSQLNonquery(sql);

                //更新上一篇文章的下一篇id
                sql = "update t_article set next_id=" + articleId + " where id=" + last_id;
                isOk = artBll.ExecuteSQLNonquery(sql);

                //生成静态页
                CommonMethod.CreateArticleHtml(articleId, title, title1, source, articleType, articleTypeName, content, keyword, artPic, article_html, tagStr, tagId, tagIdHtml, Convert.ToDateTime(update_date).ToString("yyyy年M月d日"), last_html, last_title, next_html, next_title, search_keyword);

                //生成wap版静态页
                CommonMethod.CreateArticleHtml_Wap(articleId, title, title1, source, articleType, articleTypeName, content, keyword, artPic, article_html, tagStr, tagId, tagIdHtml, search_keyword);

                //重新生成上一篇文章(更新“下一篇”链接)
                CommonMethod.CreateOneArticleHtml(last_id);
                //sql = "select top 1 * from t_article where id <" + articleId + " order by id desc";
                //DataTable dtLast = artBll.SelectToDataTable(sql);
                //if (dtLast.Rows.Count > 0)
                //{
                //    int last_id = Convert.ToInt32(dtLast.Rows[0]["id"]);
                //    //string article_html_last = dtLast.Rows[0]["html"].ToString();
                //    CommonMethod.CreateOneArticleHtml(last_id);
                //}
            }
            else //执行添加
            {
                string sql = string.Format("insert into t_article (title,keyword,daoyu,content,type,update_date,declare_mark,pic,remark,source,huandeng1,huandeng1_pic,tag,tag_id,right_type,title1,search_keyword) values ('{0}','{1}','{2}','{3}',{4},getdate(),{5},'{6}','{7}','{8}',{9},'{10}','{11}','{12}',{13},'{14}','{15}')",
                    title, keyword, daoyu, content, articleType, declare_mark, artPic, "article/", source, huandeng1, artPic_huandeng1, tagStr, tagId, right_type, title1, search_keyword);

                bool isOk = artBll.ExecuteSQLNonquery(sql);
                if (isOk)
                {
                    DataTable dtMaxId = artBll.SelectToDataTable("select max(id) as id from t_article");
                    if (dtMaxId.Rows.Count > 0)
                    {
                        articleId=Convert.ToInt32(dtMaxId.Rows[0]["id"]);
                        string id_show = CommonMethod.GetIDEncrypt(articleId);//对ID进行加密

                        DataTable dtIdShow = artBll.SelectToDataTable("select id from t_article where id_show='" + id_show + "' ");
                        while (dtIdShow.Rows.Count > 0)
                        {
                            id_show = CommonMethod.GetIDEncrypt(articleId);//有重复，再次对ID进行加密
                            dtIdShow = artBll.SelectToDataTable("select id from t_article where id_show='" + id_show + "' ");
                        }
                        articleId = Convert.ToInt32(dtMaxId.Rows[0]["id"]);
                        article_html = staticPath + id_show + ".shtml";
                        sql = "update t_article set html='" + article_html + "',id_show='" + id_show + "' where id=" + articleId;
                        isOk = artBll.ExecuteSQLNonquery(sql);//将静态页名称保存到数据库

                        GetLastNext(articleId, articleType);//获取上一篇、下一篇

                        //更新上一篇、下一篇 
                        sql = "update t_article set last_id=" + last_id + ",next_id=" + next_id + " where id=" + articleId;
                        isOk = artBll.ExecuteSQLNonquery(sql);

                        //更新上一篇文章的下一篇id
                        sql = "update t_article set next_id=" + articleId + " where id=" + last_id;
                        isOk = artBll.ExecuteSQLNonquery(sql);

                        //生成静态页
                        CommonMethod.CreateArticleHtml(articleId, title, title1, source, articleType, articleTypeName, content, keyword, artPic, article_html, tagStr, tagId, tagIdHtml, DateTime.Now.ToString("yyyy年M月d日"), last_html, last_title, next_html, next_title, search_keyword);

                        //生成wap版静态页
                        CommonMethod.CreateArticleHtml_Wap(articleId, title, title1, source, articleType, articleTypeName, content, keyword, artPic, article_html, tagStr, tagId, tagIdHtml, search_keyword);

                        //重新生成上一篇文章(更新“下一篇”链接)
                        CommonMethod.CreateOneArticleHtml(last_id);
                        //sql = "select top 1 * from t_article where id <" + articleId + " order by id desc";
                        //DataTable dtLast = artBll.SelectToDataTable(sql);
                        //if (dtLast.Rows.Count > 0)
                        //{
                        //    last_id = Convert.ToInt32(dtLast.Rows[0]["id"]);
                        //    //string article_html_last = dtLast.Rows[0]["html"].ToString();
                        //    CommonMethod.CreateOneArticleHtml(last_id);
                        //}
                    }
                }
                
            }

            if (this.txt_tag.Text.Trim() != "")
            {
                tagStr = InText.SafeSql(InText.SafeStr(this.txt_tag.Text));

                //生成标签
                string[] arrayTag = tagStr.Split(' ');
                for (int i = 0; i < arrayTag.Length; i++)
                {
                    if (arrayTag[i].Trim() != "")
                    {
                        string tag_id = SelectOneTag(arrayTag[i]);
                        if (tag_id != "")
                        {
                            CreateOneTag(tag_id);
                            if (tagIdHtml == "")
                            {
                                tagIdHtml = tag_id;
                            }
                            //select count(id) from t_article where tag_id like '*,9,*'

                            if (tag_id_a.Trim()=="")
                            {
                                //添加文章，更新该标签下的文章数量
                                artBll.ExecuteSQLNonquery("update t_tag set article_num=article_num+1 where id=" + tag_id);
                            }
                            tagId += tag_id + ",";
                        }
                    }
                }
                tagId = "," + tagId;
            }

            //生成右侧
            //CommonMethod.CteateHTML(url + "template/Side_2.aspx", "", "/userControl/Side_2.html");

            //生成404页面
            CommonMethod.CteateHTML(url + "template/404.aspx", "", "/404.html");

            if (articleId != 0)//执行修改
            {
                InText.AlertAndRedirect("修改成功", "/xzdd927/article/article_list.aspx");//  
            }
            else //执行添加
            {
                InText.AlertAndRedirect("添加成功", "/xzdd927/article/add_article.aspx");//  /xzdd927/article/article_list.aspx
            }
        }

        #region 上一篇、下一篇

        private void GetLastNext(int articleId, int articleType)
        {
            //上一篇
            string sql = "select top 1 * from t_article where id <" + articleId +  " order by id desc";
            DataTable dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                last_id = Convert.ToInt32(dt.Rows[0]["id"]);
                last_title = "上一篇：" + dt.Rows[0]["title"].ToString();
                last_html = dt.Rows[0]["html"].ToString();
            }

            //下一篇
            sql = "select top 1 * from t_article where id >" + articleId + " order by id ";
            dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                next_id = Convert.ToInt32(dt.Rows[0]["id"]);
                next_title = "下一篇：" + dt.Rows[0]["title"].ToString();
                next_html = dt.Rows[0]["html"].ToString();
            }
        }

        #endregion

        #region 生成一个标签静态页

        private void CreateOneTag(string tagId)
        {
            String sql = "select top 20 title,html from t_article where tag_id like '%," + tagId + ",%' order by id desc ";
            DataTable dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                CommonMethod.CteateTag(dt, "/tag/" + tagId + ".html");
            }
        }
        #endregion

        #region 查询一个标签

        private string SelectOneTag(string tag_name)
        {
            String sql = "select * from t_tag where tag_name='" + tag_name + "'";
            DataTable dt = artBll.SelectToDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["id"].ToString();
            }
            else
            {
                return "";
            }
        }
        #endregion

        //删除图片按钮
        protected void btn_delImg_Click(object sender, EventArgs e)
        {
            if (artPic.Trim() == "")
            {
                artPic = this.hid_artPic.Value;
            }
            if (artPic.Trim() != "")
            {
                string sql = "update t_article set pic='' where id=" + articleId;
                bool isOk = artBll.ExecuteSQLNonquery(sql);
                if (isOk)
                {
                    string strPath = HttpRuntime.AppDomainAppPath.ToString() + @ConfigurationManager.AppSettings["Article_File"].ToString() + artPic;//删除原图
                    CommonMethod.FilePicDelete(strPath);
                    strPath = HttpRuntime.AppDomainAppPath.ToString()+@ConfigurationManager.AppSettings["Article_File"].ToString() + "100_100_" + artPic;//删除缩略图
                    CommonMethod.FilePicDelete(strPath);

                    InText.AlertAndRedirect("删除成功", Request.Url.AbsoluteUri);
                }
                
            }
        }

        //删除幻灯图片按钮
        protected void btn_delImg_huandeng1_Click(object sender, EventArgs e)
        {
            if (artPic_huandeng1.Trim() != "")
            {
                string sql = "update t_article set huandeng1_pic='' where id=" + articleId;
                bool isOk = artBll.ExecuteSQLNonquery(sql);
                if (isOk)
                {
                    string strPath = HttpRuntime.AppDomainAppPath.ToString() + @ConfigurationManager.AppSettings["Article_File"].ToString() + artPic_huandeng1;//删除原图
                    CommonMethod.FilePicDelete(strPath);

                    InText.AlertAndRedirect("删除成功", Request.Url.AbsoluteUri);
                }

            }
        }

        #region 动态页生成静态页
        //private XmlProvider xmlprovider = new XmlProvider();
        public void CteateHTML(string strurl, string path, int art_id, string html)
        {
            StreamReader sr;
            StreamWriter sw;
            WebRequest HttpWebRequest = WebRequest.Create(strurl);
            WebResponse HttpWebResponse = HttpWebRequest.GetResponse();
            sr = new StreamReader(HttpWebResponse.GetResponseStream(), System.Text.Encoding.GetEncoding("utf-8"));//gb2312
            string strHtml = sr.ReadToEnd();
            strurl = strurl.Substring(strurl.LastIndexOf("/") + 1);
            strurl = strurl.Replace(".aspx", ".html");

            strHtml = strHtml.Replace("</form>", "");
            strHtml = Regex.Replace(strHtml, "<form[^>]*>", "");
            string savefile = HttpContext.Current.Server.MapPath(html);//---------------
            //savefile = savefile.Substring(0, savefile.LastIndexOf("?"));

            //编辑后台未登录状态下不能生成静态页
            if (strurl.Contains("很抱歉，没有找到您要访问的页面"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "<script type=\"text/javascript\">showResult('静态页未生成，请登录后重新操作！',false)</script>", false);
            }
            else
            {
                sw = new StreamWriter(savefile, false, System.Text.Encoding.GetEncoding("utf-8"));
                sw.WriteLine(strHtml);
                sw.Flush();
                sw.Close();
            }
        }
        #endregion

        #region 上传多张图片按钮（已停用，改为控件批量上传）
        //上传多张图片按钮（每点一次上传一张图片）
        protected void btnUpdateImg_Click(object sender, EventArgs e)
        {
            string savePath = HttpRuntime.AppDomainAppPath.ToString() + @ConfigurationManager.AppSettings["Article_File"].ToString();
            //int result = 0;
            if (this.fu_image1.HasFile)
            {
                artPic = "";
                int len = fu_image1.PostedFile.ContentLength;
                if (fu_image1.PostedFile.ContentLength <= 10240000)//10M内
                {
                    //if (FileUpload.PostedFile.ContentLength<=)
                    if (CommonMethod.IsAllowedExtension(fu_image1))//验证下文件是否为图片
                    {

                        string filepath = fu_image1.PostedFile.FileName;
                        string filename_user = filepath.Substring(filepath.LastIndexOf("\\") + 1);
                        string aLastName = filepath.Substring(filepath.LastIndexOf(".") + 1, (filepath.Length - filepath.LastIndexOf(".") - 1));   //扩展名

                        if (aLastName.Trim().ToLower() == "gif")
                        {
                            artPic = imageNamePre + DateTime.Now.ToString("yyyyMMddHHmmss") + Guid.NewGuid().ToString("N") + ".gif";
                        }
                        else
                        {
                            artPic = imageNamePre + DateTime.Now.ToString("yyyyMMddHHmmss") + Guid.NewGuid().ToString("N") + ".jpg";
                        }

                        if (aLastName.Trim().ToLower() == "gif")
                        {
                            string serverpath = savePath + "img_" + artPic;
                            string smallPath = savePath + artPic;//缩略图路径

                            fu_image1.PostedFile.SaveAs(smallPath);//保存原图片
                        }
                        else
                        {
                            string serverpath = savePath + "img_" + artPic;
                            fu_image1.PostedFile.SaveAs(serverpath);//保存原图片

                            string smallPath = savePath + artPic;//缩略图路径
                            CommonMethod.MakeThumbnail(serverpath, smallPath, 600, 600, "W");//保存成最大500*500

                            //smallPath = savePath + "100_100_" + artPic;//缩略图路径
                            //CommonMethod.MakeThumbnail(serverpath, smallPath, 117, 85, "HW");//生成缩略图155*100

                            CommonMethod.FilePicDelete(serverpath);//删除原图片
                        }
                    }
                }

                string sql = string.Format("insert into t_article_pic (article_id,pic,update_date,remark) values ({0},'{1}',getdate(),'{2}')", articleId_img, artPic, "");

                bool isOk = artBll.ExecuteSQLNonquery(sql);

                Response.Redirect(Request.Url.ToString());
            }

        }
        #endregion

        //删除一张图片按钮
        protected void repList_Img_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string[] arg = e.CommandArgument.ToString().Split('|');
                int articleId = Convert.ToInt32(arg[0]);
                string pic = arg[1];

                bool isOk = DeleteOnePic(articleId);//执行删除操作

                if (isOk)
                {
                    string strPath = HttpRuntime.AppDomainAppPath.ToString() + @ConfigurationManager.AppSettings["Article_File"].ToString() + pic;//删除原图
                    CommonMethod.FilePicDelete(strPath);
                    strPath = HttpRuntime.AppDomainAppPath.ToString() + @ConfigurationManager.AppSettings["Article_File"].ToString() + "100_100_" + pic;//删除缩略图
                    CommonMethod.FilePicDelete(strPath);

                    Response.Redirect(Request.Url.ToString());//刷新当前页
                }
                else
                {
                    InText.AlertAndRedirect("删除失败，请重试！", Request.Url.ToString());//刷新当前页
                }

            }
        }

        //删除一张图片
        private bool DeleteOnePic(int pic_id)
        {
            string sql = "delete from t_article_pic where id=" + pic_id;
            return artBll.ExecuteSQLNonquery(sql);
        }
    }
}
