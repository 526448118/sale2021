<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation = "false" CodeFile="myord_list_bill_cx.aspx.cs" Inherits="depotmanager_order_list" %>
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
    $(document).ready(function () {

        $('select').addClass("form-control");

    });
</script> 
    <!--  强制跳出框架
<script type="text/javascript">
if (window != top)
top.location.href = location.href;
</script> -->
      <style type="text/css">
          .scinput {}
      </style>
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
                <label>录入时间：</label><span class="single-select"><asp:TextBox ID="bgndate" runat="server" Width="120" CssClass="scinput" onclick="WdatePicker()" Height="32px"></asp:TextBox>
                     到<span class="single-select"><asp:TextBox ID="enddate" runat="server" Width="120px" CssClass="scinput" onclick="WdatePicker()" Height="32px"></asp:TextBox>
                </span></span></dd>
            <dd>
                <label>审核时间：</label><span class="single-select"><asp:TextBox ID="shbgdate" runat="server" Width="120px" CssClass="scinput" onclick="WdatePicker()" Height="31px"></asp:TextBox>
                     到<asp:TextBox ID="shendate" runat="server" Width="120px" CssClass="scinput" onclick="WdatePicker()" Height="32px"></asp:TextBox>
                </dd>
            <dd>订单号：<asp:TextBox ID="ordbillno" runat="server" Width="120" CssClass="scinput"></asp:TextBox>
                </span></label>订单来源:</label>&nbsp;<label><asp:DropDownList ID="DropDownList3" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Height="30px" Font-Bold="True" ForeColor="Fuchsia">
                    <asp:ListItem>全部</asp:ListItem>
                    <asp:ListItem>卡券团单</asp:ListItem>
                    <asp:ListItem>实物团单</asp:ListItem>
                    <asp:ListItem Value="收银小票">收银小票</asp:ListItem>
                </asp:DropDownList>
                </label>
                </dd>
        <dd>
            <label>
                发票类型<asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Font-Bold="True" ForeColor="Fuchsia">
                    <asp:ListItem>全部</asp:ListItem>
                    <asp:ListItem>普票</asp:ListItem>
                    <asp:ListItem>专用增值税发票</asp:ListItem>
                    <asp:ListItem>电子发票</asp:ListItem>
                </asp:DropDownList>
                &nbsp;
                单据状态<asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Font-Bold="True" ForeColor="Fuchsia">
                    <asp:ListItem>全部</asp:ListItem>
                    <asp:ListItem>未导出</asp:ListItem>
                    <asp:ListItem>已导出</asp:ListItem>
                    <asp:ListItem Value="02">未审核</asp:ListItem>
                    <asp:ListItem Value="03">已审核</asp:ListItem>
                    <asp:ListItem Value="99">已作废</asp:ListItem>
                </asp:DropDownList>
                </label>
                &nbsp;</dd>
   
     
       <asp:Button ID="lbtnSearch" runat="server" CssClass="scbtn" onclick="btnSearch_Click" Text="查询"></asp:Button>   
 </dd>
  <dd><asp:LinkButton ID="btnExport" runat="server" CssClass="save" OnClick="Button1_Click">   <li><span><img src="../images/t04.png" /></span>导出Execl</li></asp:LinkButton></dd>

    </dl>
            <!--列表-->
<asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound" OnItemCommand="rptList_ItemCommand">
    
<HeaderTemplate>
	  <table   class="tablelist"  width="1500px">
    	<thead>
    	<tr>
        <th width="20px;" align="left">序号</th>
        <th width="20px;" align="left">发票单号</th>
        <th width="40px;" align="left">公司名称</th>
        <th width="20px;" align="left">税号</th>
        <th width="40px;" align="left">地址电话</th>
        <th width="40px;" align="left">银行账号</th> 
        <th width="40px;" align="left">商品名称</th>  
        <th width="40px;" align="left">规格型号</th>
        <th width="40px;" align="left">计量单位</th>    
        <th width="20px;" align="left">数量</th>
        <th width="20px;" align="left">总价</th> 
        <th width="20px;" align="left">税收编码</th> 
        <th width="20px;" align="left">税率</th> 
        <th width="20px;" align="left">申请单号</th>
        <th width="20px;" align="left">录入时间</th>
        <th width="20px;" align="left">POS/SAP单号</th>          
        <th width="60px;" align="left">门店名</th>
        <th width="40px;" align="left">发票备注</th> 
        <th width="40px;" align="left">原发票号</th> 
        <th width="60px;" align="left">电子发票（电子邮箱）</th>  
        <th width="60px;" align="left">电子发票（公司电话）</th> 
        <th width="60px;" align="left">是否已导出</th> 
        </tr>
        </thead>
        <tbody>
 </HeaderTemplate>
<ItemTemplate>
        <tr>
 <td ><asp:Label ID="no" runat="server" Text="Label"></asp:Label></td>
 <td><%# Eval("xd_billno")%></td>
 <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("xd_billno") %>' />
 <td><%# Eval("custom")%></td>
 <td style="vnd.ms-excel.numberformat:@"><%# Eval("shuihao")%></td>
 <td><%# Eval("address")%></td> 
 <td style="vnd.ms-excel.numberformat:@"><%# Eval("bank_acc")%></td>
 <td><%# Eval("pluname")%></td>
 <td><%# Eval("plumodel")%></td>
 <td><%# Eval("pluunit")%></td>
 <td><%# Eval("plucount")%></td>
 <td><%# Eval("sstotal")%></td>
 <td><%# Eval("s_code")%></td>
 <td><%# Eval("shuilv")%></td>
 <td><%# Eval("num")%></td>
 <td><%# Eval("lrtime")%></td>
 <td style="vnd.ms-excel.numberformat:@"><%# Eval("ordbillno")%></td> 
 <td><%# Eval("dept")%></td>
 <td><%# Eval("memo")%></td>
 <td><%# Eval("old_ordbillno")%></td>
 <td><%# Eval("email")%></td>
 <td style="vnd.ms-excel.numberformat:@"><%# Eval("tellphone")%></td>
 <td><%# Eval("isdc")%></td>
                      
        </tr> 		
 	   </ItemTemplate>   
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"13\"><font color=red>暂无记录</font></td></tr>" : ""%>
   </tbody>
    </table>
</FooterTemplate>
</asp:Repeater> 


<br>    
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
    <p>
        &nbsp;</p>
    </form>
    </body>
</html>
