Imports CustomControls

Public Class OrdenesModelosVehiculo
    Public Function OrdenCodModeloVehiculo() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "COD_MOD"
            .Criterio = DataGridOrdenColumna.euCriterio.Desc
            .AliasTabla = "MOD"
            .Campo = "COD_MOD"
        End With
        Return col
    End Function
End Class