<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sw_dc_his.aspx.cs" Inherits="grace_sw_dc_his" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div><strong>导出历史查询：</strong></div>
        <div>单据号：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Height="22px" OnClick="Button1_Click" style="font-weight: 700" Text="查询" Width="65px" />
        </div>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
