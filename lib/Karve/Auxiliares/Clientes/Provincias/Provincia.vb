Imports System.Windows.Forms
Imports Karve.ConfiguracionApp
Imports Karve.Definiciones

Public Class Provincia
    Inherits Bases.frmBase

    Protected Overrides Sub setTables()

        With New frmTablasProvincias
            tablasEdit = .Tablas
        End With
        pkEdit = tablasEdit(0).CamposID(0)
        tablaUltmodi.TableAlias = "PROV"
        tablaUltmodi.CampoID = "ULTMODI"

        tablaUsumodi.TableAlias = "PROV"
        tablaUsumodi.CampoID = "USUARIO"

    End Sub
    Protected Overrides Sub setLupas()
        dtfPais.Lupa = Karve.ConfiguracionApp.lupaPais
    End Sub
    Protected Overrides Sub SaveBefore(AddReg As Boolean)
        If AddReg Then
            pkEdit.CodEdit = dameCodigoMax(db, "PROVINCIA", "SIGLAS")
        End If
    End Sub
    Protected Overrides Sub AddExtra()
    End Sub

    Protected Overrides Sub Estado_Editar()

    End Sub
End Class