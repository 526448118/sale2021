<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mdjk.aspx.cs" Inherits="grace_Default1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">

    function PlayMedia()
{
    var mediaPlugin = document.getElementById("MediaPlayer");
    mediaPlugin.controls.play();
}
function PauseMedia()
{
    var mediaPlugin = document.getElementById("MediaPlayer");
    mediaPlugin.controls.pause();
}
        </script>
    <style type="text/css">

        *{border-style: none;
    border-color: inherit;
    border-width: 0;
    font-size:small;
padding:0;
    margin-left: 0;
    margin-right: 0;
    margin-bottom: 9;
}
table{border-collapse:collapse;border-spacing: 0;}
        .auto-style1 {
            height: 24pt;
            width: 1000pt;
            color: black;
            font-size: x-large;
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
	.input.normal{ text-align: center;
        }
	.input{ padding:5px 4px; min-height:20px; line-height:20px; border:1px solid #d4d4d4; background:#fff; vertical-align:middle; color:#333; font-size:100%; }
	.input{ padding:5px 4px; min-height:20px; line-height:20px; border:1px solid #66C9F3; background:#fff; vertical-align:middle; color:#333; font-size:100%; }
        .auto-style52 {
            height: 25pt;
            color: black;
            font-size: medium;
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
            width: 163px;
            background-color: #FFCCFF;
        }
        .auto-style53 {
            height: 25pt;
            color: black;
            font-size: medium;
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
            width: 163px;
            background-color: #FFFFFF;
        }
    </style>
</head>
<body style="height: 615px; text-align: center">
    <form id="form1" runat="server">
        <table border="0" style="border-collapse:
 collapse;width:800pt; height: 113px;">

            <tr style="mso-height-source:userset;">
                <td class="auto-style1">&nbsp; 门店缴款平台<asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
               </table>
        <table border="0" style="border-collapse:
 collapse;width:800pt; height: 113px;">

            <tr style="mso-height-source:userset;">
                <td class="auto-style52">&nbsp;</td>
                <td class="auto-style52">门店编码</td>
                <td class="auto-style52">
                    门店名</td>
                <td class="auto-style52">
                    督导</td>
                <td class="auto-style52">
                    区域经理</td>
                <td class="auto-style52">
                    录入人</td>
                <td class="auto-style52">
                    欠款日期</td>
                <td class="auto-style52">
                    </td>
            </tr>
            <tr style="mso-height-source:userset;">
                <td class="auto-style53"><span class="auto-style54"><asp:Label ID="billno" runat="server"></asp:Label>
                    </span>
                </td>
                <td class="auto-style53">
                    <asp:Label ID="orgcode" runat="server"></asp:Label>
                </td>
                <td class="auto-style53">
                    <asp:Label ID="orgname" runat="server"></asp:Label>
                </td>
                <td class="auto-style53">
                    <asp:Label ID="dudao" runat="server"></asp:Label>
                </td>
                <td class="auto-style53">
                    <asp:Label ID="jingli" runat="server"></asp:Label>
                </td>
                <td class="auto-style53">
                    <span class="auto-style54">
                    <asp:Label ID="lrr2" runat="server" Text="[录入人]"></asp:Label>
                    </span>
                </td>
                <td class="auto-style53">
                    <asp:TextBox ID="qkdate" runat="server" Width="90%" CssClass="input normal" onclick="WdatePicker()" BorderColor="#DDFFFF" BorderStyle="Double" OnTextChanged="bgndate_TextChanged"></asp:TextBox></td>
                <td class="auto-style53">
                    <asp:Button ID="Buttoncx" runat="server" Height="17px" Text="查询欠款" Width="100px" OnClick="Buttoncx_Click" />
                </td>
            </tr>
            <tr style="mso-height-source:userset;">
                <td class="auto-style52">缴款说明</td>
                <td class="auto-style52">缴款ID</td>
                <td class="auto-style52">
                    应存金额</td>
                <td class="auto-style52">
                    门店存款</td>
                <td class="auto-style52">
                    存款日期</td>
                <td class="auto-style52">
                    &nbsp;</td>
                <td class="auto-style52">
                    备注</td>
                <td class="auto-style52">
                    &nbsp;</td>
            </tr>
            <tr style="mso-height-source:userset;">
                <td class="auto-style53">
                    <asp:DropDownList ID="qksm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="qkid_SelectedIndexChanged" style="height: 13px">
                    </asp:DropDownList>
                </td>
                <td class="auto-style53">
                    <asp:Label ID="qkid" runat="server"></asp:Label>
                </td>
                <td class="auto-style53">
                    <asp:Label ID="yc" runat="server"></asp:Label>
                </td>
                <td class="auto-style53">
                    <asp:TextBox ID="mdck" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderStyle="Double" Width="90%" ></asp:TextBox>
                </td>
                <td class="auto-style53">
                    <asp:TextBox ID="ckdate" runat="server" CssClass="input normal" BackColor="#DDFFFF" onclick="WdatePicker()" BorderStyle="Double" Width="90%" ></asp:TextBox>
                </td>
                <td class="auto-style53">
                    &nbsp;</td>
                <td class="auto-style53">
                    <asp:TextBox ID="memo" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderStyle="Double" Width="90%" ></asp:TextBox>
                </td>
                <td class="auto-style53">
                    <asp:Button ID="Button1" runat="server" Height="17px" Text="点击提交" Width="100px" OnClick="Button1_Click" />
                </td>
            </tr>
               </table>
        <br />
        <br />
        <br />
    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                        CellPadding="3" Font-Size="9pt"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Height="149px" Width="1200px">
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <Columns>
                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="序号"             HeaderText="序号"/>
                            <asp:BoundField DataField="单号"             HeaderText="单号"/>
                            <asp:BoundField DataField="门店编号"           HeaderText="门店编号"/>
                            <asp:BoundField DataField="门店名"           HeaderText="门店名"/>
                            <asp:BoundField DataField="欠款日期"             HeaderText="欠款日期"/>    
                            <asp:BoundField DataField="款项ID"            HeaderText="款项ID"/>
                            <asp:BoundField DataField="缴款说明"             HeaderText="缴款说明"/>
                            <asp:BoundField DataField="应存金额"           HeaderText="应存金额"/>
                            <asp:BoundField DataField="实存金额"           HeaderText="实存金额"/>                           
                            <asp:BoundField DataField="财务核实金额"             HeaderText="财务核实金额"/>
                            <asp:BoundField DataField="未缴金额"             HeaderText="未缴金额"/>                          
                            <asp:BoundField DataField="财务导入人"             HeaderText="财务导入人"/>
                            <asp:BoundField DataField="导入时间"          HeaderText="导入时间"/>   
                            <asp:BoundField DataField="备注"          HeaderText="备注"/>
                            <asp:BoundField DataField="门店更新时间"              HeaderText="门店更新时间"/>
                            <asp:BoundField DataField="财务确认时间"              HeaderText="财务确认时间"/>                           
                            <asp:BoundField DataField="单据状态"              HeaderText="单据状态"/>
                            <asp:TemplateField HeaderText ="修改" HeaderStyle-Width ="40px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="ButtonEdit" runat="server" Text ="修改" OnClick="btnDown_Click" CommandArgument='<%# Bind("序号") %>'></asp:LinkButton>
                                </ItemTemplate>   
                                <ItemStyle Width="40px" />
                              </asp:TemplateField>                                                         
                        </Columns>
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
    
    </form>

</body>
</html>
