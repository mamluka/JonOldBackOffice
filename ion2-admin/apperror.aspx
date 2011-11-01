<%@ Page Language="vb" AutoEventWireup="false" Codebehind="apperror.aspx.vb" Inherits="ion_admin.apperror" %>
<%@ Register TagPrefix="uc1" TagName="ruler" Src="webcontrols/ruler.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>apperror</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/styles.css" type="text/css" rel="StyleSheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" bgColor="#e6e6fa">
		<form id="Form1" method="post" runat="server">
			<uc1:ruler id="Ruler1" runat="server"></uc1:ruler>
			<TABLE id="tbl_header" style="BORDER-RIGHT: 1px ridge; BORDER-TOP: 1px ridge; BORDER-LEFT: 1px ridge; BORDER-BOTTOM: 1px ridge" cellpadding="0" cellspacing="0" width="100%">
				<TR>
					<TD align="left" bgColor="#708090" colspan="1">
						<asp:Label id="Label1" runat="server" Width="97%" Font-Bold="True" Font-Size="10pt" Font-Names="verdana,arial" ForeColor="Red">An Error has occured</asp:Label>
					</TD>
					<TD align="right" bgColor="#708090" colspan="1">
						<A href="<%=cRoot%>"><IMG src="/pic/back.jpg" border="0" width="16" height="15"></A>
					</TD>
				</TR>
			</TABLE>
			<TABLE id="tbl_error_occured" runat="server" style="BORDER-RIGHT: 1px ridge; BORDER-TOP: 1px ridge; BORDER-LEFT: 1px ridge; BORDER-BOTTOM: 1px ridge" cellpadding="0" cellspacing="0" width="100%" height="50" bgColor="#d3d3d3">
				<TR>
					<TD align="middle" colspan="1">
						<asp:Label id="lbl_error_occured" runat="server" ForeColor="MidnightBlue" Font-Names="verdana,arial" Font-Size="12pt" Font-Bold="True">An error has occured and logged, please continue!</asp:Label>
					</TD>
				</TR>
			</TABLE>
			<TABLE id="tbl_main" runat="server" style="BORDER-RIGHT: 1px ridge; BORDER-TOP: 1px ridge; BORDER-LEFT: 1px ridge; BORDER-BOTTOM: 1px ridge" cellSpacing="1" cellPadding="1" width="100%" border="0" bgColor="#d3d3d3">
				<TR>
					<TD width="100" vAlign="top" align="left">
						<asp:Label id="lbl_error_number" runat="server" Font-Size="8pt" Font-Names="verdana,arial">Error No</asp:Label>
					</TD>
					<TD vAlign="top" align="left" width="100%">
						<asp:TextBox id="txt_error_number" runat="server" BorderStyle="None" BackColor="#E0E0E0" Font-Size="8pt" Font-Names="verdana,arial" Width="39px" Enabled="False"></asp:TextBox>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="left">
						<asp:Label id="lbl_error_description" runat="server" Font-Size="8pt" Font-Names="verdana,arial">Description</asp:Label></TD>
					<TD vAlign="top" align="left">
						<asp:TextBox id="txt_error_description" runat="server" BorderStyle="None" BackColor="#E0E0E0" Font-Size="8pt" Font-Names="verdana,arial" Width="100%" Enabled="False"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="left">
						<asp:Label id="lbl_error_source" runat="server" Font-Size="8pt" Font-Names="verdana,arial">Source</asp:Label></TD>
					<TD vAlign="top" align="left">
						<asp:TextBox id="txt_error_source" runat="server" BorderStyle="None" BackColor="#E0E0E0" Font-Size="8pt" Font-Names="verdana,arial" Width="100%" Enabled="False"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="left">
						<asp:Label id="lbl_error_module" runat="server" Font-Size="8pt" Font-Names="verdana,arial">Module</asp:Label></TD>
					<TD vAlign="top" align="left">
						<asp:TextBox id="txt_error_module" runat="server" BorderStyle="None" BackColor="#E0E0E0" Font-Size="8pt" Font-Names="verdana,arial" Width="100%" Enabled="False"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="left">
						<asp:Label id="lbl_error_appcall" runat="server" Font-Size="8pt" Font-Names="verdana,arial">App. Call</asp:Label></TD>
					<TD vAlign="top" align="left">
						<asp:TextBox id="txt_appcall" runat="server" BorderStyle="None" BackColor="#E0E0E0" Width="100%" Font-Size="8pt" Font-Names="verdana,arial" Enabled="False"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="left">
						<asp:Label id="lbl_note" runat="server" Font-Size="8pt" Font-Names="verdana,arial">Note</asp:Label></TD>
					<TD vAlign="top" align="left">
						<asp:TextBox id="txt_note" runat="server" BorderStyle="None" BackColor="Linen" Height="132px" Width="100%" Font-Size="8pt" Font-Names="verdana,arial" TextMode="MultiLine"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="middle" colSpan="2">
					</TD>
				</TR>
			</TABLE>
			<TABLE id="tbl_button" cellpadding="0" cellspacing="0" width="100%" height="30" bgColor="#d3d3d3">
				<TR>
					<TD align="middle" colspan="1">
						<asp:Button id="btn_ok" runat="server" Width="200px" CssClass="formbutton" Text="OK"></asp:Button>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
