Imports CustomControls

Public Class ColumnasGruposVehiculos

    Public Function CodigoGrupo() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Grupo"
        col.Campo = "CODIGO"
        col.Name = "CODIGO"
        col.Tabla = "GRU"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function NombreGrupo() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Grupo"
        col.Campo = "NOMBRE"
        col.Name = "NOMBRE"
        col.Tabla = "GRU"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

End Class
