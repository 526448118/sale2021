<%@ Page Language="C#" AutoEventWireup="true"    CodeFile="add_saleord_l2.aspx.cs" Inherits="_add_saleord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" http-equiv="refresh" content="60">
    <script src="../My97DatePicker/WdatePicker.js"></script>
    <script src="../js/jquery/jquery-1.10.2.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../js/datepicker/WdatePicker.js"></script>
    <link rel="stylesheet" type="text/css" href="jquery-easyui-1.6.7/themes/default/easyui.css"/>
    <link rel="stylesheet" type="text/css" href="jquery-easyui-1.6.7/themes/icon.css"/>
    <link rel="stylesheet" type="text/css" href="jquery-easyui-1.6.7/demo.css"/>
    <script type="text/javascript" src="jquery-easyui-1.6.7/jquery.min.js"></script>
    <script type="text/javascript" src="jquery-easyui-1.6.7/jquery.easyui.min.js"></script>           
    <script type="text/javascript" src="../js/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../js/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../js/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../js/swfupload/swfupload.queue.js"></script>
    <script type="text/javascript" src="../js/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <script type="text/javascript" src="../js/pinyin.js"></script>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>订单录入</title>
    <style type="text/css">
        .auto-style1 {
            height: 44pt;
            width: 600pt;
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
            .auto-style20 {
            height: 28pt;
            width:80pt;
            color: black;
            font-size: 10pt;
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
        }
        
        .auto-style21 {
            height: 28pt;
            width:120pt;
            color: black;
            font-size: 10pt;
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
           .auto-style23 {
            height: 28pt;
            width:80pt;
            color: black;
            font-size: 10pt;
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
        .auto-style38 {
            font-size: 12pt;
        }
   
        </style>

<script type="text/javascript">

   
    var tValue = "";
    var tValue1 = "";
    var tBillno = "";

    setInterval(function (event) {
        var value = document.getElementById("pluname").value;
        var value1 = document.getElementById("plutype").value;
        var tag1 = document.getElementById("tag").innerText;
        var billno = document.getElementById("billno").innerText;


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
                        if (tag1 == 0) {
                            document.getElementById("plucode").value = 0;
                            document.getElementById("price").value = 0;
                            document.getElementById("plucode").value = arr[0];
                            document.getElementById("price").value = arr[1];
                            document.getElementById("count").value = 0;
                            document.getElementById("zk").value = 0;
                        }
                        if (tag1 == 1) {
                            document.getElementById("plucode").value = arr[0];
                            document.getElementById("price").value = arr[1];
                        }
                    }
                    else {
                        alert("当前输入商品信息不存在！请重新输入.");
                        document.getElementById("plucode").value = "";
                        document.getElementById("price").value = "";
                    }

                },
                error: function (msg) {
                    alert("数据加载出错，请重试！");
                }
            });

        }
       
    }, 0);

    functionAjax1(function (event) {
        if (tBillno != billno) {
            tBillno = document.getElementById("billno").innerText;
            $.ajax({
                type: "POST",
                contentType: "application/json;charset=utf-8",
                //cache: false,
                url: "add_saleord_l2.aspx/GetBillno",
                data: JSON.stringify({ "billno": tBillno }),
                dataType: "json",

                success: function (data) {
                    if (data.d != null) {
                        var s = data.d;
                        alert(1 + s);

                        //$("#selectClassify").html(""); var html = ""; var selectJson = result.downList;
                        //$.each(selectJson, function (i, item) {
                        //    html = html + "" + item + "";
                        //});
                        //$("#selectClassify").append(html);
                    }
                },
                error: function (msg) {
                    alert("数据加载出错，请重试1！");
                }

            });
        }

    },2000);




  
    function SearchChange() {
        var ddl = document.getElementById("thaddr")
        var index = ddl.selectedIndex;

        var Value = ddl.options[index].value;
        var Text = ddl.options[index].text;
        document.getElementById('Label4').innerHTML = Value;
        document.getElementById('taddr').value = Text;
        //alert(Value);
    }


  


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
    <li><a href="../home.aspx">首页</a><a href="#">订单录入</a></li>
    </ul>
    </div> 
     
    <div class="itab">
    <ul><li>模板订单号：</li>
       <asp:TextBox ID="billno" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="154px" ></asp:TextBox>
 	    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Button" />
 	</ul>
    </div>  
  
    <div id="content">
        <table border="0"  style="border-collapse: collapse;width:600pt; height: 436px;">
           
            <tr>
                <td class="auto-style1" colspan="6" >客户订单录入
                    <asp:Label ID="Label3" runat="server" style="font-size: medium"></asp:Label>                    
                </td>
            </tr>
            <tr>
                <td class="auto-style20">销售中心：</td>
                <td class="auto-style21">
                    <asp:DropDownList ID="DropDownList1"  runat="server" Width="95%" Height="80%">
                        <asp:ListItem>总经办</asp:ListItem>
                        <asp:ListItem>信息中心</asp:ListItem>
                        <asp:ListItem>人资部</asp:ListItem>
                        <asp:ListItem>财务部</asp:ListItem>
                        <asp:ListItem>项目部</asp:ListItem>
                        <asp:ListItem>总务部</asp:ListItem>
                        <asp:ListItem>采购部</asp:ListItem>
                        <asp:ListItem>生产部</asp:ListItem>
                        <asp:ListItem>品控部</asp:ListItem>
                        <asp:ListItem>仓库部</asp:ListItem>
                        <asp:ListItem>物流部</asp:ListItem>
                        <asp:ListItem>营销中心</asp:ListItem>
                        <asp:ListItem>企划部</asp:ListItem>
                        <asp:ListItem>市场部</asp:ListItem>
                        <asp:ListItem>业务部</asp:ListItem>                        
                        <asp:ListItem>客服部</asp:ListItem>
                        <asp:ListItem>门市部</asp:ListItem>
                        <asp:ListItem>加盟组</asp:ListItem>
                        <asp:ListItem>经销商</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style20">
                    <asp:RadioButton ID="dep01" GroupName="depxz" runat="server" Text="门店" AutoPostBack="True" CssClass="auto-style38" OnCheckedChanged="dep01_CheckedChanged" />
                    <asp:RadioButton ID="dep02" GroupName="depxz" runat="server" Text="部门" CssClass="auto-style38" OnCheckedChanged="dep02_CheckedChanged" />
                </td>
                <td class="auto-style21">
                    <asp:TextBox ID="dept" runat="server" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" Height="80%" AutoPostBack="True" OnTextChanged="dept_TextChanged" ></asp:TextBox>
                </td>
                <td class="auto-style20">业务员：</td>
                <td class="auto-style21">
                    <asp:TextBox ID="saler" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" Height="80%" AutoPostBack="True" OnTextChanged="saler_TextChanged" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style20">业务员电话：</td>
                <td class="auto-style21">
                    <asp:TextBox ID="saler_tel" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" Height="80%" OnTextChanged="saler_tel_TextChanged" ></asp:TextBox>
                </td>
                <td class="auto-style20">下单日期：</td>
                <td class="auto-style21">
                    <asp:TextBox ID="lrdate" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" Height="80%"  onclick="WdatePicker()"></asp:TextBox>
                </td>
                <td class="auto-style20">提货日期：</td>
                <td class="auto-style21">
                    <asp:TextBox ID="thdate" runat="server"  CssClass="input date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}\s{1}(\d{1,2}:){2}\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" "  BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" Height="80%"  ></asp:TextBox>
                </td>
            </tr>
               <tr>
                <td class="auto-style20">订单来源：</td>
                <td class="auto-style21">
                    <asp:DropDownList ID="ord_from" runat="server" Width="95%" Height="80%">
                        <asp:ListItem>...请选择...</asp:ListItem>
                        <asp:ListItem>门市</asp:ListItem>
                        <asp:ListItem>行政</asp:ListItem>
                        <asp:ListItem>业务</asp:ListItem>
                        <asp:ListItem>经销商</asp:ListItem>
                        <asp:ListItem>加盟业主</asp:ListItem>
                        <asp:ListItem>市场</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style20">提货方式：</td>
                <td class="auto-style21">
                    <asp:DropDownList ID="thtype" runat="server" Width="95%" Height="80%" AutoPostBack="True" OnSelectedIndexChanged="thtype_SelectedIndexChanged">
                        <asp:ListItem>...请选择...</asp:ListItem>
                        <asp:ListItem>门店自提</asp:ListItem>
                        <asp:ListItem>送货到府</asp:ListItem>
                        <asp:ListItem>工厂自提</asp:ListItem>
                        <asp:ListItem>创业园办公区自提</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style20">商品类型：</td>
                <td class="auto-style21">
                    <asp:DropDownList ID="plutype" runat="server" Width="95%" Height="80%" AutoPostBack="True" OnSelectedIndexChanged="plutype_SelectedIndexChanged">
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
              <tr>
                <td class="auto-style20">客户名称：</td>
                <td class="auto-style21">
                  <asp:TextBox ID="cust" runat="server"  BackColor="#00CCFF" width="135px"  height="28px" style="  position: absolute;  top:auto; left: auto" AutoPostBack="true" OnTextChanged="cust_Change"></asp:TextBox>
                  <asp:DropDownList ID="custname" runat="server"  BackColor="#DDFFFF" BorderColor="#00CCFF" AutoPostBack="true" onchange="document.getElementById('cust').value=this.options[this.selectedIndex].text" width="150px" height="28px" style="clip: rect(auto auto auto 120px); "  BorderStyle="Double" BorderWidth="1px" OnSelectedIndexChanged="custname_SelectedIndexChanged"   >
                      <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style20">客户税号：</td>
                <td class="auto-style21">
                    <asp:TextBox ID="cust_tax_code" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" Height="80%" ></asp:TextBox>
                </td>
                <td class="auto-style20">定单类型：</td>
                <td class="auto-style21">
                    <asp:DropDownList ID="ord_type" runat="server"  Width="95%" Height="80%">
                        <asp:ListItem>...请选择...</asp:ListItem>
                        <asp:ListItem>日常订单</asp:ListItem>
                        <asp:ListItem>团购生日蛋糕订单</asp:ListItem>
                        <asp:ListItem>端午中秋订单</asp:ListItem>
                    </asp:DropDownList>
                  </td>
            </tr>
            <tr>
                <td class="auto-style20">单位地址：</td>
                <td class="auto-style21">
                    <asp:TextBox ID="cust_addr" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" Height="80%" ></asp:TextBox>
                </td>
                <td class="auto-style20">付款方式：</td>
                <td class="auto-style21">
                    <asp:DropDownList ID="fktype" runat="server" Width="95%" Height="80%">
                        <asp:ListItem>...请选择...</asp:ListItem>
                        <asp:ListItem>现金</asp:ListItem>
                        <asp:ListItem>转账</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style20">开票否：</td>
                <td class="auto-style21">
                    <asp:DropDownList ID="kp" runat="server" Width="95%" Height="80%">
                        <asp:ListItem>...请选择...</asp:ListItem>
                        <asp:ListItem>是</asp:ListItem>
                        <asp:ListItem>否</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style20">提货地址：<asp:Label ID="Label4" runat="server"></asp:Label>
                </td>
                <td class="auto-style21">
                    <asp:TextBox ID="taddr" runat="server"  BackColor="#00CCFF" width="135px"  height="28px" style="  position: absolute; top:auto; left: auto;" ></asp:TextBox>
                     <asp:DropDownList ID="thaddr" runat="server"  BackColor="#DDFFFF" BorderColor="#00CCFF"  onchange="SearchChange();" width="150px" height="28px" style="clip: rect(auto auto auto 100px); "  BorderStyle="Double" BorderWidth="1px"  ></asp:DropDownList>
                </td>
                <td class="auto-style20">客户联系人：</td>
                <td class="auto-style21">
                    <asp:TextBox ID="cust_body" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" Height="80%" ></asp:TextBox>
                </td>
                <td class="auto-style20">客户联系电话：</td>
                <td class="auto-style21">
                    <asp:TextBox ID="cust_body_tel" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" Height="80%" ></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="auto-style20">加盟或直营：</td>
                <td class="auto-style21">
                    <asp:TextBox ID="jm" runat="server" CssClass="input normal" BackColor="#DDFFFF"  BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" Height="80%" ReadOnly="True"  ></asp:TextBox>
                </td>
                <td class="auto-style20">是否合同客户：</td>
                <td class="auto-style21">
                    <asp:DropDownList ID="htcustom" runat="server" Width="95%" Height="80%">
                        <asp:ListItem>...请选择...</asp:ListItem>
                        <asp:ListItem>合同客户</asp:ListItem>
                        <asp:ListItem>普通客户</asp:ListItem>
                    </asp:DropDownList>
                 </td>
                <td class="auto-style20">
                    <asp:Label ID="Label2" runat="server" Width="95%" Height="80%" Text="追加单："></asp:Label>
                 </td>
                <td class="auto-style21">
                    <asp:DropDownList ID="hk" runat="server" Width="95%" Height="80%">
                        <asp:ListItem>...请选择...</asp:ListItem>
                        <asp:ListItem>否</asp:ListItem>
                        <asp:ListItem>是</asp:ListItem>
                    </asp:DropDownList>
                 </td>
            </tr>
            <tr>
                <td class="auto-style20" rowspan="2">是否远程储值：</td>
                <td class="auto-style21" rowspan="2">
                    <asp:RadioButton ID="dep3" GroupName="depxz1" runat="server" Text="是" AutoPostBack="True" CssClass="auto-style38" OnCheckedChanged="yccz_CheckedChanged" Enabled="False" />
                    <asp:RadioButton ID="dep4" GroupName="depxz1" runat="server" Text="否" AutoPostBack="True" CssClass="auto-style38" OnCheckedChanged="yccz_CheckedChanged" Checked="True" Enabled="False" />
                </td> 
                <td class="auto-style20">起始卡号：</td>
                <td class="auto-style21">
                    <asp:TextBox ID="qscardid" runat="server" oninput="if(value.length>13)value=value.slice(0,13)" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" Height="80%" Enabled="False" ></asp:TextBox>
                    <br />                    
                </td>
                <td class="auto-style20" rowspan="2">断号备注:</td>
                <td class="auto-style21" rowspan="2">
                    <asp:TextBox ID="dhmemo" runat="server" CssClass="input normal" TextMode="MultiLine"  BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" Height="80%"  Enabled="False" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style20">结束卡号：</td>
                <td class="auto-style21">                    
                    <asp:TextBox ID="jscardid" runat="server" oninput="if(value.length>13)value=value.slice(0,13)" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" Height="80%" Enabled="False" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height ="30px"></td>
            </tr>
            <tr>
                <td class="auto-style20">商品编号：</td>
                <td class="auto-style21">
                    <asp:TextBox ID="plucode" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" Height="80%" ></asp:TextBox>
                </td> 
                <td class="auto-style20">商品名称：
                </td>
                <td class="auto-style21">
                    <asp:TextBox ID="pluname0" runat="server" width="135"  BackColor="#00FF99" height="28px" style="position: absolute; top:auto; left: auto;"   AutoPostBack ="True" OnTextChanged="pluname0_TextChanged" Visible="False"></asp:TextBox>
                    <asp:DropDownList ID="pluname" runat="server" onchange="document.getElementById('pluname0').value=this.options[this.selectedIndex].text" width="150px" height="28px" style="clip: rect(auto auto auto 120px); "> </asp:DropDownList>
                </td>
                <td class="auto-style20">商品数量：</td>
                <td class="auto-style21">
                    <asp:TextBox ID="count" runat="server" onkeyup="calc()" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" Height="80%" TextMode="Number" >0</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style20">单价或面值：</td>
                <td class="auto-style21">
                    <asp:TextBox ID="price" runat="server" onkeyup="calc()" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" Height="80%" ReadOnly="True" >0</asp:TextBox>
                </td>
                <td class="auto-style20">折扣：</td>
                <td class="auto-style21">
                    <asp:TextBox ID="zk" runat="server" onkeyup="calc()" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" Height="80%" TextMode="Number" >0</asp:TextBox>
                </td>
                <td class="auto-style20"><strong>折后金额：</strong></td>
                <td class="auto-style21">
                    <asp:TextBox ID="sstotal" runat="server" onkeyup="calc()" CssClass="input normal" BackColor="#CCFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" Height="80%"  >0</asp:TextBox></td>
            </tr>
             
           
            <tr>
                <td class="auto-style20">订单备注：</td>
                <td class="auto-style23" colspan="5" rowspan="2">
                    <asp:TextBox ID="memo" runat="server" Height="80%" TextMode="MultiLine" Width="98.6%"   BackColor="#CCFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px"></asp:TextBox>
                </td>
            </tr>
             
           
            <tr>
                <td class="auto-style20"><asp:Label ID="tag" runat="server"  ></asp:Label>
                </td>
            </tr>
             <tr>
                <td class="auto-style20"><strong>部门主管：</strong></td>
                <td class="auto-style21">
                    <asp:TextBox ID="next_person" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" Height="80%" AutoPostBack="True" OnTextChanged="next_person_TextChanged" ></asp:TextBox></td>
                <td class="auto-style23">
                    <asp:Button ID="Button1" runat="server" Height="30px" Text="添加商品" Width="95%"  OnClientClick="return confirm('确认商品信息无误！');" OnClick="Button1_Click" />
                 </td>
                <td class="auto-style21">
                    整单合计：　<asp:Label ID="Label1" runat="server" Text="0"></asp:Label>
                 </td>
                <td class="auto-style20"> 
                    实收：<br/><asp:TextBox ID="ss" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" Height="50%" ></asp:TextBox>
                 </td>
                <td class="auto-style21">
                    <asp:Button ID="Button2" runat="server" Height="30px" Text="保存订单" Width="90%" CssClass="auto-style17" OnClientClick="return confirm('请确认订单信息无误，确认后不能再修改！');" OnClick="Button2_Click" />
                 </td>
            </tr>
            </table>
                </div>


    <div>   
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
