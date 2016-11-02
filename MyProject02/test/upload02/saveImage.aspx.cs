using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using WebBasic.Info;
using WebBasic.Text;
using System.IO;

//namespace MyProject02.test.upload02
//{
    public partial class saveImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["aaa"]))
            {
                string aa = Request.QueryString["aaa"].ToString();
            }
            //string fileName = "";
            //if (Request.Files.Count > 0)
            //{
            //    fileName = Request.Files[0].FileName;
            //    Request.Files[0].SaveAs(Server.MapPath("./") + "/temp/" + fileName);
            //}
            //else
            //{
            //    System.Drawing.Image img = System.Drawing.Image.FromStream(Request.InputStream);
            //    fileName = Request.Headers["fileName"];
            //    fileName = Server.UrlDecode(fileName);
            //    img.Save(Server.MapPath("./") + "/temp/" + fileName);
            //}
            //Response.Write("./temp/" + fileName);

            string fileName = "";
            if (Request.Files.Count > 0)
            {
                fileName = Request.Files[0].FileName;
                //Request.Files[0].SaveAs(Server.MapPath("./") + "/temp/" + fileName);

                Save(fileName, Request.Files[0].InputStream);
            }
            else
            {
                //System.Drawing.Image img = System.Drawing.Image.FromStream(Request.InputStream);
                fileName = Request.Headers["fileName"];
                fileName = Server.UrlDecode(fileName);
                //img.Save(Server.MapPath("./") + "/temp/" + fileName);
                
                Save2(fileName, Request.InputStream);

            }
            Response.Write(fileName + " 上传完毕a！");
        }


        private void Save(string fileName,Stream stream)
        {
            MyProject02.ServiceReference1.UploadClient client = new MyProject02.ServiceReference1.UploadClient();
            MyProject02.ServiceReference1.FileUploadMessage message = new MyProject02.ServiceReference1.FileUploadMessage();
            message.FileName = fileName;
            message.SavePath = "/userImages/";//@"D:\kkk\";
            message.FileData = stream;
            message.FileData.Position = 0;//必须将Position属性置为0，否则服务端接受后不能保存

            MyProject02.ServiceReference1.IUpload channel = client.ChannelFactory.CreateChannel();

            MyProject02.ServiceReference1.UploadResultMessage resultMessage = new MyProject02.ServiceReference1.UploadResultMessage();
            resultMessage = channel.UploadFile(message);

            //if (resultMessage.UploadResult == "1")
            //{
            //    InText.Alert("上传成功！");
            //}
        }

        private void Save2(string fileName, Stream stream)
        {
            MyProject02.ServiceReference2.UploadClient client = new MyProject02.ServiceReference2.UploadClient();
            MyProject02.ServiceReference2.FileUploadMessage message = new MyProject02.ServiceReference2.FileUploadMessage();
            message.FileName = fileName;
            message.SavePath = "/userImages/";//@"D:\kkk\";
            message.FileData = stream;
            message.FileData.Position = 0;//必须将Position属性置为0，否则服务端接受后不能保存

            MyProject02.ServiceReference2.IUpload channel = client.ChannelFactory.CreateChannel();

            MyProject02.ServiceReference2.UploadResultMessage resultMessage = new MyProject02.ServiceReference2.UploadResultMessage();
            resultMessage = channel.UploadFile(message);

            //if (resultMessage.UploadResult == "1")
            //{
            //    InText.Alert("上传成功！");
            //}
        }
    //}
}
