Imports CustomControls

Public Class defGridLupaClientes
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim Cols As New Definiciones.ColumnasCli

        dgcColumns.Add(Cols.NumeroCli)
        dgcColumns.Add(Cols.NombreCli)
        dgcColumns.Add(Cols.DireccionCli)
        dgcColumns.Add(Cols.CpCli)
        dgcColumns.Add(Cols.PoblacionCli)
        dgcColumns.Add(Cols.TelefonoCli)
        dgcColumns.Add(Cols.Telefono2Cli)
        dgcColumns.Add(Cols.FaxCli)
        dgcColumns.Add(Cols.MailCli)
        dgcColumns.Add(Cols.FecAltaCli)
        dgcColumns.Add(Cols.ObsCli)
    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)
        Dim Cols As New Definiciones.OrdenesClientes
        dgoOrdenes.Add(Cols.OrdenNomCliente)
    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As DataGridTable)
        Dim Tbls As New Definiciones.TablasCli

        dgtTables.Add(Tbls.Clientes1From)
        dgtTables.Add(Tbls.Clientes2)

    End Sub

End Class
