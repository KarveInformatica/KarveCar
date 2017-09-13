Imports CustomControls

Public Class OrdenesGruposVehiculos

    Public Function OrdenGruposVehiculos() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "NOMBRE"
            .Criterio = DataGridOrdenColumna.euCriterio.Asc
            .AliasTabla = "GRU"
            .Campo = "NOMBRE"
        End With
        Return col
    End Function

End Class