Public Class cls_date
	Private m_err_number As Int32
	Private m_err_description As String
	Private m_err_source As String

	Private m_text As New Collection()

	Private m_fromdate As Date
	Private m_todate As Date

	Public Sub New()
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		Dim oText0 As New cls_textcontent()
		oText0.text = "-"
		oText0.value = 0
		Me.text.Add(oText0)
		oText0 = Nothing

		Dim oText1 As New cls_textcontent()
		oText1.text = "Today"
		oText1.value = 1
		Me.text.Add(oText1)
		oText1 = Nothing

		Dim oText2 As New cls_textcontent()
		oText2.text = "Yesterday"
		oText2.value = 2
		Me.text.Add(oText2)
		oText1 = Nothing

		Dim oText3 As New cls_textcontent()
		oText3.text = "Last 7 days"
		oText3.value = 3
		Me.text.Add(oText3)
		oText3 = Nothing

		Dim oText4 As New cls_textcontent()
		oText4.text = "Last 30 days"
		oText4.value = 4
		Me.text.Add(oText4)
		oText4 = Nothing

		Dim oText5 As New cls_textcontent()
		oText5.text = "Last 60 days"
		oText5.value = 5
		Me.text.Add(oText5)
		oText5 = Nothing

		Dim oText6 As New cls_textcontent()
		oText6.text = "Last 90 days"
		oText6.value = 6
		Me.text.Add(oText6)
		oText6 = Nothing

		Dim oText7 As New cls_textcontent()
		oText7.text = "Beginning of this week"
		oText7.value = 7
		Me.text.Add(oText7)
		oText7 = Nothing

		Dim oText8 As New cls_textcontent()
		oText8.text = "Beginning of this month"
		oText8.value = 8
		Me.text.Add(oText8)
		oText8 = Nothing

		Exit Sub

ErrorHandler:
		'--- register the error
		Me.err_number = Err.Number
		Me.err_description = Err.Description
		Me.err_source = Err.Source

	End Sub


	Public Function getdate(ByVal nDateId As Int16)

		Me.fromdate = #1/1/1900#
		Me.todate = Date.Today
		Dim DateNow As Date = Date.Today


		Select Case nDateId
			Case 0			 '--- none
				Me.fromdate = #1/1/1900#

			Case 1			'-- Today
				Me.fromdate = Date.Today

			Case 2			'-- Yesterday
				Me.fromdate = DateNow.AddDays(-1)

			Case 3			'-- Last 7 days
				Me.fromdate = DateNow.AddDays(-7)

			Case 4			'-- Last 30 days
				Me.fromdate = DateNow.AddDays(-30)

			Case 5			'-- Last 60 days
				Me.fromdate = DateNow.AddDays(-60)

			Case 6			'-- Last 90 days
				Me.fromdate = DateNow.AddDays(-90)

			Case 7			'-- Beginning of this week
				Me.fromdate = DateNow.AddDays(-DateNow.DayOfWeek)

			Case 8			'-- Beginning of this month
				Me.fromdate = DateNow.AddDays(-DateNow.Day + 1)
		End Select


	End Function



	Public Function getdayint(ByVal dDate As Date) As Int16

		Dim cDay As String = dDate.DayOfWeek

		Select Case LCase(cDay)
			Case "sunday"
				Return 1
			Case "monday"
				Return 2
			Case "tuesday"
				Return 3
			Case "wednesday"
				Return 4
			Case "thursday"
				Return 5
			Case "friday"
				Return 6
			Case "satuday"
				Return 7
		End Select



	End Function


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

	Public Property text() As Collection
		Get
			Return m_text
		End Get

		Set(ByVal Value As Collection)
			m_text = Value
		End Set
	End Property

	Public Property fromdate() As Date
		Get
			Return m_fromdate
		End Get

		Set(ByVal Value As Date)
			m_fromdate = Value
		End Set
	End Property

	Public Property todate() As Date
		Get
			Return m_todate
		End Get

		Set(ByVal Value As Date)
			m_todate = Value
		End Set
	End Property


	Private Class cls_textcontent
		Private m_text As String
		Private m_value As Int16

		Public Property text() As String
			Get
				Return m_text
			End Get

			Set(ByVal Value As String)
				m_text = Value
			End Set
		End Property

		Public Property value() As Int16
			Get
				Return m_value
			End Get

			Set(ByVal Value As Int16)
				m_value = Value
			End Set
		End Property

	End Class

End Class

