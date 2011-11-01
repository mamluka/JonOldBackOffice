Public Class cls_viewer_urldecode
    Public Function Decode(ByVal url As String) As Hashtable

        Dim hash As New Hashtable

        Dim word_list() As String
        ''


        word_list = url.Split("[")

        For Each word As String In word_list

            Dim word_val() As String = word.Split("|")

            hash.Add(word_val(0), word_val(1))

        Next

        Return hash

    End Function
    Public Function EncodeStoneType(ByVal stone As String, ByVal typeid As Int32)



    End Function
End Class
