Imports VariablesGlobales
Imports Karve.ConfiguracionApp

Public Class LupaModelo
    Private db As New ASADB.Connection

    Private _lupa As String = lupaModelosVehiculo
    Private _form As String
    Private _codigo As String
    Private _marca As String
    Private _queryOnTextChanged As Boolean = True

    Property Marca As String
        Get
            Return _marca
        End Get
        Set(value As String)
            _marca = value
        End Set
    End Property

    Property QueryOnTextChanged As Boolean
        Get
            Return _queryOnTextChanged
        End Get
        Set(value As Boolean)
            _queryOnTextChanged = value
        End Set
    End Property

    Protected Sub abrirLupa()
        Try
            If _lupa <> "" Then
                Dim frmLupa As Object

                frmLupa = VariablesGlobales.OpenForm(_lupa)
                frmLupa.MarcarFilas = False
                frmLupa.OpenFormNuevo = _form
                frmLupa.OpenDialog()
                If frmLupa.AbrirFrm Then
                    If _form <> "" Then
                        VariablesGlobales.OpenTab(_form, "")
                    End If
                Else
                    Dim dts As DataSet
                    dts = frmLupa.dtsResult

                    _queryOnTextChanged = False

                    dtfDescrip.Text_Data = dts.Tables(0).Rows(0).Item("NOMBRE")
                    dtfMod.Text_Data = dts.Tables(0).Rows(0).Item("CODIGO")
                    dtfVar.Text_Data = dts.Tables(0).Rows(0).Item("VARIANTE")

                    _queryOnTextChanged = True

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LupaModelo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.F4 Then
            abrirLupa()
        End If
    End Sub


    Private Sub dtfDescrip_btnActionClick() Handles dtfDescrip.btnActionClick
        abrirLupa()
    End Sub

    Private Sub dtfDescrip_KeyDown(sender As Object, e As KeyEventArgs) Handles dtfDescrip.KeyDown
        If e.KeyCode = Windows.Forms.Keys.F4 Then
            abrirLupa()
        End If
    End Sub

    Private Sub dtfMod_KeyDown(sender As Object, e As KeyEventArgs) Handles dtfMod.KeyDown
        If e.KeyCode = Windows.Forms.Keys.F4 Then
            abrirLupa()
        End If
    End Sub

    Private Sub dtfVar_KeyDown(sender As Object, e As KeyEventArgs) Handles dtfVar.KeyDown
        If e.KeyCode = Windows.Forms.Keys.F4 Then
            abrirLupa()
        End If
    End Sub

    Private Sub queryDesc()
        Try
            Dim mySql As String
            mySql = "Select NOMBRE from modelo where codigo = '" & dtfMod.Text_Data & "' and variante = '" & dtfVar.Text_Data & "' and marca = '" & _marca & "'"
            Dim dts As New DataSet
            dtfDescrip.Text_Data = db.executeQuery(mySql)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtfMod_TextChanged() Handles dtfMod.TextChanged
        If _queryOnTextChanged Then
            queryDesc()
        End If
    End Sub

    Private Sub dtfVar_TextChanged() Handles dtfVar.TextChanged
        If _queryOnTextChanged Then
            queryDesc()
        End If
    End Sub
End Class
