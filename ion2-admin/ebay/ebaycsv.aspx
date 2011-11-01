<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ebaycsv.aspx.vb" Inherits="ion_admin.ebaycsv"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ebaycsv</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<style type="text/css">#Form1 INPUT {
	FONT-SIZE: 12px; FONT-FAMILY: Tahoma
}
#Form1 SPAN {
	FONT-SIZE: 10px; FONT-FAMILY: Tahoma
}
#Form1 TD {
	FONT-WEIGHT: bold; FONT-SIZE: 12px; FONT-FAMILY: Tahoma
}
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
						<BR>
						<BR>
						Story 1<BR>
						Store 2<BR>
						<BR>
						<BR>
						<BR>
						Gems Story 1<BR>
						Gems Store 2</td>
					<td>
						<P>USA:&nbsp;
							<asp:dropdownlist id="e_cat" runat="server">
								<asp:ListItem Value="152899">ENGAGEMENT-ENG RING-DIAMOND SOLITAIRE - 152899</asp:ListItem>
								<asp:ListItem Value="152869">ENGAGEMENT-ENG RING-DIAMOND SOLITAIRE with accents - 152869</asp:ListItem>
								<asp:ListItem Value="152872">ENGAGEMENT-ENG RING-DIAMOND- DIAMOND THREE STONE - 152872</asp:ListItem>
								<asp:ListItem Value="92909">ENGAGEMENT-ENG/WEDDING  SETS-DIAMONDS &amp; GEMSOTNES - 92909</asp:ListItem>
								<asp:ListItem Value="92853">ENGAGEMENT-WEDDING &amp; ANNIVERSARY BAND-DIAMOND &amp; GEMSOTNES - 92853</asp:ListItem>
								<asp:ListItem Value="92913">FASHION JEWELRY - RINGS - DIAMOND RINGS - 92913</asp:ListItem>
								<asp:ListItem Value="67727">FASHION JEWELRY - RINGS - GESMTONE RINGS - 67727</asp:ListItem>
								<asp:ListItem Value="164342">FINE JEWELRY -FINE  RINGS - GENUINE DIAMOND  - 164342</asp:ListItem>
								<asp:ListItem Value="164343">FINE JEWELRY -FINE  RINGS - GENUINE GEMSTONE  - 164343</asp:ListItem>
								<asp:ListItem Value="45381">MEN'S JEWELRY - RINGS - DIAMOND- 45381</asp:ListItem>
								<asp:ListItem Value="92852">ENGAGAMENT &amp; WWEDDING - WEDDING &amp; ANNI BANDS - 92852</asp:ListItem>
								<asp:ListItem Value="43348">fashion jewelry-bracelets-tennis-diamond</asp:ListItem>
								<asp:ListItem Value="164314">fine jewellry-fine bracelets-geniune diamond</asp:ListItem>
								<asp:ListItem Value="164320">164320-fine jewellry-fine earrings-geniune diamond</asp:ListItem>
								<asp:ListItem Value="116136">116136-fashion jewelry-earrings-stud-round</asp:ListItem>
								<asp:ListItem Value="116127">116127-fashion jewelry-earrings-stud-princess</asp:ListItem>
								<asp:ListItem Value="110590">110590-fashion jewelry-earrings-HoopHuggie-Diamond</asp:ListItem>
								<asp:ListItem Value="86023">86023-fashion jewelry-earrings-Dangle-Diamond</asp:ListItem>
								
								<asp:ListItem></asp:ListItem>
							</asp:dropdownlist>&nbsp;
							<BR>
							AU:&nbsp;&nbsp;&nbsp;
							<asp:dropdownlist id="e_cat_au" runat="server">
								<asp:ListItem Value="67681" Selected="True">Fashion Rings</asp:ListItem>
								<asp:ListItem Value="164340">Women's Rings</asp:ListItem>
							</asp:dropdownlist><BR>
							FR:&nbsp;&nbsp;&nbsp;&nbsp;<asp:dropdownlist id="e_cat_fr" runat="server">
								<asp:ListItem Value="115843">Rings</asp:ListItem>
							</asp:dropdownlist><BR>
							UK:&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:dropdownlist id="e_cat_uk" runat="server">
								<asp:ListItem Value="10986">10986 - fine jewelry - earrings - diamond</asp:ListItem>
								<asp:ListItem Value="11002">11002 - fine jewelry - pendants - diamond</asp:ListItem>
								<asp:ListItem Value="67726">67726 - fine jewelry - rings - diamond</asp:ListItem>
							</asp:dropdownlist><BR>
							<BR>
							<asp:dropdownlist id="e_store_main_cat" runat="server"></asp:dropdownlist><BR>
							<asp:dropdownlist id="e_store_second_cat" runat="server"></asp:dropdownlist><BR>
							<BR>
							<asp:dropdownlist id="e_store_main_cat2" runat="server"></asp:dropdownlist><BR>
							<asp:dropdownlist id="e_store_second_cat2" runat="server"></asp:dropdownlist><BR>
						</P>
					</td>
				</tr>
				<tr>
					<td style="HEIGHT: 21px">Site<BR>
						<BR>
						Currency<BR>
						Dollar/What you need</td>
					<td style="HEIGHT: 21px"><asp:dropdownlist id="cmb_site" runat="server" AutoPostBack="True">
							<asp:ListItem Value="0">USA</asp:ListItem>
							<asp:ListItem Value="3">UK</asp:ListItem>
							<asp:ListItem Value="15">Australia</asp:ListItem>
							<asp:ListItem Value="71">France</asp:ListItem>
							<asp:ListItem Value="101">Italy</asp:ListItem>
						</asp:dropdownlist><BR>
						<BR>
						<asp:textbox id="e_currency" runat="server" Width="40px">1</asp:textbox><asp:checkbox id="chk_useconvertor" runat="server" Text="Use convertor"></asp:checkbox><BR>
					</td>
				</tr>
				<tr>
					<td>Format</td>
					<td><asp:dropdownlist id="cmb_format" runat="server">
							<asp:ListItem Value="7">Store</asp:ListItem>
							<asp:ListItem Value="1">Auction</asp:ListItem>
							<asp:ListItem Value="9" Selected="True">Fixed</asp:ListItem>
						</asp:dropdownlist></td>
				</tr>
				<tr>
					<td>Duration</td>
					<td><asp:dropdownlist id="cmb_duration" runat="server">
							<asp:ListItem Value="1">1</asp:ListItem>
							<asp:ListItem Value="3">3</asp:ListItem>
							<asp:ListItem Value="5">5</asp:ListItem>
							<asp:ListItem Value="7">7</asp:ListItem>
							<asp:ListItem Value="10">10</asp:ListItem>
							<asp:ListItem Value="30">30</asp:ListItem>
							<asp:ListItem Value="GTC" Selected="True">GTC</asp:ListItem>
						</asp:dropdownlist></td>
				</tr>
				<tr>
					<td>Desciption Inside HTML</td>
					<td><asp:textbox id="txt_desc" runat="server" Width="636px" TextMode="MultiLine" Height="192px"></asp:textbox></td>
				</tr>
				<tr>
					<td>Subtitle</td>
					<td><asp:textbox id="e_subtitle" runat="server" Width="496px" MaxLength="55"></asp:textbox></td>
				</tr>
				<tr>
					<td><BR>
						<BR>
						Youtube</td>
					<td><asp:checkbox id="chk_clarity" runat="server" Text="clarity enhanced"></asp:checkbox><BR>
						<BR>
						<asp:textbox id="e_youtube" runat="server" Width="136px"></asp:textbox></td>
				</tr>
				<tr>
					<td></td>
					<td><asp:button id="btn_load" runat="server" Text="Load"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="Button1" runat="server" Text="Clear"></asp:button></td>
				</tr>
			</table>
			<br>
			<br>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td>
						<table cellSpacing="0" cellPadding="5" width="1200" border="0">
							<tr>
								<td style="WIDTH: 83px" width="83" bgColor="#cccccc">Itemnumber</td>
								<td width="81" bgColor="#cccccc">Category</td>
								<td width="112" bgColor="#cccccc">Store Category</td>
								<td width="275" bgColor="#cccccc">Title</td>
								<td width="287" bgColor="#cccccc">Subtitle</td>
								<td width="133" bgColor="#cccccc">Price</td>
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
					<td><asp:button id="btn_save" runat="server" Text="Create CSV For Aviby"></asp:button>&nbsp;
						<asp:button id="Button2" runat="server" Text="Create CSV For New Generation Gems"></asp:button>&nbsp;&nbsp;</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
