Imports CustomControls

Public Class OrdenesPais
    Public Function OrdenNombrePais() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "PAIS"
            .Criterio = DataGridOrdenColumna.euCriterio.Asc
            .AliasTabla = "P"
        End With
        Return col
    End Function
    Public Function OrdenCodigoPais() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "CODIGO"
            .Criterio = DataGridOrdenColumna.euCriterio.Asc
            .AliasTabla = "P"
        End With
        Return col
    End Function
End Class
