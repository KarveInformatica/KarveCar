Public Class frmTablasActividadVehiculo
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "ACTIVEHI"
        table.CamposID.Add(New PrimaryKey("NUM_ACTIVEHI"))
        table.TableAlias = "ATV"
        tablasEdit.Add(table)
    End Sub
End Class
