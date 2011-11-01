<%@ Control Language="vb" AutoEventWireup="false" Codebehind="sp_diamonds.ascx.vb" Inherits="ion_admin.sp_diamonds" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<LINK href="/styles.css" type="text/css" rel="StyleSheet">
<P>
	<TABLE id="Table1" style="BORDER-RIGHT: thin ridge; BORDER-TOP: thin ridge; BORDER-LEFT: thin ridge; BORDER-BOTTOM: thin ridge; BACKGROUND-COLOR: gainsboro"
		cellSpacing="0" cellPadding="0" border="0" width="100%">
		<TR>
			<TD colSpan="1" rowSpan="1">
				<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
					<TR>
						<TD><asp:label id="Label17" runat="server" Font-Bold="True" Width="90px" Font-Names="verdana,arial"
								Font-Size="10pt" ForeColor="MidnightBlue" BorderStyle="Outset" BorderWidth="1px" BackColor="Linen">Diamond</asp:label></TD>
						<TD></TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD><asp:label id="Label9" runat="server" Width="71px" Font-Names="verdana,arial" Font-Size="8pt"
								ForeColor="MidnightBlue">Type</asp:label></TD>
						<TD><asp:dropdownlist id="cmb_stonetype" runat="server" Width="200px" CssClass="formfield"></asp:dropdownlist></TD>
						<TD><asp:label id="Label10" runat="server" Width="65px" Font-Names="verdana,arial" Font-Size="8pt"
								ForeColor="MidnightBlue">Shape</asp:label></TD>
						<TD><asp:dropdownlist id="cmb_shape" runat="server" Width="200px" CssClass="formfield"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD><asp:label id="Label4" runat="server" Width="65px" Font-Names="verdana,arial" Font-Size="8pt"
								ForeColor="MidnightBlue">Weight</asp:label></TD>
						<TD><asp:textbox id="txt_weight" runat="server" Width="90px" Font-Names="verdana,arial" Font-Size="8pt"
								ForeColor="MidnightBlue" CssClass="formfield" MaxLength="9">0.00</asp:textbox>
							<asp:label id="Label42" ForeColor="MidnightBlue" Font-Size="8pt" Font-Names="verdana,arial"
								Width="35px" runat="server">carat</asp:label>
							<asp:RangeValidator id="RangeValidator1" Font-Size="8pt" runat="server" ControlToValidate="txt_weight"
								ErrorMessage="***" MaximumValue="999999" MinimumValue="0" Type="Double"></asp:RangeValidator></TD>
						<TD><asp:label id="Label1" runat="server" Width="65px" Font-Names="verdana,arial" Font-Size="8pt"
								ForeColor="MidnightBlue">Quantity</asp:label></TD>
						<TD><asp:textbox id="txt_quantity" runat="server" Width="90px" Font-Names="verdana,arial" Font-Size="8pt"
								ForeColor="MidnightBlue" CssClass="formfield" MaxLength="5">0</asp:textbox>
							<asp:label id="Label19" ForeColor="MidnightBlue" Font-Size="8pt" Font-Names="verdana,arial"
								Width="35px" runat="server">pcs.</asp:label>
							<asp:RangeValidator id="RangeValidator2" Font-Size="8pt" runat="server" ControlToValidate="txt_quantity"
								ErrorMessage="***" MaximumValue="99999" MinimumValue="0" Type="Double"></asp:RangeValidator></TD>
					</TR>
					<TR>
						<TD><asp:label id="Label2" runat="server" Width="65px" Font-Names="verdana,arial" Font-Size="8pt"
								ForeColor="MidnightBlue">Size from</asp:label></TD>
						<TD><asp:textbox id="txt_measure1" runat="server" Width="40px" Font-Names="verdana,arial" Font-Size="8pt"
								ForeColor="MidnightBlue" CssClass="formfield" MaxLength="5">0.00</asp:textbox>×
							<asp:textbox id="txt_measure2" runat="server" Width="40px" Font-Names="verdana,arial" Font-Size="8pt"
								ForeColor="MidnightBlue" CssClass="formfield" MaxLength="5">0.00</asp:textbox>×
							<asp:textbox id="txt_measure3" runat="server" Width="40px" Font-Names="verdana,arial" Font-Size="8pt"
								ForeColor="MidnightBlue" CssClass="formfield" MaxLength="5">0.00</asp:textbox>
							<asp:label id="Label22" ForeColor="MidnightBlue" Font-Size="8pt" Font-Names="verdana,arial"
								Width="70px" runat="server">(h * w * d)</asp:label>
							<asp:RangeValidator id="RangeValidator5" Font-Size="8pt" runat="server" ControlToValidate="txt_measure1"
								ErrorMessage="*" MaximumValue="100" MinimumValue="0" Type="Double"></asp:RangeValidator>
							<asp:RangeValidator id="RangeValidator6" Font-Size="8pt" runat="server" ControlToValidate="txt_measure2"
								ErrorMessage="*" MaximumValue="100" MinimumValue="0" Type="Double"></asp:RangeValidator>
							<asp:RangeValidator id="RangeValidator7" Font-Size="8pt" runat="server" ControlToValidate="txt_measure3"
								ErrorMessage="*" MaximumValue="100" MinimumValue="0" Type="Double"></asp:RangeValidator></TD>
						<TD><asp:label id="Label3" runat="server" Width="65px" Font-Names="verdana,arial" Font-Size="8pt"
								ForeColor="MidnightBlue">Size to</asp:label></TD>
						<TD><asp:textbox id="txt_measure_to1" runat="server" Width="40px" Font-Names="verdana,arial" Font-Size="8pt"
								ForeColor="MidnightBlue" CssClass="formfield" MaxLength="4">0.00</asp:textbox>×
							<asp:textbox id="txt_measure_to2" runat="server" Width="40px" Font-Names="verdana,arial" Font-Size="8pt"
								ForeColor="MidnightBlue" CssClass="formfield" MaxLength="4">0.00</asp:textbox>×
							<asp:textbox id="txt_measure_to3" runat="server" Width="40px" Font-Names="verdana,arial" Font-Size="8pt"
								ForeColor="MidnightBlue" CssClass="formfield" MaxLength="4">0.00</asp:textbox>
							<asp:label id="Label23" ForeColor="MidnightBlue" Font-Size="8pt" Font-Names="verdana,arial"
								Width="70px" runat="server">(h * w * d)</asp:label>
							<asp:RangeValidator id="RangeValidator8" Font-Size="8pt" runat="server" ControlToValidate="txt_measure_to1"
								ErrorMessage="*" MaximumValue="100" MinimumValue="0" Type="Double"></asp:RangeValidator>
							<asp:RangeValidator id="RangeValidator9" Font-Size="8pt" runat="server" ControlToValidate="txt_measure_to2"
								ErrorMessage="*" MaximumValue="100" MinimumValue="0" Type="Double"></asp:RangeValidator>
							<asp:RangeValidator id="RangeValidator10" Font-Size="8pt" runat="server" ControlToValidate="txt_measure_to3"
								ErrorMessage="*" MaximumValue="100" MinimumValue="0" Type="Double"></asp:RangeValidator></TD>
					</TR>
					<TR>
						<TD><asp:label id="Label5" runat="server" Width="79px" Font-Names="verdana,arial" Font-Size="8pt"
								ForeColor="MidnightBlue">Color/Clarity</asp:label></TD>
						<TD><asp:dropdownlist id="cmb_colorfrom" runat="server" Width="85px" CssClass="formfield"></asp:dropdownlist><asp:dropdownlist id="cmb_clarityfrom" runat="server" Width="85px" CssClass="formfield"></asp:dropdownlist>
							<asp:label id="Label18" runat="server" Width="45px" Font-Names="verdana,arial" Font-Size="8pt"
								ForeColor="MidnightBlue">   To   -></asp:label></TD>
						<TD><asp:label id="Label6" runat="server" Width="65px" Font-Names="verdana,arial" Font-Size="8pt"
								ForeColor="MidnightBlue">Color/Clarity</asp:label></TD>
						<TD><asp:dropdownlist id="cmb_colorto" runat="server" Width="85px" CssClass="formfield"></asp:dropdownlist><asp:dropdownlist id="cmb_clarityto" runat="server" Width="85px" CssClass="formfield"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD>
							<asp:label id="Label24" ForeColor="MidnightBlue" Font-Size="8pt" Font-Names="verdana,arial"
								Width="96px" runat="server">Color Free Txt</asp:label></TD>
						<TD>
							<asp:TextBox id="txt_fancycolor" runat="server" CssClass="formfield"></asp:TextBox></TD>
						<TD>&nbsp;</TD>
						<TD>&nbsp;</TD>
					</TR>
					<TR>
						<TD><asp:label id="Label7" runat="server" Width="71px" Font-Names="verdana,arial" Font-Size="8pt"
								ForeColor="MidnightBlue">Depth</asp:label></TD>
						<TD><asp:textbox id="txt_depth" runat="server" Width="90px" Font-Names="verdana,arial" Font-Size="8pt"
								ForeColor="MidnightBlue" CssClass="formfield" MaxLength="5">0.00</asp:textbox>
							<asp:label id="Label20" ForeColor="MidnightBlue" Font-Size="8pt" Font-Names="verdana,arial"
								Width="30px" runat="server">%</asp:label>
							<asp:RangeValidator id="RangeValidator3" Font-Size="8pt" runat="server" ControlToValidate="txt_depth"
								ErrorMessage="***" MaximumValue="100" MinimumValue="0" Width="22px" Type="Double"></asp:RangeValidator></TD>
						<TD><asp:label id="Label8" runat="server" Width="71px" Font-Names="verdana,arial" Font-Size="8pt"
								ForeColor="MidnightBlue">Table width</asp:label></TD>
						<TD><asp:textbox id="txt_tablewidth" runat="server" Width="90px" Font-Names="verdana,arial" Font-Size="8pt"
								ForeColor="MidnightBlue" CssClass="formfield" MaxLength="5">0.00</asp:textbox>
							<asp:label id="Label21" ForeColor="MidnightBlue" Font-Size="8pt" Font-Names="verdana,arial"
								Width="30px" runat="server">%</asp:label>
							<asp:RangeValidator id="RangeValidator4" Font-Size="8pt" runat="server" ControlToValidate="txt_tablewidth"
								ErrorMessage="***" MaximumValue="100" MinimumValue="0" Type="Double"></asp:RangeValidator></TD>
					</TR>
					<TR>
						<TD><asp:label id="Label11" runat="server" Width="65px" Font-Names="verdana,arial" Font-Size="8pt"
								ForeColor="MidnightBlue">Polish</asp:label></TD>
						<TD><asp:dropdownlist id="cmb_polish" runat="server" Width="200px" CssClass="formfield"></asp:dropdownlist></TD>
						<TD><asp:label id="Label12" runat="server" Width="65px" Font-Names="verdana,arial" Font-Size="8pt"
								ForeColor="MidnightBlue">Symmetry</asp:label></TD>
						<TD><asp:dropdownlist id="cmb_symmetry" runat="server" Width="200px" CssClass="formfield"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD><asp:label id="Label13" runat="server" Width="65px" Font-Names="verdana,arial" Font-Size="8pt"
								ForeColor="MidnightBlue">Fluorecence</asp:label></TD>
						<TD><asp:dropdownlist id="cmb_fluorecence" runat="server" Width="200px" CssClass="formfield"></asp:dropdownlist></TD>
						<TD><asp:label id="Label14" runat="server" Width="65px" Font-Names="verdana,arial" Font-Size="8pt"
								ForeColor="MidnightBlue">Girdle</asp:label></TD>
						<TD><asp:dropdownlist id="cmb_girdle" runat="server" Width="200px" CssClass="formfield"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD><asp:label id="Label15" runat="server" Width="65px" Font-Names="verdana,arial" Font-Size="8pt"
								ForeColor="MidnightBlue">Culet</asp:label></TD>
						<TD><asp:dropdownlist id="cmb_culet" runat="server" Width="200px" CssClass="formfield"></asp:dropdownlist></TD>
						<TD><asp:label id="Label16" runat="server" Width="65px" Font-Names="verdana,arial" Font-Size="8pt"
								ForeColor="MidnightBlue">Report</asp:label></TD>
						<TD><asp:dropdownlist id="cmb_report" runat="server" Width="200px" CssClass="formfield"></asp:dropdownlist></TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
	</TABLE>
</P>
<asp:Label id="hid_subplate_id" runat="server" Visible="False">0</asp:Label>
