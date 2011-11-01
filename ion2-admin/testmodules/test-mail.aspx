<%@ Page Language="vb" AutoEventWireup="false" Codebehind="test-mail.aspx.vb" Inherits="ion_admin.test_mail"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>test_mail</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout" bgColor="darkgray">
		<form id="Form1" method="post" runat="server">
			<TABLE id="tbl_main" cellSpacing="1" cellPadding="1" width="300" border="0" bgColor="darkslateblue" style="BORDER-RIGHT: 1px ridge; BORDER-TOP: 1px ridge; BORDER-LEFT: 1px ridge; BORDER-BOTTOM: 1px ridge">
				<TR>
					<TD>
						<asp:Button id="btn_send" runat="server" Text="Send Mail" Font-Names="verdana,arial" Font-Size="8pt"></asp:Button>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:Label id="lbl_result" runat="server" Width="391px" BackColor="Linen" Font-Names="verdana,arial" Font-Size="8pt"></asp:Label></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
