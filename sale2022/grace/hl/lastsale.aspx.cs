using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Collections;
using System.Xml;
using System.Text;
using System.IO;
using System.Net;
using System.Data.OracleClient;

public partial class grace_hl_test11 : System.Web.UI.Page
{
    CommonClass cc = new CommonClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string sql1 = "select orgcode||'_'||orgname from readhscmp.lj_grace_dudao where orgcode like 'C%'";
            //Response.Write(sql);
            plu_bind(sql1);
            this.dr1.Items.Insert(0, " ");
            this.dr1.Items.Insert(1, "%");
            string sql2 = "SELECT plucode||'_'||pluname FROM tSkuPlu where pluname not like '%删除%' and plucode like '1%'";
            //Response.Write(sql);
            plu_bind2(sql2);
            this.dr2.Items.Insert(0, " ");
            this.dr2.Items.Insert(1, "%");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string plucode;
        string orgcode;
        string bgndate = this.bgdate.Text.Trim();
        string enddate = this.endate.Text.Trim();
        if (this.dr2.Text.Length >= 8)
        {
            plucode = this.dr2.Text.Trim().Substring(0, 8);
        }
        else
        {
            plucode = this.dr2.Text.Trim();
        }
        if (this.dr1.Text.Length >= 4)
        {
            orgcode = this.dr1.Text.Trim().Substring(0, 4);
        }
        else
        {
            orgcode = this.dr1.Text.Trim();
        }
        string sql = "select * from readhscmp.hl_table_lastsale where orgcode like '" + orgcode + "%' and xsdate between '" + bgndate + "' and '" + enddate + "' and plucode like '" + plucode + "%' order by xsdate";
       //Response.Write(sql);
        bind(sql);
    }
    public void bind(string sql)
    {
        OracleConnection myConn = cc.Getconora();
        myConn.Open();
        string sqlstr = sql;
        OracleDataAdapter myda = new OracleDataAdapter(sqlstr, myConn);
        DataSet myds = new DataSet();
        myda.Fill(myds, "tb_Member");
        GridView1.DataSource = myds;
        GridView1.DataKeyNames = new string[] { "memberId" };
        GridView1.DataBind();
        myConn.Close();
    }
    protected void plu_bind(string sql)
    {
        //打开与数据库的连接
        OracleConnection myConn = cc.Getconora();
        myConn.Open();
        //查询文件创建时间
        OracleDataAdapter dapt = new OracleDataAdapter(sql, myConn);
        DataSet ds = new DataSet();
        //填充数据集
        dapt.Fill(ds, "files");
        //绑定下拉菜单
        this.dr1.DataSource = ds.Tables["files"].DefaultView;   //定交数据源
        this.dr1.DataValueField = ds.Tables["files"].Columns[0].ToString();
        this.dr1.DataBind();
        //释放占用的资源
        ds.Dispose();
        dapt.Dispose();
        myConn.Close();
    }
    protected void plu_bind2(string sql)
    {
        //打开与数据库的连接
        OracleConnection myConn = cc.Getconora();
        myConn.Open();
        //查询文件创建时间
        OracleDataAdapter dapt = new OracleDataAdapter(sql, myConn);
        DataSet ds = new DataSet();
        //填充数据集
        dapt.Fill(ds, "files");
        //绑定下拉菜单
        this.dr2.DataSource = ds.Tables["files"].DefaultView;   //定交数据源
        this.dr2.DataValueField = ds.Tables["files"].Columns[0].ToString();
        this.dr2.DataBind();
        //释放占用的资源
        ds.Dispose();
        dapt.Dispose();
        myConn.Close();
    }
    protected void dr1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void dc_Click(object sender, EventArgs e)
    {
        Response.Write(GridView1.Rows.Count);
        if (GridView1.Rows.Count > 0)
        {
            toExcel(this.GridView1);
        }
        else
        {
            Response.Write("<script>alert('没有内容可导！');window.history.back();</script>");
            //obo.Common.MessageBox.Show(this, "没有数据可导出，请先查询数据!"); 
        }
    
    }
    /// <summary>
    /// 导出到Excel
    /// </summary>
    /// <param name="gv"></param>
    void toExcel(GridView gv)
    {
        Response.Charset = "GB2312";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");

        string fileName = "export_"+DateTime.Now.ToString("yyyyMMddHHmmss")+".xls";
        string style = @"<style> .text { mso-number-format:\@; } </script> ";
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
        Response.ContentType = "application/excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        this.GridView1.RenderControl(htw);
        Response.Write(style);
        Response.Write(sw.ToString());
        Response.End();
    }
    /// <summary>
    /// 这个重写貌似是必须的
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    { 

    }

}