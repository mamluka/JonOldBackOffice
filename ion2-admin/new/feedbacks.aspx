<%@ Page Language="vb" AutoEventWireup="false" Codebehind="feedbacks.aspx.vb" Inherits="ion_admin.feedbacks" %>
<%@ Register TagPrefix="uc1" TagName="ruler" Src="../webcontrols/ruler.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>feedbacks</TITLE>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<style type="text/css">
		.txt {
	FONT-SIZE: 11px;
	FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif;
	padding: 2px;
}
	.items { WIDTH: 60px}
		.inside_txt {
	font-family: Verdana, Arial, Helvetica, sans-serif;
	font-size: 11px;
}
        </style>
		
	<script language="javascript">
	
	function feedback_save(indexid) {
///	alert(indexid)
    var tr = document.getElementById('feedback_'+indexid)
//    alert(tr)
    var feed_text = tr.getElementsByTagName('TD')[3].getElementsByTagName('TEXTAREA')[0].innerText
    var item_pic =  tr.getElementsByTagName('TD')[5].getElementsByTagName('INPUT')[0].value
    var item_sort =  tr.getElementsByTagName('TD')[6].getElementsByTagName('INPUT')[0].value
    var feed_active
    
    if  (tr.getElementsByTagName('TD')[7].getElementsByTagName('INPUT')[0].checked) {
        feed_active = 1
        
    } else {
    
        feed_active = 0
    }
	
	var show_email
	
	  if  (tr.getElementsByTagName('TD')[4].getElementsByTagName('INPUT')[0].checked) {
        show_email = 1
        
    } else {
    
        show_email = 0
    }
    
//    alert(feed_text+item_pic+item_sort+feed_active)

    window.location = 'feedbacks.aspx?feed_text='+feed_text+'&item_pic='+item_pic+'&item_sort='+item_sort+'&active='+feed_active+'&id=' + indexid + '&email='+show_email
	
	}

	function view_item(indexid,req) {

	var item_id
	
	var tr = document.getElementById('feedback_'+indexid)
	
	if (req == 1 ) {
		item_id =  tr.getElementsByTagName('TD')[5].getElementsByTagName('INPUT')[0].value
	}
	else {
		item_id =  tr.getElementsByTagName('TD')[6].getElementsByTagName('INPUT')[0].value
	
	}

	if ( item_id == 0 ) { 
		alert('Item not set')

	}
	else {
		window.open('http://www.twin-diamonds.com/showitem.aspx?id='+item_id,'mywin'+item_id)
		}
		
	}
	
	</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="900" border="0">
				<tr>
					<td><uc1:ruler id="Ruler1" runat="server"></uc1:ruler></td>
				</tr>
				<tr>
					<td>
						<table cellSpacing="0" cellPadding="0" width="900" border="0">
							<tr>
								<td class="txt" width="36" bgColor="#eaeaea">ID</td>
								<td class="txt" width="67" bgColor="#eaeaea">Name</td>
								<td class="txt" width="87" bgColor="#eaeaea">Country</td>
								<td class="txt" width="290" bgColor="#eaeaea">Feedback</td>
								<td class="txt" width="197" bgColor="#eaeaea">Email</td>
								<td class="txt" width="64" bgColor="#eaeaea">Image Item								</td>
								<td class="txt" width="61" bgColor="#eaeaea">Category Item								</td>
								<td class="txt" width="39" bgColor="#eaeaea">Active</td>
								<td class="txt" width="59" bgColor="#eaeaea">Edit</td>
							</tr>
							<%
							dim i as int32
							for i=0 to me.feedback_coll.count-1
							%>
							<tr id="feedback_<%= convert.tostring(me.feedback_coll(i).id) %>" >
								<td vAlign="top" class="inside_txt"><%= convert.tostring(me.feedback_coll(i).id) %></td>
								<td vAlign="top" class="inside_txt"><%= me.feedback_coll(i).name %></td>
								<td align="center" vAlign="top" class="inside_txt"><%= me.feedback_coll(i).country %></td>
								<td vAlign="top" class="inside_txt"><textarea style="WIDTH: 290px; HEIGHT: 70px" name="textarea"><%= me.feedback_coll(i).text %></textarea></td>
						      <td vAlign="top" class="inside_txt"><%= me.feedback_coll(i).email %>
						        <input type="checkbox" name="checkbox2" value="checkbox" <%= me.feedback_coll(i).showemail %>></td>
						      <td vAlign="top" class="inside_txt"><input class="items" type="text" name="textfield" value="<%= me.feedback_coll(i).item_pic %>">
							    <br>
							    <a href="javascript:view_item(<%= convert.tostring(me.feedback_coll(i).id) %>,1)" >View Item</a> </td>
								<td vAlign="top" class="inside_txt"><input class="items" type="text" name="textfield2" value="<%= me.feedback_coll(i).item_sort %>"><br>
 <a href="javascript:view_item(<%= convert.tostring(me.feedback_coll(i).id) %>,2)" >View Item</a>							  </td>
							  <td align="center" vAlign="top" class="inside_txt"><input type="checkbox" value="checkbox" name="checkbox" <%= me.feedback_coll(i).active %>></td>
								<td align="right" vAlign="top" class="inside_txt"><input type="button" value="Save" name="Button" onClick="feedback_save(<%= convert.tostring(me.feedback_coll(i).id) %>)"></td>
							</tr>
							<% next %>
					  </table>
					</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
				</tr>
		  </table>
		  <%= me.errorstr %>
		</form>
	</body>
</HTML>
