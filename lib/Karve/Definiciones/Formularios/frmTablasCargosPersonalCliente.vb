Public Class frmTablasCargosPersonalCliente
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "PERCARGOS"
        table.CamposID.Add(New PrimaryKey("CODIGO"))
        table.TableAlias = "PCC"
        tablasEdit.Add(table)
    End Sub
End Class
