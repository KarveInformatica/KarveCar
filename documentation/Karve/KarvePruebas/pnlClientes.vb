Public Class pnlClientes
    Inherits Bases.pnlBase

    Private Sub pnlClientes_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        tablasEdit.Add("clientes1")
        tablasEdit.Add("clientes2")
        campoId = "numero_cli"

        campoOficina = "oficina"
        tablaOficina = 1

        campoEmpresa = "sublicen"
        tablaEmpresa = 1

        campoUltmodi = "ultmodi"
        tablaUltmodi = 1

        campoUsusmodi = "usuario"
        tablaUsumodi = 1
    End Sub

    Protected Overrides Sub AddExtra()
        dtfCodigo.Text_Data = "AGREGAR"
    End Sub

    Protected Overrides Sub SaveBefore(AddReg As Boolean)
        If AddReg Then
            Dim db2 As New ASADB.Connection
            idEdit = db2.executeQuery("Select NUM_INI_CLI + 1 from AUTOCODIGOS_EMP where EMPRESA = '00' and CODIGO = 'A'")
            db.executeDirect("update AUTOCODIGOS_EMP  set NUM_INI_CLI = " & idEdit & "where EMPRESA = '00' and CODIGO = 'A'")
            idEdit = Strings.Right("0000000" & idEdit, 7)
            dtfCodigo.Text_Data = idEdit
        End If
    End Sub
End Class
