Public Class frmTablasVendedores
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "VENDEDOR"
        table.CamposID.Add(New PrimaryKey("NUM_VENDE"))
        table.TableAlias = "VEND"
        tablasEdit.Add(table)
    End Sub
End Class
