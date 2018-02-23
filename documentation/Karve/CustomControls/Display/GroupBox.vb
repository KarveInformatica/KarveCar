Imports Telerik.WinControls.Themes.Windows8Theme
Imports Telerik.WinControls.Themes.Windows7Theme
Imports Telerik.WinControls.UI
Imports VariablesGlobales
Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class GroupBox
    Inherits RadGroupBox

    Protected _Theme As ThemeType = ThemeType.Plain
    Protected _numRows As Integer = 0
    Protected _reorder As Boolean = True

    Overridable Property Theme As ThemeType
        Get
            Return _Theme
        End Get
        Set(value As ThemeType)
            _Theme = value
            If _Theme = ThemeType.Plain Then
                Me.ThemeName = "Windows8"
            Else
                Me.ThemeName = "Windows7"
            End If
        End Set
    End Property

    Property numRows As Integer
        Get
            Return _numRows
        End Get
        Set(value As Integer)
            _numRows = value
            If _numRows > 0 Then
                Me.Height = _numRows * 26 + 20

            End If
        End Set
    End Property

    Property Title As String
        Get
            Return Me.Text
        End Get
        Set(value As String)
            Me.Text = value
        End Set
    End Property

    Property Reorder As Boolean
        Get
            Return _reorder
        End Get
        Set(value As Boolean)
            _reorder = value
        End Set
    End Property

    Public Sub New()
        Me.Font = New System.Drawing.Font("Verdana", 8.25)
        Me.ThemeClassName = "Telerik.WinControls.UI.RadGroupBox"
        Me.ThemeName = "Windows8"
        Me.Padding = New Padding(6, 18, 6, 6)
    End Sub

    Public Overridable Sub traduc()
        Me.Text = Translate(Me.Text)
    End Sub

    Private Sub GroupBox_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        If _reorder Then
            TabReorder()
        End If
    End Sub

    Public Overridable Sub TabReorder()
        Dim result = From c As Control In Me.Controls
                     Where c.Visible = True
                     Order By c.Location.Y, c.Location.X
                     Select c

        Dim i As Integer = 0
        For Each ctr As Control In result
            ctr.TabIndex = i
            i += 1
        Next
    End Sub
End Class
