Public Class cls_idex
    Public _idexid As Int64
    Public _clarity As String
    Public _color As String
    Public _report As String
    Public _weight As String
    Public _cut As String
    Public _size As String
    Public _standart_id As Int64
    Public _price As Integer
    Public _description As String



    Public Sub New(ByVal id As Int64, ByVal weight As String, ByVal color As String, ByVal clarity As String, ByVal cut As String, ByVal size As String, Optional ByVal report As String = "Not Specified")
        _idexid = id
        _clarity = clarity
        _color = color
        _report = report
        _weight = weight
        _cut = cut
        _size = size
        _standart_id = 2190
        _price = 1000

    End Sub
    Public Sub make_desc()
        Me._description = "Weight: " + Me._weight + " CT<br>" + "Cut: " + Me._cut + "<br>" + "Color: " + Me._color + "<br>" + "Clarity: " + Me._clarity + "<br>" + "Dimensions: " + Me._size + "<br>" + "Peport: " + Me._report
    End Sub
End Class
