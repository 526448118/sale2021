<%@ Page Language="C#" AutoEventWireup="true" CodeFile="add_saleord_l2.aspx.cs" Inherits="_add_saleord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" http-equiv="refresh" content="60">
    <script src="../My97DatePicker/WdatePicker.js"></script>
    <script src="../js/jquery/jquery-1.10.2.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
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
        .auto-style7 {
            color: black;
            font-size: 11.0pt;
            font-weight: 400;
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
        }
        .auto-style8 {
            height: 57pt;
            color: black;
            font-size: 10pt;
            font-weight: bold;
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
        .auto-style10 {
            color: black;
            font-size: 11.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: 宋体;
            text-align: left;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding-left: 1px;
            padding-right: 1px;
            padding-top: 1px;
            height: 57pt;
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
        }
        .auto-style13 {
            height: 16pt;
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
        .auto-style14 {
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
        .auto-style16 {
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
        }
        .auto-style17 {
            font-weight: bold;
            font-size: 10pt;
        }
        .auto-style18 {
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
        }
        .auto-style20 {
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
        .auto-style22 {
            font-weight: normal;
            font-size: 10pt;
        }
        .auto-style23 {
            color: black;
            font-size: 10pt;
            font-weight: normal;
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
            width: 108pt;
        }
        .auto-style27 {
            color: black;
            font-size: 10pt;
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
        .auto-style31 {
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
            width: 108pt;
        }
        .auto-style32 {
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
            width: 108pt;
        }
        .auto-style33 {
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
            width: 108pt;
        }
        .auto-style34 {
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
            width: 131pt;
        }
        .auto-style35 {
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
            width: 131pt;
        }
        .auto-style36 {
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
            width: 131pt;
        }
        .auto-style37 {
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
            width: 131pt;
        }
        .auto-style38 {
            font-size: 12pt;
        }
        .auto-style39 {
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
            width: 113pt;
        }
        .auto-style40 {
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
            width: 113pt;
        }
        .auto-style41 {
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
            width: 113pt;
        }
        .auto-style42 {
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
            width: 113pt;
        }
        .auto-style43 {
            height: 16pt;
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
        .auto-style44 {
            height: 16pt;
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
            width: 113pt;
        }
        .auto-style45 {
            height: 16pt;
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
            width: 108pt;
        }
        .auto-style46 {
            height: 16pt;
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
            width: 131pt;
        }
        .auto-style47 {
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
            height: 16pt;
        }

        .auto-style48 {
            height: 20pt;
        }
        .auto-style49 {
            color: black;
            font-size: small;
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
            width: 113pt;
        }
        .auto-style50 {
            color: black;
            font-size: small;
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
            width: 131pt;
        }

        .auto-style51 {
            font-weight: normal;
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
    var tValue = "";
    setInterval(function (event) {
        var value = document.getElementById("pluname").value;
        var value1 = document.getElementById("plutype").value;
        if (tValue != value) {
            tValue = document.getElementById("pluname").value;
            tValue1 = document.getElementById("plutype").value;

            $.ajax({
                type: "POST",
                contentType: "application/json;charset=utf-8",
                url: "add_saleord_l2.aspx/GetDeptname",
                data: JSON.stringify({ "pluname": tValue, "plutype": tValue1 }),//添加,"plutype": tValue1_20190919
                dataType: "json",
                success: function (data) {
                    if (data.d != null) {
                        var s = data.d;
                        var arr = s.split('_');
                        //alert(s);
                        document.getElementById("plucode").value = arr[0];
                        document.getElementById("price").value = arr[1];
                        document.getElementById("count").value = 0;
                        document.getElementById("zk").value = 0;
                        //var embed = document.createElement("embed");
                        //embed.src = "music/msg.mp3";
                        //embed.setAttribute("autostart",true);
                        //embed.style.width = "0";
                        //embed.style.height = "0";
                        //document.body.appendChild(embed);
                    }
                    else {
                        alert("当前输入商品信息不存在！请重新输入.");
                        document.getElementById("plucode").value = "";
                        document.getElementById("price").value = "";
                    }
                }
            });
        }

    }, 0);



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
        function calc() {
            var i1 = document.getElementById('price').value;
            var i2 = document.getElementById('count').value;
            var i3 = document.getElementById('zk').value;
            if (i1 && i2 && i3) {
                var r = document.getElementById('sstotal');
                r.value = (i1 * i2 * i3 * 0.01).toFixed(2);
            }
        }
</script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="../home.aspx">首页</a>&nbsp; <a href="#">订单录入</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;</li>
    </ul>
    </div> 
    <div class="formbody">  
    <div id="usual1" class="usual">   
    <div class="itab">
   &nbsp;<ul> 
            <li>&nbsp;模板订单号：</li>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="154px" AutoPostBack="True" Height="25px" OnTextChanged="m_TextChanged" ></asp:TextBox>
                
  	</ul>
    </div>  
        <center>
            <div id="content">
        <table border="0" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse;width:651pt; height: 614px;">
            <colgroup>
                <col style="mso-width-source:userset;mso-width-alt:3104;" />
                <col style="mso-width-source:userset;mso-width-alt:5920;" />
                <col style="mso-width-source:userset;mso-width-alt:4000;" />
                <col style="mso-width-source:userset;mso-width-alt:4896;width:115pt" width="153" />
                <col style="mso-width-source:userset;mso-width-alt:3904;width:92pt" width="122" />
                <col style="mso-width-source:userset;mso-width-alt:5888;width:138pt" width="184" />
            </colgroup>
            <tr style="mso-height-source:userset;">
                <td class="auto-style1" colspan="6" width="866">&nbsp; 客户订单录入  
                    <asp:Label ID="Label3" runat="server" style="font-size: medium"></asp:Label>
                    &nbsp;</td>
            </tr>
            <tr style="mso-height-source:userset;">
                <td class="auto-style43">销售中心：</td>
                <td class="auto-style44">
                    <asp:TextBox ID="cen" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderStyle="Double" Width="95%" ></asp:TextBox>
                </td>
                <td class="auto-style45">
                    <asp:RadioButton ID="dep01" GroupName="depxz" runat="server" Text="门店" AutoPostBack="True" CssClass="auto-style38" OnCheckedChanged="dep01_CheckedChanged" />
                    <asp:RadioButton ID="dep02" GroupName="depxz" runat="server" Text="部门" CssClass="auto-style38" OnCheckedChanged="dep02_CheckedChanged" />
                </td>
                <td class="auto-style46">
                    <asp:TextBox ID="dept" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" AutoPostBack="True" OnTextChanged="dept_TextChanged" ></asp:TextBox>
                </td>
                <td class="auto-style47">业务员：</td>
                <td class="auto-style13">
                    <asp:TextBox ID="saler" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" AutoPostBack="True" OnTextChanged="saler_TextChanged" ></asp:TextBox>
                </td>
            </tr>
            <tr height="26" style="mso-height-source:userset;height:20.1pt">
                <td class="auto-style18" height="26">业务员电话：</td>
                <td class="auto-style40">
                    <asp:TextBox ID="saler_tel" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" OnTextChanged="saler_tel_TextChanged" ></asp:TextBox>
                </td>
                <td class="auto-style32">下单日期：</td>
                <td class="auto-style35">
                    <asp:TextBox ID="lrdate" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%"  onclick="WdatePicker()"></asp:TextBox>
                </td>
                <td class="auto-style20">提货日期：</td>
                <td class="auto-style14">
                    <asp:TextBox ID="thdate" runat="server"  CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}\s{1}(\d{1,2}:){2}\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" "  BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%"  ></asp:TextBox>
                </td>
            </tr>
               <tr height="26" style="mso-height-source:userset;height:20.1pt">
                <td class="auto-style18" height="26">订单来源：</td>
                <td class="auto-style41">
                    <asp:DropDownList ID="ord_from" runat="server" CssClass="auto-style29">
                        <asp:ListItem>...请选择...</asp:ListItem>
                        <asp:ListItem>门市</asp:ListItem>
                        <asp:ListItem>行政</asp:ListItem>
                        <asp:ListItem>业务</asp:ListItem>
                        <asp:ListItem>经销商</asp:ListItem>
                        <asp:ListItem>加盟业主</asp:ListItem>
                        <asp:ListItem>市场</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style32">提货方式：</td>
                <td class="auto-style36">
                    <asp:DropDownList ID="thtype" runat="server" CssClass="auto-style29" AutoPostBack="True" OnSelectedIndexChanged="thtype_SelectedIndexChanged">
                        <asp:ListItem>...请选择...</asp:ListItem>
                        <asp:ListItem>门店自提</asp:ListItem>
                        <asp:ListItem>送货到府</asp:ListItem>
                        <asp:ListItem>工厂自提</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style20">商品类型：</td>
                <td class="auto-style3">
                    <asp:DropDownList ID="plutype" runat="server" CssClass="auto-style29" AutoPostBack="True" OnSelectedIndexChanged="plutype_SelectedIndexChanged">
                        <asp:ListItem>...请选择...</asp:ListItem>
                        <asp:ListItem Value="月饼实物"></asp:ListItem>
                        <asp:ListItem>储值卡</asp:ListItem>
                        <asp:ListItem>提领券</asp:ListItem>
                        <asp:ListItem>普通商品</asp:ListItem>
                        <asp:ListItem>礼券</asp:ListItem>
                        <asp:ListItem>粽子实物</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
              <tr style="mso-height-source:userset;">
                <td class="auto-style21">客户名称：</td>
                <td class="auto-style39">
                    <asp:TextBox ID="custname" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" ></asp:TextBox>
                </td>
                <td class="auto-style31">客户税号：</td>
                <td class="auto-style34">
                    <asp:TextBox ID="cust_tax_code" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" ></asp:TextBox>
                </td>
                <td class="auto-style12">定单类型：</td>
                <td class="auto-style21">
                    <asp:DropDownList ID="ord_type" runat="server" CssClass="auto-style29">
                        <asp:ListItem>...请选择...</asp:ListItem>
                        <asp:ListItem>日常订单</asp:ListItem>
                        <asp:ListItem>团购生日蛋糕订单</asp:ListItem>
                        <asp:ListItem>端午中秋订单</asp:ListItem>
                    </asp:DropDownList>
                  </td>
            </tr>
            <tr height="26" style="mso-height-source:userset;height:20.1pt">
                <td class="auto-style18" height="26">单位地址：</td>
                <td class="auto-style41">
                    <asp:TextBox ID="cust_addr" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" ></asp:TextBox>
                </td>
                <td class="auto-style32">付款方式：</td>
                <td class="auto-style36">
                    <asp:DropDownList ID="fktype" runat="server" CssClass="auto-style29">
                        <asp:ListItem>...请选择...</asp:ListItem>
                        <asp:ListItem>现金</asp:ListItem>
                        <asp:ListItem>转账</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style20">开票否：</td>
                <td class="auto-style19">
                    <asp:DropDownList ID="kp" runat="server" CssClass="auto-style29">
                        <asp:ListItem>...请选择...</asp:ListItem>
                        <asp:ListItem>开普票</asp:ListItem>
                        <asp:ListItem>开专用增值税发票</asp:ListItem>
                        <asp:ListItem>不开票</asp:ListItem>
                        <asp:ListItem>暂不开票</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="mso-height-source:userset;">
                <td class="auto-style21">提货地址：</td>
                <td class="auto-style42">
                    <asp:TextBox ID="thaddr" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" ></asp:TextBox>
                </td>
                <td class="auto-style31">客户联系人：</td>
                <td class="auto-style37">
                    <asp:TextBox ID="cust_body" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" ></asp:TextBox>
                </td>
                <td class="auto-style12">客户联系电话：</td>
                <td class="auto-style30">
                    <asp:TextBox ID="cust_body_tel" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" ></asp:TextBox>
                </td>
            </tr>
             <tr style="mso-height-source:userset;">
                <td class="auto-style21">加盟或直营：</td>
                <td class="auto-style42">
                    <asp:TextBox ID="jm" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderStyle="Double" Width="92%" ReadOnly="True"  ></asp:TextBox>
                </td>
                <td class="auto-style31">是否合同客户：</td>
                <td class="auto-style37">
                    <asp:DropDownList ID="htcustom" runat="server" CssClass="auto-style29">
                        <asp:ListItem>...请选择...</asp:ListItem>
                        <asp:ListItem>合同客户</asp:ListItem>
                        <asp:ListItem>普通客户</asp:ListItem>
                    </asp:DropDownList>
                 </td>
                <td class="auto-style12">
                    <asp:Label ID="Label2" runat="server" Text="是否已回款："></asp:Label>
                 </td>
                <td class="auto-style30">
                    <asp:DropDownList ID="hk" runat="server" CssClass="auto-style29" AutoPostBack="True" OnSelectedIndexChanged="plutype_SelectedIndexChanged">
                        <asp:ListItem>...请选择...</asp:ListItem>
                        <asp:ListItem>已回款</asp:ListItem>
                        <asp:ListItem>未回款</asp:ListItem>
                    </asp:DropDownList>
                 </td>
            </tr>
            <tr>
                <td class="auto-style21">是否远程储值：</td>
                <td class="auto-style49">
                    <asp:RadioButton ID="dep3" GroupName="depxz1" runat="server" Text="是" AutoPostBack="True" CssClass="auto-style38" OnCheckedChanged="yccz_CheckedChanged" Enabled="False" />
                    <asp:RadioButton ID="dep4" GroupName="depxz1" runat="server" Text="否" AutoPostBack="True" CssClass="auto-style38" OnCheckedChanged="yccz_CheckedChanged" Checked="True" Enabled="False" />
                </td> 
                <td class="auto-style31">起始卡号：<br />
                    <asp:TextBox ID="qscardid" runat="server" oninput="if(value.length>13)value=value.slice(0,13)" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" Enabled="False" ></asp:TextBox>
                </td>
                <td class="auto-style50">
                    <span class="auto-style51">结束卡号：<br />
                    </span>
                    <asp:TextBox ID="jscardid" runat="server" oninput="if(value.length>13)value=value.slice(0,13)" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" Enabled="False" ></asp:TextBox>
                </td>
                <td class="auto-style12">断号备注:</td>
                <td class="auto-style30">
                    <asp:TextBox ID="dhmemo" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" Enabled="False" ></asp:TextBox>
                </td>
            </tr>
            <tr style="mso-height-source:userset;">
                <td class="auto-style48" ></td>
            </tr>
            <tr height="26" style="mso-height-source:userset;height:20.1pt">
                <td class="auto-style18" height="26">商品编号：</td>
                <td class="auto-style41">
                    <asp:TextBox ID="plucode" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" ></asp:TextBox>
                </td> 
                <td class="auto-style32">商品名称：<asp:TextBox ID="pluname0" runat="server" BackColor="#00FF99" BorderColor="#660033" BorderStyle="Double" BorderWidth="1px" Height="24px"  AutoPostBack ="True" Width="54px" OnTextChanged="pluname0_TextChanged" Visible="False"></asp:TextBox>
                </td>
                <td class="auto-style36">
                    <asp:DropDownList ID="pluname" runat="server" CssClass="auto-style29" Width="150px">
                    </asp:DropDownList>
                </td>
                <td class="auto-style20">商品数量：</td>
                <td class="auto-style3">
                    <asp:TextBox ID="count" runat="server" onkeyup="calc()" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" TextMode="Number" >0</asp:TextBox>
                </td>
            </tr>
            <tr height="26" style="mso-height-source:userset;height:20.1pt">
                <td class="auto-style18" height="26">单价或面值：</td>
                <td class="auto-style41">
                    <asp:TextBox ID="price" runat="server" onkeyup="calc()" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" ReadOnly="True" >0</asp:TextBox>
                </td>
                <td class="auto-style23">折扣：</td>
                <td class="auto-style36">
                    <asp:TextBox ID="zk" runat="server" onkeyup="calc()" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" TextMode="Number" >0</asp:TextBox>
                </td>
                <td class="auto-style7"><strong class="auto-style22">折后金额：</strong></td>
                <td class="auto-style3">
                    <asp:TextBox ID="sstotal" runat="server" onkeyup="calc()" CssClass="input normal" BackColor="#CCFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%"  >0</asp:TextBox></td>
            </tr>
             
           
            <tr style="mso-height-source:userset;">
                <td class="auto-style8"><span class="auto-style22">订单备注：</span></td>
                <td class="auto-style10" colspan="5">
                    <asp:TextBox ID="memo" runat="server" Height="95%" TextMode="MultiLine" Width="95%" CssClass="auto-style17" BackColor="#CCFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px"></asp:TextBox>
                </td>
            </tr>
             <tr height="26" style="mso-height-source:userset;height:20.1pt">
                <td class="auto-style18" height="26"><strong>部门主管：</strong></td>
                <td class="auto-style41">
                    <asp:TextBox ID="next_person" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" AutoPostBack="True" OnTextChanged="next_person_TextChanged" ></asp:TextBox></td>
                <td class="auto-style33">
                    <asp:Button ID="Button1" runat="server" Height="30px" Text="添加商品" Width="98%" CssClass="auto-style17" OnClientClick="return confirm('确认商品信息无误！');" OnClick="Button1_Click" />
                    <font class="auto-style29" size="3">　</font></td>
                <td class="auto-style36">
                    整单合计：　<asp:Label ID="Label1" runat="server" Text="0"></asp:Label>
                 </td>
                <td class="auto-style16">
                    实收：<asp:TextBox ID="ss" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="50%" ></asp:TextBox>
                 </td>
                <td class="auto-style27">&nbsp;<asp:Button ID="Button2" runat="server" Height="30px" Text="保存订单" Width="90%" CssClass="auto-style17" OnClientClick="return confirm('请确认订单信息无误，确认后不能再修改！');" OnClick="Button2_Click" />
                 </td>
            </tr>
            </table>
                </div>
    <div>
        <br>
    <hr style="height: -13px">
         <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                        CellPadding="3" Font-Size="9pt"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"  OnRowDeleting="GridView1_RowDeleting" Height="149px" Width="864px">
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <Columns>
                        <asp:CommandField HeaderText="删除" ShowDeleteButton="True" >
                        <ItemStyle ForeColor="#0099CC" />
                        </asp:CommandField>
                            <asp:BoundField DataField="saleno"            HeaderText="单据号"/>
                            <asp:BoundField DataField="ID"                HeaderText="PID"/>
                            <asp:BoundField DataField="plucode"           HeaderText="商品编号"/>                           
                            <asp:BoundField DataField="pluname"           HeaderText="商品名称"/>
                            <asp:BoundField DataField="price"             HeaderText="单价"/>
                            <asp:BoundField DataField="count"             HeaderText="数量"/>
                            <asp:BoundField DataField="unit"              HeaderText="单位"/>
                            <asp:BoundField DataField="ystotal"           HeaderText="金额(元)"/>
                            <asp:BoundField DataField="zk"                HeaderText="折扣"/>
                            <asp:BoundField DataField="sstotal"           HeaderText="折后金额"/>
                            <asp:BoundField DataField="jobno"             HeaderText="录入人"/>                                                       
                        </Columns>
                        <RowStyle ForeColor="#000066" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
    
    </div>
            </center>
    </form>
</body>
</html>
