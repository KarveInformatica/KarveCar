Imports System.ComponentModel

Public Class DataGridRule

#Region "   .   VARIABLES.  "

    Enum euCriterio
        Igual
        Menor_Que
        MenorIgual_Que
        Mayor_Que
        MayorIgual_Que
        Distinto
        EsNulo
        NoEsNulo
        Contiene
        NoContiene
        Empieza
        Termina
    End Enum

    Enum TipoFiltro
        Texto
        Fecha
        Compuesto
    End Enum

    Enum euOperadorRule
        eAnd
        eOr
    End Enum

    Dim _Item As Integer                '*
    Dim _sName As String                '*
    Dim _sExpresion As String           '*
    Dim _sExpresionBD As String
    Dim _eCriterio As euCriterio        '*
    Dim _eOperador As euOperadorRule = euOperadorRule.eAnd    '*
    Dim _sOperador As String            '*
    Dim _sCriterio As String            '*
    Dim _sValue As String               '*
    Dim _sField As String               '*
    Dim _sAlias As String               '*
    Dim _Tabla As String                '*
    Dim _tipo As TipoFiltro             '*
    Dim _Rules As New DataGridRules     '*


#End Region

#Region "   .   PROPIEDADES.    "

    ReadOnly Property CriterioVal As String
        Get
            Return _sCriterio
        End Get
    End Property

    ReadOnly Property OperadorVal As String
        Get
            If _eOperador = euOperadorRule.eAnd Then
                Return " AND "
            ElseIf _eOperador = euOperadorRule.eOr Then
                Return " OR "
            End If
            Return " "
        End Get
    End Property

    Property Item As Integer
        Get
            Return _Item
        End Get
        Set(value As Integer)
            _Item = value
        End Set
    End Property

    <DefaultValue("eAnd")> _
    Property Operador As euOperadorRule
        Get
            Return _eOperador
        End Get
        Set(value As euOperadorRule)
            _eOperador = value
        End Set
    End Property

    Property Valor As String
        Get
            Return _sValue
        End Get
        Set(value As String)
            _sValue = value
        End Set
    End Property

    Property Campo As String
        Get
            Return _sField
        End Get
        Set(value As String)
            _sField = value
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

    Property Tabla As String
        Get
            Return _Tabla
        End Get
        Set(value As String)
            _Tabla = value
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

    Property Criterio As euCriterio
        Get
            Return _eCriterio
        End Get
        Set(value As euCriterio)
            _eCriterio = value
            Select Case _eCriterio
                Case euCriterio.Igual : _sCriterio = " = "
                Case euCriterio.Distinto : _sCriterio = " <> "
                Case euCriterio.Menor_Que : _sCriterio = " < "
                Case euCriterio.Mayor_Que : _sCriterio = " > "
                Case euCriterio.MayorIgual_Que : _sCriterio = " >= "
                Case euCriterio.MenorIgual_Que : _sCriterio = " <= "
                Case euCriterio.EsNulo : _sCriterio = " IS NULL "
                Case euCriterio.NoEsNulo : _sCriterio = " IS NOT NULL "
                Case euCriterio.NoContiene : _sCriterio = " NOT LIKE "
                Case euCriterio.Contiene : _sCriterio = " LIKE "
                Case euCriterio.Empieza : _sCriterio = " LIKE "
                Case euCriterio.Termina : _sCriterio = " LIKE "
            End Select
        End Set
    End Property

    Property Tipo As TipoFiltro
        Get
            Return _tipo
        End Get
        Set(value As TipoFiltro)
            _tipo = value
        End Set
    End Property

    Property Rules As DataGridRules
        Get
            Return _Rules
        End Get
        Set(value As DataGridRules)
            _Rules = value
        End Set
    End Property

    Property ExpresionBD As String
        Get
            Return _sExpresionBD
        End Get
        Set(value As String)
            _sExpresionBD = value
        End Set
    End Property

#End Region

End Class
