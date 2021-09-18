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
        if (Session["RememberName"] == null)
        {
         //  Response.Redirect("~/INDEX.aspx");
           // Response.Write("<script>window.location='~/INDEX.aspx'</script>");
          //  Response.Redirect("~/INDEX.aspx", true);
        }

        if (!Page.IsPostBack)
        {
            string com = Session["COM"].ToString();
            string jobno = Session["RememberName"].ToString();
            string role = Session["RoleID"].ToString();
           string sh = Session["sh_memo"].ToString();
       //     string com = AXRequest.GetQueryString("COM");
     //       string jobno = AXRequest.GetQueryString("RememberName");
    //        string role = AXRequest.GetQueryString("RoleID");
   //         string sh = AXRequest.GetQueryString("sh_memo");
           
         //   Response.Write(role+com);
            //--------------------------------------------------------
            if (com == "成都")
            {
                string sql = "select * from ord_info where com='" + com + "' and bill_status='99'"
         + " and lrstaff='" + jobno + "'";  // 
                    BindDataToRepeater(sql);
                    // Response.Write(sql);
               
            }
            //---------------------------------------------------------------
            if (com == "福州")
            {
                string sql = "select * from ord_info where com='" + com + "' and bill_status='99'"
         +" and lrstaff='" + jobno + "'";  // 
                    BindDataToRepeater(sql);
                      // Response.Write(sql);
            }
            //---------------------------------------------------------------
            if (com == "厦门")
            {
                string sql = "select * from ord_info where com='" + com + "' and bill_status='99'"
         +" and lrstaff='" + jobno + "'";  // 
                    BindDataToRepeater(sql);
                      // Response.Write(sql);

            }
          //-----------------------------------------------------------------
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
        rptList.DataSource = ds.Tables["ord_info"];
        rptList.DataBind();
        myConn.Close();
    }


   



    #region 返回订单状态=============================
    protected string GetOrderStatus(int _id)
    {
        string _title = string.Empty;

        switch (_id)
        {
            case 0:
                _title = "已生成";
                break;
            case 1:
                _title = "门市已审核";
                break;
            case 2:
                _title = "营销已审核";
                break;
            case 3:
                _title = "总经办已审";
                break;
             case 4:
                _title = "已出单";
                break;
             case 99:
                _title = "已作废";
                break;
        }

        return _title;
    }
    #endregion

    //查询
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string billno = this.billno.Text.Trim();
       string custname = this.custname.Text.Trim();
        string ywy = this.ywy.Text.Trim();
        string sqljc = " and num like '%" + billno + "%' and custname like '%" + custname + "%' and saler like '%" + ywy + "%'  order by bill_status";

         string com = Session["COM"].ToString();
         string jobno = Session["RememberName"].ToString();
         string role = Session["RoleID"].ToString();
        string sh = Session["sh_memo"].ToString();
         string com1 = AXRequest.GetQueryString("COM");
   //      Response.Write("my name is:" + com+";");
    //     string jobno = AXRequest.GetQueryString("RememberName");
   //      string role = AXRequest.GetQueryString("RoleID");
    //     string sh = AXRequest.GetQueryString("sh_memo");
         //--------------------------------------------------------
         if (com == "成都")
         {
            
                 string sql = "select * from ord_info where com='" + com + "' and bill_status='99'"
      + " and lrstaff='" + jobno + "'";  // 
                 BindDataToRepeater(sql+sqljc);
         //        Response.Write(sql);
           
         }
         //---------------------------------------------------------------
         if (com == "福州")
         {
             string sql = "select * from ord_info where com='" + com + "' and bill_status='99'"
      + " and lrstaff='" + jobno + "'";  // 
             BindDataToRepeater(sql + sqljc);
             // Response.Write(sql);
         }
         //---------------------------------------------------------------
         if (com == "厦门")
         {
             string sql = "select * from ord_info where com='" + com + "' and bill_status='99'"
      + " and lrstaff='" + jobno + "'";  // 
             BindDataToRepeater(sql + sqljc);
             // Response.Write(sql);

         }
        //-----------------------------------------------------------------

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
    public static string GetColor(string val)
    {
        if (val == "已作废")
        {
            return "color:#008000";
        }        
        else
        {
            return string.Empty;
        }
    }
}
