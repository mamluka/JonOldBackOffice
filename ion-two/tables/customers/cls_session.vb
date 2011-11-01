Public Class cls_session
	Inherits iFoundation.cls_error_connection

    Public _authenticated As Boolean
    Public _no_email_record As Boolean
	Public _session As New ion_two.cls_user

	Public Function logon(ByRef nId As Int32, ByVal cEmail As String, Optional ByVal cPassword As String = "") As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Define information to read
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._dbtype = Me._dbtype
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._table = "usr_CUSTOMERS"
		oTmpDataBroker._id = nId

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "id"
		oTmpDataBroker._fields.Add(oField1)
        ''oField1 = Nothing

		'--- Create an SQL
		Dim cSQL As String
		If nId > 0 Then
			cSQL = "select * from v_user_logon where active=1 and email ='" + cEmail + "' and id = " + System.Convert.ToString(nId)
		Else
			cSQL = "select * from v_user_logon where active=1 and email ='" + cEmail + "' and password = '" + cPassword + "'"
		End If

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
            nId = oTmpDataBroker._fields.Item(1)._result
            Me._no_email_record = False
            bError = Me.load_user(nId)

            Dim omail As New ion_two.cls_mod_mail
            omail.mail_from = "notifier@twin-diamonds.com"
            omail.subject = Me._session._email + " has logged in to the website"
            Dim body As String

            body += Me._session._email + " has logged in" + "<br>"
            body += "is vip " + Me._session._isdealer.ToString + "<br>"
            body += "user id " + Me._session._id.ToString + "<br>"
            body += "user ip " + Me._session._ip.ToString + "<br>"

            omail.mail_to = "mamluka_xomix@hotmail.com"

            omail.send_direct(body)


			If bError Then
				Me._err_number = Err.Number
				Me._err_description = Err.Description
				Me._err_source = Err.Source
				Return True
            End If
        Else
            'chek if missing password or username

            oField1._field = "id"
            oTmpDataBroker._fields.Add(oField1)
            oField1 = Nothing
            cSQL = "select * from v_user_logon where active=1 and email ='" + cEmail + "'"

            bError = oTmpDataBroker.read(cSQL)
            If bError Then
                Me._err_number = oTmpDataBroker._err_number
                Me._err_description = oTmpDataBroker._err_description
                Me._err_source = oTmpDataBroker._err_source
                Return True
            End If

            If oTmpDataBroker._hasresult Then
                ''  nId = oTmpDataBroker._fields.Item(1)._result
                ''    bError = Me.load_user(nId)
                Me._no_email_record = False
                If bError Then
                    Me._err_number = Err.Number
                    Me._err_description = Err.Description
                    Me._err_source = Err.Source
                    Return True
                End If
            Else
                Me._no_email_record = True

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

    Public Function loadbyemail(ByRef nId As Int32, ByVal cEmail As String, Optional ByVal cPassword As String = "") As Boolean
        On Error GoTo ErrorHandler

        '--- local definitions
        Dim bError As Boolean = False

        '--- Define information to read
        Dim oTmpDataBroker As New iDac.cls_T_datareader
        oTmpDataBroker._dbtype = Me._dbtype
        oTmpDataBroker._connection_string = Me._connection_string
        oTmpDataBroker._table = "usr_CUSTOMERS"
        oTmpDataBroker._id = nId

        '--- Define records
        Dim oField1 As New iDac.cls_cll_datareader
        oField1._field = "id"
        oTmpDataBroker._fields.Add(oField1)
        ''oField1 = Nothing

        '--- Create an SQL
        Dim cSQL As String

        cSQL = "select * from v_user_logon where active=1 and email ='" + cEmail + "'"

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
            nId = oTmpDataBroker._fields.Item(1)._result
            Me._no_email_record = False
            bError = Me.load_user(nId)
            If bError Then
                Me._err_number = Err.Number
                Me._err_description = Err.Description
                Me._err_source = Err.Source
                Return True
            End If
        Else
            'chek if missing password or username

            oField1._field = "id"
            oTmpDataBroker._fields.Add(oField1)
            oField1 = Nothing
            cSQL = "select * from v_user_logon where active=1 and email ='" + cEmail + "'"

            bError = oTmpDataBroker.read(cSQL)
            If bError Then
                Me._err_number = oTmpDataBroker._err_number
                Me._err_description = oTmpDataBroker._err_description
                Me._err_source = oTmpDataBroker._err_source
                Return True
            End If

            If oTmpDataBroker._hasresult Then
                ''  nId = oTmpDataBroker._fields.Item(1)._result
                ''    bError = Me.load_user(nId)
                Me._no_email_record = False
                If bError Then
                    Me._err_number = Err.Number
                    Me._err_description = Err.Description
                    Me._err_source = Err.Source
                    Return True
                End If
            Else
                Me._no_email_record = True

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

    Public Function load_user(ByVal nId As Int32) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- Get Customer
        Dim oCustomer_skl As New ion_two.skl_customers
        Dim oCustomer As New ion_two.cls_customers_lgc
        oCustomer._connection_string = Me._connection_string
        oCustomer._dbtype = Me._dbtype
        bError = oCustomer.read(nId, oCustomer_skl)
        If bError Then
            Me._err_number = oCustomer._err_number
            Me._err_description = oCustomer._err_description
            Me._err_source = oCustomer._err_source
            Return True
        End If

        '--- Load session
        Me._session._authenticated = True
        Me._session._createdate = oCustomer_skl._create_date
        Me._session._email = oCustomer_skl._email
        Me._session._id = oCustomer_skl._id
        Me._session._isdealer = oCustomer_skl._dealer
        Me._session._language = oCustomer_skl._prf_language_id
        Me._session._lastvisit = oCustomer_skl._last_visit
        Me._session._message = oCustomer_skl._online_message
        Me._session._name = Trim(oCustomer_skl._firstname) + " " + Trim(oCustomer_skl._lastname)
        Me._session._password = Trim(oCustomer_skl._password)
        Me._session._visits = oCustomer_skl._prf_timesvisited
        Me._session._phone1 = oCustomer_skl._phone1

        '--- Update user
        bError = Me.update_user(nId)
        If bError Then
            Me._err_number = Err.Number
            Me._err_description = Err.Description
            Me._err_source = Err.Source
            Return True
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

    Private Function update_user(ByVal nId As Int32) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False


        '--- Get Customer for UPDATE
        Dim oCustomer_skl As New ion_two.skl_customers
        Dim oCustomer As New ion_two.cls_customers_lgc
        oCustomer._connection_string = Me._connection_string
        oCustomer._dbtype = Me._dbtype
        bError = oCustomer.read(nId, oCustomer_skl)
        If bError Then
            Me._err_number = oCustomer._err_number
            Me._err_description = oCustomer._err_description
            Me._err_source = oCustomer._err_source
            Return True
        End If


        If oCustomer_skl._last_visit > Now Then
            oCustomer_skl._last_visit = Now
            oCustomer_skl._prf_timesvisited = oCustomer_skl._prf_timesvisited + 1

            bError = oCustomer.update(oCustomer_skl)
            If bError Then
                Me._err_number = oCustomer._err_number
                Me._err_description = oCustomer._err_description
                Me._err_source = oCustomer._err_source
                Return True
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


    Public Function create_cookie(ByRef oCookie As Web.HttpCookie) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        oCookie.Values.Add("visits", Me._session._visits + 1)
        oCookie.Values.Add("lastvisit", Date.Now)
        oCookie.Values.Add("id", Me._session._id)
        oCookie.Values.Add("mail", Me._session._email)
        oCookie.Values.Add("dealer", Me._session._isdealer)
        oCookie.Values.Add("cmp", Me._session._campaign)
        oCookie.Values.Add("afl", Me._session._affiliate)
        oCookie.Values.Add("currencyID", Me._session._currencyID)
        oCookie.Expires = Today.AddMonths(12)


        Return False
        Exit Function

ErrorHandler:
        '--- register the error
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function

    Public Function load_cookie(ByRef oCookie As Web.HttpCookie) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Dim nVisits As Int32
        Dim dLastVisit As DateTime
        Dim nId As Int32
        Dim cEmail As String
        Dim cCampaign As String
        Dim cAffiliate As String
        Dim cCurrencyId As String
        Dim cAweber As String
        Dim dealer As Boolean

        '--- Get Cookie - VISITS
        If Not oCookie.Item("visits") Is Nothing Then
            nVisits = Convert.ToInt32(oCookie.Item("visits"))
            Me._session._visits = nVisits
        End If

        '--- Get Cookie - LASTVISIT
        If Not oCookie.Item("lastvisit") Is Nothing Then
            dLastVisit = Convert.ToDateTime(oCookie.Item("lastvisit"))
            Me._session._lastvisit = dLastVisit
        End If

        '--- Get Cookie - ID
        If Not oCookie.Item("id") Is Nothing Then
            nId = Convert.ToInt32(oCookie.Item("id"))
            Me._session._id = nId
        End If

        If Not oCookie.Item("dealer") Is Nothing Then
            dealer = Convert.ToInt32(oCookie.Item("dealer"))
            Me._session._isdealer = dealer
        End If

        '--- Get Cookie - EMAIL
        If Not oCookie.Item("mail") Is Nothing Then
            cEmail = Convert.ToString(oCookie.Item("mail"))
            Me._session._email = cEmail
        End If

        '--- Get Cookie - CAMPAIGN
        If Not oCookie.Item("cmp") Is Nothing Then
            cCampaign = Convert.ToString(oCookie.Item("cmp"))
            If cCampaign = "" Then
                Me._session._campaign = cCampaign
            End If
        End If

        '--- Get Cookie - Affiliate
        If Not oCookie.Item("afl") Is Nothing Then
            cAffiliate = Convert.ToString(oCookie.Item("afl"))
            If cAffiliate <> "" Then
                Me._session._affiliate = cAffiliate
            End If
        End If

        '--- Get Cookie - currency
        If Not oCookie.Item("currencyID") Is Nothing Then
            cCurrencyId = oCookie.Item("currencyID")
            If cCurrencyId <> "" Then
                Me._session._currencyID = cCurrencyId
            End If
        End If

        '--- Get Cookie - aweberpush
        If Not oCookie.Item("aweberpopup") Is Nothing Then
            cAweber = oCookie.Item("aweberpopup")
            If cAweber = "1" Then
                Me._session._aweberPopup = True
            End If
        End If


        '--- If we have ID and EMAIL goto fast logon
        If Me._session._id > 0 Then
            If Me._session._email <> "" Then
                bError = Me.logon(nId, cEmail)
                If bError Then
                    Me._err_number = Err.Number
                    Me._err_description = Err.Description
                    Me._err_source = Err.Source
                    Return True
                End If
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

    Public Function delete_cookie(ByRef oCookie As Web.HttpCookie) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False


        Me._session._id = 0
        bError = Me.create_cookie(oCookie)
        If bError Then
            Me._err_number = Err.Number
            Me._err_description = Err.Description
            Me._err_source = Err.Source
            Return True
        End If

        'oCookie.Expires = Date.Now

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
