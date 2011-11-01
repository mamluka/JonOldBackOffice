<%@ Control Language="vb" AutoEventWireup="false" Codebehind="csvstrip.ascx.vb" Inherits="ion_admin.csvstrip" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table style="BORDER-BOTTOM: black 1px solid" cellSpacing="0" cellPadding="0" width="1200"
	border="0">
	<tr>
		<td style="WIDTH: 72px" width="91"><asp:label id="itemnumber" runat="server"></asp:label></td>
		<td width="145"><asp:textbox id="e_category" runat="server" Width="96px" EnableViewState="False"></asp:textbox></td>
		<td width="145"><asp:textbox id="e_store_category" runat="server" Width="56px"></asp:textbox><asp:textbox id="e_store_category2" runat="server" Width="48px"></asp:textbox></td>
		<td width="278"><asp:textbox id="e_title" runat="server" Width="327px" MaxLength="55"></asp:textbox></td>
		<td width="290"><asp:textbox id="e_subtitle" runat="server" Width="322px" MaxLength="55"></asp:textbox></td>
		<td width="174"><asp:textbox id="e_price" runat="server" Width="104px" EnableViewState="False"></asp:textbox><asp:label id="e_currency" runat="server"></asp:label></td>
		<td width="77">
			<P><asp:hyperlink id="link_edit" runat="server" Target="_blank">Edit</asp:hyperlink><BR>
				<asp:hyperlink id="link_preview" runat="server" Target="_blank">Preview Aviby</asp:hyperlink><BR>
				<asp:HyperLink id="link_preview2" runat="server" Target="_blank">Preview Gems</asp:HyperLink></P>
		</td>
	</tr>
	<tr>
		<td style="WIDTH: 72px"><asp:label id="itemnumber2" runat="server" Text="Story"></asp:label></td>
		<td style="WIDTH: 72px" colSpan="6"><asp:textbox id="e_story" runat="server" Width="624px" Height="104px" TextMode="MultiLine"></asp:textbox></td>
	</tr>
	<tr>
		<td style="WIDTH: 72px">&nbsp;</td>
		<td style="WIDTH: 72px">&nbsp;</td>
		<td style="WIDTH: 72px" colSpan="5">&nbsp;</td>
	</tr>
</table>
