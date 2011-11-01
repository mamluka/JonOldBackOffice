Partial Class wc_get_payments
    Inherits System.Web.UI.UserControl

    Public WithEvents hid_PaymentType As System.Web.UI.WebControls.Label
    Public WithEvents txt_cc_code As System.Web.UI.WebControls.TextBox
    Public WithEvents hid_payment As System.Web.UI.WebControls.TextBox
    Public WithEvents hid_interest As System.Web.UI.WebControls.Label
    Public WithEvents chk_payment_check As System.Web.UI.WebControls.CheckBox
    Public WithEvents chk_payment_wire As System.Web.UI.WebControls.CheckBox
    Public WithEvents chk_payment_cc As System.Web.UI.WebControls.CheckBox
    Public WithEvents vld_cq_date2 As System.Web.UI.WebControls.RequiredFieldValidator
    '---

    Public bClubOrder As Boolean
    Public oPayment As New ion_resources.cls_payment()
    Public nOrder_id As Int32
    Public nUser_id As Int32
    Public cc_valid As Boolean
    Public amount_tosave As Decimal


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
        'Put user code to initialize the page here

        If Not Page.IsPostBack Then
            'Me.hid_PaymentType.Text = 1
            'Me.vld_cq_date2.Enabled = False

        End If
    End Sub


    Private Sub cmb_cc_cardtype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_cc_cardtype.SelectedIndexChanged
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Dim nExtraChargesPerc As Decimal
        Dim nArrivalDays As Int16
        Dim nProviderCode As Int16

        bError = calc_charges(Me.cmb_cc_cardtype.SelectedItem.Value, nExtraChargesPerc, nArrivalDays, nProviderCode)
        If bError Then
            '--- when object is called in external DLL
            Session("error").err_number = Err.Number
            Session("error").err_source = Err.Source
            Session("error").err_description = Err.Description
            '--- Our custom error
            Dim oTmpDB As New System.Diagnostics.StackFrame()
            Session("error").app_module = Me.Request.CurrentExecutionFilePath
            Session("error").app_function = oTmpDB.GetMethod.Name
            Session("error").app_call = "page_init / cls_datareader"
            Server.Transfer("/apperror.aspx")
        End If

        '--- Assign
        hid_extrachargesPerc.Text = nExtraChargesPerc
        hid_providercode.Text = nProviderCode

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

    Private Function calc_charges(ByVal nCardType As Int16, ByRef nExtraCharges As Decimal, ByRef nArrivalDays As Int16, ByRef nProviderCode As Int16) As Boolean
        'On Error GoTo ErrorHandler
        Dim bError As Boolean = False


        Return False
        Exit Function

ErrorHandler:
        '--- when object is called in external DLL
        Session("error").err_number = Err.Number
        Session("error").err_source = Err.Source
        Session("error").err_description = Err.Description
        '--- Custom error
        Dim oTmpErrDB As New System.Diagnostics.StackFrame()
        Session("error").app_module = Me.Request.CurrentExecutionFilePath
        Session("error").app_function = oTmpErrDB.GetMethod.Name
        Session("error").app_call = "calc_charges / order_payments"
        Return True

    End Function

    Public Function validate(ByRef lst_error As System.Web.UI.WebControls.ListBox, ByRef bSucess As Boolean) As Boolean

        If Me.cmb_cc_cardtype.SelectedItem.Value = 1 And Me.chk_payment_cc.Checked Then
            lst_error.Items.Add("- Must select credit-card type!")
            bSucess = False
        End If

        If Me.cmb_cc_month.SelectedItem.Value = 0 And Me.chk_payment_cc.Checked Then
            lst_error.Items.Add("- Must select credit card expiration month!")
            bSucess = False
        End If

        If Me.cmb_cc_year.SelectedItem.Value = 0 And Me.chk_payment_cc.Checked Then
            lst_error.Items.Add("- Must select credit card expiration year!")
            bSucess = False
        End If

        If Me.txt_cc_nameoncard.Text = "" And Me.chk_payment_cc.Checked Then
            lst_error.Items.Add("- Must enter credit-card owner name!")
            bSucess = False
        End If

        If Me.txt_cc_cardnumber.Text.Length < 12 And Me.chk_payment_cc.Checked Then
            lst_error.Items.Add("- Must enter credit-card number!")
            bSucess = False
        End If

    End Function

    Public Function make_payment(ByRef bSuccess As Boolean, ByVal nMode As Int16, ByVal bCalcInterest As Boolean) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        bError = zeropayment(oPayment)

        oPayment.payment_type = Me.hid_PaymentType.Text
        oPayment.payment_date = Date.Now
        oPayment.order_id = nOrder_id
        oPayment.user_id = nUser_id
        oPayment.approved = False
        oPayment.approved_date = #1/1/1900#
        'oPayment.amount_total = Me.hid_payment.Text
        'oPayment.amount_interest = Me.hid_interest.Text
        oPayment.received = False
        oPayment.received_date = #1/1/1900#
        oPayment.LastModify_Date = Date.Now

        'oPayment.LastModify_User = Session("user").user_name
        'oPayment.LastModify_User_id = Session("user").user_id
        oPayment.notes = Me.txt_notes.Text
        oPayment.cc_type_id = 0

        '--- Get User
        Dim oFunctions_Order As New ion_two.cls_functions_orders
        oFunctions_Order._connection_string = Application("config").connection_string
        oFunctions_Order._dbtype = Application("config").connection_string_type
        bError = oFunctions_Order.get_order_user(oPayment.order_id, oPayment.LastModify_User_id, oPayment.LastModify_User)
        If bError Then
            Session("o_error")._Err_Number = oFunctions_Order._err_number
            Session("o_error")._Err_Description = oFunctions_Order._err_description
            Session("o_error")._Err_Source = oFunctions_Order._err_source
            Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
            Session("o_error")._Err_Call = "btn_submit_Click [ion_two.cls_functions_orders:get_order_user]"
            Server.Transfer("/aspxerror.aspx")
        End If
        oFunctions_Order = Nothing



        '--- Calculate interest
        If bCalcInterest Then
            Dim nTmpAmount = System.Convert.ToDecimal(Me.hid_payment.Text)
            bError = calc_interest(nOrder_id, nTmpAmount, oPayment.amount_interest)
            oPayment.amount_total = nTmpAmount
        Else

            oPayment.amount_total = 1000
            oPayment.amount_interest = 0
        End If


        Select Case Me.hid_PaymentType.Text
            Case 1     '-- CreditCard
                '--- Do online payment
                Dim oTmpWebPayment As New ion_resources.cls_webpay
                oTmpWebPayment.cc_clubmember = Me.chk_style_member.Checked
                oTmpWebPayment.cc_cvv = Me.txt_cc_cvv.Text.Trim
                oTmpWebPayment.cc_exp_month = Me.cmb_cc_month.SelectedItem.Value
                oTmpWebPayment.cc_exp_year = Me.cmb_cc_year.SelectedItem.Value
                oTmpWebPayment.cc_name = Me.txt_cc_nameoncard.Text.Trim
                oTmpWebPayment.cc_number = Me.txt_cc_cardnumber.Text.Trim
                oTmpWebPayment.cc_type_id = Me.cmb_cc_cardtype.SelectedItem.Value
                oTmpWebPayment.cc_user_ssn = Me.txt_cc_person_id.Text.Trim
                oTmpWebPayment.cc_confermation = Me.txt_cc_code.Text.Trim
                oTmpWebPayment.amount = oPayment.amount_total
                bError = oTmpWebPayment.make_webpayment(bSuccess, nMode)

                '--- If payment Ok then and CreditCard then approve automaticly
                'If bSuccess Then
                '    oPayment.approved = True
                '    oPayment.approved_date = Date.Now
                'End If


                '--- Save Payment
                oPayment.cc_type_id = Me.cmb_cc_cardtype.SelectedItem.Value
                oPayment.cc_name = Me.txt_cc_nameoncard.Text.Trim
                oPayment.cc_number = Me.txt_cc_cardnumber.Text.Trim
                oPayment.cc_cvv = Me.txt_cc_cvv.Text.Trim
                oPayment.cc_exp_year = Me.cmb_cc_year.SelectedItem.Value
                oPayment.cc_exp_month = Me.cmb_cc_month.SelectedItem.Value
                oPayment.cc_user_ssn = Me.txt_cc_person_id.Text.Trim
                oPayment.cc_clubmember = Me.chk_style_member.Checked
                oPayment.cc_confermation = oTmpWebPayment.cc_confermation
                oPayment.cc_cleared = oTmpWebPayment.cc_cleared

                oTmpWebPayment = Nothing

            Case 2    '-- Money Transfer
                oPayment.mt_bank = Me.txt_mt_bank.Text.Trim
                oPayment.mt_account = Me.txt_mt_account.Text.Trim
                oPayment.mt_name = Me.txt_mt_name.Text.Trim
                oPayment.mt_code = Me.txt_mt_code.Text.Trim
                bSuccess = True

            Case 3     '-- Cashiers check
                oPayment.cq_bank = Me.txt_cq_bank.Text.Trim
                oPayment.cq_name = Me.txt_cq_name.Text.Trim
                oPayment.cq_account = Me.txt_cq_account.Text.Trim
                oPayment.cq_date = System.Convert.ToDateTime(Me.txt_cq_date.Text)
                bSuccess = True

        End Select

        oPayment.approved = Me.cc_valid
        oPayment.amount_actual = Me.amount_tosave

        If bSuccess Then
            '--- Save payment
            Dim oPaymentBroker As New ion_resources.cls_payment_lgc
            oPaymentBroker.connection_string = Application("config").connection_string
            bError = oPaymentBroker.insert_payment(oPayment)
            oPaymentBroker = Nothing
        End If


        '--- Get user from order
        Dim cFirstname As String
        Dim cLastname As String
        Dim oCustomer_functions As New ion_two.cls_functions_user
        oCustomer_functions._connection_string = Application("config").connection_string
        oCustomer_functions._dbtype = Application("config").connection_string_type
        bError = oCustomer_functions.get_username(nUser_id, cFirstname, cLastname)
        If bError Then
            Session("o_error")._Err_Number = oCustomer_functions._err_number
            Session("o_error")._Err_Description = oCustomer_functions._err_description
            Session("o_error")._Err_Source = oCustomer_functions._err_source
            Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
            Session("o_error")._Err_Call = "make_payment [ion_two.cls_functions_user:get_username]"
            Server.Transfer("/aspxerror.aspx")
        End If
        oCustomer_functions = Nothing

        '--- Set status
        Dim oSetStatus As New ion_two.cls_status
        oSetStatus._connection_string = Application("config").connection_string
        oSetStatus._dbtype = Application("config").connection_string_type
        oSetStatus._user_id = nUser_id
        oSetStatus._user_name = cFirstname + " " + cLastname
        Select Case Me.hid_PaymentType.Text
            Case 1     '-- CreditCard
                If bSuccess Then
                    bError = oSetStatus.set_status(oPayment.order_id, 5)
                Else
                    bError = oSetStatus.set_status(oPayment.order_id, 2)
                End If
            Case 2
                bError = oSetStatus.set_status(oPayment.order_id, 3)
            Case 3
                bError = oSetStatus.set_status(oPayment.order_id, 3)
        End Select
        oSetStatus = Nothing

        '--- Catch the error and send message
        If bError Then
            bError = False
            Session("message").listbox.items.add("- Cannot set status for this order, please do so manualy!")
            Session("message").returnpath = "/default.aspx"
            Server.Transfer("/message.aspx")
        End If



        Return False
        Exit Function

ErrorHandler:
        '--- when object is called in external DLL
        Session("error").err_number = Err.Number
        Session("error").err_source = Err.Source
        Session("error").err_description = Err.Description
        '--- Custom error
        Dim oTmpErrDB As New System.Diagnostics.StackFrame
        Session("error").app_module = Me.Request.CurrentExecutionFilePath
        Session("error").app_function = oTmpErrDB.GetMethod.Name
        Session("error").app_call = "make_payment / order_payments"
        Return True

    End Function

    Private Function zeropayment(ByVal oPayment As ion_resources.cls_payment) As Boolean
        oPayment.payment_type = 0
        oPayment.payment_date = #1/1/1900#
        oPayment.order_id = 0
        oPayment.user_id = 0
        oPayment.approved = False
        oPayment.approved_date = #1/1/1900#
        oPayment.amount_total = 0
        oPayment.amount_interest = 0
        oPayment.cc_type_id = 0
        oPayment.cc_name = ""
        oPayment.cc_number = ""
        oPayment.cc_cvv = ""
        oPayment.cc_exp_year = ""
        oPayment.cc_exp_month = ""
        oPayment.cc_user_ssn = ""
        oPayment.cc_confermation = ""
        oPayment.cc_clubmember = False
        oPayment.cc_cleared = False
        oPayment.cc_batch = ""
        oPayment.mt_bank = ""
        oPayment.mt_account = ""
        oPayment.mt_name = ""
        oPayment.mt_code = ""
        oPayment.cq_bank = ""
        oPayment.cq_name = ""
        oPayment.cq_account = ""
        oPayment.cq_date = #1/1/1900#
        oPayment.notes = ""

    End Function

    Private Sub chk_payment_cc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_payment_cc.CheckedChanged
        Dim bError As Boolean = False
        bError = set_payment_cc()

    End Sub


    Private Sub chk_payment_wire_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_payment_wire.CheckedChanged
        Dim bError As Boolean = False
        bError = set_payment_mt()

    End Sub


    Private Sub chk_payment_check_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_payment_check.CheckedChanged
        Dim bError As Boolean = False
        bError = set_payment_cq()

    End Sub

    '############################################################################################
    Public Function set_payment_cc() As Boolean

        '--- Set payment type
        Me.hid_PaymentType.Text = 1

        '--- Set Checkbox Status
        chk_payment_cc.Checked = True
        chk_payment_cc.Enabled = False
        chk_payment_wire.Checked = False
        chk_payment_wire.Enabled = True
        chk_payment_check.Checked = False
        chk_payment_check.Enabled = True

        '--- Enable validators
        Me.vld_cc_cardnumber.Enabled = True
        Me.vld_cc_nameoncard.Enabled = True

        '--- Disable date validator
        Me.vld_cq_date2.Enabled = False

        '--- Enable CC payments
        Me.cmb_cc_cardtype.Enabled = True
        Me.cmb_cc_month.Enabled = True
        Me.cmb_cc_year.Enabled = True
        Me.txt_cc_cardnumber.Enabled = True
        Me.txt_cc_cvv.Enabled = True
        Me.txt_cc_nameoncard.Enabled = True
        Me.txt_cc_person_id.Enabled = True

        '--- disable rest
        Me.txt_cq_account.Enabled = False
        Me.txt_cq_bank.Enabled = False
        Me.txt_cq_date.Enabled = False
        Me.txt_cq_name.Enabled = False
        Me.txt_mt_account.Enabled = False
        Me.txt_mt_bank.Enabled = False
        Me.txt_mt_code.Enabled = False
        Me.txt_mt_name.Enabled = False

        '--- Empty fields
        Me.txt_mt_account.Text = ""
        Me.txt_mt_bank.Text = ""
        Me.txt_mt_code.Text = ""
        Me.txt_mt_name.Text = ""

        Me.txt_cq_account.Text = ""
        Me.txt_cq_bank.Text = ""
        Me.txt_cq_date.Text = ""
        Me.txt_cq_name.Text = ""

    End Function

    '############################################################################################
    Public Function set_payment_mt() As Boolean
        '--- Set payment type
        Me.hid_PaymentType.Text = 2

        '--- Set Checkbox Status
        chk_payment_cc.Checked = False
        chk_payment_cc.Enabled = True
        chk_payment_wire.Checked = True
        chk_payment_wire.Enabled = False
        chk_payment_check.Checked = False
        chk_payment_check.Enabled = True

        '--- Disable validators
        Me.vld_cc_cardnumber.Enabled = False
        Me.vld_cc_nameoncard.Enabled = False
        Me.vld_cq_date2.Enabled = False

        '--- Disable CC payments
        Me.cmb_cc_cardtype.Enabled = False
        Me.cmb_cc_month.Enabled = False
        Me.cmb_cc_year.Enabled = False
        Me.txt_cc_cardnumber.Enabled = False
        Me.txt_cc_cvv.Enabled = False
        Me.txt_cc_nameoncard.Enabled = False
        Me.txt_cc_person_id.Enabled = False

        Me.txt_cq_account.Enabled = False
        Me.txt_cq_bank.Enabled = False
        Me.txt_cq_date.Enabled = False
        Me.txt_cq_name.Enabled = False

        Me.txt_mt_account.Enabled = True
        Me.txt_mt_bank.Enabled = True
        Me.txt_mt_code.Enabled = True
        Me.txt_mt_name.Enabled = True

        '--- Empty fields
        Me.cmb_cc_cardtype.SelectedIndex = 0
        Me.cmb_cc_month.SelectedIndex = 0
        Me.cmb_cc_year.SelectedIndex = 0
        Me.txt_cc_cardnumber.Text = ""
        Me.txt_cc_nameoncard.Text = ""
        Me.txt_cc_code.Text = ""
        Me.chk_style_member.Enabled = False
        Me.txt_cc_cvv.Text = ""
        Me.txt_cc_person_id.Text = ""

        Me.txt_cq_account.Text = ""
        Me.txt_cq_bank.Text = ""
        Me.txt_cq_date.Text = ""
        Me.txt_cq_name.Text = ""

    End Function

    '############################################################################################
    Public Function set_payment_cq() As Boolean
        '--- Set payment type
        Me.hid_PaymentType.Text = 3

        '--- Set Checkbox Status
        chk_payment_cc.Checked = False
        chk_payment_cc.Enabled = True
        chk_payment_wire.Checked = False
        chk_payment_wire.Enabled = True
        chk_payment_check.Checked = True
        chk_payment_check.Enabled = False

        '--- Disable validators
        Me.vld_cc_cardnumber.Enabled = False
        Me.vld_cc_nameoncard.Enabled = False

        '--- Enable date validator
        Me.vld_cq_date2.Enabled = True

        '--- Disable CC payments
        Me.cmb_cc_cardtype.Enabled = False
        Me.cmb_cc_month.Enabled = False
        Me.cmb_cc_year.Enabled = False
        Me.txt_cc_cardnumber.Enabled = False
        Me.txt_cc_cvv.Enabled = False
        Me.txt_cc_nameoncard.Enabled = False
        Me.txt_cc_person_id.Enabled = False

        Me.txt_cq_account.Enabled = True
        Me.txt_cq_bank.Enabled = True
        Me.txt_cq_date.Enabled = True
        Me.txt_cq_name.Enabled = True

        Me.txt_mt_account.Enabled = False
        Me.txt_mt_bank.Enabled = False
        Me.txt_mt_code.Enabled = False
        Me.txt_mt_name.Enabled = False

        '--- Empty fields
        Me.cmb_cc_cardtype.SelectedIndex = 0
        Me.cmb_cc_month.SelectedIndex = 0
        Me.cmb_cc_year.SelectedIndex = 0
        Me.txt_cc_cardnumber.Text = ""
        Me.txt_cc_nameoncard.Text = ""
        Me.txt_cc_code.Text = ""
        Me.chk_style_member.Enabled = False
        Me.txt_cc_cvv.Text = ""
        Me.txt_cc_person_id.Text = ""

        Me.txt_mt_account.Text = ""
        Me.txt_mt_bank.Text = ""
        Me.txt_mt_code.Text = ""
        Me.txt_mt_name.Text = ""

    End Function


    '############################################################################################
    Public Function disableall() As Boolean
        Me.txt_cc_cardnumber.Enabled = False
        Me.txt_cc_cvv.Enabled = False
        Me.txt_cc_nameoncard.Enabled = False
        Me.txt_cc_person_id.Enabled = False
        Me.cmb_cc_cardtype.Enabled = False
        Me.cmb_cc_month.Enabled = False
        Me.cmb_cc_year.Enabled = False
        Me.txt_cc_code.Enabled = False
        Me.chk_style_member.Enabled = False
        Me.chk_payment_cc.Enabled = False
        Me.chk_payment_check.Enabled = False
        Me.chk_payment_wire.Enabled = False
        Me.txt_cq_account.Enabled = False
        Me.txt_cq_bank.Enabled = False
        Me.txt_cq_date.Enabled = False
        Me.txt_cq_name.Enabled = False
        Me.txt_mt_account.Enabled = False
        Me.txt_mt_bank.Enabled = False
        Me.txt_mt_code.Enabled = False
        Me.txt_mt_name.Enabled = False

    End Function

    '############################################################################################
    Public Function get_master_card_info(ByVal nOrder_id As Int32) As Boolean
        'On Error GoTo ErrorHandler
        Dim bError As Boolean = False


        Dim oTmpFunction As New ion_resources.cls_functions_payment
        oTmpFunction.connection_string = Application("config").connection_string
        Dim nCardType As Int32
        Dim cMonth As String
        Dim cYear As String
        Dim bClubMember As Boolean
        oTmpFunction.get_master_cardinfo(nOrder_id, nCardType, Me.txt_cc_nameoncard.Text, Me.txt_cc_cardnumber.Text, Me.txt_cc_cvv.Text, cYear, cMonth, Me.txt_cc_person_id.Text, Me.txt_cc_code.Text, bClubMember)
        oTmpFunction = Nothing


        If nCardType <> 0 Then
            Me.cmb_cc_cardtype.SelectedIndex = GetComboValue(Me.cmb_cc_cardtype, nCardType)
        End If

        If cMonth.Trim <> "" Then
            Me.cmb_cc_month.SelectedIndex = GetComboValue(Me.cmb_cc_month, cMonth)
        End If

        If cYear.Trim <> "" Then
            Me.cmb_cc_year.SelectedIndex = GetComboValue(Me.cmb_cc_year, cYear)
        End If


        Return False
        Exit Function

ErrorHandler:
        '--- when object is called in external DLL
        Session("error").err_number = Err.Number
        Session("error").err_source = Err.Source
        Session("error").err_description = Err.Description
        '--- Custom error
        Dim oTmpErrDB As New System.Diagnostics.StackFrame
        Session("error").app_module = Me.Request.CurrentExecutionFilePath
        Session("error").app_function = oTmpErrDB.GetMethod.Name
        Session("error").app_call = "get_master_card_info / wc_get_payment"
        Return True

    End Function

    '############################################################################################
    Private Function calc_interest(ByVal nOrder_id As Int32, ByVal nAmount As Decimal, ByRef nInterest As Decimal) As Boolean
        'On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- Get Interest param. from order
        Dim oTmpFuntion As New ion_resources.cls_functions_order
        oTmpFuntion.connection_string = Application("config").connection_string
        Dim nInterestRate As Decimal
        Dim dInterestStartDate As Date
        bError = oTmpFuntion.get_interest(nOrder_id, nInterestRate, dInterestStartDate)

        '--- Add interest
        Dim oTmpInterest As New ion_resources.cls_interest
        oTmpInterest.start_date = dInterestStartDate
        oTmpInterest.end_date = Date.Today
        oTmpInterest.start_amount = nAmount
        oTmpInterest.interest = nInterestRate
        bError = oTmpInterest.calc()

        '--- Set new ORDER TOTAL
        'oTmpInterest.end_amount

        '--- Show Interest amount
        nInterest = oTmpInterest.amount_intrest

        '--- Set new LEFT TO PAY
        'oTmpInterest.end_amount


        oTmpInterest = Nothing
        oTmpFuntion = Nothing
        'oTmpCalcPay = Nothing
        Exit Function

ErrorHandler:
        '--- when object is called in external DLL
        Session("error").err_number = Err.Number
        Session("error").err_source = Err.Source
        Session("error").err_description = Err.Description
        '--- Custom error
        Dim oTmpErrDB As New System.Diagnostics.StackFrame
        Session("error").app_module = Me.Request.CurrentExecutionFilePath
        Session("error").app_function = oTmpErrDB.GetMethod.Name
        Session("error").app_call = "calc_interest"
        Server.Transfer("/apperror.aspx")

    End Function


End Class
