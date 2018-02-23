Imports CustomControls

Public Class TablasCli

    Public Function Clientes1From() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "CLIENTES1"
        Tb.AliasTabla = "C1"

        Return Tb
    End Function

    Public Function Clientes2() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "CLIENTES2"
        Tb.Criterio = "ON C1.NUMERO_CLI = C2.NUMERO_CLI"
        Tb.Join = DataGridTable.euCriteriosJoin.InnerJoin
        Tb.AliasTabla = "C2"

        Return Tb
    End Function



End Class
