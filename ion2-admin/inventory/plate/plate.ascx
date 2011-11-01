<%@ Control Language="vb" AutoEventWireup="false" Codebehind="plate.ascx.vb" Inherits="ion_admin.plate" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="uc1" TagName="sp_jewelry" Src="sp_jewelry.ascx" %>
<%@ Register TagPrefix="uc1" TagName="sp_gemstones" Src="sp_gemstones.ascx" %>
<%@ Register TagPrefix="uc1" TagName="sp_diamonds" Src="sp_diamonds.ascx" %>
<TABLE id="tbl_main" style="BORDER-BOTTOM: 1px outset; BORDER-LEFT: 1px outset; BACKGROUND-COLOR: gainsboro; BORDER-TOP: 1px outset; BORDER-RIGHT: 1px outset"
	cellSpacing="0" cellPadding="0" width="200" align="center" border="8" runat="server">
	<TR>
		<TD align="left" bgColor="#708090"><asp:label id="lbl_caption" runat="server" Font-Bold="True" ForeColor="Khaki" Width="404px"
				Font-Size="10pt" Font-Names="verdana,arial">Inventory</asp:label></TD>
	</TR>
	<tr>
		<td borderColor="red" align="center" bgColor="red"><asp:listbox id="lst_error" runat="server" Font-Bold="True" ForeColor="MidnightBlue" Width="99%"
				BackColor="Linen" CssClass="formfield" Visible="False"></asp:listbox></td>
	</tr>
	<TR>
		<TD>&nbsp;<asp:label id="Label62" runat="server" ForeColor="MidnightBlue" Width="152px" Font-Size="8pt"
				Font-Names="verdana,arial">Paste an inventory item</asp:label><asp:textbox id="txt_copyid" runat="server" ForeColor="MidnightBlue" Width="50px" Font-Size="8pt"
				Font-Names="verdana,arial" CssClass="formfield" AutoPostBack="True" MaxLength="12">0</asp:textbox>&nbsp;<asp:label id="lbl_copyid_message" runat="server" ForeColor="MidnightBlue" Width="200px" Font-Size="8pt"
				Font-Names="verdana,arial"></asp:label>
			<asp:CheckBox style="Z-INDEX: 0" id="chk_withpictures" runat="server" Font-Names="verdana" Font-Size="8pt"
				Text="With Pictures"></asp:CheckBox></TD>
	</TR>
	<TR>
		<TD height="10"></TD>
	</TR>
	<TR>
		<TD><asp:label id="Label3" runat="server" Font-Bold="True" ForeColor="MidnightBlue" Width="100px"
				Font-Size="10pt" Font-Names="verdana,arial" BackColor="Linen" BorderStyle="Outset" BorderWidth="1px">Supplier</asp:label><BR>
			<table id="tbl_supplier" width="100%" border="0">
				<TR>
					<TD width="104" height="8"><asp:label id="Label4" runat="server" ForeColor="MidnightBlue" Width="65px" Font-Size="8pt"
							Font-Names="verdana,arial">Supplier</asp:label></TD>
					<TD width="175" height="8"><asp:dropdownlist id="cmb_supplier" runat="server" ForeColor="MidnightBlue" Width="253px" Font-Size="8pt"
							Font-Names="verdana,arial" CssClass="form_field"></asp:dropdownlist></TD>
					<TD width="85" height="8"><asp:label id="Label41" runat="server" ForeColor="MidnightBlue" Width="80px" Font-Size="8pt"
							Font-Names="verdana,arial">Item number</asp:label></TD>
					<TD width="175" height="8"><asp:textbox id="txt_itemnumber" runat="server" Font-Bold="True" ForeColor="MidnightBlue" Width="170px"
							Font-Size="9pt" Font-Names="verdana,arial" BackColor="Linen" BorderStyle="Outset" BorderWidth="1px" Enabled="False"></asp:textbox></TD>
				</TR>
				<TR>
					<TD width="104" height="17"></TD>
					<TD width="169" height="17"></TD>
					<TD width="115" height="17"><asp:label id="labael" runat="server" ForeColor="MidnightBlue" Width="80px" Font-Size="8pt"
							Font-Names="verdana,arial">Branch</asp:label></TD>
					<TD height="17"><asp:textbox id="txt_branch" runat="server" Font-Bold="True" ForeColor="MidnightBlue" Width="170px"
							Font-Size="9pt" Font-Names="verdana,arial" BackColor="Linen" BorderStyle="Outset" BorderWidth="1px" Enabled="False"></asp:textbox></TD>
				</TR>
				<TR>
					<TD width="104" height="17"><asp:label id="Label9" runat="server" ForeColor="MidnightBlue" Width="102px" Font-Size="8pt"
							Font-Names="verdana,arial">Physical Location</asp:label></TD>
					<TD width="169" height="17"><asp:dropdownlist id="cmb_location" runat="server" ForeColor="MidnightBlue" Width="170px" Font-Size="8pt"
							Font-Names="verdana,arial" CssClass="formfield"></asp:dropdownlist></TD>
					<TD width="115" height="17"><asp:label id="Label6" runat="server" ForeColor="MidnightBlue" Width="80px" Font-Size="8pt"
							Font-Names="verdana,arial">Supplier code</asp:label></TD>
					<TD height="17"><asp:textbox id="txt_supplier_code" runat="server" ForeColor="MidnightBlue" Width="170px" Font-Size="8pt"
							Font-Names="verdana,arial" CssClass="formfield" MaxLength="20"></asp:textbox></TD>
				</TR>
			</table>
		</TD>
	</TR>
	<TR>
		<TD><asp:label id="Label5" runat="server" Font-Bold="True" ForeColor="MidnightBlue" Width="100px"
				Font-Size="10pt" Font-Names="verdana,arial" BackColor="Linen" BorderStyle="Outset" BorderWidth="1px">Category</asp:label>
			<table id="tbl_category" width="100%" border="0">
				<TR>
					<TD width="94" height="15"><asp:label id="Label8" runat="server" ForeColor="MidnightBlue" Width="65px" Font-Size="8pt"
							Font-Names="verdana,arial">Category</asp:label></TD>
					<TD width="199" height="15"><asp:dropdownlist id="cmb_category" runat="server" ForeColor="MidnightBlue" Width="170px" Font-Size="8pt"
							Font-Names="verdana,arial" BackColor="#C0C0FF" CssClass="formfield" AutoPostBack="True"></asp:dropdownlist></TD>
					<TD width="130" height="15"><asp:label id="Label12" runat="server" ForeColor="MidnightBlue" Width="80px" Font-Size="8pt"
							Font-Names="verdana,arial">Sub-Category</asp:label></TD>
					<TD height="15"><asp:dropdownlist id="cmb_subcategory" runat="server" ForeColor="MidnightBlue" Width="170px" Font-Size="8pt"
							Font-Names="verdana,arial" CssClass="formfield"></asp:dropdownlist></TD>
				</TR>
			</table>
		</TD>
	</TR>
	<TR>
		<TD><asp:label id="Label15" runat="server" Font-Bold="True" ForeColor="MidnightBlue" Width="100px"
				Font-Size="10pt" Font-Names="verdana,arial" BackColor="Linen" BorderStyle="Outset" BorderWidth="1px">Prices</asp:label>
			<table id="tbl_prices" width="100%" border="0">
				<TR>
					<TD width="110"><asp:label id="Label20" runat="server" ForeColor="MidnightBlue" Width="84px" Font-Size="8pt"
							Font-Names="verdana,arial">Purchase price</asp:label></TD>
					<TD width="190"><asp:textbox id="txt_purchase_price" runat="server" ForeColor="MidnightBlue" Width="100px" Font-Size="8pt"
							Font-Names="verdana,arial" BackColor="#C0C0FF" CssClass="formfield" AutoPostBack="True" MaxLength="12">0.00</asp:textbox><asp:label id="Label42" runat="server" ForeColor="MidnightBlue" Width="30px" Font-Size="8pt"
							Font-Names="verdana,arial">$us</asp:label><asp:rangevalidator id="RangeValidator1" runat="server" Font-Size="8pt" ControlToValidate="txt_purchase_price"
							ErrorMessage="&amp;times;" MaximumValue="10000000" MinimumValue="0" Type="Currency"></asp:rangevalidator></TD>
					<TD width="120"><asp:label id="Label19" runat="server" ForeColor="MidnightBlue" Width="84px" Font-Size="8pt"
							Font-Names="verdana,arial">Sell price</asp:label></TD>
					<TD width="190"><asp:textbox id="txt_sell_price" runat="server" ForeColor="MidnightBlue" Width="100px" Font-Size="8pt"
							Font-Names="verdana,arial" CssClass="formfield" MaxLength="12">0.00</asp:textbox><asp:label id="Label44" runat="server" ForeColor="MidnightBlue" Width="30px" Font-Size="8pt"
							Font-Names="verdana,arial">$us</asp:label><asp:rangevalidator id="RangeValidator3" runat="server" Font-Size="8pt" ControlToValidate="txt_sell_price"
							ErrorMessage="&amp;times;" MaximumValue="10000000" MinimumValue="0" Type="Currency"></asp:rangevalidator></TD>
				</TR>
				<TR>
					<TD width="110"><asp:label id="Label18" runat="server" ForeColor="MidnightBlue" Width="84px" Font-Size="8pt"
							Font-Names="verdana,arial">Dealer price</asp:label></TD>
					<TD width="190"><asp:textbox id="txt_dealer_price" runat="server" ForeColor="MidnightBlue" Width="100px" Font-Size="8pt"
							Font-Names="verdana,arial" CssClass="formfield" MaxLength="12">0.00</asp:textbox><asp:label id="Label43" runat="server" ForeColor="MidnightBlue" Width="30px" Font-Size="8pt"
							Font-Names="verdana,arial">$us</asp:label><asp:rangevalidator id="RangeValidator2" runat="server" Font-Size="8pt" ControlToValidate="txt_dealer_price"
							ErrorMessage="&amp;times;" MaximumValue="10000000" MinimumValue="0" Type="Currency"></asp:rangevalidator></TD>
					<TD width="120"><asp:label id="Label17" runat="server" ForeColor="MidnightBlue" Width="92px" Font-Size="8pt"
							Font-Names="verdana,arial">Appraisal price</asp:label></TD>
					<TD width="190"><asp:textbox id="txt_appraisal_price" runat="server" ForeColor="MidnightBlue" Width="100px" Font-Size="8pt"
							Font-Names="verdana,arial" CssClass="formfield" MaxLength="12">0.00</asp:textbox><asp:label id="Label45" runat="server" ForeColor="MidnightBlue" Width="30px" Font-Size="8pt"
							Font-Names="verdana,arial">$us</asp:label><asp:rangevalidator id="RangeValidator4" runat="server" Font-Size="8pt" ControlToValidate="txt_appraisal_price"
							ErrorMessage="&amp;times;" MaximumValue="10000000" MinimumValue="0" Type="Currency"></asp:rangevalidator></TD>
				</TR>
			</table>
		</TD>
	</TR>
	<TR>
		<TD><asp:label id="Label53" runat="server" Font-Bold="True" ForeColor="MidnightBlue" Width="100px"
				Font-Size="10pt" Font-Names="verdana,arial" BackColor="Linen" BorderStyle="Outset" BorderWidth="1px">Specials</asp:label>
			<TABLE id="Table2" width="100%" border="0">
				<TR>
					<TD style="WIDTH: 133px; HEIGHT: 28px" width="133"><asp:label id="Label13" runat="server" ForeColor="MidnightBlue" Width="120px" Font-Size="8pt"
							Font-Names="verdana,arial">Item in Specials</asp:label></TD>
					<TD style="HEIGHT: 28px" width="190"><asp:checkbox id="chk_item_special" runat="server" BackColor="#C0C0FF" AutoPostBack="True"></asp:checkbox></TD>
					<TD style="HEIGHT: 28px" width="120" colSpan="2">
                        <asp:rangevalidator id="vld_date_to" runat="server" Width="264px" 
                            Font-Size="8pt" Font-Names="verdana,arial"
							ControlToValidate="txt_special_to_date" ErrorMessage="TO date cannot be before FROM date" 
                            Type="Date" Enabled="False"></asp:rangevalidator>
                        <asp:rangevalidator id="vld_date_from" runat="server" Width="264px" 
                            Font-Size="8pt" Font-Names="verdana,arial"
							ControlToValidate="txt_special_from_date" ErrorMessage="FROM date cannot be before TODAY" 
                            Type="Date" Enabled="False"></asp:rangevalidator></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 133px" width="133"><asp:label id="Label59" runat="server" ForeColor="MidnightBlue" Width="104px" Font-Size="8pt"
							Font-Names="verdana,arial">Special From date</asp:label></TD>
					<TD width="190">
						<table cellSpacing="1" cellPadding="1" border="0">
							<tr>
								<td vAlign="top"><asp:textbox id="txt_special_from_date" runat="server" ForeColor="MidnightBlue" Width="80px"
										Font-Size="8pt" Font-Names="verdana,arial" BackColor="Silver" CssClass="formfield" MaxLength="10" ReadOnly="True"></asp:textbox></td>
								<td vAlign="bottom">
									<%If Request.QueryString("mode") = 1%>
									<asp:hyperlink id="hyp_orderdate" runat="server" CssClass="no" BorderStyle="None" ImageUrl="/pic/calendar.gif"
										NavigateUrl="javascript:calendar_window=window.open('/calendar.aspx?mode=1&amp;formname=Form1.uc_Plate1_txt_special_from_date','calendar_window','width=242,height=172');calendar_window.focus()"
										backColor="LightSteelBlue">HyperLink</asp:hyperlink>
									<%Else%>
									<asp:hyperlink id="Hyperlink2" runat="server" CssClass="no" BorderStyle="None" ImageUrl="/pic/calendar.gif"
										NavigateUrl="javascript:calendar_window=window.open('/calendar.aspx?mode=1&amp;formname=Form1.Plate1_txt_special_from_date','calendar_window','width=242,height=172');calendar_window.focus()"
										backColor="LightSteelBlue">HyperLink</asp:hyperlink>
									<%End If%>
								</td>
							</tr>
						</table>
					</TD>
					<TD width="120"><asp:label id="Label58" runat="server" ForeColor="MidnightBlue" Width="104px" Font-Size="8pt"
							Font-Names="verdana,arial">Special to date</asp:label></TD>
					<TD width="190">
						<table cellSpacing="1" cellPadding="1" border="0">
							<tr>
								<td vAlign="top"><asp:textbox id="txt_special_to_date" runat="server" ForeColor="MidnightBlue" Width="80px" Font-Size="8pt"
										Font-Names="verdana,arial" BackColor="Silver" CssClass="formfield" MaxLength="10" ReadOnly="True"></asp:textbox></td>
								<td vAlign="bottom">
									<%If Request.QueryString("mode") = 1%>
									<asp:hyperlink id="Hyperlink1" runat="server" CssClass="no" BorderStyle="None" ImageUrl="/pic/calendar.gif"
										NavigateUrl="javascript:calendar_window=window.open('/calendar.aspx?mode=1&amp;formname=Form1.uc_Plate1_txt_special_to_date','calendar_window','width=242,height=172');calendar_window.focus()"
										backColor="LightSteelBlue">HyperLink</asp:hyperlink>
									<%Else%>
									<asp:hyperlink id="Hyperlink3" runat="server" CssClass="no" BorderStyle="None" ImageUrl="/pic/calendar.gif"
										NavigateUrl="javascript:calendar_window=window.open('/calendar.aspx?mode=1&amp;formname=Form1.Plate1_txt_special_to_date','calendar_window','width=242,height=172');calendar_window.focus()"
										backColor="LightSteelBlue">HyperLink</asp:hyperlink>
									<%End If%>
								</td>
								<TD vAlign="top"><asp:textbox id="txt_specialdays" runat="server" ForeColor="MidnightBlue" Width="55px" Font-Size="8pt"
										Font-Names="verdana,arial" BackColor="Silver" CssClass="formfield" MaxLength="10" ReadOnly="True"></asp:textbox></TD>
							</tr>
						</table>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 133px; HEIGHT: 63px" vAlign="top" width="133"><asp:label id="Label57" runat="server" ForeColor="MidnightBlue" Width="104px" Font-Size="8pt"
							Font-Names="verdana,arial">Special sell price</asp:label></TD>
					<TD style="HEIGHT: 63px" vAlign="top" width="190"><asp:textbox id="txt_special_sell_price" runat="server" ForeColor="MidnightBlue" Width="100px"
							Font-Size="8pt" Font-Names="verdana,arial" CssClass="formfield" MaxLength="12">0.00</asp:textbox><asp:label id="Label56" runat="server" ForeColor="MidnightBlue" Width="30px" Font-Size="8pt"
							Font-Names="verdana,arial">$us</asp:label><asp:rangevalidator id="RangeValidator10" runat="server" Font-Size="8pt" ControlToValidate="txt_special_sell_price"
							ErrorMessage="&amp;times;" MaximumValue="1000000" MinimumValue="0" Type="Currency"></asp:rangevalidator></TD>
					<TD style="HEIGHT: 63px" vAlign="top" width="120"><asp:label id="Label55" runat="server" ForeColor="MidnightBlue" Width="120px" Font-Size="8pt"
							Font-Names="verdana,arial">Special dealer price</asp:label></TD>
					<TD style="HEIGHT: 63px" vAlign="top" width="190"><asp:textbox id="txt_special_dealer_price" runat="server" ForeColor="MidnightBlue" Width="100px"
							Font-Size="8pt" Font-Names="verdana,arial" CssClass="formfield" MaxLength="12">0.00</asp:textbox><asp:label id="Label54" runat="server" ForeColor="MidnightBlue" Width="30px" Font-Size="8pt"
							Font-Names="verdana,arial">$us</asp:label><asp:rangevalidator id="RangeValidator9" runat="server" Font-Size="8pt" ControlToValidate="txt_special_dealer_price"
							ErrorMessage="&amp;times;" MaximumValue="1000000" MinimumValue="0" Type="Currency"></asp:rangevalidator></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 133px; HEIGHT: 15px"><asp:label id="Label64" runat="server" Font-Bold="True" ForeColor="MidnightBlue" Width="100px"
							Font-Size="10pt" Font-Names="verdana,arial" BackColor="Linen" BorderStyle="Outset" BorderWidth="1px">Auction</asp:label></TD>
					<TD style="HEIGHT: 15px"><asp:label id="Label36" runat="server" ForeColor="MidnightBlue" Width="120px" Font-Size="8pt"
							Font-Names="verdana,arial">Place on auction</asp:label><asp:checkbox id="chk_on_local_auction" runat="server"></asp:checkbox></TD>
					<TD style="HEIGHT: 15px">&nbsp;</TD>
					<TD style="HEIGHT: 15px">&nbsp;</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 133px"><asp:label id="Label65" runat="server" ForeColor="MidnightBlue" Width="104px" Font-Size="8pt"
							Font-Names="verdana,arial">Minimum bid price</asp:label></TD>
					<TD><asp:textbox id="txt_auction_minbid" runat="server" ForeColor="MidnightBlue" Width="100px" Font-Size="8pt"
							Font-Names="verdana,arial" CssClass="formfield" MaxLength="12"></asp:textbox></TD>
					<TD><asp:label id="Label66" runat="server" ForeColor="MidnightBlue" Width="104px" Font-Size="8pt"
							Font-Names="verdana,arial">Release date</asp:label></TD>
					<TD><asp:textbox id="txt_auction_release" runat="server" ForeColor="MidnightBlue" Width="100px" Font-Size="8pt"
							Font-Names="verdana,arial" CssClass="formfield" MaxLength="12"></asp:textbox><asp:hyperlink id="Hyperlink5" runat="server" CssClass="no" BorderStyle="None" ImageUrl="/pic/calendar.gif"
							NavigateUrl="javascript:calendar_window=window.open('/calendar.aspx?mode=1&amp;formname=Form1.Plate1_txt_auction_release','calendar_window','width=242,height=172');calendar_window.focus()"
							backColor="LightSteelBlue">HyperLink</asp:hyperlink></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<TR>
		<TD><asp:label id="Label10" runat="server" Font-Bold="True" ForeColor="MidnightBlue" Width="140px"
				Font-Size="10pt" Font-Names="verdana,arial" BackColor="Linen" BorderStyle="Outset" BorderWidth="1px">Inventory control</asp:label>
			<table id="tbl_inventory" width="100%" border="0">
				<TR>
					<TD width="120"><asp:label id="Label22" runat="server" ForeColor="MidnightBlue" Width="108px" Font-Size="8pt"
							Font-Names="verdana,arial">Currently on stock</asp:label></TD>
					<TD><asp:textbox id="txt_stock_curr" runat="server" ForeColor="MidnightBlue" Width="100px" Font-Size="8pt"
							Font-Names="verdana,arial" CssClass="formfield" MaxLength="5" Enabled="False"></asp:textbox><asp:label id="Label49" runat="server" ForeColor="MidnightBlue" Width="35px" Font-Size="8pt"
							Font-Names="verdana,arial">pcs.</asp:label><asp:rangevalidator id="RangeValidator8" runat="server" Font-Size="8pt" ControlToValidate="txt_stock_curr"
							ErrorMessage="&amp;times;" MaximumValue="99999" MinimumValue="0" Type="Integer"></asp:rangevalidator></TD>
					<TD><asp:label id="Label23" runat="server" ForeColor="MidnightBlue" Width="105px" Font-Size="8pt"
							Font-Names="verdana,arial">Minimum on stock</asp:label></TD>
					<TD width="205"><asp:textbox id="txt_stock_min" runat="server" ForeColor="MidnightBlue" Width="100px" Font-Size="8pt"
							Font-Names="verdana,arial" CssClass="formfield" MaxLength="5" Enabled="False"></asp:textbox><asp:label id="Label50" runat="server" ForeColor="MidnightBlue" Width="35px" Font-Size="8pt"
							Font-Names="verdana,arial">pcs.</asp:label><asp:rangevalidator id="RangeValidator7" runat="server" Font-Size="8pt" ControlToValidate="txt_stock_min"
							ErrorMessage="&amp;times;" MaximumValue="99999" MinimumValue="0" Type="Integer"></asp:rangevalidator></TD>
				</TR>
			</table>
		</TD>
	</TR>
	<TR>
		<TD><asp:label id="Label28" runat="server" Font-Bold="True" ForeColor="MidnightBlue" Width="100px"
				Font-Size="10pt" Font-Names="verdana,arial" BackColor="Linen" BorderStyle="Outset" BorderWidth="1px">Item status</asp:label>
			<table id="tbl_status" width="100%" border="0">
				<TR>
					<TD width="178"><asp:label id="Label33" runat="server" ForeColor="MidnightBlue" Width="108px" Font-Size="8pt"
							Font-Names="verdana,arial">Active in shop</asp:label></TD>
					<TD width="67"><asp:checkbox id="chk_active_in_shop" runat="server"></asp:checkbox></TD>
					<TD width="130"><asp:label id="Label14" runat="server" ForeColor="MidnightBlue" Width="105px" Font-Size="8pt"
							Font-Names="verdana,arial">Status</asp:label></TD>
					<TD width="205"><asp:dropdownlist id="cmb_status" runat="server" ForeColor="MidnightBlue" Width="139px" Font-Size="8pt"
							Font-Names="verdana,arial" CssClass="formfield"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD width="178"><asp:label id="Label35" runat="server" ForeColor="MidnightBlue" Width="151px" Font-Size="8pt"
							Font-Names="verdana,arial">Cannot be ordered alone</asp:label></TD>
					<TD width="67"><asp:checkbox id="chk_cannot_be_ordered_alone" runat="server" Width="100px"></asp:checkbox></TD>
					<TD width="130"><asp:label id="Label34" runat="server" ForeColor="MidnightBlue" Width="105px" Font-Size="8pt"
							Font-Names="verdana,arial">Deleted</asp:label></TD>
					<TD width="205"><asp:checkbox id="chk_deleted" runat="server"></asp:checkbox></TD>
				</TR>
				<TR>
					<TD width="178"><asp:label id="Label37" runat="server" ForeColor="MidnightBlue" Width="179px" Font-Size="8pt"
							Font-Names="verdana,arial">Cannot apear in public auction</asp:label></TD>
					<TD width="67"><asp:checkbox id="chk_not_in_public_auction" runat="server"></asp:checkbox></TD>
					<TD width="130"><asp:label id="Label67" runat="server" ForeColor="MidnightBlue" Width="105px" Font-Size="8pt"
							Font-Names="verdana,arial">Bargain</asp:label></TD>
					<TD width="205"><asp:checkbox id="chk_bargain" runat="server"></asp:checkbox></TD>
				</TR>
				<TR>
					<TD width="178"><asp:label id="Label16" runat="server" ForeColor="MidnightBlue" Width="179px" Font-Size="8pt"
							Font-Names="verdana,arial">Club 'Style' Item</asp:label></TD>
					<TD width="67"><asp:checkbox id="chk_clubitem" runat="server"></asp:checkbox></TD>
					<TD width="130"><asp:label id="Label38" runat="server" ForeColor="MidnightBlue" Width="105px" Font-Size="8pt"
							Font-Names="verdana,arial">In process</asp:label></TD>
					<TD width="205"><asp:checkbox id="chk_in_process" runat="server"></asp:checkbox></TD>
				</TR>
				<TR>
					<TD width="178"><asp:label id="Label39" runat="server" ForeColor="MidnightBlue" Width="179px" Font-Size="8pt"
							Font-Names="verdana,arial">Item sold</asp:label></TD>
					<TD width="66"><asp:checkbox id="chk_itemsold" runat="server"></asp:checkbox></TD>
					<TD width="130"><asp:label id="Label51" runat="server" ForeColor="MidnightBlue" Width="105px" Font-Size="8pt"
							Font-Names="verdana,arial">Autogenerated</asp:label><asp:label id="Label40" runat="server" ForeColor="MidnightBlue" Width="105px" Font-Size="8pt"
							Font-Names="verdana,arial">&nbsp</asp:label></TD>
					<TD width="205"><asp:checkbox id="chk_autogenerated" runat="server"></asp:checkbox></TD>
				</TR>
				<TR>
					<TD><asp:label id="Label68" runat="server" ForeColor="MidnightBlue" Width="179px" Font-Size="8pt"
							Font-Names="verdana,arial">Sample Pic</asp:label></TD>
					<TD><asp:checkbox id="chk_samplepic" runat="server"></asp:checkbox></TD>
					<TD><asp:label id="Label69" runat="server" ForeColor="MidnightBlue" Width="105px" Font-Size="8pt"
							Font-Names="verdana,arial">Week Featured</asp:label></TD>
					<TD><asp:checkbox id="chk_featured" runat="server"></asp:checkbox></TD>
				</TR>
				<TR>
					<TD><asp:label id="Label70" runat="server" ForeColor="MidnightBlue" Width="179px" Font-Size="8pt"
							Font-Names="verdana,arial"> Extra open</asp:label></TD>
					<TD><asp:checkbox id="chk_extraopen" runat="server"></asp:checkbox></TD>
					<TD><asp:label id="Label71" runat="server" ForeColor="MidnightBlue" Width="105px" Font-Size="8pt"
							Font-Names="verdana,arial">Payments</asp:label></TD>
					<TD><asp:dropdownlist id="cmb_payments" runat="server">
							<asp:ListItem Value="0">No Payments</asp:ListItem>
							<asp:ListItem Value="3">3</asp:ListItem>
							<asp:ListItem Value="5">5</asp:ListItem>
							<asp:ListItem Value="10">10</asp:ListItem>
							<asp:ListItem Value="12">12</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD><asp:label id="Label72" runat="server" ForeColor="MidnightBlue" Width="179px" Font-Size="8pt"
							Font-Names="verdana,arial">Best offer</asp:label></TD>
					<TD><asp:checkbox id="chk_bestoffer" runat="server"></asp:checkbox></TD>
					<TD></TD>
					<TD></TD>
				</TR>
			</table>
		</TD>
	</TR>
	<TR>
		<TD>
			<P><asp:label id="Label11" runat="server" Font-Bold="True" ForeColor="MidnightBlue" Width="100px"
					Font-Size="10pt" Font-Names="verdana,arial" BackColor="Linen" BorderStyle="Outset" BorderWidth="1px">Description</asp:label>
				<TABLE id="tbl_description" cellSpacing="1" cellPadding="1" width="100%" border="0">
					<TR>
						<TD align="left"><asp:label id="Label24" runat="server" ForeColor="MidnightBlue" Width="70px" Font-Size="8pt"
								Font-Names="verdana,arial">Language 1</asp:label></TD>
						<TD align="left"><asp:dropdownlist id="cmb_language1" runat="server" ForeColor="MidnightBlue" Width="140px" Font-Size="8pt"
								Font-Names="verdana,arial" BackColor="#C0C0FF" CssClass="formfield" AutoPostBack="True"></asp:dropdownlist></TD>
						<TD align="left"><asp:textbox id="txt_language1" runat="server" ForeColor="MidnightBlue" Width="420px" Font-Size="8pt"
								Font-Names="verdana,arial" CssClass="formfield"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left"><asp:label id="Label25" runat="server" ForeColor="MidnightBlue" Width="70px" Font-Size="8pt"
								Font-Names="verdana,arial">Language 2</asp:label></TD>
						<TD align="left"><asp:dropdownlist id="cmb_language2" runat="server" ForeColor="MidnightBlue" Width="140px" Font-Size="8pt"
								Font-Names="verdana,arial" BackColor="#C0C0FF" CssClass="formfield" AutoPostBack="True"></asp:dropdownlist></TD>
						<TD align="left"><asp:textbox id="txt_language2" runat="server" ForeColor="MidnightBlue" Width="420px" Font-Size="8pt"
								Font-Names="verdana,arial" CssClass="formfield"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left"><asp:label id="Label26" runat="server" ForeColor="MidnightBlue" Width="70px" Font-Size="8pt"
								Font-Names="verdana,arial">Language 3</asp:label></TD>
						<TD align="left"><asp:dropdownlist id="cmb_language3" runat="server" ForeColor="MidnightBlue" Width="140px" Font-Size="8pt"
								Font-Names="verdana,arial" BackColor="#C0C0FF" CssClass="formfield" AutoPostBack="True"></asp:dropdownlist></TD>
						<TD align="left"><asp:textbox id="txt_language3" runat="server" ForeColor="MidnightBlue" Width="420px" Font-Size="8pt"
								Font-Names="verdana,arial" CssClass="formfield"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left"><asp:label id="Label27" runat="server" ForeColor="MidnightBlue" Width="70px" Font-Size="8pt"
								Font-Names="verdana,arial">Language 4</asp:label></TD>
						<TD align="left"><asp:dropdownlist id="cmb_language4" runat="server" ForeColor="MidnightBlue" Width="140px" Font-Size="8pt"
								Font-Names="verdana,arial" BackColor="#C0C0FF" CssClass="formfield" AutoPostBack="True"></asp:dropdownlist></TD>
						<TD align="left"><asp:textbox id="txt_language4" runat="server" ForeColor="MidnightBlue" Width="420px" Font-Size="8pt"
								Font-Names="verdana,arial" CssClass="formfield"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left"><asp:label id="Label29" runat="server" ForeColor="MidnightBlue" Width="70px" Font-Size="8pt"
								Font-Names="verdana,arial">Language 5</asp:label></TD>
						<TD align="left"><asp:dropdownlist id="cmb_language5" runat="server" ForeColor="MidnightBlue" Width="140px" Font-Size="8pt"
								Font-Names="verdana,arial" BackColor="#C0C0FF" CssClass="formfield" AutoPostBack="True"></asp:dropdownlist></TD>
						<TD align="left"><asp:textbox id="txt_language5" runat="server" ForeColor="MidnightBlue" Width="420px" Font-Size="8pt"
								Font-Names="verdana,arial" CssClass="formfield"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="left"><asp:label id="Label30" runat="server" ForeColor="MidnightBlue" Width="70px" Font-Size="8pt"
								Font-Names="verdana,arial">Language 6</asp:label></TD>
						<TD align="left"><asp:dropdownlist id="cmb_language6" runat="server" ForeColor="MidnightBlue" Width="140px" Font-Size="8pt"
								Font-Names="verdana,arial" BackColor="#C0C0FF" CssClass="formfield" AutoPostBack="True"></asp:dropdownlist></TD>
						<TD align="left"><asp:textbox id="txt_language6" runat="server" ForeColor="MidnightBlue" Width="420px" Font-Size="8pt"
								Font-Names="verdana,arial" CssClass="formfield"></asp:textbox></TD>
					</TR>
				</TABLE>
			</P>
		</TD>
	</TR>
	<TR>
		<TD><asp:label id="Label63" runat="server" Font-Bold="True" ForeColor="MidnightBlue" Width="144px"
				Font-Size="10pt" Font-Names="verdana,arial" BackColor="Linen" BorderStyle="Outset" BorderWidth="1px">Smart Sort String</asp:label><BR>
			<asp:textbox id="smartsort_text" runat="server" ForeColor="MidnightBlue" Width="432px" Font-Size="8pt"
				Font-Names="verdana,arial" CssClass="formfield"></asp:textbox>&nbsp;
			<asp:dropdownlist id="smartsort_combo" runat="server" Font-Bold="True" Width="200px" Font-Size="8pt"
				BackColor="#C0C0FF" CssClass="formfield" AutoPostBack="true">
				<asp:ListItem Value="unheated middlestone">unheated middlestone</asp:ListItem>
				<asp:ListItem Value="collector">collector</asp:ListItem>
			</asp:dropdownlist></TD>
	</TR>
	<TR>
		<TD><asp:label id="Label1" runat="server" Font-Bold="True" ForeColor="MidnightBlue" Width="100px"
				Font-Size="10pt" Font-Names="verdana,arial" BackColor="Linen" BorderStyle="Outset" BorderWidth="1px">Index words</asp:label><BR>
			<asp:textbox id="txt_indexwords" runat="server" ForeColor="MidnightBlue" Width="645px" Font-Size="8pt"
				Font-Names="verdana,arial" CssClass="formfield"></asp:textbox></TD>
	</TR>
	<TR>
		<TD><asp:label id="Label61" runat="server" Font-Bold="True" ForeColor="MidnightBlue" Width="100px"
				Font-Size="10pt" Font-Names="verdana,arial" BackColor="Linen" BorderStyle="Outset" BorderWidth="1px">Similar items</asp:label><BR>
			<asp:textbox id="txt_similaritems" runat="server" ForeColor="MidnightBlue" Width="645px" Font-Size="8pt"
				Font-Names="verdana,arial" CssClass="formfield"></asp:textbox></TD>
	</TR>
	<TR>
		<TD><asp:label id="Label7" runat="server" Font-Bold="True" ForeColor="MidnightBlue" Width="100px"
				Font-Size="10pt" Font-Names="verdana,arial" BackColor="Linen" BorderStyle="Outset" BorderWidth="1px">Remarks</asp:label><BR>
			<asp:textbox id="txt_remarks" runat="server" ForeColor="MidnightBlue" Width="645px" Font-Size="8pt"
				Font-Names="verdana,arial" CssClass="formfield" Height="77px" TextMode="MultiLine"></asp:textbox></TD>
	</TR>
	<TR>
		<TD><asp:label id="Label2" runat="server" Font-Bold="True" ForeColor="MidnightBlue" Width="100px"
				Font-Size="10pt" Font-Names="verdana,arial" BackColor="Linen" BorderStyle="Outset" BorderWidth="1px">Files</asp:label><BR>
				<asp:label id="Label603" runat="server" Font-Bold="True" 
				ForeColor="MidnightBlue" Width="100px"
				Font-Size="10pt" Font-Names="verdana,arial" BackColor="Linen" BorderStyle="Outset" 
				BorderWidth="1px">Yellow Gold</asp:label>&nbsp;<TABLE id="tbl_files" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD><asp:label id="Label31" runat="server" ForeColor="MidnightBlue" Width="80px" Font-Size="8pt"
							Font-Names="verdana,arial">Picture</asp:label></TD>
					<TD><asp:textbox id="txt_hdn_picture_yg" runat="server" ForeColor="MidnightBlue" Width="122px" Font-Size="8pt"
							Font-Names="verdana,arial" CssClass="formfield" MaxLength="5" Enabled="False"></asp:textbox></TD>
					<TD><INPUT id="txt_file_picture" style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; BACKGROUND-COLOR: ghostwhite; WIDTH: 312px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove"
							type="file" onchange="FillInFilesInfo()" size="32" name="File1" runat="server">
						<INPUT id="btn_file_picture_delete" style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; WIDTH: 50px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove"
							type="button" value="delete" runat="server"> <INPUT id=btn_file_picture_view style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; WIDTH: 50px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove" onclick="javascript:viewpicture('<%=cPictureFileURL%>')" type=button value=view>
					</TD>
				</TR>
				<TR>
					<TD><asp:label id="Label32" runat="server" ForeColor="MidnightBlue" Width="80px" Font-Size="8pt"
							Font-Names="verdana,arial">Picture HiRes</asp:label></TD>
					<TD><asp:textbox id="txt_hdn_hrpicture_yg" runat="server" ForeColor="MidnightBlue" Width="122px" Font-Size="8pt"
							Font-Names="verdana,arial" CssClass="formfield" MaxLength="5" Enabled="False"></asp:textbox></TD>
					<TD><INPUT id="txt_file_hrpicture" style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; BACKGROUND-COLOR: ghostwhite; WIDTH: 312px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove"
							type="file" size="32" name="File1" runat="server"> <INPUT id="btn_file_hrpicture_delete" style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; WIDTH: 50px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove"
							type="button" value="delete" name="Button1" runat="server"> <INPUT id=btn_file_hrpicture_view style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; WIDTH: 50px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove" onclick="javascript:viewpicture('<%=cHrPictureFileURL%>')" type=button value=view name=Button2>
					</TD>
				</TR>
				<TR>
					<TD><asp:label id="Label46" runat="server" ForeColor="MidnightBlue" Width="80px" Font-Size="8pt"
							Font-Names="verdana,arial">Icon</asp:label></TD>
					<TD><asp:textbox id="txt_hdn_icon_yg" runat="server" ForeColor="MidnightBlue" Width="122px" Font-Size="8pt"
							Font-Names="verdana,arial" CssClass="formfield" MaxLength="5" Enabled="False"></asp:textbox></TD>
					<TD><INPUT id="txt_file_icon" style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; BACKGROUND-COLOR: ghostwhite; WIDTH: 312px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove"
							type="file" size="32" name="File1" runat="server"> <INPUT id="btn_file_icon_delete" style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; WIDTH: 50px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove"
							type="button" value="delete" name="Button3" runat="server"> <INPUT id=btn_file_icon_view style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; WIDTH: 50px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove" onclick="javascript:viewpicture('<%=cIconFileURL%>')" type=button value=view name=Button4>
					</TD>
				</TR>
				<TR>
					<TD><asp:label id="Label47" runat="server" ForeColor="MidnightBlue" Width="80px" Font-Size="8pt"
							Font-Names="verdana,arial">Movie</asp:label></TD>
					<TD><asp:textbox id="txt_hdn_movie_yg" runat="server" ForeColor="MidnightBlue" Width="122px" Font-Size="8pt"
							Font-Names="verdana,arial" CssClass="formfield" MaxLength="5" Enabled="False"></asp:textbox></TD>
					<TD><INPUT id="txt_file_movie" style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; BACKGROUND-COLOR: ghostwhite; WIDTH: 312px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove"
							type="file" size="32" name="File1" runat="server"> <INPUT id="btn_file_movie_delete" style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; WIDTH: 50px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove"
							type="button" value="delete" name="Button5" runat="server"> <INPUT id=btn_file_movie_view style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; WIDTH: 50px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove" onclick="javascript:viewpicture('<%=cMovieFileURL%>')" type=button value=view name=Button6>
					</TD>
				</TR>
				<TR>
					<TD><asp:label id="Label48" runat="server" ForeColor="MidnightBlue" Width="80px" Font-Size="8pt"
							Font-Names="verdana,arial">Report</asp:label></TD>
					<TD><asp:textbox id="txt_hdn_report_yg" runat="server" ForeColor="MidnightBlue" Width="122px" Font-Size="8pt"
							Font-Names="verdana,arial" CssClass="formfield" MaxLength="5" Enabled="False"></asp:textbox></TD>
					<TD><INPUT id="txt_file_report" style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; BACKGROUND-COLOR: ghostwhite; WIDTH: 312px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove"
							type="file" size="32" name="File1" runat="server"> <INPUT id="btn_file_report_delete" style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; WIDTH: 50px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove"
							type="button" value="delete" name="Button7" runat="server"> <INPUT id=btn_file_report_view style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; WIDTH: 50px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove" onclick="javascript:viewpicture('<%=cReportFileURL%>')" type=button value=view name=Button8>
					</TD>
				</TR>
				<TR>
					<TD><asp:label id="Label52" runat="server" ForeColor="MidnightBlue" Width="80px" Font-Size="8pt"
							Font-Names="verdana,arial">Hand Image</asp:label></TD>
					<TD><asp:textbox id="txt_hdn_gallery_yg" runat="server" ForeColor="MidnightBlue" Width="122px" Font-Size="8pt"
							Font-Names="verdana,arial" CssClass="formfield" MaxLength="5" Enabled="False"></asp:textbox></TD>
					<TD><INPUT id="txt_file_gallery" style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; BACKGROUND-COLOR: ghostwhite; WIDTH: 312px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove"
							type="file" size="32" name="File1" runat="server">&nbsp;<INPUT id="btn_file_gallery_delete" style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; WIDTH: 50px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove"
							type="button" value="delete" name="Button7" runat="server">&nbsp;<INPUT id=btn_file_gallery_view style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; WIDTH: 50px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove" onclick="javascript:viewpicture('<%=cGalleryFileURL%>')" type=button value=view name=Button8></TD>
				</TR>
				<TR>
					<TD><asp:label id="Label60" runat="server" ForeColor="MidnightBlue" Width="80px" Font-Size="8pt"
							Font-Names="verdana,arial">Item Page White Movie</asp:label></TD>
					<TD><asp:textbox id="txt_hdn_banner_yg" runat="server" ForeColor="MidnightBlue" Width="122px" Font-Size="8pt"
							Font-Names="verdana,arial" CssClass="formfield" MaxLength="5" Enabled="False"></asp:textbox></TD>
					<TD><INPUT id="txt_file_banner" style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; BACKGROUND-COLOR: ghostwhite; WIDTH: 312px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove"
							type="file" size="32" name="File1" runat="server">&nbsp;<INPUT id="btn_file_banner_delete" style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; WIDTH: 50px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove"
							type="button" value="delete" name="Button7" runat="server">&nbsp;<INPUT id=btn_file_banner_view style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; WIDTH: 50px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove" onclick="javascript:viewpicture('<%=cBannerFileURL%>')" type=button value=view name=Button8></TD>
				</TR>
			</TABLE>
			<asp:label id="Label604" runat="server" Font-Bold="True" 
				ForeColor="MidnightBlue" Width="100px"
				Font-Size="10pt" Font-Names="verdana,arial" BackColor="Linen" BorderStyle="Outset" 
				BorderWidth="1px">White Gold</asp:label>&nbsp;<TABLE id="tbl_files" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD><asp:label id="Label312" runat="server" ForeColor="MidnightBlue" Width="80px" Font-Size="8pt"
							Font-Names="verdana,arial">Picture</asp:label></TD>
					<TD><asp:textbox id="txt_hdn_picture_wg" runat="server" ForeColor="MidnightBlue" 
                            Width="122px" Font-Size="8pt"
							Font-Names="verdana,arial" CssClass="formfield" MaxLength="5" Enabled="False"></asp:textbox></TD>
					<TD><INPUT id="txt_file_picture2" style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; BACKGROUND-COLOR: ghostwhite; WIDTH: 312px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove"
							type="file" onchange="FillInFilesInfo()" size="32" name="File1" runat="server">
						<INPUT id="btn_file_picture_delete2" style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; WIDTH: 50px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove"
							type="button" value="delete" runat="server"> <INPUT id=btn_file_picture_view style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; WIDTH: 50px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove" onclick="javascript:viewpicture('<%=cPictureFileURL%>')" type=button value=view>
					</TD>
				</TR>
				<TR>
					<TD><asp:label id="Label322" runat="server" ForeColor="MidnightBlue" Width="80px" Font-Size="8pt"
							Font-Names="verdana,arial">Picture HiRes</asp:label></TD>
					<TD><asp:textbox id="txt_hdn_hrpicture_wg" runat="server" ForeColor="MidnightBlue" 
                            Width="122px" Font-Size="8pt"
							Font-Names="verdana,arial" CssClass="formfield" MaxLength="5" Enabled="False"></asp:textbox></TD>
					<TD><INPUT id="txt_file_hrpicture2" style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; BACKGROUND-COLOR: ghostwhite; WIDTH: 312px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove"
							type="file" size="32" name="File1" runat="server"> <INPUT id="btn_file_hrpicture_delete2" style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; WIDTH: 50px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove"
							type="button" value="delete" name="Button1" runat="server"> <INPUT id=btn_file_hrpicture_view style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; WIDTH: 50px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove" onclick="javascript:viewpicture('<%=cHrPictureFileURL%>')" type=button value=view name=Button2>
					</TD>
				</TR>
				<TR>
					<TD><asp:label id="Label462" runat="server" ForeColor="MidnightBlue" Width="80px" Font-Size="8pt"
							Font-Names="verdana,arial">Icon</asp:label></TD>
					<TD><asp:textbox id="txt_hdn_icon_wg" runat="server" ForeColor="MidnightBlue" 
                            Width="122px" Font-Size="8pt"
							Font-Names="verdana,arial" CssClass="formfield" MaxLength="5" Enabled="False"></asp:textbox></TD>
					<TD><INPUT id="txt_file_icon2" style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; BACKGROUND-COLOR: ghostwhite; WIDTH: 312px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove"
							type="file" size="32" name="File1" runat="server"> <INPUT id="btn_file_icon_delete2" style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; WIDTH: 50px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove"
							type="button" value="delete" name="Button3" runat="server"> <INPUT id=btn_file_icon_view style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; WIDTH: 50px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove" onclick="javascript:viewpicture('<%=cIconFileURL%>')" type=button value=view name=Button4>
					</TD>
				</TR>
				<TR>
					<TD><asp:label id="Label472" runat="server" ForeColor="MidnightBlue" Width="80px" Font-Size="8pt"
							Font-Names="verdana,arial">Movie</asp:label></TD>
					<TD><asp:textbox id="txt_hdn_movie_wg" runat="server" ForeColor="MidnightBlue" 
                            Width="122px" Font-Size="8pt"
							Font-Names="verdana,arial" CssClass="formfield" MaxLength="5" Enabled="False"></asp:textbox></TD>
					<TD><INPUT id="txt_file_movie2" style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; BACKGROUND-COLOR: ghostwhite; WIDTH: 312px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove"
							type="file" size="32" name="File1" runat="server"> <INPUT id="btn_file_movie_delete2" style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; WIDTH: 50px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove"
							type="button" value="delete" name="Button5" runat="server"> <INPUT id=btn_file_movie_view style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; WIDTH: 50px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove" onclick="javascript:viewpicture('<%=cMovieFileURL%>')" type=button value=view name=Button6>
					</TD>
				</TR>
				<TR>
					<TD><asp:label id="Label482" runat="server" ForeColor="MidnightBlue" Width="80px" Font-Size="8pt"
							Font-Names="verdana,arial">Report</asp:label></TD>
					<TD><asp:textbox id="txt_hdn_report_wg" runat="server" ForeColor="MidnightBlue" 
                            Width="122px" Font-Size="8pt"
							Font-Names="verdana,arial" CssClass="formfield" MaxLength="5" Enabled="False"></asp:textbox></TD>
					<TD><INPUT id="txt_file_report2" style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; BACKGROUND-COLOR: ghostwhite; WIDTH: 312px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove"
							type="file" size="32" name="File1" runat="server"> <INPUT id="btn_file_report_delete2" style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; WIDTH: 50px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove"
							type="button" value="delete" name="Button7" runat="server"> <INPUT id=btn_file_report_view style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; WIDTH: 50px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove" onclick="javascript:viewpicture('<%=cReportFileURL%>')" type=button value=view name=Button8>
					</TD>
				</TR>
				<TR>
					<TD><asp:label id="Label522" runat="server" ForeColor="MidnightBlue" Width="80px" Font-Size="8pt"
							Font-Names="verdana,arial">Hand Image</asp:label></TD>
					<TD><asp:textbox id="txt_hdn_gallery_wg" runat="server" ForeColor="MidnightBlue" 
                            Width="122px" Font-Size="8pt"
							Font-Names="verdana,arial" CssClass="formfield" MaxLength="5" Enabled="False"></asp:textbox></TD>
					<TD><INPUT id="txt_file_gallery2" style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; BACKGROUND-COLOR: ghostwhite; WIDTH: 312px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove"
							type="file" size="32" name="File1" runat="server">&nbsp;<INPUT id="btn_file_gallery_delete2" style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; WIDTH: 50px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove"
							type="button" value="delete" name="Button7" runat="server">&nbsp;<INPUT id=btn_file_gallery_view style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; WIDTH: 50px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove" onclick="javascript:viewpicture('<%=cGalleryFileURL%>')" type=button value=view name=Button8></TD>
				</TR>
				<TR>
					<TD><asp:label id="Label602" runat="server" ForeColor="MidnightBlue" Width="80px" Font-Size="8pt"
							Font-Names="verdana,arial">Item Page White Movie</asp:label></TD>
					<TD><asp:textbox id="txt_hdn_banner_wg" runat="server" ForeColor="MidnightBlue" 
                            Width="122px" Font-Size="8pt"
							Font-Names="verdana,arial" CssClass="formfield" MaxLength="5" Enabled="False"></asp:textbox></TD>
					<TD><INPUT id="txt_file_banner2" style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; BACKGROUND-COLOR: ghostwhite; WIDTH: 312px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove"
							type="file" size="32" name="File1" runat="server">&nbsp;<INPUT id="btn_file_banner_delete2" style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; WIDTH: 50px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove"
							type="button" value="delete" name="Button7" runat="server">&nbsp;<INPUT id=btn_file_banner_view style="BORDER-BOTTOM: 1px groove; BORDER-LEFT: 1px groove; WIDTH: 50px; FONT-FAMILY: verdana,arial; HEIGHT: 19px; COLOR: midnightblue; FONT-SIZE: 8pt; BORDER-TOP: 1px groove; BORDER-RIGHT: 1px groove" onclick="javascript:viewpicture('<%=cBannerFileURL%>')" type=button value=view name=Button8></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<TR>
		<TD><asp:label id="Label21" runat="server" Font-Bold="True" ForeColor="MidnightBlue" Width="100px"
				Font-Size="10pt" Font-Names="verdana,arial" BackColor="Linen" BorderStyle="Outset" BorderWidth="1px">Note</asp:label><br>
			<asp:textbox id="txt_notes" runat="server" ForeColor="MidnightBlue" Width="645px" Font-Size="8pt"
				Font-Names="verdana,arial" CssClass="formfield" Height="77px" TextMode="MultiLine"></asp:textbox></TD>
	</TR>
	<TR>
		<TD>
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD style="WIDTH: 63px"><asp:textbox id="txt_lastuser_id" runat="server" ForeColor="DarkSlateBlue" Width="70px" Font-Size="8pt"
							Font-Names="verdana,arial" BackColor="#E0E0E0" CssClass="formfield" Enabled="False"></asp:textbox></TD>
					<TD style="WIDTH: 176px"><asp:textbox id="txt_lastuser_name" runat="server" ForeColor="DarkSlateBlue" Width="250px" Font-Size="8pt"
							Font-Names="verdana,arial" BackColor="#E0E0E0" CssClass="formfield" Enabled="False"></asp:textbox></TD>
					<TD><asp:textbox id="txt_lastuser_datetime" runat="server" ForeColor="DarkSlateBlue" Width="200px"
							Font-Size="8pt" Font-Names="verdana,arial" BackColor="#E0E0E0" CssClass="formfield" Enabled="False"></asp:textbox></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<TR>
		<TD><uc1:sp_diamonds id="Sp_diamonds1" runat="server"></uc1:sp_diamonds><uc1:sp_gemstones id="Sp_gemstones1" runat="server"></uc1:sp_gemstones><uc1:sp_jewelry id="Sp_jewelry1" runat="server"></uc1:sp_jewelry></TD>
	</TR>
	<TR>
		<TD style="BACKGROUND-COLOR: darkslateblue" align="right"><asp:button id="btn_submit" runat="server" Width="190px" CssClass="formbutton" Text="Save"></asp:button></TD>
	</TR>
	<TR>
		<TD style="BACKGROUND-COLOR: darkslateblue" align="right">&nbsp;&nbsp;<asp:label id="Label73" runat="server" ForeColor="AliceBlue" Width="32px" Font-Size="8pt" Font-Names="verdana,arial">From</asp:label><asp:textbox id="txt_numfrom" runat="server" CssClass="formfield"></asp:textbox>&nbsp;
			<asp:label id="Label74" runat="server" ForeColor="AliceBlue" Width="16px" Font-Size="8pt" Font-Names="verdana,arial">To</asp:label><asp:textbox id="txt_numto" runat="server" CssClass="formfield"></asp:textbox>
			<asp:CheckBox id="chk_reset_default" runat="server" ForeColor="White" Text="Reset Default"></asp:CheckBox>
			<asp:CheckBox id="chk_disactive" runat="server" ForeColor="White" Text="DisActivate"></asp:CheckBox>
			<asp:CheckBox id="chk_activate" runat="server" ForeColor="White" Text="Activate"></asp:CheckBox>
			<asp:CheckBox id="chk_nometal" runat="server" ForeColor="White" Visible="False"></asp:CheckBox><asp:button id="go_replicate" runat="server" Width="191px" CssClass="formbutton" Text="Update Properies"></asp:button></TD>
	</TR>
</TABLE>
<asp:label id="hid_has_yellowgold" runat="server" Visible="False"></asp:label>
<asp:label id="hid_has_whitegold" runat="server" Visible="False"></asp:label>
<asp:label id="hid_has_movie" runat="server" Visible="False"></asp:label>
<P><asp:label id="hid_item_id" runat="server" Visible="False"></asp:label><asp:label id="hid_branch_id" runat="server" Visible="False"></asp:label><asp:label id="hid_plate_id" runat="server" Visible="False"></asp:label><asp:label id="hid_workmode" runat="server" Visible="False"></asp:label><asp:label id="Label75" runat="server" Visible="False"></asp:label></P>
<script language="javascript">
function viewpicture(fileurl){
	mywin=window.open('viewitem.aspx?pic='+fileurl,"displayWindow","resizable=yes,scrollbars=yes,toolbar=no,height=350,width=400");
}

</script>
