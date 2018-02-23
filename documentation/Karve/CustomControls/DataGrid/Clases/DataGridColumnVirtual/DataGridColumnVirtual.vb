Public Class DataGridColumnVirtual
    Dim _Item As Integer
    Dim _sName As String
    Dim _sExpresion As String
    Dim _sAlias As String
    Dim _sAliasTabla As String

    Property Item As Integer
        Get
            Return _Item
        End Get
        Set(value As Integer)
            _Item = value
        End Set
    End Property

    Property Name As String
        Get
            Return _sName
        End Get
        Set(value As String)
            _sName = value
        End Set
    End Property

    Property Expresion As String
        Get
            Return _sExpresion
        End Get
        Set(value As String)
            _sExpresion = value
        End Set
    End Property

    Property AliasCampo As String
        Get
            Return _sAlias
        End Get
        Set(value As String)
            _sAlias = value
        End Set
    End Property

    Property AliasTabla As String
        Get
            Return _sAliasTabla
        End Get
        Set(value As String)
            _sAliasTabla = value
        End Set
    End Property

End Class
