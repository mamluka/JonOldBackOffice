<%@ Page Language="vb" AutoEventWireup="false" Codebehind="addcustomer.aspx.vb" Inherits="ion_admin.addcustomer"%>
<%@ Register TagPrefix="uc1" TagName="wc_customer" Src="wc_customer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ruler" Src="../webcontrols/ruler.ascx" %>
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
		<form id="Form2" method="post" runat="server">
			<uc1:ruler id="Ruler1" runat="server"></uc1:ruler>
			<hr>
			<asp:Label id="lbl_inventory" runat="server" Width="100%" ForeColor="Linen" Font-Size="12pt" Font-Names="vedana,arial" BorderStyle="Groove" BorderWidth="1px" BackColor="DarkSlateBlue" Font-Bold="True" BorderColor="White">Add Customer</asp:Label>
			<hr>
			<center>
			<uc1:wc_customer id="Wc_customer1" runat="server"></uc1:wc_customer>
			</center>
		</form>
	</body>
</HTML>
