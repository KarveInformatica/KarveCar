Imports CustomControls

Public Class defGridLupaTipoDocumentos
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As CustomControls.DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim Cols As New Definiciones.ColumnasTipoDocumentos

        dgcColumns.Add(Cols.CodigoTipoDocumento)
        dgcColumns.Add(Cols.NombreTipoDocumento)
        dgcColumns.Add(Cols.RTratamientoTipoDocumento)
        dgcColumns.Add(Cols.RVistobuenoTipoDocumento)
        dgcColumns.Add(Cols.RSupervisionTipoDocumento)

    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)

    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As CustomControls.DataGridTable)
        Dim Tbls As New Definiciones.TablasTipoDocumentos

        dgtTables.Add(Tbls.TipoClienteFrom)

    End Sub
End Class
