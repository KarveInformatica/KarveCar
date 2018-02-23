Imports CustomControls

Public Class ColumnasOficina

    Public Function CodigoOficina() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Codigo"
        col.AliasCampo = "CODIGO"
        col.Name = "CODIGO"
        col.Tabla = "OFI"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function NombreOficina() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Nombre"
        col.AliasCampo = "NOMBRE"
        col.Name = "NOMBRE"
        col.Tabla = "OFI"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function TelefonoOficina() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Teléfono"
        col.AliasCampo = "TELEFONO"
        col.Name = "TELEFONO"
        col.Tabla = "OFI"
        col.Width = 100
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function EmpresaOficina() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Empresa"
        col.Campo = "NOMBRE"
        col.AliasCampo = "EMPRESA"
        col.Name = "EMPRESA"
        col.Tabla = "EMP"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function DireccionOficina() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Dirección"
        col.AliasCampo = "DIRECCION"
        col.Name = "DIRECCION"
        col.Tabla = "OFI"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function CPOficina() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "CP"
        col.AliasCampo = "CP"
        col.Name = "CP"
        col.Tabla = "OFI"
        col.Width = 80
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function PoblacionOficina() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Población"
        col.AliasCampo = "POBLACION"
        col.Name = "POBLACION"
        col.Tabla = "OFI"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function ProvinciaOficina() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Provincia"
        col.AliasCampo = "PROV"
        col.Name = "PROVINCIA"
        col.Tabla = "PROV"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    Public Function ZonaOficina() As DataGridTextBoxColumn
        Dim col As DataGridTextBoxColumn
        col = New DataGridTextBoxColumn
        col.HeaderText = "Zona"
        col.AliasCampo = "NOM_ZONA"
        col.Name = "ZONA"
        col.Tabla = "ZO"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

End Class
