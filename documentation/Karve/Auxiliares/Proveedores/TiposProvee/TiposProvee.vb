Imports System.Windows.Forms
Imports Karve.ConfiguracionApp
Imports Karve.Definiciones

Public Class TiposProvee
    Inherits Bases.frmBase


    Protected Overrides Sub setTables()

        With New frmTablasTiposProvee
            tablasEdit = .Tablas
        End With
        pkEdit = tablasEdit(0).CamposID(0)
        tablaUltmodi.TableAlias = "TPR"
        tablaUltmodi.CampoID = "ULTMODI"

        tablaUsumodi.TableAlias = "TPR"
        tablaUsumodi.CampoID = "USUARIO"

    End Sub

    Private Function DameNum() As String
        Return dameCodigoMax(db, tablasEdit(0).Tabla, pkEdit.CampoID)
    End Function

    Protected Overrides Sub setLupas()
        dtfCtagasto.Lupa = Karve.ConfiguracionApp.lupaCtasContables
    End Sub

    Protected Overrides Sub SaveBefore(AddReg As Boolean)
        If AddReg Then
            pkEdit.CodEdit = DameNum()
        End If
    End Sub

    Protected Overrides Sub SaveExtra(newReg As Boolean)

    End Sub

    Private Sub ClientesPrueba_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = "Tipos de Vehículo"
    End Sub

    Protected Overrides Sub loadAfterSave()

    End Sub

    Protected Overrides Sub ValidateExtra()

    End Sub

    Protected Overrides Sub AddExtra()
        Me.dtfCodigo.Text_Data = "AGREGAR"
    End Sub

    Private Sub dtfNombre_TextChanged() Handles dtfNombre.TextChanged
        Me.NombreRegistro = dtfNombre.Text_Data
    End Sub

End Class