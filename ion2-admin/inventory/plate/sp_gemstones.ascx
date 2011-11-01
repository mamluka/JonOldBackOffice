<%@ Control Language="vb" AutoEventWireup="false" Codebehind="sp_gemstones.ascx.vb" Inherits="ion_admin.sp_gemstones" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<LINK href="/styles.css" type="text/css" rel="StyleSheet">
<P>
	<TABLE id="Table1" style="BORDER-RIGHT: thin ridge; BORDER-TOP: thin ridge; BORDER-LEFT: thin ridge; BORDER-BOTTOM: thin ridge; BACKGROUND-COLOR: gainsboro"
		cellSpacing="0" cellPadding="0" width="100%" border="0">
		<TR>
			<TD colSpan="1" rowSpan="1">
				<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
					<TR>
						<TD>
							<asp:label id="Label17" runat="server" Width="90px" ForeColor="MidnightBlue" Font-Size="10pt"
								Font-Names="verdana,arial" Font-Bold="True" BorderStyle="Outset" BorderWidth="1px" BackColor="Linen">Gemstone</asp:label></TD>
						<TD></TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD>
							<asp:label id="Label9" runat="server" Width="71px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial">Stone type</asp:label></TD>
						<TD>
							<asp:dropdownlist id="cmb_stonetype" runat="server" Width="200px" CssClass="formfield"></asp:dropdownlist></TD>
						<TD>
							<asp:label id="Label10" runat="server" Width="65px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial">Shape</asp:label></TD>
						<TD>
							<asp:dropdownlist id="cmb_shape" runat="server" Width="200px" CssClass="formfield"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD>
							<asp:label id="Label4" runat="server" Width="65px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial">Weight</asp:label></TD>
						<TD>
							<asp:textbox id="txt_weight" runat="server" Width="90px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial" CssClass="formfield" MaxLength="9">0.00</asp:textbox>
							<asp:label id="Label42" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								Width="35px" runat="server">carat</asp:label>
							<asp:RangeValidator id="RangeValidator1" Font-Size="8pt" runat="server" Type="Double" MinimumValue="0"
								MaximumValue="999999" ErrorMessage="***" ControlToValidate="txt_weight"></asp:RangeValidator></TD>
						<TD>
							<asp:label id="Label1" runat="server" Width="65px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial">Quantity</asp:label></TD>
						<TD>
							<asp:textbox id="txt_quantity" runat="server" Width="90px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial" CssClass="formfield" MaxLength="5">0</asp:textbox>
							<asp:label id="Label24" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								Width="35px" runat="server">pcs.</asp:label>
							<asp:RangeValidator id="RangeValidator8" Font-Size="8pt" runat="server" Type="Double" MinimumValue="0"
								MaximumValue="99999" ErrorMessage="***" ControlToValidate="txt_quantity"></asp:RangeValidator></TD>
					</TR>
					<TR>
						<TD>
							<asp:label id="Label2" runat="server" Width="65px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial">Size from</asp:label></TD>
						<TD>
							<asp:textbox id="txt_measure1" runat="server" Width="40px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial" CssClass="formfield" MaxLength="5">0.00</asp:textbox>×
							<asp:textbox id="txt_measure2" runat="server" Width="40px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial" CssClass="formfield" MaxLength="5">0.00</asp:textbox>×
							<asp:textbox id="txt_measure3" runat="server" Width="40px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial" CssClass="formfield" MaxLength="5">0.00</asp:textbox>
							<asp:label id="Label22" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								Width="70px" runat="server">(h * w * d)</asp:label>
							<asp:RangeValidator id="RangeValidator6" Font-Size="8pt" runat="server" Type="Double" MinimumValue="0"
								MaximumValue="100" ErrorMessage="*" ControlToValidate="txt_measure1"></asp:RangeValidator>
							<asp:RangeValidator id="RangeValidator2" Font-Size="8pt" runat="server" Type="Double" MinimumValue="0"
								MaximumValue="100" ErrorMessage="*" ControlToValidate="txt_measure2"></asp:RangeValidator>
							<asp:RangeValidator id="RangeValidator3" Font-Size="8pt" runat="server" Type="Double" MinimumValue="0"
								MaximumValue="100" ErrorMessage="*" ControlToValidate="txt_measure3"></asp:RangeValidator></TD>
						<TD>
							<asp:label id="Label3" runat="server" Width="65px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial">Size to</asp:label></TD>
						<TD>
							<asp:textbox id="txt_measure_to1" runat="server" Width="40px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial" CssClass="formfield" MaxLength="5">0.00</asp:textbox>×
							<asp:textbox id="txt_measure_to2" runat="server" Width="40px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial" CssClass="formfield" MaxLength="5">0.00</asp:textbox>×
							<asp:textbox id="txt_measure_to3" runat="server" Width="40px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial" CssClass="formfield" MaxLength="5">0.00</asp:textbox>
							<asp:label id="Label23" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								Width="70px" runat="server">(h * w * d)</asp:label>
							<asp:RangeValidator id="RangeValidator4" Font-Size="8pt" runat="server" Type="Double" MinimumValue="0"
								MaximumValue="100" ErrorMessage="*" ControlToValidate="txt_measure_to1"></asp:RangeValidator>
							<asp:RangeValidator id="RangeValidator5" Font-Size="8pt" runat="server" Type="Double" MinimumValue="0"
								MaximumValue="100" ErrorMessage="*" ControlToValidate="txt_measure_to2"></asp:RangeValidator>
							<asp:RangeValidator id="RangeValidator7" Font-Size="8pt" runat="server" Type="Double" MinimumValue="0"
								MaximumValue="100" ErrorMessage="*" ControlToValidate="txt_measure_to3"></asp:RangeValidator></TD>
					</TR>
					<TR>
						<TD vAlign="top">
							<asp:label id="Label5" runat="server" Width="77px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial" BorderWidth="0px">Color From</asp:label></TD>
						<TD>
							<asp:dropdownlist id="cmb_colorfrom" runat="server" Width="250px" CssClass="formfield"></asp:dropdownlist>
							<asp:dropdownlist id="cmb_colortypefrom" runat="server" Width="250px" CssClass="formfield"></asp:dropdownlist></TD>
						<TD vAlign="top">
							<asp:label id="Label6" runat="server" Width="72px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial">Clarity From</asp:label></TD>
						<TD>
							<asp:dropdownlist id="cmb_clarityfrom" runat="server" Width="250px" CssClass="formfield"></asp:dropdownlist>
							<asp:dropdownlist id="cmb_claritytypefrom" runat="server" Width="250px" CssClass="formfield"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD vAlign="top">
							<asp:label id="Label18" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								Width="71px" runat="server">Color To</asp:label></TD>
						<TD>
							<asp:dropdownlist id="cmb_colorto" Width="250px" runat="server" CssClass="formfield"></asp:dropdownlist>
							<asp:dropdownlist id="cmb_colortypeto" Width="250px" runat="server" CssClass="formfield"></asp:dropdownlist></TD>
						<TD vAlign="top">&nbsp;</TD>
						<TD>&nbsp;</TD>
					</TR>
					<TR>
						<TD vAlign="top">
							<asp:label id="Label7" BorderWidth="0px" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								Width="77px" runat="server">Free Color</asp:label></TD>
						<TD>
							<asp:textbox id="free_color_txt" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								Width="248px" runat="server" CssClass="formfield"></asp:textbox></TD>
						<TD vAlign="top">
							<asp:label id="Label19" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								Width="65px" runat="server">Clarity To</asp:label></TD>
						<TD>
							<asp:dropdownlist id="cmb_clarityto" Width="250px" runat="server" CssClass="formfield"></asp:dropdownlist>
							<asp:dropdownlist id="cmb_claritytypeto" Width="250px" runat="server" CssClass="formfield"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD>
							<asp:label id="Label11" runat="server" Width="65px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial">Origin</asp:label></TD>
						<TD>
							<asp:dropdownlist id="cmb_origin" runat="server" Width="200px" CssClass="formfield"></asp:dropdownlist></TD>
						<TD>
							<asp:label id="Label12" runat="server" Width="65px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial">Brightness</asp:label></TD>
						<TD>
							<asp:dropdownlist id="cmb_brightness" runat="server" Width="200px" CssClass="formfield"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD>
							<asp:label id="Label13" runat="server" Width="65px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial">Luster</asp:label></TD>
						<TD>
							<asp:dropdownlist id="cmb_luster" runat="server" Width="200px" CssClass="formfield"></asp:dropdownlist></TD>
						<TD>
							<asp:label id="Label14" runat="server" Width="65px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial">Saturation</asp:label></TD>
						<TD>
							<asp:dropdownlist id="cmb_saturation" runat="server" Width="200px" CssClass="formfield"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD>
							<asp:label id="Label20" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								Width="65px" runat="server">Enhancements</asp:label></TD>
						<TD>
							<asp:dropdownlist id="cmb_enhancements" Width="250px" runat="server" CssClass="formfield"></asp:dropdownlist></TD>
						<TD>
							<asp:label id="Label21" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								Width="65px" runat="server">Cut</asp:label></TD>
						<TD>
							<asp:dropdownlist id="cmb_cut" Width="200px" runat="server" CssClass="formfield"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD>
							<asp:label id="Label15" runat="server" Width="86px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial">General Grade</asp:label></TD>
						<TD>
							<asp:dropdownlist id="cmb_grade" runat="server" Width="250px" CssClass="formfield"></asp:dropdownlist></TD>
						<TD>
							<asp:label id="Label16" runat="server" Width="65px" ForeColor="MidnightBlue" Font-Size="8pt"
								Font-Names="verdana,arial">Report</asp:label></TD>
						<TD>
							<asp:dropdownlist id="cmb_report" runat="server" Width="250px" CssClass="formfield"></asp:dropdownlist></TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
	</TABLE>
</P>
<asp:Label id="hid_subplate_id" runat="server" Visible="False">0</asp:Label>
