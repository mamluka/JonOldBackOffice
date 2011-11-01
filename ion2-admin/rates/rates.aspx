<%@ Page Language="vb" AutoEventWireup="false" Codebehind="rates.aspx.vb" Inherits="ion_admin.rates"%>
<%@ Register TagPrefix="uc1" TagName="ruler" Src="../webcontrols/ruler.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>rates</title>
		<LINK href="/styles.css" type="text/css" rel="StyleSheet">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="#e6e6fa" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:ruler id="Ruler1" runat="server"></uc1:ruler>
			<table cellSpacing="0" cellPadding="10" width="100%" border="0">
				<tr>
					<td colSpan="2">
						<hr>
						<asp:label id="lbl_inventory" runat="server" BorderColor="White" Font-Bold="True" BackColor="DarkSlateBlue"
							BorderWidth="1px" BorderStyle="Groove" Font-Names="vedana,arial" Font-Size="12pt" ForeColor="Linen"
							Width="100%">Show rates</asp:label>
						<hr>
					</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td><asp:datagrid id="grd_items" runat="server" BorderColor="White" BackColor="Linen" BorderWidth="1px"
							BorderStyle="Outset" Font-Names="verdana,arial" Font-Size="8pt" Width="650px" AutoGenerateColumns="False">
							<SelectedItemStyle ForeColor="Linen" BackColor="DarkSlateBlue"></SelectedItemStyle>
							<HeaderStyle ForeColor="Linen" BackColor="DarkSlateBlue"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="id" HeaderText="No"></asp:BoundColumn>
								<asp:BoundColumn DataField="name" HeaderText="Name">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="value" HeaderText="Value ">
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:HyperLinkColumn Text="Edit" DataNavigateUrlField="id" DataNavigateUrlFormatString="addhelp.aspx?mode=2&amp;id={0}"
									HeaderText="Edit"></asp:HyperLinkColumn>
								<asp:HyperLinkColumn Text="Show" DataNavigateUrlField="id" DataNavigateUrlFormatString="javascript:gethelp({0})"
									HeaderText="Show"></asp:HyperLinkColumn>
							</Columns>
							<PagerStyle ForeColor="Linen" BackColor="DarkSlateBlue" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</tr>
				<tr>
					<td colSpan="2">
						<hr>
						<asp:label id="lbl_inventory2" runat="server" BorderColor="White" Font-Bold="True" BackColor="DarkSlateBlue"
							BorderWidth="1px" BorderStyle="Groove" Font-Names="vedana,arial" Font-Size="12pt" ForeColor="Linen"
							Width="100%">Add a rate</asp:label>
						<hr>
					</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td class="formfield">&nbsp;Name:
						<asp:textbox id="name_txt" runat="server" CssClass="formfield"></asp:textbox>Code::
						<asp:textbox id="code_txt" runat="server" CssClass="formfield"></asp:textbox>Value:
						<asp:textbox id="value_txt" runat="server" Width="50px" CssClass="formfield"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:button id="Button1" runat="server" CssClass="formbutton" Text="Add"></asp:button>&nbsp;&nbsp;&nbsp;
						<asp:requiredfieldvalidator id="rate_validate" runat="server" ErrorMessage="Missing rate name" ControlToValidate="name_txt"></asp:requiredfieldvalidator>&nbsp;
						<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Missing rate code" ControlToValidate="code_txt"></asp:requiredfieldvalidator></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
