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
       // if (!Directory.Exists(path))   //�ж��ļ����Ƿ����
       // {
       //     Directory.CreateDirectory(path);
       // }
       // context.Response.ContentEncoding = System.Text.Encoding.UTF8;
       // //�ϴ�����
       // string picpath = "E:/HexilaiProject/HXLWeb/images/upload/"; //"E:/��ϲ��/hexilai/Web/images/uploadPic/";//
       ////string pathbase = HttpContext.Current.Server.MapPath(picpath);//����·��
       //// string pathbase = "/UpLoad/images/";//����·��
       // int size = 2;                     //�ļ���С����,��λmb                                                                                   //�ļ���С���ƣ���λKB
       // string[] filetype = { ".gif", ".png", ".jpg", ".jpeg", ".bmp" };                    //�ļ������ʽ

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
       //      //��ʽ��֤
       //      if (Array.IndexOf(filetype, fileExt) == -1)
       //      {
       //          state = "��������ļ�����";
       //      }
       //      //��С��֤
       //      if (uploadFile.ContentLength >= (size * 1024 * 1024))
       //      {
       //          state = "�ļ���С������վ����";
       //      }
       //      //����ͼƬ
       //      if (state == "SUCCESS")
       //      {
       //          uploadFile.SaveAs(picpath + newFileName);
       //          URL = newFileName;
       //      }
       //  }
       //  catch (Exception e)
       //  {
       //      state = "δ֪��1";//e.Message.ToString();//"δ֪����";
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