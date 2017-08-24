Public Class frmTablasTiposVisita
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "TIPOVISITAS"
        table.CamposID.Add(New PrimaryKey("CODIGO_VIS"))
        table.TableAlias = "TVIS"
        tablasEdit.Add(table)
    End Sub
End Class
