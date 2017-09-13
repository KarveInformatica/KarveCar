Imports CustomControls

Public Class ColumnasBloquesFacturacion

    Public Function CodigoBloqueFacturacion() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Codigo"
        col.AliasCampo = "CODIGO"
        col.Name = "CODIGO"
        col.Tabla = "BLQF"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function NombreBloqueFacturacion() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Nombre"
        col.AliasCampo = "NOMBRE"
        col.Name = "NOMBRE"
        col.Tabla = "BLQF"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

End Class
