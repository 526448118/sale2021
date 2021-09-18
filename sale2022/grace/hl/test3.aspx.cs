using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Text;


public partial class grace_hl_test3 : System.Web.UI.Page
{
    CommonClass cc = new CommonClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //绑定下拉框客户信息
            string sqlcd = "select distinct customname from storesys.dbo.Sap_customaddress";
            SqlConnection myConn = cc.Getconsql02();
            myConn.Open();
            SqlDataAdapter dapt = new SqlDataAdapter(sqlcd, myConn);
            DataSet ds = new DataSet();
            //填充数据集
            dapt.Fill(ds, "files");
            //绑定下拉菜单
            this.DropDownList1.DataSource = ds.Tables["files"].DefaultView;   //定交数据源
            this.DropDownList1.DataValueField = ds.Tables["files"].Columns[0].ToString();
            this.DropDownList1.DataBind();
            this.DropDownList1.Items.Insert(0, "");
            //释放占用的资源
            ds.Dispose();
            dapt.Dispose();
            myConn.Close();
        }
    }





    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        string text = this.TextBox1.Text.Trim();
        string sqlcd = "select distinct customname from storesys.dbo.Sap_customaddress where customname like '%" + text + "%'";
        SqlConnection myConn = cc.Getconsql02();
        myConn.Open();
        SqlDataAdapter dapt = new SqlDataAdapter(sqlcd, myConn);
        DataSet ds = new DataSet();
        //填充数据集
        dapt.Fill(ds, "files");
        //绑定下拉菜单
        this.DropDownList1.DataSource = ds.Tables["files"].DefaultView;   //定交数据源
        this.DropDownList1.DataValueField = ds.Tables["files"].Columns[0].ToString();
        this.DropDownList1.DataBind();
        this.DropDownList1.Items.Insert(0, "");
        //释放占用的资源
        ds.Dispose();
        dapt.Dispose();
        myConn.Close();
    }
}