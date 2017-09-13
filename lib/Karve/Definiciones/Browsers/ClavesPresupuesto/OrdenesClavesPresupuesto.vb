Imports CustomControls

Public Class OrdenesClavesPresupuesto
    Public Function OrdenCodClave() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "COD_CLAVE"
            .Criterio = DataGridOrdenColumna.euCriterio.Desc
            .AliasTabla = "CLP"
            .Campo = "COD_CLAVE"
        End With
        Return col
    End Function
End Class