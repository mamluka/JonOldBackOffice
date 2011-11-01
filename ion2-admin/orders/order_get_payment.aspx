<%@ Page Language="vb" AutoEventWireup="false" Codebehind="order_get_payment.aspx.vb" Inherits="ion_admin.order_get_payment"%>
<%@ Register TagPrefix="uc1" TagName="wc_get_payments" Src="wc_get_payments.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>order_get_payment</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/styles.css" type="text/css" rel="StyleSheet">
		<script language="javascript" src="..\script\norefresh.js"></script>
</HEAD>
	<body onKeyDown="onKeyDown();" bottomMargin="2" bgColor="darkgray" leftMargin="2" topMargin="2" rightMargin="2" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="tbl_main" style="BORDER-RIGHT: 1px ridge; BORDER-TOP: 1px ridge; FONT-SIZE: 10px; BORDER-LEFT: 1px ridge; COLOR: midnightblue; BORDER-BOTTOM: 1px ridge; FONT-FAMILY: verdana,arial" cellSpacing="1" cellPadding="1" width="100%" bgColor="#d3d3d3" border="0" RUNAT="server">
				<TR>
					<TD bgColor="#708090" height="12"><asp:label id="lbl_caption" runat="server" Width="292px" ForeColor="Khaki" Font-Size="10pt" Font-Names="verdana,arial" Font-Bold="True">Order payment:</asp:label></TD>
				</TR>
				<TR>
					<TD align="center" bgColor="red"><asp:listbox id="lst_error" runat="server" Width="99%" CssClass="formfield" Visible="False" FONT-BOLD="True" BACKCOLOR="Linen"></asp:listbox></TD>
				</TR>
				<TR>
					<TD vAlign="top"><ASP:LABEL id="LABEL18" runat="server" Width="140px" ForeColor="MidnightBlue" Font-Size="10pt" Font-Names="verdana,arial" Font-Bold="True" BackColor="Linen" BorderStyle="Outset" BorderWidth="1px">Current payment</ASP:LABEL><asp:label id="lbl_not_approved_yes" runat="server" Width="399px" Font-Bold="True" Visible="False" FORECOLOR="Red" FONT-SIZE="12pt"> &nbsp;&nbsp;&nbsp;No payments to be made !</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="tbl_masterpay" style="BORDER-RIGHT: 2px groove; BORDER-TOP: 2px groove; BORDER-LEFT: 2px groove; BORDER-BOTTOM: 2px groove" cellSpacing="1" cellPadding="1" width="54%" border="0" RUNAT="server">
							<TR>
								<TD><asp:label id="lbl_master_label" runat="server" ForeColor="DimGray" Font-Bold="True" FONT-SIZE="10pt" WIDTH="150px"></asp:label></TD>
								<TD align="right"><asp:label id="lbl_master_amount" runat="server" Width="150px" ForeColor="DimGray" Font-Bold="True" FONT-SIZE="10pt"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="tbl_payments" style="BORDER-RIGHT: 2px groove; BORDER-TOP: 2px groove; FONT-SIZE: 8pt; BORDER-LEFT: 2px groove; COLOR: midnightblue; BORDER-BOTTOM: 2px groove; FONT-FAMILY: verdana,arial" cellSpacing="1" cellPadding="1" width="100%" border="0" RUNAT="server">
							<TR>
								<TD STYLE="WIDTH: 89px"><asp:label id="label12" runat="server" FONT-SIZE="10pt"> Order total</asp:label></TD>
								<TD align="right"><asp:label id="lbl_order_total" runat="server" Width="150px" FONT-SIZE="10pt"></asp:label></TD>
								<TD align="right"></TD>
							</TR>
							<TR>
								<TD STYLE="WIDTH: 89px"><asp:label id="Label5" runat="server" FONT-SIZE="10pt">Interest</asp:label></TD>
								<TD align="right"><asp:label id="lbl_interest" runat="server" Width="150px" FONT-SIZE="10pt"></asp:label></TD>
								<TD align="right"></TD>
							</TR>
							<TR>
								<TD STYLE="WIDTH: 89px"><asp:label id="Label1" runat="server" FONT-SIZE="10pt">Total payed</asp:label></TD>
								<TD align="right"><asp:label id="lbl_total_payed" runat="server" Width="150px" FONT-SIZE="10pt"></asp:label></TD>
								<TD align="right"></TD>
							</TR>
							<TR>
								<TD STYLE="WIDTH: 89px"></TD>
								<TD align="right">
									<hr style="BORDER-RIGHT: 8px ridge; BORDER-TOP: 8px ridge; BORDER-LEFT: 8px ridge; WIDTH: 100%; BORDER-BOTTOM: 8px ridge" width="100%">
								</TD>
								<TD align="right"></TD>
							</TR>
							<TR>
								<TD STYLE="WIDTH: 89px"><asp:label id="Label2" runat="server" FONT-SIZE="10pt">Left to pay</asp:label></TD>
								<TD align="right"><asp:textbox id="txt_lefttopay" runat="server" Width="100px" CssClass="formfield" FONT-SIZE="10pt"></asp:textbox><asp:rangevalidator id="vld_lefttopay" runat="server" Font-Size="10pt" ControlToValidate="txt_lefttopay" ErrorMessage="&amp;times;" MAXIMUMVALUE="0" MINIMUMVALUE="0" TYPE="Currency"></asp:rangevalidator></TD>
								<TD align="left"><asp:checkbox id="chk_calcinterest" runat="server" BACKCOLOR="#C0C0FF" AUTOPOSTBACK="True" CHECKED="True"></asp:checkbox><asp:label id="Label3" runat="server" Width="180px" FONT-SIZE="10pt">Calculate interest</asp:label></TD>
							</TR>
						</TABLE>
						<BR>
						<ASP:LABEL id="LABEL4" runat="server" Width="140px" ForeColor="MidnightBlue" Font-Size="10pt" Font-Names="verdana,arial" Font-Bold="True" BackColor="Linen" BorderStyle="Outset" BorderWidth="1px">Payments made</ASP:LABEL></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="grd_cashstatus" runat="server" Width="100%" BACKCOLOR="Linen" FORECOLOR="DarkSlateBlue" FONT-SIZE="8pt" PAGESIZE="8" AllowPaging="True" ShowFooter="True" FONT-NAMES="Verdana,arial" AUTOGENERATECOLUMNS="False">
							<HEADERSTYLE FONT-SIZE="8pt" FONT-NAMES="verdana,arial" FONT-BOLD="True" FORECOLOR="Khaki" BACKCOLOR="SlateGray"></HEADERSTYLE>
							<COLUMNS>
								<asp:BoundColumn DataField="payment_date" HeaderText="Payment Date"></asp:BoundColumn>
								<asp:BoundColumn DataField="payment_method" HeaderText="Payment method"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Apr">
									<ITEMSTYLE HORIZONTALALIGN="Center"></ITEMSTYLE>
									<ITEMTEMPLATE>
										<asp:Label runat="server" Text='<%# IIF(DataBinder.Eval(Container, "DataItem.approved")="1", "&times;", "") %>'>
										</asp:Label>
									</ITEMTEMPLATE>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="amount_interest" HeaderText="Interest" DataFormatString="{0:N} $us">
									<ITEMSTYLE HORIZONTALALIGN="Right"></ITEMSTYLE>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="amount_total" ReadOnly="True" HeaderText="Amount" DataFormatString="{0:N} $us">
									<HEADERSTYLE HORIZONTALALIGN="Center"></HEADERSTYLE>
									<ITEMSTYLE HORIZONTALALIGN="Right"></ITEMSTYLE>
								</asp:BoundColumn>
							</COLUMNS>
							<PAGERSTYLE FONT-SIZE="8pt" FONT-NAMES="verdana,arial" FONT-BOLD="True" FORECOLOR="Khaki" BACKCOLOR="SlateGray" MODE="NumericPages"></PAGERSTYLE>
						</asp:datagrid><br>
					</TD>
				</TR>
				<TR>
					<TD><uc1:wc_get_payments id="Wc_get_payments1" runat="server"></uc1:wc_get_payments></TD>
				</TR>
				<TR>
					<TD vAlign="bottom" align="right"><INPUT class="formbutton" id="btn_close" style="WIDTH: 100px" onclick="window.close()" type="button" size="1" value="Close">
						<ASP:BUTTON id="btn_submit" runat="server" Width="100px" CssClass="formbutton" Text="Save"></ASP:BUTTON></TD>
				</TR>
			</TABLE>
			<asp:label id="hid_userid" runat="server" WIDTH="29px" VISIBLE="False">0</asp:label>
			<ASP:LABEL id="hid_orderid" runat="server" Width="29px" VISIBLE="False">0</ASP:LABEL>
			<ASP:LABEL id="hid_total_order" runat="server" WIDTH="29px" VISIBLE="False">0</ASP:LABEL>
		</form>
	</body>
</HTML>
