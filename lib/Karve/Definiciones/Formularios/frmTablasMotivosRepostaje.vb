Public Class frmTablasMotivosRepostaje
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "MOT_REPOSTAJE"
        table.CamposID.Add(New PrimaryKey("COD_MOT"))
        table.TableAlias = "MOR"
        tablasEdit.Add(table)
    End Sub
End Class
