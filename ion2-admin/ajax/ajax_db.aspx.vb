Imports System.Xml
Partial Class ajax_db
    Inherits System.Web.UI.Page
    Public inventory As ion_two.cls_inventory_lgc


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

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

        Dim id As Int32 = Request.QueryString("id")
        Dim hashstr = Request.QueryString("hashstr")



        Dim dhtmlgrid As New ion_two.cls_dhtmlgrid
        Dim ohtml As New iFunctions.cls_html

        Dim oplate As New ion_two.skl_inventory

        '--- Define logics and get the plate
        Dim oTmpPlateLogics As New ion_two.cls_inventory_lgc
        oTmpPlateLogics._connection_string = Application("config").connection_string
        oTmpPlateLogics._dbtype = Application("config").connection_string_type
        oTmpPlateLogics.read(id, oplate)
        ''oTmpInventory.load(id, oPlate, opictures)

        Dim ostringfunc As New iFunctions.cls_string
        Dim hash As Hashtable = ostringfunc.HashfromString(hashstr, "|", "::")
        ''oTmpInventory.load(

        Me.inventory = oTmpPlateLogics

        Dim req As Int32 = Request.QueryString("req")

        Response.ClearHeaders()
        Response.Clear()
        Response.ContentType = "text/xml"
        Response.Write("<?xml version='1.0' encoding='UTF-8'?>")

        Select Case req
            Case 1 ''active/deactive
                Me.UpdateActive(oplate, hash)
            Case 2 ''active/deactive
                Me.UpdateDefault(oplate, hash)
        End Select
        Response.End()
    End Sub
    Function UpdateActive(ByRef oplate As ion_two.skl_inventory, ByVal hash As Hashtable)

        If hash("active") = "1" Then
            oplate._active = True
        Else
            oplate._active = False
        End If

        Me.inventory.update(oplate)


    End Function

    Function UpdateDefault(ByRef oplate As ion_two.skl_inventory, ByVal hash As Hashtable)

        If hash("default") = "1" Then
            oplate._subplate._jewel_extended.default_model = True
        Else
            oplate._subplate._jewel_extended.default_model = False
        End If

        Me.inventory.update(oplate)


    End Function
    Function CreateAnswer()

    End Function
End Class
