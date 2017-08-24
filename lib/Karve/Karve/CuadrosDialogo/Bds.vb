Public Class Bds
    Private dtsBds As DataSet = New DataSet
    Private sBdSelect As String
    Private sProvider As String

    Private Class cbxItem
        Public name As String
        Public connectionString As String
        Public providerName As String

        Public Sub New(name As String, connectionString As String, providerName As String)
            Me.name = name
            Me.connectionString = connectionString
            Me.providerName = providerName
        End Sub

        Public Overrides Function ToString() As String
            Return Me.name
        End Function
    End Class

    Public WriteOnly Property DTS As DataSet
        Set(Value As DataSet)
            dtsBds = Value
        End Set
    End Property

    Public ReadOnly Property BDS_Select As String
        Get
            Return sBdSelect
        End Get
    End Property

    Public ReadOnly Property BDS_ProviderName As String
        Get
            Return sProvider
        End Get
    End Property

    Private Sub Bds_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        Me.cboBds.Items.Clear()
        For Each row In dtsBds.Tables(0).Rows
            Dim it As New cbxItem(row.item("name"), row.item("connectionString"), row.item("providerName"))
            Me.cboBds.Items.Add(it)
        Next
    End Sub

    Private Sub cboBds_KeyDown(sender As Object, e As KeyEventArgs) Handles cboBds.KeyDown
        If e.KeyCode = Keys.Return Then
            selectBD()
        ElseIf e.KeyCode = Keys.Escape Then
            sBdSelect = "" : Me.Close()
        End If
    End Sub
    
    Private Sub cboBds_Selected(sender As Object, e As EventArgs) Handles cboBds.DropDownClosed
        selectBD()
    End Sub

    Private Sub selectBD()
        If cboBds.SelectedIndex <> -1 Or cboBds.Text <> "" Then
            If cboBds.SelectedIndex <> -1 Then
                sBdSelect = CType(cboBds.SelectedItem, cbxItem).connectionString
                sProvider = CType(cboBds.SelectedItem, cbxItem).providerName
            Else
                sBdSelect = "EngineName=" & cboBds.Text & ";DatabaseName=" & cboBds.Text & ";Uid=cv;Pwd=1929;Links=tcpip()"
                sProvider = "ODBC"
            End If
            Me.Close()
        End If
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
End Class