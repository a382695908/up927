<%@ WebHandler  Language="C#"  Class="getContent" %>
using System;
using System.Web;

public class getContent : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/html";

        //��ȡ����
        string content = context.Request.Form["myEditor"];


        //�������ݿ������������
        //-------------

        //��ʾ


        context.Response.Write("<script src='../third-party/jquery.min.js'></script>");
        context.Response.Write("<script src='../third-party/mathquill/mathquill.min.js'></script>");
        context.Response.Write("<link rel='stylesheet' href='../third-party/mathquill/mathquill.css'/>");
        context.Response.Write("<div class='content'>" + content + "</div>");

    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}