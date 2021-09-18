<%@ Page Language="C#" AutoEventWireup="true" CodeFile="plucode2.aspx.cs" Inherits="grace_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
    <link href="../css/style.css" rel="stylesheet" type="text/css"/>
    <title>开票商品编辑</title>

<style type="text/css">

*{border-style: none;
    border-color: inherit;
    border-width: 0;
    font-size:small;
    padding:0;
    margin-left: 0;
    margin-right: 0;
}

table{border-collapse:collapse;border-spacing: 0;}       
    
    .input.normal{ width:300px;}
	.input.normal{ text-align: left;}
	.input{ padding:5px 4px; min-height:20px; line-height:20px; border:1px solid #d4d4d4; background:#fff; vertical-align:middle; color:#333; font-size:100%; }	    
        .auto-style1 {
            height: 35px;
            color: black;
            font-size: 10pt;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            vertical-align: middle;
            text-align: center;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            width: 110px;
        }
         .auto-style2 {
             height: 45pt;
            width: 770px;
            color: black;
            font-size: x-large;
            font-weight: 700;
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
        }       
       textarea{ overflow:auto; }
    </style>
</head>
<body style="height: 452px; text-align: center">
    <form id="form1" runat="server">
        <table border="0" style="border-collapse: collapse;width:700pt; height: 113px;">
            <tr>
                <td class="auto-style2" colspan="7">商品税收编码录入</td>
            </tr>
            <tr>
                <td class="auto-style1">商品名</td>
                <td class="auto-style1">税收编码</td>
                <td class="auto-style1">税收编码版本</td>
                <td class="auto-style1">税率</td>
                <td class="auto-style1">备注</td>
                <td class="auto-style1"></td>
                <td class="auto-style1">批量上传</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:TextBox ID="pluname" runat="server" class="easyui-textbox" BorderColor="#00CCFF" BackColor="#DDFFFF" BorderStyle="Double" Width="90%" ></asp:TextBox>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="s_code" runat="server" class="easyui-textbox"  BorderColor="#00CCFF" BackColor="#DDFFFF" BorderStyle="Double" Width="90%" ></asp:TextBox>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="s_code_ver" runat="server" class="easyui-textbox" BorderColor="#00CCFF" BackColor="#DDFFFF" BorderStyle="Double" Width="90%" ></asp:TextBox>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="shuilv" runat="server" class="easyui-textbox" BorderColor="#00CCFF" BackColor="#DDFFFF" BorderStyle="Double" Width="90%" ></asp:TextBox>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="memo" runat="server" class="easyui-textbox" BorderColor="#00CCFF" BackColor="#DDFFFF" BorderStyle="Double" Width="90%" ></asp:TextBox>
                </td>
                <td class="auto-style1">
                    <asp:Button ID="Button1" runat="server"  Text="点击添加" class="easyui-linkbutton" height ="95%"  Width="90%" OnClick="Button1_Click" />
                </td>
            <%--<td class="auto-style1">
                    <asp:FileUpload ID="FileUpload1" class="easyui-filebox" buttonText="选择文件" buttonAlign ="left" runat="server" BorderWidth="1px" height ="95%" Width="90%" />                    
                </td>--%>
                 <td class="auto-style1">
                    <asp:FileUpload ID="FileUpload1" class="easyui-filebox" buttonText="" buttonAlign ="left" runat="server" BorderWidth="1px" height ="95%" Width="160px" />                    
                </td>

            </tr>
            <tr>
                <td class="auto-style1">
                     <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" Font-Size="9pt" OnCheckedChanged="CheckBox2_CheckedChanged" Text="全选" />
                    <asp:Button ID="Button2" runat="server" class="easyui-linkbutton" height ="95%"  Width="50%"  Text="删除选中"  OnClientClick="javascript:return confirm('确定要删除吗?');" OnClick="Button2_Click" />
                </td>
                <td class="auto-style1">
                    <asp:Button ID="Button3" runat="server" class="easyui-linkbutton" height ="95%"  Width="40%"  Text="更新"  Enabled = "false" OnClick="Button3_Click" />
                    <asp:Button ID="Button4" runat="server" class="easyui-linkbutton" height ="95%"  Width="40%"  Text="取消"  Enabled = "false" OnClick="Button4_Click" />
                </td>
                <td class="auto-style1"></td>
                <td class="auto-style1"></td>
                <td class="auto-style1"></td>
                <td class="auto-style1">
                    <a id="btn" href="/grace/uploadfiles/m/税收编码模板.xlsx" class="easyui-linkbutton"    data-options="iconCls:'icon-tip'">模板下载</a>
                </td>
                <td class="auto-style1">
                   <asp:Button ID="Button5" runat="server" class="easyui-linkbutton" height ="95%"  Width="90%"  Text="确定上传" onclick="Button5_Click" /></td>
            </tr>
            <tr>
                <td class="auto-style1">商品搜索</td>
                <td class="auto-style1">
                    <asp:TextBox ID="pluname0" runat="server" class="easyui-textbox" BackColor="#DDFFFF" BorderStyle="Double" Width="90%" ></asp:TextBox>
                </td>
                <td class="auto-style1">
                    <asp:Button ID="Button6" runat="server"  class="easyui-linkbutton"  Text="搜索" height ="95%"  Width="90%" OnClick="Button0_Click" />
                </td>
                <td class="auto-style1"></td>
                <td class="auto-style1" colspan="3"></td>
            </tr>
               </table>
        <br />
        <br />
    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                        CellPadding="3" Font-Size="9pt"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Height="149px" width ="930">
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <Columns>
                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="com"              HeaderText="公司"/>
                            <asp:BoundField DataField="type"             HeaderText="商品名"/>
                            <asp:BoundField DataField="s_code"           HeaderText="税收编码"/>
                            <asp:BoundField DataField="shuilv"           HeaderText="税率"/>
                            <asp:BoundField DataField="s_code_ver"       HeaderText="税收编码版本号"/>                           
                            <asp:BoundField DataField="gxtime"           HeaderText="更新时间"/>
                            <asp:BoundField DataField="memo"             HeaderText="备注"/>   
                              <asp:TemplateField HeaderText ="编辑">
                                <ItemTemplate>
                                    <asp:LinkButton ID="ButtonEdit" runat="server" Text ="编辑" OnClick="btnDown_Click" CommandArgument='<%# Bind("type") %>'></asp:LinkButton>
                                </ItemTemplate>   
                              </asp:TemplateField>                                                         
                        </Columns>
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
    
    </form>

</body>
</html>
