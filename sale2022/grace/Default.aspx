<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="grace_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript">
    function PlayMedia()
{
    var mediaPlugin = document.getElementById("MediaPlayer");
    mediaPlugin.controls.play();
}
function PauseMedia()
{
    var mediaPlugin = document.getElementById("MediaPlayer");
    mediaPlugin.controls.pause();
}
        </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Button" />

        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
        <asp:TextBox ID="Textbox" runat="server"></asp:TextBox>

    &nbsp;&nbsp;

        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="提示音" />

    </div>
    </form>

</body>
</html>
