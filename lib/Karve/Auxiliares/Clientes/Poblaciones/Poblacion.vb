Imports System.Windows.Forms
Imports Karve.ConfiguracionApp
Imports Karve.Definiciones
Public Class Poblacion
    Inherits Bases.frmBase

    Protected Overrides Sub setTables()

        With New frmTablasPoblacion
            tablasEdit = .Tablas
        End With

        tablaUltmodi.TableAlias = "POBL"
        tablaUltmodi.CampoID = "ULTMODI"

        tablaUsumodi.TableAlias = "POBL"
        tablaUsumodi.CampoID = "USUARIO"

    End Sub
    Protected Overrides Sub setLupas()

    End Sub
    Protected Overrides Sub SaveBefore(AddReg As Boolean)

    End Sub
    Protected Overrides Sub AddExtra()

    End Sub

    Protected Overrides Sub Estado_Editar()

    End Sub

    Private Sub dtfPoblacion_TextChanged() Handles dtfPoblacion.TextChanged
        Me.NombreRegistro = dtfPoblacion.Text_Data
    End Sub
End Class