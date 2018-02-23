Imports System.Windows.Forms
Imports Karve.ConfiguracionApp
Imports Karve.Definiciones

Public Class Zonas
    Inherits Bases.frmBase



    Protected Overrides Sub setTables()
        With New frmTablasZonas
            tablasEdit = .Tablas
        End With
        pkEdit = tablasEdit(0).CamposID(0)

        tablaUltmodi.TableAlias = "ZN"
        tablaUltmodi.CampoID = "ULTMODI"

        tablaUsumodi.TableAlias = "ZN"
        tablaUsumodi.CampoID = "USUARIO"

    End Sub

    Protected Overrides Sub setLupas()

    End Sub

    Private Function dameCodigoZona() As String
        Return dameCodigoMax(db, tablasEdit(0).Tabla, pkEdit.CampoID, Rellenar:=True)
    End Function

    Protected Overrides Sub SaveBefore(AddReg As Boolean)
        If AddReg Then
            pkEdit.CodEdit = dameCodigoZona()
        End If
    End Sub

    Protected Overrides Sub SaveExtra(newReg As Boolean)

    End Sub

    Private Sub ClientesPrueba_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = "Zonas"
    End Sub

    Protected Overrides Sub AddExtra()
        dtfCodigo.Text_Data = dameCodigoZona()
    End Sub

    Protected Overrides Sub loadAfterSave()

    End Sub

    Protected Overrides Sub ValidateExtra()
        
    End Sub

    Private Sub dtfNombre_TextChanged() Handles dtfNombre.TextChanged
        Me.NombreRegistro = dtfNombre.Text_Data
    End Sub


End Class



