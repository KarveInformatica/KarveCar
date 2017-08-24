Imports CustomControls

Public Class defGridLupaOficina
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As CustomControls.DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim Cols As New Definiciones.ColumnasOficina

        dgcColumns.Add(Cols.CodigoOficina)
        dgcColumns.Add(Cols.NombreOficina)
        dgcColumns.Add(Cols.TelefonoOficina)
        dgcColumns.Add(Cols.EmpresaOficina)
        dgcColumns.Add(Cols.DireccionOficina)
        dgcColumns.Add(Cols.CPOficina)
        dgcColumns.Add(Cols.PoblacionOficina)
        dgcColumns.Add(Cols.ZonaOficina)

    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)

    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As CustomControls.DataGridTable)
        Dim Tbls As New Definiciones.TablasOficina

        dgtTables.Add(Tbls.OficinaFrom)
        dgtTables.Add(Tbls.Empresa)
        dgtTables.Add(Tbls.Provincias)
        dgtTables.Add(Tbls.ZonaOfi)
    End Sub
End Class
