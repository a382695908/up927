<%@ WebHandler Language="C#" Class="rndcode" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

/// <summary>
/// ValidateImageHandler 生成网站验证码功能
/// </summary>
public class rndcode : IHttpHandler, IRequiresSessionState
{
    int intLength = 6;               //长度
    string strIdentify = "rndcode"; //随机字串存储键值，以便存储到Session中
    public rndcode()
	{
	}

    /// <summary>
    ///  生成验证图片核心代码
    /// </summary>
    /// <param name="hc"></param>
    public void ProcessRequest(HttpContext hc)
    {
        hc.Response.ContentType = "image/gif";
        hc.Response.Expires = -1;
        hc.Session.Remove(strIdentify);
        Bitmap b = new Bitmap(50, 20);
        Graphics g = Graphics.FromImage(b);
        g.FillRectangle(new SolidBrush(Color.LightYellow), 0, 0, 50, 20);
        g.DrawRectangle(new Pen(new SolidBrush(Color.LightSeaGreen)), 0, 0, 49, 19);
        //g.DrawEllipse(new Pen(Color.Red), 30, 10, 10, 10);
        Font font = new Font(FontFamily.GenericSerif, 18, FontStyle.Bold, GraphicsUnit.Pixel);
        Random r = new Random();

        //合法随机显示字符列表
        string strLetters = "0123456789";
        StringBuilder s = new StringBuilder();
        Color[] colors = new Color[] { Color.Violet, Color.OrangeRed, Color.Red, Color.Orange, Color.DarkRed, Color.Turquoise, Color.Tomato, Color.Teal, Color.SkyBlue };

        //将随机生成的字符串绘制到图片上
        for (int i = 0; i < 4; i++)
        {
            s.Append(strLetters.Substring(r.Next(0, strLetters.Length - 1), 1));
            g.DrawString(s[s.Length - 1].ToString(), font, new SolidBrush(colors[r.Next(8)]), i * 11, r.Next(0, 3));
        }
        //g.DrawString("mosicn", new Font(FontFamily.GenericSerif,4,FontStyle.Regular,GraphicsUnit.Pixel), new SolidBrush(colors[r.Next(8)]), r.Next(3,30), r.Next(6, 15));
        //生成干扰线条
        Pen pen = new Pen(new SolidBrush(Color.FromArgb(100, r.Next(0, 255), r.Next(0, 255), r.Next(0, 255))), 1);
        for (int i = 0; i < 10; i++)
        {
            g.DrawLine(pen, new Point(r.Next(0, 48), r.Next(0, 19)), new Point(r.Next(0, 48), r.Next(0, 19)));
        }
        b.Save(hc.Response.OutputStream, ImageFormat.Gif);
        if (string.IsNullOrEmpty(hc.Request.QueryString["ns"]))
        {
            hc.Session[strIdentify] = s.ToString().ToLower(); //先保存在Session中(小写)，验证与用户输入是否一致。
        }
        hc.Response.End();
        ////设置输出流图片格式
        //hc.Response.ContentType = "image/gif";
        
        
        //Bitmap b = new Bitmap(75, 20);
        //Graphics g = Graphics.FromImage(b);
        //g.FillRectangle(new SolidBrush(Color.FromArgb(38,106,182)), 0, 0, 100, 30);
        //Font font = new Font(FontFamily.GenericSerif, 15, FontStyle.Bold, GraphicsUnit.Pixel);
        //Random r = new Random();

        ////合法随机显示字符列表
        //string strLetters = "ABCDEFGHIJKMNPQRSTURWXYZ23456789";
        //StringBuilder s = new StringBuilder();
        
        
        ////将随机生成的字符串绘制到图片上
        //for (int i = 0; i < intLength; i++)
        //{
        //    s.Append(strLetters.Substring(r.Next(0, strLetters.Length - 1), 1));
        //    g.DrawString(s[s.Length - 1].ToString(), font, new SolidBrush(Color.White), i * 11, r.Next(0, 3));
        //}

        ////生成干扰线条
        //Pen pen = new Pen(new SolidBrush(Color.FromArgb(100,r.Next(0, 255), r.Next(0, 255), r.Next(0, 255))), 1);
        //for (int i = 0; i < 10; i++)
        //{
        //    g.DrawLine(pen, new Point(r.Next(0, 59), r.Next(0, 19)), new Point(r.Next(0, 59), r.Next(0, 19)));
        //}
        //b.Save(hc.Response.OutputStream, ImageFormat.Gif);
        //hc.Session[strIdentify] = s.ToString().ToLower(); //先保存在Session中(小写)，验证与用户输入是否一致。
        //hc.Response.End();
   
    }
    
    /// <summary>
    /// 表示此类实例是否可以被多个请求共用(重用可以提高性能)
    /// </summary>
    public bool IsReusable
    {
        get
        {
            return true;
        }
    }
    
}