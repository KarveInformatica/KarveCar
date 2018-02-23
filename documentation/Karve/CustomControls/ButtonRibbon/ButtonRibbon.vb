Imports Telerik.WinControls.UI

Public Class ButtonRibbon
    Inherits RadButtonElement

    Dim _OpenForm As String
    'Dim AutoScaleMode As Windows.Forms.AutoScaleMode

    Public Property OpenForm As String
        Get
            Return _OpenForm
        End Get
        Set(value As String)
            _OpenForm = value
        End Set
    End Property

End Class
