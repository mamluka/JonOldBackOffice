<%@ Control Language="vb" AutoEventWireup="false" Codebehind="wc_customer.ascx.vb" Inherits="ion_admin.wc_customer" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table id="tbl_main" style="BORDER-RIGHT: 1px outset; BORDER-TOP: 1px outset; BORDER-LEFT: 1px outset; BORDER-BOTTOM: 1px outset; BACKGROUND-COLOR: gainsboro" cellspacing="1" cellpadding="1" border="0" width="640">
	<TR>
		<TD align="left" bgColor="#708090" colSpan="4">
			<asp:label id="lbl_caption" Font-Bold="True" runat="server" ForeColor="Khaki" Width="404px" Font-Size="10pt" Font-Names="verdana,arial"> Customer</asp:label></TD>
	</TR>
	<TR>
		<TD colspan="4" borderColor="red" align="center" bgColor="red">
			<asp:listbox id="lst_error" Width="99%" ForeColor="MidnightBlue" runat="server" BackColor="Linen" CssClass="formfield" Font-Bold="True" Visible="False"></asp:listbox>
		</TD>
	</TR>
	<tr>
		<td width="100">
			<asp:Label id="Label1" runat="server" ForeColor="MidnightBlue" Font-Names="verdana,arial" Font-Size="8pt" Width="84px">Customer No.</asp:Label></td>
		<td>
			<asp:TextBox id="txt_customerid" runat="server" Width="150px" CssClass="formfield" BackColor="#E0E0E0" Enabled="False" ForeColor="SlateBlue"></asp:TextBox></td>
		<td width="100">
			<asp:Label id="Label2" runat="server" ForeColor="MidnightBlue" Font-Names="verdana,arial" Font-Size="8pt" Width="84px">Create Date</asp:Label></td>
		<td>
			<asp:TextBox id="txt_createdate" runat="server" Width="150px" CssClass="formfield" Enabled="False" BackColor="#E0E0E0" ForeColor="SlateBlue"></asp:TextBox></td>
	</tr>
	<tr>
		<td width="100">
			<asp:Label id="Label3" runat="server" ForeColor="MidnightBlue" Font-Names="verdana,arial" Font-Size="8pt" Width="84px">First Name</asp:Label></td>
		<td>
			<asp:TextBox id="txt_firstname" runat="server" Width="150px" CssClass="formfield" MaxLength="40"></asp:TextBox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="&amp;times;" ControlToValidate="txt_firstname"></asp:requiredfieldvalidator></td>
		<td width="100">
			<asp:Label id="Label5" runat="server" ForeColor="MidnightBlue" Font-Names="verdana,arial" Font-Size="8pt" Width="84px">eMail</asp:Label></td>
		<td>
			<asp:TextBox id="txt_email" runat="server" Width="250px" CssClass="formfield" MaxLength="80"></asp:TextBox><asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" ErrorMessage="&amp;times;" ControlToValidate="txt_email"></asp:requiredfieldvalidator></td>
	</tr>
	<tr>
		<td width="100">
			<asp:Label id="Label4" runat="server" ForeColor="MidnightBlue" Font-Names="verdana,arial" Font-Size="8pt" Width="84px">Last Name</asp:Label></td>
		<td>
			<asp:TextBox id="txt_lastname" runat="server" Width="150px" CssClass="formfield" MaxLength="64"></asp:TextBox><asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" ErrorMessage="&amp;times;" ControlToValidate="txt_lastname"></asp:requiredfieldvalidator></td>
		<td width="100">
			<asp:Label id="Label6" runat="server" ForeColor="MidnightBlue" Font-Names="verdana,arial" Font-Size="8pt" Width="84px">Password</asp:Label></td>
		<td>
			<asp:TextBox id="txt_password" runat="server" Width="109px" CssClass="formfield" MaxLength="15"></asp:TextBox><asp:requiredfieldvalidator id="Requiredfieldvalidator4" runat="server" ErrorMessage="&amp;times;" ControlToValidate="txt_password"></asp:requiredfieldvalidator></td>
	</tr>
	<TR>
		<TD WIDTH="100"><asp:Label id="Label42" runat="server" ForeColor="MidnightBlue" Width="84px" Font-Size="8pt" Font-Names="verdana,arial">Date of birth</asp:Label></TD>
		<TD VALIGN="top" COLSPAN="2"><asp:TextBox id="txt_dateofbirth" CssClass="formfield" runat="server" Width="90px" MaxLength="10"></asp:TextBox><asp:RangeValidator id="val_BirthDate" runat="server" ErrorMessage="&amp;times;" ControlToValidate="txt_dateofbirth" Type="Date"></asp:RangeValidator></TD>
		<TD VALIGN="middle" ALIGN="center"><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" Font-Size="8pt" Font-Names="verdana,arial" ErrorMessage="- Not a correct E-mail address -" ControlToValidate="txt_email" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:regularexpressionvalidator></TD>
	</TR>
	<tr>
		<td width="100">
			<asp:Label id="Label40" runat="server" ForeColor="MidnightBlue" Width="87px" Font-Size="8pt" Font-Names="verdana,arial">Message to customer</asp:Label>
		<td colspan="2" vAlign="top">
			<asp:TextBox id="txt_message" CssClass="formfield" runat="server" Width="240px" MaxLength="40"></asp:TextBox></td>
		<td vAlign="top">
			<asp:Label id="Label41" runat="server" ForeColor="MidnightBlue" Width="61px" Font-Size="8pt" Font-Names="verdana,arial">Last visit</asp:Label>
			<asp:TextBox id="txt_lastvisit" CssClass="formfield" BackColor="#E0E0E0" runat="server" ForeColor="SlateBlue" Width="150px" Enabled="False"></asp:TextBox>
		</td>
	<tr>
		<td colSpan="4">
			<TABLE id="tbl_address" cellSpacing="1" cellPadding="1" width="100%" border="0" style="BORDER-RIGHT: 2px groove; BORDER-TOP: 2px groove; BORDER-LEFT: 2px groove; BORDER-BOTTOM: 2px groove">
				<TR>
					<TD colspan="4">
						<asp:label id="Label17" Font-Bold="True" BackColor="Linen" Width="90px" ForeColor="MidnightBlue" runat="server" Font-Size="10pt" Font-Names="verdana,arial" BorderWidth="1px" BorderStyle="Outset">Address</asp:label>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:Label id="Label7" Width="84px" Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server"> Street</asp:Label></TD>
					<TD colspan="4">
						<asp:TextBox id="txt_street1" Width="477px" runat="server" CssClass="formfield" MaxLength="100"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD width="100">
						<asp:Label id="Label9" Width="84px" Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server">City</asp:Label></TD>
					<TD width="239" style="WIDTH: 239px">
						<asp:TextBox id="txt_city1" Width="220px" runat="server" CssClass="formfield" MaxLength="40"></asp:TextBox></TD>
					<TD width="100">
						<asp:Label id="Label11" Width="84px" Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server">P.O.Box</asp:Label></TD>
					<TD width="300">
						<asp:TextBox id="txt_pobox1" Width="75px" runat="server" CssClass="formfield" MaxLength="10"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD>
						<asp:Label id="Label10" Width="84px" Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server">State</asp:Label></TD>
					<TD style="WIDTH: 239px">
						<asp:DropDownList id="cmb_state1" Width="200px" runat="server" CssClass="formfield" BackColor="#C0C0FF" AutoPostBack="True"></asp:DropDownList></TD>
					<TD>
						<asp:Label id="Label12" Width="84px" Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server">Zip</asp:Label></TD>
					<TD>
						<asp:TextBox id="txt_zip1" Width="60px" runat="server" CssClass="formfield" MaxLength="8"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD>
						<asp:Label id="Label8" Width="84px" Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server">Country</asp:Label></TD>
					<TD style="WIDTH: 239px">
						<asp:DropDownList id="cmb_country1" Width="200px" runat="server" CssClass="formfield" BackColor="#C0C0FF" AutoPostBack="True"></asp:DropDownList></TD>
					<TD>
						<asp:Label id="Label13" Width="84px" Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server">Phone</asp:Label></TD>
					<TD>
						<asp:TextBox id="txt_phone1" Width="150px" runat="server" CssClass="formfield" MaxLength="20"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD>
						&nbsp;
					</TD>
					<TD style="WIDTH: 239px">
						&nbsp;
					</TD>
					<TD>
						<asp:Label id="Label14" Width="84px" Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server">Fax</asp:Label></TD>
					<TD>
						<asp:TextBox id="txt_fax1" Width="150px" runat="server" CssClass="formfield" MaxLength="20"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD colspan="4">
						<asp:label id="Label15" Width="137px" Font-Size="10pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" BackColor="Linen" BorderStyle="Outset" BorderWidth="1px" Font-Bold="True">Shipping Address</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:Label id="Label16" Width="84px" Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server">Street</asp:Label></TD>
					<TD colspan="3">
						<asp:TextBox id="txt_street2" Width="477px" runat="server" CssClass="formfield" MaxLength="100"></asp:TextBox>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:Label id="Label18" Width="84px" Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server">City</asp:Label></TD>
					<TD style="WIDTH: 239px">
						<asp:TextBox id="txt_city2" Width="220px" runat="server" CssClass="formfield" MaxLength="40"></asp:TextBox></TD>
					<TD>
						<asp:Label id="Label21" Width="84px" Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server">P.O.Box</asp:Label></TD>
					<TD>
						<asp:TextBox id="txt_pobox2" Width="75px" runat="server" CssClass="formfield" MaxLength="10"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD>
						<asp:Label id="Label19" Width="84px" Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server">State</asp:Label></TD>
					<TD style="WIDTH: 239px">
						<asp:DropDownList id="cmb_state2" Width="200px" runat="server" CssClass="formfield" BackColor="#C0C0FF" AutoPostBack="True"></asp:DropDownList></TD>
					<TD>
						<asp:Label id="Label22" Width="84px" Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server">Zip</asp:Label></TD>
					<TD>
						<asp:TextBox id="txt_zip2" Width="60px" runat="server" CssClass="formfield" MaxLength="8"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD>
						<asp:Label id="Label20" Width="84px" Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server">Country</asp:Label></TD>
					<TD style="WIDTH: 239px">
						<asp:DropDownList id="cmb_country2" Width="200px" runat="server" CssClass="formfield" BackColor="#C0C0FF" AutoPostBack="True"></asp:DropDownList></TD>
					<TD>
						<asp:Label id="Label23" Width="84px" Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server">Phone</asp:Label></TD>
					<TD>
						<asp:TextBox id="txt_phone2" Width="150px" runat="server" CssClass="formfield" MaxLength="20"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD style="WIDTH: 239px"></TD>
					<TD>
						<asp:Label id="Label24" Width="84px" Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server">Fax</asp:Label></TD>
					<TD>
						<asp:TextBox id="txt_fax2" Width="150px" runat="server" CssClass="formfield" MaxLength="20"></asp:TextBox></TD>
				</TR>
			</TABLE>
		</td>
	</tr>
	<TR>
		<TD colSpan="4">
			<TABLE id="tbl_business" cellSpacing="1" cellPadding="1" width="100%" border="0" style="BORDER-RIGHT: 2px groove; BORDER-TOP: 2px groove; BORDER-LEFT: 2px groove; BORDER-BOTTOM: 2px groove">
				<TR>
					<TD colspan="4">
						<asp:label id="Label25" Width="137px" Font-Size="10pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" BackColor="Linen" BorderStyle="Outset" BorderWidth="1px" Font-Bold="True">Business</asp:label>
					</TD>
				</TR>
				<TR>
					<TD width="94" style="WIDTH: 94px">
						<asp:Label id="Label26" Width="92px" Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server">Business Name</asp:Label></TD>
					<TD colspan="3">
						<asp:TextBox id="txt_businessname" Width="477px" runat="server" CssClass="formfield" MaxLength="80"></asp:TextBox>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 94px">
						<asp:Label id="Label27" Width="84px" Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server">Street</asp:Label></TD>
					<TD colspan="3">
						<asp:TextBox id="txt_streetb" Width="477px" runat="server" CssClass="formfield" MaxLength="100"></asp:TextBox>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 94px">
						<asp:Label id="Label28" Width="84px" Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server">City</asp:Label></TD>
					<TD style="WIDTH: 227px">
						<asp:TextBox id="txt_cityb" Width="220px" runat="server" CssClass="formfield" MaxLength="40"></asp:TextBox></TD>
					<TD>
						<asp:Label id="Label31" Width="84px" Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server">P.O.Box</asp:Label></TD>
					<TD>
						<asp:TextBox id="txt_poboxb" Width="75px" runat="server" CssClass="formfield" MaxLength="10"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 94px">
						<asp:Label id="Label29" Width="84px" Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server">State</asp:Label></TD>
					<TD style="WIDTH: 227px">
						<asp:DropDownList id="cmb_stateb" Width="200px" runat="server" CssClass="formfield" BackColor="#C0C0FF" AutoPostBack="True"></asp:DropDownList></TD>
					<TD>
						<asp:Label id="Label32" Width="84px" Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server">Zip</asp:Label></TD>
					<TD>
						<asp:TextBox id="txt_zipb" Width="60px" runat="server" CssClass="formfield" MaxLength="8"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 94px">
						<asp:Label id="Label30" Width="84px" Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server">Country</asp:Label></TD>
					<TD style="WIDTH: 227px">
						<asp:DropDownList id="cmb_countryb" Width="200px" runat="server" CssClass="formfield" BackColor="#C0C0FF" AutoPostBack="True"></asp:DropDownList></TD>
					<TD>
						<asp:Label id="Label33" Width="84px" Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server">Phone</asp:Label></TD>
					<TD>
						<asp:TextBox id="txt_phoneb" Width="150px" runat="server" CssClass="formfield" MaxLength="20"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 94px">&nbsp;</TD>
					<TD style="WIDTH: 227px">&nbsp;</TD>
					<TD>
						<asp:Label id="Label34" Width="84px" Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server">Fax</asp:Label></TD>
					<TD>
						<asp:TextBox id="txt_faxb" Width="150px" runat="server" CssClass="formfield" MaxLength="20"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 94px">
						<asp:Label id="Label35" Width="84px" Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server">Site URL</asp:Label></TD>
					<TD style="WIDTH: 227px" colspan="3">
						<asp:TextBox id="txt_siteurl" Width="477px" runat="server" CssClass="formfield" MaxLength="150"></asp:TextBox>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 94px">
						<asp:Label id="Label38" Width="84px" Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server">Specialization</asp:Label></TD>
					<TD style="WIDTH: 227px">
						<asp:TextBox id="txt_specialization" Width="150px" runat="server" CssClass="formfield" MaxLength="50"></asp:TextBox></TD>
					<TD>
						<asp:Label id="Label39" Width="84px" Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server">Business Type</asp:Label></TD>
					<TD>
						<asp:DropDownList id="cmb_btype" Width="150px" runat="server" CssClass="formfield">
							<asp:ListItem Value="1">-</asp:ListItem>
							<asp:ListItem Value="2">Jeweler</asp:ListItem>
							<asp:ListItem Value="3">Dealer</asp:ListItem>
							<asp:ListItem Value="4">Manufacturer</asp:ListItem>
						</asp:DropDownList></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 94px">&nbsp;</TD>
					<TD style="WIDTH: 227px">
						<asp:Label id="Label36" Width="189px" Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server">Member in trading associasions</asp:Label></TD>
					<TD>&nbsp;</TD>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 94px">&nbsp;</TD>
					<TD colspan="3">
						<asp:TextBox id="txt_memberass" Width="477px" runat="server" CssClass="formfield" MaxLength="150"></asp:TextBox>
					</TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<TR>
		<TD colSpan="4">
			<TABLE id="tbl_status" style="BORDER-RIGHT: 2px groove; BORDER-TOP: 2px groove; BORDER-LEFT: 2px groove; BORDER-BOTTOM: 2px groove" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD style="WIDTH: 332px">
						<asp:label id="Label37" Width="137px" Font-Size="10pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" BackColor="Linen" BorderStyle="Outset" BorderWidth="1px" Font-Bold="True">User status</asp:label></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 332px">
						<asp:CheckBox id="chk_isactive" runat="server" BackColor="Gainsboro" CssClass="formfield" BorderStyle="None" Text="User is Active"></asp:CheckBox></TD>
					<TD>
						<asp:CheckBox id="chk_isdeleted" runat="server" BackColor="Gainsboro" CssClass="formfield" BorderStyle="None" Text="User is Deleted"></asp:CheckBox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 332px">
						<asp:CheckBox id="chk_isdealer" runat="server" BackColor="Gainsboro" CssClass="formfield" BorderStyle="None" Text="User is Dealer"></asp:CheckBox></TD>
					<TD>
						<asp:CheckBox id="chk_ishistorical" runat="server" BackColor="Gainsboro" CssClass="formfield" BorderStyle="None" Text="Historical User" Enabled="False"></asp:CheckBox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 332px">
						<asp:CheckBox id="chk_mail_regular" runat="server" BackColor="Gainsboro" CssClass="formfield" BorderStyle="None" Text="User want's to receive regular mail"></asp:CheckBox></TD>
					<TD>
						<asp:CheckBox id="chk_mail_update" runat="server" BackColor="Gainsboro" CssClass="formfield" BorderStyle="None" Text="User want's to receive Inventory update"></asp:CheckBox></TD>
				</TR>
        <TR>
          <TD style="WIDTH: 332px">&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label id="Label43" Font-Names="verdana,arial" Font-Size="8pt" Width="104px" ForeColor="MidnightBlue" runat="server">IDEX Percentage</asp:Label><asp:TextBox id="txt_idexpercent" Width="60px" runat="server" CssClass="formfield" MaxLength="8">0</asp:TextBox></TD>
          <TD><asp:RangeValidator id="RangeValidator1" Font-Names="Verdana" Font-Size="8pt" runat="server" ControlToValidate="txt_idexpercent" ErrorMessage="IDEX percentage must be between 0 and 50" Type="Integer" MaximumValue="50" MinimumValue="0"></asp:RangeValidator></TD></TR>
			</TABLE>
		</TD>
	</TR>
	<TR>
		<TD colSpan="4" align=left>
			<TABLE id="tbl_lastmodify" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD style="WIDTH: 102px">
						<asp:TextBox id="txt_userid" Width="100px" runat="server" CssClass="formfield" BackColor="#E0E0E0" Enabled="False" ForeColor="SlateBlue"></asp:TextBox></TD>
					<TD style="WIDTH: 310px">
						<asp:TextBox id="txt_username" Width="310px" runat="server" CssClass="formfield" BackColor="Gainsboro" Enabled="False" ForeColor="SlateBlue"></asp:TextBox></TD>
					<TD>
						<asp:TextBox id="txt_datetime" Width="200px" runat="server" CssClass="formfield" BackColor="#E0E0E0" Enabled="False"></asp:TextBox></TD>
				</TR>
			</TABLE><asp:TextBox id="txt_ip" Width="200px" ForeColor="SlateBlue" runat="server" CssClass="formfield" BackColor="Gainsboro" Enabled="False"></asp:TextBox>
		</TD>
	</TR>
  <TR>
    <TD colSpan="4"></TD></TR>
	<tr bgcolor="darkslateblue">
		<td colspan="4" align="right">
			<asp:Button id="btn_sbmit" CssClass="formbutton" runat="server" Width="190px" Text="Save"></asp:Button></td>
	</tr>
</table>
