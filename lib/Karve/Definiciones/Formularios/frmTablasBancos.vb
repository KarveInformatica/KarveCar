Public Class frmTablasBancos
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "BANCO"
        table.CamposID.Add(New PrimaryKey("CODBAN"))
        table.TableAlias = "BC"
        tablasEdit.Add(table)
    End Sub
End Class
