Public Class frmTablasMercadosCliente
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit
        table = New TablaEdit
        table.Tabla = "MERCADO"
        table.CamposID.Add(New PrimaryKey("CODIGO"))
        table.TableAlias = "MC"
        tablasEdit.Add(table)
    End Sub
End Class
