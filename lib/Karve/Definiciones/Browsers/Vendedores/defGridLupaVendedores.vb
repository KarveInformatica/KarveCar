Public Class defGridLupaVendedores
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As CustomControls.DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim Cols As New Definiciones.ColumnasVendedores

        dgcColumns.Add(Cols.CodigoVendedor)
        dgcColumns.Add(Cols.NombreVendedor)
        dgcColumns.Add(Cols.TelefonoVendedor)
        dgcColumns.Add(Cols.MovilVendedor)
        dgcColumns.Add(Cols.FBajaVendedor)

        colRelation = Cols.CodigoVendedor

    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)
        Dim Cols As New Definiciones.OrdenesVendedores


    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As CustomControls.DataGridTable)
        Dim Tbls As New Definiciones.TablasVendedores

        dgtTables.Add(Tbls.Vendedor)

    End Sub
End Class
