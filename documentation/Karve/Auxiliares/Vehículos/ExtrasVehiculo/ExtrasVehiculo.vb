Imports System.Windows.Forms
Imports Karve.ConfiguracionApp
Imports Karve.Definiciones

Public Class ExtrasVehiculo
    Inherits Bases.frmBase

    Protected Overrides Sub setTables()

        With New frmTablasExtrasVehiculo
            tablasEdit = .Tablas
        End With
        pkEdit = tablasEdit(0).CamposID(0)
        tablaUltmodi.TableAlias = "EXVEH"
        tablaUltmodi.CampoID = "ULTMODI"

        tablaUsumodi.TableAlias = "EXVEH"
        tablaUsumodi.CampoID = "USUARIO"

    End Sub

    Protected Overrides Sub setLupas()
        dtfTipoVeh.Lupa = Karve.ConfiguracionApp.lupaTiposVehiculo
    End Sub

    Protected Overrides Sub SaveBefore(AddReg As Boolean)
        If AddReg Then
            pkEdit.CodEdit = dameCodigoMax(db, "EXTRASVEHI", "CODIGO")
        End If
    End Sub

    Protected Overrides Sub SaveExtra(newReg As Boolean)

    End Sub

    Private Sub ClientesPrueba_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = "Extras Vehículo"
    End Sub

    Protected Overrides Sub AddExtra()
        pkEdit.CodEdit = "AGREGAR"
        dtfCodigo.Text_Data = pkEdit.CodEdit
    End Sub

    Protected Overrides Sub Estado_Editar()
        Me.dtfCodigo.ReadOnly_Data = True
    End Sub

    Protected Overrides Sub loadAfterSave()

    End Sub

    Protected Overrides Sub ValidateExtra()

    End Sub

    Private Sub dtfNombre_TextChanged() Handles dtfNombre.TextChanged
        Me.NombreRegistro = dtfNombre.Text_Data
    End Sub

End Class