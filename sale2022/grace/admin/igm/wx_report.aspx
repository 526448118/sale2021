<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wx_report.aspx.cs" Inherits="admin_ms_main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="../My97DatePicker/WdatePicker.js"></script>
<!-- <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/> -->
     <meta http-equiv="refresh" content="600; url=ms_main.aspx"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: 30pt;
            color: #003300;
        }
        .auto-style2 {
            font-size: 10pt;
        }
        .auto-style3 {
            font-size: smaller;
        }
        .auto-style6 {
            font-size: smaller;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
    
        <table border="0" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse;width:667pt; background-color: #33CCCC;">
            <colgroup>
                <col style="width: 71pt" width="95" />
            </colgroup>
            <tr height="36" style="height: 27.0pt">
                <td style="height: 27.0pt; color: #538ED5; font-size: 11.0pt; font-style: normal; text-decoration: none; font-family: 新宋体, monospace; text-align: general; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; background: #EAF1DD">
                    <asp:Image ID="Image2" runat="server" Height="98px" ImageUrl="~/admin/igm/logo.png" Width="97px" CssClass="auto-style2" />
                    <span class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span> </td>
                <td style="height: 72px; font-style: normal; text-decoration: none; font-family: 新宋体, monospace; text-align: center; vertical-align: middle; white-space: nowrap; border: .5pt solid windowtext; padding-left: 1px; padding-right: 1px; padding-top: 1px; background: #EAF1DD" class="auto-style1"><strong>门店提报信息采集</strong></td>
            </tr>
            </table>
    
    </div>
         <div>
    
        &nbsp;&nbsp;<span class="auto-style4">
    
        <span class="auto-style3">提报日期： </span> </span> 
        <asp:TextBox ID="bgndate" runat="server" CssClass="auto-style3" onclick="WdatePicker()" Width="116px"></asp:TextBox>
        <span class="auto-style3">&nbsp;到 </span> <asp:TextBox ID="enddate" runat="server" CssClass="auto-style3" onclick="WdatePicker()" Width="116px"></asp:TextBox>
        &nbsp&nbsp&nbsp&nbsp
             <asp:DropDownList ID="country" runat="server"></asp:DropDownList>
             <span class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp; </span> <asp:RadioButton ID="type1" runat="server" GroupName="1" Text="已结案" CssClass="auto-style3"  />
             <span class="auto-style3">&nbsp&nbsp&nbsp  </span>  <asp:RadioButton ID="type2" runat="server" GroupName="1" Text="未结案" CssClass="auto-style3" />
                    <span class="auto-style3">&nbsp;&nbsp;&nbsp;&nbsp;  </span>  <asp:RadioButton ID="type3" runat="server" GroupName="1" Text="全部" CssClass="auto-style3" />
                    &nbsp;
        <asp:Button ID="Button4" runat="server" Height="26px" OnClick="Button4_Click" Text="导出excel" Width="75px" CssClass="auto-style4" BorderStyle="None" style="font-size: smaller" />
                    &nbsp;<asp:Button ID="Button5" runat="server" Height="26px" OnClientClick="window.open('../grace/device_info.aspx');" Text="查看设备安装记录" Width="119px" CssClass="auto-style4" BorderStyle="None" style="font-size: smaller" />
                    &nbsp;<asp:Label ID="recordCount" runat="server" style="font-size: smaller"></asp:Label>
                    &nbsp;<span class="auto-style6">点击提报人，可查看更详细！</span><br class="auto-style3" /> <hr>
             <span class="auto-style3">&nbsp;&nbsp;
        内容：</span><asp:TextBox ID="mem" runat="server" CssClass="auto-style5" Width="261px" style="font-size: smaller"></asp:TextBox>
        <span class="auto-style3">&nbsp;&nbsp;
        </span>
        <asp:Button ID="Button1" runat="server" Height="28px" Text="查询" Width="73px" CssClass="auto-style4" OnClick="Button1_Click" BorderStyle="None" style="font-size: smaller" />
        <span class="auto-style4"><span class="auto-style3">&nbsp;<asp:CheckBox ID="CheckBox1" runat="server" Text="未解决" />
             &nbsp;&nbsp;<asp:CheckBox ID="wx" runat="server" Text="供应商外修未结案" />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </span>
        <asp:Button ID="Button3" runat="server" BorderStyle="None" Height="28px" OnClick="Button3_Click" Text="返回主页" Width="68px" CssClass="auto-style3" Font-Size="Smaller" />
             <span class="auto-style3">&nbsp;&nbsp;&nbsp;
        </span>
        </span>
        <asp:Button ID="Button2" runat="server" Height="26px" OnClick="Button2_Click" Text="关闭" Width="58px" CssClass="auto-style4" BorderStyle="None" style="font-size: smaller" />
        &nbsp;<asp:Button ID="Button6" runat="server" Height="26px" OnClientClick="window.open('../grace/lqplu_info.aspx');" Text="临期商品" Width="69px" CssClass="auto-style4" BorderStyle="None" style="font-size: smaller" />
                    &nbsp;<br />
        </div>
        <div  style="margin-left:20px"> 
        <asp:GridView ID="GridView1" runat="server" style="text-align: center" UseAccessibleHeader="False" OnRowDataBound="GridView1_RowDataBound">
            <FooterStyle Font-Size="Smaller" />
            <HeaderStyle BackColor="#66FF99" Font-Size="Smaller" />
            <RowStyle Font-Size="Smaller" />
        </asp:GridView>
            </div>
    </form>
</body>
</html>
