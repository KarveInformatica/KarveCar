Imports CustomControls

Public Class TablasFacturas

    Public Function FacturasFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "FACTURAS"
        Tb.AliasTabla = "F"

        Return Tb
    End Function

    Public Function Clientes() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "CLIENTES1"
        Tb.AliasTabla = "CL1"
        Tb.Join = DataGridTable.euCriteriosJoin.InnerJoin
        Tb.Criterio = " ON F.CLIENTE_FAC = CL1.NUMERO_CLI"
        Return Tb
    End Function

End Class
