<%@ Control Language="vb" AutoEventWireup="false" Codebehind="help_script.ascx.vb" Inherits="ion_admin.help_script" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<script language="javascript">
function gethelp(nid){
	mywin=window.open('/help.aspx?id='+nid,"displayWindow","resizable=yes,scrollbars=yes,toolbar=no,height=390,width=384");
}

</script>
