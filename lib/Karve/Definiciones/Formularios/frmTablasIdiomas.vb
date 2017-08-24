Public Class frmTablasIdiomas
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "IDIOMAS"
        table.CamposID.Add(New PrimaryKey("CODIGO"))
        table.TableAlias = "IDI"
        tablasEdit.Add(table)
    End Sub
End Class
