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
    public static DataTable Cpdt;
    protected void Page_Load(object sender, EventArgs e)
    {
        string billno = Request["id"];
        string jobno = Session["RememberName"].ToString();
      
        if (!IsPostBack)
        {
          //  Createbt();
            Cpdt = new DataTable();
            Createbt();
            GridView1.DataSource = Cpdt;
            GridView1.DataBind();
            this.pluname.Items.Insert(0, "...点此选择具体商品...");
            this.pluname.Items.Insert(1, "面包");
            this.pluname.Items.Insert(2, "蛋糕");
            this.pluname.Items.Insert(3, "生日蛋糕");
            this.pluname.Items.Insert(4, "西点");
            this.pluname.Items.Insert(5, "植物油");
            this.pluname.Items.Insert(6, "谷物加工制品");
            this.pluname.Items.Insert(7, "水果苹果");
            this.pluname.Items.Insert(8, "包装饮用水");
            this.pluname.Items.Insert(9, "蛋类");
            this.pluname.Items.Insert(10, "*谷物加工品*沁州黄小米");
            this.pluname.Items.Insert(11, "乳制品");
        }
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
        Cpdt.Columns.Add(new DataColumn("税收编码", typeof(string)));  
        Cpdt.Columns.Add(new DataColumn("录入人", typeof(string)));
        Cpdt.AcceptChanges();
        Cpdt.PrimaryKey = new DataColumn[] { Cpdt.Columns[7] };
        Cpdt.AcceptChanges();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        string jobno = Session["RememberName"].ToString();
        //---------------------------------
        string lrdate = DateTime.Now.ToString("yyyy-MM-dd"); 
        string pluname = this.pluname.Text.Trim();
        string plucount = this.plucount.Text.Trim();
        string sstotal = this.sstotal.Text.Trim();
        string plumodel = this.plumodel.Text.Trim();
        string pluunit = this.pluunit.Text.Trim();
        string s_code = this.Label2.Text.Trim();
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
 
        if (string.IsNullOrEmpty(this.pluunit.Text.Trim()))
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
        myrow[6] = s_code;  
        myrow[7] = myrow[0].ToString() + "_" + Session["RememberName"].ToString();
        Cpdt.Rows.Add(myrow);      
        Cpdt.AcceptChanges();
     
        DataRow[] drArr = Cpdt.Select("录入人 LIKE '%"+jobno+"%'");//查询
        DataTable dtNew = Cpdt.Clone(); 
        for (int i = 0; i < drArr.Length; i++)
        {
            dtNew.ImportRow(drArr[i]);
        }
        GridView1.DataKeyNames = new string[] { "录入人"};
        GridView1.DataSource = dtNew;       
        GridView1.DataBind();
      //  dtNew.Clear();

      decimal sum = 0;
        foreach (GridViewRow row in GridView1.Rows)
        {
            sum += Convert.ToDecimal(row.Cells[7].Text);
         //   Response.Write("显示值是："+row.Cells[5].Text);
        }
        Label1.Text = "整单总金额："+sum.ToString();



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
       //-------------
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
        string com = Session["COM"].ToString();
        string is_zy = this.IS_ZY.Text.Trim();

        if (billtype == "电子发票" && (email.Length < 7 || tellphone.Length < 8))//电子发票必填电话或邮箱
        {
            Response.Write("<script>alert('你正在申请电子发票;请填写正确的电话或邮箱！');</script>");
            return;
        }
        if (billtype == "专用增值税发票")//专票必须填写客户信息
        {
            if (custom.Length < 6)
            {
                Response.Write("<script>alert('你正在申请专票;请填写正确的客户名称！');</script>");
                return;
            }
            if (shuihao.Length < 10)
            {
                Response.Write("<script>alert('你正在申请专票;请填写正确的税号信息！');</script>");
                return;
            }
            if (address.Length < 10 || tellphone.Length < 8)
            {
                Response.Write("<script>alert('你正在申请专票;请填写正确的地址和电话！');</script>");
                return;
            }
            if (bank.Length < 7 || bank_acc.Length < 10)
            {
                Response.Write("<script>alert('你正在申请专票;请填写正确的开户行和账户！');</script>");
                return;
            }
        }
        decimal sum = 0;
        foreach (GridViewRow row in GridView1.Rows)
        {
            sum += Convert.ToDecimal(row.Cells[7].Text);
        }
        string ystotal  = sum.ToString();
        string sql;
        if (dep01.Checked)
        {

            sql = "INSERT INTO ord_receipt(num,cen,dept,billtype,yw_people,yw_peopletell,tick_record,sale_source,"
             + "  rec_address,ordbillno,custom,shuihao,address,bank,"
             + "  bank_acc,email,tellphone,cust_lxr,"
             + "  lxr_tel,memo ,gxtime,jobno,com,status,is_zy)"
         + " VALUES ('" + num + "','" + cen + "','" + dept + "','" + billtype + "','" + yw_people + "','" + yw_peopletell + "','" + tick_record + "','" + sale_source + "',"
        + " '" + rec_address + "','" + ordbillno + "','" + custom + "','" + shuihao + "','" + address + "','" + bank + "', "
        + " '" + bank_acc + "','" + email + "','" + tellphone + "','" + cust_lxr + "', "
       + " '" + lxr_tel + "','" + memo + "','" + gxtime + "','" + jobno + "','" + com + "','01','"+ is_zy +"')";
            //   Response.Write(sql);
        }
        else
        {
            sql = "INSERT INTO ord_receipt(num,cen,dept,billtype,yw_people,yw_peopletell,tick_record,sale_source,"
                        + "  rec_address,ordbillno,custom,shuihao,address,bank,"
                        + "  bank_acc,email,tellphone,cust_lxr,"
                        + "  lxr_tel,memo ,gxtime,jobno,com,status,is_zy)"
                    + " VALUES ('" + num + "','" + cen + "','" + dept + "','" + billtype + "','" + yw_people + "','" + yw_peopletell + "','" + tick_record + "','" + sale_source + "',"
                   + " '" + rec_address + "','" + ordbillno + "','" + custom + "','" + shuihao + "','" + address + "','" + bank + "', "
                   + " '" + bank_acc + "','" + email + "','" + tellphone + "','" + cust_lxr + "', "
                  + " '" + lxr_tel + "','" + memo + "','" + gxtime + "','" + jobno + "','" + com + "','02','"+is_zy+"')";
        }
         string user=Session["RealName"].ToString();
       
         if (GridView1.Rows.Count > 0)
         {
             try
             {
                  //  Response.Write(sql);
                 string fh = cc.execSQL01(sql).ToString();
               
                  // Response.Write(sql);
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
                         string s_code = GridView1.Rows[i].Cells[8].Text.Trim().ToString();
                         string lrr = GridView1.Rows[i].Cells[9].Text.Trim().ToString();
                         // string tltime = DateTime.Now.ToString();
                         

                         sqlStr = "INSERT INTO ord_receipt_plu(billno,id,pluname,plucount,plumodel,pluunit,sstotal,s_code,lrr) "
      + " VALUES('" + saleno + "','" + id + "','" + pluname + "','" + plucount + "','" + plumodel + "','" + pluunit + "','" + sstotal + "','"+s_code+"','" + lrr + "')";

                     
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


    protected void ora_bind( string sql)
    {
        OracleConnection con = cc.Getconora();
        con.Open();     
  
        OracleDataAdapter myDa = new OracleDataAdapter(sql, con);
        DataSet myDs = new DataSet();
        myDa.Fill(myDs);
        GridView1.DataKeyNames = new string[] { "plucode" };
        // this.GridView1.Attributes.Add("bordercolor ", "#000066");
        GridView1.DataSource = myDs;
        GridView1.DataBind();
        myDa.Dispose();
        myDs.Dispose();
        con.Close();
        con.Dispose();
    }
    

 
 
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void dept_TextChanged(object sender, EventArgs e)
    {
        string depxz;
        if (dep01.Checked)
        {
            string AA = this.dept.Text.Trim();
            if (string.IsNullOrEmpty(this.dept.Text.Trim()) || AA.Length < 3)  //判断空值
            {

                Response.Write("<script>alert('请只填写正确的门店号,如:C001');</script>");
                this.dept.Text = "";
                return;
            }
            string orgcode = this.dept.Text.Trim().ToUpper();
            string sqlcd = "select orgcode||'_'||orgname from torgmanage where orgcode='" + orgcode + "'";
            //  string sqlinfo = "select preorgcode  from torgmanage where orgcode='" + orgcode.Substring(0, 4) + "'";
            // string com = cc.ExecScalar(sqlinfo);
            string sqlzy = "select is_zy from hl_view_is_zy where orgcode='" + orgcode + "'";
            string is_zy = cc.ExecScalar(sqlzy);
            string store = cc.ExecScalar(sqlcd);
            if (string.IsNullOrEmpty(store) || AA.Length < 3)  //判断空值
            {
                Response.Write("<script>alert('请只填写正确的门店号,如:C001');</script>");
                this.dept.Text = "";
                return;
            }
            else
            {
                this.dept.Text = store;
                this.IS_ZY.Text = is_zy;
            }
        }
        else if (dep02.Checked)
        {
            depxz = dep02.Text;
            this.IS_ZY.Text = "直营店";
        }

        else
        {
            depxz = "";
            Response.Write("<script>alert('请选择：部门或门店');</script>");
            return;
            // Response.Write("<script>window.history.back();</script>");
        }
     
    }
    protected void rad2_CheckedChanged(object sender, EventArgs e)
    {
        if (dep01.Checked)
        {
            this.dept.Text = "";
        }
    }
    protected void rad1_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void pluname_SelectedIndexChanged(object sender, EventArgs e)
    {
        string pluname = this.pluname.SelectedValue;
        if (this.pluname.SelectedValue != "...点此选择具体商品...")
        {
            string sql = "select s_code  from ord_shuishou_code where type = '" + pluname + "'";
            string s_code = cc.ExecScalar1(sql);
            this.Label2.Text = s_code;
        }
    }
    protected void pluname0_TextChanged(object sender, EventArgs e)
    {
        string pluname1 = this.pluname0.Text.Trim();
        string sql = "select * from lj_grace_plu_saleord01 where name = '普通商品' and  pluname like '%" + pluname1 + "%'";
        OracleDataReader rd = cc.ora_read(sql);
        if (rd.Read())
        {

            plu_bind(sql);
            this.pluname.Items.Insert(0, "...点此选择具体商品...");
            this.pluname.Items.Insert(1, "面包");
            this.pluname.Items.Insert(2, "蛋糕");
            this.pluname.Items.Insert(3, "生日蛋糕");
            this.pluname.Items.Insert(4, "西点");
            this.pluname.Items.Insert(5, "植物油");
            this.pluname.Items.Insert(6, "谷物加工制品");
            this.pluname.Items.Insert(7, "水果苹果");
            this.pluname.Items.Insert(8, "包装饮用水");
            this.pluname.Items.Insert(9, "蛋类");
            this.pluname.Items.Insert(10, "*谷物加工品*沁州黄小米");
            this.pluname.Items.Insert(11, "乳制品");

            //    string orgcode = rd["orgcode"].ToString().Trim();
            //   this.plu.SelectedIndex = this.orgcode.Items.IndexOf(this.orgcode.Items.FindByValue(orgcode));
            rd.Close();
            rd.Dispose();
        }
    }
    protected void plu_bind(string sql)
    {
        //打开与数据库的连接
        OracleConnection myConn = cc.Getconora();
        myConn.Open();

        //查询文件创建时间
        OracleDataAdapter dapt = new OracleDataAdapter(sql, myConn);
        // Response.Write("aa");
        DataSet ds = new DataSet();
        //填充数据集
        dapt.Fill(ds, "files");
        //绑定下拉菜单
        this.pluname.DataSource = ds.Tables["files"].DefaultView;   //定交数据源
        // this.com.DataTextField = ds.Tables["files"].Columns[0].ToString();     
        this.pluname.DataTextField = ds.Tables["files"].Columns[4].ToString();
        this.pluname.DataValueField = ds.Tables["files"].Columns[3].ToString();

        this.pluname.DataBind();
        //释放占用的资源
        ds.Dispose();
        dapt.Dispose();
        myConn.Close();
    }
}