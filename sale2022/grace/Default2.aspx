<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="grace_Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
    <tr ><td class="style1" align ="left" >&nbsp;</td></tr>
   
    <tr ><td class="style1">  
       <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="rptList_ItemDataBound" >
       
      <HeaderTemplate>
	  <table class="tablelist">
    	<thead>
    	<tr>
        <th width="20px;">序号</th>
            <th width="60px;">来源</th>
		<th width="20px;">订单号</th>
		<th width="290px;">客户名称</th>
        <th width="80px">业务员</th>
        <th width="90px">下单时间</th>
		<th width="220px">提货时间</th>
        <th width="80px">商品类型</th>
		<th width="80px;">提货方式</th>
		<th width="20px;">应收金额</th>
         <th width="20px;">实收金额</th>  
            <th width="60px;">单据状态</th>       
            <th width="80px;">操作</th>      
        </tr>
        </thead>
        <tbody>
 </HeaderTemplate>
<ItemTemplate>
        <tr>
             <td width="10px;"><asp:Label ID="no" runat="server" Text="Label"></asp:Label></td>
             <td><%# Eval("ord_from")%></td>
            <td><%# Eval("num")%></td>
            <td><%# Eval("custname")%></td>
             <td><%# Eval("saler")%></td>
             <td><%# Eval("lrdate")%></td>
             <td><%# Eval("thdate")%></td>
             <td><%# Eval("plutype")%></td>
             <td><%# Eval("thtype")%></td>
             <td><%# Eval("ystotal")%></td>
             <td><%# Eval("sstotal")%></td>
            <td><%#GetOrderStatus(Convert.ToInt32(Eval("bill_status")))%></td>
             <td><a href="../grace/ord_info.aspx?id=<%#Eval("num")%>&cx=99" class="tablelink"> 处理订单</a> </td>
        </tr> 		
 	   </ItemTemplate>
<FooterTemplate>
  <%#Repeater1.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"13\"><font color=red>暂无记录</font></td></tr>" : ""%>
   </tbody>
    </table>
</FooterTemplate>
        </asp:Repeater>
        </td> </tr>
   
   
<tr> <td class="style1">
     <asp:HyperLink ID="first" runat="server">首页</asp:HyperLink>
     <asp:HyperLink ID="next" runat="server">下一页</asp:HyperLink>
     <asp:HyperLink ID="up" runat="server">上一页</asp:HyperLink>
     <asp:HyperLink ID="last" runat="server">末页</asp:HyperLink>
     &nbsp;&nbsp; 跳转到：<asp:TextBox ID="nb" runat="server" Width="30px" AutoPostBack="True" OnTextChanged="nb_TextChanged"></asp:TextBox>
     页</td></tr>
           
           <tr> <td class="style1">当前页为：<asp:Label ID="lblCurrentPage" runat="server"
                    Text="Label"></asp:Label>&nbsp;
                共<asp:Label ID="labPage" runat="server" Text="Label"></asp:Label>
                页</td><td class="style1" style="height: 21px">
     
     </td></tr>

            
    </table>
    </div>
    </form>
</body>
</html>
