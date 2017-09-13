Imports System.Net.Mail
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Net
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
Imports System.Windows.Forms

Public Class EMail

#Region "Variables"
    Private _from As String
    Private _username As String
    Private _password As String
    Private _smtp As String
    Private _port As Integer
    Private _ssl As Boolean
    Private _rcpt As String
    Private _cc As String
    Private _cco As String
    Private _subject As String
    Private _body As String
    Private _htmlBody As Boolean
    Private _attachments As New ArrayList
    Private _ignoreSSLErrors As Boolean

    Private _errorMessage As String
#End Region

#Region "Propiedades"
    Property From As String
        Get
            Return _from
        End Get
        Set(value As String)
            _from = value
        End Set
    End Property

    Property Rcpt As String
        Get
            Return _rcpt
        End Get
        Set(value As String)
            _rcpt = value
        End Set
    End Property

    Property CC As String
        Get
            Return _cc
        End Get
        Set(value As String)
            _cc = value
        End Set
    End Property

    Property CCO As String
        Get
            Return _cco
        End Get
        Set(value As String)
            _cco = value
        End Set
    End Property

    Property Username As String
        Get
            Return _username
        End Get
        Set(value As String)
            _username = value
        End Set
    End Property

    Property Password As String
        Get
            Return _password
        End Get
        Set(value As String)
            _password = value
        End Set
    End Property

    Property Smtp As String
        Get
            Return _smtp
        End Get
        Set(value As String)
            _smtp = value
        End Set
    End Property

    Property Port As Integer
        Get
            Return _port
        End Get
        Set(value As Integer)
            _port = value
        End Set
    End Property

    Property SSL As Boolean
        Get
            Return _ssl
        End Get
        Set(value As Boolean)
            _ssl = value
        End Set
    End Property

    Property Subject As String
        Get
            Return _subject
        End Get
        Set(value As String)
            _subject = value
        End Set
    End Property

    Property Body As String
        Get
            Return _body
        End Get
        Set(value As String)
            _body = value
        End Set
    End Property

    Property HtmlBody As Boolean
        Get
            Return _htmlBody
        End Get
        Set(value As Boolean)
            _htmlBody = value
        End Set
    End Property

    Property Attatchments As ArrayList
        Get
            Return _attachments
        End Get
        Set(value As ArrayList)
            _attachments = value
        End Set
    End Property

    ReadOnly Property ErrorMessage As String
        Get
            Return _errorMessage
        End Get
    End Property

    Property IgnoreSSLErrors As Boolean
        Get
            Return _ignoreSSLErrors
        End Get
        Set(value As Boolean)
            _ignoreSSLErrors = value
        End Set
    End Property

#End Region

    Public Function Send() As Boolean
        Try

            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.Timeout = 20000
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential(_username, _password)
            Smtp_Server.Port = _port
            Smtp_Server.EnableSsl = _ssl
            Smtp_Server.Host = _smtp

            e_mail = New MailMessage()
            e_mail.From = New MailAddress(_from)

            For Each address As String In _rcpt.Split(";")
                e_mail.To.Add(address.Trim)
            Next

            If _cc <> "" Then
                For Each address As String In _cc.Split(";")
                    e_mail.CC.Add(address.Trim)
                Next
            End If

            If _cco <> "" Then
                For Each address As String In _cco.Split(";")
                    e_mail.Bcc.Add(address.Trim)
                Next
            End If

            e_mail.Subject = _subject
            e_mail.IsBodyHtml = _htmlBody
            e_mail.Body = _body

            For Each fileName In _attachments
                Dim attachFile As New Attachment(fileName)
                e_mail.Attachments.Add(attachFile)
            Next

            If e_mail.IsBodyHtml Then
                setImagesCID(e_mail)
            End If

            ServicePointManager.ServerCertificateValidationCallback = New RemoteCertificateValidationCallback(AddressOf ValidateServerCertificate)
            Send = True
        Catch ex As Exception
            _errorMessage = ex.Message
            Send = False
        End Try
    End Function


    Private Sub setImagesCID(ByRef eMail As MailMessage)
        Dim headerImages As New ArrayList
        Dim i As Integer = 0

        eMail.Body = Right(eMail.Body, Len(eMail.Body) - InStr(eMail.Body, "<body>") + 1)
        eMail.Body = Left(eMail.Body, InStr(eMail.Body, "</body>") + 6)
        Try
            Dim RegexObj As New Regex("<img[^>]+src=[""']([^""']+)[""']", RegexOptions.Singleline Or RegexOptions.IgnoreCase)
            Dim MatchResults As Match = RegexObj.Match(eMail.Body)
            While MatchResults.Success
                Dim strTmp As String
                strTmp = Right(MatchResults.ToString, Len(MatchResults.ToString) - InStr(MatchResults.ToString, "src") - 4)
                strTmp = strTmp.Split(";")(1).Split(",")(1)
                strTmp = Left(strTmp, Len(strTmp) - 1)
                Dim reader As Byte() = Convert.FromBase64String(strTmp)
                Dim image As New MemoryStream
                image = New MemoryStream(reader)
                Dim headerImage As New LinkedResource(image, System.Net.Mime.MediaTypeNames.Image.Jpeg)
                headerImage.ContentId = i
                headerImages.Add(headerImage)
                strTmp = Right(MatchResults.ToString, Len(MatchResults.ToString) - InStr(MatchResults.ToString, "src") - 4)
                eMail.Body = eMail.Body.Replace(strTmp, "cid:" & i & """")
                MatchResults = MatchResults.NextMatch()
                i += 1
            End While
        Catch
        End Try

        Dim av As AlternateView
        av = AlternateView.CreateAlternateViewFromString(eMail.Body, Nothing, System.Net.Mime.MediaTypeNames.Text.Html)
        For Each headerImage In headerImages
            av.LinkedResources.Add(headerImage)
        Next

        eMail.AlternateViews.Add(av)
        eMail.Body = ""
    End Sub

    Public Function ValidateServerCertificate(sender As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyError As SslPolicyErrors) As Boolean

        If sslPolicyError = SslPolicyErrors.None Or _ignoreSSLErrors Then
            Return True
        Else
            If MessageBox.Show("El certificado de seguridad del servidor no es válido." & vbCrLf & "¿Desea continuar?", "Validación de Seguridad", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Return True
            Else
                Return False
            End If
        End If

    End Function
End Class
