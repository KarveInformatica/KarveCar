Imports CustomControls

Public Class OrdenesExtrasMod
    Public Function OrdenesExtrasMod() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "CODIGO_EV"
            .Criterio = DataGridOrdenColumna.euCriterio.Asc
            .AliasTabla = "MEV"
        End With
        Return col
    End Function

End Class
