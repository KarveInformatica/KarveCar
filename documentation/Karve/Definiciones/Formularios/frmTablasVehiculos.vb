Public Class frmTablasVehiculos
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "VEHICULO1"
        table.CamposID.Add(New PrimaryKey("CODIINT"))
        table.TableAlias = "V1"
        tablasEdit.Add(table)

        table = New TablaEdit
        table.Tabla = "VEHICULO2"
        table.CamposID.Add(New PrimaryKey("CODIINT"))
        table.TableAlias = "V2"
        tablasEdit.Add(table)

        table = New TablaEdit
        table.Tabla = "SITUACION"
        table.CamposID.Add(New PrimaryKey("NUMERO"))
        table.TableAlias = "SIT"
        tablasEdit.Add(table)
    End Sub
End Class
