Imports System.Windows.Forms
Imports Karve.ConfiguracionApp
Imports Karve.Definiciones

Public Class TiposVisita
    Inherits Bases.frmBase

    Protected Overrides Sub setTables()

        With New frmTablasTiposVisita
            tablasEdit = .Tablas
        End With
        pkEdit = tablasEdit(0).CamposID(0)
        tablaUltmodi.TableAlias = "TVIS"
        tablaUltmodi.CampoID = "ULTMODI"

        tablaUsumodi.TableAlias = "TVIS"
        tablaUsumodi.CampoID = "USUARIO"

    End Sub
    Protected Overrides Sub setLupas()

    End Sub
    Private Sub ClientesPrueba_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = "Tipos de Visitas"
    End Sub
    Protected Overrides Sub AddExtra()
        pkEdit.CodEdit = DameNum()
        dtfCodigo.Text_Data = pkEdit.CodEdit
    End Sub
    Private Function DameNum() As String
        Return dameCodigoMax(db, "TIPOVISITAS", "CODIGO_VIS", , True)
    End Function
End Class