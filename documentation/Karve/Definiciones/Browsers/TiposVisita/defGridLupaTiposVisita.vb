Public Class defGridLupaTiposVisita
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As CustomControls.DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim Cols As New Definiciones.ColumnasTiposVisita

        dgcColumns.Add(Cols.CodigoTiposVisita)
        dgcColumns.Add(Cols.NombreTiposVisita)

    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)
        Dim Cols As New Definiciones.OrdenesTiposVisita

        dgoOrdenes.Add(Cols.OrdenNomTiposVisita)
    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As CustomControls.DataGridTable)
        Dim Tbls As New Definiciones.TablasTiposVisita

        dgtTables.Add(Tbls.TiposVisitaFrom)

    End Sub
End Class
