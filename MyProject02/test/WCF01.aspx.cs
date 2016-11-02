using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;

namespace MyProject02.test
{
    public partial class WCF01 : System.Web.UI.Page
    {
        public string show = "";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ServiceReference1.UserClient client = new MyProject02.ServiceReference1.UserClient();
            string name = this.txtName.Text;
            string html = client.ShowNameString(name);
            JObject jo = JObject.Parse(html);
            string[] resultItem = jo.Properties().Select(item => item.Name.ToString()).ToArray();
            string[] resultValue = jo.Properties().Select(item => item.Value.ToString()).ToArray();
            show = resultValue[0];
        }


    }
}
