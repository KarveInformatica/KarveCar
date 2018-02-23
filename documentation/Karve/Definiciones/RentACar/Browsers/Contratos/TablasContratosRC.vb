Imports CustomControls

Public Class TablasContratosRC

    Public Function ContratosFrom() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "CONTRATOS1"
        Tb.AliasTabla = "C1"
        Tb.Name = "Contratos1"
        Return Tb
    End Function

    Public Function Contratos2() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "CONTRATOS2"
        Tb.AliasTabla = "C2"
        Tb.Join = DataGridTable.euCriteriosJoin.InnerJoin
        Tb.Criterio = " ON C1.NUMERO = C2.NUMERO"
        Tb.Name = "Contratos2"
        Return Tb
    End Function

    Public Function Contratos4() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "CONTRATOS4"
        Tb.AliasTabla = "C4"
        Tb.Join = DataGridTable.euCriteriosJoin.InnerJoin
        Tb.Criterio = " ON C1.NUMERO = C4.NUMERO"
        Tb.Name = "Contratos4"
        Return Tb
    End Function

    Public Function Oficinas() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "OFICINAS"
        Tb.AliasTabla = "OFI"
        Tb.Join = DataGridTable.euCriteriosJoin.InnerJoin
        Tb.Criterio = " ON C1.OFICINA_CON1 = OFI.CODIGO"
        Tb.Name = "Oficinas"
        Return Tb
    End Function

    Public Function Clientes() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "CLIENTES1"
        Tb.AliasTabla = "CL1"
        Tb.Join = DataGridTable.euCriteriosJoin.InnerJoin
        Tb.Criterio = " ON C1.CLIENTE_CON1 = CL1.NUMERO_CLI"
        Tb.Name = "Clientes1"
        Return Tb
    End Function

    Public Function Conductores() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "CLIENTES1"
        Tb.AliasTabla = "COND1"
        Tb.Join = DataGridTable.euCriteriosJoin.LeftJoin
        Tb.Criterio = " ON C1.CLIENTE_CON1 = COND1.NUMERO_CLI"
        Tb.Name = "Conductor1"
        Return Tb
    End Function

    Public Function Comisionistas() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "COMISIO"
        Tb.AliasTabla = "COMI"
        Tb.Join = DataGridTable.euCriteriosJoin.LeftJoin
        Tb.Criterio = " ON C2.COMISIO_CON2 = COMI.NUM_COMI"
        Tb.Name = "Comisionistas"
        Return Tb
    End Function

End Class
