Imports CustomControls

Public Class OrdenesProvee

    Public Function OrdenNumProvee() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "NUM_PROVEE"
            .Criterio = DataGridOrdenColumna.euCriterio.Desc
            .AliasTabla = "P1"
            .Campo = "NUM_PROVEE"
        End With

        Return col
    End Function

End Class
