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
using System.Data.OleDb;

public partial class _add_saleord : System.Web.UI.Page
{
    CommonClass cc = new CommonClass();
    public static DataTable Cpdt;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        //string billno = Request["id"];
        //string jobno = Session["RememberName"].ToString();
        string jobno = "SC03582";
        if (jobno == null)
        {
            Response.Write("<script>alert('会话超时，请重新登录！');top.location.href ='http://192.168.11.249:1006/index.aspx';</script>");
        }
      
        if (!IsPostBack)
        {
          //  Createbt();
            Cpdt = new DataTable();
            Createbt();
            GridView1.DataSource = Cpdt;
            GridView1.DataBind();
            string sql = "select type from ord_shuishou_code";
            SqlDataReader rd = cc.ExceRead(sql);
            if (rd.Read())
            {
                plu_bind(sql);
                this.pluname.Items.Insert(0, "...点此选择具体商品...");
                rd.Close();
                rd.Dispose();
            }
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
        Cpdt.Columns.Add(new DataColumn("税率", typeof(string)));  
        Cpdt.Columns.Add(new DataColumn("录入人", typeof(string)));
        Cpdt.AcceptChanges();
        Cpdt.PrimaryKey = new DataColumn[] { Cpdt.Columns[8] };
        Cpdt.AcceptChanges();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        string jobno = Session["RememberName"].ToString();
        //---------------------------------
        string lrdate = DateTime.Now.ToString("yyyy-MM-dd");
        string pluname = this.pluname.SelectedValue;
        string plucount = this.plucount.Text.Trim();
        string sstotal = this.sstotal.Text.Trim();
        string plumodel = this.plumodel.Text.Trim();
        string pluunit = this.pluunit.Text.Trim();
        string s_code = this.Label2.Text.Trim();
        string shuilv = this.Label4.Text.Trim();


       // --------------------------------------------

        if (pluname == "请选择" || pluname == "...点此选择具体商品..." || pluname == "...未找到商品...")
        {
            Response.Write("<script>alert('请选择商品！');</script>");
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
        myrow[7] = shuilv;
        myrow[8] = myrow[0].ToString() + "_" + Session["RememberName"].ToString();

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
        if (string.IsNullOrEmpty(this.DropDownList1.SelectedValue))  //判断空值
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
        
       
         
       
        
        if (string.IsNullOrEmpty(this.zg.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写主管工号！');</script>");
            return;
        }
        int sh_lenth = this.shuihao.Text.Length;
        string sh = this.shuihao.Text.Trim();
        if (sh_lenth != 15 && sh_lenth != 18 && sh_lenth != 17 && sh != "无" && sh_lenth != 19)
        {
           Response.Write("<script>alert('请填写正确的税号！');</script>");
           return;
        }
        //---------------------------------------------------------------
        this.Button2.Attributes.Add("onclick", "javascript:if(confirm('已确认订单信息和商品信息完整无误了吗，确认后将不能再修改?') == false) return false;");
        string num = cc.GetAutoID("id", "cxid_bill").ToString();
       //-------------------------------
        string cen = this.DropDownList1.SelectedValue;
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
        string zg = this.zg.Text.Trim();
        string old_fp = this.old_fp.Text.Trim();

        if (billtype == "电子发票" && (email.Length < 7))//电子发票必填电话或邮箱
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
            if (address.Length < 6 || tellphone.Length < 8)
            {
                Response.Write("<script>alert('你正在申请专票;请填写正确的地址和电话！');</script>");
                return;
            }
            if (bank.Length < 6 || bank_acc.Length < 9)
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
             + "  lxr_tel,memo ,gxtime,jobno,com,status,is_zy,zg,old_fp)"
         + " VALUES ('" + num + "','" + cen + "','" + dept + "','" + billtype + "','" + yw_people + "','" + yw_peopletell + "','" + tick_record + "','" + sale_source + "',"
        + " '" + rec_address + "','" + ordbillno + "','" + custom + "','" + shuihao + "','" + address + "','" + bank + "', "
        + " '" + bank_acc + "','" + email + "','" + tellphone + "','" + cust_lxr + "', "
       + " '" + lxr_tel + "','" + memo + "','" + gxtime + "','" + jobno + "','" + com + "','01','"+ is_zy +"','"+zg+"','"+old_fp+"')";
              Response.Write(sql);
        }
        else if (dep02.Checked)
        {
            sql = "INSERT INTO ord_receipt(num,cen,dept,billtype,yw_people,yw_peopletell,tick_record,sale_source,"
                        + "  rec_address,ordbillno,custom,shuihao,address,bank,"
                        + "  bank_acc,email,tellphone,cust_lxr,"
                        + "  lxr_tel,memo ,gxtime,jobno,com,status,is_zy)"
                    + " VALUES ('" + num + "','" + cen + "','" + dept + "','" + billtype + "','" + yw_people + "','" + yw_peopletell + "','" + tick_record + "','" + sale_source + "',"
                   + " '" + rec_address + "','" + ordbillno + "','" + custom + "','" + shuihao + "','" + address + "','" + bank + "', "
                   + " '" + bank_acc + "','" + email + "','" + tellphone + "','" + cust_lxr + "', "
                  + " '" + lxr_tel + "','" + memo + "','" + gxtime + "','" + jobno + "','" + com + "','02','" + is_zy + "')";
        }
        else
        {
            Response.Write("<script>alert('请选择门店或部门！');</script>");
            return;
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
                         string shuilv = GridView1.Rows[i].Cells[9].Text.Trim().ToString();
                         string lrr = GridView1.Rows[i].Cells[10].Text.Trim().ToString();
                         // string tltime = DateTime.Now.ToString();


                         sqlStr = "INSERT INTO ord_receipt_plu(billno,id,pluname,plucount,plumodel,pluunit,sstotal,s_code,shuilv,lrr) "
      + " VALUES('" + saleno + "','" + id + "','" + pluname + "','" + plucount + "','" + plumodel + "','" + pluunit + "','" + sstotal + "','" + s_code + "','" + shuilv + "','" + lrr + "')";

                     
                        comm.CommandText = sqlStr;
                        comm.Connection = con;
                        comm.Transaction = tran;
                        comm.ExecuteNonQuery();
                       // cc.execSQL01(sqlStr);
                       // Response.Write(sqlStr);
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

        if (string.IsNullOrEmpty(this.DropDownList1.SelectedValue))  //判断空值
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
            this.zg.Enabled = false;
            this.zg.Text = "由门市助理审核";
            string AA = this.dept.Text.Trim();
            string orgcode = this.dept.Text.Trim().ToUpper();
            string sqlcd = "select orgcode||'_'||orgname from torgmanage where orgcode='" + orgcode + "'";
            //  string sqlinfo = "select preorgcode  from torgmanage where orgcode='" + orgcode.Substring(0, 4) + "'";
            // string com = cc.ExecScalar(sqlinfo);
            string sqlzy = "select is_zy from hl_view_is_zy where orgcode='" + orgcode + "'";
            string is_zy = cc.ExecScalar(sqlzy);
            string store = cc.ExecScalar(sqlcd);
            //Response.Write(is_zy+"1");
            if (string.IsNullOrEmpty(store) || AA.Length < 3)  //判断空值
            {
                Response.Write("<script>alert('请只填写正确的门店号,如:C001');</script>");
                this.dept.Text = "";
                return;
            }

            else
            {
                this.dept.Text = store;
                if (is_zy != null)
                {
                    this.IS_ZY.Text = is_zy;
                }              
                else
                {
                    this.IS_ZY.ReadOnly = false;
                }
            }
        }
        else if (dep02.Checked)
        {
            this.zg.Enabled = true;
            this.zg.Text  = string.Empty;
            depxz = dep02.Text;
            this.IS_ZY.Text = "直营店";
        }

        else
        {
            depxz = "";
            Response.Write("<script>alert('请选择：部门或门店');</script>");
            dept.Text = string.Empty;
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
            string sql1 = "select shuilv  from ord_shuishou_code where type = '" + pluname + "'";
            string shuilv = cc.ExecScalar1(sql1);
            this.Label4.Text = shuilv;
        }
        if (this.pluname.SelectedValue == "...点此选择具体商品...")
        {
            this.Label2.Text = string.Empty;
            this.Label4.Text = string.Empty;
        }
    }
    protected void pluname0_TextChanged(object sender, EventArgs e)
    {
        string com = Session["COM"].ToString();
        string pluname1 = this.pluname0.Text.Trim();
        string sql = "select type from ord_shuishou_code where  type like '%" + pluname1 + "%' and com = '" + com + "'";
        string sql1 = "select type from ord_shuishou_code";
        SqlDataReader rd = cc.ExceRead(sql);
        SqlDataReader rd1 = cc.ExceRead(sql1);
        if (rd.Read())
        {

            plu_bind(sql);
            this.pluname.Items.Insert(0, "请选择");
            //    string orgcode = rd["orgcode"].ToString().Trim();
            //   this.plu.SelectedIndex = this.orgcode.Items.IndexOf(this.orgcode.Items.FindByValue(orgcode));
            rd.Close();
            rd.Dispose();
        }
        else
        {
           // plu_bind(sql1);
            this.pluname.Items.Clear();
            this.pluname.Items.Insert(0, "...未找到商品...");
            rd1.Close();
            rd1.Dispose();
        }
    }
    protected void plu_bind(string sql)
    {
        //打开与数据库的连接
        SqlConnection myConn = cc.Getconsql02();
        myConn.Open();

        //查询文件创建时间
        SqlDataAdapter dapt = new SqlDataAdapter(sql, myConn);
        // Response.Write("aa");
        DataSet ds = new DataSet();
        //填充数据集
        dapt.Fill(ds, "files");
        //绑定下拉菜单
        this.pluname.DataSource = ds.Tables["files"].DefaultView;   //定交数据源
        // this.com.DataTextField = ds.Tables["files"].Columns[0].ToString();     
        //this.pluname.DataTextField = ds.Tables["files"].Columns[4].ToString();
        this.pluname.DataValueField = ds.Tables["files"].Columns[0].ToString();

        this.pluname.DataBind();
        //释放占用的资源
        ds.Dispose();
        dapt.Dispose();
        myConn.Close();
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        string oldbill = this.oldbill.Text.Trim();
        if (oldbill != null)
        {
            string sql = "select * from ord_info where num = '"+ oldbill +"'";
            SqlDataReader rd = cc.ExceRead(sql);
            if (rd.Read())
            {
                this.dept.Text = rd["dept"].ToString();
                this.DropDownList1.SelectedValue = rd["cen"].ToString();
                this.yw_people.Text = rd["saler"].ToString();
                this.yw_peopletell.Text = rd["saler_tel"].ToString();
                this.custom.Text = rd["custname"].ToString();
                this.shuihao.Text = rd["cust_tax_code"].ToString();
                this.address.Text = rd["cust_address"].ToString();
                this.cust_lxr.Text = rd["cust_body"].ToString();
                this.lxr_tel.Text = rd["cust_body_tel"].ToString();
                this.IS_ZY.Text = rd["jm"].ToString();
                rd.Close();
                rd.Dispose();

            }
            else
            {
                Response.Redirect("http://192.168.11.249:1006/grace/add_salebill.aspx");
            }
        }
    }
    protected void billtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ty = this.billtype.SelectedValue;
        if (ty == "普票")
        {
            l2.Visible = l3.Visible = l4.Visible = l5.Visible = l6.Visible = l7.Visible = l8.Visible = l9.Visible = l10.Visible = false;   

            l2.Visible = l3.Visible = true;   
        }
        else if (ty == "专用增值税发票")
        {
            l2.Visible = l3.Visible = l4.Visible = l5.Visible = l6.Visible = l7.Visible = l8.Visible = l9.Visible = l10.Visible = false;  
            l2.Visible = l3.Visible = l4.Visible = l5.Visible = l8.Visible = l9.Visible = true;   
        }
        else if (ty == "电子发票")
        {
            l2.Visible = l3.Visible = l4.Visible = l5.Visible = l6.Visible = l7.Visible = l8.Visible = l9.Visible = l10.Visible = false;
            l2.Visible = l3.Visible = l6.Visible = true;
        }
        else 
        {
            l2.Visible = l3.Visible = l4.Visible = l5.Visible = l6.Visible = l7.Visible = l8.Visible = l9.Visible = l10.Visible = false;  
        }
    }
    protected void zg_TextChanged(object sender, EventArgs e)
    {
        string person = this.zg.Text.Trim().ToUpper();
        string sql = "select real_name from ps_manager where user_name='" + person + "'";
        string ind1 = cc.ExecScalar1(sql).ToString();
        SqlDataReader rd = cc.ExceRead(sql);
        if (rd.Read())
        {
            this.zg.Text = person + "_" + rd["real_name"].ToString();
            rd.Close();
            rd.Dispose();
        }
        else
        {
            Response.Write("<script>alert('工号错误，请重新填写！');</script>");
            return;
        }
    }
    public System.Data.DataTable GetExcelDatatable(string fileUrl)
    {
        //支持.xls和.xlsx，即包括office2010等版本的   HDR=Yes代表第一行是标题，不是数据；
        string cmdText = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0; HDR=Yes; IMEX=1'";
        System.Data.DataTable dt = null;
        //建立连接
        OleDbConnection conn = new OleDbConnection(string.Format(cmdText, fileUrl));
        try
        {
            //打开连接
            if (conn.State == ConnectionState.Broken || conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            System.Data.DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string strSql = "select * from [Sheet1$]";
            OleDbDataAdapter da = new OleDbDataAdapter(strSql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dt = ds.Tables[0];
            return dt;
        }
        catch (Exception exc)
        {
            throw exc;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        SqlConnection myConn = cc.Getconsql02();
        myConn.Open();
        SqlCommand cmd = myConn.CreateCommand();
        if (FileUpload1.HasFile == false)//HasFile用来检查FileUpload是否有指定文件
        {
            Response.Write("<script>alert('请您选择Excel文件')</script> ");
            return;//当无文件时,返回
        }
        string IsXls = Path.GetExtension(FileUpload1.FileName).ToString().ToLower();//System.IO.Path.GetExtension获得文件的扩展名
        /*Response.Write(IsXls);
         if (IsXls != ".xlsx" || IsXls != ".xls")
         {
             Response.Write("<script>alert('只可以选择Excel文件')</script>");
             return;//当选择的不是Excel文件时,返回
         }*/
        string filename = FileUpload1.FileName;              //获取Execle文件名  DateTime日期函数
        string savePath = Server.MapPath(("uploadfiles\\") + filename);//Server.MapPath 获得虚拟服务器相对路径
        DataTable ds = new DataTable();
        FileUpload1.SaveAs(savePath);                        //SaveAs 将上传的文件内容保存在服务器上
        ds = GetExcelDatatable(savePath);           //调用自定义方法
        DataRow[] dr = ds.Select();            //定义一个DataRow数组
        int rowsnum = ds.Rows.Count;
        if (rowsnum == 0)
        {
            Response.Write("<script>alert('Excel表为空表,无数据!')</script>");   //当Excel表为空时,对用户进行提示
        }
        else
        {         
            DataTable dtNew = new DataTable();
            DataColumn mycol = new DataColumn();
            dtNew.Columns.Add(new DataColumn("CPID", typeof(Int32)));
            dtNew.Columns.Add(new DataColumn("商品名称", typeof(string)));
            dtNew.Columns.Add(new DataColumn("数量", typeof(string)));
            dtNew.Columns.Add(new DataColumn("商品规格", typeof(string)));
            dtNew.Columns.Add(new DataColumn("商品单位", typeof(string)));
            dtNew.Columns.Add(new DataColumn("金额（元）", typeof(string)));
            dtNew.Columns.Add(new DataColumn("税收编码", typeof(string)));
            dtNew.Columns.Add(new DataColumn("税率", typeof(string)));
            dtNew.Columns.Add(new DataColumn("录入人", typeof(string)));
            dtNew.AcceptChanges();
            
            for (int i = 0; i < dr.Length; i++)
            {
                //前面除了你需要在建立一个“upfiles”的文件夹外，其他的都不用管了，你只需要通过下面的方式获取Excel的值，然后再将这些值用你的方式去插入到数据库里面
                string type = dr[i]["商品名"].ToString();
                string cou = dr[i]["数量"].ToString();
                string model = dr[i]["商品规格"].ToString();
                string unit = dr[i]["商品单位"].ToString();
                string ss = dr[i]["实收金额"].ToString();  
                string sql = "select s_code from ord_shuishou_code where type = '" + type + "'";
                string sql_shuilv = "select shuilv from ord_shuishou_code where type = '" + type + "'";
                string jobno = Session["RememberName"].ToString();
                string s_code = cc.ExecScalar1(sql);
                string shuilv = cc.ExecScalar1(sql_shuilv);
          
                DataRow myrow = dtNew.NewRow();
                if (dtNew.Rows.Count == 0)
                {
                    myrow[0] = 1;
                }
                else
                {
                    myrow[0] = int.Parse(dtNew.Rows[dtNew.Rows.Count - 1][0].ToString()) + 1;
                }
                myrow[1] = type;
                myrow[2] = cou;
                myrow[3] = model;
                myrow[4] = unit;
                myrow[5] = ss;
                myrow[6] = s_code;
                myrow[7] = shuilv;
                myrow[8] = myrow[0].ToString() + "_" + Session["RememberName"].ToString();
                dtNew.Rows.Add(myrow);
                dtNew.AcceptChanges();
                if (s_code == "")
                {
                    Response.Write("<script>alert('有税收编码为空,请检查！');</script>");
                }
            }
                GridView1.DataKeyNames = new string[] { "录入人" };
                GridView1.DataSource = dtNew;
                GridView1.DataBind();

                decimal sum = 0;
                foreach (GridViewRow row in GridView1.Rows)
                {
                    sum += Convert.ToDecimal(row.Cells[7].Text);
                    //   Response.Write("显示值是："+row.Cells[5].Text);
                }
                Label1.Text = "整单总金额：" + sum.ToString();
        }
        myConn.Close();
    }

    protected void shuihao_TextChanged(object sender, EventArgs e)
    {

    }
    protected void tick_record_SelectedIndexChanged(object sender, EventArgs e)
    {
        string a = this.tick_record.SelectedValue;
        if (a == "重开")
        {
            this.zf.Visible = true;
        }
        else 
        {
            this.zf.Visible = false;
        }
    }
    protected void Button00_Click(object sender, EventArgs e)
    {
        string old_fp = this.old_fp.Text.Trim();
        if (old_fp != null)
        {
            string sql = "select * from ord_receipt where num = '" + old_fp + "'";
            SqlDataReader rd = cc.ExceRead(sql);
            if (rd.Read())
            {
                this.dept.Text = rd["dept"].ToString();
                this.DropDownList1.SelectedValue = rd["cen"].ToString();
                if (rd["dept"].ToString().Substring(0, 1) == "C")
                {
                    dep01.Checked = true; dep02.Checked = false;
                }
                else
                {
                    dep02.Checked = true; dep01.Checked = false;
                }
                this.yw_people.Text = rd["yw_people"].ToString();
                this.yw_peopletell.Text = rd["yw_peopletell"].ToString();
                this.rec_address.Text = rd["rec_address"].ToString();
                this.ordbillno.Text = rd["ordbillno"].ToString();
                this.bank.Text = rd["bank"].ToString();
                this.bank_acc.Text = rd["bank_acc"].ToString();
                this.email.Text = rd["email"].ToString();
                this.tellphone.Text = rd["tellphone"].ToString();
                this.custom.Text = rd["custom"].ToString();
                this.shuihao.Text = rd["shuihao"].ToString();
                this.address.Text = rd["address"].ToString();
                this.cust_lxr.Text = rd["cust_lxr"].ToString();
                this.lxr_tel.Text = rd["lxr_tel"].ToString();
                this.IS_ZY.Text = rd["IS_ZY"].ToString();
                rd.Close();
                rd.Dispose();

            }
            else
            {
                Response.Write("<script>alert('未查到该申请单号！');</script>");
            }
        }

    }
    protected void zf_TextChanged(object sender, EventArgs e)
    {

    }
}