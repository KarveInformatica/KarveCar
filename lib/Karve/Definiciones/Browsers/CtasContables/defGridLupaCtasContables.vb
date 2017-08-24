Public Class defGridLupaCtasContables
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As CustomControls.DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim Cols As New Definiciones.ColumnasCtasContables

        dgcColumns.Add(Cols.CodigoCtasContables)
        dgcColumns.Add(Cols.NombreMarcasVehiculo)

    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)
        Dim Cols As New Definiciones.ReglasCtasContables
        dgrRules.Add(Cols.CtasContablesEmp)
    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)
        Dim Cols As New Definiciones.OrdenesCtasContables
        dgoOrdenes.Add(Cols.OrdenNomCtasContables)
    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As CustomControls.DataGridTable)
        Dim Tbls As New Definiciones.TablasCtasContables

        dgtTables.Add(Tbls.CtasContablesFrom)

    End Sub
End Class
