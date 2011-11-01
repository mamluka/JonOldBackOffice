Imports System.Net.Dns
Imports System.Net.IPEndPoint

Public Class cls_dns

    Private m_error_no As Integer
    Private m_error_desc As String
    Private m_error_source As String

    Private m_url As String  '--- URL as given
    Private m_url_domain As String  '--- only the domain name
    Private m_ip As String
    Private m_resolve_error As String


    Public Function resolve(ByVal cURL As String) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False


        '--- First prepare incomming string
        bError = prepare_url(cURL)
        If bError Then
            Return True
        End If

        '--- Resolve
        bError = resolve_link()
        If bError Then
            Return True
        End If



        Return False
        Exit Function

ErrorHandler:
        Me.error_no = Err.Number
        Me.error_desc = Err.Description
        Me.error_source = Err.Source
        Return True

    End Function


    '################################################################################
    Private Function resolve_link() As Boolean


        Try
            Dim oHostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(Me.url_domain)
            Me.ip = oHostInfo.AddressList(0).ToString

        Catch e As Exception
            Me.resolve_error = e.Message

        End Try


        Return False
    End Function



    '#######################################################################################33
    Private Function prepare_url(ByVal cURL As String) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean = False

        '--- Make URL lowercase
        Me.url = cURL.ToLower


        '--- Strip ending Slash from the full URL
        If Mid(Me.url, Me.url.Length) = "/" Then
            Me.url = Mid(Me.url, 1, Me.url.Length - 1)

        End If

        '--- Strip server call (http, https)
        If Mid(Me.url, 1, 7) = "http://" Then
            Me.url_domain = Mid(Me.url, 8)

        ElseIf Mid(Me.url.ToLower, 1, 8) = "https://" Then
            Me.url_domain = Mid(Me.url, 9)

        ElseIf Mid(Me.url.ToLower, 1, 6) = "ftp://" Then
            Me.url_domain = Mid(Me.url, 7)

        End If

        '--- Strip domain name
        Dim nLoop As Int32
        Dim bPassedTheDot As Boolean
        For nLoop = 1 To Me.url_domain.Length
            '--- Check to see if we passed a Dot
            If Mid(Me.url_domain, nLoop, 1) = "." Then
                bPassedTheDot = True
            End If

            '--- If we Passed the Dot - Check if we got a Slash
            If bPassedTheDot Then
                If Mid(Me.url_domain, nLoop, 1) = "/" Then
                    Me.url_domain = Mid(Me.url_domain, 1, nLoop - 1)
                    Exit For
                End If
            End If

        Next

        Return False
        Exit Function

ErrorHandler:
        Me.error_no = Err.Number
        Me.error_desc = Err.Description
        Me.error_source = Err.Source
        Return True

    End Function





    Public Property url() As String
        Get
            Return m_url
        End Get

        Set(ByVal Value As String)
            m_url = Value
        End Set
    End Property

    Public Property url_domain() As String
        Get
            Return m_url_domain
        End Get

        Set(ByVal Value As String)
            m_url_domain = Value
        End Set
    End Property

    Public Property ip() As String
        Get
            Return m_ip
        End Get

        Set(ByVal Value As String)
            m_ip = Value
        End Set
    End Property

    Public Property error_no() As Integer
        Get
            Return m_error_no
        End Get

        Set(ByVal Value As Integer)
            m_error_no = Value
        End Set
    End Property

    Public Property error_desc() As String
        Get
            Return m_error_desc
        End Get

        Set(ByVal Value As String)
            m_error_desc = Value
        End Set
    End Property


    Public Property error_source() As String
        Get
            Return m_error_source
        End Get

        Set(ByVal Value As String)
            m_error_source = Value
        End Set
    End Property

    Public Property resolve_error() As String
        Get
            Return m_resolve_error
        End Get

        Set(ByVal Value As String)
            m_resolve_error = Value
        End Set
    End Property

End Class
