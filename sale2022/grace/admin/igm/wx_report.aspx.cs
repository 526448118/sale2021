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

using System.IO;

public partial class admin_ms_main : System.Web.UI.Page
{
    CommonClass cc = new CommonClass();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            yw_bind();
            this.country.Items.Insert(0, "%");
           // string uname = Session["uname"].ToString();
            this.bgndate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.enddate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.type2.Checked = true;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
     /* if (GridView1.Rows.Count > 0)
        {

            ExcelOut(this.GridView1);

        }
        else
        {
            Response.Write("<script>alert('请完全填写！');window.history.back();</script>");
            //obo.Common.MessageBox.Show(this, "没有数据可导出，请先查询数据!"); 
        }  */  
        Response.Write("<script>window.close();</script");
        //关闭按钮


        //关闭页面--要弹出提示（IE6及以下不弹出提示）
        //   ClientScript.RegisterStartupScript(Page.GetType(), "", "<script language=javascript>window.opener=null;window.close();</script>");

        //不弹出提示直接关闭页面
      //  ClientScript.RegisterStartupScript(Page.GetType(), "", "<script language=javascript>window.opener=null;window.open('','_self');window.close();</script>");
    }
    protected void bindsskc(string sqlStr)
    {
        SqlConnection myConn = cc.Getconsql02();
        myConn.Open();
        //string sqlStr = " select orgname,orgcode,preorgcode from hscmp.tOrgManage where preorgcode='1102' ";
        SqlDataAdapter myDa = new SqlDataAdapter(sqlStr, myConn);
        DataSet myDs = new DataSet();
        myDa.Fill(myDs);
        GridView1.DataSource = myDs;
        GridView1.DataKeyNames = new string[] { "ID号" };
        GridView1.DataBind();
        myDa.Dispose();
        myDs.Dispose();
        myConn.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
     //   string aa = "1023";
      //  string ab = aa.Substring(0,2);
        //Response.Write(ab);
        string sql;
        string uname = Session["uname"].ToString();
        string bgndate = this.bgndate.Text.Trim();
        string enddate = this.enddate.Text.Trim();
        string mem = this.mem.Text.Trim();
        string ywtype = this.country.SelectedItem.Text;
        string company = Session["company"].ToString();
       
        if (this.wx.Checked == true)
        {
            sql = "select * from queview where 提报时间 between '" + bgndate + "' and '" + enddate + "' and ( 问题摘要 like '%" + mem + "%' or 提报人 like '%" + mem + "%') and 问题状态='未结案' and 问题类型 like '" + ywtype + "%' AND 公司='" + company + "' and 是否外修='外修' ORDER BY 提报时间,处理情况 desc";
        }
        else
        {
            if (this.CheckBox1.Checked == true)
            {
                if (this.type1.Checked == true)
                {
                    sql = "select * from queview where 提报时间 between '" + bgndate + "' and '" + enddate + "' and ( 问题摘要 like '%" + mem + "%' or 提报人 like '%" + mem + "%') and 问题状态='已结案' and 问题类型 like '" + ywtype + "%' AND 公司='" + company + "' and 处理情况<>'已解决' ORDER BY 提报时间,处理情况 desc";
                }
                else if (this.type2.Checked == true)
                {
                    sql = "select * from queview where 提报时间 between '" + bgndate + "' and '" + enddate + "' and ( 问题摘要 like '%" + mem + "%' or 提报人 like '%" + mem + "%')  and 问题状态='未结案' and 问题类型 like '" + ywtype + "%' and 公司='" + company + "' and 处理情况<>'已解决' ORDER BY 提报时间,处理情况 desc";
                }
                else
                {
                    sql = "select * from queview where substring(CONVERT(varchar,提报时间, 120 ),1,10) between '" + bgndate + "' and '" + enddate + "' and ( 问题摘要 like '%" + mem + "%' or 提报人 like '%" + mem + "%') and 问题类型 like '" + ywtype + "%' and 公司='" + company + "' and 处理情况<>'已解决' ORDER BY 提报时间,处理情况 desc";
                }
            }
            else
            {
                if (this.type1.Checked == true)
                {
                    sql = "select * from queview where 提报时间 between '" + bgndate + "' and '" + enddate + "' and ( 问题摘要 like '%" + mem + "%' or 提报人 like '%" + mem + "%') and 问题状态='已结案' and 问题类型 like '" + ywtype + "%' AND 公司='" + company + "' ORDER BY 提报时间,处理情况 desc";
                }
                else if (this.type2.Checked == true)
                {
                    sql = "select * from queview where 提报时间 between '" + bgndate + "' and '" + enddate + "' and ( 问题摘要 like '%" + mem + "%' or 提报人 like '%" + mem + "%')  and 问题状态='未结案' and 问题类型 like '" + ywtype + "%' and 公司='" + company + "' ORDER BY 提报时间,处理情况 desc";
                }
                else
                {
                    sql = "select * from queview where substring(CONVERT(varchar,提报时间, 120 ),1,10) between '" + bgndate + "' and '" + enddate + "' and ( 问题摘要 like '%" + mem + "%' or 提报人 like '%" + mem + "%') and 问题类型 like '" + ywtype + "%' and 公司='" + company + "' ORDER BY 提报时间,处理情况 desc";
                }
            }
        }
      // Response.Write(sql);

        bindsskc(sql);
        if (GridView1.PageCount > 0)     //  如果页数大于0  
        {

            GridView1.PageIndex = GridView1.PageCount - 1;   //  将当前显示页的索引转到最后一页  
            GridView1.DataBind();         //重新绑定数据，这是十分重要，这样才能到达最后一页 
            int lastSize = GridView1.Rows.Count;          //  然后获得最后一页的行数  
            if (GridView1.PageCount > 1)    //  如果页数大于1页，则计算出  
            {                                                       //  总行数=（总页数-1）* 每页行数 +  最后一页的行数 
                int rowsCount = GridView1.PageSize * (GridView1.PageCount - 1) + lastSize;
                recordCount.Text = "【记录" + rowsCount.ToString() + "条】";      //  将它赋给一个Label 
            }
            else
                recordCount.Text = "【记录" + lastSize.ToString() + "条】";   //如果页数只有一页，则直接将该页的行数赋给Label 
            GridView1.PageIndex = 0;
        }
        else
        {
            recordCount.Text = "0";     //  如果无记录，页显示0 
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Attributes.Add("onMouseOver", "Color=this.style.backgroundColor;this.style.backgroundColor='#FFCCCC'");
        e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor=Color;");
        //e.Row.Attributes.Add("onclick", "window.location.href('../dd/dd_audit.aspx?id=" + e.Row.Cells[4].Text + "')");
      //  e.Row.Attributes.Add("onclick", "window.open('../admin/view_info_admin.aspx?id=" + e.Row.Cells[0].Text + "')");
        e.Row.Cells[2].Attributes.Add("onclick", "window.open('../admin/view_info_admin.aspx?id=" + e.Row.Cells[0].Text + "')");
        /* if (e.Row.RowIndex != -1)
         {
             int id = e.Row.RowIndex + 1;
             e.Row.Cells[0].Text = id.ToString();
         }*/

       /* if (e.Row.RowIndex != -1)
        {
            int indexID = this.GridView2.PageIndex * this.GridView2.PageSize + e.Row.RowIndex + 1;
            e.Row.Cells[0].Text = indexID.ToString();
        }*/
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // string bqred = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "工号"));
            // if (bqred == "SC00913")
            // { 
            //     e.Row.BackColor = System.Drawing.Color.Brown;
            //  }

            // e.Row.Cells[5].BackColor = System.Drawing.Color.Brown;
         //   e.Row.Cells[6].BackColor = System.Drawing.Color.Red;
         //   e.Row.Cells[11].BackColor = System.Drawing.Color.Red;
            //e.Row.Cells[].BackColor = System.Drawing.Color.Brown;

            string abc = e.Row.Cells[5].Text.Trim();
           // if (Convert.ToInt32(abc) != 2)
            if(abc=="资讯类报修")
            {
                e.Row.Cells[5].BackColor = System.Drawing.Color.LightSeaGreen;
                e.Row.Cells[3].BackColor = System.Drawing.Color.LightSeaGreen;
            }
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("default2.aspx");
    }
    public void ExcelOut(GridView gv)
    {
        if (gv.Rows.Count > 0)
        {
            Response.Clear();
            Response.ClearContent();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + DateTime.Now.ToString("_yyyyMMdd_HHmmss") + ".xls");
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        else
        {
            Response.Write("没有数据");
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }

    protected void yw_bind()
    {
        //打开与数据库的连接
        SqlConnection myConn = cc.Getconsql02();
        myConn.Open();

        //查询文件创建时间
        SqlDataAdapter dapt = new SqlDataAdapter("select * from [jc_ywtype] order by ywname", myConn);
        // Response.Write("aa");
        DataSet ds = new DataSet();
        //填充数据集
        dapt.Fill(ds, "files");
        //绑定下拉菜单
        this.country.DataSource = ds.Tables["files"].DefaultView;   //定交数据源
        // this.com.DataTextField = ds.Tables["files"].Columns[0].ToString();     
        this.country.DataTextField = ds.Tables["files"].Columns[1].ToString();
        this.country.DataValueField = ds.Tables["files"].Columns[0].ToString();

        this.country.DataBind();
        //释放占用的资源
        ds.Dispose();
        dapt.Dispose();
        myConn.Close();
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
       if (GridView1.Rows.Count > 0)
        {

            ExcelOut(this.GridView1);

        }
        else
        {
            Response.Write("<script>alert('请完全填写！');window.history.back();</script>");
            //obo.Common.MessageBox.Show(this, "没有数据可导出，请先查询数据!"); 
        }
    
    }
  /*  protected void Button5_Click(object sender, EventArgs e)
    {
        string url = "/grace/device_info.aspx";
        //  Response.Redirect(url);
        Response.Write("<script language='javascript'>window.open('" + url + "','_blank');</script>");
    }*/
}