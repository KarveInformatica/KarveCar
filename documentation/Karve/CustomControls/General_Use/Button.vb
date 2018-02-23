Imports Telerik.WinControls.Themes.Windows8Theme
Imports Telerik.WinControls.Themes.Windows7Theme
Imports VariablesGlobales

Public Class Button
    Inherits Telerik.WinControls.UI.RadButton

    Protected _Theme As ThemeType = ThemeType.Plain

    Property Theme As ThemeType
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

    Private Sub Button_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        Me.Font = New System.Drawing.Font("Verdana", 8.25)
    End Sub

    Public Sub traduc()
        Me.Text = Translate(Me.Text)
    End Sub

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        Me.ThemeClassName = "Telerik.WinControls.UI.RadButton"
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
End Class
