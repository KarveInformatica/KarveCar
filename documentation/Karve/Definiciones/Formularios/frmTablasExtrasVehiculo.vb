Public Class frmTablasExtrasVehiculo
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "EXTRASVEHI"
        table.CamposID.Add(New PrimaryKey("CODIGO"))
        table.TableAlias = "EXVEH"
        tablasEdit.Add(table)
    End Sub

End Class
