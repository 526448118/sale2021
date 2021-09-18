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
//2018-10-22 v1.0
public partial class grace_Default : System.Web.UI.Page
{
    CommonClass cc = new CommonClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string sql = "select * from ord_guyuan_info order by cast(orgcode as int)";
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
        GridView1.DataKeyNames = new string[] { "orgcode" };
        GridView1.DataBind();
        myConn.Close();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string orgname = this.orgname.Text.Trim();
        string orgcode = this.orgcode.Text.Trim();
        string bgdate = this.bgdate.Text.Trim();
        string memo = this.memo.Text.Trim();
        string endate = "9999-12-31";
        string gxtime = DateTime.Now.ToString();
        if (string.IsNullOrEmpty(this.orgcode.Text.Trim()) || string.IsNullOrEmpty(this.orgname.Text.Trim()) || string.IsNullOrEmpty(this.bgdate.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('添加数据不能为空！');</script>");
            return;
        }
        //-------------------判断有无重复编码----------------
        string sqlaa = "select count(*) from ord_guyuan_info where orgcode = '" + orgcode + "'";
        int a = Convert.ToInt32(cc.ExecScalar1(sqlaa));
        if (a > 0)
        {
            Response.Write("<script>alert('有数据与现有表中的数据重复！')</script>");
            return;
        }
        //---------------------------------------------------
        string sql = "insert into ord_guyuan_info(orgname,orgcode,bgdate,endate,memo,gxtime) values ('" + orgname + "','" + orgcode + "','" + bgdate + "','" + endate + "','" + memo + "','" + gxtime + "')";
        Response.Write(sql);
        try
        {
            string fh = cc.execSQL01(sql).ToString();
            if (fh == "True")
            {
                Response.Write("<script>alert('提交成功！');window.location.href ='gy_info.aspx';</script>");
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
        //string value= this.GridView1.Rows[0].Cells[1].Text;
        //Response.Write("<script>alert('" + value + "！');</script>");
        
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
            if (cbox.Checked == true)
            {
                string datetime = DateTime.Now.ToString();
                string keyname = GridView1.Rows[i].Cells[1].Text;
                string gxti = GridView1.Rows[i].Cells[5].Text;
                string ins = " Insert into ord_guyuan_info_his(orgname,orgcode,bgdate,endate,memo,gxtime,deletetime,id) select orgname,orgcode,bgdate,endate,memo,gxtime,'" + datetime + "',id from ord_guyuan_info  where orgcode  = '" + keyname + "' and gxtime = '" + gxti + "'";
                string sql = "delete from ord_guyuan_info where orgcode = '" + keyname + "'and gxtime = '" + gxti + "'";
                cc.execSQL01(ins);
                cc.execSQL01(sql);
            }
        }
        string sql1 = "select * from ord_guyuan_info";
        bind(sql1);
    }
    protected void btnDown_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;
        string ID = lbtn.CommandArgument;
        string sql = "select * from ord_guyuan_info where orgcode = '" + ID + "' ";
        SqlConnection myConn = cc.Getconsql02();
        SqlDataAdapter sda = new SqlDataAdapter(sql, myConn);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            this.orgcode.Text = dr["orgcode"].ToString();
            this.orgname.Text = dr["orgname"].ToString();
            this.bgdate.Text = dr["bgdate"].ToString();
            this.memo.Text = dr["memo"].ToString();

            this.orgcode.Enabled = false;
            this.Button1.Enabled = false;

            this.Button3.Enabled = true;
            this.Button4.Enabled = true;
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        this.orgcode.Text = string.Empty;
        this.orgname.Text = string.Empty;
        this.bgdate.Text = string.Empty;
        this.memo.Text = string.Empty;

        this.orgcode.Enabled = true;
        this.Button1.Enabled = true;

        this.Button3.Enabled = false;
        this.Button4.Enabled = false;

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string orgcode = this.orgcode.Text.Trim();
        string orgname = this.orgname.Text.Trim();
        string bgdate = this.bgdate.Text.Trim();
        string memo = this.memo.Text.Trim();
        string gxtime = DateTime.Now.ToString();
        if (string.IsNullOrEmpty(this.orgcode.Text.Trim()) || string.IsNullOrEmpty(this.orgname.Text.Trim()) || string.IsNullOrEmpty(this.bgdate.Text.Trim()))  //判断空值
        {
            Response.Write("<script>alert('更新数据不能为空！');</script>");
            return;
        }
        string sql = "update ord_guyuan_info set orgname = '" + orgname + "',bgdate = '" + bgdate + "',memo = '" + memo + "',gxtime = '" + gxtime + "' where orgcode = '" + orgcode + "'";
        //Response.Write(sql);
        try
        {
            string fh = cc.execSQL01(sql).ToString();
            if (fh == "True")
            {
                Response.Write("<script>alert('更新成功！');window.location.href ='gy_info.aspx';</script>");
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
        this.orgcode.Text = string.Empty;
        this.orgname.Text = string.Empty;
        this.bgdate.Text = string.Empty;
        this.memo.Text = string.Empty;

        this.orgcode.Enabled = true;
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
             int rcount = 0;
             string strvalue = null;
             List<string> orclist = new List<string>();
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
                     string orgname = dr[i]["雇员名"].ToString();
                     string orgcode = dr[i]["雇员编码"].ToString();
                     string bgdate = dr[i]["开始日期"].ToString();
                     string endate = "9999-12-31";
                     string memo = dr[i]["备注"].ToString();
                     string gxtime = DateTime.Now.ToString();

                     //--------统计重复数据-------
                     string sqlct = "select count(*) from ord_guyuan_info where orgcode = '" + orgcode + "'";
                     int a = Convert.ToInt32(cc.ExecScalar1(sqlct));
                     if (a > 0)
                     {
                         rcount++;
                         orclist.Add(orgcode);
                     }

                     //Response.Write(strvalue);
                         //---------------------------
                         try
                         {
                             var uuid = Guid.NewGuid().ToString();
                             //ExecScalar1
                             string sql = string.Format("insert into ord_guyuan_info(id,orgname,orgcode,bgdate,endate,memo,gxtime) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", uuid, orgname, orgcode, bgdate, endate, memo, gxtime);
                             cmd.CommandText = sql;
                             if (cmd.ExecuteNonQuery() > 0)
                                 successly++;

                         }
                         catch (Exception ex)
                         {
                             _Result = _Result + ex.InnerException + "\\n\\r";
                         }
                 }

 
                 for (int z = 0; z < orclist.Count; z++)//获取重复编码
                 {                     
                     strvalue += orclist[z].ToString() + ",";
                 }
                 if (successly == rowsnum)
                 {
                    
                     if (rcount == 0)
                     {
                         Response.Write("<script>alert('Excle表导入成功!');window.location.href ='gy_info.aspx';</script>");
                     }
                     else
                     {
                         Response.Write("<script>alert('Excle表导入成功!且有编码重复！重复编码为：" + strvalue + "');window.location.href ='gy_info.aspx';</script>");

                         //Response.Write(strvalue);
                     }
                 }
                 else
                 {
                     Response.Write("<script>alert('Excle表导入失败!');</script>");
                     return;
                 }
             }
             myConn.Close();
        }


        protected void Button0_Click(object sender, EventArgs e)
        {
            string orgname = this.orgname0.Text.Trim();
            
            string sql = "select * from ord_guyuan_info where (orgname like '%" + orgname + "%' or orgcode like '%" + orgname + "%') order by cast(orgcode as int)";
           // Response.Write(sql);
            bind(sql);
        }
}
  
    
  