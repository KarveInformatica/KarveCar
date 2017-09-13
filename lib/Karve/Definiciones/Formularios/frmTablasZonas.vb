Public Class frmTablasZonas
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "ZONAS"
        table.CamposID.Add(New PrimaryKey("NUM_ZONA"))
        table.TableAlias = "ZN"
        tablasEdit.Add(table)
    End Sub
End Class
