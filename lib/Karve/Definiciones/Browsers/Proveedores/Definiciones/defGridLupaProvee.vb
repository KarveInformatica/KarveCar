Imports CustomControls

Public Class defGridLupaProvee
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim Cols As New Definiciones.ColumnasProvee

        dgcColumns.Add(Cols.NumeroProvee)
        dgcColumns.Add(Cols.NombreProvee)
        dgcColumns.Add(Cols.NifProvee)
        dgcColumns.Add(Cols.ComercialProvee)
        dgcColumns.Add(Cols.TelefonoProvee)
        dgcColumns.Add(Cols.DireccionProvee)
        dgcColumns.Add(Cols.CPProvee)
        dgcColumns.Add(Cols.PoblacionProvee)
        dgcColumns.Add(Cols.NombreTipoProvee)
        dgcColumns.Add(Cols.FAeatProvee)
        dgcColumns.Add(Cols.EmailProvee)
        dgcColumns.Add(Cols.FPagoNomProvee)
        dgcColumns.Add(Cols.CtaProvee)
        dgcColumns.Add(Cols.CtaGastoProvee)
        dgcColumns.Add(Cols.PlazoProvee)
        dgcColumns.Add(Cols.Plazo2Provee)
        dgcColumns.Add(Cols.Plazo3Provee)
        dgcColumns.Add(Cols.DiaPagoProvee)
        dgcColumns.Add(Cols.DiaPago2Provee)
        dgcColumns.Add(Cols.DiaPago3Provee)
        dgcColumns.Add(Cols.MesVacaProvee)
        dgcColumns.Add(Cols.MesVaca2Provee)
        dgcColumns.Add(Cols.DivisaProvee)
        dgcColumns.Add(Cols.UltimaModiProvee)
        dgcColumns.Add(Cols.UsuModiProvee)

    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)

    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As DataGridTable)
        Dim Tbls As New Definiciones.TablasProvee

        dgtTables.Add(Tbls.Provee1From)
        dgtTables.Add(Tbls.Provee2)
        dgtTables.Add(Tbls.TipoProvee)
        dgtTables.Add(Tbls.FormasProvee)

    End Sub

End Class
