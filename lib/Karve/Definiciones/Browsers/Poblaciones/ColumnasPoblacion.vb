Imports CustomControls

Public Class ColumnasPoblacion
    Public Function CodigoPaisPobla() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Código"
        col.Campo = "PAIS"
        col.AliasCampo = "PAIS"
        col.Name = "PAIS"
        col.Tabla = "POBL"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function
    Public Function CPPobla() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "CP"
        col.Campo = "CP"
        col.AliasCampo = "CP"
        col.Name = "CP"
        col.Tabla = "POBL"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function
    Public Function Pobla() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Población"
        col.AliasCampo = "POBLA"
        col.Name = "POBLA"
        col.Tabla = "POBL"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function
End Class
