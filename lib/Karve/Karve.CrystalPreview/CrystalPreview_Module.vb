Imports Karve.ConfiguracionApp

Public Module CrystalPreview_Module

    Public Function getCrystalVersion() As Object
        If VersionCrystal = crystalVersion.crystal13 Then
            Return New CrystalPreviewer13
        End If
        Return Nothing
    End Function

    Public Sub exportToPdf(ByVal reportPath As String, ByVal reportWhere As String, ByVal fileName As String)
        Dim crpExport As New CrystalPreview.CrystalPreviewer
        crpExport = getCrystalVersion()
        crpExport.reportPath = reportPath
        crpExport.reportWhere = reportWhere
        crpExport.ExportToPdf(fileName)
    End Sub
End Module
