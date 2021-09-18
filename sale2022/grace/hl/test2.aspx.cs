using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Collections;
using System.Xml;
using System.Text;
using System.IO;
using System.Net;
using System.Data.OleDb;

public partial class grace_hl_test2 : System.Web.UI.Page
{
    CommonClass cc = new CommonClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string sql = "select type from ord_shuishou_code";
            plu_bind(sql);
        }
    }
    protected void dr1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string key = Request.Form["__EVENTTARGET"];
        Response.Write(key);
    }
    protected void plu_bind(string sql)
    {
        //打开与数据库的连接
        SqlConnection myConn = cc.Getconsql02();
        myConn.Open();

        //查询文件创建时间
        SqlDataAdapter dapt = new SqlDataAdapter(sql, myConn);
        // Response.Write("aa");
        DataSet ds = new DataSet();
        //填充数据集
        dapt.Fill(ds, "files");
        //绑定下拉菜单
        this.dr1.DataSource = ds.Tables["files"].DefaultView;   //定交数据源
        // this.com.DataTextField = ds.Tables["files"].Columns[0].ToString();     
        //this.pluname.DataTextField = ds.Tables["files"].Columns[4].ToString();
        this.dr1.DataValueField = ds.Tables["files"].Columns[0].ToString();

        this.dr1.DataBind();
        //释放占用的资源
        ds.Dispose();
        dapt.Dispose();
        myConn.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //string a = this.dr1.Text.Trim();
        Response.Write("<script>alert('111');top.location.href ='http://192.168.11.249:1006/index.aspx';</script>");
    }
}