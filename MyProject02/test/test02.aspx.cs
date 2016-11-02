using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyProject02.test
{
    public partial class test02 : System.Web.UI.Page
    {
        delegate int del(int i);
        delegate bool com(string aa, int bb);
        delegate bool com1();
        delegate string write1(string s);

        protected void Page_Load(object sender, EventArgs e)
        {
            del myDel = x => x * x;
            int j = myDel(5);


            com delCom = (string x, int y) => x.Length > y;
            bool isOk= delCom("123",6);

            com1 delCom1 =() => 3 > 2;
            bool isOk1 = delCom1();

            write1 delWrite1 = (string fg) => { string s = fg; string a = "欢迎 " + s; return a; };
            string re=delWrite1("aaa");

            hello delHello=new hello(hello2);
            delHello += hello1;
            string bb= GetHello("liut",delHello);

            GetFunk();
        }

        private string GetHello(string name,hello delHello)
        {
            return delHello(name);
        }

        delegate string hello(string name);

        private string hello1(string name)
        {
            return "Hello "+name;
        }
        private string hello2(string name)
        {
            return "你好 "+name;
        }



        //private int GetChengfa(int x)
        //{
        //    return x => x * x;
        //}

        private void GetFunk()
        {
            Func<int, bool> myFunk = x => { if (x == 5) { return true; } else { return false; } };
            bool isOk = myFunk(5);

            int[] num = { 1, 2, 4, 5, 7, 8 };
            int aa = num.Count(n => n % 2 == 0);
            int[] bb = num.Where(n => n % 2 == 0).ToArray();
            int[] cc = num.TakeWhile(n => n < 7).ToArray();

            int[] dd = (from n in num where n <= 5 orderby n ascending select n).ToArray(); 
        }
    }
}
