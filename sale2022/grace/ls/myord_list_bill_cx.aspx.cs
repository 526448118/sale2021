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
    protected void Page_Load(object sender, EventArgs e)
    {
       // this.billno.Text = DateTime.Now.ToString("yyyyMMdd"); 
        if (Session["RememberName"] == null)
        {
         //  Response.Redirect("~/INDEX.aspx");
           // Response.Write("<script>window.location='~/INDEX.aspx'</script>");
          //  Response.Redirect("~/INDEX.aspx", true);
        }

        if (!Page.IsPostBack)
        {
           string com = Session["COM"].ToString();
              string sh = Session["sh_memo"].ToString();
              string jobno = Session["RememberName"].ToString();
            string role = Session["RoleID"].ToString();
        //    string com = AXRequest.GetQueryString("COM");        
        //    string jobno = AXRequest.GetQueryString("RememberName");
        //    string role = AXRequest.GetQueryString("RoleID");
        //    string sh = AXRequest.GetQueryString("sh_memo");
       //     string bgndate = Request["bgndate"];
         //   string enddate = Request["enddate"];

           
           
         //   Response.Write(role+com);
            //--------------------------------------------------------
            if (com == "成都")
            {

                string sql = "select * from ord_receipt_view01 where COM ='" + com + "'"
         + " and jobno='" + jobno + "'"; //and   lrtime between '" + bgndate + "' and '" + enddate + "'";
                  tzsql = sql;
                  this.tz1.Text = tzsql;
                 //   BindDataToRepeater(sql);
            //       con(sql);
                    //  Response.Write(tz1);              
            }
            else
            {
              //  string sql = "select * from ord_info";
               // BindDataToRepeater(sql);
            }
            //---------------------------------------------------------------
            if (com == "福州")
            {
                string sql = "select * from ord_info where com='" + com + "'"
         + " and lrstaff='" + jobno + "'  order by bill_status";  // 
                // Response.Write(sql);
              //  BindDataToRepeater(sql);
                tzsql = sql;
                this.tz1.Text = tzsql;
                con(sql);
            }
            //---------------------------------------------------------------
            if (com == "厦门")
            {
                string sql = "select * from ord_info where com='" + com + "'"
           + " and lrstaff='" + jobno + "'  order by bill_status";  // 
                // Response.Write(sql);
            //    BindDataToRepeater(sql);
                tzsql = sql;
                this.tz1.Text = tzsql;
                con(sql);

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
        sda.Fill(ds, "ord_receipt_view01");
        rptList.DataSource = ds.Tables["ord_receipt_view01"];
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
        
       string custname = this.custname.Text.Trim();
        string ywy = this.ywy.Text.Trim();
        string sqljc = " and custom like '%" + custname + "%' and yw_people like '%" + ywy + "%'  order by num desc";
      //  Response.Write("<script>window.location='~/INDEX.aspx'</script>");
         string com = Session["COM"].ToString();
        string jobno = Session["RememberName"].ToString();
        string role = Session["RoleID"].ToString();
         string sh = Session["sh_memo"].ToString();

    //     string com = AXRequest.GetQueryString("COM");
    //     string jobno = AXRequest.GetQueryString("RememberName");
    //     string role = AXRequest.GetQueryString("RoleID");
   //      string sh = AXRequest.GetQueryString("sh_memo");
         string bgndate = this.bgndate.Text.Trim();
         string enddate = this.enddate.Text.Trim();
       //  Response.Write("<script>window.location='~/grace/myord_list_bill_cx.aspx?custname='"+custname+"'&ywy='"+ywy+"'&bgndate='"+bgndate+"'&enddate='"+enddate+"''</script>");
         if (com == "成都")
         {
             string sql = "select * from ord_receipt_view01 where COM ='" + com + "'"
       + " and jobno='" + jobno + "' ";  //and   lrtime between '" + bgndate + "' and '" + enddate + "'
             tzsql = sql+sqljc;          
             
             con(tzsql);
             Response.Write(tzsql);
             
         }
         if (com == "厦门")
         {
             string sql = "select * from ord_info where com='" + com + "' and "
    + " lrstaff='" + jobno + "'";  // 
            // BindDataToRepeater(sql + sqljc);
             // Response.Write(sql);    
             con(sql + sqljc);
             tzsql = sql + sqljc;
             this.tz1.Text = tzsql;
         }
         if (com == "福州")
         {
             string sql = "select * from ord_info where com='" + com + "' and "
    + " lrstaff='" + jobno + "'";  // 
            // BindDataToRepeater(sql + sqljc);
             // Response.Write(sql);      
             con(sql + sqljc);
             tzsql = sql + sqljc;
             this.tz1.Text = tzsql;
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
        string com = Session["COM"].ToString();
        string jobno = Session["RememberName"].ToString();
        if (com == "成都")
        {
            string sql = "select * from ord_receipt_view01 where com='" + com + "' and "
   + " jobno='" + jobno + "'";  // 
                BindDataToRepeater(sql);
          //  con(sql);
            //   Response.Write(sql);            
        }
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
    protected void nb_TextChanged(object sender, EventArgs e)
    {
      /*
        string com = Session["COM"].ToString();
        string jobno = Session["RememberName"].ToString();
        if (com == "成都")
        {
            string sql = "select * from ord_info where com='" + com + "' and "
                + " lrstaff='" + jobno + "'";

            con1(sql);
        }*/
        con1(this.tz1.Text.ToString());
        con1(tzsql);
    }
    private void con(string sql)
    {
        SqlConnection con = new SqlConnection("server='192.168.11.249';database=PS_DB;uid=sa;pwd=abc@12345;");
        SqlConnection conn = new SqlConnection();
        DataSet ds = new DataSet();
        SqlDataAdapter sda = new SqlDataAdapter(sql, con);
        sda.Fill(ds, "ord_receipt_view01");
        //SqlDataAdapter sda2 = new SqlDataAdapter("select * from ProspectiveBuyer", con);
        // sda2.Fill(ds, "title");
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = ds.Tables["ord_receipt_view01"].DefaultView;
        //PagedDataSource aa = new PagedDataSource();
        pds.AllowPaging = true;//允许分页
        pds.PageSize = 1;//单页显示项数
        int CurPage;
        if (Request.QueryString["Page"] != null)
            CurPage = Convert.ToInt32(Request.QueryString["Page"]);
        else
            CurPage = 1;
        pds.CurrentPageIndex = CurPage - 1;
        int Count = pds.PageCount;

        lblCurrentPage.Text = "当前页：" + CurPage.ToString();
        labPage.Text = Count.ToString();

        //Convert.ToInt32(str) or int.Parse(str)

        if (!pds.IsFirstPage)
        {

            this.first.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=1";
            this.last.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + Convert.ToString(Count - 1); ;
            this.up.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + Convert.ToString(CurPage - 1);
            //   this.tz.NavigateUrl    = Request.CurrentExecutionFilePath + "?Page=" + num;

        }
        else
        {
            this.first.Visible = false;
            this.last.Visible = false;

        }

        if (!pds.IsLastPage)
        {

            next.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + Convert.ToString(CurPage + 1);
        }
        else
        {
            this.first.Visible = false;
            this.last.Visible = false;

        }

        rptList.DataSource = pds;
        rptList.DataBind();

    }
    private void con1(string sql)
    {
        SqlConnection con = new SqlConnection("server='192.168.11.249';database=PS_DB;uid=sa;pwd=abc@12345;");
        SqlConnection conn = new SqlConnection();
        DataSet ds = new DataSet();
        SqlDataAdapter sda = new SqlDataAdapter(sql, con);
        sda.Fill(ds, "newsTitle");
        //SqlDataAdapter sda2 = new SqlDataAdapter("select * from ProspectiveBuyer", con);
        // sda2.Fill(ds, "title");
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = ds.Tables["newsTitle"].DefaultView;
        //PagedDataSource aa = new PagedDataSource();
        pds.AllowPaging = true;//允许分页
        pds.PageSize = 200;//单页显示项数
        int CurPage;
        if (Request.QueryString["Page"] != null)
            CurPage = Convert.ToInt32(Request.QueryString["Page"]);
        else
            CurPage = 1;
        pds.CurrentPageIndex = CurPage - 1;
        int Count = pds.PageCount;

        lblCurrentPage.Text = "当前页：" + CurPage.ToString();
        labPage.Text = Count.ToString();

        //Convert.ToInt32(str) or int.Parse(str)

        //  if (!pds.IsFirstPage)
        //   {
        string num;
        num = this.nb.Text.ToString();
        Response.Write(num);
        //  this.first.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=1";
        //  this.last.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + Convert.ToString(Count - 1); ;
        //   this.up.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + Convert.ToString(CurPage - 1);
        //  this.tz.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + num;
        string aa = Request.CurrentExecutionFilePath + "?Page=" + num;
        Response.Redirect(aa, true);
        //   Response.Write(this.tz.NavigateUrl);

        //     }
        //     else
        //     {
        //         this.first.Visible = false;
        //         this.last.Visible = false;

        //      }


        rptList.DataSource = pds;
        rptList.DataBind();

    }
}
