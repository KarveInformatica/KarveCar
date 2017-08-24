Imports CustomControls

Public Class OrdenesContratosRC

    Public Function OrdenFechaSalida() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "FSALIDA_CON1"
            .Campo = "FSALIDA_CON1"
            .Criterio = DataGridOrdenColumna.euCriterio.Desc
            .AliasTabla = "C1"
        End With

        Return col
    End Function

End Class
