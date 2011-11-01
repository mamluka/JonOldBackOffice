<%@ Page Language="vb" AutoEventWireup="false" Codebehind="listcustomers.aspx.vb" Inherits="ion_admin.listcustomers"%>
<%@ Register TagPrefix="uc1" TagName="ruler" Src="../webcontrols/ruler.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>listcustomers</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/styles.css" type="text/css" rel="StyleSheet">
  </HEAD>
	<body bgColor="#e6e6fa" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:ruler id="Ruler1" runat="server"></uc1:ruler>
			<hr>
			<asp:Label id="lbl_inventory" runat="server" Width="100%" ForeColor="Linen" Font-Size="12pt" Font-Names="vedana,arial" BorderStyle="Groove" BorderWidth="1px" BackColor="DarkSlateBlue" Font-Bold="True" BorderColor="White">List Customers</asp:Label>
			<hr>
			<TABLE id="tbl_search" cellSpacing="1" cellPadding="1" width="100%" border="0" bgColor="#faf0e6" style="BORDER-RIGHT: 1px outset; BORDER-TOP: 1px outset; BORDER-LEFT: 1px outset; BORDER-BOTTOM: 1px outset">
				<TR>
					<TD width="100">
						<asp:label id="Label4" runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue" Width="65px">First Name</asp:label></TD>
					<TD>
						<asp:textbox id="txt_firstname" runat="server" Width="100px" MaxLength="40" CssClass="formfield"></asp:textbox></TD>
					<TD>
						<asp:label id="Label1" runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue" Width="65px">Last Name</asp:label></TD>
					<TD>
						<asp:textbox id="txt_lastname" runat="server" Width="200px" MaxLength="64" CssClass="formfield"></asp:textbox></TD>
					<TD align="left">
						<asp:CheckBox id="chk_dealers" runat="server" CssClass="formfield" Text="Dealers" BackColor="Linen" BorderStyle="None"></asp:CheckBox></TD>
				</TR>
				<TR>
					<TD>
						<asp:label id="Label2" runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue" Width="65px">eMail</asp:label></TD>
					<TD colspan="3">
						<asp:textbox id="txt_email" runat="server" Width="400px" MaxLength="64" CssClass="formfield"></asp:textbox></TD>
					<TD vAlign="baseline" align="right">
						<asp:button id="btn_search" runat="server" Width="97px" CssClass="formbutton" Text="Search"></asp:button></TD>
				</TR>
			</TABLE>
			<HR>
			<center>
				<asp:datagrid id="grd_items" runat="server" BorderColor="White" BackColor="Linen" BorderWidth="1px" BorderStyle="Outset" Font-Names="verdana,arial" Font-Size="8pt" Width="650px" PageSize="20" AllowPaging="True" AutoGenerateColumns="False">
<SELECTEDITEMSTYLE FORECOLOR="Linen" BACKCOLOR="DarkSlateBlue">
</SelectedItemStyle>

<HEADERSTYLE FORECOLOR="Linen" BACKCOLOR="DarkSlateBlue">
</HeaderStyle>

<COLUMNS>
<asp:BoundColumn DataField="id" HeaderText="No"></asp:BoundColumn>
<asp:TemplateColumn HeaderText="Act">
<ITEMSTYLE HORIZONTALALIGN="Center">
</ItemStyle>

<ITEMTEMPLATE>
<asp:Label runat="server" Text='<%# IIF(DataBinder.Eval(Container, "DataItem.active")="1", "&times;", "") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="email" HeaderText="eMail">
<ITEMSTYLE HORIZONTALALIGN="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="firstname" HeaderText="First Name">
<ITEMSTYLE HORIZONTALALIGN="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="lastname" HeaderText="Last Name">
<ITEMSTYLE HORIZONTALALIGN="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="dealer" HeaderText="Dealer">
<HEADERSTYLE WIDTH="20px">
</HeaderStyle>
</asp:BoundColumn>
<asp:HyperLinkColumn Text="Edit" DataNavigateUrlField="id" DataNavigateUrlFormatString="editcustomer.aspx?mode=2&amp;id={0}" HeaderText="Edit"></asp:HyperLinkColumn>
</Columns>

<PAGERSTYLE FORECOLOR="Linen" BACKCOLOR="DarkSlateBlue" MODE="NumericPages">
</PagerStyle>
				</asp:datagrid>
			</center>
		</form>
	</body>
</HTML>
