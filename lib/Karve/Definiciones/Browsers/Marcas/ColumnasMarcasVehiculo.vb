Imports CustomControls

Public Class ColumnasMarcasVehiculo

    Public Function CodigoMarcasVehiculo() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Codigo"
        col.AliasCampo = "CODIGO"
        col.Name = "CODIGO"
        col.Tabla = "MAR"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function NombreMarcasVehiculo() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Nombre"
        col.AliasCampo = "NOMBRE"
        col.Name = "NOMBRE"
        col.Tabla = "MAR"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function FBajaMarcasVehiculo() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Baja"
        col.Name = "FBAJA"
        col.Tabla = "MAR"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

End Class
