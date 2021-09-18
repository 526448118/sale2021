<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ord_status.aspx.cs" Inherits="grace_ord_status" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
       
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

     <script type="text/javascript">
         function printView(id) {
             var sprnhtml = $(id).outerHTML;
             var selfhtml = window.document.body.innerHTML;//获取当前页的html   
             window.document.body.innerHTML = sprnhtml;
             window.print();
             window.document.body.innerHTML = selfhtml;
         }
         function preview(oper) {
             if (oper < 10) {
                 bdhtml = window.document.body.innerHTML;//获取当前页的html代码 
                 sprnstr = "<!--startprint" + oper + "-->";//设置打印开始区域 
                 eprnstr = "<!--endprint" + oper + "-->";//设置打印结束区域 
                 prnhtml = bdhtml.substring(bdhtml.indexOf(sprnstr) + 18); //从开始代码向后取html 

                 prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));//从结束代码向前取html 
                 window.document.body.innerHTML = "<body>" + prnhtml + "</body>";
                 window.print();
                 window.document.body.innerHTML = bdhtml;
             }
             else {
                 window.print();
             }
         }
     </script>
        <style type="text/css">
        .auto-style1 {
            width: 16px;
            height: 16px;
        }
        .auto-style2 {
            width: 57px;
            height: 56px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <a href="javascript:void(0)" onclick="preview('print');">打印1</a>
          <a href="javascript:void(0)" onclick="printView('print');">打印2</a>
     <div id="print">    
         
        定单生成<img class="auto-style1" src="file:///C:/Users/Administrator/AppData/Local/Microsoft/Windows/Temporary%20Internet%20Files/WebTempDir/enable.png" />--------------&gt;定单生成<img class="auto-style1" src="file:///C:/Users/Administrator/AppData/Local/Microsoft/Windows/Temporary%20Internet%20Files/WebTempDir/enable.png" />--------------&gt;定单生成<img class="auto-style1" src="file:///C:/Users/Administrator/AppData/Local/Microsoft/Windows/Temporary%20Internet%20Files/WebTempDir/enable.png" />--------------&gt;定单生成<img class="auto-style1" src="file:///C:/Users/Administrator/AppData/Local/Microsoft/Windows/Temporary%20Internet%20Files/WebTempDir/enable.png" />--------------&gt;定单生成<img class="auto-style1" src="file:///C:/Users/Administrator/AppData/Local/Microsoft/Windows/Temporary%20Internet%20Files/WebTempDir/enable.png" /><br />
        --------------&gt;定单生成<img class="auto-style1" src="file:///C:/Users/Administrator/AppData/Local/Microsoft/Windows/Temporary%20Internet%20Files/WebTempDir/enable.png" />--------------&gt;定单生成<img class="auto-style1" src="file:///C:/Users/Administrator/AppData/Local/Microsoft/Windows/Temporary%20Internet%20Files/WebTempDir/enable.png" />
        
        <img class="auto-style2" src="file:///C:/Users/Administrator/AppData/Local/Microsoft/Windows/Temporary%20Internet%20Files/WebTempDir/Center%20Direction.png" /><br />
        下单
          </div>

    </form>

</body>
</html>
