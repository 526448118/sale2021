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

public partial class ord_info : System.Web.UI.Page
{
    CommonClass cc = new CommonClass();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        string billno = Request["id"];
        string roleid = Session["RoleID"].ToString();
        string sh_memo = Session["sh_memo"].ToString();
        string jobno = Session["RememberName"].ToString();
        string cx = Request["cx"];
        string com = Session["COM"].ToString();

        getstatusinfo();
        string sqlzg01 = "select next_person from ord_info where num='" + billno + "' and next_person_sh is not null";
        string zg01 = cc.ExecScalar1(sqlzg01).ToString();
        if (zg01 == jobno )
        {
           this.mo_zgsh.Visible = false; //主管审核
        }
        string sqlzg = "select count(1) from ord_info where num='" + billno + "' and next_person_sh is not null and next_person_sh_time is not null";
        string ind1 = cc.ExecScalar1(sqlzg).ToString();
         if (ind1 == "1")
        {
            this.mo_zgsh.Visible = false; //主管审核
        }
        string sqlsh = "select count(1) from ord_info where num='" + billno + "' and next_person_sh is  null and next_person_sh_time is  null ";
        string indsh = cc.ExecScalar1(sqlsh).ToString();
         if (indsh == "1")
         {
         }
        string sqlsh01 = "select sh_memo from ps_manager where user_name='" + jobno + "'";
        string indsh01 = cc.ExecScalar1(sqlsh01).ToString();
        //---------------------------
        string sqlid02 = " select bill_status from ord_info where num='" + billno + "'";
        string ind3 = cc.ExecScalar1(sqlid02).ToString();
        if (ind3 == "4" )  //
        {

           this.btnSubmit2.Visible = false;
           this.mo_sh.Visible  = this.mo_zgsh.Visible = this.mo_zf.Visible = false;
        }
        //由3变更为2，当营销审后，也能点下单完成
        if (ind3 == "3" && roleid != "1" && roleid != "2" && roleid != "3" && roleid != "4")  //
        {
            this.btnSubmit2.Visible = true;
        }
            
        else
        {
            this.btnSubmit2.Visible = false;
        }
         if (ind3 == "3")
        {
            this.mo_sh.Visible = false;
        }
         if (ind3 == "3" && indsh01 != "4" && indsh01 != "1")   //总经办审核后下单员可作废
         {
             this.mo_zf.Visible = false;
         }
         if (ind3 == "99" || ind3 == "3" || ind3 == "4")
         {
             this.mo_zf.Visible = false;
             this.mo_sh.Visible = false;
         }
       
         if (ind3==indsh01)  //
        {           
        }
        if (roleid == "2")
        {
            this.mo_sh.Visible = false;
        }
        if ((ind3 == "3" || ind3 == "4") && roleid != "1" && roleid != "2" && roleid != "3" && roleid != "4")
        {
            this.mo_zf.Visible= true;
        }
          string sql = "select * from ordhead where 单据号='"+billno+"'";
          string sqlbind = "select * from ord_bill_status where saleno='" + billno + "'";
            SqlDataReader rd = cc.ExceRead(sql);
            if (rd.Read())
            {
                this.billno.Text = billno;
                this.thdate.Text = rd["提货日期"].ToString();
                this.lrdate.Text = rd["下单日期"].ToString();
                this.cen.Text = rd["中心"].ToString();
                this.dept.Text = rd["部门"].ToString();
                this.ywy.Text = rd["业务员"].ToString();
                this.custname.Text = rd["客户名称"].ToString();
                this.custaddr.Text = rd["客户地址"].ToString();
                this.thaddr.Text = rd["提货地址"].ToString();
                this.custaddr.Text = rd["客户地址"].ToString();
                this.custbody.Text = rd["客户联系人"].ToString();
                this.custtel.Text = rd["客户电话"].ToString();
                this.fktype.Text = rd["付款方式"].ToString();
                this.kp0.Text = "开票否："+rd["开票"].ToString();
                this.kp.Text = rd["开票"].ToString();
                this.memo.Text = rd["备注"].ToString();
                this.ystotal.Text = rd["应收金额"].ToString();
                this.sstotal.Text = rd["实收金额"].ToString();
                this.ss.Text = rd["实收"].ToString();
                this.com.Text = rd["公司"].ToString()+"安德鲁森";
                this.thtype.Text = rd["提货方式"].ToString();
                this.plutype.Text = rd["商品类型"].ToString();
                this.ord_from.Text = rd["订单来源"].ToString();
                this.zg.Text= rd["主管"].ToString();
                this.jm.Text = rd["经营性质"].ToString();
                this.Literal1.Text = "<Strong>安德鲁森<br/>业务订单<Strong/>";
                this.jmmm.Text = "<Strong>[" + rd["经营性质"].ToString() + "]<Strong/>";
                this.billno_num.Text = rd["系统单号"].ToString();
                this.sm.Text = rd["税码"].ToString();
                this.htcustom.Text = rd["是否合同客户"].ToString();
                this.Label4.Text = rd["导出状态"].ToString();
                string zfreason = rd["作废原因"].ToString();
                string bill_status = rd["单据状态"].ToString();
                string plutype = rd["商品类型"].ToString();
                Label2.Text = rd["是否已回款"].ToString();
                is_yccz.Text = rd["是否远程充值"].ToString();
                ksid.Text = rd["开始卡号"].ToString();
                jsid.Text = rd["结束卡号"].ToString();
                dhmemo.Text = rd["断号备注"].ToString();
                if (plutype == "普通商品")
                {
                    this.Label2.Visible = this.Label3.Visible = true;
                }
                
                if (!string.IsNullOrEmpty(zfreason))
                {
                    this.zfmemo.Text = "-->作废原因:" + rd["作废原因"].ToString();
                }

             
                rd.Close();
                rd.Dispose();
            }
        BindDataToRepeater();
    }

    private void BindDataToRepeater()
    {
        string billno = Request["id"];
      //  string billno = "20170810022";
        SqlConnection myConn = cc.Getconsql02();
        myConn.Open();
        string sql;
        if (this.plutype.Text.Trim() == "提领券")
        {
            sql = "select 单据号,序号,商品编码+'**" + this.plutype.Text.Trim() + "' 商品编码,商品名称,价格,数量,单位,应收,折扣,实收 from ordbody  where 单据号='" + billno + "'";
        }
        else
        {
            sql = "select * from ordbody where 单据号='" + billno + "'";
        }
        SqlCommand cmd = new SqlCommand(sql, myConn);

        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = cmd;
        DataSet ds = new DataSet();
        sda.Fill(ds, "ordbody");
        rptList.DataSource = ds.Tables["ordbody"];
        rptList.DataBind();
        myConn.Close();
        myConn.Dispose();
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string user = Session["RealName"].ToString();
        string sh_memo = Session["sh_memo"].ToString();
        string gxtime = DateTime.Now.ToString();
        string com = Session["COM"].ToString();
        string jobno = Session["RememberName"].ToString();
          string billno = Request["id"];
       // string billno = "20170811026";
        //---------
        string sqlsh = "select count(1) from ord_info where num='" + billno + "' and next_person_sh is  null and next_person_sh_time is  null ";
        string indsh = cc.ExecScalar1(sqlsh).ToString();
        if (indsh == "1")
        {
            Response.Write("<script>alert('业务员主管审核后你才能审核！');</script>");
            return;
        }
        //---------------
       string sqlid=" select bill_status+1 from ord_info where num='"+billno+"'";
       string sqlid02 = " select bill_status from ord_info where num='" + billno + "'";
       string sqlid01="select sh_memo from ps_manager where user_name='"+jobno+"'";
       string ind1 = cc.ExecScalar1(sqlid).ToString();
       string ind2 = cc.ExecScalar1(sqlid01).ToString();
       string ind3 = cc.ExecScalar1(sqlid02).ToString();
       // Response.Write(ind3 + "_" + ind2);
       if (ind3 == ind2)  //
       {

           Response.Write("<script>alert('此节点已审核，你无须再审！');</script>");
           return;
       }

       if (ind1 != ind2)  //
       {
          
           Response.Write("<script>alert('前序节点还未审核，你不能审核！');</script>");
           return;
       }
      //--------------添加审核备注----------2018-10-25
       string sqlm = "select memo from ord_info where num='" + billno + "'";
       string memo_old = cc.ExecScalar1(sqlm).ToString();
       string memo;
       if (!string.IsNullOrEmpty(this.memo_info.Text.Trim()))
       {
            memo = memo_old + "|审核备注：" + this.memo_info.Text.Trim();
       }
       else
       {
            memo = memo_old;
       }
      //----------------------------------------------
        string sqlstatus = "insert into ord_bill_status(saleno,status,lrdate,lrstaff,memo,statusno) "
            + " values('" + billno + "','"+sh_memo+"','" + gxtime + "','" + jobno + "','" + memo + "','"+sh_memo+"')";
        string sqlinfo = "update ord_info set bill_status='" + sh_memo + "',memo = '" + memo + "' where num='" + billno + "' ";
        try
        {
            string fh = cc.execSQL01(sqlstatus).ToString();
            cc.execSQL01(sqlinfo);
            //  Response.Write(fh);
            if (fh == "True")
            {
                //Response.Write("审核成功！");
                Response.Write("<script>alert('审核成功！');window.location.href ='ord_list.aspx';</script>");
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
    protected void btnSubmit1_Click(object sender, EventArgs e)
    {
        string gxtime = DateTime.Now.ToString();
        string com = Session["COM"].ToString();
        string jobno = Session["RememberName"].ToString();
        string billno = Request["id"];
        //--------------添加审核备注----------2018-10-25
        string sqlm = "select memo from ord_info where num='" + billno + "'";
        string memo_old = cc.ExecScalar1(sqlm).ToString();
        string memo;
        if (!string.IsNullOrEmpty(this.memo_info.Text.Trim()))
        {
            memo = memo_old + "|审核备注：" + this.memo_info.Text.Trim();
        }
        else
        {
            memo = memo_old;
        }

        //----------------------------------------------
        string sql = "select * from ord_info where next_person='"+jobno+"' and next_person_sh is null";
         SqlDataReader rd = cc.ExceRead(sql);
         if (rd.Read())
         {
             string ordfrom = "select ord_from  from ord_info where num='" + billno + "'";
             string zgtype = cc.ExecScalar1(ordfrom).ToString();

             if (zgtype == "行政")
             {
                 sql = "update ord_info set next_person_sh='" + jobno + "',memo = '" + memo + "', next_person_sh_time='" + gxtime + "',bill_status='1' where "
                     + "  num='" + billno + "' and next_person='" + jobno + "'";
             }
             else
             {
                 sql = "update ord_info set next_person_sh='" + jobno + "',memo = '" + memo + "',next_person_sh_time='" + gxtime + "' where "
                     + "  num='" + billno + "' and next_person='" + jobno + "'";
             }

              //Response.Write(sql);
             try
             {
                 string fh = cc.execSQL01(sql).ToString();

                 if (fh == "True")
                 {
                     //Response.Write("审核成功！");
                     Response.Write("<script>alert('主管审核通过，订单进入营销审核环节！');</script>");
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
         else
         {
             Response.Write("<script>alert('你没有权限审核！');</script>");
         }
         rd.Close();
         rd.Dispose();
    }
    protected void bind(string sqlStr)
    {
        SqlConnection myConn = cc.Getconsql02();
        myConn.Open();
        //string sqlStr = " select orgname,orgcode,preorgcode from hscmp.tOrgManage where preorgcode='1102' ";
        SqlDataAdapter myDa = new SqlDataAdapter(sqlStr, myConn);
        DataSet myDs = new DataSet();
        myDa.Fill(myDs);
        GridView1.DataSource = myDs;
        //GridView1.DataKeyNames = new string[] { "ID" };
        GridView1.DataBind();
        myDa.Dispose();
        myDs.Dispose();
        myConn.Close();
        myConn.Dispose();
    }

    protected void btnSubmit0_Click(object sender, EventArgs e)
    {
        string cx = Request["cx"];
        string user = Session["RealName"].ToString();
        string sh_memo = Session["sh_memo"].ToString();
        string gxtime = DateTime.Now.ToString();
        string com = Session["COM"].ToString();
        string jobno = Session["RememberName"].ToString();
        string billno = Request["id"];
        string role = Session["RoleID"].ToString();
        string memo = "";
        string sqlid = " select isdc from ord_info where num='" + billno + "'";
        string sqlid02 = " select plutype from ord_info where num='" + billno + "'";
        string status = " select bill_status from ord_info where num='" + billno + "'";
        string ind1 = cc.ExecScalar1(sqlid).ToString();
        string ind2 = cc.ExecScalar1(sqlid02).ToString();
        string ind3 = cc.ExecScalar1(status).ToString();
        string sqlstatus = "insert into ord_bill_status(saleno,status,lrdate,lrstaff,memo,statusno) values('" + billno + "','99','" + gxtime + "','" + jobno + "','" + memo + "','99')";
        //Response.Write(ind1+role);

        if (ind3 != "99" && (role == "4"||role == "10"))//门市作废
        {
            string zfreason = this.memo_info.Text.Trim();
            string sqlinfo = "update ord_info set bill_status='99',zfreason='" + zfreason + "' where num='" + billno + "' ";
            try
            {
                if (!string.IsNullOrEmpty(zfreason))
                {
                    string fh = cc.execSQL01(sqlstatus).ToString();
                    cc.execSQL01(sqlinfo);
                    if (fh == "True")
                    {
                        Response.Write("<script>alert('作废成功！');window.location.href ='ord_info.aspx?id=" + billno + "&cx=" + cx + "';</script>");
                    }
                    else
                    {
                        Response.Write("提交失败！");
                    }
                }
                else
                {
                    Response.Write("<script>alert('请填写：作废原因！');</script>");
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

        if ((ind1 == "00" || role != "10") && ind3 !="99")//未导出或非数据组权限 且 单据未作废
        {
            string zfreason = this.memo_info.Text.Trim();
            string sqlinfo = "update ord_info set bill_status='99',zfreason='" + zfreason + "' where num='" + billno + "' ";
            try
            {
                if (!string.IsNullOrEmpty(zfreason))
                {
                    string fh = cc.execSQL01(sqlstatus).ToString();
                    cc.execSQL01(sqlinfo);                    
                    if (fh == "True")
                    {
                        Response.Write("<script>alert('作废成功！');window.location.href ='ord_info.aspx?id=" + billno + "&cx=" + cx + "';</script>");
                    }
                    else
                    {
                        Response.Write("提交失败！");
                    }
                }
                else
                {
                    Response.Write("<script>alert('请填写：作废原因！');</script>");
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
        else if (ind3 == "9" && role != "10" && ind2 == "普通商品")//申请作废状态
        {
            Response.Write("<script>alert('该单据已申请作废，请联系门市助理或数据组！');</script>");
            return;
        }

        else if (ind1 == "1" && role != "10" && ind3 != "99"&& ind2 == "普通商品" && ind3 != "9") //数据组已导出&无数据组权限&单据未作废&单据未处于申请作废状态&商品类型为普通商品
        {
            if (!string.IsNullOrEmpty(memo_info.Text.Trim()))
            {
                string zfreason = "申请作废：" + this.memo_info.Text.Trim() + "*" + jobno + "*" + DateTime.Now.ToString("D");
                string sqlinfo = "update ord_info set bill_status='9',zfreason='" + zfreason + "' where num='" + billno + "' ";
                string zfsql = "insert into ord_info_zfsq(num,sq_people,zf_reason,sq_time) values('" + billno + "','" + jobno + "','" + this.memo_info.Text.Trim() + "','" + DateTime.Now.ToString() + "')";
                //Response.Write(zfsql);
                cc.execSQL01(zfsql);
                cc.execSQL01(sqlinfo);
                Response.Write("<script>alert('该单据申请作废成功，请联系门市助理或数据组！');window.location.href ='ord_info.aspx?id="+billno+"&cx="+cx+"';</script>");
            }
            else
            {
                Response.Write("<script>alert('请填写：申请作废原因！');</script>");
            }
        }

        else if(ind3 == "99")//已作废状态
        {
            Response.Write("<script>alert('该单据已作废！');</script>");
        }
       
    }
    protected void btnSubmit2_Click(object sender, EventArgs e)
    {
        string gxtime = DateTime.Now.ToString();
        string com = Session["COM"].ToString();
        string jobno = Session["RememberName"].ToString();
        string sh_memo = Session["sh_memo"].ToString();
        string billno = Request["id"];
        string memo = "已出单";
        string sqlid02 = " select bill_status from ord_info where num='" + billno + "'"; 
        string ind3 = cc.ExecScalar1(sqlid02).ToString();
        if (ind3 == "4")  //
        {

            Response.Write("<script>alert('已下单完成,无须再处理！');</script>");
            return;
        }

        string sqlstatus = "insert into ord_bill_status(saleno,status,lrdate,lrstaff,memo,statusno) "
          + " values('" + billno + "','4','" + gxtime + "','" + jobno + "','" + memo + "','4')";
        string sqlinfo = "update ord_info set bill_status='4' where num='" + billno + "' ";
        try
        {
            string fh = cc.execSQL01(sqlinfo).ToString();
            cc.execSQL01(sqlstatus);
            if (fh == "True")
            {
                Response.Write("<script>alert('下单完成，进入后续生产、送货环节;');</script>");
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
    public void getstatusinfo()
    {
        string billno = Request["id"];
        string sql0 = "select real_name from ordinfostatus where saleno='" + billno + "' and status='0'";
        string s0 = cc.ExecScalar1(sql0).ToString();
        // Response.Write(sql0);
        this.ywysh.Text = s0;

        string sql1 = "select real_name from ordinfostatus where saleno='" + billno + "' and status='1'";
       string s1 = cc.ExecScalar1(sql1).ToString();
        // Response.Write(sql0);
        this.zl.Text = s1;

        string sqlzg = "select b.real_name from ord_info a left join ps_manager b on a.next_person_sh=b.user_name where num='" + billno + "'";
        string szg = cc.ExecScalar1(sqlzg).ToString();
        //Response.Write(sql0);
        this.zgsh.Text = szg;

        string sql2 = "select real_name from ordinfostatus where saleno='" + billno + "' and status='2'";
        string s2 = cc.ExecScalar1(sql2).ToString();
        // Response.Write(sql0);
        this.yxsh.Text = s2;

        string sql3 = "select real_name from ordinfostatus where saleno='" + billno + "' and status='3'";
        string s3 = cc.ExecScalar1(sql3).ToString();
        // Response.Write(sql0);
        this.zbsh.Text = s3;

        string sql4 = "select real_name from ordinfostatus where saleno='" + billno + "' and status='4'";
        string s4 = cc.ExecScalar1(sql4).ToString();
        // Response.Write(sql0);
        this.xd.Text = s4;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string billno = Request["id"];
        string sqlinfo = "update ord_info set ord_print='已打印' where num='" + billno + "' ";
        if (string.IsNullOrEmpty(this.yxsh.Text.Trim()))
        {
            Response.Write("<script>alert('营销未审核，不能打印!')</script>");
        }
        else
        {
            try
            {
                string fh = cc.execSQL01(sqlinfo).ToString();
                if (fh == "True")
                {
                    Response.Write("<script>alert('提交成功;');window.location.href ='ord_list.aspx';</script>");
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
    }
    public void up_print()
    {
        string billno = Request["id"];
        string sqlinfo = "update ord_info set ord_print='已打印' where num='" + billno + "' ";
        try
        {
            string fh = cc.execSQL01(sqlinfo).ToString();

            if (fh == "True")
            {
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
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        string billno = this.TextBox1.Text.Trim();
        string num = Request["id"];
        string sqlinfo01 = "update ord_info set billno='"+billno+"' where num='" + num + "'";
        try
        {
            string fh = cc.execSQL01(sqlinfo01).ToString();

            if (fh == "True")
            {
                Response.Write("<script>alert('保存成功;');</script>");
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
  
    }
    protected void rptList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ITinfo_TextChanged(object sender, EventArgs e)
    {

    }
}