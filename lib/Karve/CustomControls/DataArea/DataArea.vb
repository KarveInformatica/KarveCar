Public Class DataArea
    Inherits Datafield

    Private Sub DataArea_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            txtData.AppendText(vbCrLf)
        End If
    End Sub

    Private Sub DataArea_Focused() Handles Me.Focused
        txtData.SelectionStart = txtData.TextLength
        txtData.ScrollToCaret()
    End Sub

    Private Sub DataArea_UnFocused() Handles Me.UnFocused
        txtData.SelectionStart = 0
        txtData.SelectionLength = 1
        txtData.ScrollToCaret()
    End Sub
End Class
