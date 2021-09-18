<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs"%>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="../../My97DatePicker/WdatePicker.js"></script>
    <link rel="stylesheet" type="text/css" href="../../grace/jquery-easyui-1.6.7/themes/default/easyui.css"/>
	<link rel="stylesheet" type="text/css" href="../../grace/jquery-easyui-1.6.7/themes/icon.css"/>
	<link rel="stylesheet" type="text/css" href="../../grace/jquery-easyui-1.6.7/demo.css"/>
	<script type="text/javascript" src="../../grace/jquery-easyui-1.6.7/jquery.min.js"></script>
	<script type="text/javascript" src="../../grace/jquery-easyui-1.6.7/jquery.easyui.min.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

    <div>
        
        <asp:Label ID="Label2" runat="server" Text="按条件查询："></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="门店编号："></asp:Label>
        <asp:DropdownList id="dr1" runat="server" AutoPostBack="True" class="easyui-combobox" name="state"  labelPosition="top" OnSelectedIndexChanged="dr1_SelectedIndexChanged" Width="140px"></asp:DropdownList>
        
        <asp:Label ID="Label4" runat="server" Text="开始时间："></asp:Label>
        <asp:TextBox ID="tb_month" runat="server" BorderColor="#00CCFF" BorderWidth="1px" Height="97%" onclick="WdatePicker()" OnTextChanged="TextBox1_TextChanged" Width="100px"></asp:TextBox>
        <asp:Label ID="Label5" runat="server" Text="结束时间："></asp:Label>
        <asp:TextBox ID="tb_month0" runat="server" BorderColor="#00CCFF" BorderWidth="1px" Height="97%" onclick="WdatePicker()" OnTextChanged="TextBox1_TextChanged" Width="100px"></asp:TextBox>
        <asp:Label ID="Label6" runat="server" Text="商品编码："></asp:Label>
        <asp:DropdownList id="dr2" runat="server" AutoPostBack="True" class="easyui-combobox" name="state"  labelPosition="top" OnSelectedIndexChanged="dr1_SelectedIndexChanged" Width="140px"></asp:DropdownList>
        
        <asp:Button ID="Button1" runat="server" class="easyui-linkbutton" Text="Button" OnClick="Button1_Click" />
        
    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                        CellPadding="3" Font-Size="9pt"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <Columns>                            
                            <asp:BoundField DataField="门店编码" HeaderText="门店编码"   SortExpression="门店编码" />
                            <asp:BoundField DataField="销售日期" HeaderText="销售日期" SortExpression="销售日期"/>
                            <asp:BoundField DataField="商品编码" HeaderText="商品编码" SortExpression="商品编码"/>
                            <asp:BoundField DataField="商品名称" HeaderText="商品名称" SortExpression="商品名称"/>
                            <asp:BoundField DataField="进货数量" HeaderText="进货数量" SortExpression="进货数量"/>
                            <asp:BoundField DataField="调出数量" HeaderText="调出数量" SortExpression="调出数量"/>
                            <asp:BoundField DataField="调入数量" HeaderText="调入数量" SortExpression="调入数量"/>
                            <asp:BoundField DataField="最后一笔销售时间" HeaderText="最后一笔销售时间" SortExpression="最后一笔销售时间"/>
                            <asp:BoundField DataField="销售数量" HeaderText="销售数量" SortExpression="销售数量"/>
                                
                        </Columns>
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>                    
    </div>
    </form>
</body>
</html>
