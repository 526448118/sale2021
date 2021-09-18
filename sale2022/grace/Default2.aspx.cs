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
using System.Data.OracleClient;
using System.Security.Cryptography;
using System.Text;


public partial class grace_Default2 : System.Web.UI.Page
{
    
    private void con()
    {
        SqlConnection con = new SqlConnection("server='192.168.11.249';database=PS_DB;uid=sa;pwd=abc@12345;");
        SqlConnection conn = new SqlConnection();
        DataSet ds = new DataSet();
        SqlDataAdapter sda = new SqlDataAdapter("select top 77 * from ord_info", con);
        sda.Fill(ds, "newsTitle");
        //SqlDataAdapter sda2 = new SqlDataAdapter("select * from ProspectiveBuyer", con);
        // sda2.Fill(ds, "title");
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = ds.Tables["newsTitle"].DefaultView;
        //PagedDataSource aa = new PagedDataSource();
        pds.AllowPaging = true;//允许分页
        pds.PageSize = 10;//单页显示项数
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
            this.last.NavigateUrl  = Request.CurrentExecutionFilePath + "?Page=" + Convert.ToString(Count - 1); ;
            this.up.NavigateUrl    = Request.CurrentExecutionFilePath + "?Page=" + Convert.ToString(CurPage - 1);
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

        Repeater1.DataSource = pds;
        Repeater1.DataBind();

    }
    private void con1()
    {
        SqlConnection con = new SqlConnection("server='192.168.11.249';database=PS_DB;uid=sa;pwd=abc@12345;");
        SqlConnection conn = new SqlConnection();
        DataSet ds = new DataSet();
        SqlDataAdapter sda = new SqlDataAdapter("select top 77 * from ord_info", con);
        sda.Fill(ds, "newsTitle");
        //SqlDataAdapter sda2 = new SqlDataAdapter("select * from ProspectiveBuyer", con);
        // sda2.Fill(ds, "title");
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = ds.Tables["newsTitle"].DefaultView;
        //PagedDataSource aa = new PagedDataSource();
        pds.AllowPaging = true;//允许分页
        pds.PageSize = 10;//单页显示项数
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


        Repeater1.DataSource = pds;
        Repeater1.DataBind();

    }



    protected void Page_Load(object sender, EventArgs e)
    {
   
        if (!IsPostBack)
        {
        
              
            
            con();
            this.first.Visible = true;
            this.last.Visible = true;
            //this.Repeater1.DataSource = pds();
            //this.Repeater1.DataBind();

        }


    }
    protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lb_no = (Label)e.Item.FindControl("no");
            lb_no.Text = (1 + e.Item.ItemIndex).ToString();
        }
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
    protected void nb_TextChanged(object sender, EventArgs e)
    {
        con1();
    }
}