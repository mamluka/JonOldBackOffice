Partial Class receive_payment
    Inherits System.Web.UI.Page


    '--- Set publics
    Public nPayment_id As Int32
    Public nOrderNo As Int32
    Public oPayment As New ion_resources.cls_payment()
    Public oCashFlow As New ion_resources.cls_payment_lgc()
    Public bAllreadyApproved As Boolean


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

        Dim oFillcombo As New cls_datareader()
        Dim oError As New cls_error()
        oFillcombo.config = Application("config")
        oFillcombo.oerror = oError

        '--- fill Shipping STATE combo
        oFillcombo.combobox = Me.cmb_cc_cardtype
        oFillcombo.sqlstring = "select id, lang" & Session("user").language & "_longdescr from acc_CREDITCARD  order by lang" & Session("user").language & "_longdescr"
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
        Server.Transfer("/apperror.aspx")


    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- Set culture of form
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(Request.UserLanguages(0))
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(Request.UserLanguages(0))

        nPayment_id = Request.QueryString("id")
        oCashFlow.connection_string = Application("config").connection_string

        '--- Get the payment record
        bError = oCashFlow.get_payment(nPayment_id, oPayment)
        If bError Then
            '--- when object is called in external DLL
            Session("error").err_number = Err.Number
            Session("error").err_source = Err.Source
            Session("error").err_description = Err.Description
            '--- Custom error
            Dim oTmpErrDB1 As New System.Diagnostics.StackFrame()
            Session("error").app_module = Me.Request.CurrentExecutionFilePath
            Session("error").app_function = oTmpErrDB1.GetMethod.Name
            Session("error").app_call = "Page_load"
            Server.Transfer("/apperror.aspx")
        End If


        '--- Check if Payment is Allready Approved
        If oPayment.approved Then
            bAllreadyApproved = True
            Me.chk_payment_received.Enabled = False
            Me.txt_approval_date.Visible = True
            Me.txt_approval_date.Enabled = False
        Else
            bAllreadyApproved = False
            Me.chk_payment_received.Enabled = False
            Me.chk_payment_received.Enabled = True
            Me.txt_approval_date.Visible = False
        End If


        '--- Load Payment
        If Not Page.IsPostBack Then
            '--- Hide YesNo box
            Me.tbl_YesNo.Visible = False

            '--- Write Caption
            Dim nTmpOrderNumber As Int32
            Dim oTmpOrder As New ion_resources.cls_functions_order()
            oTmpOrder.connection_string = Application("config").connection_string
            oTmpOrder.get_ordernumber(oPayment.order_id, nTmpOrderNumber)
            Me.lbl_caption.Text = Me.lbl_caption.Text + Space(1) + Convert.ToString(nTmpOrderNumber)
            nOrderNo = nTmpOrderNumber
            oTmpOrder = Nothing

            '--- Set payment
            Me.txt_payment.Text = Format(oPayment.amount_total, "##,##0.00")
            Me.txt_amount_actual.Text = Format(oPayment.amount_actual, "##,##0.00")
            Me.txt_amount_costs.Text = Format(oPayment.amount_costs, "##,##0.00")
            Me.chk_payment_received.Checked = oPayment.approved
            Me.txt_notes.Text = oPayment.notes
            Me.txt_approval_date.Text = oPayment.approved_date
            Me.txt_lastuser_id.Text = oPayment.LastModify_User_id
            Me.txt_lastuser_name.Text = oPayment.LastModify_User
            Me.txt_lastuser_date.Text = oPayment.LastModify_Date

            Select Case oPayment.payment_type
                Case 1  '--- CreditCard
                    '--- Set the correct payment method
                    Me.tbl_payments_CerditCard.Visible = True
                    Me.tbl_money_wire.Visible = False
                    Me.tbl_check.Visible = False

                    '--- Fill CreditCard
                    Me.cmb_cc_cardtype.SelectedIndex = GetComboValue(Me.cmb_cc_cardtype, oPayment.cc_type_id)
                    Me.cmb_cc_month.SelectedIndex = GetComboValue(Me.cmb_cc_month, oPayment.cc_exp_month)
                    Me.cmb_cc_year.SelectedIndex = GetComboValue(Me.cmb_cc_year, oPayment.cc_exp_year)
                    Me.txt_cc_cardnumber.Text = oPayment.cc_number
                    Me.txt_cc_nameoncard.Text = oPayment.cc_name
                    Me.txt_cc_code.Text = oPayment.cc_confermation
                    Me.chk_style_member.Checked = oPayment.cc_clubmember
                    Me.txt_cc_cvv.Text = oPayment.cc_cvv
                    Me.txt_cc_person_id.Text = oPayment.cc_user_ssn
                    Me.chk_cc_cleared.Checked = oPayment.cc_cleared

                Case 2  '--- Money transfer
                    '--- Set the correct payment method
                    Me.tbl_payments_CerditCard.Visible = False
                    Me.tbl_money_wire.Visible = True
                    Me.tbl_check.Visible = False

                    '--- Fill Money transfer
                    Me.txt_mt_bank.Text = oPayment.mt_bank
                    Me.txt_mt_name.Text = oPayment.mt_name
                    Me.txt_mt_account.Text = oPayment.mt_account
                    Me.txt_mt_code.Text = oPayment.mt_code

                Case 3  '--- Cashiers check
                    '--- Set the correct payment method
                    Me.tbl_payments_CerditCard.Visible = False
                    Me.tbl_money_wire.Visible = False
                    Me.tbl_check.Visible = True

                    '--- Fill cashiers check
                    Me.txt_cq_bank.Text = oPayment.cq_bank
                    Me.txt_cq_name.Text = oPayment.cq_name
                    Me.txt_cq_account.Text = oPayment.cq_account
                    Me.txt_cq_date.Text = oPayment.cq_date

            End Select
        End If


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
        Session("error").app_call = "Page_load"
        Server.Transfer("/apperror.aspx")

    End Sub

    Private Sub btn_submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_submit.Click
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- Save Payment
        oPayment.amount_costs = Convert.ToDecimal(Me.txt_amount_costs.Text)
        oPayment.amount_actual = Convert.ToDecimal(Me.txt_amount_actual.Text)
        oPayment.notes = Me.txt_notes.Text.Trim


        '--- Get User
        'Dim oFunctions_Order As New ion_two.cls_functions_orders
        'oFunctions_Order._connection_string = Application("config").connection_string
        'oFunctions_Order._dbtype = Application("config").connection_string_type
        'bError = oFunctions_Order.get_order_user(oPayment.order_id, oPayment.LastModify_User_id, oPayment.LastModify_User)
        'If bError Then
        'Session("o_error")._Err_Number = oFunctions_Order._err_number
        'Session("o_error")._Err_Description = oFunctions_Order._err_description
        'Session("o_error")._Err_Source = oFunctions_Order._err_source
        'Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
        'Session("o_error")._Err_Call = "btn_submit_Click [ion_two.cls_functions_orders:get_order_user]"
        'Server.Transfer("/aspxerror.aspx")
        'End If
        'oFunctions_Order = Nothing


        oPayment.LastModify_User = Session("user").user_name
        oPayment.LastModify_User_id = Session("user").user_id

        '--- Set payment chaecked  + Date
        If Not bAllreadyApproved Then
            oPayment.approved = Me.chk_payment_received.Checked
            oPayment.approved_date = Date.Now
        End If


        Select Case oPayment.payment_type
            Case 1            '--- CreditCard
                oPayment.cc_type_id = Me.cmb_cc_cardtype.SelectedItem.Value
                oPayment.cc_exp_month = Me.cmb_cc_month.SelectedItem.Value
                oPayment.cc_exp_year = Me.cmb_cc_year.SelectedItem.Value
                oPayment.cc_number = Me.txt_cc_cardnumber.Text.Trim
                oPayment.cc_name = Me.txt_cc_nameoncard.Text.Trim
                oPayment.cc_confermation = Me.txt_cc_code.Text.Trim
                oPayment.cc_clubmember = Me.chk_style_member.Checked
                oPayment.cc_cvv = Me.txt_cc_cvv.Text.Trim
                oPayment.cc_user_ssn = Me.txt_cc_person_id.Text.Trim
                oPayment.cc_cleared = Me.chk_cc_cleared.Checked

            Case 2            '--- Money transfer
                oPayment.mt_bank = Me.txt_mt_bank.Text.Trim
                oPayment.mt_name = Me.txt_mt_name.Text.Trim
                oPayment.mt_account = Me.txt_mt_account.Text.Trim
                oPayment.mt_code = Me.txt_mt_code.Text.Trim

            Case 3            '--- Cashiers check
                oPayment.cq_bank = Me.txt_cq_bank.Text.Trim
                oPayment.cq_name = Me.txt_cq_name.Text.Trim
                oPayment.cq_account = Me.txt_cq_account.Text.Trim
                oPayment.cq_date = Me.txt_cq_date.Text.Trim

        End Select

        '--- Save the payment record
        bError = oCashFlow.update_payment(oPayment)
        If bError Then
            '--- when object is called in external DLL
            Session("error").err_number = oCashFlow.error_no
            Session("error").err_source = oCashFlow.error_source
            Session("error").err_description = oCashFlow.error_desc
            '--- Custom error
            Dim oTmpErrDB0 As New System.Diagnostics.StackFrame
            Session("error").app_module = Me.Request.CurrentExecutionFilePath
            Session("error").app_function = oTmpErrDB0.GetMethod.Name
            Session("error").app_call = "btn_submit_click"
            Server.Transfer("/apperror.aspx")
        End If

        '--- disable all controls
        bError = disableall(False)

        Dim oFunctionOrders As New ion_resources.cls_functions_order
        oFunctionOrders.connection_string = Application("config").connection_string
        Dim bOrderTransact As Boolean
        bError = oFunctionOrders.get_order_transact(oPayment.order_id, bOrderTransact)
        If Not bOrderTransact Then
            '--- Check if order fullfilled
            Dim oTmpCalcPay As New ion_resources.cls_payment_calc
            oTmpCalcPay.connection_string = Application("config").connection_string
            bError = oTmpCalcPay.calc_order(oPayment.order_id)

            '--- Check if order is fullfilled
            '--- check to see if transaction not already done
            If oTmpCalcPay.order_total_left_to_pay = 0 Then
                Me.tbl_YesNo.Visible = True
            End If

            oTmpCalcPay = Nothing

        End If

        Exit Sub

ErrorHandler:
        '--- when object is called in external DLL
        Session("error").err_number = Err.Number
        Session("error").err_source = Err.Source
        Session("error").err_description = Err.Description
        '--- Custom error
        Dim oTmpErrDB As New System.Diagnostics.StackFrame
        Session("error").app_module = Me.Request.CurrentExecutionFilePath
        Session("error").app_function = oTmpErrDB.GetMethod.Name
        Session("error").app_call = "btn_submit_click"
        Server.Transfer("/apperror.aspx")
    End Sub


    Private Function disableall(ByVal bDisable) As Boolean
        txt_cc_person_id.Enabled = bDisable
        txt_cc_nameoncard.Enabled = bDisable
        txt_cc_cvv.Enabled = bDisable
        txt_cc_cardnumber.Enabled = bDisable
        chk_style_member.Enabled = bDisable
        cmb_cc_year.Enabled = bDisable
        cmb_cc_month.Enabled = bDisable
        txt_cc_code.Enabled = bDisable
        cmb_cc_cardtype.Enabled = bDisable
        txt_mt_code.Enabled = bDisable
        txt_mt_account.Enabled = bDisable
        txt_mt_name.Enabled = bDisable
        txt_mt_bank.Enabled = bDisable
        txt_cq_date.Enabled = bDisable
        txt_cq_account.Enabled = bDisable
        txt_cq_name.Enabled = bDisable
        txt_cq_bank.Enabled = bDisable
        chk_cc_cleared.Enabled = bDisable
        btn_submit.Enabled = bDisable
        chk_payment_received.Enabled = bDisable
        RangeValidator1.Enabled = bDisable
        txt_amount_costs.Enabled = bDisable
        txt_amount_actual.Enabled = bDisable
        txt_payment.Enabled = bDisable
        txt_cc_batch.Enabled = bDisable
        txt_notes.Enabled = bDisable

    End Function

    Private Sub txt_amount_costs_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_amount_costs.TextChanged
        Me.txt_amount_actual.Text = Convert.ToDecimal(Me.txt_payment.Text) - Convert.ToDecimal(Me.txt_amount_costs.Text)
        Me.txt_amount_actual.Text = Format(Convert.ToDecimal(Me.txt_amount_actual.Text), "##,##0.00")
    End Sub

    Private Sub btn_YES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_YES.Click
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False


        '--- Get user from order
        'Dim cUser_name As String
        'Dim nUser_id As Int32
        'Dim oOrder_functions As New ion_two.cls_functions_orders
        'oOrder_functions._connection_string = Application("config").connection_string
        'oOrder_functions._dbtype = Application("config").connection_string_type
        'bError = oOrder_functions.get_order_user(Me.oPayment.order_id, nUser_id, cUser_name)
        'If bError Then
        'Session("o_error")._Err_Number = oOrder_functions._err_number
        'Session("o_error")._Err_Description = oOrder_functions._err_description
        'Session("o_error")._Err_Source = oOrder_functions._err_source
        'Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
        'Session("o_error")._Err_Call = "btn_YES_Click [ion_two.cls_functions_orders:get_order_user]"
        'Server.Transfer("/aspxerror.aspx")
        'End If
        'oOrder_functions = Nothing

        '--- Set status
        Dim oStatus As New ion_two.cls_status
        oStatus._connection_string = Application("config").connection_string
        oStatus._dbtype = Application("config").connection_string_type
        oStatus._user_name = Session("user").user_name
        oStatus._user_id = Session("user").user_id
        bError = oStatus.set_status(Me.oPayment.order_id, 4, Date.Now)
        If bError Then
            Session("o_error")._Err_Number = oStatus._err_number
            Session("o_error")._Err_Description = oStatus._err_description
            Session("o_error")._Err_Source = oStatus._err_source
            Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
            Session("o_error")._Err_Call = "btn_YES_Click [ion_two.cls_status:set_status]"
            Server.Transfer("/aspxerror.aspx")
        End If

        Me.tbl_YesNo.Visible = False

        Exit Sub

ErrorHandler:
        '--- when object is called in external DLL
        Session("error").err_number = Err.Number
        Session("error").err_source = Err.Source
        Session("error").err_description = Err.Description
        '--- Custom error
        Dim oTmpErrDB As New System.Diagnostics.StackFrame
        Session("error").app_module = Me.Request.CurrentExecutionFilePath
        Session("error").app_function = oTmpErrDB.GetMethod.Name
        Session("error").app_call = "btn_YES_click"
        Server.Transfer("/apperror.aspx")

    End Sub

    Private Sub btn_NO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_NO.Click
        Me.tbl_YesNo.Visible = False
    End Sub
End Class
