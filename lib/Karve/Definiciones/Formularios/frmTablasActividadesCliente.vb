Public Class frmTablasActividadesCliente
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "ACTIVI"
        table.CamposID.Add(New PrimaryKey("NUM_ACTIVI"))
        table.TableAlias = "ATC"
        tablasEdit.Add(table)
    End Sub
End Class
