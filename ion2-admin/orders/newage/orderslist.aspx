<%@ Page Language="vb" AutoEventWireup="false" Codebehind="orderslist.aspx.vb" Inherits="ion_admin.orderslist" %>
<%@ Register TagPrefix="uc1" TagName="topmanu" Src="../../webcontrols/base/topmanu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
  <head>
    <title>orderslist</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
		<script type="text/javascript" src="/script/grid/js/dhtmlXGrid.js"></script>
		<script type="text/javascript" src="/script/grid/js/dhtmlXCommon.js"></script>
		<script type="text/javascript" src="/script/grid/js/dhtmlXGridCell.js"></script>
		<script type="text/javascript" src="/script/grid/js/dhtmlXGrid_dload.js"></script>
		<script type="text/javascript" src="/script/grid/js/dhtmlXGrid_srnd.js"></script>
		<script language="JavaScript" type="text/javascript" src="/script/grid/js/dhtmlXGrid_pgn.js"></script>
		<script type="text/javascript" src="/script/menu/milonic_src.js"></script>
		<script type="text/javascript" src="/script/menu/mmenudom.js"></script>		
		<script language="JavaScript" type="text/javascript" src="/orders/newage/orders.js"></script>

		<script type="text/javascript" src="/script/AJS/AJS.js"></script>
		<script type="text/javascript" src="/script/AJS/AJS_fx.js"></script>
		<script type="text/javascript" src="/script/general.js"></script>
		<script type="text/javascript" src="/script/mills.js"></script>
		
		<script type="text/javascript">
		function Load() {
		
			OrderList.LoadGrid(1)
			//OrderList.BindFormToEnterSubmit()
	
			}

		</script>
		<link href="/script/grid/css/dhtmlXGrid.css" rel="stylesheet" type="text/css">
		<link href="/newcss.css" rel="stylesheet" type="text/css">
  </head>
  <body MS_POSITIONING="GridLayout" onLoad="Load()">

    <form id="Form1" method="post" runat="server">

<uc1:topmanu id="Topmanu1" runat="server"></uc1:topmanu>
			<table width="100%" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td><table width="100%" border="0" cellpadding="2" cellspacing="0" class="opration_table">
							<tr>
								<td><span class="generic_text">Order #:</span>
								  <input name="ordernumber" type="text" id="ordernumber">
								  <span class="generic_text">Email:							      </span>
								  <input name="email" type="text" id="email">
								  <span class="generic_text">							      Itemnumber:							      </span>
							    <input name="itemnumber" type="text" id="itemnumber"></td>
							</tr>
							<tr>
								<td align="right"><input type="button" name="button" id="button" value="Search" onClick="OrderList.PreformSearch()"></td>
							</tr>
						</table>
						<table width="912" border="0" cellspacing="0" cellpadding="0" align="center">
							<tr>
								<td id="gridPaging">&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td align="center"><div id="dataGrid" style="BORDER-RIGHT:#cccccc 1px dotted; BORDER-TOP:#cccccc 1px dotted; BORDER-LEFT:#cccccc 1px dotted; WIDTH:932px; BORDER-BOTTOM:#cccccc 1px dotted; HEIGHT:1200px"></div>
					</td>
				</tr>
			</table>
			<div class="loadDiv" id="loadDiv">
				Loading Items...<img src="/pic/newconst/inventory/base/loader.gif">
			</div>
			<a href="/inventory/edititem.aspx?mode=2&amp;id=1217">Edit Item</a> | <a href="/ebay/twinlister.aspx?id=1246">
				Ebay</a>
		</form>
	</body>
</HTML>