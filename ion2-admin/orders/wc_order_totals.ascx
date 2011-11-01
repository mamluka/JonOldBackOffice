<%@ Control Language="vb" AutoEventWireup="false" Codebehind="wc_order_totals.ascx.vb" Inherits="ion_admin.order_totals" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<TABLE id="tbl_totals_main" style="BORDER-RIGHT: 2px groove; BORDER-TOP: 2px groove; BORDER-LEFT: 2px groove; BORDER-BOTTOM: 2px groove"
	cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD><asp:label id="Label17" runat="server" ForeColor="MidnightBlue" Width="140px" Font-Bold="True"
				Font-Names="verdana,arial" Font-Size="10pt" BorderWidth="1px" BorderStyle="Outset" BackColor="Linen">Payment details</asp:label></TD>
	</TR>
	<TR>
		<TD align="center">
			<TABLE id="tbl_totals" style="BORDER-RIGHT: 1px outset; BORDER-TOP: 1px outset; BORDER-LEFT: 1px outset; BORDER-BOTTOM: 1px outset; BACKGROUND-COLOR: darkgray"
				cellSpacing="2" cellPadding="0" width="450" border="0">
				<TR>
					<TD vAlign="bottom" align="left" width="300"><ASP:LABEL id="Label2" runat="server" ForeColor="MidnightBlue" Width="223px" Font-Names="verdana,arial"
							Font-Size="10pt" FONT-BOLD="True">Total amount in shipping cart</ASP:LABEL></TD>
					<TD style="BORDER-RIGHT: silver 1px groove; BORDER-TOP: silver 1px groove; BORDER-LEFT: silver 1px groove; BORDER-BOTTOM: silver 1px groove"
						vAlign="bottom" align="right" width="150"><ASP:LABEL id="lbl_total_cart" Font-Size="9pt" Font-Names="verdana,arial" Width="145px" ForeColor="Blue"
							runat="server" FONT-BOLD="True"></ASP:LABEL></TD>
					<td><asp:button id="btn_getcart" runat="server" CssClass="formbutton" Text="cart"></asp:button></td>
				</TR>
				<TR>
					<TD vAlign="middle" align="left" width="300"><ASP:LABEL id="Label1" runat="server" ForeColor="MidnightBlue" Width="145px" Font-Names="verdana,arial"
							Font-Size="10pt">+ Wrapping</ASP:LABEL></TD>
					<TD style="BORDER-RIGHT: silver 2px groove; BORDER-TOP: silver 2px groove; BORDER-LEFT: silver 2px groove; BORDER-BOTTOM: silver 2px groove"
						vAlign="bottom" align="right" width="150"><ASP:LABEL id="lbl_wrapping" runat="server" ForeColor="MidnightBlue" Width="145px" Font-Names="verdana,arial"
							Font-Size="9pt"></ASP:LABEL></TD>
				</TR>
				<TR>
					<TD vAlign="middle" align="left" width="300"><ASP:LABEL id="Label3" runat="server" ForeColor="MidnightBlue" Width="200px" Font-Names="verdana,arial"
							Font-Size="10pt">+ Shipping</ASP:LABEL></TD>
					<TD style="BORDER-RIGHT: silver 2px groove; BORDER-TOP: silver 2px groove; BORDER-LEFT: silver 2px groove; BORDER-BOTTOM: silver 2px groove"
						vAlign="bottom" align="right" width="150"><ASP:LABEL id="lbl_shipping" runat="server" ForeColor="MidnightBlue" Width="145px" Font-Names="verdana,arial"
							Font-Size="9pt"></ASP:LABEL></TD>
				</TR>
				<TR>
					<TD vAlign="middle" align="left" width="300"><ASP:LABEL id="Label4" runat="server" ForeColor="MidnightBlue" Width="200px" Font-Names="verdana,arial"
							Font-Size="10pt">+ Labor</ASP:LABEL></TD>
					<TD style="BORDER-RIGHT: silver 2px groove; BORDER-TOP: silver 2px groove; BORDER-LEFT: silver 2px groove; BORDER-BOTTOM: silver 2px groove"
						vAlign="bottom" align="right" width="150"><asp:textbox id="txt_labor" runat="server" Width="100%" BackColor="#C0C0FF" CssClass="formfield_dec"
							AutoPostBack="True" MaxLength="15"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="middle" align="left" width="300"><ASP:LABEL id="Label5" runat="server" ForeColor="MidnightBlue" Width="200px" Font-Names="verdana,arial"
							Font-Size="10pt">+ Extra charges</ASP:LABEL></TD>
					<TD style="BORDER-RIGHT: silver 2px groove; BORDER-TOP: silver 2px groove; BORDER-LEFT: silver 2px groove; BORDER-BOTTOM: silver 2px groove"
						vAlign="bottom" align="right" width="150"><asp:textbox id="txt_extra_charges" runat="server" Width="100%" BackColor="#C0C0FF" CssClass="formfield_dec"
							AutoPostBack="True" MaxLength="15"></asp:textbox></TD>
				</TR>
				<TR>
					<TD vAlign="middle" align="left" width="300"><ASP:LABEL id="Label9" runat="server" ForeColor="MidnightBlue" Width="200px" Font-Names="verdana,arial"
							Font-Size="10pt">- Discount</ASP:LABEL></TD>
					<TD style="BORDER-RIGHT: silver 2px groove; BORDER-TOP: silver 2px groove; BORDER-LEFT: silver 2px groove; BORDER-BOTTOM: silver 2px groove"
						vAlign="bottom" align="right" width="150"><ASP:TEXTBOX id="txt_discount" runat="server" Width="100%" BackColor="#C0C0FF" CssClass="formfield_dec"
							AutoPostBack="True" MaxLength="15"></ASP:TEXTBOX></TD>
				</TR>
				<TR height="10">
					<TD height="10">&nbsp;
					</TD>
					<TD style="BORDER-BOTTOM: linen 1px solid" align="right" height="10">&nbsp;
					</TD>
				</TR>
				<TR>
					<TD vAlign="middle" align="left" width="300"><ASP:LABEL id="Label6" runat="server" ForeColor="MidnightBlue" Width="200px" Font-Names="verdana,arial"
							Font-Size="10pt" FONT-BOLD="True">Subtotal</ASP:LABEL></TD>
					<TD style="BORDER-RIGHT: silver 1px groove; BORDER-TOP: silver 1px groove; BORDER-LEFT: silver 1px groove; BORDER-BOTTOM: silver 1px groove"
						vAlign="bottom" align="right" width="150"><ASP:LABEL id="lbl_subtotal" runat="server" ForeColor="MidnightBlue" Width="145px" Font-Names="verdana,arial"
							Font-Size="9pt" FONT-BOLD="True"></ASP:LABEL></TD>
				</TR>
				<TR>
					<TD vAlign="middle" align="left" width="300"><ASP:LABEL id="Label7" runat="server" ForeColor="MidnightBlue" Width="153px" Font-Names="verdana,arial"
							Font-Size="10pt">+ VAT</ASP:LABEL><ASP:LABEL id="lbl_vatperc" runat="server" ForeColor="MidnightBlue" Width="50px" Font-Names="verdana,arial"
							Font-Size="10pt"></ASP:LABEL></TD>
					<TD style="BORDER-RIGHT: silver 2px groove; BORDER-TOP: silver 2px groove; BORDER-LEFT: silver 2px groove; BORDER-BOTTOM: silver 2px groove"
						vAlign="bottom" align="right" width="150"><ASP:LABEL id="lbl_vat" runat="server" ForeColor="MidnightBlue" Width="145px" Font-Names="verdana,arial"
							Font-Size="9pt"></ASP:LABEL></TD>
				</TR>
				<TR height="10">
					<TD height="10">&nbsp;
					</TD>
					<TD style="BORDER-BOTTOM: linen 3px double" align="right" height="10">&nbsp;
					</TD>
				</TR>
				<TR>
					<TD vAlign="middle" align="left" width="300"><ASP:LABEL id="Label8" runat="server" ForeColor="MidnightBlue" Width="224px" Font-Names="verdana,arial"
							Font-Size="10pt" FONT-BOLD="True">Total to charge in $US dollars</ASP:LABEL></TD>
					<TD style="BORDER-RIGHT: silver 1px groove; BORDER-TOP: silver 1px groove; BORDER-LEFT: silver 1px groove; BORDER-BOTTOM: silver 1px groove"
						vAlign="bottom" align="right" width="150"><ASP:LABEL id="lbl_grandtotal" runat="server" ForeColor="Aqua" Width="145px" Font-Names="verdana,arial"
							Font-Size="9pt" FONT-BOLD="True"></ASP:LABEL></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>
<ASP:LABEL id="hid_total_cart" runat="server" ForeColor="MidnightBlue" Width="40px" Font-Names="verdana,arial"
	Font-Size="9pt" FONT-BOLD="True" Visible="False">0</ASP:LABEL><ASP:LABEL id="hid_wrapping" runat="server" ForeColor="MidnightBlue" Width="40px" Font-Names="verdana,arial"
	Font-Size="9pt" FONT-BOLD="True" Visible="False">0</ASP:LABEL><ASP:LABEL id="hid_shipping" runat="server" ForeColor="MidnightBlue" Width="40px" Font-Names="verdana,arial"
	Font-Size="9pt" FONT-BOLD="True" Visible="False">0</ASP:LABEL><ASP:LABEL id="hid_subtotal" runat="server" ForeColor="MidnightBlue" Width="40px" Font-Names="verdana,arial"
	Font-Size="9pt" FONT-BOLD="True" Visible="False">0</ASP:LABEL><ASP:LABEL id="hid_vat" runat="server" ForeColor="MidnightBlue" Width="40px" Font-Names="verdana,arial"
	Font-Size="9pt" FONT-BOLD="True" Visible="False">0</ASP:LABEL><ASP:LABEL id="hid_vatperc" runat="server" ForeColor="MidnightBlue" Width="40px" Font-Names="verdana,arial"
	Font-Size="9pt" FONT-BOLD="True" Visible="False">0</ASP:LABEL><ASP:LABEL id="hid_grandtotal" runat="server" ForeColor="MidnightBlue" Width="40px" Font-Names="verdana,arial"
	Font-Size="9pt" FONT-BOLD="True" Visible="False">0</ASP:LABEL>
<ASP:LABEL id="hid_currency_code" Font-Size="9pt" Font-Names="verdana,arial" Width="40px" ForeColor="MidnightBlue"
	runat="server" FONT-BOLD="True" Visible="False">0</ASP:LABEL>
