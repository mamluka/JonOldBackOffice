<%@ Page Language="vb" AutoEventWireup="false" Codebehind="printorder.aspx.vb" Inherits="ion_admin.printorder"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
  <head>
    <title>printorder</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
	<LINK href="/styles.css" type="text/css" rel="StyleSheet">
	<script language="JavaScript" type="text/javascript">
	
function PrintPage() {

document.getElementById('PrintDiv').innerHTML = window.opener.document.getElementById('tbl_checkout_main').outerHTML
var tds = document.getElementById('tbl_checkout_main').getElementsByTagName('td')
var len = tds.length
tds[len-1].removeNode(true)
tds[len-2].removeNode(true)
tds[len-3].removeNode(true)
tds[len-4].removeNode(true)
tds[len-5].removeNode(true)
tds[len-6].removeNode(true)
if (document.getElementById('Wc_order1_txt_merchant_notes').value == '' ) {
	tds[len-7].removeNode(true)
}
if (document.getElementById('Wc_order1_txt_customer_notes').value == '' ) {
	tds[len-8].removeNode(true)
}

document.getElementById('payment method').removeNode(true)

window.print()
}
</script>

  <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1"><style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 00px;
	margin-bottom: 0px;
}
-->
</style></head>
  
  <body MS_POSITIONING="GridLayout" onload="PrintPage()">

    <form id="Form1" method="post" runat="server">
<div id="PrintDiv" style="BORDER-RIGHT: 1px outset; BORDER-TOP: 1px outset; BORDER-LEFT: 1px outset; BORDER-BOTTOM: 1px outset; BACKGROUND-COLOR: gainsboro; width:200px" ></div>
    </form>

  </body>
</html>
