Public Class frmTablasTiposCliente
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit
        table = New TablaEdit
        table.Tabla = "TIPOCLI"
        table.CamposID.Add(New PrimaryKey("NUM_TICLI"))
        table.TableAlias = "TC"
        tablasEdit.Add(table)
    End Sub
End Class
