Public Class pnlBrowser

#Region "Variables"
    Public mySelect As String
    Private mySql As String
    Public myWhere As String
    Private myOrder As String
    '##XUS 
    Private db As New ASADB.Connection
    Private dts As New DataSet
#End Region

#Region "Eventos"
    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        If Not dgvDatos.Columns("NOMBRE").FilterDescriptor Is Nothing Then
            MsgBox(dgvDatos.Columns("NOMBRE").FilterDescriptor.ToString)
        End If
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        mySelect = "select * from clientes1"
        myWhere = "BAJA is null"
        mySql = mySelect & " where " & myWhere
        fillDgvDatos()
    End Sub

#End Region

#Region "Funciones de Acceso a Datos"

    Private Sub fillDgvDatos()
        dts = db.fillDts(mySql)
        dgvDatos.DataSource = dts.Tables(0)
    End Sub

#End Region

    Private Sub pnlBrowser_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated

    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        mySql = mySelect & " where " & myWhere
        fillDgvDatos()
    End Sub

End Class
