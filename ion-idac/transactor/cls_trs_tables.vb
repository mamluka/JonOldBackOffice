Imports System.Data.SqlClient

Public Class cls_trs_tables
	Private m_oTable As DataTable
	Private m_oDataAdapter As New SqlDataAdapter()
	Private m_oCommandBuilder As SqlCommandBuilder
	Private m_TableName As String


	Public Property oDataAdapter() As SqlDataAdapter
		Get
			Return m_oDataAdapter
		End Get

		Set(ByVal Value As SqlDataAdapter)
			m_oDataAdapter = Value
		End Set
	End Property

	Public Property oTable() As DataTable
		Get
			Return m_oTable
		End Get

		Set(ByVal Value As DataTable)
			m_oTable = Value
		End Set
	End Property

	Public Property oCommandBuilder() As SqlCommandBuilder
		Get
			Return m_oCommandBuilder
		End Get

		Set(ByVal Value As SqlCommandBuilder)
			m_oCommandBuilder = Value
		End Set
	End Property

	Public Property TableName() As String
		Get
			Return m_TableName
		End Get

		Set(ByVal Value As String)
			m_TableName = Value
		End Set
	End Property


End Class
