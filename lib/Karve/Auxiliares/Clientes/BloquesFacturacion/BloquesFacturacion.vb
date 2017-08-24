Imports System.Windows.Forms
Imports Karve.ConfiguracionApp
Imports Karve.Definiciones

Public Class BloquesFacturacion
    Inherits Bases.frmBase



    Protected Overrides Sub setTables()

        With New frmTablasBloquesFacturacion
            tablasEdit = .Tablas
        End With
        pkEdit = tablasEdit(0).CamposID(0)
        tablaUltmodi.TableAlias = "BLQF"
        tablaUltmodi.CampoID = "ULTMODI"

        tablaUsumodi.TableAlias = "BLQF"
        tablaUsumodi.CampoID = "USUARIO"

    End Sub

    Private Function dameCodigoBlqFac() As String
        Return dameCodigoMax(db, tablasEdit(0).Tabla, pkEdit.CampoID, Rellenar:=True)
    End Function

    Protected Overrides Sub setLupas()

    End Sub

    Protected Overrides Sub SaveBefore(AddReg As Boolean)
        If AddReg Then
            pkEdit.CodEdit = dameCodigoBlqFac()
        End If
    End Sub

    Protected Overrides Sub SaveExtra(newReg As Boolean)

    End Sub

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = "Bloques de Facturación"
    End Sub

    Protected Overrides Sub AddExtra()
        dtfCodigo.Text_Data = "AGREGAR"
    End Sub

    Protected Overrides Sub loadAfterSave()

    End Sub

    Protected Overrides Sub ValidateExtra()
      
    End Sub

    Private Sub dtfNombre_TextChanged() Handles dtfNombre.TextChanged
        Me.NombreRegistro = dtfNombre.Text_Data
    End Sub

End Class