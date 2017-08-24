Public Class TablaEdit
    Protected _Tabla As String
    Protected _CampoID As String
    Protected _CamposID As New List(Of PrimaryKey)
    Protected _TableAlias As String
    Protected _ExtraWhere As String
    Protected _Sufijo As String
    Protected _SufijoABuscar As String


    Property Tabla As String
        Get
            Return _Tabla
        End Get
        Set(value As String)
            _Tabla = value
        End Set
    End Property

    Property CampoID As String
        Get
            Return _CampoID
        End Get
        Set(value As String)
            _CampoID = value
        End Set
    End Property

    Property CamposID As List(Of PrimaryKey)
        Get
            Return _CamposID
        End Get
        Set(value As List(Of PrimaryKey))
            _CamposID = value
        End Set
    End Property

    Property TableAlias As String
        Get
            Return _TableAlias
        End Get
        Set(value As String)
            _TableAlias = value
        End Set
    End Property

    Property ExtraWhere As String
        Get
            Return _ExtraWhere
        End Get
        Set(value As String)
            _ExtraWhere = value
        End Set
    End Property

    Property Sufijo As String
        Get
            Return _Sufijo
        End Get
        Set(value As String)
            _Sufijo = value
        End Set
    End Property

    Property SufijoABuscar As String
        Get
            Return _SufijoABuscar
        End Get
        Set(value As String)
            _SufijoABuscar = value
        End Set
    End Property

End Class
