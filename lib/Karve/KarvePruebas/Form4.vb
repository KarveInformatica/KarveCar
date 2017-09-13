Imports Telerik.WinControls.UI.Localization

Public Class Form4

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles Me.Load
        RadGridLocalizationProvider.CurrentProvider = New MyEnglishRadGridLocalizationProvider()
    End Sub

End Class


Public Class MyEnglishRadGridLocalizationProvider
    Inherits RadGridLocalizationProvider

End Class