Imports CustomControls

Public Class OrdenesFacturas

    Public Function OrdenFechaFactura() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "FECHA_FAC"
            .Criterio = DataGridOrdenColumna.euCriterio.Desc
            .AliasTabla = "F"
            .Campo = "FECHA_FAC"
        End With

        Return col
    End Function

    Public Function OrdenCodFactura() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "NUMERO_FAC"
            .Criterio = DataGridOrdenColumna.euCriterio.Asc
            .AliasTabla = "F"
            .Campo = "NUMERO_FAC"
        End With

        Return col
    End Function
End Class
