Imports CustomControls

Public Class TablasProDelega

    Public Function CliDelega() As DataGridTable
        Dim tb As New DataGridTable
        tb = New DataGridTable
        tb.Table = "PRODELEGA"
        tb.AliasTabla = "PRD"
        Return tb
    End Function

    Public Function Provincia() As DataGridTable
        Dim tb As New DataGridTable
        tb.Table = "PROVINCIA"
        tb.Criterio = "ON PRD.CLDIDPROVINCIA = PROV.SIGLAS"
        tb.Join = DataGridTable.euCriteriosJoin.LeftJoin
        tb.AliasTabla = "PROV"
        Return tb
    End Function

    'Public Function Pais() As DataGridTable
    '    Dim tb As New DataGridTable
    '    tb.Table = "PAIS"
    '    tb.Criterio = "ON PRD.CLDIDPAIS = P.SIGLAS"
    '    tb.Join = DataGridTable.euCriteriosJoin.LeftJoin
    '    tb.AliasTabla = "P"
    '    Return tb
    'End Function
End Class
