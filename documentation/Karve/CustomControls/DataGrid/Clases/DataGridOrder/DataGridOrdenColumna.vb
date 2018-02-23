Public Class DataGridOrdenColumna

    Public Enum euCriterio
        Asc
        Desc
    End Enum

    Dim _eCriterio As euCriterio        '*
    Dim _Item As Integer                '*
    Dim _sName As String                '*
    Dim _sCampo As String
    Dim _sExpresion As String           '*
    Dim _sExpresionBD As String           '*
    Dim _sCriterio As String            '*
    Dim _sAliasTabla As String          '*
    Dim _sAliasCampo As String          '*

    Public Property Item As Integer
        Get
            Return _Item
        End Get
        Set(value As Integer)
            _Item = value
        End Set
    End Property

    Public Property Name As String
        Get
            Return _sName
        End Get
        Set(value As String)
            _sName = value
        End Set
    End Property

    Public Property Expresion As String
        Get
            Return _sExpresion
        End Get
        Set(value As String)
            _sExpresion = value
        End Set
    End Property

    Public Property ExpresionBD As String
        Get
            Return _sExpresionBD
        End Get
        Set(value As String)
            _sExpresionBD = value
        End Set
    End Property

    Public Property AliasTabla As String
        Get
            Return _sAliasTabla
        End Get
        Set(value As String)
            _sAliasTabla = value
        End Set
    End Property

    Public Property Criterio As euCriterio
        Get
            Return _eCriterio
        End Get
        Set(value As euCriterio)
            _eCriterio = value
            Select Case _eCriterio
                Case euCriterio.Asc : _sCriterio = " ASC "
                Case euCriterio.Desc : _sCriterio = " DESC "
            End Select
        End Set
    End Property

    Public ReadOnly Property CriterioString As String
        Get
            Return _sCriterio
        End Get
    End Property

    Property Campo As String
        Get
            Return _sCampo
        End Get
        Set(value As String)
            _sCampo = value
        End Set
    End Property

    Public Property AliasCampo As String
        Get
            Return _sAliasCampo
        End Get
        Set(value As String)
            _sAliasCampo = value
        End Set
    End Property

End Class
