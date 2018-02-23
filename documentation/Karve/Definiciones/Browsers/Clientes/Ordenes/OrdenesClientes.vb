Imports CustomControls

Public Class OrdenesClientes

    Public Function OrdenNomCliente() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "NOMBRE"
            .Criterio = DataGridOrdenColumna.euCriterio.Asc
            .AliasTabla = "C1"
            .Campo = "NOMBRE"
        End With

        Return col
    End Function

    Public Function OrdenCodCliente() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "NUMERO_CLI"
            .Criterio = DataGridOrdenColumna.euCriterio.Asc
            .AliasTabla = "C1"
            .Campo = "NUMERO_CLI"
        End With

        Return col
    End Function

End Class
