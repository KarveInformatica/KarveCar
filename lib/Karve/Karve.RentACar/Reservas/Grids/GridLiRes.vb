Public Class GridLiRes
    Inherits GridLiCon

    Protected Overrides Sub DefineGrid()

        Dim definition As New Definiciones.defGridLires

        dgcColumnas = definition.Columns
        ColRel = definition.ColumnRel

        dgtTablas = definition.Tables
        TablaEdit = definition.TablaEdit

        dgrClausulas = definition.Rules

    End Sub

End Class
