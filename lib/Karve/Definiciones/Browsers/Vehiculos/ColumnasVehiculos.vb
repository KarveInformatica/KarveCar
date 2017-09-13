Imports CustomControls

Public Class ColumnasVehiculos

    Public Function CodigoVehiculo() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Codigo"
        col.AliasCampo = "CODIINT"
        col.Name = "CODIINT"
        col.Campo = "CODIINT"
        col.Tabla = "V1"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function MatriculaVehiculo() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Matricula"
        col.AliasCampo = "MATRICULA"
        col.Name = "MATRICULA"
        col.Tabla = "V1"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function MarcaVehiculo() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Marca"
        col.AliasCampo = "MARCA"
        col.Name = "MARCA"
        col.Tabla = "V1"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function ModeloVehiculo() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Modelo"
        col.AliasCampo = "MODELO"
        col.Name = "MODELO"
        col.Tabla = "V1"
        col.Width = 250
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function GrupoVehiculo() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Grupo"
        col.AliasCampo = "GRUPO"
        col.Name = "GRUPO"
        col.Tabla = "V1"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function ActividadVehiculo() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Actividad"
        col.AliasCampo = "ACTIVIDAD"
        col.Name = "ACTIVIDAD"
        col.Tabla = "V1"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function SituacionVehiculo() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Sit."
        col.AliasCampo = "SITUACION"
        col.Name = "SITUACION"
        col.Tabla = "V1"
        col.Width = 60
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function OficinaVehiculo() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Ofi."
        col.AliasCampo = "OFICINA"
        col.Name = "SITUACION"
        col.Tabla = "V2"
        col.Width = 60
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

End Class
