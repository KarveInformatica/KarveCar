Imports CustomControls

Public Class OrdenesCargosPersonalCliente
    Public Function OrdenNomCanalCliente() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "NOMBRE"
            .Criterio = DataGridOrdenColumna.euCriterio.Asc
            .AliasTabla = "PCC"
            .Campo = "NOMBRE"
        End With
        Return col
    End Function

End Class
