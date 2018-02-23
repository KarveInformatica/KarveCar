Imports CustomControls
Imports Karve.ConfiguracionApp

Public Class ColumnasBasesRes

    Public Function BaseBasesRes() As DataGridTotalColumn
        Dim col As New DataGridTotalColumn
        col.HeaderText = "Base"
        col.Name = "Base"
        col.Campo = "BASE_BR"
        col.AliasCampo = "BASE"
        col.Tabla = "BR"
        col.Width = 140
        col.ReadOnly = False
        col.AllowFiltering = True
        col.ReadOnly = True
        Return col
    End Function

    Public Function IvaPorBasesRes() As DataGridPercentageColumn
        Dim col As New DataGridPercentageColumn
        col.HeaderText = "IVA %"
        col.Name = "Iva"
        col.Campo = "IVAPOR_BR"
        col.AliasCampo = "IVAPOR"
        col.Tabla = "BR"
        col.Width = 75
        Return col
    End Function

    Public Function CuotaBasesRes() As DataGridTotalColumn
        Dim col As New DataGridTotalColumn
        col.HeaderText = "Cuota"
        col.Name = "Cuota"
        col.Campo = "CUOTA_BR"
        col.AliasCampo = "CUOTA"
        col.Tabla = "BR"
        col.Width = 100
        col.ReadOnly = True
        Return col
    End Function

    Public Function RecargoBasesRes() As DataGridPercentageColumn
        Dim col As New DataGridPercentageColumn
        col.HeaderText = "Rec. Equiv %"
        col.Name = "Recargo"
        col.Campo = "RECARGO_BR"
        col.AliasCampo = "RECARGO"
        col.Tabla = "BR"
        col.Width = 75
        Return col
    End Function

    Public Function CuorecaBasesRes() As DataGridTotalColumn
        Dim col As New DataGridTotalColumn
        col.HeaderText = "Cuota Req. Equiv."
        col.Name = "Cuoreca"
        col.Campo = "CUORECA_BR"
        col.AliasCampo = "CUORECA"
        col.Tabla = "BR"
        col.Width = 100
        col.ReadOnly = True
        Return col
    End Function

    Public Function SubtotalBasesRes() As DataGridTotalColumn
        Dim col As New DataGridTotalColumn
        col.HeaderText = "Subtotal"
        col.Name = "Subtotal"
        col.Campo = "SUBTOTAL_BR"
        col.AliasCampo = "SUBTOTAL"
        col.Tabla = "BR"
        col.Width = 100
        col.ReadOnly = True
        Return col
    End Function

    Public Function ReservaBasesRes() As DataGridTextBoxColumn
        Dim col As New DataGridTextBoxColumn
        col.HeaderText = "Reserva"
        col.Name = "Reserva"
        col.Campo = "NUMERO_BR"
        col.AliasCampo = "NUMERO"
        col.Tabla = "BR"
        col.AllowFiltering = True
        col.ReadOnly = True
        col.AllowGroup = False
        col.IsVisible = False
        col.VisibleInColumnChooser = False
        Return col
    End Function

End Class
