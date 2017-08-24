Imports System.Windows.Forms
Imports Karve.ConfiguracionApp
Imports Karve.Definiciones

Public Class Pais
    Inherits Bases.frmBase

    Protected Overrides Sub setTables()

        With New frmTablasPais
            tablasEdit = .Tablas
        End With
        pkEdit = tablasEdit(0).CamposID(0)
        tablaUltmodi.TableAlias = "P"
        tablaUltmodi.CampoID = "ULTMODI"

        tablaUsumodi.TableAlias = "P"
        tablaUsumodi.CampoID = "USUARIO"

    End Sub
    Protected Overrides Sub setLupas()
        dtfIdioma.Lupa = Karve.ConfiguracionApp.lupaIdiomas
    End Sub
    Protected Overrides Sub SaveBefore(AddReg As Boolean)
        If AddReg Then
            pkEdit.CodEdit = dtfCodigo.Text_Data
        End If
    End Sub
    Protected Overrides Sub AddExtra()
        Me.dtfCodigo.ReadOnly_Data = False
    End Sub

    Protected Overrides Sub Estado_Editar()
        Me.dtfCodigo.ReadOnly_Data = True
    End Sub
End Class