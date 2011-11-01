<%@ OutputCache Duration="1" VaryByParam="none" Location="none"%>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="editsidestones.aspx.vb" Inherits="ion_admin.editsidestones" %>
<%@ Register TagPrefix="uc1" TagName="ruler" Src="/webcontrols/ruler.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>editsidestones</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<style type="text/css"> <!-- .txt { font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: #000000; padding: 5px; }
	--> 
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
	<form id="Form1" method="post" runat="server">
	  <table width="640" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td class="txt">		<uc1:ruler id="Ruler1" runat="server"></uc1:ruler></td>
        </tr>
        <tr>
          <td class="txt">Use thie table to edit the side stones entry tables
             <br>
            <br>
             sort by shape:
             <asp:DropDownList CssClass="txt" ID="shape_select" runat="server" AutoPostBack="true"></asp:DropDownList></td>
        </tr>
        <tr>
          <td class="txt" style="display:<% =me.edit_html %>"><table width="846" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="184" class="txt"><% =me.edit_desc %></td>
                <td width="231" class="txt">New Size 
                <asp:TextBox ID="edit_size" runat="server" /></td>
                <td width="299" class="txt">New price:
                <asp:TextBox ID="edit_price" runat="server" Width="60" />
                (D-F) 
                <asp:TextBox ID="edit_price2" runat="server" Width="60" />
                (G-H)</td>
                <td width="132"><asp:Button ID="go_save" runat="server" Text="Save" />
                <asp:Button ID="go_cancel" runat="server" Text="Cancel" /></td>
              </tr>
          </table></td>
        </tr>
        <tr>
          <td><table width="948" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="33" align="center" class="txt">&nbsp;</td>
                <td width="126" align="center" class="txt">shape</td>
                <td width="248" align="center" class="txt">weight</td>
                <td width="149" align="center" class="txt">size</td>
                <td width="144" align="center" class="txt">total price 
                  <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td align="center" class="txt">D-F</td>
                      <td align="center" class="txt">G-H</td>
                    </tr>
                  </table></td>
                <td width="144" align="center" class="txt">price per carat 
                  <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td align="center" class="txt">D-F</td>
                      <td align="center" class="txt">G-H</td>
                    </tr>
                  </table></td>
                <td width="104" align="center" >&nbsp;</td>
              </tr>
              <% 
		  dim i as int32
		  for i=0 to me.table_coll.count -1 
		  
		  %>
              <tr <% if convert.tostring(me.table_coll(i).id) = request.QueryString("id") then response.Write("bgcolor='#CCCCCC'")%> >
                <td align="center" class="txt"><% =convert.tostring(i) %></td>
                <td align="center" class="txt"><%= me.table_coll(i).shape %></td>
                <td align="center" class="txt"><%= me.table_coll(i).weight %>x2</td>
                <td align="center" class="txt"><%= me.table_coll(i).size %>mm</td>
                <td align="center" class="txt"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td align="center" class="txt"><%= me.table_coll(i).total %> </td>
                    <td align="center" class="txt"><%= convert.tostring(Math.round(convert.todecimal(me.table_coll(i).total)*0.8)) %></td>
                  </tr>
                </table>
                </td>
                <td align="center" class="txt"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td align="center" class="txt"><%= convert.tostring(me.table_coll(i).price) %></td>
                    <td align="center" class="txt"><%= convert.tostring(Math.round(convert.todecimal(me.table_coll(i).price)*0.8)) %></td>
                  </tr>
                </table>
                </td>
                <td align="center" class="txt"><a href="#" onClick="redirect(<% =convert.tostring(me.table_coll(i).id) %>)" >Edit</a> <a href="javascript:void(0)" > Delete </a></td>
              </tr>
              <% next%>
          </table></td>
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
