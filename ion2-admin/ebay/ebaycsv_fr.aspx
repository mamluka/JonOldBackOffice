<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ebaycsv_fr.aspx.vb" Inherits="ion_admin.ebaycsv_fr"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ebaycsv</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<style type="text/css">
		#Form1 INPUT { FONT-SIZE: 12px; FONT-FAMILY: Tahoma }
		#Form1 SPAN { FONT-SIZE: 10px; FONT-FAMILY: Tahoma }
		#Form1 TD { FONT-WEIGHT: bold; FONT-SIZE: 12px; FONT-FAMILY: Tahoma }
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="85%" border="0">
				<tr>
					<td width="13%">from item</td>
					<td width="87%"><asp:textbox id="txt_from" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td>to item</td>
					<td><asp:textbox id="txt_to" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td>Category<BR>
						<BR>
						Story 1<BR>
						Store 2</td>
					<td>
						<asp:dropdownlist id="e_cat" runat="server">
							<asp:ListItem Value="115843">Rings</asp:ListItem>
						</asp:dropdownlist>&nbsp;
						<BR>
						<BR>
						<asp:dropdownlist id="e_store_main_cat" runat="server"></asp:dropdownlist><BR>
						<asp:dropdownlist id="e_store_second_cat" runat="server"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td style="HEIGHT: 21px">Site<BR>
						<BR>
						Dollar/Euro</td>
					<td style="HEIGHT: 21px">
						<asp:dropdownlist id="cmb_site" runat="server">
							<asp:ListItem Value="0">USA</asp:ListItem>
							<asp:ListItem Value="3">UK</asp:ListItem>
							<asp:ListItem Value="15">Australia</asp:ListItem>
							<asp:ListItem Value="71" Selected="True">France</asp:ListItem>
							<asp:ListItem Value="101">Italy</asp:ListItem>
						</asp:dropdownlist><BR>
						<BR>
						<asp:TextBox id="e_currency" runat="server" Width="24px">1</asp:TextBox></td>
				</tr>
				<tr>
					<td>Format</td>
					<td>
						<asp:dropdownlist id="cmb_format" runat="server">
							<asp:ListItem Value="7">Store</asp:ListItem>
							<asp:ListItem Value="1">Auction</asp:ListItem>
							<asp:ListItem Value="9" Selected="True">Fixed</asp:ListItem>
						</asp:dropdownlist></td>
				</tr>
				<tr>
					<td>Duration</td>
					<td>
						<asp:dropdownlist id="cmb_duration" runat="server">
							<asp:ListItem Value="1">1</asp:ListItem>
							<asp:ListItem Value="3">3</asp:ListItem>
							<asp:ListItem Value="5">5</asp:ListItem>
							<asp:ListItem Value="7">7</asp:ListItem>
							<asp:ListItem Value="10">10</asp:ListItem>
							<asp:ListItem Value="30" Selected="True">30</asp:ListItem>
							<asp:ListItem Value="GTC">GTC</asp:ListItem>
						</asp:dropdownlist></td>
				</tr>
				<tr>
					<td>Desciption Inside HTML</td>
					<td>
						<asp:textbox id="txt_desc" runat="server" Height="192px" Width="636px" TextMode="MultiLine"></asp:textbox></td>
				</tr>
				<tr>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td><BR>
						<BR>
						YouTube Code</td>
					<td>
						<asp:checkbox id="chk_clarity" runat="server" Text="clarity enhanced"></asp:checkbox><BR>
						<BR>
						<asp:TextBox id="e_youtube" runat="server" Width="136px"></asp:TextBox></td>
				</tr>
				<tr>
					<td></td>
					<td><asp:button id="btn_load" runat="server" Text="Load"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:Button id="Button1" runat="server" Text="Clear"></asp:Button></td>
				</tr>
			</table>
			<br>
			<br>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td>
						<table cellSpacing="0" cellPadding="5" width="1200" border="0">
							<tr>
								<td width="83" bgcolor="#cccccc" style="WIDTH: 83px">Itemnumber</td>
								<td width="81" bgcolor="#cccccc">Category</td>
								<td width="112" bgcolor="#cccccc">Store Category</td>
								<td width="275" bgcolor="#cccccc">Title</td>
								<td width="287" bgcolor="#cccccc">Subtitle</td>
								<td width="133" bgcolor="#cccccc">Price</td>
								<td width="100">
									<p>Edit</p>
								</td>
							</tr>
						</table>
						<asp:panel id="pnl_table" runat="server"></asp:panel></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td><asp:button id="btn_save" runat="server" Text="Create CSV"></asp:button><asp:label id="Label1" runat="server" Visible="false">Label</asp:label></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
