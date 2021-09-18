<%@ Page Language="C#" AutoEventWireup="true" CodeFile="xs_count.aspx.cs" Inherits="xs_count" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="../../My97DatePicker/WdatePicker.js"></script>
    <link rel="stylesheet" type="text/css" href="../../grace/jquery-easyui-1.6.7/themes/default/easyui.css"/>
	<link rel="stylesheet" type="text/css" href="../../grace/jquery-easyui-1.6.7/themes/icon.css"/>
	<link rel="stylesheet" type="text/css" href="../../grace/jquery-easyui-1.6.7/demo.css"/>
	<script type="text/javascript" src="../../grace/jquery-easyui-1.6.7/jquery.min.js"></script>
	<script type="text/javascript" src="../../grace/jquery-easyui-1.6.7/jquery.easyui.min.js"></script>
    <title>查询商品销售单数</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <asp:Label ID="Label2" runat="server" Text="按条件查询："></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="门店编号："></asp:Label>
        <asp:DropdownList id="dr1" runat="server" AutoPostBack="True" class="easyui-combobox" name="state"  labelPosition="top" OnSelectedIndexChanged="dr1_SelectedIndexChanged" Width="140px" Height="30px"></asp:DropdownList>
        
        <asp:Label ID="Label4" runat="server" Text="开始时间："></asp:Label>
        <asp:TextBox ID="bgdate" runat="server" BorderColor="#00CCFF" BorderWidth="1px" Height="30px" onclick="WdatePicker()" OnTextChanged="TextBox1_TextChanged" Width="100px"></asp:TextBox>
        <asp:Label ID="Label5" runat="server" Text="结束时间："></asp:Label>
        <asp:TextBox ID="endate" runat="server" BorderColor="#00CCFF" BorderWidth="1px" Height="30px" onclick="WdatePicker()" OnTextChanged="TextBox1_TextChanged" Width="100px"></asp:TextBox>
        <asp:Label ID="Label6" runat="server" Text="商品编码："></asp:Label>
        <asp:DropdownList id="dr2" runat="server" AutoPostBack="True" class="easyui-combobox" name="state"  labelPosition="top" OnSelectedIndexChanged="dr1_SelectedIndexChanged" Width="140px" Height="30px"></asp:DropdownList>
        
        <asp:Button ID="Button1" runat="server" class="easyui-linkbutton" Text="查询" OnClick="Button1_Click" Height="30px" Width="100px" />
        
        <asp:Button ID="Button2" runat="server" class="easyui-linkbutton" OnClick="dc_Click" Text="导出Excel" Height="30px" Width="100px" />
        
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                        CellPadding="3" Font-Size="9pt"  BackColor="White"   BorderWidth="1px">
                        <Columns>                            
                            <asp:BoundField DataField="orgcode" HeaderText="门店编码" SortExpression="门店编码" />
                            <asp:BoundField DataField="xsdate" HeaderText="销售日期" SortExpression="销售日期"/>
                            <asp:BoundField DataField="plucode" HeaderText="商品编码" SortExpression="商品编码"/>
                            <asp:BoundField DataField="pluname" HeaderText="商品名称" SortExpression="商品名称"/>
                            <asp:BoundField DataField="jhcount" HeaderText="进货数量" SortExpression="进货数量"/>
                            <asp:BoundField DataField="dbout" HeaderText="调出数量" SortExpression="调出数量"/>
                            <asp:BoundField DataField="dbin" HeaderText="调入数量" SortExpression="调入数量"/>
                            <asp:BoundField DataField="mxs" HeaderText="最后一笔销售时间" SortExpression="最后一笔销售时间"/>
                            <asp:BoundField DataField="xsc" HeaderText="销售数量" SortExpression="销售数量"/>
                                
                        </Columns>
                    </asp:GridView>                    
    </div>
    </form>
</body>
</html>
