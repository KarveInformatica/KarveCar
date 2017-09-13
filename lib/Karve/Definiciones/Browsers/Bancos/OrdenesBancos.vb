Imports CustomControls

Public Class OrdenesBancos
    Public Function OrdenNomBancosCliente() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "NOMBRE"
            .Criterio = DataGridOrdenColumna.euCriterio.Asc
            .AliasTabla = "BC"
            .Campo = "NOMBRE"
        End With
        Return col
    End Function

End Class
