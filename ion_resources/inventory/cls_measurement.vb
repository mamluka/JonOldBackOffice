Public Class cls_measurement
    Private m_error_number As Int32
    Private m_error_source As String
    Private m_error_description As String

    Private m_m1 As Decimal
    Private m_m2 As Decimal
    Private m_m3 As Decimal

    Private m_m11 As Decimal
    Private m_m22 As Decimal
    Private m_m33 As Decimal

    Private m_sql As String
    Private m_size_margin As Decimal
    Private m_measurments As String
    Private m_active As Boolean = False



    Function size_index(ByVal nSizeIndex As Int32) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False
        Dim cSQL As String = " "

        Select Case nSizeIndex

            Case 1 '- smaller then 3.0 x 5.0
                cSQL = cSQL + "and (measure1 < 3) and (measure2 < 5)"

            Case 100 '- 3.0 x 5.0
                cSQL = cSQL + "and (measure1 between " + Convert.ToString(3 - Me.size_margin) + "  and " + Convert.ToString(3 + Me.size_margin) + " ) and (measure2 between 5 and " + Convert.ToString(5 + Me.size_margin) + ")"

            Case 200 '- 4.0 x 6.0
                cSQL = cSQL + "and (measure1 between " + Convert.ToString(4 - Me.size_margin) + "  and " + Convert.ToString(4 + Me.size_margin) + " ) and (measure2 between 6 and " + Convert.ToString(6 + Me.size_margin) + ")"

            Case 300 '- 5.0 x 7.0
                cSQL = cSQL + "and (measure1 between " + Convert.ToString(5 - Me.size_margin) + "  and " + Convert.ToString(5 + Me.size_margin) + " ) and (measure2 between 7 and " + Convert.ToString(7 + Me.size_margin) + ")"

            Case 400 '- 6.0 x 8.0
                cSQL = cSQL + "and (measure1 between " + Convert.ToString(6 - Me.size_margin) + "  and " + Convert.ToString(6 + Me.size_margin) + " ) and (measure2 between 8 and " + Convert.ToString(8 + Me.size_margin) + ")"

            Case 500 '- 7.0 x 9.0
                cSQL = cSQL + "and (measure1 between " + Convert.ToString(7 - Me.size_margin) + "  and " + Convert.ToString(7 + Me.size_margin) + " ) and (measure2 between 9 and " + Convert.ToString(9 + Me.size_margin) + ")"

            Case 600 '- 8.0 x 10.0
                cSQL = cSQL + "and (measure1 between " + Convert.ToString(8 - Me.size_margin) + "  and " + Convert.ToString(8 + Me.size_margin) + " ) and (measure2 between 10 and " + Convert.ToString(10 + Me.size_margin) + ")"

            Case 700 '- 9.0 x 11.0
                cSQL = cSQL + "and (measure1 between " + Convert.ToString(9 - Me.size_margin) + "  and " + Convert.ToString(9 + Me.size_margin) + " ) and (measure2 between 11 and " + Convert.ToString(11 + Me.size_margin) + ")"

            Case 800 '- Larger
                cSQL = cSQL + "and (measure1 > 9) and (measure2 > 11)"

            Case 8800 '- Smaller
                cSQL = cSQL + "and (measure1 = 0) and (measure2 < 2)"

            Case 8900 '- 2.0
                cSQL = cSQL + "and (measure1 = 0) and (measure2 between " + Convert.ToString(2 - Me.size_margin) + " and " + Convert.ToString(2 + Me.size_margin) + ")"

            Case 9000 '- 3.0
                cSQL = cSQL + "and (measure1 = 0) and (measure2 between " + Convert.ToString(3 - Me.size_margin) + " and " + Convert.ToString(3 + Me.size_margin) + ")"

            Case 9100 '- 4.0
                cSQL = cSQL + "and (measure1 = 0) and (measure2 between " + Convert.ToString(4 - Me.size_margin) + " and " + Convert.ToString(4 + Me.size_margin) + ")"

            Case 9200 '- 5.0
                cSQL = cSQL + "and (measure1 = 0) and (measure2 between " + Convert.ToString(5 - Me.size_margin) + " and " + Convert.ToString(5 + Me.size_margin) + ")"

            Case 9300 '- 6.0
                cSQL = cSQL + "and (measure1 = 0) and (measure2 between " + Convert.ToString(6 - Me.size_margin) + " and " + Convert.ToString(6 + Me.size_margin) + ")"

            Case 9400 '- 7.0
                cSQL = cSQL + "and (measure1 = 0) and (measure2 between " + Convert.ToString(7 - Me.size_margin) + " and " + Convert.ToString(7 + Me.size_margin) + ")"

            Case 9500 '- 8.0
                cSQL = cSQL + "and (measure1 = 0) and (measure2 between " + Convert.ToString(8 - Me.size_margin) + " and " + Convert.ToString(8 + Me.size_margin) + ")"

            Case 9600 '- 9.0
                cSQL = cSQL + "and (measure1 = 0) and (measure2 between " + Convert.ToString(9 - Me.size_margin) + " and " + Convert.ToString(9 + Me.size_margin) + ")"

            Case 9700 '- 10.0
                cSQL = cSQL + "and (measure1 = 0) and (measure2 between " + Convert.ToString(10 - Me.size_margin) + " and " + Convert.ToString(10 + Me.size_margin) + ")"

            Case 9800 '- 11.0
                cSQL = cSQL + "and (measure1 = 0) and (measure2 between " + Convert.ToString(11 - Me.size_margin) + " and " + Convert.ToString(11 + Me.size_margin) + ")"

            Case 9900 '- 12.0
                cSQL = cSQL + "and (measure1 = 0) and (measure2 between " + Convert.ToString(12 - Me.size_margin) + " and " + Convert.ToString(12 + Me.size_margin) + ")"

            Case 10000 '- Larger
                cSQL = cSQL + "and (measure1 = 0) and (measure2 > 12)"

        End Select

        Me.sql = cSQL

        Return False
        Exit Function

ErrorHandler:
        Me.error_number = Err.Number
        Me.error_description = Err.Description
        Me.error_source = Err.Source
        Return True

    End Function


    Function get_measurements() As Boolean

        '--- all strings are full
        If Me.m1 <> 0 And Me.m2 <> 0 And Me.m3 <> 0 Then
            Me.measurments = System.Convert.ToString(Format(Me.m1, "##,##0.00")) + "&curren;" + System.Convert.ToString(Format(Me.m2, "##,##0.00")) + "&curren;" + System.Convert.ToString(Format(Me.m3, "##,##0.00")) + " mm."
            Me.active = True

            '--- regular stone only High x Width
        ElseIf Me.m1 <> 0 And Me.m2 <> 0 And Me.m3 = 0 Then
            Me.measurments = System.Convert.ToString(Format(Me.m1, "##,##0.00")) + " &curren; " + System.Convert.ToString(Format(Me.m2, "##,##0.00")) + " mm."
            Me.active = True

            '--- Round stone, m2=diameter / m3=depth
        ElseIf Me.m1 = 0 And Me.m2 <> 0 And Me.m3 <> 0 Then
            Me.measurments = System.Convert.ToString(Format(Me.m2, "##,##0.00")) + " &Oslash; " + System.Convert.ToString(Format(Me.m3, "##,##0.00")) + "mm."
            Me.active = True

            '--- Round stone, only m2=diameter
        ElseIf Me.m1 = 0 And Me.m2 <> 0 And Me.m3 = 0 Then
            Me.measurments = System.Convert.ToString(Format(Me.m2, "##,##0.00")) + " &Oslash;"
            Me.active = True

        Else
            Me.active = False
            Me.measurments = "-"

        End If

    End Function

    Function reset()
        Me.m_m1 = 0
        Me.m_m2 = 0
        Me.m_m3 = 0
        Me.m_active = False
        Me.measurments = ""

    End Function

    Public Property error_number() As Int32
        Get
            Return m_error_number
        End Get

        Set(ByVal Value As Int32)
            m_error_number = Value
        End Set
    End Property

    Public Property error_description() As String
        Get
            Return m_error_description
        End Get

        Set(ByVal Value As String)
            m_error_description = Value
        End Set
    End Property

    Public Property error_source() As String
        Get
            Return m_error_source
        End Get

        Set(ByVal Value As String)
            m_error_source = Value
        End Set
    End Property

    Public Property measurments() As String
        Get
            Return m_measurments
        End Get

        Set(ByVal Value As String)
            m_measurments = Value
        End Set
    End Property

    Public Property sql() As String
        Get
            Return m_sql
        End Get

        Set(ByVal Value As String)
            m_sql = Value
        End Set
    End Property

    Public Property m1() As Decimal
        Get
            Return m_m1
        End Get

        Set(ByVal Value As Decimal)
            m_m1 = Value
        End Set
    End Property

    Public Property m2() As Decimal
        Get
            Return m_m2
        End Get

        Set(ByVal Value As Decimal)
            m_m2 = Value
        End Set
    End Property

    Public Property m3() As Decimal
        Get
            Return m_m3
        End Get

        Set(ByVal Value As Decimal)
            m_m3 = Value
        End Set
    End Property

    Public Property m11() As Decimal
        Get
            Return m_m11
        End Get

        Set(ByVal Value As Decimal)
            m_m11 = Value
        End Set
    End Property

    Public Property m22() As Decimal
        Get
            Return m_m22
        End Get

        Set(ByVal Value As Decimal)
            m_m22 = Value
        End Set
    End Property

    Public Property m33() As Decimal
        Get
            Return m_m33
        End Get

        Set(ByVal Value As Decimal)
            m_m33 = Value
        End Set
    End Property

    Public Property size_margin() As Decimal
        Get
            Return m_size_margin
        End Get

        Set(ByVal Value As Decimal)
            m_size_margin = Value
        End Set
    End Property

    Public Property active() As Boolean
        Get
            Return m_active
        End Get

        Set(ByVal Value As Boolean)
            m_active = Value
        End Set
    End Property

End Class
