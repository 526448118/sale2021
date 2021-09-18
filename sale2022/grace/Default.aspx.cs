using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class grace_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
      //  SoundPlayer player = new SoundPlayer(Server.MapPath("~/Membership/system.wav"));
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        Response.Write("<embed src ='notify.wma' width = '0' height = '0' id = 'music' autostart = 'true'></embed>");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        
        //测试小数报错
        int id_zk = 0;
        int.TryParse(this.Textbox.Text.Trim(), out id_zk);
        if (id_zk == 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('折扣输入有误：请按以下提示填写：如8折，就填写80；如：8.5折，就填写85，不允许输入小数！');", true);
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Server.Execute("~/grace/mp3.aspx");
    }
}