using System;
using System.Web.UI;
using System.Web.Security;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtUserName.Value = Utils.GetCookie("RememberName");
        }
    }

    #region 登录系统=========================
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
 
        string userName = txtUserName.Value.Trim().ToUpper();
        string userPwd = txtPassword.Value.Trim();

        //判断登录信息
        ps_manager myuser = new ps_manager();
        string sqlGetUserID = "select  id  from [ps_manager] where user_name='" + userName + "'";
        int userid = Convert.ToInt32(DbHelperSQL.GetSingle(sqlGetUserID));
        myuser.GetModel(userid);
        if (myuser.password != null)
        {
            userPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(userPwd, "MD5");
            if (myuser.password.Trim() != userPwd)
            {
                MessageBox.errorShow(this.Page, "账号或密码有误，请重试！");
                return;
            }

            //判断账号是否被禁用
            if (Convert.ToInt32(myuser.is_lock) ==2)
            {
                MessageBox.errorShow(this.Page, "您的账号被禁用，请联系客服！");
                return;
            }
            ps_depot  myd = new ps_depot();
            myd.GetModel(Convert.ToInt32(myuser.depot_id));
            
            //判断账号对应的商家是否被禁用
            if (Convert.ToInt32(myuser.depot_id) != 0 && Convert.ToInt32(myd.status) == 2)
            {
                MessageBox.errorShow(this.Page, "您所在xx被禁用，请联系客服！");
                return;
            }
            //写入登录日志
            ps_manager_log mylog = new ps_manager_log();
            mylog.user_id = userid;
            mylog.user_name = userName;
            mylog.action_type = "登陆";
            mylog.add_time = DateTime.Now;
            mylog.remark = "登陆系统";
            mylog.user_ip = AXRequest.GetIP();
            mylog.Add();


            //写入Cookies
            Utils.WriteCookie("RememberName", userName, 14400);
            Utils.WriteCookie("AdminName", userName, 14400);
            Utils.WriteCookie("RoleID", myuser.role_id.ToString(), 14400);
            Utils.WriteCookie("AID", myuser.id.ToString(), 14400);
            Utils.WriteCookie("RealName", myuser.real_name, 14400);
            Utils.WriteCookie("DepotID", myuser.depot_id.ToString(), 14400);
            Utils.WriteCookie("DepotCatID", myuser.depot_category_id.ToString(), 14400);

            Utils.WriteCookie("COM", myuser.com, 14400);
            Utils.WriteCookie("DEPT", myuser.dept.ToString(), 14400);
            Utils.WriteCookie("sh_memo", myuser.sh_memo.ToString(), 14400);
            //写入Session
            Session["RememberName"] = userName;
            Session["AdminName"] = userName;
            Session["RoleID"] = myuser.role_id.ToString();
            Session["AID"] = myuser.id.ToString();
            Session["RealName"] = myuser.real_name;
            Session["DepotID"] = myuser.depot_id.ToString();
            Session["DepotCatID"] = myuser.depot_category_id.ToString();
            Session["COM"] = myuser.com.ToString();
            Session["DEPT"] = myuser.dept.ToString();
            Session["sh_memo"] = myuser.sh_memo.ToString();

            Session.Timeout = 45;

            Response.Redirect("main.aspx");
            return;
        }
        else
        {
            MessageBox.errorShow(this.Page, "账号或密码有误，请重试！");
            return;
        }
    }
    #endregion
}
