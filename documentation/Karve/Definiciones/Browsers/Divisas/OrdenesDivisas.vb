Imports CustomControls

Public Class OrdenesDivisas
    Public Function OrdenNombreDivisas() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "NOMBRE"
            .Criterio = DataGridOrdenColumna.euCriterio.Asc
            .AliasTabla = "DIVI"
            .Campo = "NOMBRE"
        End With
        Return col
    End Function
End Class
