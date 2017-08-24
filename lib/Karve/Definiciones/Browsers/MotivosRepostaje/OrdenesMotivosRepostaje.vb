Imports CustomControls

Public Class OrdenesMotivosRepostaje
    Public Function OrdenCodMotivosRepostaje() As DataGridOrdenColumna
        Dim col As DataGridOrdenColumna
        col = New DataGridOrdenColumna
        With col
            .Name = "NOM_MOT"
            .Criterio = DataGridOrdenColumna.euCriterio.Desc
            .AliasTabla = "MOR"
            .Campo = "NOM_MOT"
        End With
        Return col
    End Function
End Class