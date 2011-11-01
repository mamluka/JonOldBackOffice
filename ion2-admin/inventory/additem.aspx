<%@ Register TagPrefix="uc1" TagName="ruler" Src="../webcontrols/ruler.ascx" %>
<%@ Page language="VB" AutoEventWireup="false" Codebehind="additem.aspx.vb" Inherits="ion_admin.additem" trace="False" debug="False" smartNavigation="True"%>
<%@ Register TagPrefix="uc1" TagName="plate" Src="../inventory/plate/plate.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<TITLE>additem</TITLE>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/styles.css" type="text/css" rel="StyleSheet">
  </HEAD>
	<body bgColor="#e6e6fa" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<P>
				<uc1:ruler id="Ruler1" runat="server"></uc1:ruler>
			</P>
			<P>
				<TABLE id="Table1" width="100%" border="0" style="BORDER-RIGHT: 1px outset; BORDER-TOP: 1px outset; BORDER-LEFT: 1px outset; BORDER-BOTTOM: 1px outset; HEIGHT: 26px; BACKGROUND-COLOR: linen">
					<TR>
						<TD width="80">
							<asp:label id="Label4" runat="server" Width="90px" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue">Inventory type</asp:label></TD>
						<TD width="155">
							<asp:dropdownlist id="cmb_platetype" runat="server" Width="150px" Height="21px" CssClass="formfield"></asp:dropdownlist></TD>
						<TD width="60">
							<asp:label id="Label1" runat="server" Width="65px" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue">Branch</asp:label></TD>
						<TD width="155"><asp:dropdownlist id="cmb_branch" runat="server" Width="150px" Height="16px" CssClass="formfield"></asp:dropdownlist></TD>
						<TD width="400" align="right">
							<asp:Button id="btn_select" runat="server" Width="68px" Height="20px" CssClass="formbutton" Text="Select"></asp:Button></TD>
					</TR>
				</TABLE>
			</P>
			<table id="tbl_plate" runat="server" border="0" width="100%">
				<tr>
					<td>
						<hr>
						<asp:Label id="lbl_inventory" runat="server" Width="100%" ForeColor="Linen" Font-Size="12pt" Font-Names="vedana,arial" BorderStyle="Groove" BorderWidth="1px" BackColor="DarkSlateBlue" Font-Bold="True" Visible="False" BorderColor="White">Add Gemstones</asp:Label>
						<hr>
					</td>
				</tr>
				<tr>
					<td>
						<uc1:plate id="uc_Plate1" runat="server"></uc1:plate>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
