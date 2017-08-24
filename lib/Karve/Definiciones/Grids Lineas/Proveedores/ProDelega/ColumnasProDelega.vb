Imports CustomControls

Public Class ColumnasProDelega

    Public Function NumeroDelega() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Número"
        col.Name = "Numero"
        col.AliasCampo = "CLDIDDELEGA"
        col.Tabla = "PRD"
        col.Width = 80
        col.AllowFiltering = True
        col.ReadOnly = True
        col.AllowGroup = False
        Return col
    End Function

    Public Function NombreDelega() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Nombre"
        col.Name = "Nombre"
        col.AliasCampo = "CLDDELEGACION"
        col.Tabla = "PRD"
        col.Width = 200
        col.AllowFiltering = True
        Return col
    End Function

    Public Function DireccionDelega() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Direccion"
        col.Name = "Direccion"
        col.AliasCampo = "CLDDIRECCION1"
        col.Tabla = "PRD"
        col.Width = 200
        col.AllowFiltering = True
        Return col
    End Function

    Public Function Direccion2Delega() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Direccion2"
        col.Name = "Direccion2"
        col.AliasCampo = "CLDDIRECCION2"
        col.Tabla = "PRD"
        col.Width = 200
        col.AllowFiltering = True
        Return col
    End Function

    Public Function CPDelega() As DataGridBrowseBoxColumn
        Dim col As New DataGridBrowseBoxColumn
        col.HeaderText = "CP"
        col.Name = "CP"
        col.AliasCampo = "CLDCP"
        col.Tabla = "PRD"
        col.Width = 50
        col.AllowFiltering = True
        Return col
    End Function

    Public Function PoblacionDelega() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Población"
        col.Name = "Poblacion"
        col.AliasCampo = "CLDPOBLACION"
        col.Tabla = "PRD"
        col.Width = 200
        col.AllowFiltering = True
        Return col
    End Function

    Public Function CodigoProvinciaDelega() As DataGridBrowseBoxColumn
        Dim col As New DataGridBrowseBoxColumn
        col.HeaderText = "C.Provincia"
        col.Name = "CodigoProvincia"
        col.AliasCampo = "cldIdProvincia"
        col.Tabla = "PRD"
        col.Width = 100
        col.AllowFiltering = True

        col.Desc_Datafield = "PROV"
        col.Desc_DBTable = "PROVINCIA"
        col.Desc_DBPK = "SIGLAS"
        Return col
    End Function

    Public Function ProvinciaDelega() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Provincia"
        col.Name = "Provincia"
        col.AliasCampo = "PROV"
        col.Tabla = "PROV"
        col.Width = 200
        col.ReadOnly = True
        col.AllowFiltering = True
        Return col
    End Function

    'Public Function CodigoPaisDelega() As DataGridBrowseBoxColumn
    '    Dim col As New DataGridBrowseBoxColumn
    '    col.HeaderText = "C.Pais"
    '    col.Name = "CodigoPais"
    '    col.AliasCampo = "cldIdpais"
    '    col.Tabla = "PRD"
    '    col.Width = 100
    '    col.AllowFiltering = True

    '    col.Desc_Datafield = "PAIS"
    '    col.Desc_DBTable = "PAIS"
    '    col.Desc_DBPK = "SIGLAS"
    '    Return col
    'End Function

    'Public Function PaisDelega() As DataGridTextBoxColumn
    '    Dim col As New DataGridTextBoxColumn
    '    col.HeaderText = "Pais"
    '    col.Name = "Pais"
    '    col.AliasCampo = "PAIS"
    '    col.Tabla = "P"
    '    col.Width = 200
    '    col.AllowFiltering = True
    '    col.ReadOnly = True
    '    Return col
    'End Function

    Public Function ProveDelega() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Cliente"
        col.Name = "Cliente"
        col.AliasCampo = "CLDIDCLIENTE"
        col.Tabla = "PRD"
        col.AllowFiltering = True
        col.ReadOnly = True
        col.AllowGroup = False
        col.IsVisible = False
        col.VisibleInColumnChooser = False
        Return col
    End Function

End Class
