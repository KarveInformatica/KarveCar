Public Class Consulta

    Public Event CintaClick(sender As Object, e As EventArgs)

    Private Sub Consulta_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If Me.IsMdiChild = False Then Me.Cinta.Visible = True
    End Sub
    
    Private Sub Botones_click(sender As Object, e As EventArgs) Handles rbAceptar.Click, rbCancelar.Click
        RaiseEvent  CintaClick(sender, e )
    End Sub
End Class
