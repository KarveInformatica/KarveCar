Public Class PrimaryKey
    Protected _CampoID As String
    Protected _CampoGrid As String
    Protected _Expresion As String
    Protected _CodEdit As String

    Property CampoID As String
        Get
            Return _CampoID
        End Get
        Set(value As String)
            _CampoID = value
        End Set
    End Property

    Property CodEdit As String
        Get
            Return _CodEdit
        End Get
        Set(value As String)
            _CodEdit = value
        End Set
    End Property

    Property CampoGrid As String
        Get
            If _CampoGrid <> "" Then
                Return _CampoGrid
            Else
                Return _CampoID
            End If
        End Get
        Set(value As String)
            _CampoGrid = value
        End Set
    End Property

    Property Expresion As String
        Get
            Return _Expresion
        End Get
        Set(value As String)
            _Expresion = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal CampoID As String)
        _CampoID = CampoID
    End Sub

    Public Sub New(ByVal CampoID As String, ByVal CampoGrid As String)
        _CampoID = CampoID
        _CampoGrid = CampoGrid
    End Sub
End Class
