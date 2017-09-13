Imports System.Windows.Forms
Imports Karve.ConfiguracionApp
Imports Karve.Definiciones

Public Class TiposVehiculo
    Inherits Bases.frmBase

    Protected Overrides Sub setTables()

        With New frmTablasTiposVehiculo
            tablasEdit = .Tablas
        End With
        pkEdit = tablasEdit(0).CamposID(0)
        tablaUltmodi.TableAlias = "CAT"
        tablaUltmodi.CampoID = "ULTMODI"

        tablaUsumodi.TableAlias = "CAT"
        tablaUsumodi.CampoID = "USUARIO"

    End Sub

    Private Function DameNum() As String
        Return dameCodigoMax(db, tablasEdit(0).Tabla, tablasEdit(0).CampoID)
    End Function

    Protected Overrides Sub setLupas()

    End Sub

    Protected Overrides Sub SaveBefore(AddReg As Boolean)
        If AddReg Then
            pkEdit.CodEdit = Me.dtfCodigo.Text_Data
        End If
    End Sub

    Protected Overrides Sub SaveExtra(newReg As Boolean)

    End Sub

    Private Sub ClientesPrueba_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = "Tipos de Vehículo"
    End Sub

    Protected Overrides Sub AddExtra()
        Me.dtfCodigo.ReadOnly_Data = False
    End Sub

    Protected Overrides Sub loadAfterSave()

    End Sub

    Protected Overrides Sub ValidateExtra()
        
    End Sub

    Private Sub dtfNombre_TextChanged() Handles dtfNombre.TextChanged
        Me.NombreRegistro = dtfNombre.Text_Data
    End Sub

End Class