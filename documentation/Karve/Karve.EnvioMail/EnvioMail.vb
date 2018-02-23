Imports Karve.ConfiguracionApp
Imports VariablesGlobales
Imports Karve.Theme
Imports System.Windows.Forms
Imports System.Net.Mail
Imports Telerik.WinControls.UI
Imports CustomControls

Public Class EnvioMail
    Inherits CrystalPreview.CrystalViewer

#Region "Variables"
    Protected _from As String
    Protected _username As String
    Protected _password As String
    Protected _smtp As String
    Protected _port As Integer
    Protected _ssl As Boolean
    Protected _rcpt As String
    Protected _subject As String
    Protected _textoEstandar As String

    Private rbnEdicion As New CustomControls.RibbonRichField
#End Region

#Region "Propiedades"
    Property Rcpt As String
        Get
            Return _rcpt
        End Get
        Set(value As String)
            _rcpt = value
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

    Property TextoEstandar As String
        Get
            Return _textoEstandar
        End Get
        Set(value As String)
            _textoEstandar = value
        End Set
    End Property

#End Region

#Region "Load"
    Protected Overrides Sub setIconos()
        MyBase.setIconos()

        btnEnviar.Image = TemaAplicacion.Iconos(Theme_Definicion.euIconos.Mail_Ic)

        rbtImpresion.Items.Remove(rbgEMail)
        rbtImpresion.Items.Insert(0, rbgEMail)
    End Sub

    Protected Overrides Sub setCrystal()
        crpViewer.Dock = Windows.Forms.DockStyle.Fill
        pnlRpt.Controls.Add(crpViewer)
    End Sub

    Protected Overrides Sub reportLoaded(ByVal export As Boolean)
        If Not export Then
            crpViewer.Zoom(75)
            lblZoom.Text = Translate("Zoom") & ": 75%"
            setPageNum()
        End If
    End Sub

    Protected Overrides Sub loadExtra()
        If Not DesignMode Then
            _from = US.GStr("EMAIL")
            _username = US.GStr("SMTPUSER")
            _password = US.GStr("SMTPPWD")
            _smtp = US.GStr("USU_SMTP")
            _port = US.GInt("USU_PUERTO")
            _ssl = US.GBool("USU_SSL")

            dtfFrom.Text_Data = _from
            dtfRcpt.Text_Data = _rcpt
            dtfSubject.Text_Data = _subject
            dtfTextoEstandar.Text_Data = _textoEstandar

            RecorrerForm()
        End If
    End Sub

    Protected Sub RecorrerForm(Optional ByRef ctrList As Object = Nothing)
        Try
            If IsNothing(ctrList) Then
                ctrList = Me.Controls
            End If
            For Each ctr In ctrList
                If ctr.GetType() Is GetType(TabControl) Then
                    For Each tmp In CType(ctr, TabControl).TabPages
                        RecorrerForm(tmp.Controls)
                    Next
                ElseIf ctr.GetType() Is GetType(CustomControls.GroupBox) Or ctr.GetType() Is GetType(CustomControls.Panel) Or ctr.GetType() Is GetType(CustomControls.RadioGroup) Then
                    RecorrerForm(ctr.Controls)
                ElseIf ctr.GetType() Is GetType(RadPageView) Then
                    For Each page As RadPageViewPage In CType(ctr, RadPageView).Pages
                        RecorrerForm(page.Controls)
                    Next
                Else
                    If ctr.GetType() Is GetType(CustomControls.DataRichField) Then
                        AddHandler CType(ctr, Control).Enter, AddressOf setRibbon
                    ElseIf ControlesDataField(ctr) Then
                        AddHandler CType(ctr, Control).Enter, AddressOf clearRibbon
                    End If
                End If
            Next
        Catch ex As Exception
            'kMsgBox.Print("Error inesperado.", CustomControls.kMsgBox.kMsgBoxStyle.ErrorInformation, ex.Message)
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private ctrList As New List(Of Type)
    Private ctrWRibbonList As New List(Of Type)

    Private Sub fillCtrList()
        ctrList.Add(GetType(Datafield))
        ctrList.Add(GetType(DatafieldLabel))
        ctrList.Add(GetType(DataFieldLabelColor))
        ctrList.Add(GetType(DualDatafield))
        ctrList.Add(GetType(DualDatafieldLabel))
        ctrList.Add(GetType(DualDataFieldEditable))
        ctrList.Add(GetType(DualDataFieldEditableLabel))
        ctrList.Add(GetType(DataCheck))
        ctrList.Add(GetType(RadioGroup))
        ctrList.Add(GetType(DataArea))
        ctrList.Add(GetType(DataAreaLabel))
        ctrList.Add(GetType(DataDate))
        ctrList.Add(GetType(DataDateLabel))
        ctrList.Add(GetType(DataTime))
        ctrList.Add(GetType(DataTimeLabel))
        ctrList.Add(GetType(DataDir))
        ctrList.Add(GetType(DataLabel))
        ctrList.Add(GetType(EmpresaOficina))
        ctrList.Add(GetType(MaskedDataField))

        ctrWRibbonList.Add(GetType(DataArea))
        ctrWRibbonList.Add(GetType(DataAreaLabel))
    End Sub 'AÑADIR AQUI LOS NUEVOS CONTROLES

    Private Function ControlesDataField(ByRef ctr As Control) As Boolean
        Return ctrList.Contains(ctr.GetType)
    End Function

    Private Sub setRibbon(sender As Object, e As EventArgs)
        clearRibbon(sender, e)
        Dim selectedTab As RibbonTab = Nothing
        rbnEdicion = CType(sender, CustomControls.DataRichField).getRibbon
        For Each cmdTab As RibbonTab In rbnEdicion.CommandTabs
            Try
                VGribbonMDI.CommandTabs.Add(cmdTab)
                If cmdTab.Tag = 1 Then selectedTab = cmdTab
            Catch
            End Try
        Next
        Try
            selectedTab.IsSelected = True
        Catch
        End Try
    End Sub

    Private Sub clearRibbon(sender As Object, e As EventArgs)
        For Each cmdTab In rbnEdicion.CommandTabs
            Try
                VGribbonMDI.CommandTabs.Remove(cmdTab)
            Catch
            End Try
        Next
    End Sub

#End Region

#Region "Enviar"
    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click

        Cursor = Cursors.WaitCursor

        Dim e_mail As New EMail
        e_mail.Username = _username
        e_mail.Password = _password

        e_mail.Smtp = _smtp
        e_mail.Port = _port
        e_mail.SSL = _ssl

        e_mail.From = _from

        e_mail.Rcpt = dtfRcpt.Text_Data

        e_mail.Subject = dtfSubject.Text_Data
        e_mail.HtmlBody = True
        e_mail.Body = drfBody.ExportToHTML

        Dim fileName As String = crpViewer.PrintToFile(reportName)
        e_mail.Attatchments.Add(fileName)

        For Each file In flsAttachments.getFiles
            e_mail.Attatchments.Add(file)
        Next

        Dim ok As Boolean
        ok = e_mail.Send()

        Cursor = Cursors.Arrow

        If ok Then
            MsgBox("Mail Sent")
        Else
            MsgBox(e_mail.ErrorMessage)
        End If

    End Sub

#End Region

    Private Sub dtfTextoEstandar_QueryThrown(dts As DataSet) Handles dtfTextoEstandar.QueryThrown
        Try
            drfBody.ImportFromHTML(dts.Tables(0).Rows(0).Item(1))
        Catch
            drfBody.ImportFromHTML("")
        End Try
    End Sub

    Private Sub EnvioMail_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        fillCtrList()
    End Sub

    Private Sub flsAttachments_Load(sender As Object, e As EventArgs) Handles flsAttachments.Load

    End Sub
End Class