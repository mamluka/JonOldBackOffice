Public Class cls_net_reject
	Inherits iFoundation.cls_error_connection
	Public _redirect As Boolean


	Public Function check_spys(ByVal cIP As String, ByVal cDomain As String, ByVal oConfig As ion_two.cls_config) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Get Reject
		Dim oReject As New ion_two.cls_reject
		oReject._connection_string = Me._connection_string
		oReject._dbtype = Me._dbtype

		'--- Check by IP
		bError = oReject.get_exist_ip(cIP)
		If bError Then
			Me._err_number = oReject._err_number
			Me._err_description = oReject._description
			Me._err_source = oReject._err_source
			Exit Function
		End If

		'--- check also by Domain
		If Not oReject._reject And Not IsNumeric(cDomain.Substring(1, 2)) Then
			bError = oReject.get_exist_domain(cDomain)
			If bError Then
				Me._err_number = oReject._err_number
				Me._err_description = oReject._err_description
				Me._err_source = oReject._err_source
				Exit Function
			End If
		End If

		If oReject._reject Then
			'--- Send Email
			Dim cMSG As String
			cMSG = "Spys now in site: " + Date.Now + "<br><br>"
			cMSG = cMSG + "<big>" + oReject._description + "</big><br>"
			cMSG = cMSG + "IP: " + oReject._ip + "<br>"
			cMSG = cMSG + "Domain: " + oReject._domain + "<br><br>"
			If oReject._redirect Then
				cMSG = cMSG + "User has been REDIRECTED<br>"
			End If


			Dim oMailing As New ion_two.cls_mailing
			oMailing._Config = oConfig
			oMailing._subject = "Now online: " + oReject._description
			oMailing._mailto = "ion-sales@twin-diamonds.com"
			oMailing._from = "sales@twin-diamonds.com"
			oMailing._content = cMSG
			oMailing._contenttype = 3
			bError = oMailing.send()
			If bError Then
				If oMailing._err_number = 5 Then
					bError = False
				Else
					bError = True
					Me._err_number = oMailing._err_number
					Me._err_description = oMailing._err_description
					Me._err_source = oMailing._err_source
					Exit Function
				End If
			End If
		End If

		'--- Release
		oReject = Nothing


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function



End Class
