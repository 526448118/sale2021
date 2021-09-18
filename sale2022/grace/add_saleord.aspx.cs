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
      // pluname0.Visible = false;
        string billno = Request["id"];
        //string jobno = "SC03582";
       string jobno = Session["RememberName"].ToString();
        this.lrdate.Text = DateTime.Now.ToString("yyyy-MM-dd"); 
        //string cx = Request["cx"];
        if (Session["RememberName"] == null)
        {
            Response.Write("<script>alert('会话超时，请重新登录！');top.location.href ='http://192.168.11.249:1006/index.aspx';</script>");
        }
        if (!IsPostBack)
        {
          
            //------加载信息-------
            string sqlbind = "select * from ord_info where num='" + billno + "'";
            //---  bind(sqlbind);
            SqlDataReader rd = cc.ExceRead(sqlbind);
            if (rd.Read())
            {
                this.cen.Text = rd["cen"].ToString();
                this.dept.Text = rd["dept"].ToString();
                this.saler.Text = rd["saler"].ToString();
                this.saler_tel.Text = rd["saler_tel"].ToString();
                this.thdate.Text = rd["thdate"].ToString();
                this.lrdate.Text = rd["lrdate"].ToString();
                this.custname.Text = rd["custname"].ToString();
                this.cust_tax_code.Text = rd["cust_tax_code"].ToString();
                this.cust_addr.Text = rd["cust_address"].ToString();
                this.thaddr.Text = rd["th_address"].ToString();
                this.cust_body.Text = rd["cust_body"].ToString();
                this.cust_body_tel.Text = rd["cust_body_tel"].ToString();
                string fktype = rd["fktype"].ToString().Trim();
                this.fktype.SelectedIndex = this.fktype.Items.IndexOf(this.fktype.Items.FindByValue(fktype));
                string kp = rd["kp"].ToString().Trim();
                this.kp.SelectedIndex = this.kp.Items.IndexOf(this.kp.Items.FindByValue(kp));
                string ord_from = rd["ord_from"].ToString().Trim();
                this.ord_from.SelectedIndex = this.ord_from.Items.IndexOf(this.ord_from.Items.FindByValue(ord_from));
                string thtype = rd["thtype"].ToString().Trim();
                this.thtype.SelectedIndex = this.thtype.Items.IndexOf(this.thtype.Items.FindByValue(thtype));
                string plutype = rd["plutype"].ToString().Trim();
                this.plutype.SelectedIndex = this.plutype.Items.IndexOf(this.plutype.Items.FindByValue(plutype));
                string ord_type = rd["ordtype"].ToString().Trim();
                this.ord_type.SelectedIndex = this.ord_type.Items.IndexOf(this.ord_type.Items.FindByValue(ord_type));
                this.jm.Text = rd["jm"].ToString();
                string htcustom = rd["htcustom"].ToString().Trim();
                this.htcustom.SelectedIndex = this.htcustom.Items.IndexOf(this.htcustom.Items.FindByValue(htcustom));
                //  this.fktype.Text = rd["付款方式"].ToString();
                // this.kp.Text = rd["开票"].ToString()
                this.memo.Text = rd["memo"].ToString();
                this.Label1.Text = rd["sstotal"].ToString();
                if (plutype == "普通商品")
                {
                    pluname0.Visible = true;
                }

                //  this.ord_from.SelectedValue 
                //   this.thtype.Text = rd["提货方式"].ToString();
                //   this.plutype.Text = rd["商品类型"].ToString();
                //  this.ord_from.Text = rd["订单来源"].ToString();
                rd.Close();
                rd.Dispose();
                Cpdt = new DataTable();
                Createbt();
                GridView1.DataSource = Cpdt;
                GridView1.DataBind();
                bgn_bind();
            }
            //------------------

            else
            {
                // bindpd();
                Cpdt = new DataTable();
                Createbt();
                GridView1.DataSource = Cpdt;
                GridView1.DataBind();
                string dept = "select dept from ps_manager where user_name='" + jobno + "'";
                string cen = cc.ExecScalar1(dept).ToString();
                this.cen.Text = cen;
            }
        }
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TextBox13_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TextBox6_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TextBox20_TextChanged(object sender, EventArgs e)
    {

    }
    void Createbt()
    {
        DataColumn mycol = new DataColumn();
        Cpdt.Columns.Add(new DataColumn("CPID", typeof(Int32)));
        Cpdt.Columns.Add(new DataColumn("商品编号", typeof(string)));
        Cpdt.Columns.Add(new DataColumn("商品名称", typeof(string)));
        Cpdt.Columns.Add(new DataColumn("单价", typeof(string)));
        Cpdt.Columns.Add(new DataColumn("数量", typeof(string)));
        Cpdt.Columns.Add(new DataColumn("单位", typeof(string)));
        Cpdt.Columns.Add(new DataColumn("金额（元）", typeof(string)));
        Cpdt.Columns.Add(new DataColumn("折扣", typeof(string)));
        Cpdt.Columns.Add(new DataColumn("折后金额", typeof(string)));
        Cpdt.Columns.Add(new DataColumn("录入人", typeof(string)));
        Cpdt.AcceptChanges();
        Cpdt.PrimaryKey = new DataColumn[] { Cpdt.Columns[9] };
        Cpdt.AcceptChanges();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int id_zk = 0;
        int.TryParse(this.zk.Text.Trim(), out id_zk);
        //---------------------------------
        string cen = this.cen.Text.Trim();
        string dept = this.dept.Text.Trim();             string saler = this.saler.Text.Trim();
        string saler_tel = this.saler_tel.Text.Trim();   string lrdate = this.lrdate.Text.Trim();
        string thdate = this.thdate.Text.Trim();         string ord_from = this.ord_from.SelectedValue;     
        string thtype = this.thtype.SelectedValue;
        string plutype = this.plutype.SelectedValue; 
        string custname = this.custname.Text.Trim();    
        string cust_tax_code = this.cust_tax_code.Text.Trim();
        string ordtype = this.ord_type.SelectedValue;    string cust_addr = this.cust_addr.Text.Trim();
        string fktype = this.fktype.SelectedValue;       string kp = this.kp.SelectedValue;     
        string thaddr = this.thaddr.Text.Trim();
        string cust_body = this.cust_body.Text.Trim();   string cust_body_tel = this.cust_body_tel.Text.Trim();
        string plucode = this.plucode.Text.Trim();
        string pluname1 = this.pluname.SelectedItem.Text;
        string pluname = HttpUtility.UrlDecode(pluname1, Encoding.GetEncoding("gb2312"));
        string count = this.count.Text.Trim();           string price = this.price.Text.Trim();
        string zk = this.zk.Text.Trim();                 string sstotal = this.sstotal.Text.Trim();
        string memo = this.memo.Text.Trim();             string next_person = this.next_person.Text.Trim();
        string gxtime = DateTime.Now.ToString();         string com = "成都";
        string ystotal = "0";                            string htcustom = this.htcustom.SelectedValue;
        string sql="INSERT INTO ord_info(dept,cen,saler,saler_tel,lrdate,"
          +"  thdate,ord_from,thtype,plutype,custname,cust_tax_code,cust_address,"
          +"  fktype,kp,th_address,cust_body,cust_body_tel,plucode,pluname,count,"
          +"  price,zk,sstotal,ystotal,memo,next_person ,com,gxtime,htcustom)"
          + " VALUES ('"+dept+"','"+cen+"','"+saler+"','"+saler_tel+"','"+lrdate+"','"+thdate+"','"+ord_from+"',"
          +" '"+thtype+"','"+plutype+"','"+custname+"','"+cust_tax_code+"','"+cust_addr+"','"+fktype+"', "
          +" '"+kp+"','"+thaddr+"','"+cust_body+"','"+cust_body_tel+"','"+plucode+"','"+pluname+"','"+count+"', "
          +"  '"+price+"','"+zk+"','"+sstotal+"','"+ystotal+"','"+memo+"','"+next_person+"','"+com+"','"+gxtime+"','" + htcustom + "')" ;
       // --------------------------------------------
        if (this.pluname.SelectedItem.Text=="请选择")  //判断空值
        {
            Response.Write("<script>alert('请填写商品名称！');</script>");
            return;
        }
     
        if (string.IsNullOrEmpty(this.price.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写商品价格！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.count.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写商品数量！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.zk.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写折扣！');</script>");
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
        myrow[1] = plucode;
        myrow[2] = pluname;
        myrow[3] = price;
        myrow[4] = count;
        myrow[5] = "个";
        myrow[6] = Decimal.Parse(price)*Decimal.Parse(count);
        myrow[7] = zk;
        myrow[8] = sstotal;
        myrow[9] = myrow[0].ToString()+"_"+Session["RememberName"].ToString();
        string jobno = Session["RememberName"].ToString();
        // DateTime dd = Convert.ToDateTime(d.ToString());
        //  myrow[5] = cc.Geteek(dd);
        Cpdt.Rows.Add(myrow);
        // var mm = Cpdt.AsEnumerable().Sum(p => Convert.ToDouble(p["SL"]));
        //Label3.Text = mm.ToString();
        Cpdt.AcceptChanges();
        //  DataRow[] arrRows = Cpdt.Select("CPID='" + CPID + "'");
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
            sum += Convert.ToDecimal(row.Cells[10].Text);
        }
        Label1.Text = sum.ToString();
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
            sum += Convert.ToDecimal(row.Cells[10].Text);
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
    protected void zk_TextChanged(object sender, EventArgs e)
    {
          string price = this.price.Text.Trim();
          string count = this.count.Text.Trim();
          string zk = this.zk.Text.Trim();
          Decimal a = (Decimal.Parse(price)*Decimal.Parse(count)*Decimal.Parse(zk))/100;
          this.sstotal.Text = a.ToString();
       
    }
    protected void count_TextChanged(object sender, EventArgs e)
    {
        string price = this.price.Text.Trim();
        string count = this.count.Text.Trim();
        string zk = this.zk.Text.Trim();
        Decimal a = (Decimal.Parse(price) * Decimal.Parse(count) * Decimal.Parse(zk)) / 100;
        this.sstotal.Text = a.ToString();

    }
    protected void price_TextChanged(object sender, EventArgs e)
    {
        string price = this.price.Text.Trim();
        string count = this.count.Text.Trim();
        string zk = this.zk.Text.Trim();
        Decimal a = (Decimal.Parse(price) * Decimal.Parse(count) * Decimal.Parse(zk)) / 100;
        this.sstotal.Text = a.ToString();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string plutype = this.plutype.SelectedValue;
        string next_person;

        //-----------------检查约束--------------
        if (plutype == "普通商品")
        {
             next_person = "0";
        }
        else 
        {
         if (string.IsNullOrEmpty(this.next_person.Text.Trim()))  //判断空值
            {
            Response.Write("<script>alert('请填写部门主管工号！');</script>");
            return;
            }
          next_person = this.next_person.Text.Trim().Substring(0, 7);
        }
        if (string.IsNullOrEmpty(this.lrdate.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写下单日期！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.thdate.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写提货日期！');</script>");
            return;
        }
        if (this.ord_type.SelectedValue == "...请选择...")  //判断空值
        {
            Response.Write("<script>alert('请填写订单类型！');</script>");
            return;
        }
        if (this.ord_from.SelectedValue == "...请选择...")  //判断空值
        {
            Response.Write("<script>alert('请选择订单来源！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.jm.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请选择加盟或直营！');</script>");
            return;
        }
        if (this.thtype.SelectedValue == "...请选择...")  //判断空值
        {
            Response.Write("<script>alert('请选择提货方式！');</script>");
            return;
        }
        if (this.plutype.SelectedValue == "...请选择...")  //判断空值
        {
            Response.Write("<script>alert('请选择商品类型！');</script>");
            return;
        }
        if (this.fktype.SelectedValue == "...请选择...")  //判断空值
        {
            Response.Write("<script>alert('请选择付款方式！');</script>");
            return;
        }
        if (this.kp.SelectedValue == "...请选择...")  //判断空值
        {
            Response.Write("<script>alert('请选择是否开票！');</script>");
            return;
        }
        if (this.hk.SelectedValue == "...请选择...")  //判断空值
        {
            Response.Write("<script>alert('请选择是否已回款！');</script>");
            return;
        }
        if (this.htcustom.SelectedValue == "...请选择...")  //判断空值
        {
            Response.Write("<script>alert('请选择是否合同客户！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.custname.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写客户名称！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.thaddr.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写提货地址！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.cust_body.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写客户联系人！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.cust_body_tel.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写客户联系人电话！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.cust_addr.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写客户地址！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.cen.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写所属中心！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.dept.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写所属部门！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.saler.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写销售员！');</script>");
            return;
        }
        //---------------------------------------------------------------
        this.Button2.Attributes.Add("onclick", "javascript:if(confirm('已确认订单信息和商品信息完整无误了吗，确认后将不能再修改?') == false) return false;");
        string num = cc.GetAutoID("id", "cxid").ToString();

       //-------------------------------
        string cen = this.cen.Text.Trim();
        string dept = this.dept.Text.Trim(); string saler = this.saler.Text.Trim();
        string saler_tel = this.saler_tel.Text.Trim(); string lrdate = this.lrdate.Text.Trim();
        string thdate = this.thdate.Text.Trim(); string ord_from = this.ord_from.SelectedValue;
        string thtype = this.thtype.SelectedValue;
        string hk = this.hk.SelectedValue;
        string custname = this.custname.Text.Trim();
        string cust_tax_code = this.cust_tax_code.Text.Trim();
        string ordtype = this.ord_type.SelectedValue; string cust_addr = this.cust_addr.Text.Trim();
        string fktype = this.fktype.SelectedValue; string kp = this.kp.SelectedValue;
        string thaddr = this.thaddr.Text.Trim();
        string cust_body = this.cust_body.Text.Trim(); string cust_body_tel = this.cust_body_tel.Text.Trim();
        string count = this.count.Text.Trim(); string price = this.price.Text.Trim();
        string zk = this.zk.Text.Trim(); string sstotal = this.Label1.Text.Trim();
        string memo = this.memo.Text.Trim(); 
        string gxtime = DateTime.Now.ToString(); string jobno = Session["RememberName"].ToString();
        string com = Session["COM"].ToString();
        string jm  = this.jm.Text.Trim();
        string htcustom = this.htcustom.SelectedValue;
       // string com = "成都";
        decimal sum = 0;
        foreach (GridViewRow row in GridView1.Rows)
        {
            sum += Convert.ToDecimal(row.Cells[8].Text);
        }
        string ystotal  = sum.ToString();
        string sql = "INSERT INTO ord_info(dept,cen,saler,saler_tel,lrdate,"
          + "  thdate,ord_from,thtype,plutype,custname,cust_tax_code,cust_address,"
          + "  fktype,kp,th_address,cust_body,cust_body_tel,"
          + "  memo,next_person ,com,gxtime,num,ystotal,sstotal,bill_status,lrstaff,ordtype,jm,htcustom,isdc,hk)"
          + " VALUES ('" + dept + "','" + cen + "','" + saler + "','" + saler_tel + "','" + lrdate + "','" + thdate + "','" + ord_from + "',"
          + " '" + thtype + "','" + plutype + "','" + custname + "','" + cust_tax_code + "','" + cust_addr + "','" + fktype + "', "
          + " '" + kp + "','" + thaddr + "','" + cust_body + "','" + cust_body_tel + "', "
          + " '" + memo + "','" + next_person + "','" + com + "','" + gxtime + "','"+num+"','"+ystotal+"','"+sstotal+"','0','"+jobno+"','"+ordtype+"','"+jm+"','"+htcustom+"','0','"+hk+"')";
      //  string user="SC00913";
         string user=Session["RealName"].ToString();
         string sqlstatus="insert into ord_bill_status(saleno,status,lrdate,lrstaff,memo,statusno) "
             +" values('"+num+"','0','"+gxtime+"','"+jobno+"','"+memo+"','0')";
         if (GridView1.Rows.Count > 0)
         {
             try
             {
                 string fh = cc.execSQL01(sql).ToString();
                 cc.execSQL01(sqlstatus);
                 if (fh == "True")
                 {
                     Response.Write("<script>alert('提交成功！');window.location.href ='myord_list.aspx';</script>");
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

                 try
                 {
                     for (int i = 0; i < GridView1.Rows.Count; i++)
                     {
                         string sqlStr = "";
                         SqlCommand comm = new SqlCommand(sqlStr, con);
                         string saleno = num;
                         string id = GridView1.Rows[i].Cells[2].Text.Trim().ToString();
                         string plucode1 = GridView1.Rows[i].Cells[3].Text.Trim().ToString();
                         string pluname1 = GridView1.Rows[i].Cells[4].Text.Trim().ToString();
                         string price1 = GridView1.Rows[i].Cells[5].Text.ToString();
                         string count1 = GridView1.Rows[i].Cells[6].Text.Trim().ToString();
                         string unit1 = GridView1.Rows[i].Cells[7].Text.Trim().ToString();
                         string ystotal1 = GridView1.Rows[i].Cells[8].Text.Trim().ToString();
                         string zk1 = GridView1.Rows[i].Cells[9].Text.Trim().ToString();
                         string sstotal1 = GridView1.Rows[i].Cells[10].Text.Trim().ToString();
                         string lrr = GridView1.Rows[i].Cells[11].Text.Trim().ToString();

                         sqlStr = "INSERT INTO ord_plu(saleno,ID,plucode,pluname,price,count,unit,ystotal,zk,sstotal,jobno) "
      + " VALUES('" + saleno + "','" + id + "','" + plucode1 + "','" + pluname1 + "','" + price1 + "','" + count1 + "','" + unit1 + "','" + ystotal1 + "','" + zk1 + "','" + sstotal1 + "','"+lrr+"')";

                        comm.CommandText = sqlStr;
                        comm.Connection = con;
                        comm.Transaction = tran;
                        comm.ExecuteNonQuery();
                     }
                    tran.Commit();
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
       
        if (string.IsNullOrEmpty(this.next_person.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写部门主管工号！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.lrdate.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写下单日期！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.thdate.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写提货日期！');</script>");
            return;
        }
        if (this.ord_type.SelectedValue=="...请选择...")  //判断空值
        {
            Response.Write("<script>alert('请填写订单类型！');</script>");
            return;
        }
        if (this.ord_from.SelectedValue == "...请选择...")  //判断空值
        {
            Response.Write("<script>alert('请选择订单来源！');</script>");
            return;
        }
        if (this.thtype.SelectedValue == "...请选择...")  //判断空值
        {
            Response.Write("<script>alert('请选择提货方式！');</script>");
            return;
        }
        if (this.plutype.SelectedValue == "...请选择...")  //判断空值
        {
            Response.Write("<script>alert('请选择商品类型！');</script>");
            return;
        }
        if (this.fktype.SelectedValue == "...请选择...")  //判断空值
        {
            Response.Write("<script>alert('请选择付款方式！');</script>");
            return;
        }
        if (this.kp.SelectedValue == "...请选择...")  //判断空值
        {
            Response.Write("<script>alert('请选择是否开票！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.custname.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写客户名称！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.thaddr.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写提货地址！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.cust_body.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写客户联系人！');</script>");
            return;
        }
        if (string.IsNullOrEmpty(this.cust_body_tel.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填写客户联系人电话！');</script>");
            return;
        }


    }
    void bgn_bind()
    {
        string billno = Request["id"];
        string sql = "select * from ord_plu where saleno='" + billno + "'";
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
            }
            myrow[1] = rd["plucode"].ToString();
            myrow[2] = rd["pluname"].ToString();
            myrow[3] = rd["price"].ToString();
            myrow[4] = rd["count"].ToString();
            myrow[5] = rd["unit"].ToString();
            myrow[6] = rd["ystotal"].ToString();
            myrow[7] = rd["zk"].ToString();
            myrow[8] = rd["sstotal"].ToString();
            myrow[9] = rd["jobno"].ToString();
            Cpdt.Rows.Add(myrow);
            Cpdt.AcceptChanges();
            GridView1.DataKeyNames = new string[] { "录入人" };
            GridView1.DataSource = Cpdt;
            GridView1.DataBind();
        }
        rd.Close();
    }
    protected void plutype_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.pluname0.Text = "";
        this.plucode.Text = "";
        string plutype = this.plutype.SelectedValue;
      
       
        if (plutype == "储值卡")
        {  string pluname1 = this.pluname0.Text.Trim();
            pluname0.Visible = false;
            string sql = "select * from lj_grace_plu_saleord01 where name='卡' ";
            OracleDataReader rd = cc.ora_read(sql);
            if (rd.Read())
            {
                this.pluname.Enabled = true;
                plu_bind(sql);
                this.pluname.Items.Insert(0, "储值卡");
                this.plucode.Text = "储值卡";
                //    string orgcode = rd["orgcode"].ToString().Trim();
                //   this.plu.SelectedIndex = this.orgcode.Items.IndexOf(this.orgcode.Items.FindByValue(orgcode));
                rd.Close();
                rd.Dispose();
            }
        }
        else  if (plutype == "提领券")
        {
            pluname0.Visible = false;
            this.pluname.Enabled = true;
            string sql = "select * from lj_grace_plu_saleord03 where name='月饼' ";
            OracleDataReader rd = cc.ora_read(sql);
            if (rd.Read())
            {
                plu_bind(sql);
                this.pluname.Items.Insert(0, "...请选择...");
                //    string orgcode = rd["orgcode"].ToString().Trim();
                //   this.plu.SelectedIndex = this.orgcode.Items.IndexOf(this.orgcode.Items.FindByValue(orgcode));
                rd.Close();
                rd.Dispose();
            }
        }
        else   if (plutype == "粽子实物")
        {
            pluname0.Visible = false;
            this.pluname.Enabled = true;
            string sql = "select * from lj_grace_plu_saleord03 where name='粽子' order by pluname ";
            OracleDataReader rd = cc.ora_read(sql);
            if (rd.Read())
            {
           
                    plu_bind(sql);
                    this.pluname.Items.Insert(0, "...请选择...");
            //    string orgcode = rd["orgcode"].ToString().Trim();
             //   this.plu.SelectedIndex = this.orgcode.Items.IndexOf(this.orgcode.Items.FindByValue(orgcode));
                rd.Close();
                rd.Dispose();
            }
        }
        else if (plutype == "月饼实物")
        {
            pluname0.Visible = false;
            this.pluname.Enabled = true;
            string sql = "select * from lj_grace_plu_saleord03 where name='月饼' order by pluname  ";
            OracleDataReader rd = cc.ora_read(sql);
            if (rd.Read())
            {

                plu_bind(sql);
                this.pluname.Items.Insert(0, "...请选择...");
                //    string orgcode = rd["orgcode"].ToString().Trim();
                //   this.plu.SelectedIndex = this.orgcode.Items.IndexOf(this.orgcode.Items.FindByValue(orgcode));
                rd.Close();
                rd.Dispose();
            }
        }
        else if (plutype == "礼券")
        {
            pluname0.Visible = false;
            this.pluname.Enabled = true;
            string sql = "select * from lj_grace_plu_saleord01 where name='券' ";
            OracleDataReader rd = cc.ora_read(sql);
            if (rd.Read())
            {

                plu_bind(sql);
                this.pluname.Items.Insert(0, "礼券");
                this.plucode.Text = "礼券";
                //    string orgcode = rd["orgcode"].ToString().Trim();
                //   this.plu.SelectedIndex = this.orgcode.Items.IndexOf(this.orgcode.Items.FindByValue(orgcode));
                rd.Close();
                rd.Dispose();
            }
        }
        else if (plutype == "普通商品")
        {
            
            this.pluname.Enabled = true;
            pluname0.Visible = true;
           

        }
        else
        {
            this.pluname.Enabled = false;
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
    protected void pluname_SelectedIndexChanged(object sender, EventArgs e)
    {
        //pluname0.Visible = true;
        this.count.Text = "0";
        this.sstotal.Text = "0";
        this.zk.Text = "0";
        this.plucode.Text = this.pluname.SelectedValue;
        string plutype = this.plutype.SelectedValue;
        string plucode = this.pluname.SelectedValue;
        string sql = "select price from lj_grace_plu_saleord03 where plucode='"+plucode+"'";
        OracleDataReader rd = cc.ora_read(sql);
        if (rd.Read())
        {         
            this.price.Text = rd["price"].ToString().Trim();         
            rd.Close();
            rd.Dispose();
        }
        if (plutype == "提领券")
        {
            this.plucode.Text = "提领券";
        }
    }
    protected void next_person_TextChanged(object sender, EventArgs e)
    {
        string person = this.next_person.Text.Trim().ToUpper();
        string sql = "select real_name from ps_manager where user_name='" + person + "'";
        string ind1 = cc.ExecScalar1(sql).ToString();
        SqlDataReader rd = cc.ExceRead(sql);
        if (rd.Read())
        {
            this.next_person.Text = person + "_" + rd["real_name"].ToString();
            rd.Close();
            rd.Dispose();
        }
        else
        {
            Response.Write("<script>alert('工号错误，请重新填写！');</script>");
            return;
        }
    }
    protected void saler_TextChanged(object sender, EventArgs e)
    {
        string person = this.saler.Text.Trim();
        string sql = "select top 1 mobile from ps_manager where real_name='" + person + "'";
        string ind1 = cc.ExecScalar1(sql).ToString();
        this.saler_tel.Text = ind1;
    }
    protected void thtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        string thtype = this.thtype.SelectedValue;
        string com = Session["COM"].ToString();
        if (thtype == "门店自提")
        {
            this.thaddr.Text = this.dept.Text.Trim();
        }
        if (thtype == "工厂自提")
        {
                  this.thaddr.Text = "安德鲁森"+com+"烘焙工业园";
        }

    }
    protected void Button3_Click(object sender, EventArgs e)
    {

    }
    protected void TextBox1_TextChanged1(object sender, EventArgs e)
    {
        
    }
    protected void plucode_TextChanged(object sender, EventArgs e)
    {

    }
    protected void saler_tel_TextChanged(object sender, EventArgs e)
    {

    }
    protected void pluname0_TextChanged(object sender, EventArgs e)
    {
        string pluname1 = this.pluname0.Text.Trim();
        string sql = "select * from lj_grace_plu_saleord03 where name = '普通商品' and  pluname like '%" + pluname1 + "%'";
        OracleDataReader rd = cc.ora_read(sql);
        if (rd.Read())
        {

            plu_bind(sql);
            this.pluname.Items.Insert(0, "...点此选择具体商品...");
            //    string orgcode = rd["orgcode"].ToString().Trim();
            //   this.plu.SelectedIndex = this.orgcode.Items.IndexOf(this.orgcode.Items.FindByValue(orgcode));
            rd.Close();
            rd.Dispose();
        }
      
        
    }
    protected void dept_TextChanged(object sender, EventArgs e)
    {
        
        string depxz;
        if (dep01.Checked)
        {
            this.next_person.Text = "SC00076_粟红琼";
            depxz = dep01.Text;
            string AA = this.dept.Text.Trim();
            if (string.IsNullOrEmpty(this.dept.Text.Trim()) || AA.Length < 3)  //判断空值
            {
              
                Response.Write("<script>alert('请只填写正确的门店号,如:C001');</script>");
                this.dept.Text = "";
                return;
            }
            string orgcode = this.dept.Text.Trim().ToUpper();
            string sqlcd = "select orgcode||'_'||orgname from torgmanage where orgcode='" + orgcode + "'";
           // string sqlinfo = "select preorgcode  from torgmanage where orgcode='" + orgcode.Substring(0, 4) + "'";
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
                this.jm.Text = is_zy;
            }
        }
        else if (dep02.Checked)
        {
            depxz = dep02.Text;
            this.jm.Text = "直营";
        }
       
        else
        {
            depxz = "";
            Response.Write("<script>alert('请选择：部门或门店');</script>");
            return;
            // Response.Write("<script>window.history.back();</script>");
        }
        //如果选择门店再验证门店号是否正确；

    }
    protected void dep01_CheckedChanged(object sender, EventArgs e)
    {
        if (dep01.Checked)
        { 
            this.dept.Text = ""; 
        }
       
    }

    protected void m_TextChanged(object sender, EventArgs e)
    {
        string billno = this.TextBox1.Text.Trim();
        string sql = "select * from ord_info where num= '" + billno +  "'";
        SqlDataReader rd = cc.ExceRead(sql);
        if (rd.Read())
        {
            this.dept.Text = rd["dept"].ToString();
            this.saler.Text = rd["saler"].ToString();
            this.saler_tel.Text = rd["saler_tel"].ToString();
            this.thdate.Text = rd["thdate"].ToString();
            this.custname.Text = rd["custname"].ToString();
            this.cust_tax_code.Text = rd["cust_tax_code"].ToString();
            this.cust_addr.Text = rd["cust_address"].ToString();
            this.thaddr.Text = rd["th_address"].ToString();
            this.cust_body.Text = rd["cust_body"].ToString();
            this.cust_body_tel.Text = rd["cust_body_tel"].ToString();
            string fktype = rd["fktype"].ToString().Trim();
            this.fktype.SelectedIndex = this.fktype.Items.IndexOf(this.fktype.Items.FindByValue(fktype));
            string kp = rd["kp"].ToString().Trim();
            this.kp.SelectedIndex = this.kp.Items.IndexOf(this.kp.Items.FindByValue(kp));
            string ord_from = rd["ord_from"].ToString().Trim();
            this.ord_from.SelectedIndex = this.ord_from.Items.IndexOf(this.ord_from.Items.FindByValue(ord_from));
            string thtype = rd["thtype"].ToString().Trim();
            this.thtype.SelectedIndex = this.thtype.Items.IndexOf(this.thtype.Items.FindByValue(thtype));
            string plutype = rd["plutype"].ToString().Trim();
            this.plutype.SelectedIndex = this.plutype.Items.IndexOf(this.plutype.Items.FindByValue(plutype));
            string ord_type = rd["ordtype"].ToString().Trim();
            this.ord_type.SelectedIndex = this.ord_type.Items.IndexOf(this.ord_type.Items.FindByValue(ord_type));
            this.jm.Text = rd["jm"].ToString();
            string htcustom = rd["htcustom"].ToString().Trim();
            this.htcustom.SelectedIndex = this.htcustom.Items.IndexOf(this.htcustom.Items.FindByValue(htcustom));
            this.memo.Text = rd["memo"].ToString();

            if (plutype == "普通商品")
            {
                pluname0.Visible = true;
            }

            rd.Close();
            rd.Dispose();
            Cpdt = new DataTable();
            Createbt();
            GridView1.DataSource = Cpdt;
            GridView1.DataBind();
            bgn_bind();
        }
        else 
        {           
            Response.Redirect("http://192.168.11.249:1006/grace/add_saleord.aspx"); 
        }
    }
    protected void dep02_CheckedChanged(object sender, EventArgs e)
    {

    }
}