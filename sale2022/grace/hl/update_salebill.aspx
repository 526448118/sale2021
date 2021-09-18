<%@ Page Language="C#" AutoEventWireup="true" CodeFile="update_salebill.aspx.cs" Inherits="_add_saleord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" http-equiv="refresh" content="60">
       <script src="../My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../js/datepicker/WdatePicker.js"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>订单录入</title>
    <style type="text/css">
        .auto-style1 {
            height: 28pt;
            width: 866pt;
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
    <div class="itab">
  	<ul> 
    <li><a href="product_add.aspx" class="selected">增加发票申请单</a></li> 
  	</ul>
    </div>  
       <center>
    <div id="content">
        <table border="0" style="border-collapse: collapse;width:600pt; height: 500px;">
            
            <tr>
                <td class="auto-style1" colspan="6">发票申请资料录入</td>
            </tr>
            <tr>
                <td class="auto-style20">中 心：</td>
                <td class="auto-style21">
                    <asp:TextBox ID="cen" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" Width="95%" Height="80%"></asp:TextBox>
                </td>
                <td class="auto-style20">
                    <asp:RadioButton ID="dep01" runat="server" AutoPostBack="True" GroupName="1" OnCheckedChanged="rad2_CheckedChanged" Text="门店" />
                    <asp:RadioButton ID="dep02" runat="server" GroupName="1" OnCheckedChanged="rad1_CheckedChanged" Text="部门" />
                </td>
                <td class="auto-style21">
                    <asp:TextBox ID="dept" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" Height="80%" AutoPostBack="True" OnTextChanged="dept_TextChanged" ></asp:TextBox>
                </td>
                <td class="auto-style20">发票类型：</td>
                <td class="auto-style21" id="yw_type" >
                    <asp:DropDownList ID="billtype" runat="server" Width ="95%" Height="80%">
                        <asp:ListItem>...请选择...</asp:ListItem>
                        <asp:ListItem>专用增值税发票</asp:ListItem>
                        <asp:ListItem>普票</asp:ListItem>
                        <asp:ListItem>电子发票</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style20">业务员：</td>
                <td class="auto-style21">
                    <asp:TextBox ID="yw_people" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" Height="80%" Width="95%" ></asp:TextBox>
                </td>
                <td class="auto-style20">业务员电话：</td>
                <td class="auto-style21">
                    <asp:TextBox ID="yw_peopletell" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" Height="80%"  Width="95%" ></asp:TextBox>
                </td>
                <td class="auto-style20">开票记录：</td>
                <td class="auto-style21">
                    <asp:DropDownList ID="tick_record" runat="server" Width ="95%" Height="80%">
                        <asp:ListItem>...请选择...</asp:ListItem>
                        <asp:ListItem>新开</asp:ListItem>
                        <asp:ListItem>重开</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
             <tr>
                <td class="auto-style20">销售来源:</td>
                <td class="auto-style21">
                    <asp:DropDownList ID="sale_source" runat="server" Width ="95%" Height="80%">
                        <asp:ListItem>...请选择...</asp:ListItem>
                        <asp:ListItem>卡券团单</asp:ListItem>
                        <asp:ListItem>实物团单</asp:ListItem>
                        <asp:ListItem>收银小票</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style20">收货地址:</td>
                <td class="auto-style21">
                    <asp:TextBox ID="rec_address" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" Width="95%"  Height="80%"></asp:TextBox>
                </td>
                <td class="auto-style20">是否直营：</td>
                <td class="auto-style21">
                    <asp:TextBox ID="IS_ZY" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" Width="95%" ReadOnly="True"  Height="80%"></asp:TextBox>
                 </td>
            </tr>
            <tr>
                <td class="auto-style20">订单号（可填多张）：</td>
                <td class="auto-style21" colspan="5">
                    <asp:TextBox ID="ordbillno" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" Width="99%" Height="80%"></asp:TextBox>
                </td>
            </tr>
               <tr>
                <td class="auto-style20">客户名称：</td>
                <td class="auto-style21" colspan="5">
                    <asp:TextBox ID="custom" runat="server" CssClass="input normal" BackColor="#DDFFFF"  BorderColor="#00CCFF" BorderStyle="Double" Width="99%"  Height="80%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style20">税号：</td>
                <td class="auto-style21" colspan="5">
                    <asp:TextBox ID="shuihao" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" Width="99%" Height="80%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style20">客户地址：</td>
                <td class="auto-style21" colspan="5">
                    <asp:TextBox ID="address" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF"  BorderStyle="Double" Width="99%" Height="80%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style20">开户银行：</td>
                <td class="auto-style21" colspan="2">
                    <asp:TextBox ID="bank" runat="server" CssClass="input normal" BackColor="#DDFFFF"  BorderColor="#00CCFF" BorderStyle="Double" Width="95%" Height="80%" ></asp:TextBox>
                </td>
                <td class="auto-style20">银行账户：</td>
                <td class="auto-style21" colspan="2">
                    <asp:TextBox ID="bank_acc" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" Width="95%" Height="80%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style20">客户邮箱：</td>
                <td class="auto-style21" colspan="2">
                    <asp:TextBox ID="email" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%"  Height="80%"></asp:TextBox>
                </td>
                <td class="auto-style20">客户电话：</td>
                <td class="auto-style21" colspan="2">
                    <asp:TextBox ID="tellphone" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" Height="80%" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style20">客户联系人：</td>
                <td class="auto-style21" colspan="2">
                    <asp:TextBox ID="cust_lxr" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" Height="80%"></asp:TextBox>
                </td>
                <td class="auto-style20">客户联系人电话：</td>
                <td class="auto-style21" colspan="2">
                    <asp:TextBox ID="lxr_tel" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="96%" Height="80%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style20">备注信息：</td>
                <td class="auto-style21" colspan="5">
                    <asp:TextBox ID="memo" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="99%" Height="80%" TextMode="MultiLine" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height:48px"></td>
            </tr>
            <tr>
                <td class="auto-style20">商品名称：</td>
                <td class="auto-style21">
                    <asp:TextBox ID="pluname" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" Height="80%"></asp:TextBox>
                </td>
                <td class="auto-style20">商品数量：</td>
                <td class="auto-style21">
                    <asp:TextBox ID="plucount" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" Height="80%"></asp:TextBox>
                 </td>
                <td class="auto-style20">
                    商品总金额：</td>
                <td class="auto-style21">
                    <asp:TextBox ID="sstotal" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" Height="80%"></asp:TextBox>
                 </td>
            </tr>
            <tr>
                <td class="auto-style20">商品规格型号：</td>
                <td class="auto-style21">
                    <asp:TextBox ID="plumodel" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" Height="80%"></asp:TextBox>
                 </td>
                <td class="auto-style20">商品单位：</td>
                <td class="auto-style21">
                    <asp:TextBox ID="pluunit" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderColor="#00CCFF" BorderStyle="Double" BorderWidth="1px" Width="95%" Height="80%"></asp:TextBox>
                 </td>
                <td class="auto-style20"></td>
                <td class="auto-style21"></td>
            </tr>
             
           
             <tr>
                <td class="auto-style20" colspan="2"><strong>先添加商品信息，再保存申请单。</strong></td>
                <td class="auto-style21" colspan="2">
                   <asp:Button ID="Button1" runat="server"  Text="添加商品信息" Width="95%" Height="80%" OnClientClick="return confirm('确认商品信息无误！');" OnClick="Button1_Click" />
                </td>
                <td class="auto-style20">
                    <asp:Button ID="Button2" runat="server" Text="保存申请单" Width="95%"   Height="80%" OnClientClick="return confirm('请确认订单信息无误，确认后不能再修改！');" OnClick="Button2_Click" />
                    　</td>
                <td class="auto-style21">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
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
    </div>           
    </form>
</body>
</html>
