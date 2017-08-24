Imports CustomControls

Public Class OrdenesTarjetasCredito
    Public Function OrdenNomTarjetasCredito() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "NOMBRE"
            .Criterio = DataGridOrdenColumna.euCriterio.Asc
            .AliasTabla = "TAC"
            .Campo = "NOMBRE"
        End With
        Return col
    End Function

End Class
