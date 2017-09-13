Imports System.Windows.Forms

Public Class MsgBoxError
    Private masDetalles As Boolean = False

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal msgError As String, ByVal msgDetallado As String, Optional ByVal title As String = "Error")
        InitializeComponent()
        lblError.Text = msgError
        txtDetallado.Text = msgDetallado
        Me.Text = title
    End Sub

    Public Sub Print(ByVal msgError As String, ByVal msgDetallado As String, Optional ByVal title As String = "Error")
        masDetalles = True
        lblMasDetalles_Click(Nothing, Nothing)
        Me.Refresh()
        lblError.Text = msgError
        txtDetallado.Text = msgDetallado
        Me.Text = title
        Me.ShowDialog()
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        System.Environment.Exit(0)
    End Sub

    Private Sub lblMasDetalles_Click(sender As Object, e As EventArgs) Handles lblMasDetalles.Click
        If Not masDetalles Then
            lblMasDetalles.Text = "- Menos Detalles"
            Me.Height = 292
            masDetalles = True
        Else
            lblMasDetalles.Text = "+ Más Detalles"
            Me.Height = 142
            masDetalles = False
        End If
    End Sub

    Private Sub MsgBoxError_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        Me.Height = 142
    End Sub

    Private Sub MsgBoxError_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Hand)
    End Sub
End Class
