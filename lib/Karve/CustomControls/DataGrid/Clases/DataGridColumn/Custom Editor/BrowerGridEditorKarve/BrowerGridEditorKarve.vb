Imports Telerik.WinControls.UI
Imports Telerik.WinControls.UI.Localization
Imports Telerik.WinControls
Imports System.Windows.Forms
Imports System.Drawing

Public Class BrowerGridEditorKarve
    Inherits BaseGridEditor
    Private endEditOnLostFocus_Renamed As Boolean = True
    Public Overrides Property Value() As Object
        Get
            Dim editor As BrowseEditorElement = CType(Me.EditorElement, BrowseEditorElement)
            Return editor.TextBox.Text
        End Get
        Set(ByVal value As Object)
            Dim editor As BrowseEditorElement = CType(Me.EditorElement, BrowseEditorElement)
            If value IsNot Nothing AndAlso value IsNot DBNull.Value Then
                editor.TextBox.Text = value.ToString
            Else
                editor.TextBox.Text = ""
            End If
        End Set
    End Property

    Public Overrides Sub BeginEdit()
        MyBase.BeginEdit()
        Dim editor As BrowseEditorElement = CType(Me.EditorElement, BrowseEditorElement)
        editor.TextBox.HostedControl.Focus()
        AddHandler editor.Button.Click, AddressOf Button_click
    End Sub

    Public Overrides Function EndEdit() As Boolean
        Dim editor As BrowseEditorElement = CType(Me.EditorElement, BrowseEditorElement)
        RemoveHandler editor.Button.Click, AddressOf Button_click
        Return MyBase.EndEdit()
    End Function

    Protected Overrides Function CreateEditorElement() As RadElement
        Return New BrowseEditorElement()
    End Function

    Public Overrides ReadOnly Property EndEditOnLostFocus() As Boolean
        Get
            Return endEditOnLostFocus_Renamed
        End Get
    End Property

    Private Sub Button_click(ByVal sender As Object, ByVal e As EventArgs)
        endEditOnLostFocus_Renamed = False
        MsgBox("")
        endEditOnLostFocus_Renamed = True
    End Sub

End Class
