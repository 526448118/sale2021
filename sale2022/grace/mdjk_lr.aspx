<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mdjk_lr.aspx.cs" Inherits="admin_jk_lr01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <script src="../My97DatePicker/WdatePicker.js"></script>
      <script type="text/javascript"> 
          function me(id) {
              document.getElementById("HidTagId").value = id;
              document.getElementById("btnShow").click();
          }
      </script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>门店缴款</title>
    <style type="text/css">
        .auto-style1 {
            font-size: 40pt;
        }
        .auto-style2 {
            font-size: medium;
        }
        .auto-style7 {
            width: 85pt;
            color: black;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            background: white;
        }
        .auto-style8 {
            width: 80pt;
            color: black;
            font-size: smaller;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            background: #BFBFBF;
            height : 40px;
        }
        .auto-style29 {
            width: 105pt;
            color: black;
            font-size: 11.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            background: white;
            height: 40px;
        }
        </style>
</head>
<body>
    


    <form id="form1" runat="server">
            <asp:HiddenField ID="HidTagId" runat="server" Value="1"/>     
        <div style="display:none;">    
        <asp:Button ID="btnShow" Width="0" runat="server" Text="" OnClick="method" />     
        </div>
     <div align="center">
    
        <table border="0" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse;width:500pt; background-color: #33CCCC;">
            <colgroup>
                <col style="width: 71pt" width="95" />
            </colgroup>
            <tr height="36" style="height: 27.0pt">
                <td style="height: 27.0pt; color: #538ED5; font-size: 11.0pt; font-style: normal; text-decoration: none; font-family: 新宋体, monospace; text-align: general; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; background: #EAF1DD">
                    <asp:Image ID="Image2" runat="server" Height="98px" ImageUrl="admin/igm/logo.png" Width="97px" />
                    <span class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span> </td>
                <td style="height: 72px; font-style: normal; text-decoration: none; font-family: 新宋体, monospace; text-align: center; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; background: #EAF1DD" class="auto-style1">门店缴款单<asp:Label ID="Label1" runat="server" style="font-size: 6pt" Text="Label"></asp:Label>
                </td>
            </tr>
            </table>
         <hr>
         <table border="0" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse;width:683pt">
             <colgroup>
                 <col width="102" />
                 <col />
                 <col width="79" />
                 <col width="116" />
                 <col />
                 <col width="88" />
                 <col width="88" />
                 <col width="88" />
                 <col width="96" />
             </colgroup>
             <tr height="33">
                 <td class="auto-style8" height="33" style="border: thin inset #000000; padding: inherit; margin: auto" width="120">公 司：</td>
                 <td class="auto-style7" style="border: thin inset #000000; padding: inherit; margin: auto" width="86"><asp:Label ID="com" runat="server" style="text-align: center; font-weight: 700;" CssClass="auto-style2"></asp:Label>
                 </td>
                 <td class="auto-style8" style="border: thin inset #000000; padding: inherit; margin: auto">门店：</td>
                 <td class="auto-style29" style="border: thin inset #000000; padding: inherit; margin: auto" width="116"><asp:Label ID="storeno" runat="server" style="text-align: center; font-weight: 700;" CssClass="auto-style2"></asp:Label>
                     _<asp:Label ID="storename" runat="server" style="text-align: center; font-weight: 700;" CssClass="auto-style2"></asp:Label>
                 </td>
                 <td class="auto-style8" style="border: thin inset #000000; padding: inherit; margin: auto">选择欠款日期：</td>
                 <td class="auto-style7" style="border: thin inset #000000; padding: inherit; margin: auto">
                     <asp:TextBox ID="jkdate0" runat="server" CssClass="auto-style2" Height="90%" Width="95%" onclick="WdatePicker()"></asp:TextBox>
                     </td>
                 <td class="auto-style8" style="border: thin inset #000000; padding: inherit; margin: auto">单据状态：</td>
                 <td class="auto-style7" style="border: thin inset #000000; padding: inherit; margin: auto; ">
                     <asp:DropDownList ID="status" runat="server"  Height="30px" Width="98%" style="TEXT-ALIGN:center;font-size: medium">
                         <asp:ListItem Value="0">财务已导入</asp:ListItem>
                         <asp:ListItem Value="1">门店已录入</asp:ListItem>
                         <asp:ListItem Value="2">财务已审核</asp:ListItem>
                         <asp:ListItem Value="全部">全部</asp:ListItem>
                         <asp:ListItem Value="99">作废</asp:ListItem>
                     </asp:DropDownList>
                 </td>
                 <td class="auto-style8" >
                     <asp:Button ID="Button6" runat="server" Text="查询" Height="30px" style="text-align: center; font-size: x-large; font-weight: 700;" Width="70px" BorderStyle="None" OnClick="Button6_Click" ></asp:Button>
                 </td>
             </tr>
             </table>
         <p>
         </p>
         <table border="0" cellpadding="0" cellspacing="0" style="border-collapse:collapse;width:662pt">
             <tr>
                 <td class="auto-style8" style="border: thin inset #000000; padding: inherit; margin: auto">款项类型：</td>
                 <td style="border: thin inset #000000; padding: inherit; margin: auto" class="auto-style29">
                     <asp:Label ID="qktype" runat="server" style="text-align: center; font-weight: 700;" CssClass="auto-style2"></asp:Label>
                 </td>
                 <td class="auto-style8">应缴金额：</td>
                 <td class="auto-style29" style="border: thin inset #000000; padding: inherit; margin: auto">
                     <asp:Label ID="qktotal" runat="server" style="text-align: center; font-weight: 700;" CssClass="auto-style2"></asp:Label>
                 </td>
                 <td class="auto-style8" style="border: thin inset #000000; padding: inherit; margin: auto">欠款日期：</td>
                 <td class="auto-style29" style="border: thin inset #000000; padding: inherit; margin: auto">
                     <asp:Label ID="qkdate" runat="server" style="text-align: center; font-weight: 700;" CssClass="auto-style2"></asp:Label>
                 </td>
                 <td class="auto-style8" style="border: thin inset #000000; padding: inherit; margin: auto">财务导入人：</td>
                 <td class="auto-style29" style="border: thin inset #000000; padding: inherit; margin: auto">
                     <asp:Label ID="cw_lrr" runat="server" style="text-align: center; font-weight: 700;" CssClass="auto-style2"></asp:Label>
                     　</td>
             </tr>
             <tr>
                 <td class="auto-style8" style="border: thin inset #000000; padding: inherit; margin: auto">存款人(工号)：</td>
                 <td class="auto-style29" style="border: thin inset #000000; padding: inherit; margin: auto">
                     <asp:TextBox ID="ckrcode" runat="server"  Height="90%" OnTextChanged="jkrcode_TextChanged" style="TEXT-ALIGN:center;font-size: medium" AutoPostBack="True" Width="95%"></asp:TextBox>
                 </td>
                 <td class="auto-style8" style="border: thin inset #000000; padding: inherit; margin: auto">缴款金额：</td>
                 <td class="auto-style29" style="border: thin inset #000000; padding: inherit; margin: auto">
                     <asp:TextBox ID="jktotal" runat="server"  Height="90%" Width="95%" style="TEXT-ALIGN:center;font-size: medium"></asp:TextBox>
                     　</td>
                 <td class="auto-style8" style="border: thin inset #000000; padding: inherit; margin: auto">
                     实际缴款日期：</td>
                 <td class="auto-style29" style="border: thin inset #000000; padding: inherit; margin: auto">
                     <asp:TextBox ID="jkdate" runat="server"  Height="90%" Width="95%" onclick="WdatePicker()" style="TEXT-ALIGN:center;font-size: medium"></asp:TextBox>
                     </td>
                 <td class="auto-style8" style="border: thin inset #000000; padding: inherit; margin: auto">
                     </td>
                 <td class="auto-style29" style="border: thin inset #000000; padding: inherit; margin: auto">
                     </td>
             </tr>
             <tr>
                 <td class="auto-style8" style="border: thin inset #000000; padding: inherit; margin: auto">录入人(工号)：</td>
                 <td class="auto-style29" style="border: thin inset #000000; padding: inherit; margin: auto">
                     <asp:TextBox ID="lrrcode" runat="server"  Height="90%" style="TEXT-ALIGN:center;font-size: medium" AutoPostBack="True" OnTextChanged="lrrcode_TextChanged" Width="95%" ></asp:TextBox>
                 </td>
                 <td class="auto-style8" rowspan="2" style="border: thin inset #000000; padding: inherit; margin: auto">备<asp:Label ID="xuh" runat="server" Height="0px" Visible="False"></asp:Label>
                     注：</td>
                 <td colspan="5" rowspan="2" style="border: thin inset #000000; padding: inherit; margin: auto">
                     <asp:TextBox ID="jkmemo" runat="server" Height="98%" TextMode="MultiLine" Width="98%" style="font-size: medium"></asp:TextBox>
                     </td>
             </tr>
             <tr>
                 <td class="auto-style8" style="border: thin inset #000000; padding: inherit; margin: auto">银行：</td>
                 <td class="auto-style29" style="border: thin inset #000000; padding: inherit; margin: auto">
                     <asp:DropDownList ID="bank" runat="server"  Height="30px" Width="98%" style="TEXT-ALIGN:center;font-size: medium">
                     </asp:DropDownList>
                 </td>
             </tr>
             </table>
         <br>
         <asp:Button ID="Button2" runat="server" Text="保存" Height="38px" style="text-align: center; font-size: x-large; font-weight: 700;" Width="88px" BorderStyle="None" OnClick="Button2_Click"></asp:Button>
         &nbsp;&nbsp;
         <asp:Button ID="Button4" runat="server" Text="取消" Height="38px" style="text-align: center; font-size: x-large; font-weight: 700;" Width="88px" BorderStyle="None" OnClick="Button4_Click"></asp:Button>
         &nbsp;&nbsp;
         <asp:Button ID="Button5" runat="server" Text="返回主页" Height="38px" style="text-align: center; font-size: x-large; font-weight: 700;" Width="108px" BorderStyle="None" OnClick="Button5_Click"></asp:Button>
         <br />
&nbsp;
         <asp:GridView ID="GridView1" runat="server" Font-Size="Small" OnRowDataBound="GridView1_RowDataBound" style="z-index: 1; left: 10px; top: 378px; " UseAccessibleHeader="False" Width="1204px">

             <HeaderStyle BackColor="#CCCCCC" Font-Size="Small" />
         </asp:GridView>
    </div>

    </form>
</body>
</html>
