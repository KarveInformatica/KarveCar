Imports System.Windows.Forms
Imports Telerik.WinControls.UI
Imports VariablesGlobales

Public Class DataRadio
    Inherits RadRadioButton

#Region "Variables"
    Protected _DataField As String
    Public Event CheckedChanged(sender As Object, e As EventArgs)
    Protected _Theme As ThemeType = ThemeType.Plain

#End Region

#Region "Propiedades"

    Property Index As String
        Get
            Return _DataField
        End Get
        Set(ByVal value As String)
            _DataField = value
        End Set
    End Property

    Property Descripcion As String
        Get
            Return Me.Text
        End Get
        Set(ByVal value As String)
            Me.Text = value
        End Set
    End Property

    Property Checked As Boolean
        Get
            Return IsChecked
        End Get
        Set(value As Boolean)
            IsChecked = value
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
        If _Theme = ThemeType.Plain Then
            Me.ThemeName = "Windows8"
            Me.BackColor = Drawing.SystemColors.Control
        Else
            Me.ThemeName = "Windows7"
            Me.BackColor = Drawing.SystemColors.Window
        End If
    End Sub
#End Region

    Private Sub DataRadio_CheckStateChanged(sender As Object, e As EventArgs) Handles Me.CheckStateChanged
        RaiseEvent CheckedChanged(sender, e)
    End Sub

    Private Sub DataRadio_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        Me.Font = New System.Drawing.Font("Verdana", 8.25)
    End Sub

#Region "Funciones"
    Public Sub traduc()
        Descripcion = Translate(Descripcion)
    End Sub
#End Region
End Class
