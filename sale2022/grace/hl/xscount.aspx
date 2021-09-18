<%@ Page Language="C#" AutoEventWireup="true" CodeFile="xscount.aspx.cs" Inherits="grace_hl_test11" EnableEventValidation = "false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
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
        请先选择公司：<asp:RadioButton ID="cd" runat="server" AutoPostBack="True" GroupName="1" OnCheckedChanged="a_CheckedChanged" Text="成都公司" />
        <asp:RadioButton ID="xm" runat="server" AutoPostBack="True" GroupName="1" OnCheckedChanged="a_CheckedChanged" Text="厦门公司" />
        <asp:RadioButton ID="fz" runat="server" AutoPostBack="True" GroupName="1" OnCheckedChanged="a_CheckedChanged" Text="福州公司" />
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
        
        <asp:Button ID="Button2" runat="server" class="easyui-linkbutton" OnClick="dc_Click" Text="全部导出Excel" Height="30px" Width="100px" />
        
        <br />
        ------------------------------------------------------------------------------------------------------------------------------------------------------<br />
        <asp:Label ID="Label7" runat="server" Text="共有" Visible="False"></asp:Label>
        <asp:Label ID="Label8" runat="server" Text="Label" Visible="False"></asp:Label>
        <asp:Label ID="Label9" runat="server" Text="条数据" Visible="False"></asp:Label>
        <asp:Label ID="Label12" runat="server"></asp:Label>
        &nbsp;<asp:Label ID="Label13" runat="server" Text="共含"></asp:Label>
        <asp:Label ID="Label14" runat="server"></asp:Label>
        <asp:Label ID="Label15" runat="server" Text="条流水"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                        CellPadding="3" Font-Size="9pt"  BackColor="White"   BorderWidth="1px" >
                        <Columns>                            
                            <asp:BoundField DataField="orgcode" HeaderText="门店编码" SortExpression="门店编码" />
                            <asp:BoundField DataField="xsdate" HeaderText="销售日期" SortExpression="销售日期"/>
                            <asp:BoundField DataField="plucode" HeaderText="商品编码" SortExpression="商品编码"/>
                            <asp:BoundField DataField="pluname" HeaderText="商品名称" SortExpression="商品名称"/>
                            <asp:BoundField DataField="price" HeaderText="商品单价" SortExpression="商品单价"/>
                            <asp:BoundField DataField="billcount" HeaderText="单据数量" SortExpression="单据数量"/>
                            <asp:BoundField DataField="xscount" HeaderText="销售数量" SortExpression="销售数量"/>
                            <asp:BoundField DataField="th" HeaderText="退单数量" SortExpression="退单数量"/>   
                        </Columns>
        <PagerTemplate>

        </PagerTemplate>
        </asp:GridView>  
        <asp:GridView ID="GridView2" runat="server"  AutoGenerateColumns="False"
                        CellPadding="3" Font-Size="9pt"  BackColor="White"   BorderWidth="1px" Height="0px" Visible="False" Width="419px" >
                        <Columns>                            
                            <asp:BoundField DataField="orgcode" HeaderText="门店编码" SortExpression="门店编码" />
                            <asp:BoundField DataField="xsdate" HeaderText="销售日期" SortExpression="销售日期"/>
                            <asp:BoundField DataField="plucode" HeaderText="商品编码" SortExpression="商品编码"/>
                            <asp:BoundField DataField="pluname" HeaderText="商品名称" SortExpression="商品名称"/>
                            <asp:BoundField DataField="price" HeaderText="商品单价" SortExpression="商品单价"/>
                            <asp:BoundField DataField="billcount" HeaderText="单据数量" SortExpression="单据数量"/>
                            <asp:BoundField DataField="xscount" HeaderText="销售数量" SortExpression="销售数量"/>
                            <asp:BoundField DataField="th" HeaderText="退单数量" SortExpression="退单数量"/>      
                        </Columns>
        <PagerTemplate>

        </PagerTemplate>
        </asp:GridView>  
                    <br />
        共<asp:Label ID="Label10" runat="server" Text="0"></asp:Label>
        页，当前为第<asp:Label ID="Label11" runat="server" Text="0"></asp:Label>
        页&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:Button ID="firstpage" class="easyui-linkbutton" runat="server" Text="首页" OnClick="first_Click" />
        <asp:Button ID="lpage" class="easyui-linkbutton" runat="server" Text="上一页" OnClick="l_Click" />
        <asp:Button ID="npage" class="easyui-linkbutton" runat="server" Text="下一页" Height="21px" OnClick="n_Click" />
        <asp:Button ID="lastpage" class="easyui-linkbutton" runat="server" Text="尾页" OnClick="last_Click" />
        转到第
        <asp:TextBox ID="TextBox1"  onkeypress="if (event.keyCode < 48 || event.keyCode >57) event.returnValue = false;" runat="server" Width="29px"></asp:TextBox>
        页 
        <asp:Button ID="jp" class="easyui-linkbutton" runat="server" Text="Go" OnClick="jp_Click" />
    </div>
    </form>
</body>
</html>
