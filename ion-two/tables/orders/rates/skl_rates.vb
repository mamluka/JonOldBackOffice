Public Class skl_rates
    Inherits iFoundation.cls_skelet

    Public _id As Int16
    Public _name As String
    Public _code As String
    Public _value As Decimal
    Sub New()
        Me._code = ""
        Me._name = ""
        Me._value = 0
    End Sub

End Class
