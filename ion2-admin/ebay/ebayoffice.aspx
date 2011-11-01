<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ebayoffice.aspx.vb" Inherits="ion_admin.ebayoffice"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ebayoffice</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<style type="text/css">
.style1 { FONT-SIZE: 14px; FONT-WEIGHT: bold }
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellPadding="5" cellSpacing="2" bgcolor="#cccccc">
				<tr>
					<td colspan="2"><span class="style1">EBAY Actions for the website:</span></td>
				</tr>
				<tr>
					<td>&nbsp;
						<asp:button id="e_updateinv" runat="server" Text="Update Inventory"></asp:button></td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td>&nbsp;
						<asp:button id="Button1" runat="server" Text="Ebay CSV"></asp:button></td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td>&nbsp;<asp:dropdownlist id="DropDownList1" runat="server" Visible="False"></asp:dropdownlist><asp:label id="Label1" runat="server" Visible="False">Label</asp:label></td>
					<td>&nbsp;</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
