<%@ Page Language="C#" AutoEventWireup="true" CodeFile="1111.aspx.cs" Inherits="depotmanager_order_list" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<script src="../My97DatePicker/WdatePicker.js"></script>
    <title></title>
    <style type="text/css">
        .scinput {}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
	<div class="place">
    <ul class="placeul">
    <li><a href="home.aspx">首页</a></li>
    <li><a href="#">开票申请导出：</a></li>
    </ul>
    </div>
    <div class="rightinfo">
        <dl class="seachform">
            <dd>
                <label>开始日期：</label><asp:TextBox ID="bgndate" runat="server" Width="73px" CssClass="scinput" onclick="WdatePicker()"></asp:TextBox>
                <label>结束日期：</label><asp:TextBox ID="enddate" runat="server" Width="72px" CssClass="scinput" onclick="WdatePicker()"></asp:TextBox>
                <label>订单号：<asp:TextBox ID="num" runat="server" Width="72px"></asp:TextBox>
&nbsp;</label><label>客户名称：<asp:TextBox ID="num0" runat="server" Width="72px"></asp:TextBox>
                业务员：  </label><asp:TextBox ID="ywy" runat="server" Width="72px" CssClass="scinput"></asp:TextBox>    
                <asp:Button ID="lbtnSearch" runat="server" CssClass="scbtn" onclick="btnSearch_Click" Text="查询"></asp:Button>
            </dd>
            <li>
                     <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" Font-Size="9pt" OnCheckedChanged="CheckBox2_CheckedChanged"
                        Text="全选" />
                    &nbsp;<asp:Button ID="Button1" runat="server" Font-Size="9pt" Text="取消全选" OnClick="Button1_Click" />
                    &nbsp;&nbsp;<asp:Button ID="Button3" runat="server" Font-Size="9pt" Text="导出" OnClick="Button4_Click" />
            </li>

    </dl>
    </div>
    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                        CellPadding="3" Font-Size="9pt"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <Columns>
                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="num"             HeaderText="订单号"/>
                            <asp:BoundField DataField="lrtime"          HeaderText="录入时间"/>
                            <asp:BoundField DataField="ordbillno"       HeaderText="单据号"/>                           
                            <asp:BoundField DataField="com"             HeaderText="公司"/>
                            <asp:BoundField DataField="shuihao"         HeaderText="税号"/>
                            <asp:BoundField DataField="address"         HeaderText="地址电话"/> 
                            <asp:BoundField DataField="bank_acc"        HeaderText="银行账号"/>
                            <asp:BoundField DataField="pluname"         HeaderText="商品名称"/>
                            <asp:BoundField DataField="plumodel"        HeaderText="规格型号"/>
                            <asp:BoundField DataField="pluunit"         HeaderText="计量单位"/>
                            <asp:BoundField DataField="plucount"        HeaderText="数量"/>
                            <asp:BoundField DataField="sstotal"         HeaderText="实收金额"/>
                            <asp:BoundField DataField="memo"            HeaderText="备注"/>
                            <asp:BoundField DataField="dept"            HeaderText="门店名"/>
                            <asp:BoundField DataField="email"           HeaderText="电子发票（电子邮箱）"/>
                            <asp:BoundField DataField="tellphone"       HeaderText="电子发票（公司电话）"/> 
                            <asp:BoundField DataField="isdc"            HeaderText="是否已导出"/>                                                                   
                        </Columns>
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
    </div>
        <asp:GridView ID="GridView2" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
