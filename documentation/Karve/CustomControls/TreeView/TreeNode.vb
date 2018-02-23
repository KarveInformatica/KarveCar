Imports Telerik.WinControls.UI
Imports System.Drawing

Public Class TreeNode
    Inherits RadTreeNode

#Region "Variables"
    Private _form As String
    Private _type As nodeType

    Public Enum nodeType
        container
        node
    End Enum
#End Region

#Region "Propiedades"
    Property Form As String
        Get
            Return _form
        End Get
        Set(value As String)
            _form = value
        End Set
    End Property

    Property Type As nodeType
        Get
            Return _type
        End Get
        Set(value As nodeType)
            _type = value
            If value = nodeType.container Then
                Me.BackColor = Color.FromArgb(41, 167, 235) ' 25,121,202
                Me.Font = New System.Drawing.Font("Verdana", 8.25, Drawing.FontStyle.Bold)
                'Me.ForeColor = Color.White
            Else
                Me.BackColor = Nothing
                Me.Font = New System.Drawing.Font("Verdana", 8.25)
            End If
        End Set
    End Property
#End Region

#Region "New"
    Sub New()
        MyBase.New()
    End Sub

    Sub New(ByVal text As String)
        MyBase.New(text)
    End Sub

    Sub New(ByVal text As String, ByVal type As nodeType)
        MyBase.New(text)
        Me.Type = type
    End Sub

    Sub New(ByVal text As String, ByVal type As nodeType, ByVal form As String)
        MyBase.New(text)
        Me.Type = type
        Me.Form = form
    End Sub

    Sub New(ByVal text As String, ByVal type As nodeType, ByVal form As String, ByVal name As String)
        MyBase.New(text)
        Me.Name = IIf(name <> "", name, text)
        Me.Type = type
        Me.Form = form
    End Sub

    Sub New(ByVal text As String, ByVal type As nodeType, ByVal form As String, ByVal name As String, ByVal Imagen As Image)
        MyBase.New(text)
        Me.Name = IIf(name <> "", name, text)
        Me.Type = type
        Me.Form = form
        If Not Imagen Is Nothing Then Me.Image = Imagen
    End Sub
#End Region

#Region "Eventos"

#End Region
End Class
