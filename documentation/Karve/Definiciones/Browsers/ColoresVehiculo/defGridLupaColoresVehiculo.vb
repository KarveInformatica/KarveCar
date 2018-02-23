Public Class defGridLupaColoresVehiculo

    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As CustomControls.DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim Cols As New Definiciones.ColumnasColoresVehiculo

        dgcColumns.Add(Cols.CodigoColoresVehiculo)
        dgcColumns.Add(Cols.NombreColoresVehiculo)

    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)
        Dim Cols As New Definiciones.OrdenesColoresVehiculo
        dgoOrdenes.Add(Cols.OrdenColoresVehiculo)
    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As CustomControls.DataGridTable)
        Dim Tbls As New Definiciones.TablasColoresVehiculo

        dgtTables.Add(Tbls.ColoresVehiculoFrom)

    End Sub

End Class
