Public Class frmTablasBloquesFacturacion
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "BLOQUEFAC"
        table.CamposID.Add(New PrimaryKey("CODIGO"))
        table.TableAlias = "BLQF"
        tablasEdit.Add(table)
    End Sub
End Class
