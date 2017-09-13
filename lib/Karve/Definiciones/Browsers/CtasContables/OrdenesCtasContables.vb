Imports CustomControls

Public Class OrdenesCtasContables

    Public Function OrdenNomCtasContables() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "DESCRIP"
            .Criterio = DataGridOrdenColumna.euCriterio.Asc
            .AliasTabla = "CTA"
            .Campo = "DESCRIP"
        End With
        Return col
    End Function

End Class
