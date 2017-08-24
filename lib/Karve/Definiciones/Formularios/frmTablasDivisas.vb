Public Class frmTablasDivisas
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "DIVISAS"
        table.CamposID.Add(New PrimaryKey("CODIGO"))
        table.TableAlias = "DIVI"
        tablasEdit.Add(table)
    End Sub
End Class
