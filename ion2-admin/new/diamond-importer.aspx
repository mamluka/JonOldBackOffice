<%@ Page Language="vb" AutoEventWireup="false" Codebehind="diamond-importer.aspx.vb" Inherits="ion_admin.diamond_importer"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>diamond_importer</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<INPUT style="Z-INDEX: 101; POSITION: absolute; TOP: 48px; LEFT: 24px" id="datafile" type="file"
				runat="server">
			<asp:label style="Z-INDEX: 105; POSITION: absolute; TOP: 168px; LEFT: 32px" id="lbl_status"
				runat="server"></asp:label><asp:button style="Z-INDEX: 103; POSITION: absolute; TOP: 120px; LEFT: 24px" id="btn_process"
				runat="server" Text="Process File"></asp:button><asp:dropdownlist style="Z-INDEX: 102; POSITION: absolute; TOP: 80px; LEFT: 24px" id="cmb_datatype"
				runat="server">
				<asp:ListItem Value="1">India Guy</asp:ListItem>
				<asp:ListItem Value="2" Selected="True">DiamondFloor</asp:ListItem>
			</asp:dropdownlist></form>
	</body>
</HTML>
