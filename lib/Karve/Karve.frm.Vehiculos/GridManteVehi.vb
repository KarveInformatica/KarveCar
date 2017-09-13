Imports Telerik.WinControls.UI
Imports Karve.Logic
Imports Karve.ConfiguracionApp
Imports VariablesGlobales

Public Class GridManteVehi
    Inherits CustomControls.DataGrid

    Protected Overrides Sub DefineGrid()

        Dim definition As New Definiciones.defGridVehiMante

        dgcColumnas = definition.Columns
        ColRel = definition.ColumnRel

        dgtTablas = definition.Tables
        TablaEdit = definition.TablaEdit

        dgrClausulas = definition.Rules

        dgcgGroups = definition.Groups

    End Sub
End Class
