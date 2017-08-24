Public Class frmTablasFormasPago
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "FORPRO"
        table.CamposID.Add(New PrimaryKey("CODIGO"))
        table.TableAlias = "FPR"
        tablasEdit.Add(table)
    End Sub
End Class
