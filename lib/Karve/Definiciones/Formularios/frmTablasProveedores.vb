Public Class frmTablasProveedores
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "PROVEE1"
        table.CamposID.Add(New PrimaryKey("NUM_PROVEE"))
        table.TableAlias = "PR1"
        tablasEdit.Add(table)

        table = New TablaEdit
        table.Tabla = "PROVEE2"
        table.CamposID.Add(New PrimaryKey("NUM_PROVEE"))
        table.TableAlias = "PR2"
        tablasEdit.Add(table)
    End Sub
End Class
