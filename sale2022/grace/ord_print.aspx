<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ord_print.aspx.cs" Inherits="ord_print" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title>打印订单窗口</title>
<script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript">
    //窗口API
    var api = frameElement.api, W = api.opener;
    api.button({
        name: '确认打印',
        focus: true,
        callback: function () {
            printWin();
        }
    }, {
        name: '取消'
    });
    //打印方法
    function printWin() {
        var oWin = window.open("", "_blank");
        oWin.document.write(document.getElementById("content").innerHTML);
        oWin.focus();
        oWin.document.close();
        oWin.print()
        oWin.close()
    }
</script>
    <style type="text/css">
        .auto-style4 {
            width: 118px;
        }
        .auto-style5 {
            width: 159px;
        }
        .auto-style6 {
            width: 25%;
        }
        .auto-style7 {
            height: 27px;
            width: 25%;
        }
        .auto-style8 {
            width: 30%;
        }
        .auto-style9 {
            height: 27px;
            width: 30%;
        }
    </style>
</head>

<body style="margin:0;">
<form id="form1" runat="server">
<div id="content">
<table width="800" border="0" align="center" cellpadding="3" cellspacing="0" style="font-size:12px; font-family:'微软雅黑'; background:#fff;">
<tr>
  <td height="50" style="font-size:20px;" class="auto-style4">安德鲁森<br />
      业务订单</td>
  <td class="auto-style5">订&nbsp; 单 号：<asp:Label ID="billno" runat="server" Text="Label"></asp:Label>
      <br />
下单时间：<asp:Label ID="lrdate" runat="server" Text="Label"></asp:Label>
      <br />
      提货时间：<asp:Label ID="thdate" runat="server" Text="Label"></asp:Label>
    </td>
  <td width="220">中&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 心：<asp:Label ID="cen" runat="server" Text="Label"></asp:Label>
      <br />
      店（组）：<asp:Label ID="dept" runat="server" Text="Label"></asp:Label>
      <br />业 务&nbsp; 员：<asp:Label ID="ywy" runat="server" Text="Label"></asp:Label>
    </td>
</tr>
<tr>
  <td colspan="3" style="padding:10px 0; border-top:1px solid #000;">
  <asp:Repeater ID="rptList" runat="server">
      <HeaderTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="5" style="font-size:12px; font-family:'微软雅黑'; background:#fff;">
          <tr>
           <td width="18%" align="left" style="background:#ccc;">商品编码</td>
               <td width="18%" align="left" style="background:#ccc;">商品名称</td>
            <td align="left" style="background:#ccc;">价格</th>
            <td width="12%" align="left" style="background:#ccc;">数量</td>
            <td width="10%" align="left" style="background:#ccc;">单位</td>
                  <td width="10%" align="left" style="background:#ccc;">应收金额</td>
                   <td width="10%" align="left" style="background:#ccc;">折扣</td>
            <td width="12%" align="left" style="background:#ccc;">实收金额</td>
          </tr>
      </HeaderTemplate>
      <ItemTemplate>
          <tr>
            
            <td><%#Eval("商品编码")%></td>
            <td><%#Eval("商品名称")%></td>
            <td><%#Eval("价格")%></td>
                <td><%#Eval("数量")%></td>
            <td><%#Eval("单位")%></td>
            <td><%#Eval("应收")%></td>
                  <td><%#Eval("折扣")%></td>
               <td><%#Eval("实收")%></td>
          
          </tr>
      </ItemTemplate>
      <FooterTemplate>
            <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"5\">暂无记录</td></tr>" : ""%>
          </table>
     </FooterTemplate>
  </asp:Repeater>
  </td>
  </tr>
<tr>
  <td colspan="3" style="border-top:1px solid #000;">
  <table width="100%" border="0" cellspacing="0" cellpadding="5" style="margin:5px auto; font-size:12px; font-family:'微软雅黑'; background:#fff;">
    <tr>
      <td class="auto-style8">
          客户名称：
          <asp:Label ID="custname" runat="server" Text="Label"></asp:Label>
      </td>
      <td class="auto-style6">联&nbsp; 系 人：<asp:Label ID="custbody" runat="server" Text="Label"></asp:Label>
          <br /></td>
         <td valign="top">付款方式：<asp:Label ID="fktype" runat="server" /></td>
    </tr>

    <tr>
      <td class="auto-style9">客户地址：<asp:Label ID="custaddr" runat="server" Text="Label"></asp:Label>
        </td>
      <td class="auto-style7">联系电话：<asp:Label ID="custtel" runat="server" Text="Label"></asp:Label>
        </td>
         <td valign="top">&nbsp;</td>
    </tr>
    <tr>
      <td valign="top" class="auto-style8">
          提货地址：
          <asp:Label ID="thaddr" runat="server" Text="Label"></asp:Label>
      </td>
    <td valign="top" class="auto-style6">开&nbsp; 票 否：<asp:Label ID="kp" runat="server" Text="Label"></asp:Label>
        </td>
         <td valign="top">&nbsp;</td>
    </tr>
    <tr>
      <td valign="top" colspan="3"><strong>备 注：<asp:Label ID="memo" runat="server" Text="Label"></asp:Label>
          </strong></td>
          
      
    </tr>
  </table>
    <table width="100%" border="0" align="center" cellpadding="5" cellspacing="0" style="border-top:1px solid #000; font-size:12px; font-family:'微软雅黑'; background:#fff;">
      <tr>
        <td align="right" style="text-align: left"><strong>审批：</strong><asp:Label ID="Label18" runat="server" Text="Label"></asp:Label>
      &nbsp;<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 审核：</strong><asp:Label ID="Label19" runat="server" Text="Label"></asp:Label>
      &nbsp; <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 业务员：</strong><asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
      &nbsp;</td>
      </tr>
    </table></td>
  </tr>
</table>
</div>
</form>
</body>
</html>