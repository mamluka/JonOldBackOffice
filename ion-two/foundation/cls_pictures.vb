Public Class cls_pictures
	Inherits iFoundation.cls_error

	Public _no_icon As String
	Public _no_picture As String
	Public _no_hires As String
	Public _no_movie As String
	Public _no_banner As String
	Public _no_gallery As String
	Public _no_report As String

	Public _ssl_no_icon As String
	Public _ssl_no_picture As String
	Public _ssl_no_hires As String
	Public _ssl_no_movie As String
	Public _ssl_no_banner As String
	Public _ssl_no_gallery As String
	Public _ssl_no_report As String

	Public _domain As String
	Public _ssldomain As String

	Public _path As String
	Public _path_ssl As String

	Public _ssl As Boolean
	Public _result As String
    Public _direct_path As String
    Public perm_direct_path As String


	Sub New()

		Me._no_banner = "no_banner.gif"
		Me._no_gallery = "no_gallery.gif"
		Me._no_icon = "no_icon.gif"
		Me._no_picture = "no_picture.gif"
		Me._no_hires = "no_hires.gif"
		Me._no_movie = "no_movie.gif"
		Me._no_report = "no_report.gif"

		Me._ssl_no_banner = ""
		Me._ssl_no_gallery = ""
		Me._ssl_no_icon = ""
		Me._ssl_no_picture = ""
		Me._ssl_no_hires = ""
		Me._ssl_no_movie = ""
		Me._ssl_no_report = ""

		Me._path = ""
		Me._path_ssl = ""
		Me._domain = ""
		Me._ssldomain = ""
		Me._ssl = False
        Me._result = ""
        Me.perm_direct_path = "D:\internet-sites\twin-pictures\"
        Me._direct_path = "D:\internet-sites\twin-pictures\"
        ''on server this is the path need to uncommon
        '' Me._direct_path = "C:\Inet-sites\twin-pictures\"

	End Sub

	Public Function load(ByVal cDomain As String, ByVal cSSLdomain As String) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False


		'--- Set domain
		Me._domain = Trim(cDomain.ToLower)

		'--- Set SSL domain
		Me._ssldomain = Trim(cSSLdomain.ToLower)


		'--- Write picture SSL paths
		Me._ssl_no_banner = Me._ssldomain + "/pic/" + Me._no_banner
		Me._ssl_no_gallery = Me._ssldomain + "/pic/" + Me._no_gallery
		Me._ssl_no_icon = Me._ssldomain + "/pic/" + Me._no_icon
		Me._ssl_no_picture = Me._ssldomain + "/pic/" + Me._no_picture
		Me._ssl_no_hires = Me._ssldomain + "/pic/" + Me._no_hires
		Me._ssl_no_movie = Me._ssldomain + "/pic/" + Me._no_movie
		Me._ssl_no_report = Me._ssldomain + "/pic/" + Me._no_report

		'--- Write picture paths
		Me._no_banner = Me._domain + "/pic/" + Me._no_banner
		Me._no_gallery = Me._domain + "/pic/" + Me._no_gallery
		Me._no_icon = Me._domain + "/pic/" + Me._no_icon
		Me._no_picture = Me._domain + "/pic/" + Me._no_picture
		Me._no_hires = Me._domain + "/pic/" + Me._no_hires
		Me._no_movie = Me._domain + "/pic/" + Me._no_movie
		Me._no_report = Me._domain + "/pic/" + Me._no_report


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

	Public Function format_picture(ByVal oPictures As ion_two.cls_pictures, ByVal nCategory_id As Int16, ByVal nPictureType As Int16, ByVal nInString As String, ByRef bPictureExist As Boolean) As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False


		If nInString <> "" Then
			'--- Get Directory from categories
			Dim oTmpCategories As New ion_two.cls_categories
			bError = oTmpCategories.get_category(nCategory_id)
			If bError Then
				Me._err_number = oTmpCategories._err_number
				Me._err_description = oTmpCategories._err_description
				Me._err_source = oTmpCategories._err_source
				Return True
			End If

			'--- set result
			If oPictures._ssl Then
				oPictures._result = oPictures._ssldomain + oTmpCategories._relative_path + nInString
            Else
                If nInString.IndexOf("http") > -1 Then
                    oPictures._result = nInString
                    oPictures._direct_path = nInString
                Else
                    oPictures._result = oPictures._domain + oTmpCategories._relative_path + nInString
                    oPictures._direct_path = oTmpCategories._direct_path + nInString
                End If

            End If


            '--- Set both option
            Me._path = oPictures._domain + oTmpCategories._relative_path + nInString
            Me._path_ssl = oPictures._ssldomain + oTmpCategories._relative_path + nInString

            '---
            bPictureExist = True

            '--- release
            oTmpCategories = Nothing

        Else
			Select Case nPictureType
				Case 1				'-- icon
					Me._path = oPictures._no_icon
					Me._path_ssl = oPictures._ssl_no_icon
					'--- set result
					If oPictures._ssl Then
						oPictures._result = oPictures._ssl_no_icon
					Else
						oPictures._result = oPictures._no_icon
					End If

				Case 2				'-- picture
					Me._path = oPictures._no_picture
					Me._path_ssl = oPictures._ssl_no_picture
					'--- set result
					If oPictures._ssl Then
						oPictures._result = oPictures._ssl_no_picture
					Else
						oPictures._result = oPictures._no_picture
					End If

				Case 3				'-- hires picture
					Me._path = oPictures._no_hires
					Me._path_ssl = oPictures._ssl_no_hires
					'--- set result
					If oPictures._ssl Then
						oPictures._result = oPictures._ssl_no_hires
					Else
						oPictures._result = oPictures._no_hires
					End If

				Case 4				'-- gallery
					Me._path = oPictures._no_gallery
					Me._path_ssl = oPictures._ssl_no_gallery
					'--- set result
					If oPictures._ssl Then
						oPictures._result = oPictures._ssl_no_gallery
					Else
						oPictures._result = oPictures._no_gallery
					End If

				Case 5				'-- banner
					Me._path = oPictures._no_banner
					Me._path_ssl = oPictures._ssl_no_banner
					'--- set result
					If oPictures._ssl Then
						oPictures._result = oPictures._ssl_no_banner
					Else
						oPictures._result = oPictures._no_banner
					End If

				Case 6				'-- movie
					Me._path = oPictures._no_movie
					Me._path_ssl = oPictures._ssl_no_movie
					'--- set result
					If oPictures._ssl Then
						oPictures._result = oPictures._ssl_no_movie
					Else
						oPictures._result = oPictures._no_movie
					End If

				Case 7				'-- certificate
					Me._path = oPictures._no_report
					Me._path_ssl = oPictures._ssl_no_report
					'--- set result
					If oPictures._ssl Then
						oPictures._result = oPictures._ssl_no_report
					Else
						oPictures._result = oPictures._no_report
                    End If
                Case 8 ''icon for fancydiamonds.net
                    oPictures._result = "http://www.fancydiamonds.net/_media/diamonds1/icon/" + nInString
                Case 9 ''page pic for fancydiamonds
                    oPictures._result = "http://www.fancydiamonds.net/_media/diamonds1/" + nInString
                Case 10 ''cert for the fancydiamonds.net
                    oPictures._result = "http://www.fancydiamonds.net/_media/diamonds1/" + nInString
            End Select

			bPictureExist = False

		End If


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Return True

	End Function

End Class
