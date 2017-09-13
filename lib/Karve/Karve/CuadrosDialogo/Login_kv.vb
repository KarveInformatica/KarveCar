Imports Karve.ConfiguracionApp

Public Class Login_kv
    Private db As New ASADB.Connection
    Private OA As New OficinasAcceso

    ' TODO: inserte el código para realizar autenticación personalizada usando el nombre de usuario y la contraseña proporcionada 
    ' (Consulte http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' El objeto principal personalizado se puede adjuntar al objeto principal del subproceso actual como se indica a continuación: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' donde CustomPrincipal es la implementación de IPrincipal utilizada para realizar la autenticación. 
    ' Posteriormente, My.User devolverá la información de identidad encapsulada en el objeto CustomPrincipal
    ' como el nombre de usuario, nombre para mostrar, etc.

    Public ReadOnly Property Usuario As String
        Get
            Return Me.CstUsuario.Text_Data
        End Get
    End Property

    Public ReadOnly Property Oficina As String
        Get
            Return Me.CstOficina.Text_Data
        End Get
    End Property

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        Dim correcto As Boolean = False
        Dim query As String = "SELECT u.PASS FROM USURE AS u WHERE u.CODIGO = '" & CstUsuario.Text_Data & "'"
        Dim dtsUsu As DataSet = Nothing



        Dim UsuQuery = "SELECT u.CODIGO FROM USURE AS u WHERE u.CODIGO = '" & CstUsuario.Text_Data & "'"
        dtsUsu = db.fillDts(UsuQuery)

        If CstUsuario.Text_Data = "" Or CstPass.Text_Data = "" Or CstOficina.Text_Data = "" Then
            lblError.Text = "Usuario, contraseña u Oficina incorrecto."
            lblError.Visible = True
            CstUsuario.Focus()
        Else
            If checkCentro() Then

                If checkUser() Then
                    lblError.Visible = False
                    If checkPass() Then
                        Me.DialogResult = Windows.Forms.DialogResult.OK

                        Me.Close()
                    Else
                        lblError.Text = "Contraseña incorrecta."
                        lblError.Visible = True
                        CstPass.Focus()
                    End If

                Else
                    lblError.Text = "Usuario inexistente."
                    lblError.Visible = True
                    CstUsuario.Focus()
                End If
            Else : CstOficina.Focus()
            End If
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        System.Environment.Exit(0)
    End Sub

    Private Function checkPass()
        Dim correcto As Boolean = False
        Dim query As String = "SELECT u.PASS from USURE as u where u.CODIGO = '" & CstUsuario.Text_Data & "'"
        Dim DtsPass As DataSet = Nothing

        DtsPass = db.fillDts(query)
        If Not IsNothing(DtsPass) Then
            If CstPass.Text_Data = (DtsPass.Tables(0).Rows(0).Item(0)) Then
                If checkUser() Then
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                    correcto = True

                Else
                    lblError.Text = "Contraseña incorrecta."
                    lblError.Visible = True
                    CstPass.Focus()
                    correcto = False
                End If
            End If
        End If
        Return correcto
    End Function

    Public Function checkUser()
        Dim correcto As Boolean = False
        Dim UsuQuery = "SELECT u.CODIGO FROM USURE AS u WHERE u.CODIGO = '" & CstUsuario.Text_Data & "'"
        Dim DtsUsu As DataSet = Nothing
        DtsUsu = db.fillDts(UsuQuery)
        If Not IsNothing(DtsUsu) Then
            If DtsUsu.Tables(0).Rows.Count<>0 THEN 
                If DtsUsu.Tables(0).Rows(0).Item(0).ToString <> "" Then
                    correcto = True
                End If
            End If
        End If
        Return correcto
    End Function

    Public Function checkCentro()
        Dim correcto As Boolean = False
        If db.ColumnaIgual("OFICINAS", "CODIGO", " WHERE CODIGO = '" & CstOficina.Text_Data & "'") Then 'Comprobamos que la oficina exista
            correcto = OA.Busca(CstOficina.Text_Data)
            If correcto = False Then
                lblError.Text = "Oficina No Válida para este Usuario."
                lblError.Visible = True
            End If
        Else
            lblError.Text = "Oficina incorrecta."
            lblError.Visible = True
            CstOficina.Focus()
        End If
        Return correcto
    End Function

    Private Sub Login_kv_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated

        CstOficina.Visible = CK.GStr("K_OFI") = ""
        If CK.GStr("K_OFI") <> "" Then CstOficina.Text_Data = CK.GStr("K_OFI")
        '* sólo para karve, luego lo quitamos
        CstUsuario.Text_Data = "CV"
        Me.CstPass.Text_Data = "1929"
        Text_ValidaUsu()
    End Sub

    Private Sub frmLogin_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        CstUsuario.Focus()
    End Sub

    Private Sub CstUsuario_TextChanged() Handles CstUsuario.TextChanged
        Text_ValidaUsu()
    End Sub

    Private Sub CstUsuario_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CstUsuario.Validating
        Text_ValidaUsu()
    End Sub

    Private Sub Text_ValidaUsu()
        CstNomUsure.Text_Data = ""
        Dim UsuQuery = "SELECT u.NOMBRE FROM USURE AS u WHERE u.CODIGO = '" & CstUsuario.Text_Data & "'"
        Dim DtsUsu As DataSet = Nothing
        DtsUsu = db.fillDts(UsuQuery)
        If Not IsNothing(DtsUsu) Then
            If DtsUsu.Tables.Count <> 0 Then
                If DtsUsu.Tables(0).Rows.Count <> 0 Then
                    CstNomUsure.Text_Data = DtsUsu.Tables(0).Rows(0).Item(0).ToString
                    If OA.Usuario <> CstUsuario.Text_Data Then OA.LoadOfis(CstUsuario.Text_Data, CK.GBool("ACCESO_OFICINAS"))
                End If
            End If
        End If
    End Sub

End Class
