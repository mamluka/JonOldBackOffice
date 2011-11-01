<%@ Control Language="vb" AutoEventWireup="false" Codebehind="sp_jewelry.ascx.vb" Inherits="ion_admin.sp_jewelry" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<LINK href="/styles.css" type="text/css" rel="StyleSheet">
<style type="text/css">.style1 { FONT-SIZE: 11px; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
</style>
<P>
	<TABLE id="Table1" style="BORDER-RIGHT: thin ridge; BORDER-TOP: thin ridge; BORDER-LEFT: thin ridge; BORDER-BOTTOM: thin ridge; BACKGROUND-COLOR: gainsboro"
		cellSpacing="0" cellPadding="0" width="100%" border="0">
		<TR>
			<TD colSpan="1" rowSpan="1">
				<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
					<TR>
						<TD width="12%"><asp:label id="Label17" Font-Bold="True" Font-Names="verdana,arial" Font-Size="10pt" ForeColor="MidnightBlue"
								runat="server" Width="90px" BorderStyle="Outset" BorderWidth="1px" BackColor="Linen">Jewel</asp:label></TD>
						<TD width="38%"></TD>
						<TD width="16%"><asp:label id="Label7" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								runat="server" Width="90px">Related item ID</asp:label></TD>
						<TD width="34%"><asp:textbox id="txt_relateditem_id" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								runat="server" Width="45px" BackColor="#C0C0FF" CssClass="formfield" MaxLength="5" AutoPostBack="True">0</asp:textbox><asp:rangevalidator id="RangeValidator3" Font-Size="8pt" runat="server" Type="Integer" MinimumValue="0"
								MaximumValue="99999" ControlToValidate="txt_relateditem_id" ErrorMessage="***"></asp:rangevalidator></TD>
					</TR>
					<TR>
						<TD><asp:label id="Label1" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								runat="server" Width="65px">Jewel type</asp:label></TD>
						<TD><asp:dropdownlist id="cmb_jeweltype" runat="server" Width="200px" BackColor="#C0C0FF" CssClass="formfield"
								AutoPostBack="True"></asp:dropdownlist></TD>
						<TD><asp:label id="Label19" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								runat="server" Width="86px">Jewel sub-type</asp:label></TD>
						<TD><asp:dropdownlist id="cmb_jewelsubtype" runat="server" Width="200px" CssClass="formfield"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD><asp:label id="Label4" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								runat="server" Width="65px">Weight</asp:label></TD>
						<TD><asp:textbox id="txt_weight" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								runat="server" Width="90px" CssClass="formfield">0.00</asp:textbox><asp:label id="Label42" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								runat="server" Width="35px">gram</asp:label><asp:rangevalidator id="RangeValidator1" Font-Size="8pt" runat="server" Type="Double" MinimumValue="0"
								MaximumValue="999999" ControlToValidate="txt_weight" ErrorMessage="***" Display="Dynamic"></asp:rangevalidator>&nbsp;
							<asp:requiredfieldvalidator id="RequiredFieldValidator1" Font-Size="8pt" runat="server" ControlToValidate="txt_weight"
								ErrorMessage="Must Have Weight!" Display="Dynamic"></asp:requiredfieldvalidator></TD>
						<TD><asp:label id="Label10" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								runat="server" Width="65px">Size</asp:label></TD>
						<TD><asp:textbox id="txt_size" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								runat="server" Width="90px" CssClass="formfield">0.00</asp:textbox></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 10px"><asp:label id="Label2" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								runat="server" Width="71px">Metal</asp:label></TD>
						<TD style="HEIGHT: 10px"><asp:dropdownlist id="cmb_metal" runat="server" Width="200px" CssClass="formfield"></asp:dropdownlist></TD>
						<TD style="HEIGHT: 10px"><asp:label id="Label3" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								runat="server" Width="80px">Center stone</asp:label></TD>
						<TD style="HEIGHT: 10px"><asp:dropdownlist id="cmb_middlestone" runat="server" Width="200px" CssClass="formfield"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD><asp:label id="Label5" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								runat="server" Width="71px">Brand</asp:label></TD>
						<TD><asp:dropdownlist id="cmb_brand" runat="server" Width="200px" CssClass="formfield"></asp:dropdownlist></TD>
						<TD><asp:label id="Label11" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								runat="server" Width="151px" Visible="False">Center stone Description</asp:label></TD>
						<TD><asp:textbox id="txt_middlestone_desc" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								runat="server" Width="200px" CssClass="formfield" MaxLength="80" Visible="False"></asp:textbox></TD>
					</TR>
					<TR>
						<TD><asp:label id="Label8" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								runat="server" Width="71px">Setting type</asp:label></TD>
						<TD><asp:dropdownlist id="cmb_setting" runat="server" Width="200px" CssClass="formfield"></asp:dropdownlist></TD>
						<TD><asp:label id="Label6" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								runat="server" Width="80px"> Report</asp:label></TD>
						<TD><asp:dropdownlist id="cmb_report" runat="server" Width="200px" CssClass="formfield"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD><asp:label id="Label28" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								runat="server" Width="71px">Setting type</asp:label></TD>
						<TD>&nbsp;from
							<asp:textbox id="txt_bend_from" runat="server" Width="24px" CssClass="formfield"></asp:textbox>&nbsp;to
							<asp:textbox id="txt_bend_to" runat="server" Width="24px" CssClass="formfield"></asp:textbox></TD>
						<TD>&nbsp;</TD>
						<TD>&nbsp;</TD>
					</TR>
					<TR>
						<TD></TD>
						<TD>
							<asp:checkbox id="chk_default_model" Width="176px" runat="server" Font-Bold="True" CssClass="formfield"
								Visible="False" Text="Use as default model"></asp:checkbox></TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD><asp:checkbox id="chk_anniversary" runat="server" Width="115px" CssClass="formfield" Visible="False"
								Text="Anniersary"></asp:checkbox></TD>
						<TD><asp:label id="Label9" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								runat="server" Width="71px">Collection</asp:label></TD>
						<TD><asp:dropdownlist id="cmb_collection" runat="server" Width="200px" CssClass="formfield"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD><asp:checkbox id="chk_engagement" runat="server" Width="115px" CssClass="formfield" Visible="False"
								Text="Engagement"></asp:checkbox></TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD><asp:checkbox id="chk_stone_exchange" runat="server" CssClass="formfield" Text="Jewel will use Stone Exchange"></asp:checkbox><span class="style1"><br>
								Related Item id:</span>
							<asp:textbox id="txt_stone_exchange_itemid" runat="server" Width="80" CssClass="formfield" AutoPostBack="True"></asp:textbox></TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD align="left"><asp:label id="Label14" Font-Bold="True" Font-Names="verdana,arial" Font-Size="10pt" ForeColor="MidnightBlue"
								runat="server" Width="104px" BorderStyle="Outset" BorderWidth="1px" BackColor="Linen">Center Stone</asp:label></TD>
						<TD>&nbsp;</TD>
						<TD><asp:label id="Label20" Font-Bold="True" Font-Names="verdana,arial" Font-Size="10pt" ForeColor="MidnightBlue"
								runat="server" Width="96px" BorderStyle="Outset" BorderWidth="1px" BackColor="Linen">Side Stones</asp:label></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD><asp:label id="Label15" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								runat="server" Width="65px">Stone Desc</asp:label></TD>
						<TD><asp:textbox id="ext_c_desc" runat="server" CssClass="formfield"></asp:textbox></TD>
						<TD><asp:label id="Label21" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								runat="server" Width="65px">Stone Desc</asp:label></TD>
						<TD><asp:textbox id="ext_s_desc" runat="server" CssClass="formfield"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 17px"><asp:label id="Label16" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								runat="server" Width="65px">Stone Type</asp:label></TD>
						<TD style="HEIGHT: 17px"><asp:dropdownlist id="ext_c_type" runat="server" CssClass="formfield"></asp:dropdownlist></TD>
						<TD style="HEIGHT: 17px"><asp:label id="Label22" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								runat="server" Width="65px">Stone Type</asp:label></TD>
						<TD style="HEIGHT: 17px"><asp:dropdownlist id="ext_s_type" runat="server" CssClass="formfield"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD><asp:label id="Label18" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								runat="server" Width="65px">Stone Cut</asp:label><BR>
							<BR>
							<asp:label id="Label29" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								runat="server" Width="65px">Title:</asp:label><BR>
							<asp:label id="Label30" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								runat="server" Width="65px">Ebay Title:</asp:label></TD>
						<TD><asp:dropdownlist id="ext_c_cut" runat="server" CssClass="formfield"></asp:dropdownlist><BR>
							<BR>
							<asp:textbox id="txt_title" runat="server" Width="320px" CssClass="formfield" AutoPostBack="True"></asp:textbox><BR>
							<asp:textbox id="txt_ebay_title" runat="server" Width="320px" CssClass="formfield" MaxLength="55"></asp:textbox></TD>
						<TD><asp:label id="Label23" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
								runat="server" Width="65px">Stone Cut</asp:label></TD>
						<TD><asp:dropdownlist id="ext_s_cut" runat="server" CssClass="formfield"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD></TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD><asp:label id="Label27" Font-Bold="True" Font-Names="verdana,arial" Font-Size="10pt" ForeColor="MidnightBlue"
								runat="server" Width="112px" BorderStyle="Outset" BorderWidth="1px" BackColor="Linen" Visible="False">Extra Features</asp:label></TD>
						<TD>&nbsp;
							<asp:dropdownlist id="je_list" runat="server" AutoPostBack="True" Visible="False"></asp:dropdownlist></TD>
						<TD>&nbsp;</TD>
						<TD>&nbsp;</TD>
					</TR>
					<TR>
						<TD>&nbsp;</TD>
						<TD colSpan="3"><asp:panel id="je_panel" Font-Names="Verdana" Font-Size="8pt" runat="server" EnableViewState="False"></asp:panel><BR>
							&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:button id="je_update_title" runat="server" CssClass="formbutton" Text="Update Title"></asp:button></TD>
					</TR>
					<TR>
						<TD><asp:label id="Label12" Font-Bold="True" Font-Names="verdana,arial" Font-Size="10pt" ForeColor="MidnightBlue"
								runat="server" Width="90px" BorderStyle="Outset" BorderWidth="1px" BackColor="Linen">Extra</asp:label></TD>
						<TD></TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD vAlign="middle" align="center" colSpan="4" height="205">
							<!--<table cellSpacing="0" cellPadding="3" width="90%" border="0">
								<tr>
									<td vAlign="top" width="31%"><asp:dropdownlist id="extra_metal_type" Width="200px" runat="server" CssClass="formfield">
											<asp:ListItem Value="gold">gold</asp:ListItem>
											<asp:ListItem Value="platina">platina</asp:ListItem>
										</asp:dropdownlist><br>
										&nbsp;
										<br>
										<asp:button id="go_addnewmetal" Width="100px" runat="server" CssClass="formbutton" Text="Add"></asp:button></td>
									<td vAlign="top" width="69%">
										<table cellSpacing="0" cellPadding="0" width="300" border="0">
											<tr>
												<td vAlign="top" width="289"><asp:listbox id="extra_metal_list" Width="500px" runat="server" CssClass="formfield"></asp:listbox></td>
												<td vAlign="top" width="53"><asp:button id="extra_metal_edit" Width="50px" runat="server" CssClass="formbutton" Text="Edit"
														Visible="False"></asp:button><asp:button id="extra_metal_delete" Width="50px" runat="server" CssClass="formbutton" Text="Delete"></asp:button></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td vAlign="top"><asp:label id="Label13" Width="85px" runat="server" ForeColor="MidnightBlue" Font-Size="8pt"
											Font-Names="verdana,arial">Center Stone:</asp:label><asp:textbox id="extra_stone_center" Width="70px" runat="server" CssClass="formfield"></asp:textbox>&nbsp; 
										-<br>
										<asp:label id="Label24" Width="85px" runat="server" ForeColor="MidnightBlue" Font-Size="8pt"
											Font-Names="verdana,arial">Side Stones:</asp:label><asp:textbox id="extra_stone_side" Width="70px" runat="server" CssClass="formfield"></asp:textbox>&nbsp;-&nbsp;<br>
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:textbox id="extra_stone_price" Width="50px" runat="server" CssClass="formfield"></asp:textbox>$<br>
										<br>
										<asp:button id="go_addnewstone" Width="100px" runat="server" CssClass="formbutton" Text="Add"></asp:button></td>
									<td vAlign="top">
										<table cellSpacing="0" cellPadding="0" width="300" border="0">
											<tr>
												<td vAlign="top" width="250"><asp:listbox id="extra_stone_list" Width="500px" runat="server" CssClass="formfield"></asp:listbox></td>
												<td vAlign="top" width="50"><asp:button id="extra_stone_edit" Width="50px" runat="server" CssClass="formbutton" Text="Edit"></asp:button><asp:button id="extra_stone_delete" Width="50px" runat="server" CssClass="formbutton" Text="Delete"></asp:button></td>
											</tr>
										</table>
									</td>
								</tr>
							</table>--><br>
							<table cellSpacing="0" cellPadding="0" width="90%" border="0">
								<tr>
									<td style="HEIGHT: 23px"><asp:label id="Label25" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
											runat="server" Width="192px">The Metal Difference Amount:</asp:label><asp:textbox id="extra_metal_delta" runat="server" Width="96px" CssClass="formfield"></asp:textbox><asp:rangevalidator id="ext1" runat="server" Type="Integer" MinimumValue="-100000" MaximumValue="100000"
											ControlToValidate="extra_metal_delta" ErrorMessage="Must be a number" Display="Dynamic"></asp:rangevalidator>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:label id="Label26" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue"
											runat="server" Width="72px">Paste</asp:label><asp:textbox id="extra_paste" runat="server" Width="96px" CssClass="formfield" AutoPostBack="True"></asp:textbox></td>
								</tr>
								<tr>
									<td><asp:dropdownlist id="extra_schema" runat="server" CssClass="formfield" AutoPostBack="True"></asp:dropdownlist></td>
								</tr>
								<tr>
									<td>&nbsp;
										<asp:panel id="schema_controls" Font-Names="Verdana" Font-Size="8pt" ForeColor="MidnightBlue"
											runat="server" Width="750px" Height="56px"></asp:panel><asp:button id="extra_save" runat="server" CssClass="formbutton" Text="Save extra to list"></asp:button></td>
								</tr>
								<tr>
									<td><asp:listbox id="extra_list" runat="server" Width="640px" CssClass="formfield"></asp:listbox><asp:button id="extra_edit" runat="server" CssClass="formbutton" Text="Edit"></asp:button></td>
								</tr>
								<tr>
									<td><asp:button id="extra_delete" runat="server" CssClass="formbutton" Text="Delete"></asp:button></td>
								</tr>
							</table>
						</TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
	</TABLE>
</P>
<asp:label id="hid_subplate_id" runat="server" Visible="False">0</asp:label>
<asp:Label id="hid_jewel_extended_id" runat="server">0</asp:Label>
