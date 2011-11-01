Imports System.Globalization

Public Class cls_date
	Inherits iFoundation.cls_error_connection

	Public _day As Int16
	Public _month As Int16
	Public _year As Int16
	Public _hour As Int16
	Public _minute As Int16
	Public _second As Int16
	Public _ddate As DateTime
	Public _cdate As String

	Sub New()
		Me._hour = 0
		Me._minute = 0
		Me._second = 0
		Me._day = 0
		Me._month = 0
		Me._year = 0
		Me._ddate = #1/1/1900#
		Me._cdate = ""
	End Sub

	Public Function get_date() As Boolean
		'### return plain DATE only - from properties  ###'

		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		Dim dTmpDate As New DateTime(Me._year, Me._month, Me._day)
		Me._ddate = dTmpDate


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True
	End Function

	Public Function set_date() As Boolean
		'### SET properties of DATE only from datetime property ###'
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		Me._day = Day(Me._ddate)
		Me._month = Month(Me._ddate)
		Me._year = Year(Me._ddate)


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True
	End Function

	Public Function get_datetime() As Boolean
		'### GET full DATE-TIME from properties ###'
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		Dim dTmpDateTime As New DateTime(Me._year, Me._month, Me._day, Me._hour, Me._minute, Me._second)
		Me._ddate = dTmpDateTime

		'--- Use culture
		'Dim info As New System.Globalization.CultureInfo("en-US", False)
		'Dim cal As System.Globalization.Calendar
		'cal = info.Calendar
		'Dim myDateTime2 As New System.DateTime(Me._year, Me._month, Me._day, Me._hour, Me._minute, Me._second, 0, cal)


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True
	End Function

	Public Function set_datetime() As Boolean
		'### SET full DATE-TIME from properties ###'
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		Me._day = Day(Me._ddate)
		Me._month = Month(Me._ddate)
		Me._year = Year(Me._ddate)
		Me._hour = Hour(Me._ddate)
		Me._minute = Minute(Me._ddate)
		Me._second = Second(Me._ddate)

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True
	End Function

	Public Function get_culture_datetime(ByVal dDateTime As DateTime) As Boolean
		'### GET full DATE-TIME with Culture from properties (not used at the moment)  ###'
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		Me._day = Day(dDateTime)
		Me._month = Month(dDateTime)
		Me._year = Year(dDateTime)
		Me._hour = Hour(dDateTime)
		Me._minute = Minute(dDateTime)
		Me._second = Second(dDateTime)

		'--- Use culture
		Dim info As New System.Globalization.CultureInfo("en-US", False)
		Dim cal As System.Globalization.Calendar
		cal = info.Calendar
		Dim dTmpDateTime As New System.DateTime(Me._year, Me._month, Me._day, Me._hour, Me._minute, Me._second, 0, cal)
		dDateTime = dTmpDateTime

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True
	End Function


	Public Function get_timetype(ByVal cUserLanguage As String, ByRef nTimeType As Int16) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Get culture info
		Dim oDateTimeInfo As New System.Globalization.DateTimeFormatInfo
		Dim oCurrentCulture As Globalization.CultureInfo = System.Globalization.CultureInfo.CreateSpecificCulture(cUserLanguage)
		oDateTimeInfo = oCurrentCulture.DateTimeFormat


		'--- Get the timestring
		Dim cTimeString As String
		cTimeString = LCase(Convert.ToString(oDateTimeInfo.LongTimePattern()))


		If cTimeString = "h:mm:ss tt" Then
			nTimeType = 1

		ElseIf cTimeString = "hh:mm:ss" Then
			nTimeType = 2

		Else
			nTimeType = 2

		End If


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Public Function get_timechange(ByVal nMinutes As Int16, ByRef dDateTime As DateTime) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		dDateTime = dDateTime.AddMinutes(-nMinutes)

		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True
	End Function

	Public Function get_am_datestring(ByVal dDateTime As DateTime) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		Me._day = Day(dDateTime)
		Me._month = Month(dDateTime)
		Me._year = Year(dDateTime)
		Me._hour = Hour(dDateTime)
		Me._minute = Minute(dDateTime)
		Me._second = Second(dDateTime)

		Me._ddate = dDateTime
		Me._cdate = Convert.ToString(Month(dDateTime.Date)) + "/" + Convert.ToString(Day(dDateTime.Date)) + "/" + Convert.ToString(Year(dDateTime.Date))


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Public Function get_timediff_min(ByVal dDateTime1 As DateTime, ByVal dDateTime2 As DateTime, ByRef nMinuteDiff As Int16) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		'--- Check incomming
		If dDateTime1 = #1/1/1900# Then
			nMinuteDiff = 1
			Return False
		End If

		If dDateTime2 = #1/1/1900# Then
			nMinuteDiff = 1
			Return False
		End If

		nMinuteDiff = DateDiff(DateInterval.Minute, dDateTime2, dDateTime1)


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Public Function get_db_date(ByVal nDaysDiff As Int16, ByRef dDateTime As DateTime) As Boolean
		On Error GoTo ErrorHandler

		'--- local definitions
		Dim bError As Boolean = False

		'--- Define information to read
		Dim oTmpDataBroker As New iDac.cls_T_datareader
		oTmpDataBroker._connection_string = Me._connection_string
		oTmpDataBroker._dbtype = Me._dbtype

		'--- Define records
		Dim oField1 As New iDac.cls_cll_datareader
		oField1._field = "dbdate"
		oTmpDataBroker._fields.Add(oField1)
		oField1 = Nothing

		'--- Define search string
        Dim cSQLstring As String = "select DATEADD(day, " + Convert.ToString(nDaysDiff) + ", getdate()) as dbdate"
        '' Dim cSQLstring As String = "select CONVERT(char(8),DATEADD(day, " + Convert.ToString(nDaysDiff) + ", getdate()) , 112) as dbdate"
        ''Dim cSQLstring As String = "SELECT CONVERT(char(8), DATEadd(day," + Convert.ToString(nDaysDiff) + ",getdate()), 112)"
        ''Dim cSQLstring As String = "SELECT CONVERT(char(8), DATEadd(day,-10,getdate()), 112)"

        '--- Get info
        bError = oTmpDataBroker.read(cSQLstring)
        If bError Then
            Me._err_number = oTmpDataBroker._err_number
            Me._err_description = oTmpDataBroker._err_description
            Me._err_source = oTmpDataBroker._err_source
            Return True
        End If

        '--- Fill results
        dDateTime = oTmpDataBroker._fields.Item(1)._result

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
