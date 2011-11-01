<%@ Control Language="vb" AutoEventWireup="false" Codebehind="wc_cart_content.ascx.vb" Inherits="ion_admin.cart_content" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Import Namespace="ion_resources" %>


<TABLE ID=tbl_cart CELLSPACING=0 CELLPADDING=0 WIDTH="100%" BORDER=0>
<TR>
	<TD colspan="2">
		<ASP:LABEL id=Label17 ForeColor="MidnightBlue" Font-Size="10pt" Font-Names="verdana,arial" Width="150px" runat="server" BorderWidth="1px" BorderStyle="Outset" BackColor="Linen" Font-Bold="True"> Items ordered</ASP:LABEL>
	</TD>
</TR>
<TR>
	<%Dim nLoop as Integer = 1%>
	<%For Each item As cls_order_items In me.orderItems %>
   
	
    
    <TD vAlign=top align=left width=60>
		<TABLE style="BORDER-RIGHT: 2px groove; BORDER-TOP: 2px groove; FONT-SIZE: 8pt; BORDER-LEFT: 2px groove; COLOR: midnightblue; BORDER-BOTTOM: 2px groove; FONT-FAMILY: verdana,arial; BACKGROUND-COLOR: linen" cellSpacing=0 cellPadding=0 border=0>
		<TR>
			<TD bgcolor="gainsboro">
        		<%If item.icon <> "" Then  %>
					<IMG src="<%=item.icon%>" border=0>
				<%Else%>
					<IMG src="/pic/no_icon.gif" border=0 >
				<%End If%>
			</TD>
		</TR>
		</TABLE>
	</TD>
	
	<TD vAlign=top align=left width="100%">
		<TABLE id=tbl_cart_in style="BORDER-RIGHT: 2px groove; BORDER-TOP: 2px groove; FONT-SIZE: 8pt; BORDER-LEFT: 2px groove; COLOR: midnightblue; BORDER-BOTTOM: 2px groove; FONT-FAMILY: verdana,arial; BACKGROUND-COLOR: linen" cellSpacing=0 cellPadding=0 width="100%" border=0>
		<TR height=20>
			<TD vAlign=top>
				
					<%If item.jewelsize.trim <> "" Then%>
						&nbsp;&nbsp;&nbsp;&nbsp;
						<b>[Ring size:&nbsp;<%=item.jewelsize%>]</b>
					<%End If%>				
			</TD>
			
		</TR>
		<TR height=20>
			<TD vAlign=top>
				<% =(item.description)				%>
			</TD>
			<TD style="BORDER-RIGHT: #708090 1px groove; BORDER-TOP: #708090 1px groove; BORDER-LEFT: #708090 1px groove; BORDER-BOTTOM: #708090 1px groove" vAlign=middle align=right width=100>
				<%=Convert.ToString(Format(item.price*me.currency_rate, "##,##0.00"))+" " + me.Currency_Symbol %>
			</TD>
		</TR>
        <TR>
			<TD align=right>
				<ASP:LABEL id=Label3 runat="server" Width="130px" Font-Names="verdana,arial" Font-Size="8pt" ForeColor="MidnightBlue">Quantity to purchase</ASP:LABEL>
				<FONT style="BORDER-RIGHT: 1px groove; BORDER-TOP: 1px groove; FONT-SIZE: 8pt; PADDING-BOTTOM: 1px; BORDER-LEFT: 1px groove; COLOR: dimgray; PADDING-TOP: 1px; BORDER-BOTTOM: 1px groove; FONT-FAMILY: verdana,arial; BACKGROUND-COLOR: silver" >&nbsp;<%=item.item_quantity%>&nbsp;</FONT>
			 </TD>
			<TD style="BORDER-RIGHT: #708090 1px ridge; BORDER-TOP: #708090 1px ridge; BORDER-LEFT: #708090 1px ridge; BORDER-BOTTOM: #708090 1px ridge" vAlign=middle align=right width=100>
				
				<B><%=Convert.ToString(Format(item.price  , "##,##0.00"))+" " + me.Currency_Symbol %></B>
			</TD>
		</TR>
		</TABLE>
	</TD>
</TR>
<%Next%>
  
    

 </TABLE>
