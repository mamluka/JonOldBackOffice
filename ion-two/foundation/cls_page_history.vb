Public Class cls_page_history
	Inherits iFoundation.cls_error

	Public _items As New Collection


	Public Function addpage(ByVal cName As String, ByVal cUrl As String) As Boolean

		'--- Define
		Dim cPage As New cls_page_history_items
		cPage._name = cName
		cPage._url = cUrl


		'--- 
		Dim bFound As Boolean = False
		Dim nLoop As Int16
		For nLoop = 1 To Me._items.Count
			If cUrl = Me._items(nLoop)._url Then
				bFound = True
			End If
		Next

		'--- Add to Collection
		If Not bFound Then
			Me._items.Add(cPage)
		End If


		'--- Clear more then 5 pages
		If Me._items.Count = 6 Then
			Me._items.Remove(1)
		End If


		'--- Release
		cPage = Nothing


	End Function


	Private Class cls_page_history_items
		Public _name As String
		Public _url As String

		Sub New()
			Me._name = ""
			Me._url = ""
		End Sub
	End Class

End Class
