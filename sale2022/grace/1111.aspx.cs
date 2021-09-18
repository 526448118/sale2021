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

public partial class depotmanager_order_list : System.Web.UI.Page
{
    CommonClass cc = new CommonClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
 
        }
    }
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
            if (CheckBox2.Checked == true)
            {
                cbox.Checked = true;
            }
            else
            {
                cbox.Checked = false;
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        CheckBox2.Checked = false;
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
            cbox.Checked = false;
        }
    }
    private void BindDataToRepeater(string sql)
    {
        SqlConnection myConn = cc.Getconsql02();
        myConn.Open();

        SqlCommand cmd = new SqlCommand(sql, myConn);

        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = cmd;
        DataSet ds = new DataSet(); 
        sda.Fill(ds, "ord_info");
        GridView1.DataSource = sda;
        GridView1.DataKeyNames = new string[] { "num" };
        GridView1.DataBind();
        myConn.Close();
    }
    public void bind(string sql)
    {
        SqlConnection myConn = cc.Getconsql02();
        myConn.Open();        
        SqlDataAdapter myda = new SqlDataAdapter(sql, myConn);
        DataSet myds = new DataSet();
        myda.Fill(myds, "tb_Member");
        GridView1.DataSource = myds;
        GridView1.DataKeyNames = new string[] { "num" };
        GridView1.DataBind();
        myConn.Close();
    }
    public static DataTable Cpdt;
    void Createbt()//内存表
    {
        DataColumn mycol = new DataColumn();
        Cpdt.AcceptChanges();
    }
    public void DataTable()
    {
        GridView2 = GridView1;
        
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            string ID = GridView1.DataKeys[i].Value.ToString().Trim();
            DataRow[] arrRows = Cpdt.Select("num='" + ID + "'");
            CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
            if (cbox.Checked == false)
            {

            }
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
       

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //string com = Session["COM"].ToString();
        string com = "成都";
        string bgndate = this.bgndate.Text.Trim();
        string enddate = this.enddate.Text.Trim();
        string num = this.num.Text.Trim();
        string custum = this.num0.Text.Trim();
        string ywy = this.ywy.Text.Trim();
        string cxsql = "select * from ord_receipt_view001 where COM ='" + com + "'and status <> '99' and  lrtime between '" + bgndate + "' and '" + enddate + "' and num like '%" + num + "%'and custom like '%" + custum + "%' and dept like '%" + ywy + "%'  order by num desc";
        //Response.Write(cxsql);
        bind(cxsql);
    }

}