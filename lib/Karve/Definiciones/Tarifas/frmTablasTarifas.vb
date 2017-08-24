Public Class frmTablasTarifas
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "NTARI"
        table.CamposID.Add(New PrimaryKey("CODIGO"))
        table.TableAlias = "NT"
        tablasEdit.Add(table)
    End Sub
End Class
