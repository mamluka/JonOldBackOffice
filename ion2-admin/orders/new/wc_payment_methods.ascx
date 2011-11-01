<%@ Control Language="vb" AutoEventWireup="false" Codebehind="wc_payment_methods.ascx.vb" Inherits="ion_admin.wc_payment_methods" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<style type="text/css">.titles { PADDING-RIGHT: 5px; PADDING-LEFT: 5px; FONT-SIZE: 12px; PADDING-BOTTOM: 5px; COLOR: #000000; PADDING-TOP: 5px; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif; BACKGROUND-COLOR: #969696 }
</style>
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
		<td class="titles" colSpan="4"><asp:checkbox id="chk_cc" Width="16px" runat="server" AutoPostBack="True"></asp:checkbox>Cradit 
			Card
		</td>
	</tr>
	<tr>
		<td width="25%">CC type
		</td>
		<td width="25%"><asp:dropdownlist id="cc_type" runat="server"></asp:dropdownlist></td>
		<td width="25%">:Name on card</td>
		<td width="25%">
			<asp:TextBox id="cc_name" runat="server"></asp:TextBox></td>
	</tr>
	<tr>
		<td width="25%">CC number
		</td>
		<td width="25%"><asp:textbox id="cc_number" runat="server"></asp:textbox></td>
		<td width="25%">CVV</td>
		<td width="25%">
			<asp:textbox id="cc_cvv" Width="72px" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td width="25%">CC Exp Date
		</td>
		<td width="25%"><asp:dropdownlist id="cc_month" CssClass="formfield" Width="46px" runat="server">
				<asp:ListItem Value="0">-</asp:ListItem>
				<asp:ListItem Value="1">1</asp:ListItem>
				<asp:ListItem Value="2">2</asp:ListItem>
				<asp:ListItem Value="3">3</asp:ListItem>
				<asp:ListItem Value="4">4</asp:ListItem>
				<asp:ListItem Value="5">5</asp:ListItem>
				<asp:ListItem Value="6">6</asp:ListItem>
				<asp:ListItem Value="7">7</asp:ListItem>
				<asp:ListItem Value="8">8</asp:ListItem>
				<asp:ListItem Value="9">9</asp:ListItem>
				<asp:ListItem Value="10">10</asp:ListItem>
				<asp:ListItem Value="11">11</asp:ListItem>
				<asp:ListItem Value="12">12</asp:ListItem>
			</asp:dropdownlist><asp:dropdownlist id="cc_year" CssClass="formfield" Width="81px" runat="server">
				<asp:ListItem Value="0">-</asp:ListItem>
				<asp:ListItem Value="02">2002</asp:ListItem>
				<asp:ListItem Value="03">2003</asp:ListItem>
				<asp:ListItem Value="04">2004</asp:ListItem>
				<asp:ListItem Value="05">2005</asp:ListItem>
				<asp:ListItem Value="06">2006</asp:ListItem>
				<asp:ListItem Value="07">2007</asp:ListItem>
				<asp:ListItem Value="08">2008</asp:ListItem>
				<asp:ListItem Value="09">2009</asp:ListItem>
				<asp:ListItem Value="10">2010</asp:ListItem>
				<asp:ListItem Value="11">2011</asp:ListItem>
				<asp:ListItem Value="12">2012</asp:ListItem>
			</asp:dropdownlist></td>
		<td width="25%">&nbsp;ID number:
		</td>
		<td width="25%">&nbsp;
			<asp:textbox id="cc_id" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td width="25%">&nbsp;</td>
		<td width="25%">&nbsp;</td>
		<td width="25%">&nbsp;</td>
		<td width="25%">&nbsp;</td>
	</tr>
	<tr>
		<td class="titles" colSpan="4"><asp:checkbox id="chk_wt" Width="16px" runat="server" AutoPostBack="True"></asp:checkbox>Wire 
			Transfer
		</td>
	</tr>
	<tr>
		<td width="25%">Bank name
		</td>
		<td width="25%"><asp:textbox id="wt_bankname" runat="server"></asp:textbox></td>
		<td width="25%">&nbsp;</td>
		<td width="25%">&nbsp;</td>
	</tr>
	<tr>
		<td width="25%">Name of transation
		</td>
		<td width="25%"><asp:textbox id="wt_trasname" runat="server"></asp:textbox></td>
		<td width="25%">&nbsp;</td>
		<td width="25%">&nbsp;</td>
	</tr>
	<tr>
		<td width="25%">Account</td>
		<td width="25%"><asp:textbox id="wt_account" Width="112px" runat="server"></asp:textbox></td>
		<td width="25%">Transfer code
		</td>
		<td width="25%"><asp:textbox id="wt_code" Width="184px" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="titles" colSpan="4"><asp:checkbox id="chk_cq" Width="16px" runat="server" AutoPostBack="True"></asp:checkbox>Cashier's 
			Check
		</td>
	</tr>
	<tr>
		<td width="25%">Bank name
		</td>
		<td width="25%"><asp:textbox id="cq_bank" runat="server"></asp:textbox></td>
		<td width="25%">&nbsp;</td>
		<td width="25%">&nbsp;</td>
	</tr>
	<tr>
		<td width="25%">Name on check
		</td>
		<td width="25%"><asp:textbox id="cq_name" runat="server"></asp:textbox></td>
		<td width="25%">&nbsp;</td>
		<td width="25%">&nbsp;</td>
	</tr>
	<tr>
		<td>Account number
		</td>
		<td><asp:textbox id="cq_number" runat="server"></asp:textbox></td>
		<td>Check date
		</td>
		<td><asp:textbox id="cq_date" Width="104px" runat="server"></asp:textbox></td>
	</tr>
	<tr>
		<td class="titles">&nbsp;
			<asp:checkbox id="chk_paypal" AutoPostBack="True" runat="server" Width="16px"></asp:checkbox>Paypal</td>
		<td class="titles">&nbsp;</td>
		<td class="titles">&nbsp;</td>
		<td class="titles">&nbsp;</td>
	</tr>
	<tr>
		<td>&nbsp;</td>
		<td>&nbsp;</td>
		<td>&nbsp;</td>
		<td>&nbsp;</td>
	</tr>
	<tr>
		<td>&nbsp;</td>
		<td>&nbsp;</td>
		<td>&nbsp;</td>
		<td>&nbsp;</td>
	</tr>
</table>
