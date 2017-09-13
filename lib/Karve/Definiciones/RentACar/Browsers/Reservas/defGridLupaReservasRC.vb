Imports CustomControls

Public Class defGridLupaReservasRC
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As CustomControls.DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim Cols As New Definiciones.ColumnasReservasRC

        dgcColumns.Add(Cols.NumeroReserva)
        dgcColumns.Add(Cols.FCreaReserva)
        dgcColumns.Add(Cols.LocalizadorReserva)
        dgcColumns.Add(Cols.OSalReserva)
        dgcColumns.Add(Cols.ConductorReserva)
        dgcColumns.Add(Cols.ClienteReserva)
        dgcColumns.Add(Cols.NomClienteReserva)
        dgcColumns.Add(Cols.FSalidaReserva)
        dgcColumns.Add(Cols.LuEntregaReserva)
        dgcColumns.Add(Cols.FPrevReserva)
        dgcColumns.Add(Cols.LuDevoReserva)
        dgcColumns.Add(Cols.GrupoReserva)
        dgcColumns.Add(Cols.TarifaReserva)

        colRelation = Cols.NumeroReserva
    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)
        Dim Cols As New Definiciones.OrdenesReservasRC
        dgoOrdenes.Add(Cols.OrdenFechaSalida)
    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As CustomControls.DataGridTable)
        Dim Tbls As New Definiciones.TablasReservasRC

        dgtTables.Add(Tbls.Reservas1From)
        dgtTables.Add(Tbls.Reservas2)
        dgtTables.Add(Tbls.Oficinas)
        dgtTables.Add(Tbls.Clientes)

    End Sub
End Class
