Public Class DataGridColumnVirtuales
    Inherits System.Collections.Hashtable

    Public Overloads Sub Add(ByVal TablaQuery As DataGridColumnVirtual)
        MyBase.Add(TablaQuery.Name, TablaQuery)
    End Sub

    Public Function Order() As ArrayList
        Dim HC = (From c As DataGridColumnVirtual In Me.Values Order By c.Item Select c)
        Dim RS As New ArrayList
        For Each ctr As DataGridColumnVirtual In HC
            RS.Add(ctr)
        Next
        Return RS
    End Function

End Class
