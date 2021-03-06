<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ord_info.aspx.cs" Inherits="ord_info" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" http-equiv="refresh" content="60">
 <title>打印订单窗口</title>
<script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    //窗口API
    var api = frameElement.api, W = api.opener;
    api.button({
        name: '确认打印',
        focus: true,
        callback: function () {
            printWin();
        }
    }, {
        name: '取消'
    });
    //打印方法
    function printWin() {
        var oWin = window.open("", "_blank");
        oWin.document.write(document.getElementById("content").innerHTML);
        oWin.focus();
        oWin.document.close();
        oWin.print()
        oWin.close()
    }
    //局部打印
    function printView(id)
    {
    var sprnhtml = $(id).outerHTML; 
    var selfhtml = window.document.body.innerHTML;//获取当前页的html   
    window.document.body.innerHTML = sprnhtml; 
    window.print();   
    window.document.body.innerHTML = selfhtml;
    window.location.reload();
    }
    function preview(oper) {
        if (oper < 10) {
            bdhtml = window.document.body.innerHTML;//获取当前页的html代码 
            sprnstr = "<!--startprint" + oper + "-->";//设置打印开始区域 
            eprnstr = "<!--endprint" + oper + "-->";//设置打印结束区域 
            prnhtml = bdhtml.substring(bdhtml.indexOf(sprnstr) + 18); //从开始代码向后取html 

            prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));//从结束代码向前取html 
            window.document.body.innerHTML = "<body>" + prnhtml + "</body>";
            window.print();
            window.document.body.innerHTML = bdhtml;
        }
        else {
            window.print();
        }
    }
    function doPrint() {
        bdhtml = window.document.body.innerHTML;
        sprnstr = "<!--startprint-->";
        eprnstr = "<!--endprint-->";
        prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
        prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
        window.document.body.innerHTML = prnhtml;
        var obj = window.document.body;
        doZoom(obj, 18); //放大打印
        window.print();
        window.location.reload();
    }
    function doZoom(artibody, size) {
        if (!artibody) {
            return;
        }
        setChildNodesByCurrentNode(artibody, size);
    }
    function setChildNodesByCurrentNode(node, size) {
        for (var i = 0; i < node.childNodes.length; i++) {
            var artibodyChild = node.childNodes[i];
            if (artibodyChild.nodeType == 1) {
                artibodyChild.className = "";
                artibodyChild.style.fontSize = size + 'px';
                artibodyChild.style.fontFamily = '仿宋_GB2312,宋体,"Times New Roman",Georgia,serif';
                artibodyChild.style.fontWeight = 900;
                if (artibodyChild.childNodes.length > 0) {
                    setChildNodesByCurrentNode(artibodyChild, size);
                }
            }
        }
    }
</script>
  
    <style type="text/css">
        .auto-style4 {
            width: 118px;
            height: 81px;
        }
        .auto-style5 {
            width: 164px;
            height: 81px;
        }
        .auto-style6 {
            width: 25%;
        }
        .auto-style7 {
            height: 27px;
            width: 25%;
        }
        .auto-style8 {
            width: 30%;

        }
        .auto-style9 {
            height: 27px;
            width: 30%;
        }
        .auto-style10 {
            height: 81px;
        }
        .auto-style12 {
            font-size: 9pt;
        }
        .auto-style13 {
            font-size: 12pt;
        }
        .auto-style14 {
            height: 81px;
            width: 178px;
        }
    </style>
</head>

<body style="margin:0;">
<form id="form1" runat="server">
    	<div class="place">
    <span>位置:</span>
    <ul class="placeul">
    <li><a href="../home.aspx">首页</a></li>
    <li><a href="#">订单</a>信息</li>
    </ul>
    </div>  
     <div class="formtitle"><span>订单详细信息</span></div>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <!--     <a href="javascript:void(0)" onclick="printWin();">打印1</a> --> 
    <!--    <a href="javascript:void(0)" onclick="printView();">打印</a>   -->
    <div id="print">
   
    <!--startprint-->
<div id="content" style="position: static;margin-left:60px">
<table width="800" border="0" align="center" cellpadding="3" cellspacing="0" style="border: thin double #000000; font-size:9px; font-family:'微软雅黑'; background:#fff;">
<tr>
  <td style="font-size:20px;" class="auto-style4"><font class="auto-style13" size="3">安德鲁森</font><br class="auto-style13" />
      <font class="auto-style13" size="3">业务订单</font></td>
  <td class="auto-style5"><font class="auto-style12" size="3">订&nbsp; 单 号：</font><asp:Label ID="billno" runat="server" Text="Label" CssClass="auto-style12"></asp:Label>
      <br class="auto-style12" />
      <font class="auto-style12" size="3">下单时间：</font><asp:Label ID="lrdate" runat="server" Text="Label" CssClass="auto-style12"></asp:Label>
      <br class="auto-style12" />
      <font class="auto-style12" size="3">提货时间：</font><asp:Label ID="thdate" runat="server" Text="Label" CssClass="auto-style12"></asp:Label>
    </td>
  <td class="auto-style14"><font class="auto-style12" size="3">中心：</font><asp:Label ID="cen" runat="server" Text="Label" CssClass="auto-style12"></asp:Label>
      <br class="auto-style12" />
      <font class="auto-style12" size="3">店（组）：</font><asp:Label ID="dept" runat="server" Text="Label" CssClass="auto-style12"></asp:Label>
      <br class="auto-style12" /><font class="auto-style12" size="3">业 务&nbsp; 员：</font><asp:Label ID="ywy" runat="server" Text="Label" CssClass="auto-style12"></asp:Label>
    </td>
      <td width="220" class="auto-style10">订单来源：<asp:Label ID="ord_from" runat="server" Text="Label" CssClass="auto-style12"></asp:Label>
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:CheckBox ID="ch" runat="server" Checked="True" Enabled="False" />
&nbsp;<asp:Label ID="jm" runat="server" Text="Label"></asp:Label>
      <br class="auto-style12" />
          商品类型：<asp:Label ID="plutype" runat="server" Text="Label" CssClass="auto-style12"></asp:Label>
      <br class="auto-style12" />提货方式：<asp:Label ID="thtype" runat="server" Text="Label" CssClass="auto-style12"></asp:Label>
    </td>

</tr>
<tr>
  <td colspan="4" style="padding:10px 0; border-top:1px solid #000;height:100px">
  <asp:Repeater ID="rptList" runat="server">
      <HeaderTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="5" style="font-size:12px; font-family:'微软雅黑'; background:#fff;">
          <tr>
           <td width="18%" align="left" style="background:#ccc;">商品编码</td>
               <td width="18%" align="left" style="background:#ccc;">商品名称</td>
            <td align="left" style="background:#ccc;">价格</th>
            <td width="12%" align="left" style="background:#ccc;">数量</td>
            <td width="10%" align="left" style="background:#ccc;">单位</td>
                  <td width="10%" align="left" style="background:#ccc;">应收金额</td>
                   <td width="10%" align="left" style="background:#ccc;">&nbsp折扣</td>
            <td width="12%" align="left" style="background:#ccc;">实收金额</td>
          </tr>
      </HeaderTemplate>
      <ItemTemplate>
          <tr>
            
            <td><%#Eval("商品编码")%></td>
            <td><%#Eval("商品名称")%></td>
            <td><%#Eval("价格")%></td>
                <td><%#Eval("数量")%></td>
            <td><%#Eval("单位")%></td>
            <td><%#Eval("应收")%></td>
                  <td>&nbsp<%#Eval("折扣")%></td>
               <td><%#Eval("实收")%></td>
          
          </tr>
      </ItemTemplate>
      <FooterTemplate>
            <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"5\">暂无记录</td></tr>" : ""%>
          </table>
     </FooterTemplate>
  </asp:Repeater>
  </td>
  </tr>
<tr>
  <td colspan="4" style="border-top:1px solid #000;">
  <table width="100%" border="0" cellspacing="0" cellpadding="5" style="margin:5px auto; font-size:12px; font-family:'微软雅黑'; background:#fff;">
    <tr>
      <td class="auto-style8">
          <font class="auto-style12" size="3">客户名称：
          </font>
          <asp:Label ID="custname" runat="server" Text="Label" CssClass="auto-style12"></asp:Label>
      </td>
      <td class="auto-style6"><font class="auto-style12" size="3">联&nbsp; 系 人：</font><asp:Label ID="custbody" runat="server" Text="Label" CssClass="auto-style12"></asp:Label>
          <br class="auto-style12" /></td>
         <td valign="top"><font class="auto-style12" size="3">付款方式：</font><asp:Label ID="fktype" runat="server" CssClass="auto-style12" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
    </tr>

    <tr>
      <td class="auto-style9"><font class="auto-style12" size="3">客户地址：</font><asp:Label ID="custaddr" runat="server" Text="Label" CssClass="auto-style12"></asp:Label>
        </td>
      <td class="auto-style7"><font class="auto-style12" size="3">联系电话：</font><asp:Label ID="custtel" runat="server" Text="Label" CssClass="auto-style12"></asp:Label>
        </td>
         <td  class="auto-style12">应收金额：<asp:Label ID="ystotal" runat="server" CssClass="auto-style12"></asp:Label>
        </td>
    </tr>
    <tr>
      <td valign="top" class="auto-style8">
          <font class="auto-style12" size="3">提货地址：
          </font>
          <asp:Label ID="thaddr" runat="server" Text="Label" CssClass="auto-style12"></asp:Label>
      </td>
    <td valign="top" class="auto-style6"><font class="auto-style12" size="3">开&nbsp; 票 否：</font><asp:Label ID="kp" runat="server" Text="Label" CssClass="auto-style12"></asp:Label>
        </td>
         <td valign="top" class="auto-style12">实收金额：<asp:Label ID="sstotal" runat="server" CssClass="auto-style12"></asp:Label>
        </td>
    </tr>
    <tr>
      <td valign="top" colspan="3"><strong>
          <br class="auto-style12" />
          </strong><font size="3"><strong class="auto-style12">
          备 注：</strong></font><strong><asp:Label ID="memo" runat="server" Text="Label" CssClass="auto-style12"></asp:Label>
          </strong></td>
          
      
    </tr>
  </table>
    <table width="100%" border="0" align="center" cellpadding="5" cellspacing="0" style="border-top:1px solid #000; font-size:12px; font-family:'微软雅黑'; background:#fff; height: 28px;">
      <tr>
        <td align="right" style="text-align: left"><strong class="auto-style12">审批：</strong><asp:Label ID="zbsh" runat="server" CssClass="auto-style12" ForeColor="Red"></asp:Label>
      &nbsp;<strong class="auto-style12">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 审核：</strong><asp:Label ID="yxsh" runat="server" CssClass="auto-style12" ForeColor="Red"></asp:Label>
            <font class="auto-style12" size="3">&nbsp; </font> <strong class="auto-style12">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;主管：</strong><asp:Label ID="zgsh" runat="server" CssClass="auto-style12" ForeColor="Red"></asp:Label>
            <strong class="auto-style12">&nbsp;&nbsp;&nbsp;助理：</strong><asp:Label ID="zl" runat="server" CssClass="auto-style12" ForeColor="Red"></asp:Label>
            <strong class="auto-style12">&nbsp; 录入人：</strong><asp:Label ID="ywysh" runat="server" CssClass="auto-style12" ForeColor="Red"></asp:Label>
            <font class="auto-style12" size="3">&nbsp; <strong class="auto-style12">CRM&amp;SAP下单员：</strong><asp:Label ID="xd" runat="server" CssClass="auto-style12" ForeColor="Red"></asp:Label>
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="com" runat="server" Text="Label" CssClass="auto-style12"></asp:Label>
            </font></td>
      </tr>
    </table></td>
  </tr>
</table>
</div>
</div>
      <!--endprint-->
    <br>
    <hr>
       <!--  <a href="javascript:void(0)" onclick="printView('print');">打印aa</a> -->
             <div id="divBtnPrint" >&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
        <input id="BtnPrint" type="button"  value="打 印" class="btn yellow" onclick="doPrint();" />
                 &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
              <asp:Button ID="btnSubmit" runat="server" Text="审  核" CssClass="btn" OnClick="btnSubmit_Click"   />
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <asp:Button ID="btnSubmit0" runat="server" Text="作  废" CssClass="btn yellow" OnClientClick="return confirm('真的要作废吗，作废后订单将不可用！');" OnClick="btnSubmit0_Click"   />
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <asp:Button ID="btnSubmit1" runat="server" Text="主管审核" CssClass="btn" OnClick="btnSubmit1_Click"   />
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <asp:Button ID="btnSubmit2" runat="server" Text="下单完成" CssClass="btn yellow" OnClick="btnSubmit2_Click" OnClientClick="return confirm('请确认订单信息无误，确认后不能再修改！');"   />
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <!--      <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:window.location.href='ord_list.aspx';" />  -->
 <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-2);" />&nbsp;
            <font class="auto-style12" size="3"><asp:Label ID="zg" runat="server" Text="Label" CssClass="auto-style12"></asp:Label>
            </font>
        </div>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
</form>
</body>
</html>