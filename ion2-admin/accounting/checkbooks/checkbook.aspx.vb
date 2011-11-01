Partial Class checkbook
    Inherits System.Web.UI.Page

    Public nCurrency As Int16
    Public nMode As Int16
    Public nCheckId As Int32

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- Get querystrings
        nCurrency = Request.QueryString.Item("cur")
        nCheckId = Request.QueryString.Item("id")
        If nCheckId > 0 Then
            nMode = 2
        Else
            nMode = 1
        End If


        Dim oFillcombo As New cls_datareader()
        Dim oError As New cls_error()
        oFillcombo.config = Application("config")
        oFillcombo.oerror = oError

        '--- fill Suppliers combo
        oFillcombo.combobox = Me.cmb_suppliers
        oFillcombo.sqlstring = "select id2, company from spl_SUPPLIERS order by sortorder"
        oFillcombo.showfield = "company"
        bError = oFillcombo.bind_combo2()
        If bError Then
            '--- when object is called in external DLL
            Session("error").err_number = oFillcombo.oerror.err_number
            Session("error").err_source = oFillcombo.oerror.err_source
            Session("error").err_description = oFillcombo.oerror.err_description
            '--- Our custom error
            Dim oTmpDB As New System.Diagnostics.StackFrame()
            Session("error").app_module = Me.Request.CurrentExecutionFilePath
            Session("error").app_function = oTmpDB.GetMethod.Name
            Session("error").app_call = "page_init / cls_datareader"
            Server.Transfer("/apperror.aspx")
        End If

        '--- fill Accounts combo
        oFillcombo.combobox = Me.cmb_accounts
        oFillcombo.sqlstring = "select id, lang" & Session("user").language & "_longdescr from acc_ACCOUNT_NAMES order by lang" & Session("user").language & "_longdescr"
        oFillcombo.showfield = "lang" & Session("user").language & "_longdescr"
        bError = oFillcombo.bind_combo()
        If bError Then
            '--- when object is called in external DLL
            Session("error").err_number = oFillcombo.oerror.err_number
            Session("error").err_source = oFillcombo.oerror.err_source
            Session("error").err_description = oFillcombo.oerror.err_description
            '--- Our custom error
            Dim oTmpDB As New System.Diagnostics.StackFrame()
            Session("error").app_module = Me.Request.CurrentExecutionFilePath
            Session("error").app_function = oTmpDB.GetMethod.Name
            Session("error").app_call = "page_init / cls_datareader"
            Server.Transfer("/apperror.aspx")
        End If



        '--- Set header
        Select Case nMode
            Case 1
                Select Case nCurrency
                    Case 1
                        Me.lbl_header.Text = "US Dollar - New check"

                    Case 2
                        Me.lbl_header.Text = "ILS Israeli Shekel - New check"

                End Select


            Case 2
                Select Case nCurrency
                    Case 1
                        Me.lbl_header.Text = "US Dollar - Edit check"

                    Case 2
                        Me.lbl_header.Text = "ILS Israeli shekel - New check"

                End Select



        End Select


        oFillcombo = Nothing
        oError = Nothing

        Exit Sub

ErrorHandler:
        '--- when object is called in external DLL
        Session("error").err_number = Err.Number
        Session("error").err_source = Err.Source
        Session("error").err_description = Err.Description
        '--- Custom error
        Dim oTmpErrDB As New System.Diagnostics.StackFrame()
        Session("error").app_module = Me.Request.CurrentExecutionFilePath
        Session("error").app_function = oTmpErrDB.GetMethod.Name
        Session("error").app_call = "Page_Init"

    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False


        If nMode = 1 Then '--- Add


        ElseIf nMode = 2 Then '--- Edit


        End If




        Me.set_combo(1)







        Exit Sub

ErrorHandler:
        '--- when object is called in external DLL
        Session("error").err_number = Err.Number
        Session("error").err_source = Err.Source
        Session("error").err_description = Err.Description
        '--- Our custom error
        Dim oTmpErrDB As New System.Diagnostics.StackFrame()
        Session("error").app_module = Me.Request.CurrentExecutionFilePath
        Session("error").app_function = oTmpErrDB.GetMethod.Name
        Session("error").app_call = "checkbook / Page_Load"
        Server.Transfer("/apperror.aspx")

    End Sub

    '#################################################################################
    Private Function load_check(ByVal nCheckId As Int32) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False








        Return False
        Exit Function

ErrorHandler:
        '--- when object is called in external DLL
        Session("error").err_number = Err.Number
        Session("error").err_source = Err.Source
        Session("error").err_description = Err.Description
        '--- Our custom error
        Dim oTmpErrDB As New System.Diagnostics.StackFrame()
        Session("error").app_module = Me.Request.CurrentExecutionFilePath
        Session("error").app_function = oTmpErrDB.GetMethod.Name
        Session("error").app_call = "checkbook / Load_Check"
        Server.Transfer("/apperror.aspx")
        Return True

    End Function




    '#################################################################################
    Private Sub set_combo(ByVal bMode As Int16)
        '--- bMode 1 = Suppliers 2= Accounts

        If bMode = 1 Then
            Me.chk_accounts.Enabled = True
            Me.chk_accounts.Checked = False
            Me.cmb_accounts.Enabled = False

            Me.chk_suppliers.Enabled = False
            Me.chk_suppliers.Checked = True
            Me.cmb_suppliers.Enabled = True

        ElseIf bMode = 2 Then
            Me.chk_accounts.Enabled = False
            Me.chk_accounts.Checked = True
            Me.cmb_accounts.Enabled = True

            Me.chk_suppliers.Enabled = True
            Me.chk_suppliers.Checked = False
            Me.cmb_suppliers.Enabled = False

        End If

    End Sub


    Private Sub chk_suppliers_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_suppliers.CheckedChanged
        Me.set_combo(1)

    End Sub

    Private Sub chk_accounts_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_accounts.CheckedChanged
        Me.set_combo(2)
    End Sub
End Class
