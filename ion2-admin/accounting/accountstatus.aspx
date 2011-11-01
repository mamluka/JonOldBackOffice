<%@ Page Language="vb" AutoEventWireup="false" Codebehind="accountstatus.aspx.vb" Inherits="ion_admin.accountstatus"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>accountstatus</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/styles.css" type="text/css" rel="StyleSheet">
	</HEAD>
	<body bottomMargin="2" bgColor="#a9a9a9" leftMargin="2" topMargin="2" rightMargin="2" MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="tbl_main" cellSpacing="1" cellPadding="1" width="651" bgColor="#d3d3d3" border="0">
				<TR>
					<TD bgColor="#708090">
						<asp:label id="lbl_caption" runat="server" Font-Bold="True" Font-Names="verdana,arial" Font-Size="10pt" ForeColor="Khaki" Width="404px"> Supplier status:</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:datagrid id="grd_items" runat="server" Font-Names="verdana,arial" Font-Size="8pt" Width="650px" BorderColor="White" BackColor="Linen" BorderWidth="1px" BorderStyle="Outset" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" CellPadding="1">
							<SelectedItemStyle ForeColor="Linen" BackColor="DarkSlateBlue"></SelectedItemStyle>
							<HeaderStyle ForeColor="Linen" BackColor="SlateGray"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="ordernumber" HeaderText="Order#">
									<HeaderStyle Width="10px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="invoicenumber" HeaderText="Invoice#">
									<HeaderStyle Width="10px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="trs_date" HeaderText="Date" DataFormatString="{0:g}"></asp:BoundColumn>
								<asp:BoundColumn DataField="description" HeaderText="Description"></asp:BoundColumn>
								<asp:BoundColumn DataField="amount" HeaderText="Amount" DataFormatString="{0:N} $us">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle ForeColor="Linen" BackColor="SlateGray" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="Label3" runat="server" Font-Bold="True" Font-Names="verdana,arial" Font-Size="10pt" ForeColor="MidnightBlue" Width="60px">Total:</asp:Label>
						<asp:Label id="lbl_total" runat="server" Font-Bold="True" Font-Names="verdana,arial" Font-Size="10pt" ForeColor="MidnightBlue" Width="130px" BorderColor="Silver" BackColor="#E0E0E0" BorderWidth="1px" BorderStyle="Solid"></asp:Label></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD align="right">
						<INPUT class="formbutton" id="btn_close" style="WIDTH: 100px" onclick="window.close()" type="button" size="1" value="Close" name="btn_close"></TD>
				</TR>
			</TABLE>
		</FORM>
	</body>
</HTML>
