Public Class frmTablasTiposVehiculo
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "CATEGO"
        table.CamposID.Add(New PrimaryKey("CODIGO"))
        table.TableAlias = "CAT"
        tablasEdit.Add(table)
    End Sub
End Class
