Imports CustomControls

Public Class OrdenesIdiomas

    Public Function OrdenNomIdiomas() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "NOMBRE"
            .Criterio = DataGridOrdenColumna.euCriterio.Asc
            .AliasTabla = "IDI"
            .Campo = "NOMBRE"
        End With
        Return col
    End Function

End Class
