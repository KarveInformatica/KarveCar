Imports CustomControls

Public Class OrdenesVehiculos

    Public Function OrdenMatricula() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "MATRICULA"
            .Campo = "MATRICULA"
            .Criterio = DataGridOrdenColumna.euCriterio.Asc
            .AliasTabla = "V1"
        End With
        Return col
    End Function

End Class
