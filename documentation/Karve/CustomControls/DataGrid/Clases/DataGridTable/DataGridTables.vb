Public Class DataGridTables
    Inherits System.Collections.Hashtable

    Public Overloads Sub Add(ByVal TablaQuery As DataGridTable)
        TablaQuery.Item = Me.Count
        MyBase.Add(TablaQuery.Name, TablaQuery)
    End Sub

    Public Function ToArray() As ArrayList
        Dim HC = (From c As DataGridTable In Me.Values Order By c.Item Select c)
        Dim RS As New ArrayList
        For Each ctr As DataGridTable In HC
            RS.Add(ctr)
        Next
        Return RS
    End Function

End Class
