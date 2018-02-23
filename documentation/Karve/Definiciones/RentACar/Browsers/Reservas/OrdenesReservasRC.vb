Imports CustomControls

Public Class OrdenesReservasRC

    Public Function OrdenFechaSalida() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "FSALIDA_RES1"
            .Campo = "FSALIDA_RES1"
            .Criterio = DataGridOrdenColumna.euCriterio.Desc
            .AliasTabla = "R1"
        End With

        Return col
    End Function

End Class
