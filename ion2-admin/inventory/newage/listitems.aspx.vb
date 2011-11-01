Partial Class listitems
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents CheckBox1 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents CheckBox2 As System.Web.UI.WebControls.CheckBox
    Protected WithEvents CheckBox3 As System.Web.UI.WebControls.CheckBox

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
        'Put user code to initialize the page here
        'Dim dhtmlgrid As New ion_two.cls_dhtmlgrid
        'Dim array As New ArrayList
        'Dim array2 As New ArrayList
        'array2.Add("fsdfsdf")
        'array2.Add("f1sdfsdf")
        'array2.Add("fs3dfsdf")
        'array2.Add("fsd4fsdf")
        'array.Add(array2)

        'dhtmlgrid.CreateRowFromArrayList(array)
        Dim opt As New Hashtable
        Dim bo_type As combo
        bo_type = Me.FindControl("bo_type")

        opt("loadtype") = 1
        opt("title") = "Type:"
        opt("table") = "inv_STONETYPE_DIAM"
        bo_type.Start(opt)

        opt("table") = "inv_stonetype_gem"
        bo_type.Start(opt)

        bo_type.AddItem("Jewelry", "last")
        bo_type.AddItem("N/A", "999", 0)


        Dim bo_shape As combo
        bo_shape = Me.FindControl("bo_shape")

        opt("loadtype") = 1
        opt("title") = "Shape:"
        opt("table") = "inv_shape_diam"
        bo_shape.Start(opt)
        bo_shape.ReplaceItem("N/A", "999", 0)

        'Dim bo_special As combo
        'bo_special = Me.FindControl("bo_special")



        'opt("loadtype") = 2
        'opt("title") = "Special:"
        'opt("xmlfile") = "/inventory/newage/combos.xml"
        'opt("comboid") = "special"

        'bo_special.Start(opt)



    End Sub

End Class
