<%@ Register TagPrefix="uc1" TagName="ruler" Src="webcontrols/ruler.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="message.aspx.vb" Inherits="ion_admin.message"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>message</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/styles.css" type="text/css" rel="StyleSheet">
		<script language="javascript" src="..\script\norefresh.js"></script>
	</HEAD>
	<body onKeyDown="onKeyDown();" bgColor="#e6e6fa" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:ruler id="Ruler1" runat="server"></uc1:ruler>
			<TABLE id="tbl_main" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD align="middle">
						<table id="tbl_message" width="85%" cellpadding="0" cellspacing="0" border="0" bgcolor="silver" STYLE="BORDER-RIGHT: 2px ridge; BORDER-TOP: 2px ridge; BORDER-LEFT: 2px ridge; BORDER-BOTTOM: 2px ridge" HEIGHT="160">
							<TR>
								<TD ALIGN="left" BGCOLOR="#708090"><asp:Label id="Label1" runat="server" Width="74px" Font-Size="10pt" Font-Names="verdana,arial" ForeColor="Cyan" Font-Bold="True">&nbsp;Message</asp:Label>
								</TD>
							</TR>
							<tr>
								<td ALIGN="middle">
									<ASP:LISTBOX id="lsl_message" runat="server" CssClass="formfield" Width="630px" Height="113px"></ASP:LISTBOX>
								</td>
							</tr>
							<TR>
								<TD align="middle">
									<ASP:BUTTON id="btn_ok" runat="server" CssClass="formbutton" Width="151px" Text="OK"></ASP:BUTTON>
								</TD>
							</TR>
						</table>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
