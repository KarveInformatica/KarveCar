Imports CustomControls
Public Class defGridProContacto
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim cols As New ColumnasProContacto
        Dim tmp As Object

        dgcColumns.Add(cols.NumeroContacto)
        dgcColumns.Add(cols.NombreContacto)
        dgcColumns.Add(cols.CargoContacto)
        dgcColumns.Add(cols.DepartamentoContacto)
        dgcColumns.Add(cols.TelefonoContacto)
        dgcColumns.Add(cols.MovilContacto)
        dgcColumns.Add(cols.FaxContacto)
        dgcColumns.Add(cols.EmailContacto)

        tmp = cols.ProveContacto
        dgcColumns.Add(tmp)
        colRelation = tmp
    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgrRules As CustomControls.DataGridOrdenColumnas)

    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As DataGridTable)
        Dim tablas As New TablasProContacto
        Dim tmp As Object

        tmp = tablas.CliDelega
        dgtTables.Add(tmp)
        tbEdit = tmp
    End Sub
End Class
