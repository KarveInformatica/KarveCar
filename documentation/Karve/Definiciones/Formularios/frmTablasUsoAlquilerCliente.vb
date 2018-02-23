Public Class frmTablasUsoAlquilerCliente
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "USO_ALQUILER"
        table.CamposID.Add(New PrimaryKey("CODIGO"))
        table.TableAlias = "UAC"
        tablasEdit.Add(table)
    End Sub
End Class
