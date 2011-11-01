<%@ Page Language="vb" AutoEventWireup="false" Codebehind="listhelp.aspx.vb" Inherits="ion_admin.listhelp"%>
<%@ Register TagPrefix="uc1" TagName="ruler" Src="../webcontrols/ruler.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>listhelp</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/styles.css" type="text/css" rel="StyleSheet">
<script language="javascript">
function gethelp(nid){
	mywin=window.open('/help/help.aspx?id='+nid,"displayWindow","resizable=yes,scrollbars=yes,toolbar=no,height=390,width=384");
}

</script>
</HEAD>
	<body bgColor="#e6e6fa" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:ruler id="Ruler1" runat="server"></uc1:ruler>
			<hr>
			<asp:Label id="lbl_inventory" runat="server" Width="100%" ForeColor="Linen" Font-Size="12pt" Font-Names="vedana,arial" BorderStyle="Groove" BorderWidth="1px" BackColor="DarkSlateBlue" Font-Bold="True" BorderColor="White">List online Help</asp:Label>
			<HR>
			<center>
				<asp:datagrid id="grd_items" runat="server" BorderColor="White" BackColor="Linen" BorderWidth="1px" BorderStyle="Outset" Font-Names="verdana,arial" Font-Size="8pt" Width="650px" PageSize="20" AllowPaging="True" AutoGenerateColumns="False">
<SelectedItemStyle ForeColor="Linen" BackColor="DarkSlateBlue">
</SelectedItemStyle>

<HeaderStyle ForeColor="Linen" BackColor="DarkSlateBlue">
</HeaderStyle>

<Columns>
<asp:BoundColumn DataField="id" HeaderText="No"></asp:BoundColumn>
<asp:BoundColumn DataField="Keyword" HeaderText="Keyword">
<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="help_header" HeaderText="Header">
<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:HyperLinkColumn Text="Edit" DataNavigateUrlField="id" DataNavigateUrlFormatString="addhelp.aspx?mode=2&amp;id={0}" HeaderText="Edit"></asp:HyperLinkColumn>
<asp:HyperLinkColumn Text="Show" DataNavigateUrlField="id" DataNavigateUrlFormatString="javascript:gethelp({0})" HeaderText="Show"></asp:HyperLinkColumn>
</Columns>

<PagerStyle ForeColor="Linen" BackColor="DarkSlateBlue" Mode="NumericPages">
</PagerStyle>
				</asp:datagrid>
			</center>
		</form>
	</body>
</HTML>
