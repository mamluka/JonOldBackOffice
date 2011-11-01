<%@ Register TagPrefix="uc1" TagName="ruler" Src="../webcontrols/ruler.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="order.aspx.vb" Inherits="ion_admin.order" smartNavigation="True"%>
<%@ Register TagPrefix="uc1" TagName="wc_order" Src="wc_order.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<TITLE>additem</TITLE>
		<META content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<META content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/styles.css" type="text/css" rel="StyleSheet">
		<script language="JavaScript" type="text/javascript" src="/script/smalladdons.js"></script>

  </HEAD>
	<BODY bgColor="#e6e6fa" MS_POSITIONING="GridLayout">
		<FORM id="Form2" method="post" runat="server">
			<UC1:RULER id="Ruler1" runat="server"></UC1:RULER>
			<HR>
			<ASP:LABEL id="lbl_inventory" runat="server" Width="100%" ForeColor="Linen" Font-Size="12pt" Font-Names="vedana,arial" BorderStyle="Groove" BorderWidth="1px" BackColor="DarkSlateBlue" Font-Bold="True" BorderColor="White">Add Customer</ASP:LABEL>
			<HR>
			<CENTER>
				<uc1:wc_order id=Wc_order1 runat="server"></uc1:wc_order>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
