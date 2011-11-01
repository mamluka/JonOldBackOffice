<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ruler.ascx.vb" Inherits="ion_admin.control" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<TABLE id="tbl_main" cellSpacing="1" cellPadding="0" width="100%" border="0" bgColor="activeborder" style="BORDER-RIGHT: 1px groove; BORDER-TOP: 1px groove; BORDER-LEFT: 1px groove; BORDER-BOTTOM: 1px groove">
	<TR>
		<TD>
			<asp:Label id="lbl_version" runat="server" Width="100px" Font-Size="8pt" Font-Names="verdana,arial" BackColor="DarkSlateBlue" ForeColor="Linen" Height="18px" BorderStyle="Ridge" BorderWidth="3px" BorderColor="#C0C0FF" Font-Bold="True">Label</asp:Label></TD>
		<TD width="100%">
			&nbsp;
		</TD>
		<TD width="250" vAlign="baseline">
			<asp:Label id="lbl_user" runat="server" Width="200px" Font-Size="8pt" Font-Names="verdana,arial" BackColor="Silver" ForeColor="MidnightBlue" Height="17px" BorderColor="#C0C0FF" BorderWidth="1px" BorderStyle="Ridge"></asp:Label></TD>
		</TD>
		<TD>
			<asp:Button id="btn_site" ToolTip="Goto site's main page" runat="server" Text="Site" CssClass="formbutton" BorderColor="#C0C0FF"></asp:Button>
		<TD>
			<INPUT class="formbutton" id="btn_back" alt="Previous page" onclick="history.back()" type="button" value="Back" name="btn_back" style="BORDER-LEFT-COLOR: #c0c0ff; BORDER-BOTTOM-COLOR: #c0c0ff; BORDER-TOP-STYLE: outset; BORDER-TOP-COLOR: #c0c0ff; BORDER-RIGHT-STYLE: outset; BORDER-LEFT-STYLE: outset; BORDER-RIGHT-COLOR: #c0c0ff; BORDER-BOTTOM-STYLE: outset">
		</TD>
		<TD>
			<asp:Button id="btn_home" ToolTip="Goto backoffice main page" runat="server" Text="Home" CssClass="formbutton" BorderColor="#C0C0FF"></asp:Button>
		</TD>
	</TR>
</TABLE>
<BR>
