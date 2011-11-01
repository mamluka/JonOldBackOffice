<%@ Register TagPrefix="uc1" TagName="ruler" Src="../webcontrols/ruler.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="listitem.aspx.vb" Inherits="ion_admin.listitem" smartNavigation="True"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>listitems</title>
		<meta content="True" name="vs_showGrid">
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/styles.css" type="text/css" rel="StyleSheet">
		
		<script type="text/javascript" src="/inventory/newage/inventory.js"></script>
		<script type="text/javascript" src="/script/AJS/AJS.js"></script>
		<script type="text/javascript" src="/script/AJS/AJS_fx.js"></script>
		<script type="text/javascript" src="/script/general.js"></script>
		<script type="text/javascript" src="/script/mills.js"></script>
		
		
	</HEAD>
	<body bgColor="#e6e6fa" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:ruler id="Ruler1" runat="server"></uc1:ruler>
			<HR>
			<asp:label id="lbl_inventory" runat="server" ForeColor="Linen" Font-Size="12pt" Font-Names="vedana,arial"
				Width="100%" BorderColor="White" Font-Bold="True" BackColor="DarkSlateBlue" BorderWidth="1px"
				BorderStyle="Groove"></asp:label>
			<HR>
			<center>
				<TABLE id="tbl_search" style="BORDER-RIGHT: 1px outset; BORDER-TOP: 1px outset; BORDER-LEFT: 1px outset; BORDER-BOTTOM: 1px outset; BACKGROUND-COLOR: linen"
					cellSpacing="1" cellPadding="1" width="850" bgColor="linen" border="0">
					<TR>
						<TD style="WIDTH: 103px"><asp:label id="Label4" runat="server" ForeColor="MidnightBlue" Font-Size="8pt" Font-Names="verdana,arial"
								Width="90px">Item number</asp:label></TD>
						<TD style="WIDTH: 86px"><asp:textbox id="txt_itemnumber" runat="server" Width="80px" CssClass="formfield" MaxLength="11"></asp:textbox></TD>
						<TD style="WIDTH: 58px"><asp:label id="Label2" runat="server" ForeColor="MidnightBlue" Font-Size="8pt" Font-Names="verdana,arial"
								Width="50px">Type</asp:label></TD>
						<TD><asp:dropdownlist id="cmb_stonetype" runat="server" Width="150px" CssClass="formfield" Height="21px"></asp:dropdownlist></TD>
						<TD style="WIDTH: 68px"><asp:label id="Label5" runat="server" ForeColor="MidnightBlue" Font-Size="8pt" Font-Names="verdana,arial"
								Width="90px">Active</asp:label></TD>
						<TD><asp:dropdownlist id="cmb_active" runat="server" Width="150px" CssClass="formfield" Height="21px">
								<asp:ListItem Value="0">N/A</asp:ListItem>
								<asp:ListItem Value="1">Active items</asp:ListItem>
								<asp:ListItem Value="2">Non Active items</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 103px; HEIGHT: 17px"><asp:label id="Label1" runat="server" ForeColor="MidnightBlue" Font-Size="8pt" Font-Names="verdana,arial"
								Width="90px">Supplier code</asp:label></TD>
						<TD style="WIDTH: 86px; HEIGHT: 17px"><asp:textbox id="txt_itemcode" runat="server" Width="80px" CssClass="formfield" MaxLength="20"></asp:textbox></TD>
						<TD style="WIDTH: 58px; HEIGHT: 17px"><asp:label id="Label3" runat="server" ForeColor="MidnightBlue" Font-Size="8pt" Font-Names="verdana,arial"
								Width="50px">Weight</asp:label></TD>
						<TD style="HEIGHT: 17px"><asp:textbox id="txt_weight" runat="server" Width="56px" CssClass="formfield" MaxLength="8">0.00</asp:textbox><asp:rangevalidator id="RangeValidator1" runat="server" Font-Size="8pt" ControlToValidate="txt_weight"
								ErrorMessage="***" MaximumValue="1000000" MinimumValue="0" Type="Currency"></asp:rangevalidator><asp:textbox id="txt_weightto" runat="server" Width="56px" CssClass="formfield">0.00</asp:textbox></TD>
						<TD style="WIDTH: 68px; HEIGHT: 17px"><asp:label id="Label6" runat="server" ForeColor="MidnightBlue" Font-Size="8pt" Font-Names="verdana,arial"
								Width="90px">Special</asp:label></TD>
						<TD style="HEIGHT: 17px"><asp:dropdownlist id="cmb_special" runat="server" Width="150px" CssClass="formfield" Height="21px">
								<asp:ListItem Value="0">N/A</asp:ListItem>
								<asp:ListItem Value="1">Items on Special</asp:ListItem>
								<asp:ListItem Value="2">Items Not on special</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<TR>
					  <TD style="WIDTH: 103px">&nbsp;</TD>
					  <TD style="WIDTH: 86px">&nbsp;</TD>
					  <TD style="WIDTH: 58px">&nbsp;</TD>
					  <TD><asp:DropDownList ID="cmb_shape" runat="server" CssClass="formfield">
                        <asp:ListItem Value="0">N/A</asp:ListItem>
                      </asp:DropDownList></TD>
					  <TD style="WIDTH: 68px"><span style="WIDTH: 68px; HEIGHT: 17px">
					    <asp:label id="Label33" runat="server" ForeColor="MidnightBlue" Font-Size="8pt" Font-Names="verdana,arial"
								Width="90px">Center Stone</asp:label>
					  </span></TD>
					  <TD align="right"><asp:DropDownList ID="cmb_csstonetype" runat="server" CssClass="formfield">
                       
                      </asp:DropDownList></TD>
				  </TR>
					<TR>
					  <TD style="WIDTH: 103px"><span style="WIDTH: 58px">
					    <asp:CheckBox ID="chk_onebay" runat="server" Font-Size="8pt" Font-Names="verdana" Text="On Ebay"></asp:CheckBox>
					  </span></TD>
					  <TD style="WIDTH: 86px"><span style="WIDTH: 103px">
					    <asp:checkbox id="chk_defaults" runat="server" Font-Size="8pt" Font-Names="verdana" Text="Defaults Only"></asp:checkbox>
					  </span></TD>
					  <TD style="WIDTH: 58px">&nbsp;</TD>
					  <TD>&nbsp;</TD>
					  <TD style="WIDTH: 68px"></TD>
					  <TD align="right">&nbsp;</TD>
				  </TR>
					<TR>
						<TD style="WIDTH: 103px"><asp:checkbox id="chk_icons" runat="server" Font-Size="8pt" Font-Names="verdana" Text="With Icons"></asp:checkbox></TD>
						<TD style="WIDTH: 86px"><asp:label id="hid_sql" runat="server" Visible="False"></asp:label></TD>
						<TD style="WIDTH: 58px">&nbsp;</TD>
						<TD>&nbsp;</TD>
						<TD style="WIDTH: 68px"><asp:button id="update_active_go" runat="server" Width="97px" CssClass="formbutton" Text="Update Active"></asp:button></TD>
						<TD align="right"><asp:button id="Button1" runat="server" Width="97px" CssClass="formbutton" Text="Search"></asp:button>
					    <asp:Button ID="btn_ebay" runat="server" CssClass="formbutton" Text="To Ebay"></asp:Button></TD>
					</TR>
				</TABLE>
  <hr width="850">
				<asp:datagrid id="grd_items" style="Z-INDEX: 102; LEFT: 10px" runat="server" Font-Size="8pt" Font-Names="verdana,arial"
					Width="1000px" BorderColor="White" BackColor="Linen" BorderWidth="1px" BorderStyle="Outset"
					AutoGenerateColumns="False" AllowPaging="True" PageSize="15">
					<SelectedItemStyle ForeColor="Linen" BackColor="DarkSlateBlue"></SelectedItemStyle>
					<HeaderStyle ForeColor="Linen" BackColor="DarkSlateBlue"></HeaderStyle>
					<Columns>
						<asp:TemplateColumn Visible="False" HeaderText="Icon">
							<HeaderStyle Width="62px"></HeaderStyle>
							<ItemTemplate>
								<%# me.Geticon(Container.DataItem("icon_name"),Container.DataItem("category_id"))%>
							</ItemTemplate>
						</asp:TemplateColumn>
						
						<asp:TemplateColumn HeaderText="Active" ItemStyle-HorizontalAlign="Center">
							 <ItemTemplate>
							 	
							    <asp:CheckBox ID="chk_active" Runat="server"  />
							
								
								
							</ItemTemplate>
						</asp:TemplateColumn>
						
						<asp:TemplateColumn HeaderText="Active" ItemStyle-HorizontalAlign="Center">
							 <ItemTemplate>
							 	
							    <asp:CheckBox ID="chk_default" Runat="server"  />
							
								
								
							</ItemTemplate>
						</asp:TemplateColumn>
						
						<asp:TemplateColumn HeaderText="EBAY">
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
							<ItemTemplate>
								<a href="http://cgi.ebay.com/ws/eBayISAPI.dll?ViewItem&item=<%# Container.DataItem("ebayid") %>" target="_blank"><%# Container.DataItem("ebayid") %></a>
							</ItemTemplate>
						</asp:TemplateColumn>
						
						<asp:BoundColumn DataField="itemnumber" HeaderText="Item No."></asp:BoundColumn>
						<asp:BoundColumn DataField="itemcode" HeaderText="Model Code"></asp:BoundColumn>
						
						<asp:BoundColumn DataField="stonetype_long" HeaderText="Type"></asp:BoundColumn>
						<asp:BoundColumn DataField="weight" HeaderText="Weight" DataFormatString="{0:N}">
							<ItemStyle HorizontalAlign="Right"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn>
							<HeaderStyle Width="20px"></HeaderStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="shape_long" HeaderText="Shape"></asp:BoundColumn>
						<asp:BoundColumn DataField="metal" HeaderText="Metal"></asp:BoundColumn>
						<asp:BoundColumn DataField="cs_weight" HeaderText="CS Weight" DataFormatString="{0:N}"></asp:BoundColumn>
						<asp:BoundColumn DataField="color" HeaderText="Color"></asp:BoundColumn>
						<asp:BoundColumn DataField="clarity" HeaderText="Clarity"></asp:BoundColumn>
						<asp:BoundColumn DataField="sell_price" HeaderText="Sell price" DataFormatString="{0:N}">
							<ItemStyle Font-Bold="True" HorizontalAlign="Right" ForeColor="#0000CC"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn>
							<HeaderStyle Width="20px"></HeaderStyle>
						</asp:BoundColumn>
						
		
						<asp:HyperLinkColumn Text="Edit" DataNavigateUrlField="id" DataNavigateUrlFormatString="edititem.aspx?mode=2&amp;id={0}"
							HeaderText="Edit"></asp:HyperLinkColumn>
						<asp:HyperLinkColumn Text="Ebay" DataNavigateUrlField="id" DataNavigateUrlFormatString="/ebay/twinlister.aspx?id={0}"
							HeaderText="Ebay"></asp:HyperLinkColumn>
						

					</Columns>
					<PagerStyle ForeColor="Linen" BackColor="DarkSlateBlue" Mode="NumericPages"></PagerStyle>
        </asp:datagrid><br>
				<table borderColor="#00cc33" cellSpacing="0" cellPadding="0" width="640" bgColor="#faf0e6"
					border="0">
					<tr>
						<td width="225"><asp:label id="total_w" runat="server" ForeColor="MidnightBlue" Font-Size="8pt" Font-Names="verdana,arial"
								Width="90px"></asp:label></td>
						<td width="254"><asp:label id="total_pp" runat="server" ForeColor="MidnightBlue" Font-Size="8pt" Font-Names="verdana,arial"
								Width="90px"></asp:label></td>
						<td width="161"><asp:label id="total_sp" runat="server" ForeColor="MidnightBlue" Font-Size="8pt" Font-Names="verdana,arial"
								Width="90px"></asp:label></td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
