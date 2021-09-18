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
                btnExport.Visible = false;
            } //-----------------------------------------------------------------
        
    }


      protected void Bindsskc(string sqlStr)
    {
        SqlConnection myConn = cc.Getconsql02();
        myConn.Open();
        SqlDataAdapter myDa = new SqlDataAdapter(sqlStr, myConn);
        DataSet myDs = new DataSet();
        myDa.Fill(myDs);
        GridView1.DataKeyNames = new string[] { "num" };          
        GridView1.DataSource = myDs;
        GridView1.DataBind();
        myDa.Dispose();
        myDs.Dispose();
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
        string bgndate = this.bgndate.Text.Trim();
        string enddate = this.enddate.Text.Trim();
        string lrbgndate = this.bgndate0.Text.Trim();
        string lrenddate = this.enddate0.Text.Trim();
        string custname = this.custname.Text.Trim();
        string ywy = this.ywy.Text.Trim().ToUpper();
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
                string sql;
                string sql1 = "select ''''+num num,gxtime,xdorgcode,xdorgname,gyorg,jm,saler,cust_body,cust_body_tel,thdate,thtime thtime,"
                            + "thtype,plutype,custname,custnamecode,th_address,addcode,lrstaff,plucode,pluname,price,count,ystotal,zk,kp,sstotal,com,memo,isdc,"
                            + "last_dctime,dcn  from orgswpluinfo where plutype = '普通商品' and bill_status <> '99' and  custname like'%" + custname 
                            + "%' and isdc like '%" + isdc + "%' and (xdorgname like '%" + ywy + "%' or xdorgcode like'%" + ywy + "%' )";
               
                if ((bgndate == "" && enddate == "") && (lrbgndate != "" && lrenddate != ""))//提货时间为空，录入时间不为空
                {
                    sql = "and CONVERT(varchar(10),gxtime,23) between '" + lrbgndate + "' and '" + lrenddate + "' order by lrdate desc";
                    //Response.Write(sql1 + sql);
                    Bindsskc(sql1 + sql);
                    btnExport.Visible = true;
                }
                else if ((bgndate != "" && enddate != "") && (lrbgndate == "" && lrenddate == ""))//提货时间不为空，录入时间为空
                {
                    sql = "and cxthdate between '" + bgndate + "' and '" + enddate + "' order by lrdate desc";
                    Bindsskc(sql1 + sql);
                    //Response.Write(sql1 + sql);
                    btnExport.Visible = true;
                }
                else if ((bgndate == "" && enddate == "") && (lrbgndate == "" && lrenddate == "") && ywy == "" && custname == "")
                {
                    sql = "and CONVERT(varchar(10),gxtime,23) between '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and '" + DateTime.Now.ToString("yyyy-MM-dd") + "' order by lrdate desc";
                    Bindsskc(sql1 + sql);
                    //Response.Write(sql1 + sql);
                    btnExport.Visible = true;
                }
                else
                {
                    sql = "and cxthdate between '" + bgndate + "' and '" + enddate + "' and CONVERT(varchar(10),gxtime,23) between '" + lrbgndate + "' and '" + lrenddate + "' order by lrdate desc";
                    Bindsskc(sql1 + sql);
                    //Response.Write(sql1 + sql);
                    btnExport.Visible = true;
                }
            }
            else
            {
                return;
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

    private void Export(String FileType, String FileName)
    {

        Response.Clear();
        //HiddenField1.enable = false;
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
        GridView1.RenderControl(textWriter);
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
    protected void dc_Click(object sender, EventArgs e)
    {
        string role = Session["RoleID"].ToString();
        string bgndate = this.bgndate.Text.Trim();
        string enddate = this.enddate.Text.Trim();
        string custname = this.custname.Text.Trim();
        string ywy = this.ywy.Text.Trim();
        string ordstatus = this.ordstatus.SelectedValue;
        string dctime = DateTime.Now.ToString();
        int count = 0;
        string jobno = Session["RememberName"].ToString();
       
        //----------------
        if (role == "10")
        {
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                count++;
                string sql = "update ord_info set isdc = '1',last_dctime = '" + dctime + "' where num=" + GridView1.DataKeys[i].Value + "'";//因[i]中自带' 所以少加一个
                string sqlst = "insert into ord_status_dc(num,status,dctime,username) values(" + GridView1.DataKeys[i].Value + "','1','" + dctime + "','" + jobno + "')";
                //Response.Write(sqlst);
                cc.execSQL(sql);
                cc.execSQL(sqlst);
            }
            if (count == 0)
            {
                Response.Write("<script language=javascript>alert('未选中需要导出的订单！请重新选择。');location='cx_info.aspx'</script>");
            }
            Export("application/ms-excel", "订单信息.xls");
        }
        else
        {
            return;
        }
        //----------------

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowIndex > -1)
        {
            e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1);
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string  aa =  e.Row.Cells[1].Text.Trim();
            aa = aa.Replace("&#39;", "");
            
            e.Row.Attributes.Add("onMouseOver", "Col=this.style.backgroundColor;this.style.backgroundColor='#95B8FF'");
            e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor=Col;");
            e.Row.Attributes.CssStyle.Add("cursor", "hand");
            e.Row.Attributes.Add("onclick", "window.open('ord_info.aspx?id=" + aa + "')");
        }
    }
}
