Public Class frmTablasTiposProvee
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "TIPOPROVE"
        table.CamposID.Add(New PrimaryKey("NUM_TIPROVE"))
        table.TableAlias = "TPR"
        tablasEdit.Add(table)
    End Sub
End Class
