Public Class frmTablasTarjetasCredito
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "TARCREDI"
        table.CamposID.Add(New PrimaryKey("CODIGO"))
        table.TableAlias = "TAC"
        tablasEdit.Add(table)
    End Sub
End Class
