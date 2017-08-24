Imports System.Windows.Forms
Imports Karve.ConfiguracionApp
Imports Karve.Definiciones

Public Class MotivosRepostaje
    Inherits Bases.frmBase



    Protected Overrides Sub setTables()

        With New frmTablasMotivosRepostaje
            tablasEdit = .Tablas
        End With
        pkEdit = tablasEdit(0).CamposID(0)
        
        tablaUltmodi.TableAlias = "COD_MOT"
        tablaUltmodi.CampoID = "ULTMODI_MOT"

        tablaUsumodi.TableAlias = "COD_MOT"
        tablaUsumodi.CampoID = "USUARIO_MOT"

    End Sub

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
        Me.Text = "Motivos de Repostaje"
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