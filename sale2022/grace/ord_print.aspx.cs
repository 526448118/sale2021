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

public partial class ord_print : System.Web.UI.Page
{
 
    // DataClassesDataContext dc = new DataClassesDataContext();
     CommonClass cc = new CommonClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        string billno = Request["id"];
          string sql = "select * from ordhead where 单据号='"+billno+"'";
            SqlDataReader rd = cc.ExceRead(sql);
            if (rd.Read())
            {
                this.billno.Text = billno;
                this.thdate.Text = rd["提货日期"].ToString();
                this.lrdate.Text = rd["下单日期"].ToString();
                 this.cen.Text = rd["中心"].ToString();
                 this.dept.Text = rd["部门"].ToString();
                 this.ywy.Text = rd["业务员"].ToString();
                 this.custname.Text = rd["客户名称"].ToString();
                 this.custaddr.Text = rd["客户地址"].ToString();
                 this.thaddr.Text = rd["提货地址"].ToString();
                 this.custaddr.Text = rd["客户地址"].ToString();
                 this.custbody.Text = rd["客户联系人"].ToString();
                 this.custtel.Text = rd["客户电话"].ToString();
                 this.fktype.Text = rd["付款方式"].ToString();
                 this.kp.Text = rd["开票"].ToString();
                 this.memo.Text = rd["备注"].ToString();
                rd.Close();
            }
        BindDataToRepeater();
    }

    private void BindDataToRepeater()
    {
        string billno = Request["id"];
        SqlConnection myConn = cc.Getconsql02();
        myConn.Open();
        SqlCommand cmd = new SqlCommand("select * from ordbody where 单据号='"+billno+"'", myConn);

        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = cmd;
        DataSet ds = new DataSet();
        sda.Fill(ds, "ordbody");
        rptList.DataSource = ds.Tables["ordbody"];
        rptList.DataBind();
        myConn.Close();
    }


}