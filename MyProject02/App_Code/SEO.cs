using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;
using System.Text;
using System.Data.SqlClient;
using BLL;
using WebBasic.Info;
using WebBasic.Text;
using System.Configuration;
using System.Text.RegularExpressions;
using MyProject02.App_Code;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyProject02.App_Code
{
    public class SEO
    {
        ArtBll artBll = new ArtBll();

        //推送百度
        public string TS_baidu(int article_id, string html)
        {
            string resultStr = "";

            string[] result = { "-1", "尚未执行" };//执行结果

            string param = "http://www.up927.com" + html + " \n " + "http://www.up927.com/wap" + html;
            string aaa = new Http().Post(string.Format("http://data.zz.baidu.com/urls?site=www.up927.com&token={0}", "UO50AFeBnZc5cFdy"), param);
            JObject jo = JObject.Parse(aaa);
            result = jo.Properties().Select(item => item.Value.ToString()).ToArray();

            if (aaa.Contains("success"))
            {
                resultStr = "推送成功！ " + result[0] + " " + result[1];

                //更新文章的百度推送状态
                artBll.ExecuteSQLNonquery("update t_article set ts_baidu=1 where id=" + article_id);
            }
            else //提交失败，显示错误原因
            {
                resultStr = BaiduResult(Utils.CheckInt(result[0]), result[1]);
            }
            return resultStr;
        }

        private string BaiduResult(int error, string message)
        {
            string resultStr = "";
            if (error == 400)
            {
                if (message == "site error")
                {
                    resultStr="站点未在站长平台验证";
                }
                else if (message == "empty content")
                {
                    resultStr="post内容为空";
                }
                else if (message == "only 2000 urls are allowed once")
                {
                    resultStr="每次最多只能提交2000条链接";
                }
                else if (message == "over quota")
                {
                    resultStr="超过每日配额了，超配额后再提交都是无效的";
                }
            }
            else if (error == 401)
            {
                if (message == "token is not valid")
                {
                    resultStr="token错误";
                }
            }
            else if (error == 404)
            {
                if (message == "not found")
                {
                    resultStr="接口地址填写错误";
                }
            }
            else if (error == 500)
            {
                if (message == "internal error, please try later")
                {
                    resultStr="服务器偶然异常，通常重试就会成功";
                }
            }
            return resultStr;
        }

    }
}
