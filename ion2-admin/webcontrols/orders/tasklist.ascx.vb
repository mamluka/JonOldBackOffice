Imports System.Xml
Imports System.Data.SqlClient
Partial Class tasklist

    Inherits System.Web.UI.UserControl
    Public oOrder As New ion_resources.cls_order

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
        'Put user code to initialize the page here
        Dim otable As New HtmlTable
        Dim oxml As New ion_two.cls_nd_xmlread
        oxml.xml_file = Server.MapPath("/orders/todo.xml")
        oxml.Load()
        otable.Style.Add("border", "1px red solid")
        otable.Style.Add("margin-bottom", "5px")
        otable.Style.Add("width", "100%")
        For Each todorow As XmlNode In oxml.GetNodes_ByPath("row")
            Dim row As New HtmlTableRow
            For Each todocell As XmlNode In todorow.SelectNodes("cell")
                Dim cell As New HtmlTableCell
                cell.Width = "50%"
                cell.Style.Add("font-family", "verdana")
                cell.Style.Add("font-size", "11px")

                If todocell.Attributes("type").InnerText = "check" Then
                    Dim check As New HtmlInputCheckBox
                    cell.Controls.Add(New HtmlInputCheckBox)
                    Dim lit As New Literal
                    lit.Text = todocell.Attributes("text").InnerText
                    cell.Controls.Add(lit)

                    If Not IsNothing(todocell.Attributes("underscore")) Then
                        Dim lit2 As New Literal
                        lit2.Text = " " + Me.CreateUnderScore(Convert.ToInt32(todocell.Attributes("underscore").InnerText))
                        cell.Controls.Add(lit2)
                    End If



                ElseIf todocell.Attributes("type").InnerText = "text" Then
                    Dim lit As New Literal
                    lit.Text = todocell.Attributes("text").InnerText
                    cell.Controls.Add(lit)
                ElseIf todocell.Attributes("type").InnerText = "space" Then
                    Dim lit As New Literal
                    lit.Text = "x"
                    cell.Controls.Add(lit)
                ElseIf todocell.Attributes("type").InnerText = "key" Then
                    Dim lit As New Literal
                    lit.Text = Me.GetTextByKey(todocell.Attributes("key").InnerText)
                    cell.Controls.Add(lit)
                End If
                row.Cells.Add(cell)
            Next
            otable.Rows.Add(row)
        Next
        Panel.Controls.Add(otable)
    End Sub
    Public Function CreateUnderScore(ByVal length As Int32) As String
        Dim str As String
        Dim i As Int32
        For i = 0 To length
            str += "_"
        Next

        Return str
    End Function
    Public Function GetTextByKey(ByVal key As String) As String
        Dim oConnection As SqlClient.SqlConnection = New SqlClient.SqlConnection
        Dim oDataAdapter1 As SqlDataAdapter = New SqlDataAdapter
        Dim oSQLcmd1 As SqlCommand = New SqlCommand("", oConnection)
        oConnection.ConnectionString = Application("config").connection_string
        oDataAdapter1.TableMappings.Add("Table", "v_customers")

        Select Case key
            Case "email"


                oSQLcmd1.CommandText = "select * from v_customers where id =" + Me.oOrder.user_id.ToString
                oSQLcmd1.CommandType = CommandType.Text
                oDataAdapter1.SelectCommand = oSQLcmd1

                Dim oDs As DataSet
                oDs = New DataSet("customers")

                oConnection.Open()
                oDataAdapter1.Fill(oDs)
                Return oDs.Tables(0).Rows(0)("email")
            Case "payment"
                ''

                oSQLcmd1.CommandText = "select * from acc_CASHFLOW where order_id =" + Me.oOrder.id.ToString
                oSQLcmd1.CommandType = CommandType.Text
                oDataAdapter1.SelectCommand = oSQLcmd1

                Dim oDs As DataSet
                oDs = New DataSet("cash_flow")

                oConnection.Open()
                oDataAdapter1.Fill(oDs)
                Dim payment_type As String

                If oDs.Tables(0).Rows.Count > 0 Then
                    Select Case Convert.ToInt32(oDs.Tables(0).Rows(0)("payment_type"))
                        Case 1
                            payment_type = "Cradit Card<br>#" + " " + oDs.Tables(0).Rows(0)("cc_number") + " cvv " + oDs.Tables(0).Rows(0)("cc_cvv") + "<br> Exp: " + oDs.Tables(0).Rows(0)("cc_exp_month") + "/" + oDs.Tables(0).Rows(0)("cc_exp_year")
                        Case 2
                            payment_type = "Back Transfer"
                        Case 3
                            payment_type = "Check"
                        Case 4
                            payment_type = "PayPal"
                    End Select


                    Return payment_type
                Else
                    Return "Error"
                End If
            Case "order_currency"
                Return Me.oOrder.order_currency
            Case "order_currency_rate"
                Return Me.oOrder.order_currency_rate
        End Select
    End Function
End Class
