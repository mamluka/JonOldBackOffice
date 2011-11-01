<%@ Register TagPrefix="uc1" TagName="ruler" Src="../webcontrols/ruler.ascx" %>
<%@ Register TagPrefix="uc1" TagName="plate" Src="../inventory/plate/plate.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="edititem.aspx.vb" Inherits="ion_admin.edititem" smartNavigation="True"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>edititem</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/styles.css" type="text/css" rel="StyleSheet">
		<script language="JavaScript" type="text/javascript" src="/script/smalladdons.js"></script>
		<script type="text/javascript" src="/script/AJS/AJS.js"></script>
		<script type="text/javascript" src="/script/AJS/AJS_fx.js"></script>
  </HEAD>
	<body MS_POSITIONING="GridLayout" bgColor="#e6e6fa">
		<form id="Form1" method="post" encType="multipart/form-data" runat="server">
			<uc1:ruler id="Ruler1" runat="server"></uc1:ruler>
			<HR>
			<asp:Label id="lbl_inventory" runat="server" BorderStyle="Groove" BorderWidth="1px" BackColor="DarkSlateBlue" Font-Bold="True" Visible="False" BorderColor="White" Width="100%" Font-Names="vedana,arial" Font-Size="12pt" ForeColor="Linen"></asp:Label>
			<HR>
			<uc1:plate id="Plate1" runat="server"></uc1:plate>
		</form>
	</body>
</HTML>
