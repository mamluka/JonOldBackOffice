<%@ Register TagPrefix="uc1" TagName="tasklist" Src="../webcontrols/orders/tasklist.ascx" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="wc_order.ascx.vb" Inherits="ion_admin.wc_order" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="uc1" TagName="wc_order_reconsile" Src="wc_order_reconsile.ascx" %>
<%@ Register TagPrefix="uc1" TagName="wc_cart_content" Src="wc_cart_content.ascx" %>
<%@ Register TagPrefix="uc1" TagName="wc_order_totals" Src="wc_order_totals.ascx" %>
<TABLE id="tbl_checkout_main" style="BORDER-BOTTOM: 2px groove; BORDER-LEFT: 2px groove; BACKGROUND-COLOR: gainsboro; BORDER-TOP: 2px groove; BORDER-RIGHT: 2px groove"
	cellSpacing="0" cellPadding="2" width="450" border="0">
	<TR>
		<TD style="BORDER-BOTTOM: 1px outset; BORDER-LEFT: 1px outset; BORDER-TOP: 1px outset; BORDER-RIGHT: 1px outset"
			bgColor="#708090" height="20"><ASP:LABEL id="lbl_header" runat="server" Width="353px" ForeColor="Khaki" Font-Size="10pt"
				Font-Names="verdana,arial" Font-Bold="True">Checkout  (Items purchase)</ASP:LABEL></TD>
	</TR>
	<TR>
		<TD align="center" bgColor="red"><ASP:LISTBOX id="lst_error" runat="server" Width="99%" ForeColor="MidnightBlue" Font-Bold="True"
				CssClass="formfield" Visible="False" BackColor="Linen"></ASP:LISTBOX></TD>
	</TR>
	<TR>
		<TD ALIGN="right">&nbsp;
			<ASP:LABEL id="lbl_cluborder" Font-Bold="True" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="Red"
				Width="104px" runat="server" Visible="False">CLUB ITEM(S) &nbsp; &nbsp;</ASP:LABEL>
		</TD>
	</TR>
	<TR>
		<TD align="left">
			<asp:CheckBox id="chk_cannot_be_changed" Font-Bold="True" runat="server" CssClass="formfield"
				Text="Lock/Unlock order" BackColor="#C0C0FF" AutoPostBack="True"></asp:CheckBox>
			<a href="javascript:PrintOrder()"></a>
		</TD>
	</TR>
	<TR>
		<TD align="left">
			<table id="tbl_addItem" style="BORDER-BOTTOM: 2px groove; BORDER-LEFT: 2px groove; BORDER-TOP: 2px groove; BORDER-RIGHT: 2px groove"
				cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td colSpan="5"><UC1:WC_CART_CONTENT id="Wc_cart_content1" runat="server"></UC1:WC_CART_CONTENT></td>
				</tr>
				<TR>
					<TD><ASP:DROPDOWNLIST id="cmb_item_to_delete" runat="server" Width="150px" CssClass="formfield"></ASP:DROPDOWNLIST></TD>
					<TD><ASP:BUTTON id="btn_item_to_delete" runat="server" CssClass="formbutton" WIDTH="100px" Text="Remove item"></ASP:BUTTON></TD>
					<TD width="150">&nbsp;
					</TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD><asp:textbox id="txt_add_item" runat="server" CssClass="formfield" WIDTH="150px"></asp:textbox></TD>
					<TD><asp:dropdownlist id="cmb_qty" Width="50px" runat="server" CssClass="formfield">
							<asp:ListItem Value="0">Qty</asp:ListItem>
							<asp:ListItem Value="1" Selected="True">1</asp:ListItem>
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
							<asp:ListItem Value="13">13</asp:ListItem>
							<asp:ListItem Value="14">14</asp:ListItem>
							<asp:ListItem Value="15">15</asp:ListItem>
							<asp:ListItem Value="16">16</asp:ListItem>
							<asp:ListItem Value="17">17</asp:ListItem>
							<asp:ListItem Value="18">18</asp:ListItem>
							<asp:ListItem Value="19">19</asp:ListItem>
							<asp:ListItem Value="20">20</asp:ListItem>
							<asp:ListItem Value="21">21</asp:ListItem>
							<asp:ListItem Value="22">22</asp:ListItem>
							<asp:ListItem Value="23">23</asp:ListItem>
							<asp:ListItem Value="24">24</asp:ListItem>
							<asp:ListItem Value="25">25</asp:ListItem>
							<asp:ListItem Value="26">26</asp:ListItem>
							<asp:ListItem Value="27">27</asp:ListItem>
							<asp:ListItem Value="28">28</asp:ListItem>
							<asp:ListItem Value="29">29</asp:ListItem>
							<asp:ListItem Value="30">30</asp:ListItem>
						</asp:dropdownlist><asp:dropdownlist id="cmb_size" Width="70px" runat="server" CssClass="formfield">
							<asp:ListItem Value="0">Size</asp:ListItem>
							<asp:ListItem Value="4.50">4.50</asp:ListItem>
							<asp:ListItem Value="4.75">4.75</asp:ListItem>
							<asp:ListItem Value="5.0">5.0</asp:ListItem>
							<asp:ListItem Value="5.25">5.25</asp:ListItem>
							<asp:ListItem Value="5.50">5.50</asp:ListItem>
							<asp:ListItem Value="5.75">5.75</asp:ListItem>
							<asp:ListItem Value="6.00">6.00</asp:ListItem>
							<asp:ListItem Value="6.25">6.25</asp:ListItem>
							<asp:ListItem Value="6.50">6.50</asp:ListItem>
							<asp:ListItem Value="6.75">6.75</asp:ListItem>
							<asp:ListItem Value="7.00">7.00</asp:ListItem>
							<asp:ListItem Value="7.25">7.25</asp:ListItem>
							<asp:ListItem Value="7.50">7.50</asp:ListItem>
							<asp:ListItem Value="7.75">7.75</asp:ListItem>
							<asp:ListItem Value="8.00">8.00</asp:ListItem>
							<asp:ListItem Value="8.25">8.25</asp:ListItem>
							<asp:ListItem Value="8.50">8.50</asp:ListItem>
							<asp:ListItem Value="8.75">8.75</asp:ListItem>
							<asp:ListItem Value="9.00">9.00</asp:ListItem>
							<asp:ListItem Value="9.25">9.25</asp:ListItem>
							<asp:ListItem Value="9.50">9.50</asp:ListItem>
							<asp:ListItem Value="9.75">9.75</asp:ListItem>
						</asp:dropdownlist><ASP:BUTTON id="btn_add_item" runat="server" CssClass="formbutton" WIDTH="100px" Text="Add item"></ASP:BUTTON></TD>
					<TD width="150"></TD>
					<TD></TD>
					<TD></TD>
				</TR>
			</table>
			<uc1:wc_order_reconsile id="Wc_order_reconsile1" runat="server"></uc1:wc_order_reconsile></TD>
	</TR>
	<TR id="addresses">
		<TD style="HEIGHT: 307px" align="left">
			<TABLE id="tbl_address" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD>
						<TABLE id="tbl_adr_billing" style="BORDER-BOTTOM: 2px groove; BORDER-LEFT: 2px groove; BORDER-TOP: 2px groove; BORDER-RIGHT: 2px groove"
							cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD colSpan="4"><ASP:LABEL id="Label17" runat="server" Width="140px" ForeColor="MidnightBlue" Font-Size="10pt"
										Font-Names="verdana,arial" Font-Bold="True" BackColor="Linen" BorderWidth="1px" BorderStyle="Outset">Billing Address</ASP:LABEL></TD>
							</TR>
							<TR>
								<TD><ASP:LABEL id="Label15" runat="server" Width="90px" ForeColor="MidnightBlue" Font-Size="8pt"
										Font-Names="verdana,arial">Name</ASP:LABEL></TD>
								<TD colSpan="3"><ASP:TEXTBOX id="txt_bln_name" runat="server" Width="325px" ForeColor="MidnightBlue" Font-Size="8pt"
										Font-Names="verdana,arial" CssClass="formfield" MaxLength="100"></ASP:TEXTBOX><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="&amp;times;" ControlToValidate="txt_bln_name"></asp:RequiredFieldValidator></TD>
							</TR>
							<TR>
								<TD><ASP:LABEL id="Label2" runat="server" Width="90px" ForeColor="MidnightBlue" Font-Size="8pt"
										Font-Names="verdana,arial">Street</ASP:LABEL></TD>
								<TD colSpan="3"><ASP:TEXTBOX id="txt_bln_street" runat="server" Width="325px" ForeColor="MidnightBlue" Font-Size="8pt"
										Font-Names="verdana,arial" CssClass="formfield" MaxLength="100"></ASP:TEXTBOX><asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="&amp;times;" ControlToValidate="txt_bln_street"></asp:RequiredFieldValidator></TD>
							</TR>
							<TR>
								<TD><ASP:LABEL id="Label3" runat="server" Width="90px" ForeColor="MidnightBlue" Font-Size="8pt"
										Font-Names="verdana,arial">City</ASP:LABEL></TD>
								<TD><ASP:TEXTBOX id="txt_bln_city" runat="server" Width="150px" ForeColor="MidnightBlue" Font-Size="8pt"
										Font-Names="verdana,arial" CssClass="formfield" MaxLength="40"></ASP:TEXTBOX><asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="&amp;times;" ControlToValidate="txt_bln_city"></asp:RequiredFieldValidator></TD>
								<TD><ASP:LABEL id="Label25" runat="server" Width="90px" ForeColor="MidnightBlue" Font-Size="8pt"
										Font-Names="verdana,arial">Zip</ASP:LABEL></TD>
								<TD><ASP:TEXTBOX id="txt_bln_zip" runat="server" Width="100px" ForeColor="MidnightBlue" Font-Size="8pt"
										Font-Names="verdana,arial" CssClass="formfield" MaxLength="8"></ASP:TEXTBOX><asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ErrorMessage="&amp;times;" ControlToValidate="txt_bln_zip"></asp:RequiredFieldValidator></TD>
							</TR>
							<TR>
								<TD><ASP:LABEL id="Label5" runat="server" Width="90px" ForeColor="MidnightBlue" Font-Size="8pt"
										Font-Names="verdana,arial">State</ASP:LABEL></TD>
								<TD><ASP:DROPDOWNLIST id="cmb_bln_state" runat="server" Width="200px" CssClass="formfield" BackColor="#C0C0FF"
										AutoPostBack="True"></ASP:DROPDOWNLIST></TD>
								<TD><ASP:LABEL id="Label10" runat="server" Width="84px" ForeColor="MidnightBlue" Font-Size="8pt"
										Font-Names="verdana,arial">Phone</ASP:LABEL></TD>
								<TD><ASP:TEXTBOX id="txt_bln_phone" runat="server" Width="130px" CssClass="formfield" MaxLength="20"
										Wrap="False"></ASP:TEXTBOX></TD>
							</TR>
							<TR>
								<TD><ASP:LABEL id="Label6" runat="server" Width="90px" ForeColor="MidnightBlue" Font-Size="8pt"
										Font-Names="verdana,arial">Country</ASP:LABEL></TD>
								<TD><ASP:DROPDOWNLIST id="cmb_bln_country" runat="server" Width="200px" CssClass="formfield" BackColor="#C0C0FF"
										AutoPostBack="True"></ASP:DROPDOWNLIST></TD>
								<TD></TD>
								<TD></TD>
							</TR>
						</TABLE>
						<TABLE id="tbl_adr_shipping" style="BORDER-BOTTOM: 2px groove; BORDER-LEFT: 2px groove; BORDER-TOP: 2px groove; BORDER-RIGHT: 2px groove"
							cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD colSpan="4"><ASP:LABEL id="Label14" runat="server" Width="140px" ForeColor="MidnightBlue" Font-Size="10pt"
										Font-Names="verdana,arial" Font-Bold="True" BackColor="Linen" BorderWidth="1px" BorderStyle="Outset">Shipping Address</ASP:LABEL></TD>
							</TR>
							<TR>
								<TD><ASP:LABEL id="Label7" runat="server" Width="90px" ForeColor="MidnightBlue" Font-Size="8pt"
										Font-Names="verdana,arial">Name</ASP:LABEL></TD>
								<TD colSpan="3"><ASP:TEXTBOX id="txt_shp_name" runat="server" Width="325px" ForeColor="MidnightBlue" Font-Size="8pt"
										Font-Names="verdana,arial" CssClass="formfield" MaxLength="100"></ASP:TEXTBOX><asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" ErrorMessage="&amp;times;" ControlToValidate="txt_shp_name"></asp:RequiredFieldValidator></TD>
							</TR>
							<TR>
								<TD><ASP:LABEL id="Label8" runat="server" Width="90px" ForeColor="MidnightBlue" Font-Size="8pt"
										Font-Names="verdana,arial">Street</ASP:LABEL></TD>
								<TD colSpan="3"><ASP:TEXTBOX id="txt_shp_street" runat="server" Width="325px" ForeColor="MidnightBlue" Font-Size="8pt"
										Font-Names="verdana,arial" CssClass="formfield" MaxLength="100"></ASP:TEXTBOX><asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server" ErrorMessage="&amp;times;" ControlToValidate="txt_shp_street"></asp:RequiredFieldValidator></TD>
							</TR>
							<TR>
								<TD><ASP:LABEL id="Label9" runat="server" Width="90px" ForeColor="MidnightBlue" Font-Size="8pt"
										Font-Names="verdana,arial">City</ASP:LABEL></TD>
								<TD><ASP:TEXTBOX id="txt_shp_city" runat="server" Width="150px" ForeColor="MidnightBlue" Font-Size="8pt"
										Font-Names="verdana,arial" CssClass="formfield" MaxLength="40"></ASP:TEXTBOX><asp:RequiredFieldValidator id="RequiredFieldValidator7" runat="server" ErrorMessage="&amp;times;" ControlToValidate="txt_shp_city"></asp:RequiredFieldValidator></TD>
								<TD><ASP:LABEL id="Label11" runat="server" Width="90px" ForeColor="MidnightBlue" Font-Size="8pt"
										Font-Names="verdana,arial">Zip</ASP:LABEL></TD>
								<TD><ASP:TEXTBOX id="txt_shp_zip" runat="server" Width="100px" ForeColor="MidnightBlue" Font-Size="8pt"
										Font-Names="verdana,arial" CssClass="formfield" MaxLength="8"></ASP:TEXTBOX><asp:RequiredFieldValidator id="RequiredFieldValidator8" runat="server" ErrorMessage="&amp;times;" ControlToValidate="txt_shp_zip"></asp:RequiredFieldValidator></TD>
							</TR>
							<TR>
								<TD><ASP:LABEL id="Label12" runat="server" Width="90px" ForeColor="MidnightBlue" Font-Size="8pt"
										Font-Names="verdana,arial">State</ASP:LABEL></TD>
								<TD><ASP:DROPDOWNLIST id="cmb_shp_state" runat="server" Width="200px" CssClass="formfield" BackColor="#C0C0FF"
										AutoPostBack="True"></ASP:DROPDOWNLIST></TD>
								<TD><ASP:LABEL id="Label13" runat="server" Width="84px" ForeColor="MidnightBlue" Font-Size="8pt"
										Font-Names="verdana,arial">Phone</ASP:LABEL></TD>
								<TD><ASP:TEXTBOX id="txt_shp_phone" runat="server" Width="130px" CssClass="formfield" MaxLength="20"
										Wrap="False"></ASP:TEXTBOX><asp:RequiredFieldValidator id="RequiredFieldValidator9" runat="server" ErrorMessage="&amp;times;" ControlToValidate="txt_shp_phone"></asp:RequiredFieldValidator></TD>
							</TR>
							<TR>
								<TD><ASP:LABEL id="Label16" runat="server" Width="90px" ForeColor="MidnightBlue" Font-Size="8pt"
										Font-Names="verdana,arial">Country</ASP:LABEL></TD>
								<TD><ASP:DROPDOWNLIST id="cmb_shp_country" runat="server" Width="200px" CssClass="formfield" BackColor="#C0C0FF"
										AutoPostBack="True"></ASP:DROPDOWNLIST><BR>
								</TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>
									<ASP:LABEL style="Z-INDEX: 0" id="LABEL28" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
										Width="90px" runat="server">include receipt</ASP:LABEL></TD>
								<TD>
									<asp:CheckBox style="Z-INDEX: 0" id="chk_include_receipt" runat="server"></asp:CheckBox></TD>
								<TD></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<TR id="shipping charges">
		<TD>
			<TABLE id="tbl_shippingcost" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD vAlign="top" align="left">
						<TABLE id="tbl_shipping_method" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD><ASP:LABEL id="Label1" runat="server" Width="140px" ForeColor="MidnightBlue" Font-Size="10pt"
										Font-Names="verdana,arial" Font-Bold="True" BackColor="Linen" BorderWidth="1px" BorderStyle="Outset">Shipping method</ASP:LABEL></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="left" height="85"><ASP:RADIOBUTTONLIST id="rdo_shipping" runat="server" Width="300px" ForeColor="MidnightBlue" Font-Size="8pt"
										Font-Names="verdana,arial" CellSpacing="0" CellPadding="0" BACKCOLOR="#C0C0FF" BORDERSTYLE="Groove" BORDERWIDTH="2px" AUTOPOSTBACK="True">
										<asp:ListItem Value="1" Selected="True">Registered mail</asp:ListItem>
										<asp:ListItem Value="2">EMS</asp:ListItem>
										<asp:ListItem Value="3">Diamond Courier</asp:ListItem>
										<asp:ListItem Value="4">FedEx</asp:ListItem>
									</ASP:RADIOBUTTONLIST></TD>
							</TR>
						</TABLE>
					</TD>
					<TD vAlign="top" align="left">
						<TABLE id="tbl_wrapping_method" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD><ASP:LABEL id="Label18" runat="server" Width="140px" ForeColor="MidnightBlue" Font-Size="10pt"
										Font-Names="verdana,arial" Font-Bold="True" BackColor="Linen" BorderWidth="1px" BorderStyle="Outset">Package wrapping</ASP:LABEL></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="left" height="85"><ASP:RADIOBUTTONLIST id="rdo_wrapping" runat="server" Width="300px" ForeColor="MidnightBlue" Font-Size="8pt"
										Font-Names="verdana,arial" CellSpacing="0" CellPadding="0" BACKCOLOR="#C0C0FF" BORDERSTYLE="Groove" BORDERWIDTH="2px" AUTOPOSTBACK="True">
										<ASP:LISTITEM Value="1" Selected="True">Regular packaging - &lt;b&gt; 0.00 $us &lt;/n&gt;</ASP:LISTITEM>
										<ASP:LISTITEM Value="2">Fancy packaging  - </ASP:LISTITEM>
									</ASP:RADIOBUTTONLIST></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<TR id="totals">
		<TD><uc1:wc_order_totals id="Wc_order_totals1" runat="server"></uc1:wc_order_totals></TD>
	</TR>
	<TR id="payment method">
		<TD><ASP:LABEL id="LABEL20" runat="server" Width="140px" ForeColor="MidnightBlue" Font-Size="10pt"
				Font-Names="verdana,arial" Font-Bold="True" BackColor="Linen" BorderWidth="1px" BorderStyle="Outset">Lay-a-way plan</ASP:LABEL>
			<table id="tbl_layawayplan" style="BORDER-BOTTOM: 2px groove; BORDER-LEFT: 2px groove; BORDER-TOP: 2px groove; BORDER-RIGHT: 2px groove"
				cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td><ASP:LABEL id="LABEL21" runat="server" Width="107px" ForeColor="MidnightBlue" Font-Size="8pt"
							Font-Names="verdana,arial">Interest start date</ASP:LABEL></td>
					<TD><ASP:TEXTBOX id="txt_interest_start_date" runat="server" Width="90px" ForeColor="MidnightBlue"
							Font-Size="8pt" Font-Names="verdana,arial" CssClass="formfield" MaxLength="10"></ASP:TEXTBOX></TD>
					<TD><ASP:LABEL id="LABEL22" runat="server" Width="119px" ForeColor="MidnightBlue" Font-Size="8pt"
							Font-Names="verdana,arial">Interest percentage</ASP:LABEL></TD>
					<TD><ASP:TEXTBOX id="txt_interest_percent" runat="server" Width="100px" ForeColor="MidnightBlue"
							Font-Size="8pt" Font-Names="verdana,arial" CssClass="formfield" MaxLength="8"></ASP:TEXTBOX><ASP:LABEL id="LABEL23" runat="server" Width="20px" ForeColor="MidnightBlue" Font-Size="8pt"
							Font-Names="verdana,arial">%</ASP:LABEL></TD>
				</tr>
			</table>
		</TD>
	</TR>
	<TR>
		<TD></TD>
	</TR>
	<TR id="customer_notes">
		<TD align="left"><ASP:LABEL id="LABEL19" runat="server" Width="140px" ForeColor="MidnightBlue" Font-Size="10pt"
				Font-Names="verdana,arial" Font-Bold="True" BackColor="Linen" BorderWidth="1px" BorderStyle="Outset">Customer notes</ASP:LABEL><ASP:TEXTBOX id="txt_customer_notes" runat="server" Width="615px" CssClass="formfield" MaxLength="1000"
				BACKCOLOR="#E0E0E0" TextMode="MultiLine" Height="65px" ToolTip="Enter here your comments" ENABLED="False"></ASP:TEXTBOX></TD>
	</TR>
	<TR id="merchant_notes">
		<TD align="left"><ASP:LABEL id="Label4" runat="server" Width="140px" ForeColor="MidnightBlue" Font-Size="10pt"
				Font-Names="verdana,arial" Font-Bold="True" BackColor="Linen" BorderWidth="1px" BorderStyle="Outset">Merchant notes</ASP:LABEL><ASP:TEXTBOX id="txt_merchant_notes" runat="server" Width="615px" CssClass="formfield" MaxLength="1000"
				TextMode="MultiLine" Height="65px" ToolTip="Enter here your comments"></ASP:TEXTBOX></TD>
	</TR>
	<TR>
		<TD vAlign="bottom" align="left">
			<ASP:LABEL style="Z-INDEX: 0" id="LABEL27" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
				Width="158px" runat="server" BackColor="Linen" BorderStyle="Outset" BorderWidth="1px">How did you hear about us</ASP:LABEL>
			<TABLE id="tbl_lastuser" style="BORDER-BOTTOM: 2px ridge; BORDER-LEFT: 2px ridge; BORDER-TOP: 2px ridge; BORDER-RIGHT: 2px ridge"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD>
						<asp:textbox style="Z-INDEX: 0" id="txt_heartwin" Font-Names="verdana,arial" Font-Size="8pt"
							ForeColor="MidnightBlue" Width="504px" runat="server" BackColor="#E0E0E0" CssClass="formfield"
							MaxLength="120" Enabled="False"></asp:textbox></TD>
				</TR>
				<TR>
					<TD>
						<ASP:LABEL id="LABEL24" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
							Width="158px" runat="server" BackColor="Linen" BorderStyle="Outset" BorderWidth="1px">User IP and referrer</ASP:LABEL></TD>
				</TR>
				<TR>
					<TD>
						<asp:textbox id="txt_user_ip" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
							Width="97px" runat="server" BackColor="#E0E0E0" CssClass="formfield" MaxLength="120" Enabled="False"></asp:textbox>
						<asp:textbox id="txt_user_referrer" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
							Width="504px" runat="server" BackColor="#E0E0E0" CssClass="formfield" MaxLength="120" Enabled="False"></asp:textbox></TD>
				</TR>
				<TR>
					<TD>
						<ASP:LABEL id="LABEL26" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
							Width="224px" runat="server" BackColor="Linen" BorderStyle="Outset" BorderWidth="1px">Last user to change this order</ASP:LABEL></TD>
				</TR>
				<TR>
					<TD>
						<asp:textbox id="txt_lastuser_id" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
							Width="48px" runat="server" BackColor="#E0E0E0" CssClass="formfield" MaxLength="120" Enabled="False"></asp:textbox>
						<asp:textbox id="txt_lastuser_name" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
							Width="373px" runat="server" BackColor="#E0E0E0" CssClass="formfield" MaxLength="120" Enabled="False"></asp:textbox>
						<asp:textbox id="txt_lastuser_date" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
							Width="175px" runat="server" BackColor="#E0E0E0" CssClass="formfield" MaxLength="120" Enabled="False"></asp:textbox></TD>
				</TR>
			</TABLE>
			<asp:CheckBox id="chk_ebay" Font-Bold="True" runat="server" BackColor="#C0C0FF" CssClass="formfield"
				AutoPostBack="True" Text="Ebay Item"></asp:CheckBox>
		</TD>
	</TR>
	<TR id="submit">
		<TD vAlign="bottom" align="right" height="30"><INPUT class="formbutton" id="btn_back" style="WIDTH: 90px; HEIGHT: 18px" onclick="history.back()"
				type="button" value="Back" name="btn_back"> <input type="button" name="Button" value="Print Order" Class="formbutton" onclick="PrintOrder()">
			<ASP:BUTTON id="btn_save" runat="server" CssClass="formbutton" Text="Save Order"></ASP:BUTTON></TD>
	</TR>
</TABLE>
</TD></TR></TBODY></TABLE>
