using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BLL;
using WebBasic;
using WebBasic.Text;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;

namespace MyProject02.App_Code
{
    public class CommonMethod
    {

        #region 判断上传文件是不是允许的格式
        /// <summary>
        /// 判断上传文件是不是允许的格式
        /// </summary>
        /// <param name="fu">上传控件ID名称</param>
        /// <param name="fileEx">允许的文件格式.jpg,.gif</param>
        /// <returns>true：允许;false:不允许</returns>
        public static bool IsAllowedExtension(FileUpload fu)
        {
            int fileLen = fu.PostedFile.ContentLength;
            //如果客户端传的文件大小为0，则直接返回false
            if (fileLen == 0)
            {
                return false;
            }
            byte[] imgArray = new byte[fileLen];
            fu.PostedFile.InputStream.Read(imgArray, 0, fileLen);
            MemoryStream ms = new MemoryStream(imgArray);
            BinaryReader br = new BinaryReader(ms);
            string fileclass = "";
            byte buffer;
            try
            {
                buffer = br.ReadByte();
                fileclass = buffer.ToString();
                buffer = br.ReadByte();
                fileclass += buffer.ToString();
            }
            catch
            {
            }
            finally
            {
                br.Close();
                ms.Close();
            }
            FileExtension[] fileEx = { FileExtension.GIF, FileExtension.JPG, FileExtension.PNG };
            foreach (FileExtension fe in fileEx)
            {
                if (Int32.Parse(fileclass) == (int)fe)
                {
                    return true;
                }
            }
            return false;
        }

        private enum FileExtension
        {
            JPG = 255216,
            GIF = 7173,
            BMP = 6677,
            PNG = 13780,
            //EXE = 7790,
            //DLL = 7790,
            //RAR = 8297,
            //XML = 6063,
            //HTML= 6063,
            //ASPX= 239187,
            //CS  = 117115,
            //CSS = 1310,
            //JS  = 119105,
            //TXT = 210187,
            //SQL = 255254  
        }
        #endregion

        #region 生成缩略图方法
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>    
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            if (ow >= oh)
            {
                mode = "W";
            }
            else
            {
                mode = "H";
            }

            //double ratio = originalImage.Width / originalImage.Height;//长宽比例
            //if (ratio >= 1)
            //{

            //    toheight = 100;
            //    mode = "W";
            //}
            //else if (ratio < 1)
            //{
            //    towidth = 100;
            //    mode = "H";
            //}


            switch (mode)
            {
                case "HW"://指定高宽缩放（可能变形）                
                    break;
                case "W"://指定宽，高按比例                    
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H"://指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut"://指定高宽裁减（不变形）                
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }

            if (mode == "W" || mode == "H")
            {
                if (toheight > height)
                {
                    toheight = height;
                    towidth = originalImage.Width * height / originalImage.Height;
                }
                else if (towidth > width)
                {
                    towidth = width;
                    toheight = originalImage.Height * width / originalImage.Width;
                }
            }

            //if (width == 100)
            //{
            //    Double imgZise = Convert.ToDouble(originalImage.Width) / Convert.ToDouble(originalImage.Height);
            //    Double size = Convert.ToDouble(100) / Convert.ToDouble(100);

            //    //InText.Alert(imgZise + " " + size);
            //    if (imgZise > size)
            //    {
            //        towidth = 110055;
            //        toheight = (originalImage.Height * 100) / originalImage.Width;
            //    }
            //    else if (imgZise == size)
            //    {
            //        towidth = 100;
            //        toheight = 100;
            //    }
            //    else
            //    {
            //        toheight = 100;
            //        towidth = (originalImage.Width * 100) / originalImage.Height;
            //    }
            //}

            if (width == 150)
            {
                Double imgZise = Convert.ToDouble(originalImage.Width) / Convert.ToDouble(originalImage.Height);
                Double size = Convert.ToDouble(150) / Convert.ToDouble(85);

                //InText.Alert(imgZise + " " + size);
                if (imgZise > size)
                {
                    towidth = 150;
                    toheight = (originalImage.Height * 150) / originalImage.Width;
                }
                else if (imgZise == size)
                {
                    towidth = 150;
                    toheight = 150;
                }
                else
                {
                    toheight = 150;
                    towidth = (originalImage.Width * 150) / originalImage.Height;
                }
            }

            if (ow <= towidth && oh <= toheight)//原始图片长度、宽度均小于设定长度、宽度，不裁剪大小，直接生成原图尺寸
            {
                towidth = ow;
                toheight = oh;
            }
            

            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            g.Clear(System.Drawing.Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
                new System.Drawing.Rectangle(x, y, ow, oh),
                System.Drawing.GraphicsUnit.Pixel);

            try
            {
                string aLastName = thumbnailPath.Substring(thumbnailPath.LastIndexOf(".") + 1, (thumbnailPath.Length - thumbnailPath.LastIndexOf(".") - 1));//扩展名
                if (aLastName.Trim().ToLower() == "gif")
                {
                    //以Gif格式保存缩略图
                    bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Gif);
                }
                else
                {
                    //以jpg格式保存缩略图
                    bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }



        //public static void MakeThumbnail(string sourceImagePath, string thumbnailPath, int width, int height, string mode)
        //{
        //    Image originalImage = Image.FromFile(sourceImagePath);
        //    int x = 0;
        //    int y = 0;
        //    int ow = originalImage.Width;
        //    int oh = originalImage.Height;
        //    switch (mode)
        //    {
        //        // 指定高寬縮放（可能變形）
        //        case "HW":
        //            break;
        //        // 指定寬度，高度按比例
        //        case "W":
        //            height = originalImage.Height * width / originalImage.Width;
        //            break;
        //        // 指定高度，寬度按比例
        //        case "H":
        //            width = originalImage.Width * height / originalImage.Height;
        //            break;
        //        //指定高寬裁減（不變形）
        //        case "CUT":
        //            if (((double)originalImage.Width) / originalImage.Height > ((double)width) / height)
        //            {
        //                oh = originalImage.Height;
        //                ow = originalImage.Height * width / height;
        //                y = 0;
        //                x = (originalImage.Width - ow) / 2;
        //            }
        //            else
        //            {
        //                ow = originalImage.Width;
        //                oh = originalImage.Width * height / width;
        //                x = 0;
        //                y = (originalImage.Height - oh) / 2;
        //            }
        //            break;
        //        default:
        //            break;
        //    }
        //    Image bitmap = new Bitmap(width, height);
        //    Graphics g = Graphics.FromImage(bitmap);
        //    g.InterpolationMode = InterpolationMode.High;
        //    g.SmoothingMode = SmoothingMode.HighQuality;
        //    g.Clear(Color.Transparent);
        //    g.DrawImage(originalImage, new Rectangle(0, 0, width, height), new Rectangle(x, y, ow, oh), GraphicsUnit.Pixel);
        //    bitmap.Save(thumbnailPath, ImageFormat.Png);
        //}
        #endregion

        #region 返回身份证号格式：3723 2319 8810 1012 85
        /// <summary>
        /// 返回身份证号格式：3723 2319 8810 1012 85 
        /// </summary>
        /// <param name="IdNum"></param>
        /// <returns></returns>
        public static string IdNumFormat(string IdNum)
        {
            //372323 1988 1010 1285 
            string returnStr = "";
            if (IdNum != "")
            {
                returnStr += IdNum.Substring(0, 6);
                returnStr += " " + IdNum.Substring(6, 4);
                returnStr += " " + IdNum.Substring(10, 4);
                returnStr += " " + IdNum.Substring(14, 4);
            }
            /*for (int i = 0; i < IdNum.Length; i++)
            {
                if (i % 4 == 0 && i != 0)
                {
                    returnStr += " " + IdNum.Substring(i, 1);
                }
                else
                {
                    returnStr += IdNum[i];
                }

            }*/
            return returnStr;
        }
        #endregion

        #region 返回手机号格式：131 1234 5678
        /// <summary>
        /// 返回手机号格式：131 1234 5678
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public static string MobileFormat(string mobile)
        {
            //131 1234 5678
            string returnStr = "";
            for (int i = 0; i < mobile.Length; i++)
            {
                if (i == 3 || i == 7)
                {
                    returnStr += " " + mobile.Substring(i, 1);
                }
                else
                {
                    returnStr += mobile[i];
                }

            }
            return returnStr;
        }
        #endregion

        #region 返回银行卡号格式：3723 2319 8810 1012 85

        /// <summary>
        /// 返回银行卡号格式：3723 2319 8810 1012 85 
        /// </summary>
        /// <param name="IdNum"></param>
        /// <returns></returns>
        public static string IdNumFormat_Bank(string IdNum)
        {
            //3723 2319 8810 1012 85 
            string returnStr = "";
            for (int i = 0; i < IdNum.Length; i++)
            {
                if (i % 4 == 0 && i != 0)
                {
                    returnStr += " " + IdNum.Substring(i, 1);
                }
                else
                {
                    returnStr += IdNum[i];
                }

            }
            return returnStr;
        }
        #endregion

        #region 返回人物姓名格式：王**

        /// <summary>
        /// 返回人物姓名格式：王**
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string NameFormat(string name)
        {
            string returnStr = "";
            returnStr = name.Substring(0, 1);
            for (int i = 0; i < name.Length - 1; i++)
            {
                returnStr += "*";
            }
            return returnStr;
        }
        #endregion

        #region 截取字符串长度

        /// <summary>
        /// 截取字符串长度
        /// </summary>
        /// <param name="s">输入的字符串</param>
        /// <param name="len">要截取的汉字长度</param>
        /// <returns></returns>
        public static string GetStringByLenth(string s, int len)
        {
            string temp = s;
            if (ASCIIEncoding.Default.GetByteCount(temp) > len * 2)
            {
                for (int i = temp.Length; i >= 0; i--)
                {
                    temp = temp.Substring(0, i);
                    //双字符正则表达式写法[^\x00-\xff]
                    if (Regex.Replace(temp, @"[^\x00-\xff]", "zz").Length <= len * 2)
                    {
                        break;
                    }
                }
            }
            return temp;
        }


        public static string GetStringByLenth(string s, int len, bool ifP)
        {
            string temp = s;
            if (ASCIIEncoding.Default.GetByteCount(temp) > len * 2)
            {
                for (int i = temp.Length; i >= 0; i--)
                {
                    temp = temp.Substring(0, i);
                    //双字符正则表达式写法[^\x00-\xff]
                    if (Regex.Replace(temp, @"[^\x00-\xff]", "zz").Length <= len * 2)
                    {
                        if (ifP)
                        {
                            temp += "...";
                        }
                        break;
                    }
                }
            }
            return temp;
        }
        #endregion

        #region 验证是否日期

        /// <summary>
        /// 验证是否日期
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsDateTime(string source)
        {
            try
            {
                DateTime time = Convert.ToDateTime(source);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 根据条件生成新DataTable

        /// <summary>
        /// 根据条件生成新DataTable
        /// </summary>
        /// <param name="dt">源DataTable</param>
        /// <param name="condition">条件字符串，如"company_id>0"</param>
        /// <returns></returns>
        public static DataTable GetNewDataTable(DataTable dt, string condition)
        {
            DataTable newdt = new DataTable();
            newdt = dt.Clone();
            DataRow[] dr = dt.Select(condition);
            for (int i = 0; i < dr.Length; i++)
            {
                newdt.ImportRow((DataRow)dr[i]);
            }
            return newdt;//返回的查询结果
        }
        #endregion

        #region 去除数组中的空值

        public static string[] GetArrayNoEmpty(string[] array)
        {
            ArrayList al = new ArrayList();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != string.Empty)
                    al.Add(array[i]);
            }

            string[] str2 = new string[al.Count];
            for (int i = 0; i < str2.Length; i++)
            {
                str2[i] = (string)al[i];
            }

            return str2;
        }
        #endregion

        #region 删除文件
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool FilePicDelete(string path)
        {
            bool ret = false;
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
                ret = true;
            }
            return ret;
        }
        #endregion

        #region 参数加密、解密

        /// <summary>
        /// 对参数进行加密
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static string GetIDEncrypt(int p)
        {
            Random r = new Random();
            return (p ^ 337).ToString() + r.Next(100, 999).ToString();
        }

        /// <summary>
        /// 对参数进行解密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int GetIDDecrypt(string str)
        {
            string t = Regex.Replace(str, @"\D", "", RegexOptions.IgnoreCase);
            if (t.Length > 3)
            {
                t = t.Substring(0, t.Length - 3);
                if (t.Length > 9)
                {
                    t = t.Substring(0, 9);
                }
            }
            return Convert.ToInt32((Convert.ToInt32(t) ^ 337).ToString());
        }
        #endregion

        #region 生成PC版静态页

        public static bool CreateArticleHtml(int art_id, string title, string title1, string source, int articleType, string articleTypeName, string content, string keyword, string imgUrl, string article_html, string tag, string tagId, string tagIdHtml, string update_date, string last_html, string last_title, string next_html, string next_title, string search_keyword)
        {
            Hashtable artHt = new Hashtable();
            artHt.Add("$title", title);//
            artHt.Add("$titl_e1", title1);//
            if (source.Trim() == "")
            {
                //source = "<a href='http://www.up927.com/' target='_blank' title='好宝宝早教网_" + articleTypeName + "'>好宝宝早教网</a>";
                source = "毛豆妈咪";
            }
            artHt.Add("$source", source);//
            artHt.Add("$articleType", articleType);//
            artHt.Add("$article_TypeName", articleTypeName);//articleTypeName
            artHt.Add("$content", content);//
            artHt.Add("$keyword", keyword);//
            //artHt.Add("$tag", tag);
            artHt.Add("$update_date", update_date);

            artHt.Add("$last_html", last_html);
            artHt.Add("$last_title", last_title);
            artHt.Add("$next_html", next_html);
            artHt.Add("$next_title", next_title);

            if (search_keyword.Trim() != "")
            {
                string tagStr = "";
                string[] array = search_keyword.Split(' ');
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].Trim() != "")
                    {
                        tagStr += "<a href='/list.aspx?title=" + System.Web.HttpUtility.UrlEncode(array[i]) + "' target='_blank'>" + array[i] + "</a>&nbsp;&nbsp;";//<a href="#" target="_blank">温州人</a>
                    }
                }
                artHt.Add("$search_keyword", "<div class='zx_tag' align='left'>相关搜索：" + tagStr + "</div>");
                //artHt.Add("$search_keyword", search_keyword);
            }
            else
            {
                artHt.Add("$search_keyword", "");
            }

            if (tag.Trim() != "")
            {
                string tagStr = "";
                string[] array = tag.Split(' ');
                string[] arrayId = CommonMethod.GetArrayNoEmpty(tagId.Split(','));
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].Trim() != "")
                    {
                        tagStr += "<a href='/list.aspx?tag=" + arrayId[i] + "' target='_blank'>" + array[i] + "</a>&nbsp;";//<a href="#" target="_blank">温州人</a>
                    }
                }
                artHt.Add("$tag", "<div class='zx_tag' align='left'>标签：" + tagStr + "</div>");
                artHt.Add("$xiangguanShow", "");//显示相关文章
            }
            else
            {
                artHt.Add("$tag", "");
                artHt.Add("$xiangguanShow", "none");////隐藏相关文章
            }
            if (tagIdHtml.Trim() != "")
            {
                artHt.Add("$_tagUrl", "/tag/" + tagIdHtml + ".html");//<!--#include file="$_tagUrl"-->  "<!--#include file='/tag/" + tagIdHtml + ".html'-->"
            }
            else
            {
                artHt.Add("$_tagUrl", "/tag/0.html");//无相关文章，引用页为无内容
            }


            //if (imgUrl.Trim() != "")
            //{
            //    artHt.Add("$imgStr", "<img src='/Article_File/" + imgUrl + "'/>");//
            //}
            //else
            //{
            //    artHt.Add("$imgStr", "");//
            //}

            //模版文件 存放路径
            string sourceFilePath = HttpRuntime.AppDomainAppPath.ToString() + "/template/detail_2.html";

            //生成后文件 存放的 路径
            string spanFilePath = HttpRuntime.AppDomainAppPath.ToString();

            CommonMethod cm = new CommonMethod();
            return cm.WriteHTML(artHt, sourceFilePath, spanFilePath, article_html);  //生成静态页
        }
        #endregion 

        #region 生成wap版静态页

        public static bool CreateArticleHtml_Wap(int art_id, string title, string title1, string source, int articleType, string articleTypeName, string content, string keyword, string imgUrl, string article_html, string tag, string tagId, string tagIdHtml, string search_keyword)
        {
            Hashtable artHt = new Hashtable();
            artHt.Add("$title", title);//
            artHt.Add("$titl_e1", title1);//
            artHt.Add("$source", source);//
            artHt.Add("$articleType", articleType);//
            artHt.Add("$article_TypeName", articleTypeName);//
            artHt.Add("$content", content);//
            artHt.Add("$keyword", keyword);//

            if (imgUrl.Trim() != "" && !content.Contains("<img"))
            {
                artHt.Add("$imgStr", "<img src='/Article_File/af/" + imgUrl + "'/>");//
            }
            else
            {
                artHt.Add("$imgStr", "");//
            }

            if (tag.Trim() != "")
            {
                string tagStr = "";
                string[] array = tag.Split(' ');
                string[] arrayId = CommonMethod.GetArrayNoEmpty(tagId.Split(','));
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].Trim() != "")
                    {
                        tagStr += "<a href='/wap/list.aspx?tag=" + arrayId[i] + "'>" + array[i] + "</a>&nbsp;&nbsp;";//<a href="#" target="_blank">温州人</a>
                    }
                }
                artHt.Add("$tag", "<div class='div_tag'>标签：" + tagStr + "</div>");//<div class="div_tag">标签：<a href="#">妈咪日记</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="#">青岛母婴用品</a></div>
                artHt.Add("$xiangguanShow", "");//显示相关文章
            }
            else
            {
                artHt.Add("$tag", "");
                artHt.Add("$xiangguanShow", "none");////隐藏相关文章
            }
            if (tagIdHtml.Trim() != "")
            {
                artHt.Add("$_tagUrl", "/tag/" + tagIdHtml + ".html");//<!--#include file="$_tagUrl"-->  "<!--#include file='/tag/" + tagIdHtml + ".html'-->"
            }
            else
            {
                artHt.Add("$_tagUrl", "/tag/0.html");//无相关文章，引用页为无内容
            }

            //模版文件 存放路径
            string sourceFilePath = HttpRuntime.AppDomainAppPath.ToString() + "/wap/article/content1.html"; 

            //生成后文件 存放的 路径
            string spanFilePath = HttpRuntime.AppDomainAppPath.ToString() + "\\wap";

            CommonMethod cm = new CommonMethod();
            return cm.WriteHTML(artHt, sourceFilePath, spanFilePath, article_html);  //生成wap静态页
        }
        #endregion

        public static void CreateOneArticleHtml(int article_id)
        {
            ArtBll artBll = new ArtBll();
            if (article_id > 0)
            {
                

//                string sql = @"Select t_article.id as articleId,t_article.title,t_article.title1,t_article.source,t_article.keyword,t_article.daoyu,t_article.content,
//                            t_article.type,t_article.update_date,t_article.declare_mark,t_article.pic as artPic,t_article.html,t_article.remark,
//                            t_article_type.id as type_id,t_article_type.type_name,tag,t_article.tag_id
//                            FROM t_article  LEFT JOIN t_article_type ON t_article.type=t_article_type.id 
//                            WHERE t_article.id=" + article_id;

                string sql = @"Select t_article.id as articleId,t_article.title,t_article.title1,t_article.source,t_article.keyword,t_article.daoyu,t_article.content,t_article.type,t_article.update_date,t_article.declare_mark,t_article.pic as artPic,t_article.html,t_article.remark,t_article.last_id,t_article.next_id,
                            t_article1.html AS last_html,t_article1.title AS last_title,t_article2.html AS next_html,t_article2.title AS next_title,
                            t_article_type.id as type_id,t_article_type.type_name,t_article.tag,t_article.tag_id,t_article.search_keyword
                            FROM (((t_article  
                            LEFT JOIN t_article_type ON (t_article.type=t_article_type.id) )
                            LEFT JOIN t_article t_article1 ON (t_article.last_id=t_article1.id) )
                            LEFT JOIN t_article t_article2 ON (t_article.next_id=t_article2.id))
                            WHERE t_article.id=" + article_id;

                DataTable dt = artBll.SelectToDataTable(sql);
                if (dt.Rows.Count > 0)
                {

                    //articleId = Convert.ToInt32(dt.Rows[i]["id"]);
                    //string article_html = dt.Rows[i]["html"].ToString();
                    //this.CteateHTML(url + "/article/content.aspx?pc=" + pc + "&a_id=" + articleId, staticPath, article_html);
                    int articleId = Convert.ToInt32(dt.Rows[0]["articleId"]);
                    string title = dt.Rows[0]["title"].ToString();
                    string title1 = dt.Rows[0]["title1"].ToString();
                    string source = dt.Rows[0]["source"].ToString();
                    int articleType = Convert.ToInt32(dt.Rows[0]["type_id"]);
                    string articleTypeName = dt.Rows[0]["type_name"].ToString();
                    string content = dt.Rows[0]["content"].ToString();
                    string keyword = dt.Rows[0]["keyword"].ToString();
                    string search_keyword = dt.Rows[0]["search_keyword"].ToString();
                    string artPic = dt.Rows[0]["artPic"].ToString();
                    string article_html = dt.Rows[0]["html"].ToString();
                    string tagStr = dt.Rows[0]["tag"].ToString();
                    string tagIdHtml = dt.Rows[0]["tag_id"].ToString();
                    string update_date = Convert.ToDateTime(dt.Rows[0]["update_date"]).ToString("yyyy年M月d日");
                    string tag_id = dt.Rows[0]["tag_id"].ToString();

                    if (tagIdHtml.Trim() != "")
                    {
                        string[] tagArray = tagIdHtml.Split(',');
                        for (int j = 0; j < tagArray.Length; j++)
                        {
                            if (tagArray[j].Trim() != "" && tagArray[j].Trim() != ",")
                            {
                                tagIdHtml = tagArray[j].Trim();
                                break;
                            }
                        }
                    }

                    string last_title = "上一篇：" + dt.Rows[0]["last_title"].ToString();
                    string last_html = dt.Rows[0]["last_html"].ToString();
                    string next_title = "下一篇：" + dt.Rows[0]["next_title"].ToString();
                    string next_html = dt.Rows[0]["next_html"].ToString();

                    //生成静态页
                    CommonMethod.CreateArticleHtml(articleId, title, title1, source, articleType, articleTypeName, content, keyword, artPic, article_html, tagStr, tag_id, tagIdHtml, update_date, last_html, last_title, next_html, next_title, search_keyword);

                }
            }
        }


        #region 根据模板重点标签，替换生成静态页

        public bool WriteHTML(Hashtable Content, String sourceFilePath, String spanFilePath, String fileName)  //生成静态页面
        {
            bool isok = false;
            Encoding code = Encoding.GetEncoding("utf-8"); //设置文件编码

            String temp = sourceFilePath; //获取模板文件 绝对路径

            StreamReader sr = null;
            StreamWriter sw = null;

            String str = "";
            try
            {
                sr = new StreamReader(temp, code);
                str = sr.ReadToEnd(); // 读取文件
                sr.Close();
            }
            catch (Exception exp)
            {
                HttpContext.Current.Response.ContentEncoding = code;
                HttpContext.Current.Response.Write(exp.Message);
                HttpContext.Current.Response.End();
                sr.Close();
            }
            String htmlFileNme = fileName;
            //替换模板页中的内容
            foreach (DictionaryEntry de in Content)  //循环遍历
            {
                str = str.Replace(de.Key.ToString(), de.Value.ToString());
            }

            string createFilePath = spanFilePath;
            if (!Directory.Exists(createFilePath))    //判断文件夹是否存在 不存在
            {
                Directory.CreateDirectory(createFilePath);
            }

            // 写文件
            try
            {
                sw = new StreamWriter(createFilePath+htmlFileNme, false, code);
                sw.Write(str);
                sw.Flush();
                isok = true;
            }
            catch (Exception ex)
            {
                isok = false;
            }
            finally
            {
                sw.Close();
            }

            return isok;
        }
        #endregion

        #region 动态页生成静态页html

        public static bool CteateHTML(string strurl, string path, string html)
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
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "key", "<script type=\"text/javascript\">showResult('静态页未生成，请登录后重新操作！',false)</script>", false);
                return false;
            }
            else
            {
                System.Text.UTF8Encoding utf8=new System.Text.UTF8Encoding(false);

                //sw = new StreamWriter(savefile, false, System.Text.Encoding.GetEncoding("utf-8"));
                sw = new StreamWriter(savefile, false, utf8);
                sw.WriteLine(strHtml);
                sw.Flush();
                sw.Close();
                return true;
            }
        }
        #endregion

        #region 生成标签静态页

        public static bool CteateTag(DataTable dtTag, string htmlFileNme)
        {
            string strHtml = "";
            if (dtTag.Rows.Count > 0)
            {
                for (int i = 0; i < dtTag.Rows.Count; i++)
                {
                    strHtml += "<li><a href='" + dtTag.Rows[i]["html"].ToString() + "' title='" + dtTag.Rows[i]["title"].ToString() + "' target='_blank'>" + GetStringByLenth(dtTag.Rows[i]["title"].ToString(), 33) + "</a></li>\n";
                }
            }

            //生成后文件 存放的 路径
            string spanFilePath = HttpRuntime.AppDomainAppPath.ToString();
            if (!Directory.Exists(spanFilePath))//判断文件夹是否存在 不存在
            {
                Directory.CreateDirectory(spanFilePath);
            }
           
            StreamWriter sw;
            sw = new StreamWriter(spanFilePath + htmlFileNme, false, System.Text.Encoding.GetEncoding("utf-8"));
            sw.WriteLine(strHtml);
            sw.Flush();
            sw.Close();
            return true;
        }
        #endregion

        public static void ValidUrl()
        {
            HttpRequest request = HttpContext.Current.Request;
            string result = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(result)) 
            { 
                result = request.UserHostAddress;
            }
            if (result == "124.202.140.214")
            {
                HttpContext.Current.Response.Redirect("http://www.up927.com/");
            }
        }

        #region 返回访客IP

        public static string GetIp()
        {
            HttpRequest request = HttpContext.Current.Request;
            string result = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            result = request.UserHostAddress;
            return result;
        }
        #endregion



    }
}
