Imports CrystalDecisions.CrystalReports.Engine
Imports Karve.ConfiguracionApp

Public Class CrystalPreviewer

#Region "Variables"
    Protected _reportPath As String
    Protected _useFullReportPath As Boolean = False
    Protected _reportWhere As String

    Protected rpt As New ReportDocument
    Public Event reportLoaded(ByVal export As Boolean)
    Private _fileName As String

#End Region

#Region "Propiedades"
    Property reportPath As String
        Get
            Return _reportPath
        End Get
        Set(value As String)
            _reportPath = value
        End Set
    End Property

    Property reportWhere As String
        Get
            Return _reportWhere
        End Get
        Set(value As String)
            _reportWhere = value
        End Set
    End Property

    ReadOnly Property fileName As String
        Get
            Return _fileName
        End Get
    End Property

    Overridable ReadOnly Property PageCount As Integer
        Get
            Return 0
        End Get
    End Property

    Overridable ReadOnly Property CurrentPage As Integer
        Get
            Return 0
        End Get
    End Property

    Public Property UseFullReportPath As Boolean
        Get
            Return _useFullReportPath
        End Get
        Set(value As Boolean)
            _useFullReportPath = value
        End Set
    End Property

#End Region

    Public Sub Print()
        bgwPrint.RunWorkerAsync()
    End Sub

    Protected Overridable Sub Printing()

    End Sub

    Protected Overridable Sub SetReport()

    End Sub

    Private Sub bgwPrint_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles bgwPrint.DoWork
        Printing()
    End Sub

    Private Sub bgwPrint_RunWorkerCompleted(sender As Object, e As ComponentModel.RunWorkerCompletedEventArgs) Handles bgwPrint.RunWorkerCompleted
        SetReport()
        RaiseEvent reportLoaded(False)
    End Sub

    Public Overridable Sub PrintToPrinter()

    End Sub

    Public Overridable Sub Export()

    End Sub

    Public Sub ExportToPdf(ByVal fileName As String)
        Me._fileName = fileName
        bgwPrintToFile.RunWorkerAsync()
    End Sub

    Public Overridable Function PrintToFile(ByVal fileName As String) As String
        Return ""
    End Function

    Public Overridable Sub FirstPage()

    End Sub

    Public Overridable Sub PrevPage()

    End Sub

    Public Overridable Sub NextPage()

    End Sub

    Public Overridable Sub LastPage()

    End Sub

    Public Overridable Sub Search(ByVal text As String)

    End Sub

    Public Overridable Sub Zoom(ByVal zoomLevel As Integer)

    End Sub

    Private Sub bgwPrintToFile_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles bgwPrintToFile.DoWork
        Printing()
    End Sub

    Private Sub bgwPrintToFile_RunWorkerCompleted(sender As Object, e As ComponentModel.RunWorkerCompletedEventArgs) Handles bgwPrintToFile.RunWorkerCompleted
        _fileName = PrintToFile(Me._fileName)
        RaiseEvent reportLoaded(True)
    End Sub
End Class
