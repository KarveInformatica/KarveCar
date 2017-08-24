Imports CustomControls

Public Class ColumnasProContacto

    Public Function NumeroContacto() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Número"
        col.Name = "Numero"
        col.AliasCampo = "CCOIDCONTACTO"
        col.Tabla = "PRC"
        col.Width = 80
        col.AllowFiltering = True
        col.ReadOnly = True
        col.AllowGroup = False
        Return col
    End Function

    Public Function NombreContacto() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Nombre"
        col.Name = "Nombre"
        col.AliasCampo = "CCOCONTACTO"
        col.Tabla = "PRC"
        col.Width = 200
        col.AllowFiltering = True
        Return col
    End Function

    Public Function CargoContacto() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Cargo"
        col.Name = "Cargo"
        col.AliasCampo = "CCOCARGO"
        col.Tabla = "PRC"
        col.Width = 200
        col.AllowFiltering = True
        Return col
    End Function

    Public Function DepartamentoContacto() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Departamento"
        col.Name = "Departamento"
        col.AliasCampo = "CCODEPTO"
        col.Tabla = "PRC"
        col.Width = 200
        col.AllowFiltering = True
        Return col
    End Function

    Public Function TelefonoContacto() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Teléfono"
        col.Name = "Telefono"
        col.AliasCampo = "CCOTELEFONO"
        col.Tabla = "PRC"
        col.Width = 100
        col.AllowFiltering = True
        Return col
    End Function

    Public Function MovilContacto() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Móvil"
        col.Name = "Movil"
        col.AliasCampo = "CCOMOVIL"
        col.Tabla = "PRC"
        col.Width = 100
        col.AllowFiltering = True
        Return col
    End Function

    Public Function FaxContacto() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Fax"
        col.Name = "Fax"
        col.AliasCampo = "CCOFAX"
        col.Tabla = "PRC"
        col.Width = 100
        col.AllowFiltering = True
        Return col
    End Function

    Public Function EmailContacto() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Email"
        col.Name = "Email"
        col.AliasCampo = "CCOMAIL"
        col.Tabla = "PRC"
        col.Width = 200
        col.AllowFiltering = True
        Return col
    End Function

    Public Function ProveContacto() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Cliente"
        col.Name = "Cliente"
        col.AliasCampo = "CCOIDCLIENTE"
        col.Tabla = "PRC"
        col.AllowFiltering = True
        col.ReadOnly = True
        col.AllowGroup = False
        col.IsVisible = False
        col.VisibleInColumnChooser = False
        Return col
    End Function

End Class
