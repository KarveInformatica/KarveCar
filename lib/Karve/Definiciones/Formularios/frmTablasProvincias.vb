Public Class frmTablasProvincias
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "PROVINCIA"
        table.CamposID.Add(New PrimaryKey("SIGLAS"))
        table.TableAlias = "PROV"
        tablasEdit.Add(table)
    End Sub

End Class
