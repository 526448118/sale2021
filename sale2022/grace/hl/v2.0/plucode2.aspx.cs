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

public partial class grace_Default : System.Web.UI.Page
{
    CommonClass cc = new CommonClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        // string com = Session["COM"].ToString();
        string com = "成都";
        //Response.Write(com);
        if (!IsPostBack)
        {
            string sql = "select * from ord_shuishou_code where com = '" + com + "'";
            bind(sql);
        }
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
        DataSet myds = new DataSet();
        myda.Fill(myds, "tb_Member");
        GridView1.DataSource = myds;
        GridView1.DataKeyNames = new string[] { "type" };
        GridView1.DataBind();
        myConn.Close();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string com = Session["COM"].ToString();
        string pluname = this.pluname.Text.Trim();
        string sqlplu2 = "select count(*) from ord_shuishou_code where type = '" + pluname + "_" + com + "'";
        int cxpluname2 = Convert.ToInt32(cc.ExecScalar1(sqlplu2));
        if (cxpluname2 > 0)
        {
            Response.Write("<script>alert('添加数据不能重复1！');</script>");
            return;
        }
        string sqlplu = "select count(*) from ord_shuishou_code where type = '" + pluname + "'";
        int cxpluname = Convert.ToInt32(cc.ExecScalar1(sqlplu));
        if (cxpluname > 0 && pluname.Length >4)
        {
            if (pluname.Substring(pluname.Length - 4, 4) == com)//同一个公司判断不能重复
            {
                Response.Write("<script>alert('添加数据不能重复！');</script>");
                return;
            }
            else
            {
                pluname = pluname + "_" + com;//不同公司物料重复在后面添加公司代码区分
            }
        }
        if (cxpluname > 0 && pluname.Length < 5)
        {           
             pluname = pluname + "_" + com;//不同公司物料重复在后面添加公司代码区分            
        }
        
        string s_code = this.s_code.Text.Trim();
        string s_code_ver = this.s_code_ver.Text.Trim();
        string shuilv = this.shuilv.Text.Trim();
        string memo = this.memo.Text.Trim();
        string gxtime = DateTime.Now.ToString();
        if (string.IsNullOrEmpty(this.pluname.Text.Trim()) || string.IsNullOrEmpty(this.s_code.Text.Trim()) || string.IsNullOrEmpty(this.s_code_ver.Text.Trim()) || string.IsNullOrEmpty(this.shuilv.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('添加数据不能为空！');</script>");
            return;
        }
        string sql = "insert into ord_shuishou_code(s_code,s_code_ver,shuilv,type,memo,gxtime,com) values ('" + s_code + "','" + s_code_ver + "','" + shuilv + "','" + pluname + "','" + memo + "','" + gxtime + "','" + com + "')";
        //Response.Write(sql);
        try
        {
            string fh = cc.execSQL01(sql).ToString();
            if (fh == "True")
            {
                Response.Write("<script>alert('提交成功！');window.location.href ='plucode.aspx';</script>");
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

    protected void Button2_Click(object sender, EventArgs e)
    {
        //string value= this.GridView1.Rows[0].Cells[1].Text;
        //Response.Write("<script>alert('" + value + "！');</script>");
        string com = Session["COM"].ToString();
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
            if (cbox.Checked == true)
            {
                string datetime = DateTime.Now.ToString();
                string keyname = GridView1.Rows[i].Cells[2].Text;
                string ins = " Insert into ord_shuishou_code_his(s_code,s_code_ver,type,memo,udp,gxtime,deletetime,id) select s_code,s_code_ver,type,memo,udp,gxtime,'" + datetime + "',id from ord_shuishou_code  where type = '" + keyname + "'";
                string sql = "delete from ord_shuishou_code where type = '" + keyname + "'";
                cc.execSQL01(ins);
                cc.execSQL01(sql);
               // Response.Write(sql);
            }
        }
        string sql1 = "select * from ord_shuishou_code where com = '" + com + "'";
        bind(sql1);
    }
    protected void btnDown_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;
        string ID = lbtn.CommandArgument;
        string sql = "select * from ord_shuishou_code where type = '" + ID + "' ";
        SqlConnection myConn = cc.Getconsql02();
        SqlDataAdapter sda = new SqlDataAdapter(sql, myConn);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            this.pluname.Text = dr["type"].ToString();
            this.s_code.Text = dr["s_code"].ToString();
            this.s_code_ver.Text = dr["s_code_ver"].ToString();
            this.memo.Text = dr["memo"].ToString();
            this.shuilv.Text = dr["shuilv"].ToString();

            this.pluname.Enabled = false;
            this.Button1.Enabled = false;

            this.Button3.Enabled = true;
            this.Button4.Enabled = true;
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        this.pluname.Text = string.Empty;
        this.s_code.Text = string.Empty;
        this.s_code_ver.Text = string.Empty;
        this.memo.Text = string.Empty;

        this.pluname.Enabled = true;
        this.Button1.Enabled = true;

        this.Button3.Enabled = false;
        this.Button4.Enabled = false;

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string pluname = this.pluname.Text.Trim();
        string s_code = this.s_code.Text.Trim();
        string s_code_ver = this.s_code_ver.Text.Trim();
        string shuilv = this.shuilv.Text.Trim();
        string memo = this.memo.Text.Trim();
        string gxtime = DateTime.Now.ToString();
        if (string.IsNullOrEmpty(this.pluname.Text.Trim()) || string.IsNullOrEmpty(this.s_code.Text.Trim()) || string.IsNullOrEmpty(this.s_code_ver.Text.Trim()) || string.IsNullOrEmpty(this.shuilv.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('更新数据不能为空！');</script>");
            return;
        }
        string sql = "update ord_shuishou_code set s_code = '" + s_code + "',s_code_ver = '" + s_code_ver + "',shuilv = '" + shuilv + "',memo = '" + memo + "',gxtime = '" + gxtime + "' where type = '" + pluname + "'";
        Response.Write(sql);
        try
        {
            string fh = cc.execSQL01(sql).ToString();
            if (fh == "True")
            {
                Response.Write("<script>alert('更新成功！');window.location.href ='plucode.aspx';</script>");
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
        this.pluname.Text = string.Empty;
        this.s_code.Text = string.Empty;
        this.s_code_ver.Text = string.Empty;
        this.memo.Text = string.Empty;

        this.pluname.Enabled = true;
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
            string com = Session["COM"].ToString();
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
             int successly = 0;
             if (rowsnum == 0)
             {
                 Response.Write("<script>alert('Excel表为空表,无数据!')</script>");   //当Excel表为空时,对用户进行提示
             }
             else
             {
                 string _Result = "";
                 for (int i = 0; i < dr.Length; i++)
                 {
                     //前面除了你需要在建立一个“upfiles”的文件夹外，其他的都不用管了，你只需要通过下面的方式获取Excel的值，然后再将这些值用你的方式去插入到数据库里面
                     string type = dr[i]["商品名"].ToString();
                     string s_code = dr[i]["税收编码"].ToString();
                     string shuilv = dr[i]["税率"].ToString();
                     string s_code_ver = dr[i]["税收编码版本"].ToString();
                     string memo = dr[i]["备注"].ToString();
                     string gxtime = DateTime.Now.ToString();


                     //string sqlplu2 = "select count(*) from ord_shuishou_code where type = '" + type + "_" + com + "'";
                     //int cxpluname2 = Convert.ToInt32(cc.ExecScalar1(sqlplu2));
                     //if (cxpluname2 > 0)
                     //{
                     //    Response.Write(1);
                     //    return;
                     //}
                     string sqlplu = "select count(*) from ord_shuishou_code where type = '" + type + "'";
                     int cxpluname = Convert.ToInt32(cc.ExecScalar1(sqlplu));
                     if (cxpluname > 0)
                     {
                         
                             type = type + "_" + com;//不同公司物料重复在后面添加公司代码区分
                         
                     }
                     try
                     {
                         var uuid = Guid.NewGuid().ToString();                         
                         //ExecScalar1
                         string sql = string.Format("insert into ord_shuishou_code(id,type,s_code,s_code_ver,shuilv,gxtime,memo,com) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", uuid, type, s_code, s_code_ver,shuilv, gxtime,memo,com);
                         cmd.CommandText = sql;
                         if (cmd.ExecuteNonQuery() > 0)
                             successly++;

                     }
                     catch (Exception ex)
                     {
                         _Result = _Result + ex.InnerException + "\\n\\r";
                     }
                 }

                 Response.Write("<script>alert('Excle表导入成功!共导入" + successly + "条数据。');window.location.href ='plucode.aspx';</script>");
               
               
             }
             myConn.Close();
        }


        protected void Button0_Click(object sender, EventArgs e)
        {
            string com = Session["COM"].ToString();
            string pluname = this.pluname0.Text.Trim();
            string sql = "select * from ord_shuishou_code where type like '%" + pluname + "%' and com = '" + com + "'";
            bind(sql);
        }
}
  
    
  