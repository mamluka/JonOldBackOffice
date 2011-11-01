<%@ Page Language="vb" AutoEventWireup="false" Codebehind="banner_view.aspx.vb" Inherits="ion_admin.banner_view" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>banner_view</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1"><style type="text/css">
<!--
body {
	margin-left: 7px;
	margin-top: 7px;
	margin-right: 7px;
	margin-bottom: 7px;
}
-->
</style></HEAD>
	<body>
		<form id="Form1" method="post" runat="server">

		  <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td align="center">Preview of the banner file</td>
            </tr>
            <tr>
              <td align="center"><img src="<% =request.QueryString("file")%>"></td>
            </tr>
          </table>

		</form>
	</body>
</HTML>
