Imports Telerik.WinControls.UI

Public Class DataGridColumns
    Inherits System.Collections.Hashtable

    Public Overloads Sub Add(ByVal Columna As Object)
        Try
            Columna.Item = Me.Count
            MyBase.Add(Columna.Name, Columna)
        Catch
        End Try
    End Sub

    Public Function ToArray() As ArrayList
        Dim HC = (From c As Object In Me.Values Order By c.Item Select c)
        Dim RS As New ArrayList
        For Each ctr As Object In HC
            RS.Add(ctr)
        Next
        Return RS
    End Function

End Class
