using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections;
using System.Xml;
using System.Text;
using System.IO;
using System.Net;

public partial class depotmanager_order_list : System.Web.UI.Page
{
    CommonClass cc = new CommonClass();
  
    protected void Page_Load(object sender, EventArgs e)
    {
            if (!IsPostBack)
            {
               
            } 
        
    }






    public void bind(string sql)
    {
        SqlConnection myConn = cc.Getconsql02();
        myConn.Open();
        SqlDataAdapter myda = new SqlDataAdapter(sql, myConn);
        DataSet myds = new DataSet();
        myda.Fill(myds, "tb_Member");
        GridView1.DataSource = myds;
        GridView1.DataBind();
        myConn.Close();
    }

    //查询
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string bgndate = this.bgndate.Text.Trim();
        string enddate = this.enddate.Text.Trim();
        string role = "10";// Session["RoleID"].ToString();
         if (role == "10")
            {
                string sql = "select * from view_zfsq where 申请时间 between '" + bgndate + "' and '" + enddate + "'";
                //Response.Write(sql);
                bind(sql);
            }
            else
            {
                return;
            }
    }

  

   
    //小数位是0的不显示

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
