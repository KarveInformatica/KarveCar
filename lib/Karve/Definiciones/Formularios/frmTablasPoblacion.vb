Public Class frmTablasPoblacion
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "POBLACIONES"

        table.CamposID.Add(New PrimaryKey("PAIS"))
        table.CamposID.Add(New PrimaryKey("CP"))
        
        table.TableAlias = "POBL"
        tablasEdit.Add(table)
    End Sub
End Class
