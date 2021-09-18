using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxEngine;
using AjaxEngine.AjaxPages;
using System.Threading;
using AjaxEngine.Utils;

namespace AjaxEngine.Demo
{
    public partial class _Default : AjaxPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PageEngine.AutoUpdateControls = true;
            // Thread.Sleep(3000);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.TextBox1.Text += "fff";
            this.PageEngine.ShowConfirmBox<int>("aaa", this.Yes, this.No, 3);
            //this.AjaxEngine.GotoUrl("http://www.baidu.com");
        }
        [AjaxMethod]
        public void Yes(int x)
        {
            this.PageEngine.ShowMessageBox("yes" + x);
        }
        [AjaxMethod]
        public void No(int x)
        {
            this.PageEngine.ShowMessageBox("no" + x);
        }
        /// <summary>
        /// 参数和返回值都必须是string类型
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [AjaxMethod]
        public object Add(string x, string y)
        {
            return (x + y).ToString() + this.TextBox1.Text;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            this.PageEngine.OpenWindow<T, T>("Dialog.aspx", "test", "top=200px,left=200px,width=400px,height=400px", new T(), this.Callback);
        }
        [AjaxMethod]
        public void Callback(T arg)
        {
            this.PageEngine.ShowMessageBox(arg.t1.ToString());
        }
    }
}