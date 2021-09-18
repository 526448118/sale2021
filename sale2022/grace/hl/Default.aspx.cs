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

public partial class grace_hl_Default : System.Web.UI.Page
{
    CommonClass cc = new CommonClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)//首次进行该页时，页面初始化
        {
            RecordsCount= GetRecordsCount("default");//默认信息总数
            PagesCount= RecordsCount / PAGESIZE + OverPage();//默认的页总数
            ViewState["PagesCount"]= RecordsCount / PAGESIZE - ModPage();//保存末页索引，比页总数小1
            ViewState["PageIndex"]= 0;//保存页面初始索引从0开始
            ViewState["JumpPages"]= PagesCount;
            //显示lbPageCount、lbRecordCount的状态
            /*lbPageCount.Text= PagesCount.ToString();
            lbRecordCount.Text= RecordsCount.ToString();
            //判断跳页文本框失效
            if (RecordsCount<= 10)
            {
                GotoPage.Enabled= false;
            }
            GridViewDataBind("default");//调用数据绑定函数TDataBind()进行数据绑定运算*/
        }
    }

#region Members 
  const int PAGESIZE = 10;//每页显示信息数量
        int PagesCount,RecordsCount;//记录总页数和信息总条数
        int CurrentPage,Pages, JumpPage;//当前页，信息总页数(用来控制按钮失效)，跳转页码
  const string COUNT_SQL = "select count(*)  from orgpluinfo01";
#endregion
    /// <summary>
    /// 获取信息总数
    /// </summary>
    /// <param name="sqlSearch"></param>
    /// <returns></returns>
    public int GetRecordsCount(string sqlRecordsCount)
    {
           CommonClass cc = new CommonClass();
           string sqlQuery;
           if (sqlRecordsCount == "default")
           {
               sqlQuery = COUNT_SQL;
           }
           else
           {
               sqlQuery = sqlRecordsCount;
           }
           int RecordCount = 0;
           SqlConnection myConn = cc.Getconsql02();
           RecordCount = Convert.ToInt32(DbHelperSQL.GetSingle(sqlQuery));
           myConn.Close();           
           return RecordCount;
       }
    
    /// <summary>
       /// 计算余页
       /// </summary>
       /// <returns></returns>
       public int OverPage()
       {
           int pages = 0;
           if (RecordsCount % PAGESIZE != 0)
               pages = 1;
           else
               pages = 0;
           return pages;
       }
    
    /// <summary>
       /// 计算余页，防止SQL语句执行时溢出查询范围
       /// </summary>
       /// <returns></returns>
       public int ModPage()
       {
           int pages = 0;
           if (RecordsCount % PAGESIZE == 0 && RecordsCount != 0)
               pages = 1;
           else
               pages = 0;
           return pages;
       }
        /// <summary>
        /// GridView数据绑定，根据传入参数的不同，进行不同方式的查询，
        /// </summary>
        /// <param name="sqlSearch"></param>
        private void GridViewDataBind(string sqlSearch)
        {
            CurrentPage = (int)ViewState["PageIndex"];
            //从ViewState中读取页码值保存到CurrentPage变量中进行按钮失效运算
            Pages = (int)ViewState["PagesCount"];
            //从ViewState中读取总页参数进行按钮失效运算
            //判断四个按钮（首页、上一页、下一页、尾页）状态
            if (CurrentPage + 1 > 1)//当前页是否为首页
            {
                Fistpage.Enabled = true;
                Prevpage.Enabled = true;
            }
            else
            {
                Fistpage.Enabled = false;
                Prevpage.Enabled = false;
            }
            if (CurrentPage == Pages)//当前页是否为尾页
            {
                Nextpage.Enabled = false;
                Lastpage.Enabled = false;
            }
            else
            {
                Nextpage.Enabled = true;
                Lastpage.Enabled = true;
            }
            DataSet ds = new DataSet();
            string sqlResult;
            //根据传入参数sqlSearch进行判断，如果为default则为默认的分页查询，否则为添加了过滤条件的分页查询
            if (sqlSearch == "default")
            {
                //sqlResult = "select Top 10 * from orgpluinfo01 order by num desc";
                sqlResult = "Select Top " + PAGESIZE + " * from orgpluinfo01 where num is not null and num not in(select top " + PAGESIZE * CurrentPage + " num from orgpluinfo01 where  num is not null order by num desc) order by num desc";
            }
            else
            {
                sqlResult = sqlSearch;
            }
            //Response.Write(sqlResult);
            bindsskc(sqlResult);
            //显示Label控件lbCurrentPaget和文本框控件GotoPage状态
            lbCurrentPage.Text = (CurrentPage + 1).ToString();
            GotoPage.Text = (CurrentPage + 1).ToString();

        }
        protected void bindsskc(string sqlStr)
        {
            
            SqlConnection myConn = cc.Getconsql02();
            myConn.Open();
            SqlDataAdapter myDa = new SqlDataAdapter(sqlStr, myConn);
            DataSet ds = new DataSet();
            myDa.Fill(ds, "Result");
            GridView1.DataSource = ds.Tables["Result"].DefaultView;
            GridView1.DataBind();
            myDa.Dispose();
            ds.Dispose();
            myConn.Close();
        }
        /// <summary>
        /// 页面按钮Click处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void PagerBtnCommand_OnClick(object sender, EventArgs e)
        {
            CurrentPage = (int)ViewState["PageIndex"];
            //从ViewState中读取页码值保存到CurrentPage变量中进行参数运算
            Pages = (int)ViewState["PagesCount"];//从ViewState中读取总页参数运算
            Button btn = sender as Button;
            string sqlResult="default";
            if (btn != null)
            {
                string cmd = btn.CommandName;
                switch (cmd)//根据不同的CommandName做出不同的处理
                {
                    case "next":
                        CurrentPage++;
                        break;
                    case "prev":
                        CurrentPage--;
                        break;
                    case "last":
                        CurrentPage = Pages;
                        break;
                    case "search":
                        if (!string.IsNullOrEmpty(SearchName.Text))
                        {
                            RecordsCount = GetRecordsCount("select count(*) from orgpluinfo01 where num like '" + SearchName.Text + "%'");//获取过滤后的总记录数
                            PagesCount = RecordsCount / PAGESIZE + OverPage();//该变量为页总数
                            ViewState["PagesCount"] = RecordsCount / PAGESIZE - ModPage();//该变量为末页索引，比页总数小1
                            ViewState["PageIndex"] = 0;//保存一个为0的页面索引值到ViewState，页面索引从0开始
                            ViewState["JumpPages"] = PagesCount;
                            //保存PageCount到ViewState，跳页时判断用户输入数是否超出页码范围
                            //显示lbPageCount、lbRecordCount的状态
                            lbPageCount.Text = PagesCount.ToString();
                            lbRecordCount.Text = RecordsCount.ToString();
                            //判断跳页文本框失效
                            if (RecordsCount <= 10)
                                GotoPage.Enabled = false;
                            sqlResult = "Select Top " + PAGESIZE + "* from orgpluinfo01 where num is not null and  num not in(select top " + PAGESIZE * CurrentPage + " num from orgpluinfo01 where num is not null order by num desc) and num like '" + SearchName.Text + "%' order by num desc";
                        }
                        else
                        {
                            Response.Write("请输入您所要查找的单号！");
                        }
                        break;
                    case "jump":
                       JumpPage = (int)ViewState["JumpPages"];
                      //从ViewState中读取可用页数值保存到JumpPage变量中
                      //判断用户输入值是否超过可用页数范围值
                      if(Int32.Parse(GotoPage.Text) > JumpPage ||Int32.Parse(GotoPage.Text) <= 0)
                            Response.Write("<script>alert('页码范围越界！')</script>");
                      else
                      {
                          int InputPage = Int32.Parse(GotoPage.Text.ToString()) - 1;
                          //转换用户输入值保存在int型InputPage变量中
                          ViewState["PageIndex"] = InputPage;
                          CurrentPage = InputPage;
                         //写入InputPage值到ViewState["PageIndex"]中
                          sqlResult = "Select Top " + PAGESIZE + "* from orgpluinfo01 where num is not null and num not in(select top " + PAGESIZE * CurrentPage + " num from orgpluinfo01 where num is not null order by num desc) and num like '" + SearchName.Text + "%' order by num desc";
                      }
                        break;
                    default:
                        CurrentPage = 0;
                        break;
                }
                ViewState["PageIndex"] = CurrentPage;
                //将运算后的CurrentPage变量再次保存至ViewState
                GridViewDataBind(sqlResult);//调用数据绑定函数TDataBind()
            }
        }

    
    protected void btnReset_Click(object sender, EventArgs e)
     {
         RecordsCount = GetRecordsCount("default");//默认信息总数
         PagesCount = RecordsCount / PAGESIZE + OverPage();//默认的页总数
         ViewState["PagesCount"] = RecordsCount / PAGESIZE - ModPage();//保存末页索引，比页总数小1
         ViewState["PageIndex"] = 0;//保存页面初始索引从0开始
         ViewState["JumpPages"] = PagesCount;
         //保存页总数，跳页时判断用户输入数是否超出页码范围
         //显示lbPageCount、lbRecordCount的状态
         lbPageCount.Text = PagesCount.ToString();
         lbRecordCount.Text = RecordsCount.ToString();
         //判断跳页文本框失效
         if (RecordsCount <= 10)
         {
             GotoPage.Enabled = false;
         }
             GridViewDataBind("default");//调用数据绑定函数TDataBind()进行数据绑定运算
     }

 protected void Button2_Click(object sender, EventArgs e)
    {
     DataTable dsExport = new DataTable(); 
    //循环获取gridView的每列，获取表头 
    for(int i=0;i<this.GridView1.Columns.Count-1;i++) 
        { 
    //将表头信息添加到DataTable表头 
        dsExport.Columns.Add(this.GridView1.Columns[i].HeaderText); 
        } 
    //循环gridView每行，查找CheckBox被选中的行 
    foreach (GridViewRow msgRow in this.GridView1.Rows) 
        { 
    //通过ID获得所需要遍历的CheckBox 
            CheckBox chk = (CheckBox)msgRow.FindControl("CheckBox1"); 
    //判断CheckBox是否被选中 
        if (chk.Checked)
            { 
    //定义DataTable新行 
            System.Data.DataRow dr = dsExport.NewRow(); 
            for (int i = 0; i < msgRow.Cells.Count-1; i++) 
                {                
    //获取Cells数据 
                dr[i] =msgRow.Cells[i].Text.ToString(); 
                } 
    //添加新行到DataTable 
            dsExport.Rows.Add(dr); 
            }
     
        GridView2.DataSource = dsExport;
        GridView2.DataBind();
        if (dsExport.Rows.Count > 0)
        {
            //调用导出方法  
            ExportGridViewForUTF8(GridView2, DateTime.Now.ToShortDateString() + ".xls");
        }
        else
        {
           // obo.Common.MessageBox.Show(this, "没有数据可导出，请先查询数据!");
        }
    }
 }


    private void ExportGridViewForUTF8(GridView GridView, string filename)
    {

        string attachment = "attachment; filename=" + filename;
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", attachment);
        Response.Charset = "UTF-8";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
        Response.ContentType = "application/ms-excel";
        System.IO.StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        GridView.RenderControl(htw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();

    }  
    public void CreateExcel(DataTable dt, string FileType, string FileName)
        {
            Response.Clear();
            Response.Charset = "UTF-8";
            Response.Buffer = true;
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            Response.AppendHeader("Content-Disposition", "attachment;filename=\"" + System.Web.HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8) + ".xls\"");
            Response.ContentType = FileType;
            string colHeaders = string.Empty;
            string ls_item = string.Empty;
            DataRow[] myRow = dt.Select();
            int i = 0;
            int cl = dt.Columns.Count;          //总列数
            foreach (DataRow row in myRow)
            {
                for (i = 0; i < cl; i++)
                {
                    if (i == (cl - 1))
                    {
                        ls_item += row[i].ToString() + "\n";
                    }
                    else
                    {
                        ls_item += row[i].ToString() + "\t";
                    }
                }
                Response.Output.Write(ls_item);
                ls_item = string.Empty;
            }
            Response.Output.Flush();
            Response.End();
        }


    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}



