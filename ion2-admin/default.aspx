<%@ Page Language="vb" AutoEventWireup="false" Codebehind="default.aspx.vb" Inherits="ion_admin._default"%>
<%@ Register TagPrefix="uc1" TagName="ruler" Src="WebControls/ruler.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Back office - TWIN-DIAMONDS.COM</title>
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/styles.css" type="text/css" rel="StyleSheet">
	</HEAD>
	<body bgColor="#e6e6fa" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:ruler id="Ruler1" runat="server"></uc1:ruler>
			<TABLE id="tbl_main" style="BORDER-RIGHT: 1px outset; BORDER-TOP: 1px outset; BORDER-LEFT: 1px outset; BORDER-BOTTOM: 1px outset"
				cellSpacing="1" cellPadding="1" bgColor="linen" border="0">
				<TR>
					<TD align="right"><asp:label id="lbl_inventory" runat="server" CssClass="menulabel">Inventory</asp:label></TD>
					<TD><asp:button id="btn_add_item" runat="server" CssClass="menubutton" Width="160px" Text="Add"></asp:button></TD>
					<TD width="200">&nbsp;</TD>
					<TD align="right"><asp:label id="lbl_checkbooks" runat="server" CssClass="menulabel">Checkbooks</asp:label></TD>
					<TD width="160"><asp:button id="btn_add_check_usd" runat="server" CssClass="menubutton" Width="160px" Text="Add - USD"></asp:button></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
					<TD>
						<P><asp:button id="btn_edit_item" runat="server" CssClass="menubutton" Width="160px" Text="View / Edit"></asp:button><BR>
							<BR>
							<asp:button id="Button9" runat="server" CssClass="menubutton" Text="Duplicate" Width="160px"></asp:button></P>
					</TD>
					<TD width="200">&nbsp;</TD>
					<TD align="right">&nbsp;</TD>
					<TD><asp:button id="btn_add_check_ils" runat="server" CssClass="menubutton" Width="160px" Text="Add - ILS"></asp:button></TD>
				</TR>
				<TR>
					<TD colSpan="2">
						<hr SIZE="1">
					</TD>
					<TD width="200">&nbsp;</TD>
					<TD align="right">&nbsp;</TD>
					<TD vAlign="top"><asp:button id="btn_edit_checks" runat="server" CssClass="menubutton" Width="160px" Text="View / Edit"></asp:button></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lbl_customers" runat="server" CssClass="menulabel">Customers</asp:label></TD>
					<TD><asp:button id="btn_add_customer" runat="server" CssClass="menubutton" Width="160px" Text="Add"></asp:button></TD>
					<TD width="200">&nbsp;</TD>
					<TD align="right">&nbsp;</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
					<TD><asp:button id="btn_edit_customer" runat="server" CssClass="menubutton" Width="160px" Text="View / Edit"></asp:button></TD>
					<TD width="200">&nbsp;</TD>
					<TD align="right">&nbsp;</TD>
					<TD><asp:button id="btn_tdgenerate" runat="server" CssClass="menubutton" Width="160px" Text="Generate TD HTM"></asp:button></TD>
				</TR>
				<TR>
					<TD colSpan="2">
						<hr SIZE="1">
					</TD>
					<TD width="200">&nbsp;</TD>
					<TD align="right">&nbsp;</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lbl_orders" runat="server" CssClass="menulabel">Orders</asp:label></TD>
					<TD><asp:button id="btn_ListOrders" runat="server" CssClass="menubutton" Width="160px" Text="Edit Orders"></asp:button></TD>
					<TD width="200">&nbsp;</TD>
					<TD align="right"><asp:label id="lbl_helpfiles" runat="server" CssClass="menulabel" Width="120px">Help file</asp:label>&nbsp;</TD>
					<TD>&nbsp;<asp:button id="btn_addhelp" runat="server" CssClass="menubutton" Width="160px" Text="Add"></asp:button></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lbl_payments" runat="server" CssClass="menulabel">Payment</asp:label></TD>
					<TD><asp:button id="btn_receive_payments" runat="server" CssClass="menubutton" Width="160px" Text="Receive payments"></asp:button></TD>
					<TD width="200">&nbsp;</TD>
					<TD align="right">&nbsp;</TD>
					<TD>&nbsp;<asp:button id="btn_edithelp" runat="server" CssClass="menubutton" Width="160px" Text="View / Edit"></asp:button></TD>
				</TR>
				<TR>
					<TD align="right"></TD>
					<TD>
						<asp:button id="Button8" runat="server" CssClass="menubutton" Text="Add Order" Width="160px"></asp:button></TD>
					<TD width="200"></TD>
					<TD align="right"></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD align="right"></TD>
					<TD><asp:button id="btn_appraisal" runat="server" CssClass="menubutton" Width="160px" Text="Appraisals"
							Visible="False"></asp:button></TD>
					<TD width="200"></TD>
					<TD align="right"><asp:label id="lbl_reports" runat="server" CssClass="menulabel" Width="120px">Reports</asp:label></TD>
					<TD>&nbsp;<asp:button id="btn_rpt_cacheflow" runat="server" CssClass="menubutton" Width="160px" Text="Cashflow"></asp:button></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 14px" colSpan="2"></TD>
					<TD style="HEIGHT: 14px" width="200">&nbsp;</TD>
					<TD style="HEIGHT: 14px" align="right"><asp:label id="Label11" runat="server" CssClass="menulabel" Width="120px">Extra</asp:label></TD>
					<TD style="HEIGHT: 14px"><INPUT class="menubutton" style="WIDTH: 160px" onclick="OpenBanners()" type="button" value="Edit Banners"></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lbl_suppliers" runat="server" CssClass="menulabel">Suppliers</asp:label></TD>
					<TD><asp:button id="btn_supplier_status" runat="server" CssClass="menubutton" Width="160px" Text="Supplier status"></asp:button></TD>
					<TD width="200">&nbsp;</TD>
					<TD align="right">&nbsp;</TD>
					<TD><asp:button id="Button2" runat="server" CssClass="menubutton" Width="160px" Text="Edit Side Stones"></asp:button></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lbl_accounts" runat="server" CssClass="menulabel">Accounts</asp:label></TD>
					<TD><asp:button id="btn_general_acc_balance" runat="server" CssClass="menubutton" Width="160px"
							Text="General Accounts status"></asp:button></TD>
					<TD width="200">&nbsp;</TD>
					<TD align="right">&nbsp;</TD>
					<TD><asp:button id="Button3" runat="server" CssClass="menubutton" Width="160px" Text="Feedbacks"></asp:button></TD>
				</TR>
				<TR>
					<TD align="right"></TD>
					<TD></TD>
					<TD width="200"></TD>
					<TD align="right"></TD>
					<TD><asp:button id="Button4" runat="server" CssClass="menubutton" Width="160px" Text="Edit Search"></asp:button></TD>
				</TR>
				<TR>
					<TD align="right"></TD>
					<TD><asp:button id="btn_rates" runat="server" CssClass="menubutton" Width="160px" Text="Rates" Enabled="False"></asp:button></TD>
					<TD width="200"></TD>
					<TD align="right"></TD>
					<TD><asp:button id="btn_text_email" runat="server" CssClass="menubutton" Width="160px" Text="Create eMail Group"></asp:button></TD>
				</TR>
				<TR>
					<TD align="right"></TD>
					<TD></TD>
					<TD></TD>
					<TD align="right"></TD>
					<TD><INPUT class="menubutton" style="WIDTH: 160px" onclick="OpenAppr()" type="button" value="Make Appraisals"></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="Label12" runat="server" CssClass="menulabel">Ebay</asp:label></TD>
					<TD>&nbsp;
						<asp:button id="Button1" runat="server" CssClass="menubutton" Width="160px" Text="Ebay Office"></asp:button></TD>
					<TD width="200"></TD>
					<TD align="right"></TD>
					<TD>
						<script type="text/javascript">
					function OpenAppr() {
						window.open('http://www.twin-diamonds.com/backoffice/appraisal.aspx','appr')
					}
					function OpenBanners() {
						window.open('http://www.twin-diamonds.com/backoffice/homepage-banners.aspx','banners')
					}
					
						</script>
						<asp:button id="Button7" runat="server" CssClass="menubutton" Width="160px" Text="Feeds"></asp:button></TD>
				</TR>
				<TR>
					<TD colSpan="2">
						<hr SIZE="1">
					</TD>
					<TD width="200">&nbsp;</TD>
					<TD align="right">&nbsp;</TD>
					<TD>
						<asp:button id="updatecurrency" runat="server" CssClass="menubutton" Text="Update Currency"
							Width="160px"></asp:button><A href="/default.aspx"></A></TD>
				</TR>
				<TR>
					<TD colSpan="2"></TD>
					<TD width="200"></TD>
					<TD align="right"></TD>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
