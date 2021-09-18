<%@ Page Language="C#" AutoEventWireup="true" CodeFile="plucode.aspx.cs" Inherits="grace_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
            width: 651pt;
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
        .auto-style43 {
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
        }
        .auto-style44 {
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
            width: 110pt;
        }
        .input.normal{ width:300px; }
	.input.normal{ text-align: left;
        }
	.input{ padding:5px 4px; min-height:20px; line-height:20px; border:1px solid #d4d4d4; background:#fff; vertical-align:middle; color:#333; font-size:100%; }
	.input{ padding:5px 4px; min-height:20px; line-height:20px; border:1px solid #66C9F3; background:#fff; vertical-align:middle; color:#333; font-size:100%; }
	    .auto-style45 {
            height: 25pt;
            color: black;
            font-size: medium;
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
            width: 106pt;
        }
        .auto-style13 {
            height: 25pt;
            color: black;
            font-size: 11.0pt;
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
            width: 93pt;
        }
        .auto-style18 {
            height: 35px;
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
            height: 35px;
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
            width: 106pt;
            height: 35px;
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
            height: 35px;
            width: 93pt;
        }
        textarea{ overflow:auto; }

textarea{ overflow:auto; }
        .auto-style46 {
            height: 25pt;
            color: black;
            font-size: 11.0pt;
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
            width: 107pt;
        }
        .auto-style47 {
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
            height: 35px;
            width: 107pt;
        }
    </style>
</head>
<body style="height: 452px; text-align: center">
    <form id="form1" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse;width:750pt; height: 113px;">
            <colgroup>
                <col style="mso-width-source:userset;mso-width-alt:3104;" />
                <col style="mso-width-source:userset;mso-width-alt:5920;" />
                <col style="mso-width-source:userset;mso-width-alt:4000;" />
                <col style="mso-width-source:userset;mso-width-alt:4896;" />
                <col style="mso-width-source:userset;mso-width-alt:4896;" />
                <col style="mso-width-source:userset;mso-width-alt:5888;" />
                <col style="mso-width-source:userset;mso-width-alt:5888;width:138pt" width="184" />
            </colgroup>
            <tr style="mso-height-source:userset;">
                <td class="auto-style1" colspan="7">&nbsp; 商品税收编码录入</td>
            </tr>
            <tr style="mso-height-source:userset;">
                <td class="auto-style43">商品名</td>
                <td class="auto-style44">
                    税收编码</td>
                <td class="auto-style45">
                    税收编码版本</td>
                <td class="auto-style44">
                    税率</td>
                <td class="auto-style44">
                    备注</td>
                <td class="auto-style13">
                    </td>
                <td class="auto-style46">
                    批量上传</td>
            </tr>
            <tr style="mso-height-source:userset;">
                <td class="auto-style18">
                    <asp:TextBox ID="pluname" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderStyle="Double" Width="90%" ></asp:TextBox>
                </td>
                <td class="auto-style40">
                    <asp:TextBox ID="s_code" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderStyle="Double" Width="90%" ></asp:TextBox>
                </td>
                <td class="auto-style32">
                    <asp:TextBox ID="s_code_ver" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderStyle="Double" Width="90%" ></asp:TextBox>
                </td>
                <td class="auto-style40">
                    <asp:TextBox ID="shuilv" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderStyle="Double" Width="90%" ></asp:TextBox>
                </td>
                <td class="auto-style40">
                    <asp:TextBox ID="memo" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderStyle="Double" Width="90%" ></asp:TextBox>
                </td>
                <td class="auto-style14">
                    <asp:Button ID="Button1" runat="server" Height="17px" Text="点击添加" Width="100px" OnClick="Button1_Click" />
                </td>
                <td class="auto-style47">
                    <asp:FileUpload ID="FileUpload1" runat="server" BorderWidth="1px" Height="21px" Width="142px" />                    
                </td>
            </tr>
            <tr style="mso-height-source:userset;">
                <td class="auto-style18">
                     <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" Font-Size="9pt" OnCheckedChanged="CheckBox2_CheckedChanged"
                        Text="全选" />
                &nbsp;
                    <asp:Button ID="Button2" runat="server" Height="18px" Text="删除选中" Width="89px" OnClientClick="javascript:return confirm('确定要删除吗?');" OnClick="Button2_Click" />
                </td>
                <td class="auto-style40">
                    <asp:Button ID="Button3" runat="server" Height="18px" Text="更新" Width="60px" Enabled = "false" OnClick="Button3_Click" />
                &nbsp;
                    <asp:Button ID="Button4" runat="server" Height="18px" Text="取消" Width="60px" Enabled = "false" OnClick="Button4_Click" />
                </td>
                <td class="auto-style32">
                    &nbsp;</td>
                <td class="auto-style40">
                    &nbsp;</td>
                <td class="auto-style40">
                    &nbsp;</td>
                <td class="auto-style14">
                   <a href ="uploadfiles/m/税收编码模板.xlsx">模板下载<style="text-decoration: underline; width: 50px; color: #FF66FF"/></a></td>
                <td class="auto-style47">
                   <asp:Button ID="Button5" runat="server"  Text="确定上传" onclick="Button5_Click" /></td>
            </tr>
            <tr style="mso-height-source:userset;">
                <td class="auto-style18">
                     商品搜索</td>
                <td class="auto-style40">
                    <asp:TextBox ID="pluname0" runat="server" CssClass="input normal" BackColor="#DDFFFF" BorderStyle="Double" Width="90%" ></asp:TextBox>
                </td>
                <td class="auto-style32">
                    <asp:Button ID="Button6" runat="server" Height="17px" Text="搜索" Width="100px" OnClick="Button0_Click" />
                </td>
                <td class="auto-style40">
                    &nbsp;</td>
                <td class="auto-style40" colspan="3">
                    &nbsp;</td>
            </tr>
               </table>
        <br />
        <br />
        <br />
    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                        CellPadding="3" Font-Size="9pt"  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Height="149px" Width="864px">
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <Columns>
                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="com"              HeaderText="公司"/>
                            <asp:BoundField DataField="type"             HeaderText="商品名"/>
                            <asp:BoundField DataField="s_code"           HeaderText="税收编码"/>
                            <asp:BoundField DataField="shuilv"           HeaderText="税率"/>
                            <asp:BoundField DataField="s_code_ver"       HeaderText="税收编码版本号"/>                           
                            <asp:BoundField DataField="gxtime"           HeaderText="更新时间"/>
                            <asp:BoundField DataField="memo"             HeaderText="备注"/>   
                              <asp:TemplateField HeaderText ="编辑">
                                <ItemTemplate>
                                    <asp:LinkButton ID="ButtonEdit" runat="server" Text ="编辑" OnClick="btnDown_Click" CommandArgument='<%# Bind("type") %>'></asp:LinkButton>
                                </ItemTemplate>   
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
