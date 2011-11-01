<%@ Page Language="vb" AutoEventWireup="false" Codebehind="currency_rates.aspx.vb" Inherits="ion_admin.currency_rates"%>
<%@ Register TagPrefix="uc1" TagName="ruler" Src="../webcontrols/ruler.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>currency_rates</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/styles.css" type="text/css" rel="StyleSheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" bgColor="#e6e6fa">
		<form id="Form1" method="post" runat="server">
			<uc1:ruler id="Ruler1" runat="server"></uc1:ruler>
			<HR>
			<ASP:LABEL id="lbl_inventory" runat="server" ForeColor="Linen" Font-Size="12pt" Font-Names="vedana,arial" Width="100%" BorderColor="White" Font-Bold="True" BackColor="DarkSlateBlue" BorderWidth="1px" BorderStyle="Groove"> Currency Rates</ASP:LABEL>
			<HR>
			<CENTER>
				<TABLE id="tbl_frame" cellSpacing="1" cellPadding="1" width="40%" border="0" style="BORDER-RIGHT: 1px ridge; BORDER-TOP: 1px ridge; BORDER-LEFT: 1px ridge; BORDER-BOTTOM: 1px ridge" bgColor="lightgrey">
					<TR>
						<TD bgColor="#708090">
							<asp:label id="lbl_caption" runat="server" Font-Bold="True" Width="308px" Font-Names="verdana,arial" Font-Size="10pt" ForeColor="Khaki">Add Rate ILS -> USD</asp:label></TD>
					</TR>
					<TR>
						<TD align="right">
							<TABLE id="tbl_main" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD colSpan="1" align="right">
										<asp:label id="Label1" runat="server" Width="102px" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue">Date</asp:label></TD>
									<TD>
										<asp:TextBox id="txt_date" runat="server" Width="100px" CssClass="formfield" MaxLength="25"></asp:TextBox>
										<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="&amp;times;" ControlToValidate="txt_date"></asp:RequiredFieldValidator></TD>
								</TR>
								<TR>
									<TD align="right">
										<asp:label id="Label9" runat="server" Width="102px" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue">Rate</asp:label></TD>
									<TD>
										<asp:TextBox id="txt_amount" runat="server" Width="100px" CssClass="formfield" MaxLength="25"></asp:TextBox>
										<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="&amp;times;" ControlToValidate="txt_amount"></asp:RequiredFieldValidator>
										<asp:RangeValidator id="RangeValidator2" runat="server" ErrorMessage="&amp;times" ControlToValidate="txt_amount" Type="Currency" MaximumValue="6" MinimumValue="3"></asp:RangeValidator></TD>
								</TR>
								<TR>
									<TD>&nbsp;</TD>
									<TD></TD>
								</TR>
							</TABLE>
							<asp:Button id="btn_submit" runat="server" Width="125px" Text="Save" CssClass="formbutton"></asp:Button>
						</TD>
					</TR>
				</TABLE>
			</CENTER>
		</form>
	</body>
</HTML>
