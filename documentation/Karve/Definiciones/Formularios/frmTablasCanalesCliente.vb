Public Class frmTablasCanalesCliente
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "CANAL"
        table.CamposID.Add(New PrimaryKey("CODIGO"))
        table.TableAlias = "CAC"
        tablasEdit.Add(table)
    End Sub
End Class
