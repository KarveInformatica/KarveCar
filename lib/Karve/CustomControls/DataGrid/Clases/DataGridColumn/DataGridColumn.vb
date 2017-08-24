Imports Telerik.WinControls.UI



Public Class DataGridColumn
    Inherits GridViewDataColumn

    Enum eTipoColumn
        Pk
        Fecha
        Hora
        Texto
        Observaciones
        Numerico
    End Enum

    Dim _Item As Integer
    Dim _Campo As String
    Dim _Tabla As String
    Dim _ExpresionBd As String
    Dim _BackColor As System.Drawing.Color = Drawing.Color.White
    Dim _eTipoColumn As eTipoColumn

    Property Item As Integer
        Get
            Return _Item
        End Get
        Set(value As Integer)
            _Item = value
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

    Property ExpresionBd As String
        Get
            Return _ExpresionBd
        End Get
        Set(value As String)
            _ExpresionBd = value
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

    Property AliasCampo As String
        Get
            Return FieldName
        End Get
        Set(value As String)
            FieldName = value
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

    Property TipoColumna As eTipoColumn
        Get
            Return _eTipoColumn
        End Get
        Set(value As eTipoColumn)
            _eTipoColumn = value
            EstablecePropiedadesTipoColumna()
        End Set
    End Property

    Private Sub EstablecePropiedadesTipoColumna()
        Select Case _eTipoColumn
            Case eTipoColumn.Pk : ColumnaPk()
            Case eTipoColumn.Fecha : ColumnaFecha()
        End Select

    End Sub

    Private Sub ColumnaPk()
        _BackColor = Drawing.Color.SkyBlue
        MyBase.Width = 80
    End Sub

    Private Sub ColumnaFecha()
        Dim sAlias As String = _Tabla
        If sAlias <> "" Then sAlias = sAlias & "."
        _ExpresionBd = " DATEFORMAT(" & sAlias & MyBase.FieldName & ", 'dd/mm/yyyy') "
        MyBase.Width = 100
        MyBase.AllowResize = False
    End Sub

End Class
