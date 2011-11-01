<%@ Page Language="vb" AutoEventWireup="false" Codebehind="appraisal.aspx.vb" Inherits="ion_admin.appraisal1"%>
<%@ Register TagPrefix="uc1" TagName="ruler" Src="../../webcontrols/ruler.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
    <title>appraisal</title>
<meta content="Microsoft Visual Studio .NET 7.1" name=GENERATOR>
<meta content="Visual Basic .NET 7.1" name=CODE_LANGUAGE>
<meta content=JavaScript name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema><LINK href="\default.css" type=text/css rel=StyleSheet >
  </HEAD>
<body MS_POSITIONING="GridLayout">
<form id=Form1 method=post runat="server">
<TABLE id=Table1 cellSpacing=1 cellPadding=1 width=640 border=0>
  <TR>
    <TD><uc1:ruler id=Ruler1 runat="server"></uc1:ruler></TD></TR>
  <TR>
    <TD></TD></TR>
  <TR>
    <TD align=right>
      <TABLE id=Table3 cellSpacing=1 cellPadding=1 width="100%" border=0 
      >
        <TR>
          <TD>
            <TABLE class=list_table id=tbl_message_header cellSpacing=0 
            cellPadding=1 width="100%" border=0>
              <TR>
                <TD><asp:label id=lbl_header runat="server" CssClass="text_header" Width="80%">Appraisals:</asp:label></TD>
                <TD vAlign=middle align=right><A href="/default.aspx" ><IMG alt=Home src="/pic/close.gif" border=0 width="17" height="17" ></A></TD></TR></TABLE></TD></TR>
        <TR>
          <TD>
            <TABLE class=app_table_light id=Table4 cellSpacing=1 cellPadding=1 
            width="100%" border=0>
              <TR>
                <TD width=150><asp:label id=Label9 runat="server" CssClass="registration_text_1" Width="84px" EnableViewState="False">Item ID</asp:label></TD>
                <TD vAlign=top><asp:textbox id=txt_itemid runat="server" CssClass="app_field" Width="100px" AutoPostBack="True" BackColor="Lavender" MaxLength="40"></asp:textbox>&nbsp;<asp:label id=lbl_item_description runat="server" CssClass="registration_text_1" Width="350px" EnableViewState="False" Font-Size="7pt"></asp:label></TD></TR>
              <TR>
                <TD><asp:label id=Label8 runat="server" CssClass="registration_text_1" Width="84px" EnableViewState="False">User Id</asp:label></TD>
                <TD vAlign=top><asp:textbox id=txt_user_id runat="server" CssClass="app_field" Width="100px" AutoPostBack="True" BackColor="Lavender" MaxLength="40"></asp:textbox>&nbsp; 
<asp:label id=lbl_user_description runat="server" CssClass="registration_text_1" Width="300px" EnableViewState="False"></asp:label></TD></TR>
              <TR>
                <TD></TD>
                <TD><asp:requiredfieldvalidator id=RequiredFieldValidator1 runat="server" Width="160px" ControlToValidate="txt_itemid" Font-Size="9pt" Font-Names="verdana,arial" ErrorMessage="Must have an Item ID"></asp:requiredfieldvalidator><asp:rangevalidator id=RangeValidator1 runat="server" ControlToValidate="txt_itemid" Font-Size="9pt" Font-Names="verdana,arial" ErrorMessage="Item ID must be numeric" MinimumValue="1000" MaximumValue="9999">Item ID must be NUMERIC</asp:rangevalidator></TD></TR>
              <TR>
                <TD></TD>
                <TD align=right><asp:RadioButtonList id="rdo_appraisal" runat="server" Width="463px" CssClass="registration_text_1" EnableViewState="False" RepeatDirection="Horizontal">
<asp:ListItem Value="1">Diamond Appraisal</asp:ListItem>
<asp:ListItem Value="2">Gemstone Appraisal</asp:ListItem>
<asp:ListItem Value="3">Jewelry Appraisal</asp:ListItem>
</asp:RadioButtonList></TD></TR>
              <TR>
                <TD></TD>
                <TD align=right><asp:HyperLink id="hyp_apprasal" runat="server" Width="150px" CssClass="app_button_big" Target="_blank" Height="20px">Get Appraisal</asp:HyperLink></TD></TR></TABLE></TD></TR>
        <TR>
          <TD></TD></TR>
        <TR>
          <TD>
            <TABLE class=app_table_light id=Table2 cellSpacing=1 cellPadding=1 
            width="100%" border=0>
              <TR>
                <TD width=150><asp:label id=Labelp28 runat="server" CssClass="registration_text_1" Width="84px" EnableViewState="False">Name</asp:label></TD>
                <TD><asp:textbox id=txt_name runat="server" CssClass="app_field" Width="350px" MaxLength="40"></asp:textbox></TD></TR>
              <TR>
                <TD><asp:label id=Label1 runat="server" CssClass="registration_text_1" Width="84px" EnableViewState="False">Address</asp:label></TD>
                <TD><asp:textbox id=txt_address runat="server" CssClass="app_field" Width="400px" MaxLength="40"></asp:textbox></TD></TR>
              <TR>
                <TD><asp:label id=Label2 runat="server" CssClass="registration_text_1" Width="84px" EnableViewState="False">City</asp:label></TD>
                <TD><asp:textbox id=txt_city runat="server" CssClass="app_field" Width="250px" MaxLength="40"></asp:textbox></TD></TR>
              <TR>
                <TD><asp:label id=Label5 runat="server" CssClass="registration_text_1" Width="84px" EnableViewState="False">State & Zip</asp:label></TD>
                <TD><asp:textbox id=txt_state runat="server" CssClass="app_field" Width="250px" MaxLength="40"></asp:textbox></TD></TR>
              <TR>
                <TD><asp:label id=Label3 runat="server" CssClass="registration_text_1" Width="84px" EnableViewState="False">Country</asp:label></TD>
                <TD><asp:textbox id=txt_country runat="server" CssClass="app_field" Width="250px" MaxLength="40"></asp:textbox></TD></TR></TABLE></TD></TR></TABLE></TD></TR>
  <TR>
    <TD align=right>
      <TABLE class="app_table_light" id="Table8" cellSpacing="1" cellPadding="1" 
      width="100%" border="0">
        <TR>
          <TD width="150"><asp:label id="Label26" runat="server" CssClass="text_header" Font-Size="10pt">Appraisal number</asp:label></TD>
          <TD><asp:textbox id="txt_appraisalno" runat="server" CssClass="app_field" Width="150px" MaxLength="40" Enabled="False"></asp:textbox></TD></TR></TABLE></TD></TR>
  <TR>
    <TD align=right>
      <TABLE class=app_table_light id=Table6 cellSpacing=1 cellPadding=1 
      width="100%" border=0>
        <TR>
          <TD width=150><asp:label id=Label4 runat="server" CssClass="text_header" Font-Size="10pt">Jewelry:</asp:label></TD>
          <TD></TD></TR>
        <TR>
          <TD width=150><asp:label id=Label17 runat="server" CssClass="registration_text_1" Width="128px" EnableViewState="False">Total weight</asp:label></TD>
          <TD><asp:textbox id=txt_jewel_weight runat="server" CssClass="app_field" Width="150px" MaxLength="40"></asp:textbox></TD></TR>
        <TR>
          <TD width=150><asp:label id=Label12 runat="server" CssClass="registration_text_1" Width="136px" EnableViewState="False">Description</asp:label></TD>
          <TD><asp:textbox id=txt_jewel_description runat="server" CssClass="app_field" Width="400px" MaxLength="40"></asp:textbox></TD></TR>
        <TR>
          <TD><asp:label id=Label7 runat="server" CssClass="registration_text_1" Width="128px" EnableViewState="False">Middle stone</asp:label></TD>
          <TD><asp:textbox id=txt_jewel_middlestone runat="server" CssClass="app_field" Width="400px" MaxLength="100"></asp:textbox></TD></TR>
        <TR>
          <TD><asp:label id=Label16 runat="server" CssClass="registration_text_1" Width="128px" EnableViewState="False">Gold</asp:label></TD>
          <TD><asp:textbox id=txt_jewel_gold runat="server" CssClass="app_field" Width="400px" MaxLength="100"></asp:textbox></TD></TR></TABLE></TD></TR>
  <TR>
    <TD align=right>
      <TABLE class=app_table_light id=Table5 cellSpacing=1 cellPadding=1 
      width="100%" border=0>
        <TR>
          <TD colSpan=2><asp:label id=Label11 runat="server" CssClass="text_header" Width="100%" Font-Size="10pt">Gemstones and Diamonds:</asp:label></TD></TR>
        <TR>
          <TD width=150><asp:label id=Label10 runat="server" CssClass="registration_text_1" Width="84px" EnableViewState="False">Stone type</asp:label></TD>
          <TD><asp:textbox id=txt_stonetype runat="server" CssClass="app_field" Width="400px" MaxLength="100"></asp:textbox></TD></TR>
        <TR>
          <TD><asp:label id=Label20 runat="server" CssClass="registration_text_1" Width="84px" EnableViewState="False">Weight</asp:label></TD>
          <TD><asp:textbox id=txt_weight runat="server" CssClass="app_field" Width="200px" MaxLength="40"></asp:textbox></TD></TR>
        <TR>
          <TD><asp:label id=Label6 runat="server" CssClass="registration_text_1" Width="84px" EnableViewState="False">Cut</asp:label></TD>
          <TD><asp:textbox id=txt_cut runat="server" CssClass="app_field" Width="400px" MaxLength="40"></asp:textbox></TD></TR>
        <TR>
          <TD><asp:label id=Label13 runat="server" CssClass="registration_text_1" Width="84px" EnableViewState="False">Color</asp:label></TD>
          <TD><asp:textbox id=txt_color runat="server" CssClass="app_field" Width="400px" MaxLength="100"></asp:textbox></TD></TR>
        <TR>
          <TD><asp:label id=Label14 runat="server" CssClass="registration_text_1" Width="84px" EnableViewState="False">Clarity</asp:label></TD>
          <TD><asp:textbox id=txt_clarity runat="server" CssClass="app_field" Width="400px" MaxLength="100"></asp:textbox></TD></TR>
        <TR>
          <TD><asp:label id=Label15 runat="server" CssClass="registration_text_1" Width="84px" EnableViewState="False">Origin</asp:label></TD>
          <TD><asp:textbox id=txt_origin runat="server" CssClass="app_field" Width="400px" MaxLength="100"></asp:textbox></TD></TR>
        <TR>
          <TD><asp:label id=Label18 runat="server" CssClass="registration_text_1" Width="128px" EnableViewState="False">Size</asp:label></TD>
          <TD><asp:textbox id=txt_size runat="server" CssClass="app_field" Width="400px" MaxLength="100"></asp:textbox></TD></TR></TABLE></TD></TR>
  <TR>
    <TD align=right>
      <TABLE class=app_table_light id=Table7 cellSpacing=1 cellPadding=1 
      width="100%" border=0>
        <TR>
          <TD vAlign=top width=150><asp:label id=Label19 runat="server" CssClass="registration_text_1" Width="128px" EnableViewState="False">Replacement value</asp:label></TD>
          <TD><asp:textbox id=txt_value runat="server" CssClass="app_field" Width="200px" MaxLength="40"></asp:textbox></TD></TR>
        <TR>
          <TD vAlign=top width=150><asp:label id=Label24 runat="server" CssClass="registration_text_1" Width="84px" EnableViewState="False">Additional info</asp:label></TD>
          <TD><asp:textbox id=txt_notes runat="server" CssClass="app_field" Width="100%" MaxLength="40" TextMode="MultiLine" Rows="6"></asp:textbox></TD></TR>
        <TR>
          <TD vAlign=top width=150></TD>
          <TD align=center><asp:image id=img_item runat="server"></asp:image></TD></TR></TABLE><asp:Label id="hid_pic_path" runat="server" Visible="False"></asp:Label></TD></TR>
  <TR>
    <TD align=right><asp:button id=btn_run runat="server" CssClass="app_button_big" Text="Make Appraisal"></asp:button></TD></TR></TABLE></form>

  </body>
</HTML>
