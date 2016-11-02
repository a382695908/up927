<%@ WebHandler Language="C#" Class="imageUp" %>
using System;
using System.Web;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class imageUp : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
       // string path = HttpRuntime.AppDomainAppPath.ToString() + "/Article_File/af/";//"E://HexilaiProject/";
       // if (!Directory.Exists(path))   //判断文件夹是否存在
       // {
       //     Directory.CreateDirectory(path);
       // }
       // context.Response.ContentEncoding = System.Text.Encoding.UTF8;
       // //上传配置
       // string picpath = "E:/HexilaiProject/HXLWeb/images/upload/"; //"E:/贺喜来/hexilai/Web/images/uploadPic/";//
       ////string pathbase = HttpContext.Current.Server.MapPath(picpath);//保存路径
       //// string pathbase = "/UpLoad/images/";//保存路径
       // int size = 2;                     //文件大小限制,单位mb                                                                                   //文件大小限制，单位KB
       // string[] filetype = { ".gif", ".png", ".jpg", ".jpeg", ".bmp" };                    //文件允许格式

       // string callback = context.Request["callback"];
       // string editorId = context.Request["editorid"];
       // HttpPostedFile uploadFile = context.Request.Files[0];
       // string fileName = context.Request.Files[0].FileName;
        
       //  string[] temp = fileName.Split('.');
       //  string fileExt = "." + temp[temp.Length - 1].ToLower();
       //  string newFileName=System.Guid.NewGuid().ToString("N") + fileExt;
       //  string state = "SUCCESS";
       //  string URL = "";
       //  try
       //  {
       //      //格式验证
       //      if (Array.IndexOf(filetype, fileExt) == -1)
       //      {
       //          state = "不允许的文件类型";
       //      }
       //      //大小验证
       //      if (uploadFile.ContentLength >= (size * 1024 * 1024))
       //      {
       //          state = "文件大小超出网站限制";
       //      }
       //      //保存图片
       //      if (state == "SUCCESS")
       //      {
       //          uploadFile.SaveAs(picpath + newFileName);
       //          URL = newFileName;
       //      }
       //  }
       //  catch (Exception e)
       //  {
       //      state = "未知错1";//e.Message.ToString();//"未知错误";
       //      URL = "";
       //  }

       //  string json = "{\"originalName\":\"" + fileName + "\",\"name\":\"" + newFileName + "\",\"url\":\"" + URL + "\",\"size\":\"" + uploadFile.ContentLength.ToString() + "\",\"state\":\"" + state + "\",\"type\":\"" + fileExt + "\"}";
       //  /*StreamWriter swhot = new StreamWriter(path + "1.txt", true, System.Text.Encoding.GetEncoding("gb2312"));
       //  swhot.Write(json + "\r\n");
       //  swhot.Flush();
       //  swhot.Close();*/
       //  context.Response.ContentType = "text/html";
     
       //  if (callback != null)
       //  {
       //      context.Response.Write(String.Format("<script>{0}(JSON.parse(\"{1}\"));</script>", callback, json));
       //  }
       //  else
       //  {
       //      context.Response.Write(json);
       //  }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}