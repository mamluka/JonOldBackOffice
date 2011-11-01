Partial Class wc_customer
    Inherits System.Web.UI.UserControl

    Public nId As Integer
    Public nWorkMode As Integer

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

        nWorkMode = Request.QueryString("mode")
        nId = Request.QueryString("id")

        Dim oFillcombo As New cls_datareader()
        Dim oError As New cls_error()
        oFillcombo.config = Application("config")
        oFillcombo.oerror = oError

        '--- fill STATE1 combo
        oFillcombo.combobox = Me.cmb_state1
        oFillcombo.sqlstring = "select id, lang" & Session("user").language & "_longdescr from sys_STATE  order by lang" & Session("user").language & "_longdescr"
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

        '--- fill COUNTRY1 combo
        oFillcombo.combobox = Me.cmb_country1
        oFillcombo.sqlstring = "select id, lang" & Session("user").language & "_longdescr from sys_COUNTRY order by lang" & Session("user").language & "_longdescr"
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


        '--- fill STATE2 combo
        oFillcombo.combobox = Me.cmb_state2
        oFillcombo.sqlstring = "select id, lang" & Session("user").language & "_longdescr from sys_STATE  order by lang" & Session("user").language & "_longdescr"
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

        '--- fill COUNTRY2 combo
        oFillcombo.combobox = Me.cmb_country2
        oFillcombo.sqlstring = "select id, lang" & Session("user").language & "_longdescr from sys_COUNTRY order by lang" & Session("user").language & "_longdescr"
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

        '--- fill STATEb combo
        oFillcombo.combobox = Me.cmb_stateb
        oFillcombo.sqlstring = "select id, lang" & Session("user").language & "_longdescr from sys_STATE  order by lang" & Session("user").language & "_longdescr"
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

        '--- fill COUNTRYb combo
        oFillcombo.combobox = Me.cmb_countryb
        oFillcombo.sqlstring = "select id, lang" & Session("user").language & "_longdescr from sys_COUNTRY order by lang" & Session("user").language & "_longdescr"
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

    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- If We are Edititng, load Plate into Dataset
        If Not Page.IsPostBack Then
            If nId > 0 And nWorkMode = 2 Then
                bError = load_customer(nId)
                If bError Then
                    Server.Transfer("/apperror.aspx")
                End If
            End If
        End If

        '--- Set Values for the BirthDate Validator
        val_BirthDate.MinimumValue = #1/1/1900#
        val_BirthDate.MaximumValue = Date.Today



        '--- Load Defaults
        If nWorkMode = 1 Then '-Add
            chk_isactive.Checked = True
            chk_mail_regular.Checked = True
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
        Session("error").app_call = "Page_Load"
        Server.Transfer("/apperror.aspx")
    End Sub


    Function update_customer(ByVal nId As Integer) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- Define Customer class
        Dim oCustomer As New ion_resources.cls_customer()

        '--- Get customer and replace values
        Dim oLgcCustomer As New ion_resources.cls_customer_lgc()
        oLgcCustomer.connection_string = Application("config").connection_string
        bError = oLgcCustomer.get_customer(nId, oCustomer)
        If bError Then
            '--- when object is called in external DLL
            Session("error").err_number = oLgcCustomer.error_no
            Session("error").err_source = oLgcCustomer.error_source
            Session("error").err_description = oLgcCustomer.error_desc
            '--- Our custom error
            Dim oTmpDB As New System.Diagnostics.StackFrame()
            Session("error").app_module = Me.Request.CurrentExecutionFilePath
            Session("error").app_function = oTmpDB.GetMethod.Name
            Session("error").app_call = "ion_resources.cls_customer_lgc"
            Return True
        End If

        oCustomer.online_message = Convert.ToString(Me.txt_message.Text)
        oCustomer.firstname = System.Convert.ToString(txt_firstname.Text.Trim)
        oCustomer.lastname = System.Convert.ToString(txt_lastname.Text.Trim)
        oCustomer.email = System.Convert.ToString(txt_email.Text.ToLower.Trim)
        oCustomer.password = System.Convert.ToString(txt_password.Text.Trim)

        If System.Convert.ToString(txt_dateofbirth.Text.Trim) <> "" Then
            oCustomer.dateofbirth = System.Convert.ToDateTime(txt_dateofbirth.Text.Trim)
        Else
            oCustomer.dateofbirth = System.Convert.ToDateTime("01/01/1900")
        End If
        oCustomer.street1 = System.Convert.ToString(txt_street1.Text.Trim)
        oCustomer.city1 = System.Convert.ToString(txt_city1.Text.Trim)
        oCustomer.pobox1 = System.Convert.ToString(txt_pobox1.Text.Trim)
        oCustomer.state1_id = System.Convert.ToInt16(cmb_state1.SelectedItem.Value)
        oCustomer.zip1 = System.Convert.ToString(txt_zip1.Text.Trim)
        oCustomer.country1_id = System.Convert.ToInt16(cmb_country1.SelectedItem.Value)
        oCustomer.phone1 = System.Convert.ToString(txt_phone1.Text.Trim)
        oCustomer.fax1 = System.Convert.ToString(txt_fax1.Text.Trim)
        oCustomer.bname = System.Convert.ToString(txt_businessname.Text.Trim)
        oCustomer.btype_id = System.Convert.ToInt16(cmb_btype.SelectedItem.Value)
        oCustomer.bstreet = System.Convert.ToString(txt_streetb.Text.Trim)
        oCustomer.bspecialization = System.Convert.ToString(txt_specialization.Text.Trim)
        oCustomer.bcity = System.Convert.ToString(txt_cityb.Text.Trim)
        oCustomer.bpobox = System.Convert.ToString(txt_poboxb.Text.Trim)
        oCustomer.bstate_id = System.Convert.ToInt16(cmb_stateb.SelectedItem.Value)
        oCustomer.bzip = System.Convert.ToString(txt_zipb.Text.Trim)
        oCustomer.bcountry_id = System.Convert.ToInt16(cmb_countryb.SelectedItem.Value)
        oCustomer.bphone = System.Convert.ToString(txt_phoneb.Text.Trim)
        oCustomer.bfax = System.Convert.ToString(txt_faxb.Text.Trim)
        oCustomer.bsiteurl = System.Convert.ToString(txt_siteurl.Text.ToLower.Trim)
        oCustomer.btradingass = System.Convert.ToString(txt_memberass.Text.Trim)
        oCustomer.inv_mail = System.Convert.ToBoolean(chk_mail_regular.Checked)
        oCustomer.inv_update = System.Convert.ToBoolean(chk_mail_update.Checked)
        oCustomer.active = System.Convert.ToBoolean(Me.chk_isactive.Checked)
        oCustomer.dealer = System.Convert.ToBoolean(Me.chk_isdealer.Checked)
        oCustomer.userdeleted = System.Convert.ToBoolean(Me.chk_isdeleted.Checked)
        oCustomer.lastmodify_user_id = 0
        oCustomer.lastmodify_user = "User him self"
        oCustomer.lastmodify_date = System.Convert.ToDateTime(Now)
        oCustomer.historical_user = False
        oCustomer.old_id = 0
        oCustomer.last_visit = System.Convert.ToDateTime("01/01/1900")
        oCustomer.idex_percent = System.Convert.ToInt16(Me.txt_idexpercent.Text)
        oCustomer.registration_ip = System.Convert.ToString(Me.txt_ip.Text)

        '--- Update
        bError = oLgcCustomer.update_customer(oCustomer)
        If bError Then
            '--- when object is called in external DLL
            Session("error").err_number = oLgcCustomer.error_no
            Session("error").err_source = oLgcCustomer.error_source
            Session("error").err_description = oLgcCustomer.error_desc
            '--- Our custom error
            Dim oTmpDB As New System.Diagnostics.StackFrame
            Session("error").app_module = Me.Request.CurrentExecutionFilePath
            Session("error").app_function = oTmpDB.GetMethod.Name
            Session("error").app_call = "ion_resources.cls_customer_lgc"
            Return True
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
        Session("error").app_call = "update_customer"
        Server.Transfer("/apperror.aspx")

    End Function


    Function add_customer(ByRef bSaveOK As Boolean) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- Instantiate Class
        Dim oCustomer As New ion_resources.cls_customer()

        oCustomer.firstname = System.Convert.ToString(txt_firstname.Text.Trim)
        oCustomer.lastname = System.Convert.ToString(txt_lastname.Text.Trim)
        oCustomer.email = System.Convert.ToString(txt_email.Text.ToLower.Trim)
        oCustomer.password = System.Convert.ToString(txt_password.Text.Trim)
        If System.Convert.ToString(txt_dateofbirth.Text.Trim) <> "" Then
            oCustomer.dateofbirth = System.Convert.ToDateTime(txt_dateofbirth.Text.Trim)
        Else
            oCustomer.dateofbirth = System.Convert.ToDateTime("01/01/1900")
        End If
        oCustomer.online_message = ""
        oCustomer.street1 = System.Convert.ToString(txt_street1.Text.Trim)
        oCustomer.city1 = System.Convert.ToString(txt_city1.Text.Trim)
        oCustomer.pobox1 = System.Convert.ToString(txt_pobox1.Text.Trim)
        oCustomer.state1_id = System.Convert.ToInt16(cmb_state1.SelectedItem.Value)
        oCustomer.zip1 = System.Convert.ToString(txt_zip1.Text.Trim)
        oCustomer.country1_id = System.Convert.ToInt16(cmb_country1.SelectedItem.Value)
        oCustomer.phone1 = System.Convert.ToString(txt_phone1.Text.Trim)
        oCustomer.fax1 = System.Convert.ToString(txt_fax1.Text.Trim)
        oCustomer.bname = System.Convert.ToString(txt_businessname.Text.Trim)
        oCustomer.btype_id = System.Convert.ToInt16(cmb_btype.SelectedItem.Value)
        oCustomer.bstreet = System.Convert.ToString(txt_streetb.Text.Trim)
        oCustomer.bspecialization = System.Convert.ToString(txt_specialization.Text.Trim)
        oCustomer.bcity = System.Convert.ToString(txt_cityb.Text.Trim)
        oCustomer.bpobox = System.Convert.ToString(txt_poboxb.Text.Trim)
        oCustomer.bstate_id = System.Convert.ToInt16(cmb_stateb.SelectedItem.Value)
        oCustomer.bzip = System.Convert.ToString(txt_zipb.Text.Trim)
        oCustomer.bcountry_id = System.Convert.ToInt16(cmb_countryb.SelectedItem.Value)
        oCustomer.bphone = System.Convert.ToString(txt_phoneb.Text.Trim)
        oCustomer.bfax = System.Convert.ToString(txt_faxb.Text.Trim)
        oCustomer.bsiteurl = System.Convert.ToString(txt_siteurl.Text.ToLower.Trim)
        oCustomer.btradingass = System.Convert.ToString(txt_memberass.Text.Trim)
        oCustomer.inv_mail = System.Convert.ToBoolean(chk_mail_regular.Checked)
        oCustomer.inv_update = System.Convert.ToBoolean(chk_mail_update.Checked)
        oCustomer.active = True
        oCustomer.dealer = False
        oCustomer.userdeleted = False
        oCustomer.lastmodify_user_id = System.Convert.ToInt32(Session("user").user_id)
        oCustomer.lastmodify_user = System.Convert.ToString(Session("user").user_name)
        oCustomer.lastmodify_date = System.Convert.ToDateTime(Now)
        oCustomer.historical_user = False
        oCustomer.old_id = 0
        oCustomer.last_visit = System.Convert.ToDateTime("01/01/1900")
        oCustomer.idex_percent = System.Convert.ToInt16(Me.txt_idexpercent.Text)
        oCustomer.registration_ip = System.Convert.ToString(Me.txt_ip.Text)

        '--- Save customer
        Dim oCustomerBroker As New ion_resources.cls_customer_lgc()
        oCustomerBroker.connection_string = Application("config").connection_string
        bError = oCustomerBroker.insert_customer(oCustomer)
        If bError Then
            '--- when object is called in external DLL
            Session("error").err_number = oCustomerBroker.error_no
            Session("error").err_source = oCustomerBroker.error_source
            Session("error").err_description = oCustomerBroker.error_desc
            '--- Custom error
            Dim oTmpDB As New System.Diagnostics.StackFrame()
            Session("error").app_module = Me.Request.CurrentExecutionFilePath
            Session("error").app_function = oTmpDB.GetMethod.Name
            Session("error").app_call = "ion_resources.cls_customer_lgc / insert_customer"
            Return True
        End If

        txt_customerid.Text = oCustomerBroker.customer_id

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
        Session("error").app_call = "add_customer"
        Return True

    End Function


    Function validate_form(ByRef bFormError As Boolean, ByVal nId As Integer) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        lst_error.Items.Clear()
        lst_error.Items.Add("Validation Errors encountered !!!")

        If txt_firstname.Text.Trim = "" Then
            lst_error.Items.Add("- First Name must be entered")
            bFormError = True
        End If

        If txt_lastname.Text.Trim = "" Then
            lst_error.Items.Add("- Last Name must be entered")
            bFormError = True
        End If

        If txt_email.Text.Trim = "" Then
            lst_error.Items.Add("- eMail must be entered")
            bFormError = True
        End If

        If txt_password.Text.Trim = "" Then
            lst_error.Items.Add("- Password must be entered")
            bFormError = True
        End If

        If Not IsNumeric(Me.txt_idexpercent.Text) Then
            lst_error.Items.Add("- IDEX percent must be numeric!")
            bFormError = True
        End If

        '--- Check if email exists
        'TODO: check for email properly
        If nWorkMode = 1 Then
            If txt_email.Text.Trim <> "" Then
                '--- Check if eMail exists
                Dim bExists As Boolean = False
                Dim oTmpCheck As New ion_resources.cls_functions_customers
                oTmpCheck.connection_string = Application("config").connection_string
                bError = oTmpCheck.get_email_exist(txt_email.Text.ToLower.Trim, bExists)
                If bExists Then
                    lst_error.Items.Add("- This EMAIL exists already in our database, please choose an other.")
                    bFormError = True
                Else
                    bFormError = False
                End If
            End If
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
        Session("error").app_call = "validate_form"
        Return True
    End Function


    Function load_customer(ByVal nId As Integer) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- Define Customer class
        Dim oCustomer As New ion_resources.cls_customer()

        '--- Define MainPlate
        Dim oTmpCustomer As New ion_resources.cls_customer_lgc()
        oTmpCustomer.connection_string = Application("config").connection_string
        bError = oTmpCustomer.get_customer(nId, oCustomer)
        If bError Then
            '--- when object is called in external DLL
            Session("error").err_number = oTmpCustomer.error_no
            Session("error").err_source = oTmpCustomer.error_source
            Session("error").err_description = oTmpCustomer.error_desc
            '--- Our custom error
            Dim oTmpDB As New System.Diagnostics.StackFrame()
            Session("error").app_module = Me.Request.CurrentExecutionFilePath
            Session("error").app_function = oTmpDB.GetMethod.Name
            Session("error").app_call = "ion_resources.ccls_customer_lgc"
            Return True
        End If

        Me.txt_customerid.Text = oCustomer.id
        Me.txt_createdate.Text = oCustomer.create_date
        Me.txt_lastvisit.Text = oCustomer.last_visit
        Me.txt_firstname.Text = oCustomer.firstname
        Me.txt_lastname.Text = oCustomer.lastname
        Me.txt_email.Text = oCustomer.email
        Me.txt_password.Text = oCustomer.password
        Me.txt_dateofbirth.Text = oCustomer.dateofbirth
        Me.txt_street1.Text = oCustomer.street1
        Me.txt_city1.Text = oCustomer.city1
        Me.txt_pobox1.Text = oCustomer.pobox1
        Me.cmb_state1.SelectedIndex = GetComboValue(Me.cmb_state1, oCustomer.state1_id)
        Me.txt_zip1.Text = oCustomer.zip1
        Me.cmb_country1.SelectedIndex = GetComboValue(Me.cmb_country1, oCustomer.country1_id)
        Me.txt_phone1.Text = oCustomer.phone1
        Me.txt_fax1.Text = oCustomer.fax1

        Me.txt_businessname.Text = oCustomer.bname
        Me.cmb_btype.SelectedIndex = GetComboValue(Me.cmb_btype, oCustomer.btype_id)
        Me.txt_streetb.Text = oCustomer.bstreet
        Me.txt_specialization.Text = oCustomer.bspecialization
        Me.txt_cityb.Text = oCustomer.bcity
        Me.txt_poboxb.Text = oCustomer.bpobox
        Me.cmb_stateb.SelectedIndex = GetComboValue(Me.cmb_stateb, oCustomer.bstate_id)
        Me.txt_zipb.Text = oCustomer.bzip
        Me.cmb_countryb.SelectedIndex = GetComboValue(Me.cmb_countryb, oCustomer.bcountry_id)
        Me.txt_phoneb.Text = oCustomer.bphone
        Me.txt_faxb.Text = oCustomer.bfax
        Me.txt_siteurl.Text = oCustomer.bsiteurl
        Me.txt_memberass.Text = oCustomer.btradingass
        Me.chk_mail_regular.Checked = System.Convert.ToBoolean(oCustomer.inv_mail)
        Me.chk_mail_update.Checked = System.Convert.ToBoolean(oCustomer.inv_update)
        Me.chk_isactive.Checked = System.Convert.ToBoolean(oCustomer.active)
        Me.chk_isdealer.Checked = System.Convert.ToBoolean(oCustomer.dealer)
        Me.chk_isdeleted.Checked = System.Convert.ToBoolean(oCustomer.userdeleted)
        Me.txt_userid.Text = oCustomer.lastmodify_user_id

        Me.txt_username.Text = oCustomer.lastmodify_user
        Me.txt_datetime.Text = oCustomer.lastmodify_date

        Me.txt_idexpercent.Text = oCustomer.idex_percent
        Me.txt_ip.Text = oCustomer.registration_ip

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
        Session("error").app_call = "load_customer"
        Return True

    End Function


    Private Sub btn_sbmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sbmit.Click
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False
        Dim bFormError As Boolean = False
        Dim bSaveOK As Boolean = False

        '--- Validate Form
        bError = validate_form(bFormError, nId)
        If bError Then
            Server.Transfer("/apperror.aspx")
        End If

        '--- If form validation = Ok then SAVE
        If Not bFormError Then
            lst_error.Visible = False
            If nWorkMode = 1 Then '-Add
                bError = add_customer(bSaveOK)
                If bError Then
                    Server.Transfer("/apperror.aspx")
                End If

                Session("message").listbox.items.add("Customer [" + txt_customerid.Text.Trim + "] " + txt_firstname.Text.Trim + " " + txt_lastname.Text.Trim + ", has been saved!")
                Session("message").returnpath = "/default.aspx"
                Server.Transfer("/message.aspx")

            ElseIf nWorkMode = 2 Then    '-edit
                bError = update_customer(nId)
                If bError Then
                    Server.Transfer("/apperror.aspx")
                End If

                Session("message").listbox.items.add("Customer [" + txt_customerid.Text.Trim + "] " + txt_firstname.Text.Trim + " " + txt_lastname.Text.Trim + ", has been updated!")
                Session("message").returnpath = "/customers/listcustomers.aspx"
                Server.Transfer("/message.aspx")

            End If

        Else
            lst_error.Visible = True
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
        Session("error").app_call = "btn_sbmit_click"
        Server.Transfer("/apperror.aspx")
    End Sub

    Private Sub cmb_state1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_state1.SelectedIndexChanged
        If cmb_state1.SelectedIndex > 0 Then
            cmb_country1.SelectedIndex = GetComboValue(cmb_country1, "219")

        ElseIf cmb_state1.SelectedIndex = 0 Then
            cmb_country1.SelectedIndex = 0

        End If

        cmb_state2.SelectedIndex = cmb_state1.SelectedIndex
        cmb_stateb.SelectedIndex = cmb_state1.SelectedIndex
        cmb_country2.SelectedIndex = cmb_country1.SelectedIndex
        cmb_countryb.SelectedIndex = cmb_country1.SelectedIndex

    End Sub

    Private Sub cmb_country1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_country1.SelectedIndexChanged
        If cmb_country1.SelectedItem.Value <> 219 Then
            cmb_state1.SelectedIndex = 0
        End If

        cmb_country2.SelectedIndex = cmb_country1.SelectedIndex
        cmb_countryb.SelectedIndex = cmb_country1.SelectedIndex
    End Sub

    Private Sub cmb_state2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_state2.SelectedIndexChanged
        If cmb_state2.SelectedIndex > 0 Then
            cmb_country2.SelectedIndex = GetComboValue(cmb_country2, "219")
        ElseIf cmb_state2.SelectedIndex = 0 Then
            cmb_country2.SelectedIndex = 0
        End If
    End Sub

    Private Sub cmb_country2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_country2.SelectedIndexChanged
        If cmb_country2.SelectedItem.Value <> 219 Then
            cmb_state2.SelectedIndex = 0
        End If
    End Sub

    Private Sub cmb_stateb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_stateb.SelectedIndexChanged
        If cmb_stateb.SelectedIndex > 0 Then
            cmb_countryb.SelectedIndex = GetComboValue(cmb_countryb, "219")
        ElseIf cmb_stateb.SelectedIndex = 0 Then
            cmb_countryb.SelectedIndex = 0
        End If
    End Sub

    Private Sub cmb_countryb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_countryb.SelectedIndexChanged
        If cmb_countryb.SelectedItem.Value <> 219 Then
            cmb_stateb.SelectedIndex = 0
        End If
    End Sub
End Class


