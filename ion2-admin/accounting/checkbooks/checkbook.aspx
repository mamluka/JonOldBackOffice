<%@ Page Language="vb" AutoEventWireup="false" Codebehind="checkbook.aspx.vb" Inherits="ion_admin.checkbook"%>
<%@ Register TagPrefix="uc1" TagName="ruler" Src="../../webcontrols/ruler.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>checkbook</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/styles.css" type="text/css" rel="StyleSheet">
	</HEAD>
	<body bgColor="#e6e6fa" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:ruler id="Ruler1" runat="server"></uc1:ruler>
			<HR>
			<asp:label id="lbl_header" runat="server" BorderColor="White" Font-Bold="True" BackColor="DarkSlateBlue" BorderWidth="1px" BorderStyle="Groove" Font-Names="vedana,arial" Font-Size="12pt" ForeColor="Linen" Width="100%"></asp:label>
			<HR>
			<center>
				<TABLE id="tbl_frame" style="BORDER-RIGHT: 1px ridge; BORDER-TOP: 1px ridge; BORDER-LEFT: 1px ridge; BORDER-BOTTOM: 1px ridge" cellSpacing="1" cellPadding="1" width="85%" bgColor="lightgrey" border="0">
					<TR>
						<TD bgColor="#708090"><asp:label id="lbl_caption" runat="server" Font-Bold="True" Font-Names="verdana,arial" Font-Size="10pt" ForeColor="Khaki" Width="404px">Checkbook</asp:label></TD>
					</TR>
					<TR>
						<TD>
							<TABLE id="tbl_main" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD>
										<asp:label id="Label2" runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue" Width="84px">Suppliers</asp:label></TD>
									<TD width="250">
										<asp:CheckBox id="chk_suppliers" runat="server" Width="20px" BackColor="#C0C0FF" Height="14px" AutoPostBack="True"></asp:CheckBox>
										<asp:dropdownlist id="cmb_suppliers" runat="server" BackColor="#C0C0FF" Width="200px" CssClass="formfield" AutoPostBack="True"></asp:dropdownlist></TD>
									<TD>
										<asp:label id="Label4" runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue" Width="84px">Cashed</asp:label></TD>
									<TD>
										<asp:CheckBox id="chk_cashed" runat="server" Width="20px" Height="14px"></asp:CheckBox>
										<asp:TextBox id="txt_cashed" runat="server" Width="150px" MaxLength="40" CssClass="formfield" Enabled="False"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD><asp:label id="Label1" runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue" Width="102px">General accounts</asp:label></TD>
									<TD>
										<asp:CheckBox id="chk_accounts" runat="server" Width="20px" BackColor="#C0C0FF" Height="14px" AutoPostBack="True"></asp:CheckBox>
										<asp:DropDownList id="cmb_accounts" runat="server" BackColor="#C0C0FF" Width="200px" CssClass="formfield" AutoPostBack="True"></asp:DropDownList></TD>
									<TD>
										<asp:label id="Label3" runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue" Width="84px">Check No#</asp:label></TD>
									<TD>
										<asp:TextBox id="txt_check_number" runat="server" Width="60px" MaxLength="8" CssClass="formfield"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>
										<asp:label id="Label5" runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue" Width="102px">Name</asp:label></TD>
									<TD>
										<asp:TextBox id="txt_nameto" runat="server" Width="200px" MaxLength="120" CssClass="formfield"></asp:TextBox></TD>
									<TD>
										<asp:label id="Label6" runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue" Width="102px">Check date</asp:label></TD>
									<TD>
										<asp:TextBox id="txt_checkdate" runat="server" Width="150px" MaxLength="40" CssClass="formfield"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD>
										<asp:label id="Label7" runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue" Width="102px">Description</asp:label></TD>
									<TD colSpan="2">
										<asp:TextBox id="TextBox2" runat="server" Width="300px" MaxLength="200" CssClass="formfield"></asp:TextBox></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD>
										<asp:label id="Label8" runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue" Width="102px">USD rate</asp:label></TD>
									<TD>
										<asp:TextBox id="TextBox3" runat="server" Width="60px" MaxLength="8" CssClass="formfield"></asp:TextBox></TD>
									<TD>
										<asp:label id="Label9" runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue" Width="102px">Amount</asp:label></TD>
									<TD>
										<asp:TextBox id="txt_amount" runat="server" Width="100px" MaxLength="25" CssClass="formfield"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD vAlign="top">
										<asp:label id="Label10" runat="server" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue" Width="102px">Notes</asp:label></TD>
									<TD colSpan="3">
										<asp:TextBox id="txt_notes" runat="server" Width="100%" MaxLength="200" CssClass="formfield" TextMode="MultiLine" Height="71px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD></TD>
									<TD></TD>
									<TD></TD>
									<TD align="right">
										<asp:Button id="btn_submit" runat="server" Width="190px" CssClass="formbutton" Text="Save"></asp:Button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
