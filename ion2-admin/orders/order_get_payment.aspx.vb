Imports System.Data.SqlClient

Partial Class order_get_payment
    Inherits System.Web.UI.Page


    Public oConnection As SqlClient.SqlConnection = New SqlClient.SqlConnection()
    Public oDataAdapter1 As SqlDataAdapter = New SqlDataAdapter()
    Public oSQLcmd1 As SqlCommand = New SqlCommand("", oConnection)

    Public cnt_Payments As wc_get_payments
    Public nOrder_id As Int32
    Public nUser_id As Int32
    Public nTotal_To_Pay As Decimal


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- Set culture of form
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(Request.UserLanguages(0))
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(Request.UserLanguages(0))

        Dim nOrder_id As Int32 = Request.QueryString("id")
        Dim nOrder_Number As Int32
        Dim nOrder_Total_Payed As Decimal

        '--- Map WebControl
        cnt_Payments = Me.FindControl("wc_get_payments1")
        cnt_Payments.nOrder_id = nOrder_id

        If Not Page.IsPostBack Then
            '--- Get order payments
            Dim oTmpCalcPay As New ion_resources.cls_payment_calc()
            oTmpCalcPay.connection_string = Application("config").connection_string
            bError = oTmpCalcPay.calc_order(nOrder_id)
            Me.hid_total_order.Text = oTmpCalcPay.order_total

            '--- write caption of window
            Me.lbl_caption.Text = Me.lbl_caption.Text + Space(2) + System.Convert.ToString(oTmpCalcPay.order_number)

            '--- map userid to its hid_
            Me.hid_userid.Text = oTmpCalcPay.user_id
            Me.hid_orderid.Text = nOrder_id

            '--- map results
            If Convert.ToDecimal(oTmpCalcPay.payment_type) > 0 Then
                Me.lbl_master_label.Text = oTmpCalcPay.payment_name
            Else
                Me.lbl_master_label.Text = "No Initial payment"
            End If

            '--- Show Order values
            Me.lbl_master_amount.Text = Format(oTmpCalcPay.order_initial_payment, "##,##0.00") + " $us"
            Me.lbl_order_total.Text = Format(Convert.ToDecimal(Me.hid_total_order.Text), "##,##0.00") + " $us"
            Me.lbl_interest.Text = Format(oTmpCalcPay.order_interest, "##,##0.00") + " $us"
            Me.lbl_total_payed.Text = Format(oTmpCalcPay.order_total_payed, "##,##0.00") + " $us"

            cnt_Payments.hid_payment.Text = oTmpCalcPay.order_total_left_to_pay
            cnt_Payments.hid_interest.Text = oTmpCalcPay.order_interest
            'cnt_Payments.hid_PaymentType.Text = oTmpCalcPay.payment_type

            '--- Check Left to pay
            nTotal_To_Pay = oTmpCalcPay.order_initial_payment - oTmpCalcPay.order_total_payed
            If nTotal_To_Pay > 0 Then
                Me.txt_lefttopay.Text = Format(nTotal_To_Pay, "##,##0.00")
                Me.vld_lefttopay.MaximumValue = Format(nTotal_To_Pay, "##,##0.00")
                Me.vld_lefttopay.MinimumValue = 0

                '--- Disable other types of payments
                Select Case oTmpCalcPay.payment_type
                    Case 1
                        cnt_Payments.set_payment_cc()
                        cnt_Payments.chk_payment_cc.Enabled = True
                        cnt_Payments.chk_payment_check.Enabled = False
                        cnt_Payments.chk_payment_wire.Enabled = False
                        cnt_Payments.vld_cq_date2.Enabled = False

                    Case 2
                        cnt_Payments.set_payment_mt()

                    Case 3
                        cnt_Payments.set_payment_cq()

                End Select

                '--- Get Authtentication code for master payments
                bError = cnt_Payments.get_master_card_info(nOrder_id)

                Me.chk_calcinterest.Enabled = False

            Else
                '--- If initial payment already payed
                Me.txt_lefttopay.Text = Format(oTmpCalcPay.order_total_left_to_pay, "##,##0.00")
                Me.vld_lefttopay.MaximumValue = oTmpCalcPay.order_total_left_to_pay.Round(oTmpCalcPay.order_total_left_to_pay, 2)
                Me.vld_lefttopay.MinimumValue = 0
                Me.chk_calcinterest.Enabled = True

            End If


            '--- Check if nothing more to pay
            If oTmpCalcPay.order_total_left_to_pay = 0 Then
                bError = disableall()
            End If

            '--- Check if there is a reason to disable screen
            Dim oTmpFunctionOrder As New ion_resources.cls_functions_order()
            oTmpFunctionOrder.connection_string = Application("config").connection_string
            Dim bOrderReadOnly As Boolean
            Dim bOrderTranacted As Boolean

            bError = oTmpFunctionOrder.get_order_readonly(nOrder_id, bOrderReadOnly)
            If bOrderReadOnly Then
                bError = disableall()
            End If

            bError = oTmpFunctionOrder.get_order_transact(nOrder_id, bOrderTranacted)
            If bOrderTranacted Then
                bError = disableall()
            End If

            oTmpFunctionOrder = Nothing
            oTmpCalcPay = Nothing
        End If

        '--- Fill var on every refresh, hold this for the validate
        nTotal_To_Pay = Me.txt_lefttopay.Text


        '--- Populate grid
        oConnection.ConnectionString = Application("config").connection_string
        oDataAdapter1.TableMappings.Add("Table", "v_cashflow_customer")

        oSQLcmd1.CommandText = "select * from v_cashflow_customer where master = 0 and order_id = " + System.Convert.ToString(nOrder_id) + " order by payment_date "
        oSQLcmd1.CommandType = CommandType.Text
        oDataAdapter1.SelectCommand = oSQLcmd1

        Dim oDs As DataSet
        oDs = New DataSet("cashflow")

        oConnection.Open()
        oDataAdapter1.Fill(oDs)

        grd_cashstatus.DataSource = oDs
        grd_cashstatus.DataMember = "v_cashflow_customer"
        grd_cashstatus.DataBind()

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
        Session("error").app_call = "page_load"
        Server.Transfer("/apperror.aspx")

    End Sub


    '############################################################################################
    Private Sub btn_submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_submit.Click
        'On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Dim bSuccess As Boolean = True

        '--- Make sure payment > 0
        If Me.txt_lefttopay.Text < 0 Then
            Me.lst_error.Items.Add("- Amount cannot be ZERO !")
            bSuccess = False
        End If

        '--- Make sure payment is not higher then needed
        If Me.txt_lefttopay.Text > nTotal_To_Pay Then
            Me.lst_error.Items.Add("- Amount cannot be more then the amount left to pay !")
            bSuccess = False
        End If

        '--- Validate control
        bError = cnt_Payments.validate(Me.lst_error, bSuccess)
        If Not bSuccess Then
            Me.lst_error.Visible = True
            Exit Sub

        Else
            Me.lst_error.Visible = False

            '--- disable all controls on page
            bError = disableall()

            Dim bSaveOK As Boolean = False
            Dim nCreditMode As Int16 = 1

            cnt_Payments.nOrder_id = Me.hid_orderid.Text
            cnt_Payments.nUser_id = Me.hid_userid.Text
            cnt_Payments.hid_payment.Text = Me.txt_lefttopay.Text
            'cnt_Payments.hid_interest.Text = Me.lbl_interest.Text
            bError = cnt_Payments.make_payment(bSaveOK, nCreditMode, Me.chk_calcinterest.Checked)

            '--- If payments made are higher then initial pay then approve master
            Dim bApproved As Boolean = False

            '--- Get order payments
            Dim oTmpCalcPay2 As New ion_resources.cls_payment_calc()
            oTmpCalcPay2.connection_string = Application("config").connection_string
            bError = oTmpCalcPay2.calc_order(cnt_Payments.nOrder_id)

            If oTmpCalcPay2.order_initial_payment <= oTmpCalcPay2.order_total_payed Then
                Dim oTmpFunctions As New ion_resources.cls_functions_order()
                oTmpFunctions.connection_string = Application("config").connection_string
                bError = oTmpFunctions.set_approved(cnt_Payments.nOrder_id)
                oTmpFunctions = Nothing
            End If
            oTmpCalcPay2 = Nothing

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
        Session("error").app_call = "btn_submit_click"
        Server.Transfer("/apperror.aspx")

    End Sub

    '############################################################################################
    Private Function disableall()
        Dim bError As Boolean = False

        Me.txt_lefttopay.Enabled = False
        Me.btn_submit.Enabled = False
        Me.chk_calcinterest.Enabled = False
        bError = cnt_Payments.disableall

    End Function

    '############################################################################################
    Private Sub grd_cashstatus_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grd_cashstatus.PageIndexChanged
        grd_cashstatus.CurrentPageIndex = e.NewPageIndex
        grd_cashstatus.DataBind()
    End Sub


    '############################################################################################
    Function calc_interest(ByVal oTmpCalcPay As ion_resources.cls_payment_calc, ByRef bCalulated As Boolean, ByRef nInterest As Decimal, ByRef nLeftToPay As Decimal) As Boolean
        'On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- Get Interest param. from order
        Dim oTmpFuntion As New ion_resources.cls_functions_order()
        oTmpFuntion.connection_string = Application("config").connection_string
        Dim nInterestRate As Decimal
        Dim dInterestStartDate As Date
        bError = oTmpFuntion.get_interest(cnt_Payments.nOrder_id, nInterestRate, dInterestStartDate)

        '--- Add interest
        Dim oTmpInterest As New ion_resources.cls_interest()
        oTmpInterest.start_date = dInterestStartDate
        oTmpInterest.end_date = Date.Today
        oTmpInterest.start_amount = Convert.ToDecimal(Me.hid_total_order.Text)
        oTmpInterest.interest = nInterestRate
        bError = oTmpInterest.calc()

        'nOrdr_total = oTmpInterest.end_amount
        nInterest = oTmpInterest.amount_intrest
        nLeftToPay = oTmpInterest.end_amount - oTmpCalcPay.order_total_payed

        bCalulated = oTmpInterest.calculated

        oTmpInterest = Nothing
        oTmpFuntion = Nothing


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
        Session("error").app_call = "calc_interest"
        Server.Transfer("/apperror.aspx")
        Return True

    End Function



    '############################################################################################
    Private Sub chk_calcinterest_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_calcinterest.CheckedChanged
        'On Error GoTo ErrorHandler
        Dim bError As Boolean = False


        '--- Get order payments
        Dim oTmpCalcPay As New ion_resources.cls_payment_calc()
        oTmpCalcPay.connection_string = Application("config").connection_string
        bError = oTmpCalcPay.calc_order(cnt_Payments.nOrder_id)

        If Me.chk_calcinterest.Checked Then

            '--- Set new ORDER TOTAL
            Me.lbl_order_total.Text = Format(oTmpCalcPay.order_total, "##,##0.00") + " $us"

            '--- Set new LEFT TO PAY
            Me.txt_lefttopay.Text = Format(oTmpCalcPay.order_total_left_to_pay, "##,##0.00")

            '--- Set Interest
            Me.lbl_interest.Text = Format(oTmpCalcPay.order_interest, "##,##0.00") + " $us"


        Else
            '--- Set old ORDER TOTAL back
            Me.lbl_order_total.Text = Format(Convert.ToDecimal(Me.hid_total_order.Text), "##,##0.00") + " $us"

            '--- Set old LEFT TO PAY back
            Me.txt_lefttopay.Text = Format(oTmpCalcPay.order_left_to_pay, "##,##0.00")

            Me.lbl_interest.Text = Format(0, "##,##0.00") + " $us"

        End If


        oTmpCalcPay = Nothing


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
        Session("error").app_call = "chk_calc_interest_checkedChanged"
        Server.Transfer("/apperror.aspx")

    End Sub
End Class
