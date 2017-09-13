Imports CustomControls

Public Class OrdenesMarcasVehiculo

    Public Function OrdenNomTiposVehiculo() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "NOMBRE"
            .Criterio = DataGridOrdenColumna.euCriterio.Asc
            .AliasTabla = "MAR"
            .Campo = "NOMBRE"
        End With
        Return col
    End Function

End Class
