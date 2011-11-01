<%@ Page Language="vb" AutoEventWireup="false" Codebehind="old-note-prog.aspx.vb" Inherits="ion_admin.old_note_prog"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>old_note_prog</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:TextBox id="Id_number" style="Z-INDEX: 100; LEFT: 184px; POSITION: absolute; TOP: 32px"
				runat="server"></asp:TextBox>
			<asp:Label id="lbl_middle_desc" style="Z-INDEX: 110; LEFT: 624px; POSITION: absolute; TOP: 160px"
				runat="server" Height="16px" Width="392px"></asp:Label>
			<DIV style="DISPLAY: inline; Z-INDEX: 109; LEFT: 624px; WIDTH: 120px; POSITION: absolute; TOP: 88px; HEIGHT: 57px"
				ms_positioning="FlowLayout">Middle Stone Desc:</DIV>
			<asp:Label id="lbl_note" style="Z-INDEX: 106; LEFT: 192px; POSITION: absolute; TOP: 96px" runat="server"
				Width="392px" Height="160px"></asp:Label>
			<DIV style="DISPLAY: inline; Z-INDEX: 105; LEFT: 48px; WIDTH: 70px; POSITION: absolute; TOP: 96px; HEIGHT: 15px"
				ms_positioning="FlowLayout">Note:</DIV>
			<DIV style="DISPLAY: inline; Z-INDEX: 104; LEFT: 48px; WIDTH: 120px; POSITION: absolute; TOP: 32px; HEIGHT: 16px"
				ms_positioning="FlowLayout">
				<P>Number/ID Here:</P>
			</DIV>
			<HR style="Z-INDEX: 102; LEFT: 16px; WIDTH: 93.38%; POSITION: absolute; TOP: 64px; HEIGHT: 1px"
				width="93.38%" SIZE="1">
			<asp:Button id="Button1" style="Z-INDEX: 101; LEFT: 376px; POSITION: absolute; TOP: 32px" runat="server"
				Text="Search"></asp:Button>
			<HR style="Z-INDEX: 103; LEFT: 16px; WIDTH: 92.9%; POSITION: absolute; TOP: 16px; HEIGHT: 1px"
				width="92.9%" SIZE="1">
		</form>
	</body>
</HTML>
