Imports CustomControls

Public Class ColumnasZonas

    Public Function CodigoZona() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Codigo"
        col.AliasCampo = "NUM_ZONA"
        col.Name = "NUM_ZONA"
        col.Tabla = "ZN"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function NombreZona() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Nombre"
        col.AliasCampo = "NOMBRE"
        col.Name = "NOMBRE"
        col.Tabla = "ZN"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function BajaZona() As DataGridDateColumn
        Dim col As DataGridDateColumn
        col = New DataGridDateColumn
        col.HeaderText = "F.Baja"
        col.AliasCampo = "BAJAZONA"
        col.Name = "BAJAZONA"
        col.Tabla = "ZN"
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

End Class
