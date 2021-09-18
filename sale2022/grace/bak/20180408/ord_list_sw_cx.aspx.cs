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

    //    this.billno.Text = DateTime.Now.ToString("yyyyMMdd"); 
      //      string com = Session["COM"].ToString();
    //        string jobno = Session["RememberName"].ToString();
    //        string role = Session["RoleID"].ToString();
    //        string sh = Session["sh_memo"].ToString();
            if (!IsPostBack)
            {
                
            } //-----------------------------------------------------------------
        
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
        string com = Session["COM"].ToString();
        string ordstatus = this.ordstatus.SelectedValue;      
        string jobno = Session["RememberName"].ToString();
        string role = Session["RoleID"].ToString();
        string sh = Session["sh_memo"].ToString();
         if (role == "10")
            {
                string isdc;
                if (ordstatus == "全部")
                {
                    isdc = "";
                }
                else if (ordstatus == "已导出")
                {
                    isdc = "已导出";
                }
                else
                {
                    isdc = "未导出";
                }
                string sql = "select *  from orgpluinfo01 where plutype = '普通商品' and num like '%" + billno + "%' and dept like '%" + ywy + "%' and  custname like'%" + custname + "%' and isdc like '%" + isdc + "%'  order by bill_status";
                BindDataToRepeater(sql);
               // Response.Write(sql);
            }
            else
            {
                
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
        string role = Session["RoleID"].ToString();
        string billno = this.billno.Text.Trim();
        string custname = this.custname.Text.Trim();
        string ywy = this.ywy.Text.Trim();
        string ordstatus = this.ordstatus.SelectedValue;
        string isdc;
        string dctime = DateTime.Now.ToString();
        if (ordstatus == "全部")
        {
            isdc = "%";
        }
        else if (ordstatus == "已导出")
        {
            isdc = "1";
        }
        else
        {
            isdc = "0";
        }
        if (role == "10")
        {
            string sql = "update ord_info set isdc = '1', last_dctime = '" + dctime + "'  where plutype = '普通商品' and num like '%" + billno + "%' and dept like '%" + ywy + "%' and  custname like'%" + custname + "%' and isdc like '" + isdc + "%'";
            //Response.Write(sql);
            SqlConnection myConn = cc.Getconsql02();
            myConn.Open();
            SqlCommand cmd = new SqlCommand(sql, myConn);
            cmd.CommandText = sql;
            cmd.Connection = myConn;
            cmd.ExecuteNonQuery();
            myConn.Close();
            Export("application/ms-excel", "订单信息.xls");
        }
        else 
        {
            return;
        }

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
    protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
}
