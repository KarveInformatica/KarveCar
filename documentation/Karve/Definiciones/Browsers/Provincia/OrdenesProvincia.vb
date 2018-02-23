Imports CustomControls

Public Class OrdenesProvincia
    Public Function OrdenCodigoProvincia() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "SIGLAS"
            .Criterio = DataGridOrdenColumna.euCriterio.Asc
            .AliasTabla = "PROV"
        End With
        Return col
    End Function
End Class
