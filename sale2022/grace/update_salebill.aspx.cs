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
    public static DataTable Cpdt;
    CommonClass cc = new CommonClass();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        string billno = Request["id"];
        //string billno = "2";
        string jobno = Session["RememberName"].ToString();
         // string jobno ="SC00913";

          if (!IsPostBack)
          {
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
                 // this.sale_source.Text = rd["sale_source"].ToString();

                  string sale_source = rd["sale_source"].ToString().Trim();
                  this.sale_source.SelectedIndex = this.sale_source.Items.IndexOf(this.sale_source.Items.FindByValue(sale_source));

                  this.rec_address.Text = rd["rec_address"].ToString();
                  this.ordbillno.Text = rd["ordbillno"].ToString();
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
                  this.IS_ZY.Text = rd["is_zy"].ToString();
                  rd.Close();
                  rd.Dispose();
                  Cpdt = new DataTable();
                  Createbt();
                  GridView1.DataSource = Cpdt;
                  GridView1.DataBind();
                  bgn_bind();
              }
          }
   
    }

    void bgn_bind()
    {
        string billno = Request["id"];
        string sql = "select * from ord_receipt_plu where billno='" + billno + "'";
        SqlDataReader rd = cc.ExceRead(sql);
        int i = 1;
        while (rd.Read())
        {
            /* this.title.Text = rd["问题摘要"].ToString();
             string a = this.com.Text.Trim();
             string b = this.name.SelectedItem.Text;
             string c = this.name.SelectedValue;
             string d = this.zbdate.Text.Trim();*/

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
            myrow[1] = rd["pluname"].ToString();
            myrow[2] = rd["plucount"].ToString();
            myrow[3] = rd["plumodel"].ToString();
            myrow[4] = rd["pluunit"].ToString();
            myrow[5] = rd["sstotal"].ToString();
            myrow[6] = rd["lrr"].ToString();
            //   DateTime dd = Convert.ToDateTime(rd["zbdate"].ToString());
            Cpdt.Rows.Add(myrow);
            // var mm = Cpdt.AsEnumerable().Sum(p => Convert.ToDouble(p["SL"]));
            //Label3.Text = mm.ToString();
            Cpdt.AcceptChanges();
            GridView1.DataKeyNames = new string[] { "录入人" };
            GridView1.DataSource = Cpdt;
            GridView1.DataBind();
        }
        rd.Close();
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
    void Createbt()
    {
        DataColumn mycol = new DataColumn();
        Cpdt.Columns.Add(new DataColumn("CPID", typeof(Int32)));
        Cpdt.Columns.Add(new DataColumn("商品名称", typeof(string)));
        Cpdt.Columns.Add(new DataColumn("数量", typeof(string)));
        Cpdt.Columns.Add(new DataColumn("商品规格", typeof(string)));
        Cpdt.Columns.Add(new DataColumn("商品单位", typeof(string)));
        Cpdt.Columns.Add(new DataColumn("金额（元）", typeof(string)));
        Cpdt.Columns.Add(new DataColumn("录入人", typeof(string)));
        Cpdt.AcceptChanges();
        Cpdt.PrimaryKey = new DataColumn[] { Cpdt.Columns[6] };
        Cpdt.AcceptChanges();
    }



    protected void Button1_Click(object sender, EventArgs e)
    {

        string jobno = Session["RememberName"].ToString();
        //string jobno = "SC00913";
        //---------------------------------
        string lrdate = DateTime.Now.ToString("yyyy-MM-dd");
        string pluname = this.pluname.Text.Trim();
        string plucount = this.plucount.Text.Trim();
        string sstotal = this.sstotal.Text.Trim();
        string plumodel = this.plumodel.Text.Trim();
        string pluunit = this.pluunit.Text.Trim();

        // --------------------------------------------


        if (string.IsNullOrEmpty(this.pluname.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写商品名称！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.plucount.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写商品数量！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.sstotal.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写商品金额！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.plumodel.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写商品规格！');</script>");
            return;
        } if (string.IsNullOrEmpty(this.pluunit.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写商品单位！');</script>");
            return;
        }

        DataRow myrow = Cpdt.NewRow();
        if (Cpdt.Rows.Count == 0)
        {
            myrow[0] = 1;
        }
        else
        {
            myrow[0] = int.Parse(Cpdt.Rows[Cpdt.Rows.Count - 1][0].ToString()) + 1;
        }
        myrow[1] = pluname;
        myrow[2] = plucount;
        myrow[3] = plumodel;
        myrow[4] = pluunit;
        myrow[5] = sstotal;
        myrow[6] = myrow[0].ToString() + "_" + Session["RememberName"].ToString();
        Cpdt.Rows.Add(myrow);
        Cpdt.AcceptChanges();

        DataRow[] drArr = Cpdt.Select("录入人 LIKE '%" + jobno + "%'");//查询
        DataTable dtNew = Cpdt.Clone();
        for (int i = 0; i < drArr.Length; i++)
        {
            dtNew.ImportRow(drArr[i]);
        }
        GridView1.DataKeyNames = new string[] { "录入人" };
        GridView1.DataSource = dtNew;
        GridView1.DataBind();
        //  dtNew.Clear();

        decimal sum = 0;
        foreach (GridViewRow row in GridView1.Rows)
        {
            sum += Convert.ToDecimal(row.Cells[7].Text);
            //   Response.Write("显示值是："+row.Cells[5].Text);
        }
        Label1.Text = "整单总金额：" + sum.ToString();


    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string ID = GridView1.DataKeys[e.RowIndex].Value.ToString().Trim();
        string jobno = Session["RememberName"].ToString();
        //string num = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[6].Controls[0])).Text.ToString();
        DataRow[] arrRows = Cpdt.Select("录入人='" + ID + "'");
        foreach (DataRow row in arrRows)
        {
            row.Delete();
            Cpdt.Rows.Remove(row);
        }

        Cpdt.AcceptChanges();

        DataTable dtNew = Cpdt.Clone();
        DataRow[] drArr = Cpdt.Select("录入人 LIKE '%" + jobno + "%'");//查询
        for (int i = 0; i < drArr.Length; i++)
        {
            dtNew.ImportRow(drArr[i]);
        }
        GridView1.DataKeyNames = new string[] { "录入人" };

        GridView1.DataSource = dtNew;

        GridView1.DataBind();
        // dtNew.Clear();

        decimal sum = 0;
        foreach (GridViewRow row in GridView1.Rows)
        {
            sum += Convert.ToDecimal(row.Cells[4].Text);
        }
        Label1.Text = sum.ToString();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        GridView1.DataSource = Cpdt;
        GridView1.DataBind();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {


    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        GridView1.DataSource = Cpdt;
        GridView1.DataBind();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        checkmemo();
        //---------------------------------------------------------------
        this.Button2.Attributes.Add("onclick", "javascript:if(confirm('已确认订单信息和商品信息完整无误了吗，确认后将不能再修改?') == false) return false;");
        string num = cc.GetAutoID("id", "cxid_bill").ToString();
        //-------------------------------
        string cen = this.cen.Text.Trim();
        string dept = this.dept.Text.Trim();
        string billtype = this.billtype.SelectedValue;
        string yw_people = this.yw_people.Text.Trim();
        string yw_peopletell = this.yw_peopletell.Text.Trim();
        string tick_record = this.tick_record.SelectedValue;
        string sale_source = this.sale_source.SelectedValue;
        string rec_address = this.rec_address.Text.Trim();
        string ordbillno = this.ordbillno.Text.Trim();
        string custom = this.custom.Text.Trim();
        string shuihao = this.shuihao.Text.Trim();
        string address = this.address.Text.Trim();
        string bank = this.bank.Text.Trim();
        string bank_acc = this.bank_acc.Text.Trim();
        string email = this.email.Text.Trim();
        string tellphone = this.tellphone.Text.Trim();
        string cust_lxr = this.cust_lxr.Text.Trim();
        string lxr_tel = this.lxr_tel.Text.Trim();
        string memo = this.memo.Text.Trim();
        string gxtime = DateTime.Now.ToString();
        string jobno = Session["RememberName"].ToString();
        //string jobno = "SC00913";
        string com = Session["COM"].ToString();
        string is_zy = this.IS_ZY.Text.Trim();
        //string com = "成都";
        decimal sum = 0;
        foreach (GridViewRow row in GridView1.Rows)
        {
            sum += Convert.ToDecimal(row.Cells[4].Text);
        }
        string ystotal = sum.ToString();
        string sql = "INSERT INTO ord_receipt(num,cen,dept,billtype,yw_people,yw_peopletell,tick_record,sale_source,"
          + "  rec_address,ordbillno,custom,shuihao,address,bank,"
          + "  bank_acc,email,tellphone,cust_lxr,"
          + "  lxr_tel,memo ,gxtime,jobno,com,status,is_zy)"
      + " VALUES ('" + num + "','" + cen + "','" + dept + "','" + billtype + "','" + yw_people + "','" + yw_peopletell + "','" + tick_record + "','" + sale_source + "',"
     + " '" + rec_address + "','" + ordbillno + "','" + custom + "','" + shuihao + "','" + address + "','" + bank + "', "
     + " '" + bank_acc + "','" + email + "','" + tellphone + "','" + cust_lxr + "', "
    + " '" + lxr_tel + "','" + memo + "','" + gxtime + "','" + jobno + "','" + com + "','01','" + is_zy + "')";
       // Response.Write(sql);
        string user = Session["RememberName"].ToString();
       // string user = "SC00913";

        if (GridView1.Rows.Count > 0)
        {
            try
            {
                //  Response.Write(sql);
                string fh = cc.execSQL01(sql).ToString();

                Response.Write(sql);
                if (fh == "True")
                {
                    // Response.Write("提交成功！");
                    // bind();
                    Response.Write("<script>alert('提交成功！');window.location.href ='add_salebill.aspx';</script>");
                }
                else
                {
                    Response.Write("提交失败！");
                }
            }

            catch (Exception ex)
            {
                Response.Write("提交失败,失败原因:" + ex.Message);

            }
            finally
            {
            }
            //---------------------------------

            if (GridView1.Rows.Count > 0)
            {
                SqlConnection con = cc.Getconsql02();
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                //   string sqldel = "delete from zb_tab where com='" + this.com.Text + "'";
                //  cc.execSQL(sqldel);

                try
                {
                    //  cc.execSQL(sqlhead);
                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        string sqlStr = "";
                        SqlCommand comm = new SqlCommand(sqlStr, con);
                        string saleno = num;
                        string id = GridView1.Rows[i].Cells[2].Text.Trim().ToString();
                        string pluname = GridView1.Rows[i].Cells[3].Text.Trim().ToString();
                        string plucount = GridView1.Rows[i].Cells[4].Text.Trim().ToString();
                        string plumodel = GridView1.Rows[i].Cells[5].Text.Trim().ToString();
                        string pluunit = GridView1.Rows[i].Cells[6].Text.Trim().ToString();
                        string sstotal = GridView1.Rows[i].Cells[7].Text.Trim().ToString();
                        string lrr = GridView1.Rows[i].Cells[8].Text.Trim().ToString();
                        // string tltime = DateTime.Now.ToString();


                        sqlStr = "INSERT INTO ord_receipt_plu(billno,id,pluname,plucount,plumodel,pluunit,sstotal,lrr) "
     + " VALUES('" + saleno + "','" + id + "','" + pluname + "','" + plucount + "','" + plumodel + "','" + pluunit + "','" + sstotal + "','" + lrr + "')";

                        //   Response.Write(sqlStr);
                        comm.CommandText = sqlStr;
                        comm.Connection = con;
                        comm.Transaction = tran;
                        comm.ExecuteNonQuery();
                        //       cc.execSQL01(sqlStr);
                    }
                    tran.Commit();
                    //   Response.Write("<script>alert('导入成功！请勿重复导入！');window.location.href ='add_saleord.aspx'</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("更新失败,失败原因:" + ex.Message);
                    tran.Rollback();//事务回滚  
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }

            }
        }
        else
        {
            Response.Write("<script>alert('还没有添加商品明细,请先点添加按钮,再点保存！');</script>");
        }
    }
    public void checkmemo()
    {

        if (string.IsNullOrEmpty(this.cen.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写中心信息！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.dept.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写部门信息！');</script>");
            return;
        }
        if (this.billtype.SelectedValue == "...请选择...")  //判断空值
        {
            Response.Write("<script>alert('请选择开票类型！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.yw_people.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写业务员信息！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.yw_peopletell.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写业务员电话！');</script>");
            return;
        }
        if (this.tick_record.SelectedValue == "...请选择...")  //判断空值
        {
            Response.Write("<script>alert('请选择是否重开！');</script>");
            return;
        }
        if (this.sale_source.SelectedValue == "...请选择...")  //判断空值
        {
            Response.Write("<script>alert('请选择销售来源！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.rec_address.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写收货地址！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.ordbillno.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写订单号！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.custom.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写客户名称！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.shuihao.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写客户税号！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.address.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写客户地址！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.bank.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写开户行信息！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.bank_acc.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写银行账号！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.email.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写客户邮箱！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.tellphone.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写客户电话！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.cust_lxr.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写客户联系人！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.lxr_tel.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写客户联系人电话！');</script>");
            return;
        }



    }







    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    protected void memo_TextChanged(object sender, EventArgs e)
    {

    }
    protected void rad1_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void rad2_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void dept_TextChanged(object sender, EventArgs e)
    {

    }
}