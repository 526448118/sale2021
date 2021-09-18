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
using System.Data.OleDb;
using System.Data.OracleClient;


public partial class grace_Default1 : System.Web.UI.Page
{
    CommonClass cc = new CommonClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string org = "C001";
            string sql1 = "select * from readhscmp.lj_grace_dudao where orgcode = '" + org + "'";
           OracleDataReader rd = cc.ora_read(sql1);
            if (rd.Read())
            {
                this.orgcode.Text = rd["orgcode"].ToString();
                this.orgname.Text = rd["orgname"].ToString();
                this.dudao.Text = rd["dudao"].ToString();
                this.jingli.Text = rd["jingli"].ToString();
                rd.Close();
                rd.Dispose();
            }
            this.Label5.Text = org + "_" + orgname.Text;
        }

    }


    public void bind(string sql)
    {
        SqlConnection myConn = cc.Getconsql02();
        myConn.Open();
        SqlDataAdapter myda = new SqlDataAdapter(sql, myConn);
        DataSet myds1 = new DataSet();
        myda.Fill(myds1, "tb_Member1");
        GridView1.DataSource = myds1;
        GridView1.DataKeyNames = new string[] { "序号" };
        GridView1.DataBind();
        myConn.Close();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


        protected void Buttoncx_Click(object sender, EventArgs e)
        {
            string sql = "select * from mdjk_info where 门店编号 = '"+this.orgcode.Text.Trim()+"' and 欠款日期 = '"+this.qkdate.Text.Trim()+"'";
            bind(sql);
            string sql2 = "select ditinct 缴款说明 from mdjk_info where 门店编号 = '" + this.orgcode.Text.Trim() + "' and 欠款日期 = '" + this.qkdate.Text.Trim() + "'";
            plu_bind(sql2);
        }
        protected void plu_bind(string sql)
        {
            //打开与数据库的连接
            SqlConnection myConn = cc.Getconsql02();
            myConn.Open();

            //查询文件创建时间
            SqlDataAdapter dapt = new SqlDataAdapter(sql, myConn);
            DataSet ds = new DataSet();
            //填充数据集
            dapt.Fill(ds, "files");
            //绑定下拉菜单
            this.qksm.DataSource = ds.Tables["files"].DefaultView;   //定交数据源
            this.qksm.DataValueField = ds.Tables["files"].Columns[0].ToString();
            this.qksm.DataBind();
            //释放占用的资源
            ds.Dispose();
            dapt.Dispose();
            myConn.Close();
        }
        protected void qkid_SelectedIndexChanged(object sender, EventArgs e)
        {
            string qksm = this.qksm.SelectedValue;
            string sql = "select qkid from mdjk_qksm where qksm = '" + qksm + "'";
            string qkid1 = cc.ExecScalar1(sql);
            this.qkid.Text = qkid1;
        }
}
  
    
  