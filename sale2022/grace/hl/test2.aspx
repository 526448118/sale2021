<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test2.aspx.cs" Inherits="grace_hl_test2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../jquery-easyui-1.6.7/themes/default/easyui.css"/>
	<link rel="stylesheet" type="text/css" href="../jquery-easyui-1.6.7/themes/icon.css"/>
	<link rel="stylesheet" type="text/css" href="../jquery-easyui-1.6.7/demo.css"/>
	<script type="text/javascript" src="../jquery-easyui-1.6.7/jquery.min.js"></script>
	<script type="text/javascript" src="../jquery-easyui-1.6.7/jquery.easyui.min.js"></script>
    <script> $('#<%= dr1.ClientID%>').combobox({    
                 onChange: function (newValue, oldValue) {  
                       var count = $("#<%= dr1.ClientID%> option").length;    
                       var ddlFac = document.getElementById("<%= dr1.ClientID%>");                     
        for (var i = 0; i < count; i++) {                        
         if (ddlFac.options[i].value == newValue) {                            
                 __doPostBack('<%= dr1.ClientID%>', '');                            
                 break;                       
              }                   
         }                 
      }              
 }); 
       </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin:20px 0;">
		<a href="javascript:void(0)" class="easyui-linkbutton" onclick="setvalue()">SetValue</a>
		<a href="javascript:void(0)" class="easyui-linkbutton" onclick="alert($('#state').combobox('getValue'))">GetValue</a>
		<a href="javascript:void(0)" class="easyui-linkbutton" onclick="$('#state').combobox('disable')">Disable</a>
		<a href="javascript:void(0)" class="easyui-linkbutton" onclick="$('#state').combobox('enable')">Enable</a>
	</div>
        <div class="easyui-panel" style="width:100%;max-width:400px;padding:30px 60px;">
		<div style="margin-bottom:20px">
			<asp:DropdownList id="dr1" runat="server" AutoPostBack="True" class="easyui-combobox" name="state"  labelPosition="top" style="width:150px;" OnSelectedIndexChanged="dr1_SelectedIndexChanged">

			</asp:DropdownList>
		    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
		</div>
	</div>
    <div>
    
    </div>
    </form>
</body>
</html>
