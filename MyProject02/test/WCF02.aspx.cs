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
using System.IO;
using WebBasic.Info;
using WebBasic.Text;

namespace MyProject02.test
{
    public partial class WCF02 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //上传按钮
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //http://localhost:5750/Upload.svc
            
            ServiceReference1.UploadClient client = new MyProject02.ServiceReference1.UploadClient();
            ServiceReference1.FileUploadMessage message = new ServiceReference1.FileUploadMessage();
            message.FileName = FileUpload1.FileName;
            message.SavePath = @"D:\kkk\";
            message.FileData = FileUpload1.FileContent;

            ServiceReference1.IUpload channel = client.ChannelFactory.CreateChannel();

            ServiceReference1.UploadResultMessage resultMessage = new MyProject02.ServiceReference1.UploadResultMessage();
            resultMessage=channel.UploadFile(message);

            if (resultMessage.UploadResult == "1")
            {
                InText.Alert("上传成功！");
            }
        }


    }
}
