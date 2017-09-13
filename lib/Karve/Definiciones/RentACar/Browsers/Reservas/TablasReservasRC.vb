Imports CustomControls

Public Class TablasReservasRC

    Public Function Reservas1From() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "RESERVAS1"
        Tb.AliasTabla = "R1"
        Tb.Name = "Reservas1"
        Return Tb
    End Function

    Public Function Reservas2() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "RESERVAS2"
        Tb.AliasTabla = "R2"
        Tb.Join = DataGridTable.euCriteriosJoin.InnerJoin
        Tb.Criterio = " ON R1.NUMERO_RES = R2.NUMERO_RES"
        Tb.Name = "Contratos2"
        Return Tb
    End Function

    Public Function Oficinas() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "OFICINAS"
        Tb.AliasTabla = "OFI"
        Tb.Join = DataGridTable.euCriteriosJoin.InnerJoin
        Tb.Criterio = " ON R1.OFICINA_RES1 = OFI.CODIGO"
        Tb.Name = "Oficinas"
        Return Tb
    End Function

    Public Function Clientes() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "CLIENTES1"
        Tb.AliasTabla = "CL1"
        Tb.Join = DataGridTable.euCriteriosJoin.LeftJoin
        Tb.Criterio = " ON R1.CLIENTE_RES1 = CL1.NUMERO_CLI"
        Tb.Name = "Clientes1"
        Return Tb
    End Function

End Class
