
Public Class DataGridTable

#Region "   .   VARIABLES.  "

    Enum euCriteriosJoin
        FromJoin
        InnerJoin
        LeftJoin
        RightJoin
        FullJoin
        Union
        UnionAll
        FromFrom
    End Enum

    Dim _Item As Integer
    Dim _Table As String
    Dim _Alias As String
    Dim _Join As euCriteriosJoin
    Dim _Criterio As String
    Dim _TablasVirtual As New DataGridTables
    Dim _ColumnasVirtual As New DataGridColumnVirtuales
    Private _Name As String

#End Region

#Region "   -   PROPERTY.   "

    Public Property Item As Integer
        Get
            Return _Item
        End Get
        Set(value As Integer)
            _Item = value
        End Set
    End Property

    Public Property Table As String
        Get
            Return _Table
        End Get
        Set(value As String)
            _Table = value
        End Set
    End Property

    Public Property AliasTabla As String
        Get
            Return _Alias
        End Get
        Set(value As String)
            _Alias = value
        End Set
    End Property

    Public Property Join As euCriteriosJoin
        Get
            Return _Join
        End Get
        Set(value As euCriteriosJoin)
            _Join = value
        End Set
    End Property

    Public ReadOnly Property JoinText As String
        Get
            Dim sJoin As String = ""
            Select Case _Join
                Case euCriteriosJoin.FromJoin : sJoin = " FROM "
                Case euCriteriosJoin.InnerJoin : sJoin = " INNER JOIN "
                Case euCriteriosJoin.LeftJoin : sJoin = " LEFT OUTER JOIN "
                Case euCriteriosJoin.RightJoin : sJoin = " RIGHT OUTER JOIN "
                Case euCriteriosJoin.FromFrom : sJoin = ", "
                Case euCriteriosJoin.Union : sJoin = " UNION "
                Case euCriteriosJoin.UnionAll : sJoin = " UNION ALL "
                Case euCriteriosJoin.FullJoin : sJoin = " FULL OUTER JOIN "
            End Select
            Return sJoin
        End Get

    End Property

    Public Property Criterio As String
        Get
            Return _Criterio
        End Get
        Set(value As String)
            _Criterio = value
        End Set
    End Property

    Public Property TablasVirtual As DataGridTables
        Get
            Return _TablasVirtual
        End Get
        Set(value As DataGridTables)
            _TablasVirtual = value
        End Set
    End Property

    Public Property ColumnasTablaVirtual As DataGridColumnVirtuales
        Get
            Return _ColumnasVirtual
        End Get
        Set(value As DataGridColumnVirtuales)
            _ColumnasVirtual = value
        End Set
    End Property

    Public Property Name
        Get
            If _Name <> "" Then
                Return _Name
            Else
                Return _Table
            End If
        End Get
        Set(value)
            _Name = value
        End Set
    End Property

#End Region

End Class
