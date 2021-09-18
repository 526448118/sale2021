<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AjaxEngine.Demo._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="position: absolute; width: 300px; display: none; right: 5px; top: 5px; background-color: Black; color: White; padding: 5px;" id="loading">
        正在载入...
    </div>
    <div>
        <asp:Button ID="Button1" runat="server" Text="我是Asp.net Button" OnClick="Button1_Click" />
        <input style="" id="Button2" type="button" value="Html Button 调用页面方法" onclick="return Button2_onclick()" /><input id="Button3" type="button" value="Html Button 调用AjaxHandler方法" onclick="return Button3_onclick()" /></div>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Calendar ID="Calendar16" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
        ForeColor="#663399" Height="291px" ShowGridLines="True" Width="309px">
        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
        <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
        <OtherMonthDayStyle ForeColor="#CC9966" />
        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
        <SelectorStyle BackColor="#FFCC66" />
        <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
        <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
    </asp:Calendar>
    <asp:ListBox ID="ListBox1" runat="server" Height="153px" SelectionMode="Multiple" Width="305px">
        <asp:ListItem>a</asp:ListItem>
        <asp:ListItem>b</asp:ListItem>
        <asp:ListItem>c</asp:ListItem>
        <asp:ListItem>d</asp:ListItem>
        <asp:ListItem>e</asp:ListItem>
        <asp:ListItem></asp:ListItem>
    </asp:ListBox>
    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Button" />
    <asp:BulletedList ID="BulletedList1" runat="server">
        <asp:ListItem>a</asp:ListItem>
        <asp:ListItem>b</asp:ListItem>
        <asp:ListItem>c</asp:ListItem>
    </asp:BulletedList>
    </form>
    <script type="text/javascript" src="https://raw.github.com/Houfeng/ems/master/src/ems.min.js"></script>
    <script type="text/javascript">
<!--

        function Button2_onclick() {
            var t = Server.Add(1, 2, function (rs) {
                alert(rs);
            });
        };

        function Button3_onclick() {
            ems.load(['Handler1.ashx?client-script=core,agent'], function (Handler1) {
                Handler1.crossDomain = true;
                alert(Handler1.add({ t1: 1, t2: 2 }).t2);
            });
        };
        AjaxEngine.onRequestBegin = function () {
            $("#loading").show();
        };
        AjaxEngine.onRequestEnd = function () {
            $("#loading").hide();
        };
// -->
    </script>
    <!--script src="Handler1.ashx?client-script=core,agent"></script-->
</body>
</html>
