Public Class cls_defaults_search

	Public _adv_lastsearch As String
	Public _adv_searchoption As Int16

	Public _tmp_search_string As String
    Public _tmp_search_desc As String
    Public _tmp_live_search_init As String

	Sub New()
		Me._adv_lastsearch = ""
		Me._adv_searchoption = 2

		Me._tmp_search_string = ""
        Me._tmp_search_desc = ""

        Me._tmp_live_search_init = ""
	End Sub

	Sub clear()
		Me._adv_lastsearch = ""
		Me._adv_searchoption = 2

		Me._tmp_search_string = ""
		Me._tmp_search_desc = ""
	End Sub

End Class
