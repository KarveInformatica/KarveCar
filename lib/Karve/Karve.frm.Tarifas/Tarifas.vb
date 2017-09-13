Imports Karve.Definiciones
Public Class Tarifas
    Inherits Bases.frmBase

#Region "Setters"
    Protected Overrides Sub setTables()
        'Me.rbnAction.CommandTabs.AddRange(New Telerik.WinControls.RadItem() {Me.rbtEdicion})
        With New frmTablasTarifas
            tablasEdit = .Tablas
        End With
        pkEdit = tablasEdit(0).CamposID(0)

        tablaUltmodi.TableAlias = "NT"
        tablaUltmodi.CampoID = "ULTMODI"

        tablaUsumodi.TableAlias = "NT"
        tablaUsumodi.CampoID = "USUARIO"

        tablaEmpresa.TableAlias = "NT"
        tablaEmpresa.CampoID = "SUBLICEN"
    End Sub

    Protected Overrides Sub setLupas()

    End Sub

    Protected Overrides Sub setOpenForm()
    End Sub

#End Region

    Private Sub Tarifas_Load(sender As Object, e As EventArgs) Handles Me.Load
        dgvTramos.DBConnection = db
        dgvTramos.generateGrid()
    End Sub

    Private Sub cargargrids()
        dgvTramos.idRel = pkEdit.CodEdit
        dgvTramos.loadGrid()
    End Sub

    Protected Overrides Sub LoadExtra()
        cargargrids()
    End Sub

    Protected Overrides Sub SaveExtra(newReg As Boolean)
        dgvTramos.EndEdit()
        dgvTramos.guardar()
    End Sub
End Class