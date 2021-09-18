<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ord_list_zfsq_cx.aspx.cs" Inherits="depotmanager_order_list" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server" http-equiv="refresh" content="60">
<title>未处理订单</title>

<link href="../css/style_sw.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
<script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<script type="text/javascript">

    function opdg(s_type, s_url) {
        var t_width, t_height, t_title, t_url, t_id;
        t_id = 'w_1';
        switch (s_type) {
            case 'info':
                t_width = 1080;
                t_height = 560;
                t_title = '查看订单详情';
                t_url = s_url;
                break;
        }
        $.dialog({
            width: t_width,
            height: t_height,
            title: t_title,
            max: false,
            content: 'url:' + t_url
        });
    } 
</script> 
</head>
<body>
    <form id="form1" runat="server">
	<div class="place">
    <span>位置:</span>
    <ul class="placeul">
    <li><a href="../home.aspx">首页</a></li>
    </ul>
        <p>
            &nbsp;</p>
    </div>  
    <div class="rightinfo">
    <dl class="seachform"> 
    <dd>
        <label>   
        <span>
        申请作废时间</span>：</label><span class="single-select"><asp:TextBox ID="bgndate" runat="server" Width="120" CssClass="scinput" onclick="WdatePicker()"></asp:TextBox>至<asp:TextBox ID="enddate" runat="server" Width="120" CssClass="scinput" onclick="WdatePicker()"></asp:TextBox></span></dd>
	

     <dd>&nbsp;</dd>
   
     
         <asp:Button ID="lbtnSearch" runat="server" CssClass="scbtn" onclick="btnSearch_Click" Text="查询"></asp:Button>
        </dd>

    </dl>
            <!--列表-->


    <div class="pagelist">

  <div id="PageContent" runat="server" class="default">
      <asp:GridView ID="GridView1" runat="server" Width="805px">
          <RowStyle HorizontalAlign="Center" />
      </asp:GridView>
        </div>
</div>
      
    </div>
    </form>
</body>
</html>
