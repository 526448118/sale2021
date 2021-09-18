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
using System.Data.OracleClient;
using System.Security.Cryptography;
using System.Text;




/// <summary>
/// CommonClass 的摘要说明
/// </summary>
public class CommonClass : System.Web.UI.Page
{
	public CommonClass()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    /// <summary>
    /// 连接数据库
    /// </summary>
    /// <returns>返回SqlConnection对象</returns>
    /// 
   

    public SqlConnection Getconsql02()
    {
        string myStr = ConfigurationManager.ConnectionStrings["constrsql"].ToString();
        SqlConnection myConn = new SqlConnection(myStr);
        return myConn;
    }
    public OracleConnection Getconora()
    {
        string myStr = ConfigurationManager.ConnectionStrings["constrora"].ToString();
        OracleConnection myConn = new OracleConnection(myStr);
        return myConn;
    }
    public SqlDataReader ExceRead(string SqlCom)
    {
        SqlConnection con = this.Getconsql02();
        con.Open();
        //创建一个SqlCommand对象，表示要执行的SqlCom语句或存储过程
        SqlCommand sqlcom = new SqlCommand(SqlCom, con);
        SqlDataReader read = sqlcom.ExecuteReader();
               return read;
          
    }
    public bool execSQL(string sql)
    {
        SqlConnection con = Getconsql02();
        con.Open();
        SqlCommand com = new SqlCommand(sql, con);
        try
        {
            com.ExecuteNonQuery();
            con.Close();
            con.Dispose();
        }
        catch (Exception e)
        {
            Response.Write("提交失败,失败原因:" + e.Message);
            con.Close();
            con.Dispose();
          //  return false;
        }
        return true;
    }
    public bool execSQL01(string sql)
    {
        SqlConnection con = Getconsql02();
        con.Open();
        SqlCommand com = new SqlCommand(sql, con);
        try
        {
            com.ExecuteNonQuery();
           // Response.Write("提交成功！");
            con.Close();
            con.Dispose();
        }
        catch (Exception e)
        {
            Response.Write("提交失败,失败原因:" + e.Message);
            con.Close();
            con.Dispose();
            //  return false;
        }
        return true;
    }
    /// <summary>
    /// 说明：MessageBox用来在客户端弹出对话框。
    /// 参数：TxtMessage 对话框中显示的内容。
    /// 参数：Url 对话框关闭后，跳转的页
    /// </summary>
    public string MessageBox(string TxtMessage,string Url)
    {
        string str;
        str = "<script language=javascript>alert('" + TxtMessage + "');location='" + Url + "'</script>";
        return str;
    }
    /// <summary>
    /// 说明：MessageBox用来在客户端弹出对话框。
    /// 参数：TxtMessage 对话框中显示的内容。
    /// </summary>
    public string MessageBox(string TxtMessage)
    {
        string str;
        str = "<script language=javascript>alert('" + TxtMessage + "')</script>";
        return str;
    }
    /// <summary>
    /// 实现自动编号
    /// </summary>
    /// <param name="FieldName">自动编号的字段名</param>
    /// <param name="TableName">表名</param>
    /// <returns>返回编号</returns>
    public Decimal GetAutoID(string FieldName, string TableName)
    {
        SqlConnection myConn = Getconsql02();
        SqlCommand myCmd = new SqlCommand("select Max(" + FieldName + ") as MaxID from " + TableName, myConn);
        SqlDataAdapter dapt = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        dapt.Fill(ds);
        if (ds.Tables[0].Rows[0][0].ToString() == "")
        {
            return 1;
        }
        else
        {
            Decimal IntFieldID = Convert.ToDecimal(ds.Tables[0].Rows[0][0].ToString()) + 1;
            return (Convert.ToDecimal(ds.Tables[0].Rows[0][0].ToString()) + 1);
           // int IntFieldID = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) + 1;
            //return (Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) + 1);
        }
    }
    public int Getdown_num(string FieldName, string TableName,int fid)
    {
        SqlConnection myConn = Getconsql02();
        string sql = "select '"+ FieldName +"' from '"+ TableName +"' where fileID='+ fid +'";
        SqlCommand myCmd = new SqlCommand("select " + FieldName + "  from " + TableName +" where fileID="+fid, myConn);
        SqlDataAdapter dapt = new SqlDataAdapter(myCmd);
        DataSet ds = new DataSet();
        dapt.Fill(ds);
        if (ds.Tables[0].Rows[0][0].ToString() == "")
        {
            return 1;
        }
        else
        {
            int down_num = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) + 1;
            return (Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) + 1);
        }
    }
    public void auth_check(string mod)
    {       
        if (mod == "3")
        {
            System.Web.HttpContext.Current.Response.Write("<script lanuage=javascript>alert('没有权限！');location='javascript:history.go(-1)'</script>");
        }

    }
    public void auth_write_check(string mod)
    {
        if (mod == "1")
        {
            System.Web.HttpContext.Current.Response.Write("<script lanuage=javascript>alert('你只有查看权限！');location='javascript:history.go(-1)'</script>");
        }
    }



 

    public string ExecScalar(string SqlCom)
    {
        OracleConnection con = Getconora();
        con.Open();
        //创建一个SqlCommand对象，表示要执行的SqlCom语句或存储过程
        OracleCommand sqlcom = new OracleCommand(SqlCom, con);
        string content = Convert.ToString(sqlcom.ExecuteScalar());
        return content;
    }


    public string ExecScalar1(string SqlCom)
    {
        SqlConnection con = Getconsql02();
        con.Open();
        //创建一个SqlCommand对象，表示要执行的SqlCom语句或存储过程
        SqlCommand sqlcom = new SqlCommand(SqlCom, con);
        string content = Convert.ToString(sqlcom.ExecuteScalar());
        con.Close();        //
        con.Dispose();      //
        return content;
    }
    public string getMD5(string source)
    {
        string result = "";
        try
        {
            MD5 getmd5 = new MD5CryptoServiceProvider();
            byte[] targetStr = getmd5.ComputeHash(UnicodeEncoding.UTF8.GetBytes(source));
            result = BitConverter.ToString(targetStr).Replace("-", "");
            return result;
        }
        catch (Exception)
        {
            return "0";
        }

    }
    public static string StringTruncat(string oldStr, int maxLength, string endWith)
    {
        if (string.IsNullOrEmpty(oldStr))
            //   throw   new   NullReferenceException( "原字符串不能为空 "); 
            return oldStr + endWith;
        if (maxLength < 1)
            throw new Exception("返回的字符串长度必须大于[0] ");
        if (oldStr.Length > maxLength)
        {
            string strTmp = oldStr.Substring(0, maxLength);
            if (string.IsNullOrEmpty(endWith))
                return strTmp;
            else
                return strTmp + endWith;
        }
        return oldStr;
    }
    public  string Geteek(DateTime dd)
    {
        string[] weekdays = { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
       // string week = weekdays[Convert.ToInt32(DateTime.Now.DayOfWeek)];
        string week = weekdays[Convert.ToInt32(dd.DayOfWeek)];
        return week;
    }
    public OracleDataReader ora_read(string SqlCom)
    {
        OracleConnection con = this.Getconora();
        con.Open();
        //创建一个SqlCommand对象，表示要执行的SqlCom语句或存储过程
        OracleCommand sqlcom = new OracleCommand(SqlCom, con);
        OracleDataReader read = sqlcom.ExecuteReader();
        return read;
    }
}
