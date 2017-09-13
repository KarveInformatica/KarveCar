Public Class defGridLupaTiposProvee
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As CustomControls.DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim Cols As New Definiciones.ColumnasTiposProvee

        dgcColumns.Add(Cols.CodigoTiposProvee)
        dgcColumns.Add(Cols.NombreTiposProvee)
        dgcColumns.Add(Cols.CodigoCtaGastoTiposProvee)

    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)
        Dim Cols As New Definiciones.OrdenesTiposProvee
        dgoOrdenes.Add(Cols.OrdenNomTiposProvee)
    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As CustomControls.DataGridTable)
        Dim Tbls As New Definiciones.TablasTiposProvee

        dgtTables.Add(Tbls.TiposVehiculoFrom)

    End Sub
End Class
