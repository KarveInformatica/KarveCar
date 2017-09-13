Imports CustomControls

Public Class TablasVehiculos

    Public Function Vehiculo1From() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "VEHICULO1"
        Tb.AliasTabla = "V1"

        Return Tb
    End Function

    Public Function Vehiculo2() As DataGridTable
        Dim Tb As DataGridTable
        Tb = New DataGridTable
        Tb.Table = "VEHICULO2"
        Tb.AliasTabla = "V2"
        Tb.Criterio = "ON V1.CODIINT = V2.CODIINT"
        Tb.Join = DataGridTable.euCriteriosJoin.InnerJoin
        Tb.AliasTabla = "V2"
        Return Tb
    End Function

End Class
