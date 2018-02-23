Public Class FichaTecnica

    Dim _DataTable As String

    Public Property DataTable() As String
        Get
            Return _DataTable
        End Get
        Set(value As String)
            _DataTable = value
            RecorreMe(Me.Controls)
        End Set
    End Property

    Private Sub RecorreMe(ctr As Object)
        For Each ctrO In ctr

            If Not TieneDataField(ctrO) Then
                RecorreMe(ctrO.controls)
            Else
                AsignaTabla(ctrO)
            End If

        Next
    End Sub

    Private Function TieneDataField(ctr As Object) As Boolean
        Try
            Return (ctr.DataField <> "")
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub AsignaTabla(ctr As Object)
        Try
            ctr.DataTable = _DataTable
        Catch ex As Exception
        End Try
    End Sub

End Class
