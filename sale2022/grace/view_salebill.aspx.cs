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
using System.Data.OracleClient;

public partial class _add_saleord : System.Web.UI.Page
{
    CommonClass cc = new CommonClass();
    private SqlCommand cmd = null; 
  
    protected void Page_Load(object sender, EventArgs e)
    {
        string billno = Request["id"];
        string ty = Request["ty"];
        //string billno = "2";
        string jobno = Session["RememberName"].ToString();
        //string jobno ="SC00913";
        string zzt = "select is_kp from ord_receipt where num='" + billno + "'";
        int c = Convert.ToInt32(DbHelperSQL.GetSingle(zzt));
        //Response.Write(ty+b);
        if (c == 10)
        {
            string s1 = "select gxtime from ord_receipt_status where billno='" + billno + "' and status = '10'";
            string gxtime = DbHelperSQL.GetSingle(s1).ToString();
            this.Label6.Text = "财务已开票|" + gxtime + "";
            Label6.Visible = true; Button4.Visible = false;
        }
          if (!IsPostBack)
          {
              string t = "select role_id from ps_manager where user_name='" + jobno + "'";
              int a = Convert.ToInt32(DbHelperSQL.GetSingle(t));

              string zt = "select status from ord_receipt where num='" + billno + "' ";
              int b = Convert.ToInt32(DbHelperSQL.GetSingle(zt));
             
              if (ty == "2")
              {
                  if (a == 5 && (b == 0 || b == 1))
                  {
                      this.shenhe1.Visible = this.Label1.Visible = this.Label2.Visible = false;
                      this.ordbillno.ReadOnly = false;
                  }
                  else if (a == 5 && b == 2)
                  {
                      this.shenhe.Visible = this.Label2.Visible = this.shenhe1.Visible = false;
                  }
                  else if (b == 3)
                  {
                      this.shenhe.Visible = this.shenhe1.Visible = this.Label1.Visible = this.zf.Visible = false;
                      if (c == 10)
                      {
                          this.Button4.Visible = false;
                      }
                      else if (a == 7 &&c!=10)
                      {                          
                          this.zf.Visible = true;
                          this.Button4.Visible = true;
                      }
                      else
                      {
                          this.Button4.Visible = true;
                      }
                  }
                  else if (a == 7 && b == 2)
                  {
                      this.shenhe.Visible = this.Label2.Visible = false;
                      this.ordbillno.ReadOnly = false;
                  }
                  else if (a == 7 && b == 1)
                  {
                      this.Label2.Text = "门市未审核";
                      this.shenhe.Visible = this.shenhe1.Visible = this.Label1.Visible = false;
                  }
                 
                  else if (b == 99)
                  {                     
                      this.shenhe.Visible = this.shenhe1.Visible = this.Label1.Visible = this.Label2.Visible = this.zf.Visible = false;
                      this.Label3.Visible = true;
                  }
                  else
                  {
                      this.shenhe.Visible = this.shenhe1.Visible = this.Label1.Visible = this.Label2.Visible = this.zf.Visible = false;
                  }
              }
              else if (ty == "1")
              {
                  if (b == 99)
                  {
                      this.shenhe.Visible = this.shenhe1.Visible = this.Label1.Visible = this.Label2.Visible = this.zf.Visible = false;
                      this.Label3.Visible = true;
                  }
                  else if (b == 2)
                  {
                      this.shenhe.Visible = this.shenhe1.Visible = this.Label3.Visible = this.Label2.Visible = this.zf.Visible = false;
                      this.Label1.Visible  = true;;
                  }
                  else if (b == 3)
                  {
                      this.shenhe.Visible = this.shenhe1.Visible = this.Label3.Visible = this.Label1.Visible = this.zf.Visible = false;
                      this.Label2.Visible =  true;
                      if (c == 10)
                      {
                          this.Button4.Visible = false;
                      }
                      else
                      {
                          this.Button4.Visible = true;
                      }
                  }
                  else
                  {
                      this.shenhe.Visible = this.shenhe1.Visible = this.Label1.Visible = this.Label2.Visible = false;
                  }
              }
              string sql = "select * from dbo.ord_receipt where num='" + billno + "' ";
              SqlDataReader rd = cc.ExceRead(sql);
              if (rd.Read())
              {
                  this.cen.Text = rd["cen"].ToString();
                  this.dept.Text = rd["dept"].ToString();
                  this.billtype.Text = rd["billtype"].ToString();
                  this.yw_people.Text = rd["yw_people"].ToString();
                  this.yw_peopletell.Text = rd["yw_peopletell"].ToString();
                  this.tick_record.Text = rd["tick_record"].ToString();
                  this.sale_source.Text = rd["sale_source"].ToString();
                  this.rec_address.Text = rd["rec_address"].ToString();
                  this.ordbillno.Text = rd["ordbillno"].ToString();
                  this.old_billno.Text = rd["old_billno"].ToString();
                  this.custom.Text = rd["custom"].ToString();
                  this.shuihao.Text = rd["shuihao"].ToString();
                  this.address.Text = rd["address"].ToString();
                  this.bank.Text = rd["bank"].ToString();
                  this.bank_acc.Text = rd["bank_acc"].ToString();
                  this.email.Text = rd["email"].ToString();
                  this.tellphone.Text = rd["tellphone"].ToString();
                  this.cust_lxr.Text = rd["cust_lxr"].ToString();
                  this.lxr_tel.Text = rd["lxr_tel"].ToString();
                  this.memo.Text = rd["memo"].ToString();
                  this.sq_date.Text = rd["gxtime"].ToString();
                  this.Label4.Text = rd["is_zy"].ToString();
                  rd.Close();
                  rd.Dispose();
                  bindsskc("select id 编号,billno 单据号,pluname 商品名称,plucount 商品数量,plumodel 商品规格,pluunit 商品单位 ,sstotal 实收金额,s_code 税收编码,lrr 录入人 from ord_receipt_plu where billno = '" + billno + "'");

                  decimal sum = 0;
                  foreach (GridViewRow row in GridView1.Rows)
                  {
                      sum += Convert.ToDecimal(row.Cells[6].Text);
                      //   Response.Write("显示值是："+row.Cells[5].Text);
                  }
                  Label5.Text = "整单总金额：" + sum.ToString();
              }
          }
   
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
        //  GridView1.DataKeyNames = new string[] { "" };
        GridView1.DataBind();
        myDa.Dispose();
        myDs.Dispose();
        myConn.Close();
    }












    protected void Button1_Click(object sender, EventArgs e)
    {
            string jobno = Session["RememberName"].ToString();
            string zfjobno = "(操作员：" + jobno + ")";
            string billno = Request["id"];
            string zfreason = "---作废原因："+zf_reason.Text.Trim();
            string ty = Request["ty"];
            string gxtime = DateTime.Now.ToString();
            string zftime = "【" + gxtime + "】";
            string status = "99";//作废
            string memo = this.memo.Text.Trim();
            string sql1 = "update ord_receipt set status = '99',memo = '" + memo + zfreason + zftime + zfjobno + "' where num = '" + billno + "' ";
            Response.Write(sql1);
            string sql2 = "insert into ord_receipt_status(billno,lrr,gxtime,status) values ('" + billno + "','" + jobno + "','" + gxtime + "','" + status + "')";
            
            SqlConnection myConn = cc.Getconsql02();
            myConn.Open();
            cc.execSQL01(sql1);
            //cc.execSQL01(sql2);
            string fh = cc.execSQL01(sql1).ToString();
            if (fh == "True")
                    {
                        Response.Write("<script>alert('提交成功！');</script>");
                        Response.Redirect("view_salebill.aspx?id=" + billno + "&ty=" + ty + "");
                    }
                    else
                    {
                        Response.Write("提交失败！");
                    }              
            myConn.Close();
            
    }
    protected void billtype_TextChanged(object sender, EventArgs e)
    {

    }
    protected void shenhe_Click(object sender, EventArgs e)
    {
        string jobno = Session["RememberName"].ToString();
        string billno = Request["id"];
        string ty = Request["ty"];
        string gxtime = DateTime.Now.ToString();
        string ordbillno = this.ordbillno.Text.Trim();
        string status = "02";//门市审核之后的状态
        string sql1 = "update ord_receipt set status = '02',ordbillno = '" + ordbillno + "' where num = '" + billno + "' ";
        string sql2 = "insert into ord_receipt_status(billno,lrr,gxtime,status) values ('" + billno + "','" + jobno + "','" + gxtime + "','" + status + "')";
        SqlConnection myConn = cc.Getconsql02();
        myConn.Open();
        ps_manager myuser = new ps_manager();
        string t = "select count(*) from ps_manager where user_name='" + jobno + "'and role_id='5' ";   //    
        int a = Convert.ToInt32(DbHelperSQL.GetSingle(t));
        string zt = "select status from ord_receipt_status where billno='" + billno + "' ";
        int b = Convert.ToInt32(DbHelperSQL.GetSingle(zt));
        if (a > 0)   //判断权限
        {
            if (b != 02 && b!= 99) //判断是否重复
            {
                cc.execSQL01(sql1);
                cc.execSQL01(sql2);
                string fh = cc.execSQL01(sql1).ToString();
                if (fh == "True")
                {
                    Response.Write("<script>alert('提交成功！');</script>");
                    Response.Redirect("view_salebill.aspx?id=" + billno + "&ty=" + ty + "");
                }
                else
                {
                    Response.Write("提交失败！");
                }
            }
            else if (b == 02)
            {
                Response.Write("<script>alert('不能重复审核！');</script>");
            }
            else if (b == 99)
            {
                Response.Write("<script>alert('已作废不能审核！');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('无门市审核权限！！');</script>");
            return;
        }
        myConn.Close();
    }

    protected void shenhe1_Click(object sender, EventArgs e)
    {
        string jobno = Session["RememberName"].ToString();
        string billno = Request["id"];
        string ty = Request["ty"];
        string gxtime = DateTime.Now.ToString();
        string ordbillno = this.ordbillno.Text.Trim();
        string status = "03";//门市审核之后的状态
        string sql1 = "update ord_receipt set status = '03',ordbillno = '" + ordbillno + "' where num = '" + billno + "' ";
        string sql2 = "insert into ord_receipt_status(billno,lrr,gxtime,status) values ('" + billno + "','" + jobno + "','" + gxtime + "','" + status + "')";
        SqlConnection myConn = cc.Getconsql02();
        myConn.Open();
        ps_manager myuser = new ps_manager();
        string t = "select count(*) from ps_manager where user_name='" + jobno + "'and role_id='7' ";   //    
        int a = Convert.ToInt32(DbHelperSQL.GetSingle(t));
        string zt = "select status from ord_receipt_status where billno='" + billno + "' ";
        int b = Convert.ToInt32(DbHelperSQL.GetSingle(zt));
        if (a > 0)   //判断权限
        {

            if (b != 03 && b != 99) //判断是否重复
            {
                cc.execSQL01(sql1);
                cc.execSQL01(sql2);

                string fh = cc.execSQL01(sql1).ToString();



                if (fh == "True")
                {
                    // Response.Write("提交成功！");
                    // bind();
                    Response.Write("<script>alert('提交成功！');</script>");
                    Response.Redirect("view_salebill.aspx?id=" + billno + "&ty=" + ty + "");
                }
                else
                {
                    Response.Write("提交失败！");
                }
            }
            else if (b == 03)
            {
                Response.Write("<script>alert('不能重复审核！');</script>");
            }
            else if (b == 99)
            {
                Response.Write("<script>alert('已作废不能审核！');</script>");
            }

        }
        else
        {
            Response.Write("<script>alert('无财务审核权限！！');</script>");
            return;
        }
        myConn.Close();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ITinfo_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        string jobno = Session["RememberName"].ToString();
        string billno = Request["id"];
        string ty = Request["ty"];
        string gxtime = DateTime.Now.ToString();
        string ordbillno = this.ordbillno.Text.Trim();
        string status = "10";//已开票的状态
        string sql1 = "update ord_receipt set is_kp = '10' where num = '" + billno + "' ";
        string sql2 = "insert into ord_receipt_status(billno,lrr,gxtime,status) values ('" + billno + "','" + jobno + "','" + gxtime + "','" + status + "')";
        SqlConnection myConn = cc.Getconsql02();
        myConn.Open();
        string t = "select count(*) from ps_manager where user_name='" + jobno + "'and role_id='5' ";   //    
        int a = Convert.ToInt32(DbHelperSQL.GetSingle(t));
        string zt = "select is_kp from ord_receipt where billno='" + billno + "' ";
        int b = Convert.ToInt32(DbHelperSQL.GetSingle(zt));
        if (a > 0)   //判断权限
        {
            if (b != 10) //判断是否重复
            {
                cc.execSQL01(sql1);
                cc.execSQL01(sql2);
                string fh = cc.execSQL01(sql1).ToString();
                if (fh == "True")
                {
                    // Response.Write("提交成功！");
                    // bind();
                    Response.Write("<script>alert('提交成功！');</script>");
                    Response.Redirect("view_salebill.aspx?id=" + billno + "&ty=" + ty + "");
                }
                else
                {
                    Response.Write("提交失败！");
                }
            }
            else if (b == 10)
            {
                Response.Write("<script>alert('不能重复确认！');</script>");
            }          
        }
        else
        {
            Response.Write("<script>alert('对不起，您无权进行此操作！！');</script>");
            return;
        }
        myConn.Close();
    }
}