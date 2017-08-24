Imports CustomControls

Public Class OrdenesBloquesFacturacion
    Public Function OrdenNomBloqueFac() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "NOMBRE"
            .Criterio = DataGridOrdenColumna.euCriterio.Asc
            .AliasTabla = "BLQF"
            .Campo = "NOMBRE"
        End With
        Return col
    End Function

End Class
