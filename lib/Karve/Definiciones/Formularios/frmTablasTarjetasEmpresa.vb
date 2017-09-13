Public Class frmTablasTarjetasEmpresa
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "TARJETA_EMP"
        table.CamposID.Add(New PrimaryKey("COD_TARJETA"))
        table.TableAlias = "TARE"
        tablasEdit.Add(table)
    End Sub
End Class
