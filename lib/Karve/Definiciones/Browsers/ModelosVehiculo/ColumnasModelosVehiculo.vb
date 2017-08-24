Imports CustomControls

Public Class ColumnasModelosVehiculo

    Public Function CodigoModelosVehiculo() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Codigo"
        col.AliasCampo = "COD_MOD"
        col.Name = "COD_MOD"
        col.Tabla = "MOD"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function CodMarModelosVehiculo() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Marca"
        col.AliasCampo = "MARCA"
        col.Name = "MARCA"
        col.Tabla = "MOD"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function NombreModelosVehiculo() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Nombre"
        col.AliasCampo = "NOMBRE"
        col.Name = "NOMBRE"
        col.Tabla = "MOD"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function ModeloModelosVehiculo() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Modelo"
        col.AliasCampo = "CODIGO"
        col.Name = "CODIGO"
        col.Tabla = "MOD"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = False
        col.VisibleInColumnChooser = False
        col.IsVisible = False
        Return col
    End Function

    Public Function VarianteModelosVehiculo() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Variante"
        col.AliasCampo = "VARIANTE"
        col.Name = "VARIANTE"
        col.Tabla = "MOD"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = False
        col.VisibleInColumnChooser = False
        col.IsVisible = False
        Return col
    End Function

End Class