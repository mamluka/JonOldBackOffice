<%@ Register TagPrefix="uc1" TagName="ruler" Src="/webcontrols/ruler.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="link-exchange.aspx.vb" Inherits="ion_admin.link_exchange" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>editsidestones</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<style type="text/css"> .txt { PADDING-RIGHT: 5px; PADDING-LEFT: 5px; FONT-SIZE: 11px; PADDING-BOTTOM: 5px; COLOR: #000000; PADDING-TOP: 5px; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif } </style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table width="640" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td class="txt">
						<uc1:ruler id="Ruler1" runat="server"></uc1:ruler></td>
				</tr>
				<tr>
					<td class="txt"><table width="100%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td style="WIDTH: 229px">&nbsp;
									<asp:TextBox id="txt_body_Add" runat="server" TextMode="MultiLine" Width="200px" Height="80px"></asp:TextBox></td>
								<td style="WIDTH: 203px">&nbsp;
									<asp:TextBox id="txt_link_add" runat="server"></asp:TextBox></td>
								<td style="WIDTH: 113px">&nbsp;
									<asp:DropDownList id="cat_select_add" runat="server"></asp:DropDownList></td>
								<td>&nbsp;
									<asp:Button id="btn_Add" runat="server" Text="Add"></asp:Button></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td class="txt"><table width="100%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td style="WIDTH: 228px">&nbsp;
									<asp:TextBox id="txt_body_update" runat="server" TextMode="MultiLine" Width="200px" Height="80px"></asp:TextBox></td>
								<td style="WIDTH: 205px">&nbsp;
									<asp:TextBox id="txt_link_update" runat="server"></asp:TextBox></td>
								<td>&nbsp;
									<asp:DropDownList id="cat_select_update" runat="server"></asp:DropDownList></td>
								<td>&nbsp;
									<asp:Button id="btn_update" runat="server" Text="Update"></asp:Button></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td class="txt"><table width="100%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td width="6%">&nbsp;</td>
								<td width="26%">HTML</td>
								<td width="19%">Site</td>
								<td width="29%">Category</td>
								<td width="20%">&nbsp;</td>
							</tr>
							<%
							dim i as int32
							for i=0 to me.link_coll.count-1
							%>
							<tr>
								<td><%= convert.tostring(i+1) %></td>
								<td><%= me.link_coll(i).html %></td>
								<td><%= me.link_coll(i).url %></td>
								<td><%= me.link_coll(i).formatted_cat %></td>
								<td><a href="link-exchange.aspx?id=<%= convert.tostring(me.link_coll(i).id) %>">Edit</a></td>
							</tr>
							<% next %>
						</table>
					</td>
				</tr>
			</table>
			<script language="javascript1.1">
	  function redirect (id) {
	  window.location = '<% =Application("config").domain %>/new/editsidestones.aspx?action=edit&id=' + id
	  }
			</script>
		</form>
	</body>
</HTML>
