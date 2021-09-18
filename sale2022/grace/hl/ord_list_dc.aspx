<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ord_list_dc.aspx.cs" Inherits="depotmanager_order_list" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server" http-equiv="refresh" content="60">
<title>未处理订单</title>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<script type="text/javascript">

    function opdg(s_type, s_url) {
        var t_width, t_height, t_title, t_url, t_id;
        t_id = 'w_1';
        switch (s_type) {
            case 'info':
                t_width = 1080;
                t_height = 460;
                t_title = '查看订单详情';
                t_url = s_url;
                break;
        }
        $.dialog({
            width: t_width,
            height: t_height,
            title: t_title,
            max: false,
            content: 'url:' + t_url
        });
    } 
</script> 
    <style type="text/css">

.pagelist{ clear:both; display:block; margin:10px 0 20px 0; }
	*{border-style: none;
    border-color: inherit;
    border-width: 0;
    font-size:9pt;margin:0 0 0 0px;
    padding:0;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
	<div class="place">
    <span>位置:</span>
    <ul class="placeul">
    <li><a href="../home.aspx">首页</a></li>
    <li><a href="#">查看全部订单</a></li>
    </ul>
    </div>  
    <div class="rightinfo">
    <dl class="seachform"> 
    <dd>
        <label>   
        订单状态：
    <span class="rule-single-select">
<asp:DropDownList ID="billstatus"  runat="server" >
<asp:ListItem Value="22">全部</asp:ListItem>
    <asp:ListItem Value="99">订单作废</asp:ListItem>
    <asp:ListItem>已导出</asp:ListItem>
    <asp:ListItem>未导出</asp:ListItem>
</asp:DropDownList>

        单据号</span>：</label><span class="single-select"><asp:TextBox ID="billno" runat="server" Width="120" CssClass="scinput" BorderWidth="1px"></asp:TextBox></span>客户名称：<span class="single-select"><asp:TextBox ID="custname" runat="server" Width="120" CssClass="scinput" BorderColor="#000001" BorderWidth="1px"></asp:TextBox>
        </span>&nbsp;业务员：<span class="single-select"><asp:TextBox ID="ywy" runat="server" Width="120" CssClass="scinput" BorderWidth="1px"></asp:TextBox>
        </span>&nbsp;</dd>
   
     
        <asp:Button ID="lbtnSearch" runat="server" CssClass="scbtn" onclick="btnSearch_Click" Text="查询"></asp:Button>
        <asp:LinkButton ID="btnExport" runat="server" CssClass="save" OnClick="Button1_Click">   <li><span><img src="../images/t04.png" /></span>导出Execl</li></asp:LinkButton>
        </dd>

 
    </dl>
            <!--列表-->

        <br />
        <asp:GridView ID="GridView1" AllowPaging="true" runat="server" 
            OnPageIndexChanging="GridView1_PageIndexChanging"  PageSize="20" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"> 
             <Columns>
                 <asp:TemplateField>
                     <ItemTemplate>
                         <asp:CheckBox ID="CheckBox1" runat="server" />
                     </ItemTemplate>                                              
                 </asp:TemplateField>
             </Columns>
        </asp:GridView>

    </div>
    </form>
</body>
</html>
