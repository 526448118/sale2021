<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order_rep.aspx.cs" Inherits="select_order_rep" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>订单信息报表</title>    
<style type="text/css">
body{
	OVERFLOW:SCROLL;
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	font-family: "宋体";
	font-size: 14px;
	line-height: 20px;
	color: #000000;
}
table {
	font-family: "宋体";
	font-size: 14px;
	line-height: 20px;
	color: #000000;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
	  <table width="98%"  border="1" align="center" cellpadding="5" cellspacing="1" bgcolor="#CACACA">
          <tr bgcolor="#EAEAEA">
            <td height="30" colspan="10" align="center" bgcolor="#FFFFFF">
            <span style="font-size:18px;line-height: 25px;"><b>订单信息表</b></span></td>
          </tr>
                  <tr bgcolor="#FFFFFF">       
               <td align="center" colspan="10" bgcolor="#C0C0C0">    <b> 
                下单起始日期：<font color="#FE5200"><asp:Literal ID="Literal4" runat="server"></asp:Literal></font> 
                下单结束日期：<font color="#FE5200"><asp:Literal ID="Literal5" runat="server"></asp:Literal></font>  
      
               </b></td>
                   </tr>
          <tr bgcolor="#FFFFFF"> 
            <td align="center"  bgcolor="#C0C0C0"><b>序号</b></td>     
           <td align="center"  bgcolor="#C0C0C0"><b>订单号</b></td>
		<td align="center"  bgcolor="#C0C0C0"><b>商家地区</b></td>
      <td align="center"  bgcolor="#C0C0C0"><b>下单商家</b></td>
		<td align="center"  bgcolor="#C0C0C0"><b>下单账号</b></td>
        <td align="center"  bgcolor="#C0C0C0"><b>订单状态</b></td>
		<td align="center"  bgcolor="#C0C0C0"><b>下单总金额</b></td>
        <td align="center"  bgcolor="#C0C0C0"><b>调整金额</b></td>
        <td align="center"  bgcolor="#C0C0C0"><b>实际总金额</b></td>
		<td align="center"  bgcolor="#C0C0C0"><b>下单时间</b></td>

        </tr>
       <asp:Repeater ID="repCategory" runat="server">
        <ItemTemplate>
         <tr bgcolor="#FFFFFF" >
            <td align="center"> <%# Container.ItemIndex + 1%></td> 
            <td align="left" style="vnd.ms-excel.numberformat:@" ><%# Eval("order_no")%></td>			

             <td align="center"><%# Convert.ToInt32(Eval("depot_category_id")) == 0 ? "<font color=red>公司操作</font>" : new ps_depot_category().GetTitle(Convert.ToInt32(Eval("depot_category_id")))%></td>
             <td align="center"><%# Convert.ToInt32(Eval("depot_id")) == 0  ? "<font color=red>公司操作</font>" : new ps_depot().GetTitle(Convert.ToInt32(Eval("depot_id")))%></td>
             <td align="center"><%#Eval("user_name").ToString() == "" ? "匿名用户" : Eval("user_name").ToString()%></td>
              <td align="center"><%#GetOrderStatus(Convert.ToInt32(Eval("status")))%></td>
              <td align="center"><%# MyConvert(Eval("payable_amount"))%></td>	
                 <td align="center"><%# MyConvert(Eval("real_amount"))%></td>	
                 <td align="center"><%# MyConvert(Eval("order_amount"))%></td>	
             <td align="center"><%#string.Format("{0:g}",Eval("add_time"))%></td>
          </tr>
       </ItemTemplate>
       </asp:Repeater>  
                     <tr bgcolor="#FFFFFF"> 
            <td align="center"  bgcolor="#C0C0C0"><b>合计</b></td>

                <td align="center"  bgcolor="#C0C0C0"><b></b></td>
            <td align="center"  bgcolor="#C0C0C0"><b></b></td>
            <td align="center"  bgcolor="#C0C0C0"><b></b></td>
                   <td align="center"  bgcolor="#C0C0C0"><b></b></td>
            <td align="center"  bgcolor="#C0C0C0"><b></b></td>

        
            <td align="center"  bgcolor="#C0C0C0"><b><font color="red"><asp:Literal ID="Literal_pa" runat="server"></asp:Literal></font></b></td>
             <td align="center"  bgcolor="#C0C0C0"><b><font color="red"><asp:Literal ID="Literal_ra" runat="server"></asp:Literal></font></b></td>
             <td align="center"  bgcolor="#C0C0C0"><b><font color="red"><asp:Literal ID="Literal_oa" runat="server"></asp:Literal></font></b></td>
               <td align="center"  bgcolor="#C0C0C0"><b></b></td> 

        </tr>  
		 </table>
    </form>
</body>
</html>
