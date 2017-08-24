Public Class frmTablasContratosRC
    Inherits DefinicionTablas

    Public Overrides Sub setTables(ByRef tablasEdit As List(Of TablaEdit))
        Dim table As TablaEdit

        table = New TablaEdit
        table.Tabla = "CONTRATOS1"
        table.CamposID.Add(New PrimaryKey("NUMERO"))
        table.TableAlias = "C1"
        table.Sufijo = "CON1"
        tablasEdit.Add(table)

        table = New TablaEdit
        table.Tabla = "CONTRATOS2"
        table.CamposID.Add(New PrimaryKey("NUMERO"))
        table.TableAlias = "C2"
        table.Sufijo = "CON2"
        tablasEdit.Add(table)

        table = New TablaEdit
        table.Tabla = "CONTRATOS4"
        table.CamposID.Add(New PrimaryKey("NUMERO"))
        table.TableAlias = "C4"
        table.Sufijo = "CON4"
        tablasEdit.Add(table)

        table = New TablaEdit
        table.Tabla = "VEHI_CONT"
        table.CamposID.Add(New PrimaryKey("CONTRATO", "NUMERO"))
        Dim pk As New PrimaryKey("CODIINT_VC", "NUMERO")
        pk.Expresion = "(select VCACT_CON1 from CONTRATOS1 where NUMERO = '%codEdit%') order by CLAVE_VC desc"
        table.CamposID.Add(pk)
        table.TableAlias = "VC"
        tablasEdit.Add(table)
    End Sub

End Class
