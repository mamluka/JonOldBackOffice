Public Class cls_redcombo
    Public Function AddItemsFromArrayList(ByVal itemsName As String, ByVal jsfunc As String, ByVal list As ArrayList, ByRef jsString As String)

        Dim tmparray As New ArrayList

        For Each hash As Hashtable In list

            Dim ostringfunc As New iFunctions.cls_string
            Dim params As New ArrayList
            For Each key As String In hash.Keys
                params.Add(itemsName)
                params.Add(key)
                params.Add(jsfunc)
                params.Add(hash(key))

                tmparray.Add(ostringfunc.CreateJSFunc("UpdateRedComboRow", params, itemsName + jsfunc))
            Next

        Next

        jsString = Join(tmparray.ToArray, ";")

    End Function
    Public Function AddItemsFromArrayList(ByVal itemsName As String, ByVal jsfunc As Hashtable, ByVal list As ArrayList, ByRef jsString As String)

        Dim tmparray As New ArrayList

        For Each hash As Hashtable In list

            Dim ostringfunc As New iFunctions.cls_string
            Dim params As New ArrayList
            For Each key As String In hash.Keys
                params.Add(itemsName)
                params.Add(key)
                params.Add(jsfunc(key))
                params.Add(hash(key))


                tmparray.Add(ostringfunc.CreateJSFunc("UpdateRedComboRow", params, itemsName + jsfunc(key)))
            Next

        Next

        jsString = Join(tmparray.ToArray, ";")

    End Function

    Public Function AddItemsFromArrayList(ByVal itemsName As String, ByVal jsfunc As String, ByVal text As String, ByVal val As String, ByRef jsString As String)
        Dim ostringfunc As New iFunctions.cls_string

        Dim params As New ArrayList
        params.Add(itemsName)
        params.Add(text)
        params.Add(jsfunc)
        params.Add(val)




        jsString = ostringfunc.CreateJSFunc("UpdateRedComboRow", params, itemsName + jsfunc)

    End Function

    Public Function ChangeItemIndex(ByVal optName As String, ByVal newindex As String, ByRef rjsfunc As String)


        rjsfunc = optName + ".defaultIndex=" + newindex

    End Function

End Class
