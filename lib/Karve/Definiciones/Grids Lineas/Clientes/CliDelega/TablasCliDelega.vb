Imports CustomControls

Public Class TablasCliDelega

    Public Function CliDelega() As DataGridTable
        Dim tb As New DataGridTable
        tb = New DataGridTable
        tb.Table = "CLIDELEGA"
        tb.AliasTabla = "CLD"
        Return tb
    End Function

    Public Function Provincia() As DataGridTable
        Dim tb As New DataGridTable
        tb.Table = "PROVINCIA"
        tb.Criterio = "ON CLD.CLDIDPROVINCIA = PROV.SIGLAS"
        tb.Join = DataGridTable.euCriteriosJoin.LeftJoin
        tb.AliasTabla = "PROV"
        Return tb
    End Function

    Public Function Pais() As DataGridTable
        Dim tb As New DataGridTable
        tb.Table = "PAIS"
        tb.Criterio = "ON CLD.CLDIDPAIS = P.SIGLAS"
        tb.Join = DataGridTable.euCriteriosJoin.LeftJoin
        tb.AliasTabla = "P"
        Return tb
    End Function
End Class
