Public Class cls_inv_search
	Private m_err_number As Int32
	Private m_err_description As String
	Private m_err_source As String

    Private m_branch As Integer
    Private m_supplier As Integer
    Private m_itemnumber As Int32
    Private m_itemcode As String
    Private m_stonetype As String
    Private m_csstonetype As String
    Private m_stoneshape As String
    Private m_weight As Decimal
    Private m_weightto As Decimal
    Private m_active As Integer
    Private m_onebay As Integer
    Private m_defaults As Boolean
    Private m_suppliercode As Integer
    Private m_special As Integer
    Private m_sqlstring As String


    '--- 0 = N/A
    '--- 1 = True
    '--- 2 = False

    Public Function create_sql()
        On Error GoTo ErrorHandler
        Dim bError As Boolean = True

        Dim cTmpSqlString As String = ""

        cTmpSqlString = "select * from v_inventory_list where id > 0 "
        '--- Select BRANCH
        If Me.branch <> 0 Then
            cTmpSqlString = cTmpSqlString + " and branchnumber = " & Me.branch
        End If

        '--- Select Supplier
        If Me.supplier <> 0 Then
            cTmpSqlString = cTmpSqlString + " and suppliernumber = " & Me.supplier
        End If

        '--- Select Itemnumber
        If Me.itemnumber <> 0 Then
            cTmpSqlString = cTmpSqlString + " and itemnumberint = " & Me.itemnumber
        End If

        '--- Select Type
        If Me.stonetype <> "N/A" Then
            cTmpSqlString = cTmpSqlString + " and stonetype_long = '" & Me.stonetype & "'"
        End If

        If Me.stoneshape <> "N/A" Then
            cTmpSqlString = cTmpSqlString + " and shape_long = '" & Me.stoneshape & "'"
        End If

        '--- Select Active
        If Me.active <> 0 Then
            Dim cTmp As String
            If Me.active = 1 Then
                cTmp = 1
            ElseIf Me.active = 2 Then
                cTmp = 0
            End If
            cTmpSqlString = cTmpSqlString + " and qtyonstock_cur > 0 and  shopstatus = " & cTmp
        End If

        If Me.onebay <> 0 Then
            cTmpSqlString = cTmpSqlString + " and onebay=1"
        End If

        '--- Select special
        If Me.special <> 0 Then
            Dim cTmp2 As String
            If Me.special = 1 Then
                cTmp2 = 1
            ElseIf Me.special = 2 Then
                cTmp2 = 0
            End If
            cTmpSqlString = cTmpSqlString + " and onspecial = " & cTmp2
        End If

        If Me.itemcode <> "" Then
            cTmpSqlString = cTmpSqlString + " and itemcode like '" + Me.itemcode.Replace("*", "%") + "'"
        End If

        If Me.defaults = True Then
            cTmpSqlString = cTmpSqlString + " and default_model = 1 "
        End If

        If Me.csstonetype <> "-" Then
            cTmpSqlString = cTmpSqlString + " and cs_type like '" + Me.csstonetype + "'"
        End If

        If Me.weightto = 0 Then Me.weightto = Me.weight

        If Me.weight > 0 And Me.weightto > 0 Then
            cTmpSqlString = cTmpSqlString + " and weight between  " + Me.weight.ToString + " and " + Me.weightto.ToString
        End If

        'If Me.suppliercode <> "" Then
        '    cTmpSqlString = cTmpSqlString + " and itemcode = '" + Me.suppliercode + "'"
        'End If

        Me.sqlstring = cTmpSqlString + " order by id desc"

        Return False
        Exit Function

ErrorHandler:
        '--- register the error
        Me.err_number = Err.Number
        Me.err_description = Err.Description
        Me.err_source = Err.Source
        Return True

    End Function

    Public Property special() As Integer
        Get
            Return m_special
        End Get

        Set(ByVal Value As Integer)
            m_special = Value
        End Set
    End Property

    Public Property active() As Integer
        Get
            Return m_active
        End Get

        Set(ByVal Value As Integer)
            m_active = Value
        End Set
    End Property

    Public Property onebay() As Integer
        Get
            Return m_onebay
        End Get

        Set(ByVal Value As Integer)
            m_onebay = Value
        End Set
    End Property

    Public Property defaults() As Boolean
        Get
            Return m_defaults
        End Get

        Set(ByVal Value As Boolean)
            m_defaults = Value
        End Set
    End Property
    Public Property suppliercode() As Integer
        Get
            Return m_suppliercode
        End Get

        Set(ByVal Value As Integer)
            m_suppliercode = Value
        End Set

    End Property

    Public Property weight() As Decimal
        Get
            Return m_weight
        End Get

        Set(ByVal Value As Decimal)
            m_weight = Value
        End Set
    End Property
    Public Property weightto() As Decimal
        Get
            Return m_weightto
        End Get

        Set(ByVal Value As Decimal)
            m_weightto = Value
        End Set
    End Property

    Public Property stonetype() As String
        Get
            Return m_stonetype
        End Get

        Set(ByVal Value As String)
            m_stonetype = Value
        End Set
    End Property
    Public Property csstonetype() As String
        Get
            Return m_csstonetype
        End Get

        Set(ByVal Value As String)
            m_csstonetype = Value
        End Set
    End Property
    Public Property stoneshape() As String
        Get
            Return m_stoneshape
        End Get

        Set(ByVal Value As String)
            m_stoneshape = Value
        End Set
    End Property

    Public Property itemcode() As String
        Get
            Return m_itemcode
        End Get

        Set(ByVal Value As String)
            m_itemcode = Value
        End Set
    End Property

    Public Property branch() As Integer
        Get
            Return m_branch
        End Get

        Set(ByVal Value As Integer)
            m_branch = Value
        End Set
    End Property

    Public Property supplier() As Integer
        Get
            Return m_supplier
        End Get

        Set(ByVal Value As Integer)
            m_supplier = Value
        End Set
    End Property

    Public Property itemnumber() As Int32
        Get
            Return m_itemnumber
        End Get

        Set(ByVal Value As Int32)
            m_itemnumber = Value
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

    Public Property err_number() As Integer
        Get
            Return m_err_number
        End Get

        Set(ByVal Value As Integer)
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



End Class
