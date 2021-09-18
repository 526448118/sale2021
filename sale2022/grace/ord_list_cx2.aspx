<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ord_list_cx2.aspx.cs" Inherits="depotmanager_order_list" %>
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
                t_height = 560;
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
</head>
<body>
    <form id="form1" runat="server">
	<div class="place">
    <span>位置:</span>
    <ul class="placeul">
    <li><a href="../home.aspx">首页</a></li>
    <li><a href="#">已处理订单</a></li>
    </ul>
    </div>  
    <div class="rightinfo">
    <dl class="seachform"> 
    <dd><label>   
        订单状态：
    <span >
<asp:DropDownList ID="ordstatus"  runat="server" >
    <asp:ListItem Value="22">全部</asp:ListItem>
    <asp:ListItem Value="3">总经办审核</asp:ListItem>
    <asp:ListItem Value="1">门市审核</asp:ListItem>
    <asp:ListItem Value="2">营销审核</asp:ListItem>
<asp:ListItem Value="0">订单生成</asp:ListItem>
    <asp:ListItem Value="4">后台下单</asp:ListItem>
    <asp:ListItem Value="99">订单作废</asp:ListItem>
    <asp:ListItem Value="9">申请作废</asp:ListItem>
</asp:DropDownList>
    </span>
        订单号：</label><span class="single-select"><asp:TextBox ID="billno" runat="server" Width="120" CssClass="scinput"></asp:TextBox></span></dd>
	

     <dd>客户名称：<span class="single-select"><asp:TextBox ID="custname" runat="server" Width="120" CssClass="scinput"></asp:TextBox></span></label>&nbsp;</dd>
        <dd>业务员：<span class="single-select"><asp:TextBox ID="ywy" runat="server" Width="120" CssClass="scinput"></asp:TextBox></span></label>&nbsp;</dd>
   
     
       <asp:Button ID="lbtnSearch" runat="server" CssClass="scbtn" onclick="btnSearch_Click" Text="查询"></asp:Button>   
 </dd>
 <dd><asp:LinkButton ID="btnExport" runat="server" CssClass="save" OnClick="Button1_Click">   <li><span><img src="../images/t04.png" /></span>导出Execl</li></asp:LinkButton></dd>

    </dl>
            <!--列表-->
<asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound" OnItemCommand="rptList_ItemCommand">
<HeaderTemplate>
	  <table class="tablelist">
    	<thead>
    	<tr>
        <th width="20px;">序号</th>
            <th width="20px;">打印</th>
             <th width="30px;">操作</th>     
		  <th width="30px;">来源</th>
            <th width="15px;">订单号</th>
              <th width="20px;">下单部门</th>
		<th width="30px;">客户名称</th>
        <th width="20px">业务员</th>
        <th width="20px">下单时间</th>
		<th width="20px">提货时间</th>
        <th width="20px">商品类型</th>
		<th width="40px;">提货方式</th>
		<th width="20px;">应收金额</th>
         <th width="20px;">实收金额</th>  
            <th width="40px;">单据状态</th>       
            
        </tr>
        </thead>
        <tbody>
 </HeaderTemplate>
<ItemTemplate>
        <tr>
             <td width="10px;"><asp:Label ID="no" runat="server" Text="Label"></asp:Label></td>
             <td><%# Eval("ord_print")%></td>
             <td><a href="../grace/ord_info.aspx?id=<%#Eval("num")%>&cx=11" class="tablelink"> 处理订单</a> </td>
             <td><%# Eval("ord_from")%></td>
             <td><%# Eval("num")%></td>
              <td><%# Eval("dept")%></td>
            <td><%# Eval("custname")%></td>
             <td><%# Eval("saler")%></td>
             <td><%# Eval("lrdate")%></td>
             <td><%# Eval("thdate")%></td>
             <td width="40px"><%# Eval("plutype")%></td>
             <td><%# Eval("thtype")%></td>
             <td><%# Eval("ystotal")%></td>
             <td><%# Eval("sstotal")%></td>
             <td><%#GetOrderStatus(Convert.ToInt32(Eval("bill_status")))%></td>
        
      <!--          <td><a href="javascript:opdg('info','../grace/ord_info.aspx?id=<%#Eval("num")%>&cx=11');" class="tablelink">查看</a></td>  -->
        </tr> 		
 	   </ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"10\"><font color=red>暂无记录</font></td></tr>" : ""%>
   </tbody>
    </table>
</FooterTemplate>
</asp:Repeater> 

    <div class="pagelist">

  <div id="PageContent" runat="server" class="default"></div>
</div>
      
    </div>
    </form>
</body>
</html>
