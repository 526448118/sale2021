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
    public string tzsql;
    public string cxsql;
    public string strSql;
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }
    }
    protected void BindData()
    {
        SqlConnection myConn = cc.Getconsql02();
        myConn.Open();
        //string sqlStr = " select orgname,orgcode,preorgcode from hscmp.tOrgManage where preorgcode='1102' ";
        SqlDataAdapter myDa = new SqlDataAdapter(strSql, myConn);
        DataSet myDs = new DataSet();
        myDa.Fill(myDs);
        GridView1.DataSource = myDs;
        //  GridView1.DataKeyNames = new string[] { "" };
        GridView1.DataBind();
        myDa.Dispose();
        myDs.Dispose();
        myConn.Close();
    }
    protected void GridView1_PageIndexChanging(object sender,GridViewPageEventArgs e)
    {
        this.GridView1.PageIndex = e.NewPageIndex;
        BindData();
    } 

    //查询
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string custname = this.custname.Text.Trim();
        string ywy = this.ywy.Text.Trim();
        string com = Session["COM"].ToString();
        string ordstatus = this.billstatus.SelectedValue.ToString();
        string billno = this.billno.Text.Trim();      
        string jobno = Session["RememberName"].ToString();
        string role = Session["RoleID"].ToString();
        string sh = Session["sh_memo"].ToString();
        if (ordstatus == "22")
        {
            ordstatus = "";
        }
        string sqljc;
        if (ordstatus == "99")
        {
             sqljc = " and num like '%" + billno + "%' and custname like '%" + custname + "%' and saler like '%" + ywy + "%' and bill_status like '%" + ordstatus + "%' order by bill_status";
        }
        else
        {
             sqljc = " and num like '%" + billno + "%' and custname like '%" + custname + "%' and saler like '%" + ywy + "%' and isdc like '%" + ordstatus + "%' order by bill_status";
        }
        //---------------查询-------------------
        //--------------------------------------------------------

        if (com == "成都")
        {
            if (role == "2")
            {
                string sql = "select * from orgpluinfo01 where com='" + com + "'"
           + " and( next_person='" + jobno + "' or lrstaff='" + jobno + "')";
                strSql = sql + sqljc;
                BindData();
            }
            else if (role == "3")
            {
                string sql = "select * from orgpluinfo01 where com='" + com + "'  ";  // 
                strSql = sql + sqljc;
                BindData();
            }
            else if (role == "4")
            {
                if (sh == "2")
                {
                    string sql = "select * from orgpluinfo01 where  com='" + com + "'  ";  // 
                    strSql = sql + sqljc;
                    BindData();
                    //  Response.Write(sql + sqljc);
                }
                else if (sh == "3")
                {
                    string sql = "select * from orgpluinfo01 where  com='" + com + "' ";  // 
                    strSql = sql + sqljc;
                    BindData();
                    //  Response.Write(sql + sqljc);
                }
                else
                {
                }

            }
            else if (role == "5")
            {
                if (sh == "1")
                {
                    string sql = "select * from orgpluinfo01 where (ord_from in('门市') and  com='" + com + "' and plutype<>'普通商品')  ";  // 
                     //Response.Write(sql+sqljc);
                     strSql = sql + sqljc;
                     BindData();
                }
            }
            else if (role == "6")
            {

                if (sh == "1")
                {
                    string sql = "select * from orgpluinfo01 where (ord_from in('业务','经销商') and  com='" + com + "')  or  (next_person='" + jobno + "' ) or (lrstaff='" + jobno + "') ";  // 
                   //  Response.Write(sql);
                    strSql = sql;
                    BindData();
                }
            }
            else if (role == "7")
            {

                if (sh == "4")
                {
                    string sql = "select * from orgpluinfo01 where (plutype in('礼券','储值卡','提领券') and  com='" + com + "' and plutype<>'普通商品')  or  (next_person='" + jobno + "' ) or (lrstaff='" + jobno + "')";  // 
                    // Response.Write(sql);
                    strSql = sql;
                    BindData();
                }
            }
            else if (role == "8")
            {

                if (sh == "4")
                {
                    string sql = "select * from orgpluinfo01 where (plutype in('月饼实物','粽子实物') and  com='" + com + "')  or  (next_person='" + jobno + "' ) or (lrstaff='" + jobno + "')";  // 
                    // Response.Write(sql);
                    strSql = sql;
                    BindData();
                }
            }
            else if (role == "9")
            {
                if (sh == "1")
                {
                    string sql = "select * from orgpluinfo01 where (ord_from in('市场','加盟业主') and  com='" + com + "')  or  (next_person='" + jobno + "' ) or (lrstaff='" + jobno + "') ";  // 
                    //   Response.Write(sql+sqljc);
                    strSql = sql + sqljc;
                    BindData();
                }


            }
            else if (role == "10")
            {
                string sql = "select * from orgpluinfo01 where plutype = '普通商品' ";
                strSql = sql + sqljc;
                BindData();
            }
            else
            {
                string sql = "select * from orgpluinfo01 where com='" + com + "'";
                // Response.Write(sql);
                strSql = sql;
                BindData();
            }
        }
        //---------------------------------------------------------------
        if (com == "福州")
        {
            string sql = "select * from orgpluinfo01 where (com='" + com + "' and "
                      + " next_person_sh is not null and next_person_sh_time is not null) or next_person='" + jobno + "' or lrstaff='" + jobno + "'";  // 
            // Response.Write(sql);
            strSql = sql;
            BindData();
        }
        //---------------------------------------------------------------
        if (com == "厦门")
        {
            string sql = "select * from orgpluinfo01 where (com='" + com + "' and "
      + " next_person_sh is not null and next_person_sh_time is not null) or next_person='" + jobno + "' or lrstaff='" + jobno + "'";  // 
            // Response.Write(sql);
            strSql = sql;
            BindData();

        }
       

    }

  

   
    //小数位是0的不显示
    public string MyConvert(object d)
    {
        string myNum = d.ToString();
        string[] strs = d.ToString().Split('.');
        if (strs.Length > 1)
        {
            if (Convert.ToInt32(strs[1]) == 0)
            {
                myNum = strs[0];
            }
        }
        return myNum;
    }
    protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
          if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
         {
            Label lb_no = (Label)e.Item.FindControl("no");
            lb_no.Text = (1 + e.Item.ItemIndex).ToString();
          }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Export("application/ms-excel", "订单信息.xls");
       // Export("application/ms-word", "测试.doc");
    }
    private void Export(String FileType, String FileName)
    {
        Response.Clear();
        Response.BufferOutput = true;
        //设定输出字符集
        Response.Charset = "GB2312";
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.AppendHeader("Content-Disposition", "attachment;filename="
        + HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8));
    //    Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("用户信息表" + DateTime.Now.ToString("d") + ".xls", Encoding.UTF8).ToString());
        //设置输出流HttpMiME类型(导出文件格式)
        Response.ContentType = FileType;
        //关闭ViewState
        Page.EnableViewState = false;
        System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("ZH-CN", true);
        System.IO.StringWriter stringWriter = new System.IO.StringWriter(cultureInfo);
        HtmlTextWriter textWriter = new HtmlTextWriter(stringWriter);
        //rpt_pro为repeater控件的ID
        //数据源要有边框，否则导出数据也无边框
      
        //把HTML写回游览器
        Response.Write(stringWriter.ToString());
        Response.End();
        Response.Flush();
    }

 
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
    {
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
