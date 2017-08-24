Public Class frmTablasGruposVehiculos
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "GRUPOS"
        table.CamposID.Add(New PrimaryKey("CODIGO"))
        table.TableAlias = "GRU"
        tablasEdit.Add(table)
    End Sub
End Class
