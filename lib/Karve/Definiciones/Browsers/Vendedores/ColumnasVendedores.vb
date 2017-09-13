Imports CustomControls

Public Class ColumnasVendedores
    Public Function CodigoVendedor() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Código"
        col.AliasCampo = "NUM_VENDE"
        col.Name = "NUM_VENDE"
        col.Campo = "NUM_VENDE"
        col.Tabla = "VEND"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function
    Public Function NombreVendedor() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Nombre"
        col.AliasCampo = "NOMBRE"
        col.Name = "NOMBRE"
        col.Campo = "NOMBRE"
        col.Tabla = "VEND"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function
    Public Function TelefonoVendedor() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Teléfono"
        col.AliasCampo = "TELEFONO"
        col.Name = "TELEFONO"
        col.Campo = "TELEFONO"
        col.Tabla = "VEND"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function
    Public Function MovilVendedor() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Móvil"
        col.AliasCampo = "MOVIL"
        col.Name = "MOVIL"
        col.Campo = "MOVIL"
        col.Tabla = "VEND"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function
    Public Function FBajaVendedor() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Fecha Baja"
        col.AliasCampo = "FECHABAJA"
        col.Name = "FECHABAJA"
        col.Campo = "FECHABAJA"
        col.Tabla = "VEND"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function
End Class
