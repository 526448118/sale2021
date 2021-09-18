<%@ Page Language="C#" AutoEventWireup="true" CodeFile="printContent.aspx.cs" Inherits="printContent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <link href="CSS\style.css" rel="stylesheet">
</head>

<body>
<table border="0" align="center" cellpadding="0" cellspacing="0" background="Images/book.bmp" style="width: 1000px; height: 544px">
  <tr>
    <td width="32" height="189">&nbsp;</td>
    <td colspan="2">&nbsp;</td>
    <td style="width: 20px">&nbsp;</td>
  </tr>
  <tr>
    <td height="264" rowspan="2">&nbsp;</td>
    <td width="666" height="25" style="font-weight: bold; color: #0066cc">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp当前位置：订单信息打印</td>
    <td width="58" align="center" class="word_Green"><a href="#" onClick="parent.contentFrame.focus();window.print();">打印</a></td>
    <td rowspan="2" style="width: 20px">&nbsp;</td>
  </tr>
  <tr>
    <td height="400" colspan="2" align="center" valign="middle" bgcolor="#FFFFFF"><iframe name="contentFrame" src="ord_print.aspx"  frameborder="0" width="100%" height="100%" style="width: 89%; height: 97%"></iframe></td>
  </tr>
  <tr>
    <td style="height: 21px">&nbsp;</td>
    <td colspan="2" style="height: 21px">&nbsp;</td>
    <td style="width: 20px; height: 21px">&nbsp;</td>
  </tr>
</table>
</body>
</html>
