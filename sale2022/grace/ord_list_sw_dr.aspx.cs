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
using System.Data.OleDb;

public partial class depotmanager_order_list : System.Web.UI.Page
{
    CommonClass cc = new CommonClass();
  
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["RememberName"] == null)
        {
            Response.Write("<script>alert('会话超时，请重新登录！');top.location.href ='http://192.168.11.249:1006/index.aspx';</script>");
        }
        if (!IsPostBack)
        {
          
        }
        
    }
    public static String handleKey(String key)
    {
        //将中文括号替换为英文括号
        String str = "";
        if (null != key && key.Length != 0)
        {
           str = (key.Replace("）",")")).Replace("（","(");
        }
        return str;
    }


    protected void Bindsskc(string sqlStr)
    {

        SqlConnection myConn = cc.Getconsql02();
        myConn.Open();
        SqlDataAdapter myDa = new SqlDataAdapter(sqlStr, myConn);
        DataSet myDs = new DataSet();
        myDa.Fill(myDs);
        GridView1.DataKeyNames = new string[] { "num" };          
        GridView1.DataSource = myDs;
        GridView1.DataBind();
        myDa.Dispose();
        myDs.Dispose();
        myConn.Close();

    }

      protected void Bindsskc2(string sqlStr)
      {

          SqlConnection myConn = cc.Getconsql02();
          myConn.Open();
          SqlDataAdapter myDa = new SqlDataAdapter(sqlStr, myConn);
          DataSet myDs = new DataSet();
          myDa.Fill(myDs);
          GridView2.DataSource = myDs;
          GridView2.DataBind();
          myDa.Dispose();
          myDs.Dispose();
          myConn.Close();

      }





    //查询
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        string bgndate = this.bgndate.Text.Trim();
        string enddate = this.enddate.Text.Trim();
       // string com = Session["COM"].ToString();   
        string jobno = Session["RememberName"].ToString();
       // string role = Session["RoleID"].ToString();
       // string sh = Session["sh_memo"].ToString();
        string sql="";
        if (bgndate == "" && enddate == "")
        {
            sql = "select * from orgswpluinfo where CONVERT(varchar(50),gxtime,23)  = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and lrstaff = '" + jobno + "'";
        }
        else
        {
            sql = "select * from orgswpluinfo where CONVERT(varchar(50),gxtime,23) between   '" + bgndate + "' and '" + enddate + "' and lrstaff = '" + jobno + "'";
        }
        this.GridView2.Visible = false;
        this.GridView1.Visible = true;
        Bindsskc(sql);
       
    }

  

   



 
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowIndex > -1)
        {
            e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1);
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string  aa =  e.Row.Cells[1].Text.Trim();
            aa = aa.Replace("&#39;", "");
            
            e.Row.Attributes.Add("onMouseOver", "Col=this.style.backgroundColor;this.style.backgroundColor='#95B8FF'");
            e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor=Col;");
            e.Row.Attributes.CssStyle.Add("cursor", "hand");
            e.Row.Attributes.Add("onclick", "window.open('ord_info.aspx?id=" + aa + "')");
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
            string strSql = "select * from [下单模版$]";
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

    //判断字符串是否为纯数字
    public static bool IsNumber(string str)
    {
        if (str == null || str.Length == 0)    //验证这个参数是否为空
            return false;                           //是，就返回False
        ASCIIEncoding ascii = new ASCIIEncoding();//new ASCIIEncoding 的实例
        byte[] bytestr = ascii.GetBytes(str);         //把string类型的参数保存到数组里

        foreach (byte c in bytestr)                   //遍历这个数组里的内容
        {
            if (c < 48 || c > 57)                          //判断是否为数字
            {
                return false;                              //不是，就返回False
            }
        }
        return true;                                        //是，就返回True
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        string jobno = Session["RememberName"].ToString();
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
        string m = "";
        if (rowsnum == 0)
        {
            Response.Write("<script>alert('Excel表为空表,无数据!')</script>");   //当Excel表为空时,对用户进行提示
        }
        else
        {
            
            for (int i =1; i < dr.Length; i++)
            {
                //前面除了你需要在建立一个“upfiles”的文件夹外，其他的都不用管了，你只需要通过下面的方式获取Excel的值，然后再将这些值用你的方式去插入到数据库里面
                string xddate = DateTime.Now.ToString();
                string ywy = dr[i]["业务代表"].ToString();
                string gy = dr[i]["雇员编码"].ToString();
                string psdate = dr[i]["配送日期"].ToString();
                string pstime = dr[i]["送货时间"].ToString();
                string pluname = dr[i]["商品描述"].ToString();
                string plucode = dr[i]["商品编码"].ToString();
                string count = dr[i]["数量"].ToString();
                string price = dr[i]["单价"].ToString();
                string zk1 = dr[i]["折扣"].ToString();
                string zqtotal = dr[i]["折前金额"].ToString();
                string zhtotal = dr[i]["折后金额"].ToString();
                string costom = dr[i]["订单打印上客户名称"].ToString();
                string gyschl = dr[i]["供应学校"].ToString();
                string address = dr[i]["送货地址"].ToString();
                string lxr = dr[i]["联系人"].ToString();
                string lxrtel = dr[i]["联系电话"].ToString();
                string memo = dr[i]["备注"].ToString();
                string thtype = dr[i]["提货方式"].ToString();

                string sql_is_zy = "select is_zy from PS_DB.dbo.hl_dudao where orgname = '" + ywy + "'";
                string is_zy = cc.ExecScalar1(sql_is_zy);

                string gxdate = DateTime.Now.ToString("yyyyMMdd");
                string gxtime = DateTime.Now.ToString("HH:mm:ss");

                string saleno = "";
                if (psdate == "")
                {
                    continue;
                }


                if (string.IsNullOrEmpty(ywy))  //判断空值
                {
                    m = m + "<br/>" + ywy + psdate + pluname + count + gyschl + "有业务代表为空";
                    continue;
                }
                if (string.IsNullOrEmpty(psdate) || string.IsNullOrEmpty(pstime))  //判断空值
                {
                    m = m + "<br/>" + ywy + psdate + pluname + count + gyschl + "有配送时间为空";
                    continue;
                }
                if (string.IsNullOrEmpty(pluname) || string.IsNullOrEmpty(plucode))//判断空值
                {
                    m = m + "<br/>" + ywy + psdate + pluname + count + gyschl + "有商品信息为空";
                    continue;
                }
                if (string.IsNullOrEmpty(price) || string.IsNullOrEmpty(zk1) || string.IsNullOrEmpty(zqtotal) || string.IsNullOrEmpty(zhtotal))  //判断空值
                {
                    m = m + "<br/>" + ywy + psdate + pluname + count + gyschl + "有价格信息为空";
                    continue;
                }
                if (string.IsNullOrEmpty(costom) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(lxrtel))  //判断空值
                {
                    m = m + "<br/>" + ywy + psdate + pluname + count + gyschl + "有客户信息为空";
                    continue;
                }

                if (IsNumber(count) == false)
                {
                    m = m + "<br/>" + ywy + psdate + pluname + count + gyschl + "有商品数量错误";
                    continue;
                }
                if (Convert.ToInt32(count) <= 0)
                {
                    m = m + "<br/>" + ywy + psdate + pluname + count + gyschl + "有商品数量小于1";
                    continue;
                }
                


                //校验雇员信息
                string sqlgy = "select orgname from  PS_DB.dbo.ord_guyuan_info where orgcode= '" + gy + "'";
                if (handleKey(cc.ExecScalar1(sqlgy)) != handleKey(ywy))
                {
                    m = m + "<br/>" + ywy + psdate + pluname + count + gyschl + "雇员信息未匹配";
                    continue;
                }
                //校验商品信息
                string sqlplu = "select pluname from lj_grace_plu_saleord03 where name = '普通商品' and  plucode = '" + plucode + "'";
                if (handleKey(cc.ExecScalar(sqlplu)) != handleKey(pluname))
                {
                    m = m + "<br/>" + ywy + psdate + pluname + count + gyschl + "商品信息未匹配";
                    continue;
                }
                
                //比对配送日期和下单日期大小      
                if (Convert.ToInt32(psdate) < Convert.ToInt32(gxdate))
                {
                    m = m + "<br/>" + ywy + psdate + pluname + count + gyschl + "配送日期错误";
                    continue;
                }
                //存储上传数据
                //Response.Write(Convert.ToInt32(psdate));
                if (psdate != "")
                {
                    try
                    {
                        Double zk = Convert.ToDouble(zk1) * 100;

                        string sqlno = "select max(num) from PS_DB.dbo.ord_info";
                        string sqlno2 = "select max(num) from PS_DB.dbo.ord_t_dr";
                        Int64 num = Convert.ToInt64(cc.ExecScalar1(sqlno));
                        Int64 num2 = 0;
                        // Response.Write(cc.ExecScalar1(sqlno2));//存在bug风险
                        if (cc.ExecScalar1(sqlno2) != "")
                        {
                            num2 = Convert.ToInt64(cc.ExecScalar1(sqlno2));
                        }

                        if (num > num2)
                        {
                            saleno = Convert.ToString(num + 100);
                        }
                        else if (num < num2)
                        {
                            saleno = Convert.ToString(num2 + 1);
                        } 
                        

                        string sqlin = "insert into PS_DB.dbo.[ord_t_dr](num,xddate,ywy,gycode,is_zy,lrstaff,psdate,pstime,pluname,plucode,count,price,zk,zqtotal,zhtotal,thtype,costom,gyschl,address,lxr,lxrtel,memo,status,drdate) values ('" + saleno + "','" + xddate + "','" + ywy + "','" + gy + "','" + is_zy + "','" + jobno + "','" + psdate + "','" + pstime + "','" + pluname + "','" + plucode + "','" + count + "','" + price + "','" + zk + "','" + zqtotal + "','" + zhtotal + "','" + thtype + "','" + costom + "','" + gyschl + "','" + address + "','" + lxr + "','" + lxrtel + "','" + memo + "','0','" + gxdate + "')"; 
                        cc.execSQL01(sqlin);
                        //var uuid = Guid.NewGuid().ToString();
                        Response.Write(saleno);
                        successly++;
                    }
                    catch (Exception ex)
                    {
                        Response.Write("提交失败,失败原因:" + ex.Message);
                    }
                }
            }
        }
        string sql_m = "select * from  PS_DB.dbo.[ord_t_dr] where status = '0' and lrstaff = '" + jobno + "'";
        this.GridView2.Visible = true;
        this.GridView1.Visible = false;
        Bindsskc2(sql_m);
       

        if (successly == rowsnum)
        {
            Response.Write("<script>alert('Excle表导入成功!共导入" + successly + "条数据！');window.location.href ='mdjk_sh.aspx';</script>");
        }
        else
        {
            Response.Write("<script>alert('共导入" + successly + "条数据！');</script>");
            this.Label1.Text = "导入失败数据:<br/>" + m;
        }
        myConn.Close();

    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        string jobno = Session["RememberName"].ToString();
        string sql = "update PS_DB.dbo.[ord_t_dr]  set status = '3' where status = '0' and lrstaff = '" + jobno + "' ";

        string sql_c = "select count(*) from PS_DB.dbo.[ord_t_dr]  where status = '0' and lrstaff = '" + jobno + "'";
        string cou = cc.ExecScalar1(sql_c);
        if (cou == "0")
        {
            Response.Write("<script>alert('没有可删除数据！');</script>");
            return;
        }
        try 
        {
            string fh = cc.execSQL01(sql).ToString();
            if (fh == "True")
            {
                Response.Write("<script>alert('" + cou + "条数据删除成功！');</script>");
            }
            else
            {
                Response.Write("删除失败！");
            }
        }

        catch (Exception ex)
        {
            Response.Write("删除失败,失败原因:" + ex.Message );

        }
        finally
        {
        }
        string sql_m = "select * from  PS_DB.dbo.[ord_t_dr] where status = '0' and lrstaff = '" + jobno + "'";
        this.GridView2.Visible = true;
        this.GridView1.Visible = false;
        this.Label1.Text = "";
        Bindsskc2(sql_m);
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        string jobno = Session["RememberName"].ToString();
        //插入主表--注意去重
        string sqlll = "insert into  PS_DB.dbo.[ord_info](num,gxtime,bill_status,dept,cen,jm,saler,lrdate,thdate,ord_from,thtype,plutype,custname,cust_address,th_address,cust_body,cust_body_tel," +
        "memo,com,lrstaff,ordtype,isdc)" +
        "select  num,'" + DateTime.Now.ToString() + "','0',ywy,'营销中心',is_zy,ywy,convert(varchar(50),getdate(),23),convert(varchar(50),cast(psdate as date),23) +' '+stuff(stuff(pstime,3,0,':'),6,0,':')," +
        "'门市',thtype,'普通商品',costom,address,address,lxr,lxrtel,memo,'成都',lrstaff,'日常订单','0' from PS_DB.dbo.[ord_t_dr] where  num <> '' and status = '0' and lrstaff = '" + jobno + "'";
        //处理标记
        string sqlll_b = "update PS_DB.dbo.[ord_t_dr] set status = '1' where status = '0' and lrstaff = '" + jobno + "'";

        //插入明细表
        string sqlinsmx = "insert into PS_DB.dbo.ord_plu(saleno,plucode,pluname,price,count,ystotal,zk,sstotal,jobno) select num,plucode,pluname,price,count,zqtotal,zk,zhtotal,'" + jobno + "' FROM PS_DB.dbo.[ord_t_dr] where status = '1' and lrstaff = '" + jobno + "'";
        //处理标记
        string sqlinsmx_b = "update PS_DB.dbo.[ord_t_dr] set status = '2' where status = '1' and lrstaff = '" + jobno + "' "; ;


        string sql_c = "select count(*) from PS_DB.dbo.[ord_t_dr]  where status = '0' and lrstaff = '" + jobno + "'";
        string cou = cc.ExecScalar1(sql_c);
        if (cou == "0")
        {
            Response.Write("<script>alert('没有可处理数据！');</script>");
            return;
        }

        try
        {
            string s1 = cc.execSQL01(sqlll).ToString();
            string s2 = cc.execSQL01(sqlll_b).ToString();
            string s3 = cc.execSQL01(sqlinsmx).ToString();
            string s4 = cc.execSQL01(sqlinsmx_b).ToString();
            if (s1 == "True" && s2 == "True" && s3 == "True" && s4 == "True")
            {
                 Response.Write("<script>alert('" + cou + "条数据处理成功！');</script>");
            }
            else
            {
                Response.Write("操作失败！");

            }
        }

        catch (Exception ex)
        {
            Response.Write("操作失败,失败原因:" + ex.Message);

        }
        finally
        {
        }
        this.GridView2.Visible = false;
        this.GridView1.Visible = true;

        string sql = "select * from orgswpluinfo where CONVERT(varchar(50),gxtime,23) = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and lrstaff = '" + jobno + "'";
        Bindsskc(sql);
        this.Label1.Text = "";
    }




}

