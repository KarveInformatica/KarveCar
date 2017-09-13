Imports CustomControls

Public Class ColumnasMotivosRepostaje

    Public Function CodigoMotivosRepostaje() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Codigo"
        col.AliasCampo = "COD_MOT"
        col.Name = "COD_MOT"
        col.Tabla = "MOR"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function NombreMotivosRepostaje() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Nombre"
        col.AliasCampo = "NOM_MOT"
        col.Name = "NOM_MOT"
        col.Tabla = "MOR"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

End Class