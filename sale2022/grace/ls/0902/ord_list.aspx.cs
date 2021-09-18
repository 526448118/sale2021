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
        //    string com = AXRequest.GetQueryString("COM");
      //      string jobno = AXRequest.GetQueryString("RememberName");
      //      string role = AXRequest.GetQueryString("RoleID");
     //       string sh = AXRequest.GetQueryString("sh_memo");
           
         //   Response.Write(role+com);
            //--------------------------------------------------------
            if (com == "成都")
            {
                if (role == "2")
                {
                    string sql = "select * from ord_info where com='" + com + "'"
         + " and  next_person='" + jobno + "' and next_person_sh is null and bill_status<>'99' order by bill_status";  
                    BindDataToRepeater(sql);
                    //  Response.Write(sql);
                }
                else if (role == "3")
                {
                    string sql = "select * from ord_info where com='" + com + "' and bill_status in('3','99','4') order by bill_status";  // 
                    BindDataToRepeater(sql);
                }
                else if (role == "4")
                {
                    if (sh == "2")
                    {
                        string sql = "select * from ord_info where (com='" + com + "' and bill_status in('1') ) "
                     + " or  (next_person='" + jobno + "' and next_person_sh is null)    order by bill_status";  // 
                        
                        //string sql = "select * from ord_info where  com='" + com + "' and (bill_status in('1') or (ord_from in('行政') and next_person_sh is not null and bill_status in('0'))) order by bill_status";  // 
                      //  Response.Write(sql);
                         BindDataToRepeater(sql);
                    }
                    else if (sh == "3")
                    {

                        string sql = "select * from ord_info where (com='" + com + "' and bill_status in('2') ) "
                     + " or  (next_person='" + jobno + "' and next_person_sh is null)    order by bill_status";  // 
                        
                        BindDataToRepeater(sql);
                    }
                    else
                    {
                    }

                }
                else if (role == "5")
                {
                    if (sh == "1")
                    {
                        string sql = "select * from ord_info where (ord_from in('门市') and  com='" + com + "' and bill_status in('0') and next_person_sh is not null) or (ord_from in('门市','行政') and  com='" + com + "' and bill_status in('3') and plutype='自制品实物') "
  +    "    or ( next_person='" + jobno + "' and next_person_sh is null) order by bill_status";  // 
                        //  Response.Write(sql);
                        BindDataToRepeater(sql);
                    }
                }
                else if (role == "6")
                {

                    if (sh == "1")
                    {
                        string sql = "select * from ord_info where (ord_from in('业务','经销商') and  com='" + com + "' and bill_status in('0') and next_person_sh is not null) or (ord_from in('业务','经销商') and  com='" + com + "' and bill_status in('3') and plutype='自制品实物') or ( next_person='" + jobno + "' and next_person_sh is null) order by bill_status";  // 
                        // Response.Write(sql);
                        BindDataToRepeater(sql);
                    }
                }
                else if (role == "7")
                {


                    string sql = "select * from ord_info where ( plutype in('礼券','储值卡','提领券','月饼实物','粽子实物') and  com='" + com + "' and bill_status in('3')) or ( next_person='" + jobno + "' and next_person_sh is null) order by bill_status";  // 
                    // Response.Write(sql);
                    BindDataToRepeater(sql);

                }
                else if (role == "8")
                {


                    string sql = "select * from ord_info where (plutype in('月饼实物','粽子实物') and  com='" + com + "' and bill_status in('3')) or ( next_person='" + jobno + "' and next_person_sh is null) order by bill_status";  // 
                    // Response.Write(sql);
                    BindDataToRepeater(sql);

                }
                else if (role == "9")
                {
                    if (sh == "1")
                    {
                        string sql = "select * from ord_info where (ord_from in('市场','加盟业主') and  com='" + com + "' and bill_status in('0') and next_person_sh is not null) or (ord_from in('市场','加盟业主') and  com='" + com + "' and bill_status in('3') and plutype='自制品实物') or ( next_person='" + jobno + "' and next_person_sh is null) order by bill_status";  // 
                        // Response.Write(sql);
                        BindDataToRepeater(sql);
                    }

                 
                }
                else
                {
                  //  string sql = "select * from ord_info";
                  //  BindDataToRepeater(sql);
                }
            }
            else
            {
              //  string sql = "select * from ord_info";
               // BindDataToRepeater(sql);
            }
            //---------------------------------------------------------------
            if (com == "福州")
            {
                string sql = "select * from ord_info where (com='" + com + "' and "
                          + " next_person_sh is not null and next_person_sh_time is not null) or next_person='" + jobno + "' or lrstaff='" + jobno + "'";  // 
                // Response.Write(sql);
                BindDataToRepeater(sql);
            }
            //---------------------------------------------------------------
            if (com == "厦门")
            {
                string sql = "select * from ord_info where (com='" + com + "' and "
          + " next_person_sh is not null and next_person_sh_time is not null) or next_person='" + jobno + "' or lrstaff='" + jobno + "'";  // 
                // Response.Write(sql);
                BindDataToRepeater(sql);

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
        myConn.Dispose();
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
  //       string com = AXRequest.GetQueryString("COM");
 //        string jobno = AXRequest.GetQueryString("RememberName");
  //       string role = AXRequest.GetQueryString("RoleID");
  //       string sh = AXRequest.GetQueryString("sh_memo");
         if (com == "成都")
         {
             if (role == "2")
             {
                 string sql = "select * from ord_info where com='" + com + "'"
      + " and  next_person='" + jobno + "' and next_person_sh is null and bill_status<>'99' ";  // 
                 BindDataToRepeater(sql+sqljc);
                 // Response.Write(sql);
             }
             else if (role == "3")
             {
                 string sql = "select * from ord_info where com='" + com + "' and bill_status in('3','99','4') ";  // 
                 BindDataToRepeater(sql + sqljc);
             }
             else if (role == "4")
             {
                 if (sh == "2")
                 {
                     string sql = "select * from ord_info where (com='" + com + "' and bill_status in('1') ) "
                      + " or  (next_person='" + jobno + "' and next_person_sh is null)";  // 
                     BindDataToRepeater(sql + sqljc);
                 }
                 else if (sh == "3")
                 {
                     string sql = "select * from ord_info where (com='" + com + "' and bill_status in('2')) "
                     + " or  (next_person='" + jobno + "' and next_person_sh is null) ";  //
                //     Response.Write(sql + sqljc);
                     BindDataToRepeater(sql + sqljc);
                 }
                 else
                 {
                 }

             }
             else if (role == "5")
             {
                 if (sh == "1")
                 {
                     string sql = "select * from ord_info where (ord_from in('门市') and  com='" + com + "' and bill_status in('0') and next_person_sh is not null) or (ord_from in('门市','行政') and  com='" + com + "' and bill_status in('3') and plutype='自制品实物') or  (next_person='" + jobno + "' and next_person_sh is null)  ";  // 
                     //  Response.Write(sql);
                     BindDataToRepeater(sql + sqljc);
                 }
             }
             else if (role == "6")
             {

                 if (sh == "1")
                 {
                     string sql = "select * from ord_info where (ord_from in('业务','经销商') and  com='" + com + "' and bill_status in('0') and next_person_sh is not null) or (ord_from in('业务','经销商') and  com='" + com + "' and bill_status in('3') and plutype='自制品实物') or  (next_person='" + jobno + "' and next_person_sh is null)  ";  // 
                     // Response.Write(sql);
                     BindDataToRepeater(sql + sqljc);
                 }
             }
             else if (role == "7")
             {


                 string sql = "select * from ord_info where plutype in('礼券','储值卡','提领券','月饼实物','粽子实物') and  com='" + com + "' and bill_status in('3') or  (next_person='" + jobno + "' and next_person_sh is null)  ";  // 
                 // Response.Write(sql);
                 BindDataToRepeater(sql + sqljc);

             }
             else if (role == "8")
             {


                 string sql = "select * from ord_info where plutype in('月饼实物','粽子实物') and  com='" + com + "' and bill_status in('3') or  (next_person='" + jobno + "' and next_person_sh is null)  ";  // 
                 // Response.Write(sql);
                 BindDataToRepeater(sql + sqljc);

             }
             else if (role == "9")
             {
                 if (sh == "1")
                 {
                     string sql = "select * from ord_info where (ord_from in('市场','加盟业主') and  com='" + com + "' and bill_status in('0') and next_person_sh is not null) or (ord_from in('市场','加盟业主') and  com='" + com + "' and bill_status in('3') and plutype='自制品实物') or  (next_person='" + jobno + "' and next_person_sh is null)  ";  // 
                     // Response.Write(sql);
                     BindDataToRepeater(sql + sqljc);
                 }


             }
             else
             {
                 //  string sql = "select * from ord_info";
                 //  BindDataToRepeater(sql);
             }
         }
         else
         {
             //  string sql = "select * from ord_info";
             // BindDataToRepeater(sql);
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
}
