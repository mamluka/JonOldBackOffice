Public Class cls_message
    Private m_listbox As New System.Web.UI.WebControls.ListBox()
    Private m_returnpath As String


    Public Property listbox() As System.Web.UI.WebControls.ListBox
        Get
            Return m_listbox
        End Get

        Set(ByVal Value As System.Web.UI.WebControls.ListBox)
            m_listbox = Value
        End Set
    End Property


    Public Property returnpath() As String
        Get
            Return m_returnpath
        End Get

        Set(ByVal Value As String)
            m_returnpath = Value
        End Set
    End Property


End Class
