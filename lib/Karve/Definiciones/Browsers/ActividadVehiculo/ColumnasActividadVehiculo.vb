Imports CustomControls

Public Class ColumnasActividadVehiculo

    Public Function CodigoActividadVehiculo() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Codigo"
        col.AliasCampo = "NUM_ACTIVEHI"
        col.Name = "NUM_ACTIVEHI"
        col.Tabla = "ATV"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function NombreActividadVehiculo() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Nombre"
        col.AliasCampo = "NOMBRE"
        col.Name = "NOMBRE"
        col.Tabla = "ATV"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function CalcOcupaActividadVehiculo() As DataGridCheckBoxColumn
        Dim col As DataGridCheckBoxColumn
        col = New DataGridCheckBoxColumn
        col.HeaderText = "Calc.Ocupa."
        col.AliasCampo = "CALCULO"
        col.Name = "CALCULO"
        col.Tabla = "ATV"
        col.Width = 100
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function ActAlqActividadVehiculo() As DataGridCheckBoxColumn
        Dim col As DataGridCheckBoxColumn
        col = New DataGridCheckBoxColumn
        col.HeaderText = "Act.Alq."
        col.AliasCampo = "ACTIVI_ALQ"
        col.Name = "ACTIVI_ALQ"
        col.Tabla = "ATV"
        col.Width = 100
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function CodTariActActividadVehiculo() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Nombre"
        col.AliasCampo = "TARI_ACT"
        col.Name = "TARI_ACT"
        col.Tabla = "ATV"
        col.Width = 100
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

End Class
