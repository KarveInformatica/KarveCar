Imports CustomControls

Public Class OrdenesColoresVehiculo

    Public Function OrdenColoresVehiculo() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "NOMBRE"
            .Criterio = DataGridOrdenColumna.euCriterio.Asc
            .AliasTabla = "CLF"
            .Campo = "NOMBRE"
        End With
        Return col
    End Function

End Class
