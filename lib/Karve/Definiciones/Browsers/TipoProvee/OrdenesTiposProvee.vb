Imports CustomControls

Public Class OrdenesTiposProvee

    Public Function OrdenNomTiposProvee() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "NOMBRE"
            .Criterio = DataGridOrdenColumna.euCriterio.Asc
            .AliasTabla = "TPR"
            .Campo = "NOMBRE"
        End With
        Return col
    End Function

End Class
