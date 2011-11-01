<%@ Control Language="vb" AutoEventWireup="false" Codebehind="wc_order_status.ascx.vb" Inherits="ion_admin.wc_order_status" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<TABLE id="tbl_main" style="BORDER-RIGHT: 1px ridge; BORDER-TOP: 1px ridge; FONT-SIZE: 8pt; BORDER-LEFT: 1px ridge; COLOR: midnightblue; BORDER-BOTTOM: 1px ridge; FONT-FAMILY: verdana,arial; BACKGROUND-COLOR: silver"
	borderColor="lightgrey" cellSpacing="0" cellPadding="0" width="100%" border="1">
	<TR>
		<TD style="BORDER-RIGHT: 2px groove; BORDER-TOP: 2px groove; BORDER-LEFT: 2px groove; BORDER-BOTTOM: 2px groove"
			bgColor="#708090" colSpan="5">&nbsp;
			<asp:label id="lbl_header" WIDTH="501px" ForeColor="Khaki" Font-Size="10pt" Font-Bold="True"
				runat="server">Order Staus</asp:label></TD>
	</TR>
	<TR>
		<TD align="center" colSpan="5"><BR>
			<TABLE id="tbl_YesNo" style="BORDER-RIGHT: 1px ridge; BORDER-TOP: 1px ridge; FONT-SIZE: 9pt; BORDER-LEFT: 1px ridge; COLOR: khaki; BORDER-BOTTOM: 1px ridge; FONT-FAMILY: verdana,arial; BACKGROUND-COLOR: midnightblue"
				width="400" border="0" RUNAT="server">
				<TR>
					<TD><ASP:LABEL id="Label8" Font-Bold="True" runat="server" Width="310px">Are you sure you want to change status to:</ASP:LABEL></TD>
					<TD width="60"><ASP:BUTTON id="btn_YES" runat="server" Width="50px" Text="Yes" CssClass="formbutton"></ASP:BUTTON></TD>
				</TR>
				<TR>
					<TD align="center"><ASP:LABEL id="lbl_yn_question" ForeColor="#FFFFC0" Font-Bold="True" runat="server" Width="318px"
							Font-Italic="True"></ASP:LABEL></TD>
					<TD width="60"><ASP:BUTTON id="btn_NO" runat="server" Width="50px" Text="No" CssClass="formbutton"></ASP:BUTTON></TD>
				</TR>
			</TABLE>
			<asp:textbox id="hid_SettingStat" runat="server" Width="60px" VISIBLE="False"></asp:textbox><BR>
		</TD>
	</TR>
	<TR>
		<TD width="10"><ASP:LABEL id="Label4" runat="server">01</ASP:LABEL></TD>
		<TD width="20"><asp:checkbox id="chk_stat_1" runat="server" BACKCOLOR="#C0C0FF" AUTOPOSTBACK="True"></asp:checkbox></TD>
		<TD width="260"><asp:label id="lbl_sts_line_1" runat="server">New order received</asp:label></TD>
		<TD width="170"><asp:label id="lbl_date_sts_1" runat="server">&nbsp;</asp:label></TD>
		<TD width="350"></TD>
	</TR>
	<TR>
		<TD width="10" style="HEIGHT: 35px"><ASP:LABEL id="Label5" runat="server">02</ASP:LABEL></TD>
		<TD width="20" style="HEIGHT: 35px"><asp:checkbox id="chk_stat_2" runat="server" BACKCOLOR="#C0C0FF" AUTOPOSTBACK="True"></asp:checkbox></TD>
		<TD width="260" style="HEIGHT: 35px"><asp:label id="lbl_sts_line_2" runat="server">Waiting for authorization</asp:label></TD>
		<TD width="170" style="HEIGHT: 35px"><asp:label id="lbl_date_sts_2" runat="server">&nbsp;</asp:label></TD>
		<TD width="350" style="HEIGHT: 35px"><asp:textbox id="txt_note_sts_2" runat="server" Width="100%" CssClass="formfield" MaxLength="150"></asp:textbox></TD>
	</TR>
	<TR>
		<TD width="10"><ASP:LABEL id="Label9" runat="server">03</ASP:LABEL></TD>
		<TD width="20"><asp:checkbox id="chk_stat_3" runat="server" BACKCOLOR="#C0C0FF" AUTOPOSTBACK="True"></asp:checkbox></TD>
		<TD width="260"><asp:label id="lbl_sts_line_3" runat="server">Waiting for payment</asp:label></TD>
		<TD width="170"><asp:label id="lbl_date_sts_3" runat="server">&nbsp;</asp:label></TD>
		<TD width="350"><asp:textbox id="txt_note_sts_3" runat="server" Width="100%" CssClass="formfield" MaxLength="150"></asp:textbox></TD>
	</TR>
	<TR>
		<TD width="10"><ASP:LABEL id="Label14" runat="server">04</ASP:LABEL></TD>
		<TD width="20"><ASP:CHECKBOX id="chk_stat_5" runat="server" BACKCOLOR="#C0C0FF" AUTOPOSTBACK="True" Height="21px"></ASP:CHECKBOX></TD>
		<TD width="260"><ASP:LABEL id="lbl_sts_line_5" runat="server">Patial order confirmed</ASP:LABEL></TD>
		<TD width="170"><ASP:LABEL id="lbl_date_sts_5" runat="server">&nbsp;</ASP:LABEL></TD>
		<TD width="350"><ASP:TEXTBOX id="txt_note_sts_5" runat="server" Width="100%" CssClass="formfield" MaxLength="150"></ASP:TEXTBOX></TD>
	</TR>
	<TR>
		<TD width="10"><ASP:LABEL id="Label12" runat="server">05</ASP:LABEL></TD>
		<TD width="20"><asp:checkbox id="chk_stat_4" runat="server" BACKCOLOR="#C0C0FF" AUTOPOSTBACK="True"></asp:checkbox></TD>
		<TD width="260"><asp:label id="lbl_sts_line_4" runat="server" FORECOLOR="Red">Order confirmed</asp:label></TD>
		<TD width="170"><asp:label id="lbl_date_sts_4" runat="server">&nbsp;</asp:label></TD>
		<TD width="350"><asp:textbox id="txt_note_sts_4" runat="server" Width="100%" CssClass="formfield" MaxLength="150"></asp:textbox></TD>
	</TR>
	<TR>
		<TD width="10"><ASP:LABEL id="Label16" runat="server">06</ASP:LABEL></TD>
		<TD width="20"><asp:checkbox id="chk_stat_6" runat="server" BACKCOLOR="#C0C0FF" AUTOPOSTBACK="True"></asp:checkbox></TD>
		<TD width="260"><asp:label id="lbl_sts_line_6" runat="server">Order failed</asp:label></TD>
		<TD width="170"><asp:label id="lbl_date_sts_6" runat="server">&nbsp;</asp:label></TD>
		<TD width="350"><asp:textbox id="txt_note_sts_6" runat="server" Width="100%" CssClass="formfield" MaxLength="150"></asp:textbox></TD>
	</TR>
	<TR>
		<TD width="10"><ASP:LABEL id="Label17" runat="server">07</ASP:LABEL></TD>
		<TD width="20"><asp:checkbox id="chk_stat_7" runat="server" BACKCOLOR="#C0C0FF" AUTOPOSTBACK="True"></asp:checkbox></TD>
		<TD width="260"><asp:label id="lbl_sts_line_7" runat="server">Order waiting to be send</asp:label></TD>
		<TD width="170"><asp:label id="lbl_date_sts_7" runat="server">&nbsp;</asp:label></TD>
		<TD width="350"><asp:textbox id="txt_note_sts_7" runat="server" Width="100%" CssClass="formfield" MaxLength="150"></asp:textbox></TD>
	</TR>
	<TR>
		<TD width="10"><ASP:LABEL id="Label22" runat="server">08</ASP:LABEL></TD>
		<TD width="20"><ASP:CHECKBOX id="chk_stat_9" runat="server" BACKCOLOR="#C0C0FF" AUTOPOSTBACK="True"></ASP:CHECKBOX></TD>
		<TD width="260"><ASP:LABEL id="lbl_sts_line_9" runat="server">Partial order send</ASP:LABEL></TD>
		<TD width="170"><ASP:LABEL id="lbl_date_sts_9" runat="server">&nbsp;</ASP:LABEL></TD>
		<TD width="350"><ASP:TEXTBOX id="txt_note_sts_9" runat="server" Width="100%" CssClass="formfield" MaxLength="150"></ASP:TEXTBOX></TD>
	</TR>
	<TR>
		<TD width="10"><ASP:LABEL id="Label20" runat="server">09</ASP:LABEL></TD>
		<TD width="20"><asp:checkbox id="chk_stat_8" runat="server" BACKCOLOR="#C0C0FF" AUTOPOSTBACK="True"></asp:checkbox></TD>
		<TD width="260"><asp:label id="lbl_sts_line_8" runat="server" FORECOLOR="Red">Order send</asp:label></TD>
		<TD width="170"><asp:label id="lbl_date_sts_8" runat="server">&nbsp;</asp:label></TD>
		<TD width="350"><asp:textbox id="txt_note_sts_8" runat="server" Width="100%" CssClass="formfield" MaxLength="150"></asp:textbox></TD>
	</TR>
	<TR>
		<TD width="10">&nbsp;</TD>
		<TD width="20">&nbsp;</TD>
		<TD width="260">&nbsp;</TD>
		<TD width="170">&nbsp;</TD>
		<TD width="350" align="right"><ASP:LABEL id="Label3" runat="server">Tracking No.</ASP:LABEL>&nbsp;<ASP:TEXTBOX id="txt_trackingno" runat="server" Width="150px" CssClass="formfield" MaxLength="100"></ASP:TEXTBOX></TD>
	</TR>
	<TR>
		<TD>&nbsp;</TD>
		<TD>&nbsp;
			<ASP:CHECKBOX id="chk_stat_18" runat="server" AUTOPOSTBACK="True" BACKCOLOR="#C0C0FF"></ASP:CHECKBOX></TD>
		<TD>No response</TD>
		<TD>&nbsp;</TD>
		<TD>&nbsp;
			<ASP:TEXTBOX id="txt_note_sts_18" runat="server" Width="100%" CssClass="formfield" MaxLength="150"></ASP:TEXTBOX></TD>
	</TR>
	<TR>
		<TD width="10"><ASP:LABEL id="Label26" runat="server">10</ASP:LABEL></TD>
		<TD width="20"><ASP:CHECKBOX id="chk_stat_11" runat="server" BACKCOLOR="#C0C0FF" AUTOPOSTBACK="True"></ASP:CHECKBOX></TD>
		<TD width="260"><ASP:LABEL id="lbl_sts_line_11" runat="server">Order partialy received by customer</ASP:LABEL></TD>
		<TD width="170"><ASP:LABEL id="lbl_date_sts_11" runat="server">&nbsp;</ASP:LABEL></TD>
		<TD width="350"><ASP:TEXTBOX id="txt_note_sts_11" runat="server" Width="100%" CssClass="formfield" MaxLength="150"></ASP:TEXTBOX></TD>
	</TR>
	<TR>
		<TD width="10"><ASP:LABEL id="Label24" runat="server">11</ASP:LABEL></TD>
		<TD width="20"><asp:checkbox id="chk_stat_10" runat="server" BACKCOLOR="#C0C0FF" AUTOPOSTBACK="True"></asp:checkbox></TD>
		<TD width="260"><asp:label id="lbl_sts_line_10" runat="server">Order received by customer</asp:label></TD>
		<TD width="170"><asp:label id="lbl_date_sts_10" runat="server">&nbsp;</asp:label></TD>
		<TD width="350"><asp:textbox id="txt_note_sts_10" runat="server" Width="100%" CssClass="formfield" MaxLength="150"></asp:textbox></TD>
	</TR>
	<TR>
		<TD width="10"><ASP:LABEL id="Label29" runat="server">12</ASP:LABEL></TD>
		<TD width="20"><ASP:CHECKBOX id="chk_stat_13" runat="server" BACKCOLOR="#C0C0FF" AUTOPOSTBACK="True"></ASP:CHECKBOX></TD>
		<TD width="260"><ASP:LABEL id="lbl_sts_line_13" runat="server">Customer returning part of order</ASP:LABEL></TD>
		<TD width="170"><ASP:LABEL id="lbl_date_sts_13" runat="server">&nbsp;</ASP:LABEL></TD>
		<TD width="350"><ASP:TEXTBOX id="txt_note_sts_13" runat="server" Width="100%" CssClass="formfield" MaxLength="150"></ASP:TEXTBOX></TD>
	</TR>
	<TR>
		<TD width="10"><ASP:LABEL id="Label28" runat="server">13</ASP:LABEL></TD>
		<TD width="20"><asp:checkbox id="chk_stat_12" runat="server" BACKCOLOR="#C0C0FF" AUTOPOSTBACK="True"></asp:checkbox></TD>
		<TD width="260"><asp:label id="lbl_sts_line_12" runat="server">Customer returning order</asp:label></TD>
		<TD width="170"><asp:label id="lbl_date_sts_12" runat="server">&nbsp;</asp:label></TD>
		<TD width="350"><asp:textbox id="txt_note_sts_12" runat="server" Width="100%" CssClass="formfield" MaxLength="150"></asp:textbox></TD>
	</TR>
	<TR>
		<TD width="10"><ASP:LABEL id="Label33" runat="server">14</ASP:LABEL></TD>
		<TD width="20"><ASP:CHECKBOX id="chk_stat_15" runat="server" BACKCOLOR="#C0C0FF" AUTOPOSTBACK="True"></ASP:CHECKBOX></TD>
		<TD width="260"><ASP:LABEL id="lbl_sts_line_15" runat="server">Customer partialy refunded</ASP:LABEL></TD>
		<TD width="170"><ASP:LABEL id="lbl_date_sts_15" runat="server">&nbsp;</ASP:LABEL></TD>
		<TD width="350"><ASP:TEXTBOX id="txt_note_sts_15" runat="server" Width="100%" CssClass="formfield" MaxLength="150"></ASP:TEXTBOX></TD>
	</TR>
	<TR>
		<TD width="10"><ASP:LABEL id="Label32" runat="server">15</ASP:LABEL></TD>
		<TD width="20"><asp:checkbox id="chk_stat_14" runat="server" BACKCOLOR="#C0C0FF" AUTOPOSTBACK="True"></asp:checkbox></TD>
		<TD width="260"><asp:label id="lbl_sts_line_14" runat="server">Customer refunded</asp:label></TD>
		<TD width="170"><asp:label id="lbl_date_sts_14" runat="server">&nbsp;</asp:label></TD>
		<TD width="350"><asp:textbox id="txt_note_sts_14" runat="server" Width="100%" CssClass="formfield" MaxLength="150"></asp:textbox></TD>
	</TR>
	<TR>
		<TD width="10"><ASP:LABEL id="Label34" runat="server">16</ASP:LABEL></TD>
		<TD width="20"><asp:checkbox id="chk_stat_16" runat="server" BACKCOLOR="#C0C0FF" AUTOPOSTBACK="True"></asp:checkbox></TD>
		<TD width="260"><asp:label id="lbl_sts_line_16" runat="server">Order closed</asp:label></TD>
		<TD width="170"><asp:label id="lbl_date_sts_16" runat="server">&nbsp;</asp:label></TD>
		<TD width="350"><asp:textbox id="txt_note_sts_16" runat="server" Width="100%" CssClass="formfield" MaxLength="150"></asp:textbox></TD>
	</TR>
	<TR>
		<TD width="10" style="HEIGHT: 35px"><ASP:LABEL id="Label35" runat="server">17</ASP:LABEL></TD>
		<TD width="20" style="HEIGHT: 35px"><asp:checkbox id="chk_stat_17" runat="server" BACKCOLOR="#C0C0FF" AUTOPOSTBACK="True"></asp:checkbox></TD>
		<TD width="260" style="HEIGHT: 35px"><asp:label id="lbl_sts_line_17" runat="server" FORECOLOR="Red">Order cancelled</asp:label></TD>
		<TD width="170" style="HEIGHT: 35px"><asp:label id="lbl_date_sts_17" runat="server">&nbsp;</asp:label></TD>
		<TD width="350" style="HEIGHT: 35px"><asp:textbox id="txt_note_sts_17" runat="server" Width="100%" CssClass="formfield" MaxLength="150"></asp:textbox></TD>
	</TR>
	<TR>
		<TD align="right" colSpan="5"><INPUT class="formbutton" style="WIDTH: 200px; HEIGHT: 20px" onclick="window.close()" type="button"
				value="Close"></TD>
	</TR>
</TABLE>
<SCRIPT language="javascript">
function closewindow(){
 	window.alert("ddd");
 	window.close;
	}
</SCRIPT>
