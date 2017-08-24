Imports System.Windows.Forms
Imports Karve.ConfiguracionApp
Imports Karve.Definiciones

Public Class TarjetasEmpresa
    Inherits Bases.frmBase

    Protected Overrides Sub setTables()

        With New frmTablasTarjetasEmpresa
            tablasEdit = .Tablas
        End With
        pkEdit = tablasEdit(0).CamposID(0)
        tablaUltmodi.TableAlias = "TARE"
        tablaUltmodi.CampoID = "ULTMODI"

        tablaUsumodi.TableAlias = "TARE"
        tablaUsumodi.CampoID = "USUARIO"

    End Sub
    Protected Overrides Sub setLupas()

    End Sub
    Private Sub ClientesPrueba_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = "Tarjetas de empresa"
    End Sub
    Protected Overrides Sub AddExtra()
        pkEdit.CodEdit = DameNum()
        dtfCodigo.Text_Data = pkEdit.CodEdit
    End Sub
    Private Function DameNum() As String
        Return dameCodigoMax(db, "TARJETA_EMP", "COD_TARJETA", , True)
    End Function
End Class