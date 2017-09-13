Public Class frmTablasPais
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "PAIS"
        table.CamposID.Add(New PrimaryKey("SIGLAS"))
        table.TableAlias = "P"
        tablasEdit.Add(table)
    End Sub

End Class
