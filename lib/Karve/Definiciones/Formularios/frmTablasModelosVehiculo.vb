Public Class frmTablasModelosVehiculo
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit
        table = New TablaEdit
        table.Tabla = "MODELO"
        table.CamposID.Add(New PrimaryKey("COD_MOD"))
        table.TableAlias = "MOD"
        tablasEdit.Add(table)
    End Sub
End Class
