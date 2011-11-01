<%@ Register TagPrefix="uc1" TagName="ruler" Src="../webcontrols/ruler.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="addhelp.aspx.vb" Inherits="ion_admin.addhelp"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<TITLE>additem</TITLE>
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/styles.css" type="text/css" rel="StyleSheet">
  </HEAD>
	<body bgColor="#e6e6fa" MS_POSITIONING="GridLayout">
		<form id="Form2" method="post" runat="server">
			<uc1:ruler id="Ruler1" runat="server"></uc1:ruler>
			<hr>
			<asp:Label id="lbl_inventory" runat="server" Width="100%" ForeColor="Linen" Font-Size="12pt" Font-Names="vedana,arial" BorderStyle="Groove" BorderWidth="1px" BackColor="DarkSlateBlue" Font-Bold="True" BorderColor="White">Add Help</asp:Label>
			<hr>
			<center>
<TABLE id=tbl_help 
style="BORDER-RIGHT: 1px outset; BORDER-TOP: 1px outset; BORDER-LEFT: 1px outset; BORDER-BOTTOM: 1px outset; BACKGROUND-COLOR: gainsboro" cellSpacing=1 
cellPadding=1 width=640 border=0>
  <TR>
    <TD bgColor=#708090><asp:label id=lbl_caption runat="server" Font-Bold="True" Font-Names="verdana,arial" Font-Size="10pt" ForeColor="Khaki" Width="404px">Add help</asp:label></TD></TR>
  <TR>
    <TD>
      <TABLE id=tbl_helpcontent cellSpacing=1 cellPadding=1 width="100%" 
      border=0>
        <TR>
          <TD width=100><asp:Label id=Label1 runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue" Width="123px">Id</asp:Label></TD>
          <TD><asp:TextBox id=txt_id runat="server" Width="50px" CssClass="formfield" Enabled="False"></asp:TextBox></TD></TR>
        <TR>
          <TD width=100><asp:Label id=Label2 runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue" Width="130px">Description (Keyword)</asp:Label></TD>
          <TD><asp:TextBox id=txt_keyword runat="server" Width="100%" CssClass="formfield"></asp:TextBox></TD></TR>
        <TR>
          <TD width=100><asp:Label id=Label3 runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue" Width="123px">Help header</asp:Label></TD>
          <TD><asp:TextBox id=txt_header runat="server" Width="100%" CssClass="formfield"></asp:TextBox></TD></TR>
        <TR>
          <TD vAlign=top width=100><asp:Label id=Label4 runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue" Width="123px">Text</asp:Label></TD>
          <TD><asp:TextBox id=txt_text runat="server" Width="100%" CssClass="formfield" TextMode="MultiLine" Rows="30"></asp:TextBox></TD></TR></TABLE></TD></TR>
  <TR>
    <TD align=right><asp:Button id=save runat="server" Width="131px" CssClass="formbutton" Text="Save"></asp:Button></TD></TR></TABLE>
			</center>
		</form>
	</body>
</HTML>
