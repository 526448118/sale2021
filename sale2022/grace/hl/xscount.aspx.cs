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
            this.cd.Checked = true;
            string sql1 = "select orgcode||'_'||orgname from readhscmp.torgmanage where orgcode like 'C%' and orgname not like '%已关%' order by orgcode";          
            plu_bind(sql1);
            this.dr1.Items.Insert(0, " ");
            this.dr1.Items.Insert(1, "%");
            string sql2 = "SELECT plucode||'_'||pluname FROM tSkuPlu where pluname not like '%删除%' and plucode like '2%'";
            plu_bind2(sql2);
            this.dr2.Items.Insert(0, "%");
            this.firstpage.Enabled = this.lpage.Enabled = this.npage.Enabled = this.lastpage.Enabled = false;
        }
      
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        bind(1);       

        
    }
    public void bind(int Pagenum)
    {
        string plucode;
        string orgcode;

        string bgndate = this.bgdate.Text.Trim();
        string enddate = this.endate.Text.Trim();
        if (string.IsNullOrEmpty(this.bgdate.Text.Trim()) || string.IsNullOrEmpty(this.endate.Text.Trim()) )
        {
            return;
        }
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
        DateTime bgnTime = Convert.ToDateTime(bgndate);
        DateTime endTime = Convert.ToDateTime(enddate);
        int month = (endTime.Year - bgnTime.Year) * 12 + (endTime.Month - bgnTime.Month);//计算起始日期和结束日期时间差
        string mm = endTime.ToString("yyyyMM");
        StringBuilder ss = new StringBuilder();//建立可连续叠加的字符串  查询商品单数和销售数量
        StringBuilder ss2 = new StringBuilder();//建立可连续叠加的字符串 查询总单数
        string sqln = "";
        string sqlbc= "";
        for (int i = 1; i <= month; i++)//根据时间差进行循环
        {
            string mm2 = endTime.AddMonths(-i).ToString("yyyyMM");//取出循环中的月份
            sqln = " union all select * from (SELECT orgcode,orgcode||to_char(xsdate,'yyyymmdd')||plucode keyw,to_char(xsdate, 'yyyy-mm-dd') xsdate,PLUCODE,pluname,price,count(plucode) billcount,sum(xscount) xscount from tsalsalePLU" + mm2 + " where pluname not like '%手提袋%' and orgcode like '" + orgcode + "%' and plucode like '2%' and plucode <> '*' and to_char(xsdate, 'yyyy-mm-dd') between  '" + bgndate + "' and '" + enddate + "'  and plucode like '" + plucode + "%' group by orgcode, to_char(xsdate, 'yyyy-mm-dd'), PLUCODE, pluname,price,orgcode||to_char(xsdate,'yyyymmdd')||plucode order by xsdate)";
            sqlbc = "union all SELECT * FROM tsalsalePLU" + mm2 + " WHERE pluname not like '%手提袋%' and PLUCODE LIKE '2%'  and to_char(xsdate, 'yyyy-mm-dd') between  '" + bgndate + "' and '" + enddate + "'  and plucode like '" + plucode + "%' AND  orgcode like '" + orgcode + "%'";
            ss.Append(sqln);//循环出sql语句并写入ss
            ss2.Append(sqlbc);
        }
        //本月月表数据
        string sql = "select * from (SELECT orgcode,orgcode||to_char(xsdate,'yyyymmdd')||plucode keyw,to_char(xsdate, 'yyyy-mm-dd') xsdate,PLUCODE,pluname,price,count(plucode) billcount,sum(xscount) xscount from tsalsalePLU" + mm + " where pluname not like '%手提袋%' and orgcode like '" + orgcode + "%' and plucode like '2%' and plucode <> '*' and to_char(xsdate, 'yyyy-mm-dd') between  '" + bgndate + "' and '" + enddate + "'  and plucode like '" + plucode + "%' group by orgcode, to_char(xsdate, 'yyyy-mm-dd'), PLUCODE, pluname,price,orgcode||to_char(xsdate,'yyyymmdd')||plucode order by xsdate)";
        string sqlbc2 = "SELECT  * FROM tsalsalePLU" + mm + " WHERE pluname not like '%手提袋%' and PLUCODE LIKE '2%'  and to_char(xsdate, 'yyyy-mm-dd') between  '" + bgndate + "' and '" + enddate + "'  and plucode like '" + plucode + "%' AND  orgcode like '" + orgcode + "%'";

        //实时表数据
        string sqlnow = " union all select * from (SELECT orgcode,orgcode||to_char(xsdate,'yyyymmdd')||plucode keyw,to_char(xsdate, 'yyyy-mm-dd') xsdate,PLUCODE,pluname,price,count(plucode) billcount,sum(xscount) xscount from tsalsalePLU where pluname not like '%手提袋%' and orgcode like '" + orgcode + "%' and plucode like '2%' and plucode <> '*' and to_char(xsdate, 'yyyy-mm-dd') between  '" + bgndate + "' and '" + enddate + "'  and plucode like '" + plucode + "%' group by orgcode, to_char(xsdate, 'yyyy-mm-dd'), PLUCODE, pluname,price,orgcode||to_char(xsdate,'yyyymmdd')||plucode order by xsdate) ";
        string sqlbcnow = "union all SELECT  * FROM tsalsalePLU WHERE pluname not like '%手提袋%' and PLUCODE LIKE '2%'  and to_char(xsdate, 'yyyy-mm-dd') between  '" + bgndate + "' and '" + enddate + "'  and plucode like '" + plucode + "%' AND  orgcode like '" + orgcode + "%'";

        OracleConnection myConn = cc.Getconora();
        myConn.Open();
        string sqlstr;
        if (Pagenum == 1)
        {
            sqlstr = "select * from (select a.*,b.th from (" + sql + ss + sqlnow + ") a left join readhscmp.hl_tab_billth b on a.keyw = b.keyno order by xsdate) where rownum <= 20 *" + Pagenum + "  order by xsdate";
        }
        else
        {
            int Pagenum1 = Pagenum - 1;
            sqlstr = "select * from (select a.*,rownum rw from（select c.*,b.th from  (" + sql + ss + sqlnow + ") c left join readhscmp.hl_tab_billth b on c.keyw = b.keyno  order by xsdate)a) where rw <= 20 *" + Pagenum + "  and rw > 20 *" + Pagenum1 + " order by xsdate ";

        }
         //Response.Write(sqlstr);
         OracleDataAdapter myda = new OracleDataAdapter(sqlstr, myConn);
         DataSet myds = new DataSet();
         myda.Fill(myds, "tb_Member");
         GridView1.DataSource = myds;
         GridView1.DataKeyNames = new string[] { "keyw" };
         GridView1.DataBind();

        string sqlstr2 = "select a.*,b.th from (" + sql + ss + sqlnow + ") a left join readhscmp.hl_tab_billth b  on a.keyw = b.keyno order by xsdate";
        string sqlstrbc = "select count(distinct saleno) from (" + sqlbc2 + ss2 + sqlbcnow + ") WHERE PLUCODE LIKE '2%'  and to_char(xsdate, 'yyyy-mm-dd') between  '" + bgndate + "' and '" + enddate + "'  and plucode like '" + plucode + "%' AND  orgcode like '" + orgcode + "%' order by xsdate";

       // Response.Write(sqlstr2);
       // Response.Write(sqlstrbc);
        OracleDataAdapter myda2 = new OracleDataAdapter(sqlstr2, myConn);
        DataSet myds2 = new DataSet();
        myda2.Fill(myds2, "tb_Member2");
        GridView2.DataSource = myds2;
        GridView2.DataKeyNames = new string[] { "keyw" };
        GridView2.DataBind();
        this.Label7.Visible = this.Label8.Visible = this.Label9.Visible = true;
        this.Label8.Text = GridView2.Rows.Count.ToString();
        int count = GridView2.Rows.Count;
        int pcou = GridView2.Rows.Count % 20;
        string pagecount;
        //Response.Write(sqlstrbc);
        string bc = cc.ExecScalar(sqlstrbc);
        this.Label14.Text = bc;
        if (pcou == 0)
        {
            pagecount = Convert.ToString(count / 20);
            this.Label10.Text = pagecount;
        }
        else
        {
            pagecount = Convert.ToString((count / 20) + 1);
            this.Label10.Text = pagecount;
        }
        this.Label11.Text = Pagenum.ToString();
        myConn.Close();


        //判断按钮是否显示
        if (Label11.Text == "1")//首页
        {
            this.firstpage.Enabled = this.lpage.Enabled = false;
            this.npage.Enabled = this.lastpage.Enabled = true;
        }
        else if (Label11.Text == Label10.Text)//尾页
        {
            this.firstpage.Enabled = this.lpage.Enabled = true;
            this.npage.Enabled = this.lastpage.Enabled = false;
        }
        else if (this.Label10.Text == "0")
        {
            this.firstpage.Enabled = this.lpage.Enabled = this.npage.Enabled = this.lastpage.Enabled = false;
        }
        else
        {
            this.firstpage.Enabled = this.lpage.Enabled = this.npage.Enabled = this.lastpage.Enabled = true;
        }
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
        Response.Write(GridView2.Rows.Count);
        if (GridView2.Rows.Count > 0)
        {
            toExcel(this.GridView2);
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
        this.GridView2.Visible = true;
        Response.Charset = "GB2312";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");

        string fileName = "Export_"+DateTime.Now.ToString("yyyyMMddHHmmss")+".xls";
        string style = @"<style> .text { mso-number-format:\@; } </script> ";
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
        Response.ContentType = "application/excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        this.GridView2.RenderControl(htw);
        Response.Write(style);
        Response.Write(sw.ToString());
        Response.End();
        this.GridView2.Visible = false;
    }
    /// <summary>
    /// 这个重写貌似是必须的
    /// </summary>
    /// <param name="control"></param>
    public override void VerifyRenderingInServerForm(Control control)
    { 

    }


    protected void first_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Label10.Text) <= 1)
        {
            return;
        }
        {
            bind(1);
        }
    }
    protected void l_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Label11.Text) <= 1)
        {
            return;
        }
        else
        {
            int a = Convert.ToInt32(this.Label11.Text) - 1;
            bind(a);
        }

    }
    protected void n_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Label10.Text) == Convert.ToInt32(Label11.Text))
        {
            return;
        }
        else
        {
            int a = Convert.ToInt32(this.Label11.Text) + 1;
            bind(a);
        }
    }
    protected void last_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Label10.Text) == Convert.ToInt32(Label11.Text))
        {
            return;
        }
        else
        {
            int a = Convert.ToInt32(this.Label10.Text);
            bind(a);
        }
    }
    protected void jp_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(this.TextBox1.Text) > Convert.ToInt32(Label10.Text) || Convert.ToInt32(this.TextBox1.Text) < 0)
        {
            Response.Write("<script>alert('请输入1 到" + Label10.Text + "之间的数字！');</script>");
            return;
        }
        else
        {
            int a = Convert.ToInt32(this.TextBox1.Text);
            bind(a);
        }
    }
    protected void a_CheckedChanged(object sender, EventArgs e)
    {
        if (this.cd.Checked == true)
        {
            string sql1 = "select orgcode||'_'||orgname from readhscmp.torgmanage where orgcode like 'C%' and orgname not like '%已关%' order by orgcode";
            plu_bind(sql1);
            this.dr1.Items.Insert(0, " ");
            this.dr1.Items.Insert(1, "%");
        }
        else if (this.xm.Checked == true)
        {
            string sql1 = "select orgcode||'_'||orgname from readhscmp.torgmanage where orgcode like 'X%' and orgname not like '%已关%' order by orgcode";
            plu_bind(sql1);
            this.dr1.Items.Insert(0, " ");
            this.dr1.Items.Insert(1, "%");
        }
        else if (this.fz.Checked == true)
        {
            string sql1 = "select orgcode||'_'||orgname from readhscmp.torgmanage where orgcode like 'F%' and orgname not like '%已关%' order by orgcode";
            plu_bind(sql1);
            this.dr1.Items.Insert(0, " ");
            this.dr1.Items.Insert(1, "%");
        }
        else
        {

        }
    }


}