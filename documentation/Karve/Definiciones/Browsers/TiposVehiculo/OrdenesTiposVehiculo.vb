Imports CustomControls

Public Class OrdenesTiposVehiculo

    Public Function OrdenNomTiposVehiculo() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "NOMBRE"
            .Criterio = DataGridOrdenColumna.euCriterio.Asc
            .AliasTabla = "CAT"
            .Campo = "NOMBRE"
        End With
        Return col
    End Function

End Class
