Partial Class wc_order_status
    Inherits System.Web.UI.UserControl

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

    Public nOrderId As Int32

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- Set culture of form
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(Request.UserLanguages(0))
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(Request.UserLanguages(0))

        Me.tbl_YesNo.Visible = False

        '--- Get/Set Parameters
        nOrderId = Request.QueryString("id")

        '--- Load Order
        Dim oOrder As New ion_resources.cls_order
        Dim oTmpOrder As New ion_resources.cls_order_lgc()
        oTmpOrder.connection_string = Application("config").connection_string
        bError = oTmpOrder.get_order_by_id(nOrderId, oOrder)
        If bError Then
            '--- when object is called in external DLL
            Session("error").err_number = oTmpOrder.error_no
            Session("error").err_source = oTmpOrder.error_source
            Session("error").err_description = oTmpOrder.error_desc
            '--- Custom error
            Dim oTmpErrDB2 As New System.Diagnostics.StackFrame()
            Session("error").app_module = Me.Request.CurrentExecutionFilePath
            Session("error").app_function = oTmpErrDB2.GetMethod.Name
            Session("error").app_call = "Load Order"
            Server.Transfer("/apperror.aspx")
        End If


        If Not Page.IsPostBack Then
            If IsNumeric(nOrderId) Then
                If nOrderId > 0 Then
                    bError = Map_Order(oOrder)
                    If bError Then
                        Session("error").err_number = Err.Number
                        Session("error").err_source = Err.Source
                        Session("error").err_description = Err.Description
                        Session("error").app_module = Me.Request.CurrentExecutionFilePath
                        Session("error").app_call = "Page_Load [Map_Order]"
                        Server.Transfer("/apperror.aspx")
                    End If

                    bError = set_currentstatus(oOrder)
                    If bError Then
                        Session("error").err_number = Err.Number
                        Session("error").err_source = Err.Source
                        Session("error").err_description = Err.Description
                        Session("error").app_module = Me.Request.CurrentExecutionFilePath
                        Session("error").app_call = "Page_Load [set_currentstatus]"
                        Server.Transfer("/apperror.aspx")
                    End If

                End If
            End If
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
        Session("error").app_call = "Page_Load"
        Server.Transfer("/apperror.aspx")

    End Sub

    Private Function Map_Order(ByRef oOrder As ion_resources.cls_order) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- Header
        Me.lbl_header.Text = Me.lbl_header.Text + " - " + System.Convert.ToString(oOrder.ordernumber) + " - Invoice - " + System.Convert.ToString(oOrder.invoice_number)

        '--- Populate screen
        Me.chk_stat_1.Checked = oOrder.sts_new_order_received
        If oOrder.sts_new_order_received_date <> #1/1/1900# Then
            Me.lbl_date_sts_1.Text = oOrder.sts_new_order_received_date
        End If

        Me.chk_stat_2.Checked = oOrder.sts_waiting_for_authorization
        If oOrder.sts_waiting_for_authorization_date <> #1/1/1900# Then
            Me.lbl_date_sts_2.Text = oOrder.sts_waiting_for_authorization_date
        End If
        Me.txt_note_sts_2.Text = oOrder.sts_waiting_for_authorization_note


        Me.chk_stat_3.Checked = oOrder.sts_waiting_for_payment
        If oOrder.sts_waiting_for_payment_date <> #1/1/1900# Then
            Me.lbl_date_sts_3.Text = oOrder.sts_waiting_for_payment_date
        End If
        Me.txt_note_sts_3.Text = oOrder.sts_waiting_for_payment_note


        Me.chk_stat_4.Checked = oOrder.sts_order_confirmed
        If oOrder.sts_order_confirmed_date <> #1/1/1900# Then
            Me.lbl_date_sts_4.Text = oOrder.sts_order_confirmed_date
        End If
        Me.txt_note_sts_4.Text = oOrder.sts_order_confirmed_note


        Me.chk_stat_5.Checked = oOrder.sts_partial_order_confirmed
        If oOrder.sts_partial_order_confirmed_date <> #1/1/1900# Then
            Me.lbl_date_sts_5.Text = oOrder.sts_partial_order_confirmed_date
        End If
        Me.txt_note_sts_5.Text = oOrder.sts_partial_order_confirmed_note


        Me.chk_stat_6.Checked = oOrder.sts_order_failed
        If oOrder.sts_order_failed_date <> #1/1/1900# Then
            Me.lbl_date_sts_6.Text = oOrder.sts_order_failed_date
        End If
        Me.txt_note_sts_6.Text = oOrder.sts_order_failed_note


        Me.chk_stat_7.Checked = oOrder.sts_order_waiting_to_be_send
        If oOrder.sts_order_waiting_to_be_send_date <> #1/1/1900# Then
            Me.lbl_date_sts_7.Text = oOrder.sts_order_waiting_to_be_send_date
        End If
        Me.txt_note_sts_7.Text = oOrder.sts_order_waiting_to_be_send_note


        Me.chk_stat_8.Checked = oOrder.sts_order_send
        If oOrder.sts_order_send_date <> #1/1/1900# Then
            Me.lbl_date_sts_8.Text = oOrder.sts_order_send_date
        End If
        Me.txt_note_sts_8.Text = oOrder.sts_order_send_note
        Me.txt_trackingno.Text = oOrder.shipping_tracking_no


        Me.chk_stat_9.Checked = oOrder.sts_partial_order_send
        If oOrder.sts_partial_order_send_date <> #1/1/1900# Then
            Me.lbl_date_sts_9.Text = oOrder.sts_partial_order_send_date
        End If
        Me.txt_note_sts_9.Text = oOrder.sts_partial_order_send_note


        Me.chk_stat_10.Checked = oOrder.sts_order_received_by_customer
        If oOrder.sts_order_received_by_customer_date <> #1/1/1900# Then
            Me.lbl_date_sts_10.Text = oOrder.sts_order_received_by_customer_date
        End If
        Me.txt_note_sts_10.Text = oOrder.sts_order_received_by_customer_note

        Me.chk_stat_11.Checked = oOrder.sts_partial_order_received_by_customer
        If oOrder.sts_partial_order_received_by_customer_date <> #1/1/1900# Then
            Me.lbl_date_sts_11.Text = oOrder.sts_partial_order_received_by_customer_date
        End If
        Me.txt_note_sts_11.Text = oOrder.sts_partial_order_received_by_customer_note

        Me.chk_stat_12.Checked = oOrder.sts_customer_returning_order
        If oOrder.sts_customer_returning_order_date <> #1/1/1900# Then
            Me.lbl_date_sts_12.Text = oOrder.sts_customer_returning_order_date
        End If
        Me.txt_note_sts_12.Text = oOrder.sts_customer_returning_order_note


        Me.chk_stat_13.Checked = oOrder.sts_customer_returning_part_order
        If oOrder.sts_customer_returning_part_order_date <> #1/1/1900# Then
            Me.lbl_date_sts_13.Text = oOrder.sts_customer_returning_part_order_date
        End If
        Me.txt_note_sts_13.Text = oOrder.sts_customer_returning_part_order_note


        Me.chk_stat_14.Checked = oOrder.sts_customer_refunded
        If oOrder.sts_customer_refunded_date <> #1/1/1900# Then
            Me.lbl_date_sts_14.Text = oOrder.sts_customer_refunded_date
        End If
        Me.txt_note_sts_14.Text = oOrder.sts_customer_refunded_note


        Me.chk_stat_15.Checked = oOrder.sts_customer_partly_refunded
        If oOrder.sts_customer_partly_refunded_date <> #1/1/1900# Then
            Me.lbl_date_sts_15.Text = oOrder.sts_customer_partly_refunded_date
        End If
        Me.txt_note_sts_15.Text = oOrder.sts_customer_partly_refunded_note


        Me.chk_stat_16.Checked = oOrder.sts_order_closed
        If oOrder.sts_order_closed_date <> #1/1/1900# Then
            Me.lbl_date_sts_16.Text = oOrder.sts_order_closed_date
        End If
        Me.txt_note_sts_16.Text = oOrder.sts_order_closed_note


        Me.chk_stat_17.Checked = oOrder.sts_order_cancelled
        If oOrder.sts_order_cancelled_date <> #1/1/1900# Then
            Me.lbl_date_sts_17.Text = oOrder.sts_order_cancelled_date
        End If
        Me.txt_note_sts_17.Text = oOrder.sts_order_cancelled_note

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
        Session("error").app_call = "Page_Load"
        Server.Transfer("/apperror.aspx")

    End Function


    Function set_currentstatus(ByRef oOrder As ion_resources.cls_order) As Boolean
        '--- Show the current status on screen

        Dim bError As Boolean = False
        Dim bSave As Boolean = False

        If oOrder.sts_new_order_received Then         '-- 1
            bError = set_sts_1()
        End If

        If oOrder.sts_waiting_for_authorization Then          '-- 2
            bError = set_sts_2(bSave)
        End If

        If oOrder.sts_waiting_for_payment Then        '-- 3
            bError = set_sts_3(bSave)
        End If

        If oOrder.sts_partial_order_confirmed Then        '-- 5
            bError = set_sts_5(bSave)
        End If

        If oOrder.sts_order_confirmed Then        '-- 4
            bError = set_sts_4(bSave)
        End If

        If oOrder.sts_order_failed Then       '-- 6
            bError = set_sts_6(bSave)
        End If

        If oOrder.sts_order_waiting_to_be_send Then       '-- 7
            bError = set_sts_7(bSave)
        End If

        If oOrder.sts_partial_order_send Then         '-- 9
            bError = set_sts_9(bSave)
        End If

        If oOrder.sts_order_send Then         '-- 8
            bError = set_sts_8(bSave)
        End If

        If oOrder.sts_partial_order_received_by_customer Then         '-- 11
            bError = set_sts_11(bSave)
        End If

        If oOrder.sts_order_received_by_customer Then         '-- 10
            bError = set_sts_10(bSave)
        End If

        If oOrder.sts_customer_returning_part_order Then        '-- 13
            bError = set_sts_13(bSave)
        End If

        If oOrder.sts_customer_returning_order Then       '-- 12
            bError = set_sts_12(bSave)
        End If

        If oOrder.sts_customer_partly_refunded Then       '-- 15
            bError = set_sts_15(bSave)
        End If

        If oOrder.sts_customer_refunded Then          '-- 14
            bError = set_sts_14(bSave)
        End If

        If oOrder.sts_order_closed Then       '-- 16
            bError = set_sts_16(bSave)
        End If

        If oOrder.sts_order_cancelled Then        '-- 17
            bError = set_sts_17(bSave)
        End If

    End Function

    Private Sub chk_stat_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_stat_1.CheckedChanged
        Dim bError As Boolean = False

        If Me.chk_stat_1.Checked Then
            Me.hid_SettingStat.Text = 1
            bError = ask_yesno()
        End If

    End Sub

    Private Sub chk_stat_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_stat_2.CheckedChanged
        Dim bError As Boolean = False

        If Me.chk_stat_2.Checked Then
            Me.hid_SettingStat.Text = 2
            Me.lbl_yn_question.Text = "'Waiting for authorization'"
            bError = ask_yesno()
        End If

    End Sub

    Private Sub chk_stat_3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_stat_3.CheckedChanged
        Dim bError As Boolean = False

        If Me.chk_stat_3.Checked Then
            Me.hid_SettingStat.Text = 3
            Me.lbl_yn_question.Text = "'Waiting for payment'"
            bError = ask_yesno()
        End If

    End Sub

    Private Sub chk_stat_4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_stat_4.CheckedChanged
        Dim bError As Boolean = False

        If Me.chk_stat_4.Checked Then
            Me.hid_SettingStat.Text = 4
            Me.lbl_yn_question.Text = "'Order confirmed'"
            bError = ask_yesno()
        End If

    End Sub

    Private Sub chk_stat_5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_stat_5.CheckedChanged
        Dim bError As Boolean = False

        If Me.chk_stat_5.Checked Then
            Me.hid_SettingStat.Text = 5
            Me.lbl_yn_question.Text = "'Partial orde confirmed'"
            bError = ask_yesno()
        End If

    End Sub

    Private Sub chk_stat_6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_stat_6.CheckedChanged
        Dim bError As Boolean = False

        If Me.chk_stat_6.Checked Then
            Me.hid_SettingStat.Text = 6
            Me.lbl_yn_question.Text = "'Order failed'"
            bError = ask_yesno()
        End If

    End Sub

    Private Sub chk_stat_7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_stat_7.CheckedChanged
        Dim bError As Boolean = False

        If Me.chk_stat_7.Checked Then
            Me.hid_SettingStat.Text = 7
            Me.lbl_yn_question.Text = "'Order waiting to be send'"
            bError = ask_yesno()
        End If

    End Sub

    Private Sub chk_stat_8_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_stat_8.CheckedChanged
        Dim bError As Boolean = False

        If Me.chk_stat_8.Checked Then
            Me.hid_SettingStat.Text = 8
            Me.lbl_yn_question.Text = "'Order send'"
            bError = ask_yesno()
        End If

    End Sub

    Private Sub chk_stat_9_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_stat_9.CheckedChanged
        Dim bError As Boolean = False

        If Me.chk_stat_9.Checked Then
            Me.hid_SettingStat.Text = 9
            Me.lbl_yn_question.Text = "'Partial order send'"
            bError = ask_yesno()
        End If

    End Sub

    Private Sub chk_stat_10_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_stat_10.CheckedChanged
        Dim bError As Boolean = False

        If Me.chk_stat_10.Checked Then
            Me.hid_SettingStat.Text = 10
            Me.lbl_yn_question.Text = "'Order received by customer'"
            bError = ask_yesno()
        End If

    End Sub

    Private Sub chk_stat_11_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_stat_11.CheckedChanged
        Dim bError As Boolean = False

        If Me.chk_stat_11.Checked Then
            Me.hid_SettingStat.Text = 11
            Me.lbl_yn_question.Text = "'Partial order received by customer'"
            bError = ask_yesno()
        End If

    End Sub

    Private Sub chk_stat_12_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_stat_12.CheckedChanged
        Dim bError As Boolean = False

        If Me.chk_stat_12.Checked Then
            Me.hid_SettingStat.Text = 12
            Me.lbl_yn_question.Text = "'Customer returning order'"
            bError = ask_yesno()
        End If

    End Sub

    Private Sub chk_stat_13_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_stat_13.CheckedChanged
        Dim bError As Boolean = False

        If Me.chk_stat_13.Checked Then
            Me.hid_SettingStat.Text = 13
            Me.lbl_yn_question.Text = "'Customer returning part of order'"
            bError = ask_yesno()
        End If

    End Sub

    Private Sub chk_stat_14_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_stat_14.CheckedChanged
        Dim bError As Boolean = False

        If Me.chk_stat_14.Checked Then
            Me.hid_SettingStat.Text = 14
            Me.lbl_yn_question.Text = "'Customer refunded'"
            bError = ask_yesno()
        End If

    End Sub

    Private Sub chk_stat_15_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_stat_15.CheckedChanged
        Dim bError As Boolean = False

        If Me.chk_stat_15.Checked Then
            Me.hid_SettingStat.Text = 15
            Me.lbl_yn_question.Text = "'Customer partly refunded'"
            bError = ask_yesno()
        End If

    End Sub

    Private Sub chk_stat_16_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_stat_16.CheckedChanged
        Dim bError As Boolean = False

        If Me.chk_stat_16.Checked Then
            Me.hid_SettingStat.Text = 16
            Me.lbl_yn_question.Text = "'Order closed'"
            bError = ask_yesno()
        End If

    End Sub

    Private Sub chk_stat_17_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_stat_17.CheckedChanged
        Dim bError As Boolean = False

        If Me.chk_stat_17.Checked Then
            Me.hid_SettingStat.Text = 17
            Me.lbl_yn_question.Text = "'Order canelled'"
            bError = ask_yesno()
        End If

    End Sub

    '1######################################################################################
    Private Function set_sts_1() As Boolean
        Dim bError As Boolean = False
        bError = unbold_status()

        Me.lbl_sts_line_1.Font.Bold = True
        Me.lbl_sts_line_1.Font.Italic = True

        Me.chk_stat_1.Enabled = False

        Me.chk_stat_2.Enabled = True
        Me.txt_note_sts_2.Enabled = True

        Me.chk_stat_3.Enabled = True
        Me.txt_note_sts_3.Enabled = True

        Me.chk_stat_4.Enabled = True
        Me.txt_note_sts_4.Enabled = True

        Me.chk_stat_5.Enabled = True
        Me.txt_note_sts_5.Enabled = True

        Me.chk_stat_6.Enabled = True
        Me.txt_note_sts_6.Enabled = True

        Me.chk_stat_7.Enabled = False
        Me.txt_note_sts_7.Enabled = False

        Me.chk_stat_8.Enabled = False
        Me.txt_note_sts_8.Enabled = False
        Me.txt_trackingno.Enabled = False

        Me.chk_stat_9.Enabled = False
        Me.txt_note_sts_9.Enabled = False

        Me.chk_stat_10.Enabled = False
        Me.txt_note_sts_10.Enabled = False

        Me.chk_stat_11.Enabled = False
        Me.txt_note_sts_11.Enabled = False

        Me.chk_stat_12.Enabled = False
        Me.txt_note_sts_12.Enabled = False

        Me.chk_stat_13.Enabled = False
        Me.txt_note_sts_13.Enabled = False

        Me.chk_stat_14.Enabled = False
        Me.txt_note_sts_14.Enabled = False

        Me.chk_stat_15.Enabled = False
        Me.txt_note_sts_15.Enabled = False

        Me.chk_stat_16.Enabled = False
        Me.txt_note_sts_16.Enabled = False

        Me.chk_stat_17.Enabled = True
        Me.txt_note_sts_17.Enabled = True

    End Function

    '2######################################################################################
    Private Function set_sts_2(ByVal bSave As Boolean) As Boolean
        Dim bError As Boolean = False

        bError = unbold_status()

        Me.lbl_sts_line_2.Font.Bold = True
        Me.lbl_sts_line_2.Font.Italic = True

        Me.chk_stat_1.Enabled = False

        Me.chk_stat_2.Enabled = False
        Me.txt_note_sts_2.Enabled = False

        Me.chk_stat_3.Enabled = True
        Me.txt_note_sts_3.Enabled = True

        Me.chk_stat_4.Enabled = True
        Me.txt_note_sts_4.Enabled = True

        Me.chk_stat_5.Enabled = True
        Me.txt_note_sts_5.Enabled = True

        Me.chk_stat_6.Enabled = True
        Me.txt_note_sts_6.Enabled = True

        Me.chk_stat_7.Enabled = False
        Me.txt_note_sts_7.Enabled = False

        Me.chk_stat_8.Enabled = False
        Me.txt_note_sts_8.Enabled = False
        Me.txt_trackingno.Enabled = False

        Me.chk_stat_9.Enabled = False
        Me.txt_note_sts_9.Enabled = False

        Me.chk_stat_10.Enabled = False
        Me.txt_note_sts_10.Enabled = False

        Me.chk_stat_11.Enabled = False
        Me.txt_note_sts_11.Enabled = False

        Me.chk_stat_12.Enabled = False
        Me.txt_note_sts_12.Enabled = False

        Me.chk_stat_13.Enabled = False
        Me.txt_note_sts_13.Enabled = False

        Me.chk_stat_14.Enabled = False
        Me.txt_note_sts_14.Enabled = False

        Me.chk_stat_15.Enabled = False
        Me.txt_note_sts_15.Enabled = False

        Me.chk_stat_16.Enabled = False
        Me.txt_note_sts_16.Enabled = False

        Me.chk_stat_17.Enabled = True
        Me.txt_note_sts_17.Enabled = True

        '--- Save Order
        If bSave Then
            Dim dStatusDate As DateTime
            Dim oStatus As New ion_two.cls_status
            oStatus._connection_string = Application("config").connection_string
            oStatus._dbtype = Application("config").connection_string_type
            oStatus._user_name = Session("user").user_name
            oStatus._user_id = Session("user").user_id
            bError = oStatus.set_status(nOrderId, 2, dStatusDate, Me.txt_note_sts_2.Text)
            If bError Then
                Session("o_error")._Err_Number = oStatus._err_number
                Session("o_error")._Err_Description = oStatus._err_description
                Session("o_error")._Err_Source = oStatus._err_source
                Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
                Session("o_error")._Err_Call = "set_sts_2 [ion_two.cls_status:set_status]"
                Server.Transfer("/aspxerror.aspx")
            End If
            oStatus = Nothing
            '--- Show the date
            Me.lbl_date_sts_2.Text = dStatusDate
        End If

    End Function

    '3######################################################################################
    Private Function set_sts_3(ByVal bSave As Boolean) As Boolean
        Dim bError As Boolean = False
        bError = unbold_status()

        Me.lbl_sts_line_3.Font.Bold = True
        Me.lbl_sts_line_3.Font.Italic = True

        Me.chk_stat_1.Enabled = False

        Me.chk_stat_2.Enabled = False
        Me.txt_note_sts_2.Enabled = False

        Me.chk_stat_3.Enabled = False
        Me.txt_note_sts_3.Enabled = False

        Me.chk_stat_4.Enabled = True
        Me.txt_note_sts_4.Enabled = True

        Me.chk_stat_5.Enabled = True
        Me.txt_note_sts_5.Enabled = True

        Me.chk_stat_6.Enabled = True
        Me.txt_note_sts_6.Enabled = True

        Me.chk_stat_7.Enabled = False
        Me.txt_note_sts_7.Enabled = False

        Me.chk_stat_8.Enabled = False
        Me.txt_note_sts_8.Enabled = False
        Me.txt_trackingno.Enabled = False

        Me.chk_stat_9.Enabled = False
        Me.txt_note_sts_9.Enabled = False

        Me.chk_stat_10.Enabled = False
        Me.txt_note_sts_10.Enabled = False

        Me.chk_stat_11.Enabled = False
        Me.txt_note_sts_11.Enabled = False

        Me.chk_stat_12.Enabled = False
        Me.txt_note_sts_12.Enabled = False

        Me.chk_stat_13.Enabled = False
        Me.txt_note_sts_13.Enabled = False

        Me.chk_stat_14.Enabled = False
        Me.txt_note_sts_14.Enabled = False

        Me.chk_stat_15.Enabled = False
        Me.txt_note_sts_15.Enabled = False

        Me.chk_stat_16.Enabled = False
        Me.txt_note_sts_16.Enabled = False

        Me.chk_stat_17.Enabled = True
        Me.txt_note_sts_17.Enabled = True


        '--- Save Order
        If bSave Then
            Dim dStatusDate As DateTime
            Dim oStatus As New ion_two.cls_status
            oStatus._connection_string = Application("config").connection_string
            oStatus._dbtype = Application("config").connection_string_type
            oStatus._user_name = Session("user").user_name
            oStatus._user_id = Session("user").user_id
            bError = oStatus.set_status(nOrderId, 3, dStatusDate, Me.txt_note_sts_3.Text)
            If bError Then
                Session("o_error")._Err_Number = oStatus._err_number
                Session("o_error")._Err_Description = oStatus._err_description
                Session("o_error")._Err_Source = oStatus._err_source
                Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
                Session("o_error")._Err_Call = "set_sts_3 [ion_two.cls_status:set_status]"
                Server.Transfer("/aspxerror.aspx")
            End If
            oStatus = Nothing
            Me.lbl_date_sts_3.Text = dStatusDate
        End If

    End Function

    '4######################################################################################
    Private Function set_sts_4(ByVal bSave As Boolean) As Boolean
        Dim bError As Boolean = False
        bError = unbold_status()

        Me.lbl_sts_line_4.Font.Bold = True
        Me.lbl_sts_line_4.Font.Italic = True

        Me.chk_stat_1.Enabled = False

        Me.chk_stat_2.Enabled = False
        Me.txt_note_sts_2.Enabled = False

        Me.chk_stat_3.Enabled = False
        Me.txt_note_sts_3.Enabled = False

        Me.chk_stat_4.Enabled = False
        Me.txt_note_sts_4.Enabled = False

        Me.chk_stat_5.Enabled = False
        Me.txt_note_sts_5.Enabled = False

        Me.chk_stat_6.Enabled = False
        Me.txt_note_sts_6.Enabled = False

        Me.chk_stat_7.Enabled = True
        Me.txt_note_sts_7.Enabled = True

        Me.chk_stat_8.Enabled = False
        Me.txt_note_sts_8.Enabled = False
        Me.txt_trackingno.Enabled = False

        Me.chk_stat_9.Enabled = False
        Me.txt_note_sts_9.Enabled = False

        Me.chk_stat_10.Enabled = False
        Me.txt_note_sts_10.Enabled = False

        Me.chk_stat_11.Enabled = False
        Me.txt_note_sts_11.Enabled = False

        Me.chk_stat_12.Enabled = False
        Me.txt_note_sts_12.Enabled = False

        Me.chk_stat_13.Enabled = False
        Me.txt_note_sts_13.Enabled = False

        Me.chk_stat_14.Enabled = False
        Me.txt_note_sts_14.Enabled = False

        Me.chk_stat_15.Enabled = False
        Me.txt_note_sts_15.Enabled = False

        Me.chk_stat_16.Enabled = False
        Me.txt_note_sts_16.Enabled = False

        Me.chk_stat_17.Enabled = True
        Me.txt_note_sts_17.Enabled = True


        '--- Save Order
        If bSave Then
            Dim dStatusDate As DateTime
            Dim oStatus As New ion_two.cls_status
            oStatus._connection_string = Application("config").connection_string
            oStatus._dbtype = Application("config").connection_string_type
            oStatus._user_name = Session("user").user_name
            oStatus._user_id = Session("user").user_id
            bError = oStatus.set_status(nOrderId, 4, dStatusDate, Me.txt_note_sts_4.Text)
            If bError Then
                Session("o_error")._Err_Number = oStatus._err_number
                Session("o_error")._Err_Description = oStatus._err_description
                Session("o_error")._Err_Source = oStatus._err_source
                Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
                Session("o_error")._Err_Call = "set_sts_4 [ion_two.cls_status:set_status]"
                Server.Transfer("/aspxerror.aspx")
            End If
            oStatus = Nothing
            Me.lbl_date_sts_4.Text = dStatusDate
        End If

    End Function

    '5######################################################################################
    Private Function set_sts_5(ByVal bSave As Boolean) As Boolean
        Dim bError As Boolean = False
        bError = unbold_status()

        Me.lbl_sts_line_5.Font.Bold = True
        Me.lbl_sts_line_5.Font.Italic = True

        Me.chk_stat_1.Enabled = False

        Me.chk_stat_2.Enabled = False
        Me.txt_note_sts_2.Enabled = False

        Me.chk_stat_3.Enabled = False
        Me.txt_note_sts_3.Enabled = False

        Me.chk_stat_4.Enabled = True
        Me.txt_note_sts_4.Enabled = True

        Me.chk_stat_5.Enabled = False
        Me.txt_note_sts_5.Enabled = False

        Me.chk_stat_6.Enabled = False
        Me.txt_note_sts_6.Enabled = False

        Me.chk_stat_7.Enabled = False
        Me.txt_note_sts_7.Enabled = False

        Me.chk_stat_8.Enabled = False
        Me.txt_note_sts_8.Enabled = False
        Me.txt_trackingno.Enabled = False

        Me.chk_stat_9.Enabled = False
        Me.txt_note_sts_9.Enabled = False

        Me.chk_stat_10.Enabled = False
        Me.txt_note_sts_10.Enabled = False

        Me.chk_stat_11.Enabled = False
        Me.txt_note_sts_11.Enabled = False

        Me.chk_stat_12.Enabled = False
        Me.txt_note_sts_12.Enabled = False

        Me.chk_stat_13.Enabled = False
        Me.txt_note_sts_13.Enabled = False

        Me.chk_stat_14.Enabled = False
        Me.txt_note_sts_14.Enabled = False

        Me.chk_stat_15.Enabled = False
        Me.txt_note_sts_15.Enabled = False

        Me.chk_stat_16.Enabled = False
        Me.txt_note_sts_16.Enabled = False

        Me.chk_stat_17.Enabled = True
        Me.txt_note_sts_17.Enabled = True

        '--- Save Order
        If bSave Then
            Dim dStatusDate As DateTime
            Dim oStatus As New ion_two.cls_status
            oStatus._connection_string = Application("config").connection_string
            oStatus._dbtype = Application("config").connection_string_type
            oStatus._user_name = Session("user").user_name
            oStatus._user_id = Session("user").user_id
            bError = oStatus.set_status(nOrderId, 5, dStatusDate, Me.txt_note_sts_5.Text)
            If bError Then
                Session("o_error")._Err_Number = oStatus._err_number
                Session("o_error")._Err_Description = oStatus._err_description
                Session("o_error")._Err_Source = oStatus._err_source
                Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
                Session("o_error")._Err_Call = "set_sts_5 [ion_two.cls_status:set_status]"
                Server.Transfer("/aspxerror.aspx")
            End If
            oStatus = Nothing
            Me.lbl_date_sts_5.Text = dStatusDate
        End If

    End Function

    '6######################################################################################
    Private Function set_sts_6(ByVal bSave As Boolean) As Boolean
        Dim bError As Boolean = False
        bError = unbold_status()

        Me.lbl_sts_line_6.Font.Bold = True
        Me.lbl_sts_line_6.Font.Italic = True

        Me.chk_stat_1.Enabled = False

        Me.chk_stat_2.Enabled = False
        Me.txt_note_sts_2.Enabled = False

        Me.chk_stat_3.Enabled = False
        Me.txt_note_sts_3.Enabled = False

        Me.chk_stat_4.Enabled = False
        Me.txt_note_sts_4.Enabled = False

        Me.chk_stat_5.Enabled = False
        Me.txt_note_sts_5.Enabled = False

        Me.chk_stat_6.Enabled = False
        Me.txt_note_sts_6.Enabled = False

        Me.chk_stat_7.Enabled = False
        Me.txt_note_sts_7.Enabled = False

        Me.chk_stat_8.Enabled = False
        Me.txt_note_sts_8.Enabled = False
        Me.txt_trackingno.Enabled = False

        Me.chk_stat_9.Enabled = False
        Me.txt_note_sts_9.Enabled = False

        Me.chk_stat_10.Enabled = False
        Me.txt_note_sts_10.Enabled = False

        Me.chk_stat_11.Enabled = False
        Me.txt_note_sts_11.Enabled = False

        Me.chk_stat_12.Enabled = False
        Me.txt_note_sts_12.Enabled = False

        Me.chk_stat_13.Enabled = False
        Me.txt_note_sts_13.Enabled = False

        Me.chk_stat_14.Enabled = False
        Me.txt_note_sts_14.Enabled = False

        Me.chk_stat_15.Enabled = False
        Me.txt_note_sts_15.Enabled = False

        Me.chk_stat_16.Enabled = False
        Me.txt_note_sts_16.Enabled = False

        Me.chk_stat_17.Enabled = False
        Me.txt_note_sts_17.Enabled = False

        '--- Save Order
        If bSave Then
            Dim dStatusDate As DateTime
            Dim oStatus As New ion_two.cls_status
            oStatus._connection_string = Application("config").connection_string
            oStatus._dbtype = Application("config").connection_string_type
            oStatus._user_name = Session("user").user_name
            oStatus._user_id = Session("user").user_id
            bError = oStatus.set_status(nOrderId, 6, dStatusDate, Me.txt_note_sts_6.Text)
            If bError Then
                Session("o_error")._Err_Number = oStatus._err_number
                Session("o_error")._Err_Description = oStatus._err_description
                Session("o_error")._Err_Source = oStatus._err_source
                Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
                Session("o_error")._Err_Call = "set_sts_6 [ion_two.cls_status:set_status]"
                Server.Transfer("/aspxerror.aspx")
            End If
            oStatus = Nothing
            Me.lbl_date_sts_6.Text = dStatusDate
        End If

    End Function

    '7######################################################################################
    Private Function set_sts_7(ByVal bSave As Boolean) As Boolean
        Dim bError As Boolean = False
        bError = unbold_status()

        Me.lbl_sts_line_7.Font.Bold = True
        Me.lbl_sts_line_7.Font.Italic = True

        Me.chk_stat_1.Enabled = False

        Me.chk_stat_2.Enabled = False
        Me.txt_note_sts_2.Enabled = False

        Me.chk_stat_3.Enabled = False
        Me.txt_note_sts_3.Enabled = False

        Me.chk_stat_4.Enabled = False
        Me.txt_note_sts_4.Enabled = False

        Me.chk_stat_5.Enabled = False
        Me.txt_note_sts_5.Enabled = False

        Me.chk_stat_6.Enabled = False
        Me.txt_note_sts_6.Enabled = False

        Me.chk_stat_7.Enabled = False
        Me.txt_note_sts_7.Enabled = False

        Me.chk_stat_8.Enabled = True
        Me.txt_note_sts_8.Enabled = True
        Me.txt_trackingno.Enabled = True

        Me.chk_stat_9.Enabled = True
        Me.txt_note_sts_9.Enabled = True

        Me.chk_stat_10.Enabled = False
        Me.txt_note_sts_10.Enabled = False

        Me.chk_stat_11.Enabled = False
        Me.txt_note_sts_11.Enabled = False

        Me.chk_stat_12.Enabled = False
        Me.txt_note_sts_12.Enabled = False

        Me.chk_stat_13.Enabled = False
        Me.txt_note_sts_13.Enabled = False

        Me.chk_stat_14.Enabled = False
        Me.txt_note_sts_14.Enabled = False

        Me.chk_stat_15.Enabled = False
        Me.txt_note_sts_15.Enabled = False

        Me.chk_stat_16.Enabled = False
        Me.txt_note_sts_16.Enabled = False

        Me.chk_stat_17.Enabled = True
        Me.txt_note_sts_17.Enabled = True

        '--- Save Order
        If bSave Then
            Dim dStatusDate As DateTime
            Dim oStatus As New ion_two.cls_status
            oStatus._connection_string = Application("config").connection_string
            oStatus._dbtype = Application("config").connection_string_type
            oStatus._user_name = Session("user").user_name
            oStatus._user_id = Session("user").user_id
            bError = oStatus.set_status(nOrderId, 7, dStatusDate, Me.txt_note_sts_7.Text)
            If bError Then
                Session("o_error")._Err_Number = oStatus._err_number
                Session("o_error")._Err_Description = oStatus._err_description
                Session("o_error")._Err_Source = oStatus._err_source
                Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
                Session("o_error")._Err_Call = "set_sts_7 [ion_two.cls_status:set_status]"
                Server.Transfer("/aspxerror.aspx")
            End If
            oStatus = Nothing
            Me.lbl_date_sts_7.Text = dStatusDate
        End If

    End Function

    '8######################################################################################
    Private Function set_sts_8(ByVal bSave As Boolean) As Boolean
        Dim bError As Boolean = False
        bError = unbold_status()

        Me.lbl_sts_line_8.Font.Bold = True
        Me.lbl_sts_line_8.Font.Italic = True

        Me.chk_stat_1.Enabled = False

        Me.chk_stat_2.Enabled = False
        Me.txt_note_sts_2.Enabled = False

        Me.chk_stat_3.Enabled = False
        Me.txt_note_sts_3.Enabled = False

        Me.chk_stat_4.Enabled = False
        Me.txt_note_sts_4.Enabled = False

        Me.chk_stat_5.Enabled = False
        Me.txt_note_sts_5.Enabled = False

        Me.chk_stat_6.Enabled = False
        Me.txt_note_sts_6.Enabled = False

        Me.chk_stat_7.Enabled = False
        Me.txt_note_sts_7.Enabled = False

        Me.chk_stat_8.Enabled = False
        Me.txt_note_sts_8.Enabled = False
        Me.txt_trackingno.Enabled = False

        Me.chk_stat_9.Enabled = False
        Me.txt_note_sts_9.Enabled = False

        Me.chk_stat_10.Enabled = True
        Me.txt_note_sts_10.Enabled = True

        Me.chk_stat_11.Enabled = True
        Me.txt_note_sts_11.Enabled = True

        Me.chk_stat_12.Enabled = False
        Me.txt_note_sts_12.Enabled = False

        Me.chk_stat_13.Enabled = False
        Me.txt_note_sts_13.Enabled = False

        Me.chk_stat_14.Enabled = False
        Me.txt_note_sts_14.Enabled = False

        Me.chk_stat_15.Enabled = False
        Me.txt_note_sts_15.Enabled = False

        Me.chk_stat_16.Enabled = False
        Me.txt_note_sts_16.Enabled = False

        Me.chk_stat_17.Enabled = True
        Me.txt_note_sts_17.Enabled = True

        '--- Save Order
        If bSave Then
            Dim dStatusDate As DateTime
            Dim oStatus As New ion_two.cls_status
            oStatus._connection_string = Application("config").connection_string
            oStatus._dbtype = Application("config").connection_string_type
            oStatus._user_name = Session("user").user_name
            oStatus._user_id = Session("user").user_id
            bError = oStatus.set_status(nOrderId, 8, dStatusDate, Me.txt_note_sts_8.Text, Me.txt_trackingno.Text)
            If bError Then
                Session("o_error")._Err_Number = oStatus._err_number
                Session("o_error")._Err_Description = oStatus._err_description
                Session("o_error")._Err_Source = oStatus._err_source
                Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
                Session("o_error")._Err_Call = "set_sts_8 [ion_two.cls_status:set_status]"
                Server.Transfer("/aspxerror.aspx")
            End If
            oStatus = Nothing
            Me.lbl_date_sts_8.Text = dStatusDate
        End If

    End Function

    '9######################################################################################
    Private Function set_sts_9(ByVal bSave As Boolean) As Boolean
        Dim bError As Boolean = False
        bError = unbold_status()

        Me.lbl_sts_line_9.Font.Bold = True
        Me.lbl_sts_line_9.Font.Italic = True

        Me.chk_stat_1.Enabled = False

        Me.chk_stat_2.Enabled = False
        Me.txt_note_sts_2.Enabled = False

        Me.chk_stat_3.Enabled = False
        Me.txt_note_sts_3.Enabled = False

        Me.chk_stat_4.Enabled = False
        Me.txt_note_sts_4.Enabled = False

        Me.chk_stat_5.Enabled = False
        Me.txt_note_sts_5.Enabled = False

        Me.chk_stat_6.Enabled = False
        Me.txt_note_sts_6.Enabled = False

        Me.chk_stat_7.Enabled = False
        Me.txt_note_sts_7.Enabled = False

        Me.chk_stat_8.Enabled = True
        Me.txt_note_sts_8.Enabled = True
        Me.txt_trackingno.Enabled = True

        Me.chk_stat_9.Enabled = False
        Me.txt_note_sts_9.Enabled = False

        Me.chk_stat_10.Enabled = False
        Me.txt_note_sts_10.Enabled = False

        Me.chk_stat_11.Enabled = False
        Me.txt_note_sts_11.Enabled = False

        Me.chk_stat_12.Enabled = False
        Me.txt_note_sts_12.Enabled = False

        Me.chk_stat_13.Enabled = False
        Me.txt_note_sts_13.Enabled = False

        Me.chk_stat_14.Enabled = False
        Me.txt_note_sts_14.Enabled = False

        Me.chk_stat_15.Enabled = False
        Me.txt_note_sts_15.Enabled = False

        Me.chk_stat_16.Enabled = False
        Me.txt_note_sts_16.Enabled = False

        Me.chk_stat_17.Enabled = True
        Me.txt_note_sts_17.Enabled = True

        '--- Save Order
        If bSave Then
            Dim dStatusDate As DateTime
            Dim oStatus As New ion_two.cls_status
            oStatus._connection_string = Application("config").connection_string
            oStatus._dbtype = Application("config").connection_string_type
            oStatus._user_name = Session("user").user_name
            oStatus._user_id = Session("user").user_id
            bError = oStatus.set_status(nOrderId, 9, dStatusDate, Me.txt_note_sts_9.Text)
            If bError Then
                Session("o_error")._Err_Number = oStatus._err_number
                Session("o_error")._Err_Description = oStatus._err_description
                Session("o_error")._Err_Source = oStatus._err_source
                Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
                Session("o_error")._Err_Call = "set_sts_9 [ion_two.cls_status:set_status]"
                Server.Transfer("/aspxerror.aspx")
            End If
            oStatus = Nothing
            Me.lbl_date_sts_9.Text = dStatusDate
        End If

    End Function

    '10######################################################################################
    Private Function set_sts_10(ByVal bSave As Boolean) As Boolean
        Dim bError As Boolean = False
        bError = unbold_status()

        Me.lbl_sts_line_10.Font.Bold = True
        Me.lbl_sts_line_10.Font.Italic = True

        Me.chk_stat_1.Enabled = False

        Me.chk_stat_2.Enabled = False
        Me.txt_note_sts_2.Enabled = False

        Me.chk_stat_3.Enabled = False
        Me.txt_note_sts_3.Enabled = False

        Me.chk_stat_4.Enabled = False
        Me.txt_note_sts_4.Enabled = False

        Me.chk_stat_5.Enabled = False
        Me.txt_note_sts_5.Enabled = False

        Me.chk_stat_6.Enabled = False
        Me.txt_note_sts_6.Enabled = False

        Me.chk_stat_7.Enabled = False
        Me.txt_note_sts_7.Enabled = False

        Me.chk_stat_8.Enabled = False
        Me.txt_note_sts_8.Enabled = False
        Me.txt_trackingno.Enabled = False

        Me.chk_stat_9.Enabled = False
        Me.txt_note_sts_9.Enabled = False

        Me.chk_stat_10.Enabled = False
        Me.txt_note_sts_10.Enabled = False

        Me.chk_stat_11.Enabled = False
        Me.txt_note_sts_11.Enabled = False

        Me.chk_stat_12.Enabled = True
        Me.txt_note_sts_12.Enabled = True

        Me.chk_stat_13.Enabled = True
        Me.txt_note_sts_13.Enabled = True

        Me.chk_stat_14.Enabled = False
        Me.txt_note_sts_14.Enabled = False

        Me.chk_stat_15.Enabled = False
        Me.txt_note_sts_15.Enabled = False

        Me.chk_stat_16.Enabled = True
        Me.txt_note_sts_16.Enabled = True

        Me.chk_stat_17.Enabled = True
        Me.txt_note_sts_17.Enabled = True

        '--- Save Order
        If bSave Then
            Dim dStatusDate As DateTime
            Dim oStatus As New ion_two.cls_status
            oStatus._connection_string = Application("config").connection_string
            oStatus._dbtype = Application("config").connection_string_type
            oStatus._user_name = Session("user").user_name
            oStatus._user_id = Session("user").user_id
            bError = oStatus.set_status(nOrderId, 10, dStatusDate, Me.txt_note_sts_10.Text)
            If bError Then
                Session("o_error")._Err_Number = oStatus._err_number
                Session("o_error")._Err_Description = oStatus._err_description
                Session("o_error")._Err_Source = oStatus._err_source
                Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
                Session("o_error")._Err_Call = "set_sts_10 [ion_two.cls_status:set_status]"
                Server.Transfer("/aspxerror.aspx")
            End If
            oStatus = Nothing
            Me.lbl_date_sts_10.Text = dStatusDate
        End If

    End Function

    '11######################################################################################
    Private Function set_sts_11(ByVal bSave As Boolean) As Boolean
        Dim bError As Boolean = False
        bError = unbold_status()

        Me.lbl_sts_line_11.Font.Bold = True
        Me.lbl_sts_line_11.Font.Italic = True

        Me.chk_stat_1.Enabled = False

        Me.chk_stat_2.Enabled = False
        Me.txt_note_sts_2.Enabled = False

        Me.chk_stat_3.Enabled = False
        Me.txt_note_sts_3.Enabled = False

        Me.chk_stat_4.Enabled = False
        Me.txt_note_sts_4.Enabled = False

        Me.chk_stat_5.Enabled = False
        Me.txt_note_sts_5.Enabled = False

        Me.chk_stat_6.Enabled = False
        Me.txt_note_sts_6.Enabled = False

        Me.chk_stat_7.Enabled = False
        Me.txt_note_sts_7.Enabled = False

        Me.chk_stat_8.Enabled = False
        Me.txt_note_sts_8.Enabled = False
        Me.txt_trackingno.Enabled = False

        Me.chk_stat_9.Enabled = False
        Me.txt_note_sts_9.Enabled = False

        Me.chk_stat_10.Enabled = True
        Me.txt_note_sts_10.Enabled = True

        Me.chk_stat_11.Enabled = False
        Me.txt_note_sts_11.Enabled = False

        Me.chk_stat_12.Enabled = False
        Me.txt_note_sts_12.Enabled = False

        Me.chk_stat_13.Enabled = False
        Me.txt_note_sts_13.Enabled = False

        Me.chk_stat_14.Enabled = False
        Me.txt_note_sts_14.Enabled = False

        Me.chk_stat_15.Enabled = False
        Me.txt_note_sts_15.Enabled = False

        Me.chk_stat_16.Enabled = False
        Me.txt_note_sts_16.Enabled = False

        Me.chk_stat_17.Enabled = True
        Me.txt_note_sts_17.Enabled = True

        '--- Save Order
        If bSave Then
            Dim dStatusDate As DateTime
            Dim oStatus As New ion_two.cls_status
            oStatus._connection_string = Application("config").connection_string
            oStatus._dbtype = Application("config").connection_string_type
            oStatus._user_name = Session("user").user_name
            oStatus._user_id = Session("user").user_id
            bError = oStatus.set_status(nOrderId, 11, dStatusDate, Me.txt_note_sts_11.Text)
            If bError Then
                Session("o_error")._Err_Number = oStatus._err_number
                Session("o_error")._Err_Description = oStatus._err_description
                Session("o_error")._Err_Source = oStatus._err_source
                Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
                Session("o_error")._Err_Call = "set_sts_11 [ion_two.cls_status:set_status]"
                Server.Transfer("/aspxerror.aspx")
            End If
            oStatus = Nothing
            Me.lbl_date_sts_11.Text = dStatusDate
        End If

    End Function

    '12######################################################################################
    Private Function set_sts_12(ByVal bSave As Boolean) As Boolean
        Dim bError As Boolean = False
        bError = unbold_status()

        Me.lbl_sts_line_12.Font.Bold = True
        Me.lbl_sts_line_12.Font.Italic = True

        Me.chk_stat_1.Enabled = False

        Me.chk_stat_2.Enabled = False
        Me.txt_note_sts_2.Enabled = False

        Me.chk_stat_3.Enabled = False
        Me.txt_note_sts_3.Enabled = False

        Me.chk_stat_4.Enabled = False
        Me.txt_note_sts_4.Enabled = False

        Me.chk_stat_5.Enabled = False
        Me.txt_note_sts_5.Enabled = False

        Me.chk_stat_6.Enabled = False
        Me.txt_note_sts_6.Enabled = False

        Me.chk_stat_7.Enabled = False
        Me.txt_note_sts_7.Enabled = False

        Me.chk_stat_8.Enabled = False
        Me.txt_note_sts_8.Enabled = False
        Me.txt_trackingno.Enabled = False

        Me.chk_stat_9.Enabled = False
        Me.txt_note_sts_9.Enabled = False

        Me.chk_stat_10.Enabled = False
        Me.txt_note_sts_10.Enabled = False

        Me.chk_stat_11.Enabled = False
        Me.txt_note_sts_11.Enabled = False

        Me.chk_stat_12.Enabled = False
        Me.txt_note_sts_12.Enabled = False

        Me.chk_stat_13.Enabled = False
        Me.txt_note_sts_13.Enabled = False

        Me.chk_stat_14.Enabled = True
        Me.txt_note_sts_14.Enabled = True

        Me.chk_stat_15.Enabled = True
        Me.txt_note_sts_15.Enabled = True

        Me.chk_stat_16.Enabled = False
        Me.txt_note_sts_16.Enabled = False

        Me.chk_stat_17.Enabled = True
        Me.txt_note_sts_17.Enabled = True

        '--- Save Order
        If bSave Then
            Dim dStatusDate As DateTime
            Dim oStatus As New ion_two.cls_status
            oStatus._connection_string = Application("config").connection_string
            oStatus._dbtype = Application("config").connection_string_type
            oStatus._user_name = Session("user").user_name
            oStatus._user_id = Session("user").user_id
            bError = oStatus.set_status(nOrderId, 12, dStatusDate, Me.txt_note_sts_12.Text)
            If bError Then
                Session("o_error")._Err_Number = oStatus._err_number
                Session("o_error")._Err_Description = oStatus._err_description
                Session("o_error")._Err_Source = oStatus._err_source
                Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
                Session("o_error")._Err_Call = "set_sts_12 [ion_two.cls_status:set_status]"
                Server.Transfer("/aspxerror.aspx")
            End If
            oStatus = Nothing
            Me.lbl_date_sts_12.Text = dStatusDate
        End If

    End Function

    '13######################################################################################
    Private Function set_sts_13(ByVal bSave As Boolean) As Boolean
        Dim bError As Boolean = False
        bError = unbold_status()

        Me.lbl_sts_line_13.Font.Bold = True
        Me.lbl_sts_line_13.Font.Italic = True

        Me.chk_stat_1.Enabled = False

        Me.chk_stat_2.Enabled = False
        Me.txt_note_sts_2.Enabled = False

        Me.chk_stat_3.Enabled = False
        Me.txt_note_sts_3.Enabled = False

        Me.chk_stat_4.Enabled = False
        Me.txt_note_sts_4.Enabled = False

        Me.chk_stat_5.Enabled = False
        Me.txt_note_sts_5.Enabled = False

        Me.chk_stat_6.Enabled = False
        Me.txt_note_sts_6.Enabled = False

        Me.chk_stat_7.Enabled = False
        Me.txt_note_sts_7.Enabled = False

        Me.chk_stat_8.Enabled = False
        Me.txt_note_sts_8.Enabled = False
        Me.txt_trackingno.Enabled = False

        Me.chk_stat_9.Enabled = False
        Me.txt_note_sts_9.Enabled = False

        Me.chk_stat_10.Enabled = False
        Me.txt_note_sts_10.Enabled = False

        Me.chk_stat_11.Enabled = False
        Me.txt_note_sts_11.Enabled = False

        Me.chk_stat_12.Enabled = False
        Me.txt_note_sts_12.Enabled = False

        Me.chk_stat_13.Enabled = False
        Me.txt_note_sts_13.Enabled = False

        Me.chk_stat_14.Enabled = True
        Me.txt_note_sts_14.Enabled = True

        Me.chk_stat_15.Enabled = True
        Me.txt_note_sts_15.Enabled = True

        Me.chk_stat_16.Enabled = False
        Me.txt_note_sts_16.Enabled = False

        Me.chk_stat_17.Enabled = True
        Me.txt_note_sts_17.Enabled = True

        '--- Save Order
        If bSave Then
            Dim dStatusDate As DateTime
            Dim oStatus As New ion_two.cls_status
            oStatus._connection_string = Application("config").connection_string
            oStatus._dbtype = Application("config").connection_string_type
            oStatus._user_name = Session("user").user_name
            oStatus._user_id = Session("user").user_id
            bError = oStatus.set_status(nOrderId, 13, dStatusDate, Me.txt_note_sts_13.Text)
            If bError Then
                Session("o_error")._Err_Number = oStatus._err_number
                Session("o_error")._Err_Description = oStatus._err_description
                Session("o_error")._Err_Source = oStatus._err_source
                Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
                Session("o_error")._Err_Call = "set_sts_13 [ion_two.cls_status:set_status]"
                Server.Transfer("/aspxerror.aspx")
            End If
            oStatus = Nothing
            Me.lbl_date_sts_13.Text = dStatusDate
        End If

    End Function

    '14######################################################################################
    Private Function set_sts_14(ByVal bSave As Boolean) As Boolean
        Dim bError As Boolean = False
        bError = unbold_status()

        Me.lbl_sts_line_14.Font.Bold = True
        Me.lbl_sts_line_14.Font.Italic = True

        Me.chk_stat_1.Enabled = False

        Me.chk_stat_2.Enabled = False
        Me.txt_note_sts_2.Enabled = False

        Me.chk_stat_3.Enabled = False
        Me.txt_note_sts_3.Enabled = False

        Me.chk_stat_4.Enabled = False
        Me.txt_note_sts_4.Enabled = False

        Me.chk_stat_5.Enabled = False
        Me.txt_note_sts_5.Enabled = False

        Me.chk_stat_6.Enabled = False
        Me.txt_note_sts_6.Enabled = False

        Me.chk_stat_7.Enabled = False
        Me.txt_note_sts_7.Enabled = False

        Me.chk_stat_8.Enabled = False
        Me.txt_note_sts_8.Enabled = False
        Me.txt_trackingno.Enabled = False

        Me.chk_stat_9.Enabled = False
        Me.txt_note_sts_9.Enabled = False

        Me.chk_stat_10.Enabled = False
        Me.txt_note_sts_10.Enabled = False

        Me.chk_stat_11.Enabled = False
        Me.txt_note_sts_11.Enabled = False

        Me.chk_stat_12.Enabled = False
        Me.txt_note_sts_12.Enabled = False

        Me.chk_stat_13.Enabled = False
        Me.txt_note_sts_13.Enabled = False

        Me.chk_stat_14.Enabled = False
        Me.txt_note_sts_14.Enabled = False

        Me.chk_stat_15.Enabled = False
        Me.txt_note_sts_15.Enabled = False

        Me.chk_stat_16.Enabled = True
        Me.txt_note_sts_16.Enabled = True

        Me.chk_stat_17.Enabled = False
        Me.txt_note_sts_17.Enabled = False

        '--- Save Order
        If bSave Then
            Dim dStatusDate As DateTime
            Dim oStatus As New ion_two.cls_status
            oStatus._connection_string = Application("config").connection_string
            oStatus._dbtype = Application("config").connection_string_type
            oStatus._user_name = Session("user").user_name
            oStatus._user_id = Session("user").user_id
            bError = oStatus.set_status(nOrderId, 14, dStatusDate, Me.txt_note_sts_14.Text)
            If bError Then
                Session("o_error")._Err_Number = oStatus._err_number
                Session("o_error")._Err_Description = oStatus._err_description
                Session("o_error")._Err_Source = oStatus._err_source
                Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
                Session("o_error")._Err_Call = "set_sts_14 [ion_two.cls_status:set_status]"
                Server.Transfer("/aspxerror.aspx")
            End If
            oStatus = Nothing
            Me.lbl_date_sts_14.Text = dStatusDate
        End If

    End Function

    '15######################################################################################
    Private Function set_sts_15(ByVal bSave As Boolean) As Boolean
        Dim bError As Boolean = False
        bError = unbold_status()

        Me.lbl_sts_line_15.Font.Bold = True
        Me.lbl_sts_line_15.Font.Italic = True

        Me.chk_stat_1.Enabled = False

        Me.chk_stat_2.Enabled = False
        Me.txt_note_sts_2.Enabled = False

        Me.chk_stat_3.Enabled = False
        Me.txt_note_sts_3.Enabled = False

        Me.chk_stat_4.Enabled = False
        Me.txt_note_sts_4.Enabled = False

        Me.chk_stat_5.Enabled = False
        Me.txt_note_sts_5.Enabled = False

        Me.chk_stat_6.Enabled = False
        Me.txt_note_sts_6.Enabled = False

        Me.chk_stat_7.Enabled = False
        Me.txt_note_sts_7.Enabled = False

        Me.chk_stat_8.Enabled = False
        Me.txt_note_sts_8.Enabled = False
        Me.txt_trackingno.Enabled = False

        Me.chk_stat_9.Enabled = False
        Me.txt_note_sts_9.Enabled = False

        Me.chk_stat_10.Enabled = False
        Me.txt_note_sts_10.Enabled = False

        Me.chk_stat_11.Enabled = False
        Me.txt_note_sts_11.Enabled = False

        Me.chk_stat_12.Enabled = False
        Me.txt_note_sts_12.Enabled = False

        Me.chk_stat_13.Enabled = False
        Me.txt_note_sts_13.Enabled = False

        Me.chk_stat_14.Enabled = False
        Me.txt_note_sts_14.Enabled = False

        Me.chk_stat_15.Enabled = False
        Me.txt_note_sts_15.Enabled = False

        Me.chk_stat_16.Enabled = True
        Me.txt_note_sts_16.Enabled = True

        Me.chk_stat_17.Enabled = False
        Me.txt_note_sts_17.Enabled = False

        '--- Save Order
        If bSave Then
            Dim dStatusDate As DateTime
            Dim oStatus As New ion_two.cls_status
            oStatus._connection_string = Application("config").connection_string
            oStatus._dbtype = Application("config").connection_string_type
            oStatus._user_name = Session("user").user_name
            oStatus._user_id = Session("user").user_id
            bError = oStatus.set_status(nOrderId, 15, dStatusDate, Me.txt_note_sts_15.Text)
            If bError Then
                Session("o_error")._Err_Number = oStatus._err_number
                Session("o_error")._Err_Description = oStatus._err_description
                Session("o_error")._Err_Source = oStatus._err_source
                Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
                Session("o_error")._Err_Call = "set_sts_15 [ion_two.cls_status:set_status]"
                Server.Transfer("/aspxerror.aspx")
            End If
            oStatus = Nothing
            Me.lbl_date_sts_15.Text = dStatusDate
        End If

    End Function

    '16######################################################################################
    Private Function set_sts_16(ByVal bSave As Boolean) As Boolean
        Dim bError As Boolean = False
        bError = unbold_status()

        Me.lbl_sts_line_16.Font.Bold = True
        Me.lbl_sts_line_16.Font.Italic = True

        Me.chk_stat_1.Enabled = False

        Me.chk_stat_2.Enabled = False
        Me.txt_note_sts_2.Enabled = False

        Me.chk_stat_3.Enabled = False
        Me.txt_note_sts_3.Enabled = False

        Me.chk_stat_4.Enabled = False
        Me.txt_note_sts_4.Enabled = False

        Me.chk_stat_5.Enabled = False
        Me.txt_note_sts_5.Enabled = False

        Me.chk_stat_6.Enabled = False
        Me.txt_note_sts_6.Enabled = False

        Me.chk_stat_7.Enabled = False
        Me.txt_note_sts_7.Enabled = False

        Me.chk_stat_8.Enabled = False
        Me.txt_note_sts_8.Enabled = False
        Me.txt_trackingno.Enabled = False

        Me.chk_stat_9.Enabled = False
        Me.txt_note_sts_9.Enabled = False

        Me.chk_stat_10.Enabled = False
        Me.txt_note_sts_10.Enabled = False

        Me.chk_stat_11.Enabled = False
        Me.txt_note_sts_11.Enabled = False

        Me.chk_stat_12.Enabled = False
        Me.txt_note_sts_12.Enabled = False

        Me.chk_stat_13.Enabled = False
        Me.txt_note_sts_13.Enabled = False

        Me.chk_stat_14.Enabled = False
        Me.txt_note_sts_14.Enabled = False

        Me.chk_stat_15.Enabled = False
        Me.txt_note_sts_15.Enabled = False

        Me.chk_stat_16.Enabled = False
        Me.txt_note_sts_16.Enabled = False

        Me.chk_stat_17.Enabled = False
        Me.txt_note_sts_17.Enabled = False

        '--- Save Order
        If bSave Then
            Dim dStatusDate As DateTime
            Dim oStatus As New ion_two.cls_status
            oStatus._connection_string = Application("config").connection_string
            oStatus._dbtype = Application("config").connection_string_type
            oStatus._user_name = Session("user").user_name
            oStatus._user_id = Session("user").user_id
            bError = oStatus.set_status(nOrderId, 16, dStatusDate, Me.txt_note_sts_16.Text)
            If bError Then
                Session("o_error")._Err_Number = oStatus._err_number
                Session("o_error")._Err_Description = oStatus._err_description
                Session("o_error")._Err_Source = oStatus._err_source
                Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
                Session("o_error")._Err_Call = "set_sts_16 [ion_two.cls_status:set_status]"
                Server.Transfer("/aspxerror.aspx")
            End If
            oStatus = Nothing
            Me.lbl_date_sts_16.Text = dStatusDate
        End If

    End Function

    '17######################################################################################
    Private Function set_sts_17(ByVal bSave As Boolean) As Boolean
        Dim bError As Boolean = False
        bError = unbold_status()

        Me.lbl_sts_line_17.Font.Bold = True
        Me.lbl_sts_line_17.Font.Italic = True

        Me.chk_stat_1.Enabled = False

        Me.chk_stat_2.Enabled = False
        Me.txt_note_sts_2.Enabled = False

        Me.chk_stat_3.Enabled = False
        Me.txt_note_sts_3.Enabled = False

        Me.chk_stat_4.Enabled = False
        Me.txt_note_sts_4.Enabled = False

        Me.chk_stat_5.Enabled = False
        Me.txt_note_sts_5.Enabled = False

        Me.chk_stat_6.Enabled = False
        Me.txt_note_sts_6.Enabled = False

        Me.chk_stat_7.Enabled = False
        Me.txt_note_sts_7.Enabled = False

        Me.chk_stat_8.Enabled = False
        Me.txt_note_sts_8.Enabled = False
        Me.txt_trackingno.Enabled = False

        Me.chk_stat_9.Enabled = False
        Me.txt_note_sts_9.Enabled = False

        Me.chk_stat_10.Enabled = False
        Me.txt_note_sts_10.Enabled = False

        Me.chk_stat_11.Enabled = False
        Me.txt_note_sts_11.Enabled = False

        Me.chk_stat_12.Enabled = False
        Me.txt_note_sts_12.Enabled = False

        Me.chk_stat_13.Enabled = False
        Me.txt_note_sts_13.Enabled = False

        Me.chk_stat_14.Enabled = False
        Me.txt_note_sts_14.Enabled = False

        Me.chk_stat_15.Enabled = False
        Me.txt_note_sts_15.Enabled = False

        Me.chk_stat_16.Enabled = False
        Me.txt_note_sts_16.Enabled = False

        Me.chk_stat_17.Enabled = False
        Me.txt_note_sts_17.Enabled = False

        '--- Save Order
        If bSave Then
            Dim dStatusDate As DateTime
            Dim oStatus As New ion_two.cls_status
            oStatus._connection_string = Application("config").connection_string
            oStatus._dbtype = Application("config").connection_string_type
            oStatus._user_name = Session("user").user_name
            oStatus._user_id = Session("user").user_id
            bError = oStatus.set_status(nOrderId, 17, dStatusDate, Me.txt_note_sts_17.Text)
            If bError Then
                Session("o_error")._Err_Number = oStatus._err_number
                Session("o_error")._Err_Description = oStatus._err_description
                Session("o_error")._Err_Source = oStatus._err_source
                Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
                Session("o_error")._Err_Call = "set_sts_17 [ion_two.cls_status:set_status]"
                Server.Transfer("/aspxerror.aspx")
            End If
            oStatus = Nothing
            Me.lbl_date_sts_17.Text = dStatusDate

        End If

    End Function



    '######################################################################################
    Private Function unbold_status() As Boolean
        Me.lbl_sts_line_1.Font.Bold = False
        Me.lbl_sts_line_2.Font.Bold = False
        Me.lbl_sts_line_3.Font.Bold = False
        Me.lbl_sts_line_4.Font.Bold = False
        Me.lbl_sts_line_5.Font.Bold = False
        Me.lbl_sts_line_6.Font.Bold = False
        Me.lbl_sts_line_7.Font.Bold = False
        Me.lbl_sts_line_8.Font.Bold = False
        Me.lbl_sts_line_9.Font.Bold = False
        Me.lbl_sts_line_10.Font.Bold = False
        Me.lbl_sts_line_11.Font.Bold = False
        Me.lbl_sts_line_12.Font.Bold = False
        Me.lbl_sts_line_13.Font.Bold = False
        Me.lbl_sts_line_14.Font.Bold = False
        Me.lbl_sts_line_15.Font.Bold = False
        Me.lbl_sts_line_16.Font.Bold = False
        Me.lbl_sts_line_17.Font.Bold = False

        Me.lbl_sts_line_1.Font.Italic = False
        Me.lbl_sts_line_2.Font.Italic = False
        Me.lbl_sts_line_3.Font.Italic = False
        Me.lbl_sts_line_4.Font.Italic = False
        Me.lbl_sts_line_5.Font.Italic = False
        Me.lbl_sts_line_6.Font.Italic = False
        Me.lbl_sts_line_7.Font.Italic = False
        Me.lbl_sts_line_8.Font.Italic = False
        Me.lbl_sts_line_9.Font.Italic = False
        Me.lbl_sts_line_10.Font.Italic = False
        Me.lbl_sts_line_11.Font.Italic = False
        Me.lbl_sts_line_12.Font.Italic = False
        Me.lbl_sts_line_13.Font.Italic = False
        Me.lbl_sts_line_14.Font.Italic = False
        Me.lbl_sts_line_15.Font.Italic = False
        Me.lbl_sts_line_16.Font.Italic = False
        Me.lbl_sts_line_17.Font.Italic = False


    End Function

    '######################################################################################
    Private Function ask_yesno() As Boolean
        Dim bError As Boolean = False

        '--- Hide all checkboxes, avoide people play with them when we ask YesNo
        bError = visib(False)

        '--- Show the Yesno window
        Me.tbl_YesNo.Visible = True

    End Function

    '######################################################################################
    Private Sub btn_YES_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_YES.Click
        Dim bError As Boolean = False
        Dim bSave As Boolean = True
        Me.lbl_yn_question.Text = ""

        Select Case Me.hid_SettingStat.Text
            Case 1
                bError = set_sts_1()
                Me.hid_SettingStat.Text = 0

            Case 2
                bError = set_sts_2(bSave)
                Me.hid_SettingStat.Text = 0

            Case 3
                bError = set_sts_3(bSave)
                Me.hid_SettingStat.Text = 0

            Case 4
                bError = set_sts_4(bSave)
                Me.hid_SettingStat.Text = 0

            Case 5
                bError = set_sts_5(bSave)
                Me.hid_SettingStat.Text = 0

            Case 6
                bError = set_sts_6(bSave)
                Me.hid_SettingStat.Text = 0

            Case 7
                bError = set_sts_7(bSave)
                Me.hid_SettingStat.Text = 0

            Case 8
                bError = set_sts_8(bSave)
                Me.hid_SettingStat.Text = 0

            Case 9
                bError = set_sts_9(bSave)
                Me.hid_SettingStat.Text = 0

            Case 10
                bError = set_sts_10(bSave)
                Me.hid_SettingStat.Text = 0

            Case 11
                bError = set_sts_11(bSave)
                Me.hid_SettingStat.Text = 0

            Case 12
                bError = set_sts_12(bSave)
                Me.hid_SettingStat.Text = 0

            Case 13
                bError = set_sts_13(bSave)
                Me.hid_SettingStat.Text = 0

            Case 14
                bError = set_sts_14(bSave)
                Me.hid_SettingStat.Text = 0

            Case 15
                bError = set_sts_15(bSave)
                Me.hid_SettingStat.Text = 0

            Case 16
                bError = set_sts_16(bSave)
                Me.hid_SettingStat.Text = 0

            Case 17
                bError = set_sts_17(bSave)
                Me.hid_SettingStat.Text = 0

        End Select

        '--- Show all checkboxes again
        bError = visib(True)

    End Sub

    '######################################################################################
    Private Sub btn_NO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_NO.Click
        Dim bError As Boolean = False

        '--- close the YesNo window
        Me.tbl_YesNo.Visible = False
        Me.lbl_yn_question.Text = ""

        '--- If NO selected then make sure checkbox is Unchecked
        Select Case Me.hid_SettingStat.Text
            Case 1
                Me.chk_stat_1.Checked = False
                Me.hid_SettingStat.Text = 0

            Case 2
                Me.chk_stat_2.Checked = False
                Me.hid_SettingStat.Text = 0

            Case 3
                Me.chk_stat_3.Checked = False
                Me.hid_SettingStat.Text = 0

            Case 4
                Me.chk_stat_4.Checked = False
                Me.hid_SettingStat.Text = 0

            Case 5
                Me.chk_stat_5.Checked = False
                Me.hid_SettingStat.Text = 0

            Case 6
                Me.chk_stat_6.Checked = False
                Me.hid_SettingStat.Text = 0

            Case 7
                Me.chk_stat_7.Checked = False
                Me.hid_SettingStat.Text = 0

            Case 8
                Me.chk_stat_8.Checked = False
                Me.hid_SettingStat.Text = 0

            Case 9
                Me.chk_stat_9.Checked = False
                Me.hid_SettingStat.Text = 0

            Case 10
                Me.chk_stat_10.Checked = False
                Me.hid_SettingStat.Text = 0

            Case 11
                Me.chk_stat_11.Checked = False
                Me.hid_SettingStat.Text = 0

            Case 12
                Me.chk_stat_12.Checked = False
                Me.hid_SettingStat.Text = 0

            Case 13
                Me.chk_stat_13.Checked = False
                Me.hid_SettingStat.Text = 0

            Case 14
                Me.chk_stat_14.Checked = False
                Me.hid_SettingStat.Text = 0

            Case 15
                Me.chk_stat_15.Checked = False
                Me.hid_SettingStat.Text = 0

            Case 16
                Me.chk_stat_16.Checked = False
                Me.hid_SettingStat.Text = 0

            Case 17
                Me.chk_stat_17.Checked = False
                Me.hid_SettingStat.Text = 0

        End Select

        '--- Show all checkboxes again
        bError = visib(True)

    End Sub

    '######################################################################################
    Function visib(ByVal bMode) As Boolean

        Me.chk_stat_1.Visible = bMode
        Me.chk_stat_2.Visible = bMode
        Me.chk_stat_3.Visible = bMode
        Me.chk_stat_4.Visible = bMode
        Me.chk_stat_5.Visible = bMode
        Me.chk_stat_6.Visible = bMode
        Me.chk_stat_7.Visible = bMode
        Me.chk_stat_8.Visible = bMode
        Me.chk_stat_9.Visible = bMode
        Me.chk_stat_10.Visible = bMode
        Me.chk_stat_11.Visible = bMode
        Me.chk_stat_12.Visible = bMode
        Me.chk_stat_13.Visible = bMode
        Me.chk_stat_14.Visible = bMode
        Me.chk_stat_15.Visible = bMode
        Me.chk_stat_16.Visible = bMode
        Me.chk_stat_17.Visible = bMode

    End Function


End Class
