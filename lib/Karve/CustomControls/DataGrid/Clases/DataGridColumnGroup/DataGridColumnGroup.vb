Imports Telerik.WinControls.UI

Public Class DataGridColumnGroup
    Inherits GridViewColumnGroup

    Public Sub Add(ByRef col As GridViewDataColumn)
        Me.Rows(0).Columns.Add(col)
    End Sub

    Public Sub New()
        Me.Rows.Add(New GridViewColumnGroupRow())
    End Sub
End Class
