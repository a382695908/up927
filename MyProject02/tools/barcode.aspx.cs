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
using System.Drawing.Imaging;
using ThoughtWorks;
using ThoughtWorks.QRCode;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;
using System.Drawing;
using WebBasic.Info;
using WebBasic.Text;
using System.Text;

namespace MyProject02.tools
{
    public partial class barcode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //生成二维码按钮
        protected void imgBtnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            string content = InText.SafeStr(this.textContent.Value);//
            int size = Convert.ToInt32(this.ddlSize.SelectedValue);
            size = size * 3;

            if (content.Trim() != "")
            {
                create_two(content, size);
            }
        }

        private void create_two(string nr, int size)
        {
            Bitmap bt;
            string enCodeString = nr;
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            //字符串较长的情况下，用ThoughtWorks.QRCode生成二维码时出现“索引超出了数组界限”的错误。
            //解决方法：将 QRCodeVersion 改为0。
            qrCodeEncoder.QRCodeVersion = 0;
            qrCodeEncoder.QRCodeScale = size;//二维码大小级别：1级最小22*22像素，每级递增21像素，例如：2级为43*43
            qrCodeEncoder.Encode(enCodeString, Encoding.UTF8);
            bt = qrCodeEncoder.Encode(enCodeString, Encoding.UTF8);
            string filename = "aa";
            filename = filename.Replace(" ", "");
            filename = filename.Replace(":", "");
            filename = filename.Replace("-", "");
            filename = filename.Replace(".", "");
            bt.Save(Server.MapPath("~/images/user2/") + filename + ".jpg");
            this.imgCode.Src = "~/images/user2/" + filename + ".jpg";
            this.imgCode.Visible = true;
        }

    }
}
