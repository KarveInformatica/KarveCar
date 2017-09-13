Imports CustomControls

Public Class defGridLupaFacturas
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As CustomControls.DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim Cols As New Definiciones.ColumnasFacturas

        dgcColumns.Add(Cols.CodigoFacturas)
        dgcColumns.Add(Cols.FechaFacturas)
        dgcColumns.Add(Cols.ReferenciaFacturas)
        dgcColumns.Add(Cols.ClienteFacturas)
        dgcColumns.Add(Cols.NomClienteFacturas)
        dgcColumns.Add(Cols.EmpFacturas)
        dgcColumns.Add(Cols.OfiFacturas)
        dgcColumns.Add(Cols.ContraFacturas)
        dgcColumns.Add(Cols.AsientoFacturas)
        dgcColumns.Add(Cols.UsuModiFacturas)
        dgcColumns.Add(Cols.UltModiFacturas)

        colRelation = Cols.CodigoFacturas
    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)
        Dim Cols As New Definiciones.OrdenesFacturas
        dgoOrdenes.Add(Cols.OrdenFechaFactura)
        dgoOrdenes.Add(Cols.OrdenCodFactura)
    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As CustomControls.DataGridTable)
        Dim Tbls As New Definiciones.TablasFacturas

        dgtTables.Add(Tbls.FacturasFrom)
        dgtTables.Add(Tbls.Clientes)

    End Sub

End Class
