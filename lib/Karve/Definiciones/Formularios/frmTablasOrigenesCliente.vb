Public Class frmTablasOrigenesCliente
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit
        table = New TablaEdit
        table.Tabla = "ORIGEN"
        table.CamposID.Add(New PrimaryKey("NUM_ORIGEN"))
        table.TableAlias = "OC"
        tablasEdit.Add(table)
    End Sub
End Class
