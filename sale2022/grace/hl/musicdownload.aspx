<%@ Page Language="C#" AutoEventWireup="true" CodeFile="musicdownload.aspx.cs" Inherits="grace_hl_musicdownload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>门店音乐下载</title>
    <style type="text/css">

table{border-collapse:collapse;border-spacing: 0;}
        
        *{border-style: none;
    border-color: inherit;
    border-width: 0;
    font-size:small;
padding:0;
    margin-left: 0;
    margin-right: 0;
    margin-bottom: 9;
}
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
        .input.normal{ text-align: center;
        }
	.input{ padding:5px 4px; min-height:20px; line-height:20px; border:1px solid #66C9F3; background:#fff; vertical-align:middle; color:#333; font-size:100%; }
        .input{ padding:5px 4px; min-height:20px; line-height:20px; border:1px solid #d4d4d4; background:#fff; vertical-align:middle; color:#333; font-size:100%; }
	    .auto-style54 {
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
            background-color: #FFCCFF;
            width: 121px;
        }
        .auto-style55 {
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
            width: 121px;
            background-color: #FFFFFF;
        }
	    .auto-style56 {
            font-size: xx-large;
        }
	</style>
</head>
<body>
    <form id="form1" runat="server">
        <p style="text-align: center">
            <asp:Image ID="Image2" runat="server" Height="98px" ImageUrl="../admin/igm/logo.png" Width="97px" CssClass="auto-style2" />
            <span class="auto-style56">门店音乐下载</span></p>
        <table border="0" style="border-collapse:
 collapse;width:564pt; height: 113px;" align="center">

            <tr >
                <td class="auto-style54">音乐说明</td>
                <td class="auto-style52">MP3格式</td>
                <td class="auto-style52">WMV格式</td>
                <td class="auto-style52">更新时间</td>
            </tr>
            <tr>
                <td class="auto-style55">日常音乐</td>
                <td class="auto-style53">
                    <a href ="E:\myfile\music\店铺音乐\2019门店普通音乐.mp3">点击下载<style="text-decoration: underline; width: 50px; color: #FF66FF"/></a></td>
                <td class="auto-style53">
                    <a href ="music/店铺音乐/2019门店普通音乐.wmv">点击下载<style="text-decoration: underline; width: 50px; color: #FF66FF"/></a></td>
                <td class="auto-style53">
                    <asp:Label ID="Label1" runat="server" Text="20190220"></asp:Label>
                </td>
            </tr>
            <tr >
                <td class="auto-style55">圣诞音乐</td>
                <td class="auto-style53"><a href ="music/圣诞音乐/2018圣诞音乐.mp3">点击下载<style="text-decoration: underline; width: 50px; color: #FF66FF"/></a></td>
                <td class="auto-style53"><a href ="music/圣诞音乐/2018圣诞音乐.wmv">点击下载<style="text-decoration: underline; width: 50px; color: #FF66FF"/></a></td>
                <td class="auto-style53">
                    <asp:Label ID="Label2" runat="server" Text="20171124"></asp:Label>
                </td>
            </tr>
            <tr >
                <td class="auto-style55">
                    中秋音乐</td>
                <td class="auto-style53">
                    <a href ="music/新年音乐/2019新年音乐.mp3">点击下载<style="text-decoration: underline; width: 50px; color: #FF66FF"/></a></td>
                <td class="auto-style53">
                    <a href ="music/新年音乐/2019新年音乐.wmv">点击下载<style="text-decoration: underline; width: 50px; color: #FF66FF"/></a></td>
                <td class="auto-style53">
                    <asp:Label ID="Label4" runat="server" Text="20180118"></asp:Label>
                </td>
            </tr>
            <tr >
                <td class="auto-style55">
                    新年音乐</td>
                <td class="auto-style53">
                    <a href ="music/新年音乐/2019新年音乐.mp3">点击下载<style="text-decoration: underline; width: 50px; color: #FF66FF"/></a></td>
                <td class="auto-style53">
                    <a href ="music/新年音乐/2019新年音乐.wmv">点击下载<style="text-decoration: underline; width: 50px; color: #FF66FF"/></a></td>
                <td class="auto-style53">
                    <asp:Label ID="Label3" runat="server" Text="20180118"></asp:Label>
                </td>
            </tr>
               </table>
    </form>
</body>
</html>
