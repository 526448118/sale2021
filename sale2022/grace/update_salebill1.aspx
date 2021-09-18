<%@ Page Language="C#" AutoEventWireup="true" CodeFile="update_salebill.aspx.cs" Inherits="_add_saleord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server" http-equiv="refresh" content="60">
       <script src="../My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../js/datepicker/WdatePicker.js"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>订单录入</title>
    <style type="text/css">
        .auto-style1 {
            height: 24pt;
            width: 651pt;
            color: black;
            font-size: 30pt;
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
        .auto-style3 {
            color: black;
            font-size: 11.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style12 {
            color: black;
            font-size: 10pt;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            height: 20pt;
            width: 92px;
        }
        .auto-style13 {
            height: 20pt;
            color: black;
            font-size: 11.0pt;
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
        .auto-style17 {
            font-weight: bold;
            font-size: 10pt;
        }
        .auto-style19 {
            color: black;
            font-size: 10pt;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            width: 41pt;
        }
        .auto-style21 {
            height: 20pt;
            color: black;
            font-size: 10pt;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style29 {
            font-size: 10pt;
        }
        .auto-style30 {
            color: black;
            font-size: 11.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            height: 20pt;
        }
             .GridViewStyle
{   
    border-right: 2px solid #A7A6AA;
    border-bottom: 2px solid #A7A6AA;
    border-left: 2px solid white;
    border-top: 2px solid white;
    padding: 4px;
}

.GridViewStyle a
{
    color: #FFFFFF;
}

.GridViewHeaderStyle th
{
    border-left: 1px solid #EBE9ED;
    border-right: 1px solid #EBE9ED;
}

.GridViewHeaderStyle
{
    background-color: #5D7B9D;
     border: 1px dotted #5D7B9D;
    font-weight: bold;
    color: White;
     height:20px;
}

.GridViewFooterStyle
{
    background-color: #5D7B9D;
    font-weight: bold;
    color: White;
}

.GridViewRowStyle
{
    background-color: #F7F6F3;
    color: #333333;
    height:20px;
}

.GridViewAlternatingRowStyle
{
    background-color: #FFFFFF;
    color: #284775;
}

.GridViewRowStyle td, .GridViewAlternatingRowStyle td
{
    border: 1px dotted #5D7B9D;
}

.GridViewSelectedRowStyle
{
    background-color: #E2DED6;
    font-weight: bold;
    color: #333333;
}

.GridViewPagerStyle
{
    background-color: #284775;
    color: #FFFFFF;
}

.GridViewPagerStyle table /**//* to center the paging links*/
{
    margin: 0 auto 0 auto;
}

        .auto-style32 {
            height: 20.1pt;
            color: black;
            font-size: 10pt;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            width: 112px;
        }
        .auto-style33 {
            width: 112px;
        }

        .auto-style37 {
            height: 20pt;
            color: black;
            font-size: 10pt;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            width: 163px;
        }
        .auto-style38 {
            color: black;
            font-size: 11.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            width: 163px;
        }
        
        .auto-style39 {
            color: black;
            font-size: 11.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            width: 254px;
        }
        .auto-style40 {
            height: 20pt;
            color: black;
            font-size: 10pt;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            width: 254px;
        }
        .auto-style41 {
            color: black;
            font-size: 10pt;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            width: 254px;
        }
        
        .auto-style42 {
            height: 20pt;
            color: black;
            font-size: 10pt;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            width: 41pt;
        }
        .auto-style43 {
            height: 20pt;
            color: black;
            font-size: 10pt;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            width: 112px;
        }
        .auto-style44 {
            height: 27pt;
            color: black;
            font-size: 10pt;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            width: 112px;
        }
        .auto-style45 {
            height: 27pt;
            color: black;
            font-size: 10pt;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            width: 163px;
        }
        .auto-style46 {
            height: 27pt;
            color: black;
            font-size: 10pt;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            width: 41pt;
        }
        .auto-style47 {
            height: 27pt;
            color: black;
            font-size: 10pt;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            width: 254px;
        }
        .auto-style48 {
            height: 27pt;
            color: black;
            font-size: 10pt;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
        }
        .auto-style49 {
            height: 20pt;
            color: black;
            font-size: 10pt;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            width: 92px;
        }
        .auto-style50 {
            height: 27pt;
            color: black;
            font-size: 10pt;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            width: 92px;
        }
        .auto-style52 {
            color: black;
            font-size: 10pt;
            font-weight: bold;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            width: 92px;
        }
        
    </style>
       
<script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../js/swfupload/swfupload.js"></script>
<script type="text/javascript" src="../js/swfupload/swfupload.queue.js"></script>
<script type="text/javascript" src="../js/swfupload/swfupload.handlers.js"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<script type="text/javascript" src="../js/pinyin.js"></script>
<link href="../css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();

        //初始化上传控件
        $(".upload-img").each(function () {
            $(this).InitSWFUpload({ sendurl: "../tools/upload_ajax.ashx", flashurl: "../js/swfupload/swfupload.swf" });
        });

        //设置封面图片的样式
        $(".photo-list ul li .img-box img").each(function () {
            if ($(this).attr("src") == $("#hidFocusPhoto").val()) {
                $(this).parent().addClass("selected");
            }
        });

        //设置封面图片的样式
        $(".photo-list ul li .img-box img").each(function () {
            if ($(this).attr("src") == $("#hidFocusPhoto").val()) {
                $(this).parent().addClass("selected");
            }
        });


    });

</script>
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
</script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="../home.aspx">首页</a></li>
    <li>发票申请单<a href="#">录入</a></li>
    </ul>
    </div> 
    <div class="formbody">  
    <div id="usual1" class="usual">   
    <div class="itab">
  	<ul> 
    <li><a href="product_add.aspx" class="selected">增加发票申请单</a></li> 

  	</ul>
    </div>  
       
            <div id="content">
        <table border="0" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse;" width="866">
            <colgroup>
                <col style="mso-width-source:userset;mso-width-alt:3104;" />
                <col style="mso-width-source:userset;mso-width-alt:5920;" />
                <col style="mso-width-source:userset;mso-width-alt:4000;" />
                <col style="mso-width-source:userset;mso-width-alt:4896;" />
                <col style="mso-width-source:userset;mso-width-alt:3904;width:92pt" width="122" />
                <col style="mso-width-source:userset;mso-width-alt:5888;width:138pt" width="184" />
            </colgroup>
            <tr style="mso-height-source:userset;">
                <td class="auto-style1" colspan="6" width="866">发票申请资料修改</td>
            </tr>
            <tr style="mso-height-source:userset;">
                <td class="auto-style43">中 心：</td>
                <td class="auto-style38">
                    <asp:TextBox ID="cen" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderStyle="Double" Width="92%" ></asp:TextBox>
                </td>
                <td class="auto-style42">部门（店）：</td>
                <td class="auto-style39">
                    <asp:TextBox ID="dept" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="92%" ></asp:TextBox>
                </td>
                <td class="auto-style12">发票类型：</td>
                <td class="auto-style21" id="yw_type">
                    <asp:DropDownList ID="billtype" runat="server">
                        <asp:ListItem>...请选择...</asp:ListItem>
                        <asp:ListItem>专用增值税发票</asp:ListItem>
                        <asp:ListItem>普票</asp:ListItem>
                        <asp:ListItem>电子发票</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="mso-height-source:userset;">
                <td class="auto-style43">业务员：</td>
                <td class="auto-style37">
                    <asp:TextBox ID="yw_people" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderStyle="Double" Width="92%" ></asp:TextBox>
                </td>
                <td class="auto-style42">业务员电话：</td>
                <td class="auto-style40">
                    <asp:TextBox ID="yw_peopletell" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderStyle="Double" Width="92%" ></asp:TextBox>
                </td>
                <td class="auto-style49">开票记录：</td>
                <td class="auto-style21" id="tick_record">
                    <asp:DropDownList ID="tick_record" runat="server">
                        <asp:ListItem>...请选择...</asp:ListItem>
                        <asp:ListItem>新开</asp:ListItem>
                        <asp:ListItem>重开</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
             <tr style="mso-height-source:userset;">
                <td class="auto-style44">销售来源:</td>
                <td class="auto-style45">
                    <asp:DropDownList ID="sale_source" runat="server">
                        <asp:ListItem>...请选择...</asp:ListItem>
                        <asp:ListItem>卡券团单</asp:ListItem>
                        <asp:ListItem>实物团单</asp:ListItem>
                        <asp:ListItem>收银小票</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style46">收货地址:</td>
                <td class="auto-style47">
                    <asp:TextBox ID="rec_address" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderStyle="Double" Width="92%"  ></asp:TextBox>
                    </td>
                <td class="auto-style50"></td>
                <td class="auto-style48">
                 </td>
            </tr>
                <tr height="26" style="mso-height-source:userset;height:20.1pt">
                <td class="auto-style32" height="26">订单号（可填多张）：</td>
                <td class="auto-style13" colspan="5">
                    <asp:TextBox ID="ordbillno" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderStyle="Double" Width="98%" Height ="90%" ></asp:TextBox>
                   </td>
            </tr>
               <tr height="26" style="mso-height-source:userset;height:20.1pt">
                <td class="auto-style32" height="26">客户名称：</td>
                <td class="auto-style13" colspan="5">
                    <asp:TextBox ID="custom" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderStyle="Double" Width="98%" Height ="90%" ></asp:TextBox>
                   </td>
            </tr>
              <tr style="mso-height-source:userset;">
                <td class="auto-style32">税号：</td>
                <td class="auto-style13" colspan="5">
                    <asp:TextBox ID="shuihao" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderStyle="Double" Width="98%" Height ="86%" ></asp:TextBox>
                   </td>
            </tr>
            <tr height="26" style="mso-height-source:userset;height:20.1pt">
                <td class="auto-style32" height="26">客户地址：</td>
                <td class="auto-style13" colspan="5">
                    <asp:TextBox ID="address" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderStyle="Double" Width="98%" Height ="90%"></asp:TextBox>
                   </td>
            </tr>
            <tr style="mso-height-source:userset;">
                <td class="auto-style43">开户银行：</td>
                <td class="auto-style30" colspan="2">
                    <asp:TextBox ID="bank" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderStyle="Double" Width="96%" Height ="90%" ></asp:TextBox>
                   </td>
                <td class="auto-style40">
                    银行账户：</td>
                <td class="auto-style30" colspan="2">
                    <asp:TextBox ID="bank_acc" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderStyle="Double" Width="96%" Height ="74%" ></asp:TextBox>
                   </td>
            </tr>
             <tr style="mso-height-source:userset;">
                <td class="auto-style43">客户邮箱：</td>
                <td class="auto-style30" colspan="2">
                    <asp:TextBox ID="email" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="96%" ></asp:TextBox>
                 </td>
                <td class="auto-style40">客户电话：</td>
                <td class="auto-style30" colspan="2">
                    <asp:TextBox ID="tellphone" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="96%" ></asp:TextBox>
                 </td>
            </tr>
             <tr style="mso-height-source:userset;">
                <td class="auto-style43">客户联系人：</td>
                <td class="auto-style30" colspan="2">
                    <asp:TextBox ID="cust_lxr" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="96%" ></asp:TextBox>
                 </td>
                <td class="auto-style40">客户联系人电话：</td>
                <td class="auto-style30" colspan="2">
                    <asp:TextBox ID="lxr_tel" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="96%" ></asp:TextBox>
                 </td>
            </tr>
             <tr style="mso-height-source:userset;">
                <td class="auto-style43">备注信息：</td>
                <td class="auto-style30" colspan="5">
                    <asp:TextBox ID="memo" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="98%" Height="68px" TextMode="MultiLine" ></asp:TextBox>
                    <br />
                 </td>
            </tr>
            <tr  height="26" style="mso-height-source:userset;height:20.1pt">
                <td class="auto-style33" ></td>
            </tr>
            <tr>
                <td class="auto-style32" height="26">商品名称：</td>
                <td class="auto-style38">
                    <asp:TextBox ID="pluname" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="92%" ></asp:TextBox>
                 </td>
                <td class="auto-style19">商品数量：</td>
                <td class="auto-style41">
                    <asp:TextBox ID="plucount" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="92%" ></asp:TextBox>
                 </td>
                <td class="auto-style43">
                    商品总金额：</td>
                <td class="auto-style30">
                    <asp:TextBox ID="sstotal" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="92%" ></asp:TextBox>
                 </td>
            </tr>
            <tr height="26" style="mso-height-source:userset;height:20.1pt">
                <td class="auto-style32" height="26">商品规格型号：</td>
                <td class="auto-style38">
                    <asp:TextBox ID="plumodel" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="92%" ></asp:TextBox>
                 </td>
                <td class="auto-style19">商品单位：</td>
                <td class="auto-style41">
                    <asp:TextBox ID="pluunit" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="92%" ></asp:TextBox>
                 </td>
                <td class="auto-style43">
                    &nbsp;</td>
                <td class="auto-style30">
                    &nbsp;</td>
            </tr>
             
           
             <tr height="26" style="mso-height-source:userset;height:20.1pt">
                <td class="auto-style3" colspan="2">
                    <font class="auto-style29" size="3">　先添加商品信息，再保存申请单。</font></td>
                <td class="auto-style3" colspan="2">
                    <font class="auto-style29" size="3">
                    <asp:Button ID="Button1" runat="server" Height="99%" Text="添加商品信息" Width="85%" CssClass="auto-style17" OnClientClick="return confirm('确认商品信息无误！');" OnClick="Button1_Click" />
                    　</font></td>
                <td class="auto-style52">
                    <asp:Button ID="Button2" runat="server" Height="99%" Text="保存申请单" Width="98%" CssClass="auto-style17" OnClientClick="return confirm('请确认订单信息无误，确认后不能再修改！');" OnClick="Button2_Click" />
                    　</td>
                <td class="auto-style30">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                    </td>
            </tr>
            </table>
                </div>
    <div>
        <br>
    <hr>
        <asp:GridView ID="GridView1" CssClass="GridViewStyle" runat="server" Font-Size="Small" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" style="z-index: 1; left: 10px; top: 378px; height: 115px; width: 800px;" UseAccessibleHeader="False" Width="800px" BorderColor="#660066" BorderStyle="Dotted" BorderWidth="1px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField HeaderText="编辑" ShowEditButton="True" Visible="False">
                <FooterStyle ForeColor="#660066" />
                <ItemStyle ForeColor="#0099CC" />
                </asp:CommandField>
                <asp:CommandField HeaderText="删除" ShowDeleteButton="True" >
                <ItemStyle ForeColor="#0099CC" />
                </asp:CommandField>
            </Columns>
                <AlternatingRowStyle BorderColor="Black" Font-Size="Small" Wrap="False"  />
         <EditRowStyle BorderColor="Black" />
             <FooterStyle CssClass="GridViewFooterStyle" ForeColor="#CC99FF" />
    <RowStyle CssClass="GridViewRowStyle" Height="15px" />   
    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
    <PagerStyle CssClass="GridViewPagerStyle" />
    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
    <HeaderStyle CssClass="GridViewHeaderStyle" Height="15px" />
        </asp:GridView>
    
    </div>
           
    </form>
</body>
</html>
