Public Class frmTablasMarcasVehiculo
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "MARCAS"
        table.CamposID.Add(New PrimaryKey("CODIGO"))
        table.TableAlias = "MAR"
        tablasEdit.Add(table)
    End Sub
End Class
