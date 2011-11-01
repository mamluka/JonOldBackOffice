<%@ Register TagPrefix="uc1" TagName="ruler" Src="webcontrols/ruler.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="aspxerror.aspx.vb" Inherits="ion_admin.aspxerror"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
  
	<title></title>
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
	<link href="/errorform.css" type="text/css" rel="StyleSheet">
  </HEAD>
<body MS_POSITIONING="GridLayout" bgColor="#e6e6fa">
<form id="Form1" method="post" runat="server"></TABLE><uc1:ruler id=Ruler1 runat="server"></uc1:ruler>
<br>
<CENTER>
<TABLE id="tbl_main" cellSpacing="1" cellPadding="1" width="100%" border="0" bgColor=lightsteelblue>
  <TBODY>
<TR>
	<TD align="left" colspan="2">
		<TABLE id="tbl_header" style="BORDER-RIGHT: 2px groove; BORDER-TOP: 2px groove; BORDER-LEFT: 2px groove; BORDER-BOTTOM: 2px groove" bgColor=#708090 cellpadding="0" cellspacing="0" width="100%">
		<TR>
			<TD align="left" bgColor="#708090" colspan="1">
				<asp:Label id="lbl_header" runat="server" Width="97%" Font-Bold="True" Font-Size="10pt" Font-Names="verdana,arial">An Error has occured</asp:Label>
			</TD>
			<TD align="right" bgColor="#708090" colspan="1">
				<asp:ImageButton id="btn_gomain" runat="server" ImageUrl="/pic/close.gif"></asp:ImageButton>	
			</TD>
		</TR>
		</TABLE>

	</TD>
</TR>
<TR>
	<TD colspan=2>
		<TABLE id="tbl_short_error" runat="server" style="BORDER-RIGHT: 1px ridge; BORDER-TOP: 1px ridge; BORDER-LEFT: 1px ridge; BORDER-BOTTOM: 1px ridge" cellpadding="0" cellspacing="0" width="100%" height="50" bgColor="#d3d3d3">
		<TR>
			<TD align="center" colspan="1">
				<asp:Label id="lbl_errormsg" runat="server" ForeColor="MidnightBlue" Font-Names="verdana,arial" Font-Size="12pt" Font-Bold="True">An error has occured and logged, please continue!</asp:Label>
			</TD>
		</TR>
		</TABLE>
		
		<TABLE id="tbl_long_error" runat="server" cellSpacing="1" cellPadding="1" width="100%" border="0">
		<TR>
			<TD>
				<asp:Label id="lbl_error_number" runat="server" Font-Size="8pt" Font-Names="verdana,arial" CssClass="formlabel">Error No</asp:Label>
			</TD>
			<TD vAlign="top" align="left" width="100%">
				<asp:Label id=lbl2_error_number runat="server" Width="60px" CssClass="DisabledField"></asp:Label>
			</TD>
		</TR>
		<TR>
			<TD vAlign="top" align="left">
				<asp:Label id="lbl_error_description" runat="server" Font-Size="8pt" Font-Names="verdana,arial" CssClass="formlabel">Description</asp:Label>
			</TD>
			<TD vAlign="top" align="left">
				<asp:Label id=lbl2_error_description runat="server" Width="100%" CssClass="DisabledField"></asp:Label>
			</TD>
		</TR>
		<TR>
			<TD vAlign="top" align="left">
				<asp:Label id="lbl_error_source" runat="server" Font-Size="8pt" Font-Names="verdana,arial" CssClass="formlabel">Source</asp:Label>
			</TD>
			<TD vAlign="top" align="left">
				<asp:Label id=lbl2_error_source runat="server" Width="100%" CssClass="DisabledField"></asp:Label>
			</TD>
		</TR>
		<TR>
			<TD vAlign="top" align="left">
				<asp:Label id="lbl_error_module" runat="server" Font-Size="8pt" Font-Names="verdana,arial" CssClass="formlabel">Module</asp:Label>
			</TD>
			<TD vAlign="top" align="left">
				<asp:Label id=lbl2_error_module runat="server" Width="100%" CssClass="DisabledField"></asp:Label>
			</TD>
		</TR>
		<TR>
			<TD vAlign="top" align="left">
				<asp:Label id="lbl_error_appcall" runat="server" Font-Size="8pt" Font-Names="verdana,arial" CssClass="formlabel">App. Call</asp:Label>
			</TD>
			<TD vAlign="top" align="left">
				<asp:Label id=lbl2_appcall runat="server" Width="100%" CssClass="DisabledField"></asp:Label>
			</TD>
		</TR>
        <TR>
          <TD vAlign=top align=left><asp:Label id=lbl_error_function runat="server" Font-Names="verdana,arial" Font-Size="8pt" CssClass="formlabel" Visible="False">Function</asp:Label></TD>
          <TD vAlign=top align=left><asp:Label id=lbl2_function runat="server" Width="100%" CssClass="DisabledField" Visible="False"></asp:Label></TD></TR>
		<TR>
			<TD vAlign="top" align="left">
				<asp:Label id="lbl_note" runat="server" Font-Size="8pt" Font-Names="verdana,arial" CssClass="formlabel">Note</asp:Label>
			</TD>
			<TD vAlign="top" align="left">
				<asp:TextBox id="txt_note" runat="server" BorderStyle="None" Height="132px" Width="100%" Font-Size="8pt" Font-Names="verdana,arial" TextMode="MultiLine" CssClass="EnabledField"></asp:TextBox>
			</TD>
		</TR>
		</TABLE>
	</TD>
</TR>
<TR>
	<TD vAlign="top" align="center" colSpan="2" height="15">
	</TD>
</TR>
<TR>
	<TD align="center" colspan="2">
		<asp:Button id="btn_ok" runat="server" Width="200px" CssClass="SubmitButton" Text="OK"></asp:Button>
	</TD>
</TR>
</CENTER>
	
</form></TBODY></TABLE>
</body>
</HTML>
