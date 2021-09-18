<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="grace_hl_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <script type="text/javascript">
    function SelectAll(aControl) {
        var tempControl = aControl;
        var isChecked = tempControl.checked;

        elem = tempControl.form.elements;
        for (i = 0; i < elem.length; i++)
            if (elem[i].type == "checkbox" && elem[i].id != tempControl.id) {
                if (elem[i].checked != isChecked)
                    elem[i].click();
            }
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
    <div id="main">
    <div id="search">
       <table>
<tr>
<td>
    <asp:TextBox ID="SearchName" runat="server"></asp:TextBox>
</td>
<td>
    <asp:Button ID="btnSearch" runat="server" Text="查询" onclick="PagerBtnCommand_OnClick" CommandName="search" />
</td>
<td>
    <asp:Button ID="btnReset" runat="server" Text="重置" onclick="btnReset_Click" />
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
</td>
</tr>
</table>
    </div>
    <div id="gridView">
     <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
         <Columns>
         <asp:TemplateField>
                <HeaderTemplate>
                <asp:CheckBox runat="server" ID="cbHead" onclick="javascript:SelectAll(this)" AutoPostBack="true">
                </asp:CheckBox>
           </HeaderTemplate>
               <ItemTemplate>
                     <asp:CheckBox ID="CheckBox1" runat="server" />
               </ItemTemplate>
         </asp:TemplateField>
         </Columns>
      </asp:GridView>
        <asp:GridView ID="GridView2" runat="server" Visible="False">
        </asp:GridView>
    </div>
    <div id="page">
    <table>
     <tr>
     <td>
      <asp:Label ID="lbcurrentpage1" runat="server" Text="当前页:"></asp:Label>
    <asp:Label ID="lbCurrentPage" runat="server" Text=""></asp:Label>
    <asp:Label ID="lbFenGe" runat="server" Text="/"></asp:Label>
    <asp:Label ID="lbPageCount" runat="server" Text=""></asp:Label>
    </td>
     <td>
     <asp:Label ID="recordscount" runat="server" Text="总条数:"></asp:Label>
      <asp:Label ID="lbRecordCount" runat="server" Text=""></asp:Label>
    </td>
    <td>
<asp:Button ID="Fistpage" runat="server" CommandName="" Text="首页" OnClick="PagerBtnCommand_OnClick" />
<asp:Button ID="Prevpage" runat="server" CommandName="prev" Text="上一页"
        OnClick="PagerBtnCommand_OnClick" />
<asp:Button ID="Nextpage" runat="server" CommandName="next" Text="下一页" OnClick="PagerBtnCommand_OnClick" />
<asp:Button ID="Lastpage" runat="server" CommandName="last" Text="尾页"
       key="last" OnClick="PagerBtnCommand_OnClick" />
</td>
    <td>
    <asp:Label ID="lbjumppage" runat="server" Text="跳转到第"></asp:Label>
    <asp:TextBox ID="GotoPage" runat="server" Width="25px"></asp:TextBox>
    <asp:Label ID="lbye" runat="server" Text="页"></asp:Label>
      <asp:Button ID="Jump" runat="server" Text="跳转" CommandName="jump" OnClick="PagerBtnCommand_OnClick" />
    </td>
</tr>
</table>
    </div>
    </div>
    </div>        
    </form>
</body>
</html>
