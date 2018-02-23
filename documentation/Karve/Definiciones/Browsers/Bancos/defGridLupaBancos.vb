Imports CustomControls

Public Class defGridLupaBancos
    Inherits Definicion

    Protected Overrides Sub SetColumns(ByRef dgcColumns As CustomControls.DataGridColumns, ByRef colRelation As CustomControls.DataGridTextBoxColumn, ByRef dgcgGroups As CustomControls.DataGridColumnGroups)
        Dim Cols As New Definiciones.ColumnasBancos

        dgcColumns.Add(Cols.CodigoBancosCliente)
        dgcColumns.Add(Cols.NombreBancosCliente)
        dgcColumns.Add(Cols.SwiftBancosCliente)
        dgcColumns.Add(Cols.GestionarBancosCliente)

    End Sub

    Protected Overrides Sub SetRules(ByRef dgrRules As CustomControls.DataGridRules)

    End Sub

    Protected Overrides Sub SetOrdenes(ByRef dgoOrdenes As CustomControls.DataGridOrdenColumnas)
        Dim Cols As New Definiciones.OrdenesBancos
        dgoOrdenes.Add(Cols.OrdenNomBancosCliente)
    End Sub

    Protected Overrides Sub SetTables(ByRef dgtTables As CustomControls.DataGridTables, ByRef tbEdit As CustomControls.DataGridTable)
        Dim Tbls As New Definiciones.TablasBancos

        dgtTables.Add(Tbls.BancosClienteFrom)

    End Sub
End Class
