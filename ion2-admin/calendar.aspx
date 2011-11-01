<%@ Page Language="vb" AutoEventWireup="false" Codebehind="calendar.aspx.vb" Inherits="ion_admin.calendar"%>
<asp:Literal id=lit_1 runat="server"></asp:Literal>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		
		<LINK href="/styleforms.css" type=text/css rel=StyleSheet>
  </HEAD>

<body bgColor=#4a576e LEFTMARGIN="0" RIGHTMARGIN="0" TOPMARGIN="0" BOTTOMMARGIN="0">

<form id="Form1" method="post" runat="server">
<TABLE height=173 cellSpacing=0 cellPadding=0 width=157 border=0 ms_2d_layout="TRUE">
<TR vAlign=top>
	<TD width=1 height=173></TD>
    <TD width=156>
		<asp:calendar id=Calendar1 runat="server" Width="240px" BorderColor="Black" CellSpacing="1" BackColor="White" ForeColor="Black" Font-Size="8pt" BorderStyle="Solid" Font-Names="Verdana" Height="136px" NextPrevFormat="ShortMonth">
			<TodayDayStyle Font-Bold="True" BorderWidth="2px" ForeColor="DarkSlateBlue" BorderStyle="Double" BackColor="AliceBlue">
			</TodayDayStyle>

<DayStyle BorderWidth="1px" BorderStyle="Outset" BorderColor="White" BackColor="Gainsboro">
</DayStyle>

<NextPrevStyle Font-Size="8pt" Font-Bold="True" ForeColor="White">
</NextPrevStyle>

<DayHeaderStyle Font-Size="8pt" Font-Bold="True" Height="8pt" BorderWidth="1px" ForeColor="#FFFFC0" BorderStyle="Outset" BorderColor="White" BackColor="SteelBlue">
</DayHeaderStyle>

<SelectedDayStyle ForeColor="White" BackColor="#333399">
</SelectedDayStyle>

<TitleStyle Font-Size="12pt" Font-Bold="True" Height="12pt" ForeColor="White" BackColor="DarkSlateBlue">
</TitleStyle>

<WeekendDayStyle ForeColor="DimGray" BackColor="Silver">
</WeekendDayStyle>

<OtherMonthDayStyle ForeColor="#999999">
</OtherMonthDayStyle>
</asp:calendar></TD></TR>
</TABLE>
  
		</form>

  </body>
</HTML>
