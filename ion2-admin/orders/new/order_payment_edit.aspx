<%@ Register TagPrefix="uc1" TagName="wc_get_payments" Src="/orders/wc_get_payments.ascx" %>
<%@ Register TagPrefix="uc1" TagName="wc_payment_methods" Src="wc_payment_methods.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="order_payment_edit.aspx.vb" Inherits="ion_admin.order_payment_edit"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>order_payment_edit</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<LINK href="/styles.css" type="text/css" rel="StyleSheet">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<style type="text/css">.just_text { FONT-SIZE: 12px; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
	BODY { BACKGROUND-COLOR: #cccccc }
		</style>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table class="just_text" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td>
						<table cellSpacing="0" cellPadding="5" width="100%" border="0">
							<tr>
								<td align="right" width="20%">Order grand total
								</td>
								<td width="28%">&nbsp;
									<asp:label id="pay_grandtotal" runat="server"></asp:label></td>
								<td width="17%">CC verified
								</td>
								<td width="35%">&nbsp;
									<asp:checkbox id="chk_cc_verified" runat="server" AutoPostBack="True"></asp:checkbox></td>
							</tr>
							<tr>
								<td align="right">Total payed
								</td>
								<td>&nbsp;
									<asp:label id="pay_payed" runat="server"></asp:label></td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td align="right">Left to pay
								</td>
								<td>&nbsp;
									<asp:label id="pay_lefttopay" runat="server"></asp:label></td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td><br>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td width="3%" bgColor="#999999">&nbsp;</td>
								<td width="34%" bgColor="#999999">Mathod of payment
								</td>
								<td width="38%" bgColor="#999999">Amount</td>
								<td width="25%" bgColor="#999999">Date</td>
							</tr>
							<%
							dim i as int32
							if me.pay_coll.count > 0 then
							for i=0 to me.pay_coll.count-1
							%>
							<tr>
								<td><%=  convert.tostring(me.pay_coll(i).id) %></td>
								<td><%=  convert.tostring(me.pay_coll(i).payment_method) %></td>
								<td><%=  convert.tostring(me.pay_coll(i).amount_formatted) %></td>
								<td><%=  convert.tostring(me.pay_coll(i).payment_date) %></td>
							</tr>
							<%
						  	next
							end if
							
							%>
						</table>
						<br>
						<br>
					</td>
				</tr>
				<tr>
					<td><uc1:wc_payment_methods id="Wc_payment_methods1" runat="server"></uc1:wc_payment_methods></td>
				</tr>
				<tr>
					<td>&nbsp;
						<asp:textbox id="txt_amout_tosave" runat="server"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:RangeValidator id="val_tosave" runat="server" ErrorMessage="You can't put in more then left to pay"
							MinimumValue="0" Display="Dynamic" MaximumValue="3000" ControlToValidate="txt_amout_tosave"></asp:RangeValidator></td>
				</tr>
				<tr>
					<td>&nbsp;
						<asp:button id="btn_do" runat="server" Text="Make Payment"></asp:button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
