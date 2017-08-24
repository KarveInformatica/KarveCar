Public Class defGridLupaTarifas
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As CustomControls.DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim Cols As New Definiciones.ColumnasTarifas

        dgcColumns.Add(Cols.CodigoTarifa)
        dgcColumns.Add(Cols.NombreTarifa)

        colRelation = Cols.CodigoTarifa
    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)
        Dim Cols As New Definiciones.OrdenesTarifas
        dgoOrdenes.Add(Cols.OrdenTarifas)
    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As CustomControls.DataGridTable)
        Dim Tbls As New Definiciones.TablasTarifas

        dgtTables.Add(Tbls.TarifasFrom)


    End Sub
End Class
