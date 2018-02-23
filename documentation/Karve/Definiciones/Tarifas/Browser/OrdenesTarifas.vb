Imports CustomControls

Public Class OrdenesTarifas

    Public Function OrdenTarifas() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "CODIGO"
            .Criterio = DataGridOrdenColumna.euCriterio.Asc
            .AliasTabla = "NT"
            .Campo = "CODIGO"
        End With
        Return col
    End Function

End Class
