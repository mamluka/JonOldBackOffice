<%@ Page Language="vb" AutoEventWireup="false" Codebehind="newfeedbacks.aspx.vb" Inherits="ion_admin.newfeedbacks"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>newfeedbacks</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:TextBox style="Z-INDEX: 100; POSITION: absolute; TOP: 24px; LEFT: 184px" id="txt_title"
				runat="server" Width="240px" Height="24px"></asp:TextBox>
			<asp:Label style="Z-INDEX: 117; POSITION: absolute; TOP: 344px; LEFT: 72px" id="Label8" runat="server">Date</asp:Label>
			<asp:Label style="Z-INDEX: 115; POSITION: absolute; TOP: 384px; LEFT: 72px" id="Label7" runat="server">rating</asp:Label>
			<asp:TextBox style="Z-INDEX: 114; POSITION: absolute; TOP: 384px; LEFT: 184px" id="txt_rating"
				runat="server" Width="40px"></asp:TextBox>
			<asp:DropDownList style="Z-INDEX: 113; POSITION: absolute; TOP: 312px; LEFT: 184px" id="cmd_platetype"
				runat="server">
				<asp:ListItem Value="3">Jewelry</asp:ListItem>
				<asp:ListItem Value="2">Gemstone</asp:ListItem>
				<asp:ListItem Value="1">Diamond</asp:ListItem>
			</asp:DropDownList>
			<asp:Label style="Z-INDEX: 112; POSITION: absolute; TOP: 248px; LEFT: 72px" id="Label6" runat="server">Itemnumer</asp:Label>
			<asp:TextBox style="Z-INDEX: 111; POSITION: absolute; TOP: 248px; LEFT: 184px" id="txt_itemnumber"
				runat="server" Width="112px" Height="24px"></asp:TextBox>
			<asp:Label style="Z-INDEX: 106; POSITION: absolute; TOP: 216px; LEFT: 72px" id="Label5" runat="server">Name</asp:Label>
			<asp:DropDownList style="Z-INDEX: 109; POSITION: absolute; TOP: 280px; LEFT: 184px" id="cmd_country"
				runat="server" Width="128px"></asp:DropDownList>
			<asp:Label style="Z-INDEX: 108; POSITION: absolute; TOP: 280px; LEFT: 72px" id="Label4" runat="server">Country</asp:Label>
			<asp:Label style="Z-INDEX: 105; POSITION: absolute; TOP: 216px; LEFT: 72px" id="Label3" runat="server">Name</asp:Label>
			<asp:Label style="Z-INDEX: 104; POSITION: absolute; TOP: 64px; LEFT: 64px" id="Label2" runat="server">Text</asp:Label>
			<asp:Label style="Z-INDEX: 103; POSITION: absolute; TOP: 24px; LEFT: 64px" id="Label1" runat="server">Title:</asp:Label>
			<asp:TextBox style="Z-INDEX: 101; POSITION: absolute; TOP: 64px; LEFT: 184px" id="txt_text" runat="server"
				Width="240px" Height="144px" TextMode="MultiLine"></asp:TextBox>
			<asp:TextBox style="Z-INDEX: 102; POSITION: absolute; TOP: 216px; LEFT: 184px" id="txt_name"
				runat="server" Width="240px" Height="24px"></asp:TextBox>
			<asp:Button style="Z-INDEX: 110; POSITION: absolute; TOP: 424px; LEFT: 384px" id="Button1" runat="server"
				Text="Save"></asp:Button>
			<asp:TextBox style="Z-INDEX: 116; POSITION: absolute; TOP: 344px; LEFT: 184px" id="txt_date"
				runat="server" Width="104px"></asp:TextBox>
		</form>
	</body>
</HTML>
