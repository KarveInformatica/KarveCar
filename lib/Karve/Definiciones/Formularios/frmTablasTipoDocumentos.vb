Public Class frmTablasTipoDocumentos
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "TIPODOCUMENTO"
        table.CamposID.Add(New PrimaryKey("CODIGO"))
        table.TableAlias = "TIDO"
        tablasEdit.Add(table)
    End Sub
End Class
