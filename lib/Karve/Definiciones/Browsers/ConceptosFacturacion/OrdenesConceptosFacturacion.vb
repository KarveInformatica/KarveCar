Imports CustomControls

Public Class OrdenesConceptosFacturacion
    Public Function OrdenNombreConcepto() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "NOMBRE"
            .Criterio = DataGridOrdenColumna.euCriterio.Asc
            .AliasTabla = "COF"
        End With
        Return col
    End Function
    Public Function OrdenCodigoConcepto() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "CODIGO"
            .Criterio = DataGridOrdenColumna.euCriterio.Asc
            .AliasTabla = "COF"
        End With
        Return col
    End Function
End Class
