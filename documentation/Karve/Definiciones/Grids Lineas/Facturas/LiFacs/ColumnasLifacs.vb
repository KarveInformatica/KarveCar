Imports CustomControls

Public Class ColumnasLifacs

    Public Function LineaLifacs() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = ""
        col.Name = "Linea"
        col.Campo = "LINEA"
        col.Tabla = "LF"
        col.Width = 20
        col.AllowFiltering = False
        col.ReadOnly = True
        col.AllowGroup = False
        col.AllowReorder = False
        col.IsVisible = True
        col.VisibleInColumnChooser = False
        Return col
    End Function

    Public Function ConceptoLifacs() As DataGridBrowseBoxColumn
        Dim col As New DataGridBrowseBoxColumn
        col.HeaderText = "Concepto"
        col.Name = "Concepto"
        col.Campo = "CONCEPTO_LIF"
        col.Tabla = "LF"
        col.Width = 80
        col.AllowFiltering = True

        col.Desc_DBPK = "CODIGO"
        col.Desc_Datafield = "NOMBRE"
        col.Desc_DBTable = "CONCEP_FACTUR"
        Return col
    End Function

    Public Function DescripcionLifacs() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Descripción"
        col.Name = "Descripcion"
        col.Campo = "DESCRIP_LIF"
        col.Tabla = "LF"
        col.Width = 400
        col.ReadOnly = False
        col.AllowFiltering = True
        Return col
    End Function

    Public Function CantidadLifacs() As DataGridQuantityColumn
        Dim col As New DataGridQuantityColumn
        col.HeaderText = "Cantidad"
        col.Name = "Cantidad"
        col.Campo = "CANTIDAD_LIF"
        col.AliasCampo = "CANTIDAD"
        col.Tabla = "LF"
        col.Width = 50
        Return col
    End Function

    Public Function PrecioLifacs() As DataGridPriceColumn
        Dim col As New DataGridPriceColumn
        col.HeaderText = "Precio"
        col.Name = "Precio"
        col.Campo = "PRE_LIF"
        col.AliasCampo = "PRECIO"
        col.Tabla = "LF"
        col.Width = 100
        Return col
    End Function

    Public Function DtoLifacs() As DataGridPercentageColumn
        Dim col As New DataGridPercentageColumn
        col.HeaderText = "DTO %"
        col.Name = "Dto"
        col.Campo = "DTO_LIF"
        col.AliasCampo = "DTO"
        col.Tabla = "LF"
        col.Width = 75
        Return col
    End Function

    Public Function IvaLifacs() As DataGridPercentageColumn
        Dim col As New DataGridPercentageColumn
        col.HeaderText = "IVA %"
        col.Name = "Iva"
        col.Campo = "IVA"
        col.AliasCampo = "IVA"
        col.Tabla = "LF"
        col.Width = 75
        Return col
    End Function

    Public Function SubtotalLifacs() As DataGridPriceColumn
        Dim col As New DataGridPriceColumn
        col.HeaderText = "Subtotal"
        col.Name = "Subtotal"
        col.Campo = "SUBTOTAL_LIF"
        col.AliasCampo = "SUBTOTAL"
        col.Tabla = "LF"
        col.Width = 100
        col.ReadOnly = True
        Return col
    End Function

    Public Function FacturaLifacs() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Factura"
        col.Name = "Factura"
        col.Campo = "NUMERO_LIF"
        col.Tabla = "LF"
        col.AllowFiltering = True
        col.ReadOnly = True
        col.AllowGroup = False
        col.IsVisible = False
        col.VisibleInColumnChooser = False
        Return col
    End Function

    Public Function PKLifacs() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "PK"
        col.Name = "PK"
        col.Campo = "CLAVE_LF"
        col.Tabla = "LF"
        col.AllowFiltering = True
        col.ReadOnly = True
        col.AllowGroup = False
        col.IsVisible = False
        col.VisibleInColumnChooser = False
        Return col
    End Function
End Class
