Imports Telerik.WinControls.UI
Imports VariablesGlobales

Public Class Label
    Inherits RadLabel

    Private Sub Label_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        Me.Font = New System.Drawing.Font("Verdana", Me.Font.Size, Me.Font.Style)
    End Sub

    Public Sub traduc()
        Me.Text = Translate(Me.Text)
    End Sub
End Class
