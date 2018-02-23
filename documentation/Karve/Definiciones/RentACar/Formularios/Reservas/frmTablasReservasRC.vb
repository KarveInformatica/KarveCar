Public Class frmTablasReservasRC
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "RESERVAS1"
        table.CamposID.Add(New PrimaryKey("NUMERO_RES"))
        table.TableAlias = "R1"
        table.Sufijo = "RES1"
        tablasEdit.Add(table)

        table = New TablaEdit
        table.Tabla = "RESERVAS2"
        table.CamposID.Add(New PrimaryKey("NUMERO_RES"))
        table.TableAlias = "R2"
        table.Sufijo = "RES2"
        tablasEdit.Add(table)

    End Sub

End Class
