Imports CustomControls

Public Class ColumnasLicon

    Public Function ConceptoLicon() As DataGridBrowseBoxColumn
        Dim col As New DataGridBrowseBoxColumn
        col.HeaderText = "Concepto"
        col.Name = "Concepto"
        col.Campo = "CONCEPTO"
        col.Tabla = "LC"
        col.Width = 55
        col.AllowFiltering = True

        col.Desc_DBPK = "CODIGO"
        col.Desc_Datafield = "NOMBRE"
        col.Desc_DBTable = "CONCEP_FACTUR"
        Return col
    End Function

    Public Function DescripcionLiCon() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Descripción"
        col.Name = "Descripcion"
        col.Campo = "DESCCON"
        col.Tabla = "LC"
        col.Width = 140
        col.ReadOnly = False
        col.AllowFiltering = True
        Return col
    End Function

    Public Function IncluidoLicon() As DataGridCheckBoxColumn
        Dim col As New DataGridCheckBoxColumn
        col.HeaderText = "I"
        col.Name = "Incluido"
        col.Campo = "INCLUIDO"
        col.Tabla = "LC"
        col.Width = 20
        col.ReadOnly = False
        col.AllowFiltering = True
        Return col
    End Function

    Public Function UnidadLiCon() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Unidad"
        col.Name = "Unidad"
        col.Campo = "UNIDAD"
        col.Tabla = "LC"
        col.Width = 41
        col.ReadOnly = False
        col.AllowFiltering = True
        Return col
    End Function

    Public Function CantidadLiCon() As DataGridQuantityColumn
        Dim col As New DataGridQuantityColumn
        col.HeaderText = "Cantidad"
        col.Name = "Cantidad"
        col.Campo = "CANTIDAD"
        col.AliasCampo = "CANTIDAD"
        col.Tabla = "LC"
        col.Width = 50
        Return col
    End Function

    Public Function PrecioLiCon() As DataGridPriceColumn
        Dim col As New DataGridPriceColumn
        col.HeaderText = "Precio"
        col.Name = "Precio"
        col.Campo = "PRECIO"
        col.AliasCampo = "PRECIO"
        col.Tabla = "LC"
        col.Width = 85
        Return col
    End Function

    Public Function DtoLiCon() As DataGridPercentageColumn
        Dim col As New DataGridPercentageColumn
        col.HeaderText = "DTO %"
        col.Name = "Dto"
        col.Campo = "DTO"
        col.AliasCampo = "DTO"
        col.Tabla = "LC"
        col.Width = 53
        Return col
    End Function

    Public Function IvaLiCon() As DataGridPercentageColumn
        Dim col As New DataGridPercentageColumn
        col.HeaderText = "IVA %"
        col.Name = "Iva"
        col.Campo = "IVA"
        col.AliasCampo = "IVA"
        col.Tabla = "LC"
        col.Width = 47
        Return col
    End Function

    Public Function SubtotalLiCon() As DataGridPriceColumn
        Dim col As New DataGridPriceColumn
        col.HeaderText = "Subtotal"
        col.Name = "Subtotal"
        col.Campo = "SUBTOTAL"
        col.AliasCampo = "SUBTOTAL"
        col.Tabla = "LC"
        col.Width = 90
        col.ReadOnly = True
        Return col
    End Function

    Public Function ContratoLiCon() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Contrato"
        col.Name = "Contrato"
        col.Campo = "NUMERO"
        col.AliasCampo = "NUMERO"
        col.Tabla = "LC"
        col.AllowFiltering = True
        col.ReadOnly = True
        col.AllowGroup = False
        col.IsVisible = False
        col.VisibleInColumnChooser = False
        Return col
    End Function

    Public Function PKLiCon() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "PK"
        col.Name = "PK"
        col.Campo = "CLAVE_LC"
        col.Tabla = "LC"
        col.AllowFiltering = True
        col.ReadOnly = True
        col.AllowGroup = False
        col.IsVisible = False
        col.VisibleInColumnChooser = False
        Return col
    End Function

    Public Function GruposLiCon() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Grupo"
        col.Name = "Grupo"
        col.Campo = "GRUPO"
        col.AliasCampo = "GRUPO"
        col.Tabla = "LC"
        col.AllowFiltering = True
        col.ReadOnly = True
        col.AllowGroup = False
        col.IsVisible = False
        col.VisibleInColumnChooser = False
        Return col
    End Function

    Public Function TarifasLiCon() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Tarifa"
        col.Name = "Tarifa"
        col.Campo = "TARIFA"
        col.AliasCampo = "TARIFA"
        col.Tabla = "LC"
        col.AllowFiltering = True
        col.ReadOnly = True
        col.AllowGroup = False
        col.IsVisible = False
        col.VisibleInColumnChooser = False
        Return col
    End Function

End Class
