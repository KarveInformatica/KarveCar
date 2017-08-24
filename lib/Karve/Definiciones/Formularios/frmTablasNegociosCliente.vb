Public Class frmTablasNegociosCliente
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "NEGOCIO"
        table.CamposID.Add(New PrimaryKey("CODIGO"))
        table.TableAlias = "NC"
        tablasEdit.Add(table)
    End Sub
End Class
