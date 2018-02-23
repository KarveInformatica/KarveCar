Imports System.Windows.Forms
Imports Karve.ConfiguracionApp
Imports Karve.Definiciones

Public Class MarcasVehiculo
    Inherits Bases.frmBase



    Protected Overrides Sub setTables()

        With New frmTablasMarcasVehiculo
            tablasEdit = .Tablas
        End With
        pkEdit = tablasEdit(0).CamposID(0)
        tablaUltmodi.TableAlias = "MAR"
        tablaUltmodi.CampoID = "ULTMODI"

        tablaUsumodi.TableAlias = "MAR"
        tablaUsumodi.CampoID = "USUARIO"

    End Sub

    Protected Overrides Sub setLupas()
        dtfProvee.Lupa = Karve.ConfiguracionApp.lupaProvee
    End Sub

    Protected Overrides Sub setOpenForm()
        dtfProvee.OpenForm = Karve.ConfiguracionApp.frmProvee
    End Sub

    Protected Overrides Sub SaveBefore(AddReg As Boolean)
        If AddReg Then
            pkEdit.CodEdit = dtfCodigo.Text_Data
        End If
    End Sub

    Protected Overrides Sub SaveExtra(newReg As Boolean)

    End Sub

    Private Sub ClientesPrueba_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = "Marcas"
    End Sub

    Protected Overrides Sub AddExtra()
        Me.dtfCodigo.ReadOnly_Data = False
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
