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
    <asp:ListItem Value="0">订单生成</asp:ListItem>
    <asp:ListItem Value="1">助理审核</asp:ListItem>
    <asp:ListItem Value="2">营销审核</asp:ListItem>
    <asp:ListItem Value="3">总经办审核</asp:ListItem>
    <asp:ListItem Value="4">后台下单</asp:ListItem>
    <asp:ListItem Value="99">订单作废</asp:ListItem>
</asp:DropDownList>

        单据号</span>：</label><span class="single-select"><asp:TextBox ID="billno" runat="server" Width="120" CssClass="scinput"></asp:TextBox></span></dd>
	

     <dd>客户名称：<span class="single-select"><asp:TextBox ID="custname" runat="server" Width="120" CssClass="scinput"></asp:TextBox></span></label>&nbsp;</dd>
        <dd>业务员：<span class="single-select"><asp:TextBox ID="ywy" runat="server" Width="120" CssClass="scinput"></asp:TextBox></span></label>&nbsp;</dd>
   
     
       <asp:Button ID="lbtnSearch" runat="server" CssClass="scbtn" onclick="btnSearch_Click" Text="查询"></asp:Button>  
        
      </dd>
 <dd><asp:LinkButton ID="btnExport" runat="server" CssClass="save" OnClick="Button1_Click">   <li><span><img src="../images/t04.png" /></span>导出Execl</li></asp:LinkButton></dd>

 
    </dl>
            <!--列表-->
<asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
<HeaderTemplate>
	  <table align="left"   class="tablelistl">
    	<thead>
    	<tr>
             <th >序号</th>
          <th >单号</th>
             <th>中心</th>
             <th>部门</th>
              <th>销售员</th>
             <th>销售员电话</th>
             <th>录入日期</th>
             <th>提货日期</th>
             <th>订单来源</th>
             <th>提货方式</th>
              <th>商品类型</th>
             <th>客户名称</th>
             <th>联系人</th>

                <th >客户电话</th>
             <th>付款方式</th>
             <th>开票</th>
        <th>提货地址</th>
             <th>单据状态</th>
             <th>录入人</th>
    
       <th>商品编号</th>
             <th>商品名称</th>
             <th>价格</th>
     <th>数量</th>
             <th>应收金额</th>
             <th>折扣</th>
       <th>实收金额</th>     
             <th>单据状态</th>   
               <th>系统单号</th>    
         
        </tr>
        </thead>
        <tbody>
 </HeaderTemplate>
<ItemTemplate>
        <tr>
             <td ><asp:Label ID="no" runat="server" Text="Label"></asp:Label></td>
             <td><%# Eval("num")%></td>
             <td><%# Eval("cen")%></td>
             <td><%# Eval("dept")%></td>
              <td><%# Eval("saler")%></td>
             <td><%# Eval("saler_tel")%></td>
             <td><%# Eval("lrdate")%></td>
             <td><%# Eval("thdate")%></td>
             <td><%# Eval("ord_from")%></td>
             <td><%# Eval("thtype")%></td>
              <td><%# Eval("plutype")%></td>
             <td><%# Eval("custname")%></td>
             <td><%# Eval("cust_body")%></td>

                <td><%# Eval("cust_body_tel")%></td>
             <td><%# Eval("fktype")%></td>
             <td><%# Eval("kp")%></td>
        <td><%# Eval("th_address")%></td>
             <td><%# Eval("bill_status")%></td>
             <td><%# Eval("lrstaff")%></td>
    
       <td><%# Eval("plucode")%></td>
             <td><%# Eval("pluname")%></td>
             <td><%# Eval("price")%></td>
     <td><%# Eval("count")%></td>
             <td><%# Eval("ystotal")%></td>
             <td><%# Eval("zk")%></td>
                  <td><%# Eval("sstotal")%></td>
       <td ><%#GetOrderStatus(Convert.ToInt32(Eval("bill_status")))%></td>
    <td><%# Eval("billno")%></td>
             
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
