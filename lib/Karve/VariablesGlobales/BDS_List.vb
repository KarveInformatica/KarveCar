Imports System.Windows.Forms
Public Class BDS_List
    Dim dtsBds As New DataSet

    Public ReadOnly Property DTS As DataSet
        Get
            Return dtsBds
        End Get
    End Property

    Public Sub New()
        Dim DT As New DataTable("dbs")
        DT.Columns.Add("name")
        DT.Columns.Add("connectionString")
        DT.Columns.Add("providerName")
        Try

        
        Dim dtsXML As New DataSet
        dtsXML.ReadXml(Application.StartupPath & "/Karve.config.xml")
        For Each row As DataRow In dtsXML.Tables("db").Rows
            Dim nRow As DataRow = DT.NewRow
            nRow.Item("name") = row.Item("name")
            nRow.Item("connectionString") = row.Item("connectionString")
            nRow.Item("providerName") = row.Item("providerName")
            DT.Rows.Add(nRow)
        Next
            dtsBds.Tables.Add(DT)
        Catch ex As Exception
            Dim msg As New VariablesGlobales.MsgBoxError
            msg.Print("No se encontro el fichero de configuración.", ex.Message)
            System.Environment.Exit(-1)
        End Try
    End Sub
End Class
