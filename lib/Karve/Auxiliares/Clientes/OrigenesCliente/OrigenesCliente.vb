Imports System.Windows.Forms
Imports Karve.ConfiguracionApp
Imports Karve.Definiciones

Public Class OrigenesCliente
    Inherits Bases.frmBase


    Protected Overrides Sub setTables()

        With New frmTablasOrigenesCliente
            tablasEdit = .Tablas
        End With
        pkEdit = tablasEdit(0).CamposID(0)
        tablaUltmodi.TableAlias = "OC"
        tablaUltmodi.CampoID = "ULTMODI"

        tablaUsumodi.TableAlias = "OC"
        tablaUsumodi.CampoID = "USUARIO"

    End Sub

    Protected Overrides Sub setLupas()

    End Sub

    Protected Overrides Sub SaveBefore(AddReg As Boolean)
        If AddReg Then
            pkEdit.CodEdit = dameCodigoMax(db, "ORIGEN", "NUM_ORIGEN")
        End If
    End Sub

    Protected Overrides Sub SaveExtra(newReg As Boolean)

    End Sub

    Private Sub ClientesPrueba_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = "Orígenes de Clientes"
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