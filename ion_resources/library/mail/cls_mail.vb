Imports System.Web.Mail

Public Class cls_mail

	Private m_oConfig As Object
	Private m_oError As Object
	Private m_oUser As Object
	Private m_oCart As ion_resources.cls_cart
	Private m_oOrder As ion_resources.cls_order
	Private m_local_domain As String

    Private m_mailto As String
    Private m_from As String
    Private m_subject As String
    Private m_content As String
    Private m_contenttype As Integer
    Private m_hiddencontent As String

    Function send() As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Dim oMail As New MailMessage()

        If Me.from = "" Then
            oMail.From = "sales@twin-diamonds.com"
        Else
            oMail.From = Me.from
        End If


		oMail.To = Me.mailto.Trim
		oMail.Bcc = "followup@twin-diamonds.com"
        oMail.Subject = Me.subject
        oMail.BodyFormat = MailFormat.Html
        oMail.Priority = MailPriority.High
        SmtpMail.SmtpServer = Me.oconfig.smtpserver

        '--- Put content in message and continue processing further content
        oMail.Body = Me.content

        Dim cMsg As String
        Select Case Me.contenttype
            Case 1     '--- Welcome Mail
                bError = welcome_msg(cMsg)
                bError = footer(cMsg)
                oMail.Body = oMail.Body + cMsg

            Case 2     '--- Thank you for purchasing
                bError = cart_content(cMsg)
                bError = footer(cMsg)
                oMail.Body = oMail.Body + cMsg

            Case 3
                bError = admin_footer(cMsg)
                oMail.Body = oMail.Body + cMsg

            Case 51     '--- ADMIN - User applied for Dealer
                bError = admin_dealer_request(cMsg)
                bError = admin_footer(cMsg)
                oMail.Body = oMail.Body + cMsg

            Case 52     '--- ADMIN - Inventory item below stock
                bError = InventoryItemBelowStock(cMsg)
                bError = admin_footer(cMsg)
                oMail.Body = oMail.Body + cMsg

        End Select


        SmtpMail.Send(oMail)

        Return False
        Exit Function

ErrorHandler:
		'--- when object is called in external DLL
		oerror.err_number = Err.Number
		oerror.err_source = Err.Source
		oerror.err_description = Err.Description
		'--- Custom error
		Dim oTmpErrDB As New System.Diagnostics.StackFrame
		oerror.app_function = oTmpErrDB.GetMethod.Name
		oerror.app_call = "ion-resources / cls_mail"
		Return True

    End Function


    '####################################################################################
    Function InventoryItemBelowStock(ByRef cMsg As String) As Boolean
        Dim bError As Boolean = False

        cMsg = cMsg + "<font color='#330066' face='verdana,arial' size='1'>"
        cMsg = cMsg + Me.hiddencontent
        cMsg = cMsg + "</font>"

    End Function


    '####################################################################################
    Function cart_content(ByRef cMsg As String) As Boolean
        Dim bError As Boolean = False

        Dim cCountry_shipping, cCountry_billing, cState_shipping, cState_billing As String
        Dim oTmpFunction As New ion_resources.cls_get_countrystate()
        oTmpFunction.connection_string = Me.oconfig.connection_string

        bError = oTmpFunction.get_country(oOrder.adrs_billing_country_id, cCountry_billing)
        bError = oTmpFunction.get_country(oOrder.adrs_shipping_country_id, cCountry_shipping)
        bError = oTmpFunction.get_state(oOrder.adrs_billing_state_id, cState_billing)
        bError = oTmpFunction.get_state(oOrder.adrs_shipping_state_id, cState_shipping)

        cMsg = cMsg + "<TABLE ID=tbl_border STYLE='BORDER-RIGHT: 1px groove; BORDER-TOP: 1px groove; BORDER-LEFT: 1px groove; BORDER-BOTTOM: 1px groove; background-color: Linen' CELLSPACING=0 CELLPADDING=3 WIDTH='650' BORDER=0>"
        cMsg = cMsg + "<TR><TD>"
        cMsg = cMsg + "<table id='tbl_mailinfo' cellpadding='0' cellspacing='0' border='0' width='650'>"
        cMsg = cMsg + "<tr>"
        cMsg = cMsg + "    <td colspan='2'>"
        cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>Dear " + ouser.User_Name + ",<br><br>"
        cMsg = cMsg + "        We appreciate the order that you placed with us today and will do our utmost to give you fast and professional service.For faster checkout in the future please enter the following username and password when you place your order:"
        cMsg = cMsg + "    </td>"
        cMsg = cMsg + "</tr>"
        cMsg = cMsg + "<tr>"
        cMsg = cMsg + "    <td width='100'>"
        cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>User name:</b></font>"
        cMsg = cMsg + "    </td>"
        cMsg = cMsg + "    <td width='550'>"
        cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + ouser.user_name + "&nbsp;</font>"
        cMsg = cMsg + "    </td>"
        cMsg = cMsg + "</tr>"
        cMsg = cMsg + "<tr>"
        cMsg = cMsg + "    <td width='100'>"
        cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>Password:</b></font>"
        cMsg = cMsg + "    </td>"
        cMsg = cMsg + "    <td>"
        cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + ouser.password + "&nbsp;</font>"
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
        cMsg = cMsg + "        To view the status of your order please go to <a href= " + Me.local_domain + "/customer-status.aspx><u>click here</u></a>"
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
        cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + System.Convert.ToString(oOrder.ordernumber) + "&nbsp;</font>"
        cMsg = cMsg + "    </td>"
        cMsg = cMsg + "</tr>"
        cMsg = cMsg + "<tr>"
        cMsg = cMsg + "    <td width='100'>"
        cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>Order date:</b></font>"
        cMsg = cMsg + "    </td>"
        cMsg = cMsg + "    <td>"
        cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + System.Convert.ToString(oOrder.OrderDate) + "&nbsp;(local time, GMT +2)</font>"
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
        cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + oOrder.adrs_shipping_name + "&nbsp;</font>"
        cMsg = cMsg + "    </td>"
        cMsg = cMsg + "    <td width='100'>"
        cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>Name:</b></font>"
        cMsg = cMsg + "    </td>"
        cMsg = cMsg + "    <td>"
        cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + oOrder.adrs_billing_name + "&nbsp;</font>"
        cMsg = cMsg + "    </td>"
        cMsg = cMsg + "</tr>"
        cMsg = cMsg + "<tr>"
        cMsg = cMsg + "    <td width='100'>"
        cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>Street:</b></font>"
        cMsg = cMsg + "    </td>"
        cMsg = cMsg + "    <td>"
        cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + oOrder.adrs_shipping_street + "&nbsp;</font>"
        cMsg = cMsg + "    </td>"
        cMsg = cMsg + "    <td width='100'>"
        cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>Street:</b></font>"
        cMsg = cMsg + "    </td>"
        cMsg = cMsg + "    <td>"
        cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + oOrder.adrs_billing_street + "&nbsp;</font>"
        cMsg = cMsg + "    </td>"
        cMsg = cMsg + "</tr>"
        cMsg = cMsg + "<tr>"
        cMsg = cMsg + "    <td width='100'>"
        cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>City:</b></font>"
        cMsg = cMsg + "    </td>"
        cMsg = cMsg + "    <td>"
        cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + oOrder.adrs_shipping_city + "&nbsp;</font>"
        cMsg = cMsg + "    </td>"
        cMsg = cMsg + "    <td width='100'>"
        cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>City:</b></font>"
        cMsg = cMsg + "    </td>"
        cMsg = cMsg + "    <td>"
        cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + oOrder.adrs_billing_city + "&nbsp;</font>"
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
        cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + oOrder.adrs_shipping_zip + "&nbsp;</font>"
        cMsg = cMsg + "    </td>"
        cMsg = cMsg + "    <td width='100'>"
        cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>Zip:</b></font>"
        cMsg = cMsg + "    </td>"
        cMsg = cMsg + "    <td>"
        cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1> " + oOrder.adrs_billing_zip + "&nbsp;</font>"
        cMsg = cMsg + "    </td>"
        cMsg = cMsg + "</tr>"
        cMsg = cMsg + "<tr>"
        cMsg = cMsg + "    <td width='100'>"
        cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>Phone:</b></font>"
        cMsg = cMsg + "    </td>"
        cMsg = cMsg + "    <td>"
        cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + oOrder.adrs_shipping_phone + "&nbsp;</font>"
        cMsg = cMsg + "    </td>"
        cMsg = cMsg + "    <td width='100'>"
        cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>Phone:</b></font>"
        cMsg = cMsg + "    </td>"
        cMsg = cMsg + "    <td>"
        cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + oOrder.adrs_billing_phone + "&nbsp;</font>"
        cMsg = cMsg + "    </td>"
        cMsg = cMsg + "</tr>"
        cMsg = cMsg + "</table><br>"

        '---
        cMsg = cMsg + "<TABLE ID=tbl_cart CELLSPACING=0 CELLPADDING=0 WIDTH=650 BORDER=0>"
        cMsg = cMsg + "<TR><TD colspan=2>"
        cMsg = cMsg + "<font color=MidnightBlue face=verdana,arial size=2><b>Order details:</b></font>"
        cMsg = cMsg + "</TD></TR><TR>"
        Dim nLoop As Integer = 1

        For nLoop = 1 To Me.ocart.shopitem.Count
            Dim cTXT As String = System.Convert.ToString(Me.ocart.shopitem.Item(nLoop).id)
            cMsg = cMsg + "<TD vAlign=top align=left width=60>"
            cMsg = cMsg + "<TABLE style='BORDER-RIGHT: 2px groove; BORDER-TOP: 2px groove; FONT-SIZE: 8pt; BORDER-LEFT: 2px groove; COLOR: midnightblue; BORDER-BOTTOM: 2px groove; FONT-FAMILY: verdana,arial; BACKGROUND-COLOR: linen' cellSpacing=0 cellPadding=0 border=0>"
            cMsg = cMsg + "<TR><TD bgcolor=gainsboro>"
            If Me.ocart.shopitem.Item(nLoop).icon.trim <> "" Then
                cMsg = cMsg + "<IMG src='" + Me.local_domain + Me.ocart.shopitem.Item(nLoop).icon + "' border=0>"
            Else
                cMsg = cMsg + "<IMG src='" + Me.local_domain + "/pic/no_icon.gif' border=0 >"
            End If
            cMsg = cMsg + "</TD></TR></TABLE></TD><TD vAlign=top align=left width=100%>"
            cMsg = cMsg + "<TABLE id=tbl_cart_in style='BORDER-RIGHT: 2px groove; BORDER-TOP: 2px groove; FONT-SIZE: 8pt; BORDER-LEFT: 2px groove; COLOR: midnightblue; BORDER-BOTTOM: 2px groove; FONT-FAMILY: verdana,arial; BACKGROUND-COLOR: linen' cellSpacing=0 cellPadding=0 width=100% border=0>"
            cMsg = cMsg + "<TR height=20>"
            cMsg = cMsg + "<TD vAlign=top>"
            cMsg = cMsg + "<B>" + Me.ocart.shopitem.Item(nLoop).ItemNumber + "</B>"
            cMsg = cMsg + "</TD><TD vAlign=top align=right width=100>"
            If Me.ocart.shopitem.Item(nLoop).clubitem Then
                cMsg = cMsg + "<DIV class=ShowItem_item onclick='javascript:gethelp('39')' ms_positioning=FlowLayout><IMG src='" + Me.local_domain + "/pic/style_club.gif' border=0 ></DIV>"
            End If
			cMsg = cMsg + "</TD></TR><TR height=20><TD vAlign=top>" + Me.ocart.shopitem.Item(nLoop).description()
            cMsg = cMsg + "</TD><TD style='BORDER-RIGHT: #708090 1px groove; BORDER-TOP: #708090 1px groove; BORDER-LEFT: #708090 1px groove; BORDER-BOTTOM: #708090 1px groove' vAlign=center align=right width=100>"
            cMsg = cMsg + "" + Convert.ToString(Format(Me.ocart.shopitem.Item(nLoop).price, "##,##0.00")) + " $us"
            cMsg = cMsg + "</TD></TR><TR><TD align=right>"
            cMsg = cMsg + "<font color=MidnightBlue face=verdana,arial size=1>Quantity purchased</font>"
            cMsg = cMsg + "<FONT style='BORDER-RIGHT: 1px groove; BORDER-TOP: 1px groove; FONT-SIZE: 8pt; PADDING-BOTTOM: 1px; BORDER-LEFT: 1px groove; COLOR: dimgray; PADDING-TOP: 1px; BORDER-BOTTOM: 1px groove; FONT-FAMILY: verdana,arial; BACKGROUND-COLOR: silver' >&nbsp;" + System.Convert.ToString(Me.ocart.shopitem.Item(nLoop).quantity) + "&nbsp;</FONT>"
            cMsg = cMsg + "</TD><TD style='BORDER-RIGHT: #708090 1px ridge; BORDER-TOP: #708090 1px ridge; BORDER-LEFT: #708090 1px ridge; BORDER-BOTTOM: #708090 1px ridge' vAlign=center align=right width=100>"
            Me.ocart.shopitem.Item(nLoop).total_price = Me.ocart.shopitem.Item(nLoop).price * Me.ocart.shopitem.Item(nLoop).quantity
            Me.ocart.recalc()
            cMsg = cMsg + "<B>" + Convert.ToString(Format(Me.ocart.shopitem.Item(nLoop).total_price, "##,##0.00")) + " $us</B>"
            cMsg = cMsg + "</TD></TR></TABLE></TD></TR>"
        Next
        If oOrder.jewelry_size <> "" Then
            cMsg = cMsg + "<TR><TD colspan=3><font color=MidnightBlue face=verdana,arial size=1><b>Requested size:</b> " + oOrder.jewelry_size + "</font></TD></TR>"
        End If

        cMsg = cMsg + "</TD></TR></TABLE><br>"

        cMsg = cMsg + "<table id='tbl_totals' cellpadding='0' cellspacing='0' border='0' width='250'>"
        cMsg = cMsg + "<tr>"
        cMsg = cMsg + "    <td width='130'>"
        cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>Total price of items:</b></font>"
        cMsg = cMsg + "    </td>"
        cMsg = cMsg + "    <td align='right'>"
        cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + System.Convert.ToString(Format(oOrder.amnt_items, "##,##0.00")) + "&nbsp;$us</font>"
        cMsg = cMsg + "    </td>"
        cMsg = cMsg + "</tr>"
        cMsg = cMsg + "<tr>"
        If oOrder.amnt_wrapping > 0 Then
            cMsg = cMsg + "    <td width='130'>"
            cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>+ Wrapping:</b></font>"
            cMsg = cMsg + "    </td>"
            cMsg = cMsg + "    <td align='right'>"
            cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + System.Convert.ToString(Format(oOrder.amnt_wrapping, "##,##0.00")) + "&nbsp;$us</font>"
            cMsg = cMsg + "    </td>"
            cMsg = cMsg + "</tr>"
        End If
        If oOrder.amnt_shipping > 0 Then
            cMsg = cMsg + "<tr>"
            cMsg = cMsg + "    <td width='130'>"
            cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>+Shipping:</b></font>"
            cMsg = cMsg + "    </td>"
            cMsg = cMsg + "    <td align='right'>"
            cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + System.Convert.ToString(Format(oOrder.amnt_shipping, "##,##0.00")) + "&nbsp;$us</font>"
            cMsg = cMsg + "    </td>"
            cMsg = cMsg + "</tr>"
        End If
        If oOrder.amnt_labor > 0 Then
            cMsg = cMsg + "<tr>"
            cMsg = cMsg + "    <td width='130'>"
            cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>+ Labor:</b></font>"
            cMsg = cMsg + "    </td>"
            cMsg = cMsg + "    <td align='right'>"
            cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + System.Convert.ToString(Format(oOrder.amnt_labor, "##,##0.00")) + "&nbsp;$us</font>"
            cMsg = cMsg + "    </td>"
            cMsg = cMsg + "</tr>"
        End If
        If oOrder.amnt_extracharges > 0 Then
            cMsg = cMsg + "<tr>"
            cMsg = cMsg + "    <td width='130'>"
            cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>+ Extra charges:</b></font>"
            cMsg = cMsg + "    </td>"
            cMsg = cMsg + "    <td align='right'>"
            cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + System.Convert.ToString(Format(oOrder.amnt_extracharges, "##,##0.00")) + "&nbsp;$us</font>"
            cMsg = cMsg + "    </td>"
            cMsg = cMsg + "</tr>"
        End If
        If oOrder.amnt_discount > 0 Then
            cMsg = cMsg + "<tr>"
            cMsg = cMsg + "    <td width='130'>"
            cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>- Discount:</b></font>"
            cMsg = cMsg + "    </td>"
            cMsg = cMsg + "    <td align='right'>"
            cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + System.Convert.ToString(Format(oOrder.amnt_discount, "##,##0.00")) + "&nbsp;$us</font>"
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
        cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + System.Convert.ToString(Format(oOrder.amnt_subtotal, "##,##0.00")) + "&nbsp;$us</font>"
        cMsg = cMsg + "    </td>"
        cMsg = cMsg + "</tr>"
        cMsg = cMsg + "<tr>"
        If oOrder.amnt_vat > 0 Then
            cMsg = cMsg + "    <td width='130'>"
            cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1><b>+ VAT&nbsp;&nbsp;" + System.Convert.ToString(Format(oOrder.amnt_vatperc, "##,##0.00")) + "%</b></font>"
            cMsg = cMsg + "    </td>"
            cMsg = cMsg + "    <td align='right'>"
            cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + System.Convert.ToString(Format(oOrder.amnt_vat, "##,##0.00")) + "&nbsp;$us</font>"
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
        cMsg = cMsg + "        <font color=MidnightBlue face=verdana,arial size=1>" + System.Convert.ToString(Format(oOrder.amnt_grandtotal, "##,##0.00")) + "&nbsp;$us</font>"
        cMsg = cMsg + "    </td>"
        cMsg = cMsg + "</tr>"
        cMsg = cMsg + "</table>"
		cMsg = cMsg + "</TD></TR></Table><font face=verdana,arial size=1>"

    End Function


    '####################################################################################
    Function admin_dealer_request(ByRef cMsg As String) As Boolean
        cMsg = cMsg + "<font color='#330066' face='verdana,arial' size='2'>"
        cMsg = cMsg + "User : " + Me.ouser.user_name + "<br>"
        cMsg = cMsg + "E-mail : " + Me.ouser.email + "<br>"
        cMsg = cMsg + "Registered : " + Me.ouser.create_date + "<br><br>"
        cMsg = cMsg + "Has applyed for DEALER status. <br>"
        cMsg = cMsg + "</font>"
    End Function


    '####################################################################################
    Function welcome_msg(ByRef cMsg As String) As Boolean

        cMsg = cMsg + "<font color='#330066' face='verdana,arial' size='2'>"
        cMsg = cMsg + "Dear " + Me.ouser.user_name + ",<br><br>"
        cMsg = cMsg + "We are very pleased to add your name to our customer database.<br>"
        cMsg = cMsg + "When you do business with Twin-diamonds.com, you join a dynamic and resourceful company that goes<br>"
        cMsg = cMsg + "to great lengths to bring you added value.<br>"
        cMsg = cMsg + "Please retain your User name and Password for future use:<br><br>"
        cMsg = cMsg + "Login: " + Me.ouser.email + "<br>"
        cMsg = cMsg + "Password: " + Me.ouser.password + "<br><br>"
        cMsg = cMsg + "In the future, we will be happy to provide you with more items from our beautiful<br>"
        cMsg = cMsg + "collection at the best prices available<br>"
        cMsg = cMsg + "For information on purchases, shipping and handling, please read the Terms & Conditions page.<br>"
        cMsg = cMsg + "<br>"
        cMsg = cMsg + "Regards,<br>"
        cMsg = cMsg + "<b>Twin-diamonds.com</b><br>"
        cMsg = cMsg + "</font>"

    End Function

    '####################################################################################
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
        cMsg = cMsg + "ion-sg ver. " + Me.m_oConfig.ion_version
        cMsg = cMsg + "</font>"
        cMsg = cMsg + "</td></tr>"
        cMsg = cMsg + "</table>"
    End Function


    '####################################################################################
    Function footer(ByRef cMsg As String) As Boolean
        cMsg = cMsg + "<br><hr align='left' color='#808080'>"
        cMsg = cMsg + "<font color='#330066' face='verdana,arial' size='1'><b>"
        cMsg = cMsg + "<big>Twin-diamonds.com</big><br>"
        cMsg = cMsg + "Israel Diamond Exchange - Maccabi Building, Suit #150<br>"
        cMsg = cMsg + "P.O.Box 3205<br>"
        cMsg = cMsg + "Ramat-Gan<br>"
        cMsg = cMsg + "Israel 52521<br><br>"
        cMsg = cMsg + "Phone: +972-3-5235773<br><br>"
        cMsg = cMsg + "For questions please contact us by e-mail: <a href='mailto:sales@twin-diamonds.com'>sales@twin-diamonds.com</a>"
        cMsg = cMsg + "</b></font>"
        cMsg = cMsg + "<hr align='left' color='#808080'>"
    End Function



    Public Property mailto() As String
        Get
            Return m_mailto
        End Get

        Set(ByVal Value As String)
            m_mailto = Value
        End Set
    End Property

    Public Property from() As String
        Get
            Return m_from
        End Get

        Set(ByVal Value As String)
            m_from = Value
        End Set
    End Property

    Public Property subject() As String
        Get
            Return m_subject
        End Get

        Set(ByVal Value As String)
            m_subject = Value
        End Set
    End Property

    Public Property content() As String
        Get
            Return m_content
        End Get

        Set(ByVal Value As String)
            m_content = Value
        End Set
    End Property

    Public Property contenttype() As Integer
        Get
            Return m_contenttype
        End Get

        Set(ByVal Value As Integer)
            m_contenttype = Value
        End Set
    End Property

    Public Property oconfig() As Object
        Get
            Return m_oConfig
        End Get

        Set(ByVal Value As Object)
            m_oConfig = Value
        End Set
    End Property


    Public Property oerror() As Object
        Get
            Return m_oError
        End Get

        Set(ByVal Value As Object)
            m_oError = Value
        End Set
    End Property

    Public Property ouser() As Object
        Get
            Return m_oUser
        End Get

        Set(ByVal Value As Object)
            m_oUser = Value
        End Set
    End Property

    Public Property ocart() As ion_resources.cls_cart
        Get
            Return m_oCart
        End Get

        Set(ByVal Value As ion_resources.cls_cart)
            m_oCart = Value
        End Set
    End Property

    Public Property oOrder() As ion_resources.cls_order
        Get
            Return m_oOrder
        End Get

        Set(ByVal Value As ion_resources.cls_order)
            m_oOrder = Value
        End Set
    End Property

    Public Property local_domain() As String
        Get
            Return m_local_domain
        End Get

        Set(ByVal Value As String)
            m_local_domain = Value
        End Set
    End Property

    Public Property hiddencontent() As String
        Get
            Return m_hiddencontent
        End Get

        Set(ByVal Value As String)
            m_hiddencontent = Value
        End Set
    End Property

End Class
