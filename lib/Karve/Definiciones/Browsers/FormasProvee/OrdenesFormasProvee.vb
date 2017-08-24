Imports CustomControls

Public Class OrdenesFormasProvee

    Public Function OrdenFormasProvee() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "NOMBRE"
            .Criterio = DataGridOrdenColumna.euCriterio.Asc
            .AliasTabla = "FPR"
            .Campo = "NOMBRE"
        End With
        Return col
    End Function

End Class