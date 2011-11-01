Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Web
Imports CrystalDecisions.Shared

Imports System.Data
Imports System.IO

Partial Class appraisal1
    Inherits iFoundation.wsc_page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.diamond_appraisal1 = New ion_admin.diamond_appraisal
        Me.jewelry_appraisal1 = New ion_admin.jewelry_appraisal
        Me.gemstone_appraisal1 = New ion_admin.gemstone_appraisal
        '
        'diamond_appraisal1
        '
        Me.diamond_appraisal1.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation
        Me.diamond_appraisal1.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize
        Me.diamond_appraisal1.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Upper
        Me.diamond_appraisal1.PrintOptions.PrinterDuplex = CrystalDecisions.Shared.PrinterDuplex.Default
        '
        'jewelry_appraisal1
        '
        Me.jewelry_appraisal1.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation
        Me.jewelry_appraisal1.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize
        Me.jewelry_appraisal1.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Upper
        Me.jewelry_appraisal1.PrintOptions.PrinterDuplex = CrystalDecisions.Shared.PrinterDuplex.Default
        '
        'gemstone_appraisal1
        '
        Me.gemstone_appraisal1.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation
        Me.gemstone_appraisal1.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize
        Me.gemstone_appraisal1.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Upper
        Me.gemstone_appraisal1.PrintOptions.PrinterDuplex = CrystalDecisions.Shared.PrinterDuplex.Default

    End Sub
    Protected WithEvents diamond_appraisal1 As ion_admin.diamond_appraisal
    Protected WithEvents jewelry_appraisal1 As ion_admin.jewelry_appraisal
    Protected WithEvents gemstone_appraisal1 As ion_admin.gemstone_appraisal

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False



        Exit Sub

ErrorHandler:
        '--- Reporting Error
        Session("o_error")._Err_Number = Err.Number
        Session("o_error")._Err_Description = Err.Description
        Session("o_error")._Err_Source = Err.Source
        Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
        Session("o_error")._Err_Call = "Page_Load [ErrorHandler]"
        Server.Transfer("/aspxerror.aspx")

    End Sub

    Private Sub txt_itemid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_itemid.TextChanged
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- disable link button
        Me.hyp_apprasal.Visible = False

        '--- Get ID
        Dim nId As Int32 = Convert.ToInt32(Me.txt_itemid.Text)

        '--- clean
        bError = Me.clear_item
        If bError Then
            Session("o_error")._Err_Number = Me._err_number
            Session("o_error")._Err_Description = Me._err_description
            Session("o_error")._Err_Source = Me._err_source
            Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
            Session("o_error")._Err_Call = "txt_itemid_TextChanged [clear_item]"
            Server.Transfer("/aspxerror.aspx")
        End If

        '--- Get counter
        Dim nCounter As Int32
        Dim oCounter_logics As New ion_two.cls_syscounters_lgc
        oCounter_logics._connection_string = Application("config").connection_string
        oCounter_logics._dbtype = Application("config").connection_string_type
        bError = oCounter_logics.get_counter(4, nCounter)
        If bError Then
            Session("o_error")._Err_Number = oCounter_logics._err_number
            Session("o_error")._Err_Description = oCounter_logics._err_description
            Session("o_error")._Err_Source = oCounter_logics._err_source
            Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
            Session("o_error")._Err_Call = "Page_Load [ion_two.cls_syscounters_lgc:get_counter]"
            Server.Transfer("/aspxerror.aspx")
        End If
        oCounter_logics = Nothing
        Me.txt_appraisalno.Text = nCounter


        '--- Get Item
        Dim oPlate As New ion_two.skl_lst_inventory
        Dim oTmpInventory As New ion_two.cls_inventory_lgc
        oTmpInventory._connection_string = Application("config").connection_string
        oTmpInventory._dbtype = Application("config").connection_string_type
        bError = oTmpInventory.load(nId, oPlate, Session("user")._pictures, False, False, Application("config").picdir)
        If bError Then
            If oTmpInventory._err_number = 7006 Then             '--- No records found
                bError = False
                Me.lbl_item_description.Text = "- Item does not exist or is not available!"
                Exit Sub
            End If
            Session("o_error")._Err_Number = oTmpInventory._err_number
            Session("o_error")._Err_Description = oTmpInventory._err_description
            Session("o_error")._Err_Source = oTmpInventory._err_source
            Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
            Session("o_error")._Err_Call = "txt_itemid_TextChanged [ion_two.cls_inventory_lgc:load]"
            Server.Transfer("/aspxerror.aspx")
        Else
            Me.lbl_item_description.Text = oPlate._item_description

        End If
        oTmpInventory = Nothing

        '--- Set Radio button selection
        Me.rdo_appraisal.SelectedIndex = oPlate._platetype - 1

        Select Case oPlate._platetype
            Case 1
                Me.txt_weight.Text = oPlate._subplate._s_weight
                Me.txt_stonetype.Text = oPlate._subplate._stonetype
                Me.txt_cut.Text = oPlate._subplate._shape
                Me.txt_color.Text = oPlate._subplate._colorfrom
                Me.txt_clarity.Text = oPlate._subplate._clarityfrom
                Me.txt_size.Text = oPlate._subplate._s_measure

            Case 2
                Me.txt_weight.Text = oPlate._subplate._s_weight
                Me.txt_stonetype.Text = oPlate._subplate._stonetype
                Me.txt_cut.Text = oPlate._subplate._shape
                Me.txt_origin.Text = oPlate._subplate._origin
                Me.txt_size.Text = oPlate._subplate._s_measure

            Case 3
                Me.txt_jewel_weight.Text = oPlate._subplate._s_weight
                Me.txt_jewel_description.Text = oPlate._subplate._jewelrytype
                Me.txt_jewel_middlestone.Text = oPlate._subplate._middlestone_desc
                Me.txt_jewel_gold.Text = oPlate._subplate._metal

        End Select


        '---
        Me.txt_value.Text = oPlate._s_appraisal_price
        Me.img_item.ImageUrl = Application("config").domain + oPlate._picture_pic
        Me.hid_pic_path.Text = oPlate._picture_pic_direct
        Me.txt_notes.Text = oPlate._notes

        Exit Sub

ErrorHandler:
        '--- Reporting Error
        Session("o_error")._Err_Number = Err.Number
        Session("o_error")._Err_Description = Err.Description
        Session("o_error")._Err_Source = Err.Source
        Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
        Session("o_error")._Err_Call = "txt_itemid_TextChanged [ErrorHandler]"
        Server.Transfer("/aspxerror.aspx")

    End Sub

    Private Sub txt_user_id_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_user_id.TextChanged
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- disable link button
        Me.hyp_apprasal.Visible = False

        '--- Get User
        Dim nUser_id As Int32 = Convert.ToInt32(Me.txt_user_id.Text)

        '--- clean
        bError = Me.clear_user
        If bError Then
            Session("o_error")._Err_Number = Me._err_number
            Session("o_error")._Err_Description = Me._err_description
            Session("o_error")._Err_Source = Me._err_source
            Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
            Session("o_error")._Err_Call = "txt_user_id_TextChanged [clear_user]"
            Server.Transfer("/aspxerror.aspx")
        End If


        '--- declare working skelet
        Dim oCustomer As New ion_two.skl_customers

        '--- declare logics
        Dim oCustomer_lgc As New ion_two.cls_customers_lgc
        oCustomer_lgc._connection_string = Application("config").connection_string
        oCustomer_lgc._dbtype = Application("config").connection_string_type
        bError = oCustomer_lgc.read(nUser_id, oCustomer)
        If bError Then
            If oCustomer_lgc._err_number = 7003 Then
                bError = False
                Me.lbl_user_description.Text = "Cannot find user !"
                Exit Sub
            End If
            Session("o_error")._Err_Number = oCustomer_lgc._err_number
            Session("o_error")._Err_Description = oCustomer_lgc._err_description
            Session("o_error")._Err_Source = oCustomer_lgc._err_source
            Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
            Session("o_error")._Err_Call = "txt_itemid_TextChanged [ion_two.cls_customers_lgc:read]"
            Server.Transfer("/aspxerror.aspx")
        End If


        Me.txt_name.Text = oCustomer._firstname + " " + oCustomer._lastname
        Me.txt_address.Text = oCustomer._street1
        Me.txt_city.Text = oCustomer._city1


        Dim oUser_Functions As New ion_two.cls_functions_user
        oUser_Functions._connection_string = Application("config").connection_string
        oUser_Functions._dbtype = Application("config").connection_string_type

        '--- get State
        Dim cState As String = ""
        If oCustomer._state1_id > 1 Then
            bError = oUser_Functions.get_statename(oCustomer._state1_id, cState)
            If bError Then
                Session("o_error")._Err_Number = oUser_Functions._err_number
                Session("o_error")._Err_Description = oUser_Functions._err_description
                Session("o_error")._Err_Source = oUser_Functions._err_source
                Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
                Session("o_error")._Err_Call = "txt_itemid_TextChanged [ion_two.cls_functions_user:get_statename]"
                Server.Transfer("/aspxerror.aspx")
            End If
        End If
        Me.txt_state.Text = cState + "  " + oCustomer._zip1

        '--- get Country
        Dim cCountry As String = ""
        If oCustomer._country1_id > 1 Then
            bError = oUser_Functions.get_countryname(oCustomer._country1_id, cCountry)
            If bError Then
                Session("o_error")._Err_Number = oUser_Functions._err_number
                Session("o_error")._Err_Description = oUser_Functions._err_description
                Session("o_error")._Err_Source = oUser_Functions._err_source
                Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
                Session("o_error")._Err_Call = "txt_itemid_TextChanged [ion_two.cls_functions_user:get_countryname]"
                Server.Transfer("/aspxerror.aspx")
            End If
        End If
        Me.txt_country.Text = cCountry

        '--- release
        oUser_Functions = Nothing
        oCustomer_lgc = Nothing


        Exit Sub

ErrorHandler:
        '--- Reporting Error
        Session("o_error")._Err_Number = Err.Number
        Session("o_error")._Err_Description = Err.Description
        Session("o_error")._Err_Source = Err.Source
        Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
        Session("o_error")._Err_Call = "txt_itemid_TextChanged [ErrorHandler]"
        Server.Transfer("/aspxerror.aspx")

    End Sub

    Private Function clear_item() As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Me.txt_weight.Text = ""
        Me.txt_stonetype.Text = ""
        Me.txt_cut.Text = ""
        Me.txt_color.Text = ""
        Me.txt_clarity.Text = ""
        Me.txt_size.Text = ""
        Me.txt_origin.Text = ""
        Me.txt_jewel_weight.Text = ""
        Me.txt_jewel_description.Text = ""
        Me.txt_jewel_middlestone.Text = ""
        Me.txt_jewel_gold.Text = ""
        Me.txt_value.Text = ""
        Me.img_item.ImageUrl = ""
        Me.txt_notes.Text = ""
        Me.hid_pic_path.Text = ""

        Exit Function
        Return False

ErrorHandler:
        '--- Reporting Error
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function

    Private Function clear_user() As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        Me.txt_name.Text = ""
        Me.txt_address.Text = ""
        Me.txt_city.Text = ""
        Me.txt_state.Text = ""
        Me.txt_country.Text = ""

        Exit Function
        Return False

ErrorHandler:
        '--- Reporting Error
        Me._err_number = Err.Number
        Me._err_description = Err.Description
        Me._err_source = Err.Source
        Return True

    End Function

    Private Sub btn_run_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_run.Click
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False


        '--- Get user info
        Dim oTmpDataSet As DataSet = New ion_admin.ds_appraisal
        Dim oTmpDataTable_user As DataTable = oTmpDataSet.Tables("dbUserInfo")
        Dim oTmpDataTable_item As DataTable = oTmpDataSet.Tables("dbAppraisal")

        '--- USER
        Dim oTmpDataRow_user As DataRow
        oTmpDataRow_user = oTmpDataTable_user.NewRow

        oTmpDataRow_user("Name") = Convert.ToString(Me.txt_name.Text)
        oTmpDataRow_user("Address") = Convert.ToString(Me.txt_address.Text)
        oTmpDataRow_user("City") = Convert.ToString(Me.txt_city.Text)
        oTmpDataRow_user("State") = Convert.ToString(Me.txt_state.Text)
        oTmpDataRow_user("Country") = Convert.ToString(Me.txt_country.Text)
        oTmpDataRow_user("Phone") = ""

        oTmpDataTable_user.Rows.Add(oTmpDataRow_user)


        '--- ITEM
        Dim oTmpDataRow_item As DataRow
        oTmpDataRow_item = oTmpDataTable_item.NewRow

        oTmpDataRow_item("stonetype") = Convert.ToString(Me.txt_stonetype.Text)
        oTmpDataRow_item("no") = Convert.ToString(Me.txt_appraisalno.Text)
        oTmpDataRow_item("jewel_weight") = Convert.ToString(Me.txt_jewel_weight.Text)
        oTmpDataRow_item("jewel_description") = Convert.ToString(Me.txt_jewel_description.Text)
        oTmpDataRow_item("jewel_middlestone") = Convert.ToString(Me.txt_jewel_middlestone.Text)
        oTmpDataRow_item("jewel_gold") = Convert.ToString(Me.txt_jewel_gold.Text)
        oTmpDataRow_item("weight") = Convert.ToString(Me.txt_weight.Text)
        oTmpDataRow_item("cut") = Convert.ToString(Me.txt_cut.Text)
        oTmpDataRow_item("color") = Convert.ToString(Me.txt_color.Text)
        oTmpDataRow_item("clarity") = Convert.ToString(Me.txt_clarity.Text)
        oTmpDataRow_item("origin") = Convert.ToString(Me.txt_origin.Text)
        oTmpDataRow_item("size") = Convert.ToString(Me.txt_size.Text)
        oTmpDataRow_item("value") = Convert.ToString(Me.txt_value.Text)
        oTmpDataRow_item("notes") = Convert.ToString(Me.txt_notes.Text)

        '--- 
        Dim cFilename As String = Me.hid_pic_path.Text
        If File.Exists(cFilename) Then
            Dim oFileStreamer As New FileStream(cFilename, FileMode.Open, FileAccess.Read)            ' create a file stream
            Dim oBinaryReader As New BinaryReader(oFileStreamer)             ' create binary reader
            oTmpDataRow_item("picture") = oBinaryReader.ReadBytes(oBinaryReader.BaseStream.Length)
            oBinaryReader.Close()
            oFileStreamer.Close()
        End If

        oTmpDataTable_item.Rows.Add(oTmpDataRow_item)


        '--- create PDF
        Dim crReportDocument As ReportDocument
        Dim crExportOptions As ExportOptions
        Dim crDiskFileDestinationOptions As DiskFileDestinationOptions

        Dim cPDFfile As String
        Select Case Me.rdo_appraisal.SelectedValue
            Case 1
                Me.diamond_appraisal1.SetDataSource(oTmpDataSet)
                crReportDocument = Me.diamond_appraisal1

            Case 2
                Me.gemstone_appraisal1.SetDataSource(oTmpDataSet)
                crReportDocument = Me.gemstone_appraisal1

            Case 3
                Me.jewelry_appraisal1.SetDataSource(oTmpDataSet)
                crReportDocument = Me.jewelry_appraisal1
        End Select


        cPDFfile = "c:\export\appraisal\appraisal-" & Me.txt_appraisalno.Text.Trim & ".pdf"
        crDiskFileDestinationOptions = New DiskFileDestinationOptions
        crDiskFileDestinationOptions.DiskFileName = cPDFfile

        crExportOptions = crReportDocument.ExportOptions
        crExportOptions.DestinationOptions = crDiskFileDestinationOptions
        crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
        crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

        '--- Ceate
        crReportDocument.Export()

        '--- Set link to PDF
        Me.hyp_apprasal.NavigateUrl = Application("config").masterdomain + "/appraisal/appraisal-" & Me.txt_appraisalno.Text.Trim & ".pdf"
        Me.hyp_apprasal.Visible = True

        '--- Delete PDF
        'System.IO.File.Delete(fName)

        '--- Update appraisal number
        Dim nCounter As Int32 = Convert.ToInt32(Me.txt_appraisalno.Text)
        Dim oCounter_logics As New ion_two.cls_syscounters_lgc
        oCounter_logics._connection_string = Application("config").connection_string
        oCounter_logics._dbtype = Application("config").connection_string_type
        bError = oCounter_logics.set_counter(4, nCounter)
        If bError Then
            Session("o_error")._Err_Number = oCounter_logics._err_number
            Session("o_error")._Err_Description = oCounter_logics._err_description
            Session("o_error")._Err_Source = oCounter_logics._err_source
            Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
            Session("o_error")._Err_Call = "Page_Load [ion_two.cls_syscounters_lgc:get_counter]"
            Server.Transfer("/aspxerror.aspx")
        End If
        oCounter_logics = Nothing



        Exit Sub

ErrorHandler:
        '--- Reporting Error
        Session("o_error")._Err_Number = Err.Number
        Session("o_error")._Err_Description = Err.Description
        Session("o_error")._Err_Source = Err.Source
        Session("o_error")._Err_Module = Me.Request.CurrentExecutionFilePath
        Session("o_error")._Err_Call = "txt_itemid_TextChanged [ErrorHandler]"
        Server.Transfer("/aspxerror.aspx")

    End Sub
End Class
