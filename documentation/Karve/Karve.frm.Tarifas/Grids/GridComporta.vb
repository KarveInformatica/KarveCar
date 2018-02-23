Imports Telerik.WinControls.UI

Public Class GridComporta
    Inherits CustomControls.DataGrid

    Protected Overrides Sub DefineGrid()

        Dim definition As New Definiciones.defGridBasesCon

        dgcColumnas = definition.Columns
        ColRel = definition.ColumnRel

        dgtTablas = definition.Tables
        TablaEdit = definition.TablaEdit

        dgrClausulas = definition.Rules

    End Sub

End Class
