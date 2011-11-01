<%@ Page Language="vb" AutoEventWireup="false" Codebehind="addorder.aspx.vb" Inherits="ion_admin.addorder"%>
<%@ Register TagPrefix="uc1" TagName="wc_order_reconsile" Src="wc_order_reconsile.ascx" %>
<%@ Register TagPrefix="uc1" TagName="wc_cart_content" Src="wc_cart_content.ascx" %>
<%@ Register TagPrefix="uc1" TagName="wc_order_totals" Src="wc_order_totals.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>addorder</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/default.css" type="text/css" rel="stylesheet">
		<LINK href="/Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table width="70%" border="0" cellspacing="0" cellpadding="3" style="BORDER-RIGHT: 2px groove; BORDER-TOP: 2px groove; BORDER-LEFT: 2px groove; BORDER-BOTTOM: 2px groove; BACKGROUND-COLOR: gainsboro">
				<tr>
					<td><table width="100%" border="0" cellspacing="0" cellpadding="3">
							<tr>
								<td><table width="100%" border="0" cellspacing="0" cellpadding="3">
										<tr>
											<td><span style="WIDTH: 275px">
													<asp:Label ID="LABEL21" runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
														Width="90px">Item number</asp:Label>
													<asp:TextBox ID="t_itemid" runat="server" AutoPostBack="True" CssClass="formfield"></asp:TextBox>
												</span>
											</td>
										</tr>
										<tr>
											<td><span style="WIDTH: 168px; HEIGHT: 20px">
													<asp:CheckBox ID="CheckBox1" runat="server" Text="Ebay Item" Font-Size="Larger"></asp:CheckBox>
												</span>&nbsp;
												<asp:TextBox id="txt_ebaynumber" runat="server" CssClass="formfield"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td><span style="WIDTH: 275px">
													<asp:Label ID="LABEL22" runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
														Width="90px">Price</asp:Label>
													<asp:TextBox ID="t_price" runat="server" CssClass="formfield"></asp:TextBox>
												</span>
											</td>
										</tr>
										<tr>
											<td><asp:Label ID="Label23" runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
													Width="104px">Date ( D/M/Y )</asp:Label>
												<asp:TextBox ID="txt_day" runat="server" Width="24px" CssClass="formfield"></asp:TextBox>
												&nbsp;
												<asp:TextBox ID="txt_month" runat="server" Width="32px" CssClass="formfield"></asp:TextBox>
												&nbsp;
												<asp:TextBox ID="txt_year" runat="server" Width="48px" CssClass="formfield"></asp:TextBox></td>
										</tr>
										<tr>
											<td><span style="WIDTH: 275px">
													<br>
													<asp:Button ID="btn_start" runat="server" Text="Start Order"></asp:Button>
												</span>
											</td>
										</tr>
									</table>
								</td>
								<td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="3">
										<tr>
											<td><asp:Image ID="img_icon" runat="server"></asp:Image></td>
										</tr>
										<tr>
											<td><asp:HyperLink ID="hyp_item" runat="server">View
                        Item on site</asp:HyperLink></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
				</tr>
			</table>
			<asp:Panel runat="server" id="OrderForm" Visible="false">
<TABLE style="BORDER-RIGHT: 2px groove; BORDER-TOP: 2px groove; BORDER-LEFT: 2px groove; BORDER-BOTTOM: 2px groove; BACKGROUND-COLOR: gainsboro"
					cellSpacing="0" cellPadding="0" width="70%" border="0">
					<TR>
						<TD colSpan="2"><BR>
							<BR>
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 275px">
							<ASP:LABEL id="LABEL17" runat="server" Width="90px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial">Email</ASP:LABEL></TD>
						<TD>
							<asp:textbox id="txt_email" runat="server" Width="303px" CssClass="formfield" AutoPostBack="True"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 275px">
							<ASP:LABEL id="Label15" runat="server" Width="90px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial">Name</ASP:LABEL></TD>
						<TD colSpan="3">
							<ASP:TEXTBOX id="txt_bln_firstname" runat="server" Width="168px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial" CssClass="formfield" MaxLength="100"></ASP:TEXTBOX>&nbsp;
							<ASP:LABEL id="LABEL20" runat="server" Width="90px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial">Last name</ASP:LABEL>
							<ASP:TEXTBOX id="txt_bln_lastname" runat="server" Width="168px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial" CssClass="formfield" MaxLength="100"></ASP:TEXTBOX></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 275px">
							<ASP:LABEL id="Label2" runat="server" Width="90px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial">Street</ASP:LABEL></TD>
						<TD colSpan="3">
							<ASP:TEXTBOX id="txt_bln_street" runat="server" Width="325px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial" CssClass="formfield" MaxLength="100"></ASP:TEXTBOX></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 275px">
							<ASP:LABEL id="Label3" runat="server" Width="90px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial">City</ASP:LABEL></TD>
						<TD>
							<ASP:TEXTBOX id="txt_bln_city" runat="server" Width="150px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial" CssClass="formfield" MaxLength="40"></ASP:TEXTBOX></TD>
						<TD>
							<ASP:LABEL id="Label25" runat="server" Width="90px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial">Zip</ASP:LABEL></TD>
						<TD>
							<ASP:TEXTBOX id="txt_bln_zip" runat="server" Width="100px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial" CssClass="formfield" MaxLength="8"></ASP:TEXTBOX></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 275px">
							<ASP:LABEL id="Label5" runat="server" Width="90px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial">State</ASP:LABEL></TD>
						<TD>
							<ASP:DROPDOWNLIST id="cmb_bln_state" runat="server" Width="200px" CssClass="formfield" AutoPostBack="True"
								BackColor="#C0C0FF"></ASP:DROPDOWNLIST></TD>
						<TD>
							<ASP:LABEL id="Label10" runat="server" Width="84px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial">Phone</ASP:LABEL></TD>
						<TD>
							<ASP:TEXTBOX id="txt_bln_phone" runat="server" Width="130px" CssClass="formfield" MaxLength="20"
								Wrap="False"></ASP:TEXTBOX></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 275px">
							<ASP:LABEL id="Label6" runat="server" Width="90px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial">Country</ASP:LABEL></TD>
						<TD>
							<ASP:DROPDOWNLIST id="cmb_bln_country" runat="server" Width="200px" CssClass="formfield" AutoPostBack="True"
								BackColor="#C0C0FF"></ASP:DROPDOWNLIST></TD>
						<TD></TD>
						<TD></TD>
					</TR>
				</TABLE>
<TABLE id="tbl_adr_shipping" style="BORDER-RIGHT: 2px groove; BORDER-TOP: 2px groove; BORDER-LEFT: 2px groove; BORDER-BOTTOM: 2px groove; BACKGROUND-COLOR: gainsboro"
					cellSpacing="1" cellPadding="1" width="70%" border="0">
					<TR>
						<TD colSpan="4">
							<ASP:LABEL id="Label14" runat="server" Width="140px" ForeColor="MidnightBlue" Font-Size="10pt"
								Font-Names="verdana,arial" BackColor="Linen" BorderWidth="1px" BorderStyle="Outset" Font-Bold="True">Shipping Address</ASP:LABEL>
							<asp:CheckBox id="CheckBox2" runat="server" AutoPostBack="True" Text="Same As Billing Address"></asp:CheckBox></TD>
					</TR>
					<TR>
						<TD>
							<ASP:LABEL id="Label7" runat="server" Width="90px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial">Name</ASP:LABEL></TD>
						<TD colSpan="3">
							<ASP:TEXTBOX id="txt_shp_name" runat="server" Width="160px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial" CssClass="formfield" MaxLength="100"></ASP:TEXTBOX>
							<ASP:LABEL id="LABEL24" runat="server" Width="90px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial">Last name</ASP:LABEL>
							<ASP:TEXTBOX id="txt_shp_lastname" runat="server" Width="168px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial" CssClass="formfield" MaxLength="100"></ASP:TEXTBOX></TD>
					</TR>
					<TR>
						<TD>
							<ASP:LABEL id="Label8" runat="server" Width="90px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial">Street</ASP:LABEL></TD>
						<TD colSpan="3">
							<ASP:TEXTBOX id="txt_shp_street" runat="server" Width="325px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial" CssClass="formfield" MaxLength="100"></ASP:TEXTBOX></TD>
					</TR>
					<TR>
						<TD>
							<ASP:LABEL id="Label9" runat="server" Width="90px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial">City</ASP:LABEL></TD>
						<TD>
							<ASP:TEXTBOX id="txt_shp_city" runat="server" Width="150px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial" CssClass="formfield" MaxLength="40"></ASP:TEXTBOX></TD>
						<TD>
							<ASP:LABEL id="Label11" runat="server" Width="90px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial">Zip</ASP:LABEL></TD>
						<TD>
							<ASP:TEXTBOX id="txt_shp_zip" runat="server" Width="100px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial" CssClass="formfield" MaxLength="8"></ASP:TEXTBOX></TD>
					</TR>
					<TR>
						<TD>
							<ASP:LABEL id="Label12" runat="server" Width="90px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial">State</ASP:LABEL></TD>
						<TD>
							<ASP:DROPDOWNLIST id="cmb_shp_state" runat="server" Width="200px" CssClass="formfield" AutoPostBack="True"
								BackColor="#C0C0FF"></ASP:DROPDOWNLIST></TD>
						<TD>
							<ASP:LABEL id="Label13" runat="server" Width="84px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial">Phone</ASP:LABEL></TD>
						<TD>
							<ASP:TEXTBOX id="txt_shp_phone" runat="server" Width="130px" CssClass="formfield" MaxLength="20"
								Wrap="False"></ASP:TEXTBOX></TD>
					</TR>
					<TR>
						<TD>
							<ASP:LABEL id="Label16" runat="server" Width="90px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial">Country</ASP:LABEL></TD>
						<TD>
							<ASP:DROPDOWNLIST id="cmb_shp_country" runat="server" Width="200px" CssClass="formfield" AutoPostBack="True"
								BackColor="#C0C0FF"></ASP:DROPDOWNLIST></TD>
						<TD></TD>
						<TD></TD>
					</TR>
				</TABLE></TD></TR></TBODY></TABLE></TD></TR><TR id="shipping charges">
					<TD>
						<TABLE id="tbl_shippingcost" style="BORDER-RIGHT: 2px groove; BORDER-TOP: 2px groove; BORDER-LEFT: 2px groove; BORDER-BOTTOM: 2px groove; BACKGROUND-COLOR: gainsboro"
							cellSpacing="0" cellPadding="0" width="70%" border="0">
							<TR>
								<TD vAlign="top" align="left">
									<TABLE id="tbl_shipping_method" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD>
												<ASP:LABEL id="Label1" runat="server" Width="140px" ForeColor="MidnightBlue" Font-Size="10pt"
													Font-Names="verdana,arial" BackColor="Linen" BorderWidth="1px" BorderStyle="Outset" Font-Bold="True">Shipping method</ASP:LABEL></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="left" height="85">
												<ASP:RADIOBUTTONLIST id="rdo_shipping" runat="server" Width="300px" ForeColor="MidnightBlue" Font-Size="8pt"
													Font-Names="verdana,arial" CellSpacing="0" CellPadding="0" BACKCOLOR="#C0C0FF" BORDERSTYLE="Groove"
													BORDERWIDTH="2px" AUTOPOSTBACK="True" Height="104px">
													<asp:ListItem Value="0" Selected="True">Registered mail</asp:ListItem>
													<asp:ListItem Value="39.90">EMS</asp:ListItem>
													<asp:ListItem Value="179">Diamond Courier</asp:ListItem>
													<asp:ListItem Value="49">FedEx</asp:ListItem>
												</ASP:RADIOBUTTONLIST></TD>
										</TR>
									</TABLE>
								</TD>
								<TD vAlign="top" align="left">
									<TABLE id="tbl_wrapping_method" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD>
												<ASP:LABEL id="Label18" runat="server" Width="140px" ForeColor="MidnightBlue" Font-Size="10pt"
													Font-Names="verdana,arial" BackColor="Linen" BorderWidth="1px" BorderStyle="Outset" Font-Bold="True">Package wrapping</ASP:LABEL></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="left" height="85">
												<ASP:RADIOBUTTONLIST id="rdo_wrapping" runat="server" Width="300px" ForeColor="MidnightBlue" Font-Size="8pt"
													Font-Names="verdana,arial" CellSpacing="0" CellPadding="0" BACKCOLOR="#C0C0FF" BORDERSTYLE="Groove"
													BORDERWIDTH="2px" AUTOPOSTBACK="True">
													<asp:ListItem Value="0" Selected="True">Regular packaging - &lt;b&gt; 0.00 $us &lt;/n&gt;</asp:ListItem>
													<asp:ListItem Value="6.5">Fancy packaging  - </asp:ListItem>
												</ASP:RADIOBUTTONLIST></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
						<TABLE style="BORDER-RIGHT: 2px groove; BORDER-TOP: 2px groove; BORDER-LEFT: 2px groove; BORDER-BOTTOM: 2px groove; BACKGROUND-COLOR: gainsboro"
							cellSpacing="0" cellPadding="3" width="70%" border="0">
							<TR>
								<TD></TD>
							</TR>
							<TR id="customer_notes">
								<TD align="left">
									<ASP:LABEL id="LABEL19" runat="server" Width="140px" ForeColor="MidnightBlue" Font-Size="10pt"
										Font-Names="verdana,arial" BackColor="Linen" BorderWidth="1px" BorderStyle="Outset" Font-Bold="True">Customer notes</ASP:LABEL>
									<ASP:TEXTBOX id="txt_customer_notes" runat="server" Width="615px" CssClass="formfield" Visible="true"
										MaxLength="1000" BACKCOLOR="#E0E0E0" Height="65px" TextMode="MultiLine" ToolTip="Enter here your comments"></ASP:TEXTBOX><BR>
								</TD>
							</TR>
							<TR id="merchant_notes">
								<TD align="left">&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
				</TR><TR>
					<TD align="right" vAlign="bottom">
						<TABLE id="tbl_lastuser" style="BORDER-RIGHT: 2px groove; BORDER-TOP: 2px groove; BORDER-LEFT: 2px groove; BORDER-BOTTOM: 2px groove; BACKGROUND-COLOR: gainsboro"
							cellSpacing="1" cellPadding="1" width="70%" border="0">
							<TR>
								<TD><BR>
									<BR>
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="594" border="0">
										<TR>
											<TD class="inside_titles" width="132">Payment method
											</TD>
											<TD width="462">&nbsp;</TD>
										</TR>
										<TR>
											<TD class="inside_titles" vAlign="top">&nbsp;
												<asp:dropdownlist id="pay_mathod" runat="server" CssClass="input_select">
													<asp:ListItem value="1">Credit
							          Card</asp:ListItem>
													<asp:ListItem value="2">Bank
							          Transfer</asp:ListItem>
													<asp:ListItem value="3">Cashier's
							          Check</asp:ListItem>
													<asp:ListItem value="4">PayPal</asp:ListItem>
												</asp:dropdownlist></TD>
											<TD>
												<TABLE id="p_cradit_card_table" style="DISPLAY: inline" cellSpacing="0" cellPadding="0"
													width="100%" border="0">
													<TR>
														<TD class="p_mathod" align="right" width="29%">Credit cart
														</TD>
														<TD width="71%">&nbsp;
															<asp:dropdownlist id="cc_type" runat="server" CssClass="input_select"></asp:dropdownlist></TD>
													</TR>
													<TR>
														<TD class="p_mathod" align="right">Credit cart number
														</TD>
														<TD>&nbsp;
															<asp:textbox id="cc_number" runat="server" CssClass="input_select"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="p_mathod" align="right">Expiration date
														</TD>
														<TD>&nbsp;
															<asp:dropdownlist id="cc_exp_m" runat="server" Width="40px" CssClass="input_select">
																<asp:ListItem Value="0" Selected="True">-</asp:ListItem>
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
															</asp:dropdownlist>
															<asp:dropdownlist id="cc_exp_y" runat="server" Width="55px" CssClass="input_select">
																<asp:ListItem Value="0">-</asp:ListItem>
																<asp:ListItem Value="07">2007</asp:ListItem>
																<asp:ListItem Value="08">2008</asp:ListItem>
																<asp:ListItem Value="09">2009</asp:ListItem>
																<asp:ListItem Value="10">2010</asp:ListItem>
																<asp:ListItem Value="11">2011</asp:ListItem>
																<asp:ListItem Value="12">2012</asp:ListItem>
																<asp:ListItem Value="13">2013</asp:ListItem>
															</asp:dropdownlist><SPAN class="inside_titles">( MM/YY)</SPAN></TD>
													</TR>
													<TR>
														<TD class="p_mathod" align="right">CVV</TD>
														<TD>&nbsp;
															<asp:textbox id="cc_cvv" runat="server" CssClass="input_select"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="p_mathod" align="right">Name on cart
														</TD>
														<TD>&nbsp;
															<asp:textbox id="cc_name" runat="server" CssClass="input_select"></asp:textbox></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
									<BR>
								</TD>
							</TR>
							<TR>
								<TD>
									<asp:button id="Button1" runat="server" Text="Save Order"></asp:button></TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
					<TD>&nbsp;</TD>
				</TR><TR>
					<TD>&nbsp;</TD>
					<TD>&nbsp;</TD>
				</TR><TR>
					<TD>&nbsp;</TD>
					<TD>&nbsp;</TD>
				</TR><TR>
					<TD>&nbsp;</TD>
					<TD>&nbsp;</TD>
				</TR><TR>
					<TD>&nbsp;</TD>
					<TD>&nbsp;</TD>
				</TR><TR>
					<TD>&nbsp;</TD>
					<TD>&nbsp;</TD>
				</TR><TR>
					<TD>&nbsp;</TD>
					<TD>&nbsp;</TD>
				</TR><TR>
					<TD>&nbsp;</TD>
					<TD>&nbsp;</TD>
				</TR><TR>
					<TD>&nbsp;</TD>
					<TD>&nbsp;</TD>
				</TR><TR>
					<TD>&nbsp;</TD>
					<TD>&nbsp;</TD>
				</TR><TR>
					<TD>&nbsp;</TD>
					<TD>&nbsp;</TD>
				</TR><TR>
					<TD>&nbsp;</TD>
					<TD>&nbsp;</TD>
				</TR><TR>
					<TD>&nbsp;</TD>
					<TD>&nbsp;</TD>
				</TR><TR>
					<TD>&nbsp;</TD>
					<TD>&nbsp;</TD>
				</TR><TR>
					<TD>&nbsp;</TD>
					<TD>&nbsp;</TD>
				</TR></TBODY></TABLE>
			</asp:Panel>
		</form>
	</body>
</HTML>
