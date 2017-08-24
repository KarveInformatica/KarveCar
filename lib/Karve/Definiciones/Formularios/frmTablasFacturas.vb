Public Class frmTablasFacturas
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "FACTURAS"
        table.CamposID.Add(New PrimaryKey("NUMERO_FAC"))
        table.TableAlias = "F"
        tablasEdit.Add(table)
    End Sub
End Class
