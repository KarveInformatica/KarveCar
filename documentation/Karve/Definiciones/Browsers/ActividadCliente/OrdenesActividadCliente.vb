Imports CustomControls

Public Class OrdenesActividadCliente

    Public Function OrdenNomActividad() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "NOMBRE"
            .Criterio = DataGridOrdenColumna.euCriterio.Asc
            .AliasTabla = "ATC"
            .Campo = "NOMBRE"
        End With

        Return col
    End Function

End Class
