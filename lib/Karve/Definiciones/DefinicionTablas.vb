Public MustInherit Class DefinicionTablas

    Protected _tablasEdit As New List(Of TablaEdit)

    Public ReadOnly Property Tablas As List(Of TablaEdit)
        Get
            Return _tablasEdit
        End Get
    End Property

    Public Sub New()
        setTables(_tablasEdit)
    End Sub

    MustOverride Sub setTables(ByRef tablasEdit As List(Of TablaEdit))

End Class
