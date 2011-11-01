<%@ Page Language="vb" AutoEventWireup="false" Codebehind="twinlister.aspx.vb" Inherits="ion_admin.twinlister"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>twinlister</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="JavaScript" src="/script/tree/dhtmlxcommon.js" type="text/javascript"></script>
		<script language="JavaScript" src="/script/tree/dhtmlxtree.js" type="text/javascript"></script>
		<script language="JavaScript" src="/script/AJS/AJS.js" type="text/javascript"></script>
		<script language="JavaScript" src="/script/datetimepicker.js" type="text/javascript"></script>
		<script language="JavaScript" type="text/javascript" src="/script/calendar1.js"></script>
		<script>  
		var category_type = 1
		var tree=null
		var loaded=0
		var cal1=null
function LoadTree() {
tree=new dhtmlXTreeObject(document.getElementById('catTree'),"250px","450px",0); 
tree.setImagePath("/script/tree/imgs/"); 
tree.enableCheckBoxes(false);
tree.enableDragAndDrop(false); 
tree.attachEvent("onClick",AJS.bind(onNodeSelect,{tree:tree}))

cal1 = new calendar1(document.forms['Form1'].elements['e_sch_time']);
cal1.time_comp = true;

//set function object to call on node select //see other available event handlers in API documentation function onNodeSelect(nodeId){ ... } 
function onNodeSelect(nodeId){ 

if (tree.hasChildren(nodeId)) {

	tree.openItem(nodeId)
	return 0

}

AJS.hideElement(AJS.$('catTree'))
if (category_type ==1 )  {
AJS.$('e_primary_id').value = nodeId
AJS.$('catPath').value = this.tree.getUserData(nodeId,'parent')
}
if (category_type ==2 ) {
AJS.$('e_secondary_id').value = nodeId
AJS.$('catPath2').value = this.tree.getUserData(nodeId,'parent')
}

	//alert(document.getElementById(nodeId).innerHTML)
}

	//load root level from xml 
}

 function DisplayCatDiv() {
 Load()
 	AJS.showElement(AJS.$('catTree'))
	category_type = 1
//	three.tree.findItem(searchString,0,1)
//alert(tree.findItem('Oval',0,1))
 }
 function DisplayCatDiv2() {
 	Load()
 	AJS.showElement(AJS.$('catTree'))
	category_type = 2
 }
 function Load() {
 if (loaded==0 ) {
 	tree.loadXML("/ebaycat"+AJS.$('e_site').value+".xml");
	loaded=1
	}
	
 }
 function OpenCal() {
 	cal1.popup()
 }
 function RemoveCategory(obj) {
 	if ( obj.id == 'catPath' && obj.value == '' ) {
	
	AJS.$('e_primary_id').value = ''
		
	}

 	if ( obj.id == 'catPath2' && obj.value == '' ) {
	
	AJS.$('e_secondary_id').value = ''
		
	}

 }
 
 function ChangeDurationByAuctionType(id) {
 	if ( id == 1 ) {
		AJS.$('e_duration').selectedIndex=5
	}
	
	if ( id == 0 || id == 2 ) {
		AJS.$('e_duration').selectedIndex=2
	}
	
	
 }
		</script>
		<style type="text/css">.cat_text { PADDING-RIGHT: 3px; PADDING-LEFT: 3px; FONT-SIZE: 11px; PADDING-BOTTOM: 3px; PADDING-TOP: 3px; FONT-FAMILY: Tahoma, Verdana; BACKGROUND-COLOR: #cccccc }
		</style>
	</HEAD>
	<body dir="ltr" onLoad="LoadTree()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td vAlign="top" width="70%">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td>
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="cat_text">Title ( This is ebay title maximum length 55 letters )
														</td>
													</tr>
													<TR>
														<td><asp:textbox id="e_title" runat="server" Width="520px" MaxLength="55"></asp:textbox></td>
													</TR>
												</table>
											</td>
										</tr>
										<tr>
											<td>
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="cat_text">Subtitle</td>
													</tr>
													<tr>
														<td>
															<asp:textbox id="e_subtitle" runat="server" Width="512px"></asp:textbox></td>
													</tr>
												</table>
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="cat_text">Alt Title for HTML ( This is for the page HTML )
														</td>
													</tr>
													<tr>
														<td><asp:textbox id="e_alt_title" runat="server" Width="576px" AutoPostBack="True"></asp:textbox></td>
													</tr>
												</table>
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="cat_text">Description for HTML</td>
													</tr>
													<tr>
														<td><span class="cat_text"><asp:textbox id="e_desc" runat="server" Width="624px" AutoPostBack="True" Wrap="False" TextMode="MultiLine"
																	Height="142px"></asp:textbox></span></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td>
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="cat_text">Main Categiry
															<asp:button id="e_updatecat" runat="server" Text="Update Categories"></asp:button><input id="e_selectcat" onClick="DisplayCatDiv()" type="button" value="Select Main Category"
																name="e_selectcat"> <input id="e_selectcat2" onClick="DisplayCatDiv2()" type="button" value="Select Secondary  Category"
																name="e_selectcat2"></td>
													</tr>
													<tr>
														<td>
															<P></P>
															<P><asp:textbox id="catPath" runat="server" Width="750px"></asp:textbox></P>
															<P><asp:textbox id="catPath2" runat="server" Width="750px"></asp:textbox></P>
															<P><br>
																<asp:dropdownlist id="e_primery_cat" runat="server" Visible="False"></asp:dropdownlist>&nbsp;
																<asp:dropdownlist id="e_primery_cat_2" runat="server" Visible="False"></asp:dropdownlist><asp:dropdownlist id="e_primery_cat_3" runat="server" Visible="False"></asp:dropdownlist><BR>
																<asp:dropdownlist id="e_primery_cat_4" runat="server" Visible="False"></asp:dropdownlist><asp:dropdownlist id="DropDownList1" runat="server" Visible="False"></asp:dropdownlist></P>
															<P><asp:dropdownlist id="e_second_cat" runat="server" Visible="False"></asp:dropdownlist><asp:dropdownlist id="e_second_cat_2" runat="server" Visible="False"></asp:dropdownlist><asp:dropdownlist id="e_second_cat_3" runat="server" Visible="False"></asp:dropdownlist><BR>
																<asp:dropdownlist id="e_second_cat_4" runat="server" Visible="False"></asp:dropdownlist>
																<div style="DISPLAY: none"><asp:textbox id="e_primary_id" runat="server"></asp:textbox><asp:textbox id="e_secondary_id" runat="server"></asp:textbox></div>
															<P></P>
														</td>
													</tr>
												</table>
											</td>
										</tr>
										<!--<tr>
											<td>
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="cat_text">Item Specifics</td>
													</tr>
													<tr>
														<td></td>
													</tr>
												</table>
											</td>
										</tr>-->
										<tr>
											<td>
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="cat_text">Store Categories</td>
													</tr>
													<tr>
														<td><asp:dropdownlist id="e_store_main_cat" runat="server"></asp:dropdownlist><asp:dropdownlist id="e_store_second_cat" runat="server"></asp:dropdownlist></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td>
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="cat_text">Pictures</td>
													</tr>
													<tr>
														<td><asp:image id="e_picture" runat="server"></asp:image></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td>
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="cat_text">HTML CODE</td>
													</tr>
													<tr>
														<td><asp:textbox id="e_html" runat="server" Width="616px" TextMode="MultiLine" Height="258px"></asp:textbox><BR>
															<BR>
														</td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td>
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="cat_text">Private Code</td>
													</tr>
													<tr>
														<td><asp:textbox id="e_inventory_code" runat="server"></asp:textbox></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
								<td vAlign="top" width="30%">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td>
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="cat_text">Selling Format</td>
													</tr>
													<tr>
														<td><asp:dropdownlist id="e_selling_format" runat="server"></asp:dropdownlist>&nbsp; 
															Site:
															<asp:dropdownlist id="e_site" runat="server" AutoPostBack="True">
																<asp:ListItem Value="1">US</asp:ListItem>
																<asp:ListItem Value="2">UK</asp:ListItem>
																<asp:ListItem Value="6">France</asp:ListItem>
																<asp:ListItem Value="3">Australia</asp:ListItem>
															</asp:dropdownlist></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td>
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="cat_text">Item Price</td>
													</tr>
													<tr>
														<td><asp:textbox id="e_price" runat="server" Width="120px"></asp:textbox><asp:label id="e_cur_price" runat="server">Label</asp:label>Appriasel:
															<asp:textbox id="e_apramount" runat="server" Width="88px" AutoPostBack="True"></asp:textbox><asp:label id="e_cur_apr" runat="server">Label</asp:label><BR>
															<asp:checkbox id="e_bestoffer" runat="server" Text="Best Offer"></asp:checkbox><asp:checkbox id="e_private" runat="server" Text="Private Listing"></asp:checkbox>
															<asp:CheckBox id="chk_clarity" runat="server" Text="Clarity Enhanced" AutoPostBack="True"></asp:CheckBox><BR>
															Mininum Price:
															<asp:textbox id="e_min_bestoffer" runat="server"></asp:textbox></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td>
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="cat_text">Qualtity
														</td>
													</tr>
													<tr>
														<td><asp:textbox id="e_qty" runat="server">1</asp:textbox></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td>
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="cat_text">Duration</td>
													</tr>
													<tr>
														<td><asp:dropdownlist id="e_duration" runat="server"></asp:dropdownlist></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td>
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="cat_text">Listing Upgrades</td>
													</tr>
													<tr>
														<td>
															<table cellSpacing="0" cellPadding="0" width="100%" border="0">
																<tr>
																	<td><asp:checkbox id="e_u_gallery_pic" runat="server" Text="Gallery Pic" Checked="True"></asp:checkbox></td>
																	<td><asp:checkbox id="e_u_bold" runat="server" Text="Bold"></asp:checkbox></td>
																</tr>
																<tr>
																	<td><asp:checkbox id="e_u_gallery_plus" runat="server" Text="Gallery Plus" Checked="True"></asp:checkbox></td>
																	<td><asp:checkbox id="e_u_border" runat="server" Text="Border"></asp:checkbox></td>
																</tr>
																<tr>
																	<td><asp:checkbox id="e_u_highlight" runat="server" Text="Highlight"></asp:checkbox></td>
																	<td><asp:checkbox id="e_u_featured_plus" runat="server" Text="Featured Plus"></asp:checkbox></td>
																</tr>
															</table>
														</td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td>
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="cat_text">Shipping</td>
													</tr>
													<tr>
														<td><asp:dropdownlist id="e_shipping" runat="server" AutoPostBack="True"></asp:dropdownlist></td>
													</tr>
												</table>
												<asp:dropdownlist id="e_shipping_services" runat="server" Visible="True"></asp:dropdownlist></td>
										</tr>
										<tr>
											<td></td>
										</tr>
									</table>
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td class="cat_text">Scheduler</td>
										</tr>
										<tr>
											<td>
												<P>&nbsp;
													<asp:CheckBox id="e_use_sch" runat="server"></asp:CheckBox>
													<asp:TextBox id="e_sch_time" runat="server"></asp:TextBox>
													<input type="button" name="Button" value="Pick" onClick="OpenCal()"></P>
												<P>&nbsp;</P>
											</td>
										</tr>
									</table>
									<P></P>
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td class="cat_text">Fees</td>
										</tr>
										<tr>
											<td><asp:label id="e_fees" runat="server"></asp:label>&nbsp;
												<asp:label id="e_fees2" runat="server"></asp:label></td>
										</tr>
									</table>
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td class="cat_text">Item Id</td>
										</tr>
										<tr>
											<td><asp:hyperlink id="e_itemid" runat="server" Visible="False" Target="_blank">HyperLink</asp:hyperlink></td>
										</tr>
									</table>
									<P></P>
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td class="cat_text">Controls</td>
										</tr>
										<tr>
											<td>&nbsp;
												<asp:CheckBox id="e_secondsite" runat="server" Text="Put on Games-Wholesaler" AutoPostBack="True"></asp:CheckBox><BR>
												<BR>
												<table cellSpacing="0" cellPadding="3" width="100%" border="0">
													<tr>
														<td><asp:hyperlink id="e_onsite" runat="server" Target="_blank">On Site</asp:hyperlink></td>
														<td><asp:hyperlink id="e_officelink" runat="server" Target="_blank">Edit Item</asp:hyperlink></td>
														<td><asp:hyperlink id="e_preview" runat="server" Target="_blank">Preview</asp:hyperlink></td>
													</tr>
													<tr>
														<td><asp:button id="e_update" runat="server" Text="Update After Edit"></asp:button></td>
														<td><asp:button id="Go" runat="server" Text="Get Fees"></asp:button></td>
														<td><asp:button id="Upload" runat="server" Text="Upload"></asp:button></td>
													</tr>
												</table>
												<BR>
												<asp:literal id="e_specs" runat="server"></asp:literal></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<DIV id="catTree" style="BORDER-RIGHT: black 2px solid; BORDER-TOP: black 2px solid; DISPLAY: none; Z-INDEX: 101; LEFT: 288px; OVERFLOW: auto; BORDER-LEFT: black 2px solid; WIDTH: 350px; BORDER-BOTTOM: black 2px solid; POSITION: absolute; TOP: 16px; HEIGHT: 805px; BACKGROUND-COLOR: white"></DIV>
		</form>
	</body>
</HTML>
