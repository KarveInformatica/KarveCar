Imports System.Windows.Forms
Imports Karve.ConfiguracionApp
Imports Karve.Definiciones

Public Class TipoDocumentos
    Inherits Bases.frmBase

    Protected Overrides Sub setTables()

        With New frmTablasTipoDocumentos
            tablasEdit = .Tablas
        End With
        pkEdit = tablasEdit(0).CamposID(0)
        tablaUltmodi.TableAlias = "TIDO"
        tablaUltmodi.CampoID = "ULTMODI"

        tablaUsumodi.TableAlias = "TIDO"
        tablaUsumodi.CampoID = "USUARIO"

    End Sub

    Private Function DameNum() As String
        Return dameCodigoMax(db, "TIPODOCUMENTO", "CODIGO")
    End Function

    Protected Overrides Sub setLupas()

    End Sub

    Protected Overrides Sub SaveBefore(AddReg As Boolean)
        If AddReg Then
            pkEdit.CodEdit = DameNum()
        End If
    End Sub

    Protected Overrides Sub SaveExtra(newReg As Boolean)

    End Sub

    Private Sub ClientesPrueba_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = "Tipos de Documentos"
    End Sub

    Protected Overrides Sub AddExtra()
        dtfCodigo.Text_Data = "AGREGAR"
    End Sub

    Protected Overrides Sub loadAfterSave()

    End Sub

    Private Sub dtfNombre_TextChanged() Handles dtfNombre.TextChanged
        Me.NombreRegistro = dtfNombre.Text_Data
    End Sub

End Class