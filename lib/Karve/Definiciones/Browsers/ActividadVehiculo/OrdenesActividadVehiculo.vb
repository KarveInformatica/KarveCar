Imports CustomControls

Public Class OrdenesActividadVehiculo
    Public Function OrdenNomActividad() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "NOMBRE"
            .Criterio = DataGridOrdenColumna.euCriterio.Asc
            .AliasTabla = "ATV"
            .Campo = "NOMBRE"
        End With

        Return col
    End Function
End Class
