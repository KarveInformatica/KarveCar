Imports Telerik.WinControls.UI
Imports VariablesGlobales

Public Class DataGridComboBoxColumn
    Inherits GridViewComboBoxColumn

#Region "Variables"
    Dim _Item As Integer
    Dim _Campo As String
    Dim _Tabla As String
    Dim _ExpresionBd As String
    Dim _BackColor As System.Drawing.Color = Drawing.Color.White
#End Region

#Region "Propiedades"
    Property Item As Integer
        Get
            Return _Item
        End Get
        Set(value As Integer)
            _Item = value
        End Set
    End Property

    Property Tabla As String
        Get
            Return _Tabla
        End Get
        Set(value As String)
            _Tabla = value
        End Set
    End Property

    Property Campo As String
        Get
            Return _Campo
        End Get
        Set(value As String)
            _Campo = value
        End Set
    End Property

    Property AliasCampo As String
        Get
            Return FieldName
        End Get
        Set(value As String)
            FieldName = value
        End Set
    End Property

    Property ExpresionBd As String
        Get
            Return _ExpresionBd
        End Get
        Set(value As String)
            _ExpresionBd = value
        End Set
    End Property

    Property BackColor As System.Drawing.Color
        Get
            Return _BackColor
        End Get
        Set(value As System.Drawing.Color)
            _BackColor = value
        End Set
    End Property

    Public Overrides Property [ReadOnly] As Boolean
        Get
            Return MyBase.[ReadOnly]
        End Get
        Set(value As Boolean)
            MyBase.[ReadOnly] = value
            If value Then
                _BackColor = ColorSel
            End If
        End Set
    End Property
#End Region

    Sub a()

    End Sub
End Class
