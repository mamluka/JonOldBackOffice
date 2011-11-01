<%@ Register TagPrefix="uc1" TagName="ruler" Src="../webcontrols/ruler.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="list-cashflow.aspx.vb" Inherits="ion_admin.list_cashflow"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>rpt_cashflow</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/styles.css" type="text/css" rel="StyleSheet">
		<SCRIPT language="javascript">
function receivepayment(nid){
	mywin=window.open('<%=application("config").domain%>/accounting/receive-payment.aspx?id='+nid,"displayWindow","resizable=no,scrollbars=yes,toolbar=no,height=424,width=600");
}

		</SCRIPT>
	</HEAD>
	<body bgColor="#e6e6fa" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<UC1:RULER id="Ruler1" runat="server"></UC1:RULER>
			<HR>
			<ASP:LABEL id="lbl_inventory" runat="server" ForeColor="Linen" Font-Size="12pt" Font-Names="vedana,arial" Width="100%" BorderColor="White" Font-Bold="True" BackColor="DarkSlateBlue" BorderWidth="1px" BorderStyle="Groove"> Cashflow</ASP:LABEL>
			<HR>
			<CENTER>
				<TABLE id="tbl_search" style="BORDER-RIGHT: 1px outset; BORDER-TOP: 1px outset; BORDER-LEFT: 1px outset; BORDER-BOTTOM: 1px outset; BACKGROUND-COLOR: linen" cellSpacing="1" cellPadding="1" width="650" bgColor="linen" border="0">
					<TR>
						<TD vAlign="top"><ASP:LABEL id="LABEL1" runat="server" ForeColor="MidnightBlue" Font-Size="8pt" Font-Names="verdana,arial" Width="70px">Payed since</ASP:LABEL></TD>
						<TD style="WIDTH: 145px" vAlign="top" colSpan="3"><asp:dropdownlist id="cmb_date" runat="server" Width="200px" CssClass="formfield"></asp:dropdownlist></TD>
						<TD vAlign="top"></TD>
						<TD vAlign="top"></TD>
					</TR>
					<TR>
						<TD vAlign="top"><ASP:LABEL id="Label4" runat="server" ForeColor="MidnightBlue" Font-Size="8pt" Font-Names="verdana,arial" Width="70px">Order No.</ASP:LABEL></TD>
						<TD style="WIDTH: 145px" vAlign="top"><ASP:TEXTBOX id="txt_order" runat="server" Width="80px" CssClass="formfield" MaxLength="6"></ASP:TEXTBOX></TD>
						<TD vAlign="top"><ASP:LABEL id="Label2" runat="server" ForeColor="MidnightBlue" Font-Size="8pt" Font-Names="verdana,arial" Width="73px"> Email</ASP:LABEL></TD>
						<TD vAlign="top"><ASP:TEXTBOX id="txt_email" runat="server" Width="270px" CssClass="formfield" MaxLength="100"></ASP:TEXTBOX></TD>
						<TD vAlign="top"><ASP:LABEL id="Label5" runat="server" ForeColor="MidnightBlue" Font-Size="8pt" Font-Names="verdana,arial" Width="50px">Approved</ASP:LABEL></TD>
						<TD vAlign="top"><asp:checkbox id="chk_approved" runat="server"></asp:checkbox></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD style="WIDTH: 145px"></TD>
						<TD></TD>
						<TD></TD>
						<TD></TD>
						<TD align="right"><ASP:BUTTON id="btn_search" runat="server" Width="97px" CssClass="formbutton" Text="Search"></ASP:BUTTON></TD>
					</TR>
				</TABLE>
				<BR>
				<ASP:DATAGRID id="grd_cashflow" runat="server" Font-Size="8pt" Font-Names="verdana,arial" Width="750px" BorderColor="White" BackColor="Linen" BorderWidth="1px" BorderStyle="Outset" AUTOGENERATECOLUMNS="False" AllowPaging="True" PageSize="25">
					<SelectedItemStyle ForeColor="Linen" BackColor="DarkSlateBlue"></SelectedItemStyle>
					<HeaderStyle ForeColor="Linen" BackColor="DarkSlateBlue"></HeaderStyle>
					<Columns>
						<asp:BoundColumn DataField="payment_date" HeaderText="Payment date" DataFormatString="{0:d}">
							<ItemStyle HorizontalAlign="Left"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="order_number" HeaderText="Order">
							<ItemStyle Font-Bold="True" HorizontalAlign="Right" ForeColor="#0000CC"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="Customer" HeaderText="Customer name">
							<ItemStyle HorizontalAlign="Left"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="payment_method" HeaderText="Payment method">
							<ItemStyle HorizontalAlign="Left"></ItemStyle>
						</asp:BoundColumn>
						<asp:TemplateColumn HeaderText="Apr">
							<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<ItemTemplate>
								<asp:Label runat="server" Text='<%# IIF(DataBinder.Eval(Container, "DataItem.approved")="1", "&times;", "") %>'>
								</asp:Label>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="approval_date" HeaderText="Approval date" DataFormatString="{0:d}">
							<ItemStyle HorizontalAlign="Right"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="amount_total" HeaderText="Amount" DataFormatString="{0:N} $us">
							<HeaderStyle Width="90px"></HeaderStyle>
							<ItemStyle Font-Bold="True" HorizontalAlign="Right" ForeColor="#0000CC"></ItemStyle>
						</asp:BoundColumn>
						<asp:HyperLinkColumn Text="Receive payment" DataNavigateUrlField="id" DataNavigateUrlFormatString="javascript:receivepayment({0})" HeaderText="Receive payment"></asp:HyperLinkColumn>
					</Columns>
					<PagerStyle ForeColor="Linen" BackColor="DarkSlateBlue" Mode="NumericPages"></PagerStyle>
				</ASP:DATAGRID>
		</form>
		</CENTER>
	</body>
</HTML>
