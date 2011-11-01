<%@ Register TagPrefix="uc1" TagName="ruler" Src="webcontrols/ruler.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="statsbase.aspx.vb" Inherits="ion_admin.statsbase"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>stats</title>
<meta content=JavaScript name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema><LINK href="/styles.css" type=text/css rel=StyleSheet >
  </HEAD>
<body bgColor=#e6e6fa MS_POSITIONING="GridLayout">
<form id=Form1 method=post runat="server"><uc1:ruler id=Ruler1 runat="server"></uc1:ruler>
<hr>
<asp:label id=lbl_inventory runat="server" Width="100%" ForeColor="Linen" Font-Size="12pt" Font-Names="vedana,arial" BorderStyle="Groove" BorderWidth="1px" BackColor="DarkSlateBlue" Font-Bold="True" BorderColor="White"> Search engine visits</asp:label>
<hr>

<TABLE id=tbl_search 
style="BORDER-RIGHT: 1px outset; BORDER-TOP: 1px outset; BORDER-LEFT: 1px outset; BORDER-BOTTOM: 1px outset" 
cellSpacing=1 cellPadding=1 width="100%" bgColor=#faf0e6 border=0>
  <TR>
    <TD width=100><asp:label id=Label4 runat="server" Width="76px" ForeColor="MidnightBlue" Font-Size="8pt" Font-Names="verdana,arial">Select site</asp:label></TD>
    <TD><asp:dropdownlist id=cmb_site runat="server" Width="200px" CssClass="formfield" AutoPostBack="True">
<asp:ListItem Value="6">-</asp:ListItem>
<asp:ListItem Value="0">twin-diamonds.com</asp:ListItem>
<asp:ListItem Value="1">twin-diamonds - Redirects</asp:ListItem>
<asp:ListItem Value="2">gem-resource.com</asp:ListItem>
<asp:ListItem Value="3">ion-integrations.com</asp:ListItem>
<asp:ListItem Value="4">ben-yair.com</asp:ListItem>
<asp:ListItem Value="5">default</asp:ListItem>
</asp:dropdownlist></TD>
    <TD><asp:label id=Label1 runat="server" Width="81px" ForeColor="MidnightBlue" Font-Size="8pt" Font-Names="verdana,arial">Select Engine</asp:label></TD>
    <TD><asp:dropdownlist id=cmb_enginetype runat="server" Width="200px" CssClass="formfield"></asp:dropdownlist></TD></TR>
  <TR>
    <TD colSpan=3><asp:checkbox id=chk_resolve runat="server" CssClass="formfield" Text="Resolve"></asp:CheckBox>&nbsp;<asp:label id=lbl_resolve runat="server" Width="90%" ForeColor="MidnightBlue" Font-Size="8pt" Font-Names="verdana,arial"></asp:label></TD>
    <TD align=right><asp:button id=btn_search runat="server" Width="97px" CssClass="formbutton" Text="Search"></asp:button></TD></TR></TABLE>
<HR>

<center><asp:datagrid id=grd_items runat="server" Width="1150px" Font-Size="8pt" Font-Names="verdana,arial" BorderStyle="Outset" BorderWidth="1px" BackColor="Linen" BorderColor="White" PageSize="30" AllowPaging="True" AutoGenerateColumns="False">
<SelectedItemStyle ForeColor="Linen" BackColor="DarkSlateBlue">
</SelectedItemStyle>

<HeaderStyle ForeColor="Linen" BackColor="DarkSlateBlue">
</HeaderStyle>

<Columns>
<asp:BoundColumn DataField="logtime" HeaderText="Date">
<HeaderStyle Width="150px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="clienthost" HeaderText="Client Host">
<HeaderStyle Width="220px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="servicestatus" HeaderText="Status">
<HeaderStyle Width="50px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="processingtime" HeaderText="time">
<HeaderStyle Width="50px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="bytessent" HeaderText="Bytes">
<HeaderStyle Width="50px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="target" HeaderText="Target">
<HeaderStyle Width="450px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="parameters" HeaderText="Parameters">
<HeaderStyle Width="250px">
</HeaderStyle>
</asp:BoundColumn>
</Columns>

<PagerStyle ForeColor="Linen" BackColor="DarkSlateBlue" Mode="NumericPages">
</PagerStyle>
</asp:datagrid></CENTER><asp:label id=hid_table style="Z-INDEX: 101; LEFT: 56px; POSITION: absolute; TOP: 680px" runat="server" Width="192px" Visible="False"></asp:label></FORM>
	</body>
</HTML>
