<%@ Register TagPrefix="uc1" TagName="ruler" Src="../webcontrols/ruler.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="search_edit.aspx.vb" Inherits="ion_admin.search_edit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>search_edit</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td>
						<uc1:ruler id="Ruler1" runat="server"></uc1:ruler></td>
				</tr>
				<tr>
					<td><table width="100%" border="0" cellspacing="20" cellpadding="0">
							<tr>
								<td style="WIDTH: 484px">
							  <asp:ListBox id="search_list" runat="server" Width="488px" Height="387px"></asp:ListBox></td>
								<td rowspan="2" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td style="WIDTH: 48px">&nbsp;</td>
											<td>&nbsp;
												<asp:TextBox id="string_txt" runat="server"></asp:TextBox></td>
										</tr>
										<tr>
											<td style="WIDTH: 48px">&nbsp;</td>
											<td>&nbsp;
												<asp:TextBox id="url_txt" runat="server" Width="216px" Rows="3" TextMode="MultiLine" Height="88px"></asp:TextBox></td>
										</tr>
										<tr>
											<td style="WIDTH: 48px">&nbsp;</td>
											<td>&nbsp;
												<asp:Button id="btm_add" runat="server" Text="Add"></asp:Button></td>
										</tr>
									</table>
							  </td>
							</tr>
							<tr>
								<td style="WIDTH: 484px">&nbsp;
									<asp:Button id="btn_edit" runat="server" Text="Edit"></asp:Button>
									<asp:Button id="btn_delete" runat="server" Text="Delete"></asp:Button></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
