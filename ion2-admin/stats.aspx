<%@ Page Language="vb" AutoEventWireup="false" Codebehind="stats.aspx.vb" Inherits="ion_admin.stats"%>
<%@ Register TagPrefix="uc1" TagName="ruler" Src="webcontrols/ruler.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>stats</title>
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/styles.css" type="text/css" rel="StyleSheet">
  </HEAD>
	<body bgColor="#e6e6fa" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:ruler id=Ruler1 runat="server"></uc1:ruler>
			<hr>
			<asp:Label id="lbl_inventory" runat="server" Width="100%" ForeColor="Linen" Font-Size="12pt" Font-Names="vedana,arial" BorderStyle="Groove" BorderWidth="1px" BackColor="DarkSlateBlue" Font-Bold="True" BorderColor="White"> Statistics</asp:Label>
			<hr>
			<TABLE id="tbl_search" cellSpacing="1" cellPadding="1" width="100%" border="0" bgColor="#faf0e6" style="BORDER-RIGHT: 1px outset; BORDER-TOP: 1px outset; BORDER-LEFT: 1px outset; BORDER-BOTTOM: 1px outset">
				<TR>
					<TD width="100">
						<asp:label id="Label4" runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue" Width="76px">Select query</asp:label>
					</TD>
					<TD>
						<asp:DropDownList id=DropDownList1 runat="server" Width="250px" CssClass="formfield"></asp:DropDownList>
					</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD>&nbsp;<asp:label id=Label2 runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="Red" Width="76px">Site:</asp:label></TD>
					<TD>&nbsp;</TD>
					<TD>&nbsp;</TD>
				</TR>
  <TR>
    <TD><asp:label id=Label1 runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue" Width="122px">&nbsp;Application up since</asp:label></TD>
    <TD><asp:label id=lbl_sserverup runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue" Width="76px"></asp:label></TD>
    <TD></TD></TR>
  <TR>
    <TD><asp:label id=Label3 runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue" Width="122px">&nbsp;Active sessions</asp:label></TD>
    <TD><asp:label id=lbl_ssessions runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue" Width="76px"></asp:label></TD>
    <TD></TD></TR>
  <TR>
    <TD><asp:label id=Label5 runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="Red" Width="76px">BackOffice:</asp:label></TD>
    <TD></TD>
    <TD></TD></TR>
  <TR>
    <TD><asp:label id=Label6 runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue" Width="122px">&nbsp;Application up since</asp:label></TD>
    <TD><asp:label id=lbl_bserverup runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue" Width="76px"></asp:label></TD>
    <TD></TD></TR>
  <TR>
    <TD><asp:label id=Label7 runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue" Width="122px">&nbsp;Active sessions</asp:label></TD>
    <TD><asp:label id=lbl_bsessions runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue" Width="76px"></asp:label></TD>
    <TD></TD></TR>
				<TR>
					<TD>&nbsp;</TD>
					<TD>&nbsp;</TD>
					<TD align=right>
						<asp:button id="btn_search" runat="server" Width="97px" CssClass="formbutton" Text="Search"></asp:button>
					</TD>
				</TR>
			</TABLE>


			<HR>
			<center>
				<asp:datagrid id="grd_items" runat="server" BorderColor="White" BackColor="Linen" BorderWidth="1px" BorderStyle="Outset" Font-Names="verdana,arial" Font-Size="8pt" Width="1500px" PageSize="20" AllowPaging="True" AutoGenerateColumns="False">
<SelectedItemStyle ForeColor="Linen" BackColor="DarkSlateBlue">
</SelectedItemStyle>

<HeaderStyle ForeColor="Linen" BackColor="DarkSlateBlue">
</HeaderStyle>

<Columns>
<asp:BoundColumn DataField="date_time" HeaderText="Date">
<HeaderStyle Width="120px">
</HeaderStyle>
</asp:BoundColumn>
<asp:TemplateColumn HeaderText="Refferer">
<HeaderStyle Width="600px">
</HeaderStyle>

<ItemTemplate>
	<a href='<%# DataBinder.Eval(Container, "DataItem.refferer_url")%>'><%# DataBinder.Eval(Container, "DataItem.refferer_url")%></a>
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="user_name" HeaderText="Name">
<HeaderStyle Width="200px">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:TemplateColumn HeaderText="eMail">
<ItemTemplate>
	<a href='mailto:<%# DataBinder.Eval(Container, "DataItem.user_email")%>'><%# DataBinder.Eval(Container, "DataItem.user_email")%></a>
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="last_visit" HeaderText="LastVisit">
<HeaderStyle Width="120px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="visit_count" HeaderText="VisitCount">
<HeaderStyle Width="50px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="remote_ip" HeaderText="ip">
<HeaderStyle Width="80px">
</HeaderStyle>
</asp:BoundColumn>
</Columns>

<PagerStyle ForeColor="Linen" BackColor="DarkSlateBlue" Mode="NumericPages">
</PagerStyle>
				</asp:datagrid>
			</center>
		</form>
	</body>
</HTML>
