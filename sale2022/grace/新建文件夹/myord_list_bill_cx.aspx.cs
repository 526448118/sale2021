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

           
  
            //--------------------------------------------------------
            if (com == "成都")
            {

                string sql = "select * from ord_receipt_view001 where COM ='" + com + "'"
         + " and jobno='" + jobno + "'"; //and   lrtime between '" + bgndate + "' and '" + enddate + "'";
          
           
             //     contrlRepeater(sql);
                 //   BindDataToRepeater(sql);
            //       con(sql);
                    //  Response.Write(tz1);              
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
        sda.Fill(ds, "ord_receipt_view001");
        rptList.DataSource = ds.Tables["ord_receipt_view001"];
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
         //  Response.Write("<script>window.location='~/INDEX.aspx'</script>");
         string com = Session["COM"].ToString();
         string jobno = Session["RememberName"].ToString();
         string role = Session["RoleID"].ToString();
         string sh = Session["sh_memo"].ToString();
         string bgndate = this.bgndate.Text.Trim();
         string enddate = this.enddate.Text.Trim();
         string shbgndate = this.shbgdate.Text.Trim();
         string shenddate = this.shendate.Text.Trim();
         string ordbillno = this.ordbillno.Text.Trim();
         string isdc = this.DropDownList1.SelectedValue;
         string fp_type = this.DropDownList2.SelectedValue;
         string dd_type = this.DropDownList3.SelectedValue;
         string sqljc;
         if (dd_type == "全部")
         {
             dd_type = "";
         }
         if (fp_type == "全部")
         {
             fp_type = "";
         }
         if (isdc == "已导出" || isdc == "未导出")
         {
             sqljc = " and sale_source like '%" + dd_type + "%' and billtype like '%" + fp_type + "%' and isdc ='" + isdc + "'  order by num desc";
         }
         else if (isdc == "03")
         {
             sqljc = " and sale_source like '%" + dd_type + "%' and billtype like '%" + fp_type + "%' and status ='" + isdc + "'  order by num desc";
         }
         else if (isdc == "全部")
         {
             sqljc = " and sale_source like '%" + dd_type + "%' and billtype like '%" + fp_type + "%' and status = '03' order by num desc";
         }
         else 
         {
             sqljc = " and sale_source like '%" + dd_type + "%' and billtype like '%" + fp_type + "%' and status = '03' order by num desc";
         }

      
         if (com == "成都")
         {
             cxsql= "select * from ord_receipt_view001 where COM ='" + com + "'"
       + " and status <> '99' and  ((lrtime between '" + bgndate + "' and '" + enddate + "') or (shtime between '" + shbgndate + "' and '" + shenddate + "'))  and num like '%" + ordbillno + "%'";

             contrlRepeater(cxsql + sqljc);

            // Response.Write(cxsql + sqljc);   
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
       string custname = this.ordbillno.Text.Trim();
        string sqljc = " and custom like '%" + custname + "%'   order by num desc";
        string com = Session["COM"].ToString();
        string jobno = Session["RememberName"].ToString();
        string role = Session["RoleID"].ToString();
        string sh = Session["sh_memo"].ToString();
        string bgndate = this.bgndate.Text.Trim();
        string enddate = this.enddate.Text.Trim();
        string shbgndate = this.shbgdate.Text.Trim();
        string shenddate = this.shendate.Text.Trim();
        string ordbillno = this.ordbillno.Text.Trim();

        if (com == "成都" && role =="7")
        {
            string dcsql = "update ord_receipt set is_dc = '1' where num in (select num from ord_receipt_view001 where COM = '" + com + "'and status<>'99' and ((lrtime between '" + bgndate + "' and '" + enddate + "') or (shtime between '" + shbgndate + "' and '" + shenddate + "')) and num like '%"+ordbillno+"%');";
            cc.execSQL01(dcsql);
           // Response.Write(dcsql);
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


    //Repeater分页控制显示方法
    private void BindDataToRepeater01(string sql)
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
public void contrlRepeater(string sql)

{

    SqlConnection con = new SqlConnection("server='192.168.11.21';database=PS_DB;uid=sa;pwd=abc@12345;");
    SqlConnection conn = new SqlConnection();
    DataSet ds = new DataSet();
    SqlDataAdapter sda = new SqlDataAdapter(sql, con);
    sda.Fill(ds, "newsTitle");
    PagedDataSource pds = new PagedDataSource();
    pds.DataSource = ds.Tables["newsTitle"].DefaultView;      
  
      pds.AllowPaging = true;    
      pds.PageSize = 100;
      try
      {
          pds.CurrentPageIndex = Convert.ToInt32(this.labPage.Text) - 1;

      }
      catch (Exception ex)
      {
          
      }
  
      LabCountPage.Text = pds.PageCount.ToString();    
      labPage.Text = (pds.CurrentPageIndex + 1).ToString();    
      this.lbtnpritPage.Enabled = true;    
      this.lbtnFirstPage.Enabled = true;    
      this.lbtnNextPage.Enabled = true;    
      this.lbtnDownPage.Enabled = true;    
      if(pds.CurrentPageIndex<1)  
  
      {  
  
           this.lbtnpritPage.Enabled = false;    
           this.lbtnFirstPage.Enabled = false;  
  
      }  
  
      if (pds.CurrentPageIndex == pds.PageCount-1)  
  
      {  
  
           this.lbtnNextPage.Enabled = false;   
           this.lbtnDownPage.Enabled = false;  
  
      }  
    rptList.DataSource = pds;
    rptList.DataBind();

}
    protected void lbtnpritPage_Click(object sender, EventArgs e)
    {

        this.labPage.Text = Convert.ToString(Convert.ToInt32(labPage.Text.ToString()) - 1);
         string com = Session["COM"].ToString();
        string jobno = Session["RememberName"].ToString();
        string role = Session["RoleID"].ToString();
         string sh = Session["sh_memo"].ToString();
         string bgndate = this.bgndate.Text.Trim();
         string enddate = this.enddate.Text.Trim();            
cxsql= "select * from ord_receipt_view001 where COM ='" + com + "'"
       + "  and   lrtime between '" + bgndate + "' and '" + enddate + "'";
             contrlRepeater(cxsql);     

    }



    protected void lbtnFirstPage_Click(object sender, EventArgs e)
    {

        this.labPage.Text = "1";
        string com = Session["COM"].ToString();
        string jobno = Session["RememberName"].ToString();
        string role = Session["RoleID"].ToString();
        string sh = Session["sh_memo"].ToString();
        string bgndate = this.bgndate.Text.Trim();
        string enddate = this.enddate.Text.Trim();
        cxsql = "select * from ord_receipt_view001 where COM ='" + com + "'"
               + "  and   lrtime between '" + bgndate + "' and '" + enddate + "'";
        contrlRepeater(cxsql);
     
    }



    protected void lbtnDownPage_Click(object sender, EventArgs e)
    {

       this.labPage.Text = this.LabCountPage.Text;
       string com = Session["COM"].ToString();
       string jobno = Session["RememberName"].ToString();
       string role = Session["RoleID"].ToString();
       string sh = Session["sh_memo"].ToString();
       string bgndate = this.bgndate.Text.Trim();
       string enddate = this.enddate.Text.Trim();
       cxsql = "select * from ord_receipt_view001 where COM ='" + com + "'"
              + " and   lrtime between '" + bgndate + "' and '" + enddate + "'";
       contrlRepeater(cxsql);
     
    }



    protected void lbtnNextPage_Click(object sender, EventArgs e)
    {

        this.labPage.Text = Convert.ToString(Convert.ToInt32(labPage.Text.ToString()) + 1);
        string com = Session["COM"].ToString();
        string jobno = Session["RememberName"].ToString();
        string role = Session["RoleID"].ToString();
        string sh = Session["sh_memo"].ToString();
        string bgndate = this.bgndate.Text.Trim();
        string enddate = this.enddate.Text.Trim();
        cxsql = "select * from ord_receipt_view001 where COM ='" + com + "'"
               + " and   lrtime between '" + bgndate + "' and '" + enddate + "'";
        contrlRepeater(cxsql);
     
    }
    protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
