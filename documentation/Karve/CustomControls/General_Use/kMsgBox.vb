Imports Telerik.WinControls.UI
Imports System.Windows.Forms
Imports Telerik.WinControls.RichTextBox.FormatProviders.Txt
Imports VariablesGlobales

Public Class kMsgBox

#Region "Variables"
    Private sound As Media.SystemSound

    Public Enum kMsgBoxStyle
        OkOnly
        OkCancel
        YesNo
        YesNoCancel
        Exclamation
        Information
        Question
        ErrorInformation
        Critical
    End Enum
#End Region

#Region "Print"
    Public Function Print(ByVal msg As String, Optional ByVal style As kMsgBoxStyle = kMsgBoxStyle.OkOnly, _
                          Optional ByVal extraMsg As String = "", Optional ByVal title As String = "Karve") As DialogResult
            msg = Translate(msg)
            setState(msg, style, extraMsg, title)
            lblMasDetalles.Text = "+ Más Detalles"
            Me.Height = 142
            masDetalles = False
            OK_Button.Select()
            Me.ShowDialog()
        Return Me.DialogResult
    End Function

    Private Sub kMsgBox_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        bgwSound.RunWorkerAsync()
    End Sub

    Private Sub bgwSound_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwSound.DoWork
        Try
            My.Computer.Audio.PlaySystemSound(sound)
        Catch
        End Try
    End Sub
#End Region

#Region "SetSate"
    Private Sub setState(ByVal msg As String, ByVal style As kMsgBoxStyle, ByVal extraMsg As String, ByVal title As String)
        lblInfo.Text = msg
        Me.Text = title
        Dim provider As New TxtFormatProvider
        rtbDetalles.Document = provider.Import(extraMsg)

        lblInfo.Location = New Drawing.Point(12, 12)
        lblInfo.Width = 337
        pbxImage.Visible = False

        sound = Media.SystemSounds.Beep

        Select Case style
            Case kMsgBoxStyle.OkOnly
                OkOnly()
            Case kMsgBoxStyle.OkCancel
                OkCancel()
            Case kMsgBoxStyle.YesNo
                YesNo()
            Case kMsgBoxStyle.YesNoCancel
                YesNoCancel()
            Case kMsgBoxStyle.Exclamation
                Exclamation()
            Case kMsgBoxStyle.Information
                Information()
            Case kMsgBoxStyle.Question
                Question()
            Case kMsgBoxStyle.ErrorInformation
                ErrorInformation()
            Case kMsgBoxStyle.Critical
                Critical()
        End Select
    End Sub

    Private Sub OkOnly()
        showButtons(1)
        OK_Button.DialogResult = Windows.Forms.DialogResult.OK
        OK_Button.Text = "Aceptar"
        showDetails()
    End Sub
    Private Sub OkCancel()
        showButtons(2)
        OK_Button.DialogResult = Windows.Forms.DialogResult.OK
        OK_Button.Text = "Aceptar"
        Cancel_Button.DialogResult = Windows.Forms.DialogResult.Cancel
        Cancel_Button.Text = "Cancelar"
        showDetails()
    End Sub
    Private Sub YesNo()
        showButtons(2)
        OK_Button.DialogResult = Windows.Forms.DialogResult.Yes
        OK_Button.Text = "Si"
        Cancel_Button.DialogResult = Windows.Forms.DialogResult.No
        Cancel_Button.Text = "No"
        showDetails()
    End Sub
    Private Sub YesNoCancel()
        showButtons(3)
        OK_Button.DialogResult = Windows.Forms.DialogResult.Yes
        OK_Button.Text = "Si"
        Cancel_Button.DialogResult = Windows.Forms.DialogResult.No
        Cancel_Button.Text = "No"
        btnExtra.DialogResult = Windows.Forms.DialogResult.Cancel
        btnExtra.Text = "Cancelar"
        showDetails()
    End Sub
    Private Sub Exclamation()
        OkOnly()
        showImage(kMsgBoxStyle.Exclamation)
        sound = Media.SystemSounds.Exclamation
    End Sub
    Private Sub Information()
        OkOnly()
        showImage(kMsgBoxStyle.Information)
        sound = Media.SystemSounds.Asterisk
    End Sub
    Private Sub Question()
        YesNoCancel()
        showImage(kMsgBoxStyle.Question)
        sound = Media.SystemSounds.Question
    End Sub
    Private Sub ErrorInformation()
        OkOnly()
        showImage(kMsgBoxStyle.ErrorInformation)
        sound = Media.SystemSounds.Hand
    End Sub
    Private Sub Critical()
        OK_Button.DialogResult = Windows.Forms.DialogResult.None
        OK_Button.Text = "Continuar"
        Cancel_Button.DialogResult = Windows.Forms.DialogResult.Abort
        Cancel_Button.Text = "Salir"
        showDetails()
        showImage(kMsgBoxStyle.Critical)
        sound = Media.SystemSounds.Hand
    End Sub

    Private Sub showDetails()
        Dim provider As New TxtFormatProvider
        Dim txt As String = provider.Export(rtbDetalles.Document)
        If txt <> "" Then
            lblMasDetalles.Visible = True
            rtbDetalles.Visible = True
        Else
            lblMasDetalles.Visible = False
            rtbDetalles.Visible = False
        End If
    End Sub
    Private Sub showImage(ByVal style As kMsgBoxStyle)
        lblInfo.Location = New Drawing.Point(69, 12)
        lblInfo.Width = 280

        pbxImage.Visible = True

        Select Case style
            Case kMsgBoxStyle.Exclamation
                pbxImage.Image = CustomControls.My.Resources.Resources.exclamation48x48
            Case kMsgBoxStyle.Information
                pbxImage.Image = CustomControls.My.Resources.Resources.information48x48
            Case kMsgBoxStyle.Question
                pbxImage.Image = CustomControls.My.Resources.Resources.question48x48
            Case kMsgBoxStyle.ErrorInformation
                pbxImage.Image = CustomControls.My.Resources.Resources.critical48x48
            Case kMsgBoxStyle.Critical
                pbxImage.Image = CustomControls.My.Resources.Resources.critical48x48
        End Select
    End Sub
    Private Sub showButtons(ByVal nButtons As Integer)
        If nButtons = 1 Then
            tlpButtons.ColumnCount = 1
            tlpButtons.Size = New Drawing.Size(73, 29)
            tlpButtons.Location = New Drawing.Point(276, 72)
            btnExtra.Visible = False
            Cancel_Button.Visible = False
            Me.CancelButton = Cancel_Button
        ElseIf nButtons = 2 Then
            tlpButtons.ColumnCount = 2
            tlpButtons.Size = New Drawing.Size(146, 29)
            tlpButtons.Location = New Drawing.Point(203, 72)
            Cancel_Button.Visible = True
            btnExtra.Visible = False
            Me.CancelButton = Cancel_Button
        Else
            tlpButtons.ColumnCount = 3
            tlpButtons.Size = New Drawing.Size(219, 29)
            tlpButtons.Location = New Drawing.Point(130, 72)
            Cancel_Button.Visible = True
            btnExtra.Visible = True
            Me.CancelButton = btnExtra
        End If
    End Sub
#End Region

#Region "Buttons"
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = OK_Button.DialogResult
        If OK_Button.DialogResult = Windows.Forms.DialogResult.Abort Then
            System.Environment.Exit(-1)
        End If
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = Cancel_Button.DialogResult
        If Cancel_Button.DialogResult = Windows.Forms.DialogResult.Abort Then
            System.Environment.Exit(-1)
        End If
        Me.Close()
    End Sub

    Private Sub btnExtra_Click(sender As Object, e As EventArgs) Handles btnExtra.Click
        Me.DialogResult = btnExtra.DialogResult
        If btnExtra.DialogResult = Windows.Forms.DialogResult.Abort Then
            System.Environment.Exit(-1)
        End If
        Me.Close()
    End Sub
#End Region

#Region "MasDetalles"
    Private masDetalles As Boolean = False

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

    Private Sub OK_Button_MouseHover(sender As Object, e As EventArgs) Handles OK_Button.MouseHover
        Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub OK_Button_MouseLeave(sender As Object, e As EventArgs) Handles OK_Button.MouseLeave
        Cursor = Windows.Forms.Cursors.Arrow
    End Sub

#End Region

End Class
