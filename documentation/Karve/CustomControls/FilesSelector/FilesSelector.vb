Imports VariablesGlobales.Modulo_VariablesGlobales
Imports System.Windows.Forms
Imports Telerik.WinControls.UI
Imports CustomControls

Public Class FilesSelector

    Protected _Theme As ThemeType = ThemeType.Plain
    Private space As Integer = 75

    Property Descripcion As String
        Get
            Return lblDesc.Text
        End Get
        Set(ByVal value As String)
            lblDesc.Text = value
        End Set
    End Property

    Property Theme As ThemeType
        Get
            Return _Theme
        End Get
        Set(value As ThemeType)
            _Theme = value
            change_theme()
        End Set
    End Property

    Protected Overridable Sub change_theme()
        If Theme = ThemeType.Plain Then
            lstData.ThemeName = "Windows8"
        Else
            lstData.ThemeName = "Windows7"
        End If
    End Sub

    Property Label_Space As Integer
        Get
            Return space
        End Get
        Set(value As Integer)
            space = value
            lstData.Location = New System.Drawing.Point(value, 0)
            change_width()
        End Set
    End Property

    Private Sub change_width()
        lstData.Width = Me.Width - (space + 27)
    End Sub

    Private Sub btnAction_Click(sender As Object, e As EventArgs) Handles btnAction.Click
        Dim ofdAdjunto As New OpenFileDialog
        With ofdAdjunto
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            .Multiselect = True
            .ShowDialog()
        End With
        For Each file In ofdAdjunto.FileNames
            Dim it As New ListViewDataItem
            it.Text = file.Split("\").Last
            it.Tag = file
            lstData.Items.Add(it)
        Next
    End Sub

    Public Function getFiles() As ArrayList
        Dim ar As New ArrayList
        For Each it In lstData.Items
            ar.Add(it.Tag)
        Next
        Return ar
    End Function

End Class
