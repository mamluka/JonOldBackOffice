Public Class cls_nd_linkpart
    Public link As String
    Public txt As String
    Public has_redDot As Boolean
    Public javacript_command As String
    Public link_rd_id As String
    Public more As Boolean = False
    Public aftermore As Boolean = False
    Public sepup As String = ""
    Public sepdown As String = ""
    Public linkid As String
    Public title As String = ""

End Class

Public Class cls_nd_row_table
    Public header_img As String
    Public icon_pic As String
    Public desc_text As String
    Public button As String
    Public sep As Boolean = False
    Public link As String

End Class

Public Class cls_nd_morepane
    Public type As Int32
    Public link As String
    Public src As String
    Public text As String
    Public alt As String
End Class
Public Class cls_nd_3line
    Public text
    Public link
End Class
Public Class cls_nd_megaicon_department
    Public title As String
    Public link_coll As New ArrayList
    Public shift As Boolean = False
    Public topsep As String = "0"
    Public shiftamount As String = "0"
    Public qbutton_link As String = ""
End Class

