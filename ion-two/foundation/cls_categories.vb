Public Class cls_categories
	Inherits iFoundation.cls_error

	Public _id As Int32
	Public _name As String
	Public _plate As Int16
	Public _direct_path As String
	Public _relative_path As String

	Sub New()
		Me._id = 0
		Me._name = ""
		Me._plate = 0
		Me._direct_path = "'"
		Me._relative_path = ""

	End Sub

	Public Function get_category(ByVal nId As Int32, Optional ByVal cRootPath As String = "") As Boolean
		On Error GoTo ErrorHandler
		Dim bError As Boolean = False

		Select Case nId
			Case 1			'--- Diamonds
				Me._id = 1
				Me._name = "Diamonds"
				Me._plate = 1
				Me._direct_path = cRootPath + "\diamonds\"
				Me._relative_path = "/precious-stones/diamonds/"

			Case 2			'--- Fancy Diamonds
				Me._id = 2
				Me._name = "Fancy-Diamonds"
				Me._plate = 1
				Me._direct_path = cRootPath + "\fancy-diamonds\"
				Me._relative_path = "/precious-stones/fancy-diamonds/"

			Case 3			'--- Rubies
				Me._id = 3
				Me._name = "Rubies"
				Me._plate = 2
				Me._direct_path = cRootPath + "\rubies\"
				Me._relative_path = "/precious-stones/rubies/"

			Case 4			'--- Sapphires
				Me._id = 4
				Me._name = "Sapphires"
				Me._plate = 2
				Me._direct_path = cRootPath + "\sapphires\"
				Me._relative_path = "/precious-stones/sapphires/"

			Case 5			'--- Emeralds
				Me._id = 5
				Me._name = "Emeralds"
				Me._plate = 2
				Me._direct_path = cRootPath + "\emeralds\"
				Me._relative_path = "/precious-stones/emeralds/"

			Case 6
				Me._id = 6
				Me._name = "Semi-Precious"
				Me._plate = 2
				Me._direct_path = cRootPath + "\semi-precious\"
				Me._relative_path = "/precious-stones/semi-precious/"

			Case 7
				Me._id = 6
				Me._name = "Jewelry"
				Me._plate = 3
				Me._direct_path = cRootPath + "\jewelry\"
                Me._relative_path = "/precious-stones/jewelry/"

            Case 8
                Me._id = 6
                Me._name = "Cj-Upload"
                Me._plate = 3
                Me._direct_path = cRootPath + "\jeweldesign\upload"
                Me._relative_path = "/precious-stones/jeweldesign/upload/"

        End Select


		Return False
		Exit Function

ErrorHandler:
		Me._err_number = Err.Number
		Me._err_description = Err.Description
		Me._err_source = Err.Source
		Exit Function


	End Function



End Class
