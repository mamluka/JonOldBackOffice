Public Class cls_reject
	Inherits iFoundation.cls_error_connection

	Public _reject As Boolean
	Public _ip As String
	Public _domain As String
	Public _description As String
	Public _redirect As Boolean
	Public _email As String
	Public _id As Int32

	Sub New()
		Me._reject = False
		Me._ip = "000.000.000.000"
		Me._domain = ""
		Me._description = ""
		Me._email = ""
		Me._redirect = False
	End Sub

	Public Overloads Function check_reject(ByVal cEmail As String, ByVal oConfig As Object) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- check also by Email
		If Not Me._reject Then
			bError = Me.get_exist_email(cEmail)
			If bError Then
				Exit Function
			End If
		End If

		If Me._reject Then
			bError = Me.sendmail(1, oConfig)
		End If

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True
	End Function

	Public Overloads Function check_reject(ByVal cIP As String, ByVal cDomain As String, ByVal oConfig As Object) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Check by IP
		bError = Me.get_exist_ip(cIP)
		If bError Then
			Exit Function
		End If

		'--- check also by Domain
		If Not Me._reject And Not IsNumeric(cDomain.Substring(1, 2)) Then
			bError = Me.get_exist_domain(cDomain)
			If bError Then
				Exit Function
			End If
		End If

		If Me._reject Then
			bError = Me.sendmail(2, oConfig)
		End If

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Public Function get_exist_ip(ByVal cIP As String) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Define information to read
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "sys_REJECT"
		'oTmpDataBroker._id = nId

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "id"
		oTmpDataBroker._fields.Add(oField1)
		oField1 = Nothing

		Dim oField2 As New iDac.cls_cll_datareader
		oField2._field = "ip"
		oTmpDataBroker._fields.Add(oField2)
		oField2 = Nothing

		Dim oField3 As New iDac.cls_cll_datareader
		oField3._field = "netdomain"
		oTmpDataBroker._fields.Add(oField3)
		oField3 = Nothing

		Dim oField4 As New iDac.cls_cll_datareader
		oField4._field = "description"
		oTmpDataBroker._fields.Add(oField4)
		oField4 = Nothing

		Dim oField5 As New iDac.cls_cll_datareader
		oField5._field = "redirect"
		oTmpDataBroker._fields.Add(oField5)
		oField5 = Nothing


		'--- Create an SQL
		Dim cSQL As String
		cSQL = "select id, ip, netdomain, description, redirect from sys_REJECT where (ip='" + cIP + "')"

		'--- Get info
		bError = oTmpDataBroker.read(cSQL)
		If bError Then
			Me._err_number = oTmpDataBroker._err_number
			Me._err_description = oTmpDataBroker._err_description
			Me._err_source = oTmpDataBroker._err_source
			Return True
		End If

		'--- Fill results
		If oTmpDataBroker._hasresult Then
			Me._reject = True
			Me._id = oTmpDataBroker._fields.Item(1)._result
			Me._ip = oTmpDataBroker._fields.Item(2)._result
			Me._domain = oTmpDataBroker._fields.Item(3)._result
			Me._description = oTmpDataBroker._fields.Item(4)._result
			Me._redirect = oTmpDataBroker._fields.Item(5)._result
		End If

		Return False
		Exit Function

ErrorHandler:
		'--- register the error
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Public Function get_exist_domain(ByVal cDomain As String) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Define information to read
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "sys_REJECT"
		'oTmpDataBroker._id = nId

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "id"
		oTmpDataBroker._fields.Add(oField1)
		oField1 = Nothing

		Dim oField2 As New iDac.cls_cll_datareader
		oField2._field = "ip"
		oTmpDataBroker._fields.Add(oField2)
		oField2 = Nothing

		Dim oField3 As New iDac.cls_cll_datareader
		oField3._field = "netdomain"
		oTmpDataBroker._fields.Add(oField3)
		oField3 = Nothing

		Dim oField4 As New iDac.cls_cll_datareader
		oField4._field = "description"
		oTmpDataBroker._fields.Add(oField4)
		oField4 = Nothing

		Dim oField5 As New iDac.cls_cll_datareader
		oField5._field = "redirect"
		oTmpDataBroker._fields.Add(oField5)
		oField5 = Nothing

		'--- Create an SQL
		Dim cSQL As String
		cSQL = "select id, ip, netdomain, description, redirect from sys_REJECT where (netdomain like '%" + cDomain.Trim + "%')"

		'--- Get info
		bError = oTmpDataBroker.read(cSQL)
		If bError Then
			Me._err_number = oTmpDataBroker._err_number
			Me._err_description = oTmpDataBroker._err_description
			Me._err_source = oTmpDataBroker._err_source
			Return True
		End If

		'--- Fill results
		If oTmpDataBroker._hasresult Then
			Me._reject = True
			Me._id = oTmpDataBroker._fields.Item(1)._result
			Me._ip = oTmpDataBroker._fields.Item(2)._result
			Me._domain = oTmpDataBroker._fields.Item(3)._result
			Me._description = oTmpDataBroker._fields.Item(4)._result
			Me._redirect = oTmpDataBroker._fields.Item(5)._result
		End If

		Return False
		Exit Function

ErrorHandler:
		'--- register the error
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Public Function get_exist_email(ByVal cEmail As String) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Define information to read
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "sys_REJECT_email"
		'oTmpDataBroker._id = nId

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "id"
		oTmpDataBroker._fields.Add(oField1)
		oField1 = Nothing

		Dim oField2 As New iDac.cls_cll_datareader
		oField2._field = "email"
		oTmpDataBroker._fields.Add(oField2)
		oField2 = Nothing

		Dim oField3 As New iDac.cls_cll_datareader
		oField3._field = "description"
		oTmpDataBroker._fields.Add(oField3)
		oField3 = Nothing

		Dim oField4 As New iDac.cls_cll_datareader
		oField4._field = "redirect"
		oTmpDataBroker._fields.Add(oField4)
		oField4 = Nothing


		'--- Create an SQL
		Dim cSQL As String
		cSQL = "select id, email, description, redirect from sys_REJECT_email where (email='" + cEmail + "')"

		'--- Get info
		bError = oTmpDataBroker.read(cSQL)
		If bError Then
			Me._err_number = oTmpDataBroker._err_number
			Me._err_description = oTmpDataBroker._err_description
			Me._err_source = oTmpDataBroker._err_source
			Return True
		End If

		'--- Fill results
		If oTmpDataBroker._hasresult Then
			Me._reject = True
			Me._id = oTmpDataBroker._fields.Item(1)._result
			Me._email = oTmpDataBroker._fields.Item(2)._result
			Me._description = oTmpDataBroker._fields.Item(3)._result
			Me._redirect = oTmpDataBroker._fields.Item(4)._result
		End If

		Return False
		Exit Function

ErrorHandler:
		'--- register the error
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Private Function sendmail(ByVal nMode As Int16, ByVal oConfig As Object) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Send Email
		Dim cMSG As String
		Select Case nMode
			Case 1		  '-- Rejected by mail
				cMSG = "User rejected by EMAIL: " + Date.Now + "<br><br>"
				cMSG = cMSG + "<big>" + Me._description + "</big><br>"
				cMSG = cMSG + "EMAIL: " + Me._email + "<br><br>"

			Case 2		  '-- rejected by ip or domain
				cMSG = "Spys now in site: " + Date.Now + "<br><br>"
				cMSG = cMSG + "<big>" + Me._description + "</big><br>"
				cMSG = cMSG + "IP: " + Me._ip + "<br>"
				cMSG = cMSG + "Domain: " + Me._domain + "<br><br>"

		End Select

		If Me._redirect Then
			cMSG = cMSG + "User has been REDIRECTED<br>"
		End If


		Dim oMailing As New ion_two.cls_mailing
		oMailing._Config = oConfig
		oMailing._subject = "Now online: " + Me._description
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


		Return False
		Exit Function

ErrorHandler:
		'--- register the error
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function




End Class
