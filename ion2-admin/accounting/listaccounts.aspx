<%@ Page Language="vb" AutoEventWireup="false" Codebehind="listaccounts.aspx.vb" Inherits="ion_admin.listaccounts"%>
<%@ Register TagPrefix="uc1" TagName="ruler" Src="../webcontrols/ruler.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>listaccounts</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/styles.css" type="text/css" rel="StyleSheet">
		<SCRIPT language="javascript">
		function accountstatus(nid){
			mywin=window.open('<%=application("config").domain%>/accounting/accountstatus.aspx?id='+nid,"displayWindow","resizable=no,scrollbars=yes,toolbar=no,height=424,width=675");
			}
		</SCRIPT>
	</HEAD>
	<body MS_POSITIONING="GridLayout" bgColor="#e6e6fa">
		<form id="Form1" method="post" runat="server">
			<uc1:ruler id="Ruler1" runat="server"></uc1:ruler>
			<HR>
			<asp:Label id="lbl_inventory" runat="server" Width="100%" ForeColor="Linen" Font-Size="12pt" Font-Names="vedana,arial" BorderStyle="Groove" BorderWidth="1px" BackColor="DarkSlateBlue" Font-Bold="True" BorderColor="White">List Accounts</asp:Label>
			<HR>
			<center>
				<asp:datagrid id="grd_items" runat="server" BorderColor="White" BackColor="Linen" BorderWidth="1px" BorderStyle="Outset" Font-Names="verdana,arial" Font-Size="8pt" Width="400px" PageSize="25" AllowPaging="True" AutoGenerateColumns="False">
					<SelectedItemStyle ForeColor="Linen" BackColor="DarkSlateBlue"></SelectedItemStyle>
					<HeaderStyle ForeColor="Linen" BackColor="DarkSlateBlue"></HeaderStyle>
					<Columns>
						<asp:BoundColumn DataField="account" HeaderText="Account"></asp:BoundColumn>
						<asp:BoundColumn DataField="currency" HeaderText="Currency"></asp:BoundColumn>
						<asp:HyperLinkColumn Text="Status" DataNavigateUrlField="id" DataNavigateUrlFormatString="javascript:accountstatus({0})" HeaderText="Status"></asp:HyperLinkColumn>
					</Columns>
					<PagerStyle ForeColor="Linen" BackColor="DarkSlateBlue" Mode="NumericPages"></PagerStyle>
				</asp:datagrid>
			</center>
		</form>
	</body>
</HTML>
