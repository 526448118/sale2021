using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class grace_sw_dc_his : System.Web.UI.Page
{
    CommonClass cc = new CommonClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string billno = Request["billno"];
            string sql = "select * from ord_status_dc_view where 单据号 = '" + billno + "'";
            Bindsskc(sql);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string billno = this.TextBox1.Text.Trim();
        string sql = "select * from ord_status_dc_view where 单据号 = '" + billno + "'";
        Bindsskc(sql);

        //Double a = (23 & 17 + 27 | 13) % 11.31;
        //this.TextBox1.Text = a.ToString();
        /*Random rad = new Random();
        
        
        for (int i = 0; i < 100; i++)
        {
            int a = rad.Next(0, 10);
            Response.Write(a+";"); 
        }*/


    }
    protected void Bindsskc(string sqlStr)
    {
        SqlConnection myConn = cc.Getconsql02();
        myConn.Open();
        SqlDataAdapter myDa = new SqlDataAdapter(sqlStr, myConn);
        DataSet myDs = new DataSet();
        myDa.Fill(myDs);
        GridView1.DataKeyNames = new string[] { "单据号" };
        GridView1.DataSource = myDs;
        GridView1.DataBind();
        myDa.Dispose();
        myDs.Dispose();
        myConn.Close();
    }

}