Imports Karve.Theme
Imports VariablesGlobales
Imports Karve.ConfiguracionApp

Public Class kEnvioMail
    Inherits Karve.EnvioMail.EnvioMail

    Private dsn As String
    Private sender As String
    Private receiver As String
    Private mailSubject As String
    Private texto As String
    Private reportOptions As String

    Private Sub kEnvioMail_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        TemaAplicacion = New Karve.Theme.ThemeDefault
    End Sub

    Protected Overrides Sub loadExtra()
        If Not DesignMode Then
            Me.reportPath = reportOptions.Split(";")(0)
            Me.reportWhere = reportOptions.Split(";")(1)
            Me.reportName = reportOptions.Split(";")(2)
            Me.crpViewer.UseFullReportPath = True
            _from = sender.Split(";")(0)
            _username = sender.Split(";")(1)
            _password = sender.Split(";")(2)
            _smtp = sender.Split(";")(3)
            _port = sender.Split(";")(4)
            _ssl = CBool(sender.Split(";")(5))

            _rcpt = receiver
            _subject = mailSubject
            _textoEstandar = texto

            dtfFrom.Text_Data = _from
            dtfRcpt.Text_Data = _rcpt
            dtfSubject.Text_Data = _subject
            dtfTextoEstandar.DB = New ASADB.Connection
            dtfTextoEstandar.Text_Data = _textoEstandar

            MyBase.RecorrerForm()
            Me.rbnRibbon.Visible = True
            Me.stbStatus.Visible = True
        End If
    End Sub

    Public Sub New()

        Dim args As String()
        args = Environment.GetCommandLineArgs()
        Try
            dsn = args(1) 'ODBC NAME
            sender = args(2) '"email;user;pwd;smtp;port;ssl[0/1]"
            receiver = args(3)
            mailSubject = args(4)
            texto = args(5)
            reportOptions = args(6) '"reportpath;reportwhere;reportname"

            VariablesGlobales.cnxString = "{Driver=Adaptive Server Anywhere 9.0};DSN=" & dsn & ";UID=CV;PWD=1929;"
            VariablesGlobales.providerName = "ODBC"

            InitializeComponent()

            VGribbonMDI = rbnRibbon

        Catch ex As Exception

        End Try
    End Sub
End Class
