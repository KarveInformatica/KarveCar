﻿Imports System.Windows.Forms
Imports Karve.ConfiguracionApp
Imports Karve.Definiciones

Public Class CargosPersonalCliente
    Inherits Bases.frmBase

    Protected Overrides Sub setTables()

        With New frmTablasCargosPersonalCliente
            tablasEdit = .Tablas
        End With
        pkEdit = tablasEdit(0).CamposID(0)
        tablaUltmodi.TableAlias = "PCC"
        tablaUltmodi.CampoID = "ULTMODI"

        tablaUsumodi.TableAlias = "PCC"
        tablaUsumodi.CampoID = "USUARIO"

    End Sub

    Private Function dameCodigoCargoPersonal() As String
        Return dameCodigoMax(db, tablasEdit(0).Tabla, pkEdit.CampoID, Rellenar:=True)
    End Function

    Protected Overrides Sub setLupas()

    End Sub

    Protected Overrides Sub SaveBefore(AddReg As Boolean)
        If AddReg Then
            pkEdit.CodEdit = dameCodigoCargoPersonal()
        End If
    End Sub

    Protected Overrides Sub SaveExtra(newReg As Boolean)

    End Sub

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = "Cargos Personal de Clientes"
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