Imports CustomControls

Public Class ColumnasTiposVisita
    Public Function CodigoTiposVisita() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Codigo"
        col.AliasCampo = "CODIGO_VIS"
        col.Name = "CODIGO_VIS"
        col.Tabla = "TVIS"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function NombreTiposVisita() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Nombre"
        col.AliasCampo = "NOMBRE_VIS"
        col.Name = "NOMBRE_VIS"
        col.Tabla = "TVIS"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function
End Class
