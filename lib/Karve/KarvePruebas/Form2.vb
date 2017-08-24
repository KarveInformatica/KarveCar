Imports Bases
Imports System.Windows.Forms

Public Class Form2
    Inherits frmBase

    Private Sub Form2_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated

        test()
    End Sub

    Protected Overrides Sub AddExtra()
        dtfCodigo.Text_Data = "AGREGAR"
    End Sub

    Protected Overrides Sub SaveBefore(AddReg As Boolean)
        If AddReg Then
            Dim db2 As New ASADB.Connection
            idEdit = db2.executeQuery("Select NUM_INI_CLI + 1 from AUTOCODIGOS_EMP where EMPRESA = '00' and CODIGO = 'A'")
            db.executeDirect("update AUTOCODIGOS_EMP  set NUM_INI_CLI = " & idEdit & "where EMPRESA = '00' and CODIGO = 'A'")
            idEdit = Strings.Right("0000000" & idEdit, 7)
            dtfCodigo.Text_Data = idEdit
        End If
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        idEdit = "0000001"
        Load_Reg()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Save_Reg()
    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Cancel_Reg()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Add_Reg()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Delete_Reg()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub test()
        'Panel1.Controls.Remove(RadioGroup1)
        'Panel1.Controls.Remove(dtfVendedor)
        RadioGroup1.Visible = False
        dtfVendedor.Visible = False
        'Panel1.Refresh()
        'Dim result = From c As Control In Panel1.Controls
        '             Where c.Visible = True
        '             Order By c.Location.Y
        '             Select c

        'Dim YAnt As Integer = 0
        'Dim ctrAnt As Control = Nothing
        'Dim i = 0
        'For Each ctr As Control In result
        '    If YAnt <> 0 Then
        '        If ctr.Location.Y = YAnt Then
        '            YAnt = ctr.Location.Y
        '            ctr.Location = New Drawing.Point(ctr.Location.X, ctrAnt.Location.Y)
        '        Else
        '            YAnt = ctr.Location.Y
        '            ctr.Location = New Drawing.Point(ctr.Location.X, ctrAnt.Location.Y + ctrAnt.Height + 6)
        '        End If
        '    Else
        '        YAnt = ctr.Location.Y
        '    End If
        '    ctr.TabIndex = i
        '    ctrAnt = ctr
        '    i += 1
        'Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dt As DateTime
        dt = RadTimePicker1.Value
        MsgBox(dt.TimeOfDay.ToString)
        dt = dt.Date + New TimeSpan(11, 25, 0)
        RadTimePicker1.Value = dt
    End Sub
End Class