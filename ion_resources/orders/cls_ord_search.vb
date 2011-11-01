Public Class cls_ord_search
	Private m_err_number As Int32
	Private m_err_description As String
	Private m_err_source As String

	Private m_order As Int32
	Private m_email As String
	Private m_invoice As Int32
    Private m_sqlstring As String
    Private m_sort As String

	Public Function create_sql()
		On Error GoTo ErrorHandler
		Dim bError As Boolean = True

		Dim cTmpSqlString As String = ""
		cTmpSqlString = "select * from v_orders_list where ordernumber > 0 "

		'--- Select ORDER NUMBER
		If Me.order > 0 Then
			cTmpSqlString = cTmpSqlString + " and ordernumber = " & Me.order
		End If

		'--- Select EMAIL
		If Me.email <> "" Then
            cTmpSqlString = cTmpSqlString + " and customeremail like '%" & Me.email & "%'"
		End If

		'--- Select INVOICE NUMBER
		If Me.invoice > 0 Then
			cTmpSqlString = cTmpSqlString + " and invoicenumber = " & Me.invoice
        End If

        Select Case Me.sort
            Case 1
                cTmpSqlString += " order by customername"
            Case 2
                cTmpSqlString += " order by customeremail"
            Case 3
                cTmpSqlString += " order by sts_curr_stat"


        End Select

        Me.sqlstring = cTmpSqlString

        Return False
        Exit Function

ErrorHandler:
        '--- register the error
        Me.err_number = Err.Number
        Me.err_description = Err.Description
        Me.err_source = Err.Source
        Return True

	End Function


	Public Property email() As String
		Get
			Return m_email
		End Get

		Set(ByVal Value As String)
			m_email = Value
		End Set
	End Property

	Public Property order() As Int32
		Get
			Return m_order
		End Get

		Set(ByVal Value As Int32)
			m_order = Value
		End Set
    End Property
    Public Property sort() As Int32
        Get
            Return m_sort
        End Get

        Set(ByVal Value As Int32)
            m_sort = Value
        End Set
    End Property

    Public Property invoice() As Int32
        Get
            Return m_invoice
        End Get

        Set(ByVal Value As Int32)
            m_invoice = Value
        End Set
    End Property

    Public Property err_number() As Int32
        Get
            Return m_err_number
        End Get

        Set(ByVal Value As Int32)
            m_err_number = Value
        End Set
    End Property

    Public Property err_source() As String
        Get
            Return m_err_source
        End Get

        Set(ByVal Value As String)
            m_err_source = Value
        End Set
    End Property

    Public Property err_description() As String
        Get
            Return m_err_description
        End Get

        Set(ByVal Value As String)
            m_err_description = Value
        End Set
    End Property

    Public Property sqlstring() As String
        Get
            Return m_sqlstring
        End Get

        Set(ByVal Value As String)
            m_sqlstring = Value
        End Set
    End Property

End Class
