<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tes1.aspx.cs" Inherits="tes1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" http-equiv="refresh" content="60">
    <script src="../My97DatePicker/WdatePicker.js"></script>
    <script src="../js/jquery/jquery-1.10.2.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../js/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../js/swfupload/swfupload.queue.js"></script>
    <script type="text/javascript" src="../js/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <script type="text/javascript" src="../js/pinyin.js"></script>
    <link href="../css/style.css"  rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/datepicker/WdatePicker.js"></script>
    <link rel="stylesheet" type="text/css" href="../../grace/jquery-easyui-1.6.7/themes/default/easyui.css"/>
	<link rel="stylesheet" type="text/css" href="../../grace/jquery-easyui-1.6.7/themes/icon.css"/>
	<link rel="stylesheet" type="text/css" href="../../grace/jquery-easyui-1.6.7/demo.css"/>
	<script type="text/javascript" src="../../grace/jquery-easyui-1.6.7/jquery.min.js"></script>
	<script type="text/javascript" src="../../grace/jquery-easyui-1.6.7/jquery.easyui.min.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <style type="text/css">
        html, body {
            height: 100%;
            overflow: auto;
        }

        #tb1 {width:80%;
              border-collapse: collapse;text-align: center; border-color:#b6ff00; border-collapse: collapse;
        }
        .auto-style1 {
            height: 20px;
        }
    </style>
<title>Tes</title>
</head>
<body>
    <div id ="div1">
        <center>
        <h3>门店缴款表单</h3>
            <form id="ff" runat="server">
        <table id ="tb1" >
  <tr>
    <th>        
		<label for="orgcode">门店:</label>		
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </th>
    <th>
        <label for="xjtotal">现金应存款:</label>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label> 	
    </th>
    <th>        
		<label for="shuiguo">水果:</label>
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    </th>
  </tr>
  <tr>
    <th>        
		<label for="dudao">督导:</label>		
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>		
    </th>
    <th>
        <label for="pandian">盘点应存款:</label>
        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label> 
    </th>
    <th>        
		<label for="others">其他:</label>
        <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>		
    </th>
  </tr>
  <tr>
    <th class="auto-style1">        
		<label for="jingli">经理:</label>		
        <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>		
    </th>
    <th class="auto-style1">
        <label for="gongjiao">公交券赔款:</label>
        <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>		
    </th>
    <th class="auto-style1">        
		<label for="tuandan">团单:</label>
        <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>		
    </th>
  </tr>
</table>
            </form>
            </div>
</body>
</html>
