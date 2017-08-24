Imports CustomControls

Public Class defGridLupaModelosVehiculo
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As CustomControls.DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim Cols As New Definiciones.ColumnasModelosVehiculo

        dgcColumns.Add(Cols.CodigoModelosVehiculo)
        dgcColumns.Add(Cols.CodMarModelosVehiculo)
        dgcColumns.Add(Cols.NombreModelosVehiculo)

        dgcColumns.Add(Cols.ModeloModelosVehiculo)
        dgcColumns.Add(Cols.VarianteModelosVehiculo)
    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)
        Dim Cols As New Definiciones.OrdenesModelosVehiculo
        dgoOrdenes.Add(Cols.OrdenCodModeloVehiculo)
    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As CustomControls.DataGridTable)
        Dim Tbls As New Definiciones.TablasModelosVehiculo

        dgtTables.Add(Tbls.ModelosVehiculoFrom)

    End Sub
End Class