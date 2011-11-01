Public Class cls_trs_insert_payment
    Inherits ion_resources.cls_transactor

    Private m_payment_id As Int32

    '###################################################################################
    Overrides Function pre_commit(ByRef error_no As Int32, ByRef error_desc As String, ByRef error_source As String) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False


        Dim oPayment As DataRow = Me.dataset.Tables("acc_CASHFLOW").Rows(0)
        Me.payment_id = Me.general_id


        Return False
        Exit Function

ErrorHandler:
        error_no = Err.Number
        error_desc = Err.Description
        error_source = Err.Source
        Return True

    End Function




    Public Property payment_id() As Int32
        Get
            Return m_payment_id
        End Get

        Set(ByVal Value As Int32)
            m_payment_id = Value
        End Set
    End Property

End Class
