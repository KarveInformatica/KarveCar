Public Class pnlBloqueo

    Public Event enterEditMode()

    WriteOnly Property Usuario As String
        Set(value As String)
            txtUsuario.Text = value
        End Set
    End Property

    WriteOnly Property Desde As Date
        Set(value As Date)
            txtDesde.Text = value.ToString("hh:mm dd/MM/yyyy")
        End Set
    End Property

    Private Sub txtUsuario_SizeChanged(sender As Object, e As EventArgs) Handles txtUsuario.SizeChanged
        Dim move As Integer = txtUsuario.Height - 17
        lblDesde.Location = New Drawing.Point(0, 32 + move)
        txtDesde.Location = New Drawing.Point(5, 47 + move)
    End Sub

    Public Sub blockMode()
        pnlColor.BackColor = Drawing.Color.Red
        pnlColor.BorderColor = Drawing.Color.Red
        pnlBlocked.Visible = True
        pnlEdit.Visible = False
        lblInfo.Text = "REGISTRO" & vbCrLf & "BLOQUEADO"
    End Sub
    Public Sub editMode()
        pnlColor.BackColor = Drawing.Color.Green
        pnlColor.BorderColor = Drawing.Color.Green
        pnlBlocked.Visible = False
        pnlEdit.Visible = True
        lblInfo.Text = "REGISTRO" & vbCrLf & "LIBERADO"
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        RaiseEvent enterEditMode()
    End Sub

    Public Sub traduc(Optional ByRef container As Object = Nothing)
        If IsNothing(container) Then
            container = Me.Controls
        End If
        For Each ctr In container
            Try
                If ctr.GetType Is GetType(CustomControls.Panel) Then
                    traduc(CType(ctr, CustomControls.Panel).Controls)
                End If
                CType(ctr, Object).traduc()
            Catch
            End Try
        Next
    End Sub
End Class
