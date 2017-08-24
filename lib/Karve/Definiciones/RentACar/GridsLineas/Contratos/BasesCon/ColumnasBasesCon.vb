Imports CustomControls
Imports Karve.ConfiguracionApp

Public Class ColumnasBasesCon

    Public Function BaseBasescon() As DataGridTotalColumn
        Dim col As New DataGridTotalColumn
        col.HeaderText = "Base"
        col.Name = "Base"
        col.Campo = "BASE_BC"
        col.AliasCampo = "BASE"
        col.Tabla = "BC"
        col.Width = 140
        col.ReadOnly = False
        col.AllowFiltering = True
        col.ReadOnly = True
        Return col
    End Function

    Public Function IvaPorBasescon() As DataGridPercentageColumn
        Dim col As New DataGridPercentageColumn
        col.HeaderText = "IVA %"
        col.Name = "Iva"
        col.Campo = "IVAPOR_BC"
        col.AliasCampo = "IVAPOR"
        col.Tabla = "BC"
        col.Width = 75
        Return col
    End Function

    Public Function CuotaBasescon() As DataGridTotalColumn
        Dim col As New DataGridTotalColumn
        col.HeaderText = "Cuota"
        col.Name = "Cuota"
        col.Campo = "CUOTA_BC"
        col.AliasCampo = "CUOTA"
        col.Tabla = "BC"
        col.Width = 100
        col.ReadOnly = True
        Return col
    End Function

    Public Function RecargoBasescon() As DataGridPercentageColumn
        Dim col As New DataGridPercentageColumn
        col.HeaderText = "Rec. Equiv %"
        col.Name = "Recargo"
        col.Campo = "RECARGO_BC"
        col.AliasCampo = "RECARGO"
        col.Tabla = "BC"
        col.Width = 75
        Return col
    End Function

    Public Function CuorecaBasescon() As DataGridTotalColumn
        Dim col As New DataGridTotalColumn
        col.HeaderText = "Cuota Req. Equiv."
        col.Name = "Cuoreca"
        col.Campo = "CUORECA_BC"
        col.AliasCampo = "CUORECA"
        col.Tabla = "BC"
        col.Width = 100
        col.ReadOnly = True
        Return col
    End Function

    Public Function SubtotalBasescon() As DataGridTotalColumn
        Dim col As New DataGridTotalColumn
        col.HeaderText = "Subtotal"
        col.Name = "Subtotal"
        col.Campo = "SUBTOTAL_BC"
        col.AliasCampo = "SUBTOTAL"
        col.Tabla = "BC"
        col.Width = 100
        col.ReadOnly = True
        Return col
    End Function

    Public Function ContratoBasescon() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Contrato"
        col.Name = "Contrato"
        col.Campo = "NUMERO_BC"
        col.AliasCampo = "NUMERO"
        col.Tabla = "BC"
        col.AllowFiltering = True
        col.ReadOnly = True
        col.AllowGroup = False
        col.IsVisible = False
        col.VisibleInColumnChooser = False
        Return col
    End Function

End Class
