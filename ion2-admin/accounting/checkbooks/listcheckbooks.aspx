<%@ Page Language="vb" AutoEventWireup="false" Codebehind="listcheckbooks.aspx.vb" Inherits="ion_admin.listcheckbooks"%>
<%@ Register TagPrefix="uc1" TagName="ruler" Src="../../webcontrols/ruler.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>listcheckbooks</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/styles.css" type="text/css" rel="StyleSheet">
		<SCRIPT language="javascript">
		function accountstatus(nid){
			mywin=window.open('<%=application("config").domain%>/accounting/checkbooks/checkbook.aspx?id='+nid,"displayWindow","resizable=no,scrollbars=yes,toolbar=no,height=424,width=675");
			}
		</SCRIPT>
	</HEAD>
	<body MS_POSITIONING="GridLayout" bgColor="#e6e6fa">
		<form id="Form1" method="post" runat="server">
			<uc1:ruler id="Ruler1" runat="server"></uc1:ruler>
			<HR>
			<asp:Label id="lbl_inventory" runat="server" Width="100%" ForeColor="Linen" Font-Size="12pt" Font-Names="vedana,arial" BorderStyle="Groove" BorderWidth="1px" BackColor="DarkSlateBlue" Font-Bold="True" BorderColor="White">List Checkbooks</asp:Label>
			<HR>
			<TABLE id="tbl_selection" cellSpacing="1" cellPadding="1" width="100%" border="0" style="BORDER-RIGHT: 1px ridge; BORDER-TOP: 1px ridge; BORDER-LEFT: 1px ridge; BORDER-BOTTOM: 1px ridge" bgColor="#faf0e6">
				<TR>
					<TD>
						<asp:label id="Label1" runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue" Width="99px">Checkbook</asp:label></TD>
					<TD width="100%">
						<asp:DropDownList id="cmb_checkbook" runat="server" CssClass="formfield" Width="213px">
							<asp:ListItem Value="1">USD - US Dollar</asp:ListItem>
							<asp:ListItem Value="2">ILS - Israeli Shekel</asp:ListItem>
						</asp:DropDownList></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD align="right">
						<asp:button id="btn_search" runat="server" Width="97px" Text="Search" CssClass="formbutton"></asp:button></TD>
				</TR>
			</TABLE>
			<br>
			<center>
				<asp:datagrid id="grd_items" runat="server" BorderColor="White" BackColor="Linen" BorderWidth="1px" BorderStyle="Outset" Font-Names="verdana,arial" Font-Size="8pt" Width="100%" PageSize="25" AllowPaging="True" AutoGenerateColumns="False">
					<SelectedItemStyle ForeColor="Linen" BackColor="DarkSlateBlue"></SelectedItemStyle>
					<HeaderStyle ForeColor="Linen" BackColor="DarkSlateBlue"></HeaderStyle>
					<Columns>
						<asp:BoundColumn DataField="checknumber" HeaderText="Number"></asp:BoundColumn>
						<asp:BoundColumn DataField="checkdate" HeaderText="Date"></asp:BoundColumn>
						<asp:BoundColumn DataField="Name to" HeaderText="To"></asp:BoundColumn>
						<asp:BoundColumn DataField="chashed" HeaderText="Cashed"></asp:BoundColumn>
						<asp:BoundColumn DataField="amount" HeaderText="Amount" DataFormatString="{0:N}"></asp:BoundColumn>
						<asp:HyperLinkColumn Text="Edit" DataNavigateUrlField="id" DataNavigateUrlFormatString="javascript:accountstatus({0})" HeaderText="Edit"></asp:HyperLinkColumn>
					</Columns>
					<PagerStyle ForeColor="Linen" BackColor="DarkSlateBlue" Mode="NumericPages"></PagerStyle>
				</asp:datagrid>
			</center>
		</form>
	</body>
</HTML>
