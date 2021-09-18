<%@ Page Language="C#" AutoEventWireup="true" CodeFile="myord_list_bill_sh.aspx.cs" Inherits="depotmanager_order_list" %>
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
<link rel="stylesheet" type="text/css" href="jquery-easyui-1.6.7/themes/default/easyui.css"/>
<link rel="stylesheet" type="text/css" href="jquery-easyui-1.6.7/themes/icon.css"/>
<link rel="stylesheet" type="text/css" href="jquery-easyui-1.6.7/demo.css"/>
<script type="text/javascript" src="jquery-easyui-1.6.7/jquery.min.js"></script>
<script type="text/javascript" src="jquery-easyui-1.6.7/jquery.easyui.min.js"></script>
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
    <li><a href="#">发票申请记录查询：</a></li>
    </ul>
    </div>
    <div class="rightinfo">
        <dl class="seachform">
            <dd>
                <label>
                单据状态：<asp:DropDownList ID="DropDownList1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Fuchsia" Height="25px" Width="121px">
                    <asp:ListItem Value="1">门市未审</asp:ListItem>
                    <asp:ListItem Value="2">财务未审</asp:ListItem>
                    <asp:ListItem Value="3">财务已审核</asp:ListItem>
                    <asp:ListItem Value="10">已导出</asp:ListItem>
                    <asp:ListItem Value="99">已作废</asp:ListItem>
                </asp:DropDownList>
                单据来源：<asp:DropDownList ID="DropDownList2" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Fuchsia" Height="25px" Width="121px">
                    <asp:ListItem>---请选择---</asp:ListItem>
                    <asp:ListItem>卡券团单</asp:ListItem>
                    <asp:ListItem>收银小票</asp:ListItem>
                    <asp:ListItem>月饼实物团单</asp:ListItem>
                    <asp:ListItem>粽子实物团单</asp:ListItem>
                    <asp:ListItem>微信订单</asp:ListItem>
                    <asp:ListItem>商城订单</asp:ListItem>
                    <asp:ListItem>自制品团单</asp:ListItem>
                </asp:DropDownList>
                部门筛选：<asp:DropdownList id="dr1" runat="server" AutoPostBack="True" class="easyui-combobox" name="state"  labelPosition="top" OnSelectedIndexChanged="dr1_SelectedIndexChanged" Width="140px" Height="30px">
                        <asp:ListItem>总经办</asp:ListItem>
                        <asp:ListItem>信息中心</asp:ListItem>
                        <asp:ListItem>人资部</asp:ListItem>
                        <asp:ListItem>财务部</asp:ListItem>
                        <asp:ListItem>项目部</asp:ListItem>
                        <asp:ListItem>总务部</asp:ListItem>
                        <asp:ListItem>采购部</asp:ListItem>
                        <asp:ListItem>生产部</asp:ListItem>
                        <asp:ListItem>品控部</asp:ListItem>
                        <asp:ListItem>仓库部</asp:ListItem>
                        <asp:ListItem>物流部</asp:ListItem>
                        <asp:ListItem>营销中心</asp:ListItem>
                        <asp:ListItem>企划部</asp:ListItem>
                        <asp:ListItem>市场部</asp:ListItem>
                        <asp:ListItem>业务部</asp:ListItem>
                        <asp:ListItem>门市部</asp:ListItem>
                        <asp:ListItem>加盟组</asp:ListItem>
                        <asp:ListItem>经销商</asp:ListItem>
                     </asp:DropdownList>
                单据号：<span class="single-select"><asp:TextBox ID="num" runat="server" Width="120" CssClass="scinput" ></asp:TextBox>
                </span>客户名称：<asp:TextBox ID="custname" runat="server" Width="120" CssClass="scinput"></asp:TextBox>
                </label>
                &nbsp;业务员：<span class="single-select"><asp:TextBox ID="ywy" runat="server" Width="120" CssClass="scinput"></asp:TextBox>
                </span>
   
     
                <asp:Button ID="lbtnSearch" runat="server" CssClass="scbtn" onclick="btnSearch_Click" Text="查询"></asp:Button>
                <asp:LinkButton ID="btnExport" runat="server" CssClass="save" OnClick="Button1_Click" Visible="False">   <img src="../images/t04.png" />导出Execl</asp:LinkButton>
            </dd>

    </dl>
            <!--列表-->
<asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
<HeaderTemplate>
	  <table   class="tablelist" >
    	<thead>
    	<tr>
        <th width="20px;" align="left">序号</th>
        <th width="20px;" align="left">状态</th>
        <th width="40px;" align="left">处理订单</th>
        <th width="40px;" align="left">申请号</th>
		<th width="30px;" align="left">来源</th>
		<th width="40px;" align="left">公司</th>
        <th width="30px" align="left">中心</th>
        <th width="30px" align="left">部门</th>
		<th width="60px" align="left">发票类型</th>
        <th width="40px" align="left">订单号</th>
        <th width="40px" align="left">订单金额</th>
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
        </tr>
        </thead>
        <tbody>
 </HeaderTemplate>
<ItemTemplate>
        <tr>
 <td ><asp:Label ID="no" runat="server" Text="Label"></asp:Label></td>
 <td><%#(Eval("status01"))%></td>
 <td><a href="../grace/view_salebill.aspx?id=<%#Eval("num")%>&ty=2" class="tablelink"> 查看</a> </td>
 <td><%# Eval("num")%></td>
 <td><%# Eval("sale_source")%></td>
 <td><%# Eval("com")%></td>
 <td><%# Eval("cen")%></td>
 <td><%# Eval("dept")%></td> 
 <td><%# Eval("billtype")%></td>
 <td><%# Eval("ordbillno")%></td>
 <td><%# Eval("ordje")%></td>
 <td><%# Eval("yw_people")%></td>
 <td><%# Eval("yw_peopletell")%></td>
 <td><%# Eval("tick_record")%></td>
 <td><%# Eval("rec_address")%></td>
 <td><%# Eval("custom")%></td>
 <td><%# Eval("shuihao")%></td>
 <td><%# Eval("address")%></td>
 <td><%# Eval("bank")%></td>
 <td><%# Eval("bank_acc").ToString()%></td>
 <td><%# Eval("email")%></td>
 <td><%# Eval("tellphone")%></td>
 <td><%# Eval("cust_lxr")%></td>
 <td><%# Eval("lxr_tel")%></td>
 <td><%# Eval("memo")%></td>
 <td><%# Eval("jobno")%></td>

        </tr> 		
 	   </ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"13\"><font color=red>暂无记录</font></td></tr>" : ""%>
   </tbody>
    </table>
</FooterTemplate>
</asp:Repeater> 

          <div class="pagelist">
        <table align="left">

   <tr>

      <td align="center"> 
             <asp:LinkButton ID="lbtnFirstPage" runat="server" OnClick="lbtnFirstPage_Click">首页</asp:LinkButton> &nbsp
             <asp:LinkButton ID="lbtnpritPage" runat="server" OnClick="lbtnpritPage_Click">上一页</asp:LinkButton>  &nbsp
             <asp:LinkButton ID="lbtnNextPage" runat="server" OnClick="lbtnNextPage_Click">下一页</asp:LinkButton> &nbsp
             <asp:LinkButton ID="lbtnDownPage" runat="server" OnClick="lbtnDownPage_Click">尾页</asp:LinkButton> &nbsp
             第<asp:Label ID="labPage" runat="server"></asp:Label>页/共<asp:Label ID="LabCountPage" runat="server"></asp:Label>页

      </td>

  </tr>

</table>
             </div>
      
    </div>
    </form>
</body>
</html>
