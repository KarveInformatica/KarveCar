Imports CustomControls

Public Class OrdenesTiposVisita
    Public Function OrdenNomTiposVisita() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "NOMBRE_VIS"
            .Criterio = DataGridOrdenColumna.euCriterio.Asc
            .AliasTabla = "TVIS"
        End With
        Return col
    End Function
End Class
