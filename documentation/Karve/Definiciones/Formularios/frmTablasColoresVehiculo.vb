Public Class frmTablasColoresVehiculo
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "COLORFL"
        table.CamposID.Add(New PrimaryKey("CODIGO"))
        table.TableAlias = "CLF"
        tablasEdit.Add(table)
    End Sub
End Class
