<%@ Page Language="vb" AutoEventWireup="false" Codebehind="receive-payment.aspx.vb" Inherits="ion_admin.receive_payment"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>receive_payment</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/styles.css" type="text/css" rel="StyleSheet">
		<script language="javascript" src="..\script\norefresh.js"></script>
	</HEAD>
	<body onKeyDown="onKeyDown();" bottomMargin="2" bgColor="#a9a9a9" leftMargin="2" topMargin="2"
		rightMargin="2" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="tbl_main" cellSpacing="1" cellPadding="1" width="100%" bgColor="#d3d3d3" border="0">
				<TR>
					<TD bgColor="#708090"><asp:label id="lbl_caption" runat="server" Width="404px" ForeColor="Khaki" Font-Size="10pt"
							Font-Names="verdana,arial" Font-Bold="True">Receive payment order:</asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="tbl_YesNo" style="BORDER-RIGHT: 1px ridge; BORDER-TOP: 1px ridge; FONT-SIZE: 9pt; BORDER-LEFT: 1px ridge; WIDTH: 461px; COLOR: khaki; BORDER-BOTTOM: 1px ridge; FONT-FAMILY: verdana,arial; HEIGHT: 58px; BACKGROUND-COLOR: midnightblue"
							width="461" border="0" RUNAT="server">
							<TR>
								<TD>
									<ASP:LABEL id="LABEL22" runat="server" Font-Bold="True" Width="355px">Do you want to close the order (change status)?</ASP:LABEL></TD>
								<TD width="60">
									<ASP:BUTTON id="btn_YES" runat="server" Width="50px" CssClass="formbutton" Text="Yes"></ASP:BUTTON></TD>
							</TR>
							<TR>
								<TD align="center"></TD>
								<TD width="60">
									<ASP:BUTTON id="btn_NO" runat="server" Width="50px" CssClass="formbutton" Text="No"></ASP:BUTTON></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="left" height="30">
						<TABLE id="tbl_payment" cellSpacing="1" cellPadding="1" width="100%" border="0" style="BORDER-RIGHT: 2px groove; BORDER-TOP: 2px groove; BORDER-LEFT: 2px groove; BORDER-BOTTOM: 2px groove">
							<TR>
								<TD>
									<asp:label id="Label17" runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
										Width="127px">Payment</asp:label></TD>
								<TD align="right">
									<ASP:TEXTBOX id="txt_payment" runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
										Width="100px" CssClass="formfield" MaxLength="20"></ASP:TEXTBOX>
									<asp:label id="Label19" runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
										Width="36px">$usd</asp:label></TD>
								<TD align="right"><asp:label id="Label12" runat="server" Width="179px" ForeColor="Red" Font-Bold="True" FONT-NAMES="verdana,arial"
										FONT-SIZE="12pt">Payment received</asp:label><ASP:CHECKBOX id="chk_payment_received" runat="server" Width="34px" ForeColor="MidnightBlue" Font-Size="12pt"
										Font-Names="verdana,arial" Text=" "></ASP:CHECKBOX></TD>
							</TR>
							<TR>
								<TD>
									<asp:label id="Label13" runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
										Width="127px">- Transaction costs</asp:label></TD>
								<TD align="right">
									<ASP:TEXTBOX id="txt_amount_costs" runat="server" Font-Names="verdana,arial" Font-Size="8pt"
										ForeColor="MidnightBlue" Width="100px" CssClass="formfield" MaxLength="20" BackColor="#C0C0FF"
										AutoPostBack="True"></ASP:TEXTBOX>
									<asp:label id="Label15" runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
										Width="36px">$usd</asp:label></TD>
								<TD align="right">
									<ASP:TEXTBOX id="txt_approval_date" runat="server" Font-Names="verdana,arial" Font-Size="8pt"
										ForeColor="MidnightBlue" Width="131px" MaxLength="10" CssClass="formfield" BackColor="#E0E0E0"></ASP:TEXTBOX></TD>
							</TR>
							<TR>
								<TD>
									<asp:label id="Label14" runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
										Width="149px">= Actual amount received</asp:label></TD>
								<TD align="right">
									<ASP:TEXTBOX id="txt_amount_actual" runat="server" Font-Names="verdana,arial" Font-Size="8pt"
										ForeColor="MidnightBlue" Width="100px" CssClass="formfield" MaxLength="20" Enabled="False"></ASP:TEXTBOX>
									<asp:label id="Label16" runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
										Width="36px">$usd</asp:label></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD></TD>
								<TD></TD>
							</TR>
						</TABLE>
						&nbsp;
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="tbl_payments_CerditCard" style="BORDER-RIGHT: 2px groove; BORDER-TOP: 2px groove; FONT-SIZE: 8pt; BORDER-LEFT: 2px groove; COLOR: midnightblue; BORDER-BOTTOM: 2px groove; FONT-FAMILY: verdana,arial"
							cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server">
							<TR>
								<TD width="20" colSpan="4"><ASP:LABEL id="LABEL18" runat="server" Width="140px" ForeColor="MidnightBlue" Font-Size="9pt"
										Font-Names="verdana,arial" Font-Bold="True" BackColor="Linen" BorderStyle="Outset" BorderWidth="1px">Credit Card</ASP:LABEL></TD>
							</TR>
							<TR>
								<TD width="20"></TD>
								<TD width="100">
									<DIV class="CheckoutFont_link" MS_POSITIONING="FlowLayout">Card Type</DIV>
								</TD>
								<TD width="170"><asp:dropdownlist id="cmb_cc_cardtype" runat="server" Width="132px" AUTOPOSTBACK="True" CssClass="formfield"></asp:dropdownlist></TD>
								<TD width="170">
									<DIV class="CheckoutFont_link" id="div_club" MS_POSITIONING="FlowLayout" RUNAT="server">Authorization 
										code</DIV>
								</TD>
								<TD><ASP:TEXTBOX id="txt_cc_code" runat="server" Width="100px" ForeColor="MidnightBlue" Font-Size="8pt"
										Font-Names="verdana,arial" CssClass="formfield" MaxLength="20"></ASP:TEXTBOX></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD width="20"></TD>
								<TD width="100">
									<DIV class="CheckoutFont_link" MS_POSITIONING="FlowLayout">Expiration date</DIV>
								</TD>
								<TD width="170"><asp:dropdownlist id="cmb_cc_month" runat="server" Width="46px" CssClass="formfield">
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
									</asp:dropdownlist><asp:dropdownlist id="cmb_cc_year" runat="server" Width="81px" CssClass="formfield">
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
									</asp:dropdownlist></TD>
								<TD width="170">
									<DIV class="CheckoutFont_link" id="Div1" MS_POSITIONING="FlowLayout" RUNAT="server">Member 
										'Style' club</DIV>
									</U></TD>
								<TD><ASP:CHECKBOX id="chk_style_member" runat="server" ForeColor="MidnightBlue" Font-Size="8pt" Font-Names="verdana,arial"
										Text=" "></ASP:CHECKBOX></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD width="20"></TD>
								<TD width="100">
									<DIV class="CheckoutFont_link" MS_POSITIONING="FlowLayout">Card number</DIV>
								</TD>
								<TD width="170"><asp:textbox id="txt_cc_cardnumber" runat="server" Width="150px" ForeColor="MidnightBlue" Font-Size="8pt"
										Font-Names="verdana,arial" CssClass="formfield" MaxLength="40"></asp:textbox></TD>
								<TD width="170">
									<DIV class="CheckoutFont_link" MS_POSITIONING="FlowLayout">CVV number</DIV>
								</TD>
								<TD><asp:textbox id="txt_cc_cvv" runat="server" Width="40px" ForeColor="MidnightBlue" Font-Size="8pt"
										Font-Names="verdana,arial" CssClass="formfield" MaxLength="4"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD width="20"></TD>
								<TD width="100">
									<DIV class="CheckoutFont_link" MS_POSITIONING="FlowLayout">Name on card</DIV>
								</TD>
								<TD width="170"><ASP:TEXTBOX id="txt_cc_nameoncard" runat="server" Width="150px" ForeColor="MidnightBlue" Font-Size="8pt"
										Font-Names="verdana,arial" CssClass="formfield" MaxLength="40"></ASP:TEXTBOX></TD>
								<TD width="170">
									<DIV class="CheckoutFont_link" MS_POSITIONING="FlowLayout">Personal ID number</DIV>
								</TD>
								<TD><ASP:TEXTBOX id="txt_cc_person_id" runat="server" Width="100px" ForeColor="MidnightBlue" Font-Size="8pt"
										Font-Names="verdana,arial" CssClass="formfield" MaxLength="20"></ASP:TEXTBOX></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD width="20"></TD>
								<TD width="100"></TD>
								<TD width="170"></TD>
								<TD width="170"><asp:label id="Label11" runat="server" Width="80px" ForeColor="MidnightBlue" Font-Size="8pt"
										Font-Names="verdana,arial">Cleared</asp:label></TD>
								<TD><ASP:CHECKBOX id="chk_cc_cleared" runat="server" ForeColor="MidnightBlue" Font-Size="8pt" Font-Names="verdana,arial"
										Text=" "></ASP:CHECKBOX></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD width="20"></TD>
								<TD width="100"></TD>
								<TD width="170"></TD>
								<TD width="170">
									<asp:label id="Label20" runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
										Width="80px">Batch</asp:label></TD>
								<TD>
									<ASP:TEXTBOX id="txt_cc_batch" runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
										Width="100px" MaxLength="20" CssClass="formfield"></ASP:TEXTBOX></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="tbl_money_wire" style="BORDER-RIGHT: 2px groove; BORDER-TOP: 2px groove; BORDER-LEFT: 2px groove; BORDER-BOTTOM: 2px groove"
							cellSpacing="1" cellPadding="1" width="100%" border="0" runat="server">
							<TR>
								<TD><ASP:LABEL id="LABEL9" runat="server" Width="181px" ForeColor="MidnightBlue" Font-Size="9pt"
										Font-Names="verdana,arial" Font-Bold="True" BackColor="Linen" BorderStyle="Outset" BorderWidth="1px">Money transfer / Wire</ASP:LABEL>
									<TABLE id="tbl_moneytransfer" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="20"></TD>
											<TD width="140"><asp:label id="Label1" runat="server" Width="80px" ForeColor="MidnightBlue" FONT-NAMES="verdana,arial"
													FONT-SIZE="8pt">Bank name</asp:label></TD>
											<TD colSpan="3"><asp:textbox id="txt_mt_bank" runat="server" Width="300px" ForeColor="MidnightBlue" Font-Size="8pt"
													Font-Names="verdana,arial" CssClass="formfield" MaxLength="120"></asp:textbox></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD><asp:label id="Label2" runat="server" Width="127px" ForeColor="MidnightBlue" Font-Size="8pt"
													Font-Names="verdana,arial">Name on transaction</asp:label></TD>
											<TD colSpan="3"><asp:textbox id="txt_mt_name" runat="server" Width="300px" ForeColor="MidnightBlue" Font-Size="8pt"
													Font-Names="verdana,arial" CssClass="formfield" MaxLength="64"></asp:textbox></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD><asp:label id="Label3" runat="server" Width="80px" ForeColor="MidnightBlue" Font-Size="8pt"
													Font-Names="verdana,arial">Account</asp:label></TD>
											<TD><ASP:TEXTBOX id="txt_mt_account" runat="server" Width="150px" ForeColor="MidnightBlue" Font-Size="8pt"
													Font-Names="verdana,arial" CssClass="formfield" MaxLength="40"></ASP:TEXTBOX></TD>
											<TD><asp:label id="Label4" runat="server" Width="80px" ForeColor="MidnightBlue" Font-Size="8pt"
													Font-Names="verdana,arial">Transfer code</asp:label></TD>
											<TD><ASP:TEXTBOX id="txt_mt_code" runat="server" Width="100px" ForeColor="MidnightBlue" Font-Size="8pt"
													Font-Names="verdana,arial" CssClass="formfield" MaxLength="40"></ASP:TEXTBOX></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="tbl_check" style="BORDER-RIGHT: 2px groove; BORDER-TOP: 2px groove; BORDER-LEFT: 2px groove; BORDER-BOTTOM: 2px groove"
							cellSpacing="1" cellPadding="1" width="100%" border="0" runat="server">
							<TR>
								<TD><ASP:LABEL id="LABEL10" runat="server" Width="140px" ForeColor="MidnightBlue" Font-Size="9pt"
										Font-Names="verdana,arial" Font-Bold="True" BackColor="Linen" BorderStyle="Outset" BorderWidth="1px">Cashiers's check</ASP:LABEL>
									<TABLE id="tbl_cashierscheck" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="20"></TD>
											<TD width="140"><asp:label id="Label5" runat="server" Width="80px" ForeColor="MidnightBlue" Font-Size="8pt"
													Font-Names="verdana,arial">Bank name</asp:label></TD>
											<TD colSpan="3"><asp:textbox id="txt_cq_bank" runat="server" Width="300px" ForeColor="MidnightBlue" Font-Size="8pt"
													Font-Names="verdana,arial" CssClass="formfield" MaxLength="120"></asp:textbox></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD><asp:label id="Label6" runat="server" Width="96px" ForeColor="MidnightBlue" Font-Size="8pt"
													Font-Names="verdana,arial">Name on check</asp:label></TD>
											<TD colSpan="3"><asp:textbox id="txt_cq_name" runat="server" Width="300px" ForeColor="MidnightBlue" Font-Size="8pt"
													Font-Names="verdana,arial" CssClass="formfield" MaxLength="120"></asp:textbox></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD><asp:label id="Label7" runat="server" Width="80px" ForeColor="MidnightBlue" Font-Size="8pt"
													Font-Names="verdana,arial">Account</asp:label></TD>
											<TD><ASP:TEXTBOX id="txt_cq_account" runat="server" Width="150px" ForeColor="MidnightBlue" Font-Size="8pt"
													Font-Names="verdana,arial" CssClass="formfield" MaxLength="40"></ASP:TEXTBOX></TD>
											<TD><asp:label id="Label8" runat="server" Width="80px" ForeColor="MidnightBlue" Font-Size="8pt"
													Font-Names="verdana,arial">Date check</asp:label></TD>
											<TD>
												<ASP:TEXTBOX id="txt_cq_date" runat="server" Width="90px" ForeColor="MidnightBlue" Font-Size="8pt"
													Font-Names="verdana,arial" CssClass="formfield" MaxLength="10"></ASP:TEXTBOX>
												<asp:rangevalidator id="RangeValidator1" runat="server" ErrorMessage="&amp;times" ControlToValidate="txt_cq_date"
													MinimumValue="1/1/1900" MaximumValue="1/1/2050" Type="Date"></asp:rangevalidator></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
						<ASP:LABEL id="LABEL21" runat="server" Font-Bold="True" Font-Names="verdana,arial" Font-Size="10pt"
							ForeColor="MidnightBlue" Width="140px" BorderWidth="1px" BorderStyle="Outset" BackColor="Linen">Merchant notes</ASP:LABEL>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:textbox id="txt_notes" runat="server" Width="100%" CssClass="formfield" FONT-SIZE="10pt"
							TextMode="MultiLine" Height="60px" Rows="5"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="left">
						<TABLE id="tbl_lastuser" cellSpacing="1" cellPadding="1" width="100%" border="0" style="BORDER-RIGHT: 2px ridge; BORDER-TOP: 2px ridge; BORDER-LEFT: 2px ridge; BORDER-BOTTOM: 2px ridge">
							<TR>
								<TD>
									<asp:textbox id="txt_lastuser_id" runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
										Width="48px" Enabled="False" MaxLength="120" CssClass="formfield" BackColor="#E0E0E0"></asp:textbox>
									<asp:textbox id="txt_lastuser_name" runat="server" Font-Names="verdana,arial" Font-Size="8pt"
										ForeColor="MidnightBlue" Width="338px" Enabled="False" MaxLength="120" CssClass="formfield"
										BackColor="#E0E0E0"></asp:textbox>
									<asp:textbox id="txt_lastuser_date" runat="server" Font-Names="verdana,arial" Font-Size="8pt"
										ForeColor="MidnightBlue" Width="153px" Enabled="False" MaxLength="120" CssClass="formfield"
										BackColor="#E0E0E0"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="right">
						<INPUT class="formbutton" id="btn_close" style="WIDTH: 100px" onclick="window.close()"
							type="button" size="1" value="Close" name="btn_close">
						<ASP:BUTTON id="btn_submit" runat="server" Width="100px" CssClass="formbutton" Text="Save"></ASP:BUTTON></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
