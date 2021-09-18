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
using System.Data.OracleClient;

public partial class _add_saleord : System.Web.UI.Page
{
    CommonClass cc = new CommonClass();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        string billno = Request["id"];
      //  string billno = "2";
        string jobno = Session["RememberName"].ToString();
       //   string jobno ="SC00913";

          if (!IsPostBack)
          {
              string sql = "select * from dbo.ord_receipt where num='" + billno + "' ";
              SqlDataReader rd = cc.ExceRead(sql);
              if (rd.Read())
              {
                  this.cen.Text = rd["cen"].ToString();
                  this.dept.Text = rd["dept"].ToString();
                  this.billtype.Text = rd["billtype"].ToString();
                  this.yw_people.Text = rd["yw_people"].ToString();
                  this.yw_peopletell.Text = rd["yw_peopletell"].ToString();
                  this.tick_record.Text = rd["tick_record"].ToString();
                  this.sale_source.Text = rd["sale_source"].ToString();
                  this.rec_address.Text = rd["rec_address"].ToString();
                  this.ordbillno.Text = rd["ordbillno"].ToString();
                  this.custom.Text = rd["custom"].ToString();
                  this.shuihao.Text = rd["shuihao"].ToString();
                  this.address.Text = rd["address"].ToString();
                  this.bank.Text = rd["bank"].ToString();
                  this.bank_acc.Text = rd["bank_acc"].ToString();
                  this.email.Text = rd["email"].ToString();
                  this.tellphone.Text = rd["tellphone"].ToString();
                  this.cust_lxr.Text = rd["cust_lxr"].ToString();
                  this.lxr_tel.Text = rd["lxr_tel"].ToString();
                  this.memo.Text = rd["memo"].ToString();
                  rd.Close();
                  rd.Dispose();
                  bindsskc("select id 编号,billno 单据号,pluname 商品名称,plucount 商品数量,sstotal 实收金额,lrr 录入人 from ord_receipt_plu where billno = '" + billno + "'");
              }
          }
   
    }


    protected void bindsskc(string sqlStr)
    {
        SqlConnection myConn = cc.Getconsql02();
        myConn.Open();
        //string sqlStr = " select orgname,orgcode,preorgcode from hscmp.tOrgManage where preorgcode='1102' ";
        SqlDataAdapter myDa = new SqlDataAdapter(sqlStr, myConn);
        DataSet myDs = new DataSet();
        myDa.Fill(myDs);
        GridView1.DataSource = myDs;
        //  GridView1.DataKeyNames = new string[] { "" };
        GridView1.DataBind();
        myDa.Dispose();
        myDs.Dispose();
        myConn.Close();
    }

    





    

 
 
    
}