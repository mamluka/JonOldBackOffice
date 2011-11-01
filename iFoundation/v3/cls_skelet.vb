Public MustInherit Class cls_skelet

	Public _dbActive As Boolean
	Public _dbDeleted As Boolean
	Public _dbCreateDate As DateTime
	Public _dbCreateId As Int32
	Public _dbModifyDate As DateTime
	Public _dbModifyId As Int32
	Public _dbDeleteDate As DateTime
	Public _dbDeleteId As Int32

	Sub New()
		Me._dbActive = True
		Me._dbDeleted = False
		Me._dbCreateDate = #1/1/1900#
		Me._dbCreateId = 0
		Me._dbModifyDate = #1/1/1900#
		Me._dbModifyId = 0
		Me._dbDeleteDate = #1/1/1900#
		Me._dbDeleteId = 0
	End Sub

End Class
