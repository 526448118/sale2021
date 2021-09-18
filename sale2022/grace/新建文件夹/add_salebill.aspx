<%@ Page Language="C#" AutoEventWireup="true" CodeFile="add_salebill.aspx.cs" Inherits="_add_saleord" %>

<!DOCTYPE html>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" http-equiv="refresh" content="60">
    <link href="/css/bootstrap.min.css" rel="stylesheet"  />
    <script src="/js/jquery/jquery-1.10.2.min.js"></script>

    <script src="/js/bootstrap.min.js"></script>
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
            width: 95pt;
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
            width: 95pt;
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
            width: 95pt;
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
        
    *{border-style: none;
            border-color: inherit;
            border-width: 0;
            font-size:9pt;padding:0;
            margin-left: 0;
            margin-right: 0;
            margin-top: 0;
        }
        
        .auto-style54 {
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
            height: 20pt;
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
    <div class="itab">
  	    <ul> 
            <li><a href="product_add.aspx" class="selected">增加发票申请单</a></li>
            <li>在此输入订单系统订单号<asp:TextBox ID="oldbill" runat="server" BorderWidth="1px" AutoPostBack="True" Height="20px" OnTextChanged="TextBox1_TextChanged" Width="130px"></asp:TextBox></li>
  	    </ul>
    </div>        
    <div id="content">
        <table border="0"  width="866">            
            <tr>
                <td class="auto-style1" colspan="8" width="866">发票申请资料录入
                    <asp:Label ID="Label3" runat="server" Text="*号请填入正确信息"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style43">
                    <asp:Label ID="l11" runat="server" Text="*"></asp:Label>
                    中 心：</td>
                <td class="auto-style43">
                    <asp:TextBox ID="cen" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderStyle="Double" Width="99%" ></asp:TextBox>
                </td>
                <td class="auto-style43" colspan="2">
                    <asp:Label ID="l12" runat="server" Text="*"></asp:Label>
                    <asp:RadioButton ID="dep01" runat="server" AutoPostBack="True" GroupName="1" OnCheckedChanged="rad2_CheckedChanged" Text="门店" />
                    <asp:RadioButton ID="dep02" runat="server" GroupName="1" OnCheckedChanged="rad1_CheckedChanged" Text="部门" />
                </td>
                <td class="auto-style39" colspan="2">
                    <asp:TextBox ID="dept" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="92%" AutoPostBack="True" OnTextChanged="dept_TextChanged" ></asp:TextBox>
                </td>
                <td class="auto-style12">
                    <asp:Label ID="l16" runat="server" Text="*"></asp:Label>
                    发票类型：
                </td>
                <td class="auto-style21" id="yw_type">
                    <asp:DropDownList ID="billtype" runat="server" AutoPostBack="True" Height="16px" OnSelectedIndexChanged="billtype_SelectedIndexChanged" Width="116px">
                        <asp:ListItem>...请选择...</asp:ListItem>
                        <asp:ListItem>专用增值税发票</asp:ListItem>
                        <asp:ListItem>普票</asp:ListItem>
                        <asp:ListItem>电子发票</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style43">
                    <asp:Label ID="l13" runat="server" Text="*"></asp:Label>
                    业务员：                    
                </td>
                <td class="auto-style37">
                    <asp:TextBox ID="yw_people" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderStyle="Double" Width="99%" ></asp:TextBox>
                </td>
                <td class="auto-style42" colspan="2">
                    业务员电话：
                </td>
                <td class="auto-style40" colspan="2">
                    <asp:TextBox ID="yw_peopletell" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderStyle="Double" Width="92%" ></asp:TextBox>
                </td>
                <td class="auto-style49">
                    <asp:Label ID="l17" runat="server" Text="*"></asp:Label>
                    开票记录：
                </td>
                <td class="auto-style21">
                    <asp:DropDownList ID="tick_record" runat="server" Height="16px" Width="93px" OnSelectedIndexChanged="tick_record_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem>...请选择...</asp:ListItem>
                        <asp:ListItem>新开</asp:ListItem>
                        <asp:ListItem>重开</asp:ListItem>
                    </asp:DropDownList>                    
                    <asp:TextBox ID="zf" runat="server" type="button" class="btn" data-toggle="modal" data-target="#info" value="原单号" Width="73px" Visible="False" OnTextChanged="zf_TextChanged"></asp:TextBox>
               </td>
            </tr>
             <tr>
                <td class="auto-style44">
                    <asp:Label ID="l14" runat="server" Text="*"></asp:Label>
                    销售来源:
                </td>
                <td class="auto-style45">
                    <asp:DropDownList ID="sale_source" runat="server">
                        <asp:ListItem>...请选择...</asp:ListItem>
                        <asp:ListItem>卡券团单</asp:ListItem>
                        <asp:ListItem>收银小票</asp:ListItem>
                        <asp:ListItem>月饼实物团单</asp:ListItem>
                        <asp:ListItem>粽子实物团单</asp:ListItem>
                        <asp:ListItem>微信订单</asp:ListItem>
                        <asp:ListItem>商城订单</asp:ListItem>
                        <asp:ListItem>自制品团单</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style46" colspan="2">
                    收货地址:
                </td>
                <td class="auto-style47" colspan="2">
                    <asp:TextBox ID="rec_address" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderStyle="Double" Width="92%"  ></asp:TextBox>                    
                </td>
                <td class="auto-style50">
                    是否直营：
                </td>
                <td class="auto-style48">
                    <asp:TextBox ID="IS_ZY" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderStyle="Double" Width="92%" ReadOnly="True"  ></asp:TextBox>
                 </td>
            </tr>
            <tr>
                <td class="auto-style32">
                    <asp:Label ID="l15" runat="server" Text="*"></asp:Label>
                    订单号（可填多张）：
                </td>
                <td class="auto-style13" colspan="7">
                    <asp:TextBox ID="ordbillno" runat="server" Text="请输入订单系统单号/CMP单号/SAP单号" MaxLength ="40"
                        OnFocus="javascript:if(this.value=='请输入订单系统单号/CMP单号/SAP单号') {this.value=''}" OnBlur="javascript:if(this.value==''){this.value='请输入订单系统单号/CMP单号/SAP单号'}" 
                        CssClass="input normal" BackColor="#DDFFFF" BorderStyle="Double" Width="98%" Height ="90%" ></asp:TextBox>
                   </td>
            </tr>
            <tr>
                <td class="auto-style32">
                    <asp:Label ID="l2" runat="server" Text="*" Visible="False"></asp:Label>
                    客户名称：
                </td>
                <td class="auto-style13" colspan="7">
                    <asp:TextBox ID="custom" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderStyle="Double" Width="98%" Height ="90%" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style32">
                    <asp:Label ID="l3" runat="server" Text="*" Visible="False"></asp:Label>
                    税号(若没有则填无)：
                </td>
                <td class="auto-style13" colspan="7">
                    <asp:TextBox ID="shuihao" runat="server" CssClass="input normal" MaxLength ="20" BackColor="#DDFFFF" BorderStyle="Double" Width="98%" Height ="86%" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style32">
                    <asp:Label ID="l4" runat="server" Text="*" Visible="False"></asp:Label>
                    客户地址：
                </td>
                <td class="auto-style13" colspan="7">
                    <asp:TextBox ID="address" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderStyle="Double" Width="98%" Height ="90%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style43">
                    <asp:Label ID="l5" runat="server" Text="*" Visible="False"></asp:Label>
                    开户银行：
                </td>
                <td class="auto-style30" colspan="3">
                    <asp:TextBox ID="bank" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderStyle="Double" Width="96%" Height ="90%" ></asp:TextBox>
                </td>
                <td class="auto-style40" colspan="2">
                    <asp:Label ID="l8" runat="server" Text="*" Visible="False"></asp:Label>
                    银行账户：
                </td>
                <td class="auto-style30" colspan="2">
                    <asp:TextBox ID="bank_acc" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderStyle="Double" Width="96%" Height ="74%" ></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="auto-style43">
                    <asp:Label ID="l6" runat="server" Text="*" Visible="False"></asp:Label>
                    客户邮箱：
                </td>
                <td class="auto-style30" colspan="3">
                    <asp:TextBox ID="email" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="96%" ></asp:TextBox>
                </td>
                <td class="auto-style40" colspan="2">
                    <asp:Label ID="l9" runat="server" Text="*" Visible="False"></asp:Label>
                    客户电话：</td>
                <td class="auto-style30" colspan="2">
                    <asp:TextBox ID="tellphone" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="96%" ></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="auto-style43">
                    <asp:Label ID="l7" runat="server" Text="*" Visible="False"></asp:Label>
                    客户联系人：
                </td>
                <td class="auto-style30" colspan="3">
                    <asp:TextBox ID="cust_lxr" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="96%" ></asp:TextBox>
                 </td>
                <td class="auto-style40" colspan="2">
                    <asp:Label ID="l10" runat="server" Text="*" Visible="False"></asp:Label>
                    客户联系人电话：
                </td>
                <td class="auto-style30" colspan="2">
                    <asp:TextBox ID="lxr_tel" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="96%" ></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="auto-style43">
                    备注信息：
                </td>
                <td class="auto-style30" colspan="7">
                    <asp:TextBox ID="memo" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="98%" Height="68px" TextMode="MultiLine" ></asp:TextBox>
                    <br />
                 </td>
            </tr>
            <tr>
                <td class="auto-style33" ></td>
            </tr>
            <tr>
                <td class="auto-style43">开票名称：<asp:TextBox ID="pluname0" runat="server" BackColor="#00FF99" BorderColor="#660033" BorderStyle="Double" BorderWidth="1px" Height="24px"  AutoPostBack ="True" Width="48px" OnTextChanged="pluname0_TextChanged"></asp:TextBox>
                </td>
                <td class="auto-style54">
                    <asp:DropDownList ID="pluname" runat="server" CssClass="auto-style29" AutoPostBack="True" OnSelectedIndexChanged="pluname_SelectedIndexChanged" Width="150px">
                    </asp:DropDownList>
                </td>
                <td class="auto-style42" colspan="2">开票商品数量：</td>
                <td class="auto-style40" colspan="2">
                    <asp:TextBox ID="plucount" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="92%" onkeypress="if ((event.keyCode<48 || event.keyCode>57) && event.keyCode!=46) event.returnValue=false;" onpaste="return false" style="ime-mode:disabled" onkeyup="this.value=this.value.replace(/[\u4e00-\u9fa5]/g,'')"></asp:TextBox>
                </td>
                <td class="auto-style43">
                    开票总金额：</td>
                <td class="auto-style30">
                    <asp:TextBox ID="sstotal" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="92%" onkeypress="if ((event.keyCode<48 || event.keyCode>57) && event.keyCode!=46) event.returnValue=false;" onpaste="return false" style="ime-mode:disabled" onkeyup="this.value=this.value.replace(/[\u4e00-\u9fa5]/g,'')"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style32">开票商品规格型号：</td>
                <td class="auto-style38">
                    <asp:TextBox ID="plumodel" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="92%" ></asp:TextBox>
                 </td>
                <td class="auto-style19" colspan="2">开票商品单位：</td>
                <td class="auto-style41" colspan="2">
                    <asp:TextBox ID="pluunit" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="92%" ></asp:TextBox>
                 </td>
                <td class="auto-style43">
                    税收编码:</td>
                <td class="auto-style30">
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
            </tr>
             
           
             <tr>
                <td class="auto-style3">
                    部门主管工号：</td>
                <td class="auto-style3">
                    <asp:TextBox ID="zg" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="92%" OnTextChanged="zg_TextChanged" ></asp:TextBox>
                 </td>
                <td class="auto-style3">
                    
                    <asp:Button ID="Button1" runat="server" Height="100%" Text="添加商品" Width="100%" CssClass="scbtn" OnClientClick="return confirm('确认商品信息无误！');" OnClick="Button1_Click" />
                  </td>
                <td class="auto-style3" colspan="2">
                   
                    <asp:FileUpload ID="FileUpload1" runat="server" BorderWidth="1px" Height="21px" Width="142px" />                    
                    </td>
                <td class="auto-style3">
                   
                    <asp:Button ID="Button5" runat="server"  Text="批量导入" CssClass="scbtn" onclick="Button5_Click" Height="22px" /></td>
                <td class="auto-style52">
                    　<a href ="uploadfiles/m/清单发票商品模板.xlsx">模板下载<style="text-decoration: underline; width: 50px; color: #FF66FF"/></a></td>
                <td class="auto-style30">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                    <asp:Button ID="Button2" runat="server" Height="22px" Text="保存申请单" Width="65%" CssClass="scbtn" OnClientClick="return confirm('请确认订单信息无误，确认后不能再修改！');" OnClick="Button2_Click" />
                    </td>
            </tr>
            </table>
                </div>
    <div>
       
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
    
        <br />
        .</div>
                <div class="modal fade" id="info" tabindex="-1" role="dialog" aria-labelledby="myModalLabe1" style="">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">×</span>
                        </button>
                        <h5 class="modal-title" id="myModalLabe1"><asp:Label ID="stores" runat="server" Text="" CssClass="label"></asp:Label>
                         <strong>输入原发票申请号</strong>
                        </h5>
                    </div>
                    <div class="modal-body" style="margin-left: 30px">
                        <div class="input-group" style="width:350px">
                            <span class="input-group-addon" id="posmodel">原发票申请号：</span>
                            <asp:TextBox ID="old_fp" runat="server" CssClass="form-control" aria-describedby="posmodel"></asp:TextBox>
                        </div>
                        
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="Button3" runat="server" Text="确定" CssClass="btn btn-primary" style="width: 90px" OnClick="Button00_Click" />
                        <%--<asp:Button ID="Button4" runat="server" Text="取消" CssClass="btn btn-default" style="width: 90px"  onclientclick="custom_close()"/>--%>
                    </div>
                </div>
            </div>
        </div>  
    </form>
</body>
</html>
