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
     //   this.billno.Text = DateTime.Now.ToString("yyyyMMdd"); 
        if (!Page.IsPostBack)
        {
        //    string com = Session["COM"].ToString();
        //    string jobno = Session["RememberName"].ToString();
       //     string role = Session["RoleID"].ToString();
       //     string sh = Session["sh_memo"].ToString();
         
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
        sda.Fill(ds, "orgpluinfo01");
        rptList.DataSource = ds.Tables["orgpluinfo01"];
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
        // string ord_from = this.billno.Text.Trim();
        string custname = this.custname.Text.Trim();
        string ywy = this.ywy.Text.Trim();
        string com = Session["COM"].ToString();
        string ordstatus = this.billstatus.SelectedValue.ToString();
        string billno = this.billno.Text.Trim();      
        string jobno = Session["RememberName"].ToString();
        string role = Session["RoleID"].ToString();
        string sh = Session["sh_memo"].ToString();
  //       string com = AXRequest.GetQueryString("COM");
  //       string jobno = AXRequest.GetQueryString("RememberName");
  //       string role = AXRequest.GetQueryString("RoleID");
  //      string sh = AXRequest.GetQueryString("sh_memo");
        if (ordstatus == "22")
        {
            ordstatus = "";
        }
        string sqljc = " and num like '%" + billno + "%' and custname like '%" + custname + "%' and saler like '%" + ywy + "%' and bill_status like '%" + ordstatus + "%' order by bill_status";

        /*     if (ordstatus == "22")
             {
                 string sql = "select * from orgpluinfo01 where num like '%" + billno + "%' and custname like '%" + custname + "%' and saler like '%" + ywy + "%' and com='" + com + "'";
                 BindDataToRepeater(sql);
            //     Response.Write(sql);
             }
             else
             {
                 string sql = "select * from orgpluinfo01 where num like '%" + billno + "%' and custname like '%" + custname + "%' and saler like '%" + ywy + "%' and bill_status like '%" + ordstatus + "%'and com='" + com + "'";
                 BindDataToRepeater(sql);
              //   Response.Write(sql);
             } */
        //---------------查询-------------------
        //--------------------------------------------------------

        if (com == "成都")
        {
            if (role == "2")
            {
                string sql = "select * from orgpluinfo01 where com='" + com + "'"
           + " and( next_person='" + jobno + "' or lrstaff='" + jobno + "')";
                BindDataToRepeater(sql + sqljc);
            }
            else if (role == "3")
            {
                string sql = "select * from orgpluinfo01 where com='" + com + "'  ";  // 
                BindDataToRepeater(sql + sqljc);
            }
            else if (role == "4")
            {
                if (sh == "2")
                {
                    string sql = "select * from orgpluinfo01 where  com='" + com + "'  ";  // 
                    BindDataToRepeater(sql + sqljc);
                    //  Response.Write(sql + sqljc);
                }
                else if (sh == "3")
                {
                    string sql = "select * from orgpluinfo01 where  com='" + com + "' ";  // 
                    BindDataToRepeater(sql + sqljc);
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
                   //  Response.Write(sql+sqljc);
                    BindDataToRepeater(sql + sqljc);
                }
            }
            else if (role == "6")
            {

                if (sh == "1")
                {
                    string sql = "select * from orgpluinfo01 where (ord_from in('业务','经销商') and  com='" + com + "')  or  (next_person='" + jobno + "' ) or (lrstaff='" + jobno + "') ";  // 
                   //  Response.Write(sql);
                    BindDataToRepeater(sql + sqljc);
                }
            }
            else if (role == "7")
            {

                if (sh == "4")
                {
                    string sql = "select * from orgpluinfo01 where (plutype in('礼券','储值卡','提领券') and  com='" + com + "' and plutype<>'普通商品')  or  (next_person='" + jobno + "' ) or (lrstaff='" + jobno + "')";  // 
                    // Response.Write(sql);
                    BindDataToRepeater(sql + sqljc);
                }
            }
            else if (role == "8")
            {

                if (sh == "4")
                {
                    string sql = "select * from orgpluinfo01 where (plutype in('月饼实物','粽子实物') and  com='" + com + "')  or  (next_person='" + jobno + "' ) or (lrstaff='" + jobno + "')";  // 
                    // Response.Write(sql);
                    BindDataToRepeater(sql + sqljc);
                }
            }
            else if (role == "9")
            {
                if (sh == "1")
                {
                    string sql = "select * from orgpluinfo01 where (ord_from in('市场','加盟业主') and  com='" + com + "')  or  (next_person='" + jobno + "' ) or (lrstaff='" + jobno + "') ";  // 
                    //   Response.Write(sql+sqljc);
                    BindDataToRepeater(sql + sqljc);
                }


            }
            else if (role == "10")
            {
                string sql = "select * from orgpluinfo01 where plutype = '普通商品' ";
                BindDataToRepeater(sql+sqljc);
            }
            else
            {
                string sql = "select * from orgpluinfo01 where com='" + com + "'";
                // Response.Write(sql);
                BindDataToRepeater(sql + sqljc);
            }
        }
        //---------------------------------------------------------------
        if (com == "福州")
        {
            string sql = "select * from orgpluinfo01 where (com='" + com + "' and "
                      + " next_person_sh is not null and next_person_sh_time is not null) or next_person='" + jobno + "' or lrstaff='" + jobno + "'";  // 
            // Response.Write(sql);
            BindDataToRepeater(sql);
        }
        //---------------------------------------------------------------
        if (com == "厦门")
        {
            string sql = "select * from orgpluinfo01 where (com='" + com + "' and "
      + " next_person_sh is not null and next_person_sh_time is not null) or next_person='" + jobno + "' or lrstaff='" + jobno + "'";  // 
            // Response.Write(sql);
            BindDataToRepeater(sql);

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
        rptList.RenderControl(textWriter);
        //把HTML写回游览器
        Response.Write(stringWriter.ToString());
        Response.End();
        Response.Flush();
    }
    public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
    {
    }
}
