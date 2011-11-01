Public Class cls_resolve_plate
	Private m_TableName As String
	Private m_DataSetName As String
	Private m_PlateObject As Object

	Public Function resolve_plate(ByVal nPlateNumber, ByVal oSystem) As Boolean
		On Error GoTo ErrorHandler

		Select Case nPlateNumber
			Case 1		  '- diamonds
				Me.m_TableName = "inv_DIAMONDS"
				Me.m_DataSetName = "ds_plate_diamonds"
				Me.m_PlateObject = New ds_plate_diamonds()

			Case 2		  '- gemstones
				Me.m_TableName = "inv_GEMSTONES"
				Me.m_DataSetName = "ds_plate_gemstones"
				Me.m_PlateObject = New ds_plate_gemstones()

			Case 3		  '- jewelry
				Me.m_TableName = "inv_JEWELRY"
				Me.m_DataSetName = "ds_plate_jewelry"
				Me.m_PlateObject = New ds_plate_jewelry()

			Case Else
				Err.Raise(5001, "[cls_ion_functions]", "ERROR 5001: Wrong plate number passed in module: <resolve_plate>")

		End Select

		resolve_plate = False
		Exit Function

ErrorHandler:
		resolve_plate = True
		oSystem.error_no = Err.Number
		oSystem.error_desc = Err.Description
		oSystem.error_source = Err.Source

	End Function


	Public Property TableName() As String
		Get
			Return m_TableName
		End Get

		Set(ByVal Value As String)
			m_TableName = Value
		End Set
	End Property

	Public Property DataSetName() As String
		Get
			Return m_DataSetName
		End Get

		Set(ByVal Value As String)
			m_DataSetName = Value
		End Set
	End Property

	Public Property PlateObject() As Object
		Get
			Return m_PlateObject
		End Get

		Set(ByVal Value As Object)
			m_PlateObject = Value
		End Set
	End Property


End Class
