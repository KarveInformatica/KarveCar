Imports CustomControls

Public Class ColumnasBasesfac

    Public Function BaseBasesfac() As DataGridTotalColumn
        Dim col As New DataGridTotalColumn
        col.HeaderText = "Base"
        col.Name = "Base"
        col.Campo = "BASE_BF"
        col.AliasCampo = "BASE"
        col.Tabla = "BF"
        col.Width = 400
        col.ReadOnly = False
        col.AllowFiltering = True
        col.ReadOnly = True
        Return col
    End Function

    Public Function IvaPorBasesfac() As DataGridPercentageColumn
        Dim col As New DataGridPercentageColumn
        col.HeaderText = "IVA %"
        col.Name = "Iva"
        col.Campo = "IVAPOR_BF"
        col.AliasCampo = "IVAPOR"
        col.Tabla = "BF"
        col.Width = 75
        Return col
    End Function

    Public Function CuotaBasesfac() As DataGridTotalColumn
        Dim col As New DataGridTotalColumn
        col.HeaderText = "Cuota"
        col.Name = "Cuota"
        col.Campo = "CUOTA_BF"
        col.AliasCampo = "CUOTA"
        col.Tabla = "BF"
        col.Width = 100
        col.ReadOnly = True
        Return col
    End Function

    Public Function RecargoBasesfac() As DataGridPercentageColumn
        Dim col As New DataGridPercentageColumn
        col.HeaderText = "Rec. Equiv %"
        col.Name = "Recargo"
        col.Campo = "RECARGO_BF"
        col.AliasCampo = "RECARGO"
        col.Tabla = "BF"
        col.Width = 75
        Return col
    End Function

    Public Function CuorecaBasesfac() As DataGridTotalColumn
        Dim col As New DataGridTotalColumn
        col.HeaderText = "Cuota Req. Equiv."
        col.Name = "Cuoreca"
        col.Campo = "CUORECA_BF"
        col.AliasCampo = "CUORECA"
        col.Tabla = "BF"
        col.Width = 100
        col.ReadOnly = True
        Return col
    End Function

    Public Function SubtotalBasesfac() As DataGridTotalColumn
        Dim col As New DataGridTotalColumn
        col.HeaderText = "Subtotal"
        col.Name = "Subtotal"
        col.Campo = "SUBTOTAL_BF"
        col.AliasCampo = "SUBTOTAL"
        col.Tabla = "BF"
        col.Width = 100
        col.ReadOnly = True
        Return col
    End Function

    Public Function FacturaBasesfac() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Factura"
        col.Name = "Factura"
        col.Campo = "NUMERO_BF"
        col.AliasCampo = "NUMERO"
        col.Tabla = "BF"
        col.AllowFiltering = True
        col.ReadOnly = True
        col.AllowGroup = False
        col.IsVisible = False
        col.VisibleInColumnChooser = False
        Return col
    End Function

End Class
