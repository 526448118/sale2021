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


public partial class grace_Default : System.Web.UI.Page
{
    CommonClass cc = new CommonClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string usercode = "SC03582";
            string sql0 = "select user_name+'_'+real_name from ps_manager where user_name = '" + usercode + "' ";
            string us = cc.ExecScalar1(sql0).ToString();
            this.lrr1.Text = this.lrr2.Text = us;
            string sql = "select * from mdjk_info where  单据状态 = '0' order by 序号 ";
            bind(sql);
            string sql1 = "select distinct qksm from  mdjk_qksm";
            SqlDataReader rd = cc.ExceRead(sql1);
            if (rd.Read())
            {
                plu_bind(sql1);
                this.qksm.Items.Insert(0, "请选择");
                rd.Close();
                rd.Dispose();
            }
        }
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
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
            if (CheckBox2.Checked == true)
            {
                cbox.Checked = true;
            }
            else
            {
                cbox.Checked = false;
            }
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        string orgcode = this.orgcode.Text.Trim().ToUpper();
        string orgname = this.orgname.Text.Trim();
        string dudao = this.dudao.Text.Trim();
        string jingli = this.jingli.Text.Trim();
        string lrr = this.lrr2.Text.Trim();
        string qkdate = this.qkdate.Text.Trim();
        string qksm= this.qksm.SelectedValue;
        string qkid = this.qkid.Text.Trim();
        string yc = this.yc.Text.Trim();
        string memo = this.memo.Text.Trim();
        string gxtime = DateTime.Now.ToString();
        string bill = orgcode + Convert.ToDateTime(qkdate).ToString("yyyyMMdd");
        if (string.IsNullOrEmpty(orgcode) || string.IsNullOrEmpty(lrr) || string.IsNullOrEmpty(qkdate))  //判断空值
        {
            Response.Write("<script>alert('添加数据不能为空！');</script>");
            return;
        }
        string sql = "";
        string sql1 = "select count(*) from mdjk_info where 门店编号 = '" + orgcode + "' and 欠款日期 = '" + qkdate + "' and 款项ID = '10'";
        if (cc.ExecScalar1(sql1).ToString() == "0")
        {
            sql = "insert into mdjk_info(单号,缴款说明,欠款日期,款项ID,应存金额,门店编号,门店名,财务导入人,导入时间,财务备注,单据状态) values('" + bill + "','" + qksm + "',convert(varchar(100),CONVERT(datetime, '" + qkdate + "', 101),23),'" + qkid + "','" + yc + "','" + orgcode + "','" + orgname + "','" + lrr + "','" + gxtime + "','" + memo + "','0')";
        }
        else
        {
            Response.Write("<script>alert('该数据已存在，若要修改，请点击修改按钮进行操作！');</script>");
        }
        try
        {
            string fh = cc.execSQL01(sql).ToString();
            if (fh == "True")
            {
                Response.Write("<script>alert('提交成功！');window.location.href ='mdjk_dr.aspx';</script>");
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
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string value= this.GridView1.Rows[0].Cells[1].Text;
        string date =DateTime.Now.ToString();
        
       for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
            if (cbox.Checked == true)
            {
                string keyname = GridView1.Rows[i].Cells[1].Text;
                string ins = "Insert into mdjk_info_his select a.*,'" + date + "' from mdjk_info a  where 序号 = '" + keyname + "'";
                string sql = "delete from mdjk_info where 序号 = '" + keyname + "'";
              //  Response.Write(ins + sql);
                cc.execSQL01(ins);
                cc.execSQL01(sql);

                try
                {
                    string fh = cc.execSQL01(sql).ToString();
                    if (fh == "True")
                    {
                        Response.Write("<script>alert('操作成功！');window.location.href ='mdjk_dr.aspx';</script>");
                    }
                    else
                    {
                        Response.Write("操作失败！");
                    }
                }

                catch (Exception ex)
                {
                    Response.Write("提交失败,失败原因:" + ex.Message);
                }
                finally
                {
                }
            }
        }
    }
    protected void btnDown_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;
        string ID = lbtn.CommandArgument;
        string sql = "select * from mdjk_info where 序号 = '" + ID + "' ";
        SqlConnection myConn = cc.Getconsql02();
        SqlDataAdapter sda = new SqlDataAdapter(sql, myConn);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            this.orgcode.Text = dr["门店编号"].ToString();
            this.yc.Text = dr["应存金额"].ToString();
            this.memo.Text = dr["财务备注"].ToString();
            this.qkdate.Text = dr["欠款日期"].ToString();
            this.orgname.Text = dr["门店名"].ToString();

            this.billno.Text = ID;

            this.Button2.Enabled = false;
            this.Button1.Enabled = false;


            this.Button3.Enabled = true;
            this.Button4.Enabled = true;
            this.orgcode.ReadOnly = true;
        }
        string sql0 = "select * from readhscmp.lj_grace_dudao where orgcode = '" + this.orgcode.Text.Trim().ToUpper() + "'";
        OracleDataReader rd = cc.ora_read(sql0);
        if (rd.Read())
        {
            this.dudao.Text = rd["sname"].ToString();
            this.jingli.Text = rd["jobno"].ToString();
            rd.Close();
            rd.Dispose();
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        this.billno.Text = string.Empty;
        this.orgcode.Text = string.Empty;
        this.orgname.Text = string.Empty;
        this.dudao.Text = string.Empty;
        this.jingli.Text = string.Empty;
        this.yc.Text = string.Empty;
        this.memo.Text = string.Empty;
        this.memo.Text = string.Empty;

        this.yc.Enabled = true;
        this.Button2.Enabled = true;
        this.Button1.Enabled = true;

        this.Button3.Enabled = false;
        this.Button4.Enabled = false;

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string yc = this.yc.Text.Trim();
        string memo = this.memo.Text.Trim();
        string gxtime = DateTime.Now.ToString();
        string billno = this.billno.Text.Trim();
        string jkid = this.qkid.Text.Trim();
        if (string.IsNullOrEmpty(this.orgcode.Text.Trim()) || string.IsNullOrEmpty(this.lrr2.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('更新数据不能为空！');</script>");
            return;
        }
        string sql = "update mdjk_info set 应存金额 = '" + yc + "',memo = '" + memo + "',cw_gx_time = '" + gxtime + "' where 单号 = '" + billno + "' and 缴款ID = '"+jkid+"'";
        //Response.Write(sql);
        try
        {
            string fh = cc.execSQL01(sql).ToString();
            if (fh == "True")
            {
                Response.Write("<script>alert('更新成功！');window.location.href ='mdjk_dr.aspx';</script>");
            }
            else
            {
                Response.Write("更新失败！");
            }
        }

        catch (Exception ex)
        {
            Response.Write("更新失败,失败原因:" + ex.Message);
        }
        finally
        {
        }
        this.yc.Text = string.Empty;
        this.memo.Text = string.Empty;
        this.memo.Text = string.Empty;

        this.yc.Enabled = true;
        this.Button2.Enabled = true;
        this.Button1.Enabled = true;


        this.Button3.Enabled = false;
        this.Button4.Enabled = false;
       
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
             string filename = FileUpload1.FileName;              //获取Execle文件名  DateTime日期函数
             string savePath = Server.MapPath(("uploadfiles\\") + filename);//Server.MapPath 获得虚拟服务器相对路径
             DataTable ds = new DataTable();
             FileUpload1.SaveAs(savePath);                        //SaveAs 将上传的文件内容保存在服务器上
             ds = GetExcelDatatable(savePath);           //调用自定义方法
             DataRow[] dr = ds.Select();            //定义一个DataRow数组
             int rowsnum = ds.Rows.Count;
             int successly = 0;
             string lrr = this.lrr1.Text.Trim();
             if (rowsnum == 0)
             {
                 Response.Write("<script>alert('Excel表为空表,无数据!')</script>");   //当Excel表为空时,对用户进行提示
             }
             else
             {
                 for (int i = 0; i < dr.Length; i++)
                 {
                     //前面除了你需要在建立一个“upfiles”的文件夹外，其他的都不用管了，你只需要通过下面的方式获取Excel的值，然后再将这些值用你的方式去插入到数据库里面
                     string orgcode = dr[i]["门店编号"].ToString();
                     string qkdate = dr[i]["欠款日期"].ToString();
                     string qkd = Convert.ToDateTime(qkdate).ToString("yyyy-MM-dd");
                     string id_k = dr[i]["款项ID"].ToString();
                     string jksm = dr[i]["缴款说明"].ToString();
                     string yc = dr[i]["应存金额"].ToString();
                     string memo = dr[i]["财务备注"].ToString();
                     string gxtime = DateTime.Now.ToString();
                     string bill = orgcode + Convert.ToDateTime(qkdate).ToString("yyyyMMdd");
                     string orgname = "";
                     string dudao = "";
                     string jingli = "";
         
                     string sqld = "select * from readhscmp.lj_grace_dudao where orgcode = '" + orgcode + "'";//获取门店信息
                     OracleDataReader rd = cc.ora_read(sqld);
                     if (rd.Read())//如果有数据  写入表单
                     {
                         orgname = rd["orgname"].ToString().Trim();
                         dudao = rd["sname"].ToString().Trim();
                         jingli = rd["jobno"].ToString().Trim();
                     }
                     else
                     {
                         orgname = null;
                     }                  
                     if (orgname != null)
                     {
                         try
                         {
                             var uuid = Guid.NewGuid().ToString();
                             string sql0;
                             string sql1 = "select count(*) from mdjk_info where 单号 = '"+bill+"' and 款项ID = '"+id_k+"'";
                             if (cc.ExecScalar1(sql1).ToString() == "0")
                             {
                                 sql0 = "insert into mdjk_info(单号,款项ID,缴款说明,应存金额,门店编号,门店名,欠款日期,财务导入人,导入时间,财务备注,单据状态) values('" + bill + "','" + id_k + "','" + jksm + "','" + yc + "','" + orgcode + "','" + orgname + "','" + qkd + "','" + this.lrr1.Text.Trim() + "','" + gxtime + "','" + memo + "','0')";
                             }
                             else
                             {
                                 sql0 = "update mdjk_info set 应存金额 = '" + yc + "',财务导入人 = '" + lrr + "',导入时间 = '" + DateTime.Now.ToString() + "',单据状态= '0' where 单号 = '" + bill + "' and 款项ID = '" + id_k + "'";
                             }

                             string fh = cc.execSQL01(sql0).ToString();
                             if (fh == "True")
                             {
                                 successly++;
                             }

                         }
                         catch (Exception ex)
                         {
                             Response.Write("提交失败,失败原因:" + ex.Message);
                         }
                     }
                 }
                 if (successly == rowsnum)
                 {
                     Response.Write("<script>alert('Excle表导入成功!共导入" + successly + "条数据！');window.location.href ='mdjk_dr.aspx';</script>");
                 }
                 else
                 {
                     Response.Write("<script>alert('有门店信息错误!共导入" + successly + "条数据！');window.location.href ='mdjk_dr.aspx';</script>");
                 }
             }
             myConn.Close();
        }


        protected void lrr_TextChanged(object sender, EventArgs e)
        {

        }

        protected void pluname1_TextChanged(object sender, EventArgs e)
        {
            string orgcode = this.orgcode.Text.Trim().ToUpper();
            string sql = "select * from readhscmp.lj_grace_dudao where orgcode = '"+orgcode+"'";
            OracleDataReader rd = cc.ora_read(sql);
            if (rd.Read())
            {
                this.orgname.Text = rd["orgname"].ToString();
                this.dudao.Text = rd["sname"].ToString();
                this.jingli.Text = rd["jobno"].ToString();
                rd.Close();
                rd.Dispose();
            }
        }

        protected void Button0_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.orgcode1.Text.Trim()) || string.IsNullOrEmpty(this.qkdate0.Text.Trim()) || string.IsNullOrEmpty(this.qkdate1.Text.Trim()))  //判断空值
            {
                Response.Write("<script>alert('请输入门店信息和查询日期！');</script>");
                return;
            }
            string sql = "select * from mdjk_info where (门店编号 = '" + this.orgcode1.Text.Trim().ToUpper() + "' or 门店名 like '%" + this.orgcode1.Text.Trim().ToUpper() + "%') and 欠款日期 between '" + this.qkdate0.Text.Trim() + "' and '" + this.qkdate1.Text.Trim() + "' and 单据状态 = '" + this.status.SelectedIndex+ "' order by 序号";
            bind(sql);
        }
        protected void qkid_SelectedIndexChanged(object sender, EventArgs e)
        {
            string qksm = this.qksm.SelectedValue;
            string sql = "select qkid from mdjk_qksm where qksm = '" + qksm + "'";
            string qkid1 = cc.ExecScalar1(sql);
            this.qkid.Text = qkid1;
        }
        protected void Button7_Click(object sender, EventArgs e)
        {
            string lrr = this.lrr2.Text.Trim();
            string qkdate = this.qkdate.Text.Trim();
            if((string.IsNullOrEmpty(qkdate))||(string.IsNullOrEmpty(lrr)))
            {
                Response.Write("<script>alert('请选择欠款日期和填写录入人信息！');</script>");
                return;
            }
            string sql = "select orgcode,orgname,rptdate,zfcode00 from readhscmp.hl_table_mdjk02 where rptdate = '" + qkdate + "'";
            OracleConnection myConn = cc.Getconora();
            myConn.Open();
            OracleDataAdapter myda = new OracleDataAdapter(sql, myConn);
            DataSet myds2 = new DataSet();
            myda.Fill(myds2, "jkdata");
            GridView2.DataSource = myds2;
            GridView2.DataBind();
            myConn.Close();
            string sqlins;
            int rownum = GridView2.Rows.Count;
            Response.Write(rownum);
            int s = 0;
            for (int i = 0; i <= GridView2.Rows.Count - 1; i++)
            {
                string orgcode = GridView2.Rows[i].Cells[0].Text.Trim();
                string orgname = GridView2.Rows[i].Cells[1].Text.Trim();
                string rptdate = GridView2.Rows[i].Cells[2].Text.Trim();
                string zfcode00 = GridView2.Rows[i].Cells[3].Text.Trim();
                string sql1 = "select count(*) from mdjk_info where 门店编号 = '" + orgcode + "' and 欠款日期 = '" + rptdate + "' and 款项ID = '10'";
                if (cc.ExecScalar1(sql1).ToString() == "0")
                {
                    sqlins = "insert into mdjk_info(单号,缴款说明,款项ID,应存金额,门店编号,门店名,欠款日期,财务导入人,导入时间,财务备注,单据状态) values ('" + orgcode + Convert.ToDateTime(rptdate).ToString("yyyyMMdd") + "','现金应存营业款','10','" + zfcode00 + "','" + orgcode + "','" + orgname + "','" + rptdate + "','" + lrr + "','" + DateTime.Now.ToString() + "','','0')";
                }
                else
                {
                    sqlins = "update mdjk_info set 应存金额 = '" + zfcode00 + "',财务导入人 = '" + lrr + "',导入时间 = '" + DateTime.Now.ToString() + "',单据状态= '0' where 门店编号 = '" + orgcode + "' and 欠款日期 = '" + rptdate + "' and 款项ID = '10'";
                }
                //Response.Write(cc.ExecScalar1(sql1).ToString());
            
                try
                {
                    string fh = cc.execSQL01(sqlins).ToString();
                    if (fh == "True")
                    {
                        s++;
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("提交失败,失败原因:" + ex.Message);
                }
            }
            if (s == rownum)
            {
                Response.Write("<script>alert('营业数据生成成功!共生成" + s + "条数据！');window.location.href ='mdjk_dr.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('有数据未生成成功!共导入" + s + "/" + rownum + "条数据！');window.location.href ='mdjk_dr.aspx';</script>");
            }
        }
        protected void bgndate_TextChanged(object sender, EventArgs e)
        {

        }
}
  
    
  