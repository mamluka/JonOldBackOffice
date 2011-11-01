<%@ Register TagPrefix="uc1" TagName="ruler" Src="../webcontrols/ruler.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="list-orders.aspx.vb" Inherits="ion_admin.list_orders"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>list_orders</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/styles.css" type="text/css" rel="StyleSheet">
		<SCRIPT language="javascript">
function showstatus(nid){
	mywin=window.open('<%=application("config").domain%>/orders/order_status.aspx?id='+nid,"displayWindow","resizable=no,scrollbars=no,toolbar=no,height=505,width=750");
}

function makeinvoice(nid){
	mywin=window.open('<%=application("config").domain%>/orders/order_invoice.aspx?id='+nid,"displayWindow","resizable=no,scrollbars=yes,toolbar=no,height=515,width=750");
}

function payment(nid){
	mywin=window.open('<%=application("config").domain%>/orders/order_get_payment.aspx?id='+nid,"displayWindow","resizable=no,scrollbars=yes,toolbar=no,height=570,width=630");
	
	
}
function render_newpay(orderid,user_id) {

mywin=window.open('<%=application("config").domain%>/orders/new/order_payment_edit.aspx?id='+orderid+'&userid='+user_id,"displayWindow","resizable=no,scrollbars=yes,toolbar=no,height=570,width=630");

}

		</SCRIPT>
	</HEAD>
	<body bgColor="#e6e6fa" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:ruler id="Ruler1" runat="server"></uc1:ruler>
			<HR>
			<ASP:LABEL id="lbl_inventory" runat="server" ForeColor="Linen" Font-Size="12pt" Font-Names="vedana,arial"
				Width="100%" BorderColor="White" Font-Bold="True" BackColor="DarkSlateBlue" BorderWidth="1px"
				BorderStyle="Groove">List Orders</ASP:LABEL>
			<HR>
			<center>
				<TABLE id="tbl_search" style="BORDER-RIGHT: 1px outset; BORDER-TOP: 1px outset; BORDER-LEFT: 1px outset; BORDER-BOTTOM: 1px outset; BACKGROUND-COLOR: linen"
					cellSpacing="1" cellPadding="1" width="650" bgColor="linen" border="0">
					<TR>
						<TD><ASP:LABEL id="Label4" runat="server" ForeColor="MidnightBlue" Font-Size="8pt" Font-Names="verdana,arial"
								Width="70px">Order No.</ASP:LABEL></TD>
						<TD><ASP:TEXTBOX id="txt_order" runat="server" Width="80px" CssClass="formfield" MaxLength="6"></ASP:TEXTBOX></TD>
						<TD><ASP:LABEL id="Label2" runat="server" ForeColor="MidnightBlue" Font-Size="8pt" Font-Names="verdana,arial"
								Width="73px">Invoice No.</ASP:LABEL></TD>
						<TD><ASP:TEXTBOX id="txt_invoice" runat="server" Width="80px" CssClass="formfield" MaxLength="7"></ASP:TEXTBOX></TD>
						<TD><ASP:LABEL id="Label5" runat="server" ForeColor="MidnightBlue" Font-Size="8pt" Font-Names="verdana,arial"
								Width="50px">Email</ASP:LABEL></TD>
						<TD><ASP:TEXTBOX id="txt_email" runat="server" Width="270px" CssClass="formfield" MaxLength="100"></ASP:TEXTBOX></TD>
					</TR>
					<TR>
						<TD><ASP:LABEL id="LABEL1" runat="server" ForeColor="MidnightBlue" Font-Size="8pt" Font-Names="verdana,arial"
								Width="70px">Sort by</ASP:LABEL></TD>
						<TD><asp:dropdownlist id="sortorder" runat="server" AutoPostBack="True">
								<asp:ListItem Value="4">Choose</asp:ListItem>
								<asp:ListItem Value="1">Email</asp:ListItem>
								<asp:ListItem Value="2">Status</asp:ListItem>
								<asp:ListItem Value="3">Name</asp:ListItem>
							</asp:dropdownlist></TD>
						<TD></TD>
						<TD></TD>
						<TD></TD>
						<TD align="right"><ASP:BUTTON id="btn_search" runat="server" Width="97px" CssClass="formbutton" Text="Search"></ASP:BUTTON></TD>
					</TR>
				</TABLE>
				<br>
				<ASP:DATAGRID id="grd_orders" runat="server" Font-Size="7pt" Font-Names="verdana,arial" Width="100%"
					BorderColor="White" BackColor="Linen" BorderWidth="1px" BorderStyle="Outset" PageSize="25"
					AllowPaging="True" AUTOGENERATECOLUMNS="False" AllowSorting="True">
					<SelectedItemStyle ForeColor="Linen" BackColor="DarkSlateBlue"></SelectedItemStyle>
					<HeaderStyle ForeColor="Linen" BackColor="DarkSlateBlue"></HeaderStyle>
					<Columns>
						<asp:BoundColumn DataField="ordernumber" HeaderText="Order">
							<ItemStyle HorizontalAlign="Right"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="orderdate" HeaderText="Date" DataFormatString="{0:d}">
							<ItemStyle HorizontalAlign="Right"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="invoicenumber" HeaderText="Invoice">
							<ItemStyle HorizontalAlign="Right"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="customername" HeaderText="Customer"></asp:BoundColumn>
						<asp:BoundColumn DataField="customeremail" HeaderText="Email">
							<HeaderStyle Width="120px"></HeaderStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="sts_curr_stat" HeaderText="Status">
							<HeaderStyle Width="140px"></HeaderStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="amnt_grandtotal" HeaderText="Total" DataFormatString="{0:N}">
							<ItemStyle Font-Bold="True" HorizontalAlign="Right" ForeColor="#0000CC"></ItemStyle>
						</asp:BoundColumn>
						
						<asp:HyperLinkColumn Text="Edit" DataNavigateUrlField="order_id" DataNavigateUrlFormatString="order.aspx?id={0}"
							HeaderText="Edit"></asp:HyperLinkColumn>
						<asp:HyperLinkColumn Text="Pay" DataNavigateUrlField="order_id" DataNavigateUrlFormatString="javascript:payment({0})"
							HeaderText="Pay"></asp:HyperLinkColumn>
						<asp:HyperLinkColumn Text="Status" DataNavigateUrlField="order_id" DataNavigateUrlFormatString="javascript:showstatus({0})"
							HeaderText="Status"></asp:HyperLinkColumn>
						<asp:HyperLinkColumn Text="Invoice" DataNavigateUrlField="order_id" DataNavigateUrlFormatString="javascript:makeinvoice({0})"
							HeaderText="Invoice"></asp:HyperLinkColumn>
						<asp:HyperLinkColumn Text="New Pay" DataNavigateUrlField="order_id" DataNavigateUrlFormatString="javascript:render_newpay({0})"
							HeaderText="New Pay"></asp:HyperLinkColumn>
					</Columns>
					<PagerStyle ForeColor="Linen" BackColor="DarkSlateBlue" Mode="NumericPages"></PagerStyle>
				</ASP:DATAGRID></center>
		</form>
		<CENTER></CENTER>
	</body>
</HTML>
