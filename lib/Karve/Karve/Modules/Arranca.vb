Imports System.Threading
Imports VariablesGlobales
Imports Karve.ConfiguracionApp



Module Arranca

#Region "   .   INF:    "

#End Region

#Region "   .   Variables   "
    Private msgBoxError As New MsgBoxError()
    Private db As ASADB.Connection
#End Region

#Region "   .   MAIN:    Arranca App."

    Public Sub Main()
        Dim ok As Boolean = True
        If ok Then ok = LoadSplash()
        If ok Then ok = LoadBD()
        If ok Then ok = LoadCK()
        If ok Then ok = LoadUserConection()
        loadCrystal()
        CargarConstantesFormularios()
        If ok = False Then System.Environment.Exit(0)
        UnLoadSplash()
    End Sub

#End Region

#Region "   .   LOAD APP:    Arranca App."

    Public Function LoadSplash() As Boolean
        Try
            Splash.Show()
            Splash.Refresh()
            Return True
        Catch : Return False
        End Try
    End Function

    Public Function UnLoadSplash() As Boolean
        Try
            Splash.Close()
            Return True
        Catch : Return False
        End Try
    End Function

    Public Function LoadUserConection(Optional NoSplash As Boolean = False) As Boolean
        If NoSplash = False Then Splash.lblProcess.Text = "Solicitando Autentificación."
        If NoSplash = False Then Splash.Refresh()
        Login_kv.ShowDialog()
        If Login_kv.DialogResult = DialogResult.OK Then
            Dim db As New ASADB.Connection
            LoadCO(Login_kv.Oficina)
            LoadCE(Login_kv.Oficina)
            LoadCU(Login_kv.Usuario)
            LoadTRADUC()
            LoadTheme()
            ConfiguracionApp.oficina = db.executeQuery("select nombre from oficinas where codigo = '" & CO.GStr("OFICINA") & "'")
            Return True
        Else : Return False
        End If
    End Function

    Private Function LoadBD() As Boolean
        Dim dtsBds As DataSet = New DataSet
        Dim BDS_Lista As New VariablesGlobales.BDS_List
        Dim sValue As String = ""
        Dim sProvider As String = ""
        Dim ok As Boolean = False
        Try
            Splash.lblProcess.Text = "Cargando Parámetros Base de Datos"
            Splash.Refresh()
            dtsBds = BDS_Lista.DTS
            If dtsBds.Tables(0).Rows.Count = 1 Then
                sValue = dtsBds.Tables(0).Rows(0).Item("connectionString")
                sProvider = dtsBds.Tables(0).Rows(0).Item("providerName")
            Else
                Splash.lblProcess.Text = "Solicitando Base de Datos"
                Splash.Refresh()
                Bds.DTS = dtsBds
                Bds.ShowDialog()
                sValue = Bds.BDS_Select
                sProvider = Bds.BDS_ProviderName
            End If
            If sValue <> "" Then
                ok = LoadTestConection(sValue, sProvider)
                ok = True
                VariablesGlobales.cnxString = sValue
                VariablesGlobales.providerName = sProvider
                db = New ASADB.Connection
            Else : ok = False
            End If
            Return ok
        Catch ex As Exception
            MsgBox(ex.Message, vbExclamation)
            Return False
        End Try
    End Function

    Public Function LoadTestConection(Value As String, Provider As String) As Boolean
        Try
            Splash.lblProcess.Text = "Testeando Conexión"
            Splash.Refresh()
            Dim BD As New ASADB.Connection(Value, Provider)
            LoadTestConection = BD.TestConnection()
            If Not LoadTestConection Then
                msgBoxError.Print("No se pudo encontrar el origen de datos seleccionado.", "Connection String: " & Value & vbCrLf & "Provider: " & Provider)
            End If
        Catch ex As Exception
            msgBoxError.Print("No se pudo connectar con el origen de datos seleccionado.", ex.Message)
            Return False
        End Try
    End Function

    Private Sub loadCrystal()
        VersionCrystal = crystalVersion.crystal13
    End Sub
#End Region

#Region "   .   RELOGIN:    "

    Public Sub Relogin()

        LoadUserConection(True)

    End Sub

#End Region

#Region "   .   LOAD CONFIG:"

    Private Function LoadCK(Optional NoSplash As Boolean = False) As Boolean
        Try
            If NoSplash = False Then Splash.lblProcess.Text = "Cargando Configuración de Karve."
            If NoSplash = False Then Splash.Refresh()
            CK.LoadConfig("SELECT * FROM CONFIKARVE")
            Return True
        Catch : Return False
        End Try
    End Function

    Private Function LoadCE(Oficina As String, _
                            Optional NoSplash As Boolean = False) As Boolean
        Try
            Dim sEmp As String = db.executeQuery("SELECT SUBLICEN FROM OFICINAS WHERE CODIGO = " & vd.setApostrofa(Oficina))
            If NoSplash = False Then Splash.lblProcess.Text = "Cargando Configuración de Empresa."
            If NoSplash = False Then Splash.Refresh()
            CE.LoadConfig("SELECT * FROM CONFI_EMP WHERE EMPRESA = " & VD.setApostrofa(sEmp))
            decimalesPrecios = CE.GInt("DECIMALES_PRECIO")
            decimalesTotales = CE.GInt("DECIMALES")
            decimalesCantidad = 0
            decimalesPorcentaje = 2

            Return True
        Catch : Return False
        End Try
    End Function

    Private Function LoadCO(Oficina As String, _
                            Optional NoSplash As Boolean = False) As Boolean
        Try
            If NoSplash = False Then Splash.lblProcess.Text = "Cargando Configuración de Oficina."
            If NoSplash = False Then Splash.Refresh()
            CO.LoadConfig("SELECT * FROM CONFI_OFI WHERE OFICINA = " & vd.setApostrofa(Oficina))
            Return True
        Catch : Return False
        End Try
    End Function

    Private Function LoadCU(Usuario As String, _
                            Optional NoSplash As Boolean = False) As Boolean
        Try
            If NoSplash = False Then Splash.lblProcess.Text = "Cargando Configuración de Usuario."
            If NoSplash = False Then Splash.Refresh()
            US.LoadConfig("SELECT * FROM USURE WHERE CODIGO = " & vd.setApostrofa(Usuario))
            Return True
        Catch : Return False
        End Try
    End Function

    Private Function LoadTRADUC(Optional NoSplash As Boolean = False)
        Try
            If US.GStr("idiomaprg") <> "" Then
                dtsTraduc = db.fillDts("select original, traduc from k_traduc where idioma = " & US.GStr("idiomaprg"))
                dtsTraduc.Tables(0).CaseSensitive = False

                If NoSplash = False Then Splash.lblProcess.Text = "Cargando Idioma."
                If NoSplash = False Then Splash.Refresh()
            End If
            Return True
        Catch : Return False
        End Try
    End Function

#End Region

#Region "   .   LOAD THEME:"

    Public Sub LoadTheme()
        Dim sThemeName As String = CK.GStr("THEME_NAME_CK")

        Select Case LCase(sThemeName)
            Case "karve" : TemaAplicacion = New Karve.Theme.ThemeKarve
            Case Else : TemaAplicacion = New Karve.Theme.ThemeDefault
        End Select
    End Sub

#End Region

End Module
