Public Class cls_readHTM
    Inherits ion_resources.cls_base_general

    Private m_title As String
    Private m_description As String
    Private m_keywords As String
    Private m_abstract As String
    Private m_author As String
    Private m_copyright As String
    Private m_filename As String
    Private m_filepath As String
    Private m_content As New Collection()

    Sub New()
        Me.abstract = ""
        Me.author = ""
        Me.copyright = ""
        Me.description = ""
        Me.filename = ""
        Me.keywords = ""
        Me.connection_string = ""

    End Sub



    Function getfile() As Boolean
        On Error GoTo ErrorHandler


        Dim bError As Boolean
        Dim nFile As Long
        Dim cLine As String

        '--- Open configuration file *
        nFile = FreeFile()
        FileSystem.FileOpen(nFile, Me.filepath + Me.filename, OpenMode.Input, OpenAccess.Read)

        '--- Read configuration *
        Dim bInHeader As Boolean = False
        Dim bInBody As Boolean = False
        Dim bJumpLine As Boolean = False

        Do
            cLine = FileSystem.LineInput(nFile)

            Dim nInt As Integer
            Dim cTmpLine As String = LCase(cLine)

            '--- Go for HEADER
            If Not bInHeader Then
                nInt = cTmpLine.IndexOf("<head>")
                If nInt >= 0 Then
                    bInHeader = True
                End If
            End If

            If bInHeader Then
                nInt = cTmpLine.IndexOf("</head>")
                If nInt >= 0 Then
                    bInHeader = False
                End If
            End If

            '--- Go for BODY
            If bJumpLine Then
                bInBody = True
                bJumpLine = False
            End If

            If Not bInBody Then
                nInt = cTmpLine.IndexOf("<body")
                If nInt >= 0 Then
                    bJumpLine = True
                End If
            End If



            If bInBody Then
                nInt = cTmpLine.IndexOf("</body>")
                If nInt >= 0 Then
                    bInBody = False
                End If
            End If

            '--- If in header
            If bInHeader Then
                bError = getparams(cLine)
            End If

            '--- Load the document
            If bInBody Then
                Me.content.Add(cLine)

            End If


        Loop While Not EOF(nFile)

        '--- Close File *
        FileSystem.FileClose(nFile)


        '--- Everything is OK *
        Return False
        Exit Function


ErrorHandler:

        '--- when object is called in external DLL
        Me.error_no = Err.Number
        Me.error_source = Err.Source
        Me.error_desc = Err.Description
        Return True

    End Function



    '#################################################################################
    Private Function getparams(ByVal cLine As String) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean

        Dim cLine_compare As String
        cLine = cLine.Trim
        cLine_compare = LCase(cLine)

        bError = get_tag("<title>", cLine, Me.title)
        bError = get_metatag("description", cLine, Me.description)
        bError = get_metatag("keywords", cLine, Me.keywords)
        bError = get_metatag("author", cLine, Me.author)
        bError = get_metatag("copyright", cLine, Me.copyright)
        bError = get_metatag("abstract", cLine, Me.abstract)

        '--- Everything is OK *
        Return False
        Exit Function


ErrorHandler:
        Me.error_no = Err.Number
        Me.error_source = Err.Source
        Me.error_desc = Err.Description
        Return True

    End Function

    '#################################################################################
    Private Function get_tag(ByVal cTag As String, ByVal cLine As String, ByRef cContent As String) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean


        '--- Used To get final result
        cLine = cLine.Trim

        '--- Used only for comparisations
        Dim cLine_compare As String
        cLine_compare = LCase(cLine)

        Dim nStart As Integer
        Dim nEnd As Integer

        nStart = cLine_compare.IndexOf(cTag)
        If nStart >= 0 Then
            '--- Create End Tag
            Dim cEndTag As String = "</" + cTag.Substring(1)
            nEnd = cLine_compare.IndexOf(cEndTag)
            cContent = cLine.Substring(nStart + cTag.Length, nEnd - cTag.Length)

        End If

        '--- Everything is OK *
        Return False
        Exit Function


ErrorHandler:
        Me.error_no = Err.Number
        Me.error_source = Err.Source
        Me.error_desc = Err.Description
        Return True

    End Function


    '#################################################################################
    Private Function get_metatag(ByVal cTag As String, ByVal cLine As String, ByRef cContent As String) As Boolean
        On Error GoTo ErrorHandler
        Dim bError As Boolean


        '--- Used To get final result
        cLine = cLine.Trim

        '--- Used only for comparisations
        Dim cLine_compare As String
        cLine_compare = LCase(cLine)

        Dim nStart As Integer
        Dim nEnd As Integer

        nStart = cLine_compare.IndexOf("meta name=" + Chr(34) + cTag + Chr(34))
        If nStart >= 0 Then
            Dim nContent As Integer
            nContent = cLine_compare.IndexOf("content=")
            If nContent > 0 Then
                Dim cTmpString As String = cLine.Substring(nContent + 9)
                Dim nTmpPosition As Integer = cTmpString.IndexOf(Chr(34))
                cContent = Left(cTmpString, nTmpPosition)
            End If
        End If

        '--- Everything is OK *
        Return False
        Exit Function


ErrorHandler:
        Me.error_no = Err.Number
        Me.error_source = Err.Source
        Me.error_desc = Err.Description
        Return True

    End Function


    Public Property content() As Collection
        Get
            Return m_content
        End Get

        Set(ByVal Value As Collection)
            m_content = Value
        End Set
    End Property

    Public Property abstract() As String
        Get
            Return m_abstract
        End Get

        Set(ByVal Value As String)
            m_abstract = Value
        End Set
    End Property

    Public Property keywords() As String
        Get
            Return m_keywords
        End Get

        Set(ByVal Value As String)
            m_keywords = Value
        End Set
    End Property

    Public Property description() As String
        Get
            Return m_description
        End Get

        Set(ByVal Value As String)
            m_description = Value
        End Set
    End Property

    Public Property title() As String
        Get
            Return m_title
        End Get

        Set(ByVal Value As String)
            m_title = Value
        End Set
    End Property

    Public Property filename() As String
        Get
            Return m_filename
        End Get

        Set(ByVal Value As String)
            m_filename = Value
        End Set
    End Property

    Public Property filepath() As String
        Get
            Return m_filepath
        End Get

        Set(ByVal Value As String)
            m_filepath = Value
        End Set
    End Property

    Public Property author() As String
        Get
            Return m_author
        End Get

        Set(ByVal Value As String)
            m_author = Value
        End Set
    End Property

    Public Property copyright() As String
        Get
            Return m_copyright
        End Get

        Set(ByVal Value As String)
            m_copyright = Value
        End Set
    End Property

End Class
