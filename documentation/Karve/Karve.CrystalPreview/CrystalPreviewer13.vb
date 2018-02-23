Imports System.Windows.Forms
Imports Karve.ConfiguracionApp
Imports VariablesGlobales
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class CrystalPreviewer13
    Inherits CrystalPreviewer

    Private Sub CrystalPreviewer13_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        Dim exportFormatFlags As Integer = CInt(CrystalDecisions.Shared.ViewerExportFormats.PdfFormat _
            Or CrystalDecisions.Shared.ViewerExportFormats.ExcelFormat Or CrystalDecisions.Shared.ViewerExportFormats.ExcelRecordFormat _
            Or CrystalDecisions.Shared.ViewerExportFormats.XLSXFormat Or CrystalDecisions.Shared.ViewerExportFormats.WordFormat)
        rptViewer.AllowedExportFormats = exportFormatFlags
    End Sub

    Protected Overrides Sub Printing()
        Try

            Dim connPorp As String() = cnxString.Split(";")
            If Not _useFullReportPath Then
                rpt.Load(CE.GStr("DIRDOCU") + "/" + _reportPath)
            Else
                rpt.Load(_reportPath)
            End If
            'MsgBox(rpt.PrintOptions.PaperSize)
            Dim connInfo As New CrystalDecisions.Shared.ConnectionInfo
            connInfo.ServerName = connPorp(0).Split("=")(1)
            connInfo.DatabaseName = connPorp(1).Split("=")(1)
            connInfo.UserID = connPorp(2).Split("=")(1)
            connInfo.Password = connPorp(3).Split("=")(1)

            If VariablesGlobales.providerName = "ODBC" Then
                connInfo.ServerName = connInfo.DatabaseName
            End If

            If VariablesGlobales.providerName = "OLEDB" Then
                connInfo.Type = ConnectionInfoType.SQL
                rpt.DataSourceConnections.Item(0).SetConnection(connInfo.ServerName, connInfo.DatabaseName, connInfo.UserID, connInfo.Password)
            ElseIf VariablesGlobales.providerName = "ODBC" Then
                connInfo.ServerName = connInfo.DatabaseName
                Dim CrTables = rpt.Database.Tables
                For Each CrTable In CrTables
                    Dim CrTableLogonInfo = CrTable.LogonInfo
                    CrTableLogonInfo.ConnectionInfo = connInfo
                    CrTable.ApplyLogOnInfo(CrTableLogonInfo)
                Next
            End If

            'Dim db As Database = rpt.Database
            'Dim tbls As Tables = db.Tables
            'Dim tablelogs As TableLogOnInfo
            'For Each tab As Table In tbls
            '    tablelogs = tab.LogOnInfo
            '    tablelogs.ConnectionInfo = connInfo
            '    tab.ApplyLogOnInfo(tablelogs)
            '    tab.Location = tab.Name
            'Next

            rpt.RecordSelectionFormula = "(" & (reportWhere) & ")"
            rpt.Refresh()
        Catch
            MsgBox("Error inesperado", MsgBoxStyle.Critical, "Karve")
        End Try
    End Sub

    Public Overrides ReadOnly Property PageCount As Integer
        Get
            Try
                Return CType(rptViewer.Controls(0), PageView).GetLastPageNumber
            Catch
                Return rptViewer.GetCurrentPageNumber
            End Try
        End Get
    End Property

    Overrides ReadOnly Property CurrentPage As Integer
        Get
            Return rptViewer.GetCurrentPageNumber
        End Get
    End Property

    Protected Overrides Sub SetReport()
        rptViewer.ReportSource = rpt
        rptViewer.Refresh()
    End Sub

    Public Overrides Sub PrintToPrinter()
        rptViewer.PrintReport()
    End Sub

    Public Overrides Sub Export()
        rptViewer.ExportReport()
    End Sub

    Public Overrides Function PrintToFile(ByVal fileName As String) As String
        Dim destinationOptions As New DiskFileDestinationOptions()
        destinationOptions.DiskFileName = Application.StartupPath & "\exports\" & fileName & ".pdf"

        With rpt
            .ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat
            .ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
            .ExportOptions.ExportDestinationOptions = destinationOptions
            .Export()
        End With

        Return destinationOptions.DiskFileName
    End Function

    Public Overrides Sub FirstPage()
        rptViewer.ShowFirstPage()
    End Sub

    Public Overrides Sub PrevPage()
        rptViewer.ShowPreviousPage()
    End Sub

    Public Overrides Sub NextPage()
        rptViewer.ShowNextPage()
    End Sub

    Public Overrides Sub LastPage()
        rptViewer.ShowLastPage()
    End Sub

    Public Overrides Sub Search(ByVal text As String)
        rptViewer.SearchForText(text)
    End Sub

    Public Overrides Sub Zoom(ByVal zoomLevel As Integer)
        rptViewer.Zoom(zoomLevel)
    End Sub

End Class
