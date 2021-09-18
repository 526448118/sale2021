using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Xml;

public partial class home : System.Web.UI.Page
{
    protected string msg = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //判断是否登录
        ManagePage mym = new ManagePage();
        if (!mym.IsAdminLogin())
        {
            Response.Write("<script>parent.location.href='index.aspx'</script>");
            Response.End();
        }
       
        if (!IsPostBack)
        {
            noticeBind();//通知公告
           
        }
    }

  
    #region 绑定通知公告=================================
    protected void noticeBind()
    {
        ps_article bll = new ps_article();
        this.rptList_notice.DataSource = bll.GetList(13, " status=1 ", " sort_id asc, add_time desc");
        this.rptList_notice.DataBind();
    }
    #endregion


    //小数位是0的不显示
    public string MyConvert(object d)
    {
        string myNum = d.ToString();
        string[] strs = d.ToString().Split('.');
        if (strs.Length > 1)
        {
            if (Convert.ToInt32(strs[1]) == 0)
            {
                myNum = strs[0];
            }
        }
        return myNum;
    }
   
}