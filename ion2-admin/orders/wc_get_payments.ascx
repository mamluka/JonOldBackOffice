<%@ Control Language="vb" AutoEventWireup="false" Codebehind="wc_get_payments.ascx.vb" Inherits="ion_admin.wc_get_payments" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>



<meta content=False name=vs_showGrid>
<TABLE id=tbl_payments cellSpacing=0 cellPadding=0 width="100%" border=0>
  <TR>
    <TD><ASP:LABEL id=LABEL18 Font-Size="10pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" BorderWidth="1px" BorderStyle="Outset" BackColor="Linen" Font-Bold="True" Width="140px">Payment method</ASP:LABEL></TD></TR>
  <TR>
    <TD align=right><asp:textbox id=hid_payment runat="server" VISIBLE="False" CssClass="formfield_dec" FONT-BOLD="True" WIDTH="150px" HEIGHT="18px"></asp:textbox></TD></TR>
  <TR>
    <TD height=30><ASP:CHECKBOX id=chk_payment_cc Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" BackColor="#C0C0FF" ENABLED="False" AutoPostBack="True" CHECKED="True"></ASP:CHECKBOX><asp:label id=Label15 Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" Width="250px" FONT-BOLD="True"> Credit Card</asp:label></TD></TR>
  <TR id=CreditCard>
    <TD>
      <TABLE id=tbl_payments_CerditCard 
      style="BORDER-RIGHT: 2px groove; BORDER-TOP: 2px groove; FONT-SIZE: 8pt; BORDER-LEFT: 2px groove; COLOR: midnightblue; BORDER-BOTTOM: 2px groove; FONT-FAMILY: verdana,arial" 
      cellSpacing=0 cellPadding=0 width="100%" border=0>
        <TR>
          <TD width=20></TD>
          <TD width=100>
            <DIV class=CheckoutFont_link 
            MS_POSITIONING="FlowLayout">Card type</DIV></TD>
          <TD width=170><asp:dropdownlist id=cmb_cc_cardtype runat="server" Width="132px" CssClass="formfield" BACKCOLOR="#C0C0FF" AUTOPOSTBACK="True"></asp:dropdownlist></TD>
          <TD width=170>
            <DIV class=CheckoutFont_link id=div_club 
            MS_POSITIONING="FlowLayout" RUNAT="server">Authorization 
          code</DIV></TD>
          <TD><ASP:TEXTBOX id=txt_cc_code Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" Width="100px" CssClass="formfield" MaxLength="20"></ASP:TEXTBOX></TD>
          <TD></TD></TR>
        <TR>
          <TD width=20></TD>
          <TD width=100>
            <DIV class=CheckoutFont_link 
            MS_POSITIONING="FlowLayout">Expiration date</DIV></TD>
          <TD width=170><asp:dropdownlist id=cmb_cc_month runat="server" Width="46px" CssClass="formfield">
							<asp:ListItem Value="0">-</asp:ListItem>
							<asp:ListItem Value="1">1</asp:ListItem>
							<asp:ListItem Value="2">2</asp:ListItem>
							<asp:ListItem Value="3">3</asp:ListItem>
							<asp:ListItem Value="4">4</asp:ListItem>
							<asp:ListItem Value="5">5</asp:ListItem>
							<asp:ListItem Value="6">6</asp:ListItem>
							<asp:ListItem Value="7">7</asp:ListItem>
							<asp:ListItem Value="8">8</asp:ListItem>
							<asp:ListItem Value="9">9</asp:ListItem>
							<asp:ListItem Value="10">10</asp:ListItem>
							<asp:ListItem Value="11">11</asp:ListItem>
							<asp:ListItem Value="12">12</asp:ListItem>
						</asp:dropdownlist><asp:dropdownlist id=cmb_cc_year runat="server" Width="81px" CssClass="formfield">
							<asp:ListItem Value="0">-</asp:ListItem>
							<asp:ListItem Value="02">2002</asp:ListItem>
							<asp:ListItem Value="03">2003</asp:ListItem>
							<asp:ListItem Value="04">2004</asp:ListItem>
							<asp:ListItem Value="05">2005</asp:ListItem>
							<asp:ListItem Value="06">2006</asp:ListItem>
							<asp:ListItem Value="07">2007</asp:ListItem>
							<asp:ListItem Value="08">2008</asp:ListItem>
							<asp:ListItem Value="09">2009</asp:ListItem>
							<asp:ListItem Value="10">2010</asp:ListItem>
						</asp:dropdownlist></TD>
          <TD width=170>
            <DIV class=CheckoutFont_link id=Div1 
            MS_POSITIONING="FlowLayout" RUNAT="server">Member 'Style' 
          club</DIV></TD>
          <TD><ASP:CHECKBOX id=chk_style_member Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" Text=" "></ASP:CHECKBOX></TD>
          <TD></TD></TR>
        <TR>
          <TD width=20></TD>
          <TD width=100>
            <DIV class=CheckoutFont_link 
            MS_POSITIONING="FlowLayout">Card number</DIV></TD>
          <TD width=170><asp:textbox id=txt_cc_cardnumber Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" Width="150px" CssClass="formfield" MaxLength="40"></asp:textbox><asp:requiredfieldvalidator id=vld_cc_cardnumber runat="server" ErrorMessage="&amp;times;" ControlToValidate="txt_cc_cardnumber"></asp:requiredfieldvalidator></TD>
          <TD width=170>
            <DIV class=CheckoutFont_link 
            MS_POSITIONING="FlowLayout">CVV number</DIV></TD>
          <TD><asp:textbox id=txt_cc_cvv Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" Width="40px" CssClass="formfield" MaxLength="4"></asp:textbox></TD>
          <TD></TD></TR>
        <TR>
          <TD width=20></TD>
          <TD width=100>
            <DIV class=CheckoutFont_link 
            MS_POSITIONING="FlowLayout">Name on card</DIV></TD>
          <TD width=170><ASP:TEXTBOX id=txt_cc_nameoncard Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" Width="150px" CssClass="formfield" MaxLength="40"></ASP:TEXTBOX><asp:requiredfieldvalidator id=vld_cc_nameoncard runat="server" ErrorMessage="&amp;times;" ControlToValidate="txt_cc_nameoncard"></asp:requiredfieldvalidator></TD>
          <TD width=170>
            <DIV class=CheckoutFont_link 
            MS_POSITIONING="FlowLayout">Personal ID number</DIV></TD>
          <TD><ASP:TEXTBOX id=txt_cc_person_id Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" Width="100px" CssClass="formfield" MaxLength="20"></ASP:TEXTBOX></TD>
          <TD></TD></TR></TABLE></TD></TR>
  <TR id=MoneyTransfer>
    <TD>
      <TABLE id=tbl_money_wire 
      style="BORDER-RIGHT: 2px groove; BORDER-TOP: 2px groove; BORDER-LEFT: 2px groove; BORDER-BOTTOM: 2px groove" 
      cellSpacing=1 cellPadding=1 width="100%" border=0>
        <TR>
          <TD><ASP:CHECKBOX id=chk_payment_wire Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" BackColor="#C0C0FF" AutoPostBack="True"></ASP:CHECKBOX><asp:label id=Label12 Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" Width="250px" FONT-BOLD="True">Money transfer / Wire</asp:label>
            <TABLE id=tbl_moneytransfer cellSpacing=0 cellPadding=0 width="100%" 
            border=0>
              <TR>
                <TD width=20></TD>
                <TD width=140><asp:label id=Label1 ForeColor="MidnightBlue" runat="server" Width="80px" FONT-NAMES="verdana,arial" FONT-SIZE="8pt">Bank name</asp:label></TD>
                <TD colSpan=3><asp:textbox id=txt_mt_bank Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" Width="300px" CssClass="formfield" MaxLength="120"></asp:textbox></TD></TR>
              <TR>
                <TD></TD>
                <TD><asp:label id=Label2 Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" Width="127px">Name on transaction</asp:label></TD>
                <TD colSpan=3><asp:textbox id=txt_mt_name Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" Width="300px" CssClass="formfield" MaxLength="64"></asp:textbox></TD></TR>
              <TR>
                <TD></TD>
                <TD><asp:label id=Label3 Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" Width="80px">Account</asp:label></TD>
                <TD><ASP:TEXTBOX id=txt_mt_account Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" Width="150px" CssClass="formfield" MaxLength="40"></ASP:TEXTBOX></TD>
                <TD><asp:label id=Label4 Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" Width="80px">Transfer code</asp:label></TD>
                <TD><ASP:TEXTBOX id=txt_mt_code Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" Width="100px" CssClass="formfield" MaxLength="40"></ASP:TEXTBOX></TD></TR></TABLE></TD></TR></TABLE>
      <TABLE id=tbl_check 
      style="BORDER-RIGHT: 2px groove; BORDER-TOP: 2px groove; BORDER-LEFT: 2px groove; BORDER-BOTTOM: 2px groove" 
      cellSpacing=1 cellPadding=1 width="100%" border=0>
        <TR>
          <TD><ASP:CHECKBOX id=chk_payment_check Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" BackColor="#C0C0FF" AutoPostBack="True"></ASP:CHECKBOX><asp:label id=Label14 Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" Width="250px" FONT-BOLD="True"> Cashier's check</asp:label>
            <TABLE id=tbl_cashierscheck cellSpacing=0 cellPadding=0 width="100%" 
            border=0>
              <TR>
                <TD width=20></TD>
                <TD width=140><asp:label id=Label5 Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" Width="80px">Bank name</asp:label></TD>
                <TD colSpan=3><asp:textbox id=txt_cq_bank Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" Width="300px" CssClass="formfield" MaxLength="120"></asp:textbox></TD></TR>
              <TR>
                <TD></TD>
                <TD><asp:label id=Label6 Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" Width="96px">Name on check</asp:label></TD>
                <TD colSpan=3><asp:textbox id=txt_cq_name Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" Width="300px" CssClass="formfield" MaxLength="120"></asp:textbox></TD></TR>
              <TR>
                <TD></TD>
                <TD><asp:label id=Label7 Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" Width="80px">Account</asp:label></TD>
                <TD><ASP:TEXTBOX id=txt_cq_account Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" Width="150px" CssClass="formfield" MaxLength="40"></ASP:TEXTBOX></TD>
                <TD><asp:label id=Label8 Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" Width="80px">Date check</asp:label></TD>
                <TD><ASP:TEXTBOX id=txt_cq_date Font-Size="8pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" Width="80px" CssClass="formfield" MaxLength="10"></ASP:TEXTBOX><asp:rangevalidator id=vld_cq_date runat="server" ErrorMessage="&amp;times" ControlToValidate="txt_cq_date" MinimumValue="1/1/1900" MaximumValue="1/1/2050" Type="Date"></asp:rangevalidator><asp:requiredfieldvalidator id=vld_cq_date2 runat="server" ErrorMessage="&amp;times;" ControlToValidate="txt_cq_date"></asp:requiredfieldvalidator></TD></TR></TABLE></TD></TR></TABLE></TD></TR>
  <TR>
    <TD><ASP:LABEL id=LABEL9 Font-Size="10pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" BorderWidth="1px" BorderStyle="Outset" BackColor="Linen" Font-Bold="True" Width="140px">Merchant notes</ASP:LABEL></TD></TR>
  <TR>
    <TD><asp:textbox id=txt_notes runat="server" Width="100%" CssClass="formfield" FONT-SIZE="10pt" Rows="5" Height="60px" TextMode="MultiLine"></asp:textbox></TD></TR></TABLE><ASP:LABEL id=hid_extrachargesPerc Font-Size="9pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" Width="16px" FONT-BOLD="True" Visible="False">0</ASP:LABEL><ASP:LABEL id=hid_providercode Font-Size="9pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" Width="16px" FONT-BOLD="True" Visible="False">0</ASP:LABEL><ASP:LABEL id=hid_PaymentType Font-Size="9pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" Width="16px" FONT-BOLD="True" Visible="False">0</ASP:LABEL><ASP:LABEL id=hid_interest Font-Size="9pt" Font-Names="verdana,arial" ForeColor="MidnightBlue" runat="server" Width="16px" FONT-BOLD="True" Visible="False">0</ASP:LABEL>
