Imports iAnywhere.Data.SQLAnywhere

Public MustInherit Class ConnBase

#Region "Variables"
    Protected msgBoxError As New VariablesGlobales.MsgBoxError
#End Region

    Public Sub New(cnxString As String)

    End Sub

    Protected Sub New()
        ' TODO: Complete member initialization 
    End Sub

    MustOverride Function TestConnection() As Boolean

    Protected MustOverride Sub cnxOpen()

    Protected MustOverride Sub cnxClose()

    MustOverride Sub beginTransaction()

    MustOverride Sub commitTransaction()

    MustOverride Sub rollbackTransaction()

    MustOverride Function fillDts(ByVal mySql As String) As DataSet

    MustOverride Function fillDts(ByVal mySql As String, ByVal tableAlias As ArrayList) As DataSet

    MustOverride Sub updateDts(ByVal mySql As String, ByRef dts As DataSet)

    MustOverride Sub callSp(ByVal spName As String, ByVal spParams As Array)

    MustOverride Sub callSp(ByVal spName As String, ByVal ParamArray spParams() As String)

    MustOverride Function callSpResults(ByVal spName As String, ByVal spParams As Array) As DataSet

    MustOverride Function callSpResults(ByVal spName As String, ByVal ParamArray spParams() As String) As DataSet

    MustOverride Function selectSpResults(ByVal spName As String, ByVal spParams As Array) As DataSet

    MustOverride Function selectSpResults(ByVal spName As String, ByVal ParamArray spParams() As String) As DataSet

    MustOverride Sub executeDirect(ByVal mySql As String)

    MustOverride Function executeQuery(ByVal mySql As String) As String

    MustOverride Function ColumnaIgual(Tabla As String, Columna As String, Where As String) As Boolean

End Class
