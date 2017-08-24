Imports CustomControls

Public Class ColumnasTarifas

    Public Function CodigoTarifa() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Codigo"
        col.Campo = "CODIGO"
        col.Name = "CODIGO"
        col.Tabla = "NT"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function NombreTarifa() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Nombre"
        col.Campo = "NOMBRE"
        col.Name = "NOMBRE"
        col.Tabla = "NT"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

End Class
