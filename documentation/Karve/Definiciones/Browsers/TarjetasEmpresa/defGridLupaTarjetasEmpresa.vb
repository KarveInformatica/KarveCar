Public Class defGridLupaTarjetasEmpresa
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As CustomControls.DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim Cols As New Definiciones.ColumnasTarjetasEmpresa

        dgcColumns.Add(Cols.CodigoTarjetasEmpresa)
        dgcColumns.Add(Cols.NombreTarjetasEmpresa)
        dgcColumns.Add(Cols.PrecioTarjetasEmpresa)
        dgcColumns.Add(Cols.PrefijoTarjetasEmpresa)

    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)
        Dim Cols As New Definiciones.OrdenesTarjetasEmpresa
        dgoOrdenes.Add(Cols.OrdenNombreTarjetasEmpresa)
    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As CustomControls.DataGridTable)
        Dim Tbls As New Definiciones.TablasTarjetasEmpresa

        dgtTables.Add(Tbls.TarjetasCreditoFrom)

    End Sub
End Class
