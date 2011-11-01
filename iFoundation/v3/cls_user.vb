Public Class cls_user

    Public _id As Int32
    Public _anonimous_id As Int32
    Public _name As String
    Public _sessionid As String
    Public _referrer As String
    Public _ip As String
    Public _session_start As DateTime
    Public _authenticated As Boolean
    Public _email As String
    Public _password As String
    Public _lastvisit As DateTime
    Public _visits As Int32
    Public _message As String
    Public _language As Int16
    Public _createdate As DateTime
    Public _phone1 As String

    Sub New()
        Me._id = 0
        Me._anonimous_id = 0
        Me._name = ""
        Me._sessionid = ""
        Me._referrer = ""
        Me._ip = ""
        Me._session_start = Date.Now
        Me._authenticated = False
        Me._email = ""
        Me._password = ""
        Me._lastvisit = #1/1/1900#
        Me._visits = 0
        Me._message = ""
        Me._language = 1
        Me._createdate = #1/1/1900#
        Me._phone1 = ""
    End Sub

End Class
