<%@ Page Language="vb" AutoEventWireup="false" Codebehind="feeds.aspx.vb" Inherits="ion_admin.feeds" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>feeds</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:Button id="feed_shopping" runat="server" Text="Shopping.com Feed"></asp:Button>&nbsp;&nbsp;
			<asp:Button id="feed_google" runat="server" Text="Google Feed"></asp:Button>&nbsp;&nbsp;
			<asp:Button id="feed_sharesale" runat="server" Text="Sharesale Feed"></asp:Button>&nbsp;&nbsp;
			<asp:Button id="Button1" runat="server" Text="Webidz Feed"></asp:Button>&nbsp;
			<asp:Button style="Z-INDEX: 0" id="btn_prostore" runat="server" Text="Prostore Feed"></asp:Button><BR>
			<BR>
			<asp:TextBox style="Z-INDEX: 0" id="txt_sql" runat="server" Width="704px"></asp:TextBox>
		</form>
	</body>
</HTML>
