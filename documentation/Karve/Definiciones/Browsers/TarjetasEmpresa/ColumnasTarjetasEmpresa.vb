Imports CustomControls

Public Class ColumnasTarjetasEmpresa
    Public Function CodigoTarjetasEmpresa() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Codigo"
        col.AliasCampo = "COD_TARJETA"
        col.Name = "COD_TARJETA"
        col.Tabla = "TARE"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function NombreTarjetasEmpresa() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Nombre"
        col.AliasCampo = "NOMBRE"
        col.Name = "NOMBRE"
        col.Tabla = "TARE"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function
    Public Function PrecioTarjetasEmpresa() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Precio"
        col.AliasCampo = "PRECIO"
        col.Name = "PRECIO"
        col.Tabla = "TARE"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function
    Public Function PrefijoTarjetasEmpresa() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Prefijo"
        col.AliasCampo = "PREFIJO"
        col.Name = "PREFIJO"
        col.Tabla = "TARE"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function
    Public Function CondicionesTarjetasEmpresa() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Condiciones"
        col.AliasCampo = "CONDICIONES"
        col.Name = "CONDICIONES"
        col.Tabla = "TARE"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function
End Class
