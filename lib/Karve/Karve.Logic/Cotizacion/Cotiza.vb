#Region ".   IMPORTS"
Imports ASADB.Connection
Imports Karve.ConfiguracionApp
Imports System.ComponentModel
Imports VariablesGlobales
#End Region

Public Class Cotiza

#Region ".  VARIABLES.  "
    Dim _Tarifa As String
    Dim _TarifaIn As String
    Dim _Grupo As String
    Dim _GrupoIn As String
    Dim _DiasPrev As Double
    Dim _DiasCierre As Double
    Dim _Dto As Double
    Dim _EsFinSemana As Integer
    Dim _sParams As String
    Dim _SP_Cons As String
    Dim _db As ASADB.Connection
    Dim dts As New DataSet

#End Region

#Region ".  CONSTRUCTOR.    "

    Public Sub New(Value As ASADB.Connection)
        _db = Value
        ConfigCons()
    End Sub

    Private Sub ConfigCons()
        If CE.GBool("CHOFER") = False Then
            _SP_Cons = "COTIZA_NMT"
        Else : _SP_Cons = "COTIZA_COSTE"
        End If
    End Sub

#End Region

#Region ".  PUBLIC FUNCTIONS.  "

    Public Function getCotiza() As DataSet
        Try
            dts = getCotiza_In()
            Return dts
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function getCotizaContrato(ByVal idEdit As String, iva As Double) As DataSet
        Try
            Dim mySql As String
            getParametros()
            mySql = "SELECT '" & idEdit & "' AS NUMERO, GRUPO AS GRUPO, TARIFA AS TARIFA, CODCONCEP AS CONCEPTO, NOMCONCEP AS DESCCON, INCLUIDO AS INCLUIDO, ISNULL(UNIDAD, 'DIA') AS UNIDAD, CANT AS CANTIDAD, PRECIO AS PRECIO, DTO AS DTO, " & iva & " AS IVA, IMPORTE AS SUBTOTAL " & _
                    "FROM " & _SP_Cons & "(" & _sParams & ")"
            Return _db.fillDts(mySql)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

#End Region

#Region ".  PRIVATE FUNCTIONS.  "

    Private Function getCotiza_In() As DataSet
        Dim sSQL As String
        Try
            getParametros()
            sSQL = "CALL " & _SP_Cons & "(" & _sParams & ")"
            dts = _db.fillDts(sSQL)
            Return dts
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Function getParametros() As String
        _sParams = _TarifaIn & ", " & _
                  _GrupoIn & ", " & _
                  _DiasPrev & ", " & _
                  _DiasCierre & ", " & _
                  _Dto & ", " & _
                  _EsFinSemana
        Return _sParams
    End Function

#End Region

#Region ".  PROPERTIES.  "

    <Category("Parámetros SP")> _
    Public Property Tarifa As String
        Get
            Return _Tarifa
        End Get
        Set(value As String)
            _Tarifa = value
            _TarifaIn = VD.setApostrofa(value)
        End Set
    End Property

    <Category("Parámetros SP")> _
    Public Property Grupo As String
        Get
            Return _Grupo
        End Get
        Set(value As String)
            _Grupo = value
            _GrupoIn = VD.setApostrofa(value)
        End Set
    End Property

    <Category("Parámetros SP")> _
    Public Property DiasPrev As Double
        Get
            Return _DiasPrev
        End Get
        Set(value As Double)
            _DiasPrev = value
        End Set
    End Property

    <Category("Parámetros SP")> _
    Public Property DiasCierre As Double
        Get
            Return _DiasCierre
        End Get
        Set(value As Double)
            _DiasCierre = value
        End Set
    End Property

    <Category("Parámetros SP")> _
    Public Property Dto As Double
        Get
            Return _Dto
        End Get
        Set(value As Double)
            _Dto = value
        End Set
    End Property

    <Category("Parámetros SP")> _
    Public Property EsFinSemana As Double
        Get
            Return _EsFinSemana
        End Get
        Set(value As Double)
            _EsFinSemana = value
        End Set
    End Property

#End Region

End Class
