Public Class frmTablasClientes
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "CLIENTES1"
        table.CamposID.Add(New PrimaryKey("NUMERO_CLI"))
        table.TableAlias = "CL1"
        tablasEdit.Add(table)

        table = New TablaEdit
        table.Tabla = "CLIENTES2"
        table.CamposID.Add(New PrimaryKey("NUMERO_CLI"))
        table.TableAlias = "CL2"
        tablasEdit.Add(table)
    End Sub
End Class
