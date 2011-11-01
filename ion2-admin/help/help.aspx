<%@ Page Language="vb" AutoEventWireup="false" Codebehind="help.aspx.vb" Inherits="ion_admin.help" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>help</title>
		<meta content=JavaScript name=vs_defaultClientScript>
		<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
		<LINK href="/styles.css" type=text/css rel=StyleSheet >
  </HEAD>

<body bgColor=darkgray MS_POSITIONING="GridLayout" bottommargin=0 leftmargin=0 rightmargin=0 topmargin=0>
<form id=Form1 method=post runat="server">
<TABLE id=tbl_main style="BORDER-RIGHT: steelblue 1px solid; BORDER-TOP: steelblue 1px solid; BORDER-LEFT: steelblue 1px solid; BORDER-BOTTOM: steelblue 1px solid" height="100%" cellSpacing=1 cellPadding=1 width="100%" border=0>
<TR>
	<TD valign=top height=30>
		<TABLE id=tbl_header style="BORDER-RIGHT: white 2px outset; BORDER-TOP: white 2px outset; BORDER-LEFT: white 2px outset; BORDER-BOTTOM: white 2px outset; BACKGROUND-COLOR: #708090" cellSpacing=1 cellPadding=1 width="100%" border=0>
        <TR>
			<TD vAlign=center>
				<asp:Label id=Label1 runat="server" ForeColor="Cornsilk" Font-Size="10pt" Font-Names="verdana,arial" Font-Bold="True">Help</asp:Label>
			</TD>
			<TD align=right>
				<IMG style="CURSOR: hand" onclick=window.close() src="../pic/close.gif" width="17" height="17">
			</TD>
		</TR>
		</TABLE>
	</TD>
</TR>
<TR>
	<TD valign=top height="100%">
		<TABLE id=tbl_content style="BORDER-RIGHT: steelblue 1px solid; BORDER-TOP: steelblue 1px solid; BORDER-LEFT: steelblue 1px solid; COLOR: midnightblue; BORDER-BOTTOM: steelblue 1px solid; BACKGROUND-COLOR: floralwhite" cellSpacing=0 cellPadding=5 width="100%" height="100%" border=0>
        <TR>
			<TD vAlign=center align=middle height=30>
				<asp:Label id=lbl_header runat="server" Width="100%" Height="28" ForeColor="MidnightBlue" Font-Size="12pt" Font-Names="verdana,arial" Font-Bold="True">header</asp:Label>
			</TD>
		</TR>
        <TR>
			<TD style="BORDER-TOP: silver 1px solid" vAlign=top align=left>
				
			<DIV  id="div_text" ms_positioning="FlowLayout" runat=server style="FONT-SIZE: 9pt; COLOR: midnightblue; FONT-FAMILY: verdana, arial"></DIV>

			</TD>
		</TR>
		</TABLE>
	</TD>
</TR>
<TR>
	<TD align=middle>
		<INPUT class=formbutton style="WIDTH: 200px" onclick=window.close() type=button value=Close> 
    </TD>
</TR>
</TABLE>

</form>
</body>
</HTML>
