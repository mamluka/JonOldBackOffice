<%@ Page Language="vb" AutoEventWireup="false" Codebehind="banners.aspx.vb" Inherits="ion_admin.banners" EnableViewState="True" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>banners</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<style type="text/css">
BODY { BACKGROUND-COLOR: #dadada }
		</style>
		<script language="JavaScript" type="text/javascript">
function view_banner (url) {
window.open('new/banner_view.aspx?file='+url,'bannerwin','width=300,height=350')
}
</script>

	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
Edit the banner links and files, banners that has the View buttons <br>
<br>
<br>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td width="9%">Banner1:</td>
					<td width="42%"><input id="banner1_file" style="BORDER-RIGHT: 1px groove; BORDER-TOP: 1px groove; FONT-SIZE: 8pt; BORDER-LEFT: 1px groove; WIDTH: 312px; COLOR: midnightblue; BORDER-BOTTOM: 1px groove; FONT-FAMILY: verdana,arial; HEIGHT: 19px; BACKGROUND-COLOR: ghostwhite"
							type="file" size="32" name="File15" runat="server" >
				    <input type="button" name="Button" value="View" <% =Me.banner_view_html(0) %> ></td>
					<td width="35%">&nbsp;Link:
					  <asp:TextBox id="banner1_link" runat="server" Width="250"></asp:TextBox></td>
					<td width="14%"><asp:CheckBox ID="clear1" Text="Clear" runat="server"  EnableViewState="False" /></td>
				</tr>
				<tr>
					<td>Banner2:</td>
					<td><input id="banner2_file" style="BORDER-RIGHT: 1px groove; BORDER-TOP: 1px groove; FONT-SIZE: 8pt; BORDER-LEFT: 1px groove; WIDTH: 312px; COLOR: midnightblue; BORDER-BOTTOM: 1px groove; FONT-FAMILY: verdana,arial; HEIGHT: 19px; BACKGROUND-COLOR: ghostwhite"
							type="file" size="32" name="File12" runat="server">
				    <input type="button" name="Button2" value="View" <% =Me.banner_view_html(1) %>></td>
					<td>&nbsp;Link:
						<asp:TextBox id="banner2_link" runat="server" Width="250"></asp:TextBox></td>
					<td><asp:CheckBox ID="clear2" Text="Clear" runat="server"  EnableViewState="False"/></td>
				</tr>
				<tr>
					<td>Banner3:</td>
					<td><input id="banner3_file" style="BORDER-RIGHT: 1px groove; BORDER-TOP: 1px groove; FONT-SIZE: 8pt; BORDER-LEFT: 1px groove; WIDTH: 312px; COLOR: midnightblue; BORDER-BOTTOM: 1px groove; FONT-FAMILY: verdana,arial; HEIGHT: 19px; BACKGROUND-COLOR: ghostwhite"
							type="file" size="32" name="File13" runat="server" >
				    <input type="button" name="Button3" value="View" <% =Me.banner_view_html(2) %>></td>
					<td>&nbsp;Link:
						<asp:TextBox id="banner3_link" runat="server" Width="250"></asp:TextBox></td>
					<td><asp:CheckBox ID="clear3" Text="Clear" runat="server"  EnableViewState="False"/></td>
				</tr>
				<tr>
					<td>Banner4:</td>
					<td><input id="banner4_file" style="BORDER-RIGHT: 1px groove; BORDER-TOP: 1px groove; FONT-SIZE: 8pt; BORDER-LEFT: 1px groove; WIDTH: 312px; COLOR: midnightblue; BORDER-BOTTOM: 1px groove; FONT-FAMILY: verdana,arial; HEIGHT: 19px; BACKGROUND-COLOR: ghostwhite"
							type="file" size="32" name="File14" runat="server" >
				    <input type="button" name="Button4" value="View" <% =Me.banner_view_html(3) %>></td>
					<td>&nbsp;Link:
						<asp:TextBox id="banner4_link" runat="server" Width="250"></asp:TextBox></td>
					<td><asp:CheckBox ID="clear4" Text="Clear" runat="server" EnableViewState="False" /></td>
				</tr>
				<tr>
					<td>Banner5:</td>
					<td><input id="banner5_file" style="BORDER-RIGHT: 1px groove; BORDER-TOP: 1px groove; FONT-SIZE: 8pt; BORDER-LEFT: 1px groove; WIDTH: 312px; COLOR: midnightblue; BORDER-BOTTOM: 1px groove; FONT-FAMILY: verdana,arial; HEIGHT: 19px; BACKGROUND-COLOR: ghostwhite"
							type="file" size="32" name="File1" runat="server">
				    <input type="button" name="Button5" value="View" <% =Me.banner_view_html(4) %>></td >
					<td>&nbsp;Link:
					  <asp:TextBox id="banner5_link" runat="server" Width="250"></asp:TextBox></td>
					<td><asp:CheckBox ID="clear5" Text="Clear" runat="server"  EnableViewState="False"/></td>
				</tr>
				<tr>
				  <td>&nbsp;</td>
				  <td>&nbsp;</td >
				  <td>&nbsp;</td>
				  <td><br>
			        <br>
	              <asp:Button ID="Go1" runat="server" Text="Save"></asp:Button></td>
    </tr>
			</table>
		</form>
	</body>
</HTML>
