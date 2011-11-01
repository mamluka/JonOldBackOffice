Imports System.Net
Imports System.IO

Public Class cls_http


	Function readHtmlPage(ByVal url As String) As String
		Dim objResponse As WebResponse
		Dim objRequest As WebRequest
		Dim result As String
		objRequest = System.Net.HttpWebRequest.Create(url)
		objResponse = objRequest.GetResponse()
		Dim sr As New StreamReader(objResponse.GetResponseStream())
		result = sr.ReadToEnd()

		'clean up StreamReader 
		sr.Close()

		Return result
	End Function





End Class
