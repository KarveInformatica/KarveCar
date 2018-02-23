Imports CustomControls

Public Class defGridLupaContratosRC
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As CustomControls.DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim Cols As New Definiciones.ColumnasContratosRC

        dgcColumns.Add(Cols.NumeroContrato)
        dgcColumns.Add(Cols.OfiSalida)
        dgcColumns.Add(Cols.FechaSalida)
        dgcColumns.Add(Cols.OfiRetorno)
        dgcColumns.Add(Cols.FechaPrevista)
        dgcColumns.Add(Cols.FechaRetorno)
        dgcColumns.Add(Cols.DiasContrato)
        dgcColumns.Add(Cols.NumeroCliente)
        dgcColumns.Add(Cols.NombreCliente)
        dgcColumns.Add(Cols.NombreConductor)

        colRelation = Cols.NumeroContrato
    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)
        Dim Cols As New Definiciones.OrdenesContratosRC
        dgoOrdenes.Add(Cols.OrdenFechaSalida)
    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As CustomControls.DataGridTable)
        Dim Tbls As New Definiciones.TablasContratosRC

        dgtTables.Add(Tbls.ContratosFrom)
        dgtTables.Add(Tbls.Contratos2)
        dgtTables.Add(Tbls.Contratos4)
        dgtTables.Add(Tbls.Oficinas)
        dgtTables.Add(Tbls.Clientes)
        dgtTables.Add(Tbls.Conductores)
        dgtTables.Add(Tbls.Comisionistas)

    End Sub
End Class
