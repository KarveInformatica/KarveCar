Imports Bases
Imports System.Windows.Forms
Imports Karve.ConfiguracionApp
Imports Karve.Definiciones

Public Class MercadosCliente
    Inherits frmBase



    Protected Overrides Sub setTables()

        With New frmTablasMercadosCliente
            tablasEdit = .Tablas
        End With
        pkEdit = tablasEdit(0).CamposID(0)
        tablaUltmodi.TableAlias = "MC"
        tablaUltmodi.CampoID = "ULTMODI"

        tablaUsumodi.TableAlias = "MC"
        tablaUsumodi.CampoID = "USUARIO"

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
        Me.Text = "Mercados de Cliente"
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