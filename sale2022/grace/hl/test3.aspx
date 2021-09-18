<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test3.aspx.cs" Inherits="grace_hl_test3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <script src="../My97DatePicker/WdatePicker.js"></script>
        <script src="../js/jquery/jquery-1.10.2.min.js"></script>
        <script src="../js/bootstrap.min.js"></script>
        <script type="text/javascript" src="../js/datepicker/WdatePicker.js"></script>
        <link rel="stylesheet" type="text/css" href="jquery-easyui-1.6.7/themes/default/easyui.css"/>
        <link rel="stylesheet" type="text/css" href="jquery-easyui-1.6.7/themes/icon.css"/>
        <link rel="stylesheet" type="text/css" href="jquery-easyui-1.6.7/demo.css"/>
        <script type="text/javascript" src="jquery-easyui-1.6.7/jquery.min.js"></script>
        <script type="text/javascript" src="jquery-easyui-1.6.7/jquery.easyui.min.js"></script>           
        <script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
        <script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
        <script type="text/javascript" src="../js/jquery/Validform_v5.3.2_min.js"></script>
        <script type="text/javascript" src="../js/swfupload/swfupload.js"></script>
        <script type="text/javascript" src="../js/swfupload/swfupload.queue.js"></script>
        <script type="text/javascript" src="../js/swfupload/swfupload.handlers.js"></script>
        <script type="text/javascript" src="../js/layout.js"></script>
        <script type="text/javascript" src="../js/pinyin.js"></script>
        <link href="../css/style.css" rel="stylesheet" type="text/css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>demo</title>  

    <script type="text/javascript">
        window.onload = function () {
            document.getElementById("DropDownList1").focus();
            var WshShell = new ActiveXObject("Wscript.Shell");
            try {
                WshShell.SendKeys("%{DOWN}");
            } catch (e) { }
            WshShell.Quit;
        }
        </script>
</head>

<body>

<form id ="form1" runat ="server">
    <asp:TextBox ID="TextBox1" runat="server" style="width: 150px;  position: absolute" AutoPostBack="true" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
    <asp:DropDownList ID="DropDownList1" runat="server" onchange="document.getElementById('TextBox1').value=this.options[this.selectedIndex].value"  style="width: 170px; clip: rect(auto auto auto 160px); " >         
    </asp:DropDownList>
</form>

</body>
</html>