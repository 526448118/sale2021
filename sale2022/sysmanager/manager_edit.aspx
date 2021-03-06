<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manager_edit.aspx.cs" Inherits="sysmanager_manager_edit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>编辑用户</title>
<script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<script type="text/javascript" src="../js/pinyin.js"></script>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
    });
</script>
</head>
<body>
    <form id="form1" runat="server">

	<div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="../home.aspx">首页</a></li>
    <li><a href="manager_list.aspx">用户管理</a></li>
    <li><a href="#">编辑用户</a></li>
    </ul>
    </div>
    
    <div class="formbody">   
    <div class="formtitle"><span>用户信息</span></div>
    <!--用户信息-->
<div class="tab-content">
   <dl id="role" runat="server" visible="true">
    <dt>管理角色</dt>
    <dd>
      <span class="rule-single-select" style="position:absoulte;z-index:5555; ">
        <asp:DropDownList id="ddlRoleId" runat="server" datatype="*" errormsg="请选择管理员角色" sucmsg=" "  AutoPostBack="True" onselectedindexchanged="ddlRoleId_SelectedIndexChanged"></asp:DropDownList>
      </span>
    </dd>
  </dl>
     <dl id="bm" runat="server" visible="false">
    <dt>所属公司</dt>
    <dd>
      <span class="rule-single-select" style="position:absoulte;z-index:5554; ">
        <asp:DropDownList id="ddlCategoryId" runat="server" datatype="*" errormsg="请选择所属公司" sucmsg=" " AutoPostBack="True" onselectedindexchanged="ddlCategoryId_SelectedIndexChanged"></asp:DropDownList>
      </span>
    </dd>
  </dl>
    <dl id="md" runat="server" visible="false">
    <dt>所属部门</dt>
    <dd>
      <span class="rule-single-select" style="position:absoulte;z-index:5553; ">
        <asp:DropDownList id="ddlDepotId" runat="server" datatype="*" errormsg="请选择所属部门" sucmsg=" "></asp:DropDownList>
      &nbsp;</span></dd>
  </dl>
<dl>
    <dt>登录账号</dt>
    <dd><asp:TextBox ID="txtUserName" runat="server" CssClass="input normal" datatype="/^[a-zA-Z0-9\-\_]{2,50}$/" sucmsg=" " ajaxurl="../tools/admin_ajax.ashx?action=manager_validate"></asp:TextBox> <span class="Validform_checktip">*字母、下划线、数字</span></dd>
  </dl> 
<dl>
    <dt>登录密码</dt>
    <dd><asp:TextBox ID="txtPassword" runat="server" CssClass="input normal" TextMode="Password" datatype="*6-20" nullmsg="请设置密码" errormsg="密码范围在6-20位之间" sucmsg=" " ></asp:TextBox> <span class="Validform_checktip">*</span></dd>
  </dl>
  <dl>
    <dt>确认密码</dt>
    <dd><asp:TextBox ID="txtPassword1" runat="server" CssClass="input normal" TextMode="Password" datatype="*" recheck="txtPassword" nullmsg="请再输入一次密码" errormsg="两次输入的密码不一致" sucmsg=" "></asp:TextBox> <span class="Validform_checktip">*</span></dd>
  </dl>
  
  <dl>
    <dt>姓名</dt>
    <dd><asp:TextBox ID="txtRealName" runat="server" CssClass="input normal"></asp:TextBox></dd>
  </dl>
  <dl>
    <dt>手机号</dt>
    <dd><asp:TextBox ID="txtmobile" runat="server" CssClass="input normal"></asp:TextBox></dd>
  </dl>
      <dl>
    <dt>参与审核节点</dt>
    <dd>
      <span class="rule-single-select" style="position:absoulte;z-index:5553; ">
        <asp:DropDownList id="sh" runat="server" datatype="*" errormsg="请选择所属部门" sucmsg=" ">
            <asp:ListItem Value="0">...请选择...</asp:ListItem>
            <asp:ListItem Value="1">助理审核</asp:ListItem>
            <asp:ListItem Value="2">营销审核</asp:ListItem>
            <asp:ListItem Value="3">总经办审核</asp:ListItem>
            <asp:ListItem Value="4">后台下单</asp:ListItem>
        </asp:DropDownList>
      </span>
          </dd>
  </dl>

  <dl >
    <dt>是否启用</dt>
    <dd>
      <div class="rule-single-checkbox">
          <asp:CheckBox ID="cbIsLock" runat="server" Checked="True"  />
      </div>
      <span class="Validform_checktip">*不启用该账户将无法登录使用本系统</span>
    </dd>
  </dl>

  <dl>
    <dt>备注</dt>
        <dd><asp:TextBox ID="txtremark" runat="server" CssClass="input normal" ></asp:TextBox>&nbsp;&nbsp; </dd>
  </dl>
</div>
<!--/用户信息-->    
    </div>

    <!--工具栏-->
<div class="page-footer">
  <div class="btn-list">
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" onclick="btnSubmit_Click"  />
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
    <asp:Button ID="btnSubmit0" runat="server" Text="密码初始化" CssClass="btn" OnClick="btnSubmit0_Click"  />
  </div>
  <div class="clear"></div>
</div>
<!--/工具栏-->

    
    </form>
</body>
</html>
