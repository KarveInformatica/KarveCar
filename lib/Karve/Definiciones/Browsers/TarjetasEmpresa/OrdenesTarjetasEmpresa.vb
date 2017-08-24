Imports CustomControls

Public Class OrdenesTarjetasEmpresa
    Public Function OrdenNombreTarjetasEmpresa() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "NOMBRE"
            .Criterio = DataGridOrdenColumna.euCriterio.Asc
            .AliasTabla = "TARE"
            .Campo = "NOMBRE"
        End With
        Return col
    End Function
End Class
