<%@ Page Language="vb" AutoEventWireup="false" Codebehind="viewitem.aspx.vb" Inherits="ion_admin.viewitem"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>viewitem</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/styles.css" type="text/css" rel="StyleSheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:panel id="Panel1" style="Z-INDEX: 101; LEFT: 4px; POSITION: absolute; TOP: 5px" runat="server" BackColor="#E0E0E0" BorderWidth="1px" BorderStyle="Groove" Width="378px" Height="324px">
				<TABLE id="Table1" height="100%" cellSpacing="1" cellPadding="1" width="100%" border="0">
					<TR>
						<TD vAlign="top" align="right" height="10"><IMG onclick="window.close()" src="../pic/close.jpg" width="16" height="15"></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="middle" height="300">
							<HR width="100%">
							<IMG id="img_picture" alt="" src="" runat="server"><BR>
							<asp:Label id="lbl_nothing" runat="server" Height="46px" Width="314px" Font-Names="verdana,arial" Font-Size="18pt" ForeColor="MidnightBlue">Label</asp:Label></TD>
					</TR>
					<TR>
						<TD align="middle">
							<INPUT class="formbutton" style="WIDTH: 200px; HEIGHT: 20px" onclick="window.close()" type="button" value="Close"></TD>
					</TR>
				</TABLE>
			</asp:panel></form>
	</body>
</HTML>
