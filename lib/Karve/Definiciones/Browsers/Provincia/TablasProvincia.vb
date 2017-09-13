Imports CustomControls

Public Class TablasProvincia

    Public Function ProvinciaFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "PROVINCIA"
        Tb.AliasTabla = "PROV"

        Return Tb
    End Function

    Public Function Pais() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "PAIS"
        Tb.Criterio = "ON PROV.PAIS = P.SIGLAS"
        Tb.Join = DataGridTable.euCriteriosJoin.LeftJoin
        Tb.AliasTabla = "P"

        Return Tb
    End Function

End Class
