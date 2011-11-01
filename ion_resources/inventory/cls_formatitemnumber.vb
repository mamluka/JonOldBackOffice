Public Class cls_formatitemnumber

    Private m_branchnumber As Integer
    Private m_suppliernumber As Integer
    Private m_itemnumber As Int32
    Private m_newitemnumber As String


    Public Function FormatItemNumber() As Boolean

        '--- check incomming
        If Me.branchnumber < 1 Then
            Return True
        ElseIf Me.branchnumber > 99 Then
            Return True

		ElseIf Me.suppliernumber < 0 Then
			Return True
		ElseIf Me.suppliernumber > 99 Then
			Return True

		ElseIf Me.itemnumber < 1 Then
			Return True
		ElseIf Me.itemnumber > 99999 Then
			Return True

		End If

		'--- BranchNumber
		Dim cTmpBranchNumber = System.Convert.ToString(Me.branchnumber)
		If Len(cTmpBranchNumber) = 1 Then
			cTmpBranchNumber = "0" + cTmpBranchNumber
		End If

		'--- SupplierNumber
		Dim cTmpSupplierNumber = System.Convert.ToString(Me.suppliernumber)
		If Len(cTmpSupplierNumber) = 1 Then
			cTmpSupplierNumber = "0" + cTmpSupplierNumber
		End If

		'--- ItemNumber
		Dim cTmpItemNumber = System.Convert.ToString(Me.itemnumber)
		Select Case Len(cTmpItemNumber)
			Case 1
				cTmpItemNumber = "0000" + cTmpItemNumber
			Case 2
				cTmpItemNumber = "000" + cTmpItemNumber
			Case 3
				cTmpItemNumber = "00" + cTmpItemNumber
			Case 4
				cTmpItemNumber = "0" + cTmpItemNumber
		End Select

		Me.newitemnumber = cTmpBranchNumber + "-" + cTmpSupplierNumber + "-" + cTmpItemNumber

    End Function

    Public Property branchnumber() As Integer
        Get
            Return m_branchnumber
        End Get

        Set(ByVal Value As Integer)
            m_branchnumber = Value
        End Set
    End Property

    Public Property suppliernumber() As Integer
        Get
            Return m_suppliernumber
        End Get

        Set(ByVal Value As Integer)
            m_suppliernumber = Value
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

    Public Property newitemnumber() As String
        Get
            Return m_newitemnumber
        End Get

        Set(ByVal Value As String)
            m_newitemnumber = Value
        End Set
    End Property



End Class
