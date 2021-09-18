<%@ Page Language="C#" AutoEventWireup="true" CodeFile="myord_list_bill_cx.aspx.cs" Inherits="depotmanager_order_list" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server" http-equiv="refresh" content="60">
      <script src="../My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../js/datepicker/WdatePicker.js"></script>
<title>未处理订单</title>
<link href="../css/style_bill.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<script type="text/javascript">

    function opdg(s_type, s_url) {
        var t_width, t_height, t_title, t_url, t_id;
        t_id = 'w_1';
        switch (s_type) {
            case 'info':
                t_width = 1680;
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
    <!--  强制跳出框架
<script type="text/javascript">
if (window != top)
top.location.href = location.href;
</script> -->
</head>
<body>
    <form id="form1" runat="server">
	<div class="place">
    <span>位置:</span>
    <ul class="placeul">
    <li><a href="../home.aspx">首页</a></li>
    <li><a href="#">开票申请导出：</a></li>
    </ul>
    </div>
    <div class="rightinfo">
        <dl class="seachform">
            <dd>
                <label>开始日期：</label><span class="single-select"><asp:TextBox ID="bgndate" runat="server" Width="120" CssClass="scinput" onclick="WdatePicker()"></asp:TextBox>
                     结<label>束日期：</label><span class="single-select"><asp:TextBox ID="enddate" runat="server" Width="120" CssClass="scinput" onclick="WdatePicker()"></asp:TextBox>
                </span></dd>
            <dd>客户名称：<asp:TextBox ID="custname" runat="server" Width="120" CssClass="scinput"></asp:TextBox></span></label>&nbsp;</dd>
        <dd>业务员：<span class="single-select"><asp:TextBox ID="ywy" runat="server" Width="120" CssClass="scinput"></asp:TextBox></span></label>&nbsp;</dd>
   
     
       <asp:Button ID="lbtnSearch" runat="server" CssClass="scbtn" onclick="btnSearch_Click" Text="查询"></asp:Button>   
 </dd>
  <dd><asp:LinkButton ID="btnExport" runat="server" CssClass="save" OnClick="Button1_Click">   <li><span><img src="../images/t04.png" /></span>导出Execl</li></asp:LinkButton></dd>

    </dl>
            <!--列表-->
<asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
<HeaderTemplate>
	  <table   class="tablelist" >
    	<thead>
    	<tr>
        <th width="20px;" align="left">序号</th>
        <th width="40px;" align="left">申请号</th>
		<th width="40px;" align="left">来源</th>
		<th width="40px;" align="left">公司</th>
        <th width="30px" align="left">中心</th>
        <th width="30px" align="left">部门</th>
		<th width="60px" align="left">发票类型</th>
        <th width="80px" align="left">订单号</th>
		<th width="30px;" align="left">业务员</th>
		<th width="40px;" align="left">业务员电话</th>
        <th width="40px;" align="left">开票记录</th>  
        <th width="80px;" align="left">收货地址</th>       
        <th width="80px;" align="left">客户名称</th>
        <th width="60px;" align="left">税码</th>     
        <th width="80px;" align="left">地址</th>  
        <th width="80px;" align="left">开户行</th>   
        <th width="60px;" align="left">银行账号</th>   
        <th width="80px;" align="left">邮件</th>   
        <th width="40px;" align="left">公司电话</th>   
        <th width="30px;" align="left">联系人</th>   
        <th width="40px;" align="left">联系人电话</th>   
        <th width="80px;" align="left">备注</th>    
        <th width="30px;" align="left">录入人</th>
        <th width="40px;" align="left">商品名</th>    
        <th width="20px;" align="left">数量</th>    
        <th width="20px;" align="left">金额</th>             
        </tr>
        </thead>
        <tbody>
 </HeaderTemplate>
<ItemTemplate>
        <tr>
 <td ><asp:Label ID="no" runat="server" Text="Label"></asp:Label></td>
 <td><%# Eval("num")%></td>
 <td><%# Eval("sale_source")%></td>
 <td><%# Eval("com")%></td>
 <td><%# Eval("cen")%></td>
 <td><%# Eval("dept")%></td> 
 <td><%# Eval("billtype")%></td>
 <td><%# Eval("ordbillno")%></td>
 <td><%# Eval("yw_people")%></td>
 <td><%# Eval("yw_peopletell")%></td>
 <td><%# Eval("tick_record")%></td>
 <td><%# Eval("rec_address")%></td>
 <td><%# Eval("custom")%></td>
 <td><%# Eval("shuihao").ToString()%></td>
 <td><%# Eval("address")%></td>
 <td><%# Eval("bank")%></td>
 <td><%# Eval("bank_acc")%></td>
 <td><%# Eval("email")%></td>
 <td><%# Eval("tellphone")%></td>
 <td><%# Eval("cust_lxr")%></td>
 <td><%# Eval("lxr_tel")%></td>
 <td><%# Eval("memo")%></td>
 <td><%# Eval("jobno")%></td>
 <td><%# Eval("pluname")%></td>
 <td><%# Eval("plucount")%></td>
<td><%# Eval("sstotal")%></td>
        </tr> 		
 	   </ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"13\"><font color=red>暂无记录</font></td></tr>" : ""%>
   </tbody>
    </table>
</FooterTemplate>
</asp:Repeater> 

    <div class="pagelist">

  <div id="PageContent" runat="server" class="default"> <asp:HyperLink ID="first" runat="server">首页</asp:HyperLink> &nbsp
     <asp:HyperLink ID="next" runat="server">下一页</asp:HyperLink> &nbsp
     <asp:HyperLink ID="up" runat="server">上一页</asp:HyperLink> &nbsp
     <asp:HyperLink ID="last" runat="server">末页</asp:HyperLink>
     &nbsp;&nbsp; 跳转至：<asp:TextBox ID="nb" runat="server" Width="30px" AutoPostBack="True" OnTextChanged="nb_TextChanged" BorderColor="#660033" BorderStyle="Dotted" BorderWidth="1px" Height="22px" ></asp:TextBox>
     页
           
          <asp:Label ID="lblCurrentPage" runat="server"
                    Text="Label"></asp:Label>&nbsp;
                共<asp:Label ID="labPage" runat="server" Text="Label"></asp:Label>
                页&nbsp; 
      <asp:Label ID="tz1" runat="server" Visible="False"></asp:Label>
     </div>
</div>
      
    </div>
    </form>
</body>
</html>
