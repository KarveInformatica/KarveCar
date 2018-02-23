Public Class frmTablasClavesPresupuesto
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "CLAVEPTO"
        table.CamposID.Add(New PrimaryKey("COD_CLAVE"))
        table.TableAlias = "CLP"
        tablasEdit.Add(table)
    End Sub
End Class
