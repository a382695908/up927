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
using MyProject02.App_Code;

namespace MyProject02.ttt
{
    public partial class test001 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id_show = CommonMethod.GetIDEncrypt(33);//对ID进行加密
        }
    }
}
