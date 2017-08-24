Imports CustomControls
Public Class defGridVehiMante
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim cols As New ColumnasVehiMante
        'Dim colRel As DataGridBrowseBoxColumn
        Dim tmp As Object
        Dim gr As DataGridColumnGroup

        gr = cols.GrVacio

        tmp = cols.CodigoMante
        dgcColumns.Add(tmp)
        gr.Add(tmp)
        'dgcColumns.Add(cols.Mantenimiento)
        dgcgGroups.Add(gr)

        gr = cols.UltMante

        tmp = cols.FechaUltMante
        dgcColumns.Add(tmp)
        gr.Add(tmp)

        tmp = cols.KmUltMante
        dgcColumns.Add(tmp)
        gr.Add(tmp)

        dgcgGroups.Add(gr)

        gr = cols.ProxMante

        tmp = cols.FechaProxMante
        dgcColumns.Add(tmp)
        gr.Add(tmp)

        tmp = cols.KmProxMante
        dgcColumns.Add(tmp)
        gr.Add(tmp)

        dgcgGroups.Add(gr)

        tmp = cols.ManteVehi
        dgcColumns.Add(tmp)
        colRelation = tmp
    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgrRules As CustomControls.DataGridOrdenColumnas)

    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As DataGridTable)
        Dim tablas As New TablasVehiMante
        Dim tmp As Object

        tmp = tablas.VehiMante
        dgtTables.Add(tmp)
        tbEdit = tmp

    End Sub
End Class
