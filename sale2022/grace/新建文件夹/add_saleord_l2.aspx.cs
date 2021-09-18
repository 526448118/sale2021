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
using System.Web.ApplicationServices;
using System.Runtime.Serialization.Json;

public partial class _add_saleord : System.Web.UI.Page
{
    CommonClass cc = new CommonClass();
    public static DataTable Cpdt;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.qscardid.Enabled = this.jscardid.Enabled = this.dhmemo.Enabled = false;
        string billno = Request["id"];
        if (string.IsNullOrEmpty(billno))
        {
            billno = "0";
        }
        //string jobno = "SC03582";
        string jobno = Session["RememberName"].ToString();
        this.lrdate.Text = DateTime.Now.ToString("yyyy-MM-dd");

        if (Session["RememberName"] == null)
        {
            Response.Write("<script>alert('会话超时，请重新登录！');top.location.href ='http://192.168.11.249:1006/index.aspx';</script>");
        }
        if (!IsPostBack)

        {
            //--------------获取单号
            SqlConnection con = cc.Getconsql02();
            con.Open();
            SqlTransaction tran;
            tran = con.BeginTransaction();
            string sql1 = "select * from salenum";
            string sql2 = "update salenum set id = id +1";
            SqlCommand cmd1 = new SqlCommand(sql1, con);
            cmd1.Transaction = tran;
            int ssss = Convert.ToInt32(DbHelperSQL.GetSingle(sql1));
            SqlCommand cmd2 = new SqlCommand(sql2, con);
            cmd2.Transaction = tran;
            try
            {
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                tran.Commit();//提交事物 
                // Response.Write("<script>alert('创建订单号成功！')</script>");
            }
            catch
            {
                tran.Rollback();//回滚操作 
                Response.Redirect("../add_saleord_l2.aspx");
            }
            finally
            {
                
            }
            this.Label3.Text = System.DateTime.Now.ToString("yyyyMMdd") + ssss;
            
            //--------------
          
            //------加载信息-------
            string sqlbind = "select * from ord_info where num='" + billno + "'";
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
                string jm = rd["jm"].ToString().Trim();
                this.jm.Text = rd["jm"].ToString();
                string htcustom = rd["htcustom"].ToString().Trim();
                this.htcustom.SelectedIndex = this.htcustom.Items.IndexOf(this.htcustom.Items.FindByValue(htcustom));
                this.memo.Text = rd["memo"].ToString();
                this.Label1.Text = rd["sstotal"].ToString();
                if (plutype == "普通商品")
                {
                    pluname0.Visible = true;
                }
                rd.Close();
                rd.Dispose();
                string sqlplu = "select * from ord_plu where saleno = '" + billno + "'";
                bind(sqlplu);               
            }
            //------------------

            else
            {
                string dept = "select dept from ps_manager where user_name='" + jobno + "'";
                string cen = cc.ExecScalar1(dept).ToString();
                this.cen.Text = cen;
            }
            con.Close();
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
        string plucode2 = this.plucode.Text.Trim();
        string pluname1 = this.pluname.SelectedItem.Text;
        string pluname = HttpUtility.UrlDecode(pluname1, Encoding.GetEncoding("gb2312"));

        string count = this.count.Text.Trim();
        string price = Request.Form["price"].Trim();
        string zk = this.zk.Text.Trim();                 string sstotal = this.sstotal.Text.Trim();
        string memo = this.memo.Text.Trim(); string next_person = this.next_person.Text.Trim();
        string gxtime = DateTime.Now.ToString();         
        decimal ystotal = Convert.ToDecimal(price) * Convert.ToDecimal(count); string htcustom = this.htcustom.SelectedValue;

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
        int PID;
        string sql01 = "select count(*) from ord_plu where saleno = '" + this.Label3.Text.Trim() + "'";
        PID = Convert.ToInt32(DbHelperSQL.GetSingle(sql01));
        if (PID == 0)
        {
            PID = 1;
        }
        else
        {
            string sqlmax = "select  max(convert(int,ID)) from ord_plu where saleno = '" + this.Label3.Text.Trim() + "' ";
            PID = Convert.ToInt32(DbHelperSQL.GetSingle(sqlmax)) + 1;
        }
        string sql00 = "insert into  ord_plu(saleno,id,plucode,pluname,price,count,unit,ystotal,zk,sstotal,jobno) values('" + this.Label3.Text.Trim() + "','" + PID + "','" + plucode2 + "','" + pluname + "','" + price + "',"
        + "'" + count + "','个','" + ystotal + "','" + zk + "','" + sstotal + "','" + PID + "_" + Session["RememberName"].ToString() + "')  ";
        cc.execSQL01(sql00);

        string sql02 = "select * from ord_plu where saleno = '" + this.Label3.Text.Trim() + "' order by convert(int,ID)";
        bind(sql02);
        //GridView1.DataKeyNames = new string[] { "录入人"};
        decimal sum = 0;
        foreach (GridViewRow row in GridView1.Rows)
        {
            sum += Convert.ToDecimal(row.Cells[10].Text);
        }
        Label1.Text = sum.ToString();
        this.ss.Text = sum.ToString();
        //ss.Text = sum.ToString();
    }
    public void bind(string sql)
    {
        SqlConnection myConn = cc.Getconsql02();
        myConn.Open();
        SqlDataAdapter myda = new SqlDataAdapter(sql, myConn);
        DataSet myds = new DataSet();
        myda.Fill(myds, "tb_Member");
        GridView1.DataSource = myds;
        GridView1.DataKeyNames = new string[] { "ID" };
        GridView1.DataBind();
        myConn.Close();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string ID = GridView1.DataKeys[e.RowIndex].Value.ToString().Trim();
        string saleno = this.Label3.Text.Trim();
        string sqldel = "delete from ord_plu where saleno = '" + saleno + "' and ID = '" + ID + "'";
        cc.execSQL01(sqldel);
        string sql02 = "select * from ord_plu where saleno = " + this.Label3.Text.Trim() + "";
        bind(sql02);
        decimal sum = 0;
        foreach (GridViewRow row in GridView1.Rows)
        {
            sum += Convert.ToDecimal(row.Cells[10].Text);
        }
        Label1.Text = sum.ToString();
        this.ss.Text = sum.ToString();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
       
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
       
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
       /* if (string.IsNullOrEmpty(this.jm.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请选择加盟或直营！');</script>");
            return;
        }*/
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
        if (string.IsNullOrEmpty(this.ss.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('请填实收金额！');</script>");
            return;
        }
        //---------------------------------------------------------------
        this.Button2.Attributes.Add("onclick", "javascript:if(confirm('已确认订单信息和商品信息完整无误了吗，确认后将不能再修改?') == false) return false;");
        string num = this.Label3.Text.Trim();

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
        string count = this.count.Text.Trim(); string price = Request.Form["price"].Trim();
        string zk = this.zk.Text.Trim(); string sstotal = this.Label1.Text.Trim();
        string memo = this.memo.Text.Trim(); 
        string gxtime = DateTime.Now.ToString(); string jobno = Session["RememberName"].ToString();
        string com = Session["COM"].ToString();
        string jm  = this.jm.Text.Trim();
        string htcustom = this.htcustom.SelectedValue;
        string ss = this.ss.Text.Trim();

        //远程充值
        string is_yccz = "";
        string qscardid = ""; string jscardid = ""; string dhmemo = "";
        //Response.Write(sstotal);

        if (dep3.Checked == true)
        {
            is_yccz = "1";
            qscardid = this.qscardid.Text.Trim(); jscardid = this.jscardid.Text.Trim(); dhmemo = this.dhmemo.Text.Trim();
        }
        else if (dep4.Checked == true)
        {
            is_yccz = "0";
        }


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
          + "  memo,next_person ,com,gxtime,num,ystotal,sstotal,bill_status,lrstaff,ordtype,jm,htcustom,isdc,hk,ss,is_yccz,ksid,jsid,dhmemo)"
      + " VALUES ('" + dept + "','" + cen + "','" + saler + "','" + saler_tel + "','" + lrdate + "','" + thdate + "','" + ord_from + "',"
     + " '" + thtype + "','" + plutype + "','" + custname + "','" + cust_tax_code + "','" + cust_addr + "','" + fktype + "', "
     + " '" + kp + "','" + thaddr + "','" + cust_body + "','" + cust_body_tel + "', "
    + " '" + memo + "','" + next_person + "','" + com + "','" + gxtime + "','" + num + "','" + ystotal + "','" + sstotal + "','0','" + jobno + "','" + ordtype + "','" + jm + "','" + htcustom + "','0','" + hk + "','" + ss + "','" + is_yccz + "','" + qscardid + "','" + jscardid + "','" + dhmemo + "')";
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
                 Response.Write("提交失败,失败原因:" + ex.Message + sql);

             }
             finally
             {
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
 
    protected void plutype_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.pluname0.Text = "";
        this.plucode.Text = "";
        string plutype = this.plutype.SelectedValue;
        this.price.ReadOnly = true;

       
        if (plutype == "储值卡")
        {
            this.dep3.Enabled = this.dep4.Enabled = true;
            string pluname1 = this.pluname0.Text.Trim();
            pluname0.Visible = false;
            string sql = "select  distinct plucode,pluname from lj_grace_plu_saleord01 where name='卡' ";
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
            this.price.ReadOnly = false;
        }
        else  if (plutype == "提领券")
        {

            this.dep3.Enabled = this.dep4.Enabled = false;
            pluname0.Visible = false;
            this.pluname.Enabled = true;
            string plu = "";
            if (Convert.ToInt32(DateTime.Now.Month.ToString()) < 8)
            {
                plu = "粽子";
            }
            else
            {
                plu = "月饼";
            }
            //Response.Write("<script>alert('" + plu + "');</script>");
            string sql = "select distinct plucode,pluname from lj_grace_plu_saleord03 where name in ('" + plu + "') order by pluname ";
            OracleDataReader rd = cc.ora_read(sql);
            if (rd.Read())
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
                this.pluname.DataTextField = ds.Tables["files"].Columns[1].ToString();
                this.pluname.DataValueField = ds.Tables["files"].Columns[0].ToString();

                this.pluname.DataBind();
                //释放占用的资源
                ds.Dispose();
                dapt.Dispose();
                myConn.Close();


                this.pluname.Items.Insert(0, "...请选择...");
                rd.Close();
                rd.Dispose();
            }
            this.plucode.Text = "提领券";
        }
        else   if (plutype == "粽子实物")
        {
            this.dep3.Enabled = this.dep4.Enabled = false;
            pluname0.Visible = false;
            this.pluname.Enabled = true;
            string sql = "select distinct plucode,pluname from lj_grace_plu_saleord03 where name='粽子' order by pluname ";
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
            this.dep3.Enabled = this.dep4.Enabled = false;
            pluname0.Visible = false;
            this.pluname.Enabled = true;
            string sql = "select distinct plucode,pluname from lj_grace_plu_saleord03 where name='月饼' and pluname not like '%特款%'  and pluname not like '%单饼%'  order by pluname  ";
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
            this.dep3.Enabled = this.dep4.Enabled = false;
            pluname0.Visible = false;
            this.pluname.Enabled = true;
            string sql = "select distinct plucode,pluname from lj_grace_plu_saleord01 where name='券' ";
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
            this.price.ReadOnly = false;
        }
        else if (plutype == "普通商品")
        {
            this.dep3.Enabled = this.dep4.Enabled = false;
            this.pluname.Enabled = true;
            pluname0.Visible = true;
           

        }
        else
        {
            this.dep3.Enabled = this.dep4.Enabled = false;
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
        this.pluname.DataTextField = ds.Tables["files"].Columns[1].ToString();
        this.pluname.DataValueField = ds.Tables["files"].Columns[0].ToString();

        this.pluname.DataBind();
        //释放占用的资源
        ds.Dispose();
        dapt.Dispose();
        myConn.Close();
        
    }

    [WebMethod]
    public static string GetDeptname(string pluname,string plutype) //
    {

        OracleConnection conn = new OracleConnection();
        string connStr = ConfigurationManager.ConnectionStrings["constrora"].ToString();
        conn.ConnectionString = connStr;
        conn.Open();
        string pluname1 = pluname.Trim();
        string plutype1 = plutype.Trim();

        string sqlcd ="";
        if (plutype1 == "普通商品")
        {
            sqlcd = "select plucode||'_'||price  from lj_grace_plu_saleord03 where plucode='" + pluname1 + "'  order by price asc ";// and jgzccode = 'ywcd'
        }
        else
        {
            sqlcd = "select plucode||'_'||price from lj_grace_plu_saleord03 where plucode='" + pluname1 + "'";
        }
        OracleCommand myCmd = new OracleCommand(sqlcd, conn);
        string result = myCmd.ExecuteScalar().ToString();
       
        myCmd.Dispose();
        conn.Close();
        if (result == null)
        {
            return null;
        }
        else
        {
            return result;
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

    protected void TextBox1_TextChanged1(object sender, EventArgs e)
    {
        
    }

    protected void saler_tel_TextChanged(object sender, EventArgs e)
    {

    }
    protected void pluname0_TextChanged(object sender, EventArgs e)
    {
        string pluname1 = this.pluname0.Text.Trim();
        string sql = " select distinct plucode,pluname from lj_grace_plu_saleord03 where name = '普通商品' and  pluname like '%" + pluname1 + "%'  ";//and jgzccode = 'ywcd'
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
            string sqlzy = "select is_zy from hl_view_is_zy where orgcode='" + orgcode + "'";
            string is_zy = cc.ExecScalar(sqlzy);
          //  string sqlinfo = "select preorgcode  from torgmanage where orgcode='" + orgcode.Substring(0, 4) + "'";
           // string com = cc.ExecScalar(sqlinfo);
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
                if(is_zy == "直营店")
                {
                    this.jm.Text = "直营";
                }
                else if (is_zy == "加盟店")
                {
                    this.jm.Text = "加盟";
                }
                else
                {
                    this.jm.ReadOnly = false;
                }
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
        if (string.IsNullOrEmpty(billno))
        {
            billno = "0";
        }
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
         
        }
        else 
        {           
            Response.Redirect("http://192.168.11.249:1006/grace/add_saleord.aspx"); 
        }
    }
    protected void dep02_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void yccz_CheckedChanged(object sender, EventArgs e)
    {
        if (this.dep3.Checked == true)
        {
            this.qscardid.Enabled = this.jscardid.Enabled = this.dhmemo.Enabled = true;
        }
        else
        {
            this.qscardid.Enabled = this.jscardid.Enabled = this.dhmemo.Enabled = false;
        }
    }
}