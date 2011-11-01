<%@ Page Language="vb" AutoEventWireup="false" Codebehind="groups.aspx.vb" Inherits="ion_admin.groups" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>groups</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="Label3" style="Z-INDEX: 102; LEFT: 112px; POSITION: absolute; TOP: 440px" runat="server">Label</asp:Label>
			<table cellSpacing="0" cellPadding="0" width="882" border="0">
				<tr>
					<td width="176" style="WIDTH: 170px">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td>
									<asp:listbox id="lst_group" runat="server" Width="176px" Height="319px"></asp:listbox></td>
							</tr>
							<tr>
								<td>
									<asp:textbox id="txt_addgroup" runat="server"></asp:textbox>
									<br>
									<asp:textbox id="txt_groupkey" runat="server"></asp:textbox>
									<br>
									<asp:button id="btn_addgroup" runat="server" Text="Add Group"></asp:button></td>
							</tr>
						</table>
					</td>
					<td width="102" align="left" valign="top"><br>
						<asp:button id="btn_editgroup" runat="server" Text="Edit"></asp:button>
						<br>
						<asp:button id="btn_deletegroup" runat="server" Text="Delete"></asp:button></td>
					<td width="604" valign="top">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td width="39%">
									<asp:label id="Label1" runat="server">Item number</asp:label></td>
								<td width="61%"></td>
							</tr>
							<tr>
								<td>
									<asp:textbox id="txt_additem" runat="server" Width="216px"></asp:textbox></td>
								<td>
									<asp:button id="btn_additem" runat="server" Text="Add Item"></asp:button></td>
							</tr>
							<tr>
								<td>
									<asp:listbox id="lst_item" runat="server" Height="280px" Width="224px"></asp:listbox></td>
								<td valign="top">
									<br>
									<asp:button id="btn_deleteitem" runat="server" Text="Delete"></asp:button></td>
							</tr>
						</table>
						<asp:Button id="btn_itemsdone" runat="server" Text="Save List"></asp:Button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
