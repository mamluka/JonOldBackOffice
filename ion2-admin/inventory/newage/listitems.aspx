<%@ Register TagPrefix="uc1" TagName="combo" Src="../../webcontrols/base/combo.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="listitems.aspx.vb" Inherits="ion_admin.listitems"%>
<%@ Register TagPrefix="uc1" TagName="topmanu" Src="../../webcontrols/base/topmanu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>listitems</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script type="text/javascript" src="/script/grid/js/dhtmlXGrid.js"></script>
		<script type="text/javascript" src="/script/grid/js/dhtmlXCommon.js"></script>
		<script type="text/javascript" src="/script/grid/js/dhtmlXGridCell.js"></script>
		<script type="text/javascript" src="/script/grid/js/dhtmlXGrid_dload.js"></script>
		<script type="text/javascript" src="/script/grid/js/dhtmlXGrid_srnd.js"></script>
		<script language="JavaScript" type="text/javascript" src="/script/grid/js/dhtmlXGrid_pgn.js"></script>
		<script type="text/javascript" src="/script/menu/milonic_src.js"></script>
		<script type="text/javascript" src="/script/menu/mmenudom.js"></script>		

		<script type="text/javascript" src="/inventory/newage/inventory.js"></script>
		<script type="text/javascript" src="/script/AJS/AJS.js"></script>
		<script type="text/javascript" src="/script/AJS/AJS_fx.js"></script>
		<script type="text/javascript" src="/script/general.js"></script>
		<script type="text/javascript" src="/script/mills.js"></script>
		<script type="text/javascript">
		function Load() {
		
			ListItems.LoadGrid(1)
		ListItems.BindFormToEnterSubmit()
	
			}

		</script>
		<link href="/script/grid/css/dhtmlXGrid.css" rel="stylesheet" type="text/css">
		<link href="/newcss.css" rel="stylesheet" type="text/css">
		<style type="text/css">
.loadDiv { BORDER-RIGHT: #666666 1px solid; PADDING-RIGHT: 10px; BORDER-TOP: #666666 1px solid; PADDING-LEFT: 10px; FONT-SIZE: 15px; PADDING-BOTTOM: 10px; BORDER-LEFT: #666666 1px solid; WIDTH: 200px; COLOR: #ff0000; PADDING-TOP: 10px; BORDER-BOTTOM: #666666 1px solid; FONT-FAMILY: Tahoma, Verdana; HEIGHT: 50px; BACKGROUND-COLOR: #ffffff; TEXT-ALIGN: center }
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout" onLoad="Load()">
		<form id="Form1" method="post" runat="server">
			<uc1:topmanu id="Topmanu1" runat="server"></uc1:topmanu>
			<table width="100%" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td><table width="100%" border="0" cellpadding="2" cellspacing="0" class="opration_table">
							<tr>
								<td><table border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td width="256"><span class="generic_text"> Item Number: <input name="itemnumber" type="text" id="itemnumber" bindenter="true">
												</span>
											</td>
											<td width="279"><span class="generic_text">
													<uc1:combo id="bo_type" runat="server"></uc1:combo>
												</span>
											</td>
											<td width="255"><span class="generic_text">
													<uc1:combo id="bo_shape" runat="server"></uc1:combo>
												</span>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td><table width="785" border="0" cellpadding="0" cellspacing="0">
										<tr>
											<td width="364" class="generic_text">Weight from <input type="text" name="w_from" id="w_from" bindenter="true">
												Ct. to <input type="text" name="w_to" id="w_to" bindenter="true"> Ct.</td>
											<td width="421" class="generic_text">Price from: <input type="text" name="p_from" id="p_from" bindenter="true">
												$ to <input type="text" name="p_to" id="p_to" bindenter="true"> $</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td><table border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td width="111" class="generic_text">Options</td>
											<td width="252"><asp:CheckBox CssClass="generic_text" id="bo_active" runat="server" Text='Active'></asp:CheckBox>
												<asp:CheckBox id="bo_special" CssClass="generic_text" runat="server" Text='Special'></asp:CheckBox>
												<asp:CheckBox id="bo_pictures" CssClass="generic_text" runat="server" Text='Show Pictures'></asp:CheckBox></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td align="right"><input type="button" name="button" id="button" value="Search" onClick="ListItems.PreformSearch()">
									<input type="button" name="button2" id="button2" value="Ebay"></td>
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
