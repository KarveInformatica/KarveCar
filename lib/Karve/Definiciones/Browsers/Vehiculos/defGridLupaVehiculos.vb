Public Class defGridLupaVehiculos
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As CustomControls.DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim Cols As New Definiciones.ColumnasVehiculos

        dgcColumns.Add(Cols.CodigoVehiculo)
        dgcColumns.Add(Cols.MatriculaVehiculo)
        dgcColumns.Add(Cols.MarcaVehiculo)
        dgcColumns.Add(Cols.ModeloVehiculo)
        dgcColumns.Add(Cols.GrupoVehiculo)
        dgcColumns.Add(Cols.ActividadVehiculo)
        dgcColumns.Add(Cols.OficinaVehiculo)
        dgcColumns.Add(Cols.SituacionVehiculo)

        colRelation = Cols.CodigoVehiculo

    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)
        Dim Cols As New Definiciones.OrdenesVehiculos
        dgoOrdenes.Add(Cols.OrdenMatricula)
    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As CustomControls.DataGridTable)
        Dim Tbls As New Definiciones.TablasVehiculos

        dgtTables.Add(Tbls.Vehiculo1From)
        dgtTables.Add(Tbls.Vehiculo2)

    End Sub
End Class
