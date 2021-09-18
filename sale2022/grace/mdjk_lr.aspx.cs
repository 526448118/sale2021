using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections;

public partial class admin_jk_lr01 : System.Web.UI.Page
{
    //定义数据源 table
    public static DataTable Cpdt;
    CommonClass cc = new CommonClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uname"] == null)
        {
            Session["uname"] = "C001_小天店";
        }
        //this.com.Text = Session["company"].ToString();
        this.Label1.Text = Session["uname"].ToString();
        string storeno = Session["uname"].ToString().Substring(0,4);
        string storename = Session["uname"].ToString().Substring(5);
        this.storeno.Text = storeno;
        this.storename.Text = storename;

        string company = Session["uname"].ToString();
        string company1;
        if (company.Substring(0, 1) == "C")
        {
            company1 = "成都";
        }
        else if (company.Substring(0, 1) == "X")
        {
            company1 = "厦门";
        }
        else
        {
            company1 = "福州";
        }
        this.com.Text = company1;
        if (!IsPostBack)
        {                         
            this.bank.Items.Insert(0, "...请选择...");
        }
        zb_bind();
        string sql2 = "select * from mdjk_info where 门店编号 = '" + this.storeno.Text.Trim().ToUpper() + "'   and 单据状态 = '0' order by 序号";
        bind(sql2);
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

       
    }
 
    protected void zb_bind()
    {
        //打开与数据库的连接
        SqlConnection myConn = cc.Getconsql02();
        myConn.Open();

        //查询文件创建时间
        SqlDataAdapter dapt = new SqlDataAdapter("select * from storesys.dbo.jkbank order by num", myConn);
        // Response.Write("aa");
        DataSet ds = new DataSet();
        //填充数据集
        dapt.Fill(ds, "files");
        //绑定下拉菜单
        this.bank.DataSource = ds.Tables["files"].DefaultView;   //定交数据源  
        this.bank.DataTextField = ds.Tables["files"].Columns[0].ToString();
        this.bank.DataValueField = ds.Tables["files"].Columns[0].ToString();

        this.bank.DataBind();
        //释放占用的资源
        ds.Dispose();
        dapt.Dispose();
        myConn.Close();
    }

    protected void Button2_Click(object sender, System.EventArgs e)
    {
        string xh = this.xuh.Text.Trim();
        string ckr = this.ckrcode.Text.Trim();
        string lrr = this.lrrcode.Text.Trim();
        string gxdate = DateTime.Now.ToString();
        string jkmemo = this.jkmemo.Text.Trim();
        string jktotal = this.jktotal.Text.ToString();
        string bank = this.bank.SelectedValue;
        string sjjkdate = this.jkdate.Text.Trim();
        string sql0 = "select 单据状态 from mdjk_info where 序号 = '" + xh + "'";
        string status = cc.ExecScalar1(sql0);
        if (status == "0")
        {
            string sql = "update mdjk_info set 门店存款人 = '" + ckr + "',门店录入人 = '" + lrr + "',实存金额 = '" + jktotal + "',存款银行 ='" + bank + "',门店缴款时间 = '" + sjjkdate + "',门店更新时间= '" + gxdate + "',门店存款备注 = '" + jkmemo + "',单据状态 = '1' where 序号 = '" + xh + "'";
            // Response.Write(sql);
            try
            {
                string fh = cc.execSQL01(sql).ToString();
                if (fh == "True")
                {
                    Response.Write("<script>alert('提交成功！');window.location.href ='jk_lr01.aspx';</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("提交失败,失败原因:" + ex.Message);
            }
        }
        else
        {
            Response.Write("无权进行此操作！");
        }

    }

  void  bgn_bind()
    {
        string jkdate = DateTime.Now.ToString("yyyy-MM-dd");
        string sql = "select * from jkord where jkdate='" + jkdate + "' order by zbdate";
        SqlDataReader rd = cc.ExceRead(sql);
        int i = 1;
        while (rd.Read())
        {
            DataRow myrow = Cpdt.NewRow();
            if (Cpdt.Rows.Count == 0)
            {
                myrow[0] = i;
            }
            else
            {
                myrow[0] = int.Parse(Cpdt.Rows[Cpdt.Rows.Count - 1][0].ToString()) + 1;
                //myrow[0] = i+ 1;
            }
            myrow[1] = rd["jobno"].ToString();
            //------------

            //------------
            myrow[2] = rd["name"].ToString();
            myrow[3] = rd["com"].ToString();
            myrow[4] = rd["zbdate"].ToString();
            DateTime dd = Convert.ToDateTime(rd["zbdate"].ToString());
            myrow[5] = cc.Geteek(dd);
            Cpdt.Rows.Add(myrow);
            // var mm = Cpdt.AsEnumerable().Sum(p => Convert.ToDouble(p["SL"]));
            //Label3.Text = mm.ToString();
            Cpdt.AcceptChanges();
            GridView1.DataKeyNames = new string[] { "CPID" };
            GridView1.DataSource = Cpdt;
            GridView1.DataBind();
        }
        rd.Close();
    }


  protected void Button4_Click(object sender, System.EventArgs e)
  {
      this.qktype.Text = this.qktotal.Text = this.jkdate0.Text = this.cw_lrr.Text = this.qkdate.Text = string.Empty;
      this.ckrcode.Text = this.lrrcode.Text = this.jktotal.Text = this.jkdate.Text = this.jkmemo.Text = string.Empty;

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
  protected void Button5_Click(object sender, System.EventArgs e)
  {
      Response.Redirect("main.aspx");
  }



  protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
  {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
          e.Row.Attributes.Add("onMouseOver", "Color=this.style.backgroundColor;this.style.backgroundColor='#95CACA'");
          e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor=Color;");
          e.Row.Attributes.CssStyle.Add("cursor", "hand");
          string id = e.Row.Cells[15].Text.ToString();
          e.Row.Attributes.Add("onclick", "return me(" + id + ")");
      }
  }
  protected void GridView1_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
  {

  }
  protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
  {

  }

  public void method(object sender, EventArgs e)  
  {
      string id = this.HidTagId.Value;
      string sql1 = "select 单据状态 from mdjk_info where 序号= '" + id + "'";
      string status = cc.ExecScalar1(sql1);
      if (status == "0")
      {
          string sql = "select * from mdjk_info where 序号= '" + id + "'";
          SqlDataReader rd = cc.ExceRead(sql);
          if (rd.Read())
          {
              this.qktype.Text = rd["款项ID"].ToString() + "_" + rd["缴款说明"].ToString();
              this.qktotal.Text = rd["应存金额"].ToString();
              this.qkdate.Text = rd["欠款日期"].ToString();
              this.cw_lrr.Text = rd["财务导入人"].ToString();
              this.xuh.Text = rd["序号"].ToString();

          }
      }
      else
      {
          return;
      }
  }

  protected void jkrcode_TextChanged(object sender, System.EventArgs e)
  {
      string usercode = this.ckrcode.Text.ToUpper().ToString();
      string sqlqr = "select count(*) from storesys.dbo.u_admin where upper(usercode) ='" + usercode + "'";
      string user0 = cc.ExecScalar1(sqlqr);
      if (user0 != "0")
      {
          string sqlcd = "select usercode+'_'+username from storesys.dbo.u_admin where usercode ='" + usercode + "'";
          string user1 = cc.ExecScalar1(sqlcd);
          //Response.Write(user1);
          this.ckrcode.Text = user1;
      }
      else
      {
          Response.Write("<script>alert('工号填写错误或工号不存在！');</script>");
          return;
          //Response.Write(usercode);
      }
  }
  protected void lrrcode_TextChanged(object sender, System.EventArgs e)
  {
      string usercode = this.lrrcode.Text.ToUpper().ToString();
      string sqlqr = "select count(*) from storesys.dbo.u_admin where upper(usercode) ='" + usercode + "'";
      string user0 = cc.ExecScalar1(sqlqr);
      if (user0 != "0")
      {
          string sqlcd = "select usercode+'_'+username from storesys.dbo.u_admin where usercode ='" + usercode + "'";
          string user1 = cc.ExecScalar1(sqlcd);
          //Response.Write(user1);
          this.lrrcode.Text = user1;
      }
      else
      {
          Response.Write("<script>alert('工号填写错误或工号不存在！');</script>");
          return;
          //Response.Write(usercode);
      }
  }
  protected void Button6_Click(object sender, System.EventArgs e)
  {
      string sql = "";
      string status = this.status.SelectedValue;
      if (status == "全部")
      {
          status = "";
      }
      if (string.IsNullOrEmpty(this.jkdate0.Text.Trim()))  //判断空值
      {
          sql = "select * from mdjk_info where 门店编号 = '" + this.storeno.Text.Trim().ToUpper() + "'  and 单据状态 like '%" + status + "%' order by 序号";
      }
      else
      {
          sql = "select * from mdjk_info where 门店编号 = '" + this.storeno.Text.Trim().ToUpper() + "'  and 欠款日期 = '" + this.jkdate0.Text.Trim() + "'  and 单据状态 like '%" + status + "%' order by 序号";
      }
      bind(sql);
  }
}