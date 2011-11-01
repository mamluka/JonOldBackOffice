Imports System.Web.Mail

Public Class cls_mailing
	Inherits iFoundation.cls_error_connection

	Public _User As ion_two.cls_user
	Public _Cart As ion_two.cls_shopping_cart
	Public _Config As ion_two.cls_config
	Public _Order As ion_two.skl_order
	Public _local_domain As String

	Public _mailto As String
	Public _from As String
	Public _subject As String
	Public _content As String
	Public _contenttype As Integer
	Public _hiddencontent As String

	Public Function send() As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		Dim oMail As New MailMessage

		If Me._from = "" Then
			oMail.From = "sales@twin-diamonds.com"
		Else
			oMail.From = Me._from
		End If


		oMail.To = Me._mailto.Trim
		oMail.Bcc = "followup@twin-diamonds.com"
		oMail.Subject = Me._subject + "  [" + Me._mailto.Trim + "]"
		oMail.BodyFormat = MailFormat.Html
		oMail.Priority = MailPriority.High
        SmtpMail.SmtpServer = "127.0.0.1" ''Me._Config._mail._smtpserver
		'--- Put content in message and continue processing further content
		oMail.Body = Me._content

		Dim cMsg As String
		Select Case Me._contenttype
			Case 1			  '--- Welcome Mail
				bError = welcome_msg(cMsg)
				bError = footer(cMsg)
				oMail.Body = oMail.Body + cMsg

			Case 2			  '--- Thank you for purchasing
				bError = cart_content(cMsg)
				bError = footer(cMsg)
				oMail.Body = oMail.Body + cMsg

			Case 3
				bError = admin_footer(cMsg)
				oMail.Body = oMail.Body + cMsg

			Case 4
				bError = footer(cMsg)
				oMail.Body = oMail.Body + cMsg

			Case 51			  '--- ADMIN - User applied for Dealer
				bError = admin_dealer_request(cMsg)
				bError = admin_footer(cMsg)
				oMail.Body = oMail.Body + cMsg

			Case 52			  '--- ADMIN - Inventory item below stock
				bError = InventoryItemBelowStock(cMsg)
				bError = admin_footer(cMsg)
				oMail.Body = oMail.Body + cMsg

		End Select


		SmtpMail.Send(oMail)

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Function InventoryItemBelowStock(ByRef cMsg As String) As Boolean
		Dim bError As Boolean = False

		cMsg = cMsg + "<font color='#330066' face='verdana,arial' size='1'>"
		cMsg = cMsg + Me._hiddencontent
		cMsg = cMsg + "</font>"

	End Function

	Function admin_dealer_request(ByRef cMsg As String) As Boolean
		cMsg = cMsg + "<font color='#330066' face='verdana,arial' size='2'>"
		cMsg = cMsg + "User : " + Me._User._name + "<br>"
		cMsg = cMsg + "E-mail : " + Me._User._email + "<br>"
		cMsg = cMsg + "Registered : " + Me._User._createdate + "<br><br>"
		cMsg = cMsg + "Has applyed for DEALER status. <br>"
		cMsg = cMsg + "</font>"
	End Function

	Function welcome_msg(ByRef cMsg As String) As Boolean

		cMsg = cMsg + "<font color='#330066' face='verdana,arial' size='2'>"
		cMsg = cMsg + "Dear " + Me._User._name + ",<br><br>"
		cMsg = cMsg + "We are very pleased to add your name to our customer database.<br>"
		cMsg = cMsg + "When you do business with Twin-diamonds.com, you join a dynamic and resourceful company that goes<br>"
		cMsg = cMsg + "to great lengths to bring you added value.<br>"
		cMsg = cMsg + "Please retain your User name and Password for future use:<br><br>"
		cMsg = cMsg + "Login: " + Me._User._email + "<br>"
		cMsg = cMsg + "Password: " + Me._User._password + "<br><br>"
		cMsg = cMsg + "In the future, we will be happy to provide you with more items from our beautiful<br>"
		cMsg = cMsg + "collection at the best prices available<br>"
		cMsg = cMsg + "For information on purchases, shipping and handling, please read the Terms & Conditions page.<br>"
		cMsg = cMsg + "<br>"
		cMsg = cMsg + "Regards,<br>"
		cMsg = cMsg + "<b>Twin-diamonds.com</b><br>"
		cMsg = cMsg + "</font>"

	End Function

	Function admin_footer(ByRef cMsg As String) As Boolean
		cMsg = cMsg + "<br><hr align='left' color='#808080'>"
		cMsg = cMsg + ""
		cMsg = cMsg + "<table cellspacing='0' cellpadding='0' border='0' width='100%'>"
		cMsg = cMsg + "<tr><td>"
		cMsg = cMsg + "<font color='#330066' face='verdana,arial' size='1'>"
		cMsg = cMsg + "Generated:" & System.Convert.ToString(Now)
		cMsg = cMsg + "</font>"
		cMsg = cMsg + "</td>"
		cMsg = cMsg + "<td align='right'>"
		cMsg = cMsg + "<font color='#330066' face='verdana,arial' size='1'>"
		cMsg = cMsg + "ion-sg ver. " + Me._Config._ionversion
		cMsg = cMsg + "</font>"
		cMsg = cMsg + "</td></tr>"
		cMsg = cMsg + "</table>"
	End Function

	Function footer(ByRef cMsg As String) As Boolean
		cMsg = cMsg + "<br><hr align='left' color='#808080'>"
		cMsg = cMsg + "<font color='#330066' face='verdana,arial' size='1'><b>"
		cMsg = cMsg + "<big>Twin-diamonds.com</big><br>"
		cMsg = cMsg + "Israel Diamond Exchange - Maccabi Building, Suit #150<br>"
		cMsg = cMsg + "P.O.Box 3205<br>"
		cMsg = cMsg + "Ramat-Gan<br>"
		cMsg = cMsg + "Israel 52521<br><br>"
		cMsg = cMsg + "Phone: +972-54-3974161 (US 1-866-215-3174)<br>"
		cMsg = cMsg + "Fax: +972-3-6202007 <br><br>"
		cMsg = cMsg + "For questions please contact us by e-mail: <a href='mailto:sales@twin-diamonds.com'>sales@twin-diamonds.com</a>"
		cMsg = cMsg + "</b></font>"
		cMsg = cMsg + "<hr align='left' color='#808080'>"
	End Function

	Function cart_content(ByRef cMsg As String) As Boolean
		Dim bError As Boolean = False

		Dim cCountry_shipping, cCountry_billing, cState_shipping, cState_billing As String
		Dim oTmpFunction As New ion_two.cls_functions_user
		oTmpFunction._connection_string = Me._connection_string
		oTmpFunction._dbtype = Me._dbtype

		bError = oTmpFunction.get_countryname(Me._Order._adrs_billing_country_id, cCountry_billing)
		bError = oTmpFunction.get_countryname(Me._Order._adrs_shipping_country_id, cCountry_shipping)
		bError = oTmpFunction.get_statename(Me._Order._adrs_billing_state_id, cState_billing)
		bError = oTmpFunction.get_statename(Me._Order._adrs_shipping_state_id, cState_shipping)

		cMsg = cMsg + "<TABLE ID=tbl_border STYLE='BORDER-RIGHT: 1px groove; BORDER-TOP: 1px groove; BORDER-LEFT: 1px groove; BORDER-BOTTOM: 1px groove; background-color: Linen' CELLSPACING=0 CELLPADDING=3 WIDTH='650' BORDER=0>"
		cMsg = cMsg + "<TR><TD>"
		cMsg = cMsg + "<table id='tbl_mailinfo' cellpadding='0' cellspacing='0' border='0' width='650'>"
		cMsg = cMsg + "<tr>"
		cMsg = cMsg + "    <td colspan='2'>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>Dear " + Me._User._name + ",</b><br><br>"
		cMsg = cMsg + "        We appreciate the order that you placed with us today and will do our utmost to give you fast and professional service. For faster checkout in the future please enter the following Email and password when you place your order:"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "</tr>"
		cMsg = cMsg + "<tr>"
		cMsg = cMsg + "    <td width='100'>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>Email:</b></font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "    <td width='550'>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + Me._User._email + "&nbsp;</font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "</tr>"
		cMsg = cMsg + "<tr>"
		cMsg = cMsg + "    <td width='100'>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>Password:</b></font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "    <td>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + Me._User._password + "&nbsp;</font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "</tr>"
		cMsg = cMsg + "<tr>"
		cMsg = cMsg + "    <td colspan='2'>"
		cMsg = cMsg + "        &nbsp;"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "</tr>"
		cMsg = cMsg + "<tr>"
		cMsg = cMsg + "    <td colspan='2'>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>"
		cMsg = cMsg + "        To view the status of your order please go to <a href= " + Me._User._domain + "/customer-status.aspx><u>click here</u></a>"
		cMsg = cMsg + "        </font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "</tr>"
		cMsg = cMsg + "<tr>"
		cMsg = cMsg + "    <td colspan='2'>"
		cMsg = cMsg + "        &nbsp;"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "</tr>"
		cMsg = cMsg + "<tr>"
		cMsg = cMsg + "    <td width='100'>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>Order number:</b></font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "    <td>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + System.Convert.ToString(Me._Order._ordernumber) + "&nbsp;</font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "</tr>"
		cMsg = cMsg + "<tr>"
		cMsg = cMsg + "    <td width='100'>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>Order date:</b></font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "    <td>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + System.Convert.ToString(Me._Order._orderdate) + "&nbsp;(local time, GMT +2)</font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "</tr>"
		cMsg = cMsg + "</table>"
		cMsg = cMsg + "<br>"
		cMsg = cMsg + "<table id='tbl_addressinfo' cellpadding='0' cellspacing='0' border='0' width='650'>"
		cMsg = cMsg + "<tr>"
		cMsg = cMsg + "    <td>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b><u>Shipping address</u></b></font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "    <td>"
		cMsg = cMsg + "        &nbsp;"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "    <td>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b><u>Billing address</u></b></font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "    <td>"
		cMsg = cMsg + "        &nbsp;"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "</tr>"
		cMsg = cMsg + "<tr>"
		cMsg = cMsg + "    <td width='100'>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>Name:</b></font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "    <td>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + Me._Order._adrs_shipping_name + "&nbsp;</font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "    <td width='100'>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>Name:</b></font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "    <td>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + Me._Order._adrs_billing_name + "&nbsp;</font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "</tr>"
		cMsg = cMsg + "<tr>"
		cMsg = cMsg + "    <td width='100'>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>Street:</b></font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "    <td>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + Me._Order._adrs_shipping_street + "&nbsp;</font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "    <td width='100'>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>Street:</b></font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "    <td>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + Me._Order._adrs_billing_street + "&nbsp;</font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "</tr>"
		cMsg = cMsg + "<tr>"
		cMsg = cMsg + "    <td width='100'>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>City:</b></font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "    <td>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + Me._Order._adrs_shipping_city + "&nbsp;</font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "    <td width='100'>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>City:</b></font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "    <td>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + Me._Order._adrs_billing_city + "&nbsp;</font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "</tr>"
		cMsg = cMsg + "<tr>"
		cMsg = cMsg + "    <td width='100'>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>Country:</b></font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "    <td>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + cCountry_shipping + "&nbsp;</font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "    <td width='100'>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>Country:</b></font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "    <td>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + cCountry_billing + "&nbsp;</font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "</tr>"
		cMsg = cMsg + "<tr>"
		cMsg = cMsg + "    <td width='100'>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>State:</b></font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "    <td>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + cState_shipping + "&nbsp;</font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "    <td width='100'>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>State:</b></font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "    <td>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + cState_billing + "&nbsp;</font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "</tr>"
		cMsg = cMsg + "<tr>"
		cMsg = cMsg + "    <td width='100'>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>Zip:</b></font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "    <td>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + Me._Order._adrs_shipping_zip + "&nbsp;</font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "    <td width='100'>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>Zip:</b></font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "    <td>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1> " + Me._Order._adrs_billing_zip + "&nbsp;</font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "</tr>"
		cMsg = cMsg + "<tr>"
		cMsg = cMsg + "    <td width='100'>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>Phone:</b></font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "    <td>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + Me._Order._adrs_shipping_phone + "&nbsp;</font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "    <td width='100'>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>Phone:</b></font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "    <td>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + Me._Order._adrs_billing_phone + "&nbsp;</font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "</tr>"
		cMsg = cMsg + "</table><br>"

		'---
		cMsg = cMsg + "<TABLE ID=tbl_cart CELLSPACING=0 CELLPADDING=0 WIDTH=650 BORDER=0>"
		cMsg = cMsg + "<TR><TD colspan=2>"
		cMsg = cMsg + "<font color=MidnightBlue face=verdana,arial size=2><b>Order details:</b></font>"
		cMsg = cMsg + "</TD></TR><TR>"
		Dim nLoop As Integer = 1

		For nLoop = 1 To Me._Cart._shopitem.Count
			Dim cTXT As String = System.Convert.ToString(Me._Cart._shopitem.Item(nLoop)._id)
			cMsg = cMsg + "<TD vAlign=top align=left width=60>"
			cMsg = cMsg + "<TABLE style='BORDER-RIGHT: 2px groove; BORDER-TOP: 2px groove; FONT-SIZE: 8pt; BORDER-LEFT: 2px groove; COLOR: midnightblue; BORDER-BOTTOM: 2px groove; FONT-FAMILY: verdana,arial; BACKGROUND-COLOR: linen' cellSpacing=0 cellPadding=0 border=0>"
			cMsg = cMsg + "<TR><TD bgcolor=gainsboro>"
			cMsg = cMsg + "<IMG src='" + Me._Cart._shopitem.Item(nLoop)._icon + "' border=0>"
			cMsg = cMsg + "</TD></TR></TABLE></TD><TD vAlign=top align=left width=100%>"
			cMsg = cMsg + "<TABLE id=tbl_cart_in style='BORDER-RIGHT: 2px groove; BORDER-TOP: 2px groove; FONT-SIZE: 8pt; BORDER-LEFT: 2px groove; COLOR: midnightblue; BORDER-BOTTOM: 2px groove; FONT-FAMILY: verdana,arial; BACKGROUND-COLOR: linen' cellSpacing=0 cellPadding=0 width=100% border=0>"
			cMsg = cMsg + "<TR height=20>"
			cMsg = cMsg + "<TD vAlign=top>"
			cMsg = cMsg + "<B>" + Me._Cart._shopitem.Item(nLoop)._ItemNumber + "</B>"
			If Me._Cart._shopitem.Item(nLoop)._jewelsize <> "" Then
				cMsg = cMsg + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>[Ring size: " + Me._Cart._shopitem.Item(nLoop)._jewelsize + "]</b>"
			End If
			cMsg = cMsg + "</TD><TD vAlign=top align=right width=100>"
			If Me._Cart._shopitem.Item(nLoop)._clubitem Then
				cMsg = cMsg + "<DIV class=ShowItem_item onclick='javascript:gethelp('39')' ms_positioning=FlowLayout><IMG src='" + Me._User._domain + "/pic/club-item.gif' border=0 ></DIV>"
			End If
			cMsg = cMsg + "</TD></TR><TR height=20><TD vAlign=top>" + Me._Cart._shopitem.Item(nLoop)._description()
			cMsg = cMsg + "</TD><TD style='BORDER-RIGHT: #708090 1px groove; BORDER-TOP: #708090 1px groove; BORDER-LEFT: #708090 1px groove; BORDER-BOTTOM: #708090 1px groove' vAlign=center align=right width=100>"
			cMsg = cMsg + "" + Convert.ToString(Format(Me._Cart._shopitem.Item(nLoop)._price, "##,##0.00")) + " $us"
			cMsg = cMsg + "</TD></TR><TR><TD align=right>"
			cMsg = cMsg + "<font color=MidnightBlue face=verdana,arial size=1>Quantity purchased</font>"
			cMsg = cMsg + "<FONT style='BORDER-RIGHT: 1px groove; BORDER-TOP: 1px groove; FONT-SIZE: 8pt; PADDING-BOTTOM: 1px; BORDER-LEFT: 1px groove; COLOR: dimgray; PADDING-TOP: 1px; BORDER-BOTTOM: 1px groove; FONT-FAMILY: verdana,arial; BACKGROUND-COLOR: silver' >&nbsp;" + System.Convert.ToString(Me._Cart._shopitem.Item(nLoop)._quantity) + "&nbsp;</FONT>"
			cMsg = cMsg + "</TD><TD style='BORDER-RIGHT: #708090 1px ridge; BORDER-TOP: #708090 1px ridge; BORDER-LEFT: #708090 1px ridge; BORDER-BOTTOM: #708090 1px ridge' vAlign=center align=right width=100>"
			Me._Cart._shopitem.Item(nLoop)._total_price = Me._Cart._shopitem.Item(nLoop)._price * Me._Cart._shopitem.Item(nLoop)._quantity
			Me._Cart.recalc()
			cMsg = cMsg + "<B>" + Convert.ToString(Format(Me._Cart._shopitem.Item(nLoop)._total_price, "##,##0.00")) + " $us</B>"
			cMsg = cMsg + "</TD></TR></TABLE></TD></TR>"
		Next

		cMsg = cMsg + "</TD></TR></TABLE><br>"

		cMsg = cMsg + "<table id='tbl_totals' cellpadding='0' cellspacing='0' border='0' width='250'>"
		cMsg = cMsg + "<tr>"
		cMsg = cMsg + "    <td width='130'>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>Total price of items:</b></font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "    <td align='right'>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + System.Convert.ToString(Format(Me._Order._amnt_items, "##,##0.00")) + "&nbsp;$us</font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "</tr>"
		cMsg = cMsg + "<tr>"
		If Me._Order._amnt_wrapping > 0 Then
			cMsg = cMsg + "    <td width='130'>"
			cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>+ Wrapping:</b></font>"
			cMsg = cMsg + "    </td>"
			cMsg = cMsg + "    <td align='right'>"
			cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + System.Convert.ToString(Format(Me._Order._amnt_wrapping, "##,##0.00")) + "&nbsp;$us</font>"
			cMsg = cMsg + "    </td>"
			cMsg = cMsg + "</tr>"
		End If
		If Me._Order._amnt_shipping > 0 Then
			cMsg = cMsg + "<tr>"
			cMsg = cMsg + "    <td width='130'>"
			cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>+Shipping:</b></font>"
			cMsg = cMsg + "    </td>"
			cMsg = cMsg + "    <td align='right'>"
			cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + System.Convert.ToString(Format(Me._Order._amnt_shipping, "##,##0.00")) + "&nbsp;$us</font>"
			cMsg = cMsg + "    </td>"
			cMsg = cMsg + "</tr>"
		End If
		If Me._Order._amnt_labor > 0 Then
			cMsg = cMsg + "<tr>"
			cMsg = cMsg + "    <td width='130'>"
			cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>+ Labor:</b></font>"
			cMsg = cMsg + "    </td>"
			cMsg = cMsg + "    <td align='right'>"
			cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + System.Convert.ToString(Format(Me._Order._amnt_labor, "##,##0.00")) + "&nbsp;$us</font>"
			cMsg = cMsg + "    </td>"
			cMsg = cMsg + "</tr>"
		End If
		If Me._Order._amnt_extracharges > 0 Then
			cMsg = cMsg + "<tr>"
			cMsg = cMsg + "    <td width='130'>"
			cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>+ Extra charges:</b></font>"
			cMsg = cMsg + "    </td>"
			cMsg = cMsg + "    <td align='right'>"
			cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + System.Convert.ToString(Format(Me._Order._amnt_extracharges, "##,##0.00")) + "&nbsp;$us</font>"
			cMsg = cMsg + "    </td>"
			cMsg = cMsg + "</tr>"
		End If
		If Me._Order._amnt_discount > 0 Then
			cMsg = cMsg + "<tr>"
			cMsg = cMsg + "    <td width='130'>"
			cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>- Discount:</b></font>"
			cMsg = cMsg + "    </td>"
			cMsg = cMsg + "    <td align='right'>"
			cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + System.Convert.ToString(Format(Me._Order._amnt_discount, "##,##0.00")) + "&nbsp;$us</font>"
			cMsg = cMsg + "    </td>"
			cMsg = cMsg + "</tr>"
		End If
		cMsg = cMsg + "<tr>"
		cMsg = cMsg + "    <td width='130'>"
		cMsg = cMsg + "        &nbsp;"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "    <td>"
		cMsg = cMsg + "        <hr>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "</tr>"
		cMsg = cMsg + "<tr>"
		cMsg = cMsg + "    <td width='130'>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>Subtotal:</b></font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "    <td align='right'>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + System.Convert.ToString(Format(Me._Order._amnt_subtotal, "##,##0.00")) + "&nbsp;$us</font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "</tr>"
		cMsg = cMsg + "<tr>"
		If Me._Order._amnt_vat > 0 Then
			cMsg = cMsg + "    <td width='130'>"
			cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>+ VAT&nbsp;&nbsp;" + System.Convert.ToString(Format(Me._Order._amnt_vatperc, "##,##0.00")) + "%</b></font>"
			cMsg = cMsg + "    </td>"
			cMsg = cMsg + "    <td align='right'>"
			cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + System.Convert.ToString(Format(Me._Order._amnt_vat, "##,##0.00")) + "&nbsp;$us</font>"
			cMsg = cMsg + "    </td>"
			cMsg = cMsg + "</tr>"
		End If
		cMsg = cMsg + "<tr>"
		cMsg = cMsg + "    <td width='130'>"
		cMsg = cMsg + "        &nbsp;"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "    <td>"
		cMsg = cMsg + "        <hr>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "</tr>"
		cMsg = cMsg + "<tr>"
		cMsg = cMsg + "    <td width='130'>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>Total:</b></font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "    <td align='right'>"
		cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + System.Convert.ToString(Format(Me._Order._amnt_grandtotal, "##,##0.00")) + "&nbsp;$us</font>"
		cMsg = cMsg + "    </td>"
		cMsg = cMsg + "</tr>"
		cMsg = cMsg + "</table>"
		cMsg = cMsg + "</TD></TR></Table><font face=verdana,arial size=1>"

	End Function

End Class
