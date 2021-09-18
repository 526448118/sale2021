<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ord_list_sw_dr.aspx.cs" Inherits="depotmanager_order_list" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server" http-equiv="refresh" content="60">
<title>未处理订单</title>

<link href="../css/style_sw.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
<script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/layout.js"></script>

</head>
<body>
    <form id="form1" runat="server">
	<div class="place">
    <span>位置:</span>
    <ul class="placeul">
    <li><a href="../home.aspx">首页</a></li>
    <li><a href="#">实物订单</a></li>
    <li><a href="ord_list_zfsq_cx.aspx"><strong><em>实物订单导入</em></strong></a></li>
    </ul>
    </div>  
    <div >
    <dl > 
    <dd>数据导入:
        <asp:FileUpload ID="FileUpload1" runat="server" Width="105px"  />
        <asp:Button ID="Button5" runat="server" onclick="Button5_Click" CssClass="scbtn" Text="上传数据" />
        &nbsp;
        <asp:Button ID="Button6" runat="server" onclick="Button6_Click" CssClass="scbtn" Text="删除数据" />
        &nbsp;
        <asp:Button ID="Button7" runat="server" onclick="Button7_Click" CssClass="scbtn" Text="保存数据" />
        &nbsp;<span>导入时间:</span>
            <asp:TextBox ID="bgndate" runat="server" Width="120" CssClass="scinput" onclick="WdatePicker()"></asp:TextBox>至<asp:TextBox ID="enddate" runat="server" Width="120" CssClass="scinput" onclick="WdatePicker()"></asp:TextBox>
          
        &nbsp;<asp:Button ID="lbtnSearch" runat="server" CssClass="scbtn" onclick="btnSearch_Click" Text="查询"></asp:Button>

     </dd>
        <dt>
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </dt>
     </dl>
      
    </div>
            <!--列表-->
        <div class="rightinfo">


    <div class="pagelist">

  <div id="PageContent" runat="server" class="default"> <li>
         <asp:GridView ID="GridView2" runat="server" AllowSorting="True" AutoGenerateColumns="False"                        
             CellPadding="3" Font-Size="9pt"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"   Height="149px" Width="1489px" OnRowDataBound="GridView1_RowDataBound" >
                <FooterStyle BackColor="White" ForeColor="#000066" />
                        <Columns>
	                    <asp:BoundField HeaderText="序号" >
		                <ItemStyle HorizontalAlign="Center" />		                
	                    </asp:BoundField>
                            <asp:BoundField DataField="num"            HeaderText="订单号"/>
                            <asp:BoundField DataField="xddate"                HeaderText="下单日期"/>
                            <asp:BoundField DataField="ywy"           HeaderText="业务员"/>                           
                            <asp:BoundField DataField="gycode"           HeaderText="雇员编码"/>
                            <asp:BoundField DataField="psdate"             HeaderText="提货日期"/>
                            <asp:BoundField DataField="pstime"              HeaderText="提货时间"/>
                            <asp:BoundField DataField="pluname"           HeaderText="商品名称"/>
                            <asp:BoundField DataField="plucode"                HeaderText="商品编码"/>
                            <asp:BoundField DataField="count"             HeaderText="数量"/> 
                            <asp:BoundField DataField="price"            HeaderText="单价"/>
                            <asp:BoundField DataField="zk"                HeaderText="折扣"/>
                            <asp:BoundField DataField="zqtotal"           HeaderText="折前金额"/>                           
                            <asp:BoundField DataField="zhtotal"           HeaderText="折后金额"/>
                            <asp:BoundField DataField="costom"             HeaderText="客户名称"/>
                            <asp:BoundField DataField="gyschl"             HeaderText="供应学校"/>
                            <asp:BoundField DataField="address"              HeaderText="地址"/>
                            <asp:BoundField DataField="lxr"              HeaderText="联系人"/>
                            <asp:BoundField DataField="lxrtel"              HeaderText="联系人电话"/>
                            <asp:BoundField DataField="memo"           HeaderText="备注"/>
                            <asp:BoundField DataField="status"                HeaderText="单据状态"/>
                            <asp:BoundField DataField="drdate"           HeaderText="导入时间"/>
                            <asp:BoundField DataField="gxdate"             HeaderText="更新时间"/>     
                            <asp:BoundField DataField="thtype"           HeaderText="提货类型"/>
                            <asp:BoundField DataField="lrstaff"             HeaderText="录入人"/>    
                            <asp:BoundField DataField="is_zy"             HeaderText="门店属性"/>                                                       
                        </Columns>
                        <RowStyle ForeColor="#000066" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Center" BackColor="#006699" Font-Bold="True" ForeColor="White" />
         </asp:GridView>
         <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                        CellPadding="3" Font-Size="9pt"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"   Height="149px" Width="1489px" OnRowDataBound="GridView1_RowDataBound" >
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <Columns>
	                    <asp:BoundField HeaderText="序号" >
		                <ItemStyle HorizontalAlign="Center" />
		                
	                    </asp:BoundField>
                            <asp:BoundField DataField="num"            HeaderText="订单号"/>
                            <asp:BoundField DataField="gxtime"                HeaderText="录入时间"/>
                            <asp:BoundField DataField="xdorgcode"           HeaderText="门店号"/>                           
                            <asp:BoundField DataField="xdorgname"           HeaderText="下单门店"/>
                            <asp:BoundField DataField="gyorg"           HeaderText="雇员编码"/>
                            <asp:BoundField DataField="jm"             HeaderText="性质"/>
                            <asp:BoundField DataField="thdate"              HeaderText="提货日期"/>
                            <asp:BoundField DataField="saler"             HeaderText="业务员"/>
                            <asp:BoundField DataField="thtime"           HeaderText="提货时间"/>
                            <asp:BoundField DataField="thtype"                HeaderText="提货方式"/>
                            <asp:BoundField DataField="plutype"           HeaderText="商品类型"/>
                            <asp:BoundField DataField="custname"             HeaderText="客户名称"/> 
                            <asp:BoundField DataField="th_address"            HeaderText="提货地址"/>
                            <asp:BoundField DataField="lrstaff"                HeaderText="录入人"/>
                            <asp:BoundField DataField="plucode"           HeaderText="商品编号"/>                           
                            <asp:BoundField DataField="pluname"           HeaderText="商品名称"/>
                            <asp:BoundField DataField="count"             HeaderText="数量"/>
                            <asp:BoundField DataField="price"             HeaderText="价格"/>
                            <asp:BoundField DataField="ystotal"              HeaderText="应收金额"/>
                            <asp:BoundField DataField="zk"              HeaderText="折扣"/>
                            <asp:BoundField DataField="sstotal"              HeaderText="实收金额"/>
                            <asp:BoundField DataField="com"           HeaderText="公司"/>
                            <asp:BoundField DataField="cust_body"                HeaderText="联系人"/>
                            <asp:BoundField DataField="cust_body_tel"           HeaderText="联系人电话"/>
                            <asp:BoundField DataField="memo"             HeaderText="备注"/>     
                            <asp:BoundField DataField="isdc"           HeaderText="是否导出"/>
                            <asp:BoundField DataField="last_dctime"             HeaderText="最后一次导出时间"/>    
                            <asp:BoundField DataField="dcn"             HeaderText="已导出次数"/>                                                       
                        </Columns>
                        <RowStyle ForeColor="#000066" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Center" BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
    
      </li></div>
</div>
      
    </div>
    </form>
</body>
</html>
